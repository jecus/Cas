using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class QuotationFreightOrderForm : MetroForm
	{
		#region Fields

		private List<PurchaseRequestRecord> _addedRecord = new List<PurchaseRequestRecord>();

		private PurchaseOrder _order;
		private List<Supplier> _supplierShipper = new List<Supplier>();
		private List<AirportsCodes> _airportsCodes = new List<AirportsCodes>();

		#endregion

		#region Constructor

		public QuotationFreightOrderForm()
		{
			InitializeComponent();
		}

		public QuotationFreightOrderForm(PurchaseOrder order):this()
		{
			_order = order;
			
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			UpdateControls();
			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{

			var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(new ICommonFilter[]{new CommonFilter<int>(PurchaseRequestRecord.ParentPackageIdProperty, _order.ItemId) });
			var ids = records.Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids), });
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds), });

			_supplierShipper.Clear();
			_supplierShipper.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[] { new CommonFilter<int>(Supplier.SupplierClassProperty, SupplierClass.Shipper.ItemId) }));
			_order.ShipCompany = _supplierShipper.FirstOrDefault(i => i.ItemId == _order.ShipCompanyId) ?? Supplier.Unknown;

			_airportsCodes.Clear();
			_airportsCodes.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AirportCodeDTO, AirportsCodes>().OrderBy(i => i.ShortName));
			_airportsCodes.Add(AirportsCodes.Unknown);

			var parentInitialId = (int)GlobalObjects.CasEnvironment.Execute($@"select i.ItemId from PurchaseOrders p
			left join RequestsForQuotation q on q.ItemID = p.ParentID
			left join InitialOrders i on i.ItemID = q.ParentID where p.ItemId = {_order.ItemId}").Tables[0].Rows[0][0];
			var initialRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", parentInitialId));
			var initial = GlobalObjects.CasEnvironment.NewLoader.GetObject<InitialOrderDTO, InitialOrder>(new Filter("ItemId", parentInitialId));

			foreach (var record in records)
			{
				record.ParentInitialRecord = initialRecords.FirstOrDefault(i => i.ProductId == record.PackageItemId);
				if(record.ParentInitialRecord != null)
					record.ParentInitialRecord.ParentPackage = initial;
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				record.Supplier = suppliers.FirstOrDefault(i => i.ItemId == record.SupplierId);
			}
			var documents = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ParentID", _order.ItemId), true);
			_order.ClosingDocument.Clear();
			_order.ClosingDocument.AddRange(documents);

			_addedRecord.AddRange(records);
		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBoxStatus.Items.Clear();
			comboBoxStatus.DataSource = Enum.GetValues(typeof(WorkPackageStatus));
			comboBoxStatus.SelectedItem = _order.Status;

			if (_order.ItemId > 0)
			{
				textBoxTitle.Text = _order.Title;
				metroTextBoxNumber.Text = _order.Number;
				dateTimePickerOpeningDate.Value = _order.OpeningDate;
				dateTimePickerClosingDate.Value = _order.ClosingDate;
				dateTimePickerPublishDate.Value = _order.PublishingDate;
				textBoxClosingBy.Text = _order.CloseByUser;
				textBoxPublishedBy.Text = _order.PublishedByUser;
				textBoxAuthor.Text = _order.Author;
				textBoxRemarks.Text = _order.Remarks;
			}
		}

		#endregion

		#region private void ButtonCancel_Click(object sender, EventArgs e)

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = purchaseRecordListView1.SelectedItem != null;
			if (purchaseRecordListView1.SelectedItem == null) return;
			
		}
		#endregion

		#region private void ButtonOk_Click(object sender, EventArgs e)

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a price for purchase order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else
			{
				//сохранение запросного ордера
				//GlobalObjects.CasEnvironment.NewKeeper.Save(_order);

				foreach (var record in _addedRecord)
				{
					GlobalObjects.CasEnvironment.NewKeeper.Save(record);
				}

				DialogResult = DialogResult.OK;

			}
			
		}

		#endregion

		private void ButtonDelete_Click(object sender, EventArgs e)
		{

		}
	}
}
