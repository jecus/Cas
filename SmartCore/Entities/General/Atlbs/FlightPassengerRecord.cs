using System;
using System.Reflection;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{
    /// <summary>
    /// Класс описывает запуск двигателя или ВСУ
    /// </summary>
    [Table("FlightPassengerRecords", "dbo", "ItemId")]
    public class FlightPassengerRecord : AbstractRecord
    {
        private static Type _thisType;

        #region public Int32 FlightId { get; set; }
        /// <summary>
        /// Ид полета в рамках которого производился запуск
        /// </summary>
        [TableColumnAttribute("FlightId")]
        public Int32 FlightId { get; set; }

        public static PropertyInfo FlightIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightId"); }
        }

        #endregion

        #region public AGWCategory PassengerCategory { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [TableColumnAttribute("PassengerCategory")]
        public AGWCategory PassengerCategory { get; set; }
        #endregion

        #region public Int16 CountEconomy { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [TableColumnAttribute("CountEconomy")]
        public Int16 CountEconomy { get; set; }
        #endregion

        #region public Int16 CountBusiness { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [TableColumnAttribute("CountBusiness")]
        public Int16 CountBusiness { get; set; }
        #endregion

        #region public Int16 CountFirst { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [TableColumnAttribute("CountFirst")]
        public Int16 CountFirst { get; set; }
        #endregion

        #region public override DateTime RecordDate { get; set; }
        /// <summary>
        /// Дата и время произведения пуска
        /// </summary>
        [TableColumnAttribute("RecordDate")]
        public override DateTime RecordDate { get; set; }
        #endregion

        #region public override Lifelength OnLifelength { get; set; }
        /// <summary>
        /// наработка при которой была выполнена директива
        /// </summary>
        public override Lifelength OnLifelength { get; set; }
        #endregion

        #region override public string Remarks { get; set; }
        /// <summary>
        /// Доп информация к записи
        /// </summary>
        public override string Remarks { get; set; }
        #endregion

        /*
         *  Дополнительные своиства
         */

        public FlightPassengerRecord()
        {
            PassengerCategory = null;
            CountEconomy = 0;
            CountBusiness = 0;
            CountFirst = 0;
        }

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightPassengerRecord));
        }
        #endregion
    }
}
