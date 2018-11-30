using System.Collections.Generic;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция возушных судов с удобным доступом к воздушным судам
    /// </summary>
    public class AircraftCollection : CommonCollection<Aircraft>
    {

        #region public AircraftCollection()
        /// <summary>
        /// Создает пустую коллекцию возудшных судов
        /// </summary>
        public AircraftCollection()
        {
        }
        #endregion

        #region public AircraftCollection(IEnumerable<Aircraft> aircrafts):base(aircrafts)
        /// <summary>
        /// Создает коллекцию возудшных судов на основе передаваемого массива 
        /// </summary>
        /// <param name="aircrafts"></param>
        public AircraftCollection(IEnumerable<Aircraft> aircrafts):base(aircrafts)
        {
        }
        #endregion
    }
}
