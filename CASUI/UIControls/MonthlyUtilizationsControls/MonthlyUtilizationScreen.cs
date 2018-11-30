using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MonthlyUtilizationsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Properties;
using CASReports.Builders;
using CASReports.ReportTemplates;
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

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    /// <summary>
    /// Элемент управления для отображения бортового журнала ВС
    /// </summary>
    [ToolboxItem(false)]
    public class MonthlyUtilizationScreen : Control, IReference
    {

        #region Fields

        private readonly Aircraft currentAircraft;
        private AircraftFlight aircraftFlightBeforeSave;
        private AircraftFlight aircraftFlightBeforeReload;

        private AircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonRegisterFlight;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private MonthlyUtilizationView monthlyUtilizationViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl;
        private Label labelDateFrom;
        private DateTimePicker dateTimePickerDateFrom;
        private Label labelDateTo;
        private DateTimePicker dateTimePickerDateTo;
        private Button buttonOK;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel1;

        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuItemPaste;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemHighlight;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemProperties;

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private readonly bool permissionForCreate = true;
        //private readonly bool permissionForRemove = true;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения бортового журнала ВС
        /// </summary>
        public MonthlyUtilizationScreen(Aircraft aircraft)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display null-currentAircraft");
            ((DispatcheredMonthlyUtilizationScreen)this).InitComplition += MonthlyUtilizationScreen_InitComplition;
            currentAircraft = aircraft;
            InitializeComponent();
            SetToolStripMenuItems();
            permissionForCreate = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Create);
            //permissionForRemove = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Remove);
            HookAircraftFlightsCollection();
            HookAircraftFlights();
            UpdateInformation();
        }
        
        #endregion

        #region Properties

/*        #region public Statuses Status

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

        #endregion*/



/*        #region public Aircraft Aircraft

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

        #endregion*/

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
            aircraftHeaderControl = new AircraftHeaderControl(currentAircraft, true, true);
            statusImageLinkLabel1 = new StatusImageLinkLabel();
            labelDateFrom = new Label();
            dateTimePickerDateFrom = new DateTimePicker();
            labelDateTo = new Label();
            dateTimePickerDateTo = new DateTimePicker();
            buttonOK = new Button();
            monthlyUtilizationViewer = new MonthlyUtilizationView(currentAircraft);

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemHighlight = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Text = "Copy (Ctrl+C)";
            toolStripMenuItemCopy.Click += toolStripMenuItemCopy_Click;
            toolStripMenuItemCopy.Enabled = false;
            // 
            // toolStripMenuItemPaste
            // 
            toolStripMenuItemPaste.Text = "Paste (Ctrl+V)";
            toolStripMenuItemPaste.Click += toolStripMenuItemPaste_Click;
            toolStripMenuItemPaste.Enabled = false;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripMenuItemHighlight
            // 
            toolStripMenuItemHighlight.Text = "Highlight";
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
            panelTopContainer.Controls.Add(statusImageLinkLabel1);
            panelTopContainer.Controls.Add(labelDateFrom);
            panelTopContainer.Controls.Add(dateTimePickerDateFrom);
            panelTopContainer.Controls.Add(labelDateTo);
            panelTopContainer.Controls.Add(dateTimePickerDateTo);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonOK);
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
            statusImageLinkLabel1.LinkColor = Color.DimGray;
            statusImageLinkLabel1.Location = new Point(30, 3);
            statusImageLinkLabel1.Size = new Size(412, 27);
            statusImageLinkLabel1.Status = Statuses.Satisfactory;
            statusImageLinkLabel1.TabIndex = 16;
            statusImageLinkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            statusImageLinkLabel1.TextFont = Css.HeaderLinkLabel.Fonts.Font;
            // 
            // labelDateFrom
            // 
            labelDateFrom.AutoSize = true;
            labelDateFrom.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDateFrom.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateFrom.Location = new Point(32, 35);
            labelDateFrom.Text = "From";
            //
            // dateTimePickerDateFrom
            //
            dateTimePickerDateFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDateFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDateFrom.BackColor = Color.White;
            dateTimePickerDateFrom.Location = new Point(80, 32);
            dateTimePickerDateFrom.Width = 100; 
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateFrom.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            if (DateTime.Now.Month == 1)
                dateTimePickerDateFrom.Value = new DateTime(DateTime.Now.Year - 1, 12, 1);
            else
                dateTimePickerDateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDateTo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateTo.Location = new Point(190, 35);
            labelDateTo.Text = "to";
            //
            // dateTimePickerDateTo
            //
            dateTimePickerDateTo.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDateTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDateTo.BackColor = Color.White;
            dateTimePickerDateTo.Location = new Point(220, 32);
            dateTimePickerDateTo.Width = 100;
            dateTimePickerDateTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTo.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // buttonOK
            //
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonOK.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonOK.Location = new Point(340, 30);
            buttonOK.Width = 70;
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // monthlyUtilizationViewer
            //
            monthlyUtilizationViewer.ContextMenuStrip = contextMenuStrip;
            monthlyUtilizationViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            monthlyUtilizationViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            monthlyUtilizationViewer.SelectedItemsChanged += monthlyUtilizationViewer_SelectedItemsChanged;
            monthlyUtilizationViewer.ItemsPasted += monthlyUtilizationViewer_ItemsPasted;
            monthlyUtilizationViewer.ItemsDeleted += buttonDeleteSelected_Click;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(monthlyUtilizationViewer);
            Controls.Add(headerControl);
            Size = new Size(1042, 616);
        }

        #endregion

        #region private void SetToolStripMenuItems()

        private void SetToolStripMenuItems()
        {
            //contextMenuStrip.Items.Clear();
            //toolStripMenuItemHighlight.DropDownItems.Clear();
            for (int i = 0; i < HighlightCollection.Instance.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(HighlightCollection.Instance[i].FullName);
                item.Click += HighlightItem_Click;
                item.Tag = HighlightCollection.Instance[i];
                toolStripMenuItemHighlight.DropDownItems.Add(item);
            }
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemCopy,
                                                    toolStripMenuItemPaste,
                                                    toolStripMenuItemDelete,
                                                    toolStripSeparator1,
                                                    toolStripMenuItemHighlight,
                                                    toolStripSeparator2,
                                                    toolStripMenuItemProperties
                                                });
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public void UpdateInformation()
        {
            statusImageLinkLabel1.Text = "Monthly Utilization";//todo
            monthlyUtilizationViewer.Flights = GetFlights();
            monthlyUtilizationViewer.UpdateItems();
            HookAircraftFlights();
            SetContextMenuParameters(monthlyUtilizationViewer.SelectedItems.Count);
            headerControl.ContextActionControl.ButtonPrint.Enabled = monthlyUtilizationViewer.ItemsListView.Items.Count != 0;
        }

        #endregion

        #region private List<AircraftFlight> GetFlights()

        private List<AircraftFlight> GetFlights()
        {
            List<AircraftFlight> allFlights = new List<AircraftFlight>();
            for (int i = 0; i < currentAircraft.ATLBs.Length; i++)
                allFlights.AddRange(currentAircraft.ATLBs[i].Flights);
            List<AircraftFlight> flights = new List<AircraftFlight>();
            for (int i = 0; i < allFlights.Count; i++)
            {
                if (allFlights[i].FlightDate >= dateTimePickerDateFrom.Value && allFlights[i].FlightDate <= dateTimePickerDateTo.Value)
                    flights.Add(allFlights[i]);
            }
            return flights;
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
        
        #region private void buttonRegisterFlight_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonRegisterFlight_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            AircraftFlightForm form = new AircraftFlightForm(currentAircraft);
            form.Show();
            e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((monthlyUtilizationViewer.SelectedItems == null) && (monthlyUtilizationViewer.SelectedItem == null))
                return;
            DialogResult confirmResult = MessageBox.Show(monthlyUtilizationViewer.SelectedItem != null
                                                             ? "Do you really want to delete aircraft flight " + monthlyUtilizationViewer.SelectedItem.FlightNo + "?"
                                                             : "Do you really want to delete selected aircraft flights? ", "Confirm delete operation",
                                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = monthlyUtilizationViewer.SelectedItems.Count;
                List<AircraftFlight> selectedItems = new List<AircraftFlight>(monthlyUtilizationViewer.SelectedItems);
                try
                {
                    monthlyUtilizationViewer.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                        currentAircraft.RemoveFligth(selectedItems[i]);
                    monthlyUtilizationViewer.ItemsListView.EndUpdate();
                   // monthlyUtilizationViewer.UpdateItems(); // Этот метод вызываться не должен, а удаляться элемент из списка должен после возникновения соответсвтующего события, Алексей
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
            MonthlyUtilizationBuilder reportBuilder = new  MonthlyUtilizationBuilder(currentAircraft);
            reportBuilder.Flights = monthlyUtilizationViewer.SortedFlights;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)currentAircraft).RegistrationNumber + " Monthly Utilization Report";
            e.RequestedEntity = new DispatcheredMonthlyUtilizationReport(reportBuilder);

            //e.Cancel = true;
        }

        #endregion

        

        #region private void monthlyUtilizationViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void monthlyUtilizationViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);
        }

        #endregion
        
        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            buttonDeleteSelected.Enabled =
                toolStripMenuItemDelete.Enabled = count > 0;
            toolStripMenuItemProperties.Enabled = count == 1;
        }

        #endregion


        #region private void toolStripMenuItemCopy_Click(object sender, EventArgs e)

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region private void toolStripMenuItemPaste_Click(object sender, EventArgs e)

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void HighlightItem_Click(object sender, EventArgs e)

        private void HighlightItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < monthlyUtilizationViewer.SelectedItems.Count; i++)
            {
                monthlyUtilizationViewer.SelectedItems[i].Highlight = (Highlight)((ToolStripMenuItem)sender).Tag;
                try
                {
                    monthlyUtilizationViewer.SelectedItems[i].Save(true);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }
            }
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            AircraftFlightForm form = new AircraftFlightForm(monthlyUtilizationViewer.SelectedItem);
            form.Show();
        }

        #endregion
        
        #region private void monthlyUtilizationViewer_ItemsPasted(List<AircraftFlight> pasteditems)

        private void monthlyUtilizationViewer_ItemsPasted(List<AircraftFlight> pasteditems)
        {
            
        }

        #endregion


        


        #region private void UnHookAircraftFlights()

        private void UnHookAircraftFlights()
        {
            AircraftFlight[] aircraftFlights = monthlyUtilizationViewer.GetItemsArray();
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
            AircraftFlight[] aircraftFlights = monthlyUtilizationViewer.GetItemsArray();
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
            for (int i = 0; i < currentAircraft.ATLBs.Length; i++)
            {
                currentAircraft.ATLBs[i].FlightAdded += currentATLB_AircraftFlightAdded;
                currentAircraft.ATLBs[i].FlightRemoved += currentATLB_AircraftFlightRemoved;
            }
        }

        #endregion

        #region private void UnHookAircraftFlightsCollection()

        private void UnHookAircraftFlightsCollection()
        {
            for (int i = 0; i < currentAircraft.ATLBs.Length; i++)
            {
                currentAircraft.ATLBs[i].FlightAdded -= currentATLB_AircraftFlightAdded;
                currentAircraft.ATLBs[i].FlightRemoved -= currentATLB_AircraftFlightRemoved;
            }
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
            monthlyUtilizationViewer.EditItem(aircraftFlightBeforeSave, (AircraftFlight)sender);
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
                monthlyUtilizationViewer.EditItem(aircraftFlightBeforeReload, (AircraftFlight)sender);
        }

        #endregion

        #region private void currentATLB_AircraftFlightAdded(object sender, CollectionChangeEventArgs e)

        private void currentATLB_AircraftFlightAdded(object sender, CollectionChangeEventArgs e)
        {
            //monthlyUtilizationViewer.AddNewItem((AircraftFlight)e.Element);
            HookAircraftFlight((AircraftFlight)e.Element);
            UpdateInformation();
        }

        #endregion

        #region private void currentATLB_AircraftFlightRemoved(object sender, CollectionChangeEventArgs e)

        private void currentATLB_AircraftFlightRemoved(object sender, CollectionChangeEventArgs e)
        {
//            monthlyUtilizationViewer.DeleteItem((AircraftFlight)e.Element);
            UnHookAircraftFlight((AircraftFlight)e.Element);
            UpdateInformation();
        }

        #endregion



        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion
        
        #region private void MonthlyUtilizationScreen_InitComplition(object sender, EventArgs e)

        private void MonthlyUtilizationScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += MonthlyUtilizationScreen_Selected;
        }

        #endregion
        
        #region private void MonthlyUtilizationScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void MonthlyUtilizationScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
            monthlyUtilizationViewer.ItemsListView.Focus();
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

            if (monthlyUtilizationViewer != null)
            {
                monthlyUtilizationViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                monthlyUtilizationViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
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

        #region IReference Members

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

        #endregion

    }
}