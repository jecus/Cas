using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Регулярность
    /// </summary>
    public class Regularity : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<Regularity> _Items = new CommonDictionaryCollection<Regularity>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Regularity> _Items = new CommonDictionaryCollection<Regularity>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static Regularity LessThan15Minutes = new Regularity(1, "<15min", "1 - Less than 15 minutes", 1);
        /// <summary>
        /// менее 15 минут
        /// </summary>
        public static Regularity LessThan15Minutes = new Regularity(1, "<15min", "1 - Less than 15 minutes", 1);
        #endregion

        #region public static Regularity From15To30Minutes = new Regularity(2, "15-30min", "2 - From 15 to 30 minutes", 2);
        /// <summary>
        /// от 15 до 30 минут
        /// </summary>
        public static Regularity From15To30Minutes = new Regularity(2, "15-30min", "2 - From 15 to 30 minutes", 2);
        #endregion

        #region public static Regularity From30MinutesTo3Hours = new Regularity(3, "30min-3hours", "3 - From 30 minutes to 3 hours", 3);
        /// <summary>
        /// от 30 минут - 3 часа
        /// </summary>
        public static Regularity From30MinutesTo3Hours = new Regularity(3, "30min-3hours", "3 - From 30 minutes to 3 hours", 3);
        #endregion

        #region public static Regularity From3To6Hours = new Regularity(4, "3-6hours", "4 - From 3 to 6 hours", 4);
        /// <summary>
        /// от 3 до 6 часов
        /// </summary>
        public static Regularity From3To6Hours = new Regularity(4, "3-6hours", "4 - From 3 to 6 hours", 4);
        #endregion

        #region public static Regularity MoreThan6Hours = new Regularity(5, ">6hours", "5 - More than 6 hours", 5);
        /// <summary>
        /// более 6 часов
        /// </summary>
        public static Regularity MoreThan6Hours = new Regularity(5, ">6hours", "5 - More than 6 hours", 5);
        #endregion

        #region public static Regularity UNK = new Regularity(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static Regularity UNK = new Regularity(-1, "UNK", "Unknown", 0);
        #endregion

        /*
         * Свойства 
         */

        #region public int Weight
        /// <summary>
        /// Степень ущерба
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        #endregion

        /*
         * Методы
         */

        #region public static Regularity GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static Regularity GetItemById(Int32 maintenanceTypeId)
        {
            foreach (Regularity t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<Regularity> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Regularity> Items
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
        #region public Regularity()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public Regularity()
        {
        }
        #endregion

        #region public Regularity(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public Regularity(Int32 itemId, String shortName, String fullName, int weight)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _weight = weight;

            _Items.Add(this);
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is Regularity)
                return FullName.CompareTo(((Regularity)y).FullName);
            return 0;
        }
        #endregion
    }
}
