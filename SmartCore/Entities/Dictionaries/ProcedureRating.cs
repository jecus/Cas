using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    public class ProcedureRating : StaticDictionary
    {

        #region private static CommonDictionaryCollection<ProcedureRating> _Items = new CommonDictionaryCollection<ProcedureRating>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<ProcedureRating> _Items = new CommonDictionaryCollection<ProcedureRating>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static ProcedureRating Unknown = new ProcedureRating(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static ProcedureRating Unknown = new ProcedureRating(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        #region public static ProcedureRating A1 = new ProcedureRating(1, "A1", "A1", "A1");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating A1 = new ProcedureRating(1, "A1", "A1", "A1");
        #endregion

        #region public static ProcedureRating A2 = new ProcedureRating(2, "A2", "A2", "A2");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating A2 = new ProcedureRating(2, "A2", "A2", "A2");
        #endregion

        #region public static ProcedureRating A3 = new ProcedureRating(3, "A3", "A3", "A3");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating A3 = new ProcedureRating(3, "A3", "A3", "A3");
        #endregion

        #region public static ProcedureRating A4 = new ProcedureRating(4, "A4", "A4", "A4");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating A4 = new ProcedureRating(4, "A4", "A4", "A4");
        #endregion


        #region public static ProcedureRating B2 = new ProcedureRating(5, "B2", "B2", "B2");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating B2 = new ProcedureRating(5, "B2", "B2", "B2");
        #endregion


        #region public static ProcedureRating C1 = new ProcedureRating(6, "C1", "C1", "C1");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C1 = new ProcedureRating(6, "C1", "C1", "C1");
        #endregion

        #region public static ProcedureRating C2 = new ProcedureRating(7, "C2", "C2", "C2");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C2 = new ProcedureRating(7, "C2", "C2", "C2");
        #endregion

        #region public static ProcedureRating C3 = new ProcedureRating(8, "C3", "C3", "C3");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C3 = new ProcedureRating(8, "C3", "C3", "C3");
        #endregion

        #region public static ProcedureRating C4 = new ProcedureRating(9, "C4", "C4", "C4");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C4 = new ProcedureRating(9, "C4", "C4", "C4");
        #endregion

        #region public static ProcedureRating C5 = new ProcedureRating(10, "C5", "C5", "C5");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C5 = new ProcedureRating(10, "C5", "C5", "C5");
        #endregion

        #region public static ProcedureRating C6 = new ProcedureRating(11, "C6", "C6", "C6");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C6 = new ProcedureRating(11, "C6", "C6", "C6");
        #endregion

        #region public static ProcedureRating C7 = new ProcedureRating(12, "C7", "C7", "C7");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C7 = new ProcedureRating(12, "C7", "C7", "C7");
        #endregion

        #region public static ProcedureRating C8 = new ProcedureRating(13, "C8", "C8", "C8");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C8 = new ProcedureRating(13, "C8", "C8", "C8");
        #endregion

        #region public static ProcedureRating C9 = new ProcedureRating(14, "C9", "C9", "C9");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C9 = new ProcedureRating(14, "C9", "C9", "C9");
        #endregion

        #region public static ProcedureRating C10 = new ProcedureRating(15, "C10", "C10", "C10");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C10 = new ProcedureRating(15, "C10", "C10", "C10");
        #endregion

        #region public static ProcedureRating C11 = new ProcedureRating(16, "C11", "C11", "C11");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C11 = new ProcedureRating(16, "C11", "C11", "C11");
        #endregion

        #region public static ProcedureRating C12 = new ProcedureRating(17, "C12", "C12", "C12");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C12 = new ProcedureRating(17, "C12", "C12", "C12");
        #endregion

        #region public static ProcedureRating C13 = new ProcedureRating(18, "C13", "C13", "C13");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C13 = new ProcedureRating(18, "C13", "C13", "C13");
        #endregion

        #region public static ProcedureRating C14 = new ProcedureRating(19, "C14", "C14", "C14");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C14 = new ProcedureRating(19, "C14", "C14", "C14");
        #endregion

        #region public static ProcedureRating C15 = new ProcedureRating(20, "C15", "C15", "C15");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C15 = new ProcedureRating(20, "C15", "C15", "C15");
        #endregion

        #region public static ProcedureRating C16 = new ProcedureRating(21, "C16", "C16", "C16");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C16 = new ProcedureRating(21, "C16", "C16", "C16");
        #endregion

        #region public static ProcedureRating C17 = new ProcedureRating(22, "C17", "C17", "C17");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C17 = new ProcedureRating(22, "C17", "C17", "C17");
        #endregion

        #region public static ProcedureRating C18 = new ProcedureRating(23, "C18", "C18", "C18");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C18 = new ProcedureRating(23, "C18", "C18", "C18");
        #endregion

        #region public static ProcedureRating C19 = new ProcedureRating(24, "C19", "C19", "C19");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C19 = new ProcedureRating(24, "C19", "C19", "C19");
        #endregion

        #region public static ProcedureRating C20 = new ProcedureRating(25, "C20", "C20", "C20");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C20 = new ProcedureRating(25, "C20", "C20", "C20");
        #endregion

        #region public static ProcedureRating C21 = new ProcedureRating(26, "C21", "C21", "C21");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C21 = new ProcedureRating(26, "C21", "C21", "C21");
        #endregion

        #region public static ProcedureRating C22 = new ProcedureRating(27, "C22", "C22", "C22");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating C22 = new ProcedureRating(27, "C22", "C22", "C22");
        #endregion

        #region public static ProcedureRating D1 = new ProcedureRating(28, "D1", "D1", "D1");
        /// <summary> 
        /// Внутренний на месте
        /// </summary>
        public static ProcedureRating D1 = new ProcedureRating(28, "D1", "D1", "D1");
        #endregion

        /*
         * Методы
         */

        #region public static ProcedureRating GetItemById(Int32 directiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static ProcedureRating GetItemById(Int32 directiveTypeId)
        {
            foreach (ProcedureRating t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<ProcedureRating> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ProcedureRating> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is ProcedureRating)
                return String.Compare(FullName, ((ProcedureRating)y).FullName, StringComparison.Ordinal);
            return 0;
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
        #region public ProcedureRating()
        public ProcedureRating()
        {
            
        }
        #endregion

        #region public ProcedureRating(Int32 itemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public ProcedureRating(Int32 itemId, String shortName, String fullName, String commonName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    
    }
}
