using System;

namespace SmartCore.Calculations
{
    ///<summary>
    /// 
    ///</summary>
    public class TimeSpanFormatter
    {
        /// <summary>
        /// Длина поля часы
        /// </summary>
        private int hoursFieldLength;
        /// <summary>
        /// Длина поля Дни
        /// </summary>
        private int daysFieldLength;
        /// <summary>
        /// Длина поля Минуты
        /// </summary>
        private int minutesFieldLength;
        /// <summary>
        /// Отображать ли дни
        /// </summary>
        private bool showDays;
        /// <summary>
        /// Отображать ли минуты
        /// </summary>
        private bool showMinutes;
        /// <summary>
        /// Отображать ли часы
        /// </summary>
        private bool showHours;

        ///<summary>
        ///</summary>
        ///<param name="daysFieldLength"></param>
        ///<param name="hoursFieldLength"></param>
        ///<param name="minutesFieldLength"></param>
        ///<param name="showDays"></param>
        ///<param name="showHours"></param>
        ///<param name="showMinutes"></param>
        public TimeSpanFormatter(int daysFieldLength, int hoursFieldLength, int minutesFieldLength, bool showDays,
                                 bool showHours, bool showMinutes)
        {
            this.hoursFieldLength = hoursFieldLength;
            this.daysFieldLength = daysFieldLength;
            this.minutesFieldLength = minutesFieldLength;
            this.showDays = showDays;
            this.showMinutes = showMinutes;
            this.showHours = showHours;
        }

        #region Properties
        /// <summary>
        /// Длина поля часы
        /// </summary>
        public int HoursFieldLength
        {
            get { return hoursFieldLength; }
            set { hoursFieldLength = value; }
        }

        /// <summary>
        /// Длина поля Дни
        /// </summary>
        public int DaysFieldLength
        {
            get { return daysFieldLength; }
            set { daysFieldLength = value; }
        }

        /// <summary>
        /// Длина поля Минуты
        /// </summary>
        public int MinutesFieldLength
        {
            get { return minutesFieldLength; }
            set { minutesFieldLength = value; }
        }

        /// <summary>
        /// Отображать ли дни
        /// </summary>
        public bool ShowDays
        {
            get { return showDays; }
            set { showDays = value; }
        }

        /// <summary>
        /// Отображать ли минуты
        /// </summary>
        public bool ShowMinutes
        {
            get { return showMinutes; }
            set { showMinutes = value; }
        }

        /// <summary>
        /// Отображать ли часы
        /// </summary>
        public bool ShowHours
        {
            get { return showHours; }
            set { showHours = value; }
        }
        #endregion

        #region public TimeSpanFormatter(TimeSpan item, int hoursFieldLength)
        ///<summary>
        /// Создается форматер для отображения промежутка времени в формате отображения всех часов и минут
        ///</summary>
        ///<param name="hoursFieldLength">Длина отображения часов</param>
        public TimeSpanFormatter(int hoursFieldLength):this(0, hoursFieldLength, 2, false, true, true)
        {
        }
        #endregion

        #region public string Mask
        ///<summary>
        /// Маска для отображения объекта с заданными параметрами
        ///</summary>
        /// <returns>Значение</returns>
        public string GetMask()
        {
            string daysMask = "";
            if (showDays)
            {
                for (int i = 0; i < daysFieldLength; i++) daysMask+= "9";
            }
            string hoursMask = "";
            if (showHours)
            {
                for (int i = 0; i < hoursFieldLength; i++) hoursMask += "9";
            }
            string minutesMask = "";
            if (showMinutes)
            {
                for (int i = 0; i < minutesFieldLength; i++) minutesMask += "0";
            }
            if (showDays)
            {
                if (showHours)
                {
                    if (showMinutes)
                        return daysMask + ":" + hoursMask + ":" + minutesMask;
                    return daysMask + ":" + hoursMask;
                }
                return daysMask;
            }
            else
            {
                if (showHours)
                {
                    if (showMinutes)
                        return hoursMask + ":" + minutesMask;
                    return hoursMask;
                }
                else
                {
                    if (showMinutes)
                        return minutesMask;
                }
            }
            return "";
        }
        #endregion

        #region public string Data
        ///<summary>
        /// Переконвертировать объект
        ///</summary>
        /// <param name="item">Конвертируемый объект</param>
        /// <returns>Значение</returns>
        public string GetData(TimeSpan item)
        {
            TimeSpan time = item;
            string days ="";
            if (showDays)
            {
                if (showHours)
                    days = ((int) time.TotalDays).ToString();
                else
                    days = ((int)(time.TotalDays + 0.5)).ToString();
                time.Subtract(new TimeSpan((int)time.TotalDays, 0, 0, 0));
            }

            string hours="";
            if (showHours)
            {
                hours = ((int) time.TotalHours).ToString();
                time.Subtract(new TimeSpan(0, (int)time.TotalHours, 0, 0));
            }

            string minutes ="";
            if (showMinutes)
            {
                minutes = ((int) time.TotalMinutes).ToString();
                if (minutes.Length == 1)
                    minutes = "0" + minutes;
                time.Subtract(new TimeSpan(0, (int)time.TotalMinutes, 0, 0));
            }

            if (showDays)
            {
                if (showHours)
                {
                    if (showMinutes)
                        return days + ":" + hours + ":" + minutes;
                    return days + ":" + hours;
                }
                return days;
            }
            else
            {
                if (showHours)
                {
                    if (showMinutes)
                        return hours + ":" + minutes;
                    return hours;
                }
                else
                {
                    if (showMinutes)
                        return minutes;
                }
            }
            return "";
        }
        #endregion

        #region public TimeSpan ValueFromString(string source)
        ///<summary>
        /// Получается значение промежутка времени по строке
        ///</summary>
        ///<param name="source">Исходная строка</param>
        ///<returns>Значение времени</returns>
        public TimeSpan ValueFromString(string source)
        {
            string[] splitted = source.Split(new char[1]{':'});
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
            int days = 0;
            if (showDays && showHours && showMinutes)
            {
                if (splitted.Length > 2) int.TryParse(splitted[2], out minutes);
                if (splitted.Length > 1) int.TryParse(splitted[1], out hours);
                if (splitted.Length > 0) int.TryParse(splitted[0], out days);
            }
            if (showDays && showHours && !showMinutes)
            {
                if (splitted.Length > 1) int.TryParse(splitted[1], out hours);
                if (splitted.Length > 0) int.TryParse(splitted[0], out days);
            }
            if (showDays && !showHours && !showMinutes)
            {
                if (splitted.Length > 0) int.TryParse(splitted[0], out days);
            }
            if (!showDays && showHours && showMinutes)
            {
                if (splitted.Length > 1) int.TryParse(splitted[1], out minutes);
                if (splitted.Length > 0) int.TryParse(splitted[0], out hours);
            }
            if (!showDays && !showHours && showMinutes)
            {
                if (splitted.Length > 0) int.TryParse(splitted[0], out minutes);
            }
            if (!showDays && showHours && !showMinutes)
            {
                if (splitted.Length > 0) int.TryParse(splitted[0], out hours);
            }
            return new TimeSpan(days, hours, minutes, seconds);
        }
        #endregion

    }
}
