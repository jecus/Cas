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
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ReferenceControls;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Элемент управления для отображения <see cref="BaseDetailDirective"/>
    /// </summary>
    public class OutOffPhaseReferenceScreen : Control
    {

        #region Fields

        protected BaseDetailDirective directive;

        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly ExtendableRichContainer summaryDirectiveContainer;
        private readonly ExtendableRichContainer generalInforationContainer;

        private readonly ExtendableRichContainer complianceDirectiveContainer;

        private readonly OutOffPhaseReferenceInformationControl generalInformationControl;
        private readonly OutOffPhaseReferenceSummary summaryDirectiveControl;
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
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения <see cref="EngineeringOrderDirective"/>
        /// </summary>
        /// <param name="directive">Сама дирктива</param>
        public OutOffPhaseReferenceScreen(BaseDetailDirective directive)
        {
            this.directive = directive;
            permissionForUpdate = directive.HasPermission(Users.CurrentUser, DataEvent.Update);
            permissionForDelete = directive.HasPermission(Users.CurrentUser, DataEvent.Remove);
            headerControl = new HeaderControl();
            footerControl = new FooterControl();
            aircraftHeader = new AircraftHeaderControl(directive.Parent.Parent as Aircraft, true, true);
            generalInforationContainer = new ExtendableRichContainer();
            complianceDirectiveContainer = new ExtendableRichContainer();
            generalInformationControl = new OutOffPhaseReferenceInformationControl(directive);
            summaryDirectiveControl = new OutOffPhaseReferenceSummary(directive);
            complianceDirectiveControl = new DirectiveComplianceListView(directive);
            summaryDirectiveContainer = new ExtendableRichContainer();
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
            buttonDeleteDirective.TextSecondary = "requirement";
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
            // summaryDirectiveContainer
            //
            summaryDirectiveContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            summaryDirectiveContainer.LabelCaption.Text = "Summary";
            summaryDirectiveContainer.MainControl = summaryDirectiveControl;
            summaryDirectiveContainer.UpperLeftIcon = icons.GrayArrow;
            summaryDirectiveContainer.TabIndex = 0;

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
            containedPanel.Controls.Add(summaryDirectiveContainer);
            containedPanel.Controls.Add(generalInforationContainer);
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
        public BaseDetailDirective Directive
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
            summaryDirectiveControl.UpdateInformation();
            complianceDirectiveControl.SetItemsArray(DisplayedRecords);
        }

        #endregion

        #region protected bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        protected bool GetChangeStatus()
        {
            return (generalInformationControl.GetChangeStatus(true));
        }

        #endregion

        #region protected void SaveData()

        protected void SaveData()
        {
            if (GetChangeStatus())
            {
                generalInformationControl.SaveData();

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
            if (generalInformationControl.GetChangeStatus(true))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    UpdateScreen();
                }
            }
            else
            {
                UpdateScreen();
            }
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
            BaseDetail baseDetail = directive.Parent as BaseDetail;
            if (baseDetail == null)
                return;
            string caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + directive.DirectiveType.CommonName + ". " + ((directive.Description.Length>20)?directive.Description.Substring(0,20).Trim():directive.Description) + ". Compliance List";
            ComplianceListBuilder reportBuilder = new ComplianceListBuilder(complianceDirectiveControl.GetItemsArray());

            e.DisplayerText = caption;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredComplianceListReport(caption, DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString()), reportBuilder);
        }

        #endregion

        #region private void buttonAddNewRecord_Click(object sender, EventArgs e)

        private void buttonAddNewRecord_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(directive);
            form.RecordType = RecordTypesCollection.Instance.DirectivePerformanceRecordType;
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void buttonDirectiveClosing_Click(object sender, EventArgs e)

        private void buttonDirectiveClosing_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(directive);
            form.RecordType = RecordTypesCollection.Instance.DirectiveClosingRecordType;
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void buttonEditRecord_Click(object sender, EventArgs e)

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(complianceDirectiveControl.SelectedItem);
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
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
                    Program.Provider.Logger.Log("Error while deleting data", ex); return;
                }
                UpdateScreen(false);
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

        #region private void form_RecordChanged(object sender, EventArgs e)

        private void form_RecordChanged(object sender, EventArgs e)
        {
            UpdateScreen(false);
        }

        #endregion

        #endregion

    }
}
