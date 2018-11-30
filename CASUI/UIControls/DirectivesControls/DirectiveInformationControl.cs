using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Отображает информацию о директиве
    ///</summary>
    public class DirectiveInformationControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int CHECK_BOX_WIDTH = 150;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int WIDTH_INTERVAL =600;


        private BaseDetailDirective currentDirective;
        
        private Label labelATAChapter;
        private Label labelADType;
        private Label labelTitle;
        private Label labelParagraph;
        private Label labelEffectivityDate;
        private Label labelReferences;
        private Label labelApplicability;
        private Label labelSupersededBy;
        private Label labelSupersedes;
        private Label labelBiWeeklyReport;
        private Label labelSubject;
        private Label labelThreshold;
        private Label labelFirstPerformAt;
        private Label labelAndThen;
        private Label labelManHours;
        private Label labelCost;
        private Label labelRemarks;
        private Label labelHiddenRemarks;
        private Label labelRevision;
        private Label labelNotifyBefore;
        private ATAChapterComboBox comboBoxAtaChapter;
        private Panel panelADType;
        private RadioButton radioButtonAirframe;
        private RadioButton radioButtonAppliance;
        private TextBox textboxTitle;
        private TextBox textboxParagraph;
        private DateTimePicker dateTimePickerEffDate;
        private TextBox textBoxReferences;
        private TextBox textboxApplicability;
        private TextBox textboxSupersededBy;
        private TextBox textboxSupersedes;
        private TextBox textboxBiWeeklyReport;
        private TextBox textboxSubject;
        private TextBox textboxThreshold;
        private CheckBox checkBoxSinceNew;
        private CheckBox checkBoxSinceEffectivityDate;
        private CheckBox checkBoxSinceRepeatInterval;
        protected LifelengthViewer lifelengthViewerSinceNew;
        protected LifelengthViewer lifelengthViewerSinceEffectivityDate;
        protected LifelengthViewer lifelengthViewerRepeatInterval;
        protected LifelengthViewer lifelengthViewerNotifyBefore;
        private TextBox textboxManHours;
        private TextBox textboxCost;
        private TextBox textboxRemarks;
        private TextBox textboxHiddenRemarks;
        private TextBox textboxRevision;

        #endregion

        #region Constructors

        #region public DirectiveInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DirectiveInformationControl(DirectiveType directiveType)
        {
            InitializeComponent(directiveType);
        }

        #endregion

        #region public DirectiveInformationControl(BaseDetailDirective currentDirective)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public DirectiveInformationControl(BaseDetailDirective currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;
            InitializeComponent(currentDirective.DirectiveType);
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

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATAChapter текущего агрегата
        /// </summary>
        public ATAChapter ATAChapter
        {
            get
            {
                return comboBoxAtaChapter.ATAChapter;
            }
            set
            {
                comboBoxAtaChapter.ATAChapter = value;
            }
        }

        #endregion

        #region public ComboBox ComboBoxATAChapter

        /// <summary>
        /// Возвращает ComboBox с ATAChapter
        /// </summary>
        public ComboBox ComboBoxATAChapter
        {
            get
            {
                return comboBoxAtaChapter;
            }
        }

        #endregion

        #region public ADType ADType

        /// <summary>
        /// Возвращает или устанавливает ADType
        /// </summary>
        public ADType ADType
        {
            get
            {
                if (radioButtonAirframe.Checked)
                    return ADType.Airframe;
                else 
                    return ADType.Appliance;
            }
            set
            {
                if (value == ADType.Airframe)
                    radioButtonAirframe.Checked = true;
                else
                    radioButtonAppliance.Checked = true;
            }
        }

        #endregion

        #region public string Title

        /// <summary>
        /// Имя текущей директивы
        /// </summary>
        public string Title
        {
            get
            {
                return textboxTitle.Text;
            }
            set
            {
                textboxTitle.Text = value;
            }
        }

        #endregion

        #region public string Paragraph

        /// <summary>
        /// Paragraph текущей директивы
        /// </summary>
        public string Paragraph
        {
            get
            {
                return textboxParagraph.Text;
            }
            set
            {
                textboxParagraph.Text = value;
            }
        }

        #endregion

        #region public DateTime EffectiveDate

        /// <summary>
        /// Дата начала использования текущей директивы
        /// </summary>
        public DateTime EffectiveDate
        {
            get
            {
                return dateTimePickerEffDate.Value;
            }
            set
            {
                dateTimePickerEffDate.Value = value;
            }
        }

        #endregion

        #region public string References

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string References
        {
            get
            {
                return textBoxReferences.Text;
            }
            set
            {
                textBoxReferences.Text = value;
            }
        }

        #endregion

        #region public string TLPNo

        /// <summary>
        /// TLPNo текущей директивы
        /// </summary>
        public string Applicability
        {
            get
            {
                return textboxApplicability.Text;
            }
            set
            {
                textboxApplicability.Text = value;
            }
        }

        #endregion

        #region public string SupersededBy

        /// <summary>
        /// SupersededBy текущей директивы
        /// </summary>
        public string SupersededBy
        {
            get
            {
                return textboxSupersededBy.Text;
            }
            set
            {
                textboxSupersededBy.Text = value;
            }
        }

        #endregion

        #region public string Supersedes

        /// <summary>
        /// Supersedes текущей директивы
        /// </summary>
        public string Supersedes
        {
            get
            {
                return textboxSupersedes.Text;
            }
            set
            {
                textboxSupersedes.Text = value;
            }
        }

        #endregion

        #region public string BiWeeklyReport

        /// <summary>
        /// BiWeeklyReport текущей директивы
        /// </summary>
        public string BiWeeklyReport
        {
            get
            {
                return textboxBiWeeklyReport.Text;
            }
            set
            {
                textboxBiWeeklyReport.Text = value;
            }
        }

        #endregion

        #region public string Subject

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string Subject
        {
            get { return textboxSubject.Text; }
            set
            {
                textboxSubject.Text = value;
            }
        }

        #endregion

        #region public string Threshold

        /// <summary>
        /// Threshold текущей директивы
        /// </summary>
        public string Threshold
        {
            get { return textboxThreshold.Text; }
            set
            {
                textboxThreshold.Text = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Заметки текущей директивы
        /// </summary>
        public string Remarks
        {
            get
            {
                return textboxRemarks.Text;
            }
            set
            {
                textboxRemarks.Text = value;
            }
        }

        #endregion

        #region public string HiddenRemarks

        /// <summary>
        /// Заметки текущей директивы
        /// </summary>
        public string HiddenRemarks
        {
            get
            {
                return textboxHiddenRemarks.Text;
            }
            set
            {
                textboxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #region public string Revision

        /// <summary>
        /// Revision текущей директивы
        /// </summary>
        public string Revision
        {
            get
            {
                return textboxRevision.Text;
            }
            set
            {
                textboxRevision.Text = value;
            }
        }

        #endregion

        #region public double Manhours

        /// <summary>
        /// Manhours текущей директивы
        /// </summary>
        public double Manhours
        {
            get
            {
                double d;
                double.TryParse(textboxManHours.Text, out d);
                return d;
            }
            set
            {
                currentDirective.ManHours = value;
                if (Math.Abs(value) > 0.000001)
                    textboxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string ManhoursString

        /// <summary>
        /// Manhours текущей директивы
        /// </summary>
        public string ManhoursString
        {
            get
            {
                return textboxManHours.Text;
            }
            set
            {
                textboxManHours.Text = value;
            }
        }

        #endregion

        #region public double Cost

        /// <summary>
        /// Cost текущей директивы
        /// </summary>
        public double Cost
        {
            get
            {
                double d;
                double.TryParse(textboxCost.Text, out d);
                return d;
            }
            set
            {
                currentDirective.Cost = value;
                if (Math.Abs(value) > 0.000001)
                    textboxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string CostString

        /// <summary>
        /// Cost текущей директивы
        /// </summary>
        public string CostString
        {
            get
            {
                return textboxCost.Text;
            }
            set
            {
                textboxCost.Text = value;
            }
        }

        #endregion
        
        #region public Lifelength FirstPerformSinceNew

        /// <summary>
        /// Наработка First Perform - Since New
        /// </summary>
        public Lifelength FirstPerformSinceNew
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

        #region public Lifelength FirstPerformSinceEffDate

        /// <summary>
        /// Наработка First Perform - Since Effectivity Date
        /// </summary>
        public Lifelength FirstPerformSinceEffDate
        {
            get
            {
                 return lifelengthViewerSinceEffectivityDate.Lifelength;
            }
            set
            {
                lifelengthViewerSinceEffectivityDate.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength FirstPerformRepeatInterval

        /// <summary>
        /// Наработка First Perform - Repeat Interval
        /// </summary>
        public Lifelength FirstPerformRepeatInterval
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

        #region public Lifelength FirstPerformNotifyBefore

        /// <summary>
        /// Наработка First Perform - Notify Before
        /// </summary>
        public Lifelength FirstPerformNotifyBefore
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

        #region public bool PerformSinceEffectivityDate

        /// <summary>
        /// Выполняется ли директива с Effectivity Date
        /// </summary>
        public bool PerformSinceEffectivityDate
        {
            get { return checkBoxSinceEffectivityDate.Checked; }
            set { checkBoxSinceEffectivityDate.Checked = value; }
        }

        #endregion

        #region public bool PerformSinceNew

        /// <summary>
        /// Выполняется ли директива с начала эксплуатации
        /// </summary>
        public bool PerformSinceNew
        {
            get { return checkBoxSinceNew.Checked; }
            set { checkBoxSinceNew.Checked = value; }
        }

        #endregion

        #region public bool PerformRepeatedly

        /// <summary>
        /// Выполняется ли директива повторно
        /// </summary>
        public bool PerformRepeatedly
        {
            get { return checkBoxSinceRepeatInterval.Checked; }
            set { checkBoxSinceRepeatInterval.Checked = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent(DirectiveType directiveType)

        private void InitializeComponent(DirectiveType directiveType)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;

            labelATAChapter = new Label();
            labelADType = new Label();
            labelTitle = new Label();
            labelParagraph = new Label();
            labelEffectivityDate = new Label();
            labelReferences = new Label();
            labelApplicability = new Label();
            labelSupersededBy = new Label();
            labelSupersedes = new Label();
            labelBiWeeklyReport = new Label();
            labelSubject = new Label();
            labelThreshold = new Label();
            labelFirstPerformAt = new Label();
            labelAndThen = new Label();
            labelManHours = new Label();
            labelCost = new Label();
            labelRemarks = new Label();
            labelHiddenRemarks = new Label();
            labelRevision = new Label();
            labelNotifyBefore = new Label();
            comboBoxAtaChapter = new ATAChapterComboBox();
            panelADType = new Panel();
            radioButtonAirframe = new RadioButton();
            radioButtonAppliance = new RadioButton();
            textboxTitle = new TextBox();
            textboxParagraph = new TextBox();
            dateTimePickerEffDate = new DateTimePicker();
            textBoxReferences = new TextBox();
            textboxApplicability = new TextBox();
            textboxSupersededBy = new TextBox();
            textboxSupersedes = new TextBox();
            textboxBiWeeklyReport = new TextBox();
            textboxSubject = new TextBox();
            textboxThreshold = new TextBox();
            checkBoxSinceNew = new CheckBox();
            checkBoxSinceEffectivityDate = new CheckBox();
            checkBoxSinceRepeatInterval = new CheckBox();
            lifelengthViewerSinceNew = new LifelengthViewer();
            lifelengthViewerSinceEffectivityDate = new LifelengthViewer();
            lifelengthViewerRepeatInterval = new LifelengthViewer();
            lifelengthViewerNotifyBefore = new LifelengthViewer();
            textboxManHours = new TextBox();
            textboxCost = new TextBox();
            textboxRemarks = new TextBox();
            textboxHiddenRemarks = new TextBox();
            textboxRevision = new TextBox();
            // 
            // labelATAChapter
            // 
            labelATAChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelATAChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelATAChapter.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelATAChapter.Text = "ATA Chapter";
            //
            // comboBoxAtaChapter
            //
            comboBoxAtaChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            comboBoxAtaChapter.TabIndex = 0;
            // 
            // labelADType
            // 
            labelADType.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelADType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelADType.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelADType.Text = "AD Type";
            //
            // panelADType
            //
            panelADType.AutoSize = true;
            panelADType.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelADType.Controls.Add(radioButtonAirframe);
            panelADType.Controls.Add(radioButtonAppliance);
            comboBoxAtaChapter.TabIndex = 1;
            // 
            // radioButtonAirframe
            // 
            radioButtonAirframe.Cursor = Cursors.Hand;
            radioButtonAirframe.FlatStyle = FlatStyle.Flat;
            radioButtonAirframe.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonAirframe.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonAirframe.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonAirframe.Text = "Airframe";
            radioButtonAirframe.Checked = true;
            // 
            // radioButtonAppliance
            // 
            radioButtonAppliance.Cursor = Cursors.Hand;
            radioButtonAppliance.FlatStyle = FlatStyle.Flat;
            radioButtonAppliance.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonAppliance.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonAppliance.Location = new Point(radioButtonAirframe.Right, 0);
            radioButtonAppliance.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonAppliance.Text = "Appliance";
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTitle.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTitle.Text = "Title";
            // 
            // textboxTitle
            // 
            textboxTitle.BackColor = Color.White;
            textboxTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxTitle.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxTitle.MaxLength = 50;
            textboxTitle.TabIndex = 2;
            // 
            // labelParagraph
            // 
            labelParagraph.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelParagraph.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelParagraph.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelParagraph.Text = "Paragraph";
            // 
            // textboxParagraph
            // 
            textboxParagraph.BackColor = Color.White;
            textboxParagraph.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxParagraph.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxParagraph.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxParagraph.MaxLength = 50;
            textboxParagraph.TabIndex = 3;
            // 
            // labelEffectiveDate
            // 
            labelEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEffectivityDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEffectivityDate.Text = "Effective Date";
            //
            //  dateTimePickerEffDate
            //
            dateTimePickerEffDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerEffDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerEffDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerEffDate.TabIndex = 4;
            // 
            // labelReferences
            // 
            labelReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelReferences.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelReferences.Text = "References";
            // 
            // textBoxReferences
            // 
            textBoxReferences.BackColor = Color.White;
            textBoxReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxReferences.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxReferences.MaxLength = 400;
            textBoxReferences.TabIndex = 5;
            // 
            // labelApplicability
            // 
            labelApplicability.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelApplicability.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelApplicability.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelApplicability.Text = "Applicability";
            // 
            // textboxApplicability
            // 
            textboxApplicability.BackColor = Color.White;
            textboxApplicability.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxApplicability.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxApplicability.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxApplicability.MaxLength = 1000;
            textboxApplicability.TabIndex = 6;
            // 
            // labelSupersededBy
            // 
            labelSupersededBy.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSupersededBy.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSupersededBy.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSupersededBy.Text = "Superseded by";
            // 
            // textboxSupersededBy
            // 
            textboxSupersededBy.BackColor = Color.White;
            textboxSupersededBy.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSupersededBy.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSupersededBy.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxSupersededBy.MaxLength = 50;
            textboxSupersededBy.TabIndex = 7;
            // 
            // labelSupersedes
            // 
            labelSupersedes.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSupersedes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSupersedes.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSupersedes.Text = "Supersedes";
            // 
            // textboxSupersedes
            // 
            textboxSupersedes.BackColor = Color.White;
            textboxSupersedes.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSupersedes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSupersedes.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxSupersedes.MaxLength = 50;
            textboxSupersedes.TabIndex = 8;
            // 
            // labelBiWeeklyReport
            // 
            labelBiWeeklyReport.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelBiWeeklyReport.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelBiWeeklyReport.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelBiWeeklyReport.Text = "BiWeekly Report";
            // 
            // textboxBiWeeklyReport
            // 
            textboxBiWeeklyReport.BackColor = Color.White;
            textboxBiWeeklyReport.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxBiWeeklyReport.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxBiWeeklyReport.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxBiWeeklyReport.MaxLength = 1000;
            textboxBiWeeklyReport.TabIndex = 9;
            // 
            // labelSubject
            // 
            labelSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSubject.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSubject.Text = "Subject";
            // 
            // textboxSubject
            // 
            textboxSubject.ScrollBars = ScrollBars.Vertical;
            textboxSubject.BackColor = Color.White;
            textboxSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSubject.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxSubject.Multiline = true;
            textboxSubject.MaxLength = 1000;
            textboxSubject.TabIndex = 10;
            // 
            // labelThreshold
            // 
            labelThreshold.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelThreshold.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelThreshold.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelThreshold.Text = "Threshold";
            // 
            // textboxThreshold
            // 
            textboxThreshold.ScrollBars = ScrollBars.Vertical;
            textboxThreshold.BackColor = Color.White;
            textboxThreshold.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxThreshold.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxThreshold.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxThreshold.Multiline = true;
            //textboxThreshold.MaxLength = 1000;
            textboxThreshold.TabIndex = 11;
            //
            // labelFirstPerformAt
            //
            labelFirstPerformAt.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelFirstPerformAt.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFirstPerformAt.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelFirstPerformAt.Text = "First Perform At";
            //
            // checkBoxSinceNew
            //
            checkBoxSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceNew.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            checkBoxSinceNew.Text = "Since New";
            checkBoxSinceNew.CheckedChanged += checkBoxSinceNew_CheckedChanged;
            checkBoxSinceNew.TabIndex = 12;
            //
            // lifelengthViewerSinceNew
            //
            lifelengthViewerSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerSinceNew.ShowLeftHeader = false;
            lifelengthViewerSinceNew.LeftHeaderWidth = 0;
            lifelengthViewerSinceNew.ShowMinutes = false;
            lifelengthViewerSinceNew.TabIndex = 13;
            //
            // checkBoxSinceEffectivityDate
            //
            checkBoxSinceEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceEffectivityDate.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            checkBoxSinceEffectivityDate.Text = "Since Eff. Date";
            checkBoxSinceEffectivityDate.CheckedChanged += checkBoxSinceEffectivityDate_CheckedChanged;
            checkBoxSinceEffectivityDate.TabIndex = 14;
            //
            // lifelengthViewerSinceEffectivityDate
            //
            lifelengthViewerSinceEffectivityDate.ShowHeaders = false;
            lifelengthViewerSinceEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerSinceEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerSinceEffectivityDate.ShowLeftHeader = false;
            lifelengthViewerSinceEffectivityDate.LeftHeaderWidth = 0;
            lifelengthViewerSinceEffectivityDate.ShowMinutes = false;
            lifelengthViewerSinceEffectivityDate.TabIndex = 15;
            //
            // labelAndThen
            //
            labelAndThen.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelAndThen.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAndThen.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAndThen.Text = "And then";
            //
            // checkBoxSinceRepeatInterval
            //
            checkBoxSinceRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceRepeatInterval.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            checkBoxSinceRepeatInterval.Text = "Repeat every";
            checkBoxSinceRepeatInterval.CheckedChanged += checkBoxSinceRepeatInterval_CheckedChanged;
            checkBoxSinceRepeatInterval.TabIndex = 16;
            //
            // lifelengthViewerRepeatInterval
            //
            lifelengthViewerRepeatInterval.ShowHeaders = false;
            lifelengthViewerRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerRepeatInterval.ShowLeftHeader = false;
            lifelengthViewerRepeatInterval.LeftHeaderWidth = 0;
            lifelengthViewerRepeatInterval.ShowMinutes = false;
            lifelengthViewerRepeatInterval.TabIndex = 17;
            //
            // labelNotifyBefore
            //
            labelNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotifyBefore.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            labelNotifyBefore.Text = "Notify Before";
            //
            // lifelengthViewerNotifyBefore
            //
            lifelengthViewerNotifyBefore.ShowHeaders = false;
            lifelengthViewerNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNotifyBefore.ShowLeftHeader = false;
            lifelengthViewerNotifyBefore.LeftHeaderWidth = 0;
            lifelengthViewerNotifyBefore.ShowMinutes = false;
            lifelengthViewerNotifyBefore.TabIndex = 18;
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManHours.Text = "Man Hours";
            // 
            // textboxManHours
            // 
            textboxManHours.BackColor = Color.White;
            textboxManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxManHours.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxManHours.TabIndex = 19;
            // 
            // labelCost
            // 
            labelCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCost.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCost.Text = "Cost (USD)";
            // 
            // textboxCost
            // 
            textboxCost.BackColor = Color.White;
            textboxCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxCost.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxCost.TabIndex = 20;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks";
            // 
            // textboxRemarks
            // 
            textboxRemarks.ScrollBars = ScrollBars.Vertical;
            textboxRemarks.BackColor = Color.White;
            textboxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxRemarks.Multiline = true;
            textboxRemarks.MaxLength = 34000;
            textboxRemarks.TabIndex = 21;
            // 
            // labelHiddenRemarks
            // 
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHiddenRemarks.Text = "Hidden Remarks";
            // 
            // textboxHiddenRemarks
            // 
            textboxHiddenRemarks.ScrollBars = ScrollBars.Vertical;
            textboxHiddenRemarks.BackColor = Color.White;
            textboxHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxHiddenRemarks.Multiline = true;
            textboxHiddenRemarks.MaxLength = 34000;
            textboxHiddenRemarks.TabIndex = 22;
            // 
            // labelRevision
            // 
            labelRevision.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRevision.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRevision.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRevision.Text = "Revision";
            // 
            // textboxRevision
            // 
            textboxRevision.BackColor = Color.White;
            textboxRevision.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRevision.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRevision.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxRevision.TabIndex = 23;

            Controls.Add(labelATAChapter);
            Controls.Add(comboBoxAtaChapter);
            Controls.Add(labelTitle);
            Controls.Add(textboxTitle);
            Controls.Add(labelEffectivityDate);
            Controls.Add(dateTimePickerEffDate);
            Controls.Add(labelReferences);
            Controls.Add(textBoxReferences);
            Controls.Add(labelApplicability);
            Controls.Add(textboxApplicability);
            Controls.Add(labelSupersededBy);
            Controls.Add(textboxSupersededBy);
            Controls.Add(labelSupersedes);
            Controls.Add(textboxSupersedes);
            Controls.Add(labelSubject);
            Controls.Add(textboxSubject);
            Controls.Add(labelThreshold);
            Controls.Add(textboxThreshold);
            Controls.Add(labelFirstPerformAt);
            Controls.Add(checkBoxSinceNew);
            Controls.Add(lifelengthViewerSinceNew);
            Controls.Add(checkBoxSinceEffectivityDate);
            Controls.Add(lifelengthViewerSinceEffectivityDate);
            Controls.Add(labelAndThen);
            Controls.Add(checkBoxSinceRepeatInterval);
            Controls.Add(lifelengthViewerRepeatInterval);
            Controls.Add(labelNotifyBefore);
            Controls.Add(lifelengthViewerNotifyBefore);
            Controls.Add(labelRemarks);
            Controls.Add(textboxRemarks);

            labelATAChapter.Location = new Point(MARGIN, MARGIN);
            comboBoxAtaChapter.Location = new Point(labelATAChapter.Right, MARGIN);
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                Controls.Add(labelADType);
                Controls.Add(panelADType);
                labelADType.Location = new Point(MARGIN, labelATAChapter.Bottom + HEIGHT_INTERVAL);
                panelADType.Location = new Point(labelADType.Right, labelATAChapter.Bottom + HEIGHT_INTERVAL);
                labelTitle.Location = new Point(MARGIN, labelADType.Bottom + HEIGHT_INTERVAL);
                textboxTitle.Location = new Point(labelTitle.Right, labelADType.Bottom + HEIGHT_INTERVAL);
            }
            else
            {
                labelTitle.Location = new Point(MARGIN, labelATAChapter.Bottom + HEIGHT_INTERVAL);
                textboxTitle.Location = new Point(labelTitle.Right, labelATAChapter.Bottom + HEIGHT_INTERVAL);
            }
            
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType || directiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                Controls.Add(labelParagraph);
                Controls.Add(textboxParagraph);
                labelParagraph.Location = new Point(MARGIN, labelTitle.Bottom + HEIGHT_INTERVAL);
                textboxParagraph.Location = new Point(labelParagraph.Right, labelTitle.Bottom + HEIGHT_INTERVAL);
                labelEffectivityDate.Location = new Point(MARGIN, labelParagraph.Bottom + HEIGHT_INTERVAL);
                dateTimePickerEffDate.Location = new Point(labelEffectivityDate.Right, labelParagraph.Bottom + HEIGHT_INTERVAL);
            }
            else
            {
                labelEffectivityDate.Location = new Point(MARGIN, labelTitle.Bottom + HEIGHT_INTERVAL);
                dateTimePickerEffDate.Location = new Point(labelEffectivityDate.Right, labelTitle.Bottom + HEIGHT_INTERVAL);
            }
            labelReferences.Location = new Point(MARGIN, labelEffectivityDate.Bottom + HEIGHT_INTERVAL);
            textBoxReferences.Location = new Point(labelReferences.Right, dateTimePickerEffDate.Bottom + HEIGHT_INTERVAL);
            labelApplicability.Location = new Point(MARGIN, labelReferences.Bottom + HEIGHT_INTERVAL);
            textboxApplicability.Location = new Point(labelApplicability.Right, textBoxReferences.Bottom + HEIGHT_INTERVAL);
            labelSupersededBy.Location = new Point(MARGIN, labelApplicability.Bottom + HEIGHT_INTERVAL);
            textboxSupersededBy.Location = new Point(labelSupersededBy.Right, textboxApplicability.Bottom + HEIGHT_INTERVAL);
            labelSupersedes.Location = new Point(MARGIN, labelSupersededBy.Bottom + HEIGHT_INTERVAL);
            textboxSupersedes.Location = new Point(labelSupersedes.Right, textboxSupersededBy.Bottom + HEIGHT_INTERVAL);
            if (directiveType != DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                Controls.Add(labelBiWeeklyReport);
                Controls.Add(textboxBiWeeklyReport);
                labelBiWeeklyReport.Location = new Point(MARGIN, labelSupersedes.Bottom + HEIGHT_INTERVAL);
                textboxBiWeeklyReport.Location = new Point(labelBiWeeklyReport.Right, textboxSupersedes.Bottom + HEIGHT_INTERVAL);
                labelSubject.Location = new Point(MARGIN, labelBiWeeklyReport.Bottom + HEIGHT_INTERVAL);
                textboxSubject.Location = new Point(labelSubject.Right, textboxBiWeeklyReport.Bottom + HEIGHT_INTERVAL);
            }
            else
            {
                labelSubject.Location = new Point(MARGIN, labelSupersedes.Bottom + HEIGHT_INTERVAL);
                textboxSubject.Location = new Point(labelSubject.Right, textboxSupersedes.Bottom + HEIGHT_INTERVAL);
            }
            labelThreshold.Location = new Point(MARGIN, textboxSubject.Bottom + HEIGHT_INTERVAL);
            textboxThreshold.Location = new Point(labelThreshold.Right, textboxSubject.Bottom + HEIGHT_INTERVAL);
            labelFirstPerformAt.Location = new Point(WIDTH_INTERVAL, MARGIN);
            checkBoxSinceNew.Location = new Point(WIDTH_INTERVAL, labelFirstPerformAt.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerSinceNew.Location = new Point(checkBoxSinceNew.Right, labelFirstPerformAt.Bottom);
            checkBoxSinceEffectivityDate.Location = new Point(WIDTH_INTERVAL, checkBoxSinceNew.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerSinceEffectivityDate.Location = new Point(checkBoxSinceNew.Right, lifelengthViewerSinceNew.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            labelAndThen.Location = new Point(WIDTH_INTERVAL, checkBoxSinceEffectivityDate.Bottom + HEIGHT_INTERVAL);
            checkBoxSinceRepeatInterval.Location = new Point(WIDTH_INTERVAL, labelAndThen.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerRepeatInterval.Location = new Point(checkBoxSinceNew.Right, labelAndThen.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            labelNotifyBefore.Location = new Point(WIDTH_INTERVAL, checkBoxSinceRepeatInterval.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerNotifyBefore.Location = new Point(checkBoxSinceNew.Right, lifelengthViewerRepeatInterval.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            if (directiveType != DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                Controls.Add(labelManHours);
                Controls.Add(textboxManHours);
                Controls.Add(labelCost);
                Controls.Add(textboxCost);
                labelManHours.Location = new Point(WIDTH_INTERVAL, labelNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
                textboxManHours.Location = new Point(labelManHours.Right, lifelengthViewerNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
                labelCost.Location = new Point(WIDTH_INTERVAL, labelManHours.Bottom + HEIGHT_INTERVAL);
                textboxCost.Location = new Point(labelCost.Right, labelManHours.Bottom + HEIGHT_INTERVAL);
                labelRemarks.Location = new Point(WIDTH_INTERVAL, labelCost.Bottom + HEIGHT_INTERVAL);
                textboxRemarks.Location = new Point(labelRemarks.Right, labelCost.Bottom + HEIGHT_INTERVAL);
            }
            else
            {
                labelRemarks.Location = new Point(WIDTH_INTERVAL, lifelengthViewerNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
                textboxRemarks.Location = new Point(labelRemarks.Right, lifelengthViewerNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            }
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType || directiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                Controls.Add(labelHiddenRemarks);
                Controls.Add(textboxHiddenRemarks);
                labelHiddenRemarks.Location = new Point(WIDTH_INTERVAL, textboxRemarks.Bottom + HEIGHT_INTERVAL);
                textboxHiddenRemarks.Location = new Point(labelRemarks.Right, textboxRemarks.Bottom + HEIGHT_INTERVAL);
            }
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType || directiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                Controls.Add(labelRevision);
                Controls.Add(textboxRevision);
                labelRevision.Location = new Point(WIDTH_INTERVAL, textboxHiddenRemarks.Bottom + HEIGHT_INTERVAL);
                textboxRevision.Location = new Point(labelRevision.Right, textboxHiddenRemarks.Bottom + HEIGHT_INTERVAL);
            }

            checkBoxSinceRepeatInterval.Checked = true;
            checkBoxSinceNew.Checked = true;
            checkBoxSinceEffectivityDate.Checked = true;  
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
            double eps = 0.00001;
            Date effectiveDate = new Date(EffectiveDate);
            Date today = new Date(DateTime.Today);
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return true;
            if (!CheckCost(out cost))
                return true;
            Lifelength emptyLifelength = new Lifelength();
            if (directiveExist)
                return ((ATAChapter != currentDirective.AtaChapter) ||
                        (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType && ADType != currentDirective.ADType) ||
                        ((currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType) && (Paragraph != currentDirective.Paragraph || HiddenRemarks != currentDirective.HiddenRemarks || Revision != currentDirective.Revision)) ||
                        (Title != currentDirective.Title) ||
                        (EffectiveDate != currentDirective.EffectivityDate) ||
                        (References != currentDirective.References) ||
                        (Applicability != currentDirective.Applicability) ||
                        (SupersededBy != currentDirective.SupersededBy) ||
                        (Supersedes != currentDirective.Supersedes) ||
                        (currentDirective.DirectiveType != DirectiveTypeCollection.Instance.SBDirectiveType && BiWeeklyReport != currentDirective.BiweeklyReport) ||
                        (Subject != currentDirective.Description) ||
                        (Threshold != currentDirective.Boundery) ||
                        (Remarks != currentDirective.Remarks) ||
                        (currentDirective.DirectiveType != DirectiveTypeCollection.Instance.ADDirectiveType && (Math.Abs(manHours - currentDirective.ManHours) > eps || Math.Abs(cost - currentDirective.Cost) > eps)) ||
                        (PerformSinceNew != currentDirective.PerformSinceNew) ||
                        (PerformSinceEffectivityDate != currentDirective.PerformSinceEffectivityDate) ||
                        (PerformRepeatedly != currentDirective.RepeatedlyPerform) ||
                        lifelengthViewerSinceNew.Modified ||
                        lifelengthViewerSinceEffectivityDate.Modified ||
                        lifelengthViewerRepeatInterval.Modified ||
                        lifelengthViewerNotifyBefore.Modified);
            else
                return ((ATAChapter != null) ||
                        (Paragraph != "") ||
                        (ADType != ADType.Airframe) ||
                        (Title != "") ||
                        (effectiveDate.ToDateTime() != today.ToDateTime()) ||
                        (References != "") ||
                        (Applicability != "") ||
                        (SupersededBy != "") ||
                        (Supersedes != "") ||
                        (BiWeeklyReport != "") ||
                        (Subject != "") ||
                        (Threshold != "") ||
                        (Remarks != "") ||
                        (HiddenRemarks != "") ||
                        (Revision != "") ||
                        (ManhoursString != "") ||
                        (CostString != "") ||
                        !(lifelengthViewerSinceNew.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerSinceEffectivityDate.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerNotifyBefore.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerRepeatInterval.Lifelength.Equals(emptyLifelength)) ||
                        !PerformSinceNew || !PerformSinceEffectivityDate || !PerformRepeatedly);
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
            ATAChapter = sourceDirective.AtaChapter;
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                ADType = sourceDirective.ADType;
            Title = sourceDirective.Title;
            EffectiveDate = sourceDirective.EffectivityDate;
            References = sourceDirective.References;
            Applicability = sourceDirective.Applicability;
            SupersededBy = sourceDirective.SupersededBy;
            Supersedes = sourceDirective.Supersedes;
            if (currentDirective.DirectiveType != DirectiveTypeCollection.Instance.SBDirectiveType)
                BiWeeklyReport = sourceDirective.BiweeklyReport;
            Subject = sourceDirective.Description;
            Threshold = sourceDirective.Boundery;
            Remarks = sourceDirective.Remarks;
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                Paragraph = sourceDirective.Paragraph;
                HiddenRemarks = sourceDirective.HiddenRemarks;
                Revision = sourceDirective.Revision;
            }

            if (currentDirective.DirectiveType != DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                if (Math.Abs(sourceDirective.ManHours) > 0.000001)
                    Manhours = sourceDirective.ManHours;
                if (Math.Abs(sourceDirective.Cost) > 0.000001)
                    Cost = sourceDirective.Cost;
            }
            PerformSinceNew = sourceDirective.PerformSinceNew;
            PerformSinceEffectivityDate = sourceDirective.PerformSinceEffectivityDate;
            PerformRepeatedly = sourceDirective.RepeatedlyPerform;
            EffectiveDate = sourceDirective.EffectivityDate;
            
            FirstPerformSinceNew = sourceDirective.FirstPerformSinceNew;
            FirstPerformRepeatInterval = sourceDirective.RepeatPerform;
            FirstPerformSinceEffDate = sourceDirective.SinceEffectivityDatePerformanceLifelength;
            FirstPerformNotifyBefore = sourceDirective.Notification;

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            comboBoxAtaChapter.Enabled = permission;
            textboxTitle.ReadOnly = !permission;
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
                textboxParagraph.ReadOnly = !permission;
            dateTimePickerEffDate.Enabled = permission;
            textBoxReferences.ReadOnly = !permission;
            textboxApplicability.ReadOnly = !permission;
            textboxSupersededBy.ReadOnly = !permission;
            textboxSupersedes.ReadOnly = !permission;
            if (currentDirective.DirectiveType != DirectiveTypeCollection.Instance.SBDirectiveType)
                textboxBiWeeklyReport.ReadOnly = !permission;
            textboxSubject.ReadOnly = !permission;
            textboxThreshold.ReadOnly = !permission;
            checkBoxSinceNew.Enabled = permission;
            checkBoxSinceEffectivityDate.Enabled = permission;
            checkBoxSinceRepeatInterval.Enabled = permission;
            labelNotifyBefore.Enabled = permission;
            lifelengthViewerSinceNew.ReadOnly = !permission;
            lifelengthViewerSinceEffectivityDate.ReadOnly = !permission;
            lifelengthViewerRepeatInterval.ReadOnly = !permission;
            lifelengthViewerNotifyBefore.ReadOnly = !permission;
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                textboxManHours.ReadOnly = !permission;
                textboxCost.ReadOnly = !permission;
            }
            textboxRemarks.ReadOnly = !permission;
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
                textboxHiddenRemarks.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (currentDirective != null)
            {
                SaveData(currentDirective, true);
            }
        }

        #endregion

        #region  public void SaveData(BaseDetailDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        /// <param name="parent">Родитель директивы</param>
        public void SaveData(BaseDetailDirective destinationDirective, bool changePageName)
        {
            textboxTitle.Focus();
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return;
            if (!CheckCost(out cost))
                return;
            if (destinationDirective.AtaChapter != ATAChapter)
                destinationDirective.AtaChapter = ATAChapter;
            if (destinationDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType && destinationDirective.ADType != ADType)
                destinationDirective.ADType = ADType;
            if (destinationDirective.Title != Title)
            {

                destinationDirective.Title = Title;
                
                if (changePageName && destinationDirective.ExistAtDataBase)
                {
                    string caption = "";
                    {
                        if (destinationDirective.InspectedDetail is BaseDetail)
                        {
                            BaseDetail baseDetail = (BaseDetail) destinationDirective.Parent;
                            if (baseDetail is AircraftFrame)
                                caption = baseDetail.ParentAircraft.RegistrationNumber + ". " +
                                          destinationDirective.DirectiveType.CommonName + ". " +
                                          destinationDirective.Title;
                            else
                                caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " +
                                          destinationDirective.DirectiveType.CommonName + ". " +
                                          destinationDirective.Title;
                        }
                        if (DisplayerRequested != null)
                            DisplayerRequested(this,
                                               new ReferenceEventArgs(null,
                                                                      ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                                      caption));
                    }
                }
            }
            if (destinationDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || destinationDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                if (destinationDirective.Paragraph != Paragraph)
                    destinationDirective.Paragraph = Paragraph;
                if (destinationDirective.HiddenRemarks != HiddenRemarks)
                    destinationDirective.HiddenRemarks = HiddenRemarks;
                if (destinationDirective.Revision != Revision)
                    destinationDirective.Revision = Revision;
            }
            if (destinationDirective.EffectivityDate != EffectiveDate)
                destinationDirective.EffectivityDate = EffectiveDate;
            if (destinationDirective.References != References)
                destinationDirective.References = References;
            if (destinationDirective.Applicability != Applicability)
                destinationDirective.Applicability = Applicability;
            if (destinationDirective.SupersededBy != SupersededBy)
                destinationDirective.SupersededBy = SupersededBy;
            if (destinationDirective.Supersedes != Supersedes)
                destinationDirective.Supersedes = Supersedes;
            if (destinationDirective.DirectiveType != DirectiveTypeCollection.Instance.SBDirectiveType && destinationDirective.BiweeklyReport != BiWeeklyReport)
                destinationDirective.BiweeklyReport = BiWeeklyReport;
            if (destinationDirective.Description != Subject)
                destinationDirective.Description = Subject;
            if (destinationDirective.Boundery != Threshold)
                destinationDirective.Boundery = Threshold;
            if (destinationDirective.Remarks != Remarks)
                destinationDirective.Remarks = Remarks;
            if (destinationDirective.DirectiveType != DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                if (destinationDirective.ManHours != manHours)
                    destinationDirective.ManHours = manHours;
                if (destinationDirective.Cost != cost)
                    destinationDirective.Cost = cost;
            }

            if (lifelengthViewerSinceNew.Lifelength == Lifelength.NullLifelength)
                PerformSinceNew = false;
            if (lifelengthViewerSinceEffectivityDate.Lifelength == Lifelength.NullLifelength)
                PerformSinceEffectivityDate = false;
            if (lifelengthViewerRepeatInterval.Lifelength == Lifelength.NullLifelength)
                PerformRepeatedly = false;

            if (destinationDirective.PerformSinceNew != PerformSinceNew)
                destinationDirective.PerformSinceNew = PerformSinceNew;
            if (destinationDirective.PerformSinceEffectivityDate != PerformSinceEffectivityDate)
                destinationDirective.PerformSinceEffectivityDate = PerformSinceEffectivityDate;
            if (destinationDirective.RepeatedlyPerform != PerformRepeatedly)
                destinationDirective.RepeatedlyPerform = PerformRepeatedly;

            lifelengthViewerSinceNew.SaveData(destinationDirective.FirstPerformSinceNew);
            lifelengthViewerSinceEffectivityDate.SaveData(destinationDirective.SinceEffectivityDatePerformanceLifelength);
            lifelengthViewerRepeatInterval.SaveData(destinationDirective.RepeatPerform);
            lifelengthViewerNotifyBefore.SaveData(destinationDirective.Notification);
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            comboBoxAtaChapter.ClearValue();
            ADType = ADType.Airframe;
            Title = "";
            Paragraph = "";
            dateTimePickerEffDate.Value = DateTime.Today;
            References = "";
            Applicability = "";
            SupersededBy = "";
            Supersedes = "";
            BiWeeklyReport = "";
            Subject = "";
            Threshold = "";
            Remarks = "";
            HiddenRemarks = "";
            Revision = "";
            ManhoursString = "";
            CostString = "";
            lifelengthViewerSinceNew.Lifelength = new Lifelength();
            lifelengthViewerSinceEffectivityDate.Lifelength = new Lifelength();
            lifelengthViewerNotifyBefore.Lifelength = new Lifelength();
            lifelengthViewerRepeatInterval.Lifelength = new Lifelength();
            PerformSinceNew = true;
            PerformSinceEffectivityDate = true;
            PerformRepeatedly = true;
        }

        #endregion
        
        #region private void checkBoxSinceRepeatInterval_CheckedChanged(object sender, EventArgs e)

        private void checkBoxSinceRepeatInterval_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewerRepeatInterval.Enabled = checkBoxSinceRepeatInterval.Checked;
        }

        #endregion

        #region private void checkBoxSinceEffectivityDate_CheckedChanged(object sender, EventArgs e)

        private void checkBoxSinceEffectivityDate_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewerSinceEffectivityDate.Enabled = checkBoxSinceEffectivityDate.Checked;
        }

        #endregion

        #region private void checkBoxSinceNew_CheckedChanged(object sender, EventArgs e)

        private void checkBoxSinceNew_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewerSinceNew.Enabled = checkBoxSinceNew.Checked;
        }

        #endregion

        #region public bool CheckManHours(out double manHours)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="manHours">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours(out double manHours)
        {
            if (ManhoursString == "")
            {
                manHours = 0;
                return true;
            }
            if (double.TryParse(ManhoursString, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckCost(out double cost)

        /// <summary>
        /// Проверяет значение Cost
        /// </summary>
        /// <param name="cost">Значение Cost</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckCost(out double cost)
        {
            if (CostString == "")
            {
                cost = 0;
                return true;
            }
            if (double.TryParse(CostString, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckLifelengthes()

        /// <summary>
        /// Проверяется корректность введенных данных о наработках
        /// </summary>
        /// <returns></returns>
        public bool CheckLifelengthes()
        {
            return
                lifelengthViewerNotifyBefore.ValidateData() && lifelengthViewerRepeatInterval.ValidateData() &&
                lifelengthViewerSinceEffectivityDate.ValidateData() && lifelengthViewerSinceNew.ValidateData();
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