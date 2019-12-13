using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Отказы, нарушения, отклонения
	/// </summary>
	[Serializable]
	public class FailureViolationDeviation : StaticDictionary
    {
        private int _weight;

        #region private static CommonDictionaryCollection<FailureViolationDeviation> _Items = new CommonDictionaryCollection<FailureViolationDeviation>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<FailureViolationDeviation> _Items = new CommonDictionaryCollection<FailureViolationDeviation>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static FailureViolationDeviation NotAffectTheSafety = new FailureViolationDeviation(1, "NAtS", "1 - Not affect the safety", 1);
        /// <summary>
        /// не влияющие на безопасность полетов
        /// </summary>
        public static FailureViolationDeviation NotAffectTheSafety = new FailureViolationDeviation(1, "NAtS", "1 - Not affect the safety", 1);
        #endregion

        #region public static FailureViolationDeviation ComplexityOfFlight = new FailureViolationDeviation(2, "CoF", "2 - Complexity of flight", 2);
        /// <summary>
        /// усложнение условий полета
        /// </summary>
        public static FailureViolationDeviation ComplexityOfFlight = new FailureViolationDeviation(2, "CoF", "2 - Complexity of flight", 2);
        #endregion

        #region public static FailureViolationDeviation DifficultSituation = new FailureViolationDeviation(3, "DS", "3 - Difficult situation", 3);
        /// <summary>
        /// сложная ситуация
        /// </summary>
        public static FailureViolationDeviation DifficultSituation = new FailureViolationDeviation(3, "DS", "3 - Difficult situation", 3);
        #endregion

        #region public static FailureViolationDeviation AccidentSituation = new FailureViolationDeviation(4, "AS", "4 - Accident situation", 4);
        /// <summary>
        /// аварийная ситуация
        /// </summary>
        public static FailureViolationDeviation AccidentSituation = new FailureViolationDeviation(4, "AS", "4 - Accident situation", 4);
        #endregion

        #region public static FailureViolationDeviation CatastrophicSituation = new FailureViolationDeviation(5, "CS", "5 - Catastrophic Situation", 5);
        /// <summary>
        /// катастрофическая ситуация
        /// </summary>
        public static FailureViolationDeviation CatastrophicSituation = new FailureViolationDeviation(5, "CS", "5 - Catastrophic Situation", 5);
        #endregion

        #region public static FailureViolationDeviation UNK = new FailureViolationDeviation(-1, "UNK", "Unknown", 0);
        /// <summary>
        /// неизвестный
        /// </summary>
        public static FailureViolationDeviation UNK = new FailureViolationDeviation(-1, "UNK", "Unknown", 0);
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

        #region public static FailureViolationDeviation GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static FailureViolationDeviation GetItemById(Int32 maintenanceTypeId)
        {
            foreach (FailureViolationDeviation t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<FailureViolationDeviation> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<FailureViolationDeviation> Items
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
        #region public FailureViolationDeviation()
        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        public FailureViolationDeviation()
        {
        }
        #endregion

        #region public FailureViolationDeviation(Int32 itemId, String shortName, String fullName, int weight)

        /// <summary>
        /// Конструктор создает объект повреждения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="weight"></param>
        public FailureViolationDeviation(Int32 itemId, String shortName, String fullName, int weight)
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
            if (y is FailureViolationDeviation)
                return FullName.CompareTo(((FailureViolationDeviation)y).FullName);
            return 0;
        }
        #endregion
    }
}
