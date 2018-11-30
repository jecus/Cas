using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс описывает возможные состояния директивы
    /// </summary>
    [Serializable]
    public class DirectiveStatus : StaticDictionary
    {
        #region private static CommonDictionaryCollection<DirectiveStatus> _Items = new CommonDictionaryCollection<DirectiveStatus>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<DirectiveStatus> _Items = new CommonDictionaryCollection<DirectiveStatus>();
        #endregion
        /*
         * Реализация
         */
        #region static public CommonDictionaryCollection<DirectiveStatus> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<DirectiveStatus> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
         * Возможные состояния директивы
         */

        #region public static DirectiveStatus Open = new DirectiveStatus(2, "O", "Open");
        /// <summary>
        /// Директива открыта
        /// </summary>
        public static DirectiveStatus Open = new DirectiveStatus(2, "O", "Open");

        #endregion

        #region public static DirectiveStatus Closed = new DirectiveStatus(0, "C", "Closed");
        /// <summary>
        /// Директива закрыта
        /// </summary>
        public static DirectiveStatus Closed = new DirectiveStatus(0, "C", "Closed");

        #endregion

        #region public static DirectiveStatus NotApplicable = new DirectiveStatus(1, "N/A", "Not Applicable");
        /// <summary>
        /// Директива не применима
        /// </summary>
        public static DirectiveStatus NotApplicable = new DirectiveStatus(1, "N/A", "TBD");

        #endregion

        #region public static DirectiveStatus Repetative = new DirectiveStatus(3, "R", "Repetative");
        /// <summary>
        /// Директива уже выполнялась и выполнение должно быть повторено
        /// </summary>
        public static DirectiveStatus Repetative = new DirectiveStatus(3, "R", "Repetative");

        #endregion

        #region public static DirectiveStatus UNK = new DirectiveStatus(-1, "UNK", "Unknown");
        /// <summary>
        /// 
        /// </summary>
        public static DirectiveStatus UNK = new DirectiveStatus(-1, "UNK", "Unknown");
        #endregion
        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public DirectiveStatus()
        
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DirectiveStatus()
        {
        }

        #endregion

        #region public DirectiveStatus(String shortName, String fullName)

        /// <summary>
        /// Конструктор принимает псевдоним и полное имя статуса
        /// </summary>
        /// <param name="recordTypeId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public DirectiveStatus(Int32 recordTypeId, String shortName, String fullName)
        {
            ShortName = shortName;
            FullName = fullName;
            ItemId = recordTypeId;
            _Items.Add(this);
        }

        #endregion

        #region public override string ToString()
        /// <summary>
        /// Возвращает полное имя объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }

        #endregion

        #region public static ConditionState GetItemById(Int32 conditionStateId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="conditionStateId"></param>
        /// <returns></returns>
        public static DirectiveStatus GetItemById(Int32 conditionStateId)
        {
            foreach (DirectiveStatus t in _Items)
                if (t.ItemId == conditionStateId)
                    return t;
            //
            return UNK;
        }

        #endregion

    }


}
