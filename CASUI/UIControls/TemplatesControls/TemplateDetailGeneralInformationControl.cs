using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.TemplatesControls
{
    ///<summary>
    /// Отображает информацию об агрегате
    ///</summary>
    public class TemplateDetailGeneralInformationControl : UserControl, IReference
    {

        #region Fields

        private readonly TemplateAbstractDetail currentDetail;

        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 250;
        private const int TEXTBOX_WIDTH = 200;
        private const int WIDTH_INTERVAL = 150;
        private const int HEIGHT = 220;
        private const int WIDTH = 1150;
        private MaintenanceTypeCollection maintenanceCollection;
        
        private Label labelAtaChapter;
        private Label labelDescription;
        private Label labelPosition;
        private Label labelMaintFreq;
        private Label labelManufacturer;
        private Label labelModel;
        private Label labelPartNo;
        private Label labelAmount;
        private Label labelRemarks;
        private CheckBox checkBoxCalendarApplicable;
        private CheckBox checkBoxCyclesApplicable;
        private CheckBox checkBoxHoursApplicable;
        private ATAChapterComboBox comboBoxAtaChapter;
        private RadioButton radioButtonConditionMonitoring;
        private RadioButton radioButtonHardTime;
        private RadioButton radioButtonOnCondition;
        private RadioButton radioButtonUnknown;
        private TextBox textBoxDescription;
        private Panel panelLandingGearMark;
        private RadioButton radioButtonLLG;
        private RadioButton radioButtonNLG;
        private RadioButton radioButtonRLG;
        private TextBox textBoxManufacturer;
        private TextBox textBoxModel;
        private TextBox textBoxPartNo;
        private TextBox textBoxAmount;
        private TextBox textBoxRemarks;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        

        #endregion

        #region Constructors

        #region public TemplateDetailGeneralInformationControl()

        /// <summary>
        /// Создает экземпляр отображатора информации о шаблонном агрегате
        /// </summary>
        public TemplateDetailGeneralInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public TemplateDetailGeneralInformationControl(TemplateAbstractDetail currentDetail)

        /// <summary>
        /// Создает экземпляр отображатора информации о шаблонном агрегате
        /// </summary>
        /// <param name="currentDetail"></param>
        public TemplateDetailGeneralInformationControl(TemplateAbstractDetail currentDetail)
        {
            if (null == currentDetail)
                throw new ArgumentNullException("currentDetail", "Argument cannot be null");
            this.currentDetail = currentDetail;
            InitializeComponent();
        }

        #endregion

        #endregion

        #region  Propeties

/*        #region public TemplateAbstractDetail CurrentDetail

        /// <summary>
        /// Задает или возвращает отображаемый агрегат
        /// </summary>
        public TemplateAbstractDetail CurrentDetail
        {
            get { return currentDetail; }
            set
            {
                currentDetail = value;
                if (value != null) 
                    UpdateInformation();
            }
        }

        #endregion*/

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

        #region public string PartNumber

        /// <summary>
        /// Displayed PartNumber
        /// </summary>
        public string PartNumber
        {
            get { return textBoxPartNo.Text; }
            set
            {
                textBoxPartNo.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// Отображаемое описание 
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Text; }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region public LandingGearMarkType LandingGearMark

        /// <summary>
        /// Возвращает или устанавливает позицию шасси
        /// </summary>
        public LandingGearMarkType LandingGearMark
        {
            get
            {
                if (radioButtonLLG.Checked)
                    return LandingGearMarkType.Left;
                else if (radioButtonNLG.Checked)
                    return LandingGearMarkType.General;
                else if (radioButtonRLG.Checked)
                    return LandingGearMarkType.Right;
                else
                    return LandingGearMarkType.None;
            }
            set
            {
                if (value == LandingGearMarkType.Left)
                    radioButtonLLG.Checked = true;
                else if (value == LandingGearMarkType.General)
                    radioButtonNLG.Checked = true;
                else if (value == LandingGearMarkType.Right)
                    radioButtonRLG.Checked = true;
            }
        }

        #endregion

        #region public string Amount

        /// <summary>
        /// Количестко 
        /// </summary>
        public string Amount
        {
            get { return textBoxAmount.Text; }
            set
            {
                textBoxAmount.Text = value;
            }
        }

        #endregion

        #region public string Model

        /// <summary>
        /// Отображаемая модель
        /// </summary>
        public string Model
        {
            get { return textBoxModel.Text; }
            set
            {
                textBoxModel.Text = value;
            }
        }

        #endregion

        #region public string Manufacturer

        /// <summary>
        /// Отображаемый производитель 
        /// </summary>
        public string Manufacturer
        {
            get { return textBoxManufacturer.Text; }
            set
            {
                textBoxManufacturer.Text = value;
            }
        }

        #endregion

        #region public MaintenanceType MaintenanceType

        /// <summary>
        /// Отображаемый Тип технического обслуживания
        /// </summary>
        public MaintenanceType MaintenanceType
        {
            get
            {
                if (radioButtonConditionMonitoring.Checked)
                    return maintenanceCollection.ConditionMonitoringType;
                if (radioButtonOnCondition.Checked)
                    return maintenanceCollection.OnConditionType;
                if (radioButtonHardTime.Checked)
                    return maintenanceCollection.HardTimeType;
                if (radioButtonUnknown.Checked)
                    return maintenanceCollection.UnknownType;
                return null;
            }
            set
            {
                if (value.ID == maintenanceCollection.ConditionMonitoringType.ID)
                {
                    radioButtonConditionMonitoring.Checked = true;
                }
                else if (value.ID == maintenanceCollection.OnConditionType.ID)
                {
                    radioButtonOnCondition.Checked = true;
                }
                else if (value.ID == maintenanceCollection.HardTimeType.ID)
                {
                    radioButtonHardTime.Checked = true;
                }
                else
                {
                    radioButtonUnknown.Checked = true;
                }
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Отображаемые замечания
        /// </summary>
        public string Remarks
        {
            get { return textBoxRemarks.Text; }
            set
            {
                textBoxRemarks.Text = value;
            }
        }

        #endregion

        #region public bool HoursApplicable

        /// <summary>
        /// Показывает применимо ли ведение наработки по часам
        /// </summary>
        public bool HoursApplicable
        {
            get
            {
                return checkBoxHoursApplicable.Checked;
            }
            set
            {
                checkBoxHoursApplicable.Checked = value;
            }
        }

        #endregion

        #region public bool CyclesApplicable

        /// <summary>
        /// Показывает применимо ли ведение наработки по циклам
        /// </summary>
        public bool CyclesApplicable
        {
            get
            {
                return checkBoxCyclesApplicable.Checked;
            }
            set
            {
                checkBoxCyclesApplicable.Checked = value;
            }
        }

        #endregion

        #region public bool CalendarApplicable

        /// <summary>
        /// Показывает применимо ли ведение наработки по календарю
        /// </summary>
        public bool CalendarApplicable
        {
            get
            {
                return checkBoxCalendarApplicable.Checked;
            }
            set
            {
                checkBoxCalendarApplicable.Checked = value;
            }
        }

        #endregion

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void InitializeComponent()

        ///<summary>
        /// Инициализация компонентов
        ///</summary>
        public void InitializeComponent()
        {
            labelModel = new Label();
            labelManufacturer = new Label();
            comboBoxAtaChapter = new ATAChapterComboBox();
            labelPartNo = new Label();
            labelPosition = new Label();
            labelDescription = new Label();
            radioButtonConditionMonitoring = new RadioButton();
            radioButtonUnknown = new RadioButton();
            radioButtonHardTime = new RadioButton();
            radioButtonOnCondition = new RadioButton();
            labelRemarks = new Label();
            textBoxRemarks = new TextBox();
            labelAtaChapter = new Label();
            textBoxPartNo = new TextBox();
            labelMaintFreq = new Label();
            panelLandingGearMark = new Panel();
            radioButtonLLG = new RadioButton();
            radioButtonNLG = new RadioButton();
            radioButtonRLG = new RadioButton();
            textBoxDescription = new TextBox();
            labelAmount = new Label();
            textBoxManufacturer = new TextBox();
            textBoxModel = new TextBox();
            textBoxAmount = new TextBox();
            checkBoxHoursApplicable = new CheckBox();
            checkBoxCyclesApplicable = new CheckBox();
            checkBoxCalendarApplicable = new CheckBox();
            // 
            // labelPartNo
            // 
            labelPartNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPartNo.Location = new Point(MARGIN, MARGIN);
            labelPartNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPartNo.Text = "Part No:";
            labelPartNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNo
            // 
            textBoxPartNo.BackColor = Color.White;
            textBoxPartNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPartNo.Location = new Point(labelPartNo.Right, MARGIN);
            textBoxPartNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxPartNo.Text = "";
            textBoxPartNo.MaxLength = 100;
            // 
            // labelAtaChapter
            // 
            labelAtaChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAtaChapter.Location = new Point(MARGIN, labelPartNo.Bottom + HEIGHT_INTERVAL);
            labelAtaChapter.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAtaChapter.Text = "ATA Chapter:";
            labelAtaChapter.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxAtaChapter
            // 
            comboBoxAtaChapter.BackColor = Color.White;
            comboBoxAtaChapter.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxAtaChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxAtaChapter.FormattingEnabled = true; 
            comboBoxAtaChapter.Location = new Point(labelAtaChapter.Right, textBoxPartNo.Bottom + HEIGHT_INTERVAL);
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, labelAtaChapter.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxDescription.Location = new Point(labelDescription.Right, comboBoxAtaChapter.Bottom + HEIGHT_INTERVAL);
            textBoxDescription.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxDescription.MaxLength = 250;
            // 
            // labelPosition
            // 
            labelPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPosition.Location = new Point(MARGIN, labelDescription.Bottom + HEIGHT_INTERVAL);
            labelPosition.RightToLeft = RightToLeft.No;
            labelPosition.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPosition.Text = "Position:";
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelLandingGearMark
            //
            panelLandingGearMark.AutoSize = true;
            panelLandingGearMark.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelLandingGearMark.Location = new Point(labelPosition.Right, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            panelLandingGearMark.Controls.Add(radioButtonLLG);
            panelLandingGearMark.Controls.Add(radioButtonNLG);
            panelLandingGearMark.Controls.Add(radioButtonRLG);
            // 
            // radioButtonLLG
            // 
            radioButtonLLG.Cursor = Cursors.Hand;
            radioButtonLLG.FlatStyle = FlatStyle.Flat;
            radioButtonLLG.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonLLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonLLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonLLG.Text = "Left";
            // 
            // radioButtonNLG
            // 
            radioButtonNLG.Cursor = Cursors.Hand;
            radioButtonNLG.FlatStyle = FlatStyle.Flat;
            radioButtonNLG.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonNLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonNLG.Location = new Point(radioButtonLLG.Right, 0);
            radioButtonNLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonNLG.Text = "Nose";
            // 
            // radioButtonRLG
            // 
            radioButtonRLG.Cursor = Cursors.Hand;
            radioButtonRLG.FlatStyle = FlatStyle.Flat;
            radioButtonRLG.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonRLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonRLG.Location = new Point(radioButtonNLG.Right, 0);
            radioButtonRLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonRLG.Text = "Right";
            if (currentDetail is TemplateGearAssembly)
                labelModel.Location = new Point(MARGIN, labelPosition.Bottom + HEIGHT_INTERVAL);
            else
                labelModel.Location = new Point(MARGIN, labelDescription.Bottom + HEIGHT_INTERVAL);
            // 
            // labelModel
            // 
            labelModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelModel.RightToLeft = RightToLeft.No;
            labelModel.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelModel.Text = "Model:";
            labelModel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxModel
            // 
            textBoxModel.BackColor = Color.White;
            textBoxModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxModel.Location = new Point(labelModel.Right, labelModel.Top);
            textBoxModel.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxModel.MaxLength = 100;
            // 
            // labelManufacturer
            // 
            labelManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Location = new Point(MARGIN, labelModel.Bottom + HEIGHT_INTERVAL);
            labelManufacturer.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManufacturer.Text = "Manufacturer:";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxManufacturer
            // 
            textBoxManufacturer.BackColor = Color.White;
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Location = new Point(labelManufacturer.Right, textBoxModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxManufacturer.MaxLength = 100;
            // 
            // labelAmount
            // 
            labelAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAmount.Location = new Point(MARGIN, labelManufacturer.Bottom + HEIGHT_INTERVAL);
            labelAmount.RightToLeft = RightToLeft.No;
            labelAmount.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAmount.Text = "Amount:";
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxAmount
            // 
            textBoxAmount.BackColor = Color.White;
            textBoxAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAmount.Location = new Point(labelAmount.Right, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxAmount.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxAmount.MaxLength = 9;
            textBoxAmount.Text = "1";
            // 
            // labelMaintFreq
            // 
            labelMaintFreq.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaintFreq.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaintFreq.Location = new Point(textBoxPartNo.Right + WIDTH_INTERVAL, MARGIN);
            labelMaintFreq.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMaintFreq.Text = "Maint. Freq.:";
            labelMaintFreq.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioButtonConditionMonitoring
            // 
            radioButtonConditionMonitoring.Cursor = Cursors.Hand;
            radioButtonConditionMonitoring.FlatStyle = FlatStyle.Flat;
            radioButtonConditionMonitoring.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonConditionMonitoring.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonConditionMonitoring.Location = new Point(labelMaintFreq.Right, MARGIN);
            radioButtonConditionMonitoring.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            radioButtonConditionMonitoring.Text = "Condition Monitoring";
            radioButtonConditionMonitoring.TabStop = true;
            // 
            // radioButtonUnknown
            // 
            radioButtonUnknown.Cursor = Cursors.Hand;
            radioButtonUnknown.FlatStyle = FlatStyle.Flat;
            radioButtonUnknown.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonUnknown.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonUnknown.Location = new Point(radioButtonConditionMonitoring.Right, MARGIN);
            radioButtonUnknown.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            radioButtonUnknown.Text = "Unknown";
            radioButtonUnknown.TabStop = true;
            radioButtonUnknown.Checked = true;
            // 
            // radioButtonHardTime
            // 
            radioButtonHardTime.Cursor = Cursors.Hand;
            radioButtonHardTime.FlatStyle = FlatStyle.Flat;
            radioButtonHardTime.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonHardTime.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonHardTime.Location = new Point(labelMaintFreq.Right, radioButtonConditionMonitoring.Bottom + HEIGHT_INTERVAL);
            radioButtonHardTime.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            radioButtonHardTime.Text = "Hard Time";
            radioButtonHardTime.TabStop = true;
            // 
            // radioButtonOnCondition
            // 
            radioButtonOnCondition.Cursor = Cursors.Hand;
            radioButtonOnCondition.FlatStyle = FlatStyle.Flat;
            radioButtonOnCondition.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
            radioButtonOnCondition.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonOnCondition.Location = new Point(radioButtonHardTime.Right, radioButtonUnknown.Bottom + HEIGHT_INTERVAL);
            radioButtonOnCondition.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            radioButtonOnCondition.Text = "On Condition";
            radioButtonOnCondition.TabStop = true;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(textBoxPartNo.Right + WIDTH_INTERVAL, radioButtonHardTime.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Location = new Point(labelRemarks.Right, radioButtonHardTime.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Size = new Size(3 * TEXTBOX_WIDTH / 2 + 10, 4 * LABEL_HEIGHT + 3 * HEIGHT_INTERVAL);
            //textBoxRemarks.MaxLength = 400;
            // 
            // checkBoxHoursApplicable
            // 
            checkBoxHoursApplicable.Cursor = Cursors.Hand;
            checkBoxHoursApplicable.FlatStyle = FlatStyle.Flat;
            checkBoxHoursApplicable.Font = Css.SimpleLink.Fonts.Font;
            checkBoxHoursApplicable.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxHoursApplicable.Location = new Point(textBoxDescription.Right + WIDTH_INTERVAL, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            checkBoxHoursApplicable.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxHoursApplicable.Text = "Hours Applicability";
            // 
            // checkBoxCyclesApplicable
            // 
            checkBoxCyclesApplicable.Cursor = Cursors.Hand;
            checkBoxCyclesApplicable.FlatStyle = FlatStyle.Flat;
            checkBoxCyclesApplicable.Font = Css.SimpleLink.Fonts.Font;
            checkBoxCyclesApplicable.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxCyclesApplicable.Location = new Point(textBoxDescription.Right + WIDTH_INTERVAL, checkBoxHoursApplicable.Bottom + HEIGHT_INTERVAL);
            checkBoxCyclesApplicable.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxCyclesApplicable.Text = "Cycles Applicability";
            // 
            // checkBoxCalendarApplicable
            // 
            checkBoxCalendarApplicable.Cursor = Cursors.Hand;
            checkBoxCalendarApplicable.FlatStyle = FlatStyle.Flat;
            checkBoxCalendarApplicable.Font = Css.SimpleLink.Fonts.Font;
            checkBoxCalendarApplicable.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxCalendarApplicable.Location = new Point(textBoxManufacturer.Right + WIDTH_INTERVAL, checkBoxCyclesApplicable.Bottom + HEIGHT_INTERVAL);
            checkBoxCalendarApplicable.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxCalendarApplicable.Text = "Calendar Applicability";
            // 
            // DetailGeneralInformationControl
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(WIDTH, HEIGHT);
            Controls.Add(labelPartNo);
            Controls.Add(textBoxPartNo);
            Controls.Add(labelAtaChapter);
            Controls.Add(comboBoxAtaChapter);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            if (currentDetail is TemplateGearAssembly)
            {
                Controls.Add(labelPosition);
                Controls.Add(panelLandingGearMark);
            }
            Controls.Add(labelModel);
            Controls.Add(textBoxModel);
            Controls.Add(labelManufacturer);
            Controls.Add(textBoxManufacturer);
            Controls.Add(labelAmount);
            Controls.Add(textBoxAmount);
            Controls.Add(labelMaintFreq);
            Controls.Add(radioButtonConditionMonitoring);
            Controls.Add(radioButtonUnknown);
            Controls.Add(radioButtonHardTime);
            Controls.Add(radioButtonOnCondition);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(checkBoxHoursApplicable);
            Controls.Add(checkBoxCyclesApplicable);
            Controls.Add(checkBoxCalendarApplicable);

            maintenanceCollection = MaintenanceTypeCollection.Instance;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return GetChangeStatus(currentDetail);
        }

        #endregion

        #region public bool GetChangeStatus(TemplateAbstractDetail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus(TemplateAbstractDetail detail)
        {
            if (detail is TemplateDetail)
            {
                TemplateDetail det = (TemplateDetail)detail;
                if (ATAChapter != det.AtaChapter) return true;
            }
            return ((PartNumber != detail.PartNumber) ||
                    (Description != detail.Description) ||
                    (detail is TemplateGearAssembly ? LandingGearMark != ((TemplateGearAssembly)detail).LandingGearMark : false) ||
                    (MaintenanceType != detail.MaintenanceType) ||
                    (Model != detail.Model) ||
                    (Manufacturer != detail.Manufacturer) ||
                    (Amount != detail.Amount.ToString()) ||
                    (Remarks != detail.Remarks) ||
                    (HoursApplicable != detail.Lifelength.IsHoursApplicable) ||
                    (CyclesApplicable != detail.Lifelength.IsCyclesApplicable) ||
                    (CalendarApplicable != detail.Lifelength.IsCalendarApplicable));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования шаблонного агрегата
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail != null)
                UpdateInformation(currentDetail);
        }

        #endregion

        #region public void UpdateInformation(TemplateAbstractDetail detail)

        /// <summary>
        /// Заполняет поля для редактирования шаблонного агрегата
        /// </summary>
        public void UpdateInformation(TemplateAbstractDetail detail)
        {
            if (detail == null) throw new ArgumentNullException("detail");

            PartNumber = detail.PartNumber;
            if (detail is TemplateDetail)
            {
                TemplateDetail dt = (TemplateDetail)detail;
                ATAChapter = dt.AtaChapter;
            }
            Description = detail.Description;
            MaintenanceType = detail.MaintenanceType;
            Model = detail.Model;
            Manufacturer = detail.Manufacturer;
            Amount = detail.Amount.ToString();
            Remarks = detail.Remarks;
            HoursApplicable = detail.Lifelength.IsHoursApplicable;
            CyclesApplicable = detail.Lifelength.IsCyclesApplicable;
            CalendarApplicable = detail.Lifelength.IsCalendarApplicable;

            bool permission = (detail.HasPermission(Users.CurrentUser, DataEvent.Update));

            textBoxPartNo.ReadOnly = !permission;
            if ((currentDetail is TemplateDetail) && permission)
                comboBoxAtaChapter.Enabled = true;
            else
                comboBoxAtaChapter.Enabled = false;
            textBoxDescription.ReadOnly = !permission;
            if (detail is TemplateGearAssembly)
                LandingGearMark = ((TemplateGearAssembly)detail).LandingGearMark;
            textBoxModel.ReadOnly = !permission;
            textBoxManufacturer.ReadOnly = !permission;
            radioButtonConditionMonitoring.Enabled = permission;
            radioButtonHardTime.Enabled = permission;
            radioButtonOnCondition.Enabled = permission;
            radioButtonUnknown.Enabled = permission;
            textBoxAmount.ReadOnly = !permission;
            textBoxRemarks.ReadOnly = !permission;
            checkBoxCalendarApplicable.Enabled = permission;
            checkBoxCyclesApplicable.Enabled = permission;
            checkBoxHoursApplicable.Enabled = permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentDetail != null)
                SaveData(currentDetail, true);
        }

        #endregion

        #region public void SaveData(TemplateAbstractDetail detail, bool changePageName)

        /// <summary>
        /// Сохранаяет данные заданного шаблонного агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void SaveData(TemplateAbstractDetail detail, bool changePageName)
        {
            if (detail == null) 
                throw new ArgumentNullException("detail");
            int amount;
            CheckAmount(out amount);
            if (textBoxPartNo.Text != detail.PartNumber)
            {
                detail.PartNumber = textBoxPartNo.Text;
                if (changePageName)
                {
                    string caption;
                    if (detail is TemplateBaseDetail)
                    {
                        caption = ((TemplateBaseDetail)detail).ParentAircraft.Model + ". Component PN " + detail.PartNumber;
                    }
                    else
                    {
                        if (detail.Parent != null)
                            caption = ((TemplateAircraft)detail.Parent.Parent).Model+ ". Component PN " + detail.PartNumber;
                        else
                            caption = "Component PN " + detail.PartNumber;
                    }
                    if (DisplayerRequested != null)
                        DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
                }
            }
            if (detail is TemplateDetail)
            {
                TemplateDetail det = (TemplateDetail)detail;
                det.AtaChapter = ATAChapter;
            }
            if (textBoxDescription.Text != detail.Description)
                detail.Description = textBoxDescription.Text;
            if (detail is TemplateGearAssembly)
            {
                TemplateGearAssembly gearAssembly = (TemplateGearAssembly)detail;
                if (gearAssembly.LandingGearMark != LandingGearMark)
                    gearAssembly.LandingGearMark = LandingGearMark;
            }
            if (textBoxModel.Text != detail.Model)
                detail.Model = textBoxModel.Text;
            if (textBoxManufacturer.Text != detail.Manufacturer)
                detail.Manufacturer = textBoxManufacturer.Text;
            if (MaintenanceType != detail.MaintenanceType)
                detail.MaintenanceType = MaintenanceType;
            if (textBoxAmount.Text != detail.Amount.ToString())
                detail.Amount = amount;
            if (textBoxRemarks.Text != detail.Remarks)
                detail.Remarks = textBoxRemarks.Text;
            if (checkBoxHoursApplicable.Checked != detail.Lifelength.IsHoursApplicable)
                detail.Lifelength.IsHoursApplicable = checkBoxHoursApplicable.Checked;
            if (checkBoxCyclesApplicable.Checked != detail.Lifelength.IsCyclesApplicable)
                detail.Lifelength.IsCyclesApplicable = checkBoxCyclesApplicable.Checked;
            if (checkBoxCalendarApplicable.Checked != detail.Lifelength.IsCalendarApplicable)
                detail.Lifelength.IsCalendarApplicable = checkBoxCalendarApplicable.Checked;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearAllFields()
        {
            comboBoxAtaChapter.ClearValue();
            PartNumber = "";
            Description = "";
            radioButtonLLG.Checked = false;
            radioButtonNLG.Checked = false;
            radioButtonRLG.Checked = false;
            MaintenanceType = maintenanceCollection.UnknownType;
            Model = "";
            Manufacturer = "";
            Remarks = "";
            HoursApplicable = false;
            CyclesApplicable = false;
            CalendarApplicable = false;
        }

        #endregion

        #region public bool CheckAmount(out int amount)

        ///<summary>
        /// Проверяет значение Amount
        ///</summary>
        /// <param name="amount">Значение Amount</param>
        ///<returns>Возвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckAmount(out int amount)
        {
            if (!int.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show("Amount. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }
}