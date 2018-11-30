using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения PerformanceDataControl шаблонного ВС
    /// </summary>
    public class TemplatePerformanceDataControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int WIDTH_INTERVAL = 600;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 200;
        private const int LABEL_WIDTH = 280;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        private TemplateAircraft currentAircraft;

        private readonly Label labelBasicEmptyWeight = new Label();
        private readonly Label labelBasicEmptyWeightCargoConfig = new Label();
        private readonly Label labelCargoCapacityContainer = new Label();
        private readonly Label labelCruise = new Label();
        private readonly Label labelCruiseFuelFlow = new Label();
        private readonly Label labelFuelCapacity = new Label();
        private readonly Label labelMaxCruiseAltitude = new Label();
        private readonly Label labelMaxLandingWeight = new Label();
        private readonly Label labelMaxTakeOffCrossWeight = new Label();
        private readonly Label labelMaxZeroFuelWeight = new Label();

        private readonly TextBox textBoxBasicEmptyWeight = new TextBox();
        private readonly TextBox textBoxBasicEmptyWeightCargoConfig = new TextBox();
        private readonly TextBox textBoxCargoCapacityContainer = new TextBox();
        private readonly TextBox textBoxCruise = new TextBox();
        private readonly TextBox textBoxCruiseFuelFlow = new TextBox();
        private readonly TextBox textBoxFuelCapacity = new TextBox();
        private readonly TextBox textBoxMaxCruiseAltitude = new TextBox();
        private readonly TextBox textBoxMaxLandingWeight = new TextBox();
        private readonly TextBox textBoxMaxTakeOffCrossWeight = new TextBox();
        private readonly TextBox textBoxMaxZeroFuelWeight = new TextBox();

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения PerformanceDataControl шаблонного ВС
        /// </summary>
        /// <param name="currentAircraft">Шаблонное ВС</param>
        public TemplatePerformanceDataControl(TemplateAircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;

            Size = new Size(WIDTH_INTERVAL*2, 5*TEXT_BOX_HEIGHT + 4*HEIGHT_INTERVAL + TOP_MARGIN + BOTTOM_MARGIN);
            //
            // labelBasicEmptyWeight
            //
            labelBasicEmptyWeight.Location = new Point(0, TOP_MARGIN);
            labelBasicEmptyWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelBasicEmptyWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelBasicEmptyWeight.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelBasicEmptyWeight.Text = "Basic Empty Weight";
            labelBasicEmptyWeight.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelBasicEmptyWeightCargoConfig
            //
            labelBasicEmptyWeightCargoConfig.Location = new Point(0, labelBasicEmptyWeight.Bottom + HEIGHT_INTERVAL);
            labelBasicEmptyWeightCargoConfig.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelBasicEmptyWeightCargoConfig.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelBasicEmptyWeightCargoConfig.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelBasicEmptyWeightCargoConfig.Text = "Basic Empty Weight (Cargo Config.)";
            labelBasicEmptyWeightCargoConfig.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCargoCapacityContainer
            //
            labelCargoCapacityContainer.Location = new Point(0, labelBasicEmptyWeightCargoConfig.Bottom + HEIGHT_INTERVAL);
            labelCargoCapacityContainer.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCargoCapacityContainer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCargoCapacityContainer.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelCargoCapacityContainer.Text = "Cargo Capacity Container";
            labelCargoCapacityContainer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCruise
            //
            labelCruise.Location = new Point(0, labelCargoCapacityContainer.Bottom + HEIGHT_INTERVAL);
            labelCruise.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCruise.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCruise.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelCruise.Text = "Cruise (Mach)";
            labelCruise.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCruiseFuelFlow
            //
            labelCruiseFuelFlow.Location = new Point(0, labelCruise.Bottom + HEIGHT_INTERVAL);
            labelCruiseFuelFlow.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCruiseFuelFlow.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCruiseFuelFlow.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelCruiseFuelFlow.Text = "Cruise Fuel Flow";
            labelCruiseFuelFlow.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelFuelCapacity
            //
            labelFuelCapacity.Location = new Point(WIDTH_INTERVAL, TOP_MARGIN);
            labelFuelCapacity.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFuelCapacity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFuelCapacity.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelFuelCapacity.Text = "Fuel Capacity";
            labelFuelCapacity.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMaxCruiseAltitude
            //
            labelMaxCruiseAltitude.Location = new Point(WIDTH_INTERVAL, labelFuelCapacity.Bottom + HEIGHT_INTERVAL);
            labelMaxCruiseAltitude.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaxCruiseAltitude.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaxCruiseAltitude.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelMaxCruiseAltitude.Text = "Max. Cruise Altitude";
            labelMaxCruiseAltitude.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMaxLandingWeight
            //
            labelMaxLandingWeight.Location = new Point(WIDTH_INTERVAL, labelMaxCruiseAltitude.Bottom + HEIGHT_INTERVAL);
            labelMaxLandingWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaxLandingWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaxLandingWeight.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelMaxLandingWeight.Text = "Max. Landing Weight";
            labelMaxLandingWeight.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMaxTakeOffCrossWeight
            //
            labelMaxTakeOffCrossWeight.Location = new Point(WIDTH_INTERVAL, labelMaxLandingWeight.Bottom + HEIGHT_INTERVAL);
            labelMaxTakeOffCrossWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaxTakeOffCrossWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaxTakeOffCrossWeight.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelMaxTakeOffCrossWeight.Text = "Max. Take-Off Cross Weight";
            labelMaxTakeOffCrossWeight.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMaxZeroFuelWeight
            //
            labelMaxZeroFuelWeight.Location = new Point(WIDTH_INTERVAL, labelMaxTakeOffCrossWeight.Bottom + HEIGHT_INTERVAL);
            labelMaxZeroFuelWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaxZeroFuelWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaxZeroFuelWeight.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelMaxZeroFuelWeight.Text = "Max. Zero Fuel Weight";
            labelMaxZeroFuelWeight.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxBasicEmptyWeight
            //
            textBoxBasicEmptyWeight.Location = new Point(LABEL_WIDTH, TOP_MARGIN);
            textBoxBasicEmptyWeight.BackColor = Color.White;
            textBoxBasicEmptyWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxBasicEmptyWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxBasicEmptyWeight.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxBasicEmptyWeightCargoConfig
            //
            textBoxBasicEmptyWeightCargoConfig.Location = new Point(LABEL_WIDTH, textBoxBasicEmptyWeight.Bottom + HEIGHT_INTERVAL);
            textBoxBasicEmptyWeightCargoConfig.BackColor = Color.White;
            textBoxBasicEmptyWeightCargoConfig.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxBasicEmptyWeightCargoConfig.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxBasicEmptyWeightCargoConfig.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxCargoCapacityContainer
            //
            textBoxCargoCapacityContainer.Location = new Point(LABEL_WIDTH, textBoxBasicEmptyWeightCargoConfig.Bottom + HEIGHT_INTERVAL);
            textBoxCargoCapacityContainer.BackColor = Color.White;
            textBoxCargoCapacityContainer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCargoCapacityContainer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCargoCapacityContainer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxCruise
            //
            textBoxCruise.Location = new Point(LABEL_WIDTH, textBoxCargoCapacityContainer.Bottom + HEIGHT_INTERVAL);
            textBoxCruise.BackColor = Color.White;
            textBoxCruise.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCruise.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCruise.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxCruiseFuelFlow
            //
            textBoxCruiseFuelFlow.Location = new Point(LABEL_WIDTH, textBoxCruise.Bottom + HEIGHT_INTERVAL);
            textBoxCruiseFuelFlow.BackColor = Color.White;
            textBoxCruiseFuelFlow.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCruiseFuelFlow.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCruiseFuelFlow.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxFuelCapacity
            //
            textBoxFuelCapacity.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, TOP_MARGIN);
            textBoxFuelCapacity.BackColor = Color.White;
            textBoxFuelCapacity.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxFuelCapacity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxFuelCapacity.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxMaxCruiseAltitude
            //
            textBoxMaxCruiseAltitude.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxFuelCapacity.Bottom + HEIGHT_INTERVAL);
            textBoxMaxCruiseAltitude.BackColor = Color.White;
            textBoxMaxCruiseAltitude.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMaxCruiseAltitude.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMaxCruiseAltitude.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxMaxLandingWeight
            //
            textBoxMaxLandingWeight.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxMaxCruiseAltitude.Bottom + HEIGHT_INTERVAL);
            textBoxMaxLandingWeight.BackColor = Color.White;
            textBoxMaxLandingWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMaxLandingWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMaxLandingWeight.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxMaxTakeOffCrossWeight
            //
            textBoxMaxTakeOffCrossWeight.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxMaxLandingWeight.Bottom + HEIGHT_INTERVAL);
            textBoxMaxTakeOffCrossWeight.BackColor = Color.White;
            textBoxMaxTakeOffCrossWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMaxTakeOffCrossWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMaxTakeOffCrossWeight.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxMaxZeroFuelWeight
            //
            textBoxMaxZeroFuelWeight.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxMaxTakeOffCrossWeight.Bottom + HEIGHT_INTERVAL);
            textBoxMaxZeroFuelWeight.BackColor = Color.White;
            textBoxMaxZeroFuelWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxMaxZeroFuelWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxMaxZeroFuelWeight.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);


            Controls.Add(labelBasicEmptyWeight);
            Controls.Add(labelBasicEmptyWeightCargoConfig);
            Controls.Add(labelCargoCapacityContainer);
            Controls.Add(labelCruise);
            Controls.Add(labelCruiseFuelFlow);
            Controls.Add(labelFuelCapacity);
            Controls.Add(labelMaxCruiseAltitude);
            Controls.Add(labelMaxLandingWeight);
            Controls.Add(labelMaxTakeOffCrossWeight);
            Controls.Add(labelMaxZeroFuelWeight);
            Controls.Add(textBoxBasicEmptyWeight);
            Controls.Add(textBoxBasicEmptyWeightCargoConfig);
            Controls.Add(textBoxCargoCapacityContainer);
            Controls.Add(textBoxCruise);
            Controls.Add(textBoxCruiseFuelFlow);
            Controls.Add(textBoxFuelCapacity);
            Controls.Add(textBoxMaxCruiseAltitude);
            Controls.Add(textBoxMaxLandingWeight);
            Controls.Add(textBoxMaxTakeOffCrossWeight);
            Controls.Add(textBoxMaxZeroFuelWeight);

            UpdateControl();

        }

        #endregion

        #region Properties

        #region public TemplateAircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает ткущее ВС
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

            textBoxBasicEmptyWeight.ReadOnly = !permission;
            textBoxBasicEmptyWeightCargoConfig.ReadOnly = !permission;
            textBoxCargoCapacityContainer.ReadOnly = !permission;
            textBoxCruise.ReadOnly = !permission;
            textBoxCruiseFuelFlow.ReadOnly = !permission;
            textBoxFuelCapacity.ReadOnly = !permission;
            textBoxMaxCruiseAltitude.ReadOnly = !permission;
            textBoxMaxLandingWeight.ReadOnly = !permission;
            textBoxMaxTakeOffCrossWeight.ReadOnly = !permission;
            textBoxMaxZeroFuelWeight.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((textBoxBasicEmptyWeight.Text != currentAircraft.BasicEmptyWeight) ||
                    (textBoxBasicEmptyWeightCargoConfig.Text != currentAircraft.BasicEmptyWeightCargoConfig) ||
                    (textBoxCargoCapacityContainer.Text != currentAircraft.CargoCapacityContainer) ||
                    (textBoxCruise.Text != currentAircraft.Cruise) ||
                    (textBoxCruiseFuelFlow.Text != currentAircraft.CruiseFuelFlow) ||
                    (textBoxFuelCapacity.Text != currentAircraft.FuelCapacity) ||
                    (textBoxMaxCruiseAltitude.Text != currentAircraft.MaxCruiseAltitude) ||
                    (textBoxMaxLandingWeight.Text != currentAircraft.MaxLandingWeight) ||
                    (textBoxMaxTakeOffCrossWeight.Text != currentAircraft.MaxTakeOffCrossWeight) ||
                    (textBoxMaxZeroFuelWeight.Text != currentAircraft.MaxZeroFuelWeight));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного ВС
        /// </summary>
        public void SaveData()
        {
            if (textBoxBasicEmptyWeight.Text != currentAircraft.BasicEmptyWeight)
                currentAircraft.BasicEmptyWeight = textBoxBasicEmptyWeight.Text;
            if (textBoxBasicEmptyWeightCargoConfig.Text != currentAircraft.BasicEmptyWeightCargoConfig)
                currentAircraft.BasicEmptyWeightCargoConfig = textBoxBasicEmptyWeightCargoConfig.Text;
            if (textBoxCargoCapacityContainer.Text != currentAircraft.CargoCapacityContainer)
                currentAircraft.CargoCapacityContainer = textBoxCargoCapacityContainer.Text;
            if (textBoxCruise.Text != currentAircraft.Cruise)
                currentAircraft.Cruise = textBoxCruise.Text;
            if (textBoxCruiseFuelFlow.Text != currentAircraft.CruiseFuelFlow)
                currentAircraft.CruiseFuelFlow = textBoxCruiseFuelFlow.Text;
            if (textBoxFuelCapacity.Text != currentAircraft.FuelCapacity)
                currentAircraft.FuelCapacity = textBoxFuelCapacity.Text;
            if (textBoxMaxCruiseAltitude.Text != currentAircraft.MaxCruiseAltitude)
                currentAircraft.MaxCruiseAltitude = textBoxMaxCruiseAltitude.Text;
            if (textBoxMaxLandingWeight.Text != currentAircraft.MaxLandingWeight)
                currentAircraft.MaxLandingWeight = textBoxMaxLandingWeight.Text;
            if (textBoxMaxTakeOffCrossWeight.Text != currentAircraft.MaxTakeOffCrossWeight)
                currentAircraft.MaxTakeOffCrossWeight= textBoxMaxTakeOffCrossWeight.Text;
            if (textBoxMaxZeroFuelWeight.Text != currentAircraft.MaxZeroFuelWeight)
                currentAircraft.MaxZeroFuelWeight = textBoxMaxZeroFuelWeight.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о текущем шаблонном ВС
        /// </summary>
        private void UpdateControl()
        {
            textBoxBasicEmptyWeight.Text = currentAircraft.BasicEmptyWeight;
            textBoxBasicEmptyWeightCargoConfig.Text = currentAircraft.BasicEmptyWeightCargoConfig;
            textBoxCargoCapacityContainer.Text = currentAircraft.CargoCapacityContainer;
            textBoxCruise.Text = currentAircraft.Cruise;
            textBoxCruiseFuelFlow.Text = currentAircraft.CruiseFuelFlow;
            textBoxFuelCapacity.Text = currentAircraft.FuelCapacity;
            textBoxMaxCruiseAltitude.Text = currentAircraft.MaxCruiseAltitude;
            textBoxMaxLandingWeight.Text = currentAircraft.MaxLandingWeight;
            textBoxMaxTakeOffCrossWeight.Text = currentAircraft.MaxTakeOffCrossWeight;
            textBoxMaxZeroFuelWeight.Text = currentAircraft.MaxZeroFuelWeight;
            CheckPermission();
        }

        #endregion

        #endregion



    }
}

