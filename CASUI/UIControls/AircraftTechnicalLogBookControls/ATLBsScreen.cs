using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftTechnicalLogBookControls;
using CAS.UI.Properties;
using CAS.UI.UIControls.Auxiliary;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Элемент управления для отображения списка бортовых журналов ВС
    /// </summary>
    [ToolboxItem(false)]
    public class ATLBsScreen : Control, IReference
    {

        #region Fields

        private Aircraft currentAircraft;
        private ATLB atlbBeforeSave;
        private ATLB atlbBeforeReload;

        private AircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonAddATLB;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private ATLBsListView ATLBsViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl;
        private Label labelModel;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel1;

        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemProperties;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        //private readonly bool permissionForUpdate = true;
        private readonly bool permissionForRemove = true;
        private readonly bool permissionForCreate = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка бортовых журналов ВС
        /// </summary>
        public ATLBsScreen(Aircraft aircraft)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display null-currentStore");
            ((DispatcheredATLBsScreen)this).InitComplition += ATLBsScreen_InitComplition;
            currentAircraft = aircraft;
            permissionForCreate = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Create);
            permissionForRemove = true;// currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Remove);
//            permissionForUpdate = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Update);
            InitializeComponent();
            HookATLBCollection();
            HookATLBs();
            UpdateInformation();
        }
        
        #endregion

        #region Properties

        #region public Statuses Status

        /// <summary>
        /// Возвращает или устанавливает статус 
        /// </summary>
        public Statuses Status
        {
            get { return statusImageLinkLabel1.Status; }
            set { statusImageLinkLabel1.Status = value; }
        }

        #endregion

        #region public string StatusText

        /// <summary>
        /// Возвращает или устанавливает текст статуса
        /// </summary>
        public string StatusText
        {
            get { return statusImageLinkLabel1.Text; }
            set { statusImageLinkLabel1.Text = value; }
        }

        #endregion

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

        #region public Aircraft Aircraft

        /// <summary>
        /// Текущее ВС
        /// </summary>
        public Aircraft Aircraft
        {
            get { return currentAircraft; }
            set
            {
                currentAircraft = value;
                UpdateInformation();
            }
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddATLB = new RichReferenceButton();
            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl(currentAircraft, true, true);
            statusImageLinkLabel1 = new StatusImageLinkLabel();
            labelModel = new Label();
            ATLBsViewer = new ATLBsListView(currentAircraft);

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemAdd,
                                                     toolStripMenuItemDelete,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemProperties
                                                 });
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Text = "Edit";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Text = "Add ATLB";
            toolStripMenuItemAdd.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripMenuItemProperties
            // 
            toolStripMenuItemProperties.Text = "Properties";
            toolStripMenuItemProperties.Click += toolStripMenuItemProperties_Click;

            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(labelModel);
            panelTopContainer.Controls.Add(statusImageLinkLabel1);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddATLB);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 14;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Visible = false;
            buttonApplyFilter.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;
            buttonApplyFilter.Size = new Size(145, 59);
            buttonApplyFilter.TabIndex = 19;
            buttonApplyFilter.TextMain = "Apply filter";
            //buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonAddATLB
            // 
            buttonAddATLB.Enabled = permissionForCreate;
            buttonAddATLB.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddATLB.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddATLB.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddATLB.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddATLB.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddATLB.Icon = icons.Add;
            buttonAddATLB.IconNotEnabled = icons.AddGray;
            buttonAddATLB.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddATLB.Size = new Size(152, 59);
            buttonAddATLB.TabIndex = 15;
            buttonAddATLB.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddATLB.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddATLB.TextMain = "Add new";
            buttonAddATLB.TextSecondary = "ATLB";
            buttonAddATLB.DisplayerRequested += buttonAddATLB_DisplayerRequested;
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
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.BackColor = Color.Transparent;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.EditDisplayerText = "Component Status Operator";
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            //headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.Location = new Point(0, 0);
            headerControl.Name = "headerControl";
            headerControl.Size = new Size(1042, 58);
            headerControl.TabIndex = 6;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl.ReloadRised += headerControl1_ReloadRised;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "component-status.html";
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
            statusImageLinkLabel1.Status = Statuses.Satisfactory;
            statusImageLinkLabel1.TabIndex = 16;
            statusImageLinkLabel1.Text = "Component Status";
            statusImageLinkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            statusImageLinkLabel1.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelModel.ForeColor = Color.DimGray;
            labelModel.Location = new Point(57, 30);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(47, 19);
            labelModel.TabIndex = 21;
            labelModel.Text = "Date as of: ";
            //
            // ATLBsViewer
            //
            ATLBsViewer.ContextMenuStrip = contextMenuStrip;
            ATLBsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            ATLBsViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            ATLBsViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(ATLBsViewer);
            Controls.Add(headerControl);
            Size = new Size(1042, 616);
        }



        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public void UpdateInformation()
        {
            statusImageLinkLabel1.Text = currentAircraft.RegistrationNumber + ". List of Aircraft Technical Log Books";
            labelModel.Text = currentAircraft.Model;
            ATLBsViewer.UpdateItems();
            HookATLBs();
            SetContextMenuParameters(ATLBsViewer.SelectedItems.Count);
            headerControl.ContextActionControl.ButtonPrint.Enabled = ATLBsViewer.ItemsListView.Items.Count > 0;
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

            currentAircraft.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

            UpdateInformation();
        }

        #endregion

       
        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl1_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void buttonAddATLB_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddATLB_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            ATLBForm form = new ATLBForm(currentAircraft);
            form.ShowDialog();
            e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((ATLBsViewer.SelectedItems == null) && (ATLBsViewer.SelectedItem == null))
                return;
            DialogResult confirmResult = MessageBox.Show(ATLBsViewer.SelectedItem != null
                        ? "Do you really want to delete ATLB " + ATLBsViewer.SelectedItem.ATLBNo + "?"
                        : "Do you really want to delete selected ATLBs? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = ATLBsViewer.SelectedItems.Count;


                try
                {

                    List<ATLB> selectedItems = new List<ATLB>(ATLBsViewer.SelectedItems);
                    ATLBsViewer.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        currentAircraft.RemoveATLB(selectedItems[i]);
                    }
                    ATLBsViewer.ItemsListView.EndUpdate();


                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }



                //ReloadElements();
            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            /*            StoreBuilder reportBuilder = new StoreBuilder();
                        reportBuilder.IsFiltered = filterSelection.GetDetailCollectionFilter().IsNonReportFilterApply;
                        reportBuilder.AddAdditionalInformation(currentStore);
                        reportBuilder.AddDetails(ATLBsViewer.GetItemsArray());
                        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        e.DisplayerText = "Store " + currentStore.RegistrationNumber + ". Report";
                        e.RequestedEntity = new DispatcheredStoreReport(reportBuilder);*/
            e.Cancel = true;
        }

        #endregion



        #region private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);
        }

        #endregion
        
        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            toolStripMenuItemTitle.Enabled = count > 0;
            buttonDeleteSelected.Enabled = 
            toolStripMenuItemDelete.Enabled = permissionForRemove && count > 0;
            toolStripMenuItemProperties.Enabled = count == 1;
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region private void OnViewEditScreen()

        private void OnViewEditScreen()
        {
            List<ATLB> selectedATLBs = ATLBsViewer.SelectedItems;
            for (int i = 0; i < selectedATLBs.Count; i++)
            {
                DispatcheredATLBFlightsScreen requestedEntity = new DispatcheredATLBFlightsScreen(selectedATLBs[i]);
                OnDisplayerRequested(new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew,
                                           currentAircraft.RegistrationNumber + ". ATLB No " + selectedATLBs[i].ATLBNo));
            }
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ATLBForm form = new ATLBForm(currentAircraft);
            form.ShowDialog();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            ATLBForm form = new ATLBForm(ATLBsViewer.SelectedItem);
            form.ShowDialog();
        }

        #endregion



        #region private void UnHookATLBs()

        private void UnHookATLBs()
        {
            ATLB[] atlbs = ATLBsViewer.GetItemsArray();
            for (int i = 0; i < atlbs.Length; i++)
            {
                UnHookATLB(atlbs[i]);
            }
        }
        
        #endregion

        #region private void UnHookATLB(CoreType atlb)

        private void UnHookATLB(CoreType atlb)
        {
            atlb.Saving -= atlb_Saving;
            atlb.Saved -= atlb_Saved;
            atlb.Reloading -= atlb_Reloading;
            atlb.Reloaded -= atlb_Reloaded;

        }

        #endregion

        #region private void HookATLBs()

        private void HookATLBs()
        {
            ATLB[] atlbs = ATLBsViewer.GetItemsArray();
            for (int i = 0; i < atlbs.Length; i++)
            {
                UnHookATLB(atlbs[i]);
                HookATLB(atlbs[i]);
            }
        }

        #endregion

        #region private void HookATLB(CoreType atlb)

        private void HookATLB(CoreType atlb)
        {
            atlb.Saving += atlb_Saving;
            atlb.Saved += atlb_Saved;
            atlb.Reloading += atlb_Reloading;
            atlb.Reloaded += atlb_Reloaded;
        }

        #endregion

        #region private void HookATLBCollection()

        private void HookATLBCollection()
        {
            UnHookATLBCollection();
            currentAircraft.ATLBAdded += currentAircraft_ATLBAdded;
            currentAircraft.ATLBRemoved += currentAircraft_ATLBRemoved;
        }

        #endregion

        #region private void UnHookATLBCollection()

        private void UnHookATLBCollection()
        {
            currentAircraft.ATLBAdded -= currentAircraft_ATLBAdded;
            currentAircraft.ATLBRemoved -= currentAircraft_ATLBRemoved;
        }

        #endregion

        #region private void atlb_Saving(object sender, CancelEventArgs e)

        private void atlb_Saving(object sender, CancelEventArgs e)
        {
            atlbBeforeSave = (ATLB)sender;
        }

        #endregion

        #region private void atlb_Saved(object sender, EventArgs e)

        private void atlb_Saved(object sender, EventArgs e)
        {
            ATLBsViewer.EditItem(atlbBeforeSave, (ATLB)sender);
        }

        #endregion

        #region private void atlb_Reloading(object sender, CancelEventArgs e)

        private void atlb_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                atlbBeforeReload = (ATLB)sender;
        }

        #endregion

        #region private void atlb_Reloaded(object sender, EventArgs e)

        private void atlb_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                ATLBsViewer.EditItem(atlbBeforeReload, (ATLB)sender);
        }

        #endregion

        #region private void currentAircraft_ATLBAdded(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_ATLBAdded(object sender, CollectionChangeEventArgs e)
        {
            ATLBsViewer.AddNewItem((ATLB)e.Element);
            HookATLB((ATLB)e.Element);
        }

        #endregion

        #region private void currentAircraft_ATLBRemoved(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_ATLBRemoved(object sender, CollectionChangeEventArgs e)
        {
            ATLBsViewer.DeleteItem((ATLB)e.Element);
            UnHookATLB((ATLB)e.Element);
        }

        #endregion



        #region private void ATLBsScreen_InitComplition(object sender, EventArgs e)

        private void ATLBsScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion
        
        #region private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            ATLBsViewer.ItemsListView.Focus();
        }

        #endregion
        
        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookATLBs();
                UnHookATLBCollection();
            }
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
            if (buttonAddATLB != null)
                buttonAddATLB.Location = new Point(buttonDeleteSelected.Left - buttonAddATLB.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonAddATLB.Left - buttonApplyFilter.Width - 5, 0);

            if (ATLBsViewer != null)
            {
                ATLBsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                ATLBsViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion
        
        #endregion
    }
}