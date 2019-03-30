using System.Windows.Forms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    ///</summary>
    public partial class InteriorConfigurationControl : UserControl
    {
        ///<summary>
        ///</summary>
        public InteriorConfigurationControl()
        {
            InitializeComponent();
        }

        #region Properties

        #region public Aircraft Aircraft
        private Aircraft _currentAircraft;
        /// <summary>
        /// Возвращает или устанавливает текущее ВС
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
            textBoxCockpitSeating.ReadOnly = !permission;
            textBoxGalleys.ReadOnly = !permission;
            textBoxLavatory.ReadOnly = !permission;
            numericUpDownSeatingEconomy.ReadOnly = !permission;
            numericUpDownSeatingBusiness.ReadOnly = !permission;
            numericUpDownSeatingFirst.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (textBoxCockpitSeating.Text != _currentAircraft.CockpitSeating ||
                    textBoxGalleys.Text != _currentAircraft.Galleys ||
                    textBoxLavatory.Text != _currentAircraft.Lavatory ||
                    numericUpDownSeatingEconomy.Value != _currentAircraft.SeatingEconomy ||
                    numericUpDownSeatingBusiness.Value != _currentAircraft.SeatingBusiness ||
                    numericUpDownSeatingFirst.Value != _currentAircraft.SeatingFirst ||
                    textBoxAirStairDoors.Text != _currentAircraft.AirStairsDoors ||
                    textBoxBoiler.Text != _currentAircraft.Boiler ||
                    textBoxOven.Text != _currentAircraft.Oven);
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного ВС
        /// </summary>
        public void SaveData()
        {
            if (_currentAircraft == null)
                return;
            if (textBoxCockpitSeating.Text != _currentAircraft.CockpitSeating)
                _currentAircraft.CockpitSeating = textBoxCockpitSeating.Text;
            if (textBoxGalleys.Text != _currentAircraft.Galleys)
                _currentAircraft.Galleys = textBoxGalleys.Text;
            if (textBoxLavatory.Text != _currentAircraft.Lavatory)
                _currentAircraft.Lavatory = textBoxLavatory.Text;
                
            _currentAircraft.SeatingEconomy = (int)numericUpDownSeatingEconomy.Value;
            _currentAircraft.SeatingBusiness = (int)numericUpDownSeatingBusiness.Value;
            _currentAircraft.SeatingFirst = (int)numericUpDownSeatingFirst.Value;
            _currentAircraft.AirStairsDoors = textBoxAirStairDoors.Text;
            _currentAircraft.Boiler = textBoxBoiler.Text;
            _currentAircraft.Oven = textBoxOven.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о базовом агрегате текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (_currentAircraft == null)
                return;
            textBoxCockpitSeating.Text = _currentAircraft.CockpitSeating;
            textBoxGalleys.Text = _currentAircraft.Galleys;
            textBoxLavatory.Text = _currentAircraft.Lavatory;
            numericUpDownSeatingEconomy.Value = _currentAircraft.SeatingEconomy;
            numericUpDownSeatingBusiness.Value = _currentAircraft.SeatingBusiness;
            numericUpDownSeatingFirst.Value = _currentAircraft.SeatingFirst;
            textBoxOven.Text = _currentAircraft.Oven;
            textBoxBoiler.Text = _currentAircraft.Boiler;
            textBoxAirStairDoors.Text = _currentAircraft.AirStairsDoors;
            CheckPermission();
        }

        #endregion

        #endregion
    }
}
