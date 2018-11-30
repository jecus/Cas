using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция наработок
    /// </summary>
    [Serializable]
    public class LifelengthCollection:IEnumerable
    {

        #region private LifelengthCollection()
        /// <summary>
        /// Создает пустую коллекция наработок
        /// </summary>
        private LifelengthCollection()
        {
        }
        #endregion

        #region public LifelengthCollection(DateTime startDate)
        /// <summary>
        /// Создает коллекцию наработок начиная с заданной даты
        /// </summary>
        /// <param name="startDate"></param>
        public LifelengthCollection(DateTime startDate)
        {
            _startDate = startDate.Date;
            _Array = new Dictionary<FlightRegime,SortedDictionary<DateTime, Lifelength>>();
        }
        #endregion

        #region public DateTime StartDate { get; }
        /// <summary> 
        /// Начало отчета
        /// </summary>
        private DateTime _startDate;
        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                foreach (KeyValuePair<FlightRegime, SortedDictionary<DateTime, Lifelength>> pair in _Array)
                {
                    pair.Value.Clear();
                }
            }
        }
        #endregion

        #region private Lifelength this[DateTime date]

        /// <summary>
        /// Возвращает (задает) наработку на заданное число и по заданному режиму
        /// </summary>
        /// <param name="flightRegime"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private Lifelength this[DateTime date, FlightRegime flightRegime]
        {
            get
            {
                if (flightRegime == null)
                    flightRegime = FlightRegime.UNK;

                if (_Array.ContainsKey(flightRegime))
                {
                    if(_Array[flightRegime] == null)
                        _Array[flightRegime] = new SortedDictionary<DateTime, Lifelength>();
                }
                else _Array.Add(flightRegime,new SortedDictionary<DateTime, Lifelength>());

                SortedDictionary<DateTime, Lifelength> array = _Array[flightRegime];

                if (date.Date > DateTime.Today)
                {
                    Lifelength res = _Array.Count > 0 ? new Lifelength(array.Last().Value) : Lifelength.Zero;
                    res.Add(LifelengthSubResource.Calendar,  (date.Date - DateTime.Today).Days);
                    return res;
                }
                if (date.Date < _startDate.Date) 
                    return new Lifelength((_startDate.Date - date.Date).Days,0,0);
                return array.ContainsKey(date.Date) ? array[date.Date] : null;
            }
            set
            {
                if (flightRegime == null)
                    flightRegime = FlightRegime.UNK;

                if (_Array.ContainsKey(flightRegime))
                {
                    if (_Array[flightRegime] == null)
                        _Array[flightRegime] = new SortedDictionary<DateTime, Lifelength>();
                }
                else _Array.Add(flightRegime, new SortedDictionary<DateTime, Lifelength>());

                SortedDictionary<DateTime, Lifelength> array = _Array[flightRegime];

                if (array.ContainsKey(date.Date))
                    array[date.Date] = value;
                else
                {
                    if(date.Date >= _startDate.Date && date.Date <= DateTime.Today)
                        array.Add(date.Date, value);
                }
            }
        }
        #endregion

        #region public IEnumerator GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _Array.GetEnumerator();
        }
        #endregion

        #region public void Clear()
        /// <summary>
        /// Очищает последовательность элеиентов
        /// </summary>
        public void Clear()
        {
            _Array.Clear();    
        }
        #endregion

        #region override public String ToString()
        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "Count = " + _Array.Count;
        }
        #endregion
      
        /*
         * Реализация
         */

        #region private Lifelength[] _Array;
        /// <summary>
        /// Массив соддержит наработки
        /// </summary>
        private Dictionary<FlightRegime, SortedDictionary<DateTime, Lifelength>> _Array;
		#endregion

		#region private int GetIndex(DateTime date)
		///// <summary>
		///// Получает порядковый номер
		///// </summary>
		///// <param name="date"></param>
		///// <returns></returns>
		//private Int32 GetIndex(DateTime date)
		//{
		//    long index = (date.Date.Ticks - _startDate.Ticks) / TimeSpan.TicksPerDay;
		//    return Convert.ToInt32(index);
		//}
		#endregion

		#region public Lifelength GetLifelengthOnStartOfDay(DateTime date, FlightRegime flightRegime)

		/// <summary>
		/// Подсчитанная наработка на начало дня в заданном режиме
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <param name="flightRegime">режим работы</param>
		/// <returns></returns>
		public Lifelength GetLifelengthOnStartOfDay(DateTime date, FlightRegime flightRegime)
        {
            return this[date.AddDays(-1), flightRegime ?? FlightRegime.UNK];
        }
		#endregion

		#region public void SetLifelengthOnStartOfDay(DateTime date, FlightRegime flightRegime, Lifelength value)
		/// <summary>
		/// Устанавливает подсчитанную наработку на начало дня на заданном режиме
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <param name="flightRegime">режим работы</param>
		/// <param name="value">значение подсчитанной наработки</param>
		/// <returns></returns>
		public void SetLifelengthOnStartOfDay(DateTime date, FlightRegime flightRegime, Lifelength value)
        {
            this[date.AddDays(-1), flightRegime ?? FlightRegime.UNK] = value;
        }
		#endregion

		#region public Lifelength GetLifelengthOnEndOfDay(DateTime date, FlightRegime flightRegime)

		/// <summary>
		/// Подсчитанная наработка на конец дня
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <param name="flightRegime">режим работы</param>
		/// <returns></returns>
		public Lifelength GetLifelengthOnEndOfDay(DateTime date, FlightRegime flightRegime)
        {
            return this[date, flightRegime ?? FlightRegime.UNK];
        }
        #endregion

        #region  public void SetClosingLifelength(DateTime date, Lifelength value)

        /// <summary>
        /// Устанавливает подсчитанную наработку на конец дня на заданном режиме
        /// </summary>
        /// <param name="date">День на который необходимо вернуть наработку</param>
        /// <param name="flightRegime">режим работы</param>
        /// <param name="value">значение подсчитанной наработки</param>
        /// <returns></returns>
        public void SetClosingLifelength(DateTime date, FlightRegime flightRegime, Lifelength value)
        {
            this[date, flightRegime ?? FlightRegime.UNK] = value;
        }
		#endregion

		#region public Lifelength GetLifelengthOnStartOfDay(DateTime date)
		/// <summary>
		/// Подсчитанная наработка на начало дня
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <returns></returns>
		public Lifelength GetLifelengthOnStartOfDay(DateTime date)
        {
            return GetLifelengthOnStartOfDay(date,FlightRegime.UNK);
        }
		#endregion

		#region  public void SetLifelengthOnStartOfDay(DateTime date, Lifelength value)

		/// <summary>
		/// Устанавливает подсчитанную наработку на начало дня
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <param name="value">значение подсчитанной наработки</param>
		/// <returns></returns>
		public void SetLifelengthOnStartOfDay(DateTime date, Lifelength value)
        {
            SetLifelengthOnStartOfDay(date, FlightRegime.UNK, value);
        }
		#endregion

		#region public Lifelength GetLifelengthOnEndOfDay(DateTime date)
		/// <summary>
		/// Подсчитанная наработка на конец дня
		/// </summary>
		/// <param name="date">День на который необходимо вернуть наработку</param>
		/// <returns></returns>
		public Lifelength GetLifelengthOnEndOfDay(DateTime date)
        {
            return GetLifelengthOnEndOfDay(date, FlightRegime.UNK);
        }
        #endregion

        #region  public void SetClosingLifelength(DateTime date, Lifelength value)

        /// <summary>
        /// Устанавливает подсчитанную наработку на конец дня
        /// </summary>
        /// <param name="date">День на который необходимо вернуть наработку</param>
        /// <param name="value">значение подсчитанной наработки</param>
        /// <returns></returns>
        public void SetLifelengthOnEndOfDay(DateTime date, Lifelength value)
        {
            SetClosingLifelength(date, FlightRegime.UNK, value);
        }
        #endregion
    }
}
