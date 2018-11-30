using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftTechnicalLogBookControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Properties;
using CASReports.Builders;
using Controls.AvMultitabControl.Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using Controls.AvButtonT;
using Controls.StatusImageLink;
using Controls;
using Controls.AvMultitabControl;
using CASTerms;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Элемент управления для отображения бортового журнала ВС
    /// </summary>
    [ToolboxItem(false)]
    public class ATLBFlightsScreen : Control, IReference
    {

        #region Fields

        /// <summary>
        /// Текущий отображаемый бортовой журнал
        /// </summary>
        private ATLB currentATLB;
        private AircraftFlight aircraftFlightBeforeSave;
        private AircraftFlight aircraftFlightBeforeReload;

        private AircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonRegisterFlight;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private ATLBFlightsListView ATLBFlightsViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl;
        private Label labelDate;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel1;

        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemPrint;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private readonly bool permissionForCreate = true;
        private readonly bool permissionForRemove = true;
        //private readonly bool permissionForUpdate = true;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения бортового журнала ВС
        /// </summary>
        public ATLBFlightsScreen(ATLB atlb)
        {
            if (atlb == null)
                throw new ArgumentNullException("atlb", "Cannot display null-currentATLB");
            ((DispatcheredATLBFlightsScreen) this).InitComplition += ATLBFlightsScreen_InitComplition;
            currentATLB = atlb;
            InitializeComponent();
            permissionForCreate = currentATLB.HasPermission(Users.CurrentUser.Role, DataEvent.Create);
            permissionForRemove = currentATLB.HasPermission(Users.CurrentUser.Role, DataEvent.Remove);
            //permissionForUpdate = currentATLB.HasPermission(Users.CurrentUser.Role, DataEvent.Update);
            HookAircraftFlightsCollection();
            HookAircraftFlights();
            //filterSelection = new StoreDetailFilterSelectionForm(currentATLB);
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

        #region public ATLB ATLB

        /// <summary>
        /// Текущий бортовой журнал
        /// </summary>
        public ATLB ATLB
        {
            get { return currentATLB; }
            set
            {
                currentATLB = value;
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
            buttonRegisterFlight = new RichReferenceButton();
            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl((Aircraft)currentATLB.Parent, true, true);
            statusImageLinkLabel1 = new StatusImageLinkLabel();
            labelDate = new Label();
            ATLBFlightsViewer = new ATLBFlightsListView(currentATLB);

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripMenuItemPrint = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
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
                                                     toolStripMenuItemPrint

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
            toolStripMenuItemAdd.Text = "Add Aircraft Flight";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            //toolStripMenuItemAdd.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Enabled = false;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripMenuItemPrint
            // 
            toolStripMenuItemPrint.Text = "Print";
            toolStripMenuItemPrint.Click += toolStripMenuItemPrint_Click;

            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(labelDate);
            panelTopContainer.Controls.Add(statusImageLinkLabel1);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonRegisterFlight);
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
            // 
            // buttonAddDetail
            // 
            buttonRegisterFlight.Enabled = permissionForCreate;
            //buttonAddDetail.Enabled = true;
            buttonRegisterFlight.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonRegisterFlight.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonRegisterFlight.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonRegisterFlight.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonRegisterFlight.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonRegisterFlight.Icon = icons.Add;
            buttonRegisterFlight.IconNotEnabled = icons.AddGray;
            buttonRegisterFlight.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonRegisterFlight.Size = new Size(152, 59);
            buttonRegisterFlight.TabIndex = 15;
            buttonRegisterFlight.TextAlignMain = ContentAlignment.BottomCenter;
            buttonRegisterFlight.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonRegisterFlight.TextMain = "Register";
            buttonRegisterFlight.TextSecondary = "flight";
            buttonRegisterFlight.DisplayerRequested += buttonRegisterFlight_DisplayerRequested;
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
            headerControl.EditDisplayerRequested += headerControl1_EditDisplayerRequested;
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
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDate.ForeColor = Color.DimGray;
            labelDate.Location = new Point(57, 30);
            //
            // ATLBFlightsViewer
            //
            ATLBFlightsViewer.ContextMenuStrip = contextMenuStrip;
            ATLBFlightsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            ATLBFlightsViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            ATLBFlightsViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(ATLBFlightsViewer);
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
            statusImageLinkLabel1.Text = "Aircraft Technical Log Book: " + currentATLB.ATLBNo;
            labelDate.Text = "";
            ATLBFlightsViewer.UpdateItems();
            HookAircraftFlights();
            SetContextMenuParameters(ATLBFlightsViewer.SelectedItems.Count);
            headerControl.ContextActionControl.ButtonPrint.Enabled = ATLBFlightsViewer.ItemsListView.Items.Count != 0;
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

            currentATLB.Reload(true);
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
        
        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            ATLBForm form = new ATLBForm(currentATLB);
            form.ShowDialog();
            e.Cancel = true;
        }

        #endregion
        
        #region private void buttonRegisterFlight_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonRegisterFlight_DisplayerRequested(object sender, ReferenceEventArgs e)
        {

            Aircraft a = currentATLB.Parent as Aircraft;
            if (a != null)
            {
                AircraftFlight flight = a.ProposeNextFlight();
                // todo: Сергей Фролов, нужно сохранить Flight в открытом бортовом журнале (в гуях)
                //flight.ATLB = currentATLB;
                FlightDialog.Show(flight);
            }

            /*e.RequestedEntity = new DispatcheredDetailAddingScreen(currentATLB);
            e.DisplayerText = currentATLB.RegistrationNumber + ". New Component";*/
            e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((ATLBFlightsViewer.SelectedItems == null) && (ATLBFlightsViewer.SelectedItem == null))
                return;
            DialogResult confirmResult = MessageBox.Show(ATLBFlightsViewer.SelectedItem != null
                        ? "Do you really want to delete aircraft flight " + ATLBFlightsViewer.SelectedItem.FlightNo + "?"
                        : "Do you really want to delete selected aircraft flights? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = ATLBFlightsViewer.SelectedItems.Count;

                    try
                    {
                        List<AircraftFlight> selectedItems = new List<AircraftFlight>(ATLBFlightsViewer.SelectedItems);
                        ATLBFlightsViewer.ItemsListView.BeginUpdate();
                        Aircraft parent = (Aircraft) currentATLB.Parent;
                        for (int i = 0; i < count; i++)
                        {
                            parent.RemoveFligth(selectedItems[i]);
                        }
                        ATLBFlightsViewer.ItemsListView.EndUpdate();
                        ATLBFlightsViewer.UpdateItems(); // Этот метод вызываться не должен, а удаляться элемент из списка должен после возникновения соответсвтующего события, Алексей



                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }

            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            ATLBBuilder reportBuilder = new ATLBBuilder(currentATLB);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)currentATLB.Parent).RegistrationNumber + ". ATLB " + currentATLB.ATLBNo+ ". Report";
            e.RequestedEntity = new DispatcheredATLBReport(reportBuilder);
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
            toolStripMenuItemTitle.Enabled =
            toolStripMenuItemPrint.Enabled = count == 1;
            buttonDeleteSelected.Enabled =
            toolStripMenuItemDelete.Enabled = permissionForRemove && count > 0;

            //buttonDeleteSelected.Enabled = toolStripMenuItemDelete.Enabled = false; //todo
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            FlightDialog.Show(ATLBFlightsViewer.SelectedItem);
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            FlightDialog.Show(((Aircraft)currentATLB.Parent).ProposeNextFlight());
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemPrint_Click(object sender, EventArgs e)

        private void toolStripMenuItemPrint_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            args.DisplayerText = ((Aircraft)currentATLB.Parent).RegistrationNumber + ". ATLB No " + currentATLB.ATLBNo + ". Report";
            args.RequestedEntity = new DispatcheredATLBReport(new ATLBBuilder(ATLBFlightsViewer.SelectedItem));
            OnDisplayerRequested(args);
        }

        #endregion


        #region private void UnHookAircraftFlights()

        private void UnHookAircraftFlights()
        {
            AircraftFlight[] aircraftFlights = ATLBFlightsViewer.GetItemsArray();
            for (int i = 0; i < aircraftFlights.Length; i++)
            {
                UnHookAircraftFlight(aircraftFlights[i]);
            }
        }
        
        #endregion

        #region private void UnHookAircraftFlight(CoreType aircraftFlight)

        private void UnHookAircraftFlight(CoreType aircraftFlight)
        {
            aircraftFlight.Saving -= aircraftFlight_Saving;
            aircraftFlight.Saved -= aircraftFlight_Saved;
            aircraftFlight.Reloading -= aircraftFlight_Reloading;
            aircraftFlight.Reloaded -= aircraftFlight_Reloaded;

        }

        #endregion

        #region private void HookAircraftFlights()

        private void HookAircraftFlights()
        {
            AircraftFlight[] aircraftFlights = ATLBFlightsViewer.GetItemsArray();
            for (int i = 0; i < aircraftFlights.Length; i++)
            {
                UnHookAircraftFlight(aircraftFlights[i]);
                HookAircraftFlight(aircraftFlights[i]);
            }
        }

        #endregion

        #region private void HookAircraftFlight(CoreType aircraftFlight)

        private void HookAircraftFlight(CoreType aircraftFlight)
        {
            aircraftFlight.Saving += aircraftFlight_Saving;
            aircraftFlight.Saved += aircraftFlight_Saved;
            aircraftFlight.Reloading += aircraftFlight_Reloading;
            aircraftFlight.Reloaded += aircraftFlight_Reloaded;
        }

        #endregion

        #region private void HookAircraftFlightsCollection()

        private void HookAircraftFlightsCollection()
        {
            UnHookAircraftFlightsCollection();
            currentATLB.FlightAdded += currentATLB_AircraftFlightAdded;
            currentATLB.FlightRemoved += currentATLB_AircraftFlightRemoved;
        }

        #endregion

        #region private void UnHookAircraftFlightsCollection()

        private void UnHookAircraftFlightsCollection()
        {
            currentATLB.FlightAdded -= currentATLB_AircraftFlightAdded;
            currentATLB.FlightRemoved-= currentATLB_AircraftFlightRemoved;
        }

        #endregion

        #region private void aircraftFlight_Saving(object sender, CancelEventArgs e)

        private void aircraftFlight_Saving(object sender, CancelEventArgs e)
        {
            aircraftFlightBeforeSave = (AircraftFlight)sender;
        }

        #endregion

        #region private void aircraftFlight_Saved(object sender, EventArgs e)

        private void aircraftFlight_Saved(object sender, EventArgs e)
        {
            ATLBFlightsViewer.EditItem(aircraftFlightBeforeSave, (AircraftFlight)sender);
        }

        #endregion

        #region private void DetailListScreen_Reloading(object sender, CancelEventArgs e)

        private void aircraftFlight_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                aircraftFlightBeforeReload = (AircraftFlight)sender;
        }

        #endregion

        #region private void DetailListScreen_Reloaded(object sender, EventArgs e)

        private void aircraftFlight_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                ATLBFlightsViewer.EditItem(aircraftFlightBeforeReload, (AircraftFlight)sender);
        }

        #endregion

        #region private void currentATLB_AircraftFlightAdded(object sender, CollectionChangeEventArgs e)

        private void currentATLB_AircraftFlightAdded(object sender, CollectionChangeEventArgs e)
        {
            ATLBFlightsViewer.AddNewItem((AircraftFlight)e.Element);
            HookAircraftFlight((AircraftFlight)e.Element);
        }

        #endregion

        #region private void currentATLB_AircraftFlightRemoved(object sender, CollectionChangeEventArgs e)

        private void currentATLB_AircraftFlightRemoved(object sender, CollectionChangeEventArgs e)
        {
            ATLBFlightsViewer.DeleteItem((AircraftFlight)e.Element);
            UnHookAircraftFlight((AircraftFlight)e.Element);
        }

        #endregion



        #region private void ATLBFlightsScreen_InitComplition(object sender, EventArgs e)

        private void ATLBFlightsScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion
        
        #region private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            ATLBFlightsViewer.ItemsListView.Focus();
        }

        #endregion
        
        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookAircraftFlights();
                UnHookAircraftFlightsCollection();
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
            if (buttonRegisterFlight != null)
                buttonRegisterFlight.Location = new Point(buttonDeleteSelected.Left - buttonRegisterFlight.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonRegisterFlight.Left - buttonApplyFilter.Width - 5, 0);

            if (ATLBFlightsViewer != null)
            {
                ATLBFlightsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                ATLBFlightsViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion
        
        #endregion
    }
}
