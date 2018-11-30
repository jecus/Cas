using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    public class ProcedureType : StaticDictionary
    {

        #region private static CommonDictionaryCollection<ProcedureType> _Items = new CommonDictionaryCollection<ProcedureType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<ProcedureType> _Items = new CommonDictionaryCollection<ProcedureType>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static ProcedureType Unknown = new ProcedureType(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static ProcedureType Unknown = new ProcedureType(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        #region public static ProcedureType InternalOnSite = new ProcedureType(1, "IoS", "Internal on site", "Internal on site");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureType InternalOnSite = new ProcedureType(1, "IonS", "Internal on site", "Internal on site");
        #endregion

        #region public static ProcedureType ExternalOnSite = new ProcedureType(2, "EonS", "External on site", "External on site");
        /// <summary> 
        /// Внешний на месте
        /// </summary>
        public static ProcedureType ExternalOnSite = new ProcedureType(2, "EonS", "External on site", "External on site");
        #endregion

        #region public static ProcedureType InternalOnSite = new ProcedureType(3, "IoS", "Internal on site", "Internal on site");
        /// <summary> 
        /// Внутренний не на месте
        /// </summary>
        public static ProcedureType InternalOutSite = new ProcedureType(3, "IoutS", "Internal out site", "Internal out site");
        #endregion

        #region public static ProcedureType ExternalOutSite = new ProcedureType(4, "EoutS", "External out site", "External out site");
        /// <summary> 
        /// Внешний не на месте
        /// </summary>
        public static ProcedureType ExternalOutSite = new ProcedureType(4, "EoutS", "External out site", "External out site");
        #endregion

        #region public static ProcedureType Meeting = new ProcedureType(5, "M", "Meeting", "Meeting");
        /// <summary> 
        /// Внешний не на месте
        /// </summary>
        public static ProcedureType Meeting = new ProcedureType(5, "M", "Meeting", "Meeting");
        #endregion
        /*
         * Методы
         */

        #region public static ProcedureType GetItemById(Int32 directiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static ProcedureType GetItemById(Int32 directiveTypeId)
        {
            foreach (ProcedureType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<ProcedureType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ProcedureType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is ProcedureType)
                return String.Compare(FullName, ((ProcedureType)y).FullName, StringComparison.Ordinal);
            return 0;
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
        #region public ProcedureType()
        public ProcedureType()
        {
            
        }
        #endregion

        #region public ProcedureType(Int32 itemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public ProcedureType(Int32 itemId, String shortName, String fullName, String commonName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    
    }
}
