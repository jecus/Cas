using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.ReferenceControls;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения <see cref="EngineeringOrderDirective"/>
    /// </summary>
    public class EngineeringOrderDirectiveScreen : Control
    {

        #region Fields

        protected EngineeringOrderDirective directive;
      //  private readonly IDirectiveContainer parentDirectiveContainer;

        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly ExtendableRichContainer generalInforationContainer;
        private readonly ExtendableRichContainer referenceDataContainer;
        private readonly ExtendableRichContainer complianceDataContainer;
        private readonly ExtendableRichContainer complianceTermsContainer;
        private readonly ExtendableRichContainer incorporationPlaceContainer;
        private readonly ExtendableRichContainer affectedDocumentsContainer;
        private readonly ExtendableRichContainer referenceDocumentsContainer;
        private readonly ExtendableRichContainer referenceDrawingsContainer;
        private readonly ExtendableRichContainer MJOContainer;
        private readonly ExtendableRichContainer sparePartKitContainer;
        private readonly ExtendableRichContainer consumableMaterialsContainer;
        private readonly ExtendableRichContainer equipmentToolsGSEContainer;
        private readonly ExtendableRichContainer specificNotesDataContainer;
        private readonly ExtendableRichContainer complianceDirectiveContainer;

        private readonly EngineeringOrderDirectiveGeneralInformationControl generalInformationControl;
        private readonly EngineeringOrderDirectiveListControl referenceDataControl;
        private readonly EngineeringOrderDirectiveComplianceDataControl complianceDataControl;
        private readonly EngineeringOrderDirectiveComplianceTermsControl complianceTermsControl;
        private readonly EngineeringOrderDirectiveIncorporationPlaceControl incorporationPlaceControl;
        private readonly EngineeringOrderDirectiveListControl affectedDocumentsControl;
        private readonly EngineeringOrderDirectiveListControl referenceDocumentsControl;
        private readonly EngineeringOrderDirectiveListControl referenceDrawingsControl;
        private readonly EngineeringOrderDirectiveListControl MJOControl;
        private readonly EngineeringOrderDirectiveListControl sparePartKitControl;
        private readonly EngineeringOrderDirectiveListControl consumableMaterialsControl;
        private readonly EngineeringOrderDirectiveListControl equipmentToolsGSEControl;
        private readonly EngineeringOrderDirectiveSpecificNotesDataControl specificNotesDataControl;
        private readonly DirectiveComplianceListView complianceDirectiveControl;
        private readonly Panel mainPanel = new Panel();
        private readonly Panel panelCompliance = new Panel();
        private readonly AvButtonT buttonAddPerformance = new AvButtonT();
        private readonly AvButtonT buttonDirectiveClosing = new AvButtonT();
        private readonly AvButtonT buttonDeleteRecord = new AvButtonT();
        private readonly AvButtonT buttonEditRecord = new AvButtonT();
        private readonly FlowLayoutPanel containedPanel = new FlowLayoutPanel();
        private readonly Panel panelHeader = new Panel();
        private readonly StatusImageLinkLabel statusLinkLabel = new StatusImageLinkLabel();
        private readonly RichReferenceButton buttonDeleteDirective = new RichReferenceButton();
        private readonly Icons icons = new Icons();
        private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;

        private const int COMPLIANCE_INTERVAL = 10;
        private const int COMPLIANCE_LEFT_MARGIN = 13;


        //Panel paneltemp = new Panel();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения <see cref="EngineeringOrderDirective"/>
        /// </summary>
        /// <param name="directive">Сама дирктива</param>
        ///// <param name="parentDirectiveContainer"></param>
        public EngineeringOrderDirectiveScreen(EngineeringOrderDirective directive)//, IDirectiveContainer parentDirectiveContainer)
        {
            this.directive = directive;
           // this.parentDirectiveContainer = parentDirectiveContainer;
            permissionForUpdate = directive.HasPermission(Users.CurrentUser, DataEvent.Update);
            permissionForDelete = directive.HasPermission(Users.CurrentUser, DataEvent.Remove);
            headerControl = new HeaderControl();
            footerControl = new FooterControl();
            aircraftHeader = new AircraftHeaderControl(directive.Parent.Parent as Aircraft, true, true);
            generalInforationContainer = new ExtendableRichContainer();
            referenceDataContainer = new ExtendableRichContainer();
            complianceDataContainer = new ExtendableRichContainer();
            complianceTermsContainer = new ExtendableRichContainer();
            incorporationPlaceContainer = new ExtendableRichContainer();
            affectedDocumentsContainer = new ExtendableRichContainer();
            referenceDocumentsContainer = new ExtendableRichContainer();
            referenceDrawingsContainer = new ExtendableRichContainer();
            MJOContainer = new ExtendableRichContainer();
            sparePartKitContainer = new ExtendableRichContainer();
            consumableMaterialsContainer = new ExtendableRichContainer();
            equipmentToolsGSEContainer = new ExtendableRichContainer();
            specificNotesDataContainer = new ExtendableRichContainer();
            complianceDirectiveContainer = new ExtendableRichContainer();
            generalInformationControl = new EngineeringOrderDirectiveGeneralInformationControl(directive);
            referenceDataControl = new EngineeringOrderDirectiveListControl(directive.ReferenceDataTable, new string[] { "Type", "Document", "Revision", "Date", "Issuer" }, new float[] { 0.1f, 0.3f, 0.3f, 0.1f, 0.14f }, permissionForUpdate);
            complianceDataControl = new EngineeringOrderDirectiveComplianceDataControl(directive);
            complianceTermsControl = new EngineeringOrderDirectiveComplianceTermsControl(directive);
            incorporationPlaceControl = new EngineeringOrderDirectiveIncorporationPlaceControl(directive);
            affectedDocumentsControl = new EngineeringOrderDirectiveListControl(directive.AffectedDocumentsTable, new string[] { "Type", "ATA Number", "Pages" }, new float[] { 0.1f, 0.7f, 0.14f }, permissionForUpdate);
            referenceDocumentsControl = new EngineeringOrderDirectiveListControl(directive.ReferenceDocumentsTable, new string[] { "Type", "ATA Number", "Pages" }, new float[] { 0.1f, 0.7f, 0.14f }, permissionForUpdate);
            referenceDrawingsControl = new EngineeringOrderDirectiveListControl(directive.ReferenceDrawingsTable, new string[] { "Drawing Number", "Title", "Issue Date" }, new float[] { 0.1f, 0.7f, 0.14f }, permissionForUpdate);
            MJOControl = new EngineeringOrderDirectiveListControl(directive.MJOTable, new string[] { "Name", "Revision", "Item" }, new float[] { 0.1f, 0.7f, 0.14f }, permissionForUpdate);
            sparePartKitControl = new EngineeringOrderDirectiveListControl(directive.SparePartTable, new string[] { "Part Number", "Name", "Title", "Reference", "Quantity", "Price", "Delivery to date" }, new float[] { 0.1f, 0.2f, 0.2f, 0.16f, 0.1f, 0.1f, 0.08f }, permissionForUpdate);
            consumableMaterialsControl = new EngineeringOrderDirectiveListControl(directive.ConsumebleMaterialTable, new string[] { "Part Number", "Specification", "Name", "Reference", "Quantity", "Price", "Delivery to date" }, new float[] {0.1f, 0.2f, 0.2f, 0.16f, 0.1f, 0.1f, 0.08f }, permissionForUpdate);
            equipmentToolsGSEControl = new EngineeringOrderDirectiveListControl(directive.EquipmentToolsGSETable, new string[] { "Part Number", "Name", "Title", "Reference", "Quantity", "Price", "Delivery to date" }, new float[] {0.1f, 0.2f, 0.2f, 0.16f, 0.1f, 0.1f, 0.08f }, permissionForUpdate);
            specificNotesDataControl = new EngineeringOrderDirectiveSpecificNotesDataControl(directive);
            complianceDirectiveControl = new DirectiveComplianceListView(directive);
            // 
            // aircraftHeader
            // 
            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ButtonEdit.DisplayerRequested += ButtonSave_DisplayerRequested;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "directive.html";
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ButtonEdit.Enabled = permissionForUpdate;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(containedPanel);
            //
            // containedPanel
            //
            containedPanel.AutoSize = true;
            containedPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            containedPanel.FlowDirection = FlowDirection.TopDown;
            containedPanel.TabIndex = 1;
            //
            // panelHeader
            //
            panelHeader.Size = new Size(1250, 50);
            panelHeader.TabIndex = 0;
            panelHeader.Controls.Add(buttonDeleteDirective);
            panelHeader.Controls.Add(statusLinkLabel);
            // 
            // statusLinkLabel
            // 
            statusLinkLabel.ActiveLinkColor = Color.Black;
            statusLinkLabel.Enabled = false;
            statusLinkLabel.HoveredLinkColor = Color.Black;
            statusLinkLabel.ImageBackColor = Color.Transparent;
            statusLinkLabel.ImageLayout = ImageLayout.Center;
            statusLinkLabel.LinkColor = Color.DimGray;
            statusLinkLabel.LinkMouseCapturedColor = Color.Empty;
            statusLinkLabel.Location = new Point(5, 10);
            statusLinkLabel.Size = new Size(500, 27);
            statusLinkLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLinkLabel.TextFont = Css.OrdinaryText.Fonts.RegularFont;
            // 
            // buttonDeleteDirective
            // 
            buttonDeleteDirective.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            buttonDeleteDirective.BackColor = Color.Transparent;
            buttonDeleteDirective.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDirective.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDirective.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDirective.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDirective.Location = new Point(panelHeader.Right - 160, 0);
            buttonDeleteDirective.Icon = icons.Delete;
            buttonDeleteDirective.IconNotEnabled = icons.DeleteGray;
            buttonDeleteDirective.IconLayout = ImageLayout.Center;
            buttonDeleteDirective.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteDirective.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteDirective.Size = new Size(160, 50);
            buttonDeleteDirective.TabIndex = 16;
            buttonDeleteDirective.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteDirective.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteDirective.TextMain = "Delete";
            buttonDeleteDirective.TextSecondary = "directive";
            buttonDeleteDirective.DisplayerRequested += buttonDeleteDirective_DisplayerRequested;
            buttonDeleteDirective.Enabled = permissionForDelete;
            //
            // generalInforationContainer
            //
            generalInforationContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            generalInforationContainer.LabelCaption.Text = "General Information";
            generalInforationContainer.MainControl = generalInformationControl;
            generalInforationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInforationContainer.TabIndex = 0;
            //
            // referenceDataContainer
            //
            referenceDataContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            referenceDataContainer.LabelCaption.Text = "Reference Data";
            referenceDataContainer.MainControl = referenceDataControl;
            referenceDataContainer.UpperLeftIcon = icons.GrayArrow;
            referenceDataContainer.TabIndex = 1;
            //
            // complianceDataContainer
            //
            complianceDataContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            complianceDataContainer.LabelCaption.Text = "Compliance Data";
            complianceDataContainer.MainControl = complianceDataControl;
            complianceDataContainer.UpperLeftIcon = icons.GrayArrow;
            complianceDataContainer.TabIndex = 2;
            //
            // complianceTermsContainer
            //
            complianceTermsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            complianceTermsContainer.LabelCaption.Text = "Compliance Terms";
            complianceTermsContainer.MainControl = complianceTermsControl;
            complianceTermsContainer.UpperLeftIcon = icons.GrayArrow;
            complianceTermsContainer.TabIndex = 3;
            //
            // incorporationPlaceContainer
            //
            incorporationPlaceContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            incorporationPlaceContainer.LabelCaption.Text = "Incorporation Place";
            incorporationPlaceContainer.MainControl = incorporationPlaceControl;
            incorporationPlaceContainer.UpperLeftIcon = icons.GrayArrow;
            incorporationPlaceContainer.TabIndex = 4;
            //
            // affectedDocumentsContainer
            //
            affectedDocumentsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            affectedDocumentsContainer.LabelCaption.Text = "Affected Documents";
            affectedDocumentsContainer.MainControl = affectedDocumentsControl;
            affectedDocumentsContainer.UpperLeftIcon = icons.GrayArrow;
            affectedDocumentsContainer.TabIndex = 5;
            //
            // referenceDocumentsContainer
            //
            referenceDocumentsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            referenceDocumentsContainer.LabelCaption.Text = "Reference Documents";
            referenceDocumentsContainer.MainControl = referenceDocumentsControl;
            referenceDocumentsContainer.UpperLeftIcon = icons.GrayArrow;
            referenceDocumentsContainer.TabIndex = 6;
            //
            // referenceDrawingsContainer
            //
            referenceDrawingsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            referenceDrawingsContainer.LabelCaption.Text = "Reference Drawings";
            referenceDrawingsContainer.MainControl = referenceDrawingsControl;
            referenceDrawingsContainer.UpperLeftIcon = icons.GrayArrow;
            referenceDrawingsContainer.TabIndex = 7;
            //
            // MJOContainer
            //
            MJOContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            MJOContainer.LabelCaption.Text = "MJO";
            MJOContainer.MainControl = MJOControl;
            MJOContainer.UpperLeftIcon = icons.GrayArrow;
            MJOContainer.TabIndex = 8;
            //
            // sparePartKitContainer
            //
            sparePartKitContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            sparePartKitContainer.LabelCaption.Text = "Spare Part / Kit";
            sparePartKitContainer.MainControl = sparePartKitControl;
            sparePartKitContainer.UpperLeftIcon = icons.GrayArrow;
            sparePartKitContainer.TabIndex = 9;
            //
            // consumableMaterialsContainer
            //
            consumableMaterialsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            consumableMaterialsContainer.LabelCaption.Text = "Consumable Material";
            consumableMaterialsContainer.MainControl = consumableMaterialsControl;
            consumableMaterialsContainer.UpperLeftIcon = icons.GrayArrow;
            consumableMaterialsContainer.TabIndex = 10;
            //
            // equipmentToolsGSEContainer
            //
            equipmentToolsGSEContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            equipmentToolsGSEContainer.LabelCaption.Text = "Equipment / Tools / GSE";
            equipmentToolsGSEContainer.MainControl = equipmentToolsGSEControl;
            equipmentToolsGSEContainer.UpperLeftIcon = icons.GrayArrow;
            equipmentToolsGSEContainer.TabIndex = 11;
            //
            // specificNotesDataContainer
            //
            specificNotesDataContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            specificNotesDataContainer.LabelCaption.Text = "Specific Notes / Data";
            specificNotesDataContainer.MainControl = specificNotesDataControl;
            specificNotesDataContainer.UpperLeftIcon = icons.GrayArrow;
            specificNotesDataContainer.TabIndex = 12;
            // 
            // buttonAddPerformance
            // 
            buttonAddPerformance.BackColor = Color.Transparent;
            buttonAddPerformance.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddPerformance.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddPerformance.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddPerformance.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddPerformance.Icon = icons.Add;
            buttonAddPerformance.IconNotEnabled = icons.AddGray;
            buttonAddPerformance.IconLayout = ImageLayout.Center;
            buttonAddPerformance.PaddingSecondary = new Padding(0);
            buttonAddPerformance.Size = new Size(160, 50);
            buttonAddPerformance.TabIndex = 16;
            buttonAddPerformance.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonAddPerformance.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddPerformance.TextMain = "Add Performance";
            buttonAddPerformance.Click += buttonAddNewRecord_Click;
            // 
            // buttonDirectiveClosing
            // 
            buttonDirectiveClosing.BackColor = Color.Transparent;
            buttonDirectiveClosing.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDirectiveClosing.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDirectiveClosing.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDirectiveClosing.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDirectiveClosing.Icon = icons.Add;
            buttonDirectiveClosing.IconNotEnabled = icons.AddGray;
            buttonDirectiveClosing.IconLayout = ImageLayout.Center;
            buttonDirectiveClosing.PaddingSecondary = new Padding(0);
            buttonDirectiveClosing.Size = new Size(150, 50);
            buttonDirectiveClosing.TabIndex = 16;
            buttonDirectiveClosing.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDirectiveClosing.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonDirectiveClosing.TextMain = "Close Directive";
            buttonDirectiveClosing.Click += buttonDirectiveClosing_Click;
            // 
            // buttonEditRecord
            // 
            buttonEditRecord.BackColor = Color.Transparent;
            buttonEditRecord.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditRecord.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditRecord.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditRecord.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditRecord.Icon = icons.Edit;
            buttonEditRecord.IconNotEnabled = icons.EditGray;
            buttonEditRecord.IconLayout = ImageLayout.Center;
            buttonEditRecord.PaddingSecondary = new Padding(0);
            buttonEditRecord.Size = new Size(130, 50);
            buttonEditRecord.TabIndex = 16;
            buttonEditRecord.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonEditRecord.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEditRecord.TextMain = "Edit";
            buttonEditRecord.Click += buttonEditRecord_Click;
            // 
            // buttonDeleteRecord
            // 
            buttonDeleteRecord.BackColor = Color.Transparent;
            buttonDeleteRecord.Cursor = Cursors.Hand;
            buttonDeleteRecord.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteRecord.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteRecord.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteRecord.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteRecord.Icon = icons.Delete;
            buttonDeleteRecord.IconNotEnabled = icons.DeleteGray;
            buttonDeleteRecord.IconLayout = ImageLayout.Center;
            buttonDeleteRecord.PaddingSecondary = new Padding(0);
            buttonDeleteRecord.Size = new Size(150, 50);
            buttonDeleteRecord.TabIndex = 16;
            buttonDeleteRecord.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteRecord.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonDeleteRecord.TextMain = "Remove";
            buttonDeleteRecord.Click += buttonDeleteRecord_Click;
            //
            // complianceDirectiveControl
            //
            complianceDirectiveControl.Location = new Point(COMPLIANCE_LEFT_MARGIN, 0);
            complianceDirectiveControl.SelectedItemsChanged += complianceDirectiveControl_SelectedItemsChanged;
            complianceDirectiveControl.ItemEdited += complianceDirectiveControl_ItemEdited;
            complianceDirectiveControl.SizeChanged += complianceDirectiveControl_SizeChanged;
            //
            // panelCompliance
            //
            panelCompliance.AutoSize = true;
            panelCompliance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCompliance.BackColor = Css.CommonAppearance.Colors.BackColor;
            panelCompliance.Dock = DockStyle.Top;
            panelCompliance.TabIndex = 5;
            panelCompliance.Controls.Add(complianceDirectiveControl);
            panelCompliance.Controls.Add(buttonAddPerformance);
            panelCompliance.Controls.Add(buttonDirectiveClosing);
            panelCompliance.Controls.Add(buttonEditRecord);
            panelCompliance.Controls.Add(buttonDeleteRecord);
            panelCompliance.SizeChanged += panelCompliance_SizeChanged;
            //
            // complianceDirectiveContainer
            //
            complianceDirectiveContainer.Dock = DockStyle.Top;
            complianceDirectiveContainer.LabelCaption.Text = "Compliance";
            complianceDirectiveContainer.UpperLeftIcon = icons.GrayArrow;
            complianceDirectiveContainer.Extending += complianceDirectiveContainer_Extending;
            complianceDirectiveContainer.TabIndex = 4;

            containedPanel.Controls.Add(panelHeader);
            containedPanel.Controls.Add(generalInforationContainer);
            containedPanel.Controls.Add(referenceDataContainer);
            containedPanel.Controls.Add(complianceDataContainer);
            containedPanel.Controls.Add(complianceTermsContainer);
            containedPanel.Controls.Add(incorporationPlaceContainer);
            containedPanel.Controls.Add(affectedDocumentsContainer);
            containedPanel.Controls.Add(referenceDocumentsContainer);
            containedPanel.Controls.Add(referenceDrawingsContainer);
            containedPanel.Controls.Add(MJOContainer);
            containedPanel.Controls.Add(sparePartKitContainer);
            containedPanel.Controls.Add(consumableMaterialsContainer);
            containedPanel.Controls.Add(equipmentToolsGSEContainer);
            containedPanel.Controls.Add(specificNotesDataContainer);
            containedPanel.Controls.Add(complianceDirectiveContainer);
            containedPanel.Controls.Add(panelCompliance);
            
            
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
            
            
            UpdateScreen(false);
        }

        #endregion

        #region Properties

        #region public EngineeringOrderDirective Directive

        /// <summary>
        /// Возвращает текущую директиву
        /// </summary>
        public EngineeringOrderDirective Directive
        {
            get
            {
                return directive;
            }
        }

        #endregion

        #region public DirectiveRecord[] DisplayedRecords

        /// <summary>
        /// Возвращает список отображаемых записей Compliance по данной директиве
        /// </summary>
        public DirectiveRecord[] DisplayedRecords
        {
            get
            {
                List<DirectiveRecord> records = new List<DirectiveRecord>(directive.GetPerformances());
                if (directive.ClosingRecord != null)
                    records.Add(directive.ClosingRecord);
                return records.ToArray();
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void UpdateScreen()

        /// <summary>
        /// Обновляет информацию о директиве
        /// </summary>
        private void UpdateScreen()
        {
            UpdateScreen(true);
        }

        #endregion

        #region private void UpdateScreen(bool reloadDirective)

        /// <summary>
        /// Обновляет информацию о директиве
        /// </summary>
        /// <param name="reloadDirective">Синхронизировать ли с базой данных</param>
        private void UpdateScreen(bool reloadDirective)
        {
            if (reloadDirective)
            {

                try
                {
                    directive.Reload();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while loading data", ex);
                    return;
                }

            }
            statusLinkLabel.Status = (Statuses)directive.Condition;
            statusLinkLabel.Text = "Status: " + UsefulMethods.EnumToString(statusLinkLabel.Status);

            generalInformationControl.UpdateInformation();
            referenceDataControl.UpdateItems();
            complianceDataControl.UpdateInformation();
            complianceTermsControl.UpdateInformation();
            incorporationPlaceControl.UpdateInformation();
            affectedDocumentsControl.UpdateItems();
            referenceDocumentsControl.UpdateItems();
            referenceDrawingsControl.UpdateItems();
            MJOControl.UpdateItems();
            sparePartKitControl.UpdateItems();
            consumableMaterialsControl.UpdateItems();
            equipmentToolsGSEControl.UpdateItems();
            specificNotesDataControl.UpdateInformation();
        }

        #endregion

        #region protected bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        protected bool GetChangeStatus()
        {
            return (generalInformationControl.GetChangeStatus(true) ||
                    referenceDataControl.GetChangeStatus() ||
                    complianceDataControl.GetChangeStatus(true) ||
                    complianceTermsControl.GetChangeStatus(true) ||
                    incorporationPlaceControl.GetChangeStatus(true) ||
                    affectedDocumentsControl.GetChangeStatus() ||
                    referenceDocumentsControl.GetChangeStatus() ||
                    referenceDrawingsControl.GetChangeStatus() ||
                    MJOControl.GetChangeStatus() ||
                    sparePartKitControl.GetChangeStatus() ||
                    consumableMaterialsControl.GetChangeStatus() ||
                    equipmentToolsGSEControl.GetChangeStatus());
        }

        #endregion

        #region protected void SaveData()

        protected void SaveData()
        {
            if (GetChangeStatus())
            {
                generalInformationControl.SaveData();
                referenceDataControl.SaveData();
                complianceDataControl.SaveData();
                complianceTermsControl.SaveData();
                incorporationPlaceControl.SaveData();
                affectedDocumentsControl.SaveData();
                referenceDocumentsControl.SaveData();
                referenceDrawingsControl.SaveData();
                MJOControl.SaveData();
                sparePartKitControl.SaveData();
                consumableMaterialsControl.SaveData();
                equipmentToolsGSEControl.SaveData();

                try
                {
                    directive.Save(true);
                        UpdateScreen();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }


            }
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        #endregion

        #region private void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            SaveData();
            e.Cancel = true;
        }

        #endregion

        #region private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current directive?",
                                                  "Confirm deleting", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    IDirectiveContainer parentDirectiveContainer = (IDirectiveContainer)directive.Parent;
                    parentDirectiveContainer.Remove(directive);
                    MessageBox.Show("Directive was deleted successfully", "Directive deleted",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            string title = directive.Parent.Parent.ToString();
            if (!(directive.Parent is AircraftFrame))
                title += ". " + directive.Parent;
            e.DisplayerText = title + ". " + directive.DirectiveType.CommonName + ". " + directive.Title + ". Report";
            EngineeringOrderReportBuilder builder = new EngineeringOrderReportBuilder(directive);
            e.RequestedEntity = new DispatcheredEngineeringOrderReport(builder);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void buttonAddNewRecord_Click(object sender, EventArgs e)

        private void buttonAddNewRecord_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(directive);
            form.RecordType = RecordTypesCollection.Instance.DirectivePerformanceRecordType;
            if (form.ShowDialog() == DialogResult.OK)
                UpdateScreen();
        }

        #endregion

        #region private void buttonDirectiveClosing_Click(object sender, EventArgs e)

        private void buttonDirectiveClosing_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(directive);
            form.RecordType = RecordTypesCollection.Instance.DirectiveClosingRecordType;
            if (form.ShowDialog() == DialogResult.OK)
                UpdateScreen();
        }

        #endregion

        #region private void buttonEditRecord_Click(object sender, EventArgs e)

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(complianceDirectiveControl.SelectedItem);
            if (form.ShowDialog() == DialogResult.OK)
                UpdateScreen();
        }

        #endregion

        #region private void buttonDeleteRecord_Click(object sender, EventArgs e)

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            string message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "record");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < complianceDirectiveControl.SelectedItems.Count; i++)
                            directive.RemoveRecord(complianceDirectiveControl.SelectedItems[i]);

                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
                complianceDirectiveControl.SetItemsArray(DisplayedRecords);
            }
        }
        
        #endregion

        #region private void complianceDirectiveContainer_Extending(object sender, EventArgs e)

        private void complianceDirectiveContainer_Extending(object sender, EventArgs e)
        {
            panelCompliance.Visible = !panelCompliance.Visible;
        }

        #endregion

        #region private void complianceDirectiveControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void complianceDirectiveControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonEditRecord.Enabled = (permissionForUpdate && (e.ItemsCount > 0) && (e.ItemsCount < 2));
            buttonDeleteRecord.Enabled = (permissionForUpdate && (e.ItemsCount > 0));
        }

        #endregion

        #region private void complianceDirectiveControl_ItemEdited(object sender, EventArgs e)

        private void complianceDirectiveControl_ItemEdited(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        #endregion

        #region private void complianceDirectiveControl_SizeChanged(object sender, EventArgs e)

        private void complianceDirectiveControl_SizeChanged(object sender, EventArgs e)
        {
            buttonAddPerformance.Location = new Point(COMPLIANCE_LEFT_MARGIN, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonDirectiveClosing.Location = new Point(buttonAddPerformance.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonEditRecord.Location = new Point(buttonDirectiveClosing.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonDeleteRecord.Location = new Point(buttonEditRecord.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
        }

        #endregion

        #region private void panelCompliance_SizeChanged(object sender, EventArgs e)

        private void panelCompliance_SizeChanged(object sender, EventArgs e)
        {
            complianceDirectiveControl.Width = panelCompliance.Width - 16;
        }

        #endregion

        #endregion

    }
}
