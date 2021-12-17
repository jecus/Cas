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
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ComponentChangeReport
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class ComponentTrackingListScreen : ScreenControl
	{
		#region Fields

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ITransferRecordFilterParams));
		private TransferRecordCollection _initialDirectiveArray = new TransferRecordCollection();
		private TransferRecordCollection _resultDirectiveArray = new TransferRecordCollection();

		private ComponentTrackingListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemHighlight;
		
		private ContextMenuStrip _buttonPrintMenuStrip;
		private ToolStripMenuItem _itemPrintComponentChangeReport;
		private ToolStripMenuItem _itemPrintTrackingList;
		private ToolStripMenuItem _itemPrintRequest;

		#endregion

		#region Constructors

		#region private ComponentTrackingListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private ComponentTrackingListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ComponentTrackingListScreen(Aircraft aircraft) : this()
		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="aircraft">Самолет, соержащий полеты</param>
		public ComponentTrackingListScreen(Aircraft aircraft) : this()
		{
			if (aircraft == null)
				throw new ArgumentNullException("aircraft", "Cannot display null-aircraft");

			CurrentAircraft = aircraft;
			StatusTitle = CurrentAircraft + " " + "Component change report";

			InitToolStripPrintMenuItems();
			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#region public ComponentTrackingListScreen(Store store)

		public ComponentTrackingListScreen(Store store) : this()
		{
			if (store == null)
				throw new ArgumentNullException("store", "Cannot display null-store");

			CurrentStore = store;
			StatusTitle = CurrentStore + " " + "Component change report";

			InitToolStripPrintMenuItems();
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

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if(_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if(_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Cancelled)
				return;
			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Transfer records");

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			if (CurrentAircraft != null)
			{
				_initialDirectiveArray.AddRange(GlobalObjects.TransferRecordCore.GetTransferRecordsFromAndTo(CurrentAircraft, null)
								 .Where(tr => tr.StartTransferDate >= dateTimePickerDateFrom.Value && tr.TransferDate <= dateTimePickerDateTo.Value));
			}
			else
			{
				_initialDirectiveArray.AddRange(GlobalObjects.TransferRecordCore.GetTransferRecordsFromAndTo(null, CurrentStore)
								  .Where(tr => tr.StartTransferDate >= dateTimePickerDateFrom.Value && tr.TransferDate <= dateTimePickerDateTo.Value));
			}
			

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(40, "filter Transfer records");

			AnimatedThreadWorker.ReportProgress(70, "filter Transfer records");

			AnimatedThreadWorker.ReportProgress(80, "filter documents");
			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			// 
			// _toolStripMenuItemOpen
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			_toolStripMenuItemOpen.Enabled = false;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			_toolStripMenuItemHighlight.Items.Clear();
			foreach (Highlight highlight in Highlight.HighlightList)
			{
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
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				var highLight = (Highlight)((RadMenuItem)sender).Tag;

				_directivesViewer.SelectedItems[i].Highlight = highLight;
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
			TransferRecordForm form = new TransferRecordForm(_directivesViewer.SelectedItem.ParentComponent, _directivesViewer.SelectedItem);
			form.Show();
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			DialogResult confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete TransferRecords " + _directivesViewer.SelectedItem.Description + "?"
						: "Do you really want to delete selected TransferRecords? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var selectedItems = new List<TransferRecord>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete TransferRecord: Parent container is invalid", "Operation failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new ComponentTrackingListView();
			_directivesViewer.IsStore = CurrentStore != null;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
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
			headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
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

			dateTimePickerDateFrom.Value = DateTime.Now.Month == 1 
				? new DateTime(DateTime.Now.Year - 1, 12, 1) 
				: new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
			
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		private void InitToolStripPrintMenuItems()
		{
			_buttonPrintMenuStrip = new ContextMenuStrip();
			_itemPrintComponentChangeReport = new ToolStripMenuItem { Text = "Component Change Report" };
			_itemPrintTrackingList = new ToolStripMenuItem { Text = "Tracking List" };
			_itemPrintRequest = new ToolStripMenuItem { Text = "Request" };

			if (CurrentAircraft != null)
			{
				_buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[]
				{
					_itemPrintComponentChangeReport, _itemPrintTrackingList, _itemPrintRequest
				});
			}
			else
			{
				_buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[]
				{
					_itemPrintTrackingList, _itemPrintRequest
				});
			}

			ButtonPrintMenuStrip = _buttonPrintMenuStrip;

		}

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == _itemPrintComponentChangeReport)
			{
				var reportBuilder = new ComponentChangeReportBuilder(CurrentAircraft, _initialDirectiveArray.OrderByDescending(f => f.StartTransferDate).ToArray());
				e.DisplayerText = CurrentAircraft.RegistrationNumber + " Component Change Report";
				e.RequestedEntity = new ReportScreen(reportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "ComponentTrackingListScreen (Component Change Report)");
			}
			else if (sender == _itemPrintTrackingList)
			{
				var reportBuilder = new TrackingListBuilder(CurrentOperator, _resultDirectiveArray.ToArray(),CurrentStore);
				reportBuilder.FilterSelection = _filter;
				e.DisplayerText = "Tracking List Report";
				e.RequestedEntity = new ReportScreen(reportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "ComponentTrackingListScreen (Tracking List)");
			}
			else if (sender == _itemPrintRequest)
			{
				Specialist released = null;
				Specialist received = null;

				if (_filter.Filters[9].Values.Length > 0)
					released = _filter.Filters[9].Values[0] as Specialist;
				if (_filter.Filters[8].Values.Length > 0)
					received = _filter.Filters[8].Values[0] as Specialist;

				if (released != null && received != null)
				{
					var reportBuilder = new TrackingListBuilder(CurrentOperator, _resultDirectiveArray.ToArray(), CurrentStore, received, released);
					reportBuilder.FilterSelection = _filter;
					e.DisplayerText = "Request Report";
					e.RequestedEntity = new ReportScreen(reportBuilder);
					GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "ComponentTrackingListScreen (Request)");
				}
			}

		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//Aircraft a = CurrentAircraft;

			//if (a == null) return;
			//e.RequestedEntity = new FlightScreen(_currentATLB, a);
			//e.DisplayerText = a.RegistrationNumber + ". New Flight";
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

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

		#region private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(TransferRecordCollection initialCollection, TransferRecordCollection resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection.ToArray());
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

		#endregion
	}
}
