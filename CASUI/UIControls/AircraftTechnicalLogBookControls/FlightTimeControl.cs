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
    /// Контрол отображает информацию о времени полета
    /// </summary>
    public partial class FlightTimeControl : CAS.UI.Interfaces.EditObjectControl
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

        #region public FlightTimeControl()
        /// <summary>
        /// Контрол отображает информацию о времени полета
        /// </summary>
        public FlightTimeControl()
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
            if (Flight != null)
            {
                TimeSpan time1, time2;
                UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2);
                Flight.OutTime = time1;
                Flight.InTime = time2;
                UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2);
                Flight.TakeOffTime = time1;
                Flight.LdgTime = time2;
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
            if (Flight != null)
            {
                textOutIn.Text = UsefulMethods.TimePeriodToString(Flight.OutTime, Flight.InTime);
                textTakeOffLDG.Text = UsefulMethods.TimePeriodToString(Flight.TakeOffTime, Flight.LdgTime);
            }
            else
            {
                textOutIn.Text = textTakeOffLDG.Text = "";
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

            if (!ValidateTimePeriod(textOutIn)) return false;
            if (!ValidateTimePeriod(textTakeOffLDG)) return false;

            //
            return true;
        }
        #endregion

        /*
         * События формы
         */

        #region private void textOutIn_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Пользователь ввел изменения в интервал времени, изменяем разницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textOutIn_TextChanged(object sender, EventArgs e)
        {
            TimeSpan time1, time2;
            if (UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2))
            {
                textBlock.Text = UsefulMethods.TimeToString(UsefulMethods.GetDifference(time2, time1));
            }
            else
            {
                textBlock.Text = "";
            }
        }
        #endregion

        #region private void textTakeOffLDG_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Пользователь ввел изменения в интервал времени, изменяем разницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textTakeOffLDG_TextChanged(object sender, EventArgs e)
        {
            TimeSpan time1, time2;
            if (UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2))
            {
                textFlight.Text = UsefulMethods.TimeToString(UsefulMethods.GetDifference(time2, time1));
            }
            else
            {
                textFlight.Text = "";
            }
        }
        #endregion

        #region private void textOutIn_Leave(object sender, EventArgs e)
        /// <summary>
        /// Пользователь покидает поле ввода интервала, приводим к нужному формату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textOutIn_Leave(object sender, EventArgs e)
        {
            TimeSpan time1, time2;
            if (UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2))
                textOutIn.Text = UsefulMethods.TimePeriodToString(time1, time2);
        }
        #endregion

        #region private void textTakeOffLDG_Leave(object sender, EventArgs e)
        /// <summary>
        /// Пользователь покидает поле ввода интервала, приводим к нужному формату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textTakeOffLDG_Leave(object sender, EventArgs e)
        {
            TimeSpan time1, time2;
            if (UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2))
                textTakeOffLDG.Text = UsefulMethods.TimePeriodToString(time1, time2);
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

    }
}

