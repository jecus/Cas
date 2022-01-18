using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Audit
{
    [Serializable]
    public class WorkFlowStatus : StaticDictionary
    {
        #region public static CommonDictionaryCollection<WorkFlowStatus> _Items = new CommonDictionaryCollection<WorkFlowStatus>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<WorkFlowStatus> _Items = new CommonDictionaryCollection<WorkFlowStatus>();
        #endregion

        public static WorkFlowStatus Unknown = new WorkFlowStatus(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static WorkFlowStatus GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static WorkFlowStatus GetItemById(int directiveTypeId)
        {
            foreach (WorkFlowStatus t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<WorkFlowStatus> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<WorkFlowStatus> Items
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
        #region public WorkFlowStatus()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public WorkFlowStatus()
        {
        }
        #endregion

        #region public WorkFlowStatus(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public WorkFlowStatus(Int32 itemID, String shortName, String fullName, String commonName)
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
