using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class AirFleetForecastListScreen : ScreenControl
	{
		#region Fields

		private AirFleetForecastListView _directivesViewer;
		//private ForecastData _currentForecastData;
		private AirFleetForecast _currentAirFleetForecast;
		private List<NextPerformance> _forecastArray = new List<NextPerformance>();
		private List<Aircraft> _currentAircrafts;
		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private MonthlyPlanReportBuilder _scheduleReportBuilder;
		private MaintenancePlanReportBuilder _maintenancePlanReportBulder;
		private ForecastAllFleetKitsReportBuilder _forecastAllFleetKitsReportBuilder;

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportSchedule;
		private ToolStripMenuItem itemPrintReportMaintenancePlan;
		private ToolStripMenuItem itemPrintReportEquipmentAndMaterials;

		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _createWorkPakageToolStripMenuItem;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemsWorkPackages;

		#endregion
		
		#region Constructors

		#region public AirFleetForecastListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public AirFleetForecastListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public AirFleetForecastListScreen(List<Aircraft> aircrafts) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="aircrafts">ВС, которому принадлежат директивы</param>
		public AirFleetForecastListScreen(List<Aircraft> aircrafts)
			: this()
		{
			if (aircrafts == null)
				throw new ArgumentNullException("aircrafts");
			aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];
			_currentAircrafts = aircrafts;
			StatusTitle = "Forecast";
			_currentAirFleetForecast = new AirFleetForecast();

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
			itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Maintenance Plan" };
			itemPrintReportEquipmentAndMaterials = new ToolStripMenuItem { Text = "Equipment and Materials" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportSchedule, itemPrintReportMaintenancePlan, itemPrintReportEquipmentAndMaterials});

			ButtonPrintMenuStrip = buttonPrintMenuStrip;

			#endregion

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
			if (_currentAircrafts.Count == 1)
			{
				labelTitle.Text = "Date as of: " +
				SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
				GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircrafts[0]);
			}
			else
			{
				labelTitle.Text = "Date as of: " +
				SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " All aircrafts";
			}

			_directivesViewer.SetItemsArray(_forecastArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_forecastArray.Clear();
			List<IDirective> directives = new List<IDirective>();
			if (_currentAircrafts != null)
			{
				#region --загрузка элементов для AircraftArray--

				try
				{ 
					foreach (Forecast item in _currentAirFleetForecast)
					{
						AnimatedThreadWorker.ReportProgress(0, "calculation of Maintenance checks");
						GlobalObjects.AnalystCore.GetMaintenanceCheck(item);
						directives.AddRange(item.MaintenanceChecks.ToArray());

						AnimatedThreadWorker.ReportProgress(9, "calculation of Base details");
						GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectives(item);
						directives.AddRange(item.BaseComponents.ToArray());
						directives.AddRange(item.BaseComponentDirectives.ToArray());

						AnimatedThreadWorker.ReportProgress(18, "calculation of Components");
						GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(item);
						directives.AddRange(item.Components.ToArray());
						directives.AddRange(item.ComponentDirectives.ToArray());

						AnimatedThreadWorker.ReportProgress(27, "calculation of Airworthiness directives");
						GlobalObjects.AnalystCore.GetDirectives(item, DirectiveType.AirworthenessDirectives);
						directives.AddRange(item.AdStatus.ToArray());

						AnimatedThreadWorker.ReportProgress(36, "calculation of Damages");
						GlobalObjects.AnalystCore.GetDirectives(item, DirectiveType.DamagesRequiring);
						directives.AddRange(item.Damages.ToArray());

						AnimatedThreadWorker.ReportProgress(45, "calculation of Deffereds");
						GlobalObjects.AnalystCore.GetDirectives(item, DirectiveType.DeferredItems);
						directives.AddRange(item.DefferedItems.ToArray());

						AnimatedThreadWorker.ReportProgress(54, "calculation of Engineering orders");
						GlobalObjects.AnalystCore.GetEngineeringOrders(item);
						directives.AddRange(item.EngineeringOrders.ToArray());

						AnimatedThreadWorker.ReportProgress(63, "calculation of Service bulletins");
						GlobalObjects.AnalystCore.GetServiceBulletins(item);
						directives.AddRange(item.ServiceBulletins.ToArray());

						AnimatedThreadWorker.ReportProgress(72, "calculation of Out of phase");
						GlobalObjects.AnalystCore.GetDirectives(item, DirectiveType.OutOfPhase);
						directives.AddRange(item.OutOfPhaseItems.ToArray());

						AnimatedThreadWorker.ReportProgress(81, "calculation of Maintenance Directives");
						GlobalObjects.AnalystCore.GetMaintenanceDirectives(item);
						directives.AddRange(item.MaintenanceDirectives.ToArray());

						if (AnimatedThreadWorker.CancellationPending)
						{
							e.Cancel = true;
							return;
						}
					}
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}

				#region Сравнение с рабочими пакетами
				//загрузка рабочих пакетов для определения 
				//перекрытых ими выполнений задач
				if(_openPubWorkPackages == null)
					_openPubWorkPackages = new CommonCollection<WorkPackage>();
				_openPubWorkPackages.Clear();
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(null, WorkPackageStatus.Opened));
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(null, WorkPackageStatus.Published));

				AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");
				//сбор всех записей рабочих пакетов для удобства фильтрации
				List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
				foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
					openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

				foreach (IDirective dir in directives)
				{
					if (dir is MaintenanceCheck)
					{
						MaintenanceCheck mc = (MaintenanceCheck)dir;
						if (mc.Grouping)
						{
							//определение первого выполнения в котором данный чек
							//является главным
							_forecastArray.Add(mc.GetPergormanceGroupWhereCheckIsSenior().First());

							//Проход по всем след. выполнениям чека и записям в рабочих пакетах
							//для поиска перекрывающихся выполнений
							List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
							foreach (MaintenanceNextPerformance mnp in performances)
							{
								//поиск записи в рабочих пакетах по данному чеку
								//чей номер группы выполнения (по записи) совпадает с расчитанным
								WorkPackageRecord wpr =
									openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == mnp.PerformanceGroupNum &&
																	  r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
																	  r.DirectiveId == mc.ItemId);
								if (wpr != null)
									mnp.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
							}
						}
						else
						{
							//определение первого выполнения в котором данный чек
							//является главным
							_forecastArray.Add(mc.NextPerformances.First());
							//Проход по всем след. выполнениям чека и записям в рабочих пакетах
							//для поиска перекрывающихся выполнений
							List<NextPerformance> performances = dir.NextPerformances;
							foreach (NextPerformance np in performances)
							{
								//поиск записи в рабочих пакетах по данному чеку
								//чей номер группы выполнения (по записи) совпадает с расчитанным
								WorkPackageRecord wpr =
									openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
																	  r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
																	  r.DirectiveId == mc.ItemId);
								if (wpr != null)
									np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
							}
						}
					}
					else
					{
						if (dir.NextPerformances.Count <= 0)
							continue;
						_forecastArray.Add(dir.NextPerformances.First());

						BaseEntityObject baseObject = (BaseEntityObject)dir;
						//Проход по всем след. выполнениям чека и записям в рабочих пакетах
						//для поиска перекрывающихся выполнений
						List<NextPerformance> performances = dir.NextPerformances;
						foreach (NextPerformance np in performances)
						{
							//поиск записи в рабочих пакетах по данному чеку
							//чей номер группы выполнения (по записи) совпадает с расчитанным
							WorkPackageRecord wpr =
								openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
																  r.WorkPackageItemType == baseObject.SmartCoreObjectType.ItemId &&
																  r.DirectiveId == baseObject.ItemId);
							if (wpr != null)
								np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
						}
					}
				}

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				#endregion

				#region Загрузка Котировочных ордеров

				AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

				//загрузка рабочих пакетов для определения 
				//перекрытых ими выполнений задач
				if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

				_openPubQuotations.Clear();
				_openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(null, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				#endregion

				AnimatedThreadWorker.ReportProgress(100, "calculation over");

				#endregion  
			}
		}
		#endregion

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();
			AnimatedThreadWorker.Dispose();

			_forecastArray.Clear();
			_openPubWorkPackages.Clear();

			_forecastArray = null;
			_openPubWorkPackages = null;

			_openPubQuotations.Clear();
			_openPubQuotations = null;

			if (_currentAirFleetForecast != null)
			{
				_currentAirFleetForecast.Dispose();
				_currentAirFleetForecast = null;
			}

			if (_createWorkPakageToolStripMenuItem != null) _createWorkPakageToolStripMenuItem.Dispose();
			if (_toolStripMenuItemsWorkPackages != null) _toolStripMenuItemsWorkPackages.Dispose();
			if (_toolStripMenuItemHighlight != null)
			{
				foreach (RadMenuItem ttmi in _toolStripMenuItemHighlight.Items)
				{
					ttmi.Click -= HighlightItemClick;
				}
				_toolStripMenuItemHighlight.Items.Clear();
				_toolStripMenuItemHighlight.Dispose();
			}
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}
				_toolStripMenuItemsWorkPackages.Items.Clear();
				_toolStripMenuItemsWorkPackages.Dispose();
			}

			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			_createWorkPakageToolStripMenuItem = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";

			_createWorkPakageToolStripMenuItem.Text = "Create WorkPakage";
			_createWorkPakageToolStripMenuItem.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to Work package";
			
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

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new AirFleetForecastListView
									{
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemHighlight,
				new RadMenuSeparatorItem(),
				_createWorkPakageToolStripMenuItem,
				_toolStripMenuItemsWorkPackages);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_createWorkPakageToolStripMenuItem.Enabled = true;

					if (_toolStripMenuItemsWorkPackages != null)
					{
						foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
						{
							item.Click -= AddToWorkPackageItemClick;
						}

						_toolStripMenuItemsWorkPackages.Items.Clear();

						var pa = GlobalObjects.AircraftsCore.GetParentAircraft(
							_directivesViewer.SelectedItems[0].Parent);
						if (pa == null)
						{
							_toolStripMenuItemsWorkPackages.Enabled = false;
							return;
						}

						foreach (WorkPackage workPackage in _openPubWorkPackages.Where(wp => wp.ParentId == pa.ItemId))
						{
							var item = new RadMenuItem(workPackage.Title);
							item.Click += AddToWorkPackageItemClick;
							item.Tag = workPackage;
							_toolStripMenuItemsWorkPackages.Items.Add(item);
						}

						if (_toolStripMenuItemsWorkPackages.Items.Count > 0)
							_toolStripMenuItemsWorkPackages.Enabled = true;

					}
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count > 0)
			{
				_buttonComposeWorkPackage.Enabled = true;
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				_buttonComposeWorkPackage.Enabled = false;
			}
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (_currentAircrafts != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);

				//очистка массива данных по прогнозам
				_currentAirFleetForecast.Clear();

				foreach (var aircraft in _currentAircrafts)
				{
					var forecast = new Forecast{Aircraft = aircraft};
					//поиск деталей данного самолета 
					var aircraftBaseComponents =
						new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(aircraft.ItemId));
					//составление нового массива данных по прогнозам
					foreach (var baseComponent in aircraftBaseComponents)
					{
						//определение ресурсов прогноза для каждой базовой детали
						var forecastData = 
							new ForecastData(DateTime.Today,
											 baseComponent,
											 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
						//дабавление в массив
						forecast.ForecastDatas.Add(forecastData);
					} 
					_currentAirFleetForecast.Add(forecast);
				} 
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			Highlight highLight = (Highlight)((RadMenuItem)sender).Tag;
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
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
				ICommonCollection<Aircraft> pa = new CommonCollection<Aircraft>();
				foreach (NextPerformance wpItem in wpItems)
				{
					IDirective parent = wpItem.Parent;
					if(parent == null)continue;
					var a = GlobalObjects.AircraftsCore.GetParentAircraft(parent);
					if(a == null)continue;
					if(pa.GetItemById(a.ItemId) == null)
					{
						if(pa.Count > 0)
						{
							MessageBox.Show("Can't take tasks from two or more aircrafts", (string)new GlobalTermsProvider()["SystemName"],
											MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;      
						}
						pa.Add(a);
					}
				}
				if (pa.Count == 0)
				{
					MessageBox.Show("Can't take tasks with not denined parent aircraft", (string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
				foreach (NextPerformance wpItem in wpItems)
				{
					if (wpItem is MaintenanceNextPerformance)
					{
						MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
						if(mnp.PerformanceGroup.Checks.Count > 0)
						{
							foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
							{
								foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																.SelectMany(f => f.MaintenanceDirectives)
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
							foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																	.SelectMany(f => f.MaintenanceDirectives)
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
						foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																.SelectMany(f => f.MaintenanceDirectives)
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
						GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, pa[0], out message);
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
					refArgs.DisplayerText = pa[0] + "." + wp.Title;
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

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			WorkPackage wp = (WorkPackage)((RadMenuItem)sender).Tag;

			if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				List<NextPerformance> wpItems = _directivesViewer.SelectedItems.ToList();
				ICommonCollection<Aircraft> pa = new CommonCollection<Aircraft>();
				foreach (NextPerformance wpItem in wpItems)
				{
					IDirective parent = wpItem.Parent;
					if (parent == null) continue;
					var a = GlobalObjects.AircraftsCore.GetParentAircraft(parent);
					if (a == null) continue;
					if (pa.GetItemById(a.ItemId) == null)
					{
						if (pa.Count > 0)
						{
							MessageBox.Show("Can't take tasks from two or more aircrafts", (string)new GlobalTermsProvider()["SystemName"],
											MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						pa.Add(a);
					}
				}
				if (pa.Count == 0)
				{
					MessageBox.Show("Can't take tasks with not denined parent aircraft", (string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
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
								foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																.SelectMany(f => f.MaintenanceDirectives)
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
							foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																	.SelectMany(f => f.MaintenanceDirectives)
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
						foreach (MaintenanceDirective mpd in _currentAirFleetForecast
																.SelectMany(f => f.MaintenanceDirectives)
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

					if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, pa[0], out message))
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
						refArgs.DisplayerText = pa[0] != null ? pa[0].RegistrationNumber + "." + wp.Title : wp.Title;
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

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == itemPrintReportSchedule)
			{
				_scheduleReportBuilder = new MonthlyPlanReportBuilder(aircraftHeaderControl1.Operator, _directivesViewer.GetItemsArray());

				//_scheduleReportBuilder.ReportedAircraft = CurrentAircraft;
				//_scheduleReportBuilder.FilterSelection = _filter;
				//_scheduleReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
				//_scheduleReportBuilder.Forecast = _currentForecast;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Scheduled report";
				e.RequestedEntity = new ReportScreen(_scheduleReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "AirFleetForecastListView (Scheduled)");
			}
			else if (sender == itemPrintReportMaintenancePlan)
			{
				_maintenancePlanReportBulder = new MaintenancePlanReportBuilder(aircraftHeaderControl1.Operator, _directivesViewer.GetItemsArray());

				//_scheduleReportBuilder.ReportedAircraft = CurrentAircraft;
				//_scheduleReportBuilder.FilterSelection = _filter;
				//_scheduleReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
				//_scheduleReportBuilder.Forecast = _currentForecast;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Maintenance Plan report";
				e.RequestedEntity = new ReportScreen(_maintenancePlanReportBulder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "AirFleetForecastListView (Maintenance Plan)");
			}
			else if (sender == itemPrintReportEquipmentAndMaterials)
			{
				_forecastAllFleetKitsReportBuilder = new ForecastAllFleetKitsReportBuilder(aircraftHeaderControl1.Operator, _directivesViewer.GetItemsArray());
				_forecastAllFleetKitsReportBuilder.Forecast = _currentAirFleetForecast.GetForecastByAircraft(_currentAircrafts[0]);
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Equipment and Materials";
				e.RequestedEntity = new ReportScreen(_forecastAllFleetKitsReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "AirFleetForecastListView (Equipment and Materials)");
			}
			else
			{
				e.Cancel = true;
			}

			//if (_directivesViewer.ItemListView.Items.Count == 0)
			//{
			//    MessageBox.Show("0 directives");
			//}
			//e.DisplayerText = "Forecast list Report";
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//e.RequestedEntity = new ReportScreen(new ForecastListReportBuilder(_currentAirFleetForecast[0].ForecastDatas[0]));
		}
		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
			if(_currentAirFleetForecast.Count == 0)
			{
				foreach (var aircraft in _currentAircrafts)
				{
					var forecast = new Forecast { Aircraft = aircraft };
					//поиск деталей данного самолета 
					var aircraftBaseDetails =
						new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(aircraft.ItemId));
					//составление нового массива данных по прогнозам
					foreach (var baseDetail in aircraftBaseDetails)
					{
						//определение ресурсов прогноза для каждой базовой детали
						var forecastData =
							new ForecastData(DateTime.Today,
											 baseDetail,
											 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
						//дабавление в массив
						forecast.ForecastDatas.Add(forecastData);
					}
					_currentAirFleetForecast.Add(forecast);
				}    
			}

			switch ((string)sender)
			{
				case "No Forecast":
					{
					}
					break;
				case "Today":
					{
						foreach (Forecast forecast in _currentAirFleetForecast)
						{
							//составление нового массива данных по прогнозам
							foreach (ForecastData forecastData in forecast.ForecastDatas)
							{
								//определение ресурсов прогноза для каждой базовой детали
								forecastData.ForecastDate = DateTime.Today;
							}
						}
						labelDateAsOf.Text =
							"Forecast date: " +
							SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
					}
					break;
				case "This week":
					{
						foreach (Forecast forecast in _currentAirFleetForecast)
						{
							//составление нового массива данных по прогнозам
							foreach (ForecastData forecastData in forecast.ForecastDatas)
							{
								//определение ресурсов прогноза для каждой базовой детали
								forecastData.ForecastDate = DateTime.Today.AddDays(7);
							}
						}
						labelDateAsOf.Text =
							"Forecast date: " +
							SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today.AddDays(7));
					}
					break;
				case "Two weeks":
					{
						foreach (Forecast forecast in _currentAirFleetForecast)
						{
							//составление нового массива данных по прогнозам
							foreach (ForecastData forecastData in forecast.ForecastDatas)
							{
								//определение ресурсов прогноза для каждой базовой детали
								forecastData.ForecastDate = DateTime.Today.AddDays(14);
							}
						}
						labelDateAsOf.Text =
							"Forecast date: " +
							SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today.AddDays(14));
					}
					break;
				case "Month":
					{
						foreach (Forecast forecast in _currentAirFleetForecast)
						{
							//составление нового массива данных по прогнозам
							foreach (ForecastData forecastData in forecast.ForecastDatas)
							{
								//определение ресурсов прогноза для каждой базовой детали
								forecastData.ForecastDate = DateTime.Today.AddMonths(1);
							}
						}
						labelDateAsOf.Text =
							"Forecast date: " +
							SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today.AddMonths(1));
					}
					break;
				case "Custom":
					{
						var form = new ForecastCustomsWriteData(_currentAirFleetForecast);
						if(form.ShowDialog() == DialogResult.OK)
						{
							labelDateAsOf.Text =
								"Forecast date: " +
								SmartCore.Auxiliary.Convert.GetDateFormat(form.ForecastDate); 
						}
						else return;

						if (form.DialogResult == DialogResult.OK)
						{
							ForecastData main = _currentAirFleetForecast.Count > 0 &&
												_currentAirFleetForecast[0].ForecastDatas.Count > 0
													? _currentAirFleetForecast[0].ForecastDatas[0]
													: null;

							if (main == null)
								return;
							if (main.SelectedForecastType == ForecastType.ForecastByDate)
							{
								labelDateAsOf.Text =
								"Forecast date: " +
								SmartCore.Auxiliary.Convert.GetDateFormat(form.ForecastDate); 
							}
							else if (main.SelectedForecastType == ForecastType.ForecastByPeriod)
							{
								labelDateAsOf.Text =
										"Forecast Period From: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.LowerLimit) +
										" To: " + SmartCore.Auxiliary.Convert.GetDateFormat(form.ForecastDate);
							}
							else if (main.SelectedForecastType == ForecastType.ForecastByCheck)
							{
								if (main.NextPerformanceByDate)
								{
									labelDateAsOf.Text = "Forecast: " + main.NextPerformanceString;
								}
								else
								{
									labelDateAsOf.Text =
										string.Format("Forecast: {0}. {1}",
													   main.CheckName,
													   main.NextPerformance);
								}
							}
						}
						else return;
					}
					break;
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#endregion
	}
}
