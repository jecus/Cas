using System;

namespace SmartCore.Auxiliary
{

    /// <summary>
    /// Класс выполняет дополнительные преобразования типов
    /// </summary>
    public static class Convert
    {

        #region public static TimeSpan ToTimeSpan(Int32 totalMinutes)
        /// <summary>
        /// Общее количество минут переводит в объект TimeSpan 
        /// </summary>
        /// <param name="totalMinutes"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(Int32 totalMinutes)
        {
            return new TimeSpan(totalMinutes / 60, totalMinutes % 60, 0);
        }
        #endregion

        #region public static Int32 ToInt32(TimeSpan time)
        /// <summary>
        /// Переводит Time Span в количество минут
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Int32 ToInt32(TimeSpan time)
        {
            return time.Minutes + time.Hours * 60;
        }
        #endregion

        /*
        * Вывод даты
        */

        #region static public String GetDateFormat(DateTime date, string separator = "-")

        /// <summary>
        /// Возвращает дату в формате дд-месяц-гг
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static String GetDateFormat(DateTime date, string separator = "-")
        {
            
            String[] mount = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            return (date.Day + separator + mount[date.Month - 1] + separator + date.Year);
            

        }
        #endregion

        #region public static string DatePeriodToString(DateTime date1, DateTime date2)

        /// <summary>
        /// Представляет период времени в строковом виде
        /// </summary>
        /// <param name="dateMin"></param>
        /// <param name="dateMax"></param>
        /// <returns></returns>
        public static string DatePeriodToString(DateTime dateMin, DateTime dateMax)
        {
            String[] mount = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            if (dateMin.Year == dateMax.Year)
            {
                if(dateMin.Month == dateMax.Month)
                {
                    if(dateMin.Day == dateMax.Day)
                        return (dateMin.Day + " " + mount[dateMin.Month - 1] + ", " + dateMin.Year);
                    if(dateMin.DayOfYear == new DateTime(dateMin.Year, dateMin.Month, 1).DayOfYear &&
                       dateMax.DayOfYear == new DateTime(dateMin.Year, dateMin.Month, 1).AddMonths(1).AddDays(-1).DayOfYear)
                    {
                        return string.Format("{0}, {1}",
                                             mount[dateMin.Month - 1],
                                             dateMin.Year);    
                    }
                    return string.Format("{0} - {1} {2}, {3}",
                                         dateMin.Day,
                                         dateMax.Day,
                                         mount[dateMin.Month - 1],
                                         dateMin.Year);
                }
                return string.Format("{0} {1} - {2} {3}, {4}",
                                      dateMin.Day,
                                      mount[dateMin.Month - 1],
                                      dateMax.Day,
                                      mount[dateMax.Month - 1],
                                      dateMax.Year);
            }
            return string.Format("{0} {1}  {2} - {3} {4}  {5}",
                                 dateMin.Day,
                                 mount[dateMin.Month - 1],
                                 dateMin.Year,
                                 dateMax.Day,
                                 mount[dateMax.Month - 1],
                                 dateMax.Year);
        }

        #endregion

    }

}
