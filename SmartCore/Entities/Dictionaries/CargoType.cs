using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Тип груза
	/// </summary>
	[Serializable]
	public class CargoCategory : StaticDictionary
    {

        #region private static List<CargoType> _Items = new List<CargoType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<CargoCategory> _Items = new CommonDictionaryCollection<CargoCategory>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static CargoCategory HandLuggage = new CargoCategory(1, "HL", "Hand Luggage");
        /// <summary>
        /// Ручная кладь
        /// </summary>
        public static CargoCategory HandLuggage = new CargoCategory(1, "HL", "Hand Luggage");
        #endregion

        #region public static CargoType Luggage = new CargoType(2, "L", "Luggage");
        /// <summary>
        /// Багаж
        /// </summary>
        public static CargoCategory Luggage = new CargoCategory(2, "L", "Luggage");
        #endregion

        #region public static CargoType Mail = new CargoType(3, "M", "Mail");
        /// <summary>
        /// Почта
        /// </summary>
        public static CargoCategory Mail = new CargoCategory(3, "M", "Mail");
        #endregion

        #region public static CargoCategory DangerousCargo = new CargoCategory(4, "CD", "Cargo Dangerous");
        /// <summary>
        /// Опасный груз
        /// </summary>
        public static CargoCategory DangerousCargo = new CargoCategory(4, "CD", "Cargo Dangerous");
        #endregion

        #region public static CargoType Cargo200 = new CargoType(5, "C200", "Cargo 200");
        /// <summary>
        /// Груз 200
        /// </summary>
        public static CargoCategory Cargo200 = new CargoCategory(5, "C200", "Cargo 200");
        #endregion

        #region public static CargoCategory MilitaryCargo = new CargoCategory(6, "CM", "Cargo Military");
        /// <summary>
        /// Военный груз
        /// </summary>
        public static CargoCategory MilitaryCargo = new CargoCategory(6, "CM", "Cargo Military");
        #endregion

        #region public static CargoType SimplyCargo = new CargoType(7, "C", "Cargo");
        /// <summary>
        /// Обычный груз
        /// </summary>
        public static CargoCategory SimplyCargo = new CargoCategory(7, "C", "Cargo");
        #endregion

        #region public static CargoType UNK = new CargoType(-1, "UNK", "Unknown");
        /// <summary>
        /// неизвестный груз
        /// </summary>
        public static CargoCategory UNK = new CargoCategory(-1, "UNK", "Unknown");
        #endregion

        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public static CargoType GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static CargoCategory GetItemById(Int32 maintenanceTypeId)
        {
            foreach (CargoCategory t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<CargoType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<CargoCategory> Items
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
        #region public CargoType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public CargoCategory()
        {
        }
        #endregion

        #region public CargoType(Int32 itemID, String shortName, String fullName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public CargoCategory(Int32 itemId, String shortName, String fullName)
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
            if (y is CargoCategory)
                return FullName.CompareTo(((CargoCategory)y).FullName);
            return 0;
        }
        #endregion
    }
}
