using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о шасси шаблонного ВС
    /// </summary>
    public class TemplateLandingGearControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 5);

        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPartNumber = new Label();
        private readonly Label labelTSNCSN = new Label();
        private readonly Label labelMTOGW = new Label();
        private readonly Label labelAmount = new Label();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPartNumber = new TextBox();
        private readonly TextBox textBoxTSNCSN = new TextBox();
        private readonly TextBox textBoxMTOGW = new TextBox();
        private readonly TextBox textBoxAmount = new TextBox();

        private TemplateDetail currentDetail;
        private bool showLabels;

        #endregion

        #region Constructor

        /// <summary>
        /// Элемент управления для отображения информации о шасси шаблонного ВС
        /// </summary>
        public TemplateLandingGearControl(TemplateDetail currentDetail, bool showLabels)
        {
            this.currentDetail = currentDetail;
            this.showLabels = showLabels;
            Size = STANDART_SIZE;
            //
            // labelManufacturer
            //
            labelManufacturer.Location = new Point(0, 0);
            labelManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelManufacturer.Text = "Manufacturer";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelPartNumber
            //
            labelPartNumber.Location = new Point(0, labelManufacturer.Bottom + HEIGHT_INTERVAL);
            labelPartNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPartNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPartNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelPartNumber.Text = "Part Number";
            labelPartNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelTSNCSN
            //
            labelTSNCSN.Location = new Point(0, labelPartNumber.Bottom + HEIGHT_INTERVAL);
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelTSNCSN.Text = "TSN/CSN";
            labelTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMTOGW
            //
            labelMTOGW.Location = new Point(0, labelTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMTOGW.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelMTOGW.Text = "MTO GW";
            labelMTOGW.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelAmount
            //
            labelAmount.Location = new Point(0, labelMTOGW.Bottom + HEIGHT_INTERVAL);
            labelAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAmount.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelAmount.Text = "Amount";
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, 0);
            textBoxManufacturer.BackColor = Color.White;
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPartNumber
            //
            textBoxPartNumber.Location = new Point(TEXT_BOX_WIDTH, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxPartNumber.BackColor = Color.White;
            textBoxPartNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPartNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPartNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxTSNCSN
            //
            textBoxTSNCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxPartNumber.Bottom + HEIGHT_INTERVAL);
            textBoxTSNCSN.BackColor = Color.White;
            textBoxTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxTSNCSN.ReadOnly = true;
            textBoxTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxMTOGW
            //
            textBoxMTOGW.Location = new Point(TEXT_BOX_WIDTH, textBoxTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxMTOGW.BackColor = Color.White;
            textBoxMTOGW.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMTOGW.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMTOGW.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxAmount
            //
            textBoxAmount.Location = new Point(TEXT_BOX_WIDTH, textBoxMTOGW.Bottom + HEIGHT_INTERVAL);
            textBoxAmount.BackColor = Color.White;
            textBoxAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAmount.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);

            Controls.Add(labelManufacturer);
            Controls.Add(labelPartNumber);
            Controls.Add(labelTSNCSN);
            Controls.Add(labelMTOGW);
            Controls.Add(labelAmount);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPartNumber);
            Controls.Add(textBoxTSNCSN);
            Controls.Add(textBoxMTOGW);
            Controls.Add(textBoxAmount);

            UpdateControl();
            HideShowLabels(showLabels);

        }

        #endregion

        #region Properties

        #region public TemplateDetail LandingGear

        /// <summary>
        /// Возвращает или устанавливает шасси
        /// </summary>
        public TemplateDetail LandingGear
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
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

        #region private void HideShowLabels(bool showFieldsLabels)

        /// <summary>
        /// Метод, предназначенный для скрытия названий полей
        /// </summary>
        /// <param name="showFieldsLabels">Нужно ли показывать названия полей</param>
        private void HideShowLabels(bool showFieldsLabels)
        {
            labelManufacturer.Visible = showFieldsLabels;
            labelPartNumber.Visible = showFieldsLabels;
            labelTSNCSN.Visible = showFieldsLabels;
            labelMTOGW.Visible = showFieldsLabels;
            labelAmount.Visible = showFieldsLabels;
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
            textBoxPartNumber.Left = left;
            textBoxTSNCSN.Left = left;
            textBoxMTOGW.Left = left;
            textBoxAmount.Left = left;
        }

        #endregion

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxManufacturer.ReadOnly = !permission;
            textBoxPartNumber.ReadOnly = !permission;
            textBoxMTOGW.ReadOnly = !permission;
            textBoxAmount.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((textBoxManufacturer.Text != currentDetail.Manufacturer) ||
                    (textBoxPartNumber.Text != currentDetail.PartNumber) ||
                    (textBoxMTOGW.Text != currentDetail.MTOGW) ||
                    (textBoxAmount.Text != currentDetail.Amount.ToString()));
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохранаяет данные о шасси
        /// </summary>
        public bool SaveData()
        {
            if (currentDetail == null)
                return false;
            int amount;
            CheckAmount(out amount);
            if (textBoxManufacturer.Text != currentDetail.Manufacturer)
                currentDetail.Manufacturer = textBoxManufacturer.Text;
            if (textBoxPartNumber.Text != currentDetail.PartNumber)
                currentDetail.PartNumber = textBoxPartNumber.Text;
            if (textBoxMTOGW.Text != currentDetail.MTOGW)
                currentDetail.MTOGW = textBoxMTOGW.Text;
            if (textBoxAmount.Text != currentDetail.Amount.ToString())
                currentDetail.Amount = amount;
            

            return true;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о шасси текущего шаблонного ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentDetail == null)
                return;
            textBoxManufacturer.Text = currentDetail.Manufacturer;
            textBoxPartNumber.Text = currentDetail.PartNumber;
            textBoxMTOGW.Text = currentDetail.MTOGW;
            textBoxAmount.Text = currentDetail.Amount.ToString();
                       
            CheckPermission();
        }

        #endregion

        #region public bool CheckAmount()

        ///<summary>
        /// Проверяет значение Amount
        ///</summary>
        ///<returns>Возвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckAmount()
        {
            int amount;
            return CheckAmount(out amount);
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
                MessageBox.Show("Landing Gear Amount. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #endregion

    }
}
