using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция записей об актуальном агрегатов с правильной сортировкой по дате
    /// </summary>
    [Serializable]
    public class ActualStateRecordCollection : BaseRecordCollection<ActualStateRecord>
    {

        #region public ActualStateRecordCollection()
        /// <summary>
        /// Создает пустую коллекцию записей об актуальном состоянии агрегата(ов)
        /// </summary>
        public ActualStateRecordCollection()
        {
        }
        #endregion

        #region public ActualStateRecordCollection(ActualStateRecord[] actuatStateRecords)
        /// <summary>
        /// Создает коллекцию записей об актуальном состонии агрегата
        /// </summary>
        /// <param name="actuatStateRecords"></param>
        public ActualStateRecordCollection(ActualStateRecord[] actuatStateRecords)
        {
			if(actuatStateRecords != null)
				AddRange(actuatStateRecords);
        }
        #endregion

        #region public new IEnumerator<ActualStateRecord> GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<ActualStateRecord> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region public ActualStateRecord this[DateTime date, IWorkRegime regime] { get; }

        /// <summary>
        /// Возвращает запись по указанной дате и режиму, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <param name="regime"></param>
        /// <returns></returns>
        public ActualStateRecord this[DateTime date, IWorkRegime regime]
        {
            get
            {
                if (regime == null) 
                    regime = FlightRegime.UNK;
                return Items.FirstOrDefault(t => t.RecordDate.Date == date.Date && t.WorkRegime == regime);
            }
        }
        #endregion

        #region public ActualStateRecord GetLastKnownRecord(DateTime date, IWorkRegime flightRegime)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате,
        /// <br/> а режим совпадает с заданным
        /// </summary>
        /// <param name="date"></param>
        /// <param name="flightRegime"></param>
        /// <returns>Запись удовлетворяющая заданным параметрам или null</returns>
        public ActualStateRecord GetLastKnownRecord(DateTime date, IWorkRegime flightRegime)
        {
            if (flightRegime == null) flightRegime = FlightRegime.UNK;
            date = date.Date;
            return Items.OrderByDescending(r => r.RecordDate.Date)
                        .FirstOrDefault(r => r.RecordDate.Date <= date && r.WorkRegime.Equals(flightRegime));
        }

        #endregion

        #region public ActualStateRecord GetFirstKnownRecord(DateTime date, IWorkRegime flightRegime)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой больше либо равна указанной дате.
        /// <br/>а режим работы совпадает с заданным
        /// </summary>
        /// <param name="date"></param>
        /// <param name="flightRegime"></param>
        /// <returns></returns>
        public ActualStateRecord GetFirstKnownRecord(DateTime date, IWorkRegime flightRegime)
        {
            if (flightRegime == null) flightRegime = FlightRegime.UNK;
            date = date.Date;
            return Items.OrderBy(r => r.RecordDate.Date)
                        .FirstOrDefault(i => i.RecordDate.Date >= date && i.WorkRegime == flightRegime);
        
        }

        #endregion

        #region public new ActualStateRecord this[DateTime date] { get; }
        /// <summary>
        /// Возвращает запись по указанной дате, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public new ActualStateRecord this[DateTime date]
        {
            get
            {
                return this[date, FlightRegime.UNK];
            }
        }
        #endregion

        #region public new ActualStateRecord GetLastKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public new ActualStateRecord GetLastKnownRecord(DateTime date)
        {
            // возвращаем самую близкую дату
            return GetLastKnownRecord(date,FlightRegime.UNK);
        }

        #endregion

    }

}
