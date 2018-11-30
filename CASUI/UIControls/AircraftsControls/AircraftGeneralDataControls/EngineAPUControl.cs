using System.Drawing;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Management;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о двигателях и ВСУ ВС
    /// </summary>
    public partial class EngineAPUControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private const int MARGIN = 20;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 16 + TOP_MARGIN + BOTTOM_MARGIN);
        
        private readonly Label labelCaption = new Label();
        private readonly Label labelEngineModel = new Label();
        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPosition = new Label();
        private readonly Label labelSerialNumber = new Label();
        private readonly Label labelCompliance = new Label();
        private readonly Label labelComplianceTSN = new Label();
        private readonly Label labelComplianceCSN = new Label();
        private readonly Label labelComplianceDate = new Label();
        private readonly Label labelComplianceWorkType = new Label();
        private readonly Label labelNext = new Label();
        private readonly Label labelNextTSN = new Label();
        private readonly Label labelNextCSN = new Label();
        private readonly Label labelNextDate = new Label();
        private readonly Label labelNextRemains = new Label();
        private readonly Label labelNextWorkType = new Label();
        private readonly TextBox textBoxEngineModel = new TextBox();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPosition = new TextBox();
        private readonly TextBox textBoxSerialNumber = new TextBox();
        private readonly TextBox textBoxComplianceTSN = new TextBox();
        private readonly TextBox textBoxComplianceCSN = new TextBox();
        private readonly TextBox textBoxComplianceDate = new TextBox();
        private readonly TextBox textBoxComplianceWorktype = new TextBox();
        private readonly TextBox textBoxNextTSN = new TextBox();
        private readonly TextBox textBoxNextCSN = new TextBox();
        private readonly TextBox textBoxNextDate = new TextBox();
        private readonly TextBox textBoxNextRemains = new TextBox();
        private readonly TextBox textBoxNextWorkType = new TextBox();

        private BaseDetail currentBaseDetail;
        private bool showLabels;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о двигателях и ВСУ ВС
        /// </summary>
        public EngineAPUControl(BaseDetail currentBaseDetail, bool showLabels, bool showCaption)
        {
            InitializeComponent();
            this.currentBaseDetail = currentBaseDetail;
            this.showLabels = showLabels;
            labelCaption.Visible = showCaption;
            //
            // labelCaption
            //
            labelCaption.Location = new Point(TEXT_BOX_WIDTH, TOP_MARGIN);
            labelCaption.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelCaption.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCaption.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            if (currentBaseDetail != null) 
                labelCaption.Text = "Engine Pos #" + currentBaseDetail.PositionNumber;
            else
                labelCaption.Text = "Engine Pos #";
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            //
            // labelSerialNumber
            //
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelSerialNumber.Text = "Serial Number";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            if (showCaption)
            {
                labelSerialNumber.Location = new Point(0, labelCaption.Bottom + HEIGHT_INTERVAL);
                textBoxSerialNumber.Location = new Point(TEXT_BOX_WIDTH, labelCaption.Bottom + HEIGHT_INTERVAL);
                Size = STANDART_SIZE;
            }
            else
            {
                labelSerialNumber.Location = new Point(0, TOP_MARGIN);
                textBoxSerialNumber.Location = new Point(TEXT_BOX_WIDTH, TOP_MARGIN);
                Size = new Size(STANDART_SIZE.Width, STANDART_SIZE.Height - HEIGHT_INTERVAL - TEXT_BOX_HEIGHT);
            }

            //
            // labelEngineModel
            //
            labelEngineModel.Location = new Point(0, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelEngineModel.Text = "Engine Model";
            labelEngineModel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelManufacturer
            //
            labelManufacturer.Location = new Point(0, labelEngineModel.Bottom + HEIGHT_INTERVAL);
            labelManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelManufacturer.Text = "Manufacturer";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelPosition
            //
            labelPosition.Location = new Point(0, labelManufacturer.Bottom + HEIGHT_INTERVAL);
            labelPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelPosition.Text = "Position";
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCompliance
            //
            labelCompliance.Location = new Point(0, labelPosition.Bottom + HEIGHT_INTERVAL);
            labelCompliance.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCompliance.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelCompliance.Text = "Compliance";
            labelCompliance.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceTSN
            //
            labelComplianceTSN.Location = new Point(MARGIN, labelCompliance.Bottom + HEIGHT_INTERVAL);
            labelComplianceTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceTSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceTSN.Text = "TSN";
            labelComplianceTSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceCSN
            //
            labelComplianceCSN.Location = new Point(MARGIN, labelComplianceTSN.Bottom + HEIGHT_INTERVAL);
            labelComplianceCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceCSN.Text = "CSN";
            labelComplianceCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceDate
            //
            labelComplianceDate.Location = new Point(MARGIN, labelComplianceCSN.Bottom + HEIGHT_INTERVAL);
            labelComplianceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceDate.Text = "Date";
            labelComplianceDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceWorkType
            //
            labelComplianceWorkType.Location = new Point(MARGIN, labelComplianceDate.Bottom + HEIGHT_INTERVAL);
            labelComplianceWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceWorkType.Text = "Work Type";
            labelComplianceWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNext
            //
            labelNext.Location = new Point(0, labelComplianceWorkType.Bottom + HEIGHT_INTERVAL);
            labelNext.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNext.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNext.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelNext.Text = "Next";
            labelNext.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextTSN
            //
            labelNextTSN.Location = new Point(MARGIN, labelNext.Bottom + HEIGHT_INTERVAL);
            labelNextTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextTSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextTSN.Text = "TSN";
            labelNextTSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextCSN
            //
            labelNextCSN.Location = new Point(MARGIN, labelNextTSN.Bottom + HEIGHT_INTERVAL);
            labelNextCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextCSN.Text = "CSN";
            labelNextCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextDate
            //
            labelNextDate.Location = new Point(MARGIN, labelNextCSN.Bottom + HEIGHT_INTERVAL);
            labelNextDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextDate.Text = "Date";
            labelNextDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextRemains.Location = new Point(MARGIN, labelNextDate.Bottom + HEIGHT_INTERVAL);
            labelNextRemains.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextRemains.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextRemains.Text = "Remains";
            labelNextRemains.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextWorkType.Location = new Point(MARGIN, labelNextRemains.Bottom + HEIGHT_INTERVAL);
            labelNextWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextWorkType.Text = "Work Type";
            labelNextWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxEngineModel
            //
            textBoxEngineModel.Location = new Point(TEXT_BOX_WIDTH, textBoxSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, textBoxEngineModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPosition
            //
            textBoxPosition.Location = new Point(TEXT_BOX_WIDTH, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceTSN
            //
            textBoxComplianceTSN.Location = new Point(TEXT_BOX_WIDTH, labelCompliance.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceTSN.BackColor = Color.White;
            textBoxComplianceTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceTSN.ReadOnly = true;
            textBoxComplianceTSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceCSN
            //
            textBoxComplianceCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceTSN.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceCSN.BackColor = Color.White;
            textBoxComplianceCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceCSN.ReadOnly = true;
            textBoxComplianceCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceDate
            //
            textBoxComplianceDate.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceCSN.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceDate.BackColor = Color.White;
            textBoxComplianceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceDate.ReadOnly = true;
            textBoxComplianceDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceWorktype
            //
            textBoxComplianceWorktype.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceDate.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceWorktype.BackColor = Color.White;
            textBoxComplianceWorktype.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceWorktype.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceWorktype.ReadOnly = true;
            textBoxComplianceWorktype.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextTSN
            //
            textBoxNextTSN.Location = new Point(TEXT_BOX_WIDTH, labelNext.Bottom + HEIGHT_INTERVAL);
            textBoxNextTSN.BackColor = Color.White;
            textBoxNextTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextTSN.ReadOnly = true;
            textBoxNextTSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextCSN
            //
            textBoxNextCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxNextTSN.Bottom + HEIGHT_INTERVAL);
            textBoxNextCSN.BackColor = Color.White;
            textBoxNextCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextCSN.ReadOnly = true;
            textBoxNextCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextDate
            //
            textBoxNextDate.Location = new Point(TEXT_BOX_WIDTH, textBoxNextCSN.Bottom + HEIGHT_INTERVAL);
            textBoxNextDate.BackColor = Color.White;
            textBoxNextDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextDate.ReadOnly = true;
            textBoxNextDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextRemains
            //
            textBoxNextRemains.Location = new Point(TEXT_BOX_WIDTH, textBoxNextDate.Bottom + HEIGHT_INTERVAL);
            textBoxNextRemains.BackColor = Color.White;
            textBoxNextRemains.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextRemains.ReadOnly = true;
            textBoxNextRemains.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextWorkType
            //
            textBoxNextWorkType.Location = new Point(TEXT_BOX_WIDTH, textBoxNextRemains.Bottom + HEIGHT_INTERVAL);
            textBoxNextWorkType.BackColor = Color.White;
            textBoxNextWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextWorkType.ReadOnly = true;
            textBoxNextWorkType.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);

            Controls.Add(labelCaption);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelEngineModel);
            Controls.Add(labelManufacturer);
            Controls.Add(labelPosition);
            Controls.Add(labelCompliance);
            Controls.Add(labelComplianceTSN);
            Controls.Add(labelComplianceCSN);
            Controls.Add(labelComplianceDate);
            Controls.Add(labelComplianceWorkType);
            Controls.Add(labelNext);
            Controls.Add(labelNextTSN);
            Controls.Add(labelNextCSN);
            Controls.Add(labelNextDate);
            Controls.Add(labelNextRemains);
            Controls.Add(labelNextWorkType);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(textBoxEngineModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPosition);
            Controls.Add(textBoxComplianceTSN);
            Controls.Add(textBoxComplianceCSN);
            Controls.Add(textBoxComplianceDate);
            Controls.Add(textBoxComplianceWorktype);
            Controls.Add(textBoxNextTSN);
            Controls.Add(textBoxNextCSN);
            Controls.Add(textBoxNextDate);
            Controls.Add(textBoxNextRemains);
            Controls.Add(textBoxNextWorkType);

            UpdateControl();
            HideShowLabels(showLabels);

        }

        #endregion

        #region Properties

        #region public BaseDetail BaseDetail

        /// <summary>
        /// Возвращает или устанавливает текущий базовый агрегат
        /// </summary>
        public BaseDetail BaseDetail
        {
            get
            {
                return currentBaseDetail;
            }
            set
            {
                currentBaseDetail = value;
                UpdateControl();
            }
        }

        #endregion
        
        #region public static Size StandartSize

        /// <summary>
        /// Возвращает стандартный размер данного элемента управления
        /// </summary>
        public static Size StandartSize
        {
            get
            {
                return STANDART_SIZE;
            }
        }

        #endregion

        #region public bool ShowLabels

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать названия полей
        /// </summary>
        public bool ShowLabels
        {
            get
            {
                return showLabels;
            }
            set
            {
                showLabels = value;
                HideShowLabels(value);
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void HideShowLabels(bool showLabels)

        /// <summary>
        /// Метод, предназначенный для скрытия названий полей
        /// </summary>
        /// <param name="showTextBoxNames">Нужно ли показывать названия полей</param>
        private void HideShowLabels(bool showTextBoxNames)
        {
            labelEngineModel.Visible = showTextBoxNames;
            labelManufacturer.Visible = showTextBoxNames;
            labelPosition.Visible = showTextBoxNames;
            labelSerialNumber.Visible = showTextBoxNames;
            labelCompliance.Visible = showTextBoxNames;
            labelComplianceTSN.Visible = showTextBoxNames;
            labelComplianceCSN.Visible = showTextBoxNames;
            labelComplianceDate.Visible = showTextBoxNames;
            labelComplianceWorkType.Visible = showTextBoxNames;
            labelNext.Visible = showTextBoxNames;
            labelNextTSN.Visible = showTextBoxNames;
            labelNextCSN.Visible = showTextBoxNames;
            labelNextDate.Visible = showTextBoxNames;
            labelNextRemains.Visible = showTextBoxNames;
            labelNextWorkType.Visible = showTextBoxNames;
            if (showTextBoxNames)
            {
                textBoxEngineModel.Left = TEXT_BOX_WIDTH;
                textBoxManufacturer.Left = TEXT_BOX_WIDTH;
                textBoxPosition.Left = TEXT_BOX_WIDTH;
                textBoxSerialNumber.Left = TEXT_BOX_WIDTH;
                textBoxComplianceTSN.Left = TEXT_BOX_WIDTH;
                textBoxComplianceCSN.Left = TEXT_BOX_WIDTH;
                textBoxComplianceDate.Left = TEXT_BOX_WIDTH;
                textBoxComplianceWorktype.Left = TEXT_BOX_WIDTH;
                textBoxNextTSN.Left = TEXT_BOX_WIDTH;
                textBoxNextCSN.Left = TEXT_BOX_WIDTH;
                textBoxNextDate.Left = TEXT_BOX_WIDTH;
                textBoxNextRemains.Left = TEXT_BOX_WIDTH;
                textBoxNextWorkType.Left = TEXT_BOX_WIDTH;
                labelCaption.Left = TEXT_BOX_WIDTH;
                Width = STANDART_SIZE.Width;
            }
            else
            {
                textBoxEngineModel.Left = 0;
                textBoxManufacturer.Left = 0;
                textBoxPosition.Left = 0;
                textBoxSerialNumber.Left = 0;
                textBoxComplianceTSN.Left = 0;
                textBoxComplianceCSN.Left = 0;
                textBoxComplianceDate.Left = 0;
                textBoxComplianceWorktype.Left = 0;
                textBoxNextTSN.Left = 0;
                textBoxNextCSN.Left = 0;
                textBoxNextDate.Left = 0;
                textBoxNextRemains.Left = 0;
                textBoxNextWorkType.Left = 0;
                labelCaption.Left = 0;
                Width = TEXT_BOX_WIDTH;
            }

        }

        #endregion

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentBaseDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxEngineModel.ReadOnly = !permission;
            textBoxManufacturer.ReadOnly = !permission;
            textBoxPosition.ReadOnly = !permission;
            textBoxSerialNumber.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего базового агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentBaseDetail == null)
                return;
            if (textBoxEngineModel.Text != currentBaseDetail.Model)
                currentBaseDetail.Model = textBoxEngineModel.Text;
            if (textBoxManufacturer.Text != currentBaseDetail.Manufacturer)
                currentBaseDetail.Manufacturer = textBoxManufacturer.Text;
            if (textBoxPosition.Text != currentBaseDetail.PositionNumber)
                currentBaseDetail.PositionNumber = textBoxPosition.Text;
            if (textBoxSerialNumber.Text != currentBaseDetail.SerialNumber)
                currentBaseDetail.SerialNumber = textBoxSerialNumber.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о базовом агрегате текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentBaseDetail == null)
                return;
            textBoxSerialNumber.Text = currentBaseDetail.SerialNumber;
            textBoxEngineModel.Text = currentBaseDetail.Model;
            textBoxManufacturer.Text = currentBaseDetail.Manufacturer;
            textBoxPosition.Text = currentBaseDetail.PositionNumber;

            if (currentBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceTSN.Text = currentBaseDetail.Limitation.LastPerformance.Lifelength.Hours.ToString();
            if (currentBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceCSN.Text = currentBaseDetail.Limitation.LastPerformance.Lifelength.Cycles.ToString();
            if (currentBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceDate.Text = currentBaseDetail.Limitation.LastPerformance.RecordsAddDate.ToString("MMM dd,yyyy");
            if (currentBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceWorktype.Text = currentBaseDetail.Limitation.LastPerformance.DetailRecordType.FullName;
            textBoxNextTSN.Text = currentBaseDetail.Limitation.NextPerformance.Hours.ToString();
            textBoxNextCSN.Text = currentBaseDetail.Limitation.NextPerformance.Cycles.ToString();
            textBoxNextDate.Text = currentBaseDetail.Limitation.NextPerformance.Calendar.ToString();
            textBoxNextRemains.Text = currentBaseDetail.Limitation.LeftTillNextPerformance.ToString();
            textBoxNextWorkType.Text = "Пока нет";

            CheckPermission();
        }

        #endregion

        #endregion

    }
}
