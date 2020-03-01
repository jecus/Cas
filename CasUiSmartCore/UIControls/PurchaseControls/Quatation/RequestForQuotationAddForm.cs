using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	///<summary>
	/// Форма для добавления нового ордера запроса и/или его китов
	///</summary>
	public partial class RequestForQuotationAddForm : MetroForm
	{
		#region Fields

		private RequestForQuotation _addedRequest;

		private List<RequestForQuotationRecord> _addedQuotationRecord = new List<RequestForQuotationRecord>();

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		private ProductPartNumberFilter _partNumberFilter = new ProductPartNumberFilter();
		private ProductSuppliersFilter _supplierFilter = new ProductSuppliersFilter();
		private ProductManufacturerFilter _manufacturerFilter = new ProductManufacturerFilter();
		private ProductCollectionFilter _collectionFilter = new ProductCollectionFilter();

		#endregion

		#region Properties
	   
		///<summary>
		///</summary>
		public RequestForQuotation AddedRequest
		{
			get { return _addedRequest; }
		}

		#endregion

		#region Constructors

		#region private RequestForQuotationAddForm()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private RequestForQuotationAddForm()
		{
			InitializeComponent();
		}
		#endregion

		#region public RequestForQuotationAddForm(RequestForQuotation rfq) : this()
		///<summary>
		/// конструктор для добавления китов в ордер запроса
		///</summary>
		public RequestForQuotationAddForm(RequestForQuotation rfq) : this()
		{
			if (rfq == null)
			{
				throw new ArgumentNullException("rfq");
			}
			_addedRequest = rfq;

			_collectionFilter.Filters.Add(_partNumberFilter);
			_collectionFilter.Filters.Add(_supplierFilter);
			_collectionFilter.Filters.Add(_manufacturerFilter);

			_animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
			_animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
			_animatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region public RequestForQuotationAddForm(BaseEntityObject parent)  : this()
		///<summary>
		/// конструктор для создания ордера запроса для определенноно самолета
		///</summary>
		public RequestForQuotationAddForm(BaseEntityObject parent) : this()
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			_addedRequest = new RequestForQuotation { ParentId = parent.ItemId, ParentType = parent.SmartCoreObjectType };

			_collectionFilter.Filters.Add(_partNumberFilter);
			_collectionFilter.Filters.Add(_supplierFilter);
			_collectionFilter.Filters.Add(_manufacturerFilter);

			_animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
			_animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
			_animatedThreadWorker.RunWorkerAsync();

			textBoxTitle.Text = parent + "-QO-" + DateTime.Now;
			textBoxAuthor.Text = GlobalObjects.CasEnvironment.IdentityUser.Login;
		}
		#endregion

		#endregion

		#region Methods

		#region private void _animatedThreadWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)

		private void _animatedThreadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var filteredCollection = _collectionFilter.GatherDirectives();
			listViewKits.SetItemsArray(filteredCollection.ToArray());

			dictionaryComboProduct.Type = typeof(Product);
			dictionaryComboStandard.Type = typeof(GoodStandart);
			Program.MainDispatcher.ProcessControl(dictionaryComboStandard);
			Program.MainDispatcher.ProcessControl(dictionaryComboProduct);

			FormControlAttribute fca = (FormControlAttribute)
				typeof(Product)
					.GetProperty("GoodsClass")
					.GetCustomAttributes(typeof(FormControlAttribute), false)
					.FirstOrDefault();
			if (fca != null)
				comboBoxDetailClass.RootNodesNames = fca.TreeDictRootNodes;
			comboBoxDetailClass.Type = typeof(GoodsClass);

			comboBoxMeasure.Items.Clear();
			comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

			dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
			{
				KitSuppliersRelation.SupplierProperty,
				KitSuppliersRelation.CostNewProperty,
				KitSuppliersRelation.CostOverhaulProperty,
				KitSuppliersRelation.CostServiceableProperty,
			});
			dataGridViewControlSuppliers.ViewedType = typeof(KitSuppliersRelation);
		}

		#endregion

		#region private void _animatedThreadWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)

		private void _animatedThreadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				//var currentAircraftKits = GlobalObjects.PurchaseCore.GetProducts();
				var currentAircraftKits = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AccessoryDescriptionDTO, Product>().ToList();
				_collectionFilter.InitialCollection = currentAircraftKits;
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("error while loading data", exception);
			}
		}

		#endregion

		#region private void ListViewAddedItems_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

		private void listViewAddedItems_SelectedItemsChanged_1(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = listViewAddedItems.SelectedItems != null;

			if (listViewAddedItems.SelectedItem == null) return;
			var item = listViewAddedItems.SelectedItem;

			comboBoxDetailClass.SelectedItem = item.Product?.GoodsClass;
			dictionaryComboProduct.SelectedItem = item;
			comboBoxMeasure.SelectedItem = item.Measure;
			dictionaryComboStandard.SelectedItem = item.Product?.Standart;
			textBoxPartNumber.Text = item.Product?.PartNumber;
			textBoxProdDesc.Text = item.Product?.Description;
			textBoxManufacturer.Text = item.Product?.Manufacturer;
			numericUpDownQuantity.Value = (decimal)item.Quantity;
			textBoxProdRemarks.Text = item.Product?.Remarks;
			dataGridViewControlSuppliers.SetItemsArray((ICommonCollection)item.Product?.SupplierRelations);
		}

		#endregion

		#region private void UpdateListViewItems()
		private void UpdateListViewItems()
		{
			var filteredCollection = _collectionFilter.GatherDirectives();
			listViewKits.SetItemsArray(filteredCollection.ToArray());
		}
		#endregion

		#region private void ApplyQuotationOrderData()
		private void ApplyQuotationOrderData()
		{
			_addedRequest.Title = textBoxTitle.Text;
			_addedRequest.Description = textBoxDescription.Text;
			_addedRequest.OpeningDate = dateTimePickerOpeningDate.Value;
			_addedRequest.Author = textBoxAuthor.Text;
			_addedRequest.Remarks = textBoxRemarks.Text;
		}
		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)
		private void ButtonOkClick(object sender, EventArgs e)
		{   
			//#region проверка записей на соответствие
			if(_addedRequest.ItemId <= 0)
			{   
				if(textBoxTitle.Text == "")
				{
					MessageBox.Show("Please, enter a Title", (string) new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK, 
										MessageBoxIcon.Exclamation);
					return;
				}
				if(listViewAddedItems.ItemsCount <= 0)
				{
					MessageBox.Show("Please select a kits for quotation order", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation);
					return;   
				}
				//запись новой информации в запросный ордер
				ApplyQuotationOrderData();
				//сохранение запросного ордера
				GlobalObjects.CasEnvironment.NewKeeper.Save(_addedRequest);
			}
			else
			{
				if (listViewKits.ItemsCount <= 0)
				{
					MessageBox.Show("Please select a kits for quotation order", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation);
					return;
				}
			}
			
			//формирование и сохранение новых записей
			foreach (var record in _addedQuotationRecord)
			{
				record.ParentPackageId = _addedRequest.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(record);
			}
			
			DialogResult = DialogResult.OK;
			Close();
		}
		#endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion

		#region private void ButtonAddClick(object sender, EventArgs e)
		private void ButtonAddClick(object sender, EventArgs e)
		{
			if(listViewKits.SelectedItems.Count == 0)return;

			foreach (var product in listViewKits.SelectedItems.ToArray())
			{
				var newRequest = new RequestForQuotationRecord(-1, product, 1);
				newRequest.Product = product;
				_addedQuotationRecord.Add(newRequest);
			}

			listViewAddedItems.SetItemsArray(_addedQuotationRecord.ToArray());
		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if(listViewAddedItems.SelectedItems.Count == 0)return;

			foreach (var item in listViewAddedItems.SelectedItems.ToArray())
				_addedQuotationRecord.Remove(item);

			listViewAddedItems.SetItemsArray(_addedQuotationRecord.ToArray());
		}
		#endregion

		#region private void TextBoxSearchPartNumberTextChanged(object sender, EventArgs e)
		private void TextBoxSearchPartNumberTextChanged(object sender, EventArgs e)
		{
			_partNumberFilter.Mask = textBoxSearchPartNumber.Text;
			UpdateListViewItems();
		}
		#endregion

		#region private void TextBoxSearchSupplierTextChanged(object sender, EventArgs e)
		private void TextBoxSearchSupplierTextChanged(object sender, EventArgs e)
		{
			_supplierFilter.Mask = textBoxSearchSupplier.Text;
			UpdateListViewItems();
		}
		#endregion

		#region private void TextBoxSearchManufacturerTextChanged(object sender, EventArgs e)
		private void TextBoxSearchManufacturerTextChanged(object sender, EventArgs e)
		{
			_manufacturerFilter.Mask = textBoxSearchManufacturer.Text;
			UpdateListViewItems();
		}
		#endregion

		#region private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
		private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
		{
			if (dateTimePickerOpeningDate.Value < DateTimeExtend.GetCASMinDateTime())
				dateTimePickerOpeningDate.Value = DateTimeExtend.GetCASMinDateTime();
			if (dateTimePickerOpeningDate.Value > DateTime.Now)
				dateTimePickerOpeningDate.Value = DateTime.Now;
		}
		#endregion

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			if (listViewAddedItems.SelectedItem == null) return;

			listViewAddedItems.SelectedItem.Measure = (Measure)comboBoxMeasure.SelectedItem;
			listViewAddedItems.SelectedItem.Quantity = (double)numericUpDownQuantity.Value;
			listViewAddedItems.SetItemsArray(_addedQuotationRecord.ToArray());

			Reset();
		}

		private void Reset()
		{
			comboBoxDetailClass.SelectedItem = null;
			dictionaryComboProduct.SelectedItem = null;
			comboBoxMeasure.SelectedItem = null;
			dictionaryComboStandard.SelectedItem = null;
			textBoxPartNumber.Text = "";
			textBoxProdDesc.Text = "";
			textBoxManufacturer.Text = "";
			numericUpDownQuantity.Value = 0;
			textBoxProdRemarks.Text = "";
			dataGridViewControlSuppliers.ClearItems();
		}

		#region private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)

		private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
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

			decimal quantity = numericUpDownQuantity.Value;

			textBoxTotal.Text = $"{quantity:0.##}" + (measure != null ? " " + measure + "(s)" : "");
		}
		#endregion

		#region private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

	}
}
