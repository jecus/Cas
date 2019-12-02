using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Relation;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class ForecastMTOPListScreen : ScreenControl
	{
		#region Fields

		private Aircraft _currentAircraft;
		private bool _isFirstLoad;

		private Dictionary<int, Lifelength> _groupLifelengths = new Dictionary<int, Lifelength>();
		private Dictionary<int, Lifelength> _groupLifelengthsForZeroCheck = new Dictionary<int, Lifelength>();

		private CommonCollection<NextPerformance> _initial = new CommonCollection<NextPerformance>();
		private CommonCollection<NextPerformance> _result  = new CommonCollection<NextPerformance>();

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(IForecastMtopFilterParams));
		private Forecast _currentForecast;
		private ForecastMTOPListView _directivesViewer;

		private RadMenuItem _createWorkPakageToolStripMenuItem;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemsWorkPackages;

		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
		#endregion


		#region Constructors

		#region public ForecastMTOPListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public ForecastMTOPListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ForecastMTOPListScreen(Aircraft currentAircraft)

		/// <summary>
		///  Создаёт экземпляр элемента управления, отображающего список директив
		/// </summary>
		public ForecastMTOPListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");

			_currentAircraft = currentAircraft;
			CurrentAircraft = currentAircraft;

			_currentForecast = new Forecast { Aircraft = CurrentAircraft };

			_isFirstLoad = true;

			InitToolStripMenuItems();
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

			if (_isFirstLoad)
			{
				_isFirstLoad = false;
				var form = new ForecastCustomsMTOP(CurrentAircraft, _currentForecast);

				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}

			if (_currentForecast.ForecastDatas.Count > 0)
			{
				var main = _currentForecast.ForecastDatas[0];
				labelDateAsOf.Text =
					"Forecast Period From: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.LowerLimit) +
					" To: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
					"\nAvg. utlz: " + main.AverageUtilization;
			}

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}

				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (WorkPackage workPackage in _openPubWorkPackages)
				{
					var item = new RadMenuItem($"{workPackage.Title} {workPackage.Number}");
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.Items.Add(item);
				}
			}

			_directivesViewer.SetItemsArray(_result.OrderBy(i => i.PerformanceDate).ToArray());
		}

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			WorkPackage wp = (WorkPackage)((RadMenuItem)sender).Tag;

			if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				List<NextPerformance> wpItems = _directivesViewer.SelectedItems.ToList();
				List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
				foreach (NextPerformance wpItem in wpItems)
				{
					if (wpItem is MaintenanceNextPerformance)
					{
						MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
						if (mnp.PerformanceGroup.Checks.Count > 0)
						{
							foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
							{
								foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
																.Where(mpd => mpd.MaintenanceCheck != null &&
																			  mpd.MaintenanceCheck.ItemId == mc.ItemId))
								{
									NextPerformance performance =
										mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																				 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
										mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																				p.PerformanceDate < wpItem.PerformanceDate) ??
										mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																				 p.PerformanceDate > wpItem.PerformanceDate);

									if (performance == null) continue;
									if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
										bindedDirectivesPerformances.Add(performance);
								}
							}
						}
						else if (wpItem.Parent is MaintenanceCheck)
						{
							MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
							foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
																	.Where(mpd => mpd.MaintenanceCheck != null &&
																				  mpd.MaintenanceCheck.ItemId == mc.ItemId))
							{
								NextPerformance performance =
									mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																			 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
									mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																			p.PerformanceDate < wpItem.PerformanceDate) ??
									mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																			 p.PerformanceDate > wpItem.PerformanceDate);

								if (performance == null) continue;
								if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
									bindedDirectivesPerformances.Add(performance);
							}
						}
					}
					else if (wpItem.Parent is MaintenanceCheck)
					{
						MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
						foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
																.Where(mpd => mpd.MaintenanceCheck != null &&
																			  mpd.MaintenanceCheck.ItemId == mc.ItemId))
						{
							NextPerformance performance =
								mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																		 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
								mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																		p.PerformanceDate < wpItem.PerformanceDate) ??
								mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																		 p.PerformanceDate > wpItem.PerformanceDate);

							if (performance == null) continue;
							if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
								bindedDirectivesPerformances.Add(performance);
						}
					}
				}
				wpItems.AddRange(bindedDirectivesPerformances);

				try
				{
					string message;

					if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, CurrentAircraft, out message))
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					foreach (NextPerformance nextPerformance in wpItems)
					{
						nextPerformance.BlockedByPackage = wp;
						_directivesViewer.UpdateItemColor();
					}

					if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
										 MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
										== DialogResult.Yes)
					{
						ReferenceEventArgs refArgs = new ReferenceEventArgs();
						refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
						refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
						refArgs.RequestedEntity = new WorkPackageScreen(wp);
						InvokeDisplayerRequested(refArgs);
					}
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Work Package", ex);
				}
			}
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			var initialZeroMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
			var initialMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
			_result.Clear();
			_initial.Clear();
			_groupLifelengths.Clear();
			_groupLifelengthsForZeroCheck.Clear();

			if (!_isFirstLoad)
			{
				AnimatedThreadWorker.ReportProgress(0, "load checks");

			   var checks = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MTOPCheckDTO, MTOPCheck>(new Filter("ParentAircraftId", CurrentAircraft.ItemId), true).ToList();
				
				foreach (var check in checks)
				{
					foreach (var record in check.PerformanceRecords)
						record.Parent = check;
				}

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				AnimatedThreadWorker.ReportProgress(10, "load MPDs");

				initialMaintenanceDirectives.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft));

				var bindedItemsDict = GlobalObjects.BindedItemsCore.GetBindedItemsFor(CurrentAircraft.ItemId,
					initialMaintenanceDirectives.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend));

				CalculateMaintenanceDirectives(initialMaintenanceDirectives.ToList(), bindedItemsDict);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}


				AnimatedThreadWorker.ReportProgress(50, "calculation");


				if (checks.Count > 0)
				{
					//Берем утилизацию с Frame
					var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
						i.ParentAircraftId == CurrentAircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
					var avg = _currentForecast.ForecastDatas[0].AverageUtilization;

					var lastCompliance = checks.SelectMany(i => i.PerformanceRecords).OrderByDescending(i => i.RecordDate)
						.FirstOrDefault();

					GlobalObjects.MTOPCalculator.CalculateMtopChecks(checks, avg);

					_groupLifelengths = GlobalObjects.MTOPCalculator.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList());

					GlobalObjects.MTOPCalculator.CalculateNextPerformance(checks.Where(i => !i.IsZeroPhase).ToList(),
						frame.StartDate, _groupLifelengths, CurrentAircraft, avg, lastCompliance);

					GlobalObjects.MTOPCalculator.CalculatePhaseWithPerformance(initialMaintenanceDirectives, checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList(), avg, _currentForecast.ForecastDatas[0].LowerLimit, _currentForecast.ForecastDatas[0].ForecastDate);

	
					var maintenanceZeroChecks = checks.Where(i => i.IsZeroPhase).ToList();

					var lowerZeroCheck = maintenanceZeroChecks.Where(i => !i.Thresh.IsNullOrZero()).OrderBy(i => i.Thresh)
						.FirstOrDefault();
					if (lowerZeroCheck != null)
					{
						GlobalObjects.MTOPCalculator.CalculateMtopChecks(maintenanceZeroChecks, avg);

						_groupLifelengthsForZeroCheck = GlobalObjects.MTOPCalculator.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && i.IsZeroPhase).ToList());

						GlobalObjects.MTOPCalculator.CalculateNextPerformance(maintenanceZeroChecks, frame.StartDate,
							_groupLifelengthsForZeroCheck, CurrentAircraft, avg, lastCompliance);

						initialZeroMaintenanceDirectives.AddRange(initialMaintenanceDirectives
							.Where(i => i.MTOPPhase?.FirstPhase == 0).ToArray());

						GlobalObjects.MTOPCalculator.CalculatePhaseWithPerformance(initialZeroMaintenanceDirectives, maintenanceZeroChecks, avg, _currentForecast.ForecastDatas[0].LowerLimit , _currentForecast.ForecastDatas[0].ForecastDate, true);

					}

					foreach (var d in initialZeroMaintenanceDirectives)
						initialMaintenanceDirectives.Remove(d);


					_initial.AddRange(initialMaintenanceDirectives.SelectMany(i => i.MtopNextPerformances));
					_initial.AddRange(initialZeroMaintenanceDirectives.SelectMany(i => i.MtopNextPerformances));

				}

				#region Фильтрация директив

				AnimatedThreadWorker.ReportProgress(75, "filter directives");

				FilterItems(_initial, _result);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				#endregion

				#region Load WP

				AnimatedThreadWorker.ReportProgress(75, "filter Work Packages");

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				if (_openPubWorkPackages == null)
					_openPubWorkPackages = new CommonCollection<WorkPackage>();
				_openPubWorkPackages.Clear();
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));
				//сбор всех записей рабочих пакетов для удобства фильтрации
				List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
				foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
					openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);


				#endregion

				#region Загрузка Котировочных ордеров

				AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

				//загрузка рабочих пакетов для определения 
				//перекрытых ими выполнений задач
				if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

				BaseEntityObject parent = CurrentAircraft ?? (BaseEntityObject)CurrentOperator;
				_openPubQuotations.Clear();
				_openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(parent, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				#endregion

				AnimatedThreadWorker.ReportProgress(100, "Completed");
			}
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
			_directivesViewer = new ForecastMTOPListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};
			//события 

			_directivesViewer.AddMenuItems(_toolStripMenuItemHighlight,
				new RadMenuSeparatorItem(),
				_createWorkPakageToolStripMenuItem,
				_toolStripMenuItemsWorkPackages);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
					_createWorkPakageToolStripMenuItem.Enabled = true;
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			_createWorkPakageToolStripMenuItem = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";

			_createWorkPakageToolStripMenuItem.Text = "Create work package";
			_createWorkPakageToolStripMenuItem.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to work package";
			
			_toolStripMenuItemsWorkPackages.Items.Clear();
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				var item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}

		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			var highLight = (Highlight)((RadMenuItem)sender).Tag;
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
				
			foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
			{
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = Color.FromArgb(highLight.Color);
			}
		}

		#endregion

		#region private void ButtonCreateWorkPakageClick(object sender, EventArgs e)

		private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			if (MessageBox.Show("Create and save a Work Package?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				List<NextPerformance> wpItems = _directivesViewer.SelectedItems.ToList();
				List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
				foreach (NextPerformance wpItem in wpItems)
				{
					if (wpItem is MaintenanceNextPerformance)
					{
						MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
						if (mnp.PerformanceGroup.Checks.Count > 0)
						{
							foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
							{
								foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
									.Where(mpd => mpd.MaintenanceCheck != null &&
												  mpd.MaintenanceCheck.ItemId == mc.ItemId))
								{
									NextPerformance performance =
										mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																				 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
										mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																				p.PerformanceDate < wpItem.PerformanceDate) ??
										mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																				 p.PerformanceDate > wpItem.PerformanceDate);

									if (performance == null) continue;
									if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
										bindedDirectivesPerformances.Add(performance);
								}
							}
						}
						else if (wpItem.Parent is MaintenanceCheck)
						{
							MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
							foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
								.Where(mpd => mpd.MaintenanceCheck != null &&
											  mpd.MaintenanceCheck.ItemId == mc.ItemId))
							{
								NextPerformance performance =
									mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																			 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
									mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																			p.PerformanceDate < wpItem.PerformanceDate) ??
									mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																			 p.PerformanceDate > wpItem.PerformanceDate);

								if (performance == null) continue;
								if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
									bindedDirectivesPerformances.Add(performance);
							}
						}
					}
					else if (wpItem.Parent is MaintenanceCheck)
					{
						MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
						foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
							.Where(mpd => mpd.MaintenanceCheck != null &&
										  mpd.MaintenanceCheck.ItemId == mc.ItemId))
						{
							NextPerformance performance =
								mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																		 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
								mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
																		p.PerformanceDate < wpItem.PerformanceDate) ??
								mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
																		 p.PerformanceDate > wpItem.PerformanceDate);

							if (performance == null) continue;
							if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
								bindedDirectivesPerformances.Add(performance);
						}
					}
				}
				wpItems.AddRange(bindedDirectivesPerformances);

				try
				{
					string message;
					WorkPackage wp =
						GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, _currentAircraft, out message);
					if (wp == null)
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					//Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
					_openPubWorkPackages.Add(wp);
					//Создание пункта в меню открытых рабочих пакетов
					var item = new RadMenuItem(wp.Title);
					item.Click += AddToWorkPackageItemClick;
					item.Tag = wp;
					_toolStripMenuItemsWorkPackages.Items.Add(item);

					foreach (NextPerformance nextPerformance in wpItems)
					{
						nextPerformance.BlockedByPackage = wp;
						_directivesViewer.UpdateItemColor();
					}
					ReferenceEventArgs refArgs = new ReferenceEventArgs();
					refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
					refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
					refArgs.RequestedEntity = new WorkPackageScreen(wp);
					InvokeDisplayerRequested(refArgs);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Work Package", ex);
				}
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initial) { Text = "Forecast Filter Form" };

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
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

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText =
				$"{CurrentAircraft.RegistrationNumber} .Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft);
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

		#region private void CalculateMaintenanceDirectives(List<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)

		private void CalculateMaintenanceDirectives(List<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)
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
