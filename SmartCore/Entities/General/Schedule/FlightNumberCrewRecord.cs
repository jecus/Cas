using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// Класс, описывает должность члена экипажа на планируемый рейс
    /// </summary>
    [Table("FlightNumberCrewRecords", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberCrewRecordDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumberCrewRecord : BaseEntityObject
    {
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public Int32 FlightNumberId { get; set; }
        /// <summary>
		/// Идентификатор рейса
		/// </summary>
        [TableColumnAttribute("FlightNumberId")]
        [ParentAttribute]
        public FlightNumber FlightNumber { get; set; }

        public static PropertyInfo FlightNumberIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumber"); }
        }

		#endregion

        #region public Int32 Specialization { get; set; }
        /// <summary>
        /// Идентификатор должности 
        /// </summary>
        [TableColumnAttribute("SpecializationId")]
        [FormControl("Occupation")]
        [ListViewData(250f, "Occupation")]
        [NotNull]
        public Specialization Specialization { get; set; }
        #endregion

        #region public Int32 Count { get; set; }
        /// <summary>
        /// Количество специалистов данной должности, требуемое для рейса
        /// </summary>
        [TableColumnAttribute("Count")]
        [FormControl("Count")]
        [ListViewData(100f, "Count")]
        [MinMaxValue(1,10)]
        public Int32 Count { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public FlightNumberCrewRecord()
        /// <summary>
        /// Создает "пустую" запись о должности члена экипажа на планируемый рейс
        /// </summary>
        public FlightNumberCrewRecord()
        {
            Count = 1;
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
            return _thisType ?? (_thisType = typeof(FlightNumberCrewRecord));
        }
		#endregion

		public FlightNumberCrewRecord GetCopyUnsaved()
		{
			var record = (FlightNumberCrewRecord)MemberwiseClone();
			record.ItemId = -1;
			record.UnSetEvents();

			return record;
		}
	}
}
