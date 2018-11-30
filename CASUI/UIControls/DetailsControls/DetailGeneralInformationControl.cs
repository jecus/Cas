using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Exceptions;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.UIControls.DetailsControls
{

    ///<summary>
    /// Отображает информацию об агрегате
    ///</summary>
    public class DetailGeneralInformationControl : UserControl, IReference
    {

        #region Fields

        private AbstractDetail currentDetail;

        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int LABEL_HEIGHT = 25;
        private const int BIG_LABEL_HEIGHT = 30;
        private const int LABEL_WIDTH = 100;
        private const int CAPTION_WIDTH = 200;
        private const int TEXTBOX_WIDTH = 250;
        private const int RADIO_BUTTON_WIDTH = 100;
        private const int WIDTH_INTERVAL = 400 + MARGIN;
        private const int WIDTH_INTERVAL_SECOND = 800 + MARGIN;
        private MaintenanceTypeCollection maintenanceCollection;
  
        private Label labelAtaChapter;
        private Label labelDescription;
        private Label labelMaintFreq;
        private Label labelManufacturer;
        private Label labelModel;
        private Label labelPartNo;
        private Label labelPosition;
        private Label labelManHours;
        private Label labelCost;
        private Label labelKitRequired;
        private Label labelRemarks;
        private Label labelHiddenRemarks;
        private Label labelSerialNo;
        private Label labelMPDItem;
        private Label labelManufactureDate;
        private Label labelInstallationDate;
        private Label labelSupplier;
        private Label labelMaxTakeOffWeight;
        private CheckBox checkBoxAvionicsInventory;
        private Label labelHushKit;
        private Label labelALTPN;
        private CheckBox checkBoxLifeLimit;
        private LifelengthViewer lifelengthViewerLifeLimit;
        private Label labelCurrentTSNCSN;
        private LifelengthViewer lifelengthCurrentTSNCSN;
        private Label labelRemains;
        private LifelengthViewer lifelengthRemains;
        private Label labelNotify;
        private LifelengthViewer lifelengthNotify;
        private LinkLabel linkLabelJobCard;

        private TextBox textBoxALTPN;
        private TextBox textBoxHushKit;
        private Panel panelAvionicsInventory;
        private RadioButton radioButtonInventoryOptional;
        private RadioButton radioButtonInventoryRequired;
        private RadioButton radioButtonAvionicsInventoryUnknown;
        private ATAChapterComboBox comboBoxAtaChapter;
        private RadioButton radioButtonConditionMonitoring;
        private RadioButton radioButtonHardTime;
        private RadioButton radioButtonOnCondition;
        private RadioButton radioButtonUnknown;
        private TextBox textBoxDescription;
        private TextBox textBoxManufacturer;
        private TextBox textBoxModel;
        private TextBox textBoxPartNo;
        private TextBox textBoxPosition;
        private Panel panelLandingGearMark;
        private RadioButton radioButtonLLG;
        private RadioButton radioButtonNLG;
        private RadioButton radioButtonRLG;
        private TextBox textBoxManHours;
        private TextBox textBoxCost;
        private TextBox textBoxKitRequired;
        private TextBox textBoxRemarks;
        private TextBox textBoxHiddenRemarks;
        private TextBox textBoxSerialNo;
        private TextBox textBoxMPDItem;
        private TextBox textBoxMaxTakeOffWeight;
        private DateTimePicker dateTimePickerManufactureDate;
        private DateTimePicker dateTimePickerInstallationDate;
        private TextBox textBoxSupplier;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructors

        #region public DetailGeneralInformationControl()

        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        public DetailGeneralInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailGeneralInformationControl(AbstractDetail currentDetail)

        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        /// <param name="currentDetail">Агрегат</param>
        public DetailGeneralInformationControl(AbstractDetail currentDetail)
        {
            if (null == currentDetail) 
                throw new ArgumentNullException("currentDetail", "Argument cannot be null");
            this.currentDetail = currentDetail;
            InitializeComponent();
            //UpdateInformation();
        }

        #endregion
        
        #endregion

        #region Propeties

        #region public AbstractDetail CurrentDetail

        /// <summary>
        /// Задает или возвращает отображаемый агрегат
        /// </summary>
        public AbstractDetail CurrentDetail
        {
            get { return currentDetail; }
            set
            {
                currentDetail = value;
                if (value != null) UpdateInformation();
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

        #region public string SerialNumber

        /// <summary>
        /// Отображаемый  SerialNumber
        /// </summary>
        public string SerialNumber
        {
            get { return textBoxSerialNo.Text; }
            set
            {
                textBoxSerialNo.Text = value;
            }
        }

        #endregion

        #region public string MPDItem

        /// <summary>
        /// Отображаемое значение MPD Item
        /// </summary>
        public string MPDItem
        {
            get { return textBoxMPDItem.Text; }
            set
            {
                textBoxMPDItem.Text = value;
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

        #region public string Position

        /// <summary>
        /// Отображаемое положение 
        /// </summary>
        public string Position
        {
            get { return textBoxPosition.Text; }
            set
            {
                textBoxPosition.Text = value;
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

        #region public DateTime ManufactureDate

        /// <summary>
        /// Отображаемая дата производства
        /// </summary>
        public DateTime ManufactureDate
        {
            get { return dateTimePickerManufactureDate.Value; }
            set
            {
                dateTimePickerManufactureDate.Value = value;
            }
        }

        #endregion

        #region public DateTime InstallationDate

        /// <summary>
        /// Возвращает или устанавливает дату установки агрегата
        /// </summary>
        public DateTime InstallationDate
        {
            get { return dateTimePickerInstallationDate.Value; }
            set
            {
                dateTimePickerInstallationDate.Value = value;
            }
        }

        #endregion

        #region public string Supplier

        /// <summary>
        /// Отображаемый поставщик
        /// </summary>
        public string Supplier
        {
            get { return textBoxSupplier.Text; }
            set
            {
                textBoxSupplier.Text = value;
            }
        }

        #endregion

        #region public string MaxTakeOffWeight

        /// <summary>
        /// Отображаемый максимальный вес
        /// </summary>
        public string MaxTakeOffWeight
        {
            get { return textBoxMaxTakeOffWeight.Text; }
            set
            {
                textBoxMaxTakeOffWeight.Text = value;
            }
        }

        #endregion

        #region public bool AvionicsInventoryMark

        /// <summary>
        /// Avionics Inventory
        /// </summary>
        public bool AvionicsInventoryMark
        {
            get { return checkBoxAvionicsInventory.Checked; }
            set
            {
                checkBoxAvionicsInventory.Checked = value;
                radioButtonInventoryRequired.Enabled = value;
                radioButtonInventoryOptional.Enabled = value;
                radioButtonAvionicsInventoryUnknown.Enabled = value;
            }
        }

        #endregion

        #region public AvionicsInventoryMarkType AvionicsInventoryMarkType

        /// <summary>
        /// Тип Avionics Inventory
        /// </summary>
        public AvionicsInventoryMarkType AvionicsInventoryMarkType
        {
            get
            {
                if (!AvionicsInventoryMark)
                    return AvionicsInventoryMarkType.None;
                if (radioButtonInventoryOptional.Checked) 
                    return AvionicsInventoryMarkType.Optional;
                if (radioButtonInventoryRequired.Checked) 
                    return AvionicsInventoryMarkType.Required;
                return AvionicsInventoryMarkType.Unknown;
            }
            set
            {
                if (value == AvionicsInventoryMarkType.Required)
                    radioButtonInventoryRequired.Checked = true;
                else if (value == AvionicsInventoryMarkType.Optional)
                    radioButtonInventoryOptional.Checked = true;
                else
                    radioButtonAvionicsInventoryUnknown.Checked = true;
                
            }
        }

        #endregion

        #region public string ALTPN

        /// <summary>
        /// ALT P/N
        /// </summary>
        public string ALTPN
        {
            get
            {
                return textBoxALTPN.Text;
            }
            set
            {
                textBoxALTPN.Text = value;
            }
        }

        #endregion

        #region public string HusKit

        ///<summary>
        /// Hush Kit
        ///</summary>
        public string HusKit
        {
            get
            {
                return textBoxHushKit.Text;
            }
            set
            {
                textBoxHushKit.Text = value;
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

        #region public double Manhours

        /// <summary>
        /// Manhours текущего агрегата
        /// </summary>
        public double Manhours
        {
            get
            {
                double d;
                double.TryParse(textBoxManHours.Text, out d);
                return d;
            }
            set
            {
                currentDetail.ManHours = value;
                textBoxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string ManhoursString

        /// <summary>
        /// Manhours текущего агрегата
        /// </summary>
        public string ManhoursString
        {
            get
            {
                return textBoxManHours.Text;
            }
            set
            {
                textBoxManHours.Text = value;
            }
        }

        #endregion

        #region public double Cost

        /// <summary>
        /// Cost текущего агрегата
        /// </summary>
        public double Cost
        {
            get
            {
                double d;
                double.TryParse(textBoxCost.Text, out d);
                return d;
            }
            set
            {
                currentDetail.Cost = value;
                textBoxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string CostString

        /// <summary>
        /// Cost текущего агрегата
        /// </summary>
        public string CostString
        {
            get
            {
                return textBoxCost.Text;
            }
            set
            {
                textBoxCost.Text = value;
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

        #region public string HiddenRemarks

        /// <summary>
        /// Отображаемые замечания
        /// </summary>
        public string HiddenRemarks
        {
            get { return textBoxHiddenRemarks.Text; }
            set
            {
                textBoxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #region public bool LifeLimitEnabled
        /// <summary>
        /// Актуально ли ограничения срока службы агрегата
        /// </summary>
        public bool LifeLimitEnabled
        {
            get { return checkBoxLifeLimit.Checked; }
        }

        #endregion

        #region public Lifelength LifeLimit
        /// <summary>
        /// Ограничения срока службы агрегата
        /// </summary>
        public Lifelength LifeLimit
        {
            get { return lifelengthViewerLifeLimit.Lifelength; }
        }

        #endregion

        #region public Lifelength LifeLimitNotify
        /// <summary>
        /// После приближения текущей наработки к данной систему уведомляет пользователя о подходе к ограничению срока службы <see cref="lifeLimit"/>
        /// </summary>
        public Lifelength LifeLimitNotify
        {
            get
            {
                return lifelengthNotify.Lifelength;
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

        /// <summary>
        /// Инициализирует элементы управления
        /// </summary>
        public void InitializeComponent()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            labelPosition = new Label();
            labelModel = new Label();
            labelManufacturer = new Label();
            labelManHours = new Label();
            labelCost = new Label();
            labelKitRequired = new Label();
            labelRemarks = new Label();
            labelHiddenRemarks = new Label();
            comboBoxAtaChapter = new ATAChapterComboBox();
            labelPartNo = new Label();
            textBoxDescription = new TextBox();
            labelSerialNo = new Label();
            labelMPDItem = new Label();
            textBoxSerialNo = new TextBox();
            textBoxMPDItem = new TextBox();
            labelManufactureDate = new Label();
            labelInstallationDate = new Label();
            labelSupplier = new Label();
            radioButtonConditionMonitoring = new RadioButton();
            radioButtonUnknown = new RadioButton();
            radioButtonHardTime = new RadioButton();
            radioButtonOnCondition = new RadioButton();
            labelAtaChapter = new Label();
            textBoxPartNo = new TextBox();
            labelMaintFreq = new Label();
            labelDescription = new Label();
            labelMaxTakeOffWeight = new Label();
            textBoxMaxTakeOffWeight = new TextBox();
            checkBoxAvionicsInventory = new CheckBox();
            panelAvionicsInventory = new Panel();
            radioButtonInventoryOptional = new RadioButton();
            radioButtonInventoryRequired = new RadioButton();
            radioButtonAvionicsInventoryUnknown = new RadioButton();
            textBoxALTPN = new TextBox();
            textBoxHushKit = new TextBox();
            labelALTPN = new Label();
            labelHushKit = new Label();
            linkLabelJobCard = new LinkLabel();
            dateTimePickerManufactureDate = new DateTimePicker();
            dateTimePickerInstallationDate = new DateTimePicker();
            textBoxSupplier = new TextBox();
            textBoxManHours = new TextBox();
            textBoxCost = new TextBox();
            textBoxKitRequired = new TextBox();
            textBoxRemarks = new TextBox();
            textBoxHiddenRemarks = new TextBox();
            textBoxManufacturer = new TextBox();
            textBoxModel = new TextBox();
            textBoxPosition = new TextBox();
            panelLandingGearMark = new Panel();
            radioButtonLLG = new RadioButton();
            radioButtonNLG = new RadioButton();
            radioButtonRLG = new RadioButton();
            checkBoxLifeLimit = new CheckBox();
            lifelengthViewerLifeLimit = new LifelengthViewer();
            labelCurrentTSNCSN = new Label();
            lifelengthCurrentTSNCSN = new LifelengthViewer();
            labelRemains = new Label();
            lifelengthRemains = new LifelengthViewer();
            labelNotify = new Label();
            lifelengthNotify = new LifelengthViewer();
            // 
            // labelPartNo
            // 
            labelPartNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPartNo.Location = new Point(MARGIN, MARGIN);
            labelPartNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPartNo.Text = "Part No:";
            labelPartNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNo
            // 
            textBoxPartNo.BackColor = Color.White;
            textBoxPartNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPartNo.Location = new Point(labelPartNo.Right, MARGIN);
            textBoxPartNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxPartNo.Text = "";
            textBoxPartNo.MaxLength = 100;
            // 
            // labelSerialNo
            // 
            labelSerialNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelSerialNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNo.Location = new Point(MARGIN, textBoxPartNo.Bottom + HEIGHT_INTERVAL);
            labelSerialNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSerialNo.Text = "Serial No:";
            labelSerialNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxSerialNo
            // 
            textBoxSerialNo.BackColor = Color.White;
            textBoxSerialNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxSerialNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNo.Location = new Point(labelSerialNo.Right, textBoxPartNo.Bottom + HEIGHT_INTERVAL);
            textBoxSerialNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxSerialNo.MaxLength = 100;
            // 
            // labelMPDItem
            // 
            labelMPDItem.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelMPDItem.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMPDItem.Location = new Point(MARGIN, textBoxSerialNo.Bottom + HEIGHT_INTERVAL);
            labelMPDItem.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMPDItem.Text = "MPD Item:";
            labelMPDItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMPDItem
            // 
            textBoxMPDItem.BackColor = Color.White;
            textBoxMPDItem.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxMPDItem.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMPDItem.Location = new Point(labelMPDItem.Right, textBoxSerialNo.Bottom + HEIGHT_INTERVAL);
            textBoxMPDItem.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxMPDItem.MaxLength = 50;
            // 
            // labelAtaChapter
            // 
            labelAtaChapter.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAtaChapter.Location = new Point(MARGIN, textBoxMPDItem.Bottom + HEIGHT_INTERVAL);
            labelAtaChapter.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAtaChapter.Text = "ATA Chapter:";
            labelAtaChapter.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxAtaChapter
            // 
            comboBoxAtaChapter.BackColor = Color.White;
            comboBoxAtaChapter.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxAtaChapter.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            comboBoxAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxAtaChapter.FormattingEnabled = true; //todo че за?
            comboBoxAtaChapter.Location = new Point(labelAtaChapter.Right, textBoxMPDItem.Bottom + HEIGHT_INTERVAL);
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, comboBoxAtaChapter.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxDescription.Location = new Point(labelDescription.Right, comboBoxAtaChapter.Bottom + HEIGHT_INTERVAL);
            textBoxDescription.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxDescription.MaxLength = 250;
            // 
            // labelPosition
            // 
            labelPosition.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPosition.Location = new Point(MARGIN, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            labelPosition.RightToLeft = RightToLeft.No;
            labelPosition.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPosition.Text = "Position:";
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPosition
            // 
            textBoxPosition.BackColor = Color.White;
            textBoxPosition.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPosition.Location = new Point(labelPosition.Right, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            textBoxPosition.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxPosition.ReadOnly = true;
            textBoxPosition.Enabled=false;
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
            radioButtonLLG.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonLLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonLLG.Size = new Size(TEXTBOX_WIDTH/3, LABEL_HEIGHT);
            radioButtonLLG.Text = "Left";
            // 
            // radioButtonNLG
            // 
            radioButtonNLG.Cursor = Cursors.Hand;
            radioButtonNLG.FlatStyle = FlatStyle.Flat;
            radioButtonNLG.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonNLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonNLG.Location = new Point(radioButtonLLG.Right, 0);
            radioButtonNLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonNLG.Text = "Nose";
            // 
            // radioButtonRLG
            // 
            radioButtonRLG.Cursor = Cursors.Hand;
            radioButtonRLG.FlatStyle = FlatStyle.Flat;
            radioButtonRLG.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonRLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonRLG.Location = new Point(radioButtonNLG.Right, 0);
            radioButtonRLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonRLG.Text = "Right";
            // 
            // labelModel
            // 
            labelModel.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelModel.Location = new Point(MARGIN, textBoxPosition.Bottom + HEIGHT_INTERVAL);
            labelModel.RightToLeft = RightToLeft.No;
            labelModel.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelModel.Text = "Model:";
            labelModel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxModel
            // 
            textBoxModel.BackColor = Color.White;
            textBoxModel.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxModel.Location = new Point(labelModel.Right, textBoxPosition.Bottom + HEIGHT_INTERVAL);
            textBoxModel.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxModel.MaxLength = 100;
            // 
            // labelManufacturer
            // 
            labelManufacturer.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Location = new Point(MARGIN, textBoxModel.Bottom + HEIGHT_INTERVAL);
            labelManufacturer.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManufacturer.Text = "Manufacturer:";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxManufacturer
            // 
            textBoxManufacturer.BackColor = Color.White;
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Location = new Point(labelManufacturer.Right, textBoxModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxManufacturer.MaxLength = 100;
            // 
            // labelManufactureDate
            // 
            labelManufactureDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelManufactureDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufactureDate.Location = new Point(MARGIN, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            labelManufactureDate.Size = new Size(LABEL_WIDTH, BIG_LABEL_HEIGHT);
            labelManufactureDate.Text = "Manufacture Date:";
            labelManufactureDate.TextAlign = ContentAlignment.TopLeft;
            // 
            // dateTimePickerManufactureDate       
            // 
            dateTimePickerManufactureDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerManufactureDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerManufactureDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerManufactureDate.Location = new Point(labelManufactureDate.Right, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            dateTimePickerManufactureDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerManufactureDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerManufactureDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            // 
            // labelInstallationDate
            // 
            labelInstallationDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelInstallationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInstallationDate.Location = new Point(MARGIN, dateTimePickerManufactureDate.Bottom + HEIGHT_INTERVAL);
            labelInstallationDate.RightToLeft = RightToLeft.No;
            labelInstallationDate.Size = new Size(LABEL_WIDTH, BIG_LABEL_HEIGHT);
            labelInstallationDate.Text = "Installation Date:";
            labelInstallationDate.TextAlign = ContentAlignment.TopLeft;
            // 
            // dateTimePickerInstallationDate       
            // 
            dateTimePickerInstallationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerInstallationDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerInstallationDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerInstallationDate.Location = new Point(labelInstallationDate.Right, dateTimePickerManufactureDate.Bottom + HEIGHT_INTERVAL);
            dateTimePickerInstallationDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerInstallationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerInstallationDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerInstallationDate.Enabled = false;
            // 
            // labelSupplier
            // 
            labelSupplier.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelSupplier.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSupplier.Location = new Point(MARGIN, dateTimePickerInstallationDate.Bottom + HEIGHT_INTERVAL);
            labelSupplier.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSupplier.Text = "Supplier:";
            labelSupplier.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxSupplier
            // 
            textBoxSupplier.BackColor = Color.White;
            textBoxSupplier.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxSupplier.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSupplier.Location = new Point(labelSupplier.Right, dateTimePickerInstallationDate.Bottom + HEIGHT_INTERVAL);
            textBoxSupplier.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxSupplier.MaxLength = 50;
            // 
            // checkBoxAvionicsInventory
            // 
            checkBoxAvionicsInventory.Cursor = Cursors.Hand;
            checkBoxAvionicsInventory.FlatStyle = FlatStyle.Flat;
            checkBoxAvionicsInventory.Font = Css.SimpleLink.Fonts.SmallFont;
            checkBoxAvionicsInventory.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxAvionicsInventory.Location = new Point(MARGIN, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            checkBoxAvionicsInventory.Size = new Size(LABEL_WIDTH, BIG_LABEL_HEIGHT+5);
            checkBoxAvionicsInventory.Text = "Avionics Inventory";
            checkBoxAvionicsInventory.CheckedChanged += checkBoxAvionicsInventoryMark_CheckedChanged;
            //
            // panelLandingGearMark
            //
            panelAvionicsInventory.AutoSize = true;
            panelAvionicsInventory.Height = LABEL_HEIGHT;
            panelAvionicsInventory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelAvionicsInventory.Location = new Point(checkBoxAvionicsInventory.Right, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            panelAvionicsInventory.Controls.Add(radioButtonInventoryOptional);
            panelAvionicsInventory.Controls.Add(radioButtonInventoryRequired);
            panelAvionicsInventory.Controls.Add(radioButtonAvionicsInventoryUnknown);
            // 
            // radioButtonInventoryOptional
            // 
            radioButtonInventoryOptional.Cursor = Cursors.Hand;
            radioButtonInventoryOptional.Enabled = false;
            radioButtonInventoryOptional.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryOptional.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            radioButtonInventoryOptional.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryOptional.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonInventoryOptional.Text = "Optional";
            // 
            // radioButtonInventoryRequired
            // 
            radioButtonInventoryRequired.Cursor = Cursors.Hand;
            radioButtonInventoryRequired.Enabled = false;
            radioButtonInventoryRequired.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryRequired.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            radioButtonInventoryRequired.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryRequired.Location = new Point(radioButtonInventoryOptional.Right, 0);
            radioButtonInventoryRequired.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonInventoryRequired.Text = "Required";
            // 
            // radioButtonAvionicsInventoryUnknown
            // 
            radioButtonAvionicsInventoryUnknown.Cursor = Cursors.Hand;
            radioButtonAvionicsInventoryUnknown.Enabled = false;
            radioButtonAvionicsInventoryUnknown.FlatStyle = FlatStyle.Flat;
            radioButtonAvionicsInventoryUnknown.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            radioButtonAvionicsInventoryUnknown.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonAvionicsInventoryUnknown.Location = new Point(radioButtonInventoryRequired.Right, 0);
            radioButtonAvionicsInventoryUnknown.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonAvionicsInventoryUnknown.Text = "Unknown";
            // 
            // labelALTPN
            // 
            labelALTPN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelALTPN.Location = new Point(MARGIN, panelAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            labelALTPN.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelALTPN.Text = "ALT P/N:";
            // 
            // textBoxALTPN
            // 
            textBoxALTPN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxALTPN.Location = new Point(labelALTPN.Right, panelAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            textBoxALTPN.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxALTPN.MaxLength = 200;
            // 
            // linkLabelJobCard
            // 
            linkLabelJobCard.Font = Css.SimpleLink.Fonts.SmallFont;
            linkLabelJobCard.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelJobCard.Text = "Remove/Replace Job Card";
            linkLabelJobCard.LinkClicked += linkLabelJobCard_LinkClicked;
            linkLabelJobCard.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, LABEL_HEIGHT);
            linkLabelJobCard.Location = new Point(MARGIN, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            // 
            // labelHushKit
            // 
            labelHushKit.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHushKit.Location = new Point(MARGIN, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            labelHushKit.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHushKit.Text = "Hush Kit Equipped:";
            // 
            // textBoxHushKit
            // 
            textBoxHushKit.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHushKit.Location = new Point(labelHushKit.Right, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            textBoxHushKit.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxHushKit.MaxLength = 200;
            // 
            // labelMaxTakeOffWeight
            // 
            labelMaxTakeOffWeight.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelMaxTakeOffWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaxTakeOffWeight.Location = new Point(MARGIN, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            labelMaxTakeOffWeight.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMaxTakeOffWeight.Text = "Max Take Off Weight:";
            labelMaxTakeOffWeight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMaxTakeOffWeight
            // 
            textBoxMaxTakeOffWeight.BackColor = Color.White;
            textBoxMaxTakeOffWeight.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxMaxTakeOffWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMaxTakeOffWeight.Location = new Point(labelMaxTakeOffWeight.Right, textBoxSupplier.Bottom + HEIGHT_INTERVAL);
            textBoxMaxTakeOffWeight.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxMaxTakeOffWeight.MaxLength = 200;
            // 
            // labelMaintFreq
            // 
            labelMaintFreq.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelMaintFreq.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaintFreq.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelMaintFreq.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMaintFreq.Text = "Maint. Freq.:";
            labelMaintFreq.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioButtonConditionMonitoring
            // 
            radioButtonConditionMonitoring.Cursor = Cursors.Hand;
            radioButtonConditionMonitoring.FlatStyle = FlatStyle.Flat;
            radioButtonConditionMonitoring.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonConditionMonitoring.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonConditionMonitoring.Location = new Point(labelMaintFreq.Right, MARGIN);
            radioButtonConditionMonitoring.Size = new Size(TEXTBOX_WIDTH /2, LABEL_HEIGHT*3/2);
            radioButtonConditionMonitoring.TextAlign = ContentAlignment.TopLeft;
            radioButtonConditionMonitoring.Text = "Condition Monitoring";
            // 
            // radioButtonUnknown
            // 
            radioButtonUnknown.Cursor = Cursors.Hand;
            radioButtonUnknown.FlatStyle = FlatStyle.Flat;
            radioButtonUnknown.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonUnknown.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonUnknown.Location = new Point(radioButtonConditionMonitoring.Right, MARGIN);
            radioButtonUnknown.Size = new Size(TEXTBOX_WIDTH / 2, LABEL_HEIGHT);
            radioButtonUnknown.Text = "Unknown";
            radioButtonUnknown.Checked = true;
            // 
            // radioButtonHardTime
            // 
            radioButtonHardTime.Cursor = Cursors.Hand;
            radioButtonHardTime.FlatStyle = FlatStyle.Flat;
            radioButtonHardTime.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonHardTime.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonHardTime.Location = new Point(labelMaintFreq.Right, radioButtonUnknown.Bottom + HEIGHT_INTERVAL);
            radioButtonHardTime.Size = new Size(TEXTBOX_WIDTH / 2, LABEL_HEIGHT);
            radioButtonHardTime.Text = "Hard Time";
            // 
            // radioButtonOnCondition
            // 
            radioButtonOnCondition.Cursor = Cursors.Hand;
            radioButtonOnCondition.FlatStyle = FlatStyle.Flat;
            radioButtonOnCondition.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonOnCondition.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonOnCondition.Location = new Point(radioButtonHardTime.Right, radioButtonUnknown.Bottom + HEIGHT_INTERVAL);
            radioButtonOnCondition.Size = new Size(TEXTBOX_WIDTH / 2, LABEL_HEIGHT);
            radioButtonOnCondition.Text = "On Condition";
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Location = new Point(WIDTH_INTERVAL, radioButtonHardTime.Bottom + HEIGHT_INTERVAL);
            labelManHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManHours.TextAlign = ContentAlignment.MiddleLeft;
            labelManHours.Text = "Man Hours:";
            // 
            // textBoxManHours
            // 
            textBoxManHours.BackColor = Color.White;
            textBoxManHours.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManHours.Location = new Point(labelManHours.Right, radioButtonHardTime.Bottom + HEIGHT_INTERVAL);
            textBoxManHours.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelCost
            // 
            labelCost.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCost.Location = new Point(WIDTH_INTERVAL, textBoxManHours.Bottom + HEIGHT_INTERVAL);
            labelCost.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCost.TextAlign = ContentAlignment.MiddleLeft;
            labelCost.Text = "Cost (USD):";
            // 
            // textBoxCost
            // 
            textBoxCost.BackColor = Color.White;
            textBoxCost.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCost.Location = new Point(labelCost.Right, textBoxManHours.Bottom + HEIGHT_INTERVAL);
            textBoxCost.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelKitRequired
            // 
            labelKitRequired.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelKitRequired.Location = new Point(WIDTH_INTERVAL, textBoxCost.Bottom + HEIGHT_INTERVAL);
            labelKitRequired.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelKitRequired.Text = "Kit Required:";
            labelKitRequired.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxKitRequired
            // 
            textBoxKitRequired.BackColor = Color.White;
            textBoxKitRequired.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxKitRequired.Location = new Point(labelKitRequired.Right, textBoxCost.Bottom + HEIGHT_INTERVAL);
            textBoxKitRequired.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(WIDTH_INTERVAL, textBoxKitRequired.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Location = new Point(labelRemarks.Right, textBoxKitRequired.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxRemarks.MaxLength = 340000;
            // 
            // labelHiddenRemarks
            // 
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Location = new Point(WIDTH_INTERVAL, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, BIG_LABEL_HEIGHT);
            labelHiddenRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelHiddenRemarks.Text = "Hidden Remarks:";
            // 
            // textBoxHiddenRemarks
            // 
            textBoxHiddenRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxHiddenRemarks.BackColor = Color.White;
            textBoxHiddenRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHiddenRemarks.Location = new Point(labelHiddenRemarks.Right, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            textBoxHiddenRemarks.Multiline = true;
            textBoxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxHiddenRemarks.MaxLength = 34000;
            // 
            // labelCurrentTSNCSN
            // 
            labelCurrentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelCurrentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCurrentTSNCSN.Location = new Point(WIDTH_INTERVAL_SECOND, MARGIN);
            labelCurrentTSNCSN.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelCurrentTSNCSN.Text = "Current TSN/CSN:";
            labelCurrentTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthCurrentTSNCSN
            //
            lifelengthCurrentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthCurrentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthCurrentTSNCSN.ShowLeftHeader = false;
            lifelengthCurrentTSNCSN.LeftHeaderWidth = 0;
            lifelengthCurrentTSNCSN.ShowMinutes = false;
            lifelengthCurrentTSNCSN.Location = new Point(WIDTH_INTERVAL_SECOND, labelCurrentTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthCurrentTSNCSN.ReadOnly = true;
            // 
            // checkBoxLifeLimit
            // 
            checkBoxLifeLimit.Cursor = Cursors.Hand;
            checkBoxLifeLimit.FlatStyle = FlatStyle.Flat;
            checkBoxLifeLimit.Font = Css.SimpleLink.Fonts.SmallFont;
            checkBoxLifeLimit.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxLifeLimit.Location = new Point(WIDTH_INTERVAL_SECOND, lifelengthCurrentTSNCSN.Bottom + HEIGHT_INTERVAL);
            checkBoxLifeLimit.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxLifeLimit.Text = "Life Limit";
            checkBoxLifeLimit.CheckedChanged += checkBoxLifeLimit_CheckedChanged;
            //
            // lifelengthViewerLifeLimit
            //
            lifelengthViewerLifeLimit.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerLifeLimit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerLifeLimit.ShowLeftHeader = false;
            lifelengthViewerLifeLimit.LeftHeaderWidth = 0;
            lifelengthViewerLifeLimit.ShowMinutes = false;
            lifelengthViewerLifeLimit.Location = new Point(WIDTH_INTERVAL_SECOND, checkBoxLifeLimit.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerLifeLimit.Enabled = false;
            // 
            // labelRemains
            // 
            labelRemains.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemains.Location = new Point(WIDTH_INTERVAL_SECOND, lifelengthViewerLifeLimit.Bottom + HEIGHT_INTERVAL);
            labelRemains.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelRemains.Text = "Remains:";
            labelRemains.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthRemains
            //
            lifelengthRemains.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthRemains.ShowLeftHeader = false;
            lifelengthRemains.LeftHeaderWidth = 0;
            lifelengthRemains.ShowMinutes = false;
            lifelengthRemains.Location = new Point(WIDTH_INTERVAL_SECOND, labelRemains.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthRemains.ReadOnly = true;
            // 
            // labelNotify
            // 
            labelNotify.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelNotify.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotify.Location = new Point(WIDTH_INTERVAL_SECOND, lifelengthRemains.Bottom + HEIGHT_INTERVAL);
            labelNotify.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelNotify.Text = "Notify:";
            labelNotify.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthNotify
            //
            lifelengthNotify.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthNotify.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthNotify.ShowLeftHeader = false;
            lifelengthNotify.LeftHeaderWidth = 0;
            lifelengthNotify.ShowMinutes = false;
            lifelengthNotify.Location = new Point(WIDTH_INTERVAL_SECOND, labelNotify.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            // 
            // DetailGeneralInformationControl
            //
            Controls.Add(labelPartNo);
            Controls.Add(labelSerialNo);
            Controls.Add(labelMPDItem);
            Controls.Add(labelAtaChapter);
            Controls.Add(labelDescription);
            Controls.Add(labelPosition);
            Controls.Add(labelModel);
            Controls.Add(labelManufacturer);
            Controls.Add(labelManufactureDate);
            Controls.Add(labelInstallationDate);
            Controls.Add(labelMaintFreq);
            Controls.Add(labelManHours);
            Controls.Add(labelCost);
            Controls.Add(labelKitRequired);
            Controls.Add(labelRemarks);
            Controls.Add(labelHiddenRemarks);
            Controls.Add(textBoxPartNo);
            Controls.Add(textBoxSerialNo);
            Controls.Add(textBoxMPDItem);
            Controls.Add(comboBoxAtaChapter);
            Controls.Add(textBoxDescription);
            if (currentDetail is GearAssembly)
                Controls.Add(panelLandingGearMark);    
            else 
                Controls.Add(textBoxPosition);
            Controls.Add(textBoxModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(dateTimePickerManufactureDate);
            Controls.Add(dateTimePickerInstallationDate);
            Controls.Add(labelSupplier);
            Controls.Add(textBoxSupplier);
            if (currentDetail is Detail)
            {
                Controls.Add(checkBoxAvionicsInventory);
                Controls.Add(panelAvionicsInventory);
                Controls.Add(labelALTPN);
                Controls.Add(textBoxALTPN);
                linkLabelJobCard.Location = new Point(MARGIN, textBoxALTPN.Bottom + HEIGHT_INTERVAL);
            }
            else if (currentDetail is GearAssembly)
            {
                Controls.Add(labelMaxTakeOffWeight);
                Controls.Add(textBoxMaxTakeOffWeight);
                linkLabelJobCard.Location = new Point(MARGIN, textBoxMaxTakeOffWeight.Bottom + HEIGHT_INTERVAL);
            }
            else if (currentDetail is Engine)
            {
                Controls.Add(labelHushKit);
                Controls.Add(textBoxHushKit);
                linkLabelJobCard.Location = new Point(MARGIN, textBoxHushKit.Bottom + HEIGHT_INTERVAL);
            }
            Controls.Add(linkLabelJobCard);
            Controls.Add(radioButtonConditionMonitoring);
            Controls.Add(radioButtonUnknown);
            Controls.Add(radioButtonHardTime);
            Controls.Add(radioButtonOnCondition);
            Controls.Add(textBoxManHours);
            Controls.Add(textBoxCost);
            Controls.Add(textBoxKitRequired);
            Controls.Add(textBoxRemarks);
            Controls.Add(textBoxHiddenRemarks);
            Controls.Add(labelCurrentTSNCSN);
            Controls.Add(lifelengthCurrentTSNCSN);
            Controls.Add(checkBoxLifeLimit);
            Controls.Add(lifelengthViewerLifeLimit);
            Controls.Add(labelRemains);
            Controls.Add(lifelengthRemains);
            Controls.Add(labelNotify);
            Controls.Add(lifelengthNotify);

            maintenanceCollection = MaintenanceTypeCollection.Instance;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
            try
            {
                return Program.Presenters.DetailsPresenter.GetGeneralInformationChangeStatus(currentDetail, ATAChapter, PartNumber, SerialNumber, MPDItem, Description, MaintenanceType, LandingGearMark, Model, Manufacturer, ManufactureDate, InstallationDate, Supplier, MaxTakeOffWeight, HusKit, AvionicsInventoryMarkType, ALTPN, ManhoursString, CostString, textBoxKitRequired.Text, Remarks, HiddenRemarks, LifeLimitEnabled, LifeLimit, LifeLimitNotify);
            }
            catch (CoreTypeNullException ex)
            {
                Program.Provider.Logger.Log(String.Format("{0} is null", ex.ParamName), ex);
                return true;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(
                    String.Format("{0}", argumentException.Message),
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail == null) 
                throw new ArgumentNullException("currentDetail");

            PartNumber = currentDetail.PartNumber;
            SerialNumber = currentDetail.SerialNumber;
            MPDItem = currentDetail.MPDItem;
            if (currentDetail is Detail)
                ATAChapter = currentDetail.AtaChapter;
            Description = currentDetail.Description;
            MaintenanceType = currentDetail.MaintenanceType;
            if (currentDetail is GearAssembly)
                LandingGearMark = ((GearAssembly)currentDetail).LandingGearMark;
            else 
                Position = currentDetail.PositionNumber;
            Model = currentDetail.Model;
            Manufacturer = currentDetail.Manufacturer;
            ManufactureDate = currentDetail.ManufactureDate;
            InstallationDate = currentDetail.InstallationDate;
            Supplier = currentDetail.Supplier;
            if (currentDetail is Detail)
            {
                AvionicsInventoryMark = ((Detail) currentDetail).AvionicsInventoryMarked;
                AvionicsInventoryMarkType = ((Detail)currentDetail).AvionicsInventoryMark;
                ALTPN = ((Detail)currentDetail).AltPN;
            }
            if (currentDetail is Engine)
                HusKit = currentDetail.HushKit_;
            if (currentDetail is GearAssembly)
                MaxTakeOffWeight = ((GearAssembly)currentDetail).MTOGW;
            if (Math.Abs(currentDetail.ManHours) > 0.000001)
                Manhours = currentDetail.ManHours;
            if (Math.Abs(currentDetail.Cost) > 0.000001)
                Cost = currentDetail.Cost;
            textBoxKitRequired.Text = currentDetail.KitRequired;
            Remarks = currentDetail.Remarks;
            HiddenRemarks = currentDetail.HiddenRemarks;
            lifelengthCurrentTSNCSN.Lifelength = currentDetail.Lifelength;
            lifelengthRemains.Lifelength = currentDetail.Remains;
            if (currentDetail.LifeLimit != Lifelength.NullLifelength)
                checkBoxLifeLimit.Checked = true;
            lifelengthViewerLifeLimit.Lifelength = currentDetail.LifeLimit;
            //labelNotify.Text = UsefulMethods.NormalizeDate(currentDetail.DueDate);
            lifelengthNotify.Lifelength = currentDetail.LifeLimitNotify;

            bool permission = (currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update));

            textBoxPartNo.ReadOnly = !permission;
            textBoxSerialNo.ReadOnly = !permission;
            textBoxMPDItem.ReadOnly = !permission;
            if ((currentDetail is Detail) && permission && !(currentDetail.Parent is GearAssembly))
                comboBoxAtaChapter.Enabled = true;
            else
                comboBoxAtaChapter.Enabled = false;
            textBoxDescription.ReadOnly = !permission;
          //  textBoxPosition.ReadOnly = !permission;
            textBoxModel.ReadOnly = !permission;
            textBoxManufacturer.ReadOnly = !permission;
            dateTimePickerManufactureDate.Enabled = permission;
            //dateTimePickerInstallationDate.Enabled = permission;
            textBoxSupplier.ReadOnly = !permission;
            if (currentDetail is Detail)
            {
                checkBoxAvionicsInventory.Enabled = permission;
                panelAvionicsInventory.Enabled = permission;
                textBoxALTPN.ReadOnly = !permission;
            }
            if (currentDetail is Engine)
                textBoxHushKit.ReadOnly = !permission;
            if (currentDetail is GearAssembly)
                textBoxMaxTakeOffWeight.ReadOnly = !permission;
            radioButtonConditionMonitoring.Enabled = permission;
            radioButtonHardTime.Enabled = permission;
            radioButtonOnCondition.Enabled = permission;
            radioButtonUnknown.Enabled = permission;
            textBoxManHours.ReadOnly = !permission;
            textBoxCost.ReadOnly = !permission;
            textBoxRemarks.ReadOnly = !permission;
            textBoxHiddenRemarks.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        public void SaveData()
        {
            bool changePageTitle = false;
            if (SerialNumber != currentDetail.SerialNumber)
                changePageTitle = true;
            // Сохраняем данные
            try
            {
                Program.Presenters.DetailsPresenter.SaveGeneralInformationData(currentDetail, ATAChapter, PartNumber,
                                                                               SerialNumber, MPDItem, Description,
                                                                               MaintenanceType, LandingGearMark,
                                                                               Model, Manufacturer,
                                                                               ManufactureDate,
                                                                               Supplier, MaxTakeOffWeight, HusKit,
                                                                               AvionicsInventoryMarkType, ALTPN,
                                                                               ManhoursString, CostString, textBoxKitRequired.Text, Remarks,
                                                                               HiddenRemarks, LifeLimitEnabled, LifeLimit, LifeLimitNotify);
            }
            catch (CoreTypeNullException ex)
            {
                Program.Provider.Logger.Log(String.Format("{0} is null", ex.ParamName), ex);
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(
                    String.Format("{0}", argumentException.Message),
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
            // Меняем название вкладки
            if (!changePageTitle)
                return;
            string caption;
            if (currentDetail is BaseDetail)
                caption = ((BaseDetail) currentDetail).ParentAircraft.RegistrationNumber + ". Component SN " + currentDetail.SerialNumber;
            else
            {
                if (currentDetail.Parent != null)
                    caption = ((Aircraft) currentDetail.Parent.Parent).RegistrationNumber + ". Component SN " + currentDetail.SerialNumber;
                else
                    caption = "Component SN " + currentDetail.SerialNumber;
            }
            if (DisplayerRequested != null)
                DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
        }

        #endregion

        #region private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaintenanceJobCardForm form;
            if (currentDetail.JobCard == null)
                form = new MaintenanceJobCardForm(currentDetail);
            else
                form = new MaintenanceJobCardForm(currentDetail.JobCard);
            form.ShowDialog();
        }

        #endregion


        #region private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)

        private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)
        {
            AvionicsInventoryMark = checkBoxAvionicsInventory.Checked;
            if (!(radioButtonInventoryOptional.Checked) && !(radioButtonInventoryRequired.Checked) && !(radioButtonAvionicsInventoryUnknown.Checked) && (checkBoxAvionicsInventory.Checked))
                radioButtonInventoryOptional.Checked = true;
        }

        #endregion

        #region private void checkBoxLifeLimit_CheckedChanged(object sender, EventArgs e)

        private void checkBoxLifeLimit_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewerLifeLimit.Enabled = checkBoxLifeLimit.Checked;
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