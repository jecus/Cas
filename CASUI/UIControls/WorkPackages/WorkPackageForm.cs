using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.UIControls.WorkPackages
{
    /// <summary>
    /// Форма для редактирования свойств рабочего пакета
    /// </summary>
    public class WorkPackageForm : Form
    {

        #region Fields

        private readonly WorkPackage currentWorkPackage;
        private readonly Aircraft parentAircraft;
        
        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private TabPage tabPageMaintenance;
        private Label labelWorkPackage;
        private Label labelDescription;
        private Label labelCheckType;
        private Label labelAuthor;
        private Label labelOpeningDate;
        private CheckBox checkBoxPublish;
        private CheckBox checkBoxClose;
        private Label labelStation;
        private Label labelRemarks;
        private Label labelMaintenanceReleaseCertificateNo;
        private Label labelMaintenanceReportNo;
        private TextBox textBoxWorkPackage;
        private TextBox textBoxDescription;
        private TextBox textBoxCheckType;
        private TextBox textBoxAuthor;
        private DateTimePicker dateTimePickerOpeningDate;
        private DateTimePicker dateTimePickerPublishingDate;
        private DateTimePicker dateTimePickerClosingDate;
        private TextBox textBoxStation;
        private TextBox textBoxRemarks;
        private TextBox textBoxMaintenanceReleaseCertificateNo;
        private TextBox textBoxMaintenanceReportNo;
        private WindowsFormAttachedFileControl fileControl;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Label labelSeparator3;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        private const int LABEL_WIDTH = 130;
        private readonly Icons icons = new Icons();
        private ScreenMode mode;

        #endregion

        #region Constructors

        #region public WorkPackageForm(Aircraft parentAircraft)

        /// <summary>
        /// Создает форму для добавления рабочего пакета
        /// </summary>
        /// <param name="parentAircraft">ВС, к которому добавляется робочий пакет</param>
        public WorkPackageForm(Aircraft parentAircraft)
        {
            this.parentAircraft = parentAircraft;
            currentWorkPackage = new WorkPackage();
            mode = ScreenMode.Add;
            InitializeComponent();
            Text = parentAircraft.RegistrationNumber + ". New Work Package";
            textBoxWorkPackage.Text = parentAircraft.GetNewWorkPackageTitle();
        }

        #endregion

        #region public WorkPackageForm(WorkPackage currentWorkPackage)

        /// <summary>
        /// Создает форму для редактирования свойств рабочего пакета
        /// </summary>
        /// <param name="currentWorkPackage">Редактируемый рабочий пакет</param>
        public WorkPackageForm(WorkPackage currentWorkPackage)
        {
            this.currentWorkPackage = currentWorkPackage;
            mode = ScreenMode.Edit;
            InitializeComponent();
            Text = ((Aircraft) currentWorkPackage.Parent).RegistrationNumber + ". " + currentWorkPackage.Title;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public WorkPackageStatus CurrentStatus

        /// <summary>
        /// Вовзращает текущий статус робочего пакета
        /// </summary>
        public WorkPackageStatus CurrentStatus
        {
            get
            {
                WorkPackageStatus status;
                if (checkBoxClose.Checked)
                    status = WorkPackageStatus.Closed;
                else if (checkBoxPublish.Checked)
                    status = WorkPackageStatus.Published;
                else
                    status = WorkPackageStatus.Open;
                return status;
            }
        }

        #endregion
        
        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            tabPageMaintenance = new TabPage();
            labelWorkPackage = new Label();
            labelDescription = new Label();
            labelCheckType = new Label();
            labelAuthor = new Label();
            labelOpeningDate = new Label();
            checkBoxPublish = new CheckBox();
            checkBoxClose = new CheckBox();
            labelStation = new Label();
            labelRemarks = new Label();
            labelMaintenanceReleaseCertificateNo = new Label();
            labelMaintenanceReportNo = new Label();
            textBoxWorkPackage = new TextBox();
            textBoxCheckType = new TextBox();
            textBoxAuthor = new TextBox();
            textBoxDescription = new TextBox();
            dateTimePickerOpeningDate = new DateTimePicker();
            dateTimePickerPublishingDate = new DateTimePicker();
            dateTimePickerClosingDate = new DateTimePicker();
            textBoxStation = new TextBox();
            textBoxRemarks = new TextBox();
            textBoxMaintenanceReleaseCertificateNo = new TextBox();
            textBoxMaintenanceReportNo = new TextBox();
            AttachedFile file = new AttachedFile();
            file.FileData = currentWorkPackage.AttachmentData;
            file.FileName = currentWorkPackage.AttachmentFileName;
            fileControl = new WindowsFormAttachedFileControl(file, "Adobe PDF Files|*.pdf",
                                                            "There is no associated document proving the compliance of the work package. Enclose PDF file to prove the compliance.",
                                                           "Associated document proves the compliance of the work package. Open the document to see details.", icons.PDFSmall);
            labelSeparator = new Label();
            labelSeparator2 = new Label();
            labelSeparator3 = new Label();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageMaintenance);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelWorkPackage);
            tabPageGeneral.Controls.Add(textBoxWorkPackage);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelDescription);
            tabPageGeneral.Controls.Add(textBoxDescription);
            tabPageGeneral.Controls.Add(labelCheckType);
            tabPageGeneral.Controls.Add(textBoxCheckType);
            tabPageGeneral.Controls.Add(labelAuthor);
            tabPageGeneral.Controls.Add(textBoxAuthor);
            tabPageGeneral.Controls.Add(labelOpeningDate);
            tabPageGeneral.Controls.Add(dateTimePickerOpeningDate);
            tabPageGeneral.Controls.Add(checkBoxPublish);
            tabPageGeneral.Controls.Add(dateTimePickerPublishingDate);
            tabPageGeneral.Controls.Add(checkBoxClose);
            tabPageGeneral.Controls.Add(dateTimePickerClosingDate);
            tabPageGeneral.Controls.Add(labelStation);
            tabPageGeneral.Controls.Add(textBoxStation);
            tabPageGeneral.Controls.Add(labelSeparator3);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            // 
            // tabPageMaintenance
            // 
            tabPageMaintenance.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageMaintenance.Text = "Maintenance";
            tabPageMaintenance.Controls.Add(labelMaintenanceReleaseCertificateNo);
            tabPageMaintenance.Controls.Add(textBoxMaintenanceReleaseCertificateNo);
            tabPageMaintenance.Controls.Add(labelMaintenanceReportNo);
            tabPageMaintenance.Controls.Add(textBoxMaintenanceReportNo);
            tabPageMaintenance.Controls.Add(labelSeparator2);
            tabPageMaintenance.Controls.Add(fileControl);
            //
            // labelWorkPackage
            //
            labelWorkPackage.Font = Css.WindowsForm.Fonts.RegularFont;
            labelWorkPackage.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelWorkPackage.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelWorkPackage.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelWorkPackage.Text = "Work Package:";
            labelWorkPackage.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxWorkPackage
            //
            textBoxWorkPackage.BackColor = Color.White;
            textBoxWorkPackage.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxWorkPackage.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxWorkPackage.Location = new Point(labelWorkPackage.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxWorkPackage.Multiline = true;
            textBoxWorkPackage.Height = Css.WindowsForm.Constants.TEXT_BOX_WITH_PICTURE_BOX_HEIGHT;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelWorkPackage.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelDescription
            //
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDescription.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDescription
            //
            textBoxDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Location = new Point(labelDescription.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxDescription.Multiline = true;
            textBoxDescription.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            // 
            // labelCheckType
            // 
            labelCheckType.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCheckType.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCheckType.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxDescription.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelCheckType.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelCheckType.Text = "Check Type:";
            labelCheckType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCheckType
            // 
            textBoxCheckType.BackColor = Color.White;
            textBoxCheckType.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCheckType.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCheckType.Location = new Point(labelCheckType.Right, textBoxDescription.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            // 
            // labelAuthor
            // 
            labelAuthor.Font = Css.WindowsForm.Fonts.RegularFont;
            labelAuthor.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelAuthor.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelCheckType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelAuthor.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelAuthor.Text = "Author:";
            labelAuthor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.BackColor = Color.White;
            textBoxAuthor.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxAuthor.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxAuthor.Location = new Point(labelAuthor.Right, labelCheckType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            // 
            // labelOpeningDate
            // 
            labelOpeningDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelOpeningDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelOpeningDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelAuthor.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelOpeningDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelOpeningDate.Text = "Opening Date:";
            labelOpeningDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerOpeningDate
            //
            dateTimePickerOpeningDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerOpeningDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerOpeningDate.BackColor = Color.White;
            dateTimePickerOpeningDate.Location = new Point(labelOpeningDate.Right, labelAuthor.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerOpeningDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerOpeningDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // checkBoxPublish
            //
            checkBoxPublish.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxPublish.Font = Css.WindowsForm.Fonts.RegularFont;
            checkBoxPublish.ForeColor = Css.WindowsForm.Colors.ForeColor;
            checkBoxPublish.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelOpeningDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            checkBoxPublish.Size = new Size(Css.WindowsForm.Constants.DefaultLabelSize.Width - 5, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            checkBoxPublish.TextAlign = ContentAlignment.MiddleLeft;
            checkBoxPublish.Text = "Published:";
            checkBoxPublish.CheckedChanged += checkBoxPublish_CheckedChanged;
            // 
            // dateTimePickerPublishingDate
            // 
            dateTimePickerPublishingDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerPublishingDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerPublishingDate.BackColor = Color.White;
            dateTimePickerPublishingDate.Location = new Point(labelOpeningDate.Right, labelOpeningDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerPublishingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerPublishingDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerPublishingDate.GotFocus += dateTimePickerPublishingDate_GotFocus;
            //
            // checkBoxClose
            //
            checkBoxClose.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxClose.Font = Css.WindowsForm.Fonts.RegularFont;
            checkBoxClose.ForeColor = Css.WindowsForm.Colors.ForeColor;
            checkBoxClose.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, checkBoxPublish.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            checkBoxClose.Size = new Size(Css.WindowsForm.Constants.DefaultLabelSize.Width - 5, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            checkBoxClose.TextAlign = ContentAlignment.MiddleLeft;
            checkBoxClose.Text = "Closed:";
            checkBoxClose.CheckedChanged += checkBoxClose_CheckedChanged;
            // 
            // dateTimePickerClosingDate
            // 
            dateTimePickerClosingDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerClosingDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerClosingDate.BackColor = Color.White;
            dateTimePickerClosingDate.Location = new Point(labelOpeningDate.Right, checkBoxPublish.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerClosingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerClosingDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerClosingDate.GotFocus += dateTimePickerClosingDate_GotFocus;
            // 
            // labelStation
            // 
            labelStation.Font = Css.WindowsForm.Fonts.RegularFont;
            labelStation.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelStation.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, checkBoxClose.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelStation.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelStation.Text = "Station:";
            labelStation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxStation
            // 
            textBoxStation.BackColor = Color.White;
            textBoxStation.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxStation.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxStation.Location = new Point(labelStation.Right, checkBoxClose.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator3
            //
            labelSeparator3.AutoSize = false;
            labelSeparator3.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelStation.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator3.Height = 2;
            labelSeparator3.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Location = new Point(labelRemarks.Right, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            // 
            // labelMaintenanceReleaseCertificateNo
            // 
            labelMaintenanceReleaseCertificateNo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelMaintenanceReleaseCertificateNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelMaintenanceReleaseCertificateNo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelMaintenanceReleaseCertificateNo.Size = new Size(LABEL_WIDTH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelMaintenanceReleaseCertificateNo.Text = "Release Certificate No:";
            labelMaintenanceReleaseCertificateNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMaintenanceReleaseCertificateNo
            // 
            textBoxMaintenanceReleaseCertificateNo.BackColor = Color.White;
            textBoxMaintenanceReleaseCertificateNo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxMaintenanceReleaseCertificateNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxMaintenanceReleaseCertificateNo.Location = new Point(labelMaintenanceReleaseCertificateNo.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            // 
            // labelMaintenanceReportNo
            // 
            labelMaintenanceReportNo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelMaintenanceReportNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelMaintenanceReportNo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelMaintenanceReleaseCertificateNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelMaintenanceReportNo.Size = new Size(LABEL_WIDTH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelMaintenanceReportNo.Text = "Report No:";
            labelMaintenanceReportNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMaintenanceReportNo
            // 
            textBoxMaintenanceReportNo.BackColor = Color.White;
            textBoxMaintenanceReportNo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxMaintenanceReportNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxMaintenanceReportNo.Location = new Point(labelMaintenanceReportNo.Right, labelMaintenanceReleaseCertificateNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelMaintenanceReportNo.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            //
            // fileControl
            //
            fileControl.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // buttonOK
            //
            buttonOK.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonOK.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonOK.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonApply
            //
            buttonApply.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonApply.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonApply.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonApply.Text = "Apply";
            buttonApply.Click += buttonApply_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonCancel.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;


            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
            if (mode == ScreenMode.Edit)
                Text = ((Aircraft)currentWorkPackage.Parent).RegistrationNumber + ". " + currentWorkPackage.Title;
            else
                Text = parentAircraft.RegistrationNumber + ". New Work Package";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            textBoxWorkPackage.Text = currentWorkPackage.Title;
            textBoxDescription.Text = currentWorkPackage.Description;
            textBoxCheckType.Text = currentWorkPackage.CheckType;
            textBoxAuthor.Text = currentWorkPackage.Author;
            checkBoxPublish.Checked = (currentWorkPackage.Status == WorkPackageStatus.Published || currentWorkPackage.Status == WorkPackageStatus.Closed);
            checkBoxClose.Checked = (currentWorkPackage.Status == WorkPackageStatus.Closed);
            dateTimePickerOpeningDate.Value = currentWorkPackage.OpeningDate;
            dateTimePickerPublishingDate.Value = currentWorkPackage.PublishingDate;
            dateTimePickerClosingDate.Value = currentWorkPackage.ClosingDate;
            textBoxStation.Text = currentWorkPackage.Station;
            textBoxRemarks.Text = currentWorkPackage.Remarks;
            textBoxMaintenanceReleaseCertificateNo.Text = currentWorkPackage.ReleaseCertificateNo;
            textBoxMaintenanceReportNo.Text = currentWorkPackage.MaintenanceReportNo;
            //fileControl = false;
        }

        #endregion
        
        #region private void SaveData()

        /// <summary>
        /// Сохраняет данные рабочего пакета
        /// </summary>
        private void SaveData()
        {
            if (currentWorkPackage.Title != textBoxWorkPackage.Text)
                currentWorkPackage.Title = textBoxWorkPackage.Text;
            if (currentWorkPackage.Description != textBoxDescription.Text)
                currentWorkPackage.Description = textBoxDescription.Text;
            if (currentWorkPackage.CheckType != textBoxCheckType.Text)
                currentWorkPackage.CheckType = textBoxCheckType.Text;
            if (currentWorkPackage.Author != textBoxAuthor.Text)
                currentWorkPackage.Author = textBoxAuthor.Text;
            if (currentWorkPackage.OpeningDate != dateTimePickerOpeningDate.Value)
                currentWorkPackage.OpeningDate = dateTimePickerOpeningDate.Value;
            if (currentWorkPackage.PublishingDate != dateTimePickerPublishingDate.Value)
                currentWorkPackage.PublishingDate = dateTimePickerPublishingDate.Value;
            if (currentWorkPackage.ClosingDate != dateTimePickerClosingDate.Value)
                currentWorkPackage.ClosingDate = dateTimePickerClosingDate.Value;
            if (currentWorkPackage.Status != CurrentStatus)
                currentWorkPackage.Status = CurrentStatus;
            if (currentWorkPackage.Station != textBoxStation.Text)
                currentWorkPackage.Station = textBoxStation.Text;
            if (currentWorkPackage.Remarks != textBoxRemarks.Text)
                currentWorkPackage.Remarks = textBoxRemarks.Text;
            if (currentWorkPackage.ReleaseCertificateNo != textBoxMaintenanceReleaseCertificateNo.Text)
                currentWorkPackage.ReleaseCertificateNo = textBoxMaintenanceReleaseCertificateNo.Text;
            if (currentWorkPackage.MaintenanceReportNo != textBoxMaintenanceReportNo.Text)
                currentWorkPackage.MaintenanceReportNo = textBoxMaintenanceReportNo.Text;


            if (fileControl.AttachedFile == null)
            {
                if (currentWorkPackage.AttachmentData != null)
                {
                    currentWorkPackage.AttachmentData = null;
                    currentWorkPackage.AttachmentFileName = "";
                }
            }
            else if (currentWorkPackage.AttachmentData != fileControl.AttachedFile.FileData || 
                currentWorkPackage.AttachmentFileName != fileControl.AttachedFile.FileName)
            {
                currentWorkPackage.AttachmentFileName = fileControl.AttachedFile.FileName;
                currentWorkPackage.AttachmentData = fileControl.AttachedFile.FileData;
            }

            try
            {
                if (mode == ScreenMode.Edit)
                    currentWorkPackage.Save(true);
                else if (mode == ScreenMode.Add)
                {
                    parentAircraft.AddWorkPackage(currentWorkPackage);
                    if (fileControl.AttachedFile != null && fileControl.AttachedFile.FileData != null)
                    {
                        currentWorkPackage.AttachmentFileName = fileControl.AttachedFile.FileName;
                        currentWorkPackage.AttachmentData = fileControl.AttachedFile.FileData;
                    }
                    mode = ScreenMode.Edit;
                    Text = ((Aircraft)currentWorkPackage.Parent).RegistrationNumber + ". " + currentWorkPackage.Title;
                }
                if (WorkPackageChanged != null)
                    WorkPackageChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }
        #endregion
        

        #region private void checkBoxPublish_CheckedChanged(object sender, EventArgs e)

        private void checkBoxPublish_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxPublish.Checked)
                checkBoxClose.Checked = false;
        }

        #endregion

        #region private void checkBoxClose_CheckedChanged(object sender, EventArgs e)

        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClose.Checked)
                checkBoxPublish.Checked = true;
        }

        #endregion

        #region private void dateTimePickerPublishingDate_GotFocus(object sender, EventArgs e)

        private void dateTimePickerPublishingDate_GotFocus(object sender, EventArgs e)
        {
            checkBoxPublish.Checked = true;
        }

        #endregion

        #region private void dateTimePickerClosingDate_GotFocus(object sender, EventArgs e)

        private void dateTimePickerClosingDate_GotFocus(object sender, EventArgs e)
        {
            checkBoxClose.Checked = true;
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveData();
            UpdateInformation();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
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
            tabControl.Size = new Size(ClientSize.Width - Css.WindowsForm.Constants.LEFT_MARGIN - Css.WindowsForm.Constants.RIGHT_MARGIN, ClientSize.Height - Css.WindowsForm.Constants.TOP_MARGIN - Css.WindowsForm.Constants.BOTTOM_MARGIN - Css.WindowsForm.Constants.BUTTON_HEIGHT - Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxWorkPackage.Width =
            textBoxDescription.Width =
            textBoxCheckType.Width =
            textBoxAuthor.Width =
            dateTimePickerOpeningDate.Width = 
            dateTimePickerPublishingDate.Width =
            dateTimePickerClosingDate.Width =
            textBoxStation.Width =
            textBoxRemarks.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            textBoxMaintenanceReleaseCertificateNo.Width = 
            textBoxMaintenanceReportNo.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - LABEL_WIDTH;
            labelSeparator.Width =
            labelSeparator2.Width =
            labelSeparator3.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            fileControl.MinimumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 0);
            fileControl.MaximumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 300);
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion

        #endregion
        
        #region Events

        /// <summary>
        /// Событие изменения данных рабочего пакета
        /// </summary>
        public event EventHandler WorkPackageChanged;

        #endregion
        
    }
}