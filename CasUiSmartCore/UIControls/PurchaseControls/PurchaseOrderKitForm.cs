using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// Форма для редактирования кита/ов в закупочном ордере
    ///</summary>
    public partial class PurchaseOrderKitForm : Form
    {
        #region Fields
        
        private List<PurchaseOrderKitFormItem> _items = new List<PurchaseOrderKitFormItem>();

        private PurchaseOrder _currentPurchase;
        private BaseEntityObject _parentObject;
        private RequestForQuotation _parentRequest;
        private PurchaseRequestRecord _currentRequest;

        #endregion

        #region Properties

        ///<summary>
        /// возвращает родительский закупочный ордер, для которого вызвана форма
        ///</summary>
        public PurchaseOrder CurrentOrder
        {
            get { return _currentPurchase; }
        }

        #endregion

        #region Constructors
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public PurchaseOrderKitForm()
        {
            InitializeComponent();
        }

        ///<summary>
        /// конструктор для создания закупочного ордера и ордера запроса
        ///</summary>
        public PurchaseOrderKitForm(RequestForQuotation rfq)
        {
            if (rfq == null)
            {
                throw new ArgumentNullException("rfq");
            }
            _currentPurchase = new PurchaseOrder();
            _parentObject = rfq.Parent;
            _parentRequest = rfq;

            InitializeComponent();
            
            UpdateInformation(rfq);
        }

        ///<summary>
        /// конструктор для редактирования одной записи Ордера запроса
        ///</summary>
        public PurchaseOrderKitForm(PurchaseRequestRecord request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            _currentRequest = request;

            InitializeComponent();

            UpdateInformation(request);
        }

        #endregion

        #region Methods

        #region private void UpdateInformation(RequestForQuotation rfq)
        private void UpdateInformation(RequestForQuotation rfq)
        {
            if(rfq == null)return;

            flowLayoutPanelKits.Controls.Clear();
            _items.Clear();

            rfq.Products.Sort();
            
            foreach (Product accessory in rfq.Products)
            {
                RequestForQuotationRecord rec =
                    rfq.PackageRecords.FirstOrDefault(r => r.PackageItemId == accessory.ItemId);
                PurchaseOrderKitFormItem newControl = new PurchaseOrderKitFormItem(accessory,rec);
                _items.Add(newControl);
                flowLayoutPanelKits.Controls.Add(newControl);
            }

        }
        #endregion

        #region private void UpdateInformation(PurchaseRequestRecord request)
        private void UpdateInformation(PurchaseRequestRecord request)
        {
            if (request == null) return;

            flowLayoutPanelKits.Controls.Clear();
            _items.Clear();

            PurchaseOrderKitFormItem newControl = new PurchaseOrderKitFormItem(request);
            _items.Add(newControl);
            
            flowLayoutPanelKits.Controls.Add(newControl);

        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            #region проверка записей на соответствие
            bool mustOneKitChecked = false;//флаг, что выбран хотя бы один КИТ для закупочного ордера
            foreach (PurchaseOrderKitFormItem purchaseOrderKitFormItem in _items)
            {
                if (purchaseOrderKitFormItem.Checked) 
                {
                    mustOneKitChecked = true;
                    bool mustOneSupplierChecked = false; //флаг, что выбран хотя бы один поставщик КИТа
                    foreach (PurchaseOrderKitSupplierItem kitSupplierItem in purchaseOrderKitFormItem.Items)
                    {
                        if(kitSupplierItem.Checked)
                        {
                            mustOneSupplierChecked = true;
                            bool mustOneCostChecked = false;
                            foreach (CostConditionItem conditionItem in kitSupplierItem.Items)
                            {
                                if(conditionItem.Checked && conditionItem.Quantity > 0 && conditionItem.Cost > 0)
                                    mustOneCostChecked = true;
                                else
                                {
                                    if (conditionItem.Checked)
                                    {
                                        // не был выбран ни один Поставщик для данного КИТа
                                        MessageBox.Show("For KIT " + purchaseOrderKitFormItem.CurrentProduct.PartNumber +
                                                        "\nsupplied by " + kitSupplierItem.CurrentSupplier +
                                                        "\ncost condition " + conditionItem.CostCondition +  " does not indicate the quantity",
                                                        "error",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            if (!mustOneCostChecked)
                            {
                                // не был выбран ни один Поставщик для данного КИТа
                                MessageBox.Show("For KIT " + purchaseOrderKitFormItem.CurrentProduct.PartNumber + 
                                                "\nsupplied by " + kitSupplierItem.CurrentSupplier +
                                                "\nnot chosen a cost condition or does not indicate the quantity", "error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (!mustOneSupplierChecked)
                    {
                        // не был выбран ни один Поставщик для данного КИТа
                        MessageBox.Show("For KIT " + purchaseOrderKitFormItem.CurrentProduct.PartNumber
                                                   + " not select any supplier", "error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if(!mustOneKitChecked)
            {
                //не был выбран ни один КИТ для формирования закупочного ордера
                MessageBox.Show("Was not selected for any KIT the formation of purchase order ","error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            
            if(_currentPurchase != null && _currentPurchase.ItemId <= 0)
            {   
                //если закупончный ордер не был сохранен (создается из запроса на цены)
                //то необходимо сначала сохранить его для дальнейшего формирования записей
                _currentPurchase.Title =  _parentObject + "-PO-" + DateTime.Now;
                _currentPurchase.ParentId = _parentObject.ItemId;
                _currentPurchase.ParentType = _parentObject.SmartCoreObjectType;
                _currentPurchase.ParentQuotationId = _parentRequest != null ? _parentRequest.ItemId : -1;
                _currentPurchase.OpeningDate =
                    _currentPurchase.PublishingDate = 
                    _currentPurchase.ClosingDate = DateTime.Now;
	            if (_parentObject is Aircraft)
	            {
		            var aircraft = (Aircraft)_parentObject;
					_currentPurchase.Author = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId).Name;
				}
                else if (_parentObject is Store)
                    _currentPurchase.Author = ((Store)_parentObject).Operator.Name;
                else if (_parentObject is Operator)
                    _currentPurchase.Author = ((Operator)_parentObject).Name;
                else _currentPurchase.Author = GlobalObjects.CasEnvironment.Operators[0].Name;

                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentPurchase);


                double newMaxNewCost;
                double newMaxServiceableCost;
                double newMaxOverhaulCost;
                //так же необходимо записать максимальную цену из тех, что вводятся для 
                //ценовых состояний КИТа в сам КИТ
                #region Формирование и сохранение записей
                foreach (PurchaseOrderKitFormItem purchaseOrderKitFormItem in _items)
                {
                    if (purchaseOrderKitFormItem.Checked)
                    {
                        newMaxNewCost = 0;
                        newMaxServiceableCost = 0;
                        newMaxOverhaulCost = 0;

                        foreach (PurchaseOrderKitSupplierItem kitSupplierItem in purchaseOrderKitFormItem.Items)
                        {
                            if (kitSupplierItem.Checked)
                            {
                                foreach (CostConditionItem conditionItem in kitSupplierItem.Items)
                                {
                                    if (conditionItem.Checked && conditionItem.Quantity > 0)
                                    {
                                        if (conditionItem.CostCondition == ComponentStatus.New &&
                                            conditionItem.Cost > newMaxNewCost)
                                            newMaxNewCost = conditionItem.Cost;
                                        if (conditionItem.CostCondition == ComponentStatus.Serviceable &&
                                            conditionItem.Cost > newMaxServiceableCost)
                                            newMaxServiceableCost = conditionItem.Cost;
                                        if (conditionItem.CostCondition == ComponentStatus.Overhaul &&
                                            conditionItem.Cost > newMaxOverhaulCost)
                                            newMaxOverhaulCost = conditionItem.Cost;
                                        
                                        
                                        PurchaseRequestRecord newPurchaseOrderRecord =
                                            new PurchaseRequestRecord
                                                {
                                                    PackageItem = purchaseOrderKitFormItem.CurrentProduct,
                                                    PackageItemId = purchaseOrderKitFormItem.CurrentProduct.ItemId,
                                                    PackageItemType = purchaseOrderKitFormItem.CurrentProduct.SmartCoreObjectType,
                                                    ParentPackageId = _currentPurchase.ItemId,
                                                    ParentPackage = _currentPurchase,
                                                    Supplier = _currentPurchase.Supplier,
                                                    CostCondition = conditionItem.CostCondition,
                                                    Quantity = conditionItem.Quantity,
                                                    Cost = conditionItem.Cost,
                                                };

                                        GlobalObjects.CasEnvironment.NewKeeper.Save(newPurchaseOrderRecord);
                                    }
                                }
                            }
                        }

                        purchaseOrderKitFormItem.CurrentProduct.CostNew = newMaxNewCost;
                        purchaseOrderKitFormItem.CurrentProduct.CostServiceable = newMaxServiceableCost;
                        purchaseOrderKitFormItem.CurrentProduct.CostOverhaul = newMaxOverhaulCost;
                        //сохранение КИТа с последними проставленными ценами
                        GlobalObjects.CasEnvironment.NewKeeper.Save(purchaseOrderKitFormItem.CurrentProduct);
                    }
                }
                #endregion
            }

            if (_currentRequest != null)
            {
                double newMaxNewCost;
                double newMaxServiceableCost;
                double newMaxOverhaulCost;
                //так же необходимо записать максимальную цену из тех, что вводятся для 
                //ценовых состояний КИТа в сам КИТ
                #region Изменение текущей записи
                foreach (PurchaseOrderKitFormItem purchaseOrderKitFormItem in _items)
                {
                    if (purchaseOrderKitFormItem.Checked)
                    {
                        newMaxNewCost = 0;
                        newMaxServiceableCost = 0;
                        newMaxOverhaulCost = 0;

                        foreach (PurchaseOrderKitSupplierItem kitSupplierItem in purchaseOrderKitFormItem.Items)
                        {
                            if (kitSupplierItem.Checked)
                            {
                                foreach (CostConditionItem conditionItem in kitSupplierItem.Items)
                                {
                                    if (conditionItem.Checked && conditionItem.Quantity > 0)
                                    {
                                        if (conditionItem.CostCondition == ComponentStatus.New &&
                                            conditionItem.Cost > newMaxNewCost)
                                            newMaxNewCost = conditionItem.Cost;
                                        if (conditionItem.CostCondition == ComponentStatus.Serviceable &&
                                            conditionItem.Cost > newMaxServiceableCost)
                                            newMaxServiceableCost = conditionItem.Cost;
                                        if (conditionItem.CostCondition == ComponentStatus.Overhaul &&
                                            conditionItem.Cost > newMaxOverhaulCost)
                                            newMaxOverhaulCost = conditionItem.Cost;

                                        _currentRequest.Cost = conditionItem.Cost;
                                        _currentRequest.Quantity = conditionItem.Quantity;

                                        GlobalObjects.CasEnvironment.NewKeeper.Save(_currentRequest);
                                    }
                                }
                            }
                        }

                        purchaseOrderKitFormItem.CurrentProduct.CostNew = newMaxNewCost;
                        purchaseOrderKitFormItem.CurrentProduct.CostServiceable = newMaxServiceableCost;
                        purchaseOrderKitFormItem.CurrentProduct.CostOverhaul = newMaxOverhaulCost;
                        //сохранение КИТа с последними проставленными ценами
                        GlobalObjects.CasEnvironment.NewKeeper.Save(purchaseOrderKitFormItem.CurrentProduct);
                    }
                }
                #endregion
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

        #endregion

    }
}
