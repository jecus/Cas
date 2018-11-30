using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс описывает тип записей выполнения директивы
    /// </summary>
    [Serializable]
    public class DirectiveRecordType
    {

        // Таблица Dictionaries.DetailsRecordsTypes

        /*
         * Реализация
         */

        #region private  static List<DirectiveRecordType> _Items = new List<DirectiveRecordType>();

        /// <summary>
        /// Список типов
        /// </summary>
        private static List<DirectiveRecordType> _Items = new List<DirectiveRecordType>();

        #endregion

        /*
         * Предопределенные типы
         */

        #region public static DirectiveRecordType Perfromed = new DirectiveRecordType(3, "Performance");

        /// <summary>
        /// Выполнение директивы
        /// </summary>
        public static DirectiveRecordType Perfromed = new DirectiveRecordType(3, "Performance");

        #endregion

        #region public static DirectiveRecordType Closed = new DirectiveRecordType(4,"Closing");

        /// <summary>
        /// Закрытие директивы
        /// </summary>
        public static DirectiveRecordType Closed = new DirectiveRecordType(4, "Closing");

        #endregion

        #region public static DirectiveRecordType Superseded = new DirectiveRecordType(15,"Superseded");

        /// <summary>
        /// Ревизия (замена) директивы
        /// </summary>
        public static DirectiveRecordType Superseded = new DirectiveRecordType(15, "Superseded");

        #endregion

        #region public static DirectiveRecordType Terminated = new DirectiveRecordType(16,"Terminated");

        /// <summary>
        /// Выполнение (устранение, закрытие) директивы
        /// </summary>
        public static DirectiveRecordType Terminated = new DirectiveRecordType(16, "Terminated");

        #endregion

        #region public static DirectiveRecordType NotApplicable = new DirectiveRecordType(14,"Not Applicable");

        /// <summary>
        /// Директива не применима
        /// </summary>
        public static DirectiveRecordType NotApplicable = new DirectiveRecordType(14, "Not Applicable");

        #endregion

        /*
         * Свойства
         */

        #region public String Name { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public String Name { get; set; }

        #endregion

        #region  public Int32 ItemId { get; set; }

        /// <summary>
        /// ItemId  
        /// </summary>
        public Int32 ItemId { get; set; }

        #endregion

        /*
         * Методы
         */
        
        #region public override string ToString()

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region public static DirectiveRecordType GetRecordTypeById (Int32 id)
        /// <summary>
        /// Принимает id и возвращает по нему DirectiveRecordType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DirectiveRecordType GetRecordTypeById (Int32 id)
        {
            foreach (DirectiveRecordType item in _Items)
                if (item.ItemId==id)
                    return item;
            // Тип записи неизвестен - считаем за обычное выполнение директивы
            return Perfromed;
        }

        #endregion

        #region public DirectiveRecordType()

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DirectiveRecordType()
        {

        }

        #endregion

        #region public DirectiveRecordType(Int32 id,string name)
        /// <summary>
        /// Конструктор принимает 2 параметра
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <param name="name">Имя элемента</param>
        public DirectiveRecordType(Int32 id, string name)
        {
            Name = name;
            ItemId = id;
            _Items.Add(this);

        }

        #endregion


    }
}
