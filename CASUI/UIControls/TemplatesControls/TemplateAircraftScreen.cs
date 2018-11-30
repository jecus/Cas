using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Management;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.TemplatesControls.Forms;
using Controls.AvMultitabControl.Auxiliary;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения шаблонного ВС
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateAircraftScreen : UserControl
    {

        #region Fields

        private TemplateAircraftHeaderControl aircraftHeader;
        private TemplateAircraftInfoReference aircraftInfoReference;
        private TemplateAircraftReferencesControl aircraftReferencesControl1;
        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;
        /// <summary>
        /// Текущее ВС
        /// </summary>
        protected TemplateAircraft currentAircraft;
        private TemplateBaseDetailControl aircraftFrameControl;
        private TemplateBaseDetailControl[] enginesControls = new TemplateBaseDetailControl[0];
        private TemplateBaseDetailControl apuControl;
        private TemplateLandingGearsButtonsControl landingGearsButtons;
        private FlowLayoutPanel flowLayoutPanelBaseDetailsContainer;
        private FooterControl footerControl;
        private HeaderControl headerControl;
        private Panel mainPanel;
        private ReferenceStatusImageLinkLabel linkLandingGearStatus;
        private TableLayoutPanel tableLayoutPanelReferences;
        private readonly Icons icons = new Icons();
        private RichReferenceButton buttonDeleteTemplate;
        private AvButtonT buttonAddBaseDetail;
        private RichReferenceButton buttonAddTemplate;
        private bool permissionForDelete = false;
        private const int BOTTOM_MARGIN = 60;
        private const int LANDING_GEAR_STATUS_LINK_MARGIN = 17;
        private const int REFERENCES_WIDTH = 400;
        private const int REFERENCES_HEIGHT = 800;
        private const int LANDING_GEAR_INTERVAL = 50;

        #endregion

        #region Constructor

        /// <summary>
        /// Создаёт экземпляр элемента управления, отображающего шаблонное воздушное судно
        /// </summary>
        ///<param name="aircraft">Шаблонное воздушное судно для отображения</param>
        public TemplateAircraftScreen(TemplateAircraft aircraft)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display null-aircraft");
            ((DispatcheredTemplateAircraftScreen)this).InitComplition += AircraftScreen_InitComplition;
            currentAircraft = aircraft;
            HookEvents();
            InitializeComponent();
            
            UpdateHeader();
            UpdateAircraft(false);
        }

        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        /// <summary>
        /// Semiautomatically generated code
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelReferences = new TableLayoutPanel();
            mainPanel = new Panel();
            flowLayoutPanelBaseDetailsContainer = new FlowLayoutPanel();
            aircraftReferencesControl1 = new TemplateAircraftReferencesControl();
            aircraftInfoReference = new TemplateAircraftInfoReference(currentAircraft);
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new TemplateAircraftHeaderControl(currentAircraft, true, false);
            buttonAddTemplate = new RichReferenceButton();
            buttonDeleteTemplate = new RichReferenceButton();
            buttonAddBaseDetail = new AvButtonT();
            aircraftFrameControl = new TemplateBaseDetailControl(currentAircraft.AircraftFrame);
            landingGearsButtons = new TemplateLandingGearsButtonsControl(currentAircraft);
            linkLandingGearStatus = new ReferenceStatusImageLinkLabel();
            permissionForDelete = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Remove);
            // 
            // tableLayoutPanelReferences
            // 
            tableLayoutPanelReferences.AutoSize = true;
            tableLayoutPanelReferences.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelReferences.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReferences.Controls.Add(aircraftReferencesControl1, 0, 0);
            tableLayoutPanelReferences.Controls.Add(aircraftInfoReference, 0, 1);
            tableLayoutPanelReferences.Location = new Point(0, 0);
            tableLayoutPanelReferences.Margin = new Padding(10);
            tableLayoutPanelReferences.RowStyles.Add(new RowStyle());
            tableLayoutPanelReferences.RowStyles.Add(new RowStyle());
            tableLayoutPanelReferences.RowStyles.Add(new RowStyle());
            tableLayoutPanelReferences.MinimumSize = new Size(REFERENCES_WIDTH, REFERENCES_HEIGHT);
            tableLayoutPanelReferences.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(flowLayoutPanelBaseDetailsContainer);
            mainPanel.Controls.Add(tableLayoutPanelReferences);
            mainPanel.Controls.Add(landingGearsButtons);
            mainPanel.Controls.Add(linkLandingGearStatus);
            mainPanel.Controls.Add(buttonAddBaseDetail);
            mainPanel.Controls.Add(buttonDeleteTemplate);
            mainPanel.Controls.Add(buttonAddTemplate);
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.SizeChanged += mainPanel_SizeChanged;
            // 
            // flowLayoutPanelBaseDetailsContainer
            // 
            flowLayoutPanelBaseDetailsContainer.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelBaseDetailsContainer.AutoScroll = true;
            flowLayoutPanelBaseDetailsContainer.AutoSize = true;
            flowLayoutPanelBaseDetailsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelBaseDetailsContainer.Location = new Point(REFERENCES_WIDTH, 0);
            flowLayoutPanelBaseDetailsContainer.Padding = new Padding(0, 27, 0, 0);
            flowLayoutPanelBaseDetailsContainer.TabIndex = 1;
            flowLayoutPanelBaseDetailsContainer.SizeChanged += flowLayoutPanelContentContainer_SizeChanged;
            flowLayoutPanelBaseDetailsContainer.Controls.Add(aircraftFrameControl);
            // 
            // aircraftReferencesControl1
            // 
            aircraftReferencesControl1.AutoSize = true;
            aircraftReferencesControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftReferencesControl1.BackColor = Css.CommonAppearance.Colors.BackColor;
            aircraftReferencesControl1.Caption = "Aircraft references";
            aircraftReferencesControl1.DescriptionTextColor = Color.DimGray;
            aircraftReferencesControl1.Dock = DockStyle.Top;
            aircraftReferencesControl1.Location = new Point(30, 30);
            aircraftReferencesControl1.Margin = new Padding(30, 30, 3, 3);
            aircraftReferencesControl1.MinimumSize = new Size(50, 50);
            aircraftReferencesControl1.Size = new Size(362, 528);
            aircraftReferencesControl1.TabIndex = 0;
            aircraftReferencesControl1.UpperLeftIcon = icons.GrayArrow;
            aircraftReferencesControl1.LinkADStatusDisplayerRequested += linkADStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkAgingProgramDisplayerRequested += linkAgingProgram_DisplayerRequested;
            aircraftReferencesControl1.LinkAircraftGeneralDataDisplayerRequested += linkAircraftGeneralData_DisplaeyRequested;
            aircraftReferencesControl1.LinkComponentStatusDisplayerRequested += linkComponentStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkCPCPStatusDisplayerRequested += linkCPCPStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkLandingGearStatusDisplayerRequested += LinkLandingGearStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkMaintenanceStatusDisplayerRequested += linkMaintenanceStatusDisplayerRequested;
            aircraftReferencesControl1.LinkSBStatusDisplayerRequested += linkSBStatus_DisplayerRequested;
            // 
            // aircraftInfoReference
            // 
            aircraftInfoReference.AutoSize = true;
            aircraftInfoReference.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftInfoReference.BackColor = Css.CommonAppearance.Colors.BackColor;
            aircraftInfoReference.Caption = "Aircraft information";
            aircraftInfoReference.DescriptionTextColor = Color.DimGray;
            aircraftInfoReference.Margin = new Padding(30, 15, 30, 3);
            aircraftInfoReference.MinimumSize = new Size(50, 50);
            aircraftInfoReference.TabIndex = 1;
            aircraftInfoReference.UpperLeftIcon = icons.GrayArrow;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            // 
            // headerControl
            // 
            headerControl.Controls.Add(aircraftHeader);
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.EditDisplayerRequested += linkAircraftGeneralData_DisplaeyRequested;
            headerControl.ActionControl.ShowEditButton = true;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "entering_an_aircraft_to_the_cas_database";
            //
            // buttonAddBaseDetail
            //
            buttonAddBaseDetail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddBaseDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddBaseDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddBaseDetail.Icon = icons.Add;
            buttonAddBaseDetail.IconNotEnabled = icons.AddGray;
            buttonAddBaseDetail.Width = 160;
            buttonAddBaseDetail.TextMain = "Add Base Component";
            buttonAddBaseDetail.Click += buttonAddBaseDetail_Click;
            //
            // buttonDeleteTemplate
            //
            buttonDeleteTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDeleteTemplate.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteTemplate.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteTemplate.Icon = icons.Delete;
            buttonDeleteTemplate.IconNotEnabled = icons.DeleteGray;
            buttonDeleteTemplate.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteTemplate.Width = 150;
            buttonDeleteTemplate.Location = new Point(mainPanel.Right - buttonDeleteTemplate.Width, mainPanel.Bottom - buttonDeleteTemplate.Height - BOTTOM_MARGIN);
            buttonDeleteTemplate.TextMain = "Delete Template";
            buttonDeleteTemplate.DisplayerRequested += buttonDeleteTemplate_DisplayerRequested;
            buttonDeleteTemplate.Visible = permissionForDelete;
            //
            // buttonAddTemplate
            //
            buttonAddTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddTemplate.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddTemplate.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddTemplate.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddTemplate.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddTemplate.Icon = icons.Add;
            buttonAddTemplate.IconNotEnabled = icons.AddGray;
            buttonAddTemplate.Width = 350;
            buttonAddTemplate.PaddingMain = new Padding(3, 0, 0, 0);
            buttonAddTemplate.TextAlignMain = ContentAlignment.BottomLeft;
            buttonAddTemplate.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonAddTemplate.TextMain = "Add " + currentAircraft.Model;
            if (OperatorCollection.Instance.Count == 1)
                buttonAddTemplate.TextSecondary = " to " + OperatorCollection.Instance[0].Name;
            else
                buttonAddTemplate.TextSecondary = " to operator";
            buttonAddTemplate.DisplayerRequested += buttonAddTemplate_DisplayerRequested;
            //
            // linkLandingGearStatus
            //
            Css.ImageLink.Adjust(linkLandingGearStatus);
            linkLandingGearStatus.Margin = new Padding(1);
            linkLandingGearStatus.Size = new Size(300, 30);
            linkLandingGearStatus.Text = "View Landing Gear Status";
            linkLandingGearStatus.TextAlign = ContentAlignment.MiddleLeft;
            linkLandingGearStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLandingGearStatus.DisplayerRequested += LinkLandingGearStatus_DisplayerRequested;
            linkLandingGearStatus.Enabled = true;
            //
            // aircraftFrameControl
            //
            aircraftFrameControl.TabIndex = 0;
            //
            // landingGearsButtons
            //
            landingGearsButtons.LocationChanged += landingGearsButtons_LocationChanged;
            landingGearsButtons.SizeChanged += landingGearsButtons_SizeChanged;
            // 
            // TemplateAircraftScreen
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region private void UpdateAircraft()

        private void UpdateAircraft()
        {
            UpdateAircraft(true);
        }

        #endregion

        #region private void UpdateAircraft(bool reloadAircraft)

        private void UpdateAircraft(bool reloadAircraft)
        {

            try
            {
                if (reloadAircraft)
                    {
                        currentAircraft.Reload(true);
                    }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            UnHookBaseDetailEvents();
            UpdateHeader();
            aircraftInfoReference.UpdateData();
            
            if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(apuControl))
                flowLayoutPanelBaseDetailsContainer.Controls.Remove(apuControl);
            for (int i = 0; i < enginesControls.Length; i++)
            {
                if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(enginesControls[i]))
                    flowLayoutPanelBaseDetailsContainer.Controls.Remove(enginesControls[i]);
            }

            aircraftFrameControl.UpdateInformation();
            List<TemplateEngine> engines = new List<TemplateEngine>();
            engines.AddRange(currentAircraft.Engines);
            engines.Sort(new TemplateEnginePositionSerialNumberComparerDesc());
            enginesControls = new TemplateBaseDetailControl[engines.Count];
            flowLayoutPanelBaseDetailsContainer.AutoSize = false;
            for (int i = 0; i < engines.Count; i++)
            {
                if (engines[i] != null)
                {
                    enginesControls[i] = new TemplateBaseDetailControl(engines[i]);
                    enginesControls[i].TabIndex = engines.Count - i;
                    enginesControls[i].Tag = engines[i];
                    flowLayoutPanelBaseDetailsContainer.Controls.Add(enginesControls[i]);
                }
            }
            if (currentAircraft.Apu != null)
            {
                apuControl = new TemplateBaseDetailControl(currentAircraft.Apu);
                apuControl.Height = 50;
                apuControl.TabIndex = enginesControls.Length + 1;
                flowLayoutPanelBaseDetailsContainer.Controls.Add(apuControl);
            }
            flowLayoutPanelBaseDetailsContainer.AutoSize = true;
            landingGearsButtons.UpdateInformation();
            HookBaseDetailEvents();
/*                aircraftInfoReference.UpdateData();
            if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(aircraftFrameControl))
                flowLayoutPanelBaseDetailsContainer.Controls.Remove(aircraftFrameControl);
            if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(apuControl))
                flowLayoutPanelBaseDetailsContainer.Controls.Remove(apuControl);
            if (enginesControls != null)
            {
                for (int i = 0; i < enginesControls.Length; i++)
                {
                    if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(enginesControls[i]))
                        flowLayoutPanelBaseDetailsContainer.Controls.Remove(enginesControls[i]);
                }
            }
            if (currentAircraft.TemplateAircraftContainer != null)
            {
                aircraftFrameControl = new TemplateBaseDetailControl(currentAircraft.TemplateAircraftContainer);
                aircraftFrameControl.Dock = DockStyle.Top;
                aircraftFrameControl.TabIndex = 0;
            }
            List<TemplateEngine> engines = new List<TemplateEngine>();
            engines.AddRange(currentAircraft.Engines);
            engines.Sort(new TemplateEnginePositionSerialNumberComparerDesc());
            enginesControls = new TemplateBaseDetailControl[engines.Count];
            for (int i = 0; i < engines.Count; i++)
            {
                if (engines[i] != null)
                {
                    enginesControls[i] = new TemplateBaseDetailControl(engines[i]);
                    enginesControls[i].Dock = DockStyle.Top;
                    enginesControls[i].TabIndex = engines.Count - i;
                }
            }
            if (currentAircraft.Apu != null)
            {
                apuControl = new TemplateBaseDetailControl(currentAircraft.Apu);
                apuControl.Dock = DockStyle.Top;
                apuControl.TabIndex = enginesControls.Length + 1;
            }

/*
            if (currentAircraft.GearAssembly != null) //todo массив GearAssembly
            {
                landingGearsButtons = new TemplateLandingGearsButtonsControl(new TemplateDetail[] {});// currentAircraft.GearAssembly);
                landingGearsButtons.Dock = DockStyle.Top;
                landingGearsButtons.BackColor = Color.Transparent;
                landingGearsButtons.TabIndex = enginesControls.Length + 2;
            }
*/

     /*       flowLayoutPanelBaseDetailsContainer.Controls.Clear();


            flowLayoutPanelBaseDetailsContainer.Controls.Add(landingGearsButtons);
            flowLayoutPanelBaseDetailsContainer.Controls.Add(apuControl);
            flowLayoutPanelBaseDetailsContainer.Controls.AddRange(enginesControls);
            flowLayoutPanelBaseDetailsContainer.Controls.Add(aircraftFrameControl);

            paddingPanel.SendToBack();

            headerControl.ActionControl.ButtonEdit.Enabled =
                currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);*/
        }

        #endregion

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeader.Aircraft = currentAircraft;
        }

        #endregion


        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            flowLayoutPanelBaseDetailsContainer.Visible = false;
            UpdateAircraft();
            flowLayoutPanelBaseDetailsContainer.Visible = true;
        }

        #endregion

        #region private void buttonAddTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayFewPages;

            TemplateAircraftAddToDataBaseForm form = new TemplateAircraftAddToDataBaseForm(currentAircraft);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ScreensToOpening == ScreensToOpening.OpenAircraftScreen)
                {
                    e.RequestedDisplayingObject = new DisplayingObject[]
                        {
                            new DisplayingObject(new DispatcheredAircraftCollectionScreen(form.Operator),
                                                 form.Operator.Name),
                            new DisplayingObject(new DispatcheredAircraftScreen(form.TransferedAircraft),
                                                 form.Operator.Name + ". " + form.TransferedAircraft.RegistrationNumber)
                        };
                }
                else if (form.ScreensToOpening == ScreensToOpening.EditAircraftGeneralData)
                {
                    e.RequestedDisplayingObject = new DisplayingObject[]
                        {
                            new DisplayingObject(new DispatcheredAircraftCollectionScreen(form.Operator),
                                                 form.Operator.Name),
                            new DisplayingObject(new DispatcheredAircraftScreen(form.TransferedAircraft),
                                                 form.Operator.Name + ". " + form.TransferedAircraft.RegistrationNumber),
                            new DisplayingObject(new DispatcheredAircraftGeneralDataScreen(form.TransferedAircraft),
                                                 form.TransferedAircraft.RegistrationNumber + ". Aircraft General Data")
                        };
                }
                else e.Cancel = true;
            }
            else e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current template aircraft?", "Confirm deleting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    TemplateAircraftCollection.Instance.Remove(currentAircraft);
                        MessageBox.Show("Template aircraft was deleted successfully", "Template aircraft deleted",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        
        #endregion

        #region private void buttonAddBaseDetail_Click(object sender, EventArgs e)

        private void buttonAddBaseDetail_Click(object sender, EventArgs e)
        {
            TemplateAddBaseDetailForm form = new TemplateAddBaseDetailForm(currentAircraft);
            form.Closed += TemplateAddBaseDetailForm_Closed;
            form.ShowDialog();
        }

        #endregion

        #region private void TemplateAddBaseDetailForm_Closed(object sender, EventArgs e)

        private void TemplateAddBaseDetailForm_Closed(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            if (form.DialogResult == DialogResult.OK)
                UpdateAircraft();
        }

        #endregion

        

        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Templates. " + currentAircraft.Model + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
            e.DisplayerText = currentAircraft.Model + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredTemplateADDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Templates. " + currentAircraft.Model + ". " + directiveTypeCollection.AgineProgramDirectiveType.CommonName;
            e.DisplayerText = currentAircraft.Model + ". " + directiveTypeCollection.AgineProgramDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredTemplateAgingProgramDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void linkAircraftGeneralData_DisplaeyRequested(object sender, ReferenceEventArgs e)

        private void linkAircraftGeneralData_DisplaeyRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Templates. " + currentAircraft.Model + ". Aircraft General Data";
            e.DisplayerText = currentAircraft.Model + ". Aircraft General Data";
            e.RequestedEntity = new DispatcheredTemplateAircraftGeneralDataScreen(currentAircraft);
        }

        #endregion

        #region private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
           // e.DisplayerText = "Templates. " + currentAircraft.Model + ". Component Status";
            e.DisplayerText = currentAircraft.Model + ". Component Status";
            e.RequestedEntity = new DispatcheredTemplateDetailListScreen(currentAircraft);
        }

        #endregion

        #region private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
           // e.DisplayerText = "Templates. " + currentAircraft.Model + ". " + directiveTypeCollection.CPCPDirectiveType.CommonName;
            e.DisplayerText = currentAircraft.Model + ". " + directiveTypeCollection.CPCPDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredTemplateCPCPDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void linkMaintenanceStatusDisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMaintenanceStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Templates. " + currentAircraft.Model + ". Maintenance Status";
            e.DisplayerText = currentAircraft.Model + ". Maintenance Status";
            e.RequestedEntity = new DispatcheredTemplateMaintenanceStatusScreen(currentAircraft);
        }

        #endregion

        #region private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Templates. " + currentAircraft.Model + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
            e.DisplayerText = currentAircraft.Model + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredTemplateSBDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void LinkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.Model + ". Landing Gear Status";
            e.RequestedEntity = new DispatcheredTemplateDetailListScreen(currentAircraft, new TemplateDetailCollectionFilter(new TemplateDetailFilter[] {new TemplateAllDetailFilter()}), new TemplateDetailCollectionFilter(new TemplateDetailFilter[] {new TemplateLandingGearsFilter(true, true, true, true)}));
        }

        #endregion
        

        #region private void HookEvents()

        private void HookEvents()
        {
            currentAircraft.Saved += currentAircraft_Saved;
            currentAircraft.BaseDetailRemoved += currentAircraft_BaseDetailRemoved;
            currentAircraft.BaseDetailAdded += currentAircraft_BaseDetailAdded;
        }

        #endregion

        #region private void UnHookEvents()

        private void UnHookEvents()
        {
            currentAircraft.Saved -= currentAircraft_Saved;
            currentAircraft.BaseDetailRemoved -= currentAircraft_BaseDetailRemoved;
            currentAircraft.BaseDetailAdded -= currentAircraft_BaseDetailAdded;
        }

        #endregion

        #region private void HookBaseDetailEvents()

        private void HookBaseDetailEvents()
        {
            for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                currentAircraft.BaseDetails[i].Saved += BaseDetailSaved_Saved;
        }

        #endregion

        #region private void UnHookBaseDetailEvents()

        private void UnHookBaseDetailEvents()
        {
            for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                currentAircraft.BaseDetails[i].Saved -= BaseDetailSaved_Saved;
        }

        #endregion

        #region private void BaseDetailSaved_Saved(object sender, EventArgs e)

        private void BaseDetailSaved_Saved(object sender, EventArgs e)
        {
            TemplateBaseDetail baseDetail = (TemplateBaseDetail)sender;
            if (baseDetail is TemplateAircraftFrame)
                aircraftFrameControl.UpdateInformation();
            else if (baseDetail is TemplateEngine)
            {
                for (int i = 0; i < enginesControls.Length; i++)
                {
                    if (baseDetail.ID == ((TemplateEngine)enginesControls[i].Tag).ID)
                    {
                        enginesControls[i].UpdateInformation();
                        break;
                    }
                }
            }
            else if (baseDetail is TemplateAPU)
                apuControl.UpdateInformation();
            else if (baseDetail is TemplateGearAssembly)
                landingGearsButtons.UpdateInformation();
        }

        #endregion

        #region private void currentAircraft_Saved(object sender, EventArgs e)

        private void currentAircraft_Saved(object sender, EventArgs e)
        {
            aircraftInfoReference.UpdateData();
        }

        #endregion

        #region private void currentAircraft_BaseDetailAdded(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_BaseDetailAdded(object sender, CollectionChangeEventArgs e)
        {
            UpdateAircraft(false);
        }

        #endregion

        #region private void currentAircraft_BaseDetailRemoved(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_BaseDetailRemoved(object sender, CollectionChangeEventArgs e)
        {
            UpdateAircraft(false);
        }

        #endregion

        #region private void AircraftScreen_InitComplition(object sender, EventArgs e)

        private void AircraftScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookBaseDetailEvents();
                UnHookEvents();
            }
        }

        #endregion


        #region private void mainPanel_SizeChanged(object sender, EventArgs e)

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanelBaseDetailsContainer.MinimumSize = new Size(Width - REFERENCES_WIDTH - 20, 0);
            flowLayoutPanelBaseDetailsContainer.MaximumSize = new Size(Width - REFERENCES_WIDTH - 20, 800);
            buttonDeleteTemplate.Location = new Point(mainPanel.Right - buttonDeleteTemplate.Width, mainPanel.Bottom - buttonDeleteTemplate.Height - 60);
            buttonAddBaseDetail.Location = new Point(mainPanel.Right - buttonDeleteTemplate.Width - buttonAddBaseDetail.Width, mainPanel.Bottom - buttonAddBaseDetail.Height - BOTTOM_MARGIN);
            buttonAddTemplate.Location = new Point(mainPanel.Left, mainPanel.Bottom - buttonAddTemplate.Height - BOTTOM_MARGIN);
            buttonAddTemplate.BringToFront();
        }

        #endregion

        #region private void flowLayoutPanelBaseDetailsContainer_SizeChanged(object sender, EventArgs e)

        private void flowLayoutPanelContentContainer_SizeChanged(object sender, EventArgs e)
        {
            landingGearsButtons.Location = new Point(flowLayoutPanelBaseDetailsContainer.Left, flowLayoutPanelBaseDetailsContainer.Bottom + LANDING_GEAR_INTERVAL);
        }

        #endregion

        #region private void landingGearsButtons_LocationChanged(object sender, EventArgs e)

        private void landingGearsButtons_LocationChanged(object sender, EventArgs e)
        {
            linkLandingGearStatus.Location = new Point(landingGearsButtons.Left + LANDING_GEAR_STATUS_LINK_MARGIN, landingGearsButtons.Bottom);
        }

        #endregion

        #region private void landingGearsButtons_SizeChanged(object sender, EventArgs e)

        private void landingGearsButtons_SizeChanged(object sender, EventArgs e)
        {
            linkLandingGearStatus.Location = new Point(landingGearsButtons.Left + LANDING_GEAR_STATUS_LINK_MARGIN, landingGearsButtons.Bottom);
        }

        #endregion

        #endregion

    }
}
