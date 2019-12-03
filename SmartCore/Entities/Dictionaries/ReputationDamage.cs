using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Ущерб репутации
	/// </summary>
	[Serializable]
	public class ReputationDamage : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<ReputationDamage> _Items = new CommonDictionaryCollection<ReputationDamage>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<ReputationDamage> _Items = new CommonDictionaryCollection<ReputationDamage>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static ReputationDamage LightDamage = new ReputationDamage(1, "LD", "1 - Light damage", 1);
        /// <summary>
        /// легкие повреждения
        /// </summary>
        public static ReputationDamage LightDamage = new ReputationDamage(1, "LD", "1 - Light damage", 1);
        #endregion

        #region public static ReputationDamage MinorDamage = new ReputationDamage(2, "MnD", "2 - Minor Damage", 2);
        /// <summary>
        /// незначительные повреждения
        /// </summary>
        public static ReputationDamage MinorDamage = new ReputationDamage(2, "MnD", "2 - Minor Damage", 2);
        #endregion

        #region public static ReputationDamage SignificantDamage = new ReputationDamage(3, "SD", "3 - Significant damage", 3);
        /// <summary>
        /// значительные повреждения
        /// </summary>
        public static ReputationDamage SignificantDamage = new ReputationDamage(3, "SD", "3 - Significant damage", 3);
        #endregion

        #region public static ReputationDamage InStateDamage = new ReputationDamage(4, "ISD", "4 - In state damage", 4);
        /// <summary>
        /// урон внутри государства
        /// </summary>
        public static ReputationDamage InStateDamage = new ReputationDamage(4, "ISD", "4 - In state damage", 4);
        #endregion

        #region public static ReputationDamage InternationalDamage = new ReputationDamage(5, "ID", "5 - International damage", 5);
        /// <summary>
        /// международный урон
        /// </summary>
        public static ReputationDamage InternationalDamage = new ReputationDamage(5, "ID", "5 - International damage", 5);
        #endregion

        #region public static ReputationDamage UNK = new ReputationDamage(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static ReputationDamage UNK = new ReputationDamage(-1, "UNK", "Unknown", 0);
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

        #region public static ReputationDamage GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static ReputationDamage GetItemById(Int32 maintenanceTypeId)
        {
            foreach (ReputationDamage t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<ReputationDamage> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ReputationDamage> Items
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
        #region public ReputationDamage()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public ReputationDamage()
        {
        }
        #endregion

        #region public ReputationDamage(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public ReputationDamage(Int32 itemId, String shortName, String fullName, int weight)
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
            if (y is ReputationDamage)
                return FullName.CompareTo(((ReputationDamage)y).FullName);
            return 0;
        }
        #endregion
    }
}
