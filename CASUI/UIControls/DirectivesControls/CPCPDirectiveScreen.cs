using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Management;
using CAS.UI.UIControls.ComplianceControls;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.StatusImageLink;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Элемент управления для отображения информации о директиве
    /// </summary>
    [ToolboxItem(false)]
    public class CPCPDirectiveScreen : UserControl
    {
        #region Fields

        protected BaseDetailDirective currentDirective;

        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        
        private readonly CPCPDirectiveSummaryInformationControl summaryDirectiveControl;
        /// <summary>
        /// </summary>
        protected readonly CPCPDirectiveGeneralInformationControl generalDataAndPerformanceControl;
        private readonly DirectiveComplianceListView complianceDirectiveControl;
        /// <summary>
        /// </summary>
        
        private readonly ExtendableRichContainer summaryDirectiveContainer;
        private readonly ExtendableRichContainer generalDataAndPerformanceContainer;
        private readonly ExtendableRichContainer complianceDirectiveContainer;
        
        private readonly StatusImageLinkLabel statusLinkLabel = new StatusImageLinkLabel();
        private readonly Panel mainPanel;
        private readonly FlowLayoutPanel containedPanel = new FlowLayoutPanel();
        private readonly Panel panelHeader;
        private readonly Panel panelCompliance;
        
        private readonly AvButtonT buttonAddPerformance;
        private readonly AvButtonT buttonDirectiveClosing;
        private readonly AvButtonT buttonDeleteRecord;
        private readonly AvButtonT buttonEditRecord;
        private readonly RichReferenceButton buttonDeleteDirective;

        private readonly Icons icons = new Icons();
        private const int COMPLIANCE_INTERVAL = 10;

        #endregion

        #region Constructor

        #region public CPCPDirectiveScreen(BaseDetailDirective directive)

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="directive">Директива</param>
        public CPCPDirectiveScreen(BaseDetailDirective directive)
        {
            if (directive == null)
                throw new ArgumentNullException("directive", "Argument cannot be null");
            currentDirective = directive;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;

            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl(directive.Parent.Parent as Aircraft, true);

            summaryDirectiveContainer = new ExtendableRichContainer();
            generalDataAndPerformanceContainer = new ExtendableRichContainer();
            complianceDirectiveContainer = new ExtendableRichContainer();

            summaryDirectiveControl = new CPCPDirectiveSummaryInformationControl(directive);
            generalDataAndPerformanceControl = new CPCPDirectiveGeneralInformationControl(directive);
            complianceDirectiveControl = new DirectiveComplianceListView(directive);

            panelCompliance = new Panel();
            mainPanel = new Panel();
            panelHeader = new Panel();

            buttonAddPerformance = new AvButtonT();
            buttonDirectiveClosing = new AvButtonT();
            buttonDeleteRecord = new AvButtonT();
            buttonEditRecord = new AvButtonT();
            buttonDeleteDirective = new RichReferenceButton();

            // 
            // aircraftHeader
            // 
            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.TabIndex = 0;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.ButtonEdit.DisplayerRequested += ButtonSave_DisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "work_with_the_directive";
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
            // summaryDirectiveContainer
            //
            summaryDirectiveContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            summaryDirectiveContainer.LabelCaption.Text = "Directive " + directive.Title + " Summary";
            summaryDirectiveContainer.MainControl = summaryDirectiveControl;
            summaryDirectiveContainer.UpperLeftIcon = icons.GrayArrow;
            summaryDirectiveContainer.TabIndex = 1;
            //
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            generalDataAndPerformanceContainer.Extended = false;
            generalDataAndPerformanceContainer.LabelCaption.Text = "General Data And Performance";
            generalDataAndPerformanceContainer.Location = new Point(0, summaryDirectiveContainer.Bottom);
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.TabIndex = 2;
            //
            // panelHeader
            //
            panelHeader.Size = new Size(1250, 50);
            panelHeader.TabIndex = 0;
            panelHeader.Controls.Add(buttonDeleteDirective);
            panelHeader.Controls.Add(statusLinkLabel);
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
            buttonAddPerformance.TextMain = "Register Performance";
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
            buttonDeleteRecord.Click += referenceAvButtonDeleteRecord_Click;
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
            //
            // complianceDirectiveControl
            //
            complianceDirectiveControl.Dock = DockStyle.Top;
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
            panelCompliance.Visible = false;
            panelCompliance.TabIndex = 5;
            panelCompliance.Controls.Add(complianceDirectiveControl);
            panelCompliance.Controls.Add(buttonAddPerformance);
            panelCompliance.Controls.Add(buttonDirectiveClosing);
            panelCompliance.Controls.Add(buttonEditRecord);
            panelCompliance.Controls.Add(buttonDeleteRecord);
            //
            // complianceDirectiveContainer
            //
            complianceDirectiveContainer.Dock = DockStyle.Top;
            complianceDirectiveContainer.Extended = false;
            complianceDirectiveContainer.LabelCaption.Text = "Compliance";
            complianceDirectiveContainer.UpperLeftIcon = icons.GrayArrow;
            complianceDirectiveContainer.Extending += complianceDirectiveContainer_Extending;
            complianceDirectiveContainer.TabIndex = 4;

           
            containedPanel.Controls.Add(panelHeader);
            containedPanel.Controls.Add(summaryDirectiveContainer);
            containedPanel.Controls.Add(generalDataAndPerformanceContainer);
            containedPanel.Controls.Add(complianceDirectiveContainer);
            containedPanel.Controls.Add(panelCompliance);

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);

            UpdateDirective();


            complianceDirectiveControl_SelectedItemsChanged(complianceDirectiveControl, new SelectedItemsChangeEventArgs(0));
        }

        #endregion

        #endregion

        #region Properties

        #region public DirectiveRecord[] DisplayedRecords

        /// <summary>
        /// Возвращает список отображаемых записей Compliance по данной директиве
        /// </summary>
        public DirectiveRecord[] DisplayedRecords
        {
            get
            {
                List<DirectiveRecord> records = new List<DirectiveRecord>(currentDirective.GetPerformances());
                if (currentDirective.ClosingRecord != null)
                    records.Add(currentDirective.ClosingRecord); 
                return records.ToArray();
            }
        }

        #endregion
          
        #endregion

        #region Methods

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (generalDataAndPerformanceControl.GetChangeStatus(true))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ReloadDirective();
                }
            }
            else
            {
                ReloadDirective();
            }
        }

        #endregion

        #region private void complianceDirectiveControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void complianceDirectiveControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            buttonEditRecord.Enabled = (permission && (e.ItemsCount > 0) && (e.ItemsCount < 2));
            buttonDeleteRecord.Enabled = (permission && (e.ItemsCount > 0));
        }

        #endregion

        #region private void complianceDirectiveControl_ItemEdited(object sender, EventArgs e)

        private void complianceDirectiveControl_ItemEdited(object sender, EventArgs e)
        {
            ReloadDirective(); 
        }

        #endregion

        #region private void complianceDirectiveControl_SizeChanged(object sender, EventArgs e)

        private void complianceDirectiveControl_SizeChanged(object sender, EventArgs e)
        {
            buttonAddPerformance.Location = new Point(0, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonDirectiveClosing.Location = new Point(buttonAddPerformance.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonEditRecord.Location = new Point(buttonDirectiveClosing.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
            buttonDeleteRecord.Location = new Point(buttonEditRecord.Right, complianceDirectiveControl.Bottom + COMPLIANCE_INTERVAL);
        }

        #endregion

        #region private void complianceDirectiveContainer_Extending(object sender, EventArgs e)

        private void complianceDirectiveContainer_Extending(object sender, EventArgs e)
        {
            panelCompliance.Visible = !panelCompliance.Visible;
        }

        #endregion

        #region protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Метод обработки события нажатия кнопки Save
        /// </summary>
        protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            Save();
        }

        #endregion

        #region protected bool Save()

        /// <summary>
        /// Сохраняет данные текущей директивы
        /// </summary>
        protected bool Save()
        {
            double d;
            if (!generalDataAndPerformanceControl.CheckManHours(out d))
                return false;
            if (generalDataAndPerformanceControl.GetChangeStatus(true) || currentDirective.Modified)
            {
                SaveData();
            }
            return true;
        }

        #endregion
        
        #region public void SaveData()

        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        public void SaveData()
        {
            if (!generalDataAndPerformanceControl.SaveData())
                return;
            try
            {
                currentDirective.Save(true);
                ReloadDirective();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }

        }

        #endregion


        

        #region private void ReloadDirective()

        private void ReloadDirective()
        {
            try
            {

            currentDirective.Reload();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            
            UpdateDirective();
        }

        #endregion

        #region public void UpdateDirective()

        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        public void UpdateDirective()
        {

            statusLinkLabel.Status = (Statuses)currentDirective.Condition;
            if (currentDirective.Closed)
                statusLinkLabel.Text = "Status: Closed";
            else if (currentDirective.Condition == DirectiveConditionState.Pending)
                statusLinkLabel.Text = statusLinkLabel.ToString();// + UsefulMethods.EnumToString(statusLinkLabel.Status);
            else
                statusLinkLabel.Text = "Status: " + statusLinkLabel;
            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);
            buttonDeleteDirective.Enabled = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Remove);
            
            headerControl.ActionControl.ShowEditButton = permission;
            buttonAddPerformance.Enabled = permission;

            complianceDirectiveControl_SelectedItemsChanged(complianceDirectiveControl, new SelectedItemsChangeEventArgs(0));
            
            summaryDirectiveContainer.LabelCaption.Text = "Directive " + currentDirective.Title + " Summary";
            summaryDirectiveControl.UpdateInformation();
            generalDataAndPerformanceControl.UpdateInformation();

            DirectiveRecord[] records = DisplayedRecords;
            complianceDirectiveControl.SetItemsArray(records);
            complianceDirectiveControl.DoubleClickEnable = permission;
            buttonAddPerformance.Enabled = (!currentDirective.Closed);
            headerControl.ContextActionControl.ButtonPrint.Enabled = !(records.Length == 0);
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

                    IDirectiveContainer parentDirectiveContainer = (IDirectiveContainer) currentDirective.Parent;
                    parentDirectiveContainer.Remove(currentDirective);

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

        #region private void buttonDeleteRecord_Click(object sender, EventArgs e)

        private void referenceAvButtonDeleteRecord_Click(object sender, EventArgs e)
        {
            string message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "record");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < complianceDirectiveControl.SelectedItems.Count; i++)
                        currentDirective.RemoveRecord(complianceDirectiveControl.SelectedItems[i]);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); return;
                }

                UpdateDirective();
            }
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

        #region private void buttonAddNewRecord_Click(object sender, EventArgs e)

        private void buttonAddNewRecord_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(currentDirective);
            form.RecordType = RecordTypesCollection.Instance.DirectivePerformanceRecordType;
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void buttonDirectiveClosing_Click(object sender, EventArgs e)

        private void buttonDirectiveClosing_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(currentDirective);
            form.RecordType = RecordTypesCollection.Instance.DirectiveClosingRecordType;
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            BaseDetail baseDetail = currentDirective.Parent as BaseDetail;
            if (baseDetail == null)
                return;
            string caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + currentDirective.DirectiveType.CommonName + ". " + currentDirective.Title + ". Compliance List";
            ComplianceListBuilder reportBuilder = new ComplianceListBuilder(complianceDirectiveControl.GetItemsArray());
            
            e.DisplayerText = caption;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredComplianceListReport(caption, DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString()), reportBuilder);
        }

        #endregion

        #region private void form_RecordChanged(object sender, EventArgs e)

        private void form_RecordChanged(object sender, EventArgs e)
        {
            UpdateDirective();
        }

        #endregion

        #endregion
    }
}