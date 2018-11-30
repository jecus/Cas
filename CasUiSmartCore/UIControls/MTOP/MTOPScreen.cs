using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Filters;
using SmartCore.Relation;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPScreen : ScreenControl
	{
		#region Fields

		private List<MTOPCheck> _maintenanceChecks = new List<MTOPCheck>();
		private List<MTOPCheck> _maintenanceChecksDeleted = new List<MTOPCheck>();
		private List<MTOPCheck> _maintenanceZeroChecks = new List<MTOPCheck>();
		private CommonCollection<MaintenanceDirective> _initialMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
		private CommonCollection<MaintenanceDirective> _initialZeroMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
		private CommonCollection<MaintenanceDirective> _resultMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
		private CommonCollection<MaintenanceDirective> _resultZeroMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
		private Dictionary<int, Lifelength> _groupLifelengths = new Dictionary<int, Lifelength>();
		private Dictionary<int, Lifelength> _groupLifelengthsForZeroCheck = new Dictionary<int, Lifelength>();
		private AverageUtilization _averageUtilization;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(IMaintenanceDirectiveFilterParams));
		private CommonFilterCollection _filterZero = new CommonFilterCollection(typeof(IMaintenanceDirectiveFilterParams));

		#endregion

		#region Constructor

		public MTOPScreen()
		{
			InitializeComponent();
		}

		public MTOPScreen(Aircraft parentAircraft) : this()
		{
			if (parentAircraft == null)
				throw new ArgumentNullException("parentAircraft", "must be not null");
			CurrentAircraft = parentAircraft;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			statusControl.Aircraft = CurrentAircraft;
			statusControl.ConditionState = e.Result as ConditionState ?? ConditionState.NotEstimated;

			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
				                  SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
				                  GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}
			else
			{
				labelTitle.Text = "";
				labelTitle.Status = Statuses.NotActive;
			}


			mtopSummary1.UpdateControl(_maintenanceChecks, _groupLifelengths, _groupLifelengthsForZeroCheck);
			mtopGeneralControl.UpdateControl(CurrentAircraft, _maintenanceChecks, AnimatedThreadWorker);
			mtopPerformanceControl1.UpdateControl(_groupLifelengths, _resultMaintenanceDirectives, _maintenanceChecks.Where(i => !i.IsZeroPhase).ToList());
			mtopZeroPhasePerformanceControl.UpdateControl(_groupLifelengthsForZeroCheck, _resultZeroMaintenanceDirectives, _maintenanceZeroChecks);
			mtopCompliance1.UpdateControl(_maintenanceChecks, _maintenanceChecksDeleted, CurrentAircraft, _averageUtilization);
		}

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_maintenanceChecks.Clear();
			_maintenanceZeroChecks.Clear();
			_groupLifelengths.Clear();
			_groupLifelengthsForZeroCheck.Clear();
			_initialMaintenanceDirectives.Clear();
			_initialZeroMaintenanceDirectives.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			#region Загрузка

			try
			{
				var checks = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MTOPCheckDTO, MTOPCheck>(new Filter("ParentAircraftId", CurrentAircraft.ItemId), true, true);

				_maintenanceChecks.AddRange(checks.Where(i => !i.IsDeleted));
				_maintenanceChecksDeleted.AddRange(checks.Where(i => i.IsDeleted));

				_initialMaintenanceDirectives.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft));

				var bindedItemsDict = GlobalObjects.BindedItemsCore.GetBindedItemsFor(CurrentAircraft.ItemId,
					_initialMaintenanceDirectives.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend));

				CalculateMaintenanceDirectives(_initialMaintenanceDirectives, bindedItemsDict);

			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			#endregion

			AnimatedThreadWorker.ReportProgress(50, "Calculate MTOP");

			#region Расчет

			foreach (var check in _maintenanceChecks)
			{
				foreach (var record in check.PerformanceRecords)
					record.Parent = check;
			}

			foreach (var check in _maintenanceChecksDeleted)
			{
				foreach (var record in check.PerformanceRecords)
					record.Parent = check;
			}

			if (_maintenanceChecks.Count > 0)
			{
				//Берем утилизацию с Frame
				var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
					i.ParentAircraftId == CurrentAircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
				_averageUtilization = frame.AverageUtilization;

				var lastCompliance = _maintenanceChecks.SelectMany(i => i.PerformanceRecords).OrderByDescending(i => i.RecordDate).FirstOrDefault();

				GlobalObjects.MTOPCalculator.CalculateMtopChecks(_maintenanceChecks, _averageUtilization);

				_groupLifelengths = GlobalObjects.MTOPCalculator.CalculateGroupNew(_maintenanceChecks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList());

				GlobalObjects.MTOPCalculator.CalculateNextPerformance(_maintenanceChecks.Where(i => !i.IsZeroPhase).ToList(), frame.StartDate, _groupLifelengths, CurrentAircraft, _averageUtilization, lastCompliance);
				GlobalObjects.MTOPCalculator.CalculateNextPerformance(_maintenanceChecks.Where(i => !i.IsZeroPhase).ToList(), frame.StartDate, _groupLifelengths, CurrentAircraft, _averageUtilization, lastCompliance,true);
				GlobalObjects.MTOPCalculator.CalculatePhase(_initialMaintenanceDirectives, _maintenanceChecks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList(), _averageUtilization);
			


				_maintenanceZeroChecks = _maintenanceChecks.Where(i => i.IsZeroPhase).ToList();

				var lowerZeroCheck = _maintenanceZeroChecks.Where(i => !i.Thresh.IsNullOrZero()).OrderBy(i => i.Thresh).FirstOrDefault();
				if (lowerZeroCheck != null)
				{
					GlobalObjects.MTOPCalculator.CalculateMtopChecks(_maintenanceZeroChecks, _averageUtilization);

					_groupLifelengthsForZeroCheck = GlobalObjects.MTOPCalculator.CalculateGroupNew(_maintenanceZeroChecks);

					GlobalObjects.MTOPCalculator.CalculateNextPerformance(_maintenanceZeroChecks, frame.StartDate, _groupLifelengthsForZeroCheck, CurrentAircraft, _averageUtilization, lastCompliance);
					GlobalObjects.MTOPCalculator.CalculateNextPerformance(_maintenanceZeroChecks, frame.StartDate, _groupLifelengthsForZeroCheck, CurrentAircraft, _averageUtilization, lastCompliance,true);

					_initialZeroMaintenanceDirectives.AddRange(_initialMaintenanceDirectives.Where(i => i.MTOPPhase?.FirstPhase == 0).ToArray());

					GlobalObjects.MTOPCalculator.CalculatePhase(_initialZeroMaintenanceDirectives, _maintenanceChecks.Where(i => !i.Thresh.IsNullOrZero() && i.IsZeroPhase).ToList(), _averageUtilization, true);
				}

				foreach (var d in _initialZeroMaintenanceDirectives)
					_initialMaintenanceDirectives.Remove(d);


				//var q = _maintenanceChecks.Where(i => !i.IsZeroPhase).SelectMany(i => i.NextPerformances);
				//var last = _maintenanceChecks.Where(i => !i.IsZeroPhase).SelectMany(i => i.PerformanceRecords).OrderByDescending(i => i.RecordDate).FirstOrDefault();
				//var group = last.GroupName;
				//var value = Lifelength.Null;
				//foreach (var performance in q.OrderBy(i => i.PerformanceSource.Days))
				//{

				//	if (value.Days == performance.PerformanceSource.Days)
				//	{
				//		performance.Group = group --;
				//	}
				//	else
				//	{
				//		performance.Group = group++;
				//	}

					
				//	value = performance.PerformanceSource;
				//}

			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			#endregion

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(70, "filter records");

			FilterItems(_initialMaintenanceDirectives, _resultMaintenanceDirectives);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(90, "filter records");

			FilterZeroItems(_initialZeroMaintenanceDirectives, _resultZeroMaintenanceDirectives);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#region private void ExtendableRichContainerGeneralDataExtending(object sender, EventArgs e)

		private void ExtendableRichContainerGeneralDataExtending(object sender, EventArgs e)
		{
			mtopGeneralControl.Visible = !mtopGeneralControl.Visible;
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void HeaderControlButtonSaveClick(object sender, EventArgs e)

		private void HeaderControlButtonSaveClick(object sender, EventArgs e)
		{
			if (mtopGeneralControl.SaveData())
			{
				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

		private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
		{
			mtopPerformanceControl1.Visible = !mtopPerformanceControl1.Visible;
		}

		private void ExtendableRichContainerZeroPerformanceExtending(object sender, EventArgs e)
		{
			mtopZeroPhasePerformanceControl.Visible = !mtopZeroPhasePerformanceControl.Visible;
		}


		#endregion

		#region private void MtopCompliance1_ComplianceAdded(object sender, EventArgs e)

		private void MtopCompliance1_ComplianceAdded(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

		private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
		{
			mtopSummary1.Visible = !mtopSummary1.Visible;
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialMaintenanceDirectives);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		private void ButtonApplyFilterZeroClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filterZero, _initialZeroMaintenanceDirectives);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultMaintenanceDirectives.Clear();
			_resultZeroMaintenanceDirectives.Clear();

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialMaintenanceDirectives, _resultMaintenanceDirectives);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}


			AnimatedThreadWorker.ReportProgress(90, "filter records");

			FilterZeroItems(_initialZeroMaintenanceDirectives, _resultZeroMaintenanceDirectives);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<FlightTripRecord> initialCollection, ICommonCollection<FlightTripRecord> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<MaintenanceDirective> initialCollection, ICommonCollection<MaintenanceDirective> resultCollection)
		{
			if (_filter == null || _filter.Count == 0)
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#region private void FilterItems(IEnumerable<FlightTripRecord> initialCollection, ICommonCollection<FlightTripRecord> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterZeroItems(IEnumerable<MaintenanceDirective> initialCollection, ICommonCollection<MaintenanceDirective> resultCollection)
		{
			if (_filterZero == null || _filterZero.Count == 0)
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				if (_filterZero.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filterZero)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filterZero)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#region public void CalculateMaintenanceDirectives(CommonCollection<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)

		public void CalculateMaintenanceDirectives(CommonCollection<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)
		{
			foreach (var mpd in maintenanceDirectives)
			{
				
				GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd);

				if (bindedItemsDict.ContainsKey(mpd))
				{
					var bindedItems = bindedItemsDict[mpd];
					foreach (var bindedItem in bindedItems)
					{
						if (bindedItem is ComponentDirective)
						{
							GlobalObjects.PerformanceCalculator.GetNextPerformance(bindedItem);

							var firstNextPerformance =
								bindedItemsDict[mpd].SelectMany(t => t.NextPerformances).OrderBy(n => n.NextPerformanceDate).FirstOrDefault();

							if (firstNextPerformance == null)
								continue;
							mpd.BindedItemNextPerformance = firstNextPerformance;
							mpd.BindedItemNextPerformanceSource = firstNextPerformance.NextPerformanceSource ?? Lifelength.Null;
							mpd.BindedItemRemains = firstNextPerformance.Remains ?? Lifelength.Null;
							mpd.BindedItemNextPerformanceDate = firstNextPerformance.NextPerformanceDate;
							mpd.BindedItemCondition = firstNextPerformance.Condition ?? ConditionState.NotEstimated;
						}
					}
				}
			}


		}

		#endregion
	}
}
