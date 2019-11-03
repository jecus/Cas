using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.StoresControls;
using CASReports.Builders;
using CASReports.ReportTemplates;
using CASTerms;
using CrystalDecisions.Shared;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Setting;
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
	public partial class PurchaseOrderListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<PurchaseOrder> _purchaseArray = new CommonCollection<PurchaseOrder>();
		private ICommonCollection<PurchaseOrder> _resultArray = new CommonCollection<PurchaseOrder>();
		private readonly BaseEntityObject _parent;

		private PurchaseOrderListView _directivesViewer;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemMoveTo;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemReport;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private Filter filter;
		private RadMenuItem _toolStripMenuItemSendMail;

		#endregion

		#region Constructors

		#region public PurchaseOrderListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public PurchaseOrderListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PurchaseOrderListScreen(Aircraft currentAircraft) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public PurchaseOrderListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null) 
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Quotation orders";
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region public PurchaseOrderListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public PurchaseOrderListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Purchases";
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

			_purchaseArray.Clear();
			_purchaseArray = null;

			if (_toolStripMenuItemMoveTo != null) _toolStripMenuItemMoveTo.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
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

			_directivesViewer.SetItemsArray(_purchaseArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_purchaseArray.Clear();
			_resultArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				if (filter != null)
					_purchaseArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(filter));
				else _purchaseArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>());

				var supplierShipper =  GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[] { new CommonFilter<int>(Supplier.SupplierClassProperty, SupplierClass.Shipper.ItemId) });
				foreach (var order in _purchaseArray)
				{
					order.ShipCompany = supplierShipper.FirstOrDefault(i => i.ItemId == order.ShipCompanyId) ?? Supplier.Unknown;
					order.ShipTo = supplierShipper.FirstOrDefault(i => i.ItemId == order.ShipToId) ?? Supplier.Unknown;
				}
				
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Quotations", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation Quotations");

			AnimatedThreadWorker.ReportProgress(70, "filter Quotations");
			FilterItems(_purchaseArray, _resultArray);
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

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemMoveTo = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemReport = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemSendMail = new RadMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;

			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;

			_toolStripMenuItemSendMail.Text = "Send Mail";
			_toolStripMenuItemSendMail.Click += ToolStripMenuItemSendMailClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemMoveTo.Text = "Move to Store";
			_toolStripMenuItemMoveTo.Click += ToolStripMenuItemMoveToClick;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;

			_toolStripMenuItemReport.Text = "Show Report";
			_toolStripMenuItemReport.Click += _toolStripMenuItemReport_Click; 

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new RadItem[]
												{
													_toolStripMenuItemMoveTo,
													new RadMenuSeparatorItem(),
													_toolStripMenuItemPublish,
													_toolStripSeparator1,
													_toolStripMenuItemReport,
													_toolStripMenuItemSendMail,
													new RadMenuSeparatorItem(),
													_toolStripSeparator1,
													_toolStripMenuItemEdit,
													_toolStripMenuItemDelete

												});
		}

		private void ToolStripMenuItemSendMailClick(object sender, EventArgs e)
		{
			PrepareOrder(true);

			
			
		}

		#endregion

		#region private void _toolStripMenuItemReport_Click(object sender, EventArgs e)

		private void _toolStripMenuItemReport_Click(object sender, EventArgs e)
		{
			PrepareOrder();
		}

		#endregion

		private void PrepareOrder(bool isMailSend = false)
		{
			if (_directivesViewer.SelectedItem == null)
				return; ;

			var _order = _directivesViewer.SelectedItem;
			var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(new ICommonFilter[] { new CommonFilter<int>(PurchaseRequestRecord.ParentPackageIdProperty, _order.ItemId) });
			var ids = records.Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids), });
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds), });

			var department = GlobalObjects.CasEnvironment.NewLoader.GetObject<DepartmentDTO, Department>(new Filter("FullName", "Logistics & Stores Department "));

			var parentInitialId = (int)GlobalObjects.CasEnvironment.Execute($@"select i.ItemId from PurchaseOrders p
			left join RequestsForQuotation q on q.ItemID = p.ParentID
			left join InitialOrders i on i.ItemID = q.ParentID where p.ItemId = {_order.ItemId}").Tables[0].Rows[0][0];
			var initialRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", parentInitialId));
			var initial = GlobalObjects.CasEnvironment.NewLoader.GetObject<InitialOrderDTO, InitialOrder>(new Filter("ItemId", parentInitialId));

			var publisherId = GlobalObjects.CasEnvironment.ApiProvider.GetByIdAsync(_directivesViewer.SelectedItem.PublishedById)?.PersonnelId ?? -1;

			var personnel = GlobalObjects.CasEnvironment.Loader.GetObject<Specialist>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, publisherId));

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
			if (personnel == null)
			{
				MessageBox.Show($"Please attach personnel for user ({_directivesViewer.SelectedItem.PublishedByUser})",
					"Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			var builder = new PurchaseOrderReportNewBuilder(GlobalObjects.CasEnvironment.Operators[0], records, _order, department, personnel);

			PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
			if (!isMailSend)
			{
				var refArgs = new ReferenceEventArgs();
				refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refArgs.DisplayerText = $"iPurchaseOrderReport {_directivesViewer.SelectedItem.Title}";
				refArgs.RequestedEntity = new ReportScreen(builder);
				Program.MainDispatcher.DisplayerRequest(refArgs);
				refArgs.Cancel = false;
			}
			else
			{
				var doc = (PurchaseOrderReportNew)builder.GenerateReport();
				ExportOptions CrExportOptions;
				var CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
				CrDiskFileDestinationOptions.DiskFileName = "C:\\SampleReport.pdf";
				CrExportOptions = doc.ExportOptions;
				{
					CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
					CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
					CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
					CrExportOptions.FormatOptions = CrFormatTypeOptions;
				}
				var stream = doc.ExportToStream(ExportFormatType.PortableDocFormat);

				var setting = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();
				var sendMail = new MailSender(setting.GlobalSetting.MailSettings);
				sendMail.SendPurchaseEmail(records, "", personnel, stream);
			}
			
		}

		private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null)
				return;

			_directivesViewer.SelectedItem.Status = WorkPackageStatus.Published;
			_directivesViewer.SelectedItem.PublishingDate = DateTime.Now;
			_directivesViewer.SelectedItem.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
			_directivesViewer.SelectedItem.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
			GlobalObjects.CasEnvironment.NewKeeper.Save(_directivesViewer.SelectedItem);
			
			AnimatedThreadWorker.RunWorkerAsync();
		}


		#region private void ToolStripMenuItemMoveToClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemMoveToClick(object sender, EventArgs e)
		{
			var form = new MoveProductForm(_directivesViewer.SelectedItem);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_directivesViewer.SelectedItem.Status = WorkPackageStatus.Published;
				_directivesViewer.SelectedItem.ClosingDate = DateTime.Now;
				_directivesViewer.SelectedItem.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				_directivesViewer.SelectedItem.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(_directivesViewer.SelectedItem);
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				GlobalObjects.CasEnvironment.Manipulator.Delete(_directivesViewer.SelectedItem);
			}
			else
			{
				foreach (PurchaseOrder rfq in _directivesViewer.SelectedItems)
				{
					GlobalObjects.CasEnvironment.Manipulator.Delete(rfq);
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			var selected = _directivesViewer.SelectedItems.ToArray();

			try
			{
				foreach (var rfq in selected)
				{
					if (rfq.Status == WorkPackageStatus.Closed)
					{
						MessageBox.Show("Purchase Order " + rfq.Title + " is already closed.",
							(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						continue;
					}

					rfq.Status = WorkPackageStatus.Closed;
					rfq.ClosingDate = DateTime.Now;
					rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq);
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

		#region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(_directivesViewer.SelectedItem);
				PurchaseRequestForm editForm = new PurchaseRequestForm(_directivesViewer.SelectedItems[0]);
				if(editForm.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}   
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new PurchaseOrderListView
									{
										CustomMenu = _contextMenuStrip,
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
				   return;
				else if (_directivesViewer.SelectedItems.Count == 1)
				{
					PurchaseOrder po = _directivesViewer.SelectedItem;
					if (po.Status == WorkPackageStatus.Closed || po.Status == WorkPackageStatus.Opened)
					{
						_toolStripMenuItemMoveTo.Enabled = true;
						_toolStripMenuItemPublish.Enabled = true;
						_toolStripMenuItemReport.Enabled = false;
					}
					else if (po.Status == WorkPackageStatus.Published)
					{
						_toolStripMenuItemMoveTo.Enabled = false;
						_toolStripMenuItemPublish.Enabled = false;
						_toolStripMenuItemReport.Enabled = true;
					}
					else
					{
						_toolStripMenuItemMoveTo.Enabled = true;
						_toolStripMenuItemPublish.Enabled = true;
						_toolStripMenuItemReport.Enabled = false;
					}

				}
				else
				{
					_toolStripMenuItemMoveTo.Enabled = true;
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
				headerControl.EditButtonEnabled= false;
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
						? "Do you really want to delete Purchase order " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete Purchase orders? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				List<PurchaseOrder> selectedItems = new List<PurchaseOrder>();
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

		#region private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(_directivesViewer.SelectedItem);
			
			ReferenceEventArgs refe = new ReferenceEventArgs
			{
				DisplayerText = "Release To Service",
				TypeOfReflection = ReflectionTypes.DisplayInNew,
				//RequestedEntity = new DispatcheredRequestForQuotationReport(_directivesViewer.SelectedItem)
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

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderButtonReloadClick(object sender, EventArgs e)
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

		private void HeaderControlButtonPrintRequested(object sender, ReferenceEventArgs e)
		{
			//throw new NotImplementedException();
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_purchaseArray, _resultArray);

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
		private void FilterItems(IEnumerable<PurchaseOrder> initialCollection, ICommonCollection<PurchaseOrder> resultCollection)
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

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _purchaseArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonAddNewClick(object sender, EventArgs e)

		private void ButtonAddNewClick(object sender, EventArgs e)
		{

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
			var res = GlobalObjects.CasEnvironment.Execute(OrdersQueries.PurchaseSearch(TextBoxFilter.Text));
			var ids = new List<int>();
			foreach (DataRow dRow in res.Tables[0].Rows)
				ids.Add(int.Parse(dRow[0].ToString()));

			filter = new Filter("ItemId", ids);
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
