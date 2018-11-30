using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс описывает тип документа на который производится ссылка
    /// </summary>
    [Serializable]
    public class RefDocType : StaticDictionary
    {

        // Таблица Dictionaries.DetailsRecordsTypes

        /*
         * Реализация
         */

        #region private static CommonDictionaryCollection<RefDocType> _Items = new CommonDictionaryCollection<RefDocType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<RefDocType> _Items = new CommonDictionaryCollection<RefDocType>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static RefDocType Unknown = new RefDocType(-1, "Unk", "Unknown");
        /// <summary>
        /// Неизвестный
        /// </summary>
        public static RefDocType Unknown = new RefDocType(-1, "Unk", "Unknown");
        #endregion

        #region public static RefDocType AirworthinessDirective = new RefDocType(1, "AD", "Airworthiness Directive");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType AirworthinessDirective = new RefDocType(1, "AD", "Airworthiness Directive");

        #endregion

        #region public static RefDocType AMM = new RefDocType(10, "AMM", "Aircraft Maintenance Manual");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType AMM = new RefDocType(10, "AMM", "Aircraft Maintenance Manual");

        #endregion

        #region public static RefDocType IPC = new RefDocType(20, "IPC", "Illustration Part Catalog");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType IPC = new RefDocType(20, "IPC", "Illustration Part Catalog");

        #endregion

        #region public static RefDocType MEL = new RefDocType(30, "MEL", "MEL");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType MEL = new RefDocType(30, "MEL", "MEL");

        #endregion

        #region public static RefDocType MP = new RefDocType(40, "MP", "Maintenance Program");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType MP = new RefDocType(40, "MP", "Maintenance Program");

        #endregion

        #region public static RefDocType ServiceBulletin = new RefDocType(50, "SB", "Service Bulletin");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType ServiceBulletin = new RefDocType(50, "SB", "Service Bulletin");

        #endregion

        #region public static RefDocType ServiceLetter = new RefDocType(60, "SL", "Service Letter");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType ServiceLetter = new RefDocType(60, "SL", "Service Letter");

        #endregion

        #region public static RefDocType MP = new RefDocType(70, "MP", "Maintenance Program");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType SRM = new RefDocType(70, "SRM", "SRM");

        #endregion

        #region public static RefDocType WiringProgram = new RefDocType(80, "WP", "Wiring Program");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static RefDocType WiringProgram = new RefDocType(80, "WP", "Wiring Program");

        #endregion

        /*
         * Методы
         */

        #region public static RefDocType GetItemById(Int32 directiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static RefDocType GetItemById(Int32 directiveTypeId)
        {
            foreach (RefDocType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region public static CommonDictionaryCollection<RefDocType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<RefDocType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public RefDocType(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект типа документа на который производится ссылка
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public RefDocType(Int32 itemId, String shortName, String fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _Items.Add(this);
        }
        #endregion
    }
}
