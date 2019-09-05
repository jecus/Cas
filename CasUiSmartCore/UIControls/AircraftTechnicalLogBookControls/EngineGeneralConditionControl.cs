using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
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
    public partial class EngineGeneralConditionControl : EditObjectControl
    {
        private Dictionary<int, double> _componentOilFlow = new Dictionary<int, double>();

        private readonly Aircraft _currentAircraft;

        #region public EnginesGeneralCondition EngineGeneral
        /// <summary>
        /// Сгруппированная запись по состояниям двигателей, с которым связан контрол
        /// </summary>
        public EnginesGeneralCondition EngineGeneral
        {
            get { return AttachedObject as EnginesGeneralCondition; }
        }
        #endregion

        #region private EngineGeneralConditionControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private EngineGeneralConditionControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public EngineGeneralConditionControl(Aircraft aircraft, EnginesGeneralCondition engineGeneral) : this()
        ///<summary>
        /// Конструктор, создает ЭУ на онснове самолета и Группированной записи по состояниям двигателей
        ///</summary>
        public EngineGeneralConditionControl(Aircraft aircraft, EnginesGeneralCondition engineGeneral) : this()
        {
            _currentAircraft = aircraft;
            AttachedObject = engineGeneral;
        }
        #endregion

        #region public EngineGeneralConditionControl(Aircraft aircraft) : this()
        ///<summary>
        /// Конструктор, создает ЭУ на онснове самолета
        ///</summary>
        public EngineGeneralConditionControl(Aircraft aircraft)
            : this()
        {
            if(aircraft == null)return;
            _currentAircraft = aircraft;

			var baseDetailTypeIds = new[] { BaseComponentType.Apu.ItemId, BaseComponentType.Engine.ItemId };
			var aircraftBaseDetail = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, baseDetailTypeIds).ToList();

            var conditions = aircraftBaseDetail.Select(baseDetail => new EngineCondition {Engine = baseDetail}).ToList();
            var general = new EnginesGeneralCondition();
            general.EngineConditions.AddRange(conditions.ToArray());
            AttachedObject = general;
        }
        #endregion

        /*
         * Своиства
         */
        #region public int PressAlt
        /// <summary>
        /// Высота на которой произведен замер
        /// </summary>
        public int PressAlt
        {
            get { return (int)numericUpDownPressALT.Value; }
            set { numericUpDownPressALT.Value = value; }
        }
        #endregion

        #region public DateTime RecordDate
        ///<summary>
        /// Возвращает или задает (только для новых замеров) время проведения замеров
        ///</summary>
        public DateTime RecordDate
        {
            get { return dateTimePickerGMT.Value; }
            set
            {
                if(EngineGeneral.EngineConditions.Count > 0 &&
                   EngineGeneral.EngineConditions[0].ItemId < 0)
                {
                    dateTimePickerGMT.Value = value;
                }
            }
        }
        #endregion

        #region public void SetPowerUnitWorkTime(BaseDetail powerUnit, double workTime)
        ///<summary>
        /// Изменяет время работы определенной силовой установки
        ///</summary>
        ///<param name="powerUnit">Силовая установка</param>
        ///<param name="flow">Время работы</param>
        public void SetComponentOilFlow(BaseComponent powerUnit, double flow)
        {
            if (powerUnit == null) return;
            if (_componentOilFlow.ContainsKey(powerUnit.ItemId))
                _componentOilFlow[powerUnit.ItemId] = flow;
            else _componentOilFlow.Add(powerUnit.ItemId, flow);

            SetOilFlow(powerUnit.ItemId, flow);
        }

        public void SetComponentOilFlow(List<BaseComponent> powerUnits, double flow)
        {
	        foreach (var powerUnit in powerUnits)
	        {
				if (powerUnit == null) return;
				if (_componentOilFlow.ContainsKey(powerUnit.ItemId))
					_componentOilFlow[powerUnit.ItemId] = flow;
				else _componentOilFlow.Add(powerUnit.ItemId, flow);

				SetOilFlow(powerUnit.ItemId, flow);
			}
        }

		#endregion

		#region public void SetPowerUnitWorkTime(BaseDetail powerUnit, double workTime)
		///<summary>
		/// Изменяет время работы определенной силовой установки
		///</summary>
		///<param name="oilFlowInfo">Силовая установка</param>
		public void SetComponentOilFlow(Dictionary<int, double> oilFlowInfo )
        {
            _componentOilFlow.Clear();
            if (oilFlowInfo == null) return;
            foreach (KeyValuePair<int, double> d in oilFlowInfo)
            {
                _componentOilFlow.Add(d.Key, d.Value);
                SetOilFlow(d.Key, d.Value);
            }
        }
        #endregion

        #region public double GrossWeight
        /// <summary>
        /// Масса
        /// </summary>
        public double GrossWeight
        {
            get { return (double)numericUpDownGrossWeight.Value; }
            set { numericUpDownGrossWeight.Value = (decimal)value; }
        }
        #endregion

        #region public double IAS
        /// <summary>
        /// Показываемая скорость полета
        /// </summary>
        public double IAS
        {
            get { return (double)numericUpDownIAS.Value; }
            set { numericUpDownIAS.Value = (decimal)value; }
        }
        #endregion

        #region public double Mach
        /// <summary>
        /// Реальная скорость полета
        /// </summary>
        public double Mach
        {
            get { return (double)numericUpDownMach.Value; }
            set { numericUpDownMach.Value = (decimal)value; }
        }
        #endregion

        #region public double TAT
        /// <summary>
        /// Total Air Temperature
        /// </summary>
        public double TAT
        {
            get { return (double)numericUpDownTAT.Value; }
            set { numericUpDownTAT.Value = (decimal)value; }
        }
        #endregion

        #region public double OAT
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        public double OAT
        {
            get { return (double)numericUpDownOAT.Value; }
            set { numericUpDownOAT.Value = (decimal)value; }
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
            EngineGeneral.PressALT = numericUpDownPressALT.Value.ToString();
            EngineGeneral.TimeGMT = dateTimePickerGMT.Value.TimeOfDay;
            EngineGeneral.GrossWeight = (double)numericUpDownGrossWeight.Value;
            EngineGeneral.IAS = (double)numericUpDownIAS.Value;
            EngineGeneral.Mach = (double)numericUpDownMach.Value;
            EngineGeneral.TAT = (double)numericUpDownTAT.Value;
            EngineGeneral.OAT = (double)numericUpDownOAT.Value;
            EngineGeneral.FlightRegime =
                comboBoxFlightRegime.SelectedItem != null
                    ? (FlightRegime) comboBoxFlightRegime.SelectedItem
                    : FlightRegime.UNK;
            EngineGeneral.GroundAir = comboBoxGroundAir.SelectedItem != null
                                          ? (GroundAir) comboBoxGroundAir.SelectedItem
                                          : GroundAir.Ground;

            for (int i = 0; i < flowLayoutPanelEngineConditions.Controls.Count; i++)
            {
                EngineMonitoringControlItem c = flowLayoutPanelEngineConditions.Controls[i] as EngineMonitoringControlItem;
                if (c == null) continue;
                c.ApplyChanges();
                c.Condition.AddInformation(EngineGeneral);
                if (EngineGeneral != null && EngineGeneral.EngineConditions != null && !ConditionExists(c.Condition))
                    EngineGeneral.EngineConditions.Add(c.Condition);
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            if (EngineGeneral.EngineConditions.Count>0)
            {
                flowLayoutPanelEngineConditions.Controls.Clear();
                List<EngineCondition> orderedList = EngineGeneral.EngineConditions.OrderBy(e => e.Engine).ToList();
                for (int i = 0; i < orderedList.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    EngineMonitoringControlItem c = new EngineMonitoringControlItem(_currentAircraft, orderedList[i]);
                    c.Deleted += ConditionControlDeleted;
                    c.ComponentChanget += ItemComponentChanget;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelEngineConditions.Controls.Add(c);
                }
                flowLayoutPanelEngineConditions.Controls.Add(panelAdd);
            }

            int pressAlt;
            numericUpDownPressALT.Value = int.TryParse(EngineGeneral.PressALT, out pressAlt) ? pressAlt : 0;
            numericUpDownGrossWeight.Value = (decimal)EngineGeneral.GrossWeight;
            numericUpDownIAS.Value = (decimal)EngineGeneral.IAS;
            numericUpDownMach.Value = (decimal)EngineGeneral.Mach;
            numericUpDownTAT.Value = (decimal)EngineGeneral.TAT;
            numericUpDownOAT.Value = (decimal)EngineGeneral.OAT;
            dateTimePickerGMT.Value = EngineGeneral.EngineConditions[0].ItemId > 0
                ? DateTime.Today.Add(EngineGeneral.TimeGMT)
                : DateTime.Today;
            comboBoxFlightRegime.Items.Clear();
            comboBoxFlightRegime.Items.AddRange(FlightRegime.Items.ToArray());
            comboBoxFlightRegime.SelectedItem = EngineGeneral.FlightRegime;

            comboBoxGroundAir.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(GroundAir)))
                comboBoxGroundAir.Items.Add(o);
            comboBoxGroundAir.SelectedItem = EngineGeneral.GroundAir;

            checkBoxClear.Checked = (EngineGeneral.Weather & WeatherCondition.Clear) != 0;
            checkBoxClouds.Checked = (EngineGeneral.Weather & WeatherCondition.Clouds) != 0;
            checkBoxTurb.Checked = (EngineGeneral.Weather & WeatherCondition.Turb) != 0;
            checkBoxRainShow.Checked = (EngineGeneral.Weather & WeatherCondition.RainSnow) != 0;


            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            // Проверяем общие данные проверки
            // Проверка на дату и ввод правильных дробных чисел
            //TimeSpan time;
            //if (!TimeSpan.TryParse(textBoxGMT.Text, out time))
            //{
            //    Visible = true;
            //    SimpleBalloon.Show(textBoxGMT, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time in the following format: HH:MM");
            //    return false;
            //}
            //if (!checkBoxClear.Checked && !checkBoxClouds.Checked && !checkBoxRainShow.Checked && !checkBoxTurb.Checked)
            //{
            //    SimpleBalloon.Show(checkBoxClear.Text, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time in the following format: HH:MM");
            //    return false;
            //}

            for (int i = 0; i < flowLayoutPanelEngineConditions.Controls.Count; i++)
            {
                EngineMonitoringControlItem c = flowLayoutPanelEngineConditions.Controls[i] as EngineMonitoringControlItem;
                if (c != null)
                {
                    if (!c.CheckData())
                    {
                        Visible = true;
                        return false;
                    }
                }
            }
            //
            return true;
        }
        #endregion

        #region private void SetOilFlow(int powerUnit, double oilFlow)
        private void SetOilFlow(int powerUnit, double oilFlow)
        {
            List<EngineMonitoringControlItem> fcs =
                flowLayoutPanelEngineConditions.Controls
                .OfType<EngineMonitoringControlItem>()
                .Where(c => c.PowerUnit != null && c.PowerUnit.ItemId == powerUnit)
                .ToList();
            foreach (EngineMonitoringControlItem fc in fcs)
            {
                fc.OilFlow = oilFlow;
            }
        }
        #endregion

        #region private bool ConditionExists(EngineCondition con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(EngineCondition con)
        {
            //
            if (EngineGeneral == null || EngineGeneral.EngineConditions == null) return false;

            //
            return EngineGeneral.EngineConditions.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EngineMonitoringControlItem performance =
                new EngineMonitoringControlItem(_currentAircraft, new EngineCondition());
            
            if (performance.PowerUnit != null && _componentOilFlow.ContainsKey(performance.PowerUnit.ItemId))
                performance.OilFlow = _componentOilFlow[performance.PowerUnit.ItemId];

            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelEngineConditions.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelEngineConditions.Controls.Remove(panelAdd);
            flowLayoutPanelEngineConditions.Controls.Add(performance);
            flowLayoutPanelEngineConditions.Controls.Add(panelAdd);
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            EngineMonitoringControlItem control = (EngineMonitoringControlItem)sender;
            EngineCondition cond = control.Condition;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete engine condition?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelEngineConditions.Controls.Remove(control);
            }
            else if (cond.ItemId <= 0) flowLayoutPanelEngineConditions.Controls.Remove(control);
        }

        #endregion

        #region private void CheckBoxTurbClick(object sender, EventArgs e)
        private void CheckBoxTurbClick(object sender, EventArgs e)
        {
            EngineGeneral.Weather ^= WeatherCondition.Turb;
        }
        #endregion

        #region private void CheckBoxClearClick(object sender, EventArgs e)
        private void CheckBoxClearClick(object sender, EventArgs e)
        {
            EngineGeneral.Weather ^= WeatherCondition.Clear;
        }
        #endregion

        #region private void CheckBoxCloudsClick(object sender, EventArgs e)
        private void CheckBoxCloudsClick(object sender, EventArgs e)
        {
            EngineGeneral.Weather ^= WeatherCondition.Clouds;
        }
        #endregion

        #region private void CheckBoxRainShowClick(object sender, EventArgs e)
        private void CheckBoxRainShowClick(object sender, EventArgs e)
        {
            EngineGeneral.Weather ^= WeatherCondition.RainSnow;
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ItemComponentChanget(object sender, EventArgs e)
        private void ItemComponentChanget(object sender, EventArgs e)
        {
            if (sender as EngineMonitoringControlItem == null) return;
            BaseComponent powerUnit = ((EngineMonitoringControlItem)sender).PowerUnit;
            if (powerUnit != null && _componentOilFlow.ContainsKey(powerUnit.ItemId))
                ((EngineMonitoringControlItem) sender).OilFlow = _componentOilFlow[powerUnit.ItemId];
        }
        #endregion

        #region private void ComboBoxFlightRegimeSelectionChangeCommitted(object sender, EventArgs e)
        private void ComboBoxFlightRegimeSelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (EngineMonitoringControlItem item in flowLayoutPanelEngineConditions.Controls.OfType<EngineMonitoringControlItem>())
            {
                item.FlightRegime = comboBoxFlightRegime.SelectedItem as FlightRegime;
            }
        }
        #endregion

        #region private void ComboBoxGroundAirSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxGroundAirSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (EngineMonitoringControlItem item in flowLayoutPanelEngineConditions.Controls.OfType<EngineMonitoringControlItem>())
            {
                if(comboBoxGroundAir.SelectedItem is GroundAir)
                    item.GroundAir = (GroundAir)comboBoxGroundAir.SelectedItem;
                else item.GroundAir = GroundAir.Ground;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

        /*
         * Реализация
         */
    }
}
