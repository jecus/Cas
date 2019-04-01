using System;
using System.Drawing;
using System.Windows.Forms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    ///</summary>
    public partial class PerformanceDataControl : UserControl
    {
        ///<summary>
        ///</summary>
        public PerformanceDataControl()
        {
            InitializeComponent();
        }


        #region Properties

        #region public Aircraft Aircraft
        private Aircraft _currentAircraft;
        /// <summary>
        /// Возвращает или устанавливает ткущее ВС
        /// </summary>
        public Aircraft Aircraft
        {
            get
            {
                return _currentAircraft;
            }
            set
            {
                _currentAircraft = value;
                if (_currentAircraft!=null)
                {
                   UpdateControl(); 
                }
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
            bool permission = true;// currentAircraft.HasPermission(Users.IdentityUser, DataEvent.Update);

            numericUpDownBasicEmptyWeight.ReadOnly = !permission;
            numericUpDownBasicEmptyweightCargoConfig.ReadOnly = !permission;
            textBoxCargoCapacityContainer.ReadOnly = !permission;
            textBoxCruise.ReadOnly = !permission;
            textBoxCruiseFuelFlow.ReadOnly = !permission;
            textBoxFuelCapacity.ReadOnly = !permission;
            textBoxMaxCruiseAltitude.ReadOnly = !permission;
            numericUpDownMaxLandingWeight.ReadOnly = !permission;
            numericUpDownMaxTakeoffCrossWeight.ReadOnly = !permission;
            numericUpDownOperationEmptyWeight.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((numericUpDownBasicEmptyWeight.Value != (decimal)_currentAircraft.BasicEmptyWeight) ||
                    (numericUpDownBasicEmptyweightCargoConfig.Value != (decimal)_currentAircraft.BasicEmptyWeightCargoConfig) ||
                    (textBoxCargoCapacityContainer.Text != _currentAircraft.CargoCapacityContainer) ||
                    (textBoxCruise.Text != _currentAircraft.Cruise) ||
                    (textBoxCruiseFuelFlow.Text != _currentAircraft.CruiseFuelFlow) ||
                    (textBoxFuelCapacity.Text != _currentAircraft.FuelCapacity) ||
                    (textBoxMaxCruiseAltitude.Text != _currentAircraft.MaxCruiseAltitude) ||
                    (numericUpDownMaxLandingWeight.Value != (decimal)_currentAircraft.MaxLandingWeight) ||
                    (numericUpDownMaxTakeoffCrossWeight.Value != (decimal)_currentAircraft.MaxTakeOffCrossWeight) ||
                    (numericUpDownMaxZeroFuelWeight.Value != (decimal)_currentAircraft.MaxZeroFuelWeight) ||
                    (numericUpDownMaxTaxiWeight.Value != (decimal)_currentAircraft.MaxTaxiWeight)||
                    (numericUpDownMaxPayload.Value != (decimal)_currentAircraft.MaxPayloadWeight) ||
                    (numericUpDownOperationEmptyWeight.Value != (decimal)_currentAircraft.OperationalEmptyWeight) ||
                    numericTanks.Value != _currentAircraft.Tanks);
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего ВС
        /// </summary>
        public void SaveData()
        {
            _currentAircraft.BasicEmptyWeight = (double)numericUpDownBasicEmptyWeight.Value;
            _currentAircraft.BasicEmptyWeightCargoConfig = (double)numericUpDownBasicEmptyweightCargoConfig.Value;
            _currentAircraft.CargoCapacityContainer = textBoxCargoCapacityContainer.Text;
            _currentAircraft.Cruise = textBoxCruise.Text;
            _currentAircraft.CruiseFuelFlow = textBoxCruiseFuelFlow.Text;
            _currentAircraft.FuelCapacity = textBoxFuelCapacity.Text;
            _currentAircraft.MaxCruiseAltitude = textBoxMaxCruiseAltitude.Text;
            _currentAircraft.MaxLandingWeight = (double)numericUpDownMaxLandingWeight.Value;
            _currentAircraft.MaxPayloadWeight = (double)numericUpDownMaxPayload.Value;
            _currentAircraft.MaxTakeOffCrossWeight = (double)numericUpDownMaxTakeoffCrossWeight.Value;
            _currentAircraft.MaxZeroFuelWeight = (double)numericUpDownMaxZeroFuelWeight.Value;
            _currentAircraft.MaxTaxiWeight = (double)numericUpDownMaxTaxiWeight.Value;
            _currentAircraft.OperationalEmptyWeight = (double)numericUpDownOperationEmptyWeight.Value;
            _currentAircraft.Tanks = (int)numericTanks.Value;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о текущем ВС
        /// </summary>
        private void UpdateControl()
        {
            numericTanks.ValueChanged -= NumericTanksValueChanged;

            numericUpDownBasicEmptyWeight.Value = (decimal)_currentAircraft.BasicEmptyWeight;
            numericUpDownBasicEmptyweightCargoConfig.Value = (decimal)_currentAircraft.BasicEmptyWeightCargoConfig;
            textBoxCargoCapacityContainer.Text = _currentAircraft.CargoCapacityContainer;
            textBoxCruise.Text = _currentAircraft.Cruise;
            textBoxCruiseFuelFlow.Text = _currentAircraft.CruiseFuelFlow;
            textBoxFuelCapacity.Text = _currentAircraft.FuelCapacity;
            textBoxMaxCruiseAltitude.Text = _currentAircraft.MaxCruiseAltitude;
            numericUpDownMaxLandingWeight.Value = (decimal)_currentAircraft.MaxLandingWeight;
            numericUpDownMaxPayload.Value = (decimal) _currentAircraft.MaxPayloadWeight;
            numericUpDownMaxTakeoffCrossWeight.Value = (decimal)_currentAircraft.MaxTakeOffCrossWeight;
            numericUpDownMaxZeroFuelWeight.Value = (decimal)_currentAircraft.MaxZeroFuelWeight;
            numericUpDownMaxTaxiWeight.Value = (decimal)_currentAircraft.MaxTaxiWeight;
            numericUpDownOperationEmptyWeight.Value = (decimal)_currentAircraft.OperationalEmptyWeight;
            
            numericTanks.Value = _currentAircraft.Tanks;
            if (numericTanks.Value > 8 || numericTanks.Value < 0)
                numericTanks.BackColor = Color.Red;

            numericTanks.ValueChanged += NumericTanksValueChanged;

            CheckPermission();
        }

        #endregion


        #region private void NumericTanksValueChanged(object sender, System.EventArgs e)
        private void NumericTanksValueChanged(object sender, EventArgs e)
        {
            if (numericTanks.Value > 8)
                numericTanks.Value = 8;
            else if (numericTanks.Value < 0)
                numericTanks.Value = 0;
        }
        #endregion

        #endregion
    }
}
