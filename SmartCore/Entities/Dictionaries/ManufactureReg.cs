using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    #region public enum AircraftManufactureRegion : short
    /// <summary>
    /// Описывает регион производства самолета (Сов.-Российский, западный и т.д.)
    /// </summary>
    [Serializable]
    public class ManufactureRegion : StaticDictionary
    {

        #region private static CommonDictionaryCollection<AircraftManufactureRegion> _Items = new CommonDictionaryCollection<AircraftManufactureRegion>();
        /// <summary>
        /// Содержит все элементы - это пригодиться нам, когда мы захотим получить тип базового агрегата по его id
        /// </summary>
        private static CommonDictionaryCollection<ManufactureRegion> _Items = new CommonDictionaryCollection<ManufactureRegion>();
        #endregion


        /*
         * Предопределенные типы
         */

        #region public static AircraftManufactureRegion Unknown = new AircraftManufactureRegion(-1, "UNK", "Unknown");
        /// <summary>
        /// Неизвестный регион
        /// </summary>
        public static ManufactureRegion Unknown = new ManufactureRegion(-1, "UNK", "Unknown");
        #endregion

        #region public static AircraftManufactureRegion Soviet = new AircraftManufactureRegion(1, "Sov", "Soviet");
        /// <summary>
        /// Советские самолеты (Россия, Украина)
        /// </summary>
        public static ManufactureRegion Soviet = new ManufactureRegion(1, "Sov", "Soviet");
        #endregion

        #region public static AircraftManufactureRegion Western = new AircraftManufactureRegion(2, "West", "Western");
        /// <summary>
        /// Советские самолеты (Россия, Украина)
        /// </summary>
        public static ManufactureRegion Western = new ManufactureRegion(2, "West", "Western");
        #endregion

        /*
         * Методы
         */

        #region public static AircraftManufactureRegion GetItemById(Int32 itemId)
        /// <summary>
        /// Возвращает элемент по его Id
        /// </summary>
        /// <param name="itemId">id объекта</param>
        /// <returns>элемент с заданный id или null</returns>
        public static ManufactureRegion GetItemById(Int32 itemId)
        {
            for (int i = 0; i < _Items.Count; i++)
                if (_Items[i].ItemId == itemId)
                    return _Items[i];
            //
            return Unknown;
        }
        #endregion

        #region public static CommonDictionaryCollection<AircraftManufactureRegion> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ManufactureRegion> Items
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
        #region public AircraftManufactureRegion()
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        public ManufactureRegion()
        {
            ItemId = -1;
            ShortName = "";
            FullName = "";
        }
        #endregion

        #region public AircraftManufactureRegion(Int32 ItemId, String shortName, String fullName)
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public ManufactureRegion(Int32 itemId, String shortName, String fullName)
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
