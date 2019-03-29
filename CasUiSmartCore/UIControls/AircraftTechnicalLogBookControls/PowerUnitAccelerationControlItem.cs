using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    ///</summary>
    public partial class PowerUnitAccelerationControlItem : EditObjectControl
    {
        private readonly Aircraft _currentAircraft;

        #region public EngineAccelerationTime Condition

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public EngineAccelerationTime Condition
        {
            get { return AttachedObject as EngineAccelerationTime; }
            set {AttachedObject = value;}
        }
        #endregion

        #region public string DetailLabelText
        /// <summary>
        /// Текст над списком дкталей
        /// </summary>
        public string DetailLabelText
        {
            get { return labelFlightEngine.Text; }
            set { labelFlightEngine.Text = value; }
        }

        #endregion
        /*
         * Конструктор
         */

        #region public PowerUnitAccelerationControlItem()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitAccelerationControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public PowerUnitAccelerationControlItem(Aircraft aircraft, EngineAccelerationTime condition) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitAccelerationControlItem(Aircraft aircraft, EngineAccelerationTime condition)
            : this()
        {
            _currentAircraft = aircraft;
            AttachedObject = condition;
        }
        #endregion

        #region public PowerUnitAccelerationControlItem(Aircraft aircraft) : this(aircraft, new EngineAccelerationTime())
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitAccelerationControlItem(Aircraft aircraft)
            : this(aircraft, new EngineAccelerationTime())
        {
        }
        #endregion


        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {

            //Заполняем общие данные о проведении измерений

            if (Condition != null)
            {
                if (comboBoxEngine.SelectedItem is BaseComponent)
                {
                    Condition.BaseComponent = (BaseComponent)comboBoxEngine.SelectedItem;
                    Condition.BaseComponentId = Condition.BaseComponent.ItemId;
                }
                Condition.AccelerationTime = (int)numericUpDownAccelerationTime.Value;
                Condition.AccelerationTimeAir = (int)numericUpDownAir.Value;
            }
            base.ApplyChanges();
        }
        #endregion

        #region public override bool CheckData()
        public override bool CheckData()
        {
            if (comboBoxEngine.SelectedItem == null)
            {
                MessageBox.Show("Not set PowerUnit", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxEngine.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

			//поиск базовой детали
			var aircraftBaseDetails = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, BaseComponentType.Engine.ItemId).ToList();

            comboBoxEngine.Items.Clear();
            if (Condition.ItemId <= 0)
            {
                //новая запись по уровню масла
                //тогда в список добавляются все двигатели и ВСУ
                if (aircraftBaseDetails.Count > 0)
                {
                    comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                    comboBoxEngine.SelectedItem = Condition.BaseComponent;
                }
            }
            else if (Condition.BaseComponent != null)
            {
                if (_currentAircraft != null && _currentAircraft.ItemId == Condition.BaseComponent.ParentAircraftId)
				{
                    //Деталь для которой создавалась запись находится на этом самолете;
                    if (aircraftBaseDetails.Count > 0)
                        comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                }
                else comboBoxEngine.Items.Add(Condition.BaseComponent);
                comboBoxEngine.SelectedItem = Condition.BaseComponent;
            }
            else
            {
                //Базовый компонент для которого сделана запись не найден
                comboBoxEngine.Items.Add("Error: Can't Find component");
            }

            numericUpDownAccelerationTime.Value = Condition.AccelerationTime;
            numericUpDownAir.Value = Condition.AccelerationTimeAir;
            EndUpdate();
        }
        #endregion

        #region public bool ShowHeaders

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelFlightEngine.Visible; }
            set
            {
                labelAccelerationTime.Visible = value;
                labelFlightEngine.Visible = value;
                labelAir.Visible = value;
            }
        }

        #endregion

        #region private void CheckParametres()
        private void CheckParametres()
        {
            if (comboBoxEngine.SelectedItem == null ||
               comboBoxEngine.SelectedItem as BaseComponent == null)
            {
                Color white = Color.White;
                numericUpDownAccelerationTime.BackColor = white;
                numericUpDownAir.BackColor = white;
            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                numericUpDownAccelerationTime.BackColor = 
                    ((int)numericUpDownAccelerationTime.Value > bd.AccelerationGround &&
                     bd.AccelerationGround > 0)
                    ? Color.Red 
                    : Color.White;
                numericUpDownAir.BackColor =
                    ((int)numericUpDownAir.Value > bd.AccelerationAir &&
                     bd.AccelerationAir > 0)
                    ? Color.Red
                    : Color.White;
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        {
            CheckParametres();
        }
        #endregion

        #region private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        {
            CheckParametres();
        }
        #endregion

        #region private void NumericUpDownAirValueChanged(object sender, EventArgs e)
        private void NumericUpDownAirValueChanged(object sender, EventArgs e)
        {
            CheckParametres();
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}
