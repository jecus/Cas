using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using SmartCore.Mail;
using SmartCore.Purchase;
using SmartCore.Queries;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Filter = EntityCore.Filter.Filter;

namespace CAS.UI.UIControls.PurchaseControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class RequestForQuotationListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<RequestForQuotation> _quotatioArray = new CommonCollection<RequestForQuotation>();
		private ICommonCollection<RequestForQuotation> _resultArray = new CommonCollection<RequestForQuotation>();

		private readonly BaseEntityObject _parent;
		private RequestForQuotationListView _directivesViewer;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemCreatePurchase;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuSeparatorItem _toolStripSeparator1;

		private Filter filter = null;

		#endregion

		#region Constructors

		#region private RequestForQuotationListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private RequestForQuotationListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RequestForQuotationListScreen(Aircraft currentAircraft) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public RequestForQuotationListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null) 
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Aircraft Quotations";
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region public RequestForQuotationListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public RequestForQuotationListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Quotations";
			labelTitle.Visible = false;
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

			_quotatioArray.Clear();
			_quotatioArray = null;

			if (_toolStripMenuItemCreatePurchase != null) _toolStripMenuItemCreatePurchase.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
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
				labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
			}
			
			_directivesViewer.SetItemsArray(_quotatioArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_quotatioArray.Clear();
			_resultArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				if (filter != null)
					_quotatioArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationDTO, RequestForQuotation>(filter));
				else _quotatioArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationDTO, RequestForQuotation>());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Quotations", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation Quotations");

			AnimatedThreadWorker.ReportProgress(70, "filter Quotations");

			AnimatedThreadWorker.ReportProgress(100, "Complete");
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

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemCreatePurchase = new RadMenuItem();
			
			_toolStripMenuItemCreatePurchase.Text = "Publish";
			_toolStripMenuItemCreatePurchase.Click += _toolStripMenuItemCreatePurchase_Click; ;

			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
			
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
			
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			var selected = _directivesViewer.SelectedItems.ToArray();

			foreach (var rfq in selected)
			{
				if (rfq.Status == WorkPackageStatus.Closed)
				{
					MessageBox.Show("Initional Order " + rfq.Title + " is already closed.",
						(string) new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					continue;
				}

				rfq.Status = WorkPackageStatus.Closed;
				rfq.ClosingDate = DateTime.Now;
				rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(rfq);
			}

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion
		
		#region private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)

		private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count != 1) return;

			var records = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(new Filter("ParentPackageId", _directivesViewer.SelectedItem.ItemId));

			if (records.Any(i => i.SupplierPrice.Count == 0))
			{
				MessageBox.Show("Please add supplier for all products.", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}
			var editForm = new CreatePurchaseOrderForm(_directivesViewer.SelectedItems[0]);
			if (editForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("Create purchase successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				_directivesViewer.SelectedItems[0].Status = WorkPackageStatus.Published;
				_directivesViewer.SelectedItems[0].PublishingDate = DateTime.Now;
				_directivesViewer.SelectedItems[0].PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				_directivesViewer.SelectedItems[0].PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(_directivesViewer.SelectedItems[0]);
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count != 1) return;

			var editForm = new QuatationOrderFormNew(_directivesViewer.SelectedItems[0]);
			if (editForm.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new RequestForQuotationListView
									{
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemCreatePurchase,
				_toolStripMenuItemClose,
				_toolStripSeparator1,
				_toolStripMenuItemEdit);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				else if (_directivesViewer.SelectedItems.Count == 1)
				{
					RequestForQuotation wp = _directivesViewer.SelectedItem;
					if (wp.Status == WorkPackageStatus.Closed || wp.Status == WorkPackageStatus.Opened)
					{
						_toolStripMenuItemClose.Enabled = false;
					}
					else if (wp.Status == WorkPackageStatus.Published)
					{
						_toolStripMenuItemClose.Enabled = true;
					}
					else
					{
						_toolStripMenuItemClose.Enabled = true;
					}

					_toolStripMenuItemCreatePurchase.Enabled = wp.Status == WorkPackageStatus.Opened;
				}
				else
				{
					_toolStripMenuItemClose.Enabled = true;
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

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			DialogResult confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Request for quotation " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete Request for quotations? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				List<RequestForQuotation> selectedItems = new List<RequestForQuotation>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);
				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region private void ButtonAddNewClick(object sender, EventArgs e)

		private void ButtonAddNewClick(object sender, EventArgs e)
		{

		}
		#endregion

		#region private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			GlobalObjects.PurchaseCore.LoadRequestForQuotationItems(_directivesViewer.SelectedItem);
			RequestForQuotationReportBuilder builder = new RequestForQuotationReportBuilder(_directivesViewer.SelectedItem);
			
			ReferenceEventArgs refe = new ReferenceEventArgs
			{
				DisplayerText = "Release To Service",
				TypeOfReflection = ReflectionTypes.DisplayInNew,
				RequestedEntity = new ReportScreen(builder)
			};
			InvokeDisplayerRequested(refe);
			//  MessageBox.Show("Показать репорт с распечаткой титульной страницы");
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void headerControl_ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderQuotationButtonReloadClick(object sender, EventArgs e)
		{
			filter = null;
			TextBoxFilter.Clear();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderQuotationButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _quotatioArray);

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
			_resultArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_quotatioArray, _resultArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<RequestForQuotation> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<RequestForQuotation> initialCollection, ICommonCollection<RequestForQuotation> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
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

		#endregion


		private void ButtonFilterClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxFilter.Text))
			{
				filter = null;
				AnimatedThreadWorker.RunWorkerAsync();
				return;
			}
			var res = GlobalObjects.CasEnvironment.Execute(OrdersQueries.QuotationSearch(TextBoxFilter.Text));
			var ids = new List<int>();
			foreach (DataRow dRow in res.Tables[0].Rows)
				ids.Add(int.Parse(dRow[0].ToString()));

			filter = new Filter("ItemId", ids);
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
