using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о шасси ВС
    /// </summary>
    public partial class LandingGearControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private const int MARGIN = 20;
        //private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 16);
        private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 7);

        private readonly Label labelCaption = new Label();
        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPosition = new Label();
        private readonly Label labelPartNumber = new Label();
        private readonly Label labelSerialNumber = new Label();
        private readonly Label labelTSNCSN = new Label();
        private readonly Label labelCompliance = new Label();
        private readonly Label labelComplianceTSNCSN = new Label();
        private readonly Label labelComplianceDate = new Label();
        private readonly Label labelComplianceWorkType = new Label();
        private readonly Label labelNext = new Label();
        private readonly Label labelNextTSNCSN = new Label();
        private readonly Label labelNextDate = new Label();
        private readonly Label labelNextRemains = new Label();
        private readonly Label labelNextWorkType = new Label();
        private readonly Label labelMTOGW = new Label();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPosition = new TextBox();
        private readonly TextBox textBoxPartNumber = new TextBox();
        private readonly TextBox textBoxSerialNumber = new TextBox();
        private readonly TextBox textBoxTSNCSN = new TextBox();
        private readonly TextBox textBoxComplianceTSNCSN = new TextBox();
        private readonly TextBox textBoxComplianceDate = new TextBox();
        private readonly TextBox textBoxComplianceWorktype = new TextBox();
        private readonly TextBox textBoxNextTSNCSN = new TextBox();
        private readonly TextBox textBoxNextDate = new TextBox();
        private readonly TextBox textBoxNextRemains = new TextBox();
        private readonly TextBox textBoxNextWorkType = new TextBox();
        private readonly TextBox textBoxMTOGW = new TextBox();

        private GearAssembly currentGearAssembly;
        private DateTime dateAsOf;
        private bool showLabels;

        #endregion

        #region Constructor

        /// <summary>
        /// Элемент управления для отображения информации о шасси ВС
        /// </summary>
        public LandingGearControl(GearAssembly gearAssembly, DateTime dateAsOf, bool showLabels)
        {
            currentGearAssembly = gearAssembly;
            this.dateAsOf = dateAsOf;
            this.showLabels = showLabels;
            Size = STANDART_SIZE;
            //
            // labelCaption
            //
            labelCaption.Location = new Point(TEXT_BOX_WIDTH, 0);
            labelCaption.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelCaption.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCaption.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            if (currentGearAssembly != null)
                labelCaption.Text = "Pos #" + currentGearAssembly.PositionNumber;
            else
                labelCaption.Text = "Pos #";
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            //
            // labelManufacturer
            //
            labelManufacturer.Location = new Point(0, labelCaption.Bottom + HEIGHT_INTERVAL);
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
            // labelPartNumber
            //
            labelPartNumber.Location = new Point(0, labelPosition.Bottom + HEIGHT_INTERVAL);
            labelPartNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPartNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPartNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelPartNumber.Text = "Part Number";
            labelPartNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelSerialNumber
            //
            labelSerialNumber.Location = new Point(0, labelPartNumber.Bottom + HEIGHT_INTERVAL);
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelSerialNumber.Text = "Serial Number";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelTSNCSN
            //
            labelTSNCSN.Location = new Point(0, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelTSNCSN.Text = "TSN/CSN";
            labelTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCompliance
            //
            labelCompliance.Location = new Point(0, labelTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelCompliance.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCompliance.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelCompliance.Text = "Compliance";
            labelCompliance.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceTSNCSN
            //
            labelComplianceTSNCSN.Location = new Point(MARGIN, labelCompliance.Bottom + HEIGHT_INTERVAL);
            labelComplianceTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceTSNCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceTSNCSN.Text = "TSN/CSN";
            labelComplianceTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceDate
            //
            labelComplianceDate.Location = new Point(MARGIN, labelComplianceTSNCSN.Bottom + HEIGHT_INTERVAL);
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
            // labelNextTSNCSN
            //
            labelNextTSNCSN.Location = new Point(MARGIN, labelNext.Bottom + HEIGHT_INTERVAL);
            labelNextTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextTSNCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextTSNCSN.Text = "TSN/CSN";
            labelNextTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextDate
            //
            labelNextDate.Location = new Point(MARGIN, labelNextTSNCSN.Bottom + HEIGHT_INTERVAL);
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
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, labelCaption.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.BackColor = Color.White;
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPosition
            //
            textBoxPosition.Location = new Point(TEXT_BOX_WIDTH, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxPosition.BackColor = Color.White;
            textBoxPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPartNumber
            //
            textBoxPartNumber.Location = new Point(TEXT_BOX_WIDTH, textBoxPosition.Bottom + HEIGHT_INTERVAL);
            textBoxPartNumber.BackColor = Color.White;
            textBoxPartNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPartNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPartNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Location = new Point(TEXT_BOX_WIDTH, textBoxPartNumber.Bottom + HEIGHT_INTERVAL);
            textBoxSerialNumber.BackColor = Color.White;
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxTSNCSN
            //
            textBoxTSNCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxTSNCSN.BackColor = Color.White;
            textBoxTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxTSNCSN.ReadOnly = true;
            textBoxTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceTSNCSN
            //
            textBoxComplianceTSNCSN.Location = new Point(TEXT_BOX_WIDTH, labelCompliance.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceTSNCSN.BackColor = Color.White;
            textBoxComplianceTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceTSNCSN.ReadOnly = true;
            textBoxComplianceTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceDate
            //
            textBoxComplianceDate.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceTSNCSN.Bottom + HEIGHT_INTERVAL);
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
            // textBoxNextTSNCSN
            //
            textBoxNextTSNCSN.Location = new Point(TEXT_BOX_WIDTH, labelNext.Bottom + HEIGHT_INTERVAL);
            textBoxNextTSNCSN.BackColor = Color.White;
            textBoxNextTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextTSNCSN.ReadOnly = true;
            textBoxNextTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextDate
            //
            textBoxNextDate.Location = new Point(TEXT_BOX_WIDTH, textBoxNextTSNCSN.Bottom + HEIGHT_INTERVAL);
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
            //
            // labelMTOGW
            //
            //labelMTOGW.Location = new Point(0, labelNextWorkType.Bottom + HEIGHT_INTERVAL);
            labelMTOGW.Location = new Point(0, textBoxTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMTOGW.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelMTOGW.Text = "MTO GW";
            labelMTOGW.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxMTOGW
            //
         //   textBoxMTOGW.Location = new Point(TEXT_BOX_WIDTH, textBoxNextWorkType.Bottom + HEIGHT_INTERVAL);
            textBoxMTOGW.Location = new Point(TEXT_BOX_WIDTH, textBoxTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxMTOGW.BackColor = Color.White;
            textBoxMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMTOGW.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);

            Controls.Add(labelCaption);
            Controls.Add(labelManufacturer);
            Controls.Add(labelPosition);
            Controls.Add(labelPartNumber);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelTSNCSN);
/*            Controls.Add(labelCompliance);
            Controls.Add(labelComplianceTSNCSN);
            Controls.Add(labelComplianceDate);
            Controls.Add(labelComplianceWorkType);
            Controls.Add(labelNext);
            Controls.Add(labelNextTSNCSN);
            Controls.Add(labelNextDate);
            Controls.Add(labelNextRemains);
            Controls.Add(labelNextWorkType);*/
            Controls.Add(labelMTOGW);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPosition);
            Controls.Add(textBoxPartNumber);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(textBoxTSNCSN);
/*            Controls.Add(textBoxComplianceTSNCSN);
            Controls.Add(textBoxComplianceDate);
            Controls.Add(textBoxComplianceWorktype);
            Controls.Add(textBoxNextTSNCSN);
            Controls.Add(textBoxNextDate);
            Controls.Add(textBoxNextRemains);
            Controls.Add(textBoxNextWorkType);*/
            Controls.Add(textBoxMTOGW);

            UpdateControl();
            HideShowLabels(showLabels);

        }

        #endregion

        #region Properties

        #region public GearAssembly LandingGear

        /// <summary>
        /// Возвращает или устанавливает шасси
        /// </summary>
        public GearAssembly LandingGear
        {
            get
            {
                return currentGearAssembly;
            }
            set
            {
                currentGearAssembly = value;
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

        #region public DateTime DateAsOf

        /// <summary>
        /// Возвращает или устанавливает дату DateAsOf
        /// </summary>
        public DateTime DateAsOf
        {
            get
            {
                return dateAsOf;
            }
            set
            {
                dateAsOf = value;
                UpdateDateAsOf();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void HideShowLabels(bool showFieldsLabels)

        /// <summary>
        /// Метод, предназначенный для скрытия названий полей
        /// </summary>
        /// <param name="showFieldsLabels">Нужно ли показывать названия полей</param>
        private void HideShowLabels(bool showFieldsLabels)
        {
            labelManufacturer.Visible = showFieldsLabels;
            labelPosition.Visible = showFieldsLabels;
            labelPartNumber.Visible = showFieldsLabels;
            labelSerialNumber.Visible = showFieldsLabels;
            labelTSNCSN.Visible = showFieldsLabels;
            labelCompliance.Visible = showFieldsLabels;
            labelComplianceTSNCSN.Visible = showFieldsLabels;
            labelComplianceDate.Visible = showFieldsLabels;
            labelComplianceWorkType.Visible = showFieldsLabels;
            labelNext.Visible = showFieldsLabels;
            labelNextTSNCSN.Visible = showFieldsLabels;
            labelNextDate.Visible = showFieldsLabels;
            labelNextRemains.Visible = showFieldsLabels;
            labelNextWorkType.Visible = showFieldsLabels;
            labelMTOGW.Visible = showFieldsLabels;
            int left;
            if (showFieldsLabels)
            {
                left = TEXT_BOX_WIDTH;
                Width = STANDART_SIZE.Width;
            }
            else
            {
                left = 0;
                Width = TEXT_BOX_WIDTH;
            }

            textBoxManufacturer.Left = left;
            textBoxPosition.Left = left;
            textBoxPartNumber.Left = left;
            textBoxSerialNumber.Left = left;
            textBoxTSNCSN.Left = left;
            textBoxComplianceTSNCSN.Left = left;
            textBoxComplianceDate.Left = left;
            textBoxComplianceWorktype.Left = left;
            textBoxNextTSNCSN.Left = left;
            textBoxNextDate.Left = left;
            textBoxNextRemains.Left = left;
            textBoxNextWorkType.Left = left;
            textBoxMTOGW.Left = left;
            labelCaption.Left = left;
        }

        #endregion

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentGearAssembly.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxManufacturer.ReadOnly = !permission;
            textBoxPosition.ReadOnly = !permission;
            textBoxPartNumber.ReadOnly = !permission;
            textBoxSerialNumber.ReadOnly = !permission;
            textBoxMTOGW.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((textBoxManufacturer.Text != currentGearAssembly.Manufacturer) ||
                    (textBoxPosition.Text != currentGearAssembly.PositionNumber) ||
                    (textBoxPartNumber.Text != currentGearAssembly.PartNumber) ||
                    (textBoxSerialNumber.Text != currentGearAssembly.SerialNumber) ||
                    (textBoxMTOGW.Text != currentGearAssembly.MTOGW));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные о шасси
        /// </summary>
        public void SaveData()
        {
            if (currentGearAssembly == null)
                return;
            if (textBoxManufacturer.Text != currentGearAssembly.Manufacturer)
                currentGearAssembly.Manufacturer = textBoxManufacturer.Text;
            if (textBoxPosition.Text != currentGearAssembly.PositionNumber)
            {
                TransferRecord transferRecord = currentGearAssembly.GetLastTransferRecord();
                transferRecord.Position = textBoxPosition.Text;
                transferRecord.Save();
            }
            if (textBoxPartNumber.Text != currentGearAssembly.PartNumber)
                currentGearAssembly.PartNumber = textBoxPartNumber.Text;
            if (textBoxSerialNumber.Text != currentGearAssembly.SerialNumber)
                currentGearAssembly.SerialNumber = textBoxSerialNumber.Text;
            if (textBoxMTOGW.Text != currentGearAssembly.MTOGW)
                currentGearAssembly.MTOGW = textBoxMTOGW.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о шасси текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentGearAssembly == null)
                return;
            textBoxManufacturer.Text = currentGearAssembly.Manufacturer;
            textBoxPosition.Text = currentGearAssembly.PositionNumber;
            textBoxPartNumber.Text = currentGearAssembly.PartNumber;
            textBoxSerialNumber.Text = currentGearAssembly.SerialNumber;
            textBoxTSNCSN.Text = currentGearAssembly.Lifelength.ToComplianceItemString();
            textBoxMTOGW.Text = currentGearAssembly.MTOGW;
            //UpdateDateAsOf();
            
            CheckPermission();
        }

        #endregion

        #region private void UpdateDateAsOf()

        private void UpdateDateAsOf()
        {
/*
            Detail clonedDetail;
            object objectClone = currentGearAssembly.CloneAsDateOf(dateAsOf);
            if (!(objectClone is Detail))
                return;
            clonedDetail = (Detail)objectClone;
            textBoxTSNCSN.Text = clonedDetail.Lifelength.ToComplianceItemString();
            if (clonedDetail.Limitation.LastPerformance != null)
                textBoxComplianceTSNCSN.Text = clonedDetail.Limitation.LastPerformance.Lifelength.ToComplianceItemString();
            else
                textBoxComplianceTSNCSN.Text = "";
            if (clonedDetail.Limitation.LastPerformance != null)
                textBoxComplianceDate.Text = clonedDetail.Limitation.LastPerformance.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString());
            else
                textBoxComplianceDate.Text = "";
            if (clonedDetail.Limitation.LastPerformance != null)
                textBoxComplianceWorktype.Text = clonedDetail.Limitation.LastPerformance.RecordType.FullName;
            else
                textBoxComplianceWorktype.Text = "";
            textBoxNextTSNCSN.Text = clonedDetail.Limitation.NextPerformance.ToComplianceItemString();
            textBoxNextDate.Text = UsefulMethods.NormalizeDate(clonedDetail.Limitation.NextPerformanceDate);
            textBoxNextRemains.Text = clonedDetail.Limitation.LeftTillNextPerformance.ToComplianceItemStringFull();
            if (clonedDetail.Limitation.NextWorkType != null)
                textBoxNextWorkType.Text = clonedDetail.Limitation.NextWorkType.FullName;
            else
                textBoxNextWorkType.Text = ""; todo
*/
        }

        #endregion

        #endregion



    }
}
