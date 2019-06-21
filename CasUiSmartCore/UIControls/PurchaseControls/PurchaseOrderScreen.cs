using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using CASReports.Builders;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class PurchaseOrderScreen : ScreenControl
    {
        #region Fields

        private readonly PurchaseOrder _currentPurchaseOrder;
        private PurchaseOrderView _directivesViewer;

        private RadDropDownMenu _contextMenuStrip;
        private RadMenuItem _toolStripMenuItemOpenParentQuotation;
        //private ToolStripMenuItem _toolStripMenuItemOpenKitParentItem;

        #endregion
        
        #region Constructors

        #region public PurchaseOrderScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public PurchaseOrderScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public PurchaseOrderScreen(PurchaseOrder purchase)
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="purchase">Закупочный ордер которому принадлежат директивы</param>
        public PurchaseOrderScreen(PurchaseOrder purchase)
        {
            if (purchase == null)
                throw new ArgumentNullException("purchase");
            _currentPurchaseOrder = purchase;

            if (purchase.ParentType == SmartCoreType.Aircraft)
                CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(purchase.ParentId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			else if (purchase.ParentType == SmartCoreType.Store)
                CurrentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(purchase.ParentId);
            else if (CurrentAircraft == null && CurrentStore == null)
                aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0]; 
            
            StatusTitle = "Quotation Order Kits";
            InitializeComponent();
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
            _toolStripMenuItemOpenParentQuotation = new RadMenuItem();
            //_toolStripMenuItemOpenKitParentItem = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            //_contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(_contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemOpenParentQuotation.Text = "Open parent Quotation";
            _toolStripMenuItemOpenParentQuotation.Click += ToolStripMenuOpenParentQoutationClick;
            // 
            // toolStripMenuItemView
            // 
            //_toolStripMenuItemOpenKitParentItem.Text = "Open KIT parent";
            //_toolStripMenuItemOpenKitParentItem.Click += ToolStripMenuItemOpenKitParentClick;
            //// 
            //// toolStripMenuItemView
            //// 
            //_toolStripMenuItemCostConditionOverhaul.Text = "Cost Overhaul";
            //_toolStripMenuItemCostConditionOverhaul.CheckOnClick = true;
            //_toolStripMenuItemCostConditionOverhaul.Click += ToolStripMenuItemCostConditionOverhaulClick;
            _contextMenuStrip.Items.Clear();
            
            _contextMenuStrip.Items.AddRange(_toolStripMenuItemOpenParentQuotation
                                                    //_toolStripMenuItemOpenKitParentItem,
                                                    //_toolStripMenuItemCostConditionOverhaul
                                                );
        }
        #endregion

        #region private void ToolStripMenuOpenParentQoutationClick(object sender, EventArgs e)
        private void ToolStripMenuOpenParentQoutationClick(object sender, EventArgs e)
        {
            //загрузка родительского ордера запроса
            RequestForQuotation rfq = GlobalObjects.PurchaseCore.GetRequestForQuotation(_currentPurchaseOrder.ParentQuotationId);

            if(rfq == null)
            {
                //не удалось найти родительский ордер
                MessageBox.Show("impossible to find a Quotation order", (string)new GlobalTermsProvider()["SystemName"], 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            
            //удалось наити запросный ордер, открытие соответствующего экрана
            ReferenceEventArgs refe = new ReferenceEventArgs
            {
                DisplayerText = rfq.Title,
                TypeOfReflection = ReflectionTypes.DisplayInNew,
                RequestedEntity = new RequestForQuotationScreen(rfq)
            };
            InvokeDisplayerRequested(refe);   
        }
        #endregion

        //#region private void ToolStripMenuItemOpenKitParentClick(object sender, EventArgs e)
        //private void ToolStripMenuItemOpenKitParentClick(object sender, EventArgs e)
        //{
        //    if(_directivesViewer.SelectedItems.Count == 0)return;

        //    IBaseEntityObject parent;
        //    if (_directivesViewer.SelectedItems[0].Product is AccessoryRequired)
        //    {
        //        parent = ((AccessoryRequired)_directivesViewer.SelectedItems[0].Product).ParentObject;
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
        //        refe.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + " " +
        //                           baseDetail.BaseDetailType + ". Component PN " +
        //                           baseDetail.PartNumber;
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
                
        //}

        //#endregion

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
            _directivesViewer = new PurchaseOrderView
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
            GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(_currentPurchaseOrder);
            _directivesViewer.SetItemsArray(_currentPurchaseOrder.PackageRecords.ToArray());

            switch (_currentPurchaseOrder.Status)
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
            labelStatus.Text = "Status: " + _currentPurchaseOrder.Status;
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
                        ? "Do you really want to delete Purchase Request from this order ?"
                        : "Do you really want to delete Purchase Requests from this order? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;

                List<PurchaseRequestRecord> selectedItems = new List<PurchaseRequestRecord>();
                selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems[i], true);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
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
            if (_currentPurchaseOrder.Status != WorkPackageStatus.Closed)
            {
                GlobalObjects.PurchaseCore.Publish(_currentPurchaseOrder, DateTime.Now);
            }
            else
            {
                switch (MessageBox.Show(@"This purchase order is already closed," +
                                        "\nif you want to republish it," +
                                        "\nInformation entered at the closing will be erased." + "\n\n Republish " +
                                        _currentPurchaseOrder.Title + " purchase order?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.PurchaseCore.Publish(_currentPurchaseOrder, DateTime.Now);
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
            PurchaseOrderClosingForm form = new PurchaseOrderClosingForm(_currentPurchaseOrder);
            if (form.ShowDialog() != DialogResult.OK) return;
            UpdateDirectives();          
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
            e.DisplayerText = "Request For Quotation Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new ReportScreen(new PurchaseOrderReportBuilder(_currentPurchaseOrder));
            GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PurchaseOrderScreen (Request For Quotation Report)");
		}
        #endregion

        #region private void HeaderControlButtonEditClick(object sender, EventArgs e)
        private void HeaderControlButtonEditClick(object sender, EventArgs e)
        {
            PurchaseRequestForm dlg = new PurchaseRequestForm(_currentPurchaseOrder);
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
