using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// Класс для описания рейса в системе расписания
    /// </summary>
    [Table("FlightNumbers", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumber : BaseEntityObject, IDirective, IComparable<FlightNumber>, IEquatable<FlightNumber>, IFlightNumberParams, IFlightFilterParams
	{
        private static Type _thisType;
		/*
        *  Свойства
        */

		#region public FlightNum FlightNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FlightNo")]
        [ListViewData(60, "Flight №")]
        public FlightNum FlightNo { get; set; }
        #endregion

        #region public FlightAircraftCode FlightAircraftCode
        /// <summary>
        /// Код ВС на данный полет (Пассажирское, грузовое, смешанное)
        /// </summary>
        private FlightAircraftCode _flightAircraftCode;
        [TableColumnAttribute("FlightAircraftCode")]
        public FlightAircraftCode FlightAircraftCode
        {
            get { return _flightAircraftCode; }
            set { _flightAircraftCode = value; }
        }
        #endregion

        #region public FlightType FlightType
        /// <summary>
        /// Тип Рейса (Регулярный, нерегулярный, чартерный и т.д.)
        /// </summary>
        private FlightType _flightType;
        [TableColumnAttribute("FlightType")]
        public FlightType FlightType
        {
            get { return _flightType ?? FlightType.UNK; }
            set { _flightType = value; }
        }

		public static PropertyInfo FlightTypeProperty
		{
			get { return GetCurrentType().GetProperty("FlightType"); }
		}

		#endregion

		#region public FlightCategory FlightCategory
		/// <summary>
		/// Категория Рейса (Внутренний рейс, Международный рейс и т.д.)
		/// </summary>
		private FlightCategory _flightCategory;
        [TableColumnAttribute("FlightCategory")]
        public FlightCategory FlightCategory
        {
            get { return _flightCategory; }
            set { _flightCategory = value; }
        }
        #endregion

        #region  public Int32 Distance { get; set; }
        /// <summary>
        /// Дистанция полета
        /// </summary>
        [TableColumnAttribute("Distance")]
        public Int32 Distance { get; set; }
        #endregion

        #region public Measure DistanceMeasure { get; set; }
        /// <summary>
        /// Единица измерения дистанции полета
        /// </summary>
        [TableColumnAttribute("DistanceMeasure")]
        public Measure DistanceMeasure { get; set; }
        #endregion

        #region public Airport StationFrom { get; set; }
        /// <summary>
        /// Место вылета
        /// </summary>
        [TableColumnAttribute("StationFrom")]
        public AirportsCodes StationFrom { get; set; }
        #endregion

        #region public Airport StationTo { get; set; }
        /// <summary>
        /// Место посадки
        /// </summary>
        [TableColumnAttribute("StationTo")]
        public AirportsCodes StationTo { get; set; }
        #endregion

        #region  public CruiseLevel MinLevel { get; set; }
        /// <summary>
        /// Минимальный Эшелон полета
        /// </summary>
        [TableColumnAttribute("MinLevel")]
        public CruiseLevel MinLevel { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// Описание директивы
		/// </summary>
		[TableColumnAttribute("Description", 1024)]
        public String Description { get; set; }
        #endregion

        #region  public Double MaxFuelAmount { get; set; }
        /// <summary>
        /// Максимальное кол-во топлива (кг) на рейс
        /// </summary>
        [TableColumnAttribute("MaxFuelAmount")]
        public Double MaxFuelAmount { get; set; }
        #endregion

        #region  public Double MinFuelAmount { get; set; }
        /// <summary>
        /// Минимальное кол-во топлива (кг) на рейс
        /// </summary>
        [TableColumnAttribute("MinFuelAmount")]
        public Double MinFuelAmount { get; set; }
        #endregion

        #region  public Int32 MaxPassengerAmount{ get; set; }
        /// <summary>
        /// Максимальное кол-во пассажиров на рейс (чел.)
        /// </summary>
        [TableColumnAttribute("MaxPassengerAmount")]
        public Int32 MaxPassengerAmount { get; set; }
        #endregion

        #region  public Double MaxPayload{ get; set; }
        /// <summary>
        /// Максимальная коммерческая нагрузка (кг)
        /// </summary>
        [TableColumnAttribute("MaxPayload")]
        public Double MaxPayload { get; set; }
        #endregion

        #region  public Double MaxCargoWeight{ get; set; }
        /// <summary>
        /// Максимальный вес груза (кг)
        /// </summary>
        [TableColumnAttribute("MaxCargoWeight")]
        public Double MaxCargoWeight { get; set; }
        #endregion

        #region  public Double MaxTakeOffWeight{ get; set; }
        /// <summary>
        /// Максимальный Взлетный вес (кг) на рейс 
        /// </summary>
        [TableColumnAttribute("MaxTakeOffWeight")]
        public Double MaxTakeOffWeight { get; set; }
		#endregion

		#region  public Double MaxLandWeight{ get; set; }
		/// <summary>
		/// Максимальный Взлетный вес (кг) на рейс 
		/// </summary>
		[TableColumnAttribute("MaxLandWeight")]
	    public Double MaxLandWeight { get; set; }
	    #endregion

		#region public CommonCollection<FlightNumberAircraftModelRelation> AircraftModels { get; set; }

		private CommonCollection<FlightNumberAircraftModelRelation> _aircraftModels;
        /// <summary>
        /// Модели ВС, которые могут лететь на рейс
        /// </summary>
        [Child(RelationType.OneToMany, "FlightNumberId", "FlightNumber")]
        public CommonCollection<FlightNumberAircraftModelRelation> AircraftModels
        {
            get { return _aircraftModels ?? (_aircraftModels = new CommonCollection<FlightNumberAircraftModelRelation>()); }
            set
            {
                if (_aircraftModels != value)
                {
                    if (_aircraftModels != null)
                        _aircraftModels.Clear();
                    if (value != null)
                        _aircraftModels = value;
                }
            }
        }

		#endregion

        #region public CommonCollection<FlightNumberAirportRelation> AlternateAirports { get; set; }

        private CommonCollection<FlightNumberAirportRelation> _alternateAirports;
        /// <summary>
        /// Запасные аэропорты
        /// </summary>
        [Child(RelationType.OneToMany, "FlightNumberId", "FlightNumber")]
        public CommonCollection<FlightNumberAirportRelation> AlternateAirports
        {
            get { return _alternateAirports ?? (_alternateAirports = new CommonCollection<FlightNumberAirportRelation>()); }
            set
            {
                if (_alternateAirports != value)
                {
                    if (_alternateAirports != null)
                        _alternateAirports.Clear();
                    if (value != null)
                        _alternateAirports = value;
                }
            }
        }
        #endregion

        #region public CommonCollection<FlightNumberCrewRecord> FlightNumberCrewRecords { get; set; }

        private CommonCollection<FlightNumberCrewRecord> _flightNumberCrewRecords;
        /// <summary>
        /// Состав экипажа на рейс
        /// </summary>
        [Child(RelationType.OneToMany, "FlightNumberId", "FlightNumber")]
        public CommonCollection<FlightNumberCrewRecord> FlightNumberCrewRecords
        {
            get { return _flightNumberCrewRecords ?? (_flightNumberCrewRecords = new CommonCollection<FlightNumberCrewRecord>()); }
            set
            {
                if (_flightNumberCrewRecords != value)
                {
                    if (_flightNumberCrewRecords != null)
                        _flightNumberCrewRecords.Clear();
                    if (value != null)
                        _flightNumberCrewRecords = value;
                }
            }
        }
		#endregion

		#region public CommonCollection<FlightNumberPeriod> FlightNumberPeriod { get; set; }

		private CommonCollection<FlightNumberPeriod> _flightNumberPeriod;
	    /// <summary>
	    /// Состав экипажа на рейс
	    /// </summary>
	    [Child(RelationType.OneToMany, "FlightNumberId", "FlightNumber")]
	    public CommonCollection<FlightNumberPeriod> FlightNumberPeriod
		{
		    get { return _flightNumberPeriod ?? (_flightNumberPeriod = new CommonCollection<FlightNumberPeriod>()); }
		    set
		    {
			    if (_flightNumberPeriod != value)
			    {
				    if (_flightNumberPeriod != null)
						_flightNumberPeriod.Clear();
				    if (value != null)
						_flightNumberPeriod = value;
			    }
		    }
	    }
	    #endregion

		/*
         * Дополнительные свойства
         */

		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Highlight Highlight { get; set; }
        #endregion

        #region public MaintenanceDirectiveThreshold Threshold { get; set; }

        private MaintenanceDirectiveThreshold _threshold;
        /// <summary>
        /// Условие выполнения директивы
        /// </summary>
        //[TableColumnAttribute("Threshold")]
        public MaintenanceDirectiveThreshold Threshold
        {
            get { return _threshold; }
            set { _threshold = value; }
        }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Заметки по директиве
        /// </summary>
        [TableColumnAttribute("Remarks")]
        public String Remarks { get; set; }
        #endregion

        #region public String HiddenRemarks { get; set; }
        /// <summary>
        /// Скрытые заметки
        /// </summary>
        [TableColumnAttribute("HiddenRemarks")]
        public String HiddenRemarks { get; set; }
        #endregion

        #region public DirectiveRecord LastPerformance { get; }
        /// <summary>
        /// Последнее выполнение 
        /// </summary>
        public DirectiveRecord LastPerformance { get { return PerformanceRecords.GetLast(); } }
        #endregion

        #region public BaseRecordCollection<DirectiveRecord> PerformanceRecords

        private BaseRecordCollection<DirectiveRecord> _performanceRecords;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 14, "Parent")]
        public BaseRecordCollection<DirectiveRecord> PerformanceRecords
        {
            get { return _performanceRecords ?? (_performanceRecords = new BaseRecordCollection<DirectiveRecord>()); }
            internal set
            {
                if(_performanceRecords != value)
                {
                    if (_performanceRecords != null)
                        _performanceRecords.Clear();
                    if (value != null)
                        _performanceRecords = value;
                }
            }
        }
        #endregion

        #region public DirectiveStatus Status { get; }
        /// <summary>
        /// Статус директивы
        /// </summary>
        [Filter("Status:", Order = 4)]
        public DirectiveStatus Status
        {
            get
            {
                if (IsClosed) return DirectiveStatus.Closed; //директива принудительно закрыта пользователем
                if (LastPerformance == null)
                {
                    if (!_threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero() ||
                       !_threshold.FirstPerformanceSinceNew.IsNullOrZero())
                        return DirectiveStatus.Open;

                    return DirectiveStatus.NotApplicable;
                }

                if (_threshold.RepeatInterval.IsNullOrZero()) return DirectiveStatus.Closed;

                return DirectiveStatus.Repetative;
            }
        }
		#endregion

		#region Implement of IDirective
		//Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
		//у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
		// дату след. выполнения и наработку на которой это выполнение произоидет

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// Возвращает объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region IThreshold IDirective.Threshold { get; set; }
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        IThreshold IDirective.Threshold
        {
            get { return _threshold; }
            set { _threshold = value as MaintenanceDirectiveThreshold; }
        }
        #endregion

        #region IRecordCollection IDirective.PerformanceRecords { get; set; }
        /// <summary>
        /// Коллекция содержит все записи о выполнении директивы
        /// </summary>
        IRecordCollection IDirective.PerformanceRecords
        {
            get { return _performanceRecords; }
        }
        #endregion

        #region AbstractPerformanceRecord IDirective.LastPerformance { get; }
        /// <summary>
        /// Доступ к последней записи о выполнении задачи
        /// </summary>
        AbstractPerformanceRecord IDirective.LastPerformance
        {
            get
            {
                return PerformanceRecords.GetLast();
            }
        }
        #endregion

        #region public List<NextPerformance> NextPerformances { get; set; }

        private List<NextPerformance> _nextPerformances;
		/// <summary>
        /// Список последующих выполнений задачи
        /// </summary>
        public List<NextPerformance> NextPerformances
        {
            get { return _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); }
        }
        #endregion

        #region  public NextPerformance NextPerformance { get; }
        /// <summary>
        /// След. выполнение задачи
        /// </summary>
        public NextPerformance NextPerformance
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0)
                    return null;
                return _nextPerformances[0];
            }
        }
        #endregion

        #region public ConditionState Condition { get; set; }
        /// <summary>
        /// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
        /// </summary>
        [Filter("Condition:", Order = 5)]
        public ConditionState Condition
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return ConditionState.NotEstimated;
                return _nextPerformances[0].Condition;
            }
        }
        #endregion

        #region public Lifelength NextCompliance { get; }

        /// <summary>
        /// Возвращает ресурс ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        public Lifelength NextPerformanceSource
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) 
                    return Lifelength.Null;
                return _nextPerformances[0].PerformanceSource;
            }
        }
        #endregion

        #region public Lifelength Remains { get; set; }
        /// <summary>
        /// Возвращает остаток ресурса до ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        public Lifelength Remains
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
                return _nextPerformances[0].Remains;
            }
        }
        #endregion

        #region public Lifelength BeforeForecastResourceRemain { get; set; }
        /// <summary>
        /// Остаток ресурса до прогноза (вычисляется только в прогнозе)
        /// </summary>
        public Lifelength BeforeForecastResourceRemain
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
                return _nextPerformances[0].BeforeForecastResourceRemain;
            }
        }
        #endregion

        #region public Lifelength ForecastLifelength { get; set; }
        //ресурс прогноза
        public Lifelength ForecastLifelength { get; set; }
        #endregion

        #region public Lifelength AfterForecastResourceRemain { get; set; }
        /// <summary>
        /// Остаток ресурса после прогноза (вычисляется только в прогнозе)
        /// </summary>
        public Lifelength AfterForecastResourceRemain { get; set; }
        #endregion

        #region public DateTime? NextComplianceDate{ get; set; }
        /// <summary>
        /// Возвращает прблизительную дату ближайшего выполнения задачи (если оно расчитано) или null
        /// </summary>
        public DateTime? NextPerformanceDate
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return null;
                return _nextPerformances[0].PerformanceDate;
            }
        }
        #endregion

        #region public double? Percents { get; set; }
        /// <summary>
        /// (AfterForecast / (AfterForecast + beforeForecast)) * 100
        /// </summary>
        public double? Percents { get; set; }
        #endregion

        #region public string TimesToString { get; }
        /// <summary>
        /// Возвращает строковое представление количества "след. выполнений"
        /// </summary>
        public string TimesToString
        {
            get { return Times <= 1 ? "" : Times + " times"; }
        }
        #endregion

        #region public Int32 Times { get;}
        /// <summary>
        /// Сколько раз выполнится директива (применяетмя только в прогнозах)
        /// </summary>
        public Int32 Times
        {
            get { return _nextPerformances.Count > 1 ? _nextPerformances.Count : -1; }
        }
        #endregion

        #region public Boolean IsClosed { get; set; }
        /// <summary>
        /// Логический флаг, показывающий, закрыта ли директива
        /// </summary>
        [TableColumnAttribute("IsClosed")]
        public Boolean IsClosed { get; set; }
        #endregion

        #region public Boolean NextPerformanceIsBlocked { get; }
        /// <summary>
        /// Логический флаг, показывающий, заблокировано ли след. выполенение директивы рабочим пакетом
        /// </summary>
        public Boolean NextPerformanceIsBlocked
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return false;
                return _nextPerformances[0].BlockedByPackage != null;
            }
        }

        #endregion

        #region public void ResetMathData()
        public void ResetMathData()
        {
            AfterForecastResourceRemain = null;
            NextPerformances.Clear();
        }
        #endregion

        #endregion

        #region Implement IPrintSettings

        #region public bool PrintInWorkPackage { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
        /// <br/> Неприминимо к данному классу
        /// </summary>
        public bool PrintInWorkPackage { get; set; }
        #endregion

        #region public bool WorkPackageACCPrintTitle { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать НАЗВАНИЯ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        public bool WorkPackageACCPrintTitle { get; set; }
        #endregion

        #region public bool WorkPackageACCPrintTaskCard { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать РАБОЧЕЙ КАРТЫ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        public bool WorkPackageACCPrintTaskCard { get; set; }
		#endregion

		#endregion

		#region Implement IFlightNumberParams

		public FlightNumber FlightNum { get { return this; } }
		public int PeriodFrom { get; }
		public int PeriodTo { get; }
		public DateTime ArrivalDate { get { return DateTimeExtend.GetCASMinDateTime(); } }
		public DateTime DepartureDate { get { return DateTimeExtend.GetCASMinDateTime(); } }

		public bool IsMonday { get { return FlightNumberPeriod.Any(p => p.IsMonday); } }
		public bool IsThursday { get { return FlightNumberPeriod.Any(p => p.IsThursday); } }
		public bool IsWednesday { get { return FlightNumberPeriod.Any(p => p.IsWednesday); } }
		public bool IsTuesday { get { return FlightNumberPeriod.Any(p => p.IsTuesday); } }
		public bool IsFriday { get { return FlightNumberPeriod.Any(p => p.IsFriday); } }
		public bool IsSaturday { get { return FlightNumberPeriod.Any(p => p.IsSaturday); } }
		public bool IsSunday { get { return FlightNumberPeriod.Any(p => p.IsSunday); } }


		#endregion

		/*
        *  Методы 
        */


		#region public FlightNumber()
		/// <summary>
		/// Создает Описание рейса без дополнительной информации
		/// </summary>
		public FlightNumber()
        {
            SmartCoreObjectType = SmartCoreType.FlightNumber;
            //задаем все ID в -1
            ItemId = -1;

            _performanceRecords = new BaseRecordCollection<DirectiveRecord>();
            _threshold = new MaintenanceDirectiveThreshold();

            PrintInWorkPackage = true;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightNumber));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        #endregion

        #region public int CompareTo(FlightNumber y)

        public int CompareTo(FlightNumber y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is FlightNumber) return ItemId.CompareTo(((FlightNumber)y).ItemId);
            return 0;
        }
        #endregion

        #region public bool Equals(FlightNumber other)
        public bool Equals(FlightNumber other)
        {

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return ItemId == other.ItemId;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
		#endregion


		#region public FlightNumber GetCopyUnsaved()

		public new FlightNumber GetCopyUnsaved()
		{
			var flightNumber = (FlightNumber)MemberwiseClone();
			flightNumber.ItemId = -1;
			flightNumber.UnSetEvents();

			flightNumber._flightNumberPeriod = new CommonCollection<FlightNumberPeriod>();
			foreach (var period in FlightNumberPeriod)
			{
				var newObject = period.GetCopyUnsaved();
				flightNumber._flightNumberPeriod.Add(newObject);
			}

			flightNumber._aircraftModels = new CommonCollection<FlightNumberAircraftModelRelation>();
			foreach (var period in AircraftModels)
			{
				var newObject = period.GetCopyUnsaved();
				flightNumber._aircraftModels.Add(newObject);
			}

			flightNumber._alternateAirports = new CommonCollection<FlightNumberAirportRelation>();
			foreach (var period in AlternateAirports)
			{
				var newObject = period.GetCopyUnsaved();
				flightNumber._alternateAirports.Add(newObject);
			}

			flightNumber._flightNumberCrewRecords = new CommonCollection<FlightNumberCrewRecord>();
			foreach (var period in FlightNumberCrewRecords)
			{
				var newObject = period.GetCopyUnsaved();
				flightNumber._flightNumberCrewRecords.Add(newObject);
			}


			return flightNumber;
		}

		#endregion


	}
}
