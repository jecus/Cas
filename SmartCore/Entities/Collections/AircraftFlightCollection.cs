using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Atlbs;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция полетов с правильной сортировкой по дате
    /// </summary>
    [Serializable]
    public class AircraftFlightCollection:BaseRecordCollection<AircraftFlight>
    {
        #region public AircraftFlightCollection()
        /// <summary>
        /// Создает пустую коллекцию полетов воздушных судов
        /// </summary>
        public AircraftFlightCollection()
        {
        }
        #endregion

        #region public AircraftFlightCollection(AircraftFlight[]flights)
        /// <summary>
        /// Создает пустую коллекцию полетов воздушных судов
        /// </summary>
        public AircraftFlightCollection(AircraftFlight[]flights)
        {
            AddRange(flights);
        }
        #endregion

        #region public AircraftFlightCollection(List<AircraftFlight>flights):this(flights.ToArray())
        /// <summary>
        /// Создает пустую коллекцию полетов воздушных судов
        /// </summary>
        public AircraftFlightCollection(List<AircraftFlight>flights):this(flights.ToArray())
        {
        }
        #endregion

        #region  public new IEnumerator<AircraftFlight> GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<AircraftFlight> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region public List<AircraftFlight> GetFlightWithPageNum(Int32 pageNum, int atlbId)

        /// <summary>
        /// Ищет полеты с указанным номером страницы
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="atlbId"></param>
        /// <returns></returns>
        public List<AircraftFlight> GetFlightWithPageNum(string pageNum, int atlbId)
        {               
            int flightPageNum;

            if(atlbId > 0)
                return Items.Where(aircraftFlight => aircraftFlight.PageNo.Equals(pageNum)
                                                  && aircraftFlight.ATLBId == atlbId).ToList();
            return Items.Where(aircraftFlight => int.TryParse(aircraftFlight.PageNo, out flightPageNum) && aircraftFlight.PageNo.Equals(pageNum)).ToList();
        }

        #endregion

        #region public List<AircraftFlight> GetFlightWithPageNumInAtlb(string pageNum)

        /// <summary>
        /// Ищет полеты с указанным номером страницы в определенном бортовом журнале
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="atlbId">ID Бортового журнала (при передаче значения меньше 0 будут просматриваться все полеты)</param>
        /// <returns></returns>
        public List<AircraftFlight> GetFlightWithPageNumInAtlb(string pageNum, int atlbId)
        {
            if (atlbId > 0)
                return Items.Where(aircraftFlight => aircraftFlight.PageNo == pageNum 
                                                  && aircraftFlight.ATLBId == atlbId)
                            .ToList();
            return Items.Where(aircraftFlight => aircraftFlight.PageNo == pageNum).ToList();
        }

        #endregion

	    #region public IEnumerable<AircraftFlight> GetFlights(DateTime date)
		/// <summary>
		/// возвращает полеты на определенную дату.
		/// </summary>
		/// <param name="date">дата</param>
		/// <returns></returns>
		public IEnumerable<AircraftFlight> GetFlights(DateTime date)
        {
            return Items.Where(t => t.FlightDate.Date == date.Date);
        }
        #endregion

        #region public AircraftFlightCollection GetFlightsByAtlb(Int32 atlbId)

        /// <summary>
        /// Возвращает полеты чей parentAtlb совпадает с переданным.
        /// </summary>
        /// <param name="parentAtlbId"></param>
        /// <returns></returns>
        public AircraftFlightCollection GetFlightsByAtlb(int parentAtlbId)
        {
            if (parentAtlbId > 0)
                return new AircraftFlightCollection(Items.Where(i => i.ATLBId == parentAtlbId).ToArray());
            return null;
        }

        #endregion

        #region public AircraftFlightCollection GetFlightsByAtlb(Int32 atlbId)

        /// <summary>
        /// Возвращает полеты чей parentAtlb совпадает с переданным.
        /// </summary>
        /// <param name="parametres"></param>
        /// <returns></returns>
        public AircraftFlightCollection GetFlightsByAtlb(params object[] parametres)
        {
            if (parametres == null || parametres.Length == 0 || !(parametres[0] is ATLB))
                return null;
            return new AircraftFlightCollection(Items.Where(i => i.ATLBId == ((ATLB)parametres[0]).ItemId).ToArray());
        }

        #endregion

        #region public AircraftFlight GetFirstFlightInAtlb(Int32 atlbId)

        /// <summary>
        /// Возвращает первый по дате полет чей AtlbId совпадает с переданным.
        /// </summary>
        /// <param name="atlbId"></param>
        /// <returns></returns>
        public AircraftFlight GetFirstFlightInAtlb(Int32 atlbId)
        {
            return Items.Where(i => i.ATLBId == atlbId).OrderBy(i => i.RecordDate).FirstOrDefault();
        }

        #endregion

        #region public AircraftFlight GetLastFlightInAtlb(Int32 atlbId)

        /// <summary>
        /// Возвращает последний по дате полет чей AtlbId совпадает с переданным.
        /// </summary>
        /// <param name="atlbId"></param>
        /// <returns></returns>
        public AircraftFlight GetLastFlightInAtlb(Int32 atlbId)
        {
            return Items.Where(i => i.ATLBId == atlbId).OrderBy(i => i.RecordDate).LastOrDefault();
        }

        #endregion
    }
}
