using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Ущерб окружающей среде
    /// </summary>
    public class EnvironmentalDamage : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<EnvironmentalDamage> _Items = new CommonDictionaryCollection<EnvironmentalDamage>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<EnvironmentalDamage> _Items = new CommonDictionaryCollection<EnvironmentalDamage>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static EnvironmentalDamage LightDamage = new EnvironmentalDamage(1, "LD", "1 - Light damage", 1);
        /// <summary>
        /// легкие повреждения
        /// </summary>
        public static EnvironmentalDamage LightDamage = new EnvironmentalDamage(1, "LD", "1 - Light damage", 1);
        #endregion

        #region public static EnvironmentalDamage MinorDamage = new EnvironmentalDamage(2, "MnD", "2 - Minor Damage", 2);
        /// <summary>
        /// незначительные повреждения
        /// </summary>
        public static EnvironmentalDamage MinorDamage = new EnvironmentalDamage(2, "MnD", "2 - Minor Damage", 2);
        #endregion

        #region public static EnvironmentalDamage LocalizedDamage = new EnvironmentalDamage(3, "LD", "3 - Localized damage", 3);
        /// <summary>
        /// Локализованный вред
        /// </summary>
        public static EnvironmentalDamage LocalizedDamage = new EnvironmentalDamage(3, "LD", "3 - Localized damage", 3);
        #endregion

        #region public static EnvironmentalDamage SignificantDamage = new EnvironmentalDamage(4, "SD", "4 - Significant damage", 4);
        /// <summary>
        /// значительные повреждения
        /// </summary>
        public static EnvironmentalDamage SignificantDamage = new EnvironmentalDamage(4, "SD", "4 - Significant damage", 4);
        #endregion

        #region public static EnvironmentalDamage MajorDamage = new EnvironmentalDamage(5, "MjD", "5 - Major damage", 5);
        /// <summary>
        /// крупные повреждения
        /// </summary>
        public static EnvironmentalDamage MajorDamage = new EnvironmentalDamage(5, "MjD", "5 - Major damage", 5);
        #endregion

        #region public static EnvironmentalDamage UNK = new EnvironmentalDamage(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static EnvironmentalDamage UNK = new EnvironmentalDamage(-1, "UNK", "Unknown", 0);
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

        #region public static EnvironmentalDamage GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static EnvironmentalDamage GetItemById(Int32 maintenanceTypeId)
        {
            foreach (EnvironmentalDamage t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<EnvironmentalDamage> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<EnvironmentalDamage> Items
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
        #region public EnvironmentalDamage()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public EnvironmentalDamage()
        {
        }
        #endregion

        #region public EnvironmentalDamage(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public EnvironmentalDamage(Int32 itemId, String shortName, String fullName, int weight)
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
            if (y is EnvironmentalDamage)
                return FullName.CompareTo(((EnvironmentalDamage)y).FullName);
            return 0;
        }
        #endregion
    }
}
