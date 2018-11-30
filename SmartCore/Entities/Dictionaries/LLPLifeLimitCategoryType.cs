using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    #region public enum LLPLifeLimitCategoryType : short
    /// <summary>
    /// Описывает тип (основную букву) Категории жизненного цикла вращающихся деталей
    /// </summary>
    [Serializable]
    public class LLPLifeLimitCategoryType : StaticDictionary, IWorkRegime
    {

        #region private static CommonDictionaryCollection<LLPLifeLimitCategoryType> _Items = new CommonDictionaryCollection<LLPLifeLimitCategoryType>();
        /// <summary>
        /// Содержит все элементы - это пригодиться нам, когда мы захотим получить тип базового агрегата по его id
        /// </summary>
        private static CommonDictionaryCollection<LLPLifeLimitCategoryType> _Items = new CommonDictionaryCollection<LLPLifeLimitCategoryType>();
        #endregion


        /*
         * Предопределенные типы
         */

        #region public static LLPLifeLimitCategoryType Unknown = new LLPLifeLimitCategoryType(-1, "UNK", "Unknown");
        /// <summary>
        /// Неизвестный регион
        /// </summary>
        public static LLPLifeLimitCategoryType Unknown = new LLPLifeLimitCategoryType(-1, "UNK", "Unknown");
        #endregion

        #region public static LLPLifeLimitCategoryType A = new LLPLifeLimitCategoryType(1, "A", "A");
        /// <summary>
        /// A
        /// </summary>
        public static LLPLifeLimitCategoryType A = new LLPLifeLimitCategoryType(1, "A", "A");
        #endregion

        #region public static LLPLifeLimitCategoryType B = new LLPLifeLimitCategoryType(2, "B", "B");
        /// <summary>
        /// B
        /// </summary>
        public static LLPLifeLimitCategoryType B = new LLPLifeLimitCategoryType(2, "B", "B");
        #endregion

        #region public static LLPLifeLimitCategoryType C = new LLPLifeLimitCategoryType(3, "C", "C");
        /// <summary>
        /// C
        /// </summary>
        public static LLPLifeLimitCategoryType C = new LLPLifeLimitCategoryType(3, "C", "C");
        #endregion

        #region public static LLPLifeLimitCategoryType D = new LLPLifeLimitCategoryType(4, "D", "D");
        /// <summary>
        /// D
        /// </summary>
        public static LLPLifeLimitCategoryType D = new LLPLifeLimitCategoryType(4, "D", "D");
        #endregion

        /*
         * Методы
         */

        #region public static LLPLifeLimitCategoryType GetItemById(Int32 itemId)
        /// <summary>
        /// Возвращает элемент по его Id
        /// </summary>
        /// <param name="itemId">id объекта</param>
        /// <returns>элемент с заданный id или null</returns>
        public static LLPLifeLimitCategoryType GetItemById(Int32 itemId)
        {
            foreach (LLPLifeLimitCategoryType t in _Items)
                if (t.ItemId == itemId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region public static CommonDictionaryCollection<LLPLifeLimitCategoryType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<LLPLifeLimitCategoryType> Items
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
        #region public LLPLifeLimitCategoryType()
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        public LLPLifeLimitCategoryType()
        {
            SmartCoreObjectType = SmartCoreType.LLPLifeLimitCategoryType;
        }
        #endregion

        #region public LLPLifeLimitCategoryType(Int32 ItemId, String shortName, String fullName) : this()
        /// <summary>
        /// Конструктор создает запись о типе агрегата
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public LLPLifeLimitCategoryType(Int32 itemId, String shortName, String fullName) : this()
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
