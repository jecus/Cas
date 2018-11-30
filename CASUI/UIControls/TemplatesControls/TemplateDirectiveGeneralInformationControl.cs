using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    ///<summary>
    /// Отображает информацию о шаблонной директиве
    ///</summary>
    public class TemplateDirectiveGeneralInformationControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int CHECK_BOX_WIDTH = 150;
        private const int HEIGHT_INTERVAL = 20;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int WIDTH_INTERVAL =600;


        private TemplateBaseDetailDirective currentDirective;
        
        private readonly Label labelATAChapter;
        private readonly Label labelTitle;
        private readonly Label labelEffectivityDate;
        private readonly Label labelReferences;
        private readonly Label labelApplicability;
        private readonly Label labelSupersededBy;
        private readonly Label labelSupersedes;
        private readonly Label labelBiWeeklyReport;
        private readonly Label labelSubject;
        private readonly Label labelThreshold;
        private readonly Label labelFirstPerformAt;
        private readonly Label labelAndThen;
        private readonly Label labelNotifyBefore;
        private readonly Label labelManHours;
        private readonly Label labelRemarks;
        //private readonly Label labelAmount;
        private readonly ATAChapterComboBox comboBoxAtaChapter;
        private readonly TextBox textboxTitle;
        private readonly DateTimePicker dateTimePickerEffDate;
        private readonly TextBox textBoxReferences;
        private readonly TextBox textboxApplicability;
        private readonly TextBox textboxSupersededBy;
        private readonly TextBox textboxSupersedes;
        private readonly TextBox textboxBiWeeklyReport;
        private readonly TextBox textboxSubject;
        private readonly TextBox textboxThreshold;
        private readonly CheckBox checkBoxSinceNew;
        private readonly CheckBox checkBoxSinceEffectivityDate;
        private readonly CheckBox checkBoxSinceRepeatInterval;
        /// <summary>
        /// </summary>
        protected readonly LifelengthViewer lifelengthViewerSinceNew;
        /// <summary>
        /// </summary>
        protected readonly LifelengthViewer lifelengthViewerSinceEffectivityDate;
        /// <summary>
        /// </summary>
        protected readonly LifelengthViewer lifelengthViewerRepeatInterval;
        /// <summary>
        /// </summary>
        protected readonly LifelengthViewer lifelengthViewerNotifyBefore;
        private readonly TextBox textboxManHours;
        private readonly TextBox textboxRemarks;
        //  private readonly TextBox textboxAmount;
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructors

        #region public TemplateDirectiveGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о шаблонной директиве
        ///</summary>
        public TemplateDirectiveGeneralInformationControl()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            labelATAChapter = new Label();
            labelTitle = new Label();
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
            labelNotifyBefore = new Label();
            labelManHours = new Label();
            labelRemarks = new Label();
            //labelAmount = new Label();
            comboBoxAtaChapter = new ATAChapterComboBox();
            textboxTitle = new TextBox();
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
            lifelengthViewerRepeatInterval= new LifelengthViewer();
            lifelengthViewerNotifyBefore= new LifelengthViewer();
            textboxManHours = new TextBox();
            textboxRemarks = new TextBox();
            //  textboxAmount = new TextBox();
            // 
            // labelATAChapter
            // 
            labelATAChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelATAChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelATAChapter.Location = new Point(MARGIN, MARGIN);// + LABEL_HEIGHT + HEIGHT_INTERVAL);
            labelATAChapter.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelATAChapter.Text = "ATA Chapter";
            //
            // comboBoxAtaChapter
            //
            comboBoxAtaChapter.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxAtaChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxAtaChapter.Location = new Point(labelATAChapter.Right, MARGIN);
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTitle.Location = new Point(MARGIN, labelATAChapter.Bottom + HEIGHT_INTERVAL);
            labelTitle.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTitle.Text = "Title";
            // 
            // textboxTitle
            // 
            textboxTitle.BackColor = Color.White;
            textboxTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxTitle.Location = new Point(labelTitle.Right, comboBoxAtaChapter.Bottom + HEIGHT_INTERVAL);
            textboxTitle.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxTitle.MaxLength = 50;
            // 
            // labelEffectiveDate
            // 
            labelEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEffectivityDate.Location = new Point(MARGIN, labelTitle.Bottom + HEIGHT_INTERVAL);
            labelEffectivityDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEffectivityDate.Text = "Effective Date";
            //
            //  dateTimePickerEffDate
            //
            dateTimePickerEffDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerEffDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerEffDate.Location = new Point(labelEffectivityDate.Right, textboxTitle.Bottom + HEIGHT_INTERVAL);
            dateTimePickerEffDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelReferences
            // 
            labelReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelReferences.Location = new Point(MARGIN, labelEffectivityDate.Bottom + HEIGHT_INTERVAL);
            labelReferences.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelReferences.Text = "References";
            // 
            // textBoxReferences
            // 
            textBoxReferences.BackColor = Color.White;
            textBoxReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxReferences.Location = new Point(labelReferences.Right, dateTimePickerEffDate.Bottom + HEIGHT_INTERVAL);
            textBoxReferences.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxReferences.MaxLength = 400;
            // 
            // labelApplicability
            // 
            labelApplicability.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelApplicability.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelApplicability.Location = new Point(MARGIN, labelReferences.Bottom + HEIGHT_INTERVAL);
            labelApplicability.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelApplicability.Text = "Applicability";
            // 
            // textboxApplicability
            // 
            textboxApplicability.BackColor = Color.White;
            textboxApplicability.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxApplicability.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxApplicability.Location = new Point(labelApplicability.Right, textBoxReferences.Bottom + HEIGHT_INTERVAL);
            textboxApplicability.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxApplicability.MaxLength = 1000;
            // 
            // labelSupersededBy
            // 
            labelSupersededBy.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSupersededBy.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSupersededBy.Location = new Point(MARGIN, labelApplicability.Bottom + HEIGHT_INTERVAL);
            labelSupersededBy.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSupersededBy.Text = "Superseded by";
            // 
            // textboxSupersededBy
            // 
            textboxSupersededBy.BackColor = Color.White;
            textboxSupersededBy.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSupersededBy.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSupersededBy.Location = new Point(labelSupersededBy.Right, textboxApplicability.Bottom + HEIGHT_INTERVAL);
            textboxSupersededBy.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxSupersededBy.MaxLength = 50;
            // 
            // labelSupersedes
            // 
            labelSupersedes.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSupersedes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSupersedes.Location = new Point(MARGIN, labelSupersededBy.Bottom + HEIGHT_INTERVAL);
            labelSupersedes.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSupersedes.Text = "Supersedes";
            // 
            // textboxSupersedes
            // 
            textboxSupersedes.BackColor = Color.White;
            textboxSupersedes.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSupersedes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSupersedes.Location = new Point(labelSupersedes.Right, textboxSupersededBy.Bottom + HEIGHT_INTERVAL);
            textboxSupersedes.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxSupersedes.MaxLength = 50;
            // 
            // labelBiWeeklyReport
            // 
            labelBiWeeklyReport.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelBiWeeklyReport.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelBiWeeklyReport.Location = new Point(MARGIN, labelSupersedes.Bottom + HEIGHT_INTERVAL);
            labelBiWeeklyReport.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelBiWeeklyReport.Text = "BiWeekly Report";
            // 
            // textboxBiWeeklyReport
            // 
            textboxBiWeeklyReport.BackColor = Color.White;
            textboxBiWeeklyReport.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxBiWeeklyReport.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxBiWeeklyReport.Location = new Point(labelBiWeeklyReport.Right, textboxSupersedes.Bottom + HEIGHT_INTERVAL);
            textboxBiWeeklyReport.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxBiWeeklyReport.MaxLength = 50;
            // 
            // labelSubject
            // 
            labelSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSubject.Location = new Point(MARGIN, labelBiWeeklyReport.Bottom + HEIGHT_INTERVAL);
            labelSubject.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSubject.Text = "Subject";
            // 
            // textboxSubject
            // 
            textboxSubject.ScrollBars = ScrollBars.Vertical;
            textboxSubject.BackColor = Color.White;
            textboxSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSubject.Location = new Point(labelSubject.Right, textboxBiWeeklyReport.Bottom + HEIGHT_INTERVAL);
            textboxSubject.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2* HEIGHT_INTERVAL);
            textboxSubject.Multiline = true;
            textboxSubject.MaxLength = 1000;
            // 
            // labelThreshold
            // 
            labelThreshold.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelThreshold.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelThreshold.Location = new Point(MARGIN, textboxSubject.Bottom + HEIGHT_INTERVAL);
            labelThreshold.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelThreshold.Text = "Threshold";
            // 
            // textboxThreshold
            // 
            textboxThreshold.ScrollBars = ScrollBars.Vertical;
            textboxThreshold.BackColor = Color.White;
            textboxThreshold.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxThreshold.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxThreshold.Location = new Point(labelThreshold.Right, textboxSubject.Bottom + HEIGHT_INTERVAL);
            textboxThreshold.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxThreshold.Multiline = true;
            //textboxThreshold.MaxLength = 1000;
            //
            // labelFirstPerformAt
            //
            labelFirstPerformAt.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelFirstPerformAt.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFirstPerformAt.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelFirstPerformAt.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelFirstPerformAt.Text = "First Perform At";
            //
            // checkBoxSinceNew
            //
            checkBoxSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceNew.Location = new Point(WIDTH_INTERVAL, labelFirstPerformAt.Bottom + HEIGHT_INTERVAL);
            checkBoxSinceNew.Size = new Size(CHECK_BOX_WIDTH,LABEL_HEIGHT);
            checkBoxSinceNew.Text = "Since New";
            checkBoxSinceNew.CheckedChanged += checkBoxSinceNew_CheckedChanged;
            //
            // lifelengthViewerSinceNew
            //
            lifelengthViewerSinceNew.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerSinceNew.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerSinceNew.ShowLeftHeader = false;
            lifelengthViewerSinceNew.ShowMinutes = false;
            lifelengthViewerSinceNew.LeftHeaderWidth = 0;
            //
            // checkBoxSinceEffectivityDate
            //
            checkBoxSinceEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceEffectivityDate.Location = new Point(WIDTH_INTERVAL, checkBoxSinceNew.Bottom + HEIGHT_INTERVAL);
            checkBoxSinceEffectivityDate.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            checkBoxSinceEffectivityDate.Text = "Since Eff. Date";
            checkBoxSinceEffectivityDate.CheckedChanged += checkBoxSinceEffectivityDate_CheckedChanged;
            //
            // lifelengthViewerSinceEffectivityDate
            //
            lifelengthViewerSinceEffectivityDate.ShowHeaders = false;
            lifelengthViewerSinceEffectivityDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerSinceEffectivityDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerSinceEffectivityDate.ShowLeftHeader = false;
            lifelengthViewerSinceEffectivityDate.ShowMinutes = false;
            lifelengthViewerSinceEffectivityDate.LeftHeaderWidth = 0;
            //
            // labelAndThen
            //
            labelAndThen.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelAndThen.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAndThen.Location = new Point(WIDTH_INTERVAL, checkBoxSinceEffectivityDate.Bottom + HEIGHT_INTERVAL);
            labelAndThen.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAndThen.Text = "And then";
            //
            // checkBoxSinceRepeatInterval
            //
            checkBoxSinceRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            checkBoxSinceRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            checkBoxSinceRepeatInterval.Location = new Point(WIDTH_INTERVAL, labelAndThen.Bottom + HEIGHT_INTERVAL);
            checkBoxSinceRepeatInterval.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            checkBoxSinceRepeatInterval.Text = "Repeat every";
            checkBoxSinceRepeatInterval.CheckedChanged += checkBoxSinceRepeatInterval_CheckedChanged;
            //
            // lifelengthViewerRepeatInterval
            //
            lifelengthViewerRepeatInterval.ShowHeaders = false;
            lifelengthViewerRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerRepeatInterval.ShowLeftHeader = false;
            lifelengthViewerRepeatInterval.ShowMinutes = false;
            lifelengthViewerRepeatInterval.LeftHeaderWidth = 0;
            //
            // labelNotifyBefore
            //
            labelNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotifyBefore.Location = new Point(WIDTH_INTERVAL, checkBoxSinceRepeatInterval.Bottom + HEIGHT_INTERVAL);
            labelNotifyBefore.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            labelNotifyBefore.Text = "Notify Before";
            //
            // lifelengthViewerNotifyBefore
            //
            lifelengthViewerNotifyBefore.ShowHeaders = false;
            lifelengthViewerNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNotifyBefore.ShowLeftHeader = false;
            lifelengthViewerNotifyBefore.ShowMinutes = false;
            lifelengthViewerNotifyBefore.LeftHeaderWidth = 0;
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Location = new Point(WIDTH_INTERVAL, labelNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            labelManHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManHours.Text = "Man Hours";
            // 
            // textboxManHours
            // 
            textboxManHours.BackColor = Color.White;
            textboxManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxManHours.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            //textboxManHours.Validating += textboxManHours_Validating;
            textboxManHours.Text = "0.0";
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(WIDTH_INTERVAL, labelManHours.Bottom + HEIGHT_INTERVAL);
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
/*            // 
            // labelAmount
            // 
            labelAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAmount.Location = new Point(WIDTH_INTERVAL, labelManHours.Bottom + HEIGHT_INTERVAL);
            labelAmount.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAmount.Text = "Amount";
            // 
            // textboxAmount
            // 
            textboxAmount.BackColor = Color.White;
            textboxAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxAmount.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxAmount.Text = "1";*/
            
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
            Controls.Add(labelBiWeeklyReport);
            Controls.Add(textboxBiWeeklyReport);
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
            Controls.Add(labelManHours);
            Controls.Add(textboxManHours);
            Controls.Add(labelRemarks);
            Controls.Add(textboxRemarks);
            //  Controls.Add(labelAmount);
            //  Controls.Add(textboxAmount);

            lifelengthViewerSinceNew.Location = new Point(checkBoxSinceNew.Right, labelFirstPerformAt.Bottom);
            lifelengthViewerSinceEffectivityDate.Location = new Point(checkBoxSinceNew.Right, lifelengthViewerSinceNew.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerRepeatInterval.Location = new Point(checkBoxSinceNew.Right, labelAndThen.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerNotifyBefore.Location = new Point(checkBoxSinceNew.Right, lifelengthViewerRepeatInterval.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            textboxManHours.Location = new Point(labelManHours.Right, lifelengthViewerNotifyBefore.Bottom + LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxRemarks.Location = new Point(labelRemarks.Right, textboxManHours.Bottom + HEIGHT_INTERVAL);
            //  textboxAmount.Location = new Point(labelAmount.Right, textboxManHours.Bottom + HEIGHT_INTERVAL);
            
            checkBoxSinceRepeatInterval.Checked = true;
            checkBoxSinceNew.Checked = true;
            checkBoxSinceEffectivityDate.Checked = true;
        }

        #endregion

        #region public TemplateDirectiveGeneralInformationControl(TemplateBaseDetailDirective currentDirective) : this()

        ///<summary>
        /// Создает экземпляр класса для отображения информации о шаблонной директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public TemplateDirectiveGeneralInformationControl(TemplateBaseDetailDirective currentDirective) : this()
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;

            
            /*if (currentDirective.PerformSinceNew) lifelengthViewerSinceNew.Applicable = true;
            if (currentDirective.PerformSinceEffectivityDate)
                lifelengthViewerSinceEffectivityDate.Applicable = true;
            if (currentDirective.RepeatedlyPerform) lifelengthViewerRepeatInterval.Applicable = true;*/
        }

        #endregion

        #endregion

        #region Properties

        #region public TemplateBaseDetailDirective CurrentDirective

        /// <summary>
        /// Текущая шаблонная директива
        /// </summary>
        public TemplateBaseDetailDirective CurrentDirective
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

        #region public string Applicability

        /// <summary>
        /// Applicability текущей директивы
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

        #region public ActualState FirstPerformSinceNew

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

        #region public ActualState FirstPerformSinceEffDate

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

        #region public ActualState FirstPerformRepeatInterval

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

        #region public ActualState FirstPerformNotifyBefore

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

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            double eps = 0.00001;
            double d;
            Date effectiveDate = new Date(EffectiveDate);
            Date today = new Date(DateTime.Today);
            bool manHours = double.TryParse(ManhoursString, out d);
            Lifelength emptyLifelength = new Lifelength();
            if (directiveExist)
                return ((ATAChapter != currentDirective.AtaChapter) ||
                        (Title != currentDirective.Title) ||
                        (EffectiveDate != currentDirective.EffectivityDate) ||
                        (References != currentDirective.References) ||
                        (Applicability != currentDirective.Applicability) ||
                        (SupersededBy != currentDirective.SupersededBy) ||
                        (Supersedes != currentDirective.Supersedes) ||
                        (BiWeeklyReport != currentDirective.BiweeklyReport) ||
                        (Subject != currentDirective.Description) ||
                        (Threshold != currentDirective.Boundery) ||
                        (Math.Abs((Manhours - Math.Round(currentDirective.ManHours, 2))) > eps) ||
                        (Remarks != currentDirective.Remarks) ||
                        //(Amount != currentDirective.Amount.ToString()) || 
                        (PerformSinceNew != currentDirective.PerformSinceNew) ||
                        (PerformSinceEffectivityDate != currentDirective.PerformSinceEffectivityDate) ||
                        (PerformRepeatedly != currentDirective.RepeatedlyPerform) ||
                        lifelengthViewerSinceNew.Modified ||
                        lifelengthViewerSinceEffectivityDate.Modified ||
                        lifelengthViewerRepeatInterval.Modified ||
                        lifelengthViewerNotifyBefore.Modified || !manHours);
            else
                return ((ATAChapter != null) ||
                        (Title != "") ||
                        (effectiveDate.ToDateTime() != today.ToDateTime()) ||
                        (References != "") ||
                        (Applicability != "") ||
                        (SupersededBy != "") ||
                        (Supersedes != "") ||
                        (BiWeeklyReport != "") ||
                        (Subject != "") ||
                        (Threshold != "") ||
                        (ManhoursString != "0.0") ||
                        (Remarks != "") ||
                        //(Amount != "1") ||
                        !(lifelengthViewerSinceNew.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerSinceEffectivityDate.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerNotifyBefore.Lifelength.Equals(emptyLifelength)) ||
                        !(lifelengthViewerRepeatInterval.Lifelength.Equals(emptyLifelength)) ||
                        !PerformSinceNew || !PerformSinceEffectivityDate || !PerformRepeatedly);
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования шаблонной директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDirective != null)
                UpdateInformation(currentDirective);
        }

        #endregion

        #region public void UpdateInformation(TemplateBaseDetailDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования шаблонной директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(TemplateBaseDetailDirective sourceDirective)
        {
            if (sourceDirective == null) 
                throw new ArgumentNullException("sourceDirective");
            ATAChapter = sourceDirective.AtaChapter;
            Title = sourceDirective.Title;
            EffectiveDate = sourceDirective.EffectivityDate;
            References = sourceDirective.References;
            Applicability = sourceDirective.Applicability;
            SupersededBy = sourceDirective.SupersededBy;
            Supersedes = sourceDirective.Supersedes;
            BiWeeklyReport = sourceDirective.BiweeklyReport;
            Subject = sourceDirective.Description;
            Threshold = sourceDirective.Boundery;
            Manhours = sourceDirective.ManHours;
            Remarks = sourceDirective.Remarks;
            //Amount = sourceDirective.Amount.ToString();
            PerformSinceNew = sourceDirective.PerformSinceNew;
            PerformSinceEffectivityDate = sourceDirective.PerformSinceEffectivityDate;
            PerformRepeatedly = sourceDirective.RepeatedlyPerform;
            FirstPerformSinceNew = sourceDirective.FirstPerformSinceNew;
            FirstPerformRepeatInterval = sourceDirective.RepeatPerform;
            FirstPerformSinceEffDate = sourceDirective.SinceEffectivityDatePerformanceLifelength;
            FirstPerformNotifyBefore = sourceDirective.Notification;

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            comboBoxAtaChapter.Enabled = permission;
            textboxTitle.ReadOnly = !permission;
            dateTimePickerEffDate.Enabled = permission;
            textBoxReferences.ReadOnly = !permission;
            textboxApplicability.ReadOnly = !permission;
            textboxSupersededBy.ReadOnly = !permission;
            textboxSupersedes.ReadOnly = !permission;
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
            textboxManHours.ReadOnly = !permission;
            textboxRemarks.ReadOnly = !permission;
//            textboxAmount.ReadOnly = !permission;
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

        #region public void SaveData(TemplateBaseDetailDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Шаблонная директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void SaveData(TemplateBaseDetailDirective destinationDirective, bool changePageName)
        {
            textboxTitle.Focus();
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            double manHours;
            //   int amount;
            CheckManHours(out manHours);
            //CheckAmount(out amount);

            if (destinationDirective.AtaChapter != ATAChapter)
                destinationDirective.AtaChapter = ATAChapter;
            if (destinationDirective.Title != Title)
            {
                destinationDirective.Title = Title;
                if (changePageName)
                {
                    string caption = "";
                    if (destinationDirective.Parent.Parent is TemplateAircraft)
                        //caption = "Templates. " + ((TemplateAircraft)destinationDirective.Parent.Parent).Model + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                        caption = ((TemplateAircraft)destinationDirective.Parent.Parent).Model + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                    if (DisplayerRequested != null)
                        DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
                }
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
            if (destinationDirective.BiweeklyReport != BiWeeklyReport)
                destinationDirective.BiweeklyReport = BiWeeklyReport;
            if (destinationDirective.Description != Subject)
                destinationDirective.Description = Subject;
            if (destinationDirective.Boundery != Threshold)
                destinationDirective.Boundery = Threshold;
            if (destinationDirective.ManHours != manHours)
                destinationDirective.ManHours = manHours;
            if (destinationDirective.Remarks != Remarks)
                destinationDirective.Remarks = Remarks;
            //if (destinationDirective.Amount.ToString() != Amount)
            //    destinationDirective.Amount = amount;

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

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            comboBoxAtaChapter.ClearValue();
            Title = "";
            dateTimePickerEffDate.Value = DateTime.Today;
            References = "";
            Applicability = "";
            SupersededBy = "";
            Supersedes = "";
            BiWeeklyReport = "";
            Subject = "";
            Threshold = "";
            ManhoursString = "0.0";
            Remarks = "";
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

        #region public bool CheckManHours()

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours()
        {
            double manHours;
            return CheckManHours(out manHours);
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

        #endregion

        #region IReference Members

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