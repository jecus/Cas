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
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using Telerik.WinControls.UI;

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
		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(NextPerformance));
		private Forecast _currentForecast;
		private LDNDListView _directivesViewer;

		private MaintenanceDirectivesFullReportBuilderLitAViaLDND _maintenanceDirectiveReportBuilderLitAVia;

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportMPLimit;

		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _createWorkPakageToolStripMenuItem;
		private RadMenuItem _toolStripMenuItemsWorkPackages;
		private RadMenuItem _toolStripMenuItemShowTaskCard;

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

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportMPLimit = new ToolStripMenuItem { Text = "MP Limit" };


			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportMPLimit });

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

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}

				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (WorkPackage workPackage in _openPubWorkPackages)
				{
					var item = new RadMenuItem($"{workPackage.Number} {workPackage.Title}");
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.Items.Add(item);
				}
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
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemShowTaskCard,
				new RadMenuSeparatorItem(),
				_createWorkPakageToolStripMenuItem,
				_toolStripMenuItemsWorkPackages);
			
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			_createWorkPakageToolStripMenuItem = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemShowTaskCard = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			
			_createWorkPakageToolStripMenuItem.Text = "Create work package";
			_createWorkPakageToolStripMenuItem.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to work package";
			// 
			// _toolStripMenuItemShowTaskCard
			// 
			_toolStripMenuItemShowTaskCard.Text = "Show Task Card";
			_toolStripMenuItemShowTaskCard.Click += ToolStripMenuItemShowTaskCardClick;
			
			_toolStripMenuItemsWorkPackages.Items.Clear();
			
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

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

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
					var item = new RadMenuItem($"{wp.Title} {wp.Number}");
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

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;

			if (_directivesViewer.SelectedItems[0].Parent is MaintenanceDirective)
			{
				var mpd = _directivesViewer.SelectedItems[0].Parent as MaintenanceDirective;
				if (mpd == null || mpd.TaskCardNumberFile == null)
				{
					MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
					return;
				}

				try
				{
					string message;
					GlobalObjects.CasEnvironment.OpenFile(mpd.TaskCardNumberFile, out message);
					if (message != "")
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
							MessageBoxDefaultButton.Button1);
					}
				}
				catch (Exception ex)
				{
					string errorDescriptionSctring =
						$"Error while Open Attached File for {mpd}, id {mpd.ItemId}. \nFileId {mpd.TaskCardNumberFile.ItemId}";
					Program.Provider.Logger.Log(errorDescriptionSctring, ex);
				}
			}
			else if (_directivesViewer.SelectedItems[0].Parent is ComponentDirective cd)
			{
				if (cd.MaintenanceDirective == null)
					return;
				var mpd = cd.MaintenanceDirective;
				if (mpd == null || mpd.TaskCardNumberFile == null)
				{
					MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
					return;
				}

				try
				{
					string message;
					GlobalObjects.CasEnvironment.OpenFile(mpd.TaskCardNumberFile, out message);
					if (message != "")
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
							MessageBoxDefaultButton.Button1);
					}
				}
				catch (Exception ex)
				{
					string errorDescriptionSctring =
						$"Error while Open Attached File for {mpd}, id {mpd.ItemId}. \nFileId {mpd.TaskCardNumberFile.ItemId}";
					Program.Provider.Logger.Log(errorDescriptionSctring, ex);
				}
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

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			if (CurrentAircraft != null)
				e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + ReportText + " Report";
			else
			{
				e.DisplayerText = ReportText + " Report";
				e.Cancel = true;
				return;
			}
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == itemPrintReportMPLimit)
			{
				_maintenanceDirectiveReportBuilderLitAVia = new MaintenanceDirectivesFullReportBuilderLitAViaLDND(true);
				_maintenanceDirectiveReportBuilderLitAVia.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				_maintenanceDirectiveReportBuilderLitAVia.ReportedAircraft = CurrentAircraft;
				_maintenanceDirectiveReportBuilderLitAVia.AddDirectives(_result);
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP Limit";
				e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilderLitAVia);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP Limit)");
			}
			else
			{
				e.Cancel = true;
			}
		}
		#endregion

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = $"{CurrentAircraft.RegistrationNumber} .Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft);
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
