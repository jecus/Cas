using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Статус события системы безопасности полетов
	/// </summary>
	[Serializable]
	public class SmsEventStatus : StaticDictionary
    {
        #region private static CommonDictionaryCollection<SmsEventStatus> _Items = new CommonDictionaryCollection<SmsEventStatus>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<SmsEventStatus> _Items = new CommonDictionaryCollection<SmsEventStatus>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static SmsEventStatus Discovered = new SmsEventStatus(1, "Dcs", "Discovered");
        /// <summary>
        /// Обнаружено
        /// </summary>
        public static SmsEventStatus Discovered = new SmsEventStatus(1, "Dcs", "Discovered");
        #endregion

        #region public static SmsEventStatus DetermRiskLevel = new SmsEventStatus(10, "DRL", "Determining the level of risk");
        /// <summary>
        /// Определение уровня риска
        /// </summary>
        public static SmsEventStatus DetermRiskLevel = new SmsEventStatus(10, "DRL", "Determining the level of risk");
        #endregion

        #region public static SmsEventStatus ElinimatingRiskFactor = new SmsEventStatus(20, "ERF", "Eliminating the risk factor");
        /// <summary>
        /// Устранение фактора риска
        /// </summary>
        public static SmsEventStatus ElinimatingRiskFactor = new SmsEventStatus(20, "ERF", "Eliminating the risk factor");
        #endregion

        #region public static SmsEventStatus ReducingTheRisk = new SmsEventStatus(30, "RRL", "Reducion the level of risk");
        /// <summary>
        /// Снижение уровня риска
        /// </summary>
        public static SmsEventStatus ReducingTheRisk = new SmsEventStatus(30, "RRL", "Reducion the level of risk");
        #endregion

        #region public static SmsEventStatus Closed = new SmsEventStatus(40, "C", "Closed");
        /// <summary>
        /// Закрыто
        /// </summary>
        public static SmsEventStatus Closed = new SmsEventStatus(40, "C", "Closed");
        #endregion

        #region public static SmsEventStatus UNK = new SmsEventStatus(-1, "UNK", "Unknown");
        /// <summary>
        /// неизвестный
        /// </summary>
        public static SmsEventStatus UNK = new SmsEventStatus(-1, "UNK", "Unknown");
        #endregion

        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public static SmsEventStatus GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static SmsEventStatus GetItemById(Int32 maintenanceTypeId)
        {
            foreach (SmsEventStatus t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<SmsEventStatus> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<SmsEventStatus> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        /*
         * Реализация
         */
        #region public SmsEventStatus()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public SmsEventStatus()
        {
        }
        #endregion

        #region public SmsEventStatus(Int32 itemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект статуса события
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public SmsEventStatus(Int32 itemId, String shortName, String fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;

            _Items.Add(this);
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is SmsEventStatus)
                return FullName.CompareTo(((SmsEventStatus)y).FullName);
            return 0;
        }
        #endregion
    }
}
