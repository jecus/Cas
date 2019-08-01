using System;
using System.Windows.Forms;
using System.Linq;
using CAS.UI.UIControls.ProductControls;
using CAS.UI.UIControls.PurchaseControls;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

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
	        comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            textBoxRemarks.Text = string.Empty;

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
            UpdateByProduct(_currentKit.Product);

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

            comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
        }
        #endregion

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            string kitStandartName = _currentKit.Standart != null ? _currentKit.Standart.FullName : "";
            if (comboBoxMeasure.SelectedItem != _currentKit.Measure
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
				message += "Not set Class";
				return false;
			}
			if (_currentKit.Product == null)
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
        private void UpdateByProduct(Product product)
        {
            comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;
            linkLabel1.Enabled = product != null;
			if (product != null)
            {
	            TextBoxProduct.Text = product.ToString();
				comboBoxDetailClass.SelectedItem = product.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                comboBoxStandart.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //linkLabelEditSupplier.Enabled = false;
                //textBoxRemarks.ReadOnly = true;

                comboBoxMeasure.SelectedItem = product.Measure;
                comboBoxStandart.SelectedItem = product.Standart;
                textBoxPartNumber.Text = product.PartNumber;
                textBoxDescription.Text = product.Description;
                textBoxReference.Text = product.Reference;
                //textBoxSuppliers.Text = accessoryDescription.Suppliers.ToString();
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }

            if (_currentKit.ItemId > 0)
            {
                textBoxRemarks.Text = _currentKit.Remarks;

                if (product != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    comboBoxStandart.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                    //linkLabelEditSupplier.Enabled = false;
                    //textBoxRemarks.ReadOnly = true;
                    _currentKit.Suppliers = new SupplierCollection(product.Suppliers);
                    _currentKit.SupplierRelations = new CommonCollection<KitSuppliersRelation>(product.SupplierRelations);

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
                if(product != null)
                {
                    textBoxRemarks.Text = product.Remarks;

                    _currentKit.Suppliers = new SupplierCollection(product.Suppliers);
                    _currentKit.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
                    foreach (KitSuppliersRelation ksr in product.SupplierRelations)
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

		private void LinkLabelEditComponents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new ProductBindForm(_currentKit);
			if (form.ShowDialog() == DialogResult.OK)
				UpdateByProduct(_currentKit.Product);

		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new ProductForm(_currentKit.Product);
			if (form.ShowDialog() == DialogResult.OK)
				UpdateByProduct(_currentKit.Product);
		}

		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			TextBoxProduct.Text = "";
			_currentKit.Product = null;
			UpdateByProduct(_currentKit.Product);
		}
	}
}
