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
	public partial class PurchaseOrderForm : MetroForm
	{
		#region Fields

		private List<PurchaseRequestRecord> _addedRecord = new List<PurchaseRequestRecord>();

		private PurchaseOrder _order;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();
		private List<Supplier> _supplierShipper = new List<Supplier>();
		private List<AirportsCodes> _airportsCodes = new List<AirportsCodes>();

		#endregion

		#region Constructor

		public PurchaseOrderForm()
		{
			InitializeComponent();
		}

		public PurchaseOrderForm(PurchaseOrder order):this()
		{
			_order = order;
			buttonSettings.Enabled = false;
			DocumentControls.AddRange(new[] { documentControl1, documentControl2, documentControl3, documentControl4, documentControl5, documentControl6, documentControl7, documentControl8, documentControl9 });

			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			UpdateControls();
			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
			buttonSettings.Enabled = true;
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{

			var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(new ICommonFilter[]{new CommonFilter<int>(PurchaseRequestRecord.ParentPackageIdProperty, _order.ItemId) });
			var ids = records.Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids), });
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds), },true);

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

				record.ItemCost = record.Quantity * record.Cost;
				record.TotalCost = records.Sum(i => i.ItemCost);
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
			comboBoxMeasure.Items.Clear();
			//comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));
			comboBoxMeasure.Items.AddRange(Measure.Items.ToArray());

			comboBoxCondition.Items.Clear();
			comboBoxCondition.DataSource = Enum.GetValues(typeof(ComponentStatus));

			comboBoxCurrency.Items.Clear();
			comboBoxCurrency.Items.AddRange(Сurrency.Items.ToArray());

			foreach (var control in DocumentControls)
				control.Added += DocumentControl1_Added;

			for (int i = 0; i < _order.ClosingDocument.Count; i++)
			{
				var control = DocumentControls[i];
				control.CurrentDocument = _order.ClosingDocument[i];
			}
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var control = sender as DocumentControl;
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _order,
				ParentId = _order.ItemId,
				ParentTypeId = _order.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{_order.Number}",
				Description = _order.Title,
				ParentAircraftId = _order.ParentId
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_order.ClosingDocument.Add(newDocument);
				control.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private void ButtonDelete_Click(object sender, EventArgs e)

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.SelectedItems.Count == 0) return;

			DialogResult confirmResult =
				MessageBox.Show(
						"Do you really want to delete Purchase Record(s)? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				foreach (var item in purchaseRecordListView1.SelectedItems.ToArray())
				{
					_addedRecord.Remove(item);
					GlobalObjects.CasEnvironment.Keeper.Delete(item, true);
				}

				purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
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

		#region private void NumericUpDownQuantity_ValueChanged(object sender, EventArgs e)

		private void NumericUpDownQuantity_ValueChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void SetForMeasure()
		/// <summary>
		/// Изменяет контрол в соотствествии с выбранной единицей измерения
		/// </summary>
		private void SetForMeasure()
		{
			var measure = comboBoxMeasure.SelectedItem as Measure;
			if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
				numericUpDownQuantity.DecimalPlaces = 0;
			else numericUpDownQuantity.DecimalPlaces = 2;

			var quantity = numericUpDownQuantity.Value;
			var cost = numericUpDownCost.Value;

			textBoxTotal.Text = $"{quantity * cost:0.##} {(Сurrency)comboBoxCurrency.SelectedItem}";
		}
		#endregion

		#region private void ComboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void ComboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxCondition.SelectedItem == null) return;
			if (purchaseRecordListView1.SelectedItem == null) return;

			//var selected = (ComponentStatus)comboBoxCondition.SelectedItem;

			//if (selected == ComponentStatus.New)
			//{
			//	numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostNew;
			//	comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyNew;
			//}
			//else if (selected == ComponentStatus.Overhaul)
			//{
			//	numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostOverhaul;
			//	comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyOH;
			//}
			//else if (selected == ComponentStatus.Repair)
			//{
			//	numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostRepair;
			//	comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyRepair;
			//}
			//else if (selected == ComponentStatus.Serviceable)
			//{
			//	numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostServiceable;
			//	comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyServ;
			//}

		}

		#endregion

		#region private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = purchaseRecordListView1.SelectedItem != null;
			if (purchaseRecordListView1.SelectedItem == null) return;

			comboBoxCondition.SelectedItem = purchaseRecordListView1.SelectedItem.CostCondition;
			comboBoxMeasure.SelectedItem = purchaseRecordListView1.SelectedItem.Measure;
			numericUpDownQuantity.Value = (decimal)purchaseRecordListView1.SelectedItem.Quantity;
			numericUpDownCost.Value = (decimal)purchaseRecordListView1.SelectedItem.Cost;
			comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Currency;
			
			SetForMeasure();
		}
		#endregion

		#region private void Button1_Click(object sender, EventArgs e)

		private void Button1_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.SelectedItem == null) return;

			purchaseRecordListView1.SelectedItem.CostCondition = (ComponentStatus) comboBoxCondition.SelectedItem;
			purchaseRecordListView1.SelectedItem.Measure = (Measure) comboBoxMeasure.SelectedItem;
			purchaseRecordListView1.SelectedItem.Quantity = (double) numericUpDownQuantity.Value;
			purchaseRecordListView1.SelectedItem.Cost = (double)numericUpDownCost.Value;
			purchaseRecordListView1.SelectedItem.Currency = (Сurrency) comboBoxCurrency.SelectedItem;
			
			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void Reset()

		private void Reset()
		{
			button1.Enabled = false;
			comboBoxCondition.SelectedItem = null;
			comboBoxMeasure.SelectedItem = null;
			numericUpDownQuantity.Value = 0;
			numericUpDownCost.Value = 0;
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
		
		private void buttonSettings_Click(object sender, EventArgs e)
		{
			var form = new PurchaseOrderSettingForm(_order, _supplierShipper, _airportsCodes);
			form.ShowDialog();
		}
	}
}
