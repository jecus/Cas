using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class DirectiveType : StaticDictionary
    {

        #region private static CommonDictionaryCollection<DirectiveType> _Items = new CommonDictionaryCollection<DirectiveType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<DirectiveType> _Items = new CommonDictionaryCollection<DirectiveType>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static DirectiveType ModificationStatus = new DirectiveType(1, "MD", "Modification directives", "Modification Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType ModificationStatus = new DirectiveType(1, "MD", "Modification directives", "Modification Status");
        #endregion

        #region public static DirectiveType AirworthenessDirectives = new DirectiveType(2, "AD", "Airwortheness directives", "AD Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType AirworthenessDirectives = new DirectiveType(2, "AD", "Airwortheness directives", "AD Status");
        #endregion

        #region public static DirectiveType AgingProgram = new DirectiveType(3, "AP", "Aging program directive", "Aging program");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType AgingProgram = new DirectiveType(3, "AP", "Aging program directive", "Aging program");
        #endregion

        #region public static DirectiveType DeferredItems = new DirectiveType(5, "DI", "Deferred items directive", "Deferred items");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType DeferredItems = new DirectiveType(5, "DI", "Deferred items directive", "Deferred items");
        #endregion

        #region public static DirectiveType EngineeringOrders = new DirectiveType(6, "EO", "Engineering orders status directives", "EO Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType EngineeringOrders = new DirectiveType(6, "EO", "Engineering orders status directives", "EO Status");
        #endregion

        #region public static DirectiveType OutOfPhase = new DirectiveType(7, "OP", "Out of Phase Requirements", "Out of Phase Requirements");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType OutOfPhase = new DirectiveType(7, "OP", "Out of Phase Requirements", "Out of Phase Requirements");
        #endregion

        #region public static DirectiveType Repair = new DirectiveType(8, "Repair", "Repair status directives", "Repair Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType Repair = new DirectiveType(8, "Repair", "Repair status directives", "Repair Status");
        #endregion

        #region public static DirectiveType SB = new DirectiveType19, "SB", "SB status directives", "SB Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType SB = new DirectiveType(9, "SB", "SB status directives", "SB Status");
        #endregion

        #region public static DirectiveType SSID = new DirectiveType(11, "SSID", "SSID directives", "SSID Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType SSID = new DirectiveType(11, "SSID", "SSID directives", "SSID Status");
        #endregion

        #region public static DirectiveType DamagesRequiring = new DirectiveType(12, "DRI", "Damages Requiring Inspection", "DRI Status");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveType DamagesRequiring = new DirectiveType(12, "DRI", "Damages Requiring Inspection", "DRI Status");
        #endregion

        #region public static DirectiveType All = new DirectiveType(-2, "All", "All", "All");
        /// <summary> 
        /// Указатель на то что нужно выводить все директивы в скрине Forecast
        /// </summary>
        public static DirectiveType All = new DirectiveType(-2, "All", "All", "All");
        #endregion

        #region public static DirectiveType Unknown = new DirectiveType(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static DirectiveType Unknown = new DirectiveType(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        /*
         * Методы
         */

        #region public static DirectiveType GetDirectiveTypeById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static DirectiveType GetDirectiveTypeById(Int32 directiveTypeId)
        {
            foreach (DirectiveType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<DirectiveType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<DirectiveType> Items
        {
            get { return _Items; }
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

        #region public DirectiveType()
        /// <summary>
        /// Конструктор создает объект по умолчанию
        /// </summary>
        public DirectiveType()
        {
        }
        #endregion

        #region public DirectiveType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public DirectiveType(Int32 itemId, String shortName, String fullName, String commonName)
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
