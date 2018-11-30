using System;
using System.Windows.Forms;

using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет задавать информацию о жидкостях 
    /// </summary>
    public partial class FlightFluidsControl : Interfaces.EditObjectControl
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

        #region public FlightFluidsControl()
        /// <summary>
        /// Контрол позволяет задать информацию о жидкостях 
        /// </summary>
        public FlightFluidsControl()
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
            if (Flight != null && Flight.FluidsCondition != null)
            {

                // Hydraulic Fluid
                //Flight.FluidsCondition.HydraulicFluidAdded = UsefulMethods.StringToDouble(textAdded.Text);
                //Flight.FluidsCondition.HydraulicFluidOnBoard = UsefulMethods.StringToDouble(textOnBoard.Text);

                // De Iceing
                Flight.FluidsCondition.GroundDeIce = checkDeIce.Checked;

                TimeSpan time1, time2;
                UsefulMethods.ParseTimePeriod(textTimePeriod.Text, out time1, out time2);
                Flight.FluidsCondition.AntiIcingStartTime = time1;
                Flight.FluidsCondition.AntiIcingEndTime = time2;
                Flight.FluidsCondition.AntiIcingFluidType = textFluidType.Text;
                Flight.FluidsCondition.AEACode = textAEACode.Text;
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
            if (Flight != null && Flight.FluidsCondition != null)
            {
                //textAdded.Text = Flight.FluidsCondition.HydraulicFluidAdded.ToString();
                //textOnBoard.Text = Flight.FluidsCondition.HydraulicFluidOnBoard.ToString();
                checkDeIce.Checked = Flight.FluidsCondition.GroundDeIce;
                textTimePeriod.Text = UsefulMethods.TimePeriodToString(Flight.FluidsCondition.AntiIcingStartTime, Flight.FluidsCondition.AntiIcingEndTime);
                textFluidType.Text = Flight.FluidsCondition.AntiIcingFluidType;
                textAEACode.Text = Flight.FluidsCondition.AEACode;
            }
            else
            {
                //textAdded.Text = textOnBoard.Text = textTimePeriod.Text = textFluidType.Text = textAEACode.Text = "";
                checkDeIce.Checked = false;
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

            // Hydraulic Fluid
            //if (!ValidateDoubleTextBox(textAdded)) return false;
            //if (!ValidateDoubleTextBox(textOnBoard)) return false;

            // De Iceing
            if (!ValidateTimePeriod(textTimePeriod)) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateTimePeriod(TextBox textBox)
        /// <summary>
        /// Проверяем введенный интервал времени
        /// </summary>
        /// <returns></returns>
        private bool ValidateTimePeriod(TextBox textBox)
        {

            TimeSpan time1, time2;
            if (!UsefulMethods.ParseTimePeriod(textBox.Text, out time1, out time2))
            {

                SimpleBalloon.Show(textBox, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH.MM - HH.MM"); 

                return false;
            }

            //
            return true;
        }
        #endregion

        #region private bool ValidateDoubleTextBox(TextBox textBox)
        /// <summary>
        /// Проверяет правильность ввода дробного числа
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool ValidateDoubleTextBox(TextBox textBox)
        {
            double d;
            if (!UsefulMethods.StringToDouble(textBox.Text, out d))
            {
                SimpleBalloon.Show(textBox, ToolTipIcon.Warning, "Incorrect numeric format", "Enter valid number"); 
                return false;
            }

            //
            return true;
        }
        #endregion


        /*
         * События контрола
         */

        #region private void TextTimePeriodLeave(object sender, EventArgs e)
        /// <summary>
        /// Когда пользователь ввел интервал времени и уходит с контрола мы проверяем данные и приводим их в нужный формат - например удаляем лишние пробелы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextTimePeriodLeave(object sender, EventArgs e)
        {
            TimeSpan time1, time2;
            if (UsefulMethods.ParseTimePeriod(textTimePeriod.Text, out time1, out time2))
                textTimePeriod.Text = UsefulMethods.TimePeriodToString(time1, time2);
        }
        #endregion
    }
}

