using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.PurchaseControls.Quatation;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Setting;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	public partial class QuatationOrderFormNew : MetroForm
	{
		#region Fields

		private List<RequestForQuotationRecord> _addedQuatationOrderRecords = new List<RequestForQuotationRecord>();
		private List<RequestForQuotationRecord> _deleteExistQuatationOrderRecords = new List<RequestForQuotationRecord>();

		private readonly RequestForQuotation _order;
		private List<BaseEntityObject> destinations = new List<BaseEntityObject>();
		private DefferedCategoriesCollection _defferedCategories = new DefferedCategoriesCollection();
		private List<QuotationCost> _quotationCosts = new List<QuotationCost>();
		private List<Supplier> _suppliers = new List<Supplier>();
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();
		private Settings _setting;

		#endregion

		#region Properties

		public RequestForQuotation AddedInitial
		{
			get { return _order; }
		}

		#endregion

		#region Constructor

		public QuatationOrderFormNew()
		{
			InitializeComponent();
		}

		public QuatationOrderFormNew(RequestForQuotation order, IEnumerable<Product> selectedProducts = null) : this()
		{
			if (selectedProducts != null)
			{
				foreach (var product in selectedProducts)
				{
					var newRequest = new RequestForQuotationRecord(-1, product, 1);
					newRequest.Product = product;
					_addedQuatationOrderRecords.Add(newRequest);
				}
			}

			_order = order;

			DocumentControls.AddRange(new[] { documentControl1, documentControl2, documentControl3, documentControl4, documentControl5, documentControl6, documentControl7, documentControl8, documentControl9, documentControl10 });

			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());

			UpdateControls();
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			destinations.Clear();
			_suppliers.Clear();

			if (_order != null && _order.ItemId > 0)
			{
				_quotationCosts.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<QuotationCostDTO, QuotationCost>(new Filter("QuotationId", _order.ItemId)));
				_addedQuatationOrderRecords.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(new Filter("ParentPackageId", _order.ItemId)));
				var ids = _addedQuatationOrderRecords.Select(i => i.PackageItemId);
				var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true);
				var supplierId = _addedQuatationOrderRecords.SelectMany(i => i.SupplierPrice).Select(i => i.SupplierId);
				var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>(new Filter("ItemId",supplierId));
				_setting = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();

				if(_setting == null)
					_setting = new Settings();

				if (ids.Count() > 0)
				{
					foreach (var addedInitialOrderRecord in _addedQuatationOrderRecords)
					{
						addedInitialOrderRecord.ParentPackage = _order;
						var product = products.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.PackageItemId);

						foreach (var relation in product.SupplierRelations)
						{
							var findCost = _quotationCosts.FirstOrDefault(i => i.ProductId == product.ItemId && i.SupplierId == relation.Supplier.ItemId);
							if (findCost != null)
							{
								findCost.SupplierName = relation.Supplier.Name;
								product.QuatationCosts.Add(findCost);
							}
							else product.QuatationCosts.Add(new QuotationCost { QuotationId = _order.ItemId, ProductId = product.ItemId, SupplierId = relation.SupplierId, SupplierName = relation.Supplier.Name });
						}

						addedInitialOrderRecord.Product = product;

						foreach (var price in addedInitialOrderRecord.SupplierPrice)
						{
							price.Parent = addedInitialOrderRecord;
							price.Supplier = suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);
						}
					}
				}
			}

			var documents = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ParentID", _order.ItemId), true);
			_order.ClosingDocument.Clear();
			_order.ClosingDocument.AddRange(documents);

			_defferedCategories.Clear();
			_defferedCategories.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DefferedCategorieDTO, DeferredCategory>(loadChild: true));

			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

			_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>(loadChild: true));
		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(_setting.GlobalSetting.QuotationSupplierSetting.Parameters.Select(i => i.Key).ToArray());

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

		#region private void comboBoxMeasure_SelectedIndexChanged(object sender, System.EventArgs e)

		private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void numericUpDownQuantity_ValueChanged(object sender, System.EventArgs e)

		private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (listViewInitialItems.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else
			{
				if (_order.ItemId < 0)
					GlobalObjects.CasEnvironment.NewKeeper.Save(_order);

				foreach (var record in _addedQuatationOrderRecords)
				{
					record.ParentPackageId = _order.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(record);

					if (record.Product != null)
					{
						foreach (var ksr in record.Product.SupplierRelations)
						{
							if (ksr.SupplierId != 0)
							{
								ksr.KitId = record.Product.ItemId;
								ksr.ParentTypeId = record.Product.SmartCoreObjectType.ItemId;

								try
								{
									GlobalObjects.CasEnvironment.NewKeeper.Save(ksr);
								}
								catch (Exception ex)
								{
									Program.Provider.Logger.Log("Error while saving data", ex);
									return;
								}
							}
						}
					}
				}

				foreach (var record in _deleteExistQuatationOrderRecords)
					GlobalObjects.CasEnvironment.NewKeeper.Delete(record);

				DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			
		}

		#endregion

		

		#region private void ButtonDelete_Click(object sender, EventArgs e)

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if(listViewInitialItems.SelectedItems.Count == 0) return;

			foreach (var item in listViewInitialItems.SelectedItems.ToArray())
			{
				if (item is RequestForQuotationRecord)
				{
					var rec = item as RequestForQuotationRecord;
					if (rec.ItemId > 0)
						_deleteExistQuatationOrderRecords.Add(rec);

					_addedQuatationOrderRecords.Remove(rec);
				}

				
			}

			listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());
			
		}


		#endregion

		#region private void listViewInitialItems_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

		private void listViewInitialItems_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (listViewInitialItems.SelectedItem == null) return;
			button2.Enabled = listViewInitialItems.SelectedItem is RequestForQuotationRecord;
			if (!(listViewInitialItems.SelectedItem is RequestForQuotationRecord))
				return;
		}

		#endregion

		private void Button2_Click(object sender, EventArgs e)
		{
			if (!(listViewInitialItems.SelectedItem is RequestForQuotationRecord))
				return;

			var form = new QuotationSupplierForm(_suppliers, listViewInitialItems.SelectedItem as RequestForQuotationRecord);
			if(form.ShowDialog() == DialogResult.OK)
				listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());

		}


		private List<BaseEntityObject> UpdateLW(List<RequestForQuotationRecord> records)
		{
			var res = new List<BaseEntityObject>();

			foreach (var record in records)
			{
				res.Add(record);
				res.AddRange(record.SupplierPrice);
			}
			return res;
		}

		private void buttonAddSupplierForAll_Click(object sender, EventArgs e)
		{
			if(comboBox1.SelectedItem == null)
				return;

			if(listViewInitialItems.ItemsCount == 0)
				return;

			var ids = _setting.GlobalSetting.QuotationSupplierSetting.Parameters[comboBox1.SelectedItem.ToString()];
			var s = _suppliers.Where(i => ids.Contains(i.ItemId));

			foreach (var record in listViewInitialItems.SelectedItems.Where(i => i is RequestForQuotationRecord).Cast<RequestForQuotationRecord>())
			{
				var res = s.Select(i => new SupplierPrice() {SupplierId = i.ItemId, Supplier = i, Parent = record});

				foreach (var supplierPrice in res)
				{
					if(record.SupplierPrice.FirstOrDefault(i => i.SupplierId == supplierPrice.SupplierId) == null)
						record.SupplierPrice.Add(supplierPrice);
				}
				
			}
			listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());
		}

		private void button3_Click(object sender, EventArgs e)
		{

			var form = new QuotationCostForm(_suppliers, listViewInitialItems.GetItemsArray().Where(i => i is RequestForQuotationRecord).Cast<RequestForQuotationRecord>().ToList());
			if (form.ShowDialog() == DialogResult.OK)
				listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());
		}

		private void buttonAddQualificationNumber_Click(object sender, EventArgs e)
		{
			var suppliers = listViewInitialItems.GetItemsArray().Where(i => i is RequestForQuotationRecord)
				.Cast<RequestForQuotationRecord>().SelectMany(i => i.SupplierPrice.Select(p => p.Supplier)).Distinct();

			   var form = new QualificationNumberForm(_order,suppliers);
			   if (form.ShowDialog() == DialogResult.OK)
				   listViewInitialItems.SetItemsArray(UpdateLW(_addedQuatationOrderRecords).ToArray());
		}

		private void buttonExtended_Click(object sender, EventArgs e)
		{
			new QuotationSettingForm(_order).ShowDialog();
		}
	}
}
