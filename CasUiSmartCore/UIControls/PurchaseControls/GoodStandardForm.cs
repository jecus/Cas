using System;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// Форма для редактирования данных о стандарте продукта
    ///</summary>
    public partial class GoodStandardForm : CommonEditorForm
    {
        #region Fields

        private GoodStandart _currentKit;
        #endregion

        #region Constructors

        #region public GoodStandardForm()

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public GoodStandardForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public GoodStandardForm(GoodStandart currentKit) : this()

        /// <summary>
        /// Создает форму для редактирования переданного элемента
        /// </summary>
        /// <param name="currentKit"></param>
        public GoodStandardForm(GoodStandart currentKit)
            : this()
        {
            _currentKit = currentKit;
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Properties

        ///<summary>
        /// Возвращает редактируемый объект
        ///</summary>
        public override BaseEntityObject CurrentObject
        {
            get { return _currentKit; }
        }
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            comboBoxDefaultProduct.Items.Clear();

            if (_currentKit.ItemId <= 0)
            {
                buttonDelete.Visible = false;
                ButtonAdd.Visible = false;
                labelProducts.Visible = false;
                dataGridViewProducts.Visible = false;
            }
            else
            {
                var products = GlobalObjects.PurchaseCore.GetProducts(_currentKit.ItemId, true);

                foreach (var product in products)
                {
                    comboBoxDefaultProduct.Items.Add(product);
                    if (product.ItemId == _currentKit.DefaultProductId)
                        comboBoxDefaultProduct.SelectedItem = product;
                }

                dataGridViewProducts.ViewedType = typeof(Product);
                dataGridViewProducts.SetItemsArray(products.ToArray());
            }
            //comboBoxDetailClass.Items.Clear();
            //comboBoxDetailClass.Items.AddRange(new object[] { DetailClass.Component, DetailClass.ConsumablePart, DetailType.CTE, DetailClass.FLM, DetailClass.Kit, DetailClass.Tool, });

            FormControlAttribute fca = (FormControlAttribute)
                _currentKit.GetType()
                    .GetProperty("GoodsClass")
                    .GetCustomAttributes(typeof (FormControlAttribute), false)
                    .FirstOrDefault();
            if (fca != null)
                comboBoxDetailClass.RootNodesNames = fca.TreeDictRootNodes;
            comboBoxDetailClass.Type = typeof(GoodsClass);
            //comboBoxMeasure.Items.Clear();
            //comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

            if (_currentKit == null) return;

            //numericCostNew.Enabled = true;
            //numericCostServiceable.Enabled = true;
            //numericCostOverhaul.Enabled = true;

            //if (_currentKit.DetailType == DetailType.CTE)
            //    comboBoxDetailClass.SelectedItem = _currentKit.DetailType;
            //else comboBoxDetailClass.SelectedItem = _currentKit.GoodsClass;
            comboBoxDetailClass.SelectedItem = _currentKit.GoodsClass;
            //comboBoxMeasure.SelectedItem = _currentKit.Measure;
            textBoxName.Text = _currentKit.FullName;
            textBoxPartNumber.Text = _currentKit.PartNumber;
            textBoxDescription.Text = _currentKit.Description;
            //numericCostNew.Value = (decimal)_currentKit.CostNew;
            //numericCostServiceable.Value = (decimal)_currentKit.CostServiceable;
            //numericCostOverhaul.Value = (decimal)_currentKit.CostOverhaul;
            textBoxRemarks.Text = _currentKit.Remarks;
        }
        #endregion

        #region protected override void SetFormControls()
        protected override void SetFormControls()
        {

        }
        #endregion

        #region protected override bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        protected override bool GetChangeStatus()
        {
            int selectedDefProdId = comboBoxDefaultProduct.SelectedItem != null
                ? ((Product) comboBoxDefaultProduct.SelectedItem).ItemId
                : -1;
            if (textBoxName.Text != _currentKit.FullName
                //|| comboBoxMeasure.SelectedItem != _currentKit.Measure
                || selectedDefProdId != _currentKit.DefaultProductId
                || textBoxPartNumber.Text != _currentKit.PartNumber
                || textBoxDescription.Text != _currentKit.Description
                || textBoxRemarks.Text != _currentKit.Remarks
                //|| numericCostNew.Value != (decimal)_currentKit.CostNew
                //|| numericCostServiceable.Value != (decimal)_currentKit.CostServiceable
                //|| numericCostOverhaul.Value != (decimal)_currentKit.CostOverhaul
                || (comboBoxDetailClass.SelectedItem is GoodsClass && _currentKit.GoodsClass != comboBoxDetailClass.SelectedItem))
                return true;

            return false;
        }
        #endregion

        #region protected override public ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        protected override bool ValidateData(out string message)
        {
            message = "";

            //if (comboBoxMeasure.SelectedItem == null)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Not set measure";
            //    return false;
            //}
            if (textBoxName.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Name";
                return false;
            }
            //if (textBoxPartNumber.Text == "")
            //{
            //    if (message != "") message += "\n ";
            //    message += "Not set Standart or Part Number";
            //    return false;
            //}
            if (textBoxDescription.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Description";
                return false;
            }
            //if (comboBoxMeasure.SelectedItem as Measure == null)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Not set Measure";
            //    return false;
            //}

            return true;
        }

        #endregion

        #region protected override bool ApplyChanges()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        protected override void ApplyChanges()
        {
            //DetailClass detailClass = DetailClass.Component;
            //DetailType detailType = DetailType.Unknown;
            //if (comboBoxDetailClass.SelectedItem is DetailClass)
            //{
            //    detailClass = (DetailClass)comboBoxDetailClass.SelectedItem;
            //    detailType = DetailType.Unknown;
            //}
            //else if (comboBoxDetailClass.SelectedItem is DetailType)
            //{
            //    detailType = (DetailType)comboBoxDetailClass.SelectedItem;
            //    detailClass = DetailClass.Component;
            //}

            int selectedDefProdId = comboBoxDefaultProduct.SelectedItem != null
                ? ((Product)comboBoxDefaultProduct.SelectedItem).ItemId
                : -1;

            _currentKit.FullName = textBoxName.Text;
            //_currentKit.GoodsClass = detailClass;
            //_currentKit.DetailType = detailType;
            _currentKit.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass ?? GoodsClass.Unknown;
            _currentKit.DefaultProductId = selectedDefProdId;
            _currentKit.PartNumber = string.IsNullOrEmpty(textBoxPartNumber.Text) ? "N/A" : textBoxPartNumber.Text;
            _currentKit.Description = textBoxDescription.Text;
            //_currentKit.Measure = comboBoxMeasure.SelectedItem as Measure;
            //_currentKit.CostNew = (double)numericCostNew.Value;
            //_currentKit.CostServiceable = (double)numericCostServiceable.Value;
            //_currentKit.CostOverhaul = (double)numericCostOverhaul.Value;
            _currentKit.Remarks = textBoxRemarks.Text;
        }
        #endregion

        #region protected override void AbortChanges()
        protected override void AbortChanges()
        {
            try
            {
                //if (_currentKit.ItemId <= 0)
                //{
                //    foreach (KitSuppliersRelation relation in _currentKit.SupplierRelations)
                //    {
                //        GlobalObjects.CasEnvironment.Manipulator.Delete(relation, false);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save consumable part", ex);
            }
        }
        #endregion

        #region protected override void Save()
        protected override void Save()
        {
            try
            {
                GlobalObjects.CasEnvironment.Manipulator.Save(_currentKit);

                //foreach (KitSuppliersRelation relation in _currentKit.SupplierRelations)
                //{
                //    if (relation.SupplierId != 0)
                //    {
                //        relation.KitId = _currentKit.ItemId;
                //        GlobalObjects.CasEnvironment.Keeper.Save(relation);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                ProductForm form =
                    new ProductForm(new Product {Standart = _currentKit}, false);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Product product = form.CurrentObject as Product;
                    if(product == null)
                        return;
                    dataGridViewProducts.AddItem(product);

                    comboBoxDefaultProduct.Items.Add(product);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building new object", ex);
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedItems == null ||
                dataGridViewProducts.SelectedItems.Count == 0) return;

            DialogResult confirmResult =
                MessageBox.Show(dataGridViewProducts.SelectedItems.Count == 1
                        ? "Do you really want to delete KIT " + dataGridViewProducts.SelectedItems[0] + "?"
                        : "Do you really want to delete selected KITs? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                dataGridViewProducts.ItemListView.BeginUpdate();
                foreach (BaseEntityObject directive in dataGridViewProducts.SelectedItems)
                {
                    Product product = directive as Product;
                    if (product == null)
                        continue;
                    try
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Save(product);
                        _currentKit.Products.RemoveById(product.ItemId);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
                dataGridViewProducts.ItemListView.EndUpdate();

                dataGridViewProducts.SetItemsArray(_currentKit.Products.ToArray());

                comboBoxDefaultProduct.Items.Clear();
                foreach (Product product in _currentKit.Products)
                {
                    comboBoxDefaultProduct.Items.Add(product);
                    if (product.ItemId == _currentKit.DefaultProductId)
                        comboBoxDefaultProduct.SelectedItem = product;
                }
            }
        }
        #endregion

        #endregion

    }
}
