using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ATLBs;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DiscrepanciesControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComplianceControls;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.ComponentChangeReport
{
    /// <summary>
    /// Элемент управления для отображения списка отклонений
    /// </summary>
    public class ComponentChangeScreen : UserControl, IReference
    {
    #region Fields

        private readonly Aircraft currentAircraft;

        private AircraftHeaderControl aircraftHeaderControl;
        private ComponentChangeListView componentChangeViewer;
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
        public ComponentChangeScreen(Aircraft aircraft)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display null-currentAircraft");
            ((DispatcheredComponentChangeScreen)this).InitComplition += ComponentChangeScreen_InitComplition;
            currentAircraft = aircraft;
            InitializeComponent();
            SetToolStripMenuItems();
            permissionForCreate = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Create);
            //permissionForRemove = currentAircraft.HasPermission(Users.CurrentUser.Role, DataEvent.Remove);
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
            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl(currentAircraft, true, true);
            statusImageLinkLabel1 = new StatusImageLinkLabel();
            labelDateFrom = new Label();
            dateTimePickerDateFrom = new DateTimePicker();
            labelDateTo = new Label();
            dateTimePickerDateTo = new DateTimePicker();
            buttonOK = new Button();
            componentChangeViewer = new ComponentChangeListView(currentAircraft);

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemHighlight = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            /*// 
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
            toolStripMenuItemHighlight.Text = "Highlight";*/
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
            panelTopContainer.Controls.Add(buttonOK);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 14;
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
            componentChangeViewer.ContextMenuStrip = contextMenuStrip;
            componentChangeViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            componentChangeViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            componentChangeViewer.SelectedItemsChanged += componentChangeViewer_SelectedItemsChanged;
            componentChangeViewer.ItemsPasted += componentChangeViewer_ItemsPasted;
            componentChangeViewer.ItemsDeleted += buttonDeleteSelected_Click;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(componentChangeViewer);
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
            statusImageLinkLabel1.Text = "Component Change Report";//todo
            componentChangeViewer.records = GetTransferRecords();
            componentChangeViewer.UpdateItems();
            HookAircraftFlights();
            //SetContextMenuParameters(componentChangeViewer.SelectedItems.Count);
            headerControl.ContextActionControl.ButtonPrint.Enabled = componentChangeViewer.ItemsListView.Items.Count != 0;
        }

        #endregion

        #region private List<TransferRecord> GetTransferRecords()

        private List<TransferRecord> GetTransferRecords()
        {
            List<TransferRecord> allFlights = new List<TransferRecord>();
           for (int i = 0; i < currentAircraft.ContainedDetails.Length;i++ )
                allFlights.AddRange(currentAircraft.ContainedDetails[i].GetTransferRecords());
            List<TransferRecord> records = new List<TransferRecord>();
            for (int i = 0; i < allFlights.Count; i++)
            {
                if (allFlights[i].RecordDate >= dateTimePickerDateFrom.Value && allFlights[i].RecordDate <= dateTimePickerDateTo.Value)
                    records.Add(allFlights[i]);
            }
            return records;
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
           
            e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
          /* if ((componentChangeViewer.SelectedItems == null) && (componentChangeViewer.SelectedItem == null))
                return;
            DialogResult confirmResult = MessageBox.Show(componentChangeViewer.SelectedItem != null
                                                             ? "Do you really want to delete aircraft flight " + monthlyUtilizationViewer.SelectedItem.FlightNo + "?"
                                                             : "Do you really want to delete selected aircraft flights? ", "Confirm delete operation",
                                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = componentChangeViewer.SelectedItems.Count;
                List<TransferRecord> selectedItems = new List<TransferRecord>(componentChangeViewer.SelectedItems);
                try
                {
                    componentChangeViewer.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                        ((AbstractDetail)(selectedItems[i].Parent)).RemoveRecord();
                    componentChangeViewer.ItemsListView.EndUpdate();
                   // monthlyUtilizationViewer.UpdateItems(); // Этот метод вызываться не должен, а удаляться элемент из списка должен после возникновения соответсвтующего события, Алексей
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }

            }*/
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        
        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            componentChangeViewer.records.Sort(new TransferRecordComparer());
            ComponentChangeReportBuilder reportBuilder = new ComponentChangeReportBuilder(currentAircraft,componentChangeViewer.records.ToArray());
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)currentAircraft).RegistrationNumber + " Component Change Report";
            e.RequestedEntity = new DispatcheredComponentChangeReport(reportBuilder);

            //e.Cancel = true;
        }

        #endregion

        

        #region private void componentViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentChangeViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            //SetContextMenuParameters(e.ItemsCount);
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
           /* for (int i = 0; i < componentChangeViewer.SelectedItems.Count; i++)
            {
               componentChangeViewer.SelectedItems[i].Highlight = (Highlight)((ToolStripMenuItem)sender).Tag;
                try
                {
                    componentChangeViewer.SelectedItems[i].Save(true);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }
            }*/
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            TransferRecordForm form = new TransferRecordForm((AbstractDetail)componentChangeViewer.SelectedItem.Parent, componentChangeViewer.SelectedItem);
            form.Show();
        }

        #endregion

        #region private void componentChangeViewer_ItemsPasted(List<TransferRecord> pasteditems)

        private void componentChangeViewer_ItemsPasted(List<TransferRecord> pasteditems)
        {
            
        }

        #endregion
     
        #region private void UnHookAircraftFlights()

       private void UnHookAircraftFlights()
        {
           /* AircraftFlight[] aircraftFlights = monthlyUtilizationViewer.GetItemsArray();
            for (int i = 0; i < aircraftFlights.Length; i++)
            {
                UnHookAircraftFlight(aircraftFlights[i]);
            }*/
        }
        
        #endregion

        #region private void UnHookAircraftFlight(CoreType aircraftFlight)

        private void UnHookAircraftFlight(CoreType aircraftFlight)
        {
            //aircraftFlight.Saving -= aircraftFlight_Saving;
            //aircraftFlight.Saved -= aircraftFlight_Saved;
            //aircraftFlight.Reloading -= aircraftFlight_Reloading;
            aircraftFlight.Reloaded -= aircraftFlight_Reloaded;

        }

        #endregion

        #region private void HookAircraftFlights()

        private void HookAircraftFlights()
        {
            /*AircraftFlight[] aircraftFlights = monthlyUtilizationViewer.GetItemsArray();
            for (int i = 0; i < aircraftFlights.Length; i++)
            {
                UnHookAircraftFlight(aircraftFlights[i]);
                HookAircraftFlight(aircraftFlights[i]);
            }*/
        }

        #endregion

        #region private void HookAircraftFlight(CoreType aircraftFlight)

        private void HookAircraftFlight(CoreType aircraftFlight)
        {
            aircraftFlight.Saving += aircraftFlight_Saving;
            //aircraftFlight.Saved += aircraftFlight_Saved;
            //aircraftFlight.Reloading += aircraftFlight_Reloading;
            aircraftFlight.Reloaded += aircraftFlight_Reloaded;
        }

        #endregion

        #region private void HookAircraftFlightsCollection()

        private void HookAircraftFlightsCollection()
        {
            UnHookAircraftFlightsCollection();
            for (int i = 0; i < currentAircraft.ATLBs.Length; i++)
            {
               // currentAircraft.ATLBs[i].FlightAdded += currentATLB_AircraftFlightAdded;
               // currentAircraft.ATLBs[i].FlightRemoved += currentATLB_AircraftFlightRemoved;
            }
        }

        #endregion

        #region private void UnHookAircraftFlightsCollection()

        private void UnHookAircraftFlightsCollection()
        {
            for (int i = 0; i < currentAircraft.ATLBs.Length; i++)
            {
                //currentAircraft.ATLBs[i].FlightAdded -= currentATLB_AircraftFlightAdded;
                //currentAircraft.ATLBs[i].FlightRemoved -= currentATLB_AircraftFlightRemoved;
            }
        }

        #endregion

        #region private void aircraftFlight_Saving(object sender, CancelEventArgs e)

       private void aircraftFlight_Saving(object sender, CancelEventArgs e)
        {
           // aircraftFlightBeforeSave = (AircraftFlight)sender;
        }

        #endregion

        #region private void aircraftFlight_Saved(object sender, EventArgs e)

        /*private void aircraftFlight_Saved(object sender, EventArgs e)
        {
            monthlyUtilizationViewer.EditItem(aircraftFlightBeforeSave, (AircraftFlight)sender);
        }
*/
        #endregion

        #region private void DetailListScreen_Reloading(object sender, CancelEventArgs e)

       /* private void aircraftFlight_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                aircraftFlightBeforeReload = (AircraftFlight)sender;
        }*/

        #endregion

        #region private void DetailListScreen_Reloaded(object sender, EventArgs e)

        private void aircraftFlight_Reloaded(object sender, EventArgs e)
        {
           //if (!InvokeRequired)
             //   componentChangeViewer.EditItem(aircraftFlightBeforeReload, (AircraftFlight)sender);*/
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion
        
        #region private void ComponentChangeScreen_InitComplition(object sender, EventArgs e)

        private void ComponentChangeScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            //((AvMultitabControl)sender).Selected += componentChangeViewer_Selected;
        }

        #endregion

        #region private void ComponentChangeScreen_Selected(object sender, AvMultitabControlEventArgs e)


        private void ComponentChangeScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
           componentChangeViewer.ItemsListView.Focus();
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
            if (componentChangeViewer != null)
            {
                componentChangeViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                componentChangeViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion
        
        #endregion

        internal class TransferRecordComparer : IComparer<TransferRecord>
        {
            public int Compare(TransferRecord x, TransferRecord y)
            {
                return -DateTime.Compare(x.RecordDate, y.RecordDate);
            }
        }

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