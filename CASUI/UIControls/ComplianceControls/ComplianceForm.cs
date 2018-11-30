using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.Messages;
using CAS.UI.UIControls.Auxiliary;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CASTerms;

namespace CAS.UI.UIControls.ComplianceControls
{
    /// <summary>
    /// Форма для редактирования свойств записи Compliance
    /// </summary>
    public class ComplianceForm : Form
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly BaseDetailDirective currentDirective;
        private DirectiveRecord currentRecord;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelAircraft;
        private Label labelComponent;
        private Label labelWorkType;
        private Label labelDate;
        private Label labelAircraftTSNCSN;
        private Label labelHours;
        private Label labelCycles;
        private Label labelRemarks;
        private Label labelMaintenanceOrganization;
        private Label labelReference;
        private TextBox textBoxAircraft;
        private TextBox textBoxComponent;
        private ComboBox comboBoxWorkType;
        private DateTimePicker dateTimePickerDate;
        private TextBox textBoxHours;
        private TextBox textBoxCycles;
        private TextBox textBoxRemarks;
        private TextBox textBoxMaintenanceOrganization;
        private TextBox textBoxReference;
        private CheckBox checkBoxOfficialRecordsReceived;
        private WindowsFormAttachedFileControl fileControl;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Label labelSeparator3;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        private readonly Icons icons = new Icons();
        private Dictionary<string, RecordType> hashTextRecordType;
        private RecordTypesCollection recordTypesCollection;
        private bool actualStateChanged;
        private ActualStateRecord[] actualStateRecords;

        #endregion

        #region Constructors

        #region public ComplianceForm(BaseDetailDirective directive, DirectiveRecord directiveRecord)

        /// <summary>
        /// Создает форму для редактирования записи Compliance директивы
        /// </summary>
        /// <param name="directiveRecord">Запись Compliance</param>
        public ComplianceForm(DirectiveRecord directiveRecord)
        {
            mode = ScreenMode.Edit;
            currentRecord = directiveRecord;
            if (directiveRecord.Parent is BaseDetailDirective)
            {
                currentDirective = (BaseDetailDirective)directiveRecord.Parent;
                InitializeComponent();
                UpdateWorkTypes();
            }
            else
            {
                currentDetail = (AbstractDetail) directiveRecord.Parent.Parent;
                InitializeComponent();
                UpdateDetailDirectiveList();
            }
            UpdateInformation();
        }

        #endregion

        #region public ComplianceForm(BaseDetailDirective directive)

        /// <summary>
        /// Создает форму для добавления записи Compliance директиве
        /// </summary>
        /// <param name="directive">Директива</param>
        public ComplianceForm(BaseDetailDirective directive)
        {
            currentDirective = directive;
            currentRecord = new DirectiveRecord();
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateWorkTypes();
            UpdateInformation();
        }

        #endregion

        #region public ComplianceForm(AbstractDetail detail)

        /// <summary>
        /// Создает форму для добавления записи Compliance работе агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        public ComplianceForm(AbstractDetail detail)
        {
            currentDetail = detail;
            currentRecord = new DirectiveRecord();
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateDetailDirectiveList();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Properties

        #region public string AircraftSN

        /// <summary>
        /// Возвращает или устанавливает информацию о ВС
        /// </summary>
        public string AircraftSN
        {
            get
            {
                return textBoxAircraft.Text;
            }
            set
            {
                textBoxAircraft.Text = value;
            }
        }

        #endregion

        #region public string ComponentSN

        /// <summary>
        /// Возвращает или устанавливает информацию об агрегате
        /// </summary>
        public string ComponentSN
        {
            get
            {
                return textBoxComponent.Text;
            }
            set
            {
                textBoxComponent.Text = value;
            }
        }

        #endregion

        #region public string LabelComponent

        /// <summary>
        /// Возвращает или устанавливает название поля агрегата(или директивы)
        /// </summary>
        public string LabelComponent
        {
            get
            {
                return labelComponent.Text;
            }
            set
            {
                labelComponent.Text = value;
            }
        }

        #endregion

        #region public RecordType RecordType

        /// <summary>
        /// Возвращает или устанавливает тип текущей работы
        /// </summary>
        public RecordType RecordType
        {
            get
            {
                return hashTextRecordType[comboBoxWorkType.Text];
            }
            set
            {
                comboBoxWorkType.Text = value.FullName;
            }
        }

        #endregion

        #region public DetailDirective DetailDirective

        /// <summary>
        /// Возвращает или устанавливает тип текущей работы
        /// </summary>
        public DetailDirective DetailDirective
        {
            get
            {
                return (DetailDirective)comboBoxWorkType.SelectedItem;
            }
            set
            {
                comboBoxWorkType.SelectedItem = value;
            }
        }

        #endregion

        #region public DateTime Date

        /// <summary>
        /// Возвращает или устанавливает дату отправки агрегата на работу
        /// </summary>
        public DateTime Date
        {
            get
            {
                return dateTimePickerDate.Value;
            }
            set
            {
                dateTimePickerDate.Value = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Возвращает или устанавливает замечания к работе
        /// </summary>
        public string Remarks
        {
            get
            {
                return textBoxRemarks.Text;
            }
            set
            {
                textBoxRemarks.Text = value;
            }
        }

        #endregion

        #region public string MaintenanceOrganization

        /// <summary>
        /// Возвращает или устанавливает базу ТО, которая выполняла работу
        /// </summary>
        public string MaintenanceOrganization
        {
            get
            {
                return textBoxMaintenanceOrganization.Text;
            }
            set
            {
                textBoxMaintenanceOrganization.Text = value;
            }
        }

        #endregion

        #region public string Reference

        /// <summary>
        /// На основании какого документа была сделана работа или перемещен агрегат
        /// </summary>
        public string Reference
        {
            get
            {
                return textBoxReference.Text;
            }
            set
            {
                textBoxReference.Text = value;
            }
        }

        #endregion

        #region public bool OfficialRecordsReceived

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее потверждено ли выполнение работы
        /// </summary>
        public bool OfficialRecordsReceived
        {
            get
            {
                return checkBoxOfficialRecordsReceived.Checked;
            }
            set
            {
                checkBoxOfficialRecordsReceived.Checked = value;
            }
        }

        #endregion

        #region public AttachedFile AttachedFile

        /// <summary>
        /// Возвращает или устанавливает прикрепленный файл
        /// </summary>
        public AttachedFile AttachedFile
        {
            get
            {
                return fileControl.AttachedFile;
            }
            set
            {
                fileControl.AttachedFile = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelAircraft = new Label();
            labelComponent = new Label();
            labelWorkType = new Label();
            labelDate = new Label();
            labelAircraftTSNCSN = new Label();
            labelHours = new Label();
            labelCycles = new Label();
            labelRemarks = new Label();
            labelMaintenanceOrganization = new Label();
            labelReference = new Label();
            textBoxAircraft = new TextBox();
            textBoxComponent = new TextBox();
            comboBoxWorkType = new ComboBox();
            dateTimePickerDate = new DateTimePicker();
            textBoxHours = new TextBox();
            textBoxCycles = new TextBox();
            textBoxRemarks = new TextBox();
            textBoxMaintenanceOrganization = new TextBox();
            textBoxReference = new TextBox();
            checkBoxOfficialRecordsReceived = new CheckBox();
            fileControl = new WindowsFormAttachedFileControl(currentRecord.AttachedFile, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
                    "Attached file proves the compliance.", icons.PDFSmall);
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelSeparator = new Label();
            labelSeparator2 = new Label();
            labelSeparator3 = new Label();
            hashTextRecordType = new Dictionary<string, RecordType>();
            recordTypesCollection = RecordTypesCollection.Instance;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            //
            // labelAircraft
            //
            labelAircraft.Font = Css.WindowsForm.Fonts.RegularFont;
            labelAircraft.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelAircraft.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelAircraft.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelAircraft.Text = "Aircraft:";
            labelAircraft.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAircraft
            //
            textBoxAircraft.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxAircraft.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxAircraft.Location = new Point(labelAircraft.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxAircraft.ReadOnly = true;
            //
            // labelComponent
            //
            labelComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            labelComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelComponent.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelAircraft.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelComponent.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelComponent.Text = "Component:";
            labelComponent.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxComponent
            //
            textBoxComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxComponent.Location = new Point(labelComponent.Right, labelAircraft.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxComponent.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelComponent.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelWorkType
            //
            labelWorkType.Font = Css.WindowsForm.Fonts.RegularFont;
            labelWorkType.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelWorkType.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelWorkType.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelWorkType.Text = "Work Type:";
            labelWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxWorkType
            //
            comboBoxWorkType.BackColor = Color.White;
            comboBoxWorkType.Font = Css.WindowsForm.Fonts.RegularFont;
            comboBoxWorkType.ForeColor = Css.WindowsForm.Colors.ForeColor;
            comboBoxWorkType.Location = new Point(labelWorkType.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            if (mode == ScreenMode.Edit)
                comboBoxWorkType.Enabled = false;
            // 
            // labelDate
            // 
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelWorkType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDate.BackColor = Color.White;
            dateTimePickerDate.Location = new Point(labelDate.Right, labelWorkType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDate.ValueChanged += dateTimePickerDate_ValueChanged;
            //
            // labelAircraftTSNCSN
            //
            labelAircraftTSNCSN.Font = Css.WindowsForm.Fonts.RegularFont;
            labelAircraftTSNCSN.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelAircraftTSNCSN.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelAircraftTSNCSN.Text = "TSN/CSN";
            labelAircraftTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            labelAircraftTSNCSN.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelHours
            //
            labelHours.Font = Css.WindowsForm.Fonts.RegularFont;
            labelHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelHours.Size = new Size(Css.WindowsForm.Constants.LABEL_SHORT_WITH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelHours.Text = "Hours:";
            labelHours.TextAlign = ContentAlignment.MiddleLeft;
            labelHours.Location = new Point(labelAircraftTSNCSN.Right, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // textBoxHours
            //
            textBoxHours.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxHours.BackColor = Color.White;
            textBoxHours.Location = new Point(labelHours.Right, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxHours.Width = Css.WindowsForm.Constants.TEXT_BOX_SHORT_WITH;
            textBoxHours.TextChanged += ActualState_TextChanged;
            //
            // labelCycles
            //
            labelCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCycles.Size = new Size(Css.WindowsForm.Constants.LABEL_SHORT_WITH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelCycles.Text = "Cycles:";
            labelCycles.TextAlign = ContentAlignment.MiddleLeft;
            labelCycles.Location = new Point(textBoxHours.Right + Css.WindowsForm.Constants.LABEL_MARGIN*2, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // textBoxCycles
            //
            textBoxCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCycles.BackColor = Color.White;
            textBoxCycles.Location = new Point(labelCycles.Right, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxCycles.Width = Css.WindowsForm.Constants.TEXT_BOX_SHORT_WITH;
            textBoxCycles.TextChanged += ActualState_TextChanged;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            textBoxRemarks.Location = new Point(labelRemarks.Right, textBoxHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxRemarks.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelMaintenanceOrganization
            //
            labelMaintenanceOrganization.Font = Css.WindowsForm.Fonts.RegularFont;
            labelMaintenanceOrganization.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelMaintenanceOrganization.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelMaintenanceOrganization.Text = "MO:";
            labelMaintenanceOrganization.TextAlign = ContentAlignment.MiddleLeft;
            labelMaintenanceOrganization.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // textBoxMaintenanceOrganization
            //
            textBoxMaintenanceOrganization.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxMaintenanceOrganization.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxMaintenanceOrganization.BackColor = Color.White;
            textBoxMaintenanceOrganization.Location = new Point(labelMaintenanceOrganization.Right, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelReference
            //
            labelReference.Font = Css.WindowsForm.Fonts.RegularFont;
            labelReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelReference.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelReference.Text = "Reference:";
            labelReference.TextAlign = ContentAlignment.MiddleLeft;
            labelReference.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxMaintenanceOrganization.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // textBoxReference
            //
            textBoxReference.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxReference.BackColor = Color.White;
            textBoxReference.Location = new Point(labelMaintenanceOrganization.Right, textBoxMaintenanceOrganization.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // checkBoxOfficialRecordsReceived
            //
            checkBoxOfficialRecordsReceived.Font = Css.WindowsForm.Fonts.RegularFont;
            checkBoxOfficialRecordsReceived.ForeColor = Css.WindowsForm.Colors.ForeColor;
            checkBoxOfficialRecordsReceived.TextAlign = ContentAlignment.MiddleLeft;
            checkBoxOfficialRecordsReceived.Text = "Official Records Received:";
            checkBoxOfficialRecordsReceived.Location = new Point(labelReference.Right, textBoxReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator3
            //
            labelSeparator3.AutoSize = false;
            labelSeparator3.Height = 2;
            labelSeparator3.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator3.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, checkBoxOfficialRecordsReceived.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // fileControl
            //
            fileControl.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
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
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelAircraft);
            tabPageGeneral.Controls.Add(textBoxAircraft);
            tabPageGeneral.Controls.Add(labelComponent);
            tabPageGeneral.Controls.Add(textBoxComponent);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelWorkType);
            tabPageGeneral.Controls.Add(comboBoxWorkType);
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(dateTimePickerDate);
            tabPageGeneral.Controls.Add(labelAircraftTSNCSN);
            tabPageGeneral.Controls.Add(labelHours);
            tabPageGeneral.Controls.Add(textBoxHours);
            tabPageGeneral.Controls.Add(labelCycles);
            tabPageGeneral.Controls.Add(textBoxCycles);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            tabPageGeneral.Controls.Add(labelSeparator2);
            tabPageGeneral.Controls.Add(labelMaintenanceOrganization);
            tabPageGeneral.Controls.Add(textBoxMaintenanceOrganization);
            tabPageGeneral.Controls.Add(labelReference);
            tabPageGeneral.Controls.Add(textBoxReference);
            tabPageGeneral.Controls.Add(checkBoxOfficialRecordsReceived);
            tabPageGeneral.Controls.Add(labelSeparator3);
            tabPageGeneral.Controls.Add(fileControl);

            string complianceText = ". Compliance";
            if (currentDetail != null)
            {
                Text = "SN " + currentDetail.SerialNumber + complianceText;
                if (!currentDetail.InUse)
                    labelAircraft.Text = "Store:";
            }
            else
                Text = currentDirective.Title + complianceText;
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
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
            if (currentDetail != null)
            {
                if (currentDetail is BaseDetail)
                    AircraftSN = ((BaseDetail) currentDetail).ParentAircraft.RegistrationNumber;
                else
                    AircraftSN = ((Aircraft)currentDetail.Parent.Parent).RegistrationNumber;
                LabelComponent = "Component:";
                ComponentSN = "SN " + currentDetail.SerialNumber;
                if (currentRecord.Parent != null)
                    DetailDirective = (DetailDirective)currentRecord.Parent;
                else if (comboBoxWorkType.Items.Count > 0)
                    comboBoxWorkType.SelectedIndex = 0;
            }
            else
            {
                AircraftSN = ((Aircraft)currentDirective.Parent.Parent).RegistrationNumber;
                LabelComponent = "Directive:";
                ComponentSN = currentDirective.Title;
                if (currentRecord.Parent != null)
                    RecordType = currentRecord.RecordType;
                else if (comboBoxWorkType.Items.Count > 0)
                    comboBoxWorkType.SelectedIndex = 0;
            }
            if (mode == ScreenMode.Edit)
            {
                Date = currentRecord.RecordDate;
                Remarks = currentRecord.Description;
                MaintenanceOrganization = currentRecord.MaintenanceOrganization;
                Reference = currentRecord.Reference;
                OfficialRecordsReceived = currentRecord.OfficialDocumentsReceived;
            }
            FillActualState();
        }

        #endregion

        #region private void UpdateWorkTypes()

        private void UpdateWorkTypes()
        {
            hashTextRecordType.Add(recordTypesCollection.DirectivePerformanceRecordType.FullName, recordTypesCollection.DirectivePerformanceRecordType);
            comboBoxWorkType.Items.Add(recordTypesCollection.DirectivePerformanceRecordType.FullName); 
            hashTextRecordType.Add(recordTypesCollection.DirectiveClosingRecordType.FullName, recordTypesCollection.DirectiveClosingRecordType);
            comboBoxWorkType.Items.Add(recordTypesCollection.DirectiveClosingRecordType.FullName);
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                hashTextRecordType.Add(recordTypesCollection.DirectiveNotApplicableRecordType.FullName, recordTypesCollection.DirectiveNotApplicableRecordType);
                comboBoxWorkType.Items.Add(recordTypesCollection.DirectiveNotApplicableRecordType.FullName);
                hashTextRecordType.Add(recordTypesCollection.DirectiveSupersedingRecordType.FullName, recordTypesCollection.DirectiveSupersedingRecordType);
                comboBoxWorkType.Items.Add(recordTypesCollection.DirectiveSupersedingRecordType.FullName);
                hashTextRecordType.Add(recordTypesCollection.DirectiveTerminatingType.FullName, recordTypesCollection.DirectiveTerminatingType);
                comboBoxWorkType.Items.Add(recordTypesCollection.DirectiveTerminatingType.FullName);
            }
            comboBoxWorkType.SelectedIndex = 0;
        }

        #endregion

        #region private void UpdateDetailDirectiveList()

        private void UpdateDetailDirectiveList()
        {
            List<DetailDirective> detailDirectives = new List<DetailDirective>(currentDetail.GetDetailDirectives());
            for (int i = 0; i < detailDirectives.Count; i++ )
                comboBoxWorkType.Items.Add(detailDirectives[i]);
            if (comboBoxWorkType.Items.Count > 0)
                comboBoxWorkType.SelectedIndex = 0;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            TimeSpan hours;
            int cycles;
            if (!UsefulMethods.ParseTime(textBoxHours.Text, out hours))
            {
                SimpleBalloon.Show(textBoxHours, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH:MM");
                return false;
            }
            if (!int.TryParse(textBoxCycles.Text, out cycles))
            {
                SimpleBalloon.Show(textBoxCycles, ToolTipIcon.Warning, "Incorrect value", "Please enter integer value");
                return false;
            }
            if (currentRecord.RecordDate != Date)
                currentRecord.RecordDate = Date;
            if (currentRecord.Description != Remarks)
                currentRecord.Description = Remarks;
            if (currentRecord.AttachedFile != AttachedFile)
            {
                currentRecord.AttachedFile.FileName = AttachedFile.FileName;
                currentRecord.AttachedFile.FileData = AttachedFile.FileData;
            }
            if (currentRecord.MaintenanceOrganization != MaintenanceOrganization)
                currentRecord.MaintenanceOrganization = MaintenanceOrganization;
            if (currentRecord.Reference != Reference)
                currentRecord.Reference = Reference;
            if (currentRecord.OfficialDocumentsReceived != OfficialRecordsReceived)
                currentRecord.OfficialDocumentsReceived = OfficialRecordsReceived;

            try
            {
                if (mode == ScreenMode.Add)
                {
                    currentRecord.Completed = true;
                    if (currentDetail != null)
                    {
                        currentRecord = new DetailDirectiveRecord(currentRecord);
                        ((DetailDirective)comboBoxWorkType.SelectedItem).AddPerformance((DetailDirectiveRecord)currentRecord);
                    }
                    else
                    {
                        if (currentRecord.RecordType != RecordType)
                            currentRecord.RecordType = RecordType;
                        if (currentRecord.RecordType == RecordTypesCollection.Instance.DirectivePerformanceRecordType &&
                            !currentDirective.RepeatedlyPerform)
                            currentRecord.RecordType = RecordTypesCollection.Instance.DirectiveClosingRecordType;
                        currentDirective.AddRecord(currentRecord);
                    }
                    if (AttachedFile != null)
                    {
                        currentRecord.AttachedFile.FileName = AttachedFile.FileName;
                        currentRecord.AttachedFile.FileData = AttachedFile.FileData;
                    }
                    mode = ScreenMode.Edit;
                }
                currentRecord.Save(true);
                if (actualStateChanged)
                {
                    bool exist = false;
                    int index = -1;
                    for (int i = actualStateRecords.Length - 1; i >= 0; i--)
                    {
                        if (UsefulMethods.CompareDates(actualStateRecords[i].RecordDate, dateTimePickerDate.Value))
                        {
                            exist = true;
                            index = i;
                            break;
                        }
                    }
                    if (exist)
                    {
                        if (MessageBox.Show("There is another actual state record for this date.\nExisting data will be updated.\nContinue?", new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            actualStateRecords[index].Lifelength = new Lifelength(new TimeSpan(0), cycles, hours);
                            actualStateRecords[index].Save();
                        }
                    }
                    else
                    {
                        ActualStateRecord record = new ActualStateRecord(new Lifelength(new TimeSpan(0), cycles, hours));
                        record.RecordDate = dateTimePickerDate.Value;
                        if (currentRecord.Parent.Parent is BaseDetail)
                            ((BaseDetail)currentRecord.Parent.Parent).AddRecord(record);
                        else
                            ((BaseDetail) currentRecord.Parent.Parent.Parent).AddRecord(record);
                    }
                }
                if (RecordChanged != null)
                    RecordChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion


        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveData();
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
            textBoxAircraft.Width = 
            textBoxComponent.Width =
            comboBoxWorkType.Width =
            dateTimePickerDate.Width = 
            textBoxRemarks.Width =
            textBoxMaintenanceOrganization.Width =
            textBoxReference.Width =
            checkBoxOfficialRecordsReceived.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
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

        #region private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            if (!actualStateChanged)
                FillActualState();
        }

        #endregion

        #region private void FillActualState()

        private void FillActualState()
        {
            Lifelength actualState;
            if (currentDetail != null)
            {
                if (currentDetail is BaseDetail)
                {
                    actualState = currentDetail.GetLifelength(dateTimePickerDate.Value);
                    actualStateRecords = currentDetail.GetActualSettingRecords(dateTimePickerDate.Value);
                }
                else
                {
                    actualState = ((BaseDetail)currentDetail.Parent).GetLifelength(dateTimePickerDate.Value);
                    actualStateRecords = ((BaseDetail)currentDetail.Parent).GetActualSettingRecords(dateTimePickerDate.Value);
                }
            }
            else
            {
                actualState = ((BaseDetail)currentDirective.Parent).GetLifelength(dateTimePickerDate.Value);
                actualStateRecords = ((BaseDetail) currentDirective.Parent).GetActualSettingRecords(dateTimePickerDate.Value);
            }
            if (actualState != null)
            {
                textBoxHours.Text = UsefulMethods.HoursToString(actualState.Hours);
                textBoxCycles.Text = actualState.Cycles.ToString();
            }
            actualStateChanged = false;
        }

        #endregion

        #region private void ActualState_TextChanged(object sender, EventArgs e)

        private void ActualState_TextChanged(object sender, EventArgs e)
        {
            actualStateChanged = true;
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие изменения записи
        /// </summary>
        public event EventHandler RecordChanged;

        #endregion


    }
}