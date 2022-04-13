using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.ProductControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using SmartCore.Purchase;
using FilterType = SmartCore.Filters.FilterType;

namespace CAS.UI.UIControls.StoresControls
{
	///<summary>
	/// Форма для редактирования расходника, КИТа, ГСМ и т.д.
	///</summary>
	public partial class ComponentForm : MetroForm
	{
		public Component _consumablePart;
		private Store _currentStore;
		private bool _isStore;
		private ProductCost _productCost;
		private List<Specialist> _specialists = new List<Specialist>();
		private Department _department;
		private Department _departmentPalanning;

		#region Properties

		#region public ComponentStorePosition State

		public ComponentStorePosition State
		{
			get { return comboBoxPosition.SelectedItem as ComponentStorePosition; }
			set { comboBoxPosition.SelectedItem = value; }
		}

		#endregion

		#endregion

		#region Constructors

		#region private ConsumablePartAndKitForm()
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		private ComponentForm()
		{
			InitializeComponent();
		}
		#endregion

		#region public ConsumablePartAndKitForm(Detail consumablePart) : this()
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ComponentForm(Component consumablePart) : this()
		{
			_consumablePart = consumablePart;
			_isStore = GlobalObjects.StoreCore.GetStoreById(consumablePart.ParentStoreId) != null;
			Task.Run(() => DoWork())
				.ContinueWith(task => FillControls(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region public ConsumablePartAndKitForm(Store store) : this()
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ComponentForm(Store store)
			: this()
		{
			_currentStore = store;
			_consumablePart = new Component {GoodsClass = GoodsClass.MaintenanceMaterials };
			Task.Run(() => DoWork())
				.ContinueWith(task => FillControls(), TaskScheduler.FromCurrentSynchronizationContext());
		}
		#endregion

		#endregion

		#region Methods

		private void DoWork()
		{
			_specialists.Clear();

			if (_consumablePart.ItemId > 0)
			{
				var documents = GlobalObjects.CasEnvironment.Loader.GetObjectList<Document>(new ICommonFilter[]
				{
					new CommonFilter<int>(Document.ParentIdProperty, _consumablePart.ItemId),
					new CommonFilter<int>(Document.ParentTypeIdProperty, _consumablePart.SmartCoreObjectType.ItemId)
				});

				var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
				_consumablePart.DocumentFaa = documents.FirstOrDefault(i => i.DocumentSubType.ItemId == docSubType.ItemId);

				docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;
				_consumablePart.DocumentShipping = documents.FirstOrDefault(i => i.DocumentSubType.ItemId == docSubType.ItemId);

			}

			_department =
				GlobalObjects.CasEnvironment.NewLoader.GetObject<DepartmentDTO, Department>(new Filter("FullName",
					"Logistics & Stores Department "));

			_departmentPalanning =
				GlobalObjects.CasEnvironment.NewLoader.GetObject<DepartmentDTO, Department>(new Filter("FullName",
					"Planning"));

			var spec = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SpecializationDTO, Occupation>(
				new Filter("DepartmentId", _department.ItemId));
			var ids = spec.Select(i => i.ItemId);

			_specialists.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectList< Specialist>(new ICommonFilter[]
			{
				new CommonFilter<int>(Specialist.SpecializationIdProperty, FilterType.In, ids.ToArray()), 
			}));
		}

		#region private void FillControls()
		/// <summary>
		/// Обновляет значения полей
		/// </summary>
		private void FillControls()
		{
			Program.MainDispatcher.ProcessControl(comboBoxStandart);
			Program.MainDispatcher.ProcessControl(dictionaryComboBoxLocation);

			comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;
			comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
			comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;
			dateTimePickerInstallDate.ValueChanged -= DateTimePickerInstallationDateValueChanged;
			dateTimePickerManufactureDate.ValueChanged -= DateTimePickerManufactureDateValueChanged;
			dataGridViewControlSuppliers.CellValueChanged -= DataGridViewControlSuppliers_CellValueChanged;

			var fca = (FormControlAttribute)
				typeof(Product)
					.GetProperty("GoodsClass")
					.GetCustomAttributes(typeof(FormControlAttribute), false)
					.FirstOrDefault();
			if (fca != null)
				comboBoxDetailClass.RootNodesNames = fca.TreeDictRootNodes;
			comboBoxDetailClass.Type = typeof(GoodsClass);

			dataGridViewControlSuppliers.ViewedTypeProperties.Clear();
			dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
			{
				ProductCost.QtyInProperty,
				ProductCost.UnitPriceProperty,
				ProductCost.TotalPriceProperty,
				ProductCost.ShipPriceProperty,
				ProductCost.SubTotalProperty,
				ProductCost.TaxProperty,
				ProductCost.Tax1Property,
				ProductCost.Tax2Property,
				ProductCost.TotalProperty,
				ProductCost.CurrencyProperty,
			});
			dataGridViewControlSuppliers.ViewedType = typeof(ProductCost);

			ataChapterComboBox.UpdateInformation();
			ataChapterComboBox.ATAChapter = _consumablePart.ATAChapter;

			dictionaryComboBoxLocation.Type = typeof(Locations);
			comboBoxStandart.Type = typeof(GoodStandart);
			comboBoxMeasure.Items.Clear();
			comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] {MeasureCategory.Mass, MeasureCategory.EconomicEntity, MeasureCategory.Volume, }));
			comboBoxMeasure.Items.Add(Measure.Centimeters);
			comboBoxMeasure.Items.Add(Measure.SquareMeter);
			comboBoxStatus.Items.Clear();
			foreach (var o in Enum.GetValues(typeof(ComponentStatus)))
				comboBoxStatus.Items.Add(o);
			comboBoxPosition.Items.Clear();
			comboBoxPosition.Items.AddRange(ComponentStorePosition.Items.ToArray());
			State = _consumablePart.State;

			dateTimePickerManufactureDate.MinDate = DateTimeExtend.GetCASMinDateTime();
			dateTimePickerManufactureDate.MaxDate = DateTime.Now;
			dateTimePickerInstallDate.MinDate = DateTimeExtend.GetCASMinDateTime();
			dateTimePickerInstallDate.MaxDate = DateTime.Now;

			comboBoxDetailClass.SelectedItem = _consumablePart.GoodsClass;
			textBoxDiscrepancy.Text = _consumablePart.Discrepancy;
			textBoxPartNumber.Text = _consumablePart.PartNumber;
			textBoxAltPartNum.Text = _consumablePart.ALTPartNumber;
			textBoxSerialNumber.Text = _consumablePart.SerialNumber;
			textBoxBatchNumber.Text = _consumablePart.BatchNumber;
			textBoxIdNumber.Text = _consumablePart.IdNumber;
			textBoxDescription.Text = _consumablePart.Description;
			textBoxProductCode.Text = _consumablePart.Code;
			metroTextBoxPacking.Text = _consumablePart.Packing;

			if (_consumablePart.ProductCosts.Count == 0)
				_consumablePart.ProductCosts.Add(new ProductCost {QtyIn = _consumablePart.QuantityIn, Currency = Сurrency.USD});
			else _productCost = _consumablePart.ProductCosts.FirstOrDefault();

			dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _consumablePart.ProductCosts);

			dictionaryComboBoxLocation.SelectedItem = _consumablePart.Location;
			comboBoxMeasure.SelectedItem = _consumablePart.Measure;
			numericUpDownQuantity.Value = (decimal) _consumablePart.QuantityIn;
			textBoxRemarks.Text = _consumablePart.Remarks;
			checkBoxIncoming.Checked = _consumablePart.Incoming;
			checkBoxPOOL.Checked = _consumablePart.IsPOOL;
			checkBoxDangerous.Checked = _consumablePart.IsDangerous;


			comboBoxSupplier.Enabled = dateTimePickerReciveDate.Enabled = _isStore;

			Product product;
			if ((product = _consumablePart.Product) != null)
			{
				comboBoxDetailClass.SelectedItem = product.GoodsClass;

				comboBoxDetailClass.Enabled = false;
				comboBoxMeasure.Enabled = false;
				textBoxPartNumber.ReadOnly = true;
				textBoxAltPartNum.ReadOnly = true;
				comboBoxStandart.Enabled = false;
				textBoxDescription.ReadOnly = true;
				comboBoxMeasure.SelectedItem = product.Measure;
				comboBoxStandart.SelectedItem = product.Standart;
				textBoxPartNumber.Text = product.PartNumber;
				textBoxAltPartNum.Text = product.AltPartNumber;
				textBoxDescription.Text = product.Description;
				textBoxManufacturer.Text = product.Manufacturer;
			}
			else if (_consumablePart.Standart != null)
			{
				var goodStandart = _consumablePart.Standart;
				comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

				comboBoxDetailClass.Enabled = false;
				textBoxPartNumber.ReadOnly = true;
				textBoxDescription.ReadOnly = true;

				comboBoxStandart.SelectedItemId = goodStandart.ItemId;
				textBoxPartNumber.Text = goodStandart.PartNumber;
				textBoxDescription.Text = goodStandart.Description;
				textBoxManufacturer.Text = "";
			}
			comboBoxStatus.SelectedItem = _consumablePart.ComponentStatus;
			textBoxRemarks.Text = _consumablePart.Remarks;

			if (_consumablePart.ItemId > 0)
			{
				numericUpDownQuantity.Enabled = false;
				buttonSaveAndAdd.Visible = false;
				var record = _consumablePart.TransferRecords.GetLast();
				State = record.State;
				dateTimePickerInstallDate.Value = record.TransferDate;
				dateTimePickerManufactureDate.Value = _consumablePart.ManufactureDate;


				documentControlFaa.CurrentDocument = _consumablePart.DocumentFaa;
				documentControlFaa.Added += DocumentControlFaa_Added;
				documentControlShip.CurrentDocument = _consumablePart.DocumentShipping;
				documentControlShip.Added += DocumentControlShip_Added;
			}
			else
			{
				documentControlFaa.Enabled = false;
				documentControlShip.Enabled = false;

				buttonSaveAndAdd.Visible = true;
				State = ComponentStorePosition.Serviceable;
				dateTimePickerManufactureDate.Value = DateTime.Today;
				dateTimePickerInstallDate.Value = DateTime.Today;
			}

			comboBoxReceived.Items.Clear();
			comboBoxReceived.Items.Add(Specialist.Unknown);
			comboBoxReceived.Items.AddRange(_specialists.ToArray());
			comboBoxReceived.SelectedItem = _consumablePart.Received;

			SetForDetailClass();
			SetForMeasure();
			UpdateByModel(_consumablePart.Model);

			comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
			comboBoxDetailClass.SelectedIndexChanged += ComboBoxDetailClassSelectedIndexChanged;
			comboBoxMeasure.SelectedIndexChanged += ComboBoxMeasureSelectedIndexChanged;
			dateTimePickerInstallDate.ValueChanged += DateTimePickerInstallationDateValueChanged;
			dateTimePickerManufactureDate.ValueChanged += DateTimePickerManufactureDateValueChanged;
			dataGridViewControlSuppliers.CellValueChanged += DataGridViewControlSuppliers_CellValueChanged;

		}

		#endregion

		private void DataGridViewControlSuppliers_CellValueChanged(object sender, EventArgs e)
		{
			if (dataGridViewControlSuppliers.PreResultRowList.Count == 0)
				return;

			dataGridViewControlSuppliers.CellValueChanged -= DataGridViewControlSuppliers_CellValueChanged;


			var qty = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[0].Value);
			var unitPrice = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[1].Value);
			var totalPrice = qty*unitPrice; 
			var shipPrice = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[3].Value);
			var subTotal = shipPrice + unitPrice;
			var tax1 = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[5].Value);
			var tax2 = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[6].Value);
			var tax3 = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[7].Value);
			var total = tax1 + tax2 + tax3 + subTotal;

			dataGridViewControlSuppliers.PreResultRowList[0].Cells[2].Value = totalPrice;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[4].Value = subTotal;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[8].Value = total;

			dataGridViewControlSuppliers.CellValueChanged += DataGridViewControlSuppliers_CellValueChanged;
		}

		#region private bool GetChangeStatus()
		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		private bool GetChangeStatus(Component obj)
		{
			var kitStandartName = _consumablePart.Standart != null ? _consumablePart.Standart.FullName : "";
			if (textBoxPartNumber.Text != obj.PartNumber
			    || textBoxAltPartNum.Text != obj.ALTPartNumber
			    || (comboBoxStandart.SelectedItem != null
				    ? comboBoxStandart.SelectedItem != _consumablePart.Standart
				    : (comboBoxStandart.Text != "Select Item" && comboBoxStandart.Text != "N/A"
					      ? comboBoxStandart.Text != kitStandartName
					      : kitStandartName != "") ||
				      textBoxSerialNumber.Text != obj.SerialNumber ||
				      textBoxBatchNumber.Text != obj.BatchNumber ||
				      textBoxIdNumber.Text != obj.IdNumber ||
				      textBoxDescription.Text != obj.Description ||
				      textBoxProductCode.Text != obj.Code ||
				      dataGridViewControlSuppliers.GetChangeStatus() ||
				      dictionaryComboBoxLocation.SelectedItem.ItemId != obj.Location.ItemId ||
				      textBoxRemarks.Text != obj.Remarks ||
				      (ComponentStatus) comboBoxStatus.SelectedItem != obj.ComponentStatus ||
				      dateTimePickerManufactureDate.Value != obj.ManufactureDate ||
				      numericUpDownQuantity.Value != (decimal) obj.QuantityIn ||
				      ataChapterComboBox.ATAChapter.ItemId != obj.ATAChapter.ItemId ||
				      checkBoxIncoming.Checked != obj.Incoming ||
				      checkBoxPOOL.Checked != obj.IsPOOL ||
				      checkBoxDangerous.Checked != obj.IsDangerous ||
				      textBoxDiscrepancy.Text != obj.Discrepancy))
			{
				return true;
			}

			if ((comboBoxDetailClass.SelectedItem != obj.GoodsClass) ||
			    (comboBoxMeasure.SelectedItem as Measure == null && obj.Measure != null) ||
			    (comboBoxMeasure.SelectedItem as Measure != null && obj.Measure == null) ||
			    (comboBoxMeasure.SelectedItem as Measure != null && obj.Measure != null &&
			     comboBoxMeasure.SelectedItem != obj.Measure))
			{
				return true;
			}

			if (obj.ItemId <= 0 && (dateTimePickerInstallDate.Value != DateTimeExtend.GetCASMinDateTime()))
				return true;

			if (obj.ItemId > 0 && (dateTimePickerInstallDate.Value != obj.TransferRecords.GetLast().TransferDate))
				return true;
			return false;
		}

		#endregion

		#region private bool ValidateData(out string message)

		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		private bool ValidateData(out string message)
		{
			message = "";
			if (_consumablePart.Product == null && _consumablePart.ItemId > 0)
			{
				if (message != "") message += "\n ";
				message += "Not set Product";
				return false;
			}
			if (!(comboBoxDetailClass.SelectedItem is GoodsClass))
			{
				if (message != "") message += "\n ";
				message += "Not set Product Class";
				return false;
			}
			if (textBoxPartNumber.Text == "" && (comboBoxStandart.Text == "" || comboBoxStandart.SelectedItem == null))
			{
				if (message != "") message += "\n ";
				message += "Not set Standart or Part Number";
				return false;
			}
			if (textBoxDescription.Text == "")
			{
				if (message != "") message += "\n ";
				message += "Not set Description";
				return false;
			}
			if (comboBoxMeasure.SelectedItem as Measure == null)
			{
				if (message != "") message += "\n ";
				message += "Not set Quantity";
				return false;
			}
			if (numericUpDownQuantity.Value == 0)
			{
				if (message != "") message += "\n ";
				message += "Not set Quantity";
				return false;
			}
			if (textBoxManufacturer.Text == "" && dataGridViewControlSuppliers.Count == 0)
			{
				if (message != "") message += "\n ";
				message += "Not set Manufacturer or Suppliers";
				return false;
			}

			string m;
			if (!dataGridViewControlSuppliers.ValidateData(out m))
			{
				if (message != "") message += "\n ";
				message += m;
				return false;
			}
			if (dateTimePickerInstallDate.Value < dateTimePickerManufactureDate.Value)
			{
				if (message != "") message += "\n ";
				message += "Installation date must be grather than manufacture date";
				return false;
			}

			return true;
		}

		#endregion

		#region private void ApplyChanges(StockDetailInfo obj)
		/// <summary>
		/// Применить к объекту сделанные изменения на контроле. 
		/// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
		/// Вызов base.ApplyChanges() обязателен
		/// </summary>
		/// <returns></returns>
		private void ApplyChanges(Component obj)
		{
			obj.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
			obj.ATAChapter = ataChapterComboBox.SelectedItem as AtaChapter;
			obj.PartNumber = textBoxPartNumber.Text;
			obj.ALTPartNumber = textBoxAltPartNum.Text;
			obj.SerialNumber = textBoxSerialNumber.Text;
			obj.BatchNumber = textBoxBatchNumber.Text;
			obj.IdNumber = textBoxIdNumber.Text;
			obj.Description = textBoxDescription.Text;
			obj.Code = textBoxProductCode.Text;
			obj.Measure = comboBoxMeasure.SelectedItem as Measure;
			obj.ComponentStatus = comboBoxStatus.SelectedItem != null
				? (ComponentStatus) comboBoxStatus.SelectedItem
				: ComponentStatus.New;
			

			if (obj.ItemId <= 0)
			{
				obj.QuantityIn = (double)numericUpDownQuantity.Value;
				obj.Quantity = (double)numericUpDownQuantity.Value;
			}
				

			obj.Location = dictionaryComboBoxLocation.SelectedItem as Locations;
			obj.Received = comboBoxReceived.SelectedItem as Specialist;
			obj.ReceivedId = _consumablePart.Received?.ItemId ?? -1;
			obj.Remarks = textBoxRemarks.Text;
			obj.ManufactureDate = dateTimePickerManufactureDate.Value;
			obj.ATAChapter = ataChapterComboBox.ATAChapter;
			obj.Discrepancy = textBoxDiscrepancy.Text;
			obj.Incoming = checkBoxIncoming.Checked;
			obj.IsPOOL = checkBoxPOOL.Checked;
			obj.IsDangerous = checkBoxDangerous.Checked;
			obj.Packing = metroTextBoxPacking.Text;
			obj.FromSupplier = comboBoxSupplier.SelectedItem as Supplier;
			obj.FromSupplierReciveDate = dateTimePickerReciveDate.Value;


			dataGridViewControlSuppliers.ApplyChanges(true);

			obj.ProductCosts.Clear();
			obj.ProductCosts.AddRange(dataGridViewControlSuppliers.GetItemsArray());

			if (obj.ItemId > 0 &&
			    (_consumablePart.TransferRecords.GetLast().State != State ||
			     _consumablePart.TransferRecords.GetLast().TransferDate != dateTimePickerInstallDate.Value))
			{
				var record = _consumablePart.TransferRecords.GetLast();
				record.State = State;
				record.TransferDate = dateTimePickerInstallDate.Value;
			}
		}
		#endregion

		#region private void AbortChanges()
		private void AbortChanges()
		{
			try
			{
				if (_consumablePart.ItemId <= 0)
				{
					foreach (var relation in _consumablePart.SupplierRelations)
					{
						GlobalObjects.CasEnvironment.Manipulator.Delete(relation, false);
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save consumable part", ex);
			}
		}
		#endregion

		#region private void ClearFields()

		private void ClearFields()
		{
			comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;
			comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
			comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;
			dateTimePickerInstallDate.ValueChanged -= DateTimePickerInstallationDateValueChanged;
			dateTimePickerManufactureDate.ValueChanged -= DateTimePickerManufactureDateValueChanged;
			numericUpDownQuantity.ValueChanged -= NumericUpDownQuantityValueChanged;

			comboBoxPosition.SelectedItem = ComponentStorePosition.UNK;
			comboBoxPosition.Enabled = true;
			comboBoxDetailClass.SelectedItem = GoodsClass.MaintenanceMaterials;
			comboBoxDetailClass.Enabled = true;
			textBoxPartNumber.Text = "";
			textBoxPartNumber.ReadOnly = false;
			textBoxPartNumber.Enabled = true;

			textBoxAltPartNum.Text = "";
			textBoxAltPartNum.ReadOnly = false;
			textBoxAltPartNum.Enabled = true;

			textBoxSerialNumber.Text = "";
			textBoxSerialNumber.ReadOnly = false;
			textBoxSerialNumber.Enabled = true;

			textBoxBatchNumber.Text = "";
			textBoxBatchNumber.ReadOnly = false;
			textBoxBatchNumber.Enabled = true;

			textBoxIdNumber.Text = "";
			textBoxIdNumber.ReadOnly = false;
			textBoxIdNumber.Enabled = true;

			textBoxDescription.Text = "";
			textBoxDescription.ReadOnly = false;
			textBoxDescription.Enabled = true;

			textBoxProductCode.Text = "";
			textBoxProductCode.ReadOnly = false;
			textBoxProductCode.Enabled = true;

			comboBoxStandart.SelectedItemId = -1;
			comboBoxStandart.Enabled = true;

			dataGridViewControlSuppliers.ClearItems();
			dictionaryComboBoxLocation.ClearValue();
			dictionaryComboBoxLocation.Enabled = true;

			comboBoxMeasure.SelectedItem = Measure.Unit;
			comboBoxMeasure.Enabled = true;

			numericUpDownQuantity.Value = 0;
			numericUpDownQuantity.ReadOnly = false;

			textBoxRemarks.Text = "";


			textBoxRemarks.Text = "";

			dateTimePickerManufactureDate.Value = DateTime.Today;
			dateTimePickerInstallDate.Value = DateTime.Today;

			SetForDetailClass();
			SetForMeasure();

			comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
			comboBoxDetailClass.SelectedIndexChanged += ComboBoxDetailClassSelectedIndexChanged;
			comboBoxMeasure.SelectedIndexChanged += ComboBoxMeasureSelectedIndexChanged;
			dateTimePickerInstallDate.ValueChanged += DateTimePickerInstallationDateValueChanged;
			dateTimePickerManufactureDate.ValueChanged += DateTimePickerManufactureDateValueChanged;
			numericUpDownQuantity.ValueChanged += NumericUpDownQuantityValueChanged;
		}
		#endregion

		#region private void Save()
		private void Save()
		{
			try
			{
				if (_consumablePart.ItemId <= 0)
                {
					if(_currentStore == null)
						_currentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(_consumablePart.ParentStoreId);
                    GlobalObjects.ComponentCore.AddComponent(_consumablePart, _currentStore, dateTimePickerInstallDate.Value, "" ,State, destinationResponsible: true);
                }
                else
                {
                    GlobalObjects.ComponentCore.Save(_consumablePart);
                    var record = _consumablePart.TransferRecords.GetLast();
                    GlobalObjects.NewKeeper.Save(record);

	                foreach (var productCost in _consumablePart.ProductCosts)
	                {
						productCost.ParentId = _consumablePart.ItemId;
						productCost.ParentTypeId = _consumablePart.SmartCoreType.ItemId;
		                productCost.SupplierId = _consumablePart.FromSupplier.ItemId;
		                productCost.KitId = _consumablePart.Product?.ItemId ?? -1;
						GlobalObjects.NewKeeper.Save(productCost);
					}
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save smsEventType", ex);
            }
        }
        #endregion

        #region private void SetForDetailClass()
        /// <summary>
        /// Изменяет контрол в соотствествии с выбранным классом детали
        /// </summary>
        private void SetForDetailClass()
        {
            var dc = comboBoxDetailClass.SelectedItem as GoodsClass;
            if (dc == null)
            {
                comboBoxMeasure.Enabled = true;
                comboBoxMeasure.SelectedItem = _consumablePart.Measure;
                //numericUpDownQuantity.DecimalPlaces = 2;
				numericUpDownQuantity.Maximum = decimal.MaxValue;
			}
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
                numericUpDownQuantity.DecimalPlaces = 0;
				numericUpDownQuantity.Maximum = decimal.MaxValue;
			}
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
				numericUpDownQuantity.DecimalPlaces = 0;
				numericUpDownQuantity.Minimum = 0;
                numericUpDownQuantity.Maximum = 1;
            }
            else
            {
				numericUpDownQuantity.Maximum = decimal.MaxValue;
			}
        }
        #endregion

        #region private void SetForMeasure()
        /// <summary>
        /// Изменяет контрол в соотствествии с выбранной единицей измерения
        /// </summary>
        private void SetForMeasure()
        {
            var measure = comboBoxMeasure.SelectedItem as Measure;
            //if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
            //    numericUpDownQuantity.DecimalPlaces = 0;
            //else numericUpDownQuantity.DecimalPlaces = 2;

			double quantity;

			if (_consumablePart.ItemId > 0)
				quantity = _consumablePart.Quantity;
	        else quantity = (double)numericUpDownQuantity.Value;

			textBoxTotal.Text = $"{quantity:0.##}" + (measure != null ? " " + measure + "(s)" : "");
		}
        #endregion

        #region private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)
        {
            dateTimePickerInstallDate.ValueChanged -= DateTimePickerInstallationDateValueChanged;

            if (_consumablePart.ItemId <= 0)
            {
                if (dateTimePickerInstallDate.Value < dateTimePickerManufactureDate.Value)
                    dateTimePickerInstallDate.Value = dateTimePickerManufactureDate.Value;
            }
            else
            {
                var record = _consumablePart.TransferRecords.GetLast();

                if (record.FromAircraftId == 0 &&
                    record.FromBaseComponentId == 0 &&
                    record.FromStoreId == 0)
                {
                    //Деталь только что добавлена, ни откуда не перемещалась
                    //Ограничением будет дата производства детали

                    if (dateTimePickerInstallDate.Value < dateTimePickerManufactureDate.Value)
                        dateTimePickerInstallDate.Value = dateTimePickerManufactureDate.Value;
                }
                else
                {
                    // Деталь была перемещена откуда - то,
                    // Ограничением будет дата начала перемещения
                    if (dateTimePickerInstallDate.Value < record.StartTransferDate)
                        dateTimePickerInstallDate.Value = record.StartTransferDate;
                }

                if (dateTimePickerInstallDate.Value > DateTime.Now)
                    dateTimePickerInstallDate.Value = DateTime.Now;
            }

            dateTimePickerInstallDate.ValueChanged += DateTimePickerInstallationDateValueChanged;
        }
        #endregion

        #region private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)
        {
            if (_consumablePart.ItemId <= 0)
            {
                if (dateTimePickerManufactureDate.Value > dateTimePickerInstallDate.Value)
                    dateTimePickerManufactureDate.Value = dateTimePickerInstallDate.Value;
            }
            else
            {
                var record = _consumablePart.TransferRecords.GetLast();

                if (record.FromAircraftId == 0 &&
                    record.FromBaseComponentId == 0 &&
                    record.FromStoreId == 0)
                {
                    //Деталь только что добавлена, ни откуда не перемещалась
                    //Ограничением будет дата установки

                    if (dateTimePickerManufactureDate.Value > dateTimePickerInstallDate.Value)
                        dateTimePickerManufactureDate.Value = dateTimePickerInstallDate.Value;
                }
                else
                {
                    // Деталь была перемещена откуда - то,
                    // Ограничением будет дата начала перемещения
                    if (dateTimePickerManufactureDate.Value > record.StartTransferDate)
                        dateTimePickerManufactureDate.Value = record.StartTransferDate;
                }

                if (dateTimePickerManufactureDate.Value > DateTime.Now)
                    dateTimePickerManufactureDate.Value = DateTime.Now;
            }
        }
        #endregion

        #region private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForDetailClass();
        }
        #endregion

        #region private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForMeasure();
        }
        #endregion

        #region private void NumericUpDownQuantityValueChanged(object sender, EventArgs e)
        private void NumericUpDownQuantityValueChanged(object sender, EventArgs e)
        {
            SetForMeasure();
        }
        #endregion

        #region private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        private void UpdateByModel(ComponentModel product)
        {
	        linkLabel1.Enabled = _consumablePart.Product != null;

			if (product != null)
	        {
		        TextBoxProduct.Text = product.ToString();
	            if (product.ImageFile != null)
	            {
		            fileControlImage.Enabled = true;
		            fileControlImage.UpdateInfo(product.ImageFile,
			            "Image Files|*.jpg;*.jpeg;*.png",
			            "This record does not contain a image. Enclose Image file to prove the compliance.",
			            "Attached file proves the Image.");
					fileControlImage.ShowLinkLabelRemove = false;
				}
				else
				{
					fileControlImage.UpdateInfo(null, "", "", "");
					fileControlImage.Enabled = false;
				}

				UpdateSupplier(product);

				if (_productCost != null && _productCost.KitId == product.ItemId)
					dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _consumablePart.ProductCosts);
				else ResetProductCost();

				comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                comboBoxStandart.Enabled = false;
                textBoxPartNumber.Enabled = false;
                textBoxAltPartNum.Enabled = false;
                textBoxDescription.Enabled = false;
	            textBoxManufacturer.Enabled = false;
	            textBoxProductCode.Enabled = false;
				comboBoxMeasure.Enabled = false;
	            ataChapterComboBox.Enabled = false;

				comboBoxDetailClass.SelectedItem = product.GoodsClass;
				comboBoxMeasure.SelectedItem = product.Measure;
                comboBoxStandart.SelectedItem = product.Standart;
                textBoxPartNumber.Text = product.PartNumber;
                textBoxAltPartNum.Text = product.AltPartNumber;
                textBoxDescription.Text = product.Description;
				checkBoxDangerous.Checked = product.IsDangerous;
				textBoxManufacturer.Text = product.Manufacturer;
	            ataChapterComboBox.ATAChapter = product.ATAChapter;
	            textBoxProductCode.Text = product.Code;
	            metroTextBoxEffectivity.Text = product.IsEffectivity;

				SetForDetailClass();
			}
            else
            {
				ataChapterComboBox.Enabled = true;
				comboBoxDetailClass.Enabled = true;
				textBoxProductCode.Enabled = true;
				metroTextBoxEffectivity.Text = "";
            }

            if (_consumablePart.ItemId > 0)
            {
                textBoxRemarks.Text = _consumablePart.Remarks;

                if (product != null)
                {
                    _consumablePart.Suppliers = new SupplierCollection(product.Suppliers);
                    _consumablePart.SupplierRelations = new CommonCollection<KitSuppliersRelation>(product.SupplierRelations);
                }
                else
                {
                    comboBoxMeasure.Enabled = true;
                    comboBoxStandart.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxAltPartNum.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                }
            }
            else
            {
                if (product != null)
                {
                    textBoxRemarks.Text = product.Remarks;

                    _consumablePart.Suppliers = new SupplierCollection(product.Suppliers);
                    _consumablePart.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
                    foreach (var ksr in product.SupplierRelations)
                    {
                        _consumablePart.SupplierRelations.Add(new KitSuppliersRelation(ksr));
                    }
                }
                comboBoxStandart.Enabled = true;
            }

            comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
        }
        #endregion

        #region private void ComboBoxStandartSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxStandartSelectedIndexChanged(object sender, EventArgs e)
        {
            GoodStandart goodStandart;
            if ((goodStandart = comboBoxStandart.SelectedItem as GoodStandart) != null)
            {
                comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

				comboBoxDetailClass.Enabled = false;
				textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;

                textBoxPartNumber.Text = goodStandart.PartNumber;
                textBoxDescription.Text = goodStandart.Description;
            }
            else
            {
				if(_consumablePart.Product == null)
					comboBoxDetailClass.Enabled = true;
			}

            if (_consumablePart.ItemId > 0)
            {
                textBoxRemarks.Text = _consumablePart.Remarks;

                if (goodStandart != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                }
                else
                {
                    comboBoxMeasure.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                }
            }
            else
            {
                if (goodStandart != null)
                {
                    textBoxRemarks.Text = goodStandart.Remarks;
                }
                comboBoxDetailClass.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
            }
        }
		#endregion

		#region private void checkBoxIncoming_CheckedChanged(object sender, EventArgs e)

		private void checkBoxIncoming_CheckedChanged(object sender, EventArgs e)
		{
			textBoxDiscrepancy.Enabled = !checkBoxIncoming.Checked;
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus(_consumablePart))
            {
                var result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (result == DialogResult.No)
                {
                    AbortChanges();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    ApplyChanges(_consumablePart);
                    Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if (_consumablePart != null)
            {
                if (GetChangeStatus(_consumablePart))
                {
                    var result = MessageBox.Show("Do you want to save changes?",
                                                          (string)new GlobalTermsProvider()["SystemName"],
                                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                          MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Cancel)
                    {
                        DialogResult = DialogResult.None;
                        return;
                    }
                    if (result == DialogResult.No)
                    {
                        AbortChanges();
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    else
                    {
                        string message;
                        if (!ValidateData(out message))
                        {
                            message += "\nAbort operation";
                            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ApplyChanges(_consumablePart);
                        Save();
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        #endregion

        #region private void ButtonSaveAndAddClick(object sender, EventArgs e)
        private void ButtonSaveAndAddClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus(_consumablePart))
            {
                var result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    return;
                }
                
                ApplyChanges(_consumablePart);
                Save();

                if (MessageBox.Show("Item added successfully" + "\nClear Fields before add new Item?",
                                new GlobalTermsProvider()["SystemName"].ToString(),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ClearFields();
                }
                _consumablePart = new Component();
            }
            else
            {
                MessageBox.Show("Nothing to save! Abort operation",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }
		#endregion

		#region private void UpdateSupplier(Product model)

		private void UpdateSupplier(Product model)
		{
			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(model.Suppliers.ToArray());
			comboBoxSupplier.Items.Add(Supplier.Unknown);

			if (comboBoxSupplier.Items.Count > 1)
				comboBoxSupplier.SelectedItem = _consumablePart.FromSupplier;
			else comboBoxSupplier.SelectedItem = Supplier.Unknown;


			if (_consumablePart.FromSupplier == Supplier.Unknown)
				dateTimePickerReciveDate.Value = DateTimeExtend.GetCASMinDateTime();
			else
				dateTimePickerReciveDate.Value = _consumablePart.FromSupplierReciveDate;

			if (_isStore)
				comboBoxSupplier.Enabled = dateTimePickerReciveDate.Enabled = model.Suppliers.Count > 0;
			else comboBoxSupplier.Enabled = dateTimePickerReciveDate.Enabled = _isStore;
		}

		#endregion

		#region private void ResetProductCost()

		private void ResetProductCost()
		{
			dataGridViewControlSuppliers.CellValueChanged -= DataGridViewControlSuppliers_CellValueChanged;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[1].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[2].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[3].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[4].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[5].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[6].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[7].Value = 0;
			dataGridViewControlSuppliers.PreResultRowList[0].Cells[8].Value = 0;
			dataGridViewControlSuppliers.CellValueChanged += DataGridViewControlSuppliers_CellValueChanged;
		}

		#endregion

		#endregion

		#region private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedSupplier = comboBoxSupplier.SelectedItem as Supplier;

			if (_productCost != null && _productCost.SupplierId == selectedSupplier.ItemId)
				dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _consumablePart.ProductCosts);
			else ResetProductCost();
		}

		#endregion

		private void DocumentControlShip_Added(object sender, EventArgs e)
		{
			var control = sender as DocumentControl;
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _consumablePart,
				ParentId = _consumablePart.ItemId,
				ParentTypeId = _consumablePart.SmartCoreObjectType.ItemId,
				DocType = DocumentType.StoreRecord,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"",
				Description = "",
				ParentAircraftId = _consumablePart.ParentAircraftId,
				Department = _department
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
				control.CurrentDocument = newDocument;
		}

		private void DocumentControlFaa_Added(object sender, EventArgs e)
		{
			var control = sender as DocumentControl;
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _consumablePart,
				ParentId = _consumablePart.ItemId,
				ParentTypeId = _consumablePart.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{_consumablePart}",
				Description = _consumablePart.Description,
				ParentAircraftId = _consumablePart.ParentAircraftId,
				Department = _departmentPalanning
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
				control.CurrentDocument = newDocument;
		}

		private void LinkLabelEditComponents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new ModelBindForm(_consumablePart);
			if(form.ShowDialog() == DialogResult.OK)
				UpdateByModel(_consumablePart.Model);

		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new ModelForm(_consumablePart.Model);
			if (form.ShowDialog() == DialogResult.OK)
				UpdateByModel(_consumablePart.Model);
		}

		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			TextBoxProduct.Text = "";
			_consumablePart.Model = null;
			UpdateByModel(_consumablePart.Model);
		}
	}
}
