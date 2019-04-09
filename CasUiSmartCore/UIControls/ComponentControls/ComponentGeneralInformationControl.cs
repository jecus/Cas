using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = System.Convert;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// ЭУ для отображения главной информации по сохраненной в БД детали
    ///</summary>
    public partial class ComponentGeneralInformationControl : UserControl
    {
        #region Fields

        private Component _currentComponent;
        private bool _isStore;
		private ProductCost _productCost;
	    private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		#endregion

		#region Constructors

		#region public DetailGeneralInformationControl()
		///<summary>
		///</summary>
		public ComponentGeneralInformationControl()
        {
            InitializeComponent();
            comboBoxAtaChapter.UpdateInformation();
        }

        #endregion

        #region public DetailGeneralInformationControl(AbstractDetail currentDetail)

        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        /// <param name="currentComponentгрегат</param>
        public ComponentGeneralInformationControl(Component currentComponent) : this()
        {
            if (null == currentComponent)
                throw new ArgumentNullException("currentComponent", "Argument cannot be null");
            _currentComponent = currentComponent;
            _isStore = GlobalObjects.StoreCore.GetStoreById(currentComponent.ParentStoreId) != null;
			UpdateControl();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Propeties

        #region public Detail CurrentDetail
        ///<summary>
        ///</summary>
        public Component CurrentComponent
        {
            set
            {
                _currentComponent = value;
                _isStore = GlobalObjects.StoreCore.GetStoreById(value.ParentStoreId) != null || value.ParentSupplierId > 0 || value.ParentSpecialistId > 0;
				UpdateControl();
                UpdateInformation();
            }
        }
        #endregion

        #region private ATAChapter ATAChapter

        /// <summary>
        /// ATAChapter текущего агрегата
        /// </summary>
        private AtaChapter ATAChapter
        {
            get
            {
                return comboBoxAtaChapter.ATAChapter;
            }
            set
            {
                comboBoxAtaChapter.ATAChapter = value;
            }
        }

        #endregion

        #region private string PartNumber

        /// <summary>
        /// Displayed PartNumber
        /// </summary>
        private string PartNumber
        {
            get { return textBoxPartNo.Text; }
            set
            {
                textBoxPartNo.Text = value;
            }
        }

        #endregion

        #region private string SerialNumber

        /// <summary>
        /// Отображаемый  SerialNumber
        /// </summary>
        private string SerialNumber
        {
            get { return textBoxSerialNo.Text; }
            set
            {
                textBoxSerialNo.Text = value;
            }
        }

        #endregion

        #region private string BatchNumber

        /// <summary>
        /// Отображаемый Пакетный номер
        /// </summary>
        private string BatchNumber
        {
            get { return textBoxBatchNumber.Text; }
            set
            {
                textBoxBatchNumber.Text = value;
            }
        }

        #endregion

        #region private string IdNumber
        /// <summary>
        /// Отображаемый идентификационный номер
        /// </summary>
        private string IdNumber
        {
            get { return textBoxIdNumber.Text; }
            set
            {
                textBoxIdNumber.Text = value;
            }
        }

        #endregion

        #region private string MPDItem

        /// <summary>
        /// Отображаемое значение MPD Item
        /// </summary>
        private string MPDItem
        {
            get { return textBoxMPDItem.Text; }
            set { textBoxMPDItem.Text = value; }
        }

        #endregion

        #region private string Description

        /// <summary>
        /// Отображаемое описание 
        /// </summary>
        private string Description
        {
            get { return textBoxDescription.Text; }
            set
            {
                textBoxDescription.Text = value;
            }
        }

		#endregion

		#region public ComponentStorePosition State

		public ComponentStorePosition State
	    {
		    get
		    {
			    return comboBoxStorePosition.SelectedItem as ComponentStorePosition;  
		    }
		    set
		    {
			    comboBoxStorePosition.SelectedItem = value;
		    }
	    }

	    #endregion

	    #region public string Position

		/// <summary>
		/// Отображаемое положение 
		/// </summary>
		public string Position
        {
            get
            {
                return textBoxPosition.Text;
            }
            set
            {
				textBoxPosition.Text = value;  
            }
        }

        #endregion

        #region  private string ComponentLocation

        /// <summary>
        /// Полка на складе
        /// </summary>
        private Locations ComponentLocation
        {
            get
            {
				var location = dictionaryComboBoxLocation.SelectedItem as Locations;
				return location ?? Locations.Unknown;
			}
            set
            {
				dictionaryComboBoxLocation.SelectedItem = value;
            }
        }

        #endregion

        #region private LandingGearMarkType LandingGearMark

        /// <summary>
        /// Возвращает или устанавливает позицию шасси
        /// </summary>
        private LandingGearMarkType LandingGearMark
        {
            get
            {
                if (radioButtonLLG.Checked)
                    return LandingGearMarkType.Left;
                if (radioButtonNLG.Checked)
                    return LandingGearMarkType.General;
                if (radioButtonRLG.Checked)
                    return LandingGearMarkType.Right;
                return LandingGearMarkType.None;
            }
            set
            {
                switch (value)
                {
                    case LandingGearMarkType.Left:
                        radioButtonLLG.Checked = true;
                        break;
                    case LandingGearMarkType.General:
                        radioButtonNLG.Checked = true;
                        break;
                    case LandingGearMarkType.Right:
                        radioButtonRLG.Checked = true;
                        break;
                }
            }
        }

        #endregion

        #region private DetailModel Model

        /// <summary>
        /// Отображаемая модель
        /// </summary>
        private ComponentModel Model
        {
            get { return comboBoxModel.SelectedItem as ComponentModel; }
            set
            {
                comboBoxModel.SelectedItem = value;
            }
        }

        #endregion

        #region private string Manufacturer

        /// <summary>
        /// Отображаемый производитель 
        /// </summary>
        private string Manufacturer
        {
            get { return textBoxManufacturer.Text; }
            set
            {
                textBoxManufacturer.Text = value;
            }
        }

        #endregion

        #region private DateTime ManufactureDate

        /// <summary>
        /// Отображаемая дата производства
        /// </summary>
        private DateTime ManufactureDate
        {
            get { return dateTimePickerManufactureDate.Value; }
            set
            {
                dateTimePickerManufactureDate.Value = value;
            }
        }

        #endregion

        #region private DateTime DeliveryDate

        /// <summary>
        /// Отображаемая дата доставки
        /// </summary>
        private DateTime DeliveryDate
        {
            get { return dateTimePickerDeliveryDate.Value; }
            set
            {
                dateTimePickerDeliveryDate.Value = value;
            }
        }

		#endregion

		#region public DateTime InstallationDate

		/// <summary>
		/// Возвращает или устанавливает дату установки агрегата
		/// </summary>
		public DateTime InstallationDate
        {
            get { return dateTimePickerInstallationDate.Value; }
            set
            {
                dateTimePickerInstallationDate.Value = value;
            }
        }

        #endregion

        #region private string MaxTakeOffWeight

        /// <summary>
        /// Отображаемый максимальный вес
        /// </summary>
        private string MaxTakeOffWeight
        {
            get { return textBoxMaxTakeOffWeight.Text; }
            set
            {
                textBoxMaxTakeOffWeight.Text = value;
            }
        }

        #endregion

        #region private bool AvionicsInventoryMark

        /// <summary>
        /// Avionics Inventory
        /// </summary>
        private bool AvionicsInventoryMark
        {
            get { return checkBoxAvionicsInventory.Checked; }
            set
            {
                checkBoxAvionicsInventory.Checked = value;
                radioButtonInventoryRequired.Enabled = value;
                radioButtonInventoryOptional.Enabled = value;
                radioButtonAvionicsInventoryUnknown.Enabled = value;
            }
        }

        #endregion

        #region private bool LLPDiskMark

        /// <summary>
        /// LLPDiskMark
        /// </summary>
        private bool LLPDiskMark
        {
            set { checkBoxLLPMark.Checked = value;}
        }

        #endregion

        #region private bool LLPCategoriesMark

        /// <summary>
        /// LLPCategoriesMark
        /// </summary>
        private bool LLPCategoriesMark
        {
            set { checkBoxLLPCategories.Checked = value; }
        }

        #endregion

        #region private GoodsClass GoodsClass
        /// <summary>
        /// DetailType
        /// </summary>
        private GoodsClass GoodsClass
        {
            get
            {
                GoodsClass goodsClass =
                    comboBoxComponentType.SelectedItem as GoodsClass;
                return goodsClass ?? GoodsClass.AircraftComponents;
            }
            set { comboBoxComponentType.SelectedItem = value ?? GoodsClass.AircraftComponents; }
        }

        #endregion

        #region private double Quantity

        /// <summary>
        /// Quantity
        /// </summary>
        private double Quantity
        {
            get { return (double)numericUpDownQuantity.Value; }
            set { numericUpDownQuantity.Value = (decimal)value; }
        }

        #endregion

        #region private AvionicsInventoryMarkType AvionicsInventoryMarkType

        /// <summary>
        /// Тип Avionics Inventory
        /// </summary>
        private AvionicsInventoryMarkType AvionicsInventoryMarkType
        {
            get
            {
                if (!AvionicsInventoryMark)
                    return AvionicsInventoryMarkType.None;
                if (radioButtonInventoryOptional.Checked)
                    return AvionicsInventoryMarkType.Optional;
                if (radioButtonInventoryRequired.Checked)
                    return AvionicsInventoryMarkType.Required;
                return AvionicsInventoryMarkType.Unknown;
            }
            set
            {
                AvionicsInventoryMark = true;
                switch (value)
                {
                    case AvionicsInventoryMarkType.Required:
                        radioButtonInventoryRequired.Checked = true;
                        break;
                    case AvionicsInventoryMarkType.Optional:
                        radioButtonInventoryOptional.Checked = true;
                        break;
                    case AvionicsInventoryMarkType.Unknown:
                        radioButtonAvionicsInventoryUnknown.Checked = true;
                        break;
                    default:
                        radioButtonAvionicsInventoryUnknown.Checked = true;
                        AvionicsInventoryMark = false;
                        break;
                }
            }
        }

        #endregion

        #region private string ALTPN

        /// <summary>
        /// ALT P/N
        /// </summary>
        private string ALTPN
        {
            get
            {
                return textBoxALTPN.Text;
            }
            set
            {
                textBoxALTPN.Text = value;
            }
        }

		#endregion

		#region private string AltPartNumber

		/// <summary>
		/// Displayed PartNumber
		/// </summary>
		private string AltPartNumber
		{
			get { return textBoxAltPartNum.Text; }
			set
			{
				textBoxAltPartNum.Text = value;
			}
		}

		#endregion

		#region private string HusKit

		///<summary>
		/// Hush Kit
		///</summary>
		private string HusKit
        {
            get
            {
                return textBoxHushKit.Text;
            }
            set
            {
                textBoxHushKit.Text = value;
            }
        }

        #endregion

        #region private MaintenanceType MaintenanceType
        /// <summary>
        /// Отображаемый Тип технического обслуживания
        /// </summary>
        private MaintenanceControlProcess MaintenanceType
        {
            get
            {
                MaintenanceControlProcess type =
                    comboBoxMaintProc.SelectedItem as MaintenanceControlProcess;
                return type ?? MaintenanceControlProcess.UNK;
            }
            set { comboBoxMaintProc.SelectedItem = value; }
        }
        #endregion

        #region private DetailStatus DetailStatus
        /// <summary>
        /// Возвращает или задает состояние агрегата
        /// </summary>
        private ComponentStatus ComponentStatus
        {
            get
            {
                return comboBoxStatus.SelectedItem is ComponentStatus 
                    ? (ComponentStatus)comboBoxStatus.SelectedItem 
                    : ComponentStatus.New;
            }
            set { comboBoxStatus.SelectedItem = value; }
        }
        #endregion

        #region public string Code
        /// <summary>
        /// Код создаваемого агрегата
        /// </summary>
        public string Code
        {
            get { return textBoxProductCode.Text; }
            set
            {
                textBoxProductCode.Text = value;
            }
        }

		#endregion

		#region  private string Discrepancy

		private string Discrepancy
	    {
		    get
		    {
			    return textBoxDiscrepancy.Text;
		    }
		    set
		    {
			    textBoxDiscrepancy.Text = value;
		    }
	    }

		#endregion

		#region private bool Incoming

		private bool Incoming
	    {
		    get
		    {
			    return checkBoxIncoming.Checked;
		    }
		    set
		    {
			    checkBoxIncoming.Checked = value;
		    }
	    }

		#endregion

		#region public bool IsPool

		public bool IsPool
		{
			get { return checkBoxPOOL.Checked; }
			set { checkBoxPOOL.Checked = value; }
		}

		#endregion

		#region public bool IsDangerous

		public bool IsDangerous
		{
			get { return checkBoxDangerous.Checked; }
			set { checkBoxDangerous.Checked = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region public bool GetChangeStatus()
		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		public bool GetChangeStatus()
        {
            try
            {
                if (ATAChapter != _currentComponent.ATAChapter ||
                    PartNumber != _currentComponent.PartNumber ||
                    Code != _currentComponent.Code ||
                    SerialNumber != _currentComponent.SerialNumber ||
                    BatchNumber != _currentComponent.BatchNumber ||
                    IdNumber != _currentComponent.IdNumber ||
                    MPDItem != _currentComponent.MPDItem ||
                    Position != _currentComponent.TransferRecords.GetLast().Position ||
                    State != _currentComponent.TransferRecords.GetLast().State ||
                    ComponentLocation.ItemId != _currentComponent.Location.ItemId ||
                    Description != _currentComponent.Description ||
                    LandingGearMark != _currentComponent.LandingGear ||
                    Model != _currentComponent.Model ||
                    MaintenanceType != _currentComponent.MaintenanceControlProcess ||
                    ComponentStatus != _currentComponent.ComponentStatus ||
                    Manufacturer != _currentComponent.Manufacturer ||
                    ManufactureDate != _currentComponent.ManufactureDate ||
                    InstallationDate != _currentComponent.TransferRecords.GetLast().TransferDate ||
                    DeliveryDate != _currentComponent.DeliveryDate ||
                    _currentComponent.SupplierRelations.Any(sr => sr.ItemId < 0) ||
                    MaxTakeOffWeight != _currentComponent.MTOGW ||
                    HusKit != _currentComponent.HushKit ||
                    AvionicsInventoryMarkType != _currentComponent.AvionicsInventory ||
                    ALTPN != _currentComponent.ALTPartNumber ||
                    Quantity != _currentComponent.Quantity ||
                    !GoodsClass.Equals(_currentComponent.GoodsClass) ||
					Discrepancy != _currentComponent.Discrepancy ||
					Incoming != _currentComponent.Incoming ||
					IsPool != _currentComponent.IsPOOL ||
					IsDangerous != _currentComponent.IsDangerous ||
					dataGridViewControlSuppliers.GetChangeStatus() ||
					(_currentComponent is BaseComponent && textBoxThrust.Text != ((BaseComponent)_currentComponent).Thrust) ||
					fileControlShipping.GetChangeStatus())
                    return true;
            }
            catch
                (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
            return false;

        }

        #endregion

        #region public void UpdateControl()
        /// <summary>
        /// Обновляет контрол
        /// </summary>
        private void UpdateControl()
        {
			dataGridViewControlSuppliers.CellValueChanged -= DataGridViewControlSuppliers_CellValueChanged;

			comboBoxMaintProc.Items.Clear();
            comboBoxMaintProc.Items.AddRange(MaintenanceControlProcess.Items.ToArray());

            comboBoxStatus.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(ComponentStatus)))
                comboBoxStatus.Items.Add(o);


			fileControlShipping.UpdateInfo(_currentComponent.IncomingFile,
										   "Adobe PDF Files|*.pdf",
										   "This record does not contain a file proving the Shipping File. Enclose PDF file to prove the compliance.",
										   "Attached file proves the Shipping File.");

	        comboBoxSupplier.Enabled = dateTimePickerReciveDate.Enabled = _isStore;

			dataGridViewControlSuppliers.ClearItems();
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


			if (_isStore)
            {
                labelLocation.Visible = true;
                dictionaryComboBoxLocation.Visible = true;
				dictionaryComboBoxLocation.Type = typeof(Locations);

	            labelPosition.Text = "State:";

				comboBoxStorePosition.Location = new Point(113, 260);//textBoxPosition.Location;
                comboBoxStorePosition.Visible = true;
                comboBoxStorePosition.Items.Clear();
                comboBoxStorePosition.Items.AddRange(ComponentStorePosition.Items.ToArray());
                Controls.Remove(textBoxPosition);
            }
            if (_currentComponent is BaseComponent)
            {
                comboBoxComponentType.RootNodesNames = new []{"AircraftBaseComponents", "VehicleBaseComponents"};
                comboBoxComponentType.Type = typeof(GoodsClass);

                labelComponentType.Visible = comboBoxComponentType.Visible =
                    labelQuantity.Visible = numericUpDownQuantity.Visible = false;
                if(((BaseComponent)_currentComponent).BaseComponentType == BaseComponentType.Engine)
                {
                    //если отображается двигатель, то надо скрыть некоторые контролы (описаны ниже)
                    checkBoxLLPMark.Visible = comboBoxComponentType.Visible = false;
                    //и отобразить флажок LLP категорий для предоставления возможности пометить
                    //могут ли детали данного двигателя расчитываться по LLP категориям
                    checkBoxLLPCategories.Visible = true;
                    comboBoxComponentType.Visible = false;
                    labelThrust.Visible = true;
                    textBoxThrust.Visible = true;
                }
            }
            else
            {
                if (_isStore)
                {
                    FormControlAttribute fca = (FormControlAttribute)
                    typeof(Component)
                        .GetProperty("GoodsClass")
                        .GetCustomAttributes(typeof(FormControlAttribute), false)
                        .FirstOrDefault();
                    if (fca != null)
                        comboBoxComponentType.RootNodesNames = fca.TreeDictRootNodes;
                    comboBoxComponentType.Type = typeof(GoodsClass);
                }
                else comboBoxComponentType.RootNodesNames = new[] { "ComponentsAndParts", "ProductionAuxiliaryEquipment" };
                comboBoxComponentType.Type = typeof(GoodsClass);


                if(_currentComponent.ParentBaseComponent != null)
                {
                    if(_currentComponent.ParentBaseComponent.BaseComponentType == BaseComponentType.Engine)//TODO:(Evgenii Babak) заменить на использование ComponentCore 
					{
                        if(_currentComponent.ParentBaseComponent.LLPCategories)
                        {
                            //если отображается простоая деталь и ее родительской деталью является двигатель
                            //и расчеты его дочерних крутящихся элементов расчитываются по категориям, то:
                            //0.скрыть маркер Emergency и контрол количества этих элементов
                            labelComponentType.Visible = comboBoxComponentType.Visible = 
                                numericUpDownQuantity.Visible = labelQuantity.Visible = false;
                            //1.надо отобразить маркеры LLP
                            checkBoxLLPMark.Visible = checkBoxLLPCategories.Visible = true;
                            //2.маркер LLP категорий сделать недоступным 
                            checkBoxLLPCategories.Enabled = false;
                        }
                        else
                        {
                            labelComponentType.Visible = comboBoxComponentType.Visible = numericUpDownQuantity.Visible =
                                labelQuantity.Visible = checkBoxLLPMark.Visible = true;
                            checkBoxLLPCategories.Visible = checkBoxLLPCategories.Enabled = false;  
                        }
                    }
                    else
                    {
                        labelComponentType.Visible = comboBoxComponentType.Visible = numericUpDownQuantity.Visible =
                            labelQuantity.Visible = true;
                        checkBoxLLPMark.Visible = checkBoxLLPCategories.Visible = checkBoxLLPCategories.Enabled = false;     
                    }

	                if (_currentComponent.ParentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
	                {
		                dateTimePickerStart.Visible = true;
		                lifelengthViewerStart.Visible = true;
		                groupBoxStart.Visible = true;
					}
                }
                else
                {
                    labelComponentType.Visible = comboBoxComponentType.Visible = numericUpDownQuantity.Visible = labelQuantity.Visible =
                        checkBoxLLPMark.Visible = checkBoxLLPCategories.Visible = true;
                    checkBoxLLPCategories.Enabled = false;    
                }
            }

	        if (_currentComponent.LLPMark && _currentComponent.LLPCategories)
	        {
		        lifelengthViewer2.Visible = lifelengthViewer3.Visible = lifelengthViewer4.Visible = lifelengthViewer5.Visible = true;
		        lifelengthViewerAStartFrom.Visible = lifelengthViewerBStartFrom.Visible = lifelengthViewerCStartFrom.Visible = lifelengthViewerDStartFrom.Visible = true;
		        labelAStartFrom.Visible = labelBStartFrom.Visible = labelCStartFrom.Visible = labelDStartFrom.Visible = true;
		        dateTimePickerAStartFrom.Visible = dateTimePickerBStartFrom.Visible = dateTimePickerCStartFrom.Visible = dateTimePickerDStartFrom.Visible = true;
				delimiter1.Visible = delimiter2.Visible = delimiter3.Visible = delimiter4.Visible = true;
			}
	        else
	        {
				dataGridViewControlSuppliers.Location = new Point(5, 530);
		        labelSupplier.Location = new Point(554, 510);
		        Size = new Size(1195, 603);
			}

            GoodsClass dt = _currentComponent.GoodsClass;
            if (dt == null)
                labelQuantity.Visible = numericUpDownQuantity.Visible = false;
            else if (dt == GoodsClass.AircraftComponentsEmergency)
                labelQuantity.Visible = numericUpDownQuantity.Visible = true;
            else labelQuantity.Visible = numericUpDownQuantity.Visible = false;

			dataGridViewControlSuppliers.CellValueChanged += DataGridViewControlSuppliers_CellValueChanged;
		}

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        public void UpdateInformation()
        {
	        radioButtonA.CheckedChanged -= radioButton_CheckedChanged;
	        radioButtonB.CheckedChanged -= radioButton_CheckedChanged;
	        radioButtonC.CheckedChanged -= radioButton_CheckedChanged;
	        radioButtonD.CheckedChanged -= radioButton_CheckedChanged;

			if (_currentComponent == null)
                throw new ArgumentNullException("_current" + "Detail");

            comboBoxModel.Type = typeof(ComponentModel);
            Program.MainDispatcher.ProcessControl(comboBoxModel);

	        if (_currentComponent.PartNumber.EndsWith("Copy"))
		        _currentComponent.PartNumber = _currentComponent.PartNumber.Replace("Copy", "");

			PartNumber = _currentComponent.PartNumber;
            Code = _currentComponent.Code;
            SerialNumber = _currentComponent.SerialNumber;
            BatchNumber = _currentComponent.BatchNumber;
            IdNumber = _currentComponent.IdNumber;
            ATAChapter = _currentComponent.ATAChapter;
            Description = _currentComponent.Model != null ? _currentComponent.Model.Description : _currentComponent.Description;
            Model = _currentComponent.Model;
            MaintenanceType = _currentComponent.MaintenanceControlProcess;
            ComponentStatus = _currentComponent.ComponentStatus;
            Manufacturer = _currentComponent.Manufacturer;
            ManufactureDate = _currentComponent.ManufactureDate;
            DeliveryDate = _currentComponent.DeliveryDate;
            InstallationDate = _currentComponent.TransferRecords.GetLast().TransferDate;
            Position = _currentComponent.TransferRecords.GetLast().Position;
            State = _currentComponent.TransferRecords.GetLast().State;
            ComponentLocation = _currentComponent.Location;
            Quantity = _currentComponent.Quantity;
            ALTPN = _currentComponent.ALTPartNumber;
            Discrepancy = _currentComponent.Discrepancy;
	        Incoming = _currentComponent.Incoming;
			IsDangerous = _currentComponent.IsDangerous;
			IsPool = _currentComponent.IsPOOL;

			if (_currentComponent.ProductCosts.Count == 0)
				_currentComponent.ProductCosts.Add(new ProductCost { QtyIn = _currentComponent.QuantityIn, Currency = Сurrency.USD });
			else _productCost = _currentComponent.ProductCosts.FirstOrDefault();

			dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _currentComponent.ProductCosts);

			documentControl1.CurrentDocument = _currentComponent.Document;
			documentControl1.Added += DocumentControl1_Added;

			if (_isStore)
	        {
		        textBoxMPDItem.Enabled = false;
		        MPDItem = "";
	        }
	        else
	        {
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
				if (parentAircraft.MSG == MSG.MSG3)
				{
					textBoxMPDItem.Enabled = false;
					MPDItem = "";
				}
				else
				{
					textBoxMPDItem.Enabled = true;
					MPDItem = _currentComponent.MPDItem;
				}

		        if (_currentComponent.LLPMark && _currentComponent.LLPCategories)
		        {
					var list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
								.OfType<LLPLifeLimitCategory>()
								.Where(llp => llp.AircraftModel.ItemId == parentAircraft.Model.ItemId).ToList();

					foreach (var category in list)
					{
						var llpData = _currentComponent.LLPData.GetItemByCatagory(category);
						if (llpData == null)continue;

						llpData.LLPLifelengthCurrent.Days = Convert.ToInt32((InstallationDate.Date.Ticks - ManufactureDate.Date.Ticks) / TimeSpan.TicksPerDay);
						llpData.LLPLifeLengthForDate.Days = Convert.ToInt32((llpData.FromDate.Date.Ticks - ManufactureDate.Date.Ticks) / TimeSpan.TicksPerDay);

						if (category.CategoryType == LLPLifeLimitCategoryType.A)
						{
							lifelengthViewer2.Lifelength = llpData.LLPLifelengthCurrent;
							lifelengthViewerAStartFrom.Lifelength = llpData.LLPLifeLengthForDate;
							dateTimePickerAStartFrom.Value = llpData.FromDate;
						}
						else if (category.CategoryType == LLPLifeLimitCategoryType.B)
						{
							lifelengthViewer3.Lifelength = llpData.LLPLifelengthCurrent;
							lifelengthViewerBStartFrom.Lifelength = llpData.LLPLifeLengthForDate;
							dateTimePickerBStartFrom.Value = llpData.FromDate;
						}
						else if (category.CategoryType == LLPLifeLimitCategoryType.C)
						{
							lifelengthViewer4.Lifelength = llpData.LLPLifelengthCurrent;
							lifelengthViewerCStartFrom.Lifelength = llpData.LLPLifeLengthForDate;
							dateTimePickerCStartFrom.Value = llpData.FromDate;
						}
						else
						{
							lifelengthViewer5.Lifelength = llpData.LLPLifelengthCurrent;
							lifelengthViewerDStartFrom.Lifelength = llpData.LLPLifeLengthForDate;
							dateTimePickerDStartFrom.Value = llpData.FromDate;
						}
					}
				}

			}
	        
			if (_currentComponent is BaseComponent)
            {
                //MaintenanceType = ((Detail)currentDetail).MaintenanceType;
                if (((BaseComponent)_currentComponent).BaseComponentType == BaseComponentType.LandingGear)
                    LandingGearMark = _currentComponent.LandingGear;
                else
                    Position = _currentComponent.TransferRecords.GetLast().Position;
                if (((BaseComponent)_currentComponent).BaseComponentType == BaseComponentType.Engine)
                {
                    HusKit = _currentComponent.HushKit;
                    MaxTakeOffWeight = _currentComponent.MTOGW;
                    textBoxThrust.Text = ((BaseComponent) _currentComponent).Thrust;
                }
                checkBoxLLPCategories.Checked = ((BaseComponent)_currentComponent).LLPCategories;
	            var selectedCategory = _currentComponent.ChangeLLPCategoryRecords.GetLast()?.ToCategory;

	            if (selectedCategory != null)
	            {
		            if (selectedCategory.CategoryType == LLPLifeLimitCategoryType.A)
			            radioButtonA.Checked = true;
					else if(selectedCategory.CategoryType == LLPLifeLimitCategoryType.B)
						radioButtonB.Checked = true;
		            else if (selectedCategory.CategoryType == LLPLifeLimitCategoryType.C)
			            radioButtonC.Checked = true;
					else radioButtonD.Checked = true;
				}

				GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject)_currentComponent);
            }
            else
            {
	            if (_currentComponent.ParentBaseComponent != null && _currentComponent.ParentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
	            {
		            dateTimePickerStart.Value = _currentComponent.StartDate;
		            lifelengthViewerStart.Lifelength = _currentComponent.StartLifelength;
				}

                AvionicsInventoryMarkType = _currentComponent.AvionicsInventory;
                AvionicsInventoryMark = AvionicsInventoryMarkType != AvionicsInventoryMarkType.None;
                LLPDiskMark = _currentComponent.LLPMark;
                LLPCategoriesMark = _currentComponent.LLPCategories;
                GoodsClass = _currentComponent.GoodsClass;
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject)_currentComponent);
            }

            ////////////////////////////////////////////
            //загрузка котировочных ордеров для определения 
            //того, можно ли менять партийный и серийный номер данного агрегата
            List<RequestForQuotation> closedQuotations = new List<RequestForQuotation>();
            List<PurchaseOrder> closedPurchases = new List<PurchaseOrder>();
            try
            {
                closedQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(null,
                                                                                     new []{WorkPackageStatus.Closed},
                                                                                     false,
                                                                                     new [] { _currentComponent.Product }));
                closedPurchases.AddRange(GlobalObjects.PurchaseCore.GetPurchaseOrders(null,
                                                                                     WorkPackageStatus.Closed,
                                                                                     false,
                                                                                     new AbstractAccessory[] { _currentComponent }));
                if (closedQuotations.Count > 0 || closedPurchases.Count > 0)
                {
                    textBoxPartNo.ReadOnly = true;
                    textBoxSerialNo.ReadOnly = true;
                }
                else
                {
                    textBoxPartNo.ReadOnly = false;
                    textBoxSerialNo.ReadOnly = false;
                }
            }
            catch (Exception exception)
            {
	            var parametres = DestinationHelper.GetDestinationString(_currentComponent.ParentAircraftId, _currentComponent.ParentStoreId);
                parametres += "Detail:" + _currentComponent;
                Program.Provider.Logger.Log("Error while loading requestes for detail. Params:" + parametres, exception);
            }


	        radioButtonA.CheckedChanged += radioButton_CheckedChanged;
	        radioButtonB.CheckedChanged += radioButton_CheckedChanged;
	        radioButtonC.CheckedChanged += radioButton_CheckedChanged;
	        radioButtonD.CheckedChanged += radioButton_CheckedChanged;
		}

		#endregion

		private void DataGridViewControlSuppliers_CellValueChanged(object sender, EventArgs e)
		{
			if (dataGridViewControlSuppliers.PreResultRowList.Count == 0)
				return;

			dataGridViewControlSuppliers.CellValueChanged -= DataGridViewControlSuppliers_CellValueChanged;


			var qty = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[0].Value);
			var unitPrice = System.Convert.ToDouble(dataGridViewControlSuppliers.PreResultRowList[0].Cells[1].Value);
			var totalPrice = qty * unitPrice;
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


		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
	    {
		    var newDocument = CreateNewDocument();
		    var form = new DocumentForm(newDocument, false);
		    if (form.ShowDialog() == DialogResult.OK)
		    {
			    _currentComponent.Document = newDocument;
			    documentControl1.CurrentDocument = newDocument;

		    }
	    }

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
	    {
		    var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;
		    var partNumber = _currentComponent.PartNumber;
		    var serialNumber = _currentComponent.SerialNumber;
		    var description = _currentComponent.Description;

		    return new Document
		    {
			    ParentId = _currentComponent.ItemId,
			    Parent = _currentComponent,
			    ParentTypeId = _currentComponent.SmartCoreObjectType.ItemId,
			    DocType = DocumentType.TechnicalRecords,
			    DocumentSubType = docSubType,
			    IsClosed = true,
			    ContractNumber = $"P/N:{partNumber} S/N:{serialNumber}",
			    Description = description,
				ParentAircraftId = _currentComponent.ParentAircraftId
		    };
	    }

	    #endregion

		#region public void ApplyChanges(Component component)

		public void ApplyChanges(Component component)
	    {
		    component.ATAChapter = ATAChapter;
		    component.PartNumber = PartNumber;
			component.Code = Code;
		    component.SerialNumber = SerialNumber;
		    component.BatchNumber = BatchNumber;
		    component.IdNumber = IdNumber;
		    component.Description = Description;
		    component.LandingGear = LandingGearMark;
		    component.Model = Model;
		    component.MaintenanceControlProcess = MaintenanceType;
		    component.ComponentStatus = ComponentStatus;
		    component.Manufacturer = Manufacturer;
		    component.ManufactureDate = ManufactureDate;
		    component.DeliveryDate = DeliveryDate;
		    component.MTOGW = MaxTakeOffWeight;
		    component.HushKit = HusKit;
		    component.AvionicsInventory = AvionicsInventoryMarkType;
		    component.ALTPartNumber = ALTPN;
		    component.Location = ComponentLocation;
		    component.GoodsClass = component.Model != null ? component.Model.GoodsClass : GoodsClass;
		    component.Incoming = Incoming;
		    component.IsPOOL = IsPool;
		    component.IsDangerous = IsDangerous;
		    component.Discrepancy = Discrepancy;
			component.FromSupplier = comboBoxSupplier.SelectedItem as Supplier;
		    component.FromSupplierReciveDate = dateTimePickerReciveDate.Value;

			fileControlShipping.ApplyChanges();
			component.IncomingFile = fileControlShipping.AttachedFile;

			dataGridViewControlSuppliers.ApplyChanges(true);

			component.ProductCosts.Clear();
			component.ProductCosts.AddRange(dataGridViewControlSuppliers.GetItemsArray());

			if (!_isStore)
		    {
			    var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentAircraftId);
				//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			    if (parentAircraft.MSG == MSG.MSG2)
				    component.MPDItem = MPDItem;


				var list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
								.OfType<LLPLifeLimitCategory>()
								.Where(llp => llp.AircraftModel.ItemId == parentAircraft.Model.ItemId).ToList();

				foreach (var category in list)
				{
					var llpData = _currentComponent.LLPData.GetItemByCatagory(category);

					if(llpData == null)
						continue;

					if (category.CategoryType == LLPLifeLimitCategoryType.A)
					{
						llpData.LLPLifelengthCurrent = lifelengthViewer2.Lifelength;
						llpData.LLPLifeLengthForDate = lifelengthViewerAStartFrom.Lifelength;
						llpData.FromDate = dateTimePickerAStartFrom.Value;
					}
					else if (category.CategoryType == LLPLifeLimitCategoryType.B)
					{
						llpData.LLPLifelengthCurrent = lifelengthViewer3.Lifelength;
						llpData.LLPLifeLengthForDate = lifelengthViewerBStartFrom.Lifelength;
						llpData.FromDate = dateTimePickerBStartFrom.Value;
					}
					else if (category.CategoryType == LLPLifeLimitCategoryType.C)
					{
						llpData.LLPLifelengthCurrent = lifelengthViewer4.Lifelength;
						llpData.LLPLifeLengthForDate = lifelengthViewerCStartFrom.Lifelength;
						llpData.FromDate = dateTimePickerCStartFrom.Value;
					}
					else
					{
						llpData.LLPLifelengthCurrent = lifelengthViewer5.Lifelength;
						llpData.LLPLifeLengthForDate = lifelengthViewerDStartFrom.Lifelength;
						llpData.FromDate = dateTimePickerDStartFrom.Value;
					}
				}

			}

		    if (component is BaseComponent)
		    {
			    var bd = component as BaseComponent;
			    if (bd.BaseComponentType == BaseComponentType.Engine)
				    bd.Thrust = textBoxThrust.Text;
		    }
		    else
		    {
			    if (_currentComponent.ParentBaseComponent != null && _currentComponent.ParentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
			    {
				    _currentComponent.StartDate = dateTimePickerStart.Value;
					_currentComponent.StartLifelength = lifelengthViewerStart.Lifelength;
			    }
				component.Quantity = Quantity;
		    }
	    }

	    #endregion

        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";
            if (ATAChapter == null || ATAChapter.ItemId <= 0)
            {
                if (message != "") message += "\n ";
                message += "Please select ATA chapter";
            }

			string validateFiles;
			if (!fileControlShipping.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "Shipping File: " + validateFiles;
			}
			if (textBoxManufacturer.Text == "" && dataGridViewControlSuppliers.Count == 0)
			{
				if (message != "") message += "\n ";
				message += "Not set Manufacturer or Suppliers";
				return false;
			}

			if (message != "")
                return false;
            return true;
        }

        #endregion

        #region private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)
        {
            dateTimePickerInstallationDate.ValueChanged -= DateTimePickerInstallationDateValueChanged;

            if (_currentComponent == null)
            {
                if(dateTimePickerInstallationDate.Value < DateTimeExtend.GetCASMinDateTime())
                    dateTimePickerInstallationDate.Value = DateTimeExtend.GetCASMinDateTime();
                if(dateTimePickerInstallationDate.Value > DateTime.Today)
                    dateTimePickerInstallationDate.Value = DateTime.Today;
            }
            else
            {
                TransferRecord record = _currentComponent.TransferRecords.GetLast();

                if (record.FromAircraftId == 0 && 
                    record.FromBaseComponentId == 0 && 
                    record.FromStoreId == 0)
                {
                    //Деталь только что добавлена, ни откуда не перемещалась
                    //Ограничением будет дата производства детали

                    if (dateTimePickerInstallationDate.Value < dateTimePickerManufactureDate.Value)
                        dateTimePickerInstallationDate.Value = dateTimePickerManufactureDate.Value;
                }
                else
                {
                    // Деталь была перемещена откуда - то,
                    // Ограничением будет дата начала перемещения
                    if (dateTimePickerInstallationDate.Value < record.StartTransferDate)
                        dateTimePickerInstallationDate.Value = record.StartTransferDate;
                }

                if (dateTimePickerInstallationDate.Value > DateTime.Now)
                    dateTimePickerInstallationDate.Value = DateTime.Now;
            }

            dateTimePickerInstallationDate.ValueChanged += DateTimePickerInstallationDateValueChanged;
        }
        #endregion

        #region private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)

        private void CheckBoxAvionicsInventoryMarkCheckedChanged(object sender, EventArgs e)
        {
            AvionicsInventoryMark = checkBoxAvionicsInventory.Checked;
            if (!(radioButtonInventoryOptional.Checked) && !(radioButtonInventoryRequired.Checked) && !(radioButtonAvionicsInventoryUnknown.Checked) && (checkBoxAvionicsInventory.Checked))
                radioButtonInventoryOptional.Checked = true;
        }

        #endregion

        #region private void CheckBoxLLPMarkClick(object sender, EventArgs e)
        /// <summary>
        /// событие нажатия на маркер LLP, происходит только при отображении детали, 
        /// родителем которой является двигатель
        /// (в противном случае контрол CheckBoxLLPMark скрыт, и событие невозможно)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxLLPMarkClick(object sender, EventArgs e)
        {
            if (_currentComponent is BaseComponent) return;
            Component d = _currentComponent;
            d.LLPMark = checkBoxLLPCategories.Visible = checkBoxLLPMark.Checked;

            if(d.ParentBaseComponent != null)//TODO:(Evgenii Babak) заменить на использование ComponentCore 
			{
                if (d.ParentBaseComponent.BaseComponentType == BaseComponentType.Engine && d.ParentBaseComponent.LLPCategories)//TODO:(Evgenii Babak) заменить на использование ComponentCore 
				{
                    //родительской деталью является двигатель
                    //и расчеты его дочерних крутящихся элементов расчитываются по категориям, то:
                    d.LLPCategories = checkBoxLLPCategories.Checked = d.ParentBaseComponent.LLPCategories;
                }
                //else
                //{
                //если дочерние элемнты двигателя не расичтываются по LLP то 
                //нужно просто посатвить маркер LLP на данную деталь 
                //(это было сделано выше d.LLPMark = checkBoxLLPMark.Checked;)
                //}
            }
            //else
            //{
            //    //Если родительской деталт нет (данная деталь могла юыть перемещена на склад)
            //    //то маркер LLP катерогий береться из текущей детали т.к. был установлен в тот момент
            //    //когда деталь находилась на базовой детали
            //    checkBoxLLPCategories.Checked = d.LLPCategories;   
            //}
            
            if (d.LLPMark && d.LLPCategories && d.ChangeLLPCategoryRecords.Count == 0)
            {
                LLPLifeLimitCategory changeOnCategory = null;
                List<LLPLifeLimitCategory> list = null;

                var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);//TODO:(Evgenii Babak) надо пересмореть т.к из Aircraft тут используется только Model

				if (aircraft != null)
                {
                    list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                        .OfType<LLPLifeLimitCategory>()
                        .Where(c => c.AircraftModel == aircraft.Model)
                        .ToList();
                    //LINQ запрос для сортировки записей по дате;
                    list = (from record in list orderby record.GetChar() ascending select record).ToList();
                    changeOnCategory = list.FirstOrDefault();
                }

                d.ChangeLLPCategoryRecords.Add(new ComponentLLPCategoryChangeRecord
                {
                    ParentId = d.ItemId,
                    ToCategory = changeOnCategory ?? LLPLifeLimitCategory.Unknown,
                    RecordDate = d.ManufactureDate,
                    OnLifelength = Lifelength.Zero
                });

                GlobalObjects.CasEnvironment.NewKeeper.Save(d.ChangeLLPCategoryRecords[0]);

                if (d.LLPData.Count == 0 && list != null)
                    foreach (LLPLifeLimitCategory category in list)
                    {
                        d.LLPData.Add(new ComponentLLPCategoryData
                        {
                            LLPLifeLimit = d.LifeLimit,
                            ParentCategory = category,
                            ComponentId = d.ItemId
                        });
                        GlobalObjects.CasEnvironment.NewKeeper.Save(d.LLPData.Last());
                    }
            }
            if (LLPMarkChecked != null) LLPMarkChecked(this, e); 
        }
        #endregion

        #region private void CheckBoxLLPCategoriesClick(object sender, EventArgs e)
        /// <summary>
        /// событие нажатия на маркер LLP категории, происходит только при отображении двигателя
        /// (в противном случае контрол CheckBoxLLPCategories заблокирован, и событие невозможно)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxLLPCategoriesClick(object sender, EventArgs e)
        {
            if (!(_currentComponent is BaseComponent)) return;
            //Елси данное событие произошло, то надо перевести все дочерние детали
            //имеющие маркер LLP на расчет по категориям LLP(checked), 
            //или наоборот перевести на обычный расчет
            var bd = (BaseComponent) _currentComponent;
            bd.LLPCategories = checkBoxLLPCategories.Checked;
            //извлечение всех LLPmark деталей
            var details = GlobalObjects.ComponentCore.GetComponents(bd, true);

            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(bd.ParentAircraftId);//TODO:(Evgenii Babak) надо пересмореть т.к из Aircraft тут используется только Model
			List<LLPLifeLimitCategory> list = null;
            if (aircraft != null)
            {
                list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                        .OfType<LLPLifeLimitCategory>()
                        .Where(c => c.AircraftModel.ItemId == aircraft.Model.ItemId)
                        .ToList();
                //LINQ запрос для сортировки записей по дате;
                list = (from record in list orderby record.GetChar() ascending select record).ToList();
            }
            foreach (var detail in details)
            {
                if (detail.LLPData.Count == 0 && list != null)
                    foreach (LLPLifeLimitCategory category in list)
                    {
                        detail.LLPData.Add(new ComponentLLPCategoryData
                        {
                            ParentCategory = category,
                            ComponentId = detail.ItemId
                        });
                    }
                            
                detail.LLPCategories = bd.LLPCategories;
                GlobalObjects.ComponentCore.Save(detail);
                if (detail.LLPMark && detail.LLPCategories && detail.ChangeLLPCategoryRecords.Count == 0)
                {
                    detail.ChangeLLPCategoryRecords.Add(new ComponentLLPCategoryChangeRecord
                    {
                        ParentId = detail.ItemId,
                        ToCategory = list != null && list.Count != 0 ? list[0] : LLPLifeLimitCategory.Unknown,
                        RecordDate = detail.ManufactureDate,
                        OnLifelength = Lifelength.Zero
                    });
                    GlobalObjects.CasEnvironment.NewKeeper.Save(detail.ChangeLLPCategoryRecords[0]);
                }
                
            }
            GlobalObjects.ComponentCore.Save(bd);     
        }
        #endregion

        #region private void ComboBoxComponentTypeSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxComponentTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            GoodsClass dt = comboBoxComponentType.SelectedItem as GoodsClass;
            if (dt == null)
                labelQuantity.Visible = numericUpDownQuantity.Visible = false;
            else if (dt == GoodsClass.AircraftComponentsEmergency)
                labelQuantity.Visible = numericUpDownQuantity.Visible = true;
            else labelQuantity.Visible = numericUpDownQuantity.Visible = false;

            InvokeComponentTypeChanged(dt ?? GoodsClass.Unknown);
        }
        #endregion

        #region private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            ComponentModel accessoryDescription;
            if ((accessoryDescription = comboBoxModel.SelectedItem as ComponentModel) != null)
            {
	            if (accessoryDescription.ImageFile?.FileSize != null)
	            {
		            fileControlImage.Enabled = true;
		            fileControlImage.UpdateInfo(accessoryDescription.ImageFile,
			            "Image Files|*.jpg;*.jpeg;*.png",
			            "This record does not contain a image. Enclose Image file to prove the compliance.",
			            "Attached file proves the Image.");
		            fileControlImage.ShowLinkLabelRemove = false;
	            }
	            else
	            {
					fileControlImage.UpdateInfo(null,"","","");
		            fileControlImage.Enabled = false;
	            }

				UpdateSupplier(accessoryDescription);

				if (_productCost != null && _productCost.KitId == accessoryDescription.ItemId)
					dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _currentComponent.ProductCosts);
				else ResetProductCost();

				comboBoxComponentType.SelectedItem = accessoryDescription.GoodsClass;
	            checkBoxDangerous.Checked = accessoryDescription.IsDangerous;

                comboBoxComponentType.Enabled = false;
                comboBoxAtaChapter.ATAChapter = accessoryDescription.ATAChapter;
                comboBoxAtaChapter.Enabled = false;
                textBoxPartNo.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
				textBoxProductCode.ReadOnly = true;


				textBoxPartNo.Text = accessoryDescription.PartNumber;
				textBoxAltPartNum.Text = accessoryDescription.AltPartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
                textBoxProductCode.Text = accessoryDescription.Code;
                textBoxManufacturer.Text = accessoryDescription.Manufacturer;
                //dataGridViewControlSuppliers.SetItemsArray(accessoryDescription.SupplierRelations);
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }
            else
            {
	            comboBoxSupplier.Enabled = false;
	            comboBoxSupplier.SelectedItem = null;
				dateTimePickerReciveDate.Value = DateTimeExtend.GetCASMinDateTime();
				dateTimePickerReciveDate.Enabled = false;

				comboBoxComponentType.Enabled = true;
                comboBoxAtaChapter.Enabled = true;
                //comboBoxMeasure.Enabled = true;
                //comboBoxStandart.Enabled = true;
                textBoxPartNo.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                textBoxProductCode.ReadOnly = false;
                //dataGridViewControlSuppliers.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
            }

            //comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
        }
		#endregion

		#region private void checkBoxIncoming_CheckedChanged(object sender, EventArgs e)

		private void checkBoxIncoming_CheckedChanged(object sender, EventArgs e)
	    {
		    textBoxDiscrepancy.Enabled = !checkBoxIncoming.Checked;
	    }

		#endregion

		#region private void UpdateSupplier(ComponentModel model)

		private void UpdateSupplier(ComponentModel model)
	    {
		    comboBoxSupplier.Items.Clear();

		    var suppliers = model.SupplierRelations.Select(r => r.Supplier).ToArray();
		    comboBoxSupplier.Items.AddRange(suppliers);
		    comboBoxSupplier.Items.Add(Supplier.Unknown);

		    if (comboBoxSupplier.Items.Count > 1)
			    comboBoxSupplier.SelectedItem = _currentComponent.FromSupplier;
		    else comboBoxSupplier.SelectedItem = Supplier.Unknown;

		    if (_currentComponent.FromSupplier == Supplier.Unknown)
			    dateTimePickerReciveDate.Value = DateTimeExtend.GetCASMinDateTime();
		    else
			    dateTimePickerReciveDate.Value = _currentComponent.FromSupplierReciveDate;

		    if(_isStore)
			    comboBoxSupplier.Enabled = dateTimePickerReciveDate.Enabled = suppliers.Length > 0;
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

		#region Events
		///<summary>
		/// Событие оповещающее о смене отметки о принедлежности детали к LLP 
		///</summary>
		public event EventHandler LLPMarkChecked;

	    public event EventHandler LLPLifeLimitChanged;

		#region public event ValueChangedEventHandler ComponentTypeChanged
		///<summary>
		/// Сигнализирует о смене типа компонента
		///</summary>
		private void InvokeComponentTypeChanged(GoodsClass value)
        {
            ValueChangedEventHandler handler = ComponentTypeChanged;
            if (handler != null) handler(new ValueChangedEventArgs(value));
        }
        ///<summary>
        /// Событие оповещающее о смене типа компонента
        ///</summary>
        [Category("Component data")]
        [Description("Возникает при изменении типа компонента")]
        public event ValueChangedEventHandler ComponentTypeChanged;
		#endregion

		#endregion

		private void dateTimePickerReciveDate_ValueChanged(object sender, EventArgs e)
		{
			DeliveryDate = dateTimePickerReciveDate.Value;
		}

		private void dateTimePickerDeliveryDate_ValueChanged(object sender, EventArgs e)
		{
			if(dateTimePickerReciveDate.Enabled)
				dateTimePickerReciveDate.Value  = DeliveryDate;
		}

		private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedSupplier = comboBoxSupplier.SelectedItem as Supplier;

			if (_productCost != null && _productCost.SupplierId == selectedSupplier.ItemId)
				dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _currentComponent.ProductCosts);
			else ResetProductCost();
		}

		private void checkBoxLLPCategories_CheckedChanged(object sender, EventArgs e)
		{
			if (_currentComponent is BaseComponent)
			{
				labelCheck.Visible = radioButtonA.Visible =
					radioButtonB.Visible = radioButtonC.Visible = radioButtonD.Visible = checkBoxLLPCategories.Checked;
			}
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			radioButtonA.CheckedChanged -= radioButton_CheckedChanged;
			radioButtonB.CheckedChanged -= radioButton_CheckedChanged;
			radioButtonC.CheckedChanged -= radioButton_CheckedChanged;
			radioButtonD.CheckedChanged -= radioButton_CheckedChanged;

			if (_currentComponent.ChangeLLPCategoryRecords.GetLast() != null &&
			    _currentComponent.ChangeLLPCategoryRecords.GetLast().RecordDate.Date == DateTime.Today)
			{
				MessageBox.Show(@"On this day there is a record of the change of category.\n
                                  Edit an existing record",
					new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			var dlg = new ComponentChangeLLPCategoryRecordForm(_currentComponent, new ComponentLLPCategoryChangeRecord
				{
					ParentComponent = _currentComponent,
					RecordDate = DateTime.Now
				});
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				_animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
				_animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
				_animatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				var selectedCategory = _currentComponent.ChangeLLPCategoryRecords.GetLast()?.ToCategory;

				if (selectedCategory != null)
				{
					if (selectedCategory.CategoryType == LLPLifeLimitCategoryType.A)
						radioButtonA.Checked = true;
					else if (selectedCategory.CategoryType == LLPLifeLimitCategoryType.B)
						radioButtonB.Checked = true;
					else if (selectedCategory.CategoryType == LLPLifeLimitCategoryType.C)
						radioButtonC.Checked = true;
					else radioButtonD.Checked = true;
				}
				else
				{
					radioButtonA.Checked = radioButtonB.Checked = radioButtonC.Checked = radioButtonD.Checked = false;
					radioButtonA.CheckedChanged += radioButton_CheckedChanged;
					radioButtonB.CheckedChanged += radioButton_CheckedChanged;
					radioButtonC.CheckedChanged += radioButton_CheckedChanged;
					radioButtonD.CheckedChanged += radioButton_CheckedChanged;
				}
			}

		}

		private void _animatedThreadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (LLPLifeLimitChanged != null)
				LLPLifeLimitChanged(this, e);
		}

		private void _animatedThreadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentComponent);

			if (((BaseComponent) _currentComponent).BaseComponentType == BaseComponentType.Engine)
			{
				var components = GlobalObjects.ComponentCore.GetComponents((BaseComponent) _currentComponent, true);

				var lastRecords = _currentComponent.ChangeLLPCategoryRecords.GetLast();
				if(lastRecords == null)
					return;
				foreach (var component in components)
				{
					var newLLpRecord = new ComponentLLPCategoryChangeRecord
					{
						ParentComponent = component,
						RecordDate = lastRecords.RecordDate,
						ToCategory = lastRecords.ToCategory,
					};

					var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);
					var list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
						.OfType<LLPLifeLimitCategory>()
						.Where(llp => llp.AircraftModel?.ItemId == aircraft.Model.ItemId)
						.ToList();
					//LINQ запрос для сортировки записей по дате;
					var sortrecords = (from record in list
						orderby record.GetChar() ascending
						select record).ToList();

					foreach (var t in sortrecords)
					{
						var llpData = component.LLPData.GetItemByCatagory(t);
						if (llpData == null)
						{
							llpData = new ComponentLLPCategoryData
							{
								//LLPLifeLimit = component.LifeLimit,TODO:Обсудить
								ParentCategory = t,
								ComponentId = component.ItemId
							};
							component.LLPData.Add(llpData);
							GlobalObjects.CasEnvironment.NewKeeper.Save(llpData);
						}
					}

					try
					{
						GlobalObjects.ComponentCore.RegisterChangeLLPCategory(component, newLLpRecord);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while saving data", ex);
					}

				}
			}
		}

		private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
		{
			dateTimePickerStart.ValueChanged -= dateTimePickerStart_ValueChanged;

			if (dateTimePickerStart.Value < DateTimeExtend.GetCASMinDateTime())
				dateTimePickerStart.Value = DateTimeExtend.GetCASMinDateTime();

			var a = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);

			_currentComponent.StartLifelength.Days = Calculator.GetDays(a.ManufactureDate, dateTimePickerStart.Value);
			lifelengthViewerStart.Lifelength = _currentComponent.StartLifelength;

			dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
		}
	}
}
