using System;


namespace SmartCore.Calculations
{
    ///<summary>
    ///</summary>
    public class LifelengthFormatter
    {
        private TimeSpanFormatter hoursFormatter;
        private TimeSpanFormatter calendarFormatter;
        private int cyclesFieldLength;
        private readonly string notApplicableString = "";

        #region Constructors
        ///<summary>
        ///</summary>
        ///<param name="hoursFormatter"></param>
        ///<param name="cyclesFieldLength"></param>
        ///<param name="calendarFormatter"></param>
        public LifelengthFormatter(TimeSpanFormatter hoursFormatter, int cyclesFieldLength, TimeSpanFormatter calendarFormatter)
        {
            this.cyclesFieldLength = cyclesFieldLength;
            this.hoursFormatter = hoursFormatter;
            this.calendarFormatter = calendarFormatter;
        }

        /// <summary>
        /// Создается формировщик наработки по умолчанию
        /// </summary>
        public LifelengthFormatter():this(new TimeSpanFormatter(0, 6, 0, false, true, false), 6, new TimeSpanFormatter(6, 0, 0, true, false, false))
        {
            
        }
        #endregion

        #region Methods

        #region public string GetCalendarMask()
        ///<summary>
        /// Маска календарной наработки
        ///</summary>
        public string GetCalendarMask()
        {
            
            return calendarFormatter.GetMask();
        }
        #endregion

        #region public string GetHoursMask()
        ///<summary>
        /// Маска наработки по часам
        ///</summary>
        public string GetHoursMask()
        {
            return hoursFormatter.GetMask();
            
        }
        #endregion

        #region public string GetCyclesMask()
        ///<summary>
        /// Маска наработки по циклам
        ///</summary>
        public string GetCyclesMask()
        {
            string mask = "";
            for (int i = 0; i < cyclesFieldLength; i++)
                mask = "9" + mask;
            return mask;
        }
        #endregion

        #region public string GetCalendarData(TimeSpan item)
        ///<summary>
        /// Календарное значение наработки
        ///</summary>
        public string GetCalendarData(TimeSpan item)
        {
            return calendarFormatter.GetData(item);
        }
        #endregion

        #region public string GetCalendarData(Lifelength source, string calendarRemark)

        /// <summary>
        /// Календарное значение наработки
        /// </summary>
        /// <param name="source">Источник наработки</param>
        /// <param name="calendarRemark">Замечания, идущие после значения</param>
        /// <returns></returns>
        public string GetCalendarData(Lifelength source, string calendarRemark)
        {
            if (calendarRemark == "")
                return notApplicableString;
            if (source == null)
                return notApplicableString;
            if (source.Days!=null)
                return GetCalendarData(new Lifelength(source.Days,0,0)) + calendarRemark;
            return notApplicableString;
        }

        #endregion

        #region public string GetCalendarData(Lifelength source)

        /// <summary>
        /// Календарное значение наработки
        /// </summary>
        /// <param name="source">Источник наработки</param>
        /// <returns></returns>
        public string GetCalendarData(Lifelength source)
        {
            int days=0;
            if (source.Days!=null)
                days = (int)Math.Round((double)source.Days);            

            string calendar="";
            if (days != 0)
            {
                if (((int)(days / 365) * 365 <= days) && ((int)(days / 365) * 366 >= days))
                    calendar = (days/365).ToString() + " year";

                else if (days%360 == 0)
                    calendar = (days/360).ToString() + " year";

                else if (days%30 == 0)

                    if ((days/30)%6 == 0)
                        calendar = (days/30/6).ToString() + " year";
                    else
                        calendar = (days/30).ToString() + " month";

                else
                    calendar = days.ToString() + " day";
            }

            return calendar;
        }

        #endregion


        #region public string GetHoursData(Lifelength source, string hoursRemark)

        ///<summary>
        /// Вычисляется значение наработки по часам
        ///</summary>
        ///<param name="source">Источник нарботки</param>
        ///<param name="hoursRemark">Замечания, после значения</param>
        ///<returns></returns>
        public string GetHoursData(Lifelength source, string hoursRemark)
        {

            if (source == null)
                return notApplicableString;
            if (source.TotalMinutes!=null)
                return GetHoursData(new TimeSpan(0,0,(int)source.TotalMinutes,0)) + hoursRemark;
            return notApplicableString;
        }

        #endregion

        #region public string GetCyclesData(Lifelength source, string cyclesRemark)

        ///<summary>
        /// Вычисляется значение наработки по циклам
        ///</summary>
        ///<param name="source">Источник наработки</param>
        ///<param name="cyclesRemark"></param>
        ///<returns></returns>
        public string GetCyclesData(Lifelength source, string cyclesRemark)
        {

            if (source == null)
                return notApplicableString;
            if (source.Cycles!=null)
                return source.Cycles.ToString() + cyclesRemark;
            return notApplicableString;
        }

        #endregion

        #region public string GetHoursData(TimeSpan item)
        ///<summary>
        /// Данные наработки по часам
        ///</summary>
        public string GetHoursData(TimeSpan item)
        {
            return hoursFormatter.GetData(item);
        }
        #endregion

        #region public string GetData(Lifelength source, string hoursRemark, string cyclesRemark, string calendarRemark)
        ///<summary>
        /// Получается информация, отображающая наработку
        ///</summary>
        ///<param name="source">Исходная наработка</param>
        ///<param name="hoursRemark">Текст, идущий после значения наработки по часам</param>
        ///<param name="cyclesRemark">Текст, идущий после значения наработки по циклам</param>
        ///<param name="calendarRemark">Текст, идущий после значения наработки по календарю</param>
        ///<returns></returns>
        public string GetData(Lifelength source, string hoursRemark, string cyclesRemark, string calendarRemark)
        {
            return
                GetHoursData(source, hoursRemark) + GetCyclesData(source, cyclesRemark) + GetCalendarData(source, calendarRemark);
        }
        #endregion

        #region public string GetData(Lifelength source, string hoursRemark, string cyclesRemark)
        ///<summary>
        /// Получается информация, отображающая наработку
        ///</summary>
        ///<param name="source">Исходная наработка</param>
        ///<param name="hoursRemark">Текст, идущий после значения наработки по часам</param>
        ///<param name="cyclesRemark">Текст, идущий после значения наработки по циклам</param>
        ///<returns></returns>
        public string GetData(Lifelength source, string hoursRemark, string cyclesRemark)
        {
            return
                GetHoursData(source, hoursRemark) + GetCyclesData(source, cyclesRemark) + GetCalendarData(source);
        }
        #endregion

        #region public string GetData(Lifelength source, string hoursRemark, string cyclesRemark, string calendarRemark, bool showHours, bool showCycles, bool showCalendar)
        ///<summary>
        /// Получается информация, отображающая наработку
        ///</summary>
        ///<param name="source">Исходная наработка</param>
        ///<param name="hoursRemark">Текст, идущий после значения наработки по часам</param>
        ///<param name="cyclesRemark">Текст, идущий после значения наработки по циклам</param>
        ///<param name="calendarRemark">Текст, идущий после значения наработки по календарю</param>
        /// <param name="showHours"></param>
        /// <param name="showCycles"></param>
        /// <param name="showCalendar"></param>
        ///<returns></returns>
        public string GetData(Lifelength source, string hoursRemark, string cyclesRemark, string calendarRemark, bool showHours, bool showCycles, bool showCalendar)
        {
            string res = "";
            if (showHours)
                res += GetHoursData(source, hoursRemark);
            if (showCycles)
                res += GetCyclesData(source, cyclesRemark);
            if (showCalendar)
                res += GetCalendarData(source, calendarRemark);
            return res;
        }
        #endregion

        #region public string GetDataWithCalendar(Lifelength lifelength, string hoursRemark, string cyclesRemark, string calendarRemark)

        ///<summary>
        /// Получается информация, отображающая наработку. Календарная наработка отображается как дата
        ///</summary>
        ///<param name="lifelength">Исходная наработка</param>
        ///<param name="hoursRemark">Текст, идущий после значения наработки по часам</param>
        ///<param name="cyclesRemark">Текст, идущий после значения наработки по циклам</param>
        ///<param name="calendarRemark">Текст, идущий после значения наработки по календарю</param>
        ///<returns></returns>
        public string GetDataWithCalendar(Lifelength lifelength, string hoursRemark, string cyclesRemark, string calendarRemark)
        {
            return GetHoursData(lifelength, hoursRemark) + GetCyclesData(lifelength, cyclesRemark) + GetCalendar(lifelength, calendarRemark);
        }

        #endregion

        #region public string GetCalendar(Lifelength lifelength, string remark)

        /// <summary>
        /// Вычисляется календарная наработка как дата
        /// </summary>
        /// <param name="lifelength">Исходная наработка</param>
        /// <param name="remark">Замечания после данных</param>
        /// <returns></returns>
        public string GetCalendar(Lifelength lifelength, string remark)
        {
            return new DateTime(new TimeSpan(0,0,(int)lifelength.Days).Ticks).ToShortDateString() + remark;
        }

        #endregion

        #region public TimeSpanFormatter HoursFormatter
        ///<summary>
        /// Формировщик часовой наработоки
        ///</summary>
        public TimeSpanFormatter HoursFormatter
        {
            get { return hoursFormatter; }
            set { hoursFormatter = value; }
        }
        #endregion

        #region public TimeSpanFormatter CalendarFormatter
        ///<summary>
        /// Формировщик календарной наработоки
        ///</summary>
        public TimeSpanFormatter CalendarFormatter
        {
            get { return calendarFormatter; }
            set { calendarFormatter = value; }
        }
        #endregion

        #region public int CyclesFieldLength
        ///<summary>
        /// Формировщик наработоки по циклам
        ///</summary>
        public int CyclesFieldLength
        {
            get { return cyclesFieldLength; }
            set { cyclesFieldLength = value; }
        }
        #endregion

        #region public TimeSpan CalendarValueFromString(string source)
        /// <summary>
        /// Получается значение календарной наработки из исходной строки
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <returns>Полученное значение</returns>
        public TimeSpan CalendarValueFromString(string source)
        {
            return calendarFormatter.ValueFromString(source);
        }
        #endregion

        #region public TimeSpan HoursValueFromString(string source)
        /// <summary>
        /// Получается значение часовой наработки из исходной строки
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <returns>Полученное значение</returns>
        public TimeSpan HoursValueFromString(string source)
        {
            return hoursFormatter.ValueFromString(source);
        }
        #endregion

        #region public int CyclesValueFromString(string source)
        ///<summary>
        /// Получение наработки по циклам из строки
        ///</summary>
        ///<param name="source">Исходная строка</param>
        ///<returns>Полученное значение</returns>
        public int CyclesValueFromString(string source)
        {
            int value;
            int.TryParse(source, out value);
            return value;
        }
        #endregion

        #region public string GetHoursCyclesData(Lifelength source, string hoursRemark, string cyclesRemark)
        ///<summary>
        /// Получается информация, отображающая наработку в часах и циклах
        ///</summary>
        ///<param name="source">Исходная наработка</param>
        ///<param name="hoursRemark">Текст, идущий после значения наработки по часам</param>
        ///<param name="cyclesRemark">Текст, идущий после значения наработки по циклам</param>
        ///<returns></returns>
        public string GetHoursCyclesData(Lifelength source, string hoursRemark, string cyclesRemark)
        {
            return
                GetHoursData(source, hoursRemark) + GetCyclesData(source, cyclesRemark);
        }
        #endregion
        #endregion

    }
}
