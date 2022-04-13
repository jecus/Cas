using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Tasks
{
    [Serializable]
    public class TaskLevel : StaticDictionary
    {
        #region public static CommonDictionaryCollection<TaskLevel> _Items = new CommonDictionaryCollection<TaskLevel>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<TaskLevel> _Items = new CommonDictionaryCollection<TaskLevel>();
        #endregion

        public static TaskLevel One = new TaskLevel(1, "1", "1", "");
        public static TaskLevel Two = new TaskLevel(2, "2", "2", "");
        public static TaskLevel Three = new TaskLevel(3, "3", "3", "");
       // public static TaskLevel Unknown = new TaskLevel(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static TaskLevel GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static TaskLevel GetItemById(int directiveTypeId)
        {
            foreach (TaskLevel t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return One;
        }

        #endregion

        #region static public CommonDictionaryCollection<TaskLevel> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<TaskLevel> Items
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
        * Свойства
        */

        /*
         * Реализация
         */
        #region public TaskLevel()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public TaskLevel()
        {
        }
        #endregion

        #region public TaskLevel(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public TaskLevel(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
	}
}
