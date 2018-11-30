using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Регулярность
    /// </summary>
    public class PropertyDamage : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<PropertyDamage> _Items = new CommonDictionaryCollection<PropertyDamage>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<PropertyDamage> _Items = new CommonDictionaryCollection<PropertyDamage>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static PropertyDamage LightDamage = new PropertyDamage(1, "LD", "1 - Light damage", 1);
        /// <summary>
        /// легкие повреждения
        /// </summary>
        public static PropertyDamage LightDamage = new PropertyDamage(1, "LD", "1 - Light damage", 1);
        #endregion

        #region public static PropertyDamage MinorDamage = new PropertyDamage(2, "MnD", "2 - Minor Damage", 2);
        /// <summary>
        /// незначительные повреждения
        /// </summary>
        public static PropertyDamage MinorDamage = new PropertyDamage(2, "MnD", "2 - Minor Damage", 2);
        #endregion

        #region public static PropertyDamage SignificantDamage = new PropertyDamage(3, "SD", "3 - Significant damage", 3);
        /// <summary>
        /// значительные повреждения
        /// </summary>
        public static PropertyDamage SignificantDamage = new PropertyDamage(3, "SD", "3 - Significant damage", 3);
        #endregion

        #region public static PropertyDamage ExtensiveDamage = new PropertyDamage(4, "ED", "4 - Extensive damage", 4);
        /// <summary>
        /// обширные повреждения
        /// </summary>
        public static PropertyDamage ExtensiveDamage = new PropertyDamage(4, "ED", "4 - Extensive damage", 4);
        #endregion

        #region public static PropertyDamage MajorDamage = new PropertyDamage(5, "MjD", "5 - Major damage", 5);
        /// <summary>
        /// крупные повреждения
        /// </summary>
        public static PropertyDamage MajorDamage = new PropertyDamage(5, "MjD", "5 - Major damage", 5);
        #endregion

        #region public static PropertyDamage UNK = new PropertyDamage(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static PropertyDamage UNK = new PropertyDamage(-1, "UNK", "Unknown", 0);
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

        #region public static PropertyDamage GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static PropertyDamage GetItemById(Int32 maintenanceTypeId)
        {
            foreach (PropertyDamage t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<PropertyDamage> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<PropertyDamage> Items
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
        #region public PropertyDamage()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public PropertyDamage()
        {
        }
        #endregion

        #region public PropertyDamage(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public PropertyDamage(Int32 itemId, String shortName, String fullName, int weight)
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
            if (y is PropertyDamage)
                return FullName.CompareTo(((PropertyDamage)y).FullName);
            return 0;
        }
        #endregion
    }
}
