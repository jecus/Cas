using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using System.Linq;
using CAS.UI.UIControls.PurchaseControls.Initial;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class InitionalOrderScreen : ScreenControl
    {
        #region Fields

        private readonly InitialOrder _currentItem;
        private InitionalOrderView _directivesViewer;

        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
        private CommonCollection<PurchaseOrder> _openPubPurchases = new CommonCollection<PurchaseOrder>();

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemCostConditions;
        private ToolStripMenuItem _toolStripMenuItemCostConditionNew;
        private ToolStripMenuItem _toolStripMenuItemCostConditionServiceable;
        private ToolStripMenuItem _toolStripMenuItemCostConditionOverhaul;
        private ToolStripMenuItem _toolStripMenuItemAddKits;
        //private ToolStripMenuItem _toolStripMenuItemOpenKitParentItem;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripMenuItem _toolStripMenuItemComposeQuotationOrder;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
        private ToolStripMenuItem _toolStripMenuItemComposePurchaseOrder;
        private ToolStripMenuItem _toolStripMenuItemPurchases;

        #endregion
        
        #region Constructors

        #region private InitionalOrderScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private InitionalOrderScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public InitionalOrderScreen(InitialOrder request) : this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="request">ВС, которому принадлежат директивы</param>
        public InitionalOrderScreen(InitialOrder request)
            : this()
        {
            if (request == null)
                throw new ArgumentNullException("request");
            _currentItem = request;
            
            if(_currentItem.ParentType == SmartCoreType.Aircraft)
                CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentItem.ParentId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			else if (_currentItem.ParentType == SmartCoreType.Store)
                CurrentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(_currentItem.ParentId);
            else if (CurrentAircraft == null && CurrentStore == null)
                aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];

            StatusTitle = "Initional Order Kits";
            InitToolStripMenuItems();
            InitListView();
        }

        #endregion

        #endregion

        #region Methods

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            _openPubQuotations.Clear();
            _openPubQuotations = null;

            _openPubPurchases.Clear();
            _openPubPurchases = null;

            //if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            //if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
            //if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            //if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
            //if (_toolStripMenuItemDeleteRecord != null) _toolStripMenuItemDeleteRecord.Dispose();
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
            if (_toolStripMenuItemComposeQuotationOrder != null) _toolStripMenuItemComposeQuotationOrder.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.DropDownItems.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }

            if (_toolStripMenuItemComposePurchaseOrder != null) _toolStripMenuItemComposePurchaseOrder.Dispose();
            if (_toolStripMenuItemPurchases != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemPurchases.DropDownItems)
                {
                    item.Click -= AddToPurchaseOrderItemClick;
                }
                _toolStripMenuItemPurchases.DropDownItems.Clear();
                _toolStripMenuItemPurchases.Dispose();
            }

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            labelStatus.Text = "IO Status: " + _currentItem.Status;

            switch (_currentItem.Status)
            {
                case WorkPackageStatus.Published:
                    {
                        buttonPublish.Enabled = false;
                        buttonClose.Enabled = true;
                        //if (_currentItem.CanClose == false)
                        //{
                        //    buttonClose.ShowToolTip = true;
                        //    buttonClose.ToolTipText = "This work package can not be closed";
                        //}
                        //else
                        //{
                        //    buttonClose.ShowToolTip = false;
                        //    buttonClose.ToolTipText = "";
                        //}
                        break;
                    }
                case WorkPackageStatus.Closed:
                    {
                        buttonPublish.Enabled = true;
                        //if (_currentItem.CanPublish == false)
                        //{
                        //    buttonPublish.ShowToolTip = true;
                        //    buttonPublish.ToolTipText = "This work package can not be republished";
                        //}
                        //else
                        //{
                        //    buttonPublish.ShowToolTip = false;
                        //    buttonPublish.ToolTipText = "";
                        //}
                        break;
                    }
                default:
                    {
                        buttonPublish.Enabled = true;
                        buttonClose.Enabled = true;
                        //if (_currentWorkPackage.CanClose == false)
                        //{
                        //    buttonClose.ShowToolTip = true;
                        //    buttonClose.ToolTipText = "This work package can not be closed";
                        //}
                        //else
                        //{
                        //    buttonClose.ShowToolTip = false;
                        //    buttonClose.ToolTipText = "";
                        //}
                        break;
                    }
            }

            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }

                _toolStripMenuItemQuotations.DropDownItems.Clear();

                foreach (RequestForQuotation quotation in _openPubQuotations)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(quotation.Title);
                    item.Click += AddToQuotationOrderItemClick;
                    item.Tag = quotation;
                    _toolStripMenuItemQuotations.DropDownItems.Add(item);
                }
            }
            if (_toolStripMenuItemPurchases != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemPurchases.DropDownItems)
                {
                    item.Click -= AddToPurchaseOrderItemClick;
                }

                _toolStripMenuItemPurchases.DropDownItems.Clear();

                foreach (RequestForQuotation quotation in _openPubQuotations)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(quotation.Title);
                    item.Click += AddToPurchaseOrderItemClick;
                    item.Tag = quotation;
                    _toolStripMenuItemPurchases.DropDownItems.Add(item);
                }
            }

            _directivesViewer.SetItemsArray(_currentItem.PackageRecords.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            AnimatedThreadWorker.ReportProgress(0, "Loading Order");

            GlobalObjects.PurchaseCore.GetInitialOrderItemsWithCalculate(_currentItem);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            #region Загрузка Котировочных ордеров

            AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

            _openPubQuotations.Clear();
            _openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(CurrentParent, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Загрузка Закупочных ордеров

            AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            if (_openPubPurchases == null) _openPubPurchases = new CommonCollection<PurchaseOrder>();

            _openPubPurchases.Clear();
            _openPubPurchases.AddRange(GlobalObjects.PurchaseCore.GetPurchaseOrders(CurrentParent, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "calculation over");
        }
        #endregion

        #region public override void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public override void OnInitCompletion(object sender)
        {
            AnimatedThreadWorker.RunWorkerAsync();

            base.OnInitCompletion(sender);
        }
        #endregion

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemAddKits = new ToolStripMenuItem();
            //_toolStripMenuItemOpenKitParentItem = new ToolStripMenuItem();
            _toolStripMenuItemCostConditions = new ToolStripMenuItem();
            _toolStripMenuItemCostConditionNew = new ToolStripMenuItem();
            _toolStripMenuItemCostConditionServiceable = new ToolStripMenuItem();
            _toolStripMenuItemCostConditionOverhaul = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripMenuItemComposeQuotationOrder = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
            _toolStripMenuItemComposePurchaseOrder = new ToolStripMenuItem();
            _toolStripMenuItemPurchases = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // _toolStripMenuItemOpenKitParentItem
            // 
            _toolStripMenuItemAddKits.Text = "Add kits";
            _toolStripMenuItemAddKits.Click += ToolStripMenuItemAddKitsClick;
            // 
            // _toolStripMenuItemOpenKitParentItem
            // 
            //_toolStripMenuItemOpenKitParentItem.Text = "Open KIT parent";
            //_toolStripMenuItemOpenKitParentItem.Click += ToolStripMenuItemOpenKitParentClick;
            // 
            // _toolStripMenuItemCostConditions
            // 
            _toolStripMenuItemCostConditions.Text = "Cost Conditions";
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemCostConditionNew.Text = "Cost New";
            _toolStripMenuItemCostConditionNew.Click += ToolStripMenuItemCostConditionNewClick;
            _toolStripMenuItemCostConditionNew.CheckOnClick = true;
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemCostConditionServiceable.Text = "Cost Serviceable";
            _toolStripMenuItemCostConditionServiceable.CheckOnClick = true;
            _toolStripMenuItemCostConditionServiceable.Click += ToolStripMenuItemCostConditionServiceableClick;
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemCostConditionOverhaul.Text = "Cost Overhaul";
            _toolStripMenuItemCostConditionOverhaul.CheckOnClick = true;
            _toolStripMenuItemCostConditionOverhaul.Click += ToolStripMenuItemCostConditionOverhaulClick;
            //
            // _toolStripMenuItemComposeQuotationOrder
            //
            _toolStripMenuItemComposeQuotationOrder.Text = "Compose New Quotation Order";
            _toolStripMenuItemComposeQuotationOrder.Click += ToolStripMenuItemComposeQuotationClick;
            //
            // _toolStripMenuItemQuotations
            //
            _toolStripMenuItemQuotations.Text = "Add to Quotation Order";
            //
            // _toolStripMenuItemComposePurchaseOrder
            //
            _toolStripMenuItemComposePurchaseOrder.Text = "Compose New Purchase Order";
            _toolStripMenuItemComposePurchaseOrder.Click += ToolStripMenuItemComposePurchaseClick;
            //
            // _toolStripMenuItemPurchases
            //
            _toolStripMenuItemPurchases.Text = "Add to Purchase Order";

            _toolStripMenuItemCostConditions.DropDownItems.Add(_toolStripMenuItemCostConditionNew);
            _toolStripMenuItemCostConditions.DropDownItems.Add(_toolStripMenuItemCostConditionServiceable);
            _toolStripMenuItemCostConditions.DropDownItems.Add(_toolStripMenuItemCostConditionOverhaul);

            _contextMenuStrip.Items.Clear();
            _contextMenuStrip.Opening += ContextMenuStripOpen;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    _toolStripMenuItemAddKits,
                                                    //_toolStripMenuItemOpenKitParentItem,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemCostConditions,
                                                    new ToolStripSeparator(), 
                                                    _toolStripMenuItemComposeQuotationOrder,
                                                    _toolStripMenuItemQuotations,
                                                    new ToolStripSeparator(), 
                                                    _toolStripMenuItemComposePurchaseOrder,
                                                    _toolStripMenuItemPurchases,
                                                });
        }
        #endregion

        #region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
        /// <summary>
        /// Проверка на выделение 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripOpen(object sender, CancelEventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0)
            {
                //_toolStripMenuItemOpenKitParentItem.Enabled = false;
                _toolStripMenuItemCostConditions.Enabled = false;
            }
            //else if (_directivesViewer.SelectedItems.Count == 1)
            //{
            //    _toolStripMenuItemCostConditions.Enabled = true;
                
            //    InitionalOrderRecord rec =
            //        _currentRfQ.PackageRecords.FirstOrDefault(r => r.PackageItemId == _directivesViewer.SelectedItem.Product.ItemId);
            //    if(rec != null)
            //    {
            //        _toolStripMenuItemCostConditionNew.Checked = (rec.CostCondition & (Int16) KitCostCondition.New)!=0;
            //        _toolStripMenuItemCostConditionServiceable.Checked = (rec.CostCondition & (Int16)KitCostCondition.Serviceable) != 0;
            //        _toolStripMenuItemCostConditionOverhaul.Checked = (rec.CostCondition & (Int16)KitCostCondition.Overhaul) != 0;
            //    }
                  
            //}
            //else
            //{
            //    _toolStripMenuItemCostConditions.Enabled = true;

            //    List<InitionalOrderRecord> records =
            //        _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

            //    if (records.Count != 0)
            //    {
            //        _toolStripMenuItemCostConditionNew.Checked = records.Any(rec=> (rec.CostCondition & (Int16)KitCostCondition.New) != 0);
            //        _toolStripMenuItemCostConditionServiceable.Checked = records.Any(rec => (rec.CostCondition & (Int16)KitCostCondition.Serviceable) != 0);
            //        _toolStripMenuItemCostConditionOverhaul.Checked = records.Any(rec => (rec.CostCondition & (Int16)KitCostCondition.Overhaul) != 0);
            //    }
            //}
            _toolStripMenuItemComposeQuotationOrder.Enabled = true;
        }

        #endregion

        #region private void ToolStripMenuItemAddKitsClick(object sender, EventArgs e)
        private void ToolStripMenuItemAddKitsClick(object sender, EventArgs e)
        {
            OrderAddForm form = new OrderAddForm(_currentItem);
            if(form.ShowDialog() == DialogResult.OK)
                AnimatedThreadWorker.RunWorkerAsync();

        }
        #endregion

        #region private void ToolStripMenuItemOpenKitParentClick(object sender, EventArgs e)
        //private void ToolStripMenuItemOpenKitParentClick(object sender, EventArgs e)
        //{
        //    if (_directivesViewer.SelectedItems.Count == 0) return;

        //    IBaseEntityObject parent;
        //    if (_directivesViewer.SelectedItems[0].Product is AccessoryRequired)
        //    {
        //        parent = (BaseEntityObject)((AccessoryRequired) _directivesViewer.SelectedItems[0].Product).ParentObject;
        //    }
        //    else
        //    {
        //        parent = _directivesViewer.SelectedItems[0].Product;   
        //    }

        //    string regNumber = "";
        //    ReferenceEventArgs refe = new ReferenceEventArgs();
        //    if (parent is Directive)
        //    {
        //        Directive dir = (Directive) parent;
        //        if (dir is DeferredItem)
        //        {
        //            DeferredItem deffered = (DeferredItem)dir;

        //            if (deffered.ParentBaseDetail.ParentAircraft != null)
        //                regNumber = deffered.ParentBaseDetail.ParentAircraft.RegistrationNumber;
        //            refe.DisplayerText = regNumber + ". Deffered. " + deffered.Title;
        //            DeferredScreen defferedScreen = new DeferredScreen(deffered);
        //            defferedScreen.ReflectionType = ReflectionTypes.DisplayInNew;

        //            refe.RequestedEntity = defferedScreen;
        //            refe.TypeOfReflection = ReflectionTypes.DisplayInNew;

        //            InvokeDisplayerRequested(refe);
        //        }
        //        else if (dir is DamageItem)
        //        {
        //            DamageItem damage = (DamageItem)dir;

        //            if (damage.ParentBaseDetail.ParentAircraft != null)
        //                regNumber = damage.ParentBaseDetail.ParentAircraft.RegistrationNumber;
        //            refe.DisplayerText = regNumber + ". Damage" + damage.Title;
        //            DamageDirectiveScreen damageDirectiveScreen = new DamageDirectiveScreen(damage);
        //            damageDirectiveScreen.ReflectionType = ReflectionTypes.DisplayInNew;

        //            refe.RequestedEntity = damageDirectiveScreen;
        //            refe.TypeOfReflection = ReflectionTypes.DisplayInNew;

        //            InvokeDisplayerRequested(refe);
        //        }
        //        else if (dir.DirectiveType == DirectiveType.OutOfPhase)
        //        {
        //            if (dir.ParentBaseDetail.ParentAircraft != null)
        //                regNumber = dir.ParentBaseDetail.ParentAircraft.RegistrationNumber;
        //            refe.DisplayerText = regNumber + ". Out of phase" + dir.Title;
        //            OutOfPhaseReferenceScreen outOfPhaseScreen = new OutOfPhaseReferenceScreen(dir);
        //            outOfPhaseScreen.ReflectionType = ReflectionTypes.DisplayInNew;

        //            refe.RequestedEntity = outOfPhaseScreen;
        //            refe.TypeOfReflection = ReflectionTypes.DisplayInNew;

        //            InvokeDisplayerRequested(refe);
        //        }
        //        else
        //        {
        //            refe.DisplayerText = dir.ParentBaseDetail.ParentAircraft.RegistrationNumber + " " + dir.Title;

        //            refe.RequestedEntity = new DirectiveScreen(dir);
        //            refe.TypeOfReflection = ReflectionTypes.DisplayInNew;

        //            InvokeDisplayerRequested(refe);
        //        }
        //    }
        //    else if (parent is BaseDetail)
        //    {
        //        BaseDetail baseDetail = (BaseDetail)parent;
        //        if(baseDetail.ParentAircraft != null)
        //            refe.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + " ";
        //        else if(baseDetail.ParentStore != null)
        //            refe.DisplayerText = baseDetail.ParentStore.Name + " ";
        //        refe.DisplayerText += baseDetail.BaseDetailType + ". Component PN " +
        //                              baseDetail.PartNumber;
        //        refe.RequestedEntity = new DetailScreenNew(baseDetail);

        //        InvokeDisplayerRequested(refe);
        //    }
        //    else if (parent is Detail)
        //    {
        //        Detail detail = (Detail)parent;
        //        if (detail.DetailClass != DetailClass.Component)
        //        {
        //            ConsumablePartAndKitForm form = new ConsumablePartAndKitForm((Detail)parent);
        //            form.ShowDialog();
        //        }
        //        else
        //        {

        //            refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
        //            if (detail.ParentAircraft != null)
        //            {
        //                refe.DisplayerText = detail.ParentAircraft.RegistrationNumber + ". Component PN " +
        //                                   detail.PartNumber;
        //            }
        //            else if (detail.ParentStore != null)
        //            {
        //                refe.DisplayerText = detail.ParentStore.Name + ". Component PN " + detail.PartNumber;
        //            }
        //            else refe.DisplayerText = "Component PN " + detail.PartNumber;
        //            refe.RequestedEntity = new DetailScreenNew(detail);
        //            InvokeDisplayerRequested(refe);
        //        }
        //    }
        //    else if (parent is DetailDirective)
        //    {
        //        //открытие DetailScreen
        //        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
        //        if (((DetailDirective)parent).ParentDetail != null)
        //        {
        //            Detail detail = ((DetailDirective)parent).ParentDetail;
        //            refe.DisplayerText = detail.ParentAircraft.RegistrationNumber + ". Component PN " + detail.PartNumber;
        //            refe.RequestedEntity = new DetailScreenNew(detail);
        //        }

        //        InvokeDisplayerRequested(refe);
        //    }
        //    else if (parent is MaintenanceCheck)
        //    {
        //        refe.DisplayerText = ((MaintenanceCheck)parent).ParentAircraft.RegistrationNumber + ". Maintenance Program";
        //        refe.RequestedEntity = new MaintenanceScreen(((MaintenanceCheck)parent).ParentAircraft);
        //        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
        //        InvokeDisplayerRequested(refe);
        //    }
        //    else if (parent is NonRoutineJob)
        //    {
        //        NonRoutineJob nrj = ((NonRoutineJob)parent);
        //        NonRoutineJobForm form = new NonRoutineJobForm(nrj);
        //        form.ShowDialog();
        //    }
        //    else if (parent is MaintenanceDirective)
        //    {
        //        MaintenanceDirective md = (MaintenanceDirective)parent;
        //        if (md.ParentBaseDetail.BaseDetailType == BaseDetailType.Frame)
        //        {
        //            refe.DisplayerText = md.ParentBaseDetail.ParentAircraft.RegistrationNumber;
        //        }
        //        else
        //        {
        //            if (md.ParentBaseDetail.ParentAircraft != null)
        //                refe.DisplayerText = md.ParentBaseDetail.ParentAircraft.RegistrationNumber + ". " + md.ParentBaseDetail;
        //            else
        //                refe.DisplayerText = md.ParentBaseDetail.ToString();
        //        }
        //        refe.DisplayerText += ". MPD. " + md.WorkType.CommonName + ". " + md.TaskNumberCheck;
        //        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
        //        refe.RequestedEntity = new MaintenanceDirectiveScreen(md);
        //        InvokeDisplayerRequested(refe);
        //    }    
        //}

        #endregion

        #region private void ToolStripMenuItemCostConditionNewClick(object sender, EventArgs e)
        private void ToolStripMenuItemCostConditionNewClick(object sender, EventArgs e)
        {
            //if (_directivesViewer.SelectedItems.Count == 1)
            //{
            //    RequestForQuotationRecord rec =
            //        _currentRfQ.RequestForQuotationRecords.Where(r => r.KitId == _directivesViewer.SelectedItem.ItemId).FirstOrDefault();
            //    if(rec != null)
            //    {
            //        rec.CostCondition = (Int16)(rec.CostCondition ^ (Int16) KitCostCondition.New);
            //        GlobalObjects.CasEnvironment.Keeper.Save(rec);
            //    }
                  
            //}
            //else
            //{
                //List<InitionalOrderRecord> records =
                //    _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

                //if (records.Count != 0)
                //{
                //    foreach (InitionalOrderRecord record in records)
                //    {
                //        record.CostCondition = (Int16) (record.CostCondition ^ (Int16) KitCostCondition.New);
                //        GlobalObjects.CasEnvironment.Keeper.Save(record);
                //    }
                //}
            //}

        }
        #endregion

        #region private void ToolStripMenuItemCostConditionServiceableClick(object sender, EventArgs e)
        private void ToolStripMenuItemCostConditionServiceableClick(object sender, EventArgs e)
        {
            //if (_directivesViewer.SelectedItems.Count == 1)
            //{
            //    RequestForQuotationRecord rec =
            //        _currentRfQ.RequestForQuotationRecords.Where(r => r.KitId == _directivesViewer.SelectedItem.ItemId).FirstOrDefault();
            //    if (rec != null)
            //    {
            //        rec.CostCondition = (Int16)(rec.CostCondition ^ (Int16)KitCostCondition.Serviceable);
            //        GlobalObjects.CasEnvironment.Keeper.Save(rec);
            //    }

            //}
            //else
            //{
                //List<RequestForQuotationRecord> records =
                //    _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

                //if (records.Count != 0)
                //{
                //    foreach (RequestForQuotationRecord record in records)
                //    {
                //        record.CostCondition = (Int16)(record.CostCondition ^ (Int16)KitCostCondition.Serviceable);
                //        GlobalObjects.CasEnvironment.Keeper.Save(record);
                //    }
                //}
            //}

        }
        #endregion

        #region private void ToolStripMenuItemCostConditionOverhaulClick(object sender, EventArgs e)
        private void ToolStripMenuItemCostConditionOverhaulClick(object sender, EventArgs e)
        {
            //if (_directivesViewer.SelectedItems.Count == 1)
            //{
            //    RequestForQuotationRecord rec =
            //        _currentRfQ.RequestForQuotationRecords.Where(r => r.KitId == _directivesViewer.SelectedItem.ItemId).FirstOrDefault();
            //    if (rec != null)
            //    {
            //        rec.CostCondition = (Int16)(rec.CostCondition ^ (Int16)KitCostCondition.Overhaul);
            //        GlobalObjects.CasEnvironment.Keeper.Save(rec);
            //    }

            //}
            //else
            ////{
            //    List<RequestForQuotationRecord> records =
            //        _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

            //    if (records.Count != 0)
            //    {
            //        foreach (RequestForQuotationRecord record in records)
            //        {
            //            record.CostCondition = (Int16)(record.CostCondition ^ (Int16)KitCostCondition.Overhaul);
            //            GlobalObjects.CasEnvironment.Keeper.Save(record);
            //        }
            //    }
            //}

        }
        #endregion

        #region private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        /// <summary>
        /// Создает закупочный ордер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeQuotationOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

        #endregion

        #region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

        private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void ToolStripMenuItemComposePurchaseClick(object sender, EventArgs e)
        /// <summary>
        /// Создает закупочный ордер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposePurchaseClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeQuotationOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

        #endregion

        #region private void AddToPurchaseOrderItemClick(object sender, EventArgs e)

        private void AddToPurchaseOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new InitionalOrderView()
                                    {
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            _directivesViewer.ItemListView.ContextMenuStrip = _contextMenuStrip;

            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems == null) return;

            DialogResult confirmResult =
                MessageBox.Show(
                    _directivesViewer.SelectedItem != null
                        ? "Do you really want to delete Kit from this order " + _directivesViewer.SelectedItem.Product.PartNumber + "?"
                        : "Do you really want to delete Kits from this order? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;

                List<Product> selectedItems = new List<Product>();
                selectedItems.AddRange(_directivesViewer.SelectedItems.Select(i=>i.Product));
                try
                {
                    //GlobalObjects.CasEnvironment.Manipulator.DeleteFromRequestForQuotation(selectedItems[i], _currentRfQ);
                    GlobalObjects.PackageCore.DeleteFromPackage<InitialOrder, InitialOrderRecord>(selectedItems.ToArray(), _currentItem);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }
                AnimatedThreadWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region private void ButtonPublishClick(object sender, EventArgs e)

        private void ButtonPublishClick(object sender, EventArgs e)
        {
            if (_currentItem.Status != WorkPackageStatus.Closed)
            {
                GlobalObjects.PackageCore.PublishPackage<InitialOrder, InitialOrderRecord>(_currentItem, DateTime.Now);
            }
            else
            {
                switch (MessageBox.Show(@"This Initial Order is already closed," +
                                        "\nif you want to republish it," +
                                        "\nInformation entered at the closing will be erased." + "\n\n Republish " +
                                        _currentItem.Title + " Initional Order?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.PackageCore.PublishPackage<InitialOrder, InitialOrderRecord>(_currentItem, DateTime.Now);
                        break;
                    case DialogResult.No:
                        //arguments.Cancel = true;
                        break;
                }
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        #region private void ButtonCloseClick(object sender, EventArgs e)

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            //RequestForQuotationClosingForm form = new RequestForQuotationClosingForm(_currentRfQ); 
            //if (form.ShowDialog() != DialogResult.OK)return;
            //UpdateDirectives();
            
            //if (form.CreatePurchaseOrder)
            //{
            //    _currentRfQ.Products.Sort();
            //    PurchaseOrderKitForm kitForm = new PurchaseOrderKitForm(_currentRfQ);
            //    if (kitForm.ShowDialog() == DialogResult.OK)
            //    {
            //        ReferenceEventArgs refe = new ReferenceEventArgs
            //        {
            //            DisplayerText = kitForm.CurrentOrder.Title,
            //            TypeOfReflection = ReflectionTypes.DisplayInNew,
            //            RequestedEntity = new PurchaseOrderScreen(kitForm.CurrentOrder)
            //        };
            //        InvokeDisplayerRequested(refe);   
            //    }
            //}           
        }

        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;

            //RequestForQuotationReportBuilder builder = new RequestForQuotationReportBuilder(_currentRfQ);

            //e.DisplayerText = "Request For Quotation Report";
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //e.RequestedEntity = new ReportScreen(builder);
        }
        #endregion

        #region private void HeaderControlButtonEditClick(object sender, EventArgs e)
        private void HeaderControlButtonEditClick(object sender, EventArgs e)
        {
            CommonEditorForm dlg = new CommonEditorForm(_currentItem);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #endregion

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
