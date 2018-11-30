using System;
using SmartCore.Calculations;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Абстрактный класс для всех записей
    /// </summary>
    [Serializable]
    public abstract class AbstractRecord : BaseEntityObject
    {

        #region public abstract DateTime RecordDate { get; set; }
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public abstract DateTime RecordDate { get; set; }
        #endregion

        #region public abstract Lifelength OnLifelength { get; set; }
        /// <summary>
        /// наработка при которой была выполнена директива
        /// </summary>
        public abstract Lifelength OnLifelength { get; set; }
        #endregion

        #region public abstract string Remarks { get; set; }
        /// <summary>
        /// Доп информация к записи
        /// </summary>
        public abstract string Remarks { get; set; }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is AbstractRecord) return RecordDate.CompareTo(((AbstractRecord)y).RecordDate);
            return 0;
        }
        #endregion
    }
}
