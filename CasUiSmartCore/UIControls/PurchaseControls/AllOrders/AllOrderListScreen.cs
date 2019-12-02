using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Queries;
using Telerik.WinControls.UI;
using Filter = EntityCore.Filter.Filter;

namespace CAS.UI.UIControls.PurchaseControls.AllOrders
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class AllOrderListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<ILogistic> _initialArray = new CommonCollection<ILogistic>();
		private ICommonCollection<ILogistic> _resultArray = new CommonCollection<ILogistic>();
		private readonly BaseEntityObject _parent;
		
		private AllOrderListView _directivesViewer;
		
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemCreateQuatation;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemCreatePurchase;

		private Filter initialfilter = null;
		private Filter quotationfilter = null;
		private Filter purchasefilter = null;

		#endregion

		#region Constructors

		#region private InitialOrderListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private AllOrderListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public InitialOrderListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public AllOrderListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Initials";
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

			_initialArray.Clear();
			_initialArray = null;

			if (_directivesViewer != null)
				_directivesViewer.Dispose();

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
			
			_directivesViewer.SetItemsArray(_resultArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
			checkBoxAll.Enabled = true;
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_initialArray.Clear();
			_resultArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Orders");

			try
			{
				if (!checkBoxAll.Checked)
				{
					if (initialfilter != null)
					{
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderDTO, InitialOrder>(new[]
							{
								initialfilter,
								new Filter("Status", WorkPackageStatus.Opened)
							}));
					}
					else
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderDTO, InitialOrder>(
								new Filter("Status", WorkPackageStatus.Opened)));

					if (quotationfilter != null)
					{
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader
								.GetObjectList<RequestForQuotationDTO, RequestForQuotation>(new[]
								{
									quotationfilter,
									new Filter("Status", WorkPackageStatus.Opened)
								}));

					}
					else
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader
								.GetObjectList<RequestForQuotationDTO, RequestForQuotation>(new Filter("Status",
									WorkPackageStatus.Opened)));

					if (purchasefilter != null)
					{
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(new[]
							{
								purchasefilter,
								new Filter("Status", WorkPackageStatus.Published)
							}));
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(new[]
							{
								purchasefilter,
								new Filter("Status", WorkPackageStatus.Opened),
							}));
					}
					else
					{
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(new[]
							{
								new Filter("Status", WorkPackageStatus.Published)
							}));
						_initialArray.AddRange(
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(new[]
							{
								new Filter("Status", WorkPackageStatus.Opened),

							}));

					}
				}
				else
				{
					_initialArray.AddRange(
						GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderDTO, InitialOrder>());
					_initialArray.AddRange(
						GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationDTO, RequestForQuotation>());
					_initialArray.AddRange(
						GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>());
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Orders", ex);
			}

			AnimatedThreadWorker.ReportProgress(70, "filter Orders");
			FilterItems(_initialArray, _resultArray);
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
		
		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new AllOrderListView()
									{
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemPublish,
				_toolStripMenuItemClose,
				_toolStripSeparator1,
				_toolStripMenuItemEdit);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				else if (_directivesViewer.SelectedItems.Count == 1)
				{
					var wp = _directivesViewer.SelectedItem;
					if (wp.Status == WorkPackageStatus.Closed || wp.Status == WorkPackageStatus.Opened)
					{
						_toolStripMenuItemClose.Enabled = false;
						_toolStripMenuItemPublish.Enabled = true;
					}
					else if (wp.Status == WorkPackageStatus.Published)
					{
						_toolStripMenuItemClose.Enabled = true;
						_toolStripMenuItemPublish.Enabled = false;
					}
					else
					{
						_toolStripMenuItemClose.Enabled = true;
						_toolStripMenuItemPublish.Enabled = true;
					}

					_toolStripMenuItemCreateQuatation.Enabled = true;

					if (wp is InitialOrder)
					{
						_toolStripMenuItemCreatePurchase.Enabled = false;
						_toolStripMenuItemCreateQuatation.Enabled = true;
					}
					else if (wp is RequestForQuotation)
					{
						_toolStripMenuItemCreatePurchase.Enabled = true;
						_toolStripMenuItemCreateQuatation.Enabled = false;
					}
					else
					{
						_toolStripMenuItemCreatePurchase.Enabled = false;
						_toolStripMenuItemCreateQuatation.Enabled = false;
					}
				}

				else
				{
					_toolStripMenuItemCreateQuatation.Enabled = false;
					_toolStripMenuItemClose.Enabled = true;
					_toolStripMenuItemPublish.Enabled = true;
					_toolStripMenuItemCreatePurchase.Enabled = false;
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemCreateQuatation = new RadMenuItem();
			_toolStripMenuItemCreatePurchase = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			
			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += _toolStripMenuItemEdit_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += _toolStripMenuItemPublish_Click;
			// 
			// toolStripMenuItemCreatePurchas
			//
			_toolStripMenuItemCreatePurchase.Text = "Create Purchase Order";
			_toolStripMenuItemCreatePurchase.Click += _toolStripMenuItemCreatePurchase_Click; ;
			// 
			// toolStripMenuItemCreateQuatation
			//
			_toolStripMenuItemCreateQuatation.Text = "Create Quatation Order";
			_toolStripMenuItemCreateQuatation.Click += _toolStripMenuItemCreateQuatation_Click;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += _toolStripMenuItemClose_Click;
		}

		#endregion

		#region private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)

		private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)

		private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			
		}

		#endregion

		#region private void _toolStripMenuItemClose_Click(object sender, EventArgs e)

		private void _toolStripMenuItemClose_Click(object sender, EventArgs e)
		{
			var selected = _directivesViewer.SelectedItems.ToArray();

			try
			{
				foreach (var rfq in selected)
				{
					if (rfq.Status == WorkPackageStatus.Closed)
					{
						MessageBox.Show("Order " + rfq.Title + " is already closed.",
							(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						continue;
					}

					rfq.Status = WorkPackageStatus.Closed;
					rfq.ClosingDate = DateTime.Now;
					rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq as BaseEntityObject);
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				throw;
			}

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		private void _toolStripMenuItemCreateQuatation_Click(object sender, EventArgs e)
		{

		}

		#region private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems[0] is RequestForQuotation)
			{
				var editForm = new CreatePurchaseOrderForm(_directivesViewer.SelectedItems[0] as RequestForQuotation);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					MessageBox.Show("Create purchase successful", "Message infomation", MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					foreach (var rfq in _directivesViewer.SelectedItems)
					{
						if (rfq.Status == WorkPackageStatus.Published)
						{
							MessageBox.Show("Initional Order " + rfq.Title + " is already publisher.",
								(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
							continue;
						}

						rfq.Status = WorkPackageStatus.Published;
						rfq.PublishingDate = DateTime.Now;
						rfq.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
						rfq.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
						GlobalObjects.CasEnvironment.NewKeeper.Save(rfq as BaseEntityObject);
					}
				}
				AnimatedThreadWorker.RunWorkerAsync();
			}
			else if (_directivesViewer.SelectedItems[0] is InitialOrder)
			{
				var initial = _directivesViewer.SelectedItems[0] as InitialOrder;
				var quatation = new RequestForQuotation
				{
					Parent = initial,
					ParentType = initial.SmartCoreObjectType,
					Title = initial.Title,
					OpeningDate = DateTime.Now,
					Author = initial.Author,
					Remarks = initial.Remarks,
					Number = initial.Number,
				};

				GlobalObjects.CasEnvironment.NewKeeper.Save(quatation);

				var initialRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", initial.ItemId));
				var ids = initialRecords.Select(i => i.ProductId);
				if (ids.Count() > 0)
				{
					var product = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter("ItemId", ids));
					foreach (var addedInitialOrderRecord in initialRecords)
						addedInitialOrderRecord.Product = product.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
				}

				foreach (var record in initialRecords)
				{
					var newquatationRecord = new RequestForQuotationRecord(quatation.ItemId, record.Product, record.Quantity);
					newquatationRecord.Priority = record.Priority;
					newquatationRecord.Measure = record.Measure;
					newquatationRecord.DeferredCategory = record.DeferredCategory;
					newquatationRecord.CostCondition = record.CostCondition;
					newquatationRecord.DestinationObjectType = record.DestinationObjectType;
					newquatationRecord.DestinationObjectId = record.DestinationObjectId;
					newquatationRecord.Remarks = record.Remarks;
					newquatationRecord.LifeLimit = new Lifelength(record.LifeLimit);
					newquatationRecord.LifeLimitNotify = new Lifelength(record.LifeLimitNotify);

					GlobalObjects.CasEnvironment.Keeper.Save(newquatationRecord);
				}
				
				initial.Status = WorkPackageStatus.Published;
				initial.PublishingDate = DateTime.Now;
				initial.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				initial.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(initial);

				var form = new QuatationOrderFormNew(quatation);
				if (form.ShowDialog() == DialogResult.OK)
				{
					MessageBox.Show("Create quatation successful", "Message infomation", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
				AnimatedThreadWorker.RunWorkerAsync();
			}
			else if (_directivesViewer.SelectedItems[0] is PurchaseOrder)
			{
				var purch = _directivesViewer.SelectedItem as PurchaseOrder;
				//var form = new MoveProductForm(purch);
				//if (form.ShowDialog() == DialogResult.OK)
				//{
					purch.Status = WorkPackageStatus.Published;
					purch.PublishingDate = DateTime.Now;
					purch.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					purch.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(purch);
				//}
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void _toolStripMenuItemEdit_Click(object sender, EventArgs e)

		private void _toolStripMenuItemEdit_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			if (_directivesViewer.SelectedItem is InitialOrder)
			{
				var editForm = new InitialOrderFormNew(_directivesViewer.SelectedItem as InitialOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else if (_directivesViewer.SelectedItem is RequestForQuotation)
			{
				var editForm = new QuatationOrderFormNew(_directivesViewer.SelectedItem as RequestForQuotation);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else
			{
				var editForm = new PurchaseOrderForm(_directivesViewer.SelectedItem as PurchaseOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
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

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			var confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Order " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete Orders? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var selectedItems = new List<ILogistic>();
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
			var form = new InitialOrderFormNew(new InitialOrder() { ParentId = CurrentParent.ItemId, ParentType = CurrentParent.SmartCoreObjectType });
			if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			initialfilter = null;
			quotationfilter = null;
			purchasefilter = null;
			TextBoxFilter.Clear();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialArray);

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

			FilterItems(_initialArray, _resultArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<InitialOrder> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<ILogistic> initialCollection, ICommonCollection<ILogistic> resultCollection)
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
					var acceptable = true;
					foreach (var filter in _filter)
						acceptable = filter.Acceptable(pd as BaseEntityObject); if (!acceptable) break;

					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					var acceptable = true;
					foreach (var filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd as BaseEntityObject); if (acceptable) break;
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
				initialfilter = null;
				quotationfilter = null;
				purchasefilter = null;
				AnimatedThreadWorker.RunWorkerAsync();
				return;
			}
			var initial = GlobalObjects.CasEnvironment.Execute(OrdersQueries.InitialSearch(TextBoxFilter.Text));
			var quotation = GlobalObjects.CasEnvironment.Execute(OrdersQueries.QuotationSearch(TextBoxFilter.Text));
			var purchase = GlobalObjects.CasEnvironment.Execute(OrdersQueries.PurchaseSearch(TextBoxFilter.Text));

			var initialids = new List<int>();
			foreach (DataRow dRow in initial.Tables[0].Rows)
				initialids.Add(int.Parse(dRow[0].ToString()));

			var quotationids = new List<int>();
			foreach (DataRow dRow in quotation.Tables[0].Rows)
				quotationids.Add(int.Parse(dRow[0].ToString()));

			var purchaseids = new List<int>();
			foreach (DataRow dRow in purchase.Tables[0].Rows)
				purchaseids.Add(int.Parse(dRow[0].ToString()));

			initialfilter = new Filter("ItemId", initialids);
			quotationfilter = new Filter("ItemId", quotationids);
			purchasefilter = new Filter("ItemId", purchaseids);
			AnimatedThreadWorker.RunWorkerAsync();
		}

		private void CheckBoxAll_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBoxAll.Enabled = false;
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
