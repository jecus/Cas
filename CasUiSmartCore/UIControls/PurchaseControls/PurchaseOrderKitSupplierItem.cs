using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// ЭУ отображает одного поставщика КИТ-а в закупочном ордере
    ///</summary>
    public partial class PurchaseOrderKitSupplierItem : UserControl
    {
        #region Fields

        private Supplier _currentSupplier;
        private List<CostConditionItem> _items = new List<CostConditionItem>();
        
        #endregion

        #region Constructors
        
        #region public PurchaseOrderKitSupplierItem()
        ///<summary>
        ///</summary>
        public PurchaseOrderKitSupplierItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public PurchaseOrderKitSupplierItem(Supplier supplier, RequestForQuotationRecord record)
        ///<summary>
        ///</summary>
        public PurchaseOrderKitSupplierItem(Supplier supplier, RequestForQuotationRecord record)
        {
            _currentSupplier = supplier;

            InitializeComponent();

            UpdateInformation(record);
        }
        #endregion

        #region public PurchaseOrderKitSupplierItem(PurchaseRequestRecord request)
        ///<summary>
        ///</summary>
        public PurchaseOrderKitSupplierItem(PurchaseRequestRecord request)
        {
            //_currentSupplier = request.Supplier;

            InitializeComponent();

            UpdateInformation(request);
        }
        #endregion

        #endregion

        #region Properties

        #region public bool Checked
        ///<summary>
        /// нужно ли добавить данного поставщика кипа в закупочный акт 
        /// (пользоваться только в режиме создания закупочного акта)
        ///</summary>
        public bool Checked
        {
            get { return checkBoxSupplier.Checked; }
        }
        #endregion

        #region public List<PurchaseOrderKitSupplierItem> Items
        ///<summary>
        /// возвращает сформированные объекты ценовых состояний поставщика данного КИТа в закупочном ордере
        ///</summary>
        public List<CostConditionItem> Items
        {
            get { return _items; }
        }
        #endregion

        #region public Supplier CurrentSupplier
        ///<summary>
        /// Возвращает текущего поставщика
        ///</summary>
        public Supplier CurrentSupplier
        {
            get { return _currentSupplier; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation(RequestForQuotationRecord record)
        private void UpdateInformation(RequestForQuotationRecord record)
        {
            if (_currentSupplier == null || record == null) return;

            labelSupplierName.Text = _currentSupplier.Name;

            _items.Clear();
            flowLayoutPanelCostConditions.Controls.Clear();

            if ((record.CostCondition & ComponentStatus.New) != 0)
            {
                CostConditionItem newControl = new CostConditionItem { MainText = "N", CostCondition = ComponentStatus.New };
                _items.Add(newControl);
                flowLayoutPanelCostConditions.Controls.Add(newControl);
            }
            if ((record.CostCondition & ComponentStatus.Serviceable) != 0)
            {
                CostConditionItem newControl = new CostConditionItem { MainText = "S", CostCondition = ComponentStatus.Serviceable };
                _items.Add(newControl);
                flowLayoutPanelCostConditions.Controls.Add(newControl);
            }
            if ((record.CostCondition & ComponentStatus.Overhaul) != 0)
            {
                CostConditionItem newControl = new CostConditionItem { MainText = "OH", CostCondition = ComponentStatus.Overhaul };
                _items.Add(newControl);
                flowLayoutPanelCostConditions.Controls.Add(newControl);
            }
        }
        #endregion

        #region private void UpdateInformation(PurchaseRequestRecord request)
        private void UpdateInformation(PurchaseRequestRecord request)
        {
            if (_currentSupplier == null || request == null) return;

            labelSupplierName.Text = _currentSupplier.Name;
            checkBoxSupplier.Checked = true;
            checkBoxSupplier.Visible = false;

            _items.Clear();
            flowLayoutPanelCostConditions.Controls.Clear();
            CostConditionItem newControl = null;
            if (request.CostCondition == ComponentStatus.New)
            {
                newControl = new CostConditionItem(request) { MainText = "N", CostCondition = ComponentStatus.New, Cost = request.Cost, Quantity = request.Quantity };  
            }
            if (request.CostCondition == ComponentStatus.Serviceable)
            {
                newControl = new CostConditionItem(request) { MainText = "S", CostCondition = ComponentStatus.Serviceable, Cost = request.Cost, Quantity = request.Quantity };
            }
            if (request.CostCondition == ComponentStatus.Overhaul)
            {
                newControl = new CostConditionItem(request) { MainText = "OH", CostCondition = ComponentStatus.Overhaul, Cost = request.Cost, Quantity = request.Quantity };
            }
            if(newControl != null)
            {
                _items.Add(newControl);
                flowLayoutPanelCostConditions.Controls.Add(newControl);
            }
            
        }
        #endregion

        #region private void CheckBoxSupplierCheckedChanged(object sender, EventArgs e)
        private void CheckBoxSupplierCheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanelCostConditions.Enabled = checkBoxSupplier.Checked;
        }
        #endregion

        #endregion
    }
}
