using System;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    ///</summary>
    public partial class OtherControl : UserControl
    {
        ///<summary>
        ///</summary>
        public OtherControl()
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
            textBoxAddressBit.ReadOnly = !permission;
            textBoxELTHexCode.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (textBoxAddressBit.Text != _currentAircraft.AircraftAddress24Bit ||
                    textBoxELTHexCode.Text != _currentAircraft.ELTIdHexCode ||
                    numericUpDownNoiceCategory.Value != _currentAircraft.NoiceCategory ||
                    numericUpDownlandingCategory.Value != _currentAircraft.LandingCategory ||
                    ((Brakes)comboBoxBrakes.SelectedItem) != _currentAircraft.Brakes ||
                    checkBoxFADEC.Checked != _currentAircraft.FADEC ||
                    checkBoxEFIS.Checked != _currentAircraft.EFIS ||
                    checkBoxWinglets.Checked != _currentAircraft.Winglets);
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
            if (textBoxAddressBit.Text != _currentAircraft.AircraftAddress24Bit)
                _currentAircraft.AircraftAddress24Bit = textBoxAddressBit.Text;
            if (textBoxELTHexCode.Text != _currentAircraft.ELTIdHexCode)
                _currentAircraft.ELTIdHexCode = textBoxELTHexCode.Text;

            _currentAircraft.FADEC = checkBoxFADEC.Checked;
            _currentAircraft.EFIS = checkBoxEFIS.Checked;
            _currentAircraft.Winglets = checkBoxWinglets.Checked;
            _currentAircraft.Brakes = comboBoxBrakes.SelectedItem != null ? (Brakes) comboBoxBrakes.SelectedItem : Brakes.Carbon;
            _currentAircraft.NoiceCategory = (int)numericUpDownNoiceCategory.Value;
            _currentAircraft.LandingCategory = (int) numericUpDownlandingCategory.Value;
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
            comboBoxBrakes.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Brakes)))
                comboBoxBrakes.Items.Add(o);

            textBoxAddressBit.Text = _currentAircraft.AircraftAddress24Bit;
            textBoxELTHexCode.Text = _currentAircraft.ELTIdHexCode;
            numericUpDownNoiceCategory.Value = _currentAircraft.NoiceCategory;
            numericUpDownlandingCategory.Value = _currentAircraft.LandingCategory;
            comboBoxBrakes.SelectedItem = _currentAircraft.Brakes;
            checkBoxFADEC.Checked = _currentAircraft.FADEC;
            checkBoxEFIS.Checked = _currentAircraft.EFIS;
            checkBoxWinglets.Checked = _currentAircraft.Winglets;

            CheckPermission();
        }

        #endregion

        #endregion
    }
}
