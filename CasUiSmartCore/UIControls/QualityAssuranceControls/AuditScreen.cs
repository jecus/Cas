using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class AuditScreen : ScreenControl
	{
		#region Fields

		private readonly Audit _currentDirective;

		private CommonCollection<BaseEntityObject> _itemsArray = new CommonCollection<BaseEntityObject>();
		/// <summary>
		/// Рабочие пакеты, имеющие те же задачи, что и текущий
		/// </summary>
		private CommonCollection<Audit> _relatedWorkPackages = new CommonCollection<Audit>();
		private AuditView _directivesViewer;

#if  KAC
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private List<RadMenuItem> _toolStripMenuItemsWorkPackages;

		#endregion

		#region Constructors

		#region private AuditScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private AuditScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public AuditScreen(Audit audit)
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="audit"></param>
		public AuditScreen(Audit audit)
			: this()
		{
			if (audit == null)
				throw new ArgumentNullException("audit");
		   
			CurrentOperator = audit.Operator;

			_currentDirective = audit;

			//InitializeComponent();
			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();
			AnimatedThreadWorker.Dispose();

			_itemsArray.Clear();
			_itemsArray = null;

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages)
					item.Dispose();
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Cancelled)
				return;

			labelDateAsOf.Text = "Audit Status: " + _currentDirective.Status;

			switch (_currentDirective.Status)
			{
				case WorkPackageStatus.Published:
					{
						buttonAddNonRoutineJob.Enabled = false;
						buttonPublish.Enabled = false;
						buttonClose.Enabled = true;
						if (_currentDirective.CanClose == false)
						{
							buttonClose.ShowToolTip = true;
							buttonClose.ToolTipText = "This audit can not be closed";
						}
						else
						{
							buttonClose.ShowToolTip = false;
							buttonClose.ToolTipText = "";
						}
						break;
					}
				case WorkPackageStatus.Closed:
					{
						buttonAddNonRoutineJob.Enabled = false;
						buttonPublish.Enabled = true;
						if(_currentDirective.CanPublish == false)
						{
							buttonPublish.ShowToolTip = true;
							buttonPublish.ToolTipText = "This audit can not be republished";
						}
						else
						{
							buttonPublish.ShowToolTip = false;
							buttonPublish.ToolTipText = "";   
						}
						break;
					}
				default:
					{
						buttonAddNonRoutineJob.Enabled = true;
						buttonPublish.Enabled = true;
						buttonClose.Enabled = true;
						if (_currentDirective.CanClose == false)
						{
							buttonClose.ShowToolTip = true;
							buttonClose.ToolTipText = "This audit can not be closed";
						}
						else
						{
							buttonClose.ShowToolTip = false;
							buttonClose.ToolTipText = "";
						}
						break;
					}
			}
			_directivesViewer.SetItemsArray(_itemsArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_itemsArray.Clear();
			_relatedWorkPackages.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Audit");
			
			//GlobalObjects.CasEnvironment.Loader.LoadWorkPackageItems(_currentWorkPackage);
			GlobalObjects.AuditCore.GetAuditItemsWithCalculate(_currentDirective);
			if (_currentDirective.MaxClosingDate < _currentDirective.MinClosingDate)
				_currentDirective.CanClose = false;
			CommonCollection<BaseEntityObject> wpItems = new CommonCollection<BaseEntityObject>();
			foreach (AuditRecord record in _currentDirective.AuditRecords) 
				wpItems.Add((BaseEntityObject)record.Task);   

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			double currentProc = 20;
			int countDirectives = wpItems.Count;
			if (countDirectives == 0)countDirectives = 1;
			double delay = (100 - currentProc) / countDirectives;

			if (_currentDirective.Status != WorkPackageStatus.Closed)
			{
				AnimatedThreadWorker.ReportProgress(10, "load related Audit");
			   
				foreach (AuditRecord record in _currentDirective.AuditRecords)
				{
					AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "calculation of directives");

					if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
					{
						MaintenanceCheck mc = (MaintenanceCheck) record.Task;
						MaintenanceNextPerformance mnp = 
							mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
						if(mnp != null)
							_itemsArray.Add(mnp);
					}
					else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
					{
						_itemsArray.Add((BaseEntityObject)record.Task);
					}
					else if (record.Task.SmartCoreObjectType == SmartCoreType.Component)
					{
						if (record.Task.NextPerformances.Count > 0)
							_itemsArray.Add(record.Task.NextPerformances[0]);
						else _itemsArray.Add((BaseEntityObject)record.Task);
					}
					else
					{
						if (record.Task.NextPerformances.Count > 0)
							_itemsArray.Add(record.Task.NextPerformances[0]);
						else _itemsArray.Add((BaseEntityObject)record.Task);
					}
				}
			}
			else
			{
				//При закоытом Рабочем пакете, в список попадают записи о выполении
				//сделанные в рамках данного рабочего пакета
				AnimatedThreadWorker.ReportProgress(10, "load related Audits");
				_relatedWorkPackages.AddRange(GlobalObjects.AuditCore.GetAudits(CurrentOperator,
																				 WorkPackageStatus.Closed,
																				 true,
																				 wpItems));
				//сбор всех записей рабочих пакетов для удобства фильтрации
				AbstractPerformanceRecord apr;
				foreach (AuditRecord record in _currentDirective.AuditRecords)
				{
					AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "check records");
					
					apr = record.Task.PerformanceRecords
						.Cast<AbstractPerformanceRecord>()
						.FirstOrDefault(pr => pr.DirectivePackageId == _currentDirective.ItemId);
					if (apr != null)
						_itemsArray.Add(apr);
					else
					{
						if (record.Task.NextPerformances.Count > 0)
							_itemsArray.Add(record.Task.NextPerformances[0]);
						else _itemsArray.Add((BaseEntityObject)record.Task);
					}
				}   
			}

			AnimatedThreadWorker.ReportProgress(100, "calculation over");
		}
		#endregion

		#region private void CloseWorkPackage()
		private void CloseWorkPackage()
		{
			IEnumerable<AuditRecord> blockedRecords = 
				_currentDirective.AuditRecords
				.Where(rec => rec.Task != null && 
							  rec.Task.NextPerformances != null && 
							  rec.Task.NextPerformances.Count > 0 && 
							  rec.Task.NextPerformances.Any(np => np.BlockedByPackage != null && 
																  np.BlockedByPackage.ItemId != _currentDirective.ItemId));

			if (_currentDirective.CanClose == false || blockedRecords.Any())
			{
				string message = "This audit can not be closed";
				foreach (AuditRecord blockedRecord in blockedRecords)
				{
					NextPerformance np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByPackage != null);
					message += $"\nTask: {blockedRecord.Task} blocked by audit {np.BlockedByPackage}";
				}
				if(_currentDirective.MaxClosingDate < _currentDirective.MinClosingDate)
				{
					message +=
						$"\nMin Closing Date: {_currentDirective.MinClosingDate} better than Max Closing Date: {_currentDirective.MaxClosingDate}"; 
				}
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			AuditClosingFormNew form = new AuditClosingFormNew(_currentDirective);
			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				AnimatedThreadWorker.RunWorkerAsync();
			}    
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new List<RadMenuItem>();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";

			_toolStripMenuItemsWorkPackages.Clear();
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				RadMenuItem item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}
		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				Highlight highLight = (Highlight) ((RadMenuItem) sender).Tag;
				
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)return;
			foreach (BaseEntityObject selectedItem in _directivesViewer.SelectedItems)
			{
				if (selectedItem is Procedure)
				{
					ReferenceEventArgs refE = new ReferenceEventArgs();
					refE.DisplayerText = ((Procedure)selectedItem).Title;
					refE.RequestedEntity = new ProcedureScreen((Procedure)selectedItem);
					refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
					InvokeDisplayerRequested(refE);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			CloseWorkPackage();
		}

		#endregion

		#region private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		{
			//NonRoutineJobForm form = new NonRoutineJobForm(new AuditRecord(_currentDirective.ItemId, -1, -1));

			//if (form.ShowDialog() == DialogResult.OK) 
			//    AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonPublishClick(object sender, EventArgs e)

		private void ButtonPublishClick(object sender, EventArgs e)
		{
			if (_currentDirective.CanPublish == false)
			{
				string message = "This Audit can not be published";
				if (_currentDirective.BlockPublishReason != "")
					message += "\n" + _currentDirective.BlockPublishReason;

				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (_currentDirective.Status != WorkPackageStatus.Closed)
				GlobalObjects.AuditCore.Publish(_currentDirective, DateTime.Now, "");
			else
			{
				switch (MessageBox.Show(@"This Audit is already closed," +
										"\nif you want to republish it," +
										"\nrecordings created during its execution will be erased." + "\n\n Republish " +
										_currentDirective.Title + " Audit?", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button2))
				{
					case DialogResult.Yes:
						GlobalObjects.AuditCore.Publish(_currentDirective, DateTime.Now, "");
						break;
					case DialogResult.No:
						//arguments.Cancel = true;
						break;
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonReleaseToService(object sender, EventArgs e)

		private void ButtonReleaseToService(object sender, EventArgs e)
		{
			//SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(_currentDirective);
			//form.ShowDialog();
		}

		#endregion

		#region void ButtonCloseClick(object sender, EventArgs e)

		void ButtonCloseClick(object sender, EventArgs e)
		{
			CloseWorkPackage();
		}

		#endregion

		#region private void ButtonEditClick(object sender, EventArgs e)

		private void ButtonEditClick(object sender, EventArgs e)
		{
			CommonEditorForm form = new CommonEditorForm(_currentDirective);
			form.ShowDialog();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new AuditView(_currentDirective);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemClose,
				_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemHighlight);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
				}
			};
			
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			_toolStripMenuItemHighlight.Enabled = _directivesViewer.SelectedItems.Count > 0;
			_toolStripMenuItemOpen.Enabled = _directivesViewer.SelectedItems.Count > 0;
			_toolStripMenuItemClose.Enabled = _directivesViewer.SelectedItems.Count > 0;
			foreach (RadMenuItem t in _toolStripMenuItemsWorkPackages)
				t.Enabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (CurrentOperator != null)
			{
				labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
			}
			else
			{
				labelTitle.Text = "";
				labelTitle.Status = Statuses.NotActive;
			}
			AnimatedThreadWorker.RunWorkerAsync();
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
			//WorkPackageReportBuilder reportBuilder = new WorkPackageReportBuilder
			//{
			//    ReportedAircraft = CurrentAircraft,
			//    ReportedWorkPackage = _currentWorkPackage
			//};
			//e.DisplayerText = "Work Package";
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//e.RequestedEntity = new ReportScreen(reportBuilder);
		   
			//SelectWorkscopePrintTasksForm form = new SelectWorkscopePrintTasksForm(_currentDirective);
			//if(form.ShowDialog()!= DialogResult.OK)
			//{
			//    e.Cancel = true;
			//    return;
			//}

			//_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
			//_workscopeReportBuilder.WorkPackage = _currentDirective;
			//_workscopeReportBuilder.AddDirectives(form.SelectedItems);
			//e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + _currentDirective.Title + "." + "Workscope";
			//e.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.Cancel = true;
		}
		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
		}
		#endregion

		#endregion
	}
}
