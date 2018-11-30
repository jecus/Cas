using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о шаблонных двигателях и ВСУ ВС
    /// </summary>
    public class TemplateEngineControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        
        private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 6 + TOP_MARGIN + BOTTOM_MARGIN);
        
        private readonly Label labelEngineModel = new Label();
        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPartNumber = new Label();
        private readonly Label labelAmount = new Label();
        private readonly Label labelTSNCSN = new Label();
        private readonly TextBox textBoxEngineModel = new TextBox();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPartNumber = new TextBox();
        private readonly TextBox textBoxTSNCSN = new TextBox();
        private readonly TextBox textBoxAmount = new TextBox();
        private readonly ReferenceLinkLabel linkViewInfo = new ReferenceLinkLabel();
        private TemplateBaseDetail currentBaseDetail;
        private bool showLabels;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонных двигателях и ВСУ ВС
        /// </summary>
        public TemplateEngineControl(TemplateBaseDetail currentBaseDetail, bool showLabels)
        {
            this.currentBaseDetail = currentBaseDetail;
            this.showLabels = showLabels;
            //
            // labelEngineModel
            //
            labelEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineModel.Size = new Size(TEXT_BOX_WIDTH, TOP_MARGIN);
            labelEngineModel.Text = "Engine Model";
            labelEngineModel.TextAlign = ContentAlignment.MiddleLeft;
            labelEngineModel.Location = new Point(0, TOP_MARGIN);
            Size = new Size(STANDART_SIZE.Width, STANDART_SIZE.Height - HEIGHT_INTERVAL - TEXT_BOX_HEIGHT);
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
            // labelAmount
            //
            labelAmount.Location = new Point(0, labelTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAmount.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelAmount.Text = "Amount";
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxEngineModel
            //
            textBoxEngineModel.Location = new Point(TEXT_BOX_WIDTH, TOP_MARGIN);
            textBoxEngineModel.BackColor = Color.White;
            textBoxEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, textBoxEngineModel.Bottom + HEIGHT_INTERVAL);
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
            // textBoxAmount
            //
            textBoxAmount.Location = new Point(TEXT_BOX_WIDTH, textBoxTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxAmount.BackColor = Color.White;
            textBoxAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAmount.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // linkViewInfo
            //
            linkViewInfo.Location = new Point(0, textBoxAmount.Bottom + HEIGHT_INTERVAL);
            linkViewInfo.Font = Css.SimpleLink.Fonts.Font;
            linkViewInfo.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkViewInfo.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            linkViewInfo.Text = "View Info";
            linkViewInfo.TextAlign = ContentAlignment.MiddleLeft;
            linkViewInfo.ReflectionType = ReflectionTypes.DisplayInNew;
            //linkViewInfo.DisplayerText = "Templates. " + currentBaseDetail.ParentAircraft.Model + ". Component PN " + currentBaseDetail.PartNumber;
            linkViewInfo.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". Component PN " + currentBaseDetail.PartNumber;
            linkViewInfo.DisplayerRequested += linkViewInfo_DisplayerRequested;

            

            Controls.Add(labelEngineModel);
            Controls.Add(labelManufacturer);
            Controls.Add(labelPartNumber);
            Controls.Add(labelTSNCSN);
            Controls.Add(labelAmount);
            Controls.Add(textBoxEngineModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPartNumber);
            Controls.Add(textBoxTSNCSN);
            Controls.Add(textBoxAmount);
            Controls.Add(linkViewInfo);

            UpdateControl();
            HideShowLabels(showLabels);

        }
        

        #endregion

        #region Properties

        #region public TemplateBaseDetail BaseDetail

        /// <summary>
        /// Возвращает или устанавливает текущий шаблонный базовый агрегат
        /// </summary>
        public TemplateBaseDetail BaseDetail
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
            labelPartNumber.Visible = showTextBoxNames;
            labelTSNCSN.Visible = showTextBoxNames;
            labelAmount.Visible = showTextBoxNames;
            int left;
            if (showTextBoxNames)
            {
                left = TEXT_BOX_WIDTH;
                Width = STANDART_SIZE.Width;
            }
            else
            {
                left = 0;
                Width = TEXT_BOX_WIDTH;
            }
            textBoxEngineModel.Left = left;
            textBoxManufacturer.Left = left;
            textBoxPartNumber.Left = left;
            textBoxTSNCSN.Left = left;
            textBoxAmount.Left = left;
            linkViewInfo.Left = left;
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
            textBoxPartNumber.ReadOnly = !permission;
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
            return ((textBoxEngineModel.Text != currentBaseDetail.Model) ||
                    (textBoxManufacturer.Text != currentBaseDetail.Manufacturer) ||
                    (textBoxPartNumber.Text != currentBaseDetail.PartNumber) ||
                    (textBoxAmount.Text != currentBaseDetail.Amount.ToString()));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного базового агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentBaseDetail == null)
                return;
            int amount;
            CheckAmount(out amount);
            if (textBoxEngineModel.Text != currentBaseDetail.Model)
                currentBaseDetail.Model = textBoxEngineModel.Text;
            if (textBoxManufacturer.Text != currentBaseDetail.Manufacturer)
                currentBaseDetail.Manufacturer = textBoxManufacturer.Text;
            if (textBoxPartNumber.Text != currentBaseDetail.PartNumber)
                currentBaseDetail.PartNumber = textBoxPartNumber.Text;
            if (textBoxAmount.Text != currentBaseDetail.Amount.ToString())
                currentBaseDetail.Amount = amount;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о шаблонном базовом агрегате текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentBaseDetail == null)
                return;
            textBoxEngineModel.Text = currentBaseDetail.Model;
            textBoxManufacturer.Text = currentBaseDetail.Manufacturer;
            textBoxPartNumber.Text = currentBaseDetail.PartNumber;
            textBoxAmount.Text = currentBaseDetail.Amount.ToString();
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
                MessageBox.Show("Engine Amount. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void linkViewInfo_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkViewInfo_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredTemplateDetailScreen(currentBaseDetail);
        }

        #endregion

        #endregion

    }
}
