using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения дополнительной информации
    /// </summary>
    public class OtherControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int LABEL_WIDTH = 150;
        private const int TEXT_BOX_WIDTH = 250;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        
        private readonly Label labelDeliveryDate = new Label();
        private readonly Label labelAcceptanceDate = new Label();
        private readonly DateTimePicker dateTimePickerDeliveryDate = new DateTimePicker();
        private readonly DateTimePicker dateTimePickerAcceptanceDate = new DateTimePicker();
        
        private Aircraft currentAircraft;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения дополнительной информации
        /// </summary>
        public OtherControl(Aircraft currentAircraft)
        {
            Size = new Size(TEXT_BOX_WIDTH + LABEL_WIDTH, 2 * TEXT_BOX_HEIGHT + HEIGHT_INTERVAL + TOP_MARGIN + BOTTOM_MARGIN);
            this.currentAircraft = currentAircraft;
            //
            // labelDeliveryDate
            //
            labelDeliveryDate.Location = new Point(0, TOP_MARGIN);
            labelDeliveryDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDeliveryDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDeliveryDate.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelDeliveryDate.Text = "Delivery Date:";
            labelDeliveryDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDeliveryDate
            //
            dateTimePickerDeliveryDate.Location = new Point(LABEL_WIDTH, TOP_MARGIN);
            dateTimePickerDeliveryDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerDeliveryDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDeliveryDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            dateTimePickerDeliveryDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDeliveryDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelAcceptanceDate
            //
            labelAcceptanceDate.Location = new Point(0, labelDeliveryDate.Bottom + HEIGHT_INTERVAL);
            labelAcceptanceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAcceptanceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAcceptanceDate.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAcceptanceDate.Text = "Acceptance Date:";
            labelAcceptanceDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerAcceptanceDate
            //
            dateTimePickerAcceptanceDate.Location = new Point(LABEL_WIDTH, labelDeliveryDate.Bottom + HEIGHT_INTERVAL);
            dateTimePickerAcceptanceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerAcceptanceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerAcceptanceDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            dateTimePickerAcceptanceDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerAcceptanceDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();

            Controls.Add(labelDeliveryDate);
            Controls.Add(dateTimePickerDeliveryDate);
            Controls.Add(labelAcceptanceDate);
            Controls.Add(dateTimePickerAcceptanceDate);
            
            UpdateControl();
        }

        #endregion

        #region Methods

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            dateTimePickerAcceptanceDate.Enabled = permission;
            dateTimePickerDeliveryDate.Enabled = permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((dateTimePickerAcceptanceDate.Value != currentAircraft.AcceptanceDate) ||
                    (dateTimePickerDeliveryDate.Value != currentAircraft.DeliveryDate));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного ВС
        /// </summary>
        public void SaveData()
        {
            if (dateTimePickerAcceptanceDate.Value != currentAircraft.AcceptanceDate)
                currentAircraft.AcceptanceDate = dateTimePickerAcceptanceDate.Value;
            if (dateTimePickerDeliveryDate.Value != currentAircraft.DeliveryDate)
                currentAircraft.DeliveryDate = dateTimePickerDeliveryDate.Value;
        }

        #endregion

        #region public void UpdateControl()

        /// <summary>
        /// Обновляет информацию о базовом агрегате текущего ВС
        /// </summary>
        public void UpdateControl()
        {
            if (currentAircraft == null)
                return;
            dateTimePickerAcceptanceDate.Value = currentAircraft.AcceptanceDate;
            dateTimePickerDeliveryDate.Value = currentAircraft.DeliveryDate;
            CheckPermission();
        }

        #endregion

        #endregion
    }
}
