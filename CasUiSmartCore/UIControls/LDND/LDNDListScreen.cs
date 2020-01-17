using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Filters;

namespace CAS.UI.UIControls.LDND
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class LDNDListScreen : ScreenControl
	{
		#region Fields

		private Aircraft _currentAircraft;

		private CommonCollection<NextPerformance> _initial = new CommonCollection<NextPerformance>();
		private CommonCollection<NextPerformance> _result  = new CommonCollection<NextPerformance>();

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(NextPerformance));
		private Forecast _currentForecast;
		private LDNDListView _directivesViewer;

		#endregion

		#region Constructors

		#region public ForecastMTOPListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public LDNDListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ForecastMTOPListScreen(Aircraft currentAircraft)

		/// <summary>
		///  Создаёт экземпляр элемента управления, отображающего список директив
		/// </summary>
		public LDNDListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");

			_currentAircraft = currentAircraft;
			CurrentAircraft = currentAircraft;

			_currentForecast = new Forecast { Aircraft = CurrentAircraft };

			InitListView();
			UpdateInformation();
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_currentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
								  SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
								  GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}

			if (_currentForecast.ForecastDatas.Count > 0)
			{
				var main = _currentForecast.ForecastDatas[0];
				labelDateAsOf.Text =
					"Forecast Period From: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.LowerLimit) +
					" To: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
					"\nAvg. utlz: " + main.AverageUtilization;
			}

			_directivesViewer.SetItemsArray(_result.OrderBy(i => i.PerformanceDate).ToArray());
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_result.Clear();
			_initial.Clear();
			var mtopDirectives = new List<IMtopCalc>();

			AnimatedThreadWorker.ReportProgress(10, "load Directives");


			var baseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId);
			var components = GlobalObjects.ComponentCore.GetComponents(baseComponents.ToList());
			var componentDirectives = components.SelectMany(i => i.ComponentDirectives);

			var mpds = GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft);
			foreach (var componentDirective in componentDirectives)
			{
				foreach (var items in componentDirective.ItemRelations.Where(i =>
					i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId ||
					i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
				{
					var id = componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId;
					componentDirective.MaintenanceDirective = mpds.FirstOrDefault(i => i.ItemId == id);
				}
			}

			var directives = GlobalObjects.DirectiveCore.GetDirectives(CurrentAircraft, DirectiveType.All);

			mtopDirectives.AddRange(mpds.Where(i => i.Status == DirectiveStatus.Open || i.Status == DirectiveStatus.Repetative));
			mtopDirectives.AddRange(directives.Where(i => i.Status == DirectiveStatus.Open || i.Status == DirectiveStatus.Repetative));
			mtopDirectives.AddRange(componentDirectives.Where(i => i.Status == DirectiveStatus.Open || i.Status == DirectiveStatus.Repetative));



			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}


			AnimatedThreadWorker.ReportProgress(50, "Calculation");

			GlobalObjects.MTOPCalculator.CalculateDirectiveNew(mtopDirectives);

			_initial.AddRange(mtopDirectives.SelectMany(i => i.NextPerformances));

			FilterItems(_initial, _result);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			AnimatedThreadWorker.ReportProgress(100, "Completed");
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_result.Clear();

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initial, _result);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new LDNDListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};
			//события 

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initial) { Text = "LDND Filter Form" };

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<NextPerformance> initialCollection, ICommonCollection<NextPerformance> resultCollection)
		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<NextPerformance> initialCollection, ICommonCollection<NextPerformance> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (NextPerformance pd in initialCollection)
			{
				//if (pd.Parent != null && pd.Parent is MaintenanceCheck && ((MaintenanceCheck)pd.Parent).Name == "C02")
				//{
				//    pd.ToString();
				//}
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

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			if(!AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ForecastContextMenuClick(object sender, EventArgs e)

		private void ForecastContextMenuClick(object sender, EventArgs e)
		{
			var form = new ForecastCustomsMTOP(CurrentAircraft, _currentForecast);

			if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#endregion
	}
}
