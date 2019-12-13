using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Людские Повреждения
	/// </summary>
	[Serializable]
	public class HumanDamage : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<HumanDamage> _Items = new CommonDictionaryCollection<HumanDamage>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<HumanDamage> _Items = new CommonDictionaryCollection<HumanDamage>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static HumanDamage LightInjuries = new HumanDamage(1, "LI", "1 - Light injuries", 1);
        /// <summary>
        /// легкие травмы
        /// </summary>
        public static HumanDamage LightInjuries = new HumanDamage(1, "LI", "1 - Light injuries", 1);
        #endregion

        #region public static HumanDamage MinorInjuries = new HumanDamage(2, "MI", "2 - Minor injuries", 2);
        /// <summary>
        /// незначительные травмы
        /// </summary>
        public static HumanDamage MinorInjuries = new HumanDamage(2, "MI", "2 - Minor injuries", 2);
        #endregion

        #region public static HumanDamage SignificantInjuries = new HumanDamage(3, "SI", "3 - Significant injuries", 3);
        /// <summary>
        /// значительные травмы
        /// </summary>
        public static HumanDamage SignificantInjuries = new HumanDamage(3, "SI", "3 - Significant injuries", 3);
        #endregion

        #region public static HumanDamage SingleFatality = new HumanDamage(4, "SF", "4 - Single Fatality", 4);
        /// <summary>
        /// единичный смертельный случай
        /// </summary>
        public static HumanDamage SingleFatality = new HumanDamage(4, "SF", "4 - Single Fatality", 4);
        #endregion

        #region public static HumanDamage NumerousDeaths = new HumanDamage(5, "ND", "5 - Numerous Deaths", 5);
        /// <summary>
        /// многочисленные смертельные случаи
        /// </summary>
        public static HumanDamage NumerousDeaths = new HumanDamage(5, "ND", "5 - Numerous Deaths", 5);
        #endregion

        #region public static HumanDamage UNK = new HumanDamage(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static HumanDamage UNK = new HumanDamage(-1, "UNK", "Unknown", 0);
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

        #region public static HumanDamage GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static HumanDamage GetItemById(Int32 maintenanceTypeId)
        {
            foreach (HumanDamage t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<HumanDamage> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<HumanDamage> Items
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
        #region public HumanDamage()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public HumanDamage()
        {
        }
        #endregion

        #region public HumanDamage(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public HumanDamage(Int32 itemId, String shortName, String fullName, int weight)
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
            if (y is HumanDamage)
                return FullName.CompareTo(((HumanDamage)y).FullName);
            return 0;
        }
        #endregion
    }
}
