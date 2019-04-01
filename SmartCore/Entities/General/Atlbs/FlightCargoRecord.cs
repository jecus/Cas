using System;
using System.Reflection;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{
    /// <summary>
    /// Класс описывает груз на борту во время определенного полета
    /// </summary>
    [Table("FlightCargoRecords", "dbo", "ItemId")]
    public class FlightCargoRecord : AbstractRecord
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

        #region public CargoCategory CargoCategory { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [TableColumnAttribute("CargoCategory")]
        public CargoCategory CargoCategory { get; set; }
        #endregion

        #region public double Weigth { get; set; }
        /// <summary>
        /// Вес 
        /// </summary>
        [TableColumnAttribute("Weigth")]
        public double Weigth { get; set; }
        #endregion

        #region public Measure Measure { get; set; }
        /// <summary>
        /// Единица измерения груза
        /// </summary>
        [TableColumnAttribute("Measure")]
        public Measure Measure { get; set; }
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

        #region public FlightCargoRecord()

        public FlightCargoRecord()
        {
            CargoCategory = null;
            Weigth = 0;
            Measure = null;
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightCargoRecord;
        }

        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightCargoRecord));
        }
        #endregion
    }
}
