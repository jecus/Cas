using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Tasks
{
    [Serializable]
    public class TaskType : StaticDictionary
    {
        #region public static CommonDictionaryCollection<TaskType> _Items = new CommonDictionaryCollection<TaskType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<TaskType> _Items = new CommonDictionaryCollection<TaskType>();
        #endregion

        public static TaskType Training = new TaskType(1, "Training", "Training", "Training");
        public static TaskType OJT = new TaskType(2, "OJT", "OJT", "OJT");

        /*
         * Методы
         */

        #region public static TaskType GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static TaskType GetItemById(int directiveTypeId)
        {
            foreach (TaskType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Training;
        }

        #endregion

        #region static public CommonDictionaryCollection<TaskType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<TaskType> Items
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
        #region public TaskType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public TaskType()
        {
        }
        #endregion

        #region public TaskType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public TaskType(Int32 itemID, String shortName, String fullName, String commonName)
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
