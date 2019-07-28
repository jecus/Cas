using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Entities.General.Accessory;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.KitControls
{
    ///<summary>
    ///</summary>
    public partial class KitSupplierFormItem : UserControl
    {
        #region Fields
        private KitSuppliersRelation _currentKitSupplier;

        private ToolTip _comboBoxItemToolTip;
        #endregion

        #region Properties
       
        #region public KitSuppliersRelation KitSuppliersRelation
        ///<summary>
        /// Возвращает или назначает текущего поставщика КИТ-а
        ///</summary>
        public KitSuppliersRelation KitSuppliersRelation
        {
            get { return _currentKitSupplier; }
            set
            {
                _currentKitSupplier = value;
                UpdateInformation();
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли елемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return panelMain.Visible; }
            set
            {
                extendableRichContainer.Extended = value;
                panelMain.Visible = value;
            }
        }
        #endregion

        #endregion

        #region Constructors
       
        #region public KitSupplierFormItem()
        ///<summary>
        ///</summary>
        public KitSupplierFormItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public KitSupplierFormItem(KitSuppliersRelation KitSuppliersRelation)
        ///<summary>
        /// Конструктор, принимающий поставщика KITа для отображения
        ///</summary>
        public KitSupplierFormItem(KitSuppliersRelation kitSuppliersRelation)
        {
            _currentKitSupplier = kitSuppliersRelation;
            _comboBoxItemToolTip = new ToolTip();
            
            InitializeComponent();
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if(_currentKitSupplier == null) return;
           var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>();
            comboBoxKitSupplier.Items.Clear();
            comboBoxKitSupplier.Items.AddRange(suppliers.ToArray());
            comboBoxKitSupplier.SelectedItem = suppliers.FirstOrDefault(s => s.ItemId == _currentKitSupplier.SupplierId);

            numericCostNew.Value = (decimal)_currentKitSupplier.CostNew;
            numericCostOverhaul.Value = (decimal)_currentKitSupplier.CostOverhaul;
            numericCostServiceable.Value = (decimal)_currentKitSupplier.CostServiceable;
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

            if (comboBoxKitSupplier.SelectedItem as Supplier == null)
            {
                if (message != "") 
                    message += "\n ";
                message += "Not Set Supplier";
                
                comboBoxKitSupplier.Focus();
                
                return false;
            }

            return true;
        }

        #endregion

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            if (comboBoxKitSupplier.SelectedIndex == -1) 
                return false;
            if (_currentKitSupplier.SupplierId != ((Supplier)comboBoxKitSupplier.SelectedItem).ItemId ||
                numericCostNew.Value != (decimal)_currentKitSupplier.CostNew ||
                numericCostOverhaul.Value != (decimal)_currentKitSupplier.CostOverhaul ||
                numericCostServiceable.Value != (decimal)_currentKitSupplier.CostServiceable)
                return true;
            return false;
        }
        #endregion

        #region public void ApplyChanges()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void ApplyChanges()
        {
            _currentKitSupplier.Supplier = (comboBoxKitSupplier.SelectedItem) as Supplier;
            _currentKitSupplier.CostNew = (double)numericCostNew.Value;
            _currentKitSupplier.CostOverhaul = (double) numericCostOverhaul.Value;
            _currentKitSupplier.CostServiceable = (double) numericCostServiceable.Value;
        }
        #endregion

        #region public void SaveData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            _currentKitSupplier.Supplier = comboBoxKitSupplier.SelectedItem as Supplier;
            _currentKitSupplier.CostNew = (double)numericCostNew.Value;
            _currentKitSupplier.CostOverhaul = (double)numericCostOverhaul.Value;
            _currentKitSupplier.CostServiceable = (double)numericCostServiceable.Value;
            try
            {
                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentKitSupplier);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this supplier?", "Deleting confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) 
                == DialogResult.Yes)
            {
                if (Deleted != null)
                    Deleted(this, EventArgs.Empty);
            }
        }
        #endregion

        #region private void ComboBoxKitSupplierDrawItem(object sender, DrawItemEventArgs e)
        private void ComboBoxKitSupplierDrawItem(object sender, DrawItemEventArgs e)
        {
            Supplier supplier = ((Supplier)comboBoxKitSupplier.Items[e.Index]);

            e.DrawBackground();
            
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(supplier.Name, e.Font, br, e.Bounds);
            }

            var dictionaryCollection = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO,Product>(new Filter("ModelingObjectTypeId", -1));
            string supplierProducts = supplier.Products;
            if(dictionaryCollection != null)
            {
                var accessoryDescriptions = dictionaryCollection.Where(ad => ad.Suppliers.Contains(supplier)).ToArray();
                if(accessoryDescriptions.Any())
                {
                    supplierProducts = accessoryDescriptions.Aggregate("", (current, accessoryDescription) => current + (accessoryDescription.ToString() + "    "));
                }
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                _comboBoxItemToolTip.Show(supplierProducts, comboBoxKitSupplier, e.Bounds.Right, e.Bounds.Bottom);
            }
            else
            {
                _comboBoxItemToolTip.Hide(comboBoxKitSupplier);
            }
            
            e.DrawFocusRectangle();
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            panelMain.Visible = !panelMain.Visible;
        }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion
        
    }
}
