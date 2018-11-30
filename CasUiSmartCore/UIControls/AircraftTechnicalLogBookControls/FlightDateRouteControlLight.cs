using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол отображает общую информацию о полете
    /// </summary>
    public partial class FlightDateRouteControlLight : Interfaces.EditObjectControl
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

        #region public FlightGeneralInformationControl()
        /// <summary>
        /// Контрол отображает общую информацию о полете
        /// </summary>
        public FlightDateRouteControlLight()
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
                Flight.FlightNo = textFlightNo.Text;
                Flight.PageNo = textBoxPageNum.Text;
                Flight.FlightDate = dateTimePickerFlightDate.Value.Date;
                Flight.StationFrom = textFrom.Text;
                Flight.StationTo = textTo.Text;
                if (comboBoxRecordType.SelectedItem != null)
                    Flight.AtlbRecordType = (AtlbRecordType)comboBoxRecordType.SelectedItem;
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

            comboBoxRecordType.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(AtlbRecordType)))
                comboBoxRecordType.Items.Add(o);

            if (Flight != null)
            {
                textFlightNo.Text = Flight.FlightNo;
                dateTimePickerFlightDate.Value = Flight.FlightDate.Date;
                textFrom.Text = Flight.StationFrom;
                textTo.Text = Flight.StationTo;
                textBoxPageNum.Text = Flight.PageNo;
                comboBoxRecordType.SelectedItem = Flight.AtlbRecordType > 0 ? Flight.AtlbRecordType : AtlbRecordType.Flight;
            }
            else
            {
                textFlightNo.Text = textFrom.Text = textTo.Text = textBoxPageNum.Text = "";
                comboBoxRecordType.SelectedItem = AtlbRecordType.Flight;
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
            if (!ValidatePageNo()) return false;

            if (dateTimePickerFlightDate.Value > DateTime.Now)
            {
                MessageBox.Show("Flight date must be between 1950.1.1 and today", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidatePageNo()
        /// <summary>
        /// Проверяем Номер страницы
        /// </summary>
        /// <returns></returns>
        private bool ValidatePageNo()
        {
            //Проверка формата написания номера страницы
            int pageNum;
            if (!int.TryParse(textBoxPageNum.Text, out pageNum))
            {
                SimpleBalloon.Show(textBoxPageNum, ToolTipIcon.Warning, "Incorrect page num",
                                   "Please enter the date in the following format: XXXPageNum");

                return false;
            }

            #region//проверка серии в номере страницы
            //if (Flight.ATLBId <= 0) return true;//отсутсвует родительский борт-журнал

            //AircraftFlight firstInAtlb = Flight.ParentAircraft.Flights.GetFirstFlightInAtlb(Flight.ATLBId);
            //AircraftFlight lastInAtlb = Flight.ParentAircraft.Flights.GetLastFlightInAtlb(Flight.ATLBId);

            //if (firstInAtlb == null || (firstInAtlb.PageNo == "" && lastInAtlb.PageNo == "")) 
            //    return true; //отсутсвуют первый (а значит и последний) полеты, несчем сравнивать
            //int firstPageNum, lastPageNum;
            ////проверка на правильность формата введения номера страницы
            //int.TryParse(firstInAtlb.PageNo, out firstPageNum);
            //int.TryParse(lastInAtlb.PageNo, out lastPageNum);
            //if (firstPageNum < 0 && lastPageNum < 0) return true;
            ////Получение серийных номеров
            //string firstSerial = firstPageNum >= 0 ? firstInAtlb.PageNo.Replace(firstPageNum.ToString(), "") : "";
            //string lastSerial = lastPageNum >= 0 ? lastInAtlb.PageNo.Replace(lastPageNum.ToString(), "") : "";
            //string currentSerial = textBoxPageNum.Text.Replace(pageNum.ToString(), "");

            //if (Flight != firstInAtlb && Flight != lastInAtlb && 
            //    firstSerial != currentSerial && lastSerial != currentSerial)
            //{
            //    //SimpleBalloon.Show(textBoxPageNum, ToolTipIcon.Warning, "Incorrect page num Serial",
            //    //                   "Please enter the serial in the following format: " + firstSerial + "PageNum");

            //    //return false;

            //    MessageBox.Show("Incorrect page num Serial. " +
            //                    "\nPlease enter the serial in the following format: " + firstSerial + "PageNum." +
            //                    "\nOr create a new Log",
            //                    new GlobalTermsProvider()["SystemName"].ToString(),
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //    return false;
            //}
            #endregion

            #region//проверка на диапазон
            //if (lastPageNum > firstPageNum)
            //{
            //    //нумерация страниц идет по возрастанию
            //    if((firstPageNum >= 0 && Math.Abs(pageNum - firstPageNum) >= 150 ) &&
            //       (lastPageNum >= 0 && Math.Abs(lastPageNum - pageNum) >= 150))
            //    {
            //        MessageBox.Show("Incorrect page num. " +
            //                    "\nPlease enter the page number in the range from: " + firstPageNum + " to: " + lastPageNum + "." +
            //                    "\nOr create a new Log",
            //                    new GlobalTermsProvider()["SystemName"].ToString(),
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //        return false;    
            //    }
            //}
            //else if (firstPageNum > lastPageNum)
            //{
            //    //нумерация страниц идет по по убыванию
            //    if ((firstPageNum >= 0 && Math.Abs(firstPageNum - pageNum) >= 150) &&
            //        (lastPageNum >= 0 && Math.Abs(pageNum - lastPageNum) >= 150))
            //    {
            //        MessageBox.Show("Incorrect page num. " +
            //                    "\nPlease enter the page number in the range from: " + lastPageNum + " to: " + firstPageNum + "." +
            //                    "\nOr create a new Log",
            //                    new GlobalTermsProvider()["SystemName"].ToString(),
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (firstPageNum >= 0 && Math.Abs(firstPageNum - pageNum) >= 150)
            //    {
            //        MessageBox.Show("Incorrect page num. " +
            //                    "\nPlease enter the page number in the range from: " + firstPageNum + " +- 150." +
            //                    "\nOr create a new Log",
            //                    new GlobalTermsProvider()["SystemName"].ToString(),
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //        return false;
            //    }    
            //}
            #endregion

            #region//Проверка на наличие полета с таким же номером страницы
            var temp = GlobalObjects.AircraftFlightsCore.GetFlightWithPageNum(Flight.AircraftId, pageNum, Flight.ATLBId); 
            if (Flight.ParentATLB != null && 
                temp.Count >= Flight.ParentATLB.PageFlightCount && 
                !temp.Contains(Flight))
            {
                MessageBox.Show(@"The number of flights on a given page number" + 
                                "\nexceeds the possible quantitative flight " + 
                                "\non the same page of the logbook." +
                                "\nPlease enter another page num",
                                new GlobalTermsProvider()["SystemName"].ToString(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }
            #endregion
           
            //DateTime? flightDate = UsefulMethods.StringToDate(textDate.Text);
            //AircraftFlight lastFlightInAtlb = flightDate != null 
            //    ? Flight.ParentAircraft.Flights.GetPreviousKnownRecord(flightDate.Value)
            //    : null;
            //int prevPageNum;
            //if(lastFlightInAtlb != null && int.TryParse(lastFlightInAtlb.PageNo, out prevPageNum))
            //{
            //    //сравнивание номеров страниц предыдущего и текущего полета
            //    if(Math.Abs(prevPageNum - pageNum) > 1)
            //    {
            //        SimpleBalloon.Show(textBoxPageNum, ToolTipIcon.Warning, "Incorrect page num",
            //                       "introduced by the page number is different from the previous more than one unit");
            //        return false;
            //    }
            //}
            return true;
        }
        #endregion

        #region private void DateTimePickerFlightDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerFlightDateValueChanged(object sender, EventArgs e)
        {
            InvokeFlightDateChanget(dateTimePickerFlightDate.Value);
        }
        #endregion

        #region private void comboBoxRecordType_SelectedIndexChanged(object sender, EventArgs e)
        private void comboBoxRecordType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region private void TextFromTextChanged(object sender, EventArgs e)
        private void TextFromTextChanged(object sender, EventArgs e)
        {
            InvokeFlightStationFromChanget(textFrom.Text);
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает во время изменения даты полета
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает во время изменения даты полета")]
        public event DateChangedEventHandler FlightDateChanget;

        ///<summary>
        /// Возникает во время изменения станции отбытия полета
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает во время изменения станции отбытия полета")]
        public event ValueChangedEventHandler FlightStationFromChanget;

        ///<summary>
        /// Сигнализирует об изменени даты полета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeFlightDateChanget(DateTime e)
        {
            DateChangedEventHandler handler = FlightDateChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        ///<summary>
        /// Сигнализирует об изменени даты полета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeFlightStationFromChanget(string e)
        {
            ValueChangedEventHandler handler = FlightStationFromChanget;
            if (handler != null) handler(new ValueChangedEventArgs(e));
        }

        #endregion

    }
}

