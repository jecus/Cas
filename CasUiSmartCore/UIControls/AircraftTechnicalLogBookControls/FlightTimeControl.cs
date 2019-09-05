using System;
using System.ComponentModel;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол отображает информацию о времени полета
    /// </summary>
    public partial class FlightTimeControl : Interfaces.EditObjectControl
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
                //TimeSpan time1, time2;
                //UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2);
                //Flight.OutTime = (Int32)time1.TotalMinutes;
                //Flight.InTime = (Int32)time2.TotalMinutes;
                Flight.OutTime = (Int32) dateTimePickerOut.Value.TimeOfDay.TotalMinutes;
                Flight.InTime = (Int32) dateTimePickerIn.Value.TimeOfDay.TotalMinutes;
                //UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2);
                //Flight.TakeOffTime = (Int32)time1.TotalMinutes;
                //Flight.LDGTime = (Int32)time2.TotalMinutes;
                Flight.TakeOffTime = (Int32)dateTimePickerTakeOff.Value.TimeOfDay.TotalMinutes;
                Flight.LDGTime = (Int32)dateTimePickerLDG.Value.TimeOfDay.TotalMinutes;
                Flight.NightTime = (Int32) dateTimePickerNight.Value.TimeOfDay.TotalMinutes;
                Flight.DelayTime = (short) numericUpDownDelay.Value;
                Flight.DelayReason = reasonComboBox.SelectedReason;
                Flight.CancelReason = reasonComboBoxCancelled.SelectedReason;
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
            reasonComboBox.ReasonCategory = "Delay";
            reasonComboBoxCancelled.ReasonCategory = "Cancel";
            if (Flight != null)
            {
                numericUpDownDelay.Value = Flight.DelayTime;
                reasonComboBox.SelectedReason = Flight.DelayReason;
                reasonComboBoxCancelled.SelectedReason = Flight.CancelReason;
                dateTimePickerOut.Value = Flight.FlightDate.Date.AddMinutes(Flight.OutTime);
                dateTimePickerIn.Value = Flight.FlightDate.Date.AddMinutes(Flight.InTime);
                dateTimePickerTakeOff.Value = Flight.FlightDate.Date.AddMinutes(Flight.TakeOffTime);
                dateTimePickerLDG.Value = Flight.FlightDate.Date.AddMinutes(Flight.LDGTime);
                dateTimePickerNight.Value = Flight.FlightDate.Date.AddMinutes(Flight.NightTime);
            }
            else
            {
                dateTimePickerOut.Value = DateTime.Today;
                dateTimePickerIn.Value = DateTime.Today;
                dateTimePickerTakeOff.Value = DateTime.Today;
                dateTimePickerLDG.Value = DateTime.Today;
                dateTimePickerNight.Value = DateTime.Today;
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

            //if (!ValidateTimePeriod(textOutIn)) return false;
            //if (!ValidateTimePeriod(textTakeOffLDG)) return false;

            //
            return true;
        }
        #endregion

        /*
         * События формы
         */

        #region private void TextOutInTextChanged(object sender, EventArgs e)
        ///// <summary>
        ///// Пользователь ввел изменения в интервал времени, изменяем разницу
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextOutInTextChanged(object sender, EventArgs e)
        //{
        //    TimeSpan time1, time2;
        //    if (UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2))
        //    {
        //        textBlock.Text = UsefulMethods.TimeToString(UsefulMethods.GetDifference(time2, time1));
        //    }
        //    else
        //    {
        //        textBlock.Text = "";
        //    }
        //}
        #endregion

        #region private void TextTakeOffLDGTextChanged(object sender, EventArgs e)
        ///// <summary>
        ///// Пользователь ввел изменения в интервал времени, изменяем разницу
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextTakeOffLDGTextChanged(object sender, EventArgs e)
        //{
        //    TimeSpan time1, time2;
        //    if (UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2))
        //    {
        //        textFlight.Text = UsefulMethods.TimeToString(UsefulMethods.GetDifference(time2, time1));
        //    }
        //    else
        //    {
        //        textFlight.Text = "";
        //    }
        //}
        #endregion

        #region private void TextOutInLeave(object sender, EventArgs e)
        ///// <summary>
        ///// Пользователь покидает поле ввода интервала, приводим к нужному формату
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextOutInLeave(object sender, EventArgs e)
        //{
        //    TimeSpan time1, time2;
        //    if (UsefulMethods.ParseTimePeriod(textOutIn.Text, out time1, out time2))
        //        textOutIn.Text = UsefulMethods.TimePeriodToString(time1, time2);
        //}
        #endregion

        #region private void TextTakeOffLDGLeave(object sender, EventArgs e)
        ///// <summary>
        ///// Пользователь покидает поле ввода интервала, приводим к нужному формату
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextTakeOffLDGLeave(object sender, EventArgs e)
        //{
        //    TimeSpan time1, time2;
        //    if (UsefulMethods.ParseTimePeriod(textTakeOffLDG.Text, out time1, out time2))
        //        textTakeOffLDG.Text = UsefulMethods.TimePeriodToString(time1, time2);
        //}
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateTimePeriod(TextBox textBox)
        ///// <summary>
        ///// Проверяем введенный интервал времени
        ///// </summary>
        ///// <returns></returns>
        //private bool ValidateTimePeriod(TextBox textBox)
        //{

        //    TimeSpan time1, time2;
        //    if (!UsefulMethods.ParseTimePeriod(textBox.Text, out time1, out time2))
        //    {
                
        //        SimpleBalloon.Show(textBox, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH.MM - HH.MM");

        //        return false;
        //    }

        //    //
        //    return true;
        //}
        #endregion

        #region private void DateTimePickerOutValueChanged(object sender, EventArgs e)
        private void DateTimePickerOutValueChanged(object sender, EventArgs e)
        {
            if(sender != dateTimePickerIn && sender != dateTimePickerOut)
                return;
            textBlock.Text = 
                UsefulMethods.TimeToString(UsefulMethods.GetDifference(dateTimePickerIn.Value.TimeOfDay, 
                                                                       dateTimePickerOut.Value.TimeOfDay));

            if (sender == dateTimePickerOut)
            {
                InvokeOutTimeChanget(dateTimePickerOut.Value);

                dateTimePickerTakeOff.Value = dateTimePickerOut.Value;
            }
            if (sender == dateTimePickerIn)
            {
                InvokeInTimeChanget(dateTimePickerIn.Value);

                dateTimePickerLDG.Value = dateTimePickerIn.Value;
            }
        }
        #endregion

        #region private void DateTimePickerLDGValueChanged(object sender, EventArgs e)
        private void DateTimePickerLDGValueChanged(object sender, EventArgs e)
        {
            if (sender != dateTimePickerTakeOff && sender != dateTimePickerLDG)
                return;

            TimeSpan flightDifference = 
                UsefulMethods.GetDifference(dateTimePickerLDG.Value.TimeOfDay,
                                            dateTimePickerTakeOff.Value.TimeOfDay);
            TimeSpan day =
                UsefulMethods.GetDifference(flightDifference, 
                                            dateTimePickerNight.Value.TimeOfDay);
            textFlight.Text =
                UsefulMethods.TimeToString(flightDifference);
            textBoxDay.Text =
                UsefulMethods.TimeToString(day);

            if (sender == dateTimePickerTakeOff) InvokeTakeOffTimeChanget(dateTimePickerTakeOff.Value);
            if (sender == dateTimePickerLDG) InvokeLDGTimeChanget(dateTimePickerLDG.Value);
            InvokeFlightTimeChanget(flightDifference);
		}
        #endregion

        #region private void DateTimePickerNightValueChanged(object sender, EventArgs e)
        private void DateTimePickerNightValueChanged(object sender, EventArgs e)
        {
            TimeSpan flightDifference =
                UsefulMethods.GetDifference(dateTimePickerLDG.Value.TimeOfDay,
                                            dateTimePickerTakeOff.Value.TimeOfDay);
            TimeSpan day =
                UsefulMethods.GetDifference(flightDifference,
                                            dateTimePickerNight.Value.TimeOfDay);
            textBoxDay.Text =
                UsefulMethods.TimeToString(day);
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает при изменении времени вывода из ангара
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени вывода из ангара")]
        public event DateChangedEventHandler OutTimeChanget;

        ///<summary>
        /// Возникает при изменении времени ввода в ангар
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени ввода в ангар")]
        public event DateChangedEventHandler InTimeChanget;

        ///<summary>
        /// Возникает при изменении времени взлета
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени взлета")]
        public event DateChangedEventHandler TakeOffTimeChanget;

        ///<summary>
        /// Возникает при изменении времени посадки
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени посадки")]
        public event DateChangedEventHandler LDGTimeChanget;
        
        ///<summary>
        /// Возникает при изменении времени посадки
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени полета")]
        public event EventHandler FlightTimeChanget;

        ///<summary>
        /// Сигнализирует об изменении времени вывода из ангара
        ///</summary>
        ///<param name="e"></param>
        private void InvokeOutTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = OutTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        ///<summary>
        /// Сигнализирует об изменении времени взлета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeInTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = InTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        ///<summary>
        /// Сигнализирует об изменении времени ввода в ангар
        ///</summary>
        ///<param name="e"></param>
        private void InvokeTakeOffTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = TakeOffTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        ///<summary>
        /// Сигнализирует об изменении времени посадки
        ///</summary>
        ///<param name="e"></param>
        private void InvokeLDGTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = LDGTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        private void InvokeFlightTimeChanget(TimeSpan e)
        {
            EventHandler handler = FlightTimeChanget;
            if (handler != null) handler(e, new EventArgs());
        }

        #endregion

	    public void EnableControls(AtlbRecordType atlbRecordType)
	    {
		    dateTimePickerOut.Enabled = dateTimePickerIn.Enabled = textBlock.Enabled =
			    dateTimePickerTakeOff.Enabled = dateTimePickerLDG.Enabled =
				    textFlight.Enabled = atlbRecordType != AtlbRecordType.Maintenance;

	    }
    }
}

