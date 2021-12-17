﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Commercial;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.CommercialControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class RequestListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<Request> _initialDirectiveArray = new CommonCollection<Request>();
		private CommonCollection<Request> _resultDirectiveArray = new CommonCollection<Request>();

		private RequestListView _directivesViewer;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(Request));

#if  KAC
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemPrintWP;
		private RadMenuItem _toolStripMenuItemPrintWorkscope;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private List<RadMenuItem> _toolStripMenuItemsWorkPackages;
		private RadMenuItem _toolStripMenuItemHighlight;

		#endregion

		#region Constructors

		#region public RequestListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public RequestListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RequestListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public RequestListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			CurrentOperator = currentOperator;
			StatusTitle = currentOperator.Name + " Requests";

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

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages)
					item.Dispose();
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			if (_toolStripMenuItemPublish != null) _toolStripMenuItemPublish.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			if (_toolStripMenuItemPrintWP != null) _toolStripMenuItemPrintWP.Dispose();
			if (_toolStripMenuItemPrintWorkscope != null) _toolStripMenuItemPrintWorkscope.Dispose();
			
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		/// <summary>
		/// Производит действия после работы над списком элементов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
			headerControl.PrintButtonEnabled= _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		/// <summary>
		/// Производит работы над списком элементов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Work Packages");

			_initialDirectiveArray.AddRange(GlobalObjects.PackageCore.GetDirectivePackages<Request, RequestRecord>(CurrentOperator).ToArray());

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
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new List<RadMenuItem>();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripMenuItemPrintWP = new RadMenuItem();
			_toolStripMenuItemPrintWorkscope = new RadMenuItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			// 
			// toolStripMenuItemPrintWP
			// 
			_toolStripMenuItemPrintWP.Text = "Print Work package";
			_toolStripMenuItemPrintWP.Click += ToolStripMenuItemDeletePrintWP;
			// 
			// toolStripMenuItemPrintWorkscope
			// 
			_toolStripMenuItemPrintWorkscope.Text = "Print Work scope";
			_toolStripMenuItemPrintWorkscope.Click += ToolStripMenuItemDeletePrintWorkscope;

			_toolStripMenuItemsWorkPackages.Clear();
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
			foreach (Request o in _directivesViewer.SelectedItems)
			{
				ReferenceEventArgs refE = new ReferenceEventArgs();
				refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refE.DisplayerText = o.Title;
				refE.RequestedEntity = new RequestScreen(o);
				InvokeDisplayerRequested(refE);
			}
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
		private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		{
			foreach (Request item in _directivesViewer.SelectedItems)
			{
				Request wp = item;
				if (wp.Status != WorkPackageStatus.Closed)
					GlobalObjects.PackageCore.Publish<Request, RequestRecord>(item, DateTime.Now, "");
				else
				{
					switch (MessageBox.Show(@"This Request is already closed," +
											 "\nif you want to republish it," +
											 "\nrecordings created during its execution will be erased." + "\n\n Republish " + wp.Title + " Request?", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button2))
					{
						case DialogResult.Yes:
							GlobalObjects.PackageCore.Publish<Request, RequestRecord>(item, DateTime.Now, "");
							break;
						case DialogResult.No:
							//arguments.Cancel = true;
							break;
					}
				}
			}

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		/// <summary>
		/// Запрашивает распечатку рабочего пакета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			Request wp = _directivesViewer.SelectedItem;
			if (wp.PackageItemsLoaded == false)
				GlobalObjects.PackageCore.LoadDirectivePackageItems<Request, RequestRecord>(wp);

			//SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(wp);
			//form.ShowDialog();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;
			
			//Audit wp = _directivesViewer.SelectedItem;
			//if (wp.AuditItemsLoaded == false)
			//    GlobalObjects.CasEnvironment.Manipulator.GetAuditItemsWithCalculate(wp);

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

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			DialogResult dlgResult = DialogResult.No;

			foreach (Request item in _directivesViewer.SelectedItems)
			{
				if (item.Status == WorkPackageStatus.Closed)
				{
					MessageBox.Show("Request " + item.Title + " is already closed.",
									(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					continue;
				}

				if (item.PackageItemsLoaded == false)
					GlobalObjects.PackageCore.LoadDirectivePackageItems<Request, RequestRecord>(item);

				IEnumerable<RequestRecord> blockedRecords =
				item.PackageRecords.Where(rec => rec.Task != null &&
							  rec.Task.NextPerformances != null &&
							  rec.Task.NextPerformances.Count > 0 &&
							  rec.Task.NextPerformances.Any(np => np.BlockedByPackage != null &&
																  np.BlockedByPackage.ItemId != item.ItemId));
				if (item.CanClose == false || blockedRecords.Any())
				{
					string message = "This Request can not be closed";
					foreach (RequestRecord blockedRecord in blockedRecords)
					{
						NextPerformance np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByPackage != null);
						message += $"\nTask: {blockedRecord.Task} blocked by request {np.BlockedByPackage}";
					}
					if (item.MaxClosingDate < item.MinClosingDate)
					{
						message +=
							$"\nMin Closing Date: {item.MinClosingDate} better than Max Closing Date: {item.MaxClosingDate}";
					}
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					continue;
				}

				//AuditClosingFormNew form = new AuditClosingFormNew(item);
				//form.ShowDialog();
				//if (form.DialogResult == DialogResult.OK)
				//{
				//    dlgResult = DialogResult.OK;
				//} 
			}

			//Если хотя бы одно окно возвратило DialogResult.OK
			//производится перезагрузка элементов
			if (dlgResult == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			} 
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			DeleteItem(); 
		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			Request workOrder = new Request { Parent = CurrentOperator, ParentId = CurrentOperator.ItemId };
			CommonEditorForm form = new CommonEditorForm(workOrder);

			if (form.ShowDialog() == DialogResult.OK)
			{

				e.DisplayerText = workOrder.Title;
				e.RequestedEntity = new RequestScreen(workOrder);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new RequestListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemPublish,
				_toolStripMenuItemClose,
				_toolStripSeparator1,
				_toolStripMenuItemEdit,
				_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemPrintWP,
				_toolStripMenuItemPrintWorkscope,
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

		#region private void DeleteItem()
		private void DeleteItem()
		{
			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0) return;

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete Request " + _directivesViewer.SelectedItems[0].Title + "?"
						: "Do you really want to delete selected Requests ? ", "Confirm delete operation",
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
		#endregion

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

		#region private void FilterItems(IEnumerable<Request> initialCollection, ICommonCollection<Request> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Request> initialCollection, ICommonCollection<Request> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Request pd in initialCollection)
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
			//IEnumerable<Audit> list = _directivesViewer.GetItemsArray();
			//WorkPackageListReportBuilder reportBuilder = new WorkPackageListReportBuilder{ReportedAircraft = CurrentAircraft};
			//reportBuilder.AddDirectives(list.ToArray());

			//e.DisplayerText = "Work Package List";
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//e.RequestedEntity = new ReportScreen(reportBuilder);
			e.Cancel = true;
		}
		#endregion

		#region private void ButtonReleaseToService(object sender, EventArgs e)

		private void ButtonReleaseToService(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			Request wp = _directivesViewer.SelectedItem;
			GlobalObjects.PackageCore.LoadDirectivePackageItems<Request, RequestRecord>(wp);

			//SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(wp);
			//form.ShowDialog();
			//e.Cancel = true;
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
