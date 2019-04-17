using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// Форма для задания неснижаемого запаса некоторого комплектующего на складе
    ///</summary>
    public partial class StockComponentInfoForm : MetroForm
    {
        private StockComponentInfo _stockComponentInfo;
	    private readonly bool _disableControls;
	    private IEnumerable<StockComponentInfo> _existInfos;

        #region Constructors
        
        #region public StockDetailInfoForm()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StockComponentInfoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public StockDetailInfoForm(StockDetailInfo stockDetailInfo)

	    /// <summary>
	    /// Создает форму для редактирование переданного объекта
	    /// </summary>
	    /// <param name="stockComponentInfo">Объект неснижаемого запаса</param>
	    /// <param name="disableControls"></param>
	    public StockComponentInfoForm(StockComponentInfo stockComponentInfo, bool disableControls = false) : this ()
        {
            _stockComponentInfo = stockComponentInfo;
	        _disableControls = disableControls;
	        FillControls();

	        if (disableControls)
		        DisableControls();
        }

		#endregion

		#endregion

		#region Methods

		private void DisableControls()
		{
			dictionaryComboProduct.Enabled = false;
			textBoxStandart.Enabled = false;
			comboBoxDetailClass.Enabled = false;
			textBoxPartNumber.Enabled = false;
			textBoxDescription.Enabled = false;
			comboBoxMeasure.Enabled = false;
		}

		#region public void FillControls()
		/// <summary>
		/// Обновляет значения полей
		/// </summary>
		public void FillControls()
        {
            Program.MainDispatcher.ProcessControl(dictionaryComboProduct);
            //textBoxStandart.Type = typeof(GoodStandart);
            //Program.MainDispatcher.ProcessControl(textBoxStandart);

            _existInfos = null;
            _existInfos = 
                
	        GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<StockComponentInfoDTO, StockComponentInfo>(new Filter("StoreID", _stockComponentInfo.StoreId));

			dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;
            //textBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;
            comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
            comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;

            FormControlAttribute fca = (FormControlAttribute)
                typeof(StockComponentInfo)
                    .GetProperty("GoodsClass")
                    .GetCustomAttributes(typeof(FormControlAttribute), false)
                    .FirstOrDefault();
            if (fca != null)
                comboBoxDetailClass.RootNodesNames = fca.TreeDictRootNodes;
            comboBoxDetailClass.Type = typeof(GoodsClass);

            dictionaryComboProduct.Type = typeof(Product);
            comboBoxMeasure.Items.Clear();
            comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity}));

            comboBoxDetailClass.SelectedItem = _stockComponentInfo.GoodsClass;
            textBoxPartNumber.Text = _stockComponentInfo.PartNumber;
            textBoxDescription.Text = _stockComponentInfo.Description;
            dictionaryComboProduct.SelectedItem = _stockComponentInfo.AccessoryDescription;
            comboBoxMeasure.SelectedItem = _stockComponentInfo.Measure;
            numericUpDownQuantity.Value = (decimal)_stockComponentInfo.ShouldBeOnStock;

            Product accessoryDescription;
            GoodStandart accessoryStandart;

            if ((accessoryDescription = _stockComponentInfo.AccessoryDescription) != null)
            {
                comboBoxDetailClass.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                //textBoxStandart.Enabled = false;
                textBoxDescription.ReadOnly = true;

                comboBoxMeasure.SelectedItem = accessoryDescription.Measure;
                textBoxStandart.Text = accessoryDescription.Standart != null ? accessoryDescription.Standart.ToString() : "";
                textBoxPartNumber.Text = accessoryDescription.PartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
            }
            else if (_stockComponentInfo.Standart != null)
            {
                accessoryStandart = _stockComponentInfo.Standart;
                comboBoxDetailClass.SelectedItem = accessoryStandart.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                //comboBoxMeasure.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = accessoryStandart.Measure;
                textBoxStandart.Text = accessoryStandart.ToString();
                textBoxPartNumber.Text = accessoryStandart.PartNumber;
                textBoxDescription.Text = accessoryStandart.Description;
            }

            SetForDetailClass();
            SetForMeasure();

            comboBoxDetailClass.SelectedIndexChanged += ComboBoxDetailClassSelectedIndexChanged;
            comboBoxMeasure.SelectedIndexChanged += ComboBoxMeasureSelectedIndexChanged;
            //textBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
            dictionaryComboProduct.SelectedIndexChanged += DictionaryComboProductSelectedIndexChanged;
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus(StockComponentInfo obj)
        {
            //string kitStandartName = _stockDetailInfo.Standart != null ? _stockDetailInfo.Standart.FullName : "";
            if (textBoxPartNumber.Text != obj.PartNumber ||
                textBoxDescription.Text != obj.Description ||
                dictionaryComboProduct.SelectedItem != obj.AccessoryDescription ||
                numericUpDownQuantity.Value != (decimal)obj.ShouldBeOnStock ||
                (_stockComponentInfo.Standart != null ? _stockComponentInfo.Standart.ToString() != textBoxStandart.Text : textBoxStandart.Text != ""))
            {
                return true;
            }

            if ((!(comboBoxDetailClass.SelectedItem is GoodsClass) || comboBoxDetailClass.SelectedItem != obj.GoodsClass) ||
                (comboBoxMeasure.SelectedItem as Measure == null && obj.Measure != null) ||
                (comboBoxMeasure.SelectedItem as Measure != null && obj.Measure == null) ||
                (comboBoxMeasure.SelectedItem as Measure != null && obj.Measure != null &&
                comboBoxMeasure.SelectedItem != obj.Measure))
            {
                return true;
            }
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
            if (!(comboBoxDetailClass.SelectedItem is GoodsClass))
            {
                if (message != "") message += "\n ";
                message += "Not set Detail Class";
                return false;    
            }
            if (textBoxPartNumber.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Part Number";
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

            if(_existInfos != null && 
               _existInfos.FirstOrDefault(i => i.ItemId != _stockComponentInfo.ItemId &&
                                               i.GoodsClass == (GoodsClass)comboBoxDetailClass.SelectedItem &&
                                               i.PartNumber.Replace(" ", "").ToLower() == textBoxPartNumber.Text.Replace(" ", "").ToLower()) != null)
            {
                if (message != "") message += "\n ";
                message += "Stock detail info with this part number: " + textBoxPartNumber.Text +
                           "\nand goods class: " + comboBoxDetailClass.SelectedItem + 
                           "\nis already exist.";
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
        private void ApplyChanges(StockComponentInfo obj)
        {
            Product p = dictionaryComboProduct.SelectedItem as Product;
            obj.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
            obj.PartNumber = textBoxPartNumber.Text;
            obj.Description = textBoxDescription.Text;
            obj.AccessoryDescription = p;
            obj.Standart = p != null ? p.Standart : null;
            obj.Measure = comboBoxMeasure.SelectedItem as Measure;
            obj.ShouldBeOnStock = (double)numericUpDownQuantity.Value;
        }
        #endregion

        #region private void Save()
        private void Save()
        {
            //string standart = textBoxStandart.Text.Replace(" ", "").ToLower();
            //string partNumber = textBoxPartNumber.Text.Replace(" ", "").ToLower();

            //List<GoodStandart> goodStandarts = null;
            //GoodStandart goodStandart;
            //try
            //{
            //    goodStandarts = GlobalObjects.CasEnvironment.Loader.GetObjectList<GoodStandart>();
            //}
            //catch (Exception ex)
            //{
            //    Program.Provider.Logger.Log("Not Find dictionary of type " + typeof(GoodStandart).Name, ex);
            //}

            //if (_stockDetailInfo.Standart == null && goodStandarts != null && standart != "")
            //{
            //    goodStandart = goodStandarts
            //        .FirstOrDefault(ad => ad.PartNumber.Replace(" ", "").ToLower() == partNumber
            //                           && ad.FullName.Replace(" ", "").ToLower() == standart);
            //    if (goodStandart == null)
            //    {
            //        goodStandart = new GoodStandart();
            //        goodStandart.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
            //        goodStandart.PartNumber = textBoxPartNumber.Text;
            //        goodStandart.Description = textBoxDescription.Text;
            //        goodStandart.FullName = textBoxStandart.Text;
            //        //goodStandart.Measure = comboBoxMeasure.SelectedItem as Measure;

            //        GlobalObjects.CasEnvironment.Manipulator.Save(goodStandart);
            //    }
            //    _stockDetailInfo.Standart = goodStandart;
            //}

            try
            {
                GlobalObjects.CasEnvironment.Manipulator.Save(_stockComponentInfo);
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
            GoodsClass dc = comboBoxDetailClass.SelectedItem as GoodsClass;
            if (dc == null)
            {
                comboBoxMeasure.Enabled = true;
                comboBoxMeasure.SelectedItem = _stockComponentInfo.Measure;
                numericUpDownQuantity.DecimalPlaces = 2;
            }
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
                numericUpDownQuantity.DecimalPlaces = 0;
            }
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
                numericUpDownQuantity.DecimalPlaces = 0;
            }
        }
        #endregion

        #region private void SetForMeasure()
        /// <summary>
        /// Изменяет контрол в соотствествии с выбранной единицей измерения
        /// </summary>
        private void SetForMeasure()
        {
            Measure measure = comboBoxMeasure.SelectedItem as Measure;
            if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
                numericUpDownQuantity.DecimalPlaces = 0;
            else numericUpDownQuantity.DecimalPlaces = 2;
        }
        #endregion

        #region private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForDetailClass();
			if (_disableControls)
				DisableControls();
		}
        #endregion

        #region private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForMeasure();
			if (_disableControls)
				DisableControls();
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
            if (GetChangeStatus(_stockComponentInfo))
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
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
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    ApplyChanges(_stockComponentInfo);
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
            if (_stockComponentInfo != null)
            {
                if (GetChangeStatus(_stockComponentInfo))
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes?",
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
                        ApplyChanges(_stockComponentInfo);
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

        #region private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        {
            //textBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            Product product;
            if ((product = dictionaryComboProduct.SelectedItem as Product) != null)
            {
                comboBoxDetailClass.SelectedItem = product.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                //textBoxStandart.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //textBoxRemarks.ReadOnly = true;

                comboBoxMeasure.SelectedItem = product.Measure;
                textBoxStandart.Text = product.Standart != null ? product.Standart.ToString() : "";
                textBoxPartNumber.Text = product.PartNumber;
                textBoxDescription.Text = product.Description;
            }

            if (_stockComponentInfo.ItemId > 0)
            {
                if (product != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    //textBoxStandart.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    comboBoxMeasure.Enabled = true;
                    //textBoxStandart.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                }
            }
            else
            {
                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                //textBoxStandart.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
            }

			if (_disableControls)
				DisableControls();
		}
        #endregion

        #region private void ComboBoxStandartSelectedIndexChanged(object sender, EventArgs e)
        //private void ComboBoxStandartSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GoodStandart goodStandart;
        //    if ((goodStandart = textBoxStandart.SelectedItem as GoodStandart) != null)
        //    {
        //        comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

        //        comboBoxDetailClass.Enabled = false;
        //        //comboBoxMeasure.Enabled = false;
        //        textBoxPartNumber.ReadOnly = true;
        //        textBoxDescription.ReadOnly = true;
        //        //textBoxRemarks.ReadOnly = true;

        //        //comboBoxMeasure.SelectedItem = goodStandart.Measure;
        //        textBoxPartNumber.Text = goodStandart.PartNumber;
        //        textBoxDescription.Text = goodStandart.Description;
        //        //textBoxRemarks.Text = accessoryDescription.Remarks;
        //    }

        //    if (_stockDetailInfo.ItemId > 0)
        //    {
        //        if (goodStandart != null)
        //        {
        //            comboBoxDetailClass.Enabled = false;
        //            //comboBoxMeasure.Enabled = false;
        //            textBoxPartNumber.ReadOnly = true;
        //            textBoxDescription.ReadOnly = true;
        //        }
        //        else
        //        {
        //            comboBoxDetailClass.Enabled = true;
        //            //comboBoxMeasure.Enabled = true;
        //            textBoxPartNumber.ReadOnly = false;
        //            textBoxDescription.ReadOnly = false;
        //        }
        //    }
        //    else
        //    {
        //        comboBoxDetailClass.Enabled = true;
        //        //comboBoxMeasure.Enabled = true;
        //        textBoxPartNumber.ReadOnly = false;
        //        textBoxDescription.ReadOnly = false;
        //    }
        //}
        #endregion

        #endregion
    }
}
