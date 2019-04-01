using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General
{

    /// <summary>
    /// Класс, описывает запись о полете определенного специалиста
    /// </summary>
    [Table("FlightCrews", "dbo", "ItemId")]
    [Dto(typeof(FlightCrewRecordDTO))]
	public class FlightCrewRecord : BaseEntityObject
    {
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public Int32 FlightId { get; set; }
        /// <summary>
		/// Идентификатор полета
		/// </summary>
        [TableColumnAttribute("FlightId")]
        public Int32 FlightId { get; set; }

        public static PropertyInfo FlightIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightId"); }
        }

		#endregion

        #region public Int32 Specialist { get; set; }
        /// <summary>
		/// Идентификатор специалиста
		/// </summary>
        [TableColumnAttribute("SpecialistId")]
        [Child(false)]
        public Specialist Specialist { get; set; }

		public static PropertyInfo SpecialistIdProperty
		{
			get { return GetCurrentType().GetProperty("Specialist"); }
		}

		#endregion

		#region public Int32 Specialization { get; set; }
		/// <summary>
		/// Идентификатор специализации специалиста 
		/// </summary>
		[TableColumnAttribute("SpecializationId")]
        public Specialization Specialization { get; set; }
        #endregion

        #region public Int32 IDNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("IdNo")]
        public Int32 IdNo { get; set; }
        #endregion

		#region public String Limitations { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Limitations")]
        public String Limitations { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Remarks")]
        public String Remarks { get; set; }
		#endregion

        /*
		*  Методы 
		*/

        #region public FlightCrewRecord()
        /// <summary>
        /// Создает "пустую" запись о полете специалиста
        /// </summary>
        public FlightCrewRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightCrewRecord;

        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightCrewRecord));
        }
        #endregion
    }
}
