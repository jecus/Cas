using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Discrepancies
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class DiscrepanciesListScreen: ScreenControl
	{
		#region Fields

		private CommonCollection<Discrepancy> _initialDirectiveArray = new CommonCollection<Discrepancy>();
		private CommonCollection<Discrepancy> _resultDirectiveArray = new CommonCollection<Discrepancy>();

		private DiscrepanciesListView _directivesViewer;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(Discrepancy));

#if  KAC
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuItem _toolStripMenuItemHighlight;

		#endregion

		#region Constructors

		#region public DiscrepanciesListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public DiscrepanciesListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public DiscrepanciesListScreen(Aircraft currentAircraft)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public DiscrepanciesListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = currentAircraft.RegistrationNumber + " Discrepancies";

			InitToolStripMenuItems();
			InitListView();
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

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;
			
			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();

			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
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

			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
			headerControl.PrintButtonEnabled= _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Work Packages");

			_initialDirectiveArray.AddRange(GlobalObjects.DiscrepanciesCore.GetDiscrepancies(CurrentAircraft).ToArray());

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			
			_toolStripMenuItemOpen = new RadMenuItem();
			
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
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

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				var highLight = (Highlight) ((RadMenuItem) sender).Tag;
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
			//foreach (Discrepancy o in _directivesViewer.SelectedItems)
			//{
			//    ReferenceEventArgs refE = new ReferenceEventArgs();
			//    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//    refE.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + o.Title : o.Title;
			//    refE.RequestedEntity = new WorkPackageScreen(o);
			//    InvokeDisplayerRequested(refE);
			//}
		}

		#endregion

		#region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				CommonEditorForm form = new CommonEditorForm(_directivesViewer.SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
					AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		//{
		//    foreach (Discrepancy item in _directivesViewer.SelectedItems)
		//    {
		//        Discrepancy wp = item;
		//        if (wp.Status != WorkPackageStatus.Closed)
		//            GlobalObjects.CasEnvironment.Manipulator.Publish(item, DateTime.Now, "");
		//        else
		//        {
		//            switch (MessageBox.Show(@"This work package is already closed," +
		//                                     "\nif you want to republish it," +
		//                                     "\nrecordings created during its execution will be erased." + "\n\n Republish " + wp.Title + " work package?", (string)new GlobalTermsProvider()["SystemName"],
		//                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
		//                                MessageBoxDefaultButton.Button2))
		//            {
		//                case DialogResult.Yes:
		//                    GlobalObjects.CasEnvironment.Manipulator.Publish(item, DateTime.Now, "");
		//                    break;
		//                case DialogResult.No:
		//                    //arguments.Cancel = true;
		//                    break;
		//            }
		//        }
		//    }

		//    AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
		//    AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
		//    AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

		//    AnimatedThreadWorker.RunWorkerAsync();
		//}

		#endregion
		
		#region private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		/// <summary>
		/// Запрашивает распечатку рабочего пакета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		{
			//if (_directivesViewer.SelectedItem == null) return;

			//WorkPackage wp = _directivesViewer.SelectedItem;
			//if (wp.WorkPackageItemsLoaded == false)
			//    GlobalObjects.CasEnvironment.Manipulator.GetWorkPackageItemsWithCalculate(wp);

			//SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(wp);
			//form.ShowDialog();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		{
			//if (_directivesViewer.SelectedItem == null) return;
			
			//WorkPackage wp = _directivesViewer.SelectedItem;
			//if (wp.WorkPackageItemsLoaded == false)
			//    GlobalObjects.CasEnvironment.Manipulator.GetWorkPackageItemsWithCalculate(wp);

			//SelectWorkscopePrintTasksForm form = new SelectWorkscopePrintTasksForm(wp);
			//if (form.ShowDialog() != DialogResult.OK)
			//    return;

			//ReferenceEventArgs refE = new ReferenceEventArgs();

			//_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
			//_workscopeReportBuilder.WorkPackage = wp;
			//_workscopeReportBuilder.AddDirectives(form.SelectedItems);
			//refE.DisplayerText = CurrentAircraft.RegistrationNumber + "." + wp.Title + "." + "Workscope";
			//refE.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
			//refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//InvokeDisplayerRequested(refE);
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		//private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		//{
		//    DialogResult dlgResult = DialogResult.No;

		//    foreach (WorkPackage item in _directivesViewer.SelectedItems)
		//    {
		//        if (item.Status == WorkPackageStatus.Closed)
		//        {
		//            MessageBox.Show("Work package " + item.Title + " is already closed.",
		//                            (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
		//                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
		//            continue;
		//        }

		//        if (item.WorkPackageItemsLoaded == false)
		//            GlobalObjects.CasEnvironment.Manipulator.GetWorkPackageItemsWithCalculate(item);

		//        IEnumerable<WorkPackageRecord> blockedRecords =
		//        item.WorkPakageRecords
		//        .Where(rec => rec.Task != null &&
		//                      rec.Task.NextPerformances != null &&
		//                      rec.Task.NextPerformances.Count > 0 &&
		//                      rec.Task.NextPerformances.Where(np => np.BlockedByWP != null &&
		//                                                            np.BlockedByWP.ItemId != item.ItemId).Count() > 0);
		//        if (item.CanClose == false || blockedRecords.Count() > 0)
		//        {
		//            string message = "This work package can not be closed";
		//            foreach (WorkPackageRecord blockedRecord in blockedRecords)
		//            {
		//                NextPerformance np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByWP != null);
		//                message += string.Format("\nTask: {0} blocked by work package {1}",
		//                                            blockedRecord.Task,
		//                                            np.BlockedByWP);
		//            }
		//            if (item.MaxClosingDate < item.MinClosingDate)
		//            {
		//                message += string.Format("\nMin Closing Date: {0} better than Max Closing Date: {1}",
		//                                            item.MinClosingDate,
		//                                            item.MaxClosingDate);
		//            }
		//            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
		//                            MessageBoxButtons.OK, MessageBoxIcon.Error);
		//            continue;
		//        }

		//        WorkPackageClosingFormNew form = new WorkPackageClosingFormNew(item);
		//        form.ShowDialog();
		//        if (form.DialogResult == DialogResult.OK)
		//        {
		//            dlgResult = DialogResult.OK;
		//        } 
		//    }

		//    //Если хотя бы одно окно возвратило DialogResult.OK
		//    //производится перезагрузка элементов
		//    if (dlgResult == DialogResult.OK)
		//    {
		//        AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
		//        AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
		//        AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

		//        AnimatedThreadWorker.RunWorkerAsync();
		//    } 
		//}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			DeleteWorkPackage(); 
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new DiscrepanciesListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator2,
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

		private void DeleteWorkPackage()
		{
			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0) return;

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete Work package " + _directivesViewer.SelectedItems[0].Description + "?"
						: "Do you really want to delete selected Work packages? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();

				GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}   
		}

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<Discrepancy> initialCollection, ICommonCollection<Discrepancy> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Discrepancy> initialCollection, ICommonCollection<Discrepancy> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Discrepancy pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
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

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count > 0)
			{
				buttonDeleteSelected.Enabled = true;
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				buttonDeleteSelected.Enabled = false;
			}
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.Cancel = true;

			//IEnumerable<Discrepancy> list = _directivesViewer.GetItemsArray();
			//WorkPackageListReportBuilder reportBuilder = new WorkPackageListReportBuilder{ReportedAircraft = CurrentAircraft};
			//reportBuilder.AddDirectives(list.ToArray());

			//e.DisplayerText = "Work Package List";
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//e.RequestedEntity = new ReportScreen(reportBuilder);
		}
		#endregion

		#region private void ButtonReleaseToService(object sender, EventArgs e)

		////private void ButtonReleaseToService(object sender, EventArgs e)
		////{
		////    if (_directivesViewer.SelectedItem == null) return;

		////    Discrepancy wp = _directivesViewer.SelectedItem;
		////    GlobalObjects.CasEnvironment.Loader.LoadWorkPackageItems(wp);

		////    //ConcatenatePdfDocuments(wp);

		////    SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(wp);
		////    form.ShowDialog();
		////    //e.Cancel = true;
		////}

		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
		}
		#endregion

		#endregion
	}
}
