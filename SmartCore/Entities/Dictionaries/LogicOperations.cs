using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    public class LogicOperation : StaticDictionary
    {

        public LogicOperationCategory OperationCategory { get; set; }

        #region private static CommonDictionaryCollection<LogicOperation> _Items = new CommonDictionaryCollection<LogicOperation>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<LogicOperation> _Items = new CommonDictionaryCollection<LogicOperation>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static LogicOperation Unknown = new LogicOperation(-1, "Unk", "Unknown", LogicOperationCategory.Unknown);
        /// <summary>
        /// Неизвестный
        /// </summary>
        public static LogicOperation Unknown = new LogicOperation(-1, "Unk", "Unknown", LogicOperationCategory.Unknown);
        #endregion

        #region public static LogicOperation Less = new LogicOperation(11, "<", "Less", LogicOperationCategory.Compare);
        /// <summary>
        /// Меньше
        /// </summary>
        public static LogicOperation Less = new LogicOperation(11, "<", "Less", LogicOperationCategory.Compare);
        #endregion

        #region public static LogicOperation LessOrEqual = new LogicOperation(12, "<=", "Less or equal", LogicOperationCategory.Compare);
        /// <summary>
        /// Меньше либо равно
        /// </summary>
        public static LogicOperation LessOrEqual = new LogicOperation(12, "<=", "Less or equal", LogicOperationCategory.Compare);
        #endregion

        #region public static LogicOperation Equal = new LogicOperation(13, "=", "Equal", LogicOperationCategory.Compare);
        /// <summary>
        /// Равно
        /// </summary>
        public static LogicOperation Equal = new LogicOperation(13, "=", "Equal", LogicOperationCategory.Compare);
        #endregion

        #region public static LogicOperation GratherOrEqual = new LogicOperation(14, ">=", "Grather or equal", LogicOperationCategory.Compare);
        /// <summary>
        /// Больше или авно
        /// </summary>
        public static LogicOperation GratherOrEqual = new LogicOperation(14, ">=", "Grather or equal", LogicOperationCategory.Compare);
        #endregion

        #region public static LogicOperation Grather = new LogicOperation(15, ">", "Grather", LogicOperationCategory.Compare);
        /// <summary>
        /// Больше
        /// </summary>
        public static LogicOperation Grather = new LogicOperation(15, ">", "Grather", LogicOperationCategory.Compare);
        #endregion

        /*
         * Свойства 
         */

        #region static public CommonDictionaryCollection<LogicOperation> Items
        /// <summary>
        /// Возвращает список элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<LogicOperation> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
		*  Методы 
		*/

        #region public LogicOperation()
        /// <summary>
        /// Конструктор создает пустой объект категории единицы измерения
        /// </summary>
        public LogicOperation()
        {
        }
        #endregion

        #region public LogicOperation(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект логической операции
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="mc"></param>
        public LogicOperation(Int32 itemId, String shortName, String fullName, LogicOperationCategory mc)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            OperationCategory = mc;
            _Items.Add(this);
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName;
        }
        #endregion

        #region public static IEnumerable<LogicOperation> GetByCategory(LogicOperationCategory category)
        /// <summary>
        /// Возвращает логические операции соостветствующие определенной категории, 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<LogicOperation> GetByCategory(LogicOperationCategory category)
        {
            return _Items.Where(m=>m.OperationCategory == category);
        }
        #endregion
    }

    #region public class LogicOperationCategory : StaticDictionary
    /// <summary>
    /// Категория логической операции
    /// </summary>
    public class LogicOperationCategory : StaticDictionary
    {

        #region private static CommonDictionaryCollection<LogicOperationCategory> _Items = new CommonDictionaryCollection<LogicOperationCategory>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<LogicOperationCategory> _Items = new CommonDictionaryCollection<LogicOperationCategory>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static LogicOperationCategory Unknown = new LogicOperationCategory(-1, "Unk", "Unknown", "");
        /// <summary>
        /// Неизвестный
        /// </summary>
        public static LogicOperationCategory Unknown = new LogicOperationCategory(-1, "Unk", "Unknown");
        #endregion

        #region public static LogicOperationCategory Compare = new LogicOperationCategory(1, "C", "Compare");
        /// <summary>
        /// Сравнение
        /// </summary>
        public static LogicOperationCategory Compare = new LogicOperationCategory(1, "C", "Compare");
        #endregion

        /*
         * Свойства 
         */

        #region static public CommonDictionaryCollection<LogicOperationCategory> Items
        /// <summary>
        /// Возвращает список элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<LogicOperationCategory> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
		*  Методы 
		*/
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        #region public LogicOperationCategory()
        /// <summary>
        /// Конструктор создает пустой объект категории логической операции
        /// </summary>
        public LogicOperationCategory()
        {
        }
        #endregion

        #region public LogicOperationCategory(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект категории единицы измерения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public LogicOperationCategory(Int32 itemId, String shortName, String fullName)
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
