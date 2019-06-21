using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using System.Linq;
using CAS.UI.UIControls.PurchaseControls.Quatation;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class RequestForQuotationScreen : ScreenControl
    {
        #region Fields

        private readonly RequestForQuotation _currentRfQ;
        private RequestForQuotationView _directivesViewer;

        private RadDropDownMenu _contextMenuStrip;
        private RadMenuItem _toolStripMenuItemCostConditions;
        private RadMenuItem _toolStripMenuItemCostConditionNew;
        private RadMenuItem _toolStripMenuItemCostConditionServiceable;
        private RadMenuItem _toolStripMenuItemCostConditionOverhaul;
        private RadMenuItem _toolStripMenuItemAddKits;
        //private ToolStripMenuItem _toolStripMenuItemOpenKitParentItem;
        private RadMenuSeparatorItem _toolStripSeparator1;

        #endregion
        
        #region Constructors

        #region private RequestForQuotationScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private RequestForQuotationScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public RequestForQuotationScreen(RequestForQuotation request) : this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="request">ВС, которому принадлежат директивы</param>
        public RequestForQuotationScreen(RequestForQuotation request)
            : this()
        {
            if (request == null)
                throw new ArgumentNullException("request");
            _currentRfQ = request;
            
            if(_currentRfQ.ParentType == SmartCoreType.Aircraft)
                CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentRfQ.ParentId);//TODO:(Evgenii Babak) пересмотреть использование ParentId здесь
			else if (_currentRfQ.ParentType == SmartCoreType.Store)
                CurrentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(_currentRfQ.ParentId);
            else if (CurrentAircraft == null && CurrentStore == null)
                aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0]; 
            
            StatusTitle = "Quotation Order Kits";
            InitToolStripMenuItems();
            InitListView();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new RadDropDownMenu();
            _toolStripMenuItemAddKits = new RadMenuItem();
            //_toolStripMenuItemOpenKitParentItem = new ToolStripMenuItem();
            _toolStripMenuItemCostConditions = new RadMenuItem();
            _toolStripMenuItemCostConditionNew = new RadMenuItem();
            _toolStripMenuItemCostConditionServiceable = new RadMenuItem();
            _toolStripMenuItemCostConditionOverhaul = new RadMenuItem();
            _toolStripSeparator1 = new RadMenuSeparatorItem();
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

            _toolStripMenuItemCostConditions.Items.Add(_toolStripMenuItemCostConditionNew);
            _toolStripMenuItemCostConditions.Items.Add(_toolStripMenuItemCostConditionServiceable);
            _toolStripMenuItemCostConditions.Items.Add(_toolStripMenuItemCostConditionOverhaul);

            _contextMenuStrip.Items.Clear();
            
            _contextMenuStrip.Items.AddRange(_toolStripMenuItemAddKits,
                                                    //_toolStripMenuItemOpenKitParentItem,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemCostConditions);
        }
        #endregion

        #region void _contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //void _contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    ToolStripMenuItem checkedItem = (ToolStripMenuItem) e.ClickedItem;
            
        //    if(checkedItem == _toolStripMenuItemCostConditionNew)
        //    {
        //        _contextMenuStrip.AutoClose = false;
        //        if (_directivesViewer.SelectedItems.Count == 1)
        //        {
        //            List<RequestForQuotationRecord> records
        //                = new List<RequestForQuotationRecord>(GlobalObjects.CasEnvironment.Loader.GetRequestForQuotationRecords(_currentRfQ));

        //            RequestForQuotationRecord rec =
        //                records.Where(r => r.KitId == _directivesViewer.SelectedItem.ItemId).FirstOrDefault();
        //            if (rec != null)
        //            {
        //                rec.CostCondition = (Int16)(rec.CostCondition ^ (Int16)KitCostCondition.New);
        //                GlobalObjects.CasEnvironment.Keeper.Save(rec);
        //            }

        //        }
        //        else
        //        {
        //            _toolStripMenuItemCostConditionNew.Checked = false;
        //        }
        //    }
        //}
        #endregion

        #region private void ToolStripMenuItemAddKitsClick(object sender, EventArgs e)
        private void ToolStripMenuItemAddKitsClick(object sender, EventArgs e)
        {
            RequestForQuotationAddForm form = new RequestForQuotationAddForm(_currentRfQ);
            if(form.ShowDialog() == DialogResult.OK)
                UpdateDirectives();

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
                List<RequestForQuotationRecord> records =
                    _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

                if (records.Count != 0)
                {
                    foreach (RequestForQuotationRecord record in records)
                    {
                        record.CostCondition = (record.CostCondition ^ ComponentStatus.New);
                        GlobalObjects.CasEnvironment.NewKeeper.Save(record);
                    }
                }
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
                List<RequestForQuotationRecord> records =
                    _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

                if (records.Count != 0)
                {
                    foreach (RequestForQuotationRecord record in records)
                    {
                        record.CostCondition = (record.CostCondition ^ ComponentStatus.Serviceable);
                        GlobalObjects.CasEnvironment.NewKeeper.Save(record);
                    }
                }
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
            //{
                List<RequestForQuotationRecord> records =
                    _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

                if (records.Count != 0)
                {
                    foreach (RequestForQuotationRecord record in records)
                    {
                        record.CostCondition = (record.CostCondition ^ ComponentStatus.Overhaul);
                        GlobalObjects.CasEnvironment.NewKeeper.Save(record);
                    }
                }
            //}

        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        private void UpdateInformation()
        {
            if (CurrentAircraft != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
            }
            UpdateDirectives();
            _directivesViewer.Focus();
        }
        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new RequestForQuotationView
                                    {
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            _directivesViewer.CustomMenu = _contextMenuStrip;

            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            _directivesViewer.MenuOpeningAction = () =>
            {
	            if (_directivesViewer.SelectedItems.Count <= 0)
	            {
		            //_toolStripMenuItemOpenKitParentItem.Enabled = false;
		            _toolStripMenuItemCostConditions.Enabled = false;
	            }
	            else if (_directivesViewer.SelectedItems.Count == 1)
	            {
		            _toolStripMenuItemCostConditions.Enabled = true;

		            RequestForQuotationRecord rec =
			            _currentRfQ.PackageRecords.FirstOrDefault(r => r.PackageItemId == _directivesViewer.SelectedItem.Product.ItemId);
		            if (rec != null)
		            {
			            _toolStripMenuItemCostConditionNew.IsChecked = (rec.CostCondition & ComponentStatus.New) != 0;
			            _toolStripMenuItemCostConditionServiceable.IsChecked = (rec.CostCondition & ComponentStatus.Serviceable) != 0;
			            _toolStripMenuItemCostConditionOverhaul.IsChecked = (rec.CostCondition & ComponentStatus.Overhaul) != 0;
		            }

	            }
	            else
	            {
		            _toolStripMenuItemCostConditions.Enabled = true;

		            List<RequestForQuotationRecord> records =
			            _currentRfQ.PackageRecords.Where(rec => _directivesViewer.SelectedItems.Any(kit => rec.PackageItemId == kit.Product.ItemId)).ToList();

		            if (records.Count != 0)
		            {
			            _toolStripMenuItemCostConditionNew.IsChecked = records.Any(rec => (rec.CostCondition & ComponentStatus.New) != 0);
			            _toolStripMenuItemCostConditionServiceable.IsChecked = records.Any(rec => (rec.CostCondition & ComponentStatus.Serviceable) != 0);
			            _toolStripMenuItemCostConditionOverhaul.IsChecked = records.Any(rec => (rec.CostCondition & ComponentStatus.Overhaul) != 0);
		            }
	            }
			};

			panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
        }

        #endregion

        #region private void UpdateDirectives()

        private void UpdateDirectives()
        {
            GlobalObjects.PurchaseCore.LoadRequestForQuotationItems(_currentRfQ);
            _directivesViewer.SetItemsArray(_currentRfQ.PackageRecords.ToArray());

            switch (_currentRfQ.Status)
            {
                case WorkPackageStatus.Published:
                    {
                        buttonPublish.Enabled = false;
                        buttonClose.Enabled = true;
                        break;
                    }
                case WorkPackageStatus.Closed:
                    {
                        buttonPublish.Enabled = true;
                        buttonClose.Enabled = false;
                        break;
                    }
                default:
                    {
                        buttonPublish.Enabled = true;
                        buttonClose.Enabled = true;
                        break;
                    }
            }
            labelStatus.Text = "Status: " + _currentRfQ.Status;
            headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
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
                List<Product> selectedItems = new List<Product>();
                selectedItems.AddRange(_directivesViewer.SelectedItems.Select(i=>i.Product));
                try
                {
                   GlobalObjects.PackageCore.DeleteFromPackage<RequestForQuotation, RequestForQuotationRecord>(selectedItems.ToArray(), _currentRfQ);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }
                UpdateDirectives();
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
            if (_currentRfQ.Status != WorkPackageStatus.Closed)
            {
                GlobalObjects.PurchaseCore.Publish(_currentRfQ, DateTime.Now);
            }
            else
            {
                switch (MessageBox.Show(@"This Quotation request order is already closed," +
                                        "\nif you want to republish it," +
                                        "\nInformation entered at the closing will be erased." + "\n\n Republish " +
                                        _currentRfQ.Title + " quotation request order?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.PurchaseCore.Publish(_currentRfQ, DateTime.Now);
                        break;
                    case DialogResult.No:
                        //arguments.Cancel = true;
                        break;
                }
            }
            UpdateDirectives();
        }

        #endregion

        #region private void ButtonCloseClick(object sender, EventArgs e)

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            RequestForQuotationClosingForm form = new RequestForQuotationClosingForm(_currentRfQ); 
            if (form.ShowDialog() != DialogResult.OK)return;
            UpdateDirectives();
            
            if (form.CreatePurchaseOrder)
            {
                _currentRfQ.Products.Sort();
                PurchaseOrderKitForm kitForm = new PurchaseOrderKitForm(_currentRfQ);
                if (kitForm.ShowDialog() == DialogResult.OK)
                {
                    ReferenceEventArgs refe = new ReferenceEventArgs
                    {
                        DisplayerText = kitForm.CurrentOrder.Title,
                        TypeOfReflection = ReflectionTypes.DisplayInNew,
                        RequestedEntity = new PurchaseOrderScreen(kitForm.CurrentOrder)
                    };
                    InvokeDisplayerRequested(refe);   
                }
            }           
        }

        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            UpdateDirectives();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            RequestForQuotationReportBuilder builder = new RequestForQuotationReportBuilder(_currentRfQ);

            e.DisplayerText = "Request For Quotation Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new ReportScreen(builder);
            GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "RequestForQuotationScreen (Request For Quotation Report)");
		}
        #endregion

        #region void HeaderControlButtonEditClick(object sender, EventArgs e)
        void HeaderControlButtonEditClick(object sender, EventArgs e)
        {
            CommonEditorForm dlg = new CommonEditorForm(_currentRfQ);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation();
            }
        }
        #endregion

        #region private void ButtonFilter_Click(object sender, EventArgs e)

        private void ButtonFilter_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion


    }
}
