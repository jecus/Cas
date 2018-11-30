using System;
using System.Windows.Forms;

namespace CAS.UI.UIControls.LogBookControls
{
    /// <summary>
    /// Класс, предназначенный для хранения ТУПО даты, без времени
    /// </summary>
    public class Date
    {

        #region Fields

        private DateTime date;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает новый объект типа Date для хранения даты
        /// </summary>
        public Date(DateTime value)
        {
            date = new DateTime(value.Year, value.Month, value.Day,0,0,0);
        }

        #endregion

        #region Properties

        #region public int Year

        /// <summary>
        /// Возвращает количество лет
        /// </summary>
        public int Year
        {
            get
            {
                return date.Year;
            }
        }

        #endregion

        #region public int Month

        /// <summary>
        /// Возвращает количество месяцев
        /// </summary>
        public int Month
        {
            get
            {
                return date.Month;
            }
        }

        #endregion

        #region public int Day

        /// <summary>
        /// Возвращает количество дней
        /// </summary>
        public int Day
        {
            get
            {
                return date.Day;
            }
        }

        #endregion

        #region public DateTime Value

        /// <summary>
        /// Возвращает или устанавливает значение (дату)
        /// </summary>
        public DateTime Value
        {
            get
            {
                return date;
            }
            set
            {
                date = new DateTime(value.Year, value.Month, value.Day,0,0,0);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void AddYears(int yearCount)

        /// <summary>
        /// Добавляет года
        /// </summary>
        /// <param name="yearCount">Количество лет</param>
        public void AddYears(int yearCount)
        {
            date.AddYears(yearCount);
        }

        #endregion

        #region public void AddMonths(int monthsCount)

        /// <summary>
        /// Добавляет месяцы
        /// </summary>
        /// <param name="monthsCount">Количество месяцев</param>
        public void AddMonths(int monthsCount)
        {
            date.AddMonths(monthsCount);
        }

        #endregion

        #region public void AddMonths(int monthsCount)

        /// <summary>
        /// Добавляет дни
        /// </summary>
        /// <param name="daysCount">Количество дней</param>
        public void AddDays(double daysCount)
        {
            date.AddDays(daysCount);
        }

        #endregion

        #region public DateTime ToDateTime()

        /// <summary>
        /// Преобразовывает значение в DateTime
        /// </summary>
        public DateTime ToDateTime()
        {
            return date;
        }

        #endregion

        #endregion

    }
}
