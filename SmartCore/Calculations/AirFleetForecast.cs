using System;
using System.Collections.Generic;
using SmartCore.Entities.General;
using System.Collections;

namespace SmartCore.Calculations
{

    /// <summary>
    /// Прогноз на будущее для всех воздушных судов авиакомпании
    /// </summary>
    public class AirFleetForecast : IEnumerable<Forecast>
    {
        private List<Forecast> _forecasts = new List<Forecast>();

        #region public DateTime ForecastDate { get; set; }

        /// <summary>
        /// Дата, на которую составляется проноз
        /// </summary>
        public DateTime ForecastDate { get; set; }

        #endregion

        #region public AirFleetForecast()
        /// <summary>
        /// Прогноз на будущее для всех воздушных судов авиакомпании
        /// </summary>
        public AirFleetForecast()
        {
            
        }
        #endregion

        #region public void Clear()
        public void Clear()
        {
            if (_forecasts != null) _forecasts.Clear();    
        }
        #endregion

        #region public int Count { get { return _forecasts.Count; } }

        /// <summary>
        /// Возвращает количество отчетов 
        /// </summary>
        public int Count { get { return _forecasts.Count; } }
        
        #endregion

        #region public Forecast this[int index]

        /// <summary>
        /// Возвращает составленный отчет по порядковому номеру в коллекции
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Forecast this[int index]
        {
            get { return _forecasts[index]; }
        }

        #endregion

        #region public Forecast GetForecastByAircraft(Aircraft aircraft)

        /// <summary>
        /// Возвращает составленный отчет для конкретного воздушного судна
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        public Forecast GetForecastByAircraft(Aircraft aircraft)
        {
            for (int i = 0; i < _forecasts.Count; i++)
                if (_forecasts[i].Aircraft == aircraft)
                    return _forecasts[i];
            //
            return null;
        }

        #endregion

        #region public void Add(Forecast forecast)
        /// <summary>
        /// Добавляет отчет в коллекцию
        /// </summary>
        /// <param name="forecast"></param>
        public void Add(Forecast forecast)
        {
            _forecasts.Add(forecast);
        }
        #endregion

        #region public void Dispose()
        /// <summary>
        /// Производит удаление всех коллекций прогноза
        /// </summary>
        public void Dispose()
        {
            foreach (Forecast forecast in _forecasts)
            {
                forecast.Dispose();
            }
        }
        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Реализация цикла Foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _forecasts.GetEnumerator();
        }

        #endregion

        #region Члены IEnumerable<Forecast>
        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<Forecast> GetEnumerator()
        {
            return _forecasts.GetEnumerator();
        }
        #endregion

    }

}
