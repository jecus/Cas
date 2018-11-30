using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    #region public enum MaintenanceCheckScheduleType : short
    /// <summary>
    /// Описывает тип (основную букву) Категории жизненного цикла вращающихся деталей
    /// </summary>
    [Serializable]
    public class MaintenanceCheckScheduleType : StaticDictionary
    {

        #region private static CommonDictionaryCollection<MaintenanceCheckScheduleType> _Items = new CommonDictionaryCollection<MaintenanceCheckScheduleType>();
        /// <summary>
        /// Содержит все элементы - это пригодиться нам, когда мы захотим получить тип базового агрегата по его id
        /// </summary>
        private static CommonDictionaryCollection<MaintenanceCheckScheduleType> _Items = new CommonDictionaryCollection<MaintenanceCheckScheduleType>();
        #endregion


        /*
         * Предопределенные типы
         */

        #region public static MaintenanceCheckScheduleType Unknown = new MaintenanceCheckScheduleType(-1, "UNK", "Unknown");
        /// <summary>
        /// Неизвестный регион
        /// </summary>
        public static MaintenanceCheckScheduleType Unknown = new MaintenanceCheckScheduleType(-1, "UNK", "Unknown");
        #endregion

        #region public static MaintenanceCheckScheduleType Schedule = new MaintenanceCheckScheduleType(1, "Schedule", "Schedule");
        /// <summary>
        /// Schedule
        /// </summary>
        public static MaintenanceCheckScheduleType Schedule = new MaintenanceCheckScheduleType(1, "Schedule", "Schedule");
        #endregion

        #region public static MaintenanceCheckScheduleType Unschedule = new MaintenanceCheckScheduleType(2, "Unschedule", "Unschedule");
        /// <summary>
        /// Unschedule
        /// </summary>
        public static MaintenanceCheckScheduleType Unschedule = new MaintenanceCheckScheduleType(2, "Unschedule", "Unschedule");
        #endregion


        /*
         * Методы
         */

        #region public static MaintenanceCheckScheduleType GetItemById(Int32 itemId)
        /// <summary>
        /// Возвращает элемент по его Id
        /// </summary>
        /// <param name="itemId">id объекта</param>
        /// <returns>элемент с заданный id или null</returns>
        public static MaintenanceCheckScheduleType GetItemById(Int32 itemId)
        {
            foreach (MaintenanceCheckScheduleType t in _Items)
                if (t.ItemId == itemId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region public static CommonDictionaryCollection<MaintenanceCheckScheduleType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<MaintenanceCheckScheduleType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public override string ToString()
        /// <summary> 
        /// Представляет элемент в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName;
        }
        #endregion

        /*
         * Реализация
         */
        #region public MaintenanceCheckScheduleType()
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        public MaintenanceCheckScheduleType()
        {
            SmartCoreObjectType = SmartCoreType.Unknown;
        }
        #endregion

        #region public MaintenanceCheckScheduleType(Int32 ItemId, String shortName, String fullName) : this()
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public MaintenanceCheckScheduleType(Int32 itemId, String shortName, String fullName)
            : this()
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _Items.Add(this);
        }
        #endregion
    }
    #endregion
}
