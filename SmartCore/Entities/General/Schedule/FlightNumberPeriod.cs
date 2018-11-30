using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// Класс, описывает период планируемого рейса
    /// </summary>
    [Table("FlightNumberPeriods", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberPeriodDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumberPeriod : BaseEntityObject, IFlightNumberParams, IFlightFilterParams
	{
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public Int32 FlightNumberId { get; set; }
        /// <summary>
		/// Идентификатор рейса
		/// </summary>
        [TableColumn("FlightNumberId")]
        public int FlightNumberId { get; set; }


		public FlightNumber FlightNum { get; set; }
		public static PropertyInfo FlightNumberIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumberId"); }
        }

		#endregion

		#region public int PeriodFrom { get; set; }
		/// <summary>
		/// Дата начала периода рейса 
		/// </summary>
		[TableColumn("PeriodFrom")]
        public int PeriodFrom { get; set; }
		#endregion

		#region public int PeriodTo { get; set; }
		/// <summary>
		/// Дата окончания периода рейса 
		/// </summary>
		[TableColumn("PeriodTo")]
        public int PeriodTo { get; set; }

		#endregion

		#region public DateTime ArrivalDate { get; set; }

		[TableColumn("ArrivalDate")]
	    public DateTime ArrivalDate { get; set; }

		public static PropertyInfo ArrivalDateProperty
		{
			get { return GetCurrentType().GetProperty("ArrivalDate"); }
		}

		#endregion

		#region public DateTime DepartureDate { get; set; }

		[TableColumn("DepartureDate")]
	    public DateTime DepartureDate { get; set; }

		public static PropertyInfo DepartureDateProperty
		{
			get { return GetCurrentType().GetProperty("DepartureDate"); }
		}
		#endregion

		#region public bool IsMonday { get; set; }

		[TableColumn("IsMonday")]
		[Filter("IsMonday")]
	    public bool IsMonday { get; set; }

		#endregion

		#region public bool IsThursday { get; set; }

		[TableColumn("IsThursday")]
	    public bool IsThursday { get; set; }

		#endregion

		#region public bool IsWednesday { get; set; }

		[TableColumn("IsWednesday")]
	    public bool IsWednesday { get; set; }

		#endregion

		#region public bool IsTuesday { get; set; }

		[TableColumn("IsTuesday")]
	    public bool IsTuesday { get; set; }

		#endregion

		#region public bool IsFriday { get; set; }

		[TableColumn("IsFriday")]
	    public bool IsFriday { get; set; }

		#endregion

		#region public bool IsSaturday { get; set; }

		[TableColumn("IsSaturday")]
	    public bool IsSaturday { get; set; }

		#endregion

		#region public bool IsSunday { get; set; }

		[TableColumn("IsSunday")]
	    public bool IsSunday { get; set; }

		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion

		[TableColumn("Schedule")]
		public Dictionaries.Schedule Schedule { get; set; }

		public static PropertyInfo ScheduleProperty
		{
			get { return GetCurrentType().GetProperty("Schedule"); }
		}

		public FlightNum FlightNo { get { return FlightNum.FlightNo; } }
		public FlightAircraftCode FlightAircraftCode { get { return FlightNum.FlightAircraftCode; } }
		public FlightType FlightType { get { return FlightNum.FlightType; } }
		public FlightCategory FlightCategory { get { return FlightNum.FlightCategory; } }
		public AirportsCodes StationFrom { get { return FlightNum.StationFrom; } }
		public AirportsCodes StationTo { get { return FlightNum.StationTo; } }
		public CommonCollection<FlightNumberAircraftModelRelation> AircraftModels { get { return FlightNum.AircraftModels; } }

		/*
		*  Методы 
		*/

		#region public FlightNumberPeriod()
		/// <summary>
		/// Создает "пустую" запись о периоде действия планируемого рейса
		/// </summary>
		public FlightNumberPeriod()
        {
			SmartCoreObjectType = SmartCoreType.FlightNumberPeriod;
	        ItemId = -1;

			DepartureDate = DateTime.Today;
			ArrivalDate = DateTime.Today;
        }

		public FlightNumberPeriod(FlightNumberPeriod toCopy)
		{
			FlightNumberId = toCopy.FlightNumberId;
			FlightNum = toCopy.FlightNum;
			PeriodFrom = toCopy.PeriodFrom;
			ArrivalDate = toCopy.ArrivalDate;
			PeriodTo = toCopy.PeriodTo;
			DepartureDate = toCopy.DepartureDate;
			IsMonday = toCopy.IsMonday;
			IsThursday = toCopy.IsThursday;
			IsWednesday = toCopy.IsWednesday;
			IsTuesday = toCopy.IsTuesday;
			IsFriday = toCopy.IsFriday;
			IsSaturday = toCopy.IsSaturday;
			IsSaturday = toCopy.IsSaturday;
			IsSunday = toCopy.IsSunday;
		}

		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
	        var departure = DepartureDate.Date.AddMinutes(PeriodFrom);
	        var arrival = DepartureDate.Date.AddMinutes(PeriodTo);

			return $"{FlightNo} {StationFrom.ShortName} - {StationTo.ShortName} {departure:HH:mm} - {arrival:HH:mm}";
        }
        #endregion   

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightNumberPeriod));
        }
		#endregion

		public FlightNumberPeriod GetCopyUnsaved()
		{
			var flightNumber = (FlightNumberPeriod)MemberwiseClone();
			flightNumber.ItemId = -1;
			flightNumber.UnSetEvents();

			flightNumber.FlightNumberId = -1;

			return flightNumber;
		}
	}
}
