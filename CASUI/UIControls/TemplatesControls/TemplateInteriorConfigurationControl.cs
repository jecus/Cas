using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения Interior Configuration шаблонного ВС
    /// </summary>
    public class TemplateInteriorConfigurationControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int LABEL_WIDTH = 150;
        private const int TEXT_BOX_WIDTH = 250;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        
        private readonly Label labelSeatingCapacity = new Label();
        private readonly Label labelGalleys = new Label();
        private readonly Label labelLavatory = new Label();
        private readonly Label labelCockpitSeating = new Label();
        private readonly TextBox textBoxSeatingCapacity = new TextBox();
        private readonly TextBox textBoxGalleys = new TextBox();
        private readonly TextBox textBoxLavatory = new TextBox();
        private readonly TextBox textBoxCockpitSeating = new TextBox();
        
        private TemplateAircraft currentAircraft;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения Interior Configuration шаблонного ВС
        /// </summary>
        public TemplateInteriorConfigurationControl(TemplateAircraft currentAircraft)
        {
            Size = new Size(TEXT_BOX_WIDTH + LABEL_WIDTH, 4 * TEXT_BOX_HEIGHT + 3 * HEIGHT_INTERVAL + TOP_MARGIN + BOTTOM_MARGIN);
            this.currentAircraft = currentAircraft;
            //
            // labelCockpitSeating
            //
            labelCockpitSeating.Location = new Point(0, TOP_MARGIN);
            labelCockpitSeating.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCockpitSeating.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCockpitSeating.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelCockpitSeating.Text = "Cockpit Seating";
            labelCockpitSeating.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelGalleys
            //
            labelGalleys.Location = new Point(0, labelCockpitSeating.Bottom + HEIGHT_INTERVAL);
            labelGalleys.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelGalleys.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelGalleys.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelGalleys.Text = "Galleys";
            labelGalleys.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelLavatory
            //
            labelLavatory.Location = new Point(0, labelGalleys.Bottom + HEIGHT_INTERVAL);
            labelLavatory.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLavatory.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLavatory.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelLavatory.Text = "Lavatory";
            labelLavatory.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelSeatingCapacity
            //
            labelSeatingCapacity.Location = new Point(0, labelLavatory.Bottom + HEIGHT_INTERVAL);
            labelSeatingCapacity.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSeatingCapacity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSeatingCapacity.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelSeatingCapacity.Text = "Seating Capacity";
            labelSeatingCapacity.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxCockpitSeating
            //
            textBoxCockpitSeating.Location = new Point(LABEL_WIDTH, TOP_MARGIN);
            textBoxCockpitSeating.BackColor = Color.White;
            textBoxCockpitSeating.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCockpitSeating.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCockpitSeating.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxGalleys
            //
            textBoxGalleys.Location = new Point(LABEL_WIDTH, textBoxCockpitSeating.Bottom + HEIGHT_INTERVAL);
            textBoxGalleys.BackColor = Color.White;
            textBoxGalleys.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxGalleys.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxGalleys.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxLavatory
            //
            textBoxLavatory.Location = new Point(LABEL_WIDTH, textBoxGalleys.Bottom + HEIGHT_INTERVAL);
            textBoxLavatory.BackColor = Color.White;
            textBoxLavatory.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLavatory.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxLavatory.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxSeatingCapacity
            //
            textBoxSeatingCapacity.Location = new Point(LABEL_WIDTH, textBoxLavatory.Bottom + HEIGHT_INTERVAL);
            textBoxSeatingCapacity.BackColor = Color.White;
            textBoxSeatingCapacity.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSeatingCapacity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSeatingCapacity.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);

            Controls.Add(labelCockpitSeating);
            Controls.Add(labelGalleys);
            Controls.Add(labelLavatory);
            Controls.Add(labelSeatingCapacity);
            Controls.Add(textBoxCockpitSeating);
            Controls.Add(textBoxGalleys);
            Controls.Add(textBoxLavatory);
            Controls.Add(textBoxSeatingCapacity);

            UpdateControl();
        }

        #endregion

        #region Properties

        #region public TemplateAircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает текущее шаблонное ВС
        /// </summary>
        public TemplateAircraft Aircraft
        {
            get
            {
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                UpdateControl();
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            textBoxCockpitSeating.ReadOnly = !permission;
            textBoxGalleys.ReadOnly = !permission;
            textBoxLavatory.ReadOnly = !permission;
            textBoxSeatingCapacity.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((textBoxCockpitSeating.Text != currentAircraft.CockpitSeating) ||
                    (textBoxGalleys.Text != currentAircraft.Galleys) ||
                    (textBoxLavatory.Text != currentAircraft.Lavatory) ||
                    (textBoxSeatingCapacity.Text != currentAircraft.SeatingCapacity));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного ВС
        /// </summary>
        public void SaveData()
        {
            if (currentAircraft == null)
                return;
            if (textBoxCockpitSeating.Text != currentAircraft.CockpitSeating)
                currentAircraft.CockpitSeating = textBoxCockpitSeating.Text;
            if (textBoxGalleys.Text != currentAircraft.Galleys)
                currentAircraft.Galleys = textBoxGalleys.Text;
            if (textBoxLavatory.Text != currentAircraft.Lavatory)
                currentAircraft.Lavatory = textBoxLavatory.Text;
            if (textBoxSeatingCapacity.Text != currentAircraft.SeatingCapacity)
                currentAircraft.SeatingCapacity = textBoxSeatingCapacity.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о текущем шаблонном ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentAircraft == null)
                return;
            textBoxCockpitSeating.Text = currentAircraft.CockpitSeating;
            textBoxGalleys.Text = currentAircraft.Galleys;
            textBoxLavatory.Text = currentAircraft.Lavatory;
            textBoxSeatingCapacity.Text = currentAircraft.SeatingCapacity;
            CheckPermission();
        }

        #endregion

        #endregion
    }
}
