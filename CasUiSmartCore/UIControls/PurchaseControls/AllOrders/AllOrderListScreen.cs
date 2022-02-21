using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CAS.UI.UIControls.PurchaseControls.Quatation;
using CASReports.Builders;
using CASReports.ReportTemplates;
using CASTerms;
using CrystalDecisions.Shared;
using Entity.Abstractions.Filters;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using SmartCore.Mail;
using SmartCore.Packages;
using SmartCore.Purchase;
using SmartCore.Queries;
using Telerik.WinControls.UI;


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
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemFreightQ;

		private Filter initialfilter = null;
		private Filter quotationfilter = null;
		private Filter purchasefilter = null;

		string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

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
				new RadMenuSeparatorItem(),
				_toolStripMenuItemFreightQ,
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
					_toolStripMenuItemFreightQ.Enabled = wp is PurchaseOrder && wp.Status == WorkPackageStatus.Opened;
				}

				else
				{
					_toolStripMenuItemClose.Enabled = true;
					_toolStripMenuItemPublish.Enabled = true;
					_toolStripMenuItemFreightQ.Enabled = false;
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemFreightQ = new RadMenuItem();
			
			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += _toolStripMenuItemEdit_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += _toolStripMenuItemPublish_Click;
			// 
			// toolStripMenuItemFreightQ
			// 
			_toolStripMenuItemFreightQ.Text = "Freight Q";
			_toolStripMenuItemFreightQ.Click += _toolStripMenuItemFreightQ_Click;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += _toolStripMenuItemClose_Click;
		}

		private void _toolStripMenuItemFreightQ_Click(object sender, EventArgs e)
		{
			new QuotationFreightOrderForm(_directivesViewer.SelectedItem as PurchaseOrder).ShowDialog();
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
					GlobalObjects.NewKeeper.Save(rfq as BaseEntityObject);
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

		#region private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItems.Count == 0)
				return;

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
						GlobalObjects.NewKeeper.Save(rfq as BaseEntityObject);

						SendQuotationOrder(rfq as RequestForQuotation);
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

				GlobalObjects.NewKeeper.Save(quatation);

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
				GlobalObjects.NewKeeper.Save(initial);

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
					GlobalObjects.NewKeeper.Save(purch);
					SendPurchaseOrder(purch);
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
				GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);
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

		#region private void ButtonFilterClick(object sender, EventArgs e)

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

		#endregion

		#region private void CheckBoxAll_CheckedChanged(object sender, System.EventArgs e)

		private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxAll.Enabled = false;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region Mails

		private void SendPurchaseOrder(PurchaseOrder _order)
		{
			//var res = MessageBox.Show("Do you really want sent Mail?", "Information", MessageBoxButtons.YesNo,
			//	MessageBoxIcon.Information);

			var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(new ICommonFilter[]
				{new CommonFilter<int>(BasePackageRecord.ParentPackageIdProperty, _order.ItemId)});
			var ids = records.Select(s => s.SupplierId).Distinct().ToList();
			ids.Add(_order.ShipToId);
			ids.Add(_order.ShipCompanyId);
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()),});
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds),});

			var department =
				GlobalObjects.CasEnvironment.NewLoader.GetObject<DepartmentDTO, Department>(new Filter("FullName",
					"Logistics & Stores Department "));

			var parentInitialId = (int) GlobalObjects.CasEnvironment.Execute($@"select i.ItemId from PurchaseOrders p
			left join RequestsForQuotation q on q.ItemID = p.ParentID
			left join InitialOrders i on i.ItemID = q.ParentID where p.ItemId = {_order.ItemId}").Tables[0].Rows[0][0];
			var initialRecords =
				GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(
					new Filter("ParentPackageId", parentInitialId));
			var initial =
				GlobalObjects.CasEnvironment.NewLoader.GetObject<InitialOrderDTO, InitialOrder>(new Filter("ItemId",
					parentInitialId));

			var publisherId = GlobalObjects.CasEnvironment.ApiProvider
				                  .GetByIdAsync(_directivesViewer.SelectedItem.PublishedById)?.PersonnelId ?? -1;

			var personnel =
				GlobalObjects.CasEnvironment.Loader.GetObject<Specialist>(
					new CommonFilter<int>(BaseEntityObject.ItemIdProperty, publisherId));

			var destinations = new List<BaseEntityObject>();
			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

			foreach (var record in records)
			{
				record.ParentInitialRecord = initialRecords.FirstOrDefault(i => i.ProductId == record.PackageItemId);
				if (record.ParentInitialRecord != null)
					record.ParentInitialRecord.ParentPackage = initial;
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				record.Supplier = suppliers.FirstOrDefault(i => i.ItemId == record.SupplierId);

				if (record.ParentInitialRecord != null)
					record.ParentInitialRecord.DestinationObject = destinations.FirstOrDefault(i =>
						i.ItemId == record.ParentInitialRecord.DestinationObjectId &&
						record.ParentInitialRecord.DestinationObjectType.ItemId == i.SmartCoreObjectType.ItemId);
			}

			_order.Supplier = records.FirstOrDefault(i => i.Supplier != null).Supplier;
			_order.ShipCompany = suppliers.FirstOrDefault(i => i.ItemId == _order.ShipCompanyId);
			_order.ShipTo = suppliers.FirstOrDefault(i => i.ItemId == _order.ShipToId);
			var airportCode = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<AirportCodeDTO, AirportsCodes>(_order.StationId);

			if (personnel == null)
			{
				MessageBox.Show($"Please attach personnel for user ({_directivesViewer.SelectedItem.PublishedByUser})",
					"Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			var builder = new PurchaseOrderReportNewBuilder(GlobalObjects.CasEnvironment.Operators[0], records, _order,
				department, personnel);

			var doc = (PurchaseOrderReportNew)builder.GenerateReport();
			var CrFormatTypeOptions = new PdfRtfWordFormatOptions();
			var CrDiskFileDestinationOptions = new DiskFileDestinationOptions {DiskFileName = "C:\\SampleReport.pdf"};
			var CrExportOptions = doc.ExportOptions;
			{
				CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
				CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
				CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
				CrExportOptions.FormatOptions = CrFormatTypeOptions;
			}
			var sendMail = new MailSender(GlobalObjects.CasEnvironment.NewLoader);
			sendMail.SendPurchaseEmail(records, "", personnel, doc.ExportToStream(ExportFormatType.PortableDocFormat));
			sendMail.SendPurchaseToShipper("", _order.ShipCompany , personnel, airportCode.ShortName, doc.ExportToStream(ExportFormatType.PortableDocFormat));


		}

		private void SendQuotationOrder(RequestForQuotation _quotation)
		{
			var personnel = GlobalObjects.CasEnvironment.Loader.GetObject<Specialist>(
				new CommonFilter<int>(BaseEntityObject.ItemIdProperty,
					GlobalObjects.CasEnvironment.IdentityUser.PersonnelId));

			if (personnel == null)
			{
				MessageBox.Show(
					$"Please attach personnel for user ({GlobalObjects.CasEnvironment.IdentityUser.ItemId})",
					"Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			var destinations = new List<BaseEntityObject>();
			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

			var records =
				GlobalObjects.CasEnvironment.NewLoader
					.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(
						new Filter("ParentPackageId", _quotation.ItemId));
			var ids = records.SelectMany(i => i.SupplierPrice).Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids),});
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds),});


			var parentInitialId = (int) GlobalObjects.CasEnvironment.Execute(
					$@"select i.ItemId from RequestsForQuotation q
			left join InitialOrders i on i.ItemID = q.ParentID where q.ItemId = {_quotation.ItemId}").Tables[0]
				.Rows[0][0];
			var _initialRecords =
				GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(
					new Filter("ParentPackageId", parentInitialId));

			foreach (var record in records)
			{
				record.ParentInitialRecord = _initialRecords.FirstOrDefault(i => i.ProductId == record.PackageItemId);
				if (record.ParentInitialRecord != null)
					record.ParentInitialRecord.DestinationObject = destinations.FirstOrDefault(i =>
						i.ItemId == record.ParentInitialRecord.DestinationObjectId &&
						record.ParentInitialRecord.DestinationObjectType.ItemId == i.SmartCoreObjectType.ItemId);
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				foreach (var price in record.SupplierPrice)
				{
					price.Supplier = suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);
					price.Parent = record;
				}
			}

			foreach (var g in records.SelectMany(i => i.SupplierPrice).GroupBy(i => i.Supplier))
			{
				var sendMail = new MailSender(GlobalObjects.CasEnvironment.NewLoader);
				sendMail.SendQuotationEmail(g.Select(i => i.Parent).ToList(), "", personnel);
			}

		}

		#endregion

		private bool CheckEmail(string email)
		{
			return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
		}

		#endregion
	}
}
