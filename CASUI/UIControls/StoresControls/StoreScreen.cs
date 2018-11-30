using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.StoresControls;
using CAS.UI.Properties;
using CASReports.Builders;
using Controls.AvMultitabControl.Auxiliary;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using Controls.AvButtonT;
using Controls.StatusImageLink;
using Controls;
using Controls.AvMultitabControl;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Элемент управления для отображения списка агрегатов склада
    /// </summary>
    [ToolboxItem(false)]
    public class StoreScreen : Control, IReference
    {

        #region Fields

        private readonly Store currentStore;
        private readonly Operator currentOperator;
        private object detailBeforeSave;
        private object detailBeforeReload;

        private OperatorHeaderControl operatorHeaderControl;
        private RichReferenceButton buttonAddDetail;
        private AvButtonT buttonAddConsumablePartAndKit;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private StoreDetailsListView storeDetailsViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl1;
        private ReferenceLinkLabel linkShoulBeOnStock;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel1;

        private ToolStripMenuItem toolStripMenuItemInstallToAnAircraft;
        private ToolStripMenuItem toolStripMenuItemMoveToStore;
        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemLLPDiskSheetStatus;
        private ToolStripMenuItem toolStripMenuItemEngineeringOrders;
        private ToolStripMenuItem toolStripMenuItemSBStatus;
        private ToolStripMenuItem toolStripMenuItemADStatus;
        private ToolStripMenuItem toolStripMenuItemDiscrepancies;
        private ToolStripMenuItem toolStripMenuItemLogBook;
        private ToolStripMenuItem toolStripMenuItemHighlight;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;
        private readonly bool permissionForCreate = true;

        #endregion

        #region Constructors

        #region public StoreScreen(Store store)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов склада
        /// </summary>
        public StoreScreen(Store store)
        {
            if (store == null)
                throw new ArgumentNullException("store", "Cannot display null-currentStore");
            ((DispatcheredStoreScreen) this).InitComplition += StoreScreen_InitComplition;
            currentStore = store;
            InitializeComponent();
            /*permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.UpdateInformation);*/
            HookDetailCollection();
            HookDetails();
            UpdateInformation();
        }

        #endregion
        
        #region public StoreScreen(Operator currentOperator)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов всех складов эксплуатанта
        /// </summary>
        /// <param name="currentOperator">Эксплуатант</param>
        public StoreScreen(Operator currentOperator)
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");
            ((DispatcheredStoreScreen)this).InitComplition += StoreScreen_InitComplition;
            this.currentOperator = currentOperator;
            InitializeComponent();
            HookDetailCollection();
            HookDetails();
            //filterSelection = new StoreDetailFilterSelectionForm(store);
            UpdateInformation();
        }

        #endregion
                
        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddDetail = new RichReferenceButton();
            buttonAddConsumablePartAndKit = new AvButtonT();
            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            if (currentStore != null)
            {
                operatorHeaderControl = new OperatorHeaderControl(currentStore.Operator, true);
                storeDetailsViewer = new StoreDetailsListView(currentStore);
            }
            else
            {
                operatorHeaderControl = new OperatorHeaderControl(currentOperator, true);
                storeDetailsViewer = new StoreDetailsListView(currentOperator);
            }
            statusImageLinkLabel1 = new StatusImageLinkLabel();
            linkShoulBeOnStock = new ReferenceLinkLabel();
            

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItemInstallToAnAircraft = new ToolStripMenuItem();
            toolStripMenuItemMoveToStore = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemADStatus = new ToolStripMenuItem();
            toolStripMenuItemEngineeringOrders = new ToolStripMenuItem();
            toolStripMenuItemDiscrepancies = new ToolStripMenuItem();
            toolStripMenuItemSBStatus = new ToolStripMenuItem();
            toolStripMenuItemLLPDiskSheetStatus = new ToolStripMenuItem();
            toolStripMenuItemLogBook = new ToolStripMenuItem();
            toolStripMenuItemHighlight = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemHighlight,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemInstallToAnAircraft,
                                                     toolStripMenuItemMoveToStore,
                                                     toolStripSeparator4,
                                                     toolStripMenuItemAdd,
                                                     toolStripMenuItemDelete,
                                                     toolStripSeparator3,
                                                     toolStripMenuItemADStatus,
                                                     toolStripMenuItemEngineeringOrders,
                                                     toolStripMenuItemDiscrepancies,
                                                     toolStripMenuItemLLPDiskSheetStatus,
                                                     toolStripMenuItemSBStatus,
                                                     toolStripMenuItemLogBook,
                                                 });
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Size = new Size(178, 22);
            toolStripMenuItemTitle.Text = "Edit";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemHighlight
            // 
            toolStripMenuItemHighlight.Text = "Highlight";
            toolStripMenuItemHighlight.CheckOnClick = true;
            toolStripMenuItemHighlight.Click += toolStripMenuItemHighlight_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Size = new Size(178, 22);
            toolStripMenuItemAdd.Text = "Add Component";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemInstallToAnAircraft
            // 
            toolStripMenuItemInstallToAnAircraft.Size = new Size(178, 22);
            toolStripMenuItemInstallToAnAircraft.Text = "Install to an Aircraft";
            toolStripMenuItemInstallToAnAircraft.Click += toolStripMenuItemInstallToAnAircraft_Click;
            // 
            // toolStripMenuItemMoveToStore
            // 
            toolStripMenuItemMoveToStore.Size = new Size(178, 22);
            toolStripMenuItemMoveToStore.Text = "Move to Store";
            toolStripMenuItemMoveToStore.Click += toolStripMenuItemMoveToStore_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(175, 6);
            // 
            // toolStripMenuItemADStatus
            // 
            toolStripMenuItemADStatus.Size = new Size(178, 22);
            toolStripMenuItemADStatus.Text = "AD Status";
            toolStripMenuItemADStatus.Click += toolStripMenuItemADStatus_Click;
            // 
            // toolStripMenuItemEngineeringOrders
            // 
            toolStripMenuItemEngineeringOrders.Size = new Size(178, 22);
            toolStripMenuItemEngineeringOrders.Text = "Engineering Orders";
            toolStripMenuItemEngineeringOrders.Click += toolStripMenuItemEngineeringOrders_Click;
            // 
            // toolStripMenuItemDiscrepancies
            // 
            toolStripMenuItemDiscrepancies.Size = new Size(178, 22);
            toolStripMenuItemDiscrepancies.Text = "Discrepancies";
            toolStripMenuItemDiscrepancies.Click += toolStripMenuItemDiscrepancies_Click;
            // 
            // toolStripMenuItemLLPDiskSheetStatus
            // 
            toolStripMenuItemLLPDiskSheetStatus.Size = new Size(178, 22);
            toolStripMenuItemLLPDiskSheetStatus.Text = "LLP Disk Sheet Status";
            toolStripMenuItemLLPDiskSheetStatus.Click += toolStripMenuItemLLPDiskSheetStatus_Click;
            // 
            // toolStripMenuItemSBStatus
            // 
            toolStripMenuItemSBStatus.Size = new Size(178, 22);
            toolStripMenuItemSBStatus.Text = "SB Status";
            toolStripMenuItemSBStatus.Click += toolStripMenuItemSBStatus_Click;
            // 
            // toolStripMenuItemSBStatus
            // 
            toolStripMenuItemLogBook.Size = new Size(178, 22);
            toolStripMenuItemLogBook.Text = "Log Book";
            toolStripMenuItemLogBook.Click += toolStripMenuItemLogBook_Click;
            

            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(linkShoulBeOnStock);
            panelTopContainer.Controls.Add(statusImageLinkLabel1);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddConsumablePartAndKit);
            panelTopContainer.Controls.Add(buttonAddDetail);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 14;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;
            buttonApplyFilter.Size = new Size(145, 59);
            buttonApplyFilter.TabIndex = 19;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonAddConsumablePartAndKit
            // 
            buttonAddConsumablePartAndKit.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddConsumablePartAndKit.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddConsumablePartAndKit.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddConsumablePartAndKit.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddConsumablePartAndKit.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddConsumablePartAndKit.Icon = icons.Add;
            buttonAddConsumablePartAndKit.IconNotEnabled = icons.AddGray;
            buttonAddConsumablePartAndKit.Size = new Size(190, 59);
            buttonAddConsumablePartAndKit.TabIndex = 15;
            buttonAddConsumablePartAndKit.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddConsumablePartAndKit.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddConsumablePartAndKit.TextMain = "Add new";
            buttonAddConsumablePartAndKit.TextSecondary = "Consumable/Kit";
            buttonAddConsumablePartAndKit.Click += buttonAddConsumablePartAndKit_Click;
            // 
            // buttonAddDetail
            // 
            buttonAddDetail.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.Icon = icons.Add;
            buttonAddDetail.IconNotEnabled = icons.AddGray;
            buttonAddDetail.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDetail.Size = new Size(152, 59);
            buttonAddDetail.TabIndex = 15;
            buttonAddDetail.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDetail.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDetail.TextMain = "Add new";
            buttonAddDetail.TextSecondary = "component";
            buttonAddDetail.DisplayerRequested += buttonAddDetail_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.Enabled = false;
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.IconNotEnabled = icons.DeleteGray;
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(145, 59);
            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
            // 
            // footerControl1
            // 
            footerControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl1.BackColor = Color.Transparent;
            footerControl1.Dock = DockStyle.Bottom;
            footerControl1.Location = new Point(0, 568);
            footerControl1.Margin = new Padding(0);
            footerControl1.MaximumSize = new Size(0, 48);
            footerControl1.MinimumSize = new Size(0, 48);
            footerControl1.Name = "footerControl1";
            footerControl1.Size = new Size(1042, 48);
            footerControl1.TabIndex = 10;
            // 
            // headerControl1
            // 
            headerControl1.ActionControlSplitterVisible = true;
            headerControl1.ContextActionControl.ShowPrintButton = true;
            headerControl1.BackColor = Color.Transparent;
            headerControl1.BackgroundImage = Resources.HeaderBar;
            headerControl1.Controls.Add(operatorHeaderControl);
            headerControl1.Dock = DockStyle.Top;
            headerControl1.EditDisplayerText = "Component Status Operator";
            headerControl1.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl1.EditDisplayerRequested += headerControl1_EditDisplayerRequested;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1042, 58);
            headerControl1.TabIndex = 6;
            headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl1.ReloadRised += headerControl1_ReloadRised;
            headerControl1.ContextActionControl.ButtonHelp.TopicID = "component-status.html";
            if (currentStore == null)
                headerControl1.ActionControl.ShowEditButton = false;
            // 
            // statusImageLinkLabel1
            // 
            statusImageLinkLabel1.ActiveLinkColor = Color.Black;
            statusImageLinkLabel1.Enabled = false;
            statusImageLinkLabel1.HoveredLinkColor = Color.Black;
            statusImageLinkLabel1.ImageBackColor = Color.Transparent;
            statusImageLinkLabel1.ImageLayout = ImageLayout.Center;
            statusImageLinkLabel1.LinkColor = Color.DimGray;
            statusImageLinkLabel1.LinkMouseCapturedColor = Color.Empty;
            statusImageLinkLabel1.Location = new Point(28, 3);
            statusImageLinkLabel1.Margin = new Padding(0);
            statusImageLinkLabel1.Name = "statusImageLinkLabel1";
            statusImageLinkLabel1.Size = new Size(412, 27);
            statusImageLinkLabel1.Status = Statuses.Pending;
            statusImageLinkLabel1.TabIndex = 16;
            statusImageLinkLabel1.Text = "Component Status";
            statusImageLinkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            statusImageLinkLabel1.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //
            // linkStock
            //
            linkShoulBeOnStock.Location = new Point(57, 30);
            linkShoulBeOnStock.Size = new Size(200, 19);
            linkShoulBeOnStock.Text = "Should be on stock";
            linkShoulBeOnStock.Enabled = true;
            linkShoulBeOnStock.ReflectionType = ReflectionTypes.DisplayInNew;
            linkShoulBeOnStock.DisplayerRequested += linkShoulBeOnStock_DisplayerRequested;
            Css.SimpleLink.Adjust(linkShoulBeOnStock);
            //
            // storeDetailsViewer
            //
            storeDetailsViewer.ContextMenuStrip = contextMenuStrip;
            storeDetailsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            storeDetailsViewer.Size = new Size(Width, Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            storeDetailsViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(storeDetailsViewer);
            Controls.Add(headerControl1);
            Size = new Size(1042, 616);
        }

        #endregion

        #region public virtual void UpdateElements()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public virtual void UpdateInformation()
        {
            UpdateStoreInformation();
            storeDetailsViewer.UpdateItems();
            HookDetails();
            buttonAddDetail.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Enabled = permissionForCreate;
            if (!permissionForUpdate)
            {
                headerControl1.ActionControl.ButtonEdit.TextMain = "View";// ShowEditButton = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.UpdateInformation);
                headerControl1.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl1.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }

            SetContextMenuParameters(storeDetailsViewer.SelectedItems.Count);

            headerControl1.ContextActionControl.ButtonPrint.Enabled = storeDetailsViewer.ItemsListView.Items.Count != 0;
        }

        #endregion

        #region private void UpdateStoreInformation()

        private void UpdateStoreInformation()
        {
            if (currentStore != null)
                statusImageLinkLabel1.Text = "Store: " + currentStore.StoreId;
            else
                statusImageLinkLabel1.Text = currentOperator.Name + ". Stock";
        }

        #endregion
        
        #region private void headerControl1_ReloadRised(object sender, EventArgs e)

        private void headerControl1_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// 
        /// </summary>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }

        #endregion

        #region private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            StoreForm form = new StoreForm(currentStore);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateStoreInformation();
            }
            e.Cancel = true;
        }

        #endregion

        #region private void OnViewEditScreen()

        private void OnViewEditScreen()
        {
            List<object> selectedDetails = storeDetailsViewer.SelectedItems;
            for (int i = 0; i < selectedDetails.Count; i++)
            {
                object detail = selectedDetails[i];
                DispatcheredDetailScreen requestedEntity = new DispatcheredDetailScreen(detail);
                string displayerText;
                if (currentStore != null)
                    if(detail is Detail)
                        displayerText = currentStore.StoreId + ". Component SN " + ((Detail)detail).SerialNumber;
                    else
                        displayerText = currentStore.StoreId + ". Component SN " + ((BaseDetail)detail).RepresentingDetail.SerialNumber;
                else
                    if (detail is Detail)
                        displayerText = (((Detail)detail).ParentStore).StoreId + ". Component SN " + ((Detail)detail).SerialNumber;//todo
                    else
                        displayerText = (((BaseDetail)detail).ParentStore).StoreId + ". Component SN " + ((BaseDetail)detail).RepresentingDetail.SerialNumber;//todo
                OnDisplayerRequested(new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, displayerText));
            }
        }

        #endregion

        #region private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (currentStore != null)
            {
                e.RequestedEntity = new DispatcheredDetailAddingScreen(currentStore);
                e.DisplayerText = currentStore.StoreId + ". New Component";
            }
            else
            {
                if (global::.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
                e.RequestedEntity = new DispatcheredDetailAddingScreen(currentOperator.Stores[0]);
                e.DisplayerText = currentOperator.Stores[0].RegistrationNumber + ". New Component";
            }
        }

        #endregion

        #region private void buttonAddConsumablePartAndKit_Click(object sender, EventArgs e)

        private void buttonAddConsumablePartAndKit_Click(object sender, EventArgs e)
        {
            if (currentStore != null)
            {
                ConsumablePartAndKitForm form = new ConsumablePartAndKitForm(currentStore);
                form.Show();
            }
            else
                MessageBox.Show("Функционал пока не реализован" + Environment.NewLine + "Работает в отдельном складе");
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((storeDetailsViewer.SelectedItems == null) && (storeDetailsViewer.SelectedItem == null))
                return;
            DialogResult confirmResult =
                MessageBox.Show(
                    storeDetailsViewer.SelectedItem != null
                        ? "Do you really want to delete component " + storeDetailsViewer.SelectedItem.SerialNumber +
                          "?"
                        : "Do you really want to delete selected components? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = storeDetailsViewer.SelectedItems.Count;


                try
                {
                    List<AbstractDetail> selectedItems = new List<AbstractDetail>(storeDetailsViewer.SelectedItems);
                    storeDetailsViewer.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        IDetailContainer parent = selectedItems[i].Parent as IDetailContainer;
                        if (parent == null)
                        {
                            MessageBox.Show("Failed to delete component: Parent container is invalid",
                                            "Operation failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (parent is Aircraft)
                            ((Aircraft)parent).RemoveBaseDetail((BaseDetail)selectedItems[i]);
                        else
                            parent.Remove(selectedItems[i]);

                    }
                    storeDetailsViewer.ItemsListView.EndUpdate();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); return;
                }


                //ReloadElements();
            }
        }

        #endregion

        #region protected void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
        {
            try
            {
                if (currentStore != null)
                    currentStore.Reload(true);
                else
                {
                    for (int i = 0; i < currentOperator.Stores.Count; i++)
                        currentOperator.Stores[i].Reload(true);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            UpdateInformation();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            StoreBuilder reportBuilder = new StoreBuilder();
            if (currentStore != null)
            {
                reportBuilder.IsFiltered = filterSelection.GetDetailCollectionFilter().IsNonReportFilterApply;
                if (currentStore.Operator.Stores.Count == 1)
                    reportBuilder.AddAdditionalInformation(currentStore.Operator.LogoTypeWhite, currentStore.RegistrationNumber, currentStore.Model);
                else
                    reportBuilder.AddAdditionalInformation(currentOperator.LogoTypeWhite, currentStore.Operator.Name + " Stock General Report", currentStore.Model);
                e.DisplayerText = "Store " + currentStore.RegistrationNumber + ". Report";
            }
            else
            {
                reportBuilder.AddAdditionalInformation(currentOperator.LogoTypeWhite, currentOperator.Name + ". Stock General Report", "");
                e.DisplayerText = currentOperator.Name + " Stock Report";
            }
            reportBuilder.AddDetails(storeDetailsViewer.GetItemsArray());
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredStoreReport(reportBuilder);
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            if (currentStore != null)
            {
                filterSelection.SetFilterParameters(additionalFilter);
                filterSelection.Show();
                filterSelection.BringToFront();
                filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
                filterSelection.ApplyFilter += filterSelection_ApplyFilter;
            }
            else
                MessageBox.Show("Функционал пока не реализован" + Environment.NewLine + "Работает в отдельном складе");
        }

        #endregion

        #region private void filterSelection_ApplyFilter(object sender, EventArgs e)

        private void filterSelection_ApplyFilter(object sender, EventArgs e)
        {
            additionalFilter = filterSelection.GetDetailCollectionFilter();
            UpdateInformation();
        }

        #endregion

        #region private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);

            bool visible = (storeDetailsViewer.SelectedItem is BaseDetail); //todo доделать
            toolStripSeparator3.Visible = visible;
            toolStripMenuItemADStatus.Visible = visible;
            toolStripMenuItemEngineeringOrders.Visible = visible;
            toolStripMenuItemDiscrepancies.Visible = visible;
            toolStripMenuItemLLPDiskSheetStatus.Visible = visible;
            toolStripMenuItemSBStatus.Visible = visible;
            toolStripMenuItemLogBook.Visible = visible;
        }

        #endregion

        #region private void linkShoulBeOnStock_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkShoulBeOnStock_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (currentStore != null)
            {
                e.DisplayerText = currentStore.RegistrationNumber + ". Should be on stock";
                e.RequestedEntity = new DispatcheredShouldBeOnStockScreen(currentStore);
            }
            else
            {
                e.DisplayerText = currentOperator.Name + ". Should be on stock";
                e.RequestedEntity = new DispatcheredShouldBeOnStockScreen(currentOperator);
            }
                
        }

        #endregion

        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            bool permission = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            toolStripMenuItemADStatus.Enabled =
            toolStripMenuItemEngineeringOrders.Enabled = 
            toolStripMenuItemDiscrepancies.Enabled = 
            toolStripMenuItemLLPDiskSheetStatus.Enabled = 
            toolStripMenuItemSBStatus.Enabled = 
            toolStripMenuItemLogBook.Enabled = permission && count == 1;

            toolStripMenuItemTitle.Enabled = 
            toolStripMenuItemHighlight.Enabled = count > 0;

            buttonDeleteSelected.Enabled = permissionForDelete && (count > 0);
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;

            bool onlyConsumablePartsAndKits = true;
            for (int i = 0; i < storeDetailsViewer.SelectedItems.Count; i++)
            {
                if (storeDetailsViewer.SelectedItems[i].DetailPattern != DetailPattern.ConsumablePart &&
                    storeDetailsViewer.SelectedItems[i].DetailPattern != DetailPattern.Kit)
                    onlyConsumablePartsAndKits = false;
            }
            if (onlyConsumablePartsAndKits)
                toolStripMenuItemInstallToAnAircraft.Enabled = false;
            else if (storeDetailsViewer.SelectedItem != null)
                toolStripMenuItemInstallToAnAircraft.Enabled = storeDetailsViewer.SelectedItem.DetailPattern != DetailPattern.ConsumablePart && storeDetailsViewer.SelectedItem.DetailPattern != DetailPattern.Kit;
            else
                toolStripMenuItemInstallToAnAircraft.Enabled = count > 0;

            bool highlight = false;
            bool allHighlight = true;
            for (int i = 0; i < storeDetailsViewer.SelectedItems.Count; i++)
            {
                if (storeDetailsViewer.SelectedItems[i].Highlight == HighlightCollection.Instance[KnownColor.Blue]) 
                    highlight = true;
                else
                    allHighlight = false;
            }
            if (allHighlight)
                toolStripMenuItemHighlight.CheckState = CheckState.Checked;
            else if (highlight)
                toolStripMenuItemHighlight.CheckState = CheckState.Indeterminate;
            else
                toolStripMenuItemHighlight.CheckState = CheckState.Unchecked;
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region private void toolStripMenuItemHighlight_Click(object sender, EventArgs e)

        private void toolStripMenuItemHighlight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storeDetailsViewer.SelectedItems.Count; i++)
            {
                //storeDetailsViewer.SelectedItems[i].Highlight = toolStripMenuItemHighlight.Checked; Todo: Изменить под новый функционал
                storeDetailsViewer.SelectedItems[i].Save(true);
            }
        }
        
        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            buttonAddDetail_DisplayerRequested(this, arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemInstallToAnAircraft_Click(object sender, EventArgs e)

        private void toolStripMenuItemInstallToAnAircraft_Click(object sender, EventArgs e)
        {
            MoveDetailForm form;
            if (storeDetailsViewer.SelectedItem != null)
                form = new MoveDetailForm(storeDetailsViewer.SelectedItem, MoveDetailFormMode.MoveToAircraft, null);
            else
            {
                bool containBaseDetail = false;
                bool onlyBaseDetails = true;
                bool containConsumablePartsAndKits = false;
              //  bool onlyConsumablePartsAndKits = true;
                for (int i = 0; i < storeDetailsViewer.SelectedItems.Count; i++ )
                {
                    if (storeDetailsViewer.SelectedItems[i] is BaseDetail)
                        containBaseDetail = true;
                    else if (storeDetailsViewer.SelectedItems[i] is Detail)
                    {
                        onlyBaseDetails = false;
                        if (storeDetailsViewer.SelectedItems[i].DetailPattern == DetailPattern.ConsumablePart || storeDetailsViewer.SelectedItems[i].DetailPattern == DetailPattern.Kit)
                            containConsumablePartsAndKits = true;
                        /*else
                            onlyConsumablePartsAndKits = false;*/
                    }
                }
                if (onlyBaseDetails)
                {
                    List<BaseDetail> baseDetails = new List<BaseDetail>();
                    for (int i = 0; i < storeDetailsViewer.SelectedItems.Count; i++)
                        baseDetails.Add((BaseDetail)storeDetailsViewer.SelectedItems[i]);
                    form = new MoveDetailForm(baseDetails, MoveDetailFormMode.MoveToAircraft,  null);
                }
                /*                else if (onlyConsumablePartsAndKits)
                                {
                                    MessageBox.Show("You can not move consumable parts and kits to an aircraft.", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }*/
                else if (containBaseDetail)
                {
                    MessageBox.Show("You can not move details along with base details.\nUse separate iterations.", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (containConsumablePartsAndKits)
                {
                    MessageBox.Show("You can not move details along with consumable parts and kits.\nUse separate iterations.", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    form = new MoveDetailForm(storeDetailsViewer.SelectedItems, MoveDetailFormMode.MoveToAircraft,  null);
            }
            form.ShowDialog();
        }

        #endregion

        #region private void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)

        private void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)
        {
            MoveDetailForm form = new MoveDetailForm(storeDetailsViewer.SelectedItems, MoveDetailFormMode.MoveToStore, currentStore);
            form.ShowDialog();
        }

        #endregion

        #region private void toolStripMenuItemADStatus_Click(object sender, EventArgs e)

        private void toolStripMenuItemADStatus_Click(object sender, EventArgs e)
        {
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail) storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (storeDetailsViewer.SelectedItem is AircraftFrame)
            {
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + DirectiveTypeCollection.Instance.ADDirectiveType.CommonName;
                args.RequestedEntity = new DispatcheredADStatusView(baseDetail.ParentAircraft);
            }
            else
            {
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + DirectiveTypeCollection.Instance.ADDirectiveType.CommonName;
                args.RequestedEntity = new DispatcheredADStatusView(baseDetail);
            }
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemEngineeringOrders_Click(object sender, EventArgs e)

        private void toolStripMenuItemEngineeringOrders_Click(object sender, EventArgs e)
        {
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName;
            else
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName;
            args.RequestedEntity = new DispatcheredEngeneeringOrdersDirectiveListScreen(baseDetail);
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemDiscrepancies_Click(object sender, EventArgs e)

        private void toolStripMenuItemDiscrepancies_Click(object sender, EventArgs e)
        {
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". Aircraft Frame SN " + baseDetail.SerialNumber + ". Discrepancies";
            else
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". Discrepancies";
            args.RequestedEntity = new DispatcheredDiscrepanciesScreen(baseDetail);
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemLLPDiskSheetStatus_Click(object sender, EventArgs e)

        private void toolStripMenuItemLLPDiskSheetStatus_Click(object sender, EventArgs e)
        {
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". LLP Disk Sheet Status";
            DetailCollectionFilter filter = new DetailCollectionFilter(new DetailFilter[] { new EngineLLPFilter(baseDetail) });
            LLPStatusReportBuilder reportBuilder = new LLPStatusReportBuilder((Engine)baseDetail);

            DispatcheredComponentStatusScreen dispatcheredComponentStatusScreen = new DispatcheredComponentStatusScreen(baseDetail, filter, reportBuilder);
            dispatcheredComponentStatusScreen.StatusText = baseDetail + ". LLP Disk Sheet Status";
            dispatcheredComponentStatusScreen.Status = (Statuses)baseDetail.ConditionState;
            args.RequestedEntity = dispatcheredComponentStatusScreen;
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemSBStatus_Click(object sender, EventArgs e)

        private void toolStripMenuItemSBStatus_Click(object sender, EventArgs e)
        {
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
            {
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + DirectiveTypeCollection.Instance.SBDirectiveType.CommonName;
                args.RequestedEntity = new DispatcheredSBStatusView(baseDetail.ParentAircraft);
            }
            else
            {
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + DirectiveTypeCollection.Instance.SBDirectiveType.CommonName;
                args.RequestedEntity = new DispatcheredSBStatusView(baseDetail);
            }
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemLogBook_Click(object sender, EventArgs e)

        private void toolStripMenuItemLogBook_Click(object sender, EventArgs e)
        {
/*
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            if (baseDetail is AircraftFrame)
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". Log Book";    
            else
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". Log Book";
            args.RequestedEntity = new DispatcheredBaseDetailLogBookScreen(baseDetail);
            OnDisplayerRequested(args);
*/
        }

        #endregion


        #region protected void OnAddRecord(RecordType recordType)

        /// <summary>
        /// Добавление записи для данного агрегата   
        /// </summary>
        /// <param name="recordType"></param>
        protected void OnAddRecord(RecordType recordType)
        {
/*            FormAddRecord formAddRecords = new FormAddRecord(storeDetailsViewer.SelectedItems, ScreenMode.Add, DetailRecordFormView.Compliance);
            formAddRecords.WorkType = recordType;
            if (formAddRecords.ShowDialog() == DialogResult.OK)
            {
                currentStore.LocalReload();
            }
            UpdateInformation();*/
        }

        #endregion

        #region public void CloseFilter()

        /// <summary>
        /// Закрытие формы выбора фильтра
        /// </summary>
        public void CloseFilter()
        {
         //   filterSelection.Close();
        }

        #endregion




        #region private void UnHookDetails()

        private void UnHookDetails()
        {
            AbstractDetail[] details = storeDetailsViewer.GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                UnHookDetail(details[i]);
            }
        }
        
        #endregion

        #region private void UnHookDetail(AbstractDetail detail)

        private void UnHookDetail(AbstractDetail detail)
        {
            detail.Saving -= detail_Saving;
            detail.Saved -= detail_Saved;
            detail.Reloading -= detail_Reloading;
            detail.Reloaded -= detail_Reloaded;

        }

        #endregion

        #region private void HookDetails()

        private void HookDetails()
        {
            AbstractDetail[] details = storeDetailsViewer.GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                UnHookDetail(details[i]);
                HookDetail(details[i]);
            }
        }

        #endregion

        #region private void HookDetail(AbstractDetail detail)

        private void HookDetail(AbstractDetail detail)
        {
            detail.Saving += detail_Saving;
            detail.Saved += detail_Saved;
            detail.Reloading += detail_Reloading;
            detail.Reloaded += detail_Reloaded;
        }

        #endregion

        #region private void HookDetailCollection()

        private void HookDetailCollection()
        {
            UnHookDetailCollection();
            if (currentStore != null)
            {
                currentStore.DetailRemoved += currentStore_DetailRemoved;
                currentStore.BaseDetailRemoved += currentStore_DetailRemoved;
                currentStore.DetailAdded += currentStore_DetailAdded;
                currentStore.BaseDetailAdded += currentStore_DetailAdded;
            }
            else
            {
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                {
                    currentOperator.Stores[i].DetailRemoved += currentStore_DetailRemoved;
                    currentOperator.Stores[i].BaseDetailRemoved += currentStore_DetailRemoved;
                    currentOperator.Stores[i].DetailAdded += currentStore_DetailAdded;
                    currentOperator.Stores[i].BaseDetailAdded += currentStore_DetailAdded;    
                }
            }
        }

        #endregion

        #region private void UnHookDetailCollection()

        private void UnHookDetailCollection()
        {
            if (currentStore != null)
            {
                currentStore.DetailRemoved -= currentStore_DetailRemoved;
                currentStore.BaseDetailRemoved -= currentStore_DetailRemoved;
                currentStore.DetailAdded -= currentStore_DetailAdded;
                currentStore.BaseDetailAdded -= currentStore_DetailAdded;
            }
            else
            {
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                {
                    currentOperator.Stores[i].DetailRemoved -= currentStore_DetailRemoved;
                    currentOperator.Stores[i].BaseDetailRemoved -= currentStore_DetailRemoved;
                    currentOperator.Stores[i].DetailAdded -= currentStore_DetailAdded;
                    currentOperator.Stores[i].BaseDetailAdded -= currentStore_DetailAdded;
                }
            }
        }

        #endregion

        #region private void detail_Saving(object sender, CancelEventArgs e)

        private void detail_Saving(object sender, CancelEventArgs e)
        {
            detailBeforeSave = (AbstractDetail)sender;
        }

        #endregion

        #region private void detail_Saved(object sender, EventArgs e)

        private void detail_Saved(object sender, EventArgs e)
        {
            storeDetailsViewer.EditItem(detailBeforeSave, (AbstractDetail)sender);
        }

        #endregion

        #region private void detail_Reloading(object sender, CancelEventArgs e)

        private void detail_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                detailBeforeReload = (AbstractDetail)sender;
        }

        #endregion

        #region private void detail_Reloaded(object sender, EventArgs e)

        private void detail_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                storeDetailsViewer.EditItem(detailBeforeReload, (AbstractDetail)sender);
        }

        #endregion

        #region private void currentStore_DetailAdded(object sender, CollectionChangeEventArgs e)

        private void currentStore_DetailAdded(object sender, CollectionChangeEventArgs e)
        {
            storeDetailsViewer.AddNewItem((AbstractDetail)e.Element);
            HookDetail((AbstractDetail)e.Element);
        }

        #endregion

        #region private void currentStore_DetailRemoved(object sender, CollectionChangeEventArgs e)

        private void currentStore_DetailRemoved(object sender, CollectionChangeEventArgs e)
        {
            storeDetailsViewer.DeleteItem((AbstractDetail)e.Element);
            UnHookDetail((AbstractDetail) e.Element);
        }

        #endregion



        #region private void StoreScreen_InitComplition(object sender, EventArgs e)

        private void StoreScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion
        
        #region private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            storeDetailsViewer.ItemsListView.Focus();
        }

        #endregion
        
        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookDetails();
                UnHookDetailCollection();
            }
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (buttonDeleteSelected != null)
                buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
            if (buttonAddDetail != null)
                buttonAddDetail.Location = new Point(buttonDeleteSelected.Left - buttonAddDetail.Width - 5, 0);
            if (buttonAddConsumablePartAndKit != null)
                buttonAddConsumablePartAndKit.Location = new Point(buttonAddDetail.Left - buttonAddConsumablePartAndKit.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonAddConsumablePartAndKit.Left - buttonApplyFilter.Width - 5, 0);

            if (storeDetailsViewer != null)
            {
                storeDetailsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                storeDetailsViewer.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #endregion

        #region IRefernce Members

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public DisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

        #endregion
    }
}