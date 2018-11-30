using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// Класс, описывает расписание рейса на определенный день
    /// </summary>
    [Table("FlightNumberPeriod s", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberPeriodDTO))]
	[Condition("IsDeleted", "0")]
    public class FlightNumberPeriodDaySchedule : BaseEntityObject
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

        #region public Int32 FlightNumberPeriodId { get; set; }
        /// <summary>
        /// описывает период, которому принадлежит день расписания рейса
        /// </summary>
        [TableColumnAttribute("FlightNumberPeriodId")]
        [ParentAttribute]
        public FlightNumberPeriod FlightNumberPeriod { get; set; }

        public static PropertyInfo FlightNumberPeriodProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumberPeriod"); }
        }

        #endregion

        #region public DateTime PeriodFrom { get; set; }
        /// <summary>
        /// Дата начала периода рейса 
        /// </summary>
        [TableColumnAttribute("PeriodFrom")]
        [FormControl("PeriodFrom")]
        [ListViewData(200f, "PeriodFrom")]
        [NotNull]
        public DateTime PeriodFrom { get; set; }
        #endregion

        #region public DateTime PeriodTo { get; set; }
        /// <summary>
        /// Дата окончания периода рейса 
        /// </summary>
        [TableColumnAttribute("PeriodTo")]
        [FormControl("PeriodTo")]
        [ListViewData(200f, "PeriodTo")]
        [NotNull]
        public DateTime PeriodTo { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public FlightNumberPeriodDaySchedule()
        /// <summary>
        /// Создает "пустую" запись о периоде действия планируемого рейса
        /// </summary>
        public FlightNumberPeriodDaySchedule()
        {
            PeriodFrom = DateTime.Today;
            PeriodTo = DateTime.Today.AddDays(1);
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
            return _thisType ?? (_thisType = typeof(FlightNumberPeriod));
        }
        #endregion
    }
}
