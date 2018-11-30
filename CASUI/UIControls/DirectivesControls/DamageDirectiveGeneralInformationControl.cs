using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Management;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Отображает информацию о директиве
    ///</summary>
    public class DamageDirectiveGeneralInformationControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int TOP_MARGIN = 20;
        private const int LABEL_WIDTH = 180;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int WIDTH_INTERVAL = 600;

        private BaseDetailDirective currentDirective;

        private Label labelTitle;
        private Label labelDescription;
        private Label labelInitialDocuments;
        private Label labelRequiredInspection;
        private Label labelSinceNew;
        private Label labelRepeatInterval;
        private Label labelNotifyBefore;
        private Label labelRemarks;
        private Label labelHiddenRemarks;
        private Label labelLastCompliance;
        private Label labelDate;
        private Label labelLastComplianceTSNCSN;
        private Label labelInspectionDocument;
        private TextBox textboxTitle;
        private RadioButton radioButtonSDR;
        private RadioButton radioButtonDBC;
        private TextBox textboxDescription;
        private TextBox textBoxInitialDocuments;
        private TextBox textBoxRequiredInspection;
        private LifelengthViewer lifelengthViewerSinceNew;
        private LifelengthViewer lifelengthViewerRepeatInterval;
        private LifelengthViewer lifelengthViewerNotifyBefore;
        private TextBox textBoxRemarks;
        private TextBox textBoxHiddenRemarks;
        private DateTimePicker dateTimePickerDate;
        private LifelengthViewer lifelengthViewerLastCompliance;
        private TextBox textBoxInspectionDocument;
        private WindowsFormAttachedFileControl fileControl;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public DamageDirectiveGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DamageDirectiveGeneralInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DamageDirectiveGeneralInformationControl(BaseDetailDirective currentDirective)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public DamageDirectiveGeneralInformationControl(BaseDetailDirective currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public BaseDetailDirective CurrentDirective

        /// <summary>
        /// Текущая директива
        /// </summary>
        public BaseDetailDirective CurrentDirective
        {
            get
            {
                return currentDirective;
            }
            set
            {
                currentDirective = value;
            }
        }

        #endregion

        #region public DamageType DamageType

        /// <summary>
        /// Тип текущей директивы
        /// </summary>
        public DamageType DamageType
        {
            get
            {
                if (radioButtonSDR.Checked)
                    return DamageType.StructureDefectReportStatus;
                return DamageType.DentAndBucklChart;
            }
            set
            {
                if (value == DamageType.StructureDefectReportStatus)
                    radioButtonSDR.Checked = true;
                else
                    radioButtonDBC.Checked = true;
            }
        }

        #endregion

        #region public TextBox TextBoxDescription

        /// <summary>
        /// Возвращает текстбокс с Description
        /// </summary>
        public TextBox TextBoxDescription
        {
            get { return textboxDescription; }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string Description
        {
            get
            {
                return textboxDescription.Text;
            }
            set
            {
                textboxDescription.Text = value;
            }
        }

        #endregion

        #region public string InitialDocuments

        /// <summary>
        /// Документ в котором было отражено повреждение
        /// </summary>
        public string InitialDocuments
        {
            get
            {
                return textBoxInitialDocuments.Text;
            }
            set
            {
                textBoxInitialDocuments.Text = value;
            }
        }

        #endregion

        #region public string InspectionDocument

        /// <summary>
        /// Документ, подтверждающий выполнение последней инспекции
        /// </summary>
        public string InspectionDocument
        {
            get
            {
                return textBoxInspectionDocument.Text;
            }
            set
            {
                textBoxInspectionDocument.Text = value;
            }
        }

        #endregion

        #region public string RequiredInspection

        /// <summary>
        /// Ещё какая то инспекция..
        /// </summary>
        public string RequiredInspection
        {
            get
            {
                return textBoxRequiredInspection.Text;
            }
            set
            {
                textBoxRequiredInspection.Text = value;
            }
        }

        #endregion

        #region public Lifelength FirstPerformance

        /// <summary>
        /// Наработка c момента первого выполнения
        /// </summary>
        public Lifelength FirstPerformance
        {
            get
            {
                return lifelengthViewerSinceNew.Lifelength;
            }
            set
            {
                lifelengthViewerSinceNew.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength RepeatInterval

        /// <summary>
        /// Repeat Interval текущей директивы
        /// </summary>
        public Lifelength RepeatInterval
        {
            get
            {
                return lifelengthViewerRepeatInterval.Lifelength;
            }
            set
            {
                lifelengthViewerRepeatInterval.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength NotifyBefore

        /// <summary>
        /// Наработка Notify Before
        /// </summary>
        public Lifelength NotifyBefore
        {
            get
            {
                return lifelengthViewerNotifyBefore.Lifelength;
            }
            set
            {
                lifelengthViewerNotifyBefore.Lifelength = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Примечания к текущей директиве
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

        #region public string HiddenRemarks

        /// <summary>
        /// Примечания к текущей директиве
        /// </summary>
        public string HiddenRemarks
        {
            get
            {
                return textBoxHiddenRemarks.Text;
            }
            set
            {
                textBoxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;

            labelTitle = new Label();
            labelDescription = new Label();
            labelInitialDocuments = new Label();
            labelRequiredInspection = new Label();
            labelSinceNew = new Label();
            labelRepeatInterval = new Label();
            labelNotifyBefore = new Label();
            labelRemarks = new Label();
            labelHiddenRemarks = new Label();
            labelLastCompliance = new Label();
            labelDate = new Label();
            labelLastComplianceTSNCSN = new Label();
            labelInspectionDocument = new Label();
            textboxTitle = new TextBox();
            radioButtonSDR = new RadioButton();
            radioButtonDBC = new RadioButton();
            textboxDescription = new TextBox();
            textBoxInitialDocuments = new TextBox();
            textBoxRequiredInspection = new TextBox();
            lifelengthViewerSinceNew = new LifelengthViewer();
            lifelengthViewerRepeatInterval = new LifelengthViewer();
            lifelengthViewerNotifyBefore = new LifelengthViewer();
            textBoxRemarks = new TextBox();
            textBoxHiddenRemarks = new TextBox();
            dateTimePickerDate = new DateTimePicker();
            lifelengthViewerLastCompliance = new LifelengthViewer();
            textBoxInspectionDocument = new TextBox();
            fileControl = new WindowsFormAttachedFileControl(null, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
                    "Attached file proves the compliance.", icons.PDFSmall);
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTitle.Location = new Point(MARGIN, TOP_MARGIN);
            labelTitle.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTitle.Text = "Title";
            // 
            // textboxTitle
            // 
            textboxTitle.BackColor = Color.White;
            textboxTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxTitle.Location = new Point(labelTitle.Right, TOP_MARGIN);
            textboxTitle.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxTitle.MaxLength = 50;
            textboxTitle.TabIndex = 2;
            // 
            // radioButtonSDR
            // 
            radioButtonSDR.Cursor = Cursors.Hand;
            radioButtonSDR.FlatStyle = FlatStyle.Flat;
            radioButtonSDR.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonSDR.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonSDR.Location = new Point(MARGIN + LABEL_WIDTH, textboxTitle.Bottom + HEIGHT_INTERVAL);
            radioButtonSDR.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonSDR.Text = "SDR";
            radioButtonSDR.Checked = true;
            // 
            // radioButtonDBC
            // 
            radioButtonDBC.Cursor = Cursors.Hand;
            radioButtonDBC.FlatStyle = FlatStyle.Flat;
            radioButtonDBC.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonDBC.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonDBC.Location = new Point(radioButtonSDR.Right, textboxTitle.Bottom + HEIGHT_INTERVAL);
            radioButtonDBC.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonDBC.Text = "DBC";
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, radioButtonSDR.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Description:";
            // 
            // textboxDescription
            // 
            textboxDescription.BackColor = Color.White;
            textboxDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxDescription.Location = new Point(labelDescription.Right, radioButtonSDR.Bottom + HEIGHT_INTERVAL);
            textboxDescription.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxDescription.Multiline = true;
            textboxDescription.ScrollBars = ScrollBars.Vertical;
            // 
            // labelInitialDocuments
            // 
            labelInitialDocuments.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelInitialDocuments.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInitialDocuments.Location = new Point(MARGIN, textboxDescription.Bottom + HEIGHT_INTERVAL);
            labelInitialDocuments.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelInitialDocuments.Text = "Initial Documents:";
            //
            //  textBoxInitialDocuments
            //
            textBoxInitialDocuments.BackColor = Color.White;
            textBoxInitialDocuments.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxInitialDocuments.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxInitialDocuments.Location = new Point(labelInitialDocuments.Right, textboxDescription.Bottom + HEIGHT_INTERVAL);
            textBoxInitialDocuments.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelRequiredInspection
            // 
            labelRequiredInspection.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRequiredInspection.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRequiredInspection.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRequiredInspection.Text = "Required Inspection:";
            labelRequiredInspection.Location = new Point(MARGIN, textBoxInitialDocuments.Bottom + HEIGHT_INTERVAL);
            //
            //  textBoxRequiredInspection
            //
            textBoxRequiredInspection.BackColor = Color.White;
            textBoxRequiredInspection.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRequiredInspection.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRequiredInspection.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxRequiredInspection.Multiline = true;
            textBoxRequiredInspection.ScrollBars = ScrollBars.Vertical;
            textBoxRequiredInspection.Location = new Point(labelRequiredInspection.Right, textBoxInitialDocuments.Bottom + HEIGHT_INTERVAL);
            // 
            // labelSinceNew
            // 
            labelSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSinceNew.Location = new Point(MARGIN, textBoxRequiredInspection.Bottom + HEIGHT_INTERVAL + 17);
            labelSinceNew.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSinceNew.Text = "First Inspection:";
            //
            // lifelengthViewerSinceNew
            //
            lifelengthViewerSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerSinceNew.ShowLeftHeader = false;
            lifelengthViewerSinceNew.LeftHeaderWidth = 0;
            lifelengthViewerSinceNew.ShowMinutes = false;
            lifelengthViewerSinceNew.TabIndex = 13;
            lifelengthViewerSinceNew.Location = new Point(labelSinceNew.Right, textBoxRequiredInspection.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            // 
            // labelRepeatInterval
            // 
            labelRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRepeatInterval.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRepeatInterval.Text = "Repeat Interval:";
            //
            // lifelengthViewerNotifyBefore
            //
            lifelengthViewerRepeatInterval.ShowHeaders = false;
            lifelengthViewerRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerRepeatInterval.ShowLeftHeader = false;
            lifelengthViewerRepeatInterval.LeftHeaderWidth = 0;
            lifelengthViewerRepeatInterval.ShowMinutes = false;
            //
            // labelNotifyBefore
            //
            labelNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotifyBefore.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelNotifyBefore.Text = "Notify Before:";
            //
            // lifelengthViewerNotifyBefore
            //
            lifelengthViewerNotifyBefore.ShowHeaders = false;
            lifelengthViewerNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNotifyBefore.ShowLeftHeader = false;
            lifelengthViewerNotifyBefore.LeftHeaderWidth = 0;
            lifelengthViewerNotifyBefore.ShowMinutes = false;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            // 
            // labelHiddenRemarks
            // 
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHiddenRemarks.Text = "Hidden remarks:";
            // 
            // textBoxHiddenRemarks
            // 
            textBoxHiddenRemarks.BackColor = Color.White;
            textBoxHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxHiddenRemarks.Multiline = true;
            textBoxHiddenRemarks.ScrollBars = ScrollBars.Vertical;
            //
            // labelLastCompliance
            //
            labelLastCompliance.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelLastCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLastCompliance.Location = new Point(WIDTH_INTERVAL, TOP_MARGIN);
            labelLastCompliance.Size = new Size(WIDTH_INTERVAL, TOP_MARGIN);
            labelLastCompliance.Text = "Last Inspection";
            // 
            // labelDate
            // 
            labelDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDate.Location = new Point(WIDTH_INTERVAL, labelLastCompliance.Bottom + HEIGHT_INTERVAL);
            labelDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDate.Location = new Point(labelDate.Right, labelLastCompliance.Bottom + HEIGHT_INTERVAL);
            dateTimePickerDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDate.Enabled = false;
            //
            // labelLastComplianceTSNCSN
            //
            labelLastComplianceTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLastComplianceTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLastComplianceTSNCSN.Location = new Point(WIDTH_INTERVAL, dateTimePickerDate.Bottom + HEIGHT_INTERVAL + 17);
            labelLastComplianceTSNCSN.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelLastComplianceTSNCSN.Text = "TSN CSN:";
            //
            // lifelengthViewerLastCompliance
            //
            lifelengthViewerLastCompliance.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerLastCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerLastCompliance.ShowLeftHeader = false;
            lifelengthViewerLastCompliance.LeftHeaderWidth = 0;
            lifelengthViewerLastCompliance.ShowMinutes = false;
            lifelengthViewerLastCompliance.Location = new Point(labelLastComplianceTSNCSN.Right, dateTimePickerDate.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerLastCompliance.ReadOnly = true;
            // 
            // labelInspectionDocument
            // 
            labelInspectionDocument.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelInspectionDocument.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInspectionDocument.Location = new Point(WIDTH_INTERVAL, lifelengthViewerLastCompliance.Bottom + HEIGHT_INTERVAL);
            labelInspectionDocument.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelInspectionDocument.Text = "Inspection Document:";
            // 
            // textBoxInspectionDocument
            // 
            textBoxInspectionDocument.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxInspectionDocument.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxInspectionDocument.Location = new Point(labelInspectionDocument.Right, lifelengthViewerLastCompliance.Bottom + HEIGHT_INTERVAL);
            textBoxInspectionDocument.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxInspectionDocument.ReadOnly = true;
            //
            // fileControl
            //
            fileControl.Location = new Point(WIDTH_INTERVAL, textBoxInspectionDocument.Bottom + HEIGHT_INTERVAL);


            Controls.Add(labelTitle);
            Controls.Add(textboxTitle);
            Controls.Add(radioButtonSDR);
            Controls.Add(radioButtonDBC);
            Controls.Add(labelDescription);
            Controls.Add(textboxDescription);
            Controls.Add(labelInitialDocuments);
            Controls.Add(textBoxInitialDocuments);
            Controls.Add(labelRequiredInspection);
            Controls.Add(textBoxRequiredInspection);
            Controls.Add(labelSinceNew);
            Controls.Add(lifelengthViewerSinceNew);
            Controls.Add(labelRepeatInterval);
            Controls.Add(lifelengthViewerRepeatInterval);
            Controls.Add(labelNotifyBefore);
            Controls.Add(lifelengthViewerNotifyBefore);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(labelHiddenRemarks);
            Controls.Add(textBoxHiddenRemarks);
            Controls.Add(labelLastCompliance);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelLastComplianceTSNCSN);
            Controls.Add(lifelengthViewerLastCompliance);
            Controls.Add(labelInspectionDocument);
            Controls.Add(textBoxInspectionDocument);
            Controls.Add(fileControl);


            labelRepeatInterval.Location = new Point(MARGIN, lifelengthViewerSinceNew.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerRepeatInterval.Location = new Point(labelRepeatInterval.Right, lifelengthViewerSinceNew.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            labelNotifyBefore.Location = new Point(MARGIN, lifelengthViewerRepeatInterval.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerNotifyBefore.Location = new Point(labelNotifyBefore.Right, lifelengthViewerRepeatInterval.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            labelRemarks.Location = new Point(MARGIN, labelNotifyBefore.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.Location = new Point(labelRemarks.Right, lifelengthViewerNotifyBefore.Bottom + HEIGHT_INTERVAL);
            labelHiddenRemarks.Location = new Point(MARGIN, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            textBoxHiddenRemarks.Location = new Point(labelHiddenRemarks.Right, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
        }

        #endregion

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)
                return ((textboxTitle.Text != currentDirective.Title) ||
                        (DamageType != currentDirective.DamageType) ||
                        (Description != currentDirective.Description) ||
                        (InitialDocuments != currentDirective.References) ||
                        (RequiredInspection != currentDirective.Boundery) ||
                        (lifelengthViewerSinceNew.Modified) ||
                        (lifelengthViewerRepeatInterval.Modified) ||
                        (lifelengthViewerNotifyBefore.Modified) ||
                        (Remarks != currentDirective.Remarks) ||
                        (HiddenRemarks != currentDirective.HiddenRemarks));
            return ((textboxTitle.Text != "") ||
                    (!radioButtonSDR.Checked) ||
                    (Description != "") ||
                    (InitialDocuments != "") ||
                    (RequiredInspection != "") ||
                    !(lifelengthViewerSinceNew.Lifelength != Lifelength.NullLifelength) ||
                    !(lifelengthViewerRepeatInterval.Lifelength != Lifelength.NullLifelength) ||
                    !(lifelengthViewerNotifyBefore.Lifelength != Lifelength.NullLifelength) ||
                    (Remarks != "") ||
                    (HiddenRemarks != ""));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDirective != null)
                UpdateInformation(currentDirective);
        }

        #endregion

        #region public void UpdateInformation(BaseDetailDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(BaseDetailDirective sourceDirective)
        {
            if (sourceDirective == null) 
                throw new ArgumentNullException("sourceDirective");
            textboxTitle.Text = sourceDirective.Title;
            DamageType = sourceDirective.DamageType;
            Description = sourceDirective.Description;
            InitialDocuments = sourceDirective.References;
            RequiredInspection = sourceDirective.Boundery;
            FirstPerformance = sourceDirective.FirstPerformSinceNew;
            RepeatInterval = sourceDirective.RepeatPerform;
            NotifyBefore = sourceDirective.Notification;
            Remarks = sourceDirective.Remarks;
            HiddenRemarks = sourceDirective.HiddenRemarks;
            if (sourceDirective.LastPerformance != null)
            {
                dateTimePickerDate.Value = sourceDirective.LastPerformance.RecordDate;
                lifelengthViewerLastCompliance.Lifelength = sourceDirective.LastPerformance.Lifelength;
                InspectionDocument = sourceDirective.LastPerformance.Reference;
                fileControl.AttachedFile = sourceDirective.LastPerformance.AttachedFile;
            }

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            textboxTitle.ReadOnly = !permission;
            radioButtonSDR.Enabled = radioButtonDBC.Enabled = permission;
            textboxDescription.ReadOnly = !permission;
            textBoxInitialDocuments.Enabled = permission;
            lifelengthViewerRepeatInterval.ReadOnly = !permission;
            lifelengthViewerNotifyBefore.ReadOnly = !permission;
            textBoxRemarks.ReadOnly = !permission;
            textBoxHiddenRemarks.ReadOnly = !permission;
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public bool SaveData()
        {
            if (currentDirective != null)
            {
                return SaveData(currentDirective, true);
            }
            return false;
        }

        #endregion

        #region  public bool SaveData(BaseDetailDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public bool SaveData(BaseDetailDirective destinationDirective, bool changePageName)
        {
            textboxDescription.Focus();
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            if (destinationDirective.Title != textboxTitle.Text)
                destinationDirective.Title = textboxTitle.Text;
            if (destinationDirective.DamageType != DamageType)
                destinationDirective.DamageType = DamageType;
            if (destinationDirective.Description != Description)
                destinationDirective.Description = Description;
            if (destinationDirective.References != InitialDocuments)
                destinationDirective.References = InitialDocuments;
            if (destinationDirective.Boundery != RequiredInspection)
                destinationDirective.Boundery = RequiredInspection;
            lifelengthViewerSinceNew.SaveData(destinationDirective.FirstPerformSinceNew);
            lifelengthViewerRepeatInterval.SaveData(destinationDirective.RepeatPerform);
            lifelengthViewerNotifyBefore.SaveData(destinationDirective.Notification);
            //destinationDirective.FirstPerformSinceNew = new Lifelength(RepeatInterval);
            destinationDirective.RepeatedlyPerform = destinationDirective.RepeatPerform != Lifelength.NullLifelength;
            if (destinationDirective.Remarks != Remarks)
                destinationDirective.Remarks = Remarks;
            if (destinationDirective.HiddenRemarks != HiddenRemarks)
                destinationDirective.HiddenRemarks = HiddenRemarks;
            return true;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textboxTitle.Text = "";
            radioButtonSDR.Checked = true;
            Description = "";
            InitialDocuments = "";
            InspectionDocument = "";
            RequiredInspection = "";
            lifelengthViewerRepeatInterval.Lifelength = new Lifelength();
            lifelengthViewerNotifyBefore.Lifelength = new Lifelength();
            Remarks = "";
            HiddenRemarks = "";
        }

        #endregion

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

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

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}