using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// ЭУ для отображения одного кита в форме КИТов закупочного ордера
    ///</summary>
    public partial class PurchaseOrderKitFormItem : UserControl
    {
        #region Fields

        private Product _currentAccessory;
        private List<PurchaseOrderKitSupplierItem> _items = new List<PurchaseOrderKitSupplierItem>();

        #endregion

        #region Properties

        #region public bool Checked
        ///<summary>
        /// нужно ли добавить данный КИТ в закупочный акт 
        /// (пользоваться только в режиме создания закупочного акта)
        ///</summary>
        public bool Checked
        {
            get { return checkBoxKit.Checked; }
        }
        #endregion

        #region public IEnumerable<PurchaseOrderKitSupplierItem> Items
        ///<summary>
        /// возвращает сформированные объекты поставщиков данного КИТа в закупочном ордере
        ///</summary>
        public IEnumerable<PurchaseOrderKitSupplierItem> Items
        {
            get { return _items; }
        }
        #endregion

        #region public Product CurrentProduct
        ///<summary>
        /// возвращает текущее комплектующее
        ///</summary>
        public Product CurrentProduct
        {
            get { return _currentAccessory; }
        }
        #endregion

        #endregion

        #region Constructors

        #region public PurchaseOrderKitFormItem()
        ///<summary>
        ///</summary>
        public PurchaseOrderKitFormItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public PurchaseOrderKitFormItem(Product accessory, RequestForQuotationRecord record)
        ///<summary>
        ///</summary>
        public PurchaseOrderKitFormItem(Product accessory, RequestForQuotationRecord record)
        {
            _currentAccessory = accessory;
            
            InitializeComponent();

            UpdateInformation(record);
        }
        #endregion

        #region public PurchaseOrderKitFormItem(PurchaseRequestRecord request)
        ///<summary>
        ///</summary>
        public PurchaseOrderKitFormItem(PurchaseRequestRecord request)
        {
            if (request == null)
            {
                new ArgumentNullException("request");
                return;
            }
            _currentAccessory = request.Product;

            InitializeComponent();

            UpdateInformation(request);
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation(RequestForQuotationRecord record)
        private void UpdateInformation(RequestForQuotationRecord record)
        {
            if (_currentAccessory == null || record == null) return;

            labelKitName.Text = _currentAccessory.PartNumber + " " + _currentAccessory.Description;

            flowLayoutPanelSuppliers.Controls.Clear();
            _items.Clear();
            foreach (Supplier supplier in _currentAccessory.Suppliers)
            {
                PurchaseOrderKitSupplierItem newControl = new PurchaseOrderKitSupplierItem(supplier, record);
                _items.Add(newControl);
                flowLayoutPanelSuppliers.Controls.Add(newControl);
            }
        }
        #endregion

        #region private void UpdateInformation(PurchaseRequestRecord request)
        private void UpdateInformation(PurchaseRequestRecord request)
        {
            if (_currentAccessory == null || request == null) return;

            labelKitName.Text = _currentAccessory.PartNumber + " " + _currentAccessory.Description;
            checkBoxKit.Checked = true;
            checkBoxKit.Visible = false;

            flowLayoutPanelSuppliers.Controls.Clear();
            _items.Clear();

            PurchaseOrderKitSupplierItem newControl = new PurchaseOrderKitSupplierItem(request);
            _items.Add(newControl);
            flowLayoutPanelSuppliers.Controls.Add(newControl);
        }
        #endregion

        #region private void CheckBoxKitCheckedChanged(object sender, EventArgs e)
        private void CheckBoxKitCheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanelSuppliers.Enabled = checkBoxKit.Checked;
        }
        #endregion

        #endregion
    }
}
