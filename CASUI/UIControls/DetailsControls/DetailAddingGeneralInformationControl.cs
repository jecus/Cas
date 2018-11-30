using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.LogBookControls;
using CASTerms;
using CAS.Core.Core.Exceptions;

namespace CAS.UI.UIControls.DetailsControls
{

    ///<summary>
    /// Элемент управления, использующийся для задания общей информации при добавлении агрегата
    ///</summary>
    public class DetailAddingGeneralInformationControl : UserControl
    {
        
        #region Fields

        private readonly Aircraft currentAircraft;
        private readonly bool isStore;

        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 100;
        private const int CAPTION_WIDTH = 200;
        private const int TEXTBOX_WIDTH = 250;
        private const int WIDTH_INTERVAL = 400 + MARGIN;
        private const int WIDTH_INTERVAL_SECOND = 800 + MARGIN;
  
        private Label labelMPDItem;
        private Label labelAtaChapter;
        private Label labelDescription;
        private Label labelPartNo;
        private Label labelSerialNo;
        private Label labelRemarks;
        private Label labelInstallationData;
        private Label labelInstallationDate;
        private Label labelComponentTSNCSN;
        private Label labelAircraftTSNCSN;
        private Label labelHiddenRemarks;
        private Label labelActualState;
        private Label labelDateAsOf;
        private Label labelComponentCurrentTSNCSN;
        private Label labelTCSI;
        private TextBox textBoxMPDItem;
        private ATAChapterComboBox comboBoxAtaChapter;
        private TextBox textBoxDescription;
        private TextBox textBoxPartNo;
        private TextBox textBoxSerialNo;
        private CheckBox checkBoxLifeLimit;
        private LifelengthViewer lifelengthViewerLifeLimit;
        private TextBox textBoxRemarks;
        private DateTimePicker dateTimePickerInstallationDate;
        private LifelengthViewer lifelengthViewerComponentTSNCSN;
        private LifelengthViewer lifelengthViewerAircraftTSNCSN;
        private TextBox textBoxHiddenRemarks;
        private DateTimePicker dateTimePickerDateAsOf;
        private LifelengthViewer lifelengthViewerComponentCurrentTSNCSN;
        private LifelengthViewer lifelengthViewerComponentTCSI;

        private Delimiter delimiter1;
        private Delimiter delimiter2;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления, использующийся для задания общей информации при добавлении агрегата
        /// </summary>
        public DetailAddingGeneralInformationControl(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            isStore = aircraft.Type == AircraftType.Store;
            InitializeComponent();
        }

        #endregion

        #region Propeties

        #region public string MPDItem

        /// <summary>
        /// MPD Item создаваемого агрегата
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

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATA глава создаваемого агрегата
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
        /// Партийный номер создаваемого агрегата
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
        /// Серийный номер создаваемого агрегата
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

        #region public string Description

        /// <summary>
        /// Описание создаваемого агрегата
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

        #region public string Remarks

        /// <summary>
        /// Замечания к создаваемому агрегату
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

        #region public Lifelength LifeLimit

        /// <summary>
        /// Ограничение агрегата по сроку эксплуатации
        /// </summary>
        public Lifelength LifeLimit
        {
            get { return lifelengthViewerLifeLimit.Lifelength; }
            set
            {
                lifelengthViewerLifeLimit.Lifelength = value;
            }
        }

        #endregion

        #region public bool LifelimitEnabled

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее актуально ли ограничение
        /// </summary>
        public bool LifelimitEnabled
        {
            get
            {
                return checkBoxLifeLimit.Checked;
            }
            set
            {
                checkBoxLifeLimit.Checked = value;
            }
        }

        #endregion

        #region public string HiddenRemarks

        /// <summary>
        /// Замечания к создаваемому агрегату
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

        #region public DateTime InstallationDate

        /// <summary>
        /// Дата установки агрегата на ВС
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

        #region public Lifelength ComponentTSNCSN

        /// <summary>
        /// Наработка агрегата на момент установки
        /// </summary>
        public Lifelength ComponentTSNCSN
        {
            get { return lifelengthViewerComponentTSNCSN.Lifelength; }
            set
            {
                lifelengthViewerComponentTSNCSN.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength AircraftTSNCSN

        /// <summary>
        /// Наработка ВС на момент установки агрегата
        /// </summary>
        public Lifelength AircraftTSNCSN
        {
            get { return lifelengthViewerAircraftTSNCSN.Lifelength; }
            set
            {
                lifelengthViewerAircraftTSNCSN.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength ComponentCurrentTSNCSN

        /// <summary>
        /// Текущая наработка агрегата
        /// </summary>
        public Lifelength ComponentCurrentTSNCSN
        {
            get { return lifelengthViewerComponentCurrentTSNCSN.Lifelength; }
            set
            {
                lifelengthViewerComponentCurrentTSNCSN.Lifelength = value;
            }
        }

        #endregion



        #region public Lifelength ComponentTCSI

        /// <summary>
        /// Наработка агрегата с момента установки
        /// </summary>
        public Lifelength ComponentTCSI
        {
            get { return lifelengthViewerComponentTCSI.Lifelength; }
            set
            {
                lifelengthViewerComponentTCSI.Lifelength = value;
            }
        }

        #endregion

        #region public bool SetCurrentComponentTSNCSN

        /// <summary>
        /// Возвращает значение, показывающее нужно ли добавлять запись ActualData на текущее число
        /// </summary>
        public bool SetCurrentComponentTSNCSN
        {
            get
            {
                return (lifelengthViewerComponentCurrentTSNCSN.Enabled && lifelengthViewerComponentCurrentTSNCSN.Lifelength != Lifelength.NullLifelength);
            }
        }

        #endregion

        #region public bool SetActualDataToAircraft

        /// <summary>
        /// Возвращает значение, показывающее нужно ли добавлять запись ActualData к ВС
        /// </summary>
        public bool SetActualDataToAircraft
        {
            get
            {
                return lifelengthViewerAircraftTSNCSN.Modified;
            }
        }

        #endregion

        #region public DateTime DateAsOf

        /// <summary>
        /// Текущая дата 
        /// </summary>
        public DateTime DateAsOf
        {
            get { return dateTimePickerDateAsOf.Value; }
            set
            {
                dateTimePickerDateAsOf.Value = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        /// <summary>
        /// Инициализирует элементы управления
        /// </summary>
        private void InitializeComponent()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            labelMPDItem = new Label();
            labelAtaChapter = new Label();
            labelDescription = new Label();
            labelPartNo = new Label();
            labelSerialNo = new Label();
            labelRemarks = new Label();
            labelInstallationData = new Label();
            labelInstallationDate = new Label();
            labelComponentTSNCSN = new Label();
            labelAircraftTSNCSN = new Label();
            labelHiddenRemarks = new Label();
            labelActualState = new Label();
            labelDateAsOf = new Label();
            labelComponentCurrentTSNCSN = new Label();
            labelTCSI = new Label();
            textBoxMPDItem = new TextBox();
            comboBoxAtaChapter = new ATAChapterComboBox();
            textBoxDescription = new TextBox();
            textBoxPartNo = new TextBox();
            textBoxSerialNo = new TextBox();
            checkBoxLifeLimit = new CheckBox();
            lifelengthViewerLifeLimit = new LifelengthViewer();
            textBoxRemarks = new TextBox();
            dateTimePickerInstallationDate = new DateTimePicker();
            lifelengthViewerComponentTSNCSN = new LifelengthViewer();
            lifelengthViewerAircraftTSNCSN = new LifelengthViewer();
            textBoxHiddenRemarks = new TextBox();
            dateTimePickerDateAsOf = new DateTimePicker();
            lifelengthViewerComponentCurrentTSNCSN = new LifelengthViewer();
            lifelengthViewerComponentTCSI = new LifelengthViewer();
            delimiter1 = new Delimiter();
            delimiter2 = new Delimiter();
            // 
            // labelMPDItem
            // 
            labelMPDItem.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelMPDItem.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMPDItem.Location = new Point(MARGIN, MARGIN);
            labelMPDItem.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMPDItem.Text = "MPD Item:";
            labelMPDItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMPDItem
            // 
            textBoxMPDItem.BackColor = Color.White;
            textBoxMPDItem.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxMPDItem.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMPDItem.Location = new Point(labelMPDItem.Right, MARGIN);
            textBoxMPDItem.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxMPDItem.MaxLength = 50;
            textBoxMPDItem.TabIndex = 0;
            // 
            // labelAtaChapter
            // 
            labelAtaChapter.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAtaChapter.Location = new Point(MARGIN, labelMPDItem.Bottom + HEIGHT_INTERVAL);
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
            comboBoxAtaChapter.Location = new Point(labelAtaChapter.Right, labelMPDItem.Bottom + HEIGHT_INTERVAL);
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            comboBoxAtaChapter.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, labelAtaChapter.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxDescription.Location = new Point(labelDescription.Right, labelAtaChapter.Bottom + HEIGHT_INTERVAL);
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Multiline = true;
            textBoxDescription.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxDescription.MaxLength = 250;
            textBoxDescription.TabIndex = 2;
            // 
            // labelPartNo
            // 
            labelPartNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPartNo.Location = new Point(MARGIN, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            labelPartNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPartNo.Text = "Part No:";
            labelPartNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNo
            // 
            textBoxPartNo.BackColor = Color.White;
            textBoxPartNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxPartNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPartNo.Location = new Point(labelPartNo.Right, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            textBoxPartNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxPartNo.MaxLength = 100;
            textBoxPartNo.TabIndex = 3;
            // 
            // labelSerialNo
            // 
            labelSerialNo.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelSerialNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNo.Location = new Point(MARGIN, labelPartNo.Bottom + HEIGHT_INTERVAL);
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
            textBoxSerialNo.TabIndex = 4;
            // 
            // checkBoxLifeLimit
            // 
            checkBoxLifeLimit.Cursor = Cursors.Hand;
            checkBoxLifeLimit.FlatStyle = FlatStyle.Flat;
            checkBoxLifeLimit.Font = Css.SimpleLink.Fonts.SmallFont;
            checkBoxLifeLimit.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxLifeLimit.Location = new Point(MARGIN, labelSerialNo.Bottom + HEIGHT_INTERVAL);
            checkBoxLifeLimit.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxLifeLimit.Text = "Life Limit";
            checkBoxLifeLimit.CheckedChanged += checkBoxLifeLimit_CheckedChanged;
            checkBoxLifeLimit.TabIndex = 5;
            //
            // lifelengthViewerLifeLimit
            //
            lifelengthViewerLifeLimit.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerLifeLimit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerLifeLimit.ShowLeftHeader = false;
            lifelengthViewerLifeLimit.LeftHeaderWidth = 0;
            lifelengthViewerLifeLimit.ShowMinutes = false;
            lifelengthViewerLifeLimit.Location = new Point(MARGIN, checkBoxLifeLimit.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerLifeLimit.Enabled = false;
            lifelengthViewerLifeLimit.TabIndex = 6;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(MARGIN, lifelengthViewerLifeLimit.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Location = new Point(labelRemarks.Right, lifelengthViewerLifeLimit.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxRemarks.MaxLength = 340000;
            textBoxRemarks.TabIndex = 7;
            //
            // delimiter1
            //
            delimiter1.Orientation = DelimiterOrientation.Vertical;
            delimiter1.Location = new Point(WIDTH_INTERVAL -(WIDTH_INTERVAL - MARGIN - LABEL_WIDTH - TEXTBOX_WIDTH)/2, MARGIN);
            delimiter1.Height = 265;
            // 
            // labelInstallationData
            // 
            labelInstallationData.Font = Css.SmallHeader.Fonts.BoldFont;
            labelInstallationData.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelInstallationData.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelInstallationData.TextAlign = ContentAlignment.MiddleLeft;
            labelInstallationData.Text = "Installation Data";
            // 
            // labelInstallationDate
            // 
            labelInstallationDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelInstallationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInstallationDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelInstallationDate.Text = "Date:";
            labelInstallationDate.TextAlign = ContentAlignment.MiddleLeft;
            labelInstallationDate.TabIndex = 8;
            // 
            // dateTimePickerInstallationDate       
            // 
            dateTimePickerInstallationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerInstallationDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerInstallationDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerInstallationDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerInstallationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerInstallationDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerInstallationDate.ValueChanged += dateTimePickerInstallationDate_ValueChanged;
            dateTimePickerInstallationDate.TabIndex = 9;
            // 
            // labelComponentTSNCSN
            // 
            labelComponentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelComponentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComponentTSNCSN.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelComponentTSNCSN.Text = "Component TSN/CSN:";
            labelComponentTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerComponentTSNCSN
            //
            lifelengthViewerComponentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerComponentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerComponentTSNCSN.ShowLeftHeader = false;
            lifelengthViewerComponentTSNCSN.LeftHeaderWidth = 0;
            lifelengthViewerComponentTSNCSN.ShowMinutes = false;
            lifelengthViewerComponentTSNCSN.LifelengthChanged += lifelengthViewerComponentTSNCSN_LifelengthChanged;
            lifelengthViewerComponentTSNCSN.TabIndex = 10;
            // 
            // labelAircraftTSNCSN
            // 
            labelAircraftTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelAircraftTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftTSNCSN.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelAircraftTSNCSN.Text = "Aircraft TSN/CSN:";
            labelAircraftTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerAircraftTSNCSN
            //
            lifelengthViewerAircraftTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerAircraftTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerAircraftTSNCSN.ShowLeftHeader = false;
            lifelengthViewerAircraftTSNCSN.LeftHeaderWidth = 0;
            lifelengthViewerAircraftTSNCSN.ShowMinutes = false;
            lifelengthViewerAircraftTSNCSN.TabIndex = 11;
            // 
            // labelHiddenRemarks
            // 
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT*2);
            labelHiddenRemarks.TextAlign = ContentAlignment.TopLeft;
            labelHiddenRemarks.Text = "Hidden Remarks:";
            // 
            // textBoxHiddenRemarks
            // 
            textBoxHiddenRemarks.BackColor = Color.White;
            textBoxHiddenRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHiddenRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxHiddenRemarks.Multiline = true;
            textBoxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxHiddenRemarks.MaxLength = 340000;
            textBoxHiddenRemarks.TabIndex = 12;
            //
            // delimiter2
            //
            delimiter2.Orientation = DelimiterOrientation.Vertical;
            delimiter2.Location = new Point(WIDTH_INTERVAL_SECOND - (WIDTH_INTERVAL_SECOND - WIDTH_INTERVAL - LABEL_WIDTH - TEXTBOX_WIDTH) / 2, MARGIN);
            delimiter2.Height = 265;
            // 
            // labelActualState
            // 
            labelActualState.Font = Css.SmallHeader.Fonts.BoldFont;
            labelActualState.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelActualState.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelActualState.TextAlign = ContentAlignment.MiddleLeft;
            labelActualState.Text = "Actual State";
            // 
            // labelDateAsOf
            // 
            labelDateAsOf.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateAsOf.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDateAsOf.Text = "Date As Of:";
            labelDateAsOf.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerDateAsOf       
            // 
            dateTimePickerDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDateAsOf.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDateAsOf.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerDateAsOf.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerDateAsOf.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateAsOf.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDateAsOf.ValueChanged += dateTimePickerDateAsOf_ValueChanged;
            dateTimePickerDateAsOf.TabIndex = 13;
            // 
            // labelComponentCurrentTSNCSN
            // 
            labelComponentCurrentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelComponentCurrentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComponentCurrentTSNCSN.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelComponentCurrentTSNCSN.Text = "Component current TSN/CSN:";
            labelComponentCurrentTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerComponentCurrentTSNCSN
            //
            lifelengthViewerComponentCurrentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerComponentCurrentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerComponentCurrentTSNCSN.ShowLeftHeader = false;
            lifelengthViewerComponentCurrentTSNCSN.LeftHeaderWidth = 0;
            lifelengthViewerComponentCurrentTSNCSN.ShowMinutes = false;
            lifelengthViewerComponentCurrentTSNCSN.LifelengthChanged += lifelengthViewerComponentCurrentTSNCSN_LifelengthChanged;
            lifelengthViewerComponentCurrentTSNCSN.TabIndex = 14;
            // 
            // labelTCSI
            // 
            labelTCSI.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelTCSI.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTCSI.Size = new Size(CAPTION_WIDTH, LABEL_HEIGHT);
            labelTCSI.Text = "Component TCSI:";
            labelTCSI.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerComponentTCSI
            //
            lifelengthViewerComponentTCSI.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerComponentTCSI.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerComponentTCSI.ShowLeftHeader = false;
            lifelengthViewerComponentTCSI.LeftHeaderWidth = 0;
            lifelengthViewerComponentTCSI.ShowMinutes = false;
            lifelengthViewerComponentTCSI.LifelengthChanged += lifelengthViewerComponentTCSI_LifelengthChanged;
            lifelengthViewerComponentTCSI.TabIndex = 15;
            // 
            // DetailGeneralInformationControl
            //
            Controls.Add(labelMPDItem);
            Controls.Add(textBoxMPDItem);
            Controls.Add(labelAtaChapter);
            Controls.Add(comboBoxAtaChapter);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelPartNo);
            Controls.Add(textBoxPartNo);
            Controls.Add(labelSerialNo);
            Controls.Add(textBoxSerialNo);
            Controls.Add(checkBoxLifeLimit);
            Controls.Add(lifelengthViewerLifeLimit);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);

            Controls.Add(labelDateAsOf);
            Controls.Add(dateTimePickerDateAsOf);
            Controls.Add(labelComponentTSNCSN);
            Controls.Add(lifelengthViewerComponentTSNCSN);
            Controls.Add(labelHiddenRemarks);
            Controls.Add(textBoxHiddenRemarks);
            if (!isStore)
            {
                labelInstallationData.Location = new Point(WIDTH_INTERVAL, MARGIN);
                labelInstallationDate.Location = new Point(WIDTH_INTERVAL, labelInstallationData.Bottom + HEIGHT_INTERVAL);
                dateTimePickerInstallationDate.Location = new Point(labelInstallationDate.Right, labelInstallationData.Bottom + HEIGHT_INTERVAL);
                labelComponentTSNCSN.Location = new Point(WIDTH_INTERVAL, labelInstallationDate.Bottom + HEIGHT_INTERVAL);
                lifelengthViewerComponentTSNCSN.Location = new Point(WIDTH_INTERVAL, labelComponentTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
                labelAircraftTSNCSN.Location = new Point(WIDTH_INTERVAL, lifelengthViewerComponentTSNCSN.Bottom + HEIGHT_INTERVAL);
                lifelengthViewerAircraftTSNCSN.Location = new Point(WIDTH_INTERVAL, labelAircraftTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
                labelHiddenRemarks.Location = new Point(WIDTH_INTERVAL, lifelengthViewerLifeLimit.Bottom + HEIGHT_INTERVAL);
                textBoxHiddenRemarks.Location = new Point(labelHiddenRemarks.Right, lifelengthViewerLifeLimit.Bottom + HEIGHT_INTERVAL);
                labelActualState.Location = new Point(WIDTH_INTERVAL_SECOND, MARGIN);
                labelDateAsOf.Location = new Point(WIDTH_INTERVAL_SECOND, labelActualState.Bottom + HEIGHT_INTERVAL);
                dateTimePickerDateAsOf.Location = new Point(labelDateAsOf.Right, labelActualState.Bottom + HEIGHT_INTERVAL);
                labelComponentCurrentTSNCSN.Location = new Point(WIDTH_INTERVAL_SECOND, labelDateAsOf.Bottom + HEIGHT_INTERVAL);
                lifelengthViewerComponentCurrentTSNCSN.Location = new Point(WIDTH_INTERVAL_SECOND, labelComponentCurrentTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
                labelTCSI.Location = new Point(WIDTH_INTERVAL_SECOND, lifelengthViewerComponentCurrentTSNCSN.Bottom + HEIGHT_INTERVAL);
                lifelengthViewerComponentTCSI.Location = new Point(WIDTH_INTERVAL_SECOND, labelTCSI.Bottom + HEIGHT_LIFELENGTH_INTERVAL);

                Controls.Add(delimiter1);
                Controls.Add(labelInstallationData);
                Controls.Add(labelInstallationDate);
                Controls.Add(dateTimePickerInstallationDate);
                Controls.Add(labelAircraftTSNCSN);
                Controls.Add(lifelengthViewerAircraftTSNCSN);
                Controls.Add(delimiter2);
                Controls.Add(labelActualState);
                Controls.Add(labelComponentCurrentTSNCSN);
                Controls.Add(lifelengthViewerComponentCurrentTSNCSN);
                Controls.Add(labelTCSI);
                Controls.Add(lifelengthViewerComponentTCSI);
            }
            else
            {
                dateTimePickerDateAsOf.TabIndex = 9;
                labelDateAsOf.Location = new Point(WIDTH_INTERVAL, MARGIN);
                dateTimePickerDateAsOf.Location = new Point(labelDateAsOf.Right, MARGIN);
                labelComponentTSNCSN.Location = new Point(WIDTH_INTERVAL, labelDateAsOf.Bottom + HEIGHT_INTERVAL);
                lifelengthViewerComponentTSNCSN.Location = new Point(WIDTH_INTERVAL, labelComponentTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
                labelHiddenRemarks.Location = new Point(WIDTH_INTERVAL, lifelengthViewerComponentTSNCSN.Bottom + HEIGHT_INTERVAL);
                textBoxHiddenRemarks.Location = new Point(labelHiddenRemarks.Right, lifelengthViewerComponentTSNCSN.Bottom + HEIGHT_INTERVAL);
            }
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (MPDItem != "" ||
                    ATAChapter != null ||
                    Description != "" ||
                    PartNumber != "" ||
                    SerialNumber != "" ||
                    LifelimitEnabled ||
                    lifelengthViewerLifeLimit.Modified ||
                    Remarks != "" ||
                    HiddenRemarks != "" ||
                    InstallationDate != DateTime.Today ||
                    lifelengthViewerComponentTSNCSN.Modified ||
                    lifelengthViewerAircraftTSNCSN.Modified ||
                    DateAsOf != DateTime.Today ||
                    lifelengthViewerComponentCurrentTSNCSN.Modified ||
                    lifelengthViewerComponentTCSI.Modified);
        }

        #endregion

        #region public void SaveData(AbstractDetail detail)

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        public void SaveData(AbstractDetail detail)
        {
            try
            {
                Program.Presenters.DetailsPresenter.SaveGeneralInformationDataWhenDetailAdding(
                    detail, MPDItem, ATAChapter, Description, PartNumber, SerialNumber, Remarks, LifelimitEnabled, LifeLimit);
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
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            comboBoxAtaChapter.ClearValue();
            MPDItem = "";
            Description = "";
            PartNumber = "";
            SerialNumber = "";
            LifelimitEnabled = false;
            LifeLimit = Lifelength.NullLifelength;
            lifelengthViewerLifeLimit.Modified = false;
            Remarks = "";
            HiddenRemarks = "";
            InstallationDate = DateTime.Today;
            ComponentTSNCSN = Lifelength.NullLifelength;
            lifelengthViewerComponentTSNCSN.Modified = false;
            if (!isStore)
            {
                //AircraftTSNCSN = currentAircraft.LoadLifelength(DateTime.Today);
               // lifelengthViewerAircraftTSNCSN.Modified = false;
            }
            DateAsOf = DateTime.Today;
           // ComponentCurrentTSNCSN = Lifelength.NullLifelength;
          //  lifelengthViewerComponentCurrentTSNCSN.Modified = false;
         //   ComponentTCSI = Lifelength.NullLifelength;
           // lifelengthViewerComponentTCSI.Modified = false;
        }

        #endregion

        #region private void checkBoxLifeLimit_CheckedChanged(object sender, EventArgs e)

        private void checkBoxLifeLimit_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewerLifeLimit.Enabled = checkBoxLifeLimit.Checked;
        }

        #endregion

        #region private void dateTimePickerInstallationDate_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerInstallationDate_ValueChanged(object sender, EventArgs e)
        {
            if (!lifelengthViewerAircraftTSNCSN.Modified)
            {
                AircraftTSNCSN = currentAircraft.GetLifelength(InstallationDate);
                lifelengthViewerAircraftTSNCSN.Modified = false;
            }
        }

        #endregion

        #region private void lifelengthViewerComponentCurrentTSNCSN_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerComponentCurrentTSNCSN_LifelengthChanged(object sender, EventArgs e)
        {
            if (ComponentTSNCSN == Lifelength.NullLifelength)
                return;
            ComponentTCSI = ComponentCurrentTSNCSN - ComponentTSNCSN;
        }

        #endregion

        #region private void lifelengthViewerComponentTCSI_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerComponentTCSI_LifelengthChanged(object sender, EventArgs e)
        {
            if (ComponentTSNCSN == Lifelength.NullLifelength)
                return;
            ComponentCurrentTSNCSN = ComponentTSNCSN + ComponentTCSI;
        }

        #endregion

        #region private void lifelengthViewerComponentTSNCSN_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerComponentTSNCSN_LifelengthChanged(object sender, EventArgs e)
        {
            if (ComponentCurrentTSNCSN != Lifelength.NullLifelength)
                ComponentTCSI = ComponentCurrentTSNCSN - ComponentTSNCSN;
        }

        #endregion
        
        #region private void dateTimePickerDateAsOf_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerDateAsOf_ValueChanged(object sender, EventArgs e)
        {
            ActualStateRecord[] records = currentAircraft.AircraftFrame.GetActualSettingRecords(dateTimePickerDateAsOf.Value.AddDays(1));
            DateTime dateAsOf = dateTimePickerDateAsOf.Value;
            for (int i = records.Length - 1; i >= 0; i--)
            {
                if (records[i].RecordDate.Year == dateAsOf.Year && records[i].RecordDate.Month == dateAsOf.Month && records[i].RecordDate.Day == dateAsOf.Day)
                {
                    lifelengthViewerComponentCurrentTSNCSN.Lifelength = records[i].Lifelength;
                    ComponentTCSI = ComponentCurrentTSNCSN - ComponentTSNCSN;
                    lifelengthViewerComponentCurrentTSNCSN.Enabled = false;
                    lifelengthViewerComponentTCSI.Enabled = false;
                    lifelengthViewerComponentCurrentTSNCSN.Modified = false;
                    lifelengthViewerComponentTCSI.Modified = false;
                    return;
                }
            }
            lifelengthViewerComponentCurrentTSNCSN.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerComponentTCSI.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerComponentCurrentTSNCSN.Enabled = true;
            lifelengthViewerComponentTCSI.Enabled = true;
            lifelengthViewerComponentCurrentTSNCSN.Modified = false;
            lifelengthViewerComponentTCSI.Modified = false;
        }

        #endregion

        #endregion

    }
}