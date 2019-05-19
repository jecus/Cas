using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CASTerms;
using System.Linq;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.KitControls
{
    ///<summary>
    /// ЭУ для отображения информации KIT-а
    ///</summary>
    public partial class KitFormItem : UserControl
    {
        #region Fields
        private AbstractAccessory _currentKit;
        #endregion

        #region Properties

        #region public AbstractAccessory Kit
        ///<summary>
        /// Возвращает или назначает текущий KIT
        ///</summary>
        public AbstractAccessory Kit
        {
            get { return _currentKit; }
            set
            {
                _currentKit = value; 
                UpdateInformation();
            }
        }
        #endregion

        #region public bool ButtonDeleteVisible
        ///<summary>
        ///</summary>
        public bool ButtonDeleteVisible
        {
            get { return ButtonDelete.Visible; }
            set { ButtonDelete.Visible = value; }
        }
        #endregion

        #endregion

        #region Constructors

        #region public KitFormItem()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public KitFormItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public KitFormItem(AbstractAccessory currentKit) : this()
        ///<summary>
        /// Конструктор, принимающий KIT для отображения
        ///</summary>
        public KitFormItem(AbstractAccessory currentKit) : this ()
        {
            _currentKit = currentKit;
            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            comboBoxProduct.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;
            comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            textBoxRemarks.Text = string.Empty;
            comboBoxProduct.Type = typeof(Product);
            Program.MainDispatcher.ProcessControl(comboBoxProduct);

            comboBoxStandart.Type = typeof(GoodStandart);
            Program.MainDispatcher.ProcessControl(comboBoxStandart);


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

            comboBoxMeasure.Items.Add(Measure.Liter);
            comboBoxMeasure.Items.Add(Measure.Gallon);
            comboBoxMeasure.Items.Add(Measure.Quart);
            comboBoxMeasure.Items.Add(Measure.SquareMeter);
            comboBoxMeasure.Items.Add(Measure.Foot);
            comboBoxMeasure.Items.Add(Measure.Miles);
            comboBoxMeasure.Items.Add(Measure.SquareFoot);
            comboBoxMeasure.Items.Add(Measure.Metres);
            comboBoxMeasure.Items.Add(Measure.Centimeters);

            if (_currentKit == null) return;

            comboBoxDetailClass.SelectedItem = GoodsClass.KIT;
            comboBoxMeasure.SelectedItem = Measure.Unit;
            comboBoxProduct.SelectedItem = _currentKit.Product;

            Product accessoryDescription;
            if ((accessoryDescription = _currentKit.Product) != null)
            {
                comboBoxDetailClass.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                comboBoxStandart.Enabled = false;
                textBoxDescription.ReadOnly = true;
                //linkLabelEditSupplier.Enabled = true;

                comboBoxMeasure.SelectedItem = accessoryDescription.Measure;
                comboBoxStandart.SelectedItem = accessoryDescription.Standart;
                textBoxPartNumber.Text = accessoryDescription.PartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
                textBoxReference.Text = accessoryDescription.Reference;
                //textBoxSuppliers.Text = accessoryDescription.Suppliers.ToString();
            }
            else if (_currentKit.Standart != null)
            {
                GoodStandart accessoryStandart = _currentKit.Standart;
                comboBoxDetailClass.SelectedItem = accessoryStandart.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                //comboBoxMeasure.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //linkLabelEditSupplier.Enabled = true;

                //comboBoxMeasure.SelectedItem = accessoryStandart.Measure;
                comboBoxStandart.SelectedItem = accessoryStandart;
                textBoxPartNumber.Text = accessoryStandart.PartNumber;
                textBoxDescription.Text = accessoryStandart.Description;
                textBoxReference.Text = "";
            }
            else
            {
                if (_currentKit is Component)
                {
                    comboBoxDetailClass.SelectedItem = _currentKit.GoodsClass;

                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    comboBoxStandart.Enabled = false;
                    textBoxDescription.ReadOnly = true;
                    //linkLabelEditSupplier.Enabled = true;

                    comboBoxMeasure.SelectedItem = _currentKit.Measure;
                    comboBoxStandart.SelectedItem = _currentKit.Standart;
                    textBoxPartNumber.Text = _currentKit.PartNumber;
                    textBoxDescription.Text = _currentKit.Description;
                    textBoxReference.Text = _currentKit.Product?.Reference;
                    //textBoxSuppliers.Text = _currentKit.Suppliers.ToString();   
                }
            }
            textBoxRemarks.Text = _currentKit.Remarks;
            numericCount.Value = (decimal)_currentKit.Quantity;

            if(_currentKit.ItemId > 0)
            {
                //if (comboBoxAccessoryDescription.SelectedItem != null)
                //{
                //    comboBoxAccessoryDescription.Enabled = _currentKit.Product.IsDeleted;
                //    comboBoxDetailClass.Enabled = false;
                //    comboBoxMeasure.Enabled = false;
                //    textBoxPartNumber.ReadOnly = false;
                //    textBoxDescription.ReadOnly = false;
                //    textBoxManufacturer.ReadOnly = false;
                //    textBoxRemarks.ReadOnly = false;
                //    if (_rfqr != null)
                //    {
                //        numericCostNew.ReadOnly = true;
                //        numericCostServiceable.ReadOnly = true;
                //        numericCostOverhaul.ReadOnly = true;
                //    }
                //    else
                //    {
                //        numericCostNew.ReadOnly = false;
                //        numericCostServiceable.ReadOnly = false;
                //        numericCostOverhaul.ReadOnly = false;
                //    }
                //    textBoxSuppliers.ReadOnly = false;
                //    linkLabelEditSupplier.Enabled = false;
                //}
                //else
                //{
                //    comboBoxDetailClass.Enabled = true;
                //    comboBoxMeasure.Enabled = true;
                //    textBoxPartNumber.ReadOnly = true;
                //    textBoxDescription.ReadOnly = true;
                //    textBoxManufacturer.ReadOnly = true;
                //    textBoxRemarks.ReadOnly = true;
                //    numericCostNew.ReadOnly = true;
                //    numericCostServiceable.ReadOnly = true;
                //    numericCostOverhaul.ReadOnly = true;
                //    textBoxSuppliers.ReadOnly = true;
                //    linkLabelEditSupplier.Enabled = true;
                //}

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
                                                                                         new[] { _currentKit.Product }));
                    closedPurchases.AddRange(GlobalObjects.PurchaseCore.GetPurchaseOrders(null,
                                                                                         WorkPackageStatus.Closed,
                                                                                         false,
                                                                                         new [] { _currentKit }));
                    comboBoxProduct.Enabled = 
                        _currentKit.Product == null || 
                        _currentKit.Product.IsDeleted || 
                        (closedQuotations.Count == 0 && closedPurchases.Count == 0);
                }
                catch (Exception exception)
                {
                    Program.Provider.Logger.Log("Error while loading requestes for detail", exception);
                }
            }
            //else
            //{
            //    //comboBoxDetailClass.SelectedItem = DetailClass.Kit;
            //    //comboBoxDetailClass.Enabled = true;
            //    //textBoxPartNumber.ReadOnly = true;
            //    //textBoxDescription.ReadOnly = true;
            //    //textBoxManufacturer.ReadOnly = true;
            //    //textBoxRemarks.ReadOnly = true;
            //    //numericCostNew.ReadOnly = true;
            //    //numericCostServiceable.ReadOnly = true;
            //    //numericCostOverhaul.ReadOnly = true;
            //    //textBoxSuppliers.ReadOnly = true;
            //    //linkLabelEditSupplier.Enabled = true;
            //}
            //if (_currentKit.ItemId > 0)
            //{
            //    Product accessoryDescription;
            //    if((accessoryDescription = comboBoxAccessoryDescription.SelectedItem as Product) != null)
            //    {
            //        comboBoxAccessoryDescription.Enabled = accessoryDescription.IsDeleted;
            //    }
            //    else comboBoxAccessoryDescription.Enabled = true;

            //    //////////////////////////////////////////////
            //    ////загрузка котировочных ордеров для определения 
            //    ////того, можно ли менять партийный и серийный номер данного агрегата
            //    //List<RequestForQuotation> closedQuotations = new List<RequestForQuotation>();
            //    //List<PurchaseOrder> closedPurchases = new List<PurchaseOrder>();
            //    //try
            //    //{
            //    //    closedQuotations.AddRange(GlobalObjects.CasEnvironment.Loader.GetRequestForQuotation(null,
            //    //                                                                         WorkPackageStatus.Closed,
            //    //                                                                         false,
            //    //                                                                         new CommonCollection<AbstractAccessory> { _currentKit }));
            //    //    closedPurchases.AddRange(GlobalObjects.CasEnvironment.Loader.GetPurchaseOrders(null,
            //    //                                                                         WorkPackageStatus.Closed,
            //    //                                                                         false,
            //    //                                                                         new CommonCollection<AbstractAccessory> { _currentKit }));
            //    //    textBoxPartNumber.ReadOnly = (closedQuotations.Count > 0 || closedPurchases.Count > 0);
            //    //}
            //    //catch (Exception exception)
            //    //{
            //    //    Program.Provider.Logger.Log("Error while loading requestes for detail", exception);
            //    //}
            //}
            
            comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
            comboBoxProduct.SelectedIndexChanged += DictComboDescriptionSelectedIndexChanged;
        }
        #endregion

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            string kitStandartName = _currentKit.Standart != null ? _currentKit.Standart.FullName : "";
            if (comboBoxProduct.SelectedItem != _currentKit.Product
                || comboBoxMeasure.SelectedItem != _currentKit.Measure
                || (comboBoxStandart.SelectedItem != null 
                        ? comboBoxStandart.SelectedItem != _currentKit.Standart 
                        : (comboBoxStandart.Text != "Select Item" && comboBoxStandart.Text != "N/A"
                            ? comboBoxStandart.Text != kitStandartName
                            : kitStandartName != ""))
                || textBoxPartNumber.Text != _currentKit.PartNumber
                || textBoxDescription.Text != _currentKit.Description
                || textBoxRemarks.Text != _currentKit.Remarks
                //|| numericCostNew.Value != (decimal)_currentKit.CostNew
                //|| numericCostServiceable.Value != (decimal)_currentKit.CostServiceable
                //|| numericCostOverhaul.Value != (decimal)_currentKit.CostOverhaul
                || (comboBoxDetailClass.SelectedItem != _currentKit.GoodsClass))
                return true;

            if (numericCount.Value != (decimal)_currentKit.Quantity 
                //|| numericCostNew.Value != (decimal)_currentKit.CostNew 
                //|| numericCostServiceable.Value != (decimal)_currentKit.CostServiceable 
                //|| numericCostOverhaul.Value != (decimal)_currentKit.CostOverhaul
                )
                return true;

            return false;
        }
        #endregion

        #region private public ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";
            //if (comboBoxAccessoryDescription.SelectedItem == null && _currentKit.ItemId > 0)
            //{
            //    if (message != "") message += "\n ";
            //    message += "You can not save the existing item without using a template";
            //    return false;
            //}
            if (comboBoxDetailClass.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set detail type";
                return false;
            }
            if (comboBoxMeasure.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set measure";
                return false;
            }

            string standart = comboBoxStandart.Text;

            if (textBoxPartNumber.Text == "" && (standart == "Select Item" || standart == "N/A" || comboBoxStandart.SelectedItem == null))
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
            //if (comboBoxProduct.Text != "" && string.IsNullOrEmpty(textBoxReference.Text))
            //{
            //    if (message != "") message += "\n ";
            //    message += "Not set Reference";
            //    return false;
            //}
            //if (comboBoxMeasure.SelectedItem as Measure == null)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Not set Quantity";
            //    return false;
            //}
            if (numericCount.Value == 0)
            {
                if (message != "") message += "\n ";
                message += "Not set Quantity";
                return false;
            }
            return true;
        }

        #endregion

        #region public bool ApplyChanges()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void ApplyChanges()
        {
            _currentKit.Product = comboBoxProduct.SelectedItem as Product;
	        _currentKit.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
            _currentKit.Quantity = (double)numericCount.Value;
			_currentKit.PartNumber = textBoxPartNumber.Text;
			_currentKit.Description = textBoxDescription.Text;
			_currentKit.Standart = comboBoxStandart.SelectedItem as GoodStandart;
			_currentKit.Remarks = textBoxRemarks.Text;
			_currentKit.Measure = comboBoxMeasure.SelectedItem as Measure;

		}
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this item?", "Deleting confirmation", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) 
                == DialogResult.Yes)
            {
                if (Deleted != null)
                    Deleted(this, EventArgs.Empty);
            }
        }
        #endregion

        #region private void DictComboDescriptionSelectedIndexChanged(object sender, EventArgs e)
        private void DictComboDescriptionSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            Product accessoryDescription;
            if ((accessoryDescription = comboBoxProduct.SelectedItem as Product) != null)
            {
                comboBoxDetailClass.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                comboBoxStandart.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //linkLabelEditSupplier.Enabled = false;
                //textBoxRemarks.ReadOnly = true;

                comboBoxMeasure.SelectedItem = accessoryDescription.Measure;
                comboBoxStandart.SelectedItem = accessoryDescription.Standart;
                textBoxPartNumber.Text = accessoryDescription.PartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
                textBoxReference.Text = accessoryDescription.Reference;
                //textBoxSuppliers.Text = accessoryDescription.Suppliers.ToString();
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }

            if (_currentKit.ItemId > 0)
            {
                textBoxRemarks.Text = _currentKit.Remarks;

                if (accessoryDescription != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    comboBoxStandart.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                    //linkLabelEditSupplier.Enabled = false;
                    //textBoxRemarks.ReadOnly = true;
                    _currentKit.Suppliers = new SupplierCollection(accessoryDescription.Suppliers);
                    _currentKit.SupplierRelations = new CommonCollection<KitSuppliersRelation>(accessoryDescription.SupplierRelations);

                    //textBoxSuppliers.Text = accessoryDescription.Suppliers.ToString();
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    comboBoxMeasure.Enabled = true;
                    comboBoxStandart.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                    //linkLabelEditSupplier.Enabled = true;
                    //textBoxRemarks.ReadOnly = false;
                    //numericCostNew.ReadOnly = false;
                    //numericCostServiceable.ReadOnly = false;
                    //numericCostOverhaul.ReadOnly = false;
                }
            }
            else
            {
                if(accessoryDescription != null)
                {
                    textBoxRemarks.Text = accessoryDescription.Remarks;

                    _currentKit.Suppliers = new SupplierCollection(accessoryDescription.Suppliers);
                    _currentKit.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
                    foreach (KitSuppliersRelation ksr in accessoryDescription.SupplierRelations)
                    {
                        _currentKit.SupplierRelations.Add(new KitSuppliersRelation(ksr));
                    }

                    //textBoxSuppliers.Text = accessoryDescription.Suppliers.ToString();
                }
                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                comboBoxStandart.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                //linkLabelEditSupplier.Enabled = true;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
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
                //comboBoxMeasure.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //linkLabelEditSupplier.Enabled = false;
                //textBoxRemarks.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = goodStandart.Measure;
                textBoxPartNumber.Text = goodStandart.PartNumber;
                textBoxDescription.Text = goodStandart.Description;
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }

            if (_currentKit.ItemId > 0)
            {
                textBoxRemarks.Text = _currentKit.Remarks;

                if (goodStandart != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                    //linkLabelEditSupplier.Enabled = false;
                    //textBoxRemarks.ReadOnly = true;
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    comboBoxMeasure.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                    //textBoxRemarks.ReadOnly = false;
                    //numericCostNew.ReadOnly = false;
                    //numericCostServiceable.ReadOnly = false;
                    //numericCostOverhaul.ReadOnly = false;
                }
            }
            else
            {
                if (goodStandart != null)
                {
                    textBoxRemarks.Text = goodStandart.Remarks;
                }
                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
            }
        }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

		#endregion

		private void numericCount_ValueChanged(object sender, EventArgs e)
		{
			var dc = comboBoxDetailClass.SelectedItem as GoodsClass;
			if (dc == null)
			{
				comboBoxMeasure.Enabled = true;
				comboBoxMeasure.SelectedItem = _currentKit.Measure;
				numericCount.Maximum = decimal.MaxValue;
			}
			else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
			{
				comboBoxMeasure.Enabled = false;
				comboBoxMeasure.SelectedItem = Measure.Unit;
				numericCount.DecimalPlaces = 0;
				numericCount.Maximum = decimal.MaxValue;
			}
			else if (dc.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
			{
				comboBoxMeasure.Enabled = false;
				comboBoxMeasure.SelectedItem = Measure.Unit;
				numericCount.DecimalPlaces = 0;
				numericCount.Minimum = 0;
				numericCount.Maximum = 1;
			}
			else
			{
				numericCount.Maximum = decimal.MaxValue;
			}
		}
	}
}
