using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{


    /// <summary>
    /// Контрол отображает информацию по двигателя во время полета
    /// </summary>
    public partial class EngineMonitoringControl : CAS.UI.Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public EngineMonitoringControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public EngineMonitoringControl()
        {
            InitializeComponent();
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

            // Заполняем общие данные о проведении измерений
            if (Flight != null)
            {
                EnginesGeneralCondition egc = Flight.EnginesGeneralCondition;
                egc.PressALT = textPressAlt.Text;
                TimeSpan time;
                if (TimeSpan.TryParse(textGMT.Text, out time))
                {
                    egc.TimeGMT = time; 
                }
                egc.GrossWeight = UsefulMethods.StringToDouble(textGrossWeight.Text);
                egc.IAS = UsefulMethods.StringToDouble(textIAS.Text);
                egc.MACH = UsefulMethods.StringToDouble(textMach.Text);
                egc.TAT = UsefulMethods.StringToDouble(textTAT.Text);
                egc.OAT = UsefulMethods.StringToDouble(textOAT.Text);
            }

            // Заполняем данные о первом двигателе
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 1)
            {
                EngineCondition eng = Flight.EngineConditions[0];
                eng.EPR = UsefulMethods.StringToDouble(textERP1.Text);
                eng.N1 = UsefulMethods.StringToDouble(textN11.Text);
                eng.EGT = UsefulMethods.StringToDouble(textEGT1.Text);
                eng.N2 = UsefulMethods.StringToDouble(textN21.Text);
                eng.OilTemperature = UsefulMethods.StringToDouble(textOilTemperature1.Text);
                eng.OilPressure = UsefulMethods.StringToDouble(textOilPressure1.Text);
                eng.FuelFlow = UsefulMethods.StringToDouble(textFuelFlow1.Text);
                eng.FuelBurn = UsefulMethods.StringToDouble(textFuelBurn1.Text);
            }

            // Заполняем данные о первом двигателе
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 2)
            {
                EngineCondition eng = Flight.EngineConditions[1];
                eng.EPR = UsefulMethods.StringToDouble(textERP2.Text);
                eng.N1 = UsefulMethods.StringToDouble(textN12.Text);
                eng.EGT = UsefulMethods.StringToDouble(textEGT2.Text);
                eng.N2 = UsefulMethods.StringToDouble(textN22.Text);
                eng.OilTemperature = UsefulMethods.StringToDouble(textOilTemperature2.Text);
                eng.OilPressure = UsefulMethods.StringToDouble(textOilPressure2.Text);
                eng.FuelFlow = UsefulMethods.StringToDouble(textFuelFlow2.Text);
                eng.FuelBurn = UsefulMethods.StringToDouble(textFuelBurn2.Text);
            }

            //
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

            // Заполняем общие данные проведения измерений
            if (Flight != null && Flight.EnginesGeneralCondition != null)
            {
                textPressAlt.Text = Flight.EnginesGeneralCondition.PressALT;
                textGMT.Text = UsefulMethods.TimeToString(Flight.EnginesGeneralCondition.TimeGMT);
                textGrossWeight.Text = Flight.EnginesGeneralCondition.GrossWeight.ToString();
                textIAS.Text = Flight.EnginesGeneralCondition.IAS.ToString();
                textMach.Text = Flight.EnginesGeneralCondition.MACH.ToString();
                textTAT.Text = Flight.EnginesGeneralCondition.TAT.ToString();
                textOAT.Text = Flight.EnginesGeneralCondition.OAT.ToString();
            }
            else
            {
                textPressAlt.Text = textGMT.Text = textGrossWeight.Text = textIAS.Text = textMach.Text = textTAT.Text = textOAT.Text = "";
            }


            // Заполняем данные первого двигателя
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 1)
            {
                EngineCondition eng = Flight.EngineConditions[0];
                if (eng.Engine != null) labelEng1.Text = "ENG " + eng.Engine.PositionNumber;
                else labelEng1.Text = "ENG #1";
                textERP1.Text = eng.EPR.ToString();
                textN11.Text = eng.N1.ToString();
                textEGT1.Text = eng.EGT.ToString();
                textN21.Text = eng.N2.ToString();
                textOilTemperature1.Text = eng.OilTemperature.ToString();
                textOilPressure1.Text = eng.OilPressure.ToString();
                textFuelFlow1.Text = eng.FuelFlow.ToString();
                textFuelBurn1.Text = eng.FuelBurn.ToString();
            }
            else
            {
                textERP1.Text = textN11.Text = textEGT1.Text = textN21.Text = textOilTemperature1.Text = textOilPressure1.Text = 
                    textFuelFlow1.Text = textFuelBurn1.Text = "";
            }

            // Заполняем данные второго двигателя
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 2)
            {
                EngineCondition eng = Flight.EngineConditions[1];
                if (eng.Engine != null) labelEng2.Text = "ENG " + eng.Engine.PositionNumber;
                else labelEng2.Text = "ENG #2";
                textERP2.Text = eng.EPR.ToString();
                textN12.Text = eng.N1.ToString();
                textEGT2.Text = eng.EGT.ToString();
                textN22.Text = eng.N2.ToString();
                textOilTemperature2.Text = eng.OilTemperature.ToString();
                textOilPressure2.Text = eng.OilPressure.ToString();
                textFuelFlow2.Text = eng.FuelFlow.ToString();
                textFuelBurn2.Text = eng.FuelBurn.ToString();
            }
            else
            {
                textERP2.Text = textN12.Text = textEGT2.Text = textN22.Text = textOilTemperature2.Text = textOilPressure2.Text =
                    textFuelFlow2.Text = textFuelBurn2.Text = "";
            }

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
            TimeSpan time;
            if (!TimeSpan.TryParse(textGMT.Text, out time))
            {
                MessageBox.Show("Incorrect time format");
                textGMT.Focus();
                textGMT.SelectAll();
                return false;
            }

            if (!CheckDoubleTextBox(textGrossWeight)) return false;
            if (!CheckDoubleTextBox(textIAS)) return false;
            if (!CheckDoubleTextBox(textMach)) return false;
            if (!CheckDoubleTextBox(textTAT)) return false;
            if (!CheckDoubleTextBox(textOAT)) return false;


            // Проверяем данные первого двигателя
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 1)
            {
                if (!CheckDoubleTextBox(textERP1)) return false;
                if (!CheckDoubleTextBox(textN11)) return false;
                if (!CheckDoubleTextBox(textEGT1)) return false;
                if (!CheckDoubleTextBox(textN21)) return false;
                if (!CheckDoubleTextBox(textOilTemperature1)) return false;
                if (!CheckDoubleTextBox(textOilPressure1)) return false;
                if (!CheckDoubleTextBox(textFuelFlow1)) return false;
                if (!CheckDoubleTextBox(textFuelBurn1)) return false;
            }

            // Проверяем данные второго двигателя
            if (Flight != null && Flight.EngineConditions != null && Flight.EngineConditions.Length >= 2)
            {
                if (!CheckDoubleTextBox(textERP2)) return false;
                if (!CheckDoubleTextBox(textN12)) return false;
                if (!CheckDoubleTextBox(textEGT2)) return false;
                if (!CheckDoubleTextBox(textN22)) return false;
                if (!CheckDoubleTextBox(textOilTemperature2)) return false;
                if (!CheckDoubleTextBox(textOilPressure2)) return false;
                if (!CheckDoubleTextBox(textFuelFlow2)) return false;
                if (!CheckDoubleTextBox(textFuelBurn2)) return false;
            }

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool CheckDoubleTextBox(TextBox textBox)
        /// <summary>
        /// Проверяет правильность ввода дробного числа
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool CheckDoubleTextBox(TextBox textBox)
        {
            double d;
            if (!UsefulMethods.StringToDouble(textBox.Text, out d))
            {
                //
                SimpleBalloon.Show(textBox, ToolTipIcon.Warning, "Incorrect numeric format", "Enter valid number"); 

                return false;
            }

            //
            return true;
        }
        #endregion

    }
}

