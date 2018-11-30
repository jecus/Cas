using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.StoresControls;
using CASReports.Builders;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;
using CAS.Core.Types.Directives;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения отдельного агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class DetailScreen : UserControl
    {

        #region Fields

        private const int COMPLIANCE_INTERVAL = 10;

        private readonly AircraftHeaderControl aircraftHeader;
        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;

        private readonly AvButtonT buttonAddCompliance;
        private readonly AvButtonT buttonAddActualData;
        private readonly AvButtonT buttonDeleteRecord;
        private readonly AvButtonT buttonEditRecord;
        private readonly RichReferenceButton buttonInstallPickOffDetail;

        protected readonly BaseDetailHeaderControl baseDetailHeaderControl;
        /// <summary>
        /// </summary>
        protected readonly DetailGeneralInformationControl generalInformationControl;
        /// <summary>
        /// </summary>
        protected readonly DetailCompliancePerformanceListControl compliancePerformanceControl;
        /// <summary>
        /// </summary>
        protected readonly DetailWarrantyControl warrantyControl;
        /// <summary>
        /// </summary>
        protected readonly EASAControl easaControl;
        /// <summary>
        /// </summary>
        protected readonly DetailStoreControl storeControl;
        private readonly DetailComplianceListView complianceControl;

        private readonly ExtendableRichContainer generalInformationContainer;
        private readonly ExtendableRichContainer compliancePerformanceContainer;
        private readonly ExtendableRichContainer warrantyContainer;
        private readonly ExtendableRichContainer easaContainer;
        private readonly ExtendableRichContainer storeContainer;
        private readonly ExtendableRichContainer complianceDetailContainer;

        private readonly Panel mainPanel = new Panel();
        private readonly FlowLayoutPanel containedPanel = new FlowLayoutPanel();
        private readonly Panel panelCompliance = new Panel();
        
        private readonly Icons icons = new Icons();
        protected AbstractDetail currentDetail;

        //private readonly string easaFileName = "EASA Form 8330.pdf";

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения отдельного агрегата
        /// </summary>
        /// <param name="detail"></param>
        public DetailScreen(AbstractDetail detail)
        {
            if (detail == null)
                throw new ArgumentNullException("detail", "Argument cannot be null");

            currentDetail = detail;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl(currentDetail.Aircraft, true);
            baseDetailHeaderControl = new BaseDetailHeaderControl(currentDetail);
            generalInformationControl = new DetailGeneralInformationControl(currentDetail);
            compliancePerformanceControl = new DetailCompliancePerformanceListControl(currentDetail);
            warrantyControl = new DetailWarrantyControl(currentDetail);
            easaControl = new EASAControl(currentDetail, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the origin of the detail. Enclose PDF file to prove the origin.",
                    "Attached file proves the origin of the detail.", icons.PDFSmall);
            if (!currentDetail.InUse)
                storeControl = new DetailStoreControl(currentDetail);
            complianceControl = new DetailComplianceListView(currentDetail);

            generalInformationContainer = new ExtendableRichContainer();
            compliancePerformanceContainer = new ExtendableRichContainer();
            warrantyContainer = new ExtendableRichContainer();
            easaContainer = new ExtendableRichContainer();
            storeContainer = new ExtendableRichContainer();
            complianceDetailContainer = new ExtendableRichContainer();
            
            buttonAddCompliance = new AvButtonT();
            buttonAddActualData = new AvButtonT();
            buttonDeleteRecord = new AvButtonT();
            buttonEditRecord = new AvButtonT();
            buttonInstallPickOffDetail = new RichReferenceButton();

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
            headerControl.TabIndex = 0;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ButtonEdit.DisplayerRequested += ButtonSave_DisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "work_with_the_aggregate";
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
            // generalInformationContainer
            //
            generalInformationContainer.Extended = false;
            generalInformationContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            generalInformationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInformationContainer.Caption = "Component General Information";
            generalInformationContainer.MainControl = generalInformationControl;
            generalInformationContainer.TabIndex = 2;
            //
            // compliancePerformanceContainer
            //
            compliancePerformanceContainer.Extended = false;
            compliancePerformanceContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            compliancePerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            compliancePerformanceContainer.Caption = "Compliance/Performance";
            compliancePerformanceContainer.MainControl = compliancePerformanceControl;
            compliancePerformanceContainer.TabIndex = 3;
            //
            // warrantyContainer
            //
            warrantyContainer.Extended = false;
            warrantyContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            warrantyContainer.UpperLeftIcon = icons.GrayArrow;
            warrantyContainer.Caption = "Warranty";
            warrantyContainer.MainControl = warrantyControl;
            warrantyContainer.TabIndex = 4;
            //
            // easaContainer
            //
            easaContainer.Extended = false;
            easaContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            easaContainer.UpperLeftIcon = icons.GrayArrow;
            //easaContainer.Caption = "EASA / FAA Form 8330";
            easaContainer.Caption = "FAA Form 8330";
            easaContainer.MainControl = easaControl;
            easaContainer.TabIndex = 5;

            //
            // storeContainer
            //
            storeContainer.Extended = false;
            storeContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            storeContainer.UpperLeftIcon = icons.GrayArrow;
            storeContainer.Caption = "Store";
            storeContainer.MainControl = storeControl;
            storeContainer.TabIndex = 7;
            // 
            // buttonAddCompliance
            // 
            buttonAddCompliance.BackColor = Color.Transparent;
            buttonAddCompliance.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddCompliance.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddCompliance.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddCompliance.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddCompliance.Icon = icons.Add;
            buttonAddCompliance.IconNotEnabled = icons.AddGray;
            buttonAddCompliance.IconLayout = ImageLayout.Center;
            buttonAddCompliance.PaddingSecondary = new Padding(0);
            buttonAddCompliance.Size = new Size(150, 50);
            buttonAddCompliance.TabIndex = 16;
            buttonAddCompliance.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonAddCompliance.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddCompliance.TextMain = "Register Compliance";
            buttonAddCompliance.Click += buttonAddCompliance_Click;
            // 
            // buttonAddActualData
            // 
            buttonAddActualData.BackColor = Color.Transparent;
            buttonAddActualData.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddActualData.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddActualData.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddActualData.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddActualData.Icon = icons.Add;
            buttonAddActualData.IconNotEnabled = icons.AddGray;
            buttonAddActualData.IconLayout = ImageLayout.Center;
            buttonAddActualData.PaddingSecondary = new Padding(0);
            buttonAddActualData.Size = new Size(150, 50);
            buttonAddActualData.TabIndex = 16;
            buttonAddActualData.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonAddActualData.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddActualData.TextMain = "Set Actual State";
            buttonAddActualData.Click += buttonAddActualData_Click;
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
            // buttonInstallPickOffDetail
            // 
            buttonInstallPickOffDetail.BackColor = Color.Transparent;
            buttonInstallPickOffDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonInstallPickOffDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonInstallPickOffDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonInstallPickOffDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonInstallPickOffDetail.Icon = icons.Edit;
            buttonInstallPickOffDetail.IconNotEnabled = icons.EditGray;
            buttonInstallPickOffDetail.IconLayout = ImageLayout.Center;
            buttonInstallPickOffDetail.PaddingSecondary = new Padding(0);
            buttonInstallPickOffDetail.Size = new Size(150, 50);
            buttonInstallPickOffDetail.TabIndex = 16;
            buttonInstallPickOffDetail.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonInstallPickOffDetail.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonInstallPickOffDetail.ReflectionType = ReflectionTypes.DisplayInCurrent;
            if (currentDetail.InUse)
                buttonInstallPickOffDetail.TextMain = "Pick Off";
            else
                buttonInstallPickOffDetail.TextMain = "Install";
            buttonInstallPickOffDetail.DisplayerRequested += buttonInstallPickOffDetail_DisplayerRequested;
            //
            // complianceControl
            //

            complianceControl.Dock = DockStyle.Top;
            complianceControl.Height = 188;
            complianceControl.SelectedItemsChanged += complianceDirectiveControl_SelectedItemsChanged;
            complianceControl.ItemEdited += complianceDirectiveControl_ItemEdited;
            complianceControl.SizeChanged += complianceDirectiveControl_SizeChanged;

            //
            // panelCompliance
            //
            panelCompliance.AutoSize = true;
            panelCompliance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCompliance.BackColor = Css.CommonAppearance.Colors.BackColor;
            panelCompliance.Dock = DockStyle.Top;
            panelCompliance.Visible = false;
            panelCompliance.TabIndex = 7;
            panelCompliance.Controls.Add(complianceControl);
            panelCompliance.Controls.Add(buttonAddCompliance);
            panelCompliance.Controls.Add(buttonAddActualData);
            panelCompliance.Controls.Add(buttonEditRecord);
            panelCompliance.Controls.Add(buttonDeleteRecord);
            panelCompliance.Controls.Add(buttonInstallPickOffDetail);
            //
            // baseDetailHeaderControl
            //
            baseDetailHeaderControl.TabIndex = 0;
            //
            // complianceDetailContainer
            //
            complianceDetailContainer.LabelCaption.Text = "Compliance";
            complianceDetailContainer.UpperLeftIcon = icons.GrayArrow;
            complianceDetailContainer.Extending += complianceDirectiveContainer_Extending;
            complianceDetailContainer.TabIndex = 6;

            containedPanel.Controls.Add(baseDetailHeaderControl);
            containedPanel.Controls.Add(generalInformationContainer);
            containedPanel.Controls.Add(compliancePerformanceContainer);
            containedPanel.Controls.Add(warrantyContainer);
            containedPanel.Controls.Add(easaContainer);
            if (!currentDetail.InUse)
                containedPanel.Controls.Add(storeContainer);
            containedPanel.Controls.Add(complianceDetailContainer);
            containedPanel.Controls.Add(panelCompliance);
            
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
            UpdateDetail(false);

            complianceDirectiveControl_SelectedItemsChanged(complianceControl, new SelectedItemsChangeEventArgs(0));
        }

        #endregion

        #region Properties

        #region public AbstractDetail Detail

        /// <summary>
        /// Возвращает или устанавливает агрегат, с которым работает данный элемент управления
        /// </summary>
        public AbstractDetail Detail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                generalInformationControl.UpdateInformation();
                UpdateDetail();
            }
        }

        #endregion


        #region public AbstractRecord[] DisplayedDetailRecords

        /// <summary>
        /// Возвращает список отображаемых записей Compliance по данному агрегату
        /// </summary>
        public AbstractRecord[] DisplayedDetailRecords
        {
            get
            {
                List<AbstractRecord> detailRecords = new List<AbstractRecord>();
                detailRecords.AddRange(currentDetail.GetActualSettingRecords());
                detailRecords.AddRange(currentDetail.GetTransferRecords());
                detailRecords.AddRange(currentDetail.GetDetailDirectivesPerformances());
                return detailRecords.ToArray();
            }
        }

        #endregion


        #endregion

        #region Methods

        #region private void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Метод обработки события нажатия кнопки Save
        /// </summary>
        private void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            SaveData();
            e.Cancel = true;
        }

        #endregion

        #region private void complianceControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void complianceDirectiveControl_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            bool permission = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            buttonEditRecord.Enabled = (permission && (e.ItemsCount > 0) && (e.ItemsCount < 2));
            buttonDeleteRecord.Enabled = (permission && (e.ItemsCount > 0));
        }

        #endregion

        #region private void complianceControl_ItemEdited(object sender, EventArgs e)

        private void complianceDirectiveControl_ItemEdited(object sender, EventArgs e)
        {
            UpdateDetail();
        }

        #endregion
        
        #region private void complianceControl_SizeChanged(object sender, EventArgs e)

        private void complianceDirectiveControl_SizeChanged(object sender, EventArgs e)
        {
            buttonAddCompliance.Location = new Point(0, complianceControl.Bottom + COMPLIANCE_INTERVAL);
            buttonAddActualData.Location = new Point(buttonAddCompliance.Right, complianceControl.Bottom + COMPLIANCE_INTERVAL);
            buttonEditRecord.Location = new Point(buttonAddActualData.Right, complianceControl.Bottom + COMPLIANCE_INTERVAL);
            buttonDeleteRecord.Location = new Point(buttonEditRecord.Right, complianceControl.Bottom + COMPLIANCE_INTERVAL);
            buttonInstallPickOffDetail.Location = new Point(buttonDeleteRecord.Right, complianceControl.Bottom + COMPLIANCE_INTERVAL);
        }

        #endregion
        
        #region private void complianceDetailContainer_Extending(object sender, EventArgs e)

        private void complianceDirectiveContainer_Extending(object sender, EventArgs e)
        {
            panelCompliance.Visible = !panelCompliance.Visible;
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (generalInformationControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    UpdateDetail();
                }
            }
            else
            {
                UpdateDetail();
            }
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        public bool SaveData()
        {
/*            string message = "";
            if (generalInformationControl.PartNumber == "")
            {
                GetMessage(ref message, "Part Number");
            }
            if (generalInformationControl.SerialNumber == "")
            {
                GetMessage(ref message, "Serial Number");
            }
            if (generalInformationControl.Description == "")
            {
                GetMessage(ref message, "Description");
            }
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }*/
            generalInformationControl.Focus();
            baseDetailHeaderControl.SaveData();
            generalInformationControl.SaveData();
            compliancePerformanceControl.SaveData();
            warrantyControl.SaveData();
            easaControl.SaveData();
            if (!currentDetail.InUse)
                storeControl.SaveData();

            try
            {
                currentDetail.Save(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            UpdateDetail(false);
            return true;
        }

        #endregion

        #region private void UpdateDetail()

        private void UpdateDetail()
        {
            UpdateDetail(true);
        }

        #endregion

        #region private void UpdateDetail(bool reloadDetail)

        private void UpdateDetail(bool reloadDetail)
        {
            try
            {
                if (reloadDetail)
                    if (currentDetail is BaseDetail)
                        currentDetail.Reload();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex); 
                return;
            }


            bool permission = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);
            
            headerControl.ActionControl.ShowEditButton = permission;
            buttonAddCompliance.Enabled = (permission && currentDetail.GetDetailDirectives().Length > 0);

            complianceDirectiveControl_SelectedItemsChanged(complianceControl, new SelectedItemsChangeEventArgs(0));

            baseDetailHeaderControl.UpdateInformation();
            generalInformationControl.UpdateInformation();
            compliancePerformanceControl.UpdateInformation();
            warrantyControl.UpdateInformation();
            easaControl.UpdateInformation();
            if (!currentDetail.InUse)
                storeControl.UpdateInformation();


            complianceControl.UpdateItems();
            complianceControl.DoubleClickEnable = permission;
            headerControl.ContextActionControl.ButtonPrint.Enabled = !(DisplayedDetailRecords.Length == 0);


        }

        #endregion

        #region private void buttonDeleteRecord_Click(object sender, EventArgs e)

        /// <summary>
        /// Удаляет техническую запись(записи) агрегата
        /// </summary>
        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {

            string message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "record");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {

                for (int i = 0; i < complianceControl.SelectedItems.Count; i++)
                        currentDetail.RemoveRecord(complianceControl.SelectedItems[i]);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
                UpdateDetail();
            }
        }

        #endregion

        #region private void buttonEditRecord_Click(object sender, EventArgs e)

        /// <summary>
        /// Редактирует техничесую запись агрегата
        /// </summary>
        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            if (complianceControl.SelectedItem == null)
                return;
            if (complianceControl.SelectedItem.RecordType == RecordTypesCollection.Instance.TransferType)
            {
                TransferRecordForm form = new TransferRecordForm(currentDetail, (TransferRecord)complianceControl.SelectedItem);
                form.RecordChanged += form_RecordChanged;
                form.ShowDialog();
            }
            else if (complianceControl.SelectedItem.RecordType == RecordTypesCollection.Instance.ActualStateRecordType)
            {
                ActualStateRecordForm form = new ActualStateRecordForm((ActualStateRecord)complianceControl.SelectedItem);
                form.RecordChanged += form_RecordChanged;
                form.ShowDialog();
            }
            else
            {
                ComplianceForm form = new ComplianceForm((DirectiveRecord)complianceControl.SelectedItem);
                form.RecordChanged += form_RecordChanged;
                form.ShowDialog();
            }
        }

        #endregion

        #region private void buttonAddCompliance_Click(object sender, EventArgs e)

        /// <summary>
        /// Добавляет техническую запись агрегата
        /// </summary>
        private void buttonAddCompliance_Click(object sender, EventArgs e)
        {
            ComplianceForm form = new ComplianceForm(currentDetail);
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void buttonAddActualData_Click(object sender, EventArgs e)

        private void buttonAddActualData_Click(object sender, EventArgs e)
        {
            ActualStateRecordForm form = new ActualStateRecordForm(currentDetail);
            form.RecordChanged += form_RecordChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            BaseDetail baseDetail;
            if (currentDetail is BaseDetail)
                baseDetail = (BaseDetail)currentDetail;
            else
                baseDetail = currentDetail.Parent as BaseDetail;
            if (baseDetail == null)
                return;
            string caption = baseDetail.ParentAircraft.RegistrationNumber + ". Component " + currentDetail.SerialNumber + ". Compliance List";
            ComplianceListBuilder reportBuilder = new ComplianceListBuilder(complianceControl.GetItemsArray());
            e.DisplayerText = caption;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredComplianceListReport(caption, DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString()), reportBuilder);
        }

        #endregion

        #region private void buttonInstallPickOffDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonInstallPickOffDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            MoveDetailForm form;
            if (currentDetail.InUse)
                form = new MoveDetailForm(currentDetail, MoveDetailFormMode.MoveToStore, null);
                
            else
                form = new MoveDetailForm(currentDetail, MoveDetailFormMode.MoveToAircraft, null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (currentDetail is BaseDetail)
                    e.DisplayerText = ((Aircraft)currentDetail.Parent).RegistrationNumber + ". Component SN " + currentDetail.SerialNumber;
                else
                    e.DisplayerText = ((Aircraft)currentDetail.Parent.Parent).RegistrationNumber + ". Component SN " + currentDetail.SerialNumber;
                e.RequestedEntity = new DispatcheredDetailScreen(currentDetail);
            }
            else
                e.Cancel = true;
        }
        #endregion

        #region private static void GetMessage(ref string message, string field)
        /// <summary>
        /// Метод, предназначенный для формирования сообщения для MessageBox
        /// </summary>
        private static void GetMessage(ref string message, string field)
        {
            if (message == "")
                message += "Please fill " + field;
            else
                message += ", " + field;
        }

        #endregion

        #region private void form_RecordChanged(object sender, EventArgs e)

        private void form_RecordChanged(object sender, EventArgs e)
        {
            UpdateDetail(false);
        }

        #endregion

        #endregion

    }
}