using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения параметров агрегата
    /// </summary>
    public class TemplateDetailParametersControl : UserControl
    {

        #region Fields

        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 180;
        private const int LABEL_REMARK_WIDTH = 300;
        private const int TEXTBOX_WIDTH = 250;
        private const int WIDTH_INTERVAL = 610;

        private CheckBox checkBoxLLP;
        private CheckBox checkBoxLandingGear;
        private CheckBox checkBoxAvionicsInventory;
        private CheckBox checkBoxIncludeToLandingGearReport;
        private RadioButton radioButtonLLG;
        private RadioButton radioButtonNLG;
        private RadioButton radioButtonRLG;
        private TextBox textBoxALTPN;
        private TextBox textBoxHushKit;
        private TextBox textBoxMTOGW;
        private Label labelLLPRemark;
        private Label labelLandingGearsRemark;
        private RadioButton radioButtonInventoryOptional;
        private RadioButton radioButtonInventoryRequired;
        private Label labelALTPN;
        private Label labelMTOGW;
        private Label labelHushKit;
        private Label labelAvionicsInventoryRemark;
        private Panel panelLandingGear;

        private TemplateAbstractDetail currentDetail;
        private bool showHushKit = true;

        #endregion

        #region Constructors

        #region public TemplateDetailParametersControl()

        /// <summary>
        /// Создает элемент управления для отображения параметров шаблонного агрегата
        /// </summary>
        public TemplateDetailParametersControl()
        {
            InitializeComponent();    
        }

        #endregion

        #region public TemplateDetailParametersControl(TemplateAbstractDetail detail) : this()

        /// <summary>
        /// Создает элемент управления для отображения параметров шаблонного агрегата
        /// </summary>
        /// <param name="detail">Текущий агрегат</param>
        public TemplateDetailParametersControl(TemplateAbstractDetail detail) : this()
        {
            currentDetail = detail;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public TemplateAbstractDetail Currentdetail

        /// <summary>
        /// Возвращает или устанавливает агрегат, с которым работает данный элемент управления
        /// </summary>
        public TemplateAbstractDetail Currentdetail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                UpdateInformation();
            }
        }

        #endregion

        #region public bool LLPMark

        /// <summary>
        /// LLP attribute
        /// </summary>
        public bool LLPMark
        {
            get
            {
                return checkBoxLLP.Checked;
            }
            set
            {
                checkBoxLLP.Checked = value;
            }
        }

        #endregion


        #region public bool LandingGearMark

        /// <summary>
        /// Landing Gear
        /// </summary>
        public bool LandingGearMark
        {
            get
            {
                return checkBoxLandingGear.Checked;
            }
            set
            {
                checkBoxLandingGear.Checked = value;
                panelLandingGear.Enabled = value;
            }
        }

        #endregion

        #region public LandingGearMarkType LandingGearMarkType

        /// <summary>
        /// Тип шасси
        /// </summary>
        public LandingGearMarkType LandingGearMarkType
        {
            get
            {
                if (!LandingGearMark) return LandingGearMarkType.None;
                if (radioButtonNLG.Checked) return LandingGearMarkType.General;
                if (radioButtonLLG.Checked) return LandingGearMarkType.Left;
                if (radioButtonRLG.Checked) return LandingGearMarkType.Right;
                return LandingGearMarkType.None;
            }
            set
            {
                LandingGearMark = value != LandingGearMarkType.None;
                if (value == LandingGearMarkType.General) radioButtonNLG.Checked = true;
                if (value == LandingGearMarkType.Left) radioButtonLLG.Checked = true;
                if (value == LandingGearMarkType.Right) radioButtonRLG.Checked = true;
            }
        }

        #endregion

        #region public string MTOGW

        /// <summary>
        /// MTO GW
        /// </summary>
        public string MTOGW
        {
            get
            {
                return textBoxMTOGW.Text;
            }
            set
            {
                textBoxMTOGW.Text = value;
            }
        }

        #endregion

        #region public bool LandingGearVisible

        /// <summary>
        /// Возвращает или устанавливает свойство Visible для LandingGearMark
        /// </summary>
        public bool LandingGearVisible
        {
            get
            {
                return checkBoxLandingGear.Visible;
            }
            set
            {
                checkBoxLandingGear.Visible = value;
                labelLandingGearsRemark.Visible = value;
                panelLandingGear.Visible = value;
            }
        }

        #endregion

        #region public bool LandingGearEnabled

        /// <summary>
        /// Возвращает или устанавливает свойство Enabled для LandingGearMark
        /// </summary>
        public bool LandingGearEnabled
        {
            get
            {
                return checkBoxLandingGear.Enabled;
            }
            set
            {
                checkBoxLandingGear.Enabled = value;
                if (value && checkBoxLandingGear.Checked)
                    panelLandingGear.Enabled = value;
            }
        }

        #endregion


        #region public bool IncludeToLandingGearReportMark

        /// <summary>
        /// Include To Landing Gears Report
        /// </summary>
        public bool IncludeToLandingGearReportMark
        {
            get
            {
                return checkBoxIncludeToLandingGearReport.Checked;
            }
            set
            {
                checkBoxIncludeToLandingGearReport.Checked = value;
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
                if (!AvionicsInventoryMark) return AvionicsInventoryMarkType.None;
                if (radioButtonInventoryOptional.Checked) return AvionicsInventoryMarkType.Optional;
                if (radioButtonInventoryRequired.Checked) return AvionicsInventoryMarkType.Required;
                return AvionicsInventoryMarkType.None;
            }
            set
            {
                AvionicsInventoryMark = value != AvionicsInventoryMarkType.None;
                if (value == AvionicsInventoryMarkType.Required) radioButtonInventoryRequired.Checked = true;
                if (value == AvionicsInventoryMarkType.Optional) radioButtonInventoryOptional.Checked = true;
            }
        }

        #endregion

        #region public bool AvionicsInventoryVisible

        /// <summary>
        /// Возвращает или устанавливает свойство Visible для AvionicsInventoryMark
        /// </summary>
        public bool AvionicsInventoryVisible
        {
            get
            {
                return checkBoxAvionicsInventory.Visible;
            }
            set
            {
                checkBoxAvionicsInventory.Visible = value;
                labelAvionicsInventoryRemark.Visible = value;
                radioButtonInventoryOptional.Visible = value;
                radioButtonInventoryRequired.Visible = value;

            }
        }

        #endregion

        #region public bool AvionicsInventoryEnabled

        /// <summary>
        /// Возвращает или устанавливает свойство Enabled для AvionicsInventoryMark
        /// </summary>
        public bool AvionicsInventoryEnabled
        {
            get
            {
                return checkBoxAvionicsInventory.Enabled;
            }
            set
            {
                checkBoxAvionicsInventory.Enabled = value;
                if (value && checkBoxAvionicsInventory.Checked)
                {
                    radioButtonInventoryOptional.Enabled = value;
                    radioButtonInventoryRequired.Enabled = value;
                }
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

        #region public bool ShowHushKit

        /// <summary>
        /// Показывать ли поле HushKit
        /// </summary>
        public bool ShowHushKit
        {
            get
            {
                return showHushKit;
            }
            set
            {
                showHushKit = value;
                labelHushKit.Visible = value;
                textBoxHushKit.Visible = value;
            }

        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            checkBoxLLP = new CheckBox();
            checkBoxLandingGear = new CheckBox();
            checkBoxAvionicsInventory = new CheckBox();
            checkBoxIncludeToLandingGearReport = new CheckBox();
            radioButtonLLG = new RadioButton();
            radioButtonNLG = new RadioButton();
            radioButtonRLG = new RadioButton();
            radioButtonInventoryOptional = new RadioButton();
            radioButtonInventoryRequired = new RadioButton();
            textBoxALTPN = new TextBox();
            textBoxHushKit = new TextBox();
            textBoxMTOGW = new TextBox();
            labelLLPRemark = new Label();
            labelLandingGearsRemark = new Label();
            labelALTPN = new Label();
            labelMTOGW = new Label();
            labelHushKit = new Label();
            labelAvionicsInventoryRemark = new Label();
            panelLandingGear = new Panel();
            // 
            // checkBoxLLP
            // 
            checkBoxLLP.Cursor = Cursors.Hand;
            checkBoxLLP.FlatStyle = FlatStyle.Flat;
            checkBoxLLP.Font = Css.SimpleLink.Fonts.Font;
            checkBoxLLP.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxLLP.Location = new Point(MARGIN, MARGIN);
            checkBoxLLP.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxLLP.Text = "LLP";
            // 
            // labelLLPRemark
            // 
            labelLLPRemark.Font = Css.SimpleLink.Fonts.Font;
            labelLLPRemark.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLLPRemark.Location = new Point(checkBoxLLP.Right, MARGIN);
            labelLLPRemark.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelLLPRemark.Text = "This Component Is Lifelimit Part";
            // 
            // checkBoxLandingGear
            // 
            checkBoxLandingGear.Cursor = Cursors.Hand;
            checkBoxLandingGear.FlatStyle = FlatStyle.Flat;
            checkBoxLandingGear.Font = Css.SimpleLink.Fonts.Font;
            checkBoxLandingGear.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxLandingGear.Location = new Point(MARGIN, checkBoxLLP.Bottom + HEIGHT_INTERVAL);
            checkBoxLandingGear.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxLandingGear.Text = "Landing Gear";
            checkBoxLandingGear.CheckedChanged += checkBoxLandingGearMark_CheckedChanged;
            // 
            // labelLandingGearsRemark
            // 
            labelLandingGearsRemark.Font = Css.SimpleLink.Fonts.Font;
            labelLandingGearsRemark.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLandingGearsRemark.Location = new Point(checkBoxLandingGear.Right, checkBoxLLP.Bottom + HEIGHT_INTERVAL);
            labelLandingGearsRemark.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelLandingGearsRemark.Text = "This Component Is Landing Gear";
            // 
            // radioButtonLLG
            // 
            radioButtonLLG.Cursor = Cursors.Hand;
            radioButtonLLG.FlatStyle = FlatStyle.Flat;
            radioButtonLLG.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonLLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonLLG.Location = new Point(LABEL_WIDTH, 0);
            radioButtonLLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonLLG.Text = "LLG";
            // 
            // radioButtonNLG
            // 
            radioButtonNLG.Cursor = Cursors.Hand;
            radioButtonNLG.FlatStyle = FlatStyle.Flat;
            radioButtonNLG.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonNLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonNLG.Location = new Point(radioButtonLLG.Right, 0);
            radioButtonNLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonNLG.Text = "NLG";
            // 
            // radioButtonRLG
            // 
            radioButtonRLG.Cursor = Cursors.Hand;
            radioButtonRLG.FlatStyle = FlatStyle.Flat;
            radioButtonRLG.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonRLG.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonRLG.Location = new Point(radioButtonNLG.Right, 0);
            radioButtonRLG.Size = new Size(TEXTBOX_WIDTH / 3, LABEL_HEIGHT);
            radioButtonRLG.Text = "RLG";
            // 
            // labelMTOGW
            // 
            labelMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMTOGW.Location = new Point(0, radioButtonLLG.Bottom + HEIGHT_INTERVAL);
            labelMTOGW.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMTOGW.Text = "MTO GW:";
            // 
            // textBoxMTOGW
            // 
            textBoxMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMTOGW.Location = new Point(labelMTOGW.Right, radioButtonLLG.Bottom + HEIGHT_INTERVAL);
            textBoxMTOGW.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxMTOGW.MaxLength = 200;
            //
            // panelLandingGear
            // 
            panelLandingGear.Enabled = false;
            panelLandingGear.Location = new Point(MARGIN, checkBoxLandingGear.Bottom + HEIGHT_INTERVAL);
            panelLandingGear.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, LABEL_HEIGHT * 2 + HEIGHT_INTERVAL);
            panelLandingGear.Controls.Add(radioButtonLLG);
            panelLandingGear.Controls.Add(radioButtonNLG);
            panelLandingGear.Controls.Add(radioButtonRLG);
            panelLandingGear.Controls.Add(labelMTOGW);
            panelLandingGear.Controls.Add(textBoxMTOGW);
            //
            // checkBoxIncludeToLandingGearReport
            //
            checkBoxIncludeToLandingGearReport.Cursor = Cursors.Hand;
            checkBoxIncludeToLandingGearReport.FlatStyle = FlatStyle.Flat;
            checkBoxIncludeToLandingGearReport.Font = Css.SimpleLink.Fonts.Font;
            checkBoxIncludeToLandingGearReport.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxIncludeToLandingGearReport.Location = new Point(MARGIN, panelLandingGear.Bottom + HEIGHT_INTERVAL);
            checkBoxIncludeToLandingGearReport.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, LABEL_HEIGHT);
            checkBoxIncludeToLandingGearReport.Text = "Include To Landing Gears Report";
            checkBoxIncludeToLandingGearReport.CheckedChanged += checkBoxIncludeToLandingGearReport_CheckedChanged;
            // 
            // checkBoxAvionicsInventory
            // 
            checkBoxAvionicsInventory.Cursor = Cursors.Hand;
            checkBoxAvionicsInventory.FlatStyle = FlatStyle.Flat;
            checkBoxAvionicsInventory.Font = Css.SimpleLink.Fonts.Font;
            checkBoxAvionicsInventory.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxAvionicsInventory.Location = new Point(WIDTH_INTERVAL, MARGIN);
            checkBoxAvionicsInventory.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxAvionicsInventory.Text = "Avionics Inventory";
            checkBoxAvionicsInventory.CheckedChanged += checkBoxAvionicsInventoryMark_CheckedChanged;
            // 
            // labelAvionicsInventoryRemark
            // 
            labelAvionicsInventoryRemark.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAvionicsInventoryRemark.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAvionicsInventoryRemark.Location = new Point(checkBoxAvionicsInventory.Right, MARGIN);
            labelAvionicsInventoryRemark.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelAvionicsInventoryRemark.Text = "This Component Is Avionics Inventory";
            // 
            // radioButtonInventoryOptional
            // 
            radioButtonInventoryOptional.Cursor = Cursors.Hand;
            radioButtonInventoryOptional.Enabled = false;
            radioButtonInventoryOptional.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryOptional.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInventoryOptional.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryOptional.Location = new Point(labelAvionicsInventoryRemark.Left, checkBoxAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            radioButtonInventoryOptional.Size = new Size(TEXTBOX_WIDTH / 2, LABEL_HEIGHT);
            radioButtonInventoryOptional.Text = "Optional";
            // 
            // radioButtonInventoryRequired
            // 
            radioButtonInventoryRequired.Cursor = Cursors.Hand;
            radioButtonInventoryRequired.Enabled = false;
            radioButtonInventoryRequired.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryRequired.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInventoryRequired.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryRequired.Location = new Point(radioButtonInventoryOptional.Right, checkBoxAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            radioButtonInventoryRequired.Size = new Size(TEXTBOX_WIDTH / 2, LABEL_HEIGHT);
            radioButtonInventoryRequired.Text = "Required";
            // 
            // labelALTPN
            // 
            labelALTPN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelALTPN.Location = new Point(WIDTH_INTERVAL, radioButtonInventoryOptional.Bottom + HEIGHT_INTERVAL);
            labelALTPN.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelALTPN.Text = "ALT P/N:";
            // 
            // textBoxALTPN
            // 
            textBoxALTPN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxALTPN.Location = new Point(labelALTPN.Right, radioButtonInventoryOptional.Bottom + HEIGHT_INTERVAL);
            textBoxALTPN.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxALTPN.MaxLength = 200;
            // 
            // labelHushKit
            // 
            labelHushKit.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHushKit.Location = new Point(WIDTH_INTERVAL, labelALTPN.Bottom + HEIGHT_INTERVAL);
            labelHushKit.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHushKit.Text = "Hush Kit Equipped:";
            // 
            // textBoxHushKit
            // 
            textBoxHushKit.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHushKit.Location = new Point(labelHushKit.Right, textBoxALTPN.Bottom + HEIGHT_INTERVAL);
            textBoxHushKit.Name = "textBoxHushKit";
            textBoxHushKit.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxHushKit.MaxLength = 200;
            // 
            // DetailParametersControl
            // 
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;


            Controls.Add(checkBoxLLP);
            Controls.Add(labelLLPRemark);
            Controls.Add(checkBoxLandingGear);
            Controls.Add(labelLandingGearsRemark);
            Controls.Add(panelLandingGear);
            Controls.Add(checkBoxIncludeToLandingGearReport);
            Controls.Add(checkBoxAvionicsInventory);
            Controls.Add(labelAvionicsInventoryRemark);
            Controls.Add(radioButtonInventoryOptional);
            Controls.Add(radioButtonInventoryRequired);
            Controls.Add(labelALTPN);
            Controls.Add(textBoxALTPN);
            Controls.Add(labelHushKit);
            Controls.Add(textBoxHushKit);
            Controls.Add(labelHushKit);
            Controls.Add(textBoxHushKit);
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
                return ((LLPMark != det.IncludedIntoLLP) ||
                        (AvionicsInventoryMarkType != det.AvionicsInventoryMark) ||
                        (ALTPN != det.AltPN) ||
                        (MTOGW != det.MTOGW));
            }
            return false;
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail != null)
                UpdateInformation(currentDetail);
        }

        #endregion

        #region public void UpdateInformation(TemplateAbstractDetail detail)

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        /// <param name="abstractDetail">Шаблонный агрегат по которому отображается информация</param>
        public void UpdateInformation(TemplateAbstractDetail abstractDetail)
        {
            if (abstractDetail == null) 
                throw new ArgumentNullException("abstractDetail");
            bool permission = abstractDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            if (abstractDetail is TemplateDetail)
            {
                checkBoxLLP.Visible = true;
                labelLLPRemark.Visible = true;
                LandingGearVisible = true;
                checkBoxIncludeToLandingGearReport.Visible = true;
                AvionicsInventoryVisible = true;
                textBoxALTPN.Visible = true;
                labelALTPN.Visible = true;
                textBoxHushKit.Visible = false;
                labelHushKit.Visible = false;
                checkBoxLLP.Enabled = permission;
                checkBoxLandingGear.Enabled = permission;
                checkBoxIncludeToLandingGearReport.Enabled = permission;
                checkBoxAvionicsInventory.Enabled = permission;
                textBoxALTPN.Enabled = permission;

                TemplateDetail detail = (TemplateDetail)abstractDetail;
                LLPMark = detail.IncludedIntoLLP;
                MTOGW = detail.MTOGW;
                LandingGearEnabled = permission;


                AvionicsInventoryMarkType = detail.AvionicsInventoryMark;
                AvionicsInventoryEnabled = permission;

                ALTPN = detail.AltPN;
            }
            else
            {
                checkBoxLLP.Visible = false;
                labelLLPRemark.Visible = false;
                LandingGearVisible = false;
                labelLandingGearsRemark.Visible = false;
                labelMTOGW.Visible = false;
                checkBoxIncludeToLandingGearReport.Visible = false;
                AvionicsInventoryVisible = false;
                labelAvionicsInventoryRemark.Visible = false;
                textBoxALTPN.Visible = false;
                labelALTPN.Visible = false;
                if (abstractDetail is TemplateEngine)
                {
                    labelHushKit.Location = new Point(MARGIN, MARGIN);
                    textBoxHushKit.Location = new Point(labelHushKit.Right, MARGIN);
                    textBoxHushKit.Visible = true;
                    textBoxHushKit.Enabled = permission;
                    labelHushKit.Visible = true;
                    HusKit = abstractDetail.HushKit_;
                }
                else
                {
                    textBoxHushKit.Visible = false;
                    labelHushKit.Visible = false;
                }
            }
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохраняются данные текущего шаблонного агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentDetail != null)
                SaveData(currentDetail);
        }

        #endregion

        #region public void SaveData(TemplateAbstractDetail destinationDetail)

        /// <summary>
        /// Сохраняются данные заданного шаблонного агрегата
        /// </summary>
        /// <param name="abstractDetail">Шаблонный агрегат у которого сохраняются данные</param>
        public void SaveData(TemplateAbstractDetail abstractDetail)
        {
            if (abstractDetail == null) 
                throw new ArgumentNullException("abstractDetail");

            if (abstractDetail is TemplateDetail)
            {
                TemplateDetail detail = (TemplateDetail)abstractDetail;

                detail.IncludedIntoLLP = LLPMark;
                detail.AvionicsInventoryMark = AvionicsInventoryMarkType;
                detail.AltPN = ALTPN;
                detail.MTOGW = MTOGW;
            }
            if (abstractDetail is TemplateEngine)
            {
                abstractDetail.HushKit_ = HusKit;
            }
        }

        #endregion

        #region private void checkBoxLandingGearMark_CheckedChanged(object sender, EventArgs e)

        private void checkBoxLandingGearMark_CheckedChanged(object sender, EventArgs e)
        {
            LandingGearMark = checkBoxLandingGear.Checked;
            if (IncludeToLandingGearReportMark && LandingGearMark)
                checkBoxIncludeToLandingGearReport.Checked = false;
            if (!(radioButtonLLG.Checked) && !(radioButtonNLG.Checked) && !(radioButtonRLG.Checked) && (checkBoxLandingGear.Checked))
                radioButtonNLG.Checked = true;
        }

        #endregion

        #region private void checkBoxIncludeToLandingGearReport_CheckedChanged(object sender, EventArgs e)

        private void checkBoxIncludeToLandingGearReport_CheckedChanged(object sender, EventArgs e)
        {
            if (LandingGearMark && IncludeToLandingGearReportMark)
                checkBoxLandingGear.Checked = false;
        }

        #endregion

        #region private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)

        private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)
        {
            AvionicsInventoryMark = checkBoxAvionicsInventory.Checked;
            if (!(radioButtonInventoryOptional.Checked) && !(radioButtonInventoryRequired.Checked) && (checkBoxAvionicsInventory.Checked))
                radioButtonInventoryOptional.Checked = true;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearAllFields()
        {
            checkBoxLLP.Checked = false;
            checkBoxLandingGear.Checked = false;
            checkBoxIncludeToLandingGearReport.Checked = false;
            checkBoxAvionicsInventory.Checked = false;
            textBoxALTPN.Text = "";
            textBoxHushKit.Text = "";
            textBoxMTOGW.Text = "";
        }

        #endregion

        #endregion


    }
}