using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Calculations;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.SMS;
using SmartCore.Files;

namespace SmartCore.Entities.General.Atlbs
{

	/// <summary>
	/// Класс описывает полет воздушного судна
	/// </summary>
	[Serializable]
	[Table("AircraftFlights", "dbo", "ItemId")]
	[Dto(typeof(AircraftFlightDTO))]
	[Condition("IsDeleted", "0")]
	public class AircraftFlight: AbstractRecord, IFileContainer, IEmployeeFlightFilterParams, IMounthlyUtilizationFilter
	{
		/*
		 * поля 
		 */

		private static Type _thisType;

		/*
		*  Свойства
		*/

		#region public Int32 ATLBId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ATLBId")]
		public Int32 ATLBId { get; set; }

		public static PropertyInfo ATLBIdProperty
		{
			get { return GetCurrentType().GetProperty("ATLBId"); }
		}

		#endregion

		#region public AtlbRecordType AtlbRecordType
		/// <summary>
		/// 
		/// </summary>
		private AtlbRecordType _atlbRecordType;
		[TableColumnAttribute("AtlbRecordType")]
		public AtlbRecordType AtlbRecordType
		{
			get { return _atlbRecordType; }
			set { _atlbRecordType = value; }
		}
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

		#region public String FlightNo { get; set; }

		public string ATLB { get{return ParentATLB?.ATLBNo ?? "";} }
		public string FlightN
		{
			get { return FlightNumber?.FullName ?? ""; }
		}

		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FlightNo")]
		public String FlightNo { get; set; }
		#endregion

		#region public FlightNum FlightNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FlightNumber")]
		public FlightNum FlightNumber
		{
			get { return _flightNumber ?? FlightNum.Unknown; }
			set { _flightNumber = value; }
		}

		public static PropertyInfo FlightNumberProperty
		{
			get { return GetCurrentType().GetProperty("FlightNumber"); }
		}

		#endregion

		#region public DateTime FlightDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		private DateTime _flightDate;
		[TableColumnAttribute("FlightDate")]
		public DateTime FlightDate
		{
			get { return _flightDate; }
			set { _flightDate = value; }
		}

		public static PropertyInfo FlightDateProperty
		{
			get { return GetCurrentType().GetProperty("FlightDate"); }
		}
		#endregion

		#region public FlightType FlightType
		/// <summary>
		/// 
		/// </summary>
		private FlightType _flightType;
		[TableColumnAttribute("FlightType")]
		public FlightType FlightType
		{
			get { return _flightType ?? FlightType.UNK; }
			set { _flightType = value; }
		}
		#endregion

		#region public FlightCategory FlightCategory
		/// <summary>
		/// 
		/// </summary>
		private FlightCategory _flightCategory;
		[TableColumnAttribute("FlightCategory")]
		public FlightCategory FlightCategory
		{
			get { return _flightCategory; }
			set { _flightCategory = value; }
		}
		#endregion

		#region  public CruiseLevel Level { get; set; }
		/// <summary>
		/// Эшелон полета
		/// </summary>
		[TableColumnAttribute("Level")]
		public CruiseLevel Level { get; set; }
		#endregion

		#region public double AlignmentBefore { get; set; }
		/// <summary>
		/// Центровка до  полета
		/// </summary>
		[TableColumnAttribute("AlignmentBefore")]
		public double AlignmentBefore { get; set; }
		#endregion

		#region public Int32 AlignmentAfter { get; set; }
		/// <summary>
		/// Центровка после полета
		/// </summary>
		[TableColumnAttribute("AlignmentAfter")]
		public double AlignmentAfter { get; set; }
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

		#region public double TakeOffWeight { get; set; }
		/// <summary>
		/// Взлетный вес
		/// </summary>
		[TableColumnAttribute("TakeOffWeight")]
		public double TakeOffWeight { get; set; }
		#endregion

		#region public String StationFrom { get; set; }
		/// <summary>
		/// Место вылета
		/// </summary>
		[TableColumnAttribute("StationFrom")]
		public String StationFrom { get; set; }
		#endregion

		#region public String StationTo { get; set; }
		/// <summary>
		/// Место посадки
		/// </summary>
		[TableColumnAttribute("StationTo")]
		public String StationTo { get; set; }
		#endregion

		#region public Airport StationFrom { get; set; }

		private AirportsCodes _stationFromId;

		/// <summary>
		/// Место вылета
		/// </summary>
		[TableColumnAttribute("StationFromId")]
		public AirportsCodes StationFromId
		{
			get { return _stationFromId ?? AirportsCodes.Unknown; }
			set { _stationFromId = value; }
		}

		public static PropertyInfo StationFromIdProperty
		{
			get { return GetCurrentType().GetProperty("StationFromId"); }
		}

		#endregion

		#region public Airport StationTo { get; set; }

		private AirportsCodes _stationToId;

		/// <summary>
		/// Место посадки
		/// </summary>
		[TableColumnAttribute("StationToId")]
		public AirportsCodes StationToId
		{
			get { return _stationToId ?? AirportsCodes.Unknown; }
			set { _stationToId = value; }
		}

		public static PropertyInfo StationToIdProperty
		{
			get { return GetCurrentType().GetProperty("StationToId"); }
		}

		#endregion

		#region public short DelayTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("DelayTime")]
		public short DelayTime { get; set; }
		#endregion

		#region public Int32 DelayReasonId { get; set; }
		/// <summary>
		/// Причина задержки рейса
		/// </summary>
		[TableColumnAttribute("DelayReasonId")]
		public Reason DelayReason { get; set; }
		#endregion

		#region public Reason CancelReasonId { get; set; }
		/// <summary>
		/// Причина отмены рейса
		/// </summary>
		[TableColumnAttribute("CancelReasonId")]
		public Reason CancelReason { get; set; }
		#endregion

		#region public Int32 OutTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("OutTime")]
		public Int32 OutTime { get; set; }
		#endregion

		#region public Int32 InTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("InTime")]
		public Int32 InTime { get; set; }
		#endregion

		#region public Int32 TakeOffTime { get; set; }
		/// <summary>
		/// Время взлета воздушного судна (в абсолютных минутах относительно начала дня)
		/// </summary>
		[TableColumnAttribute("TakeOffTime")]
		public Int32 TakeOffTime { get; set; }
		#endregion

		#region public Int32 LDGTime { get; set; }
		/// <summary>
		/// Время посадки воздушного судна (в абсолютных минутах относительно начала дня)
		/// </summary>
		[TableColumnAttribute("LDGTime")]
		public Int32 LDGTime { get; set; }
		#endregion

		#region public Int32 NightTime { get; set; }
		/// <summary>
		/// Ночное время полета воздушного судна (в абсолютных минутах относительно начала дня)
		/// </summary>
		[TableColumnAttribute("NightTime")]
		public Int32 NightTime { get; set; }
		#endregion

		#region public Int32 CrsId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("CRSId")]
		public Int32 CrsId { get; set; }
		#endregion

		#region public Int32 FileId { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// 
		/// </summary>

		public AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.AircraftFlightAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.AircraftFlightAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 13)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion

		#region public String Tanks{ get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Tanks")]
		public String Tanks//{ get; set; }
		{
			get { return FuelTankCollection.CollectionToString(); }
			set { FuelTankCollection.StringToCollection(value); }
		}
		#endregion

		#region public FuelTankConditionCollection FuelTankCollection { get; set; }

		private FuelTankConditionCollection _fuelTankCollection;
		/// <summary>
		/// Состояние топливных баков
		/// </summary>
		public FuelTankConditionCollection FuelTankCollection
		{
			get { return _fuelTankCollection ?? (_fuelTankCollection = new FuelTankConditionCollection()); }
			set { _fuelTankCollection = value;}
		}
		#endregion

		#region public String Fluids { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Fluids")]
		public String Fluids
		{
			get { return FluidsCondition.ToString(); }
			set { FluidsCondition.ToValues(value); }
		}
		#endregion

		#region public String EnginesGeneralCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("EnginesGeneralCondition")]
		public String EnginesGeneralCondition// { get; set; } 
		{
			get { return EnginesGeneralConditions.ToString() ; }
			set { EnginesGeneralConditions.ToValues(value); }
		}
		#endregion

		#region public CertificateOfReleaseToService CertificateOfReleaseToService
		/// <summary>
		/// Cертификат о допуске к эксплуптации
		/// </summary>
		public CertificateOfReleaseToService CertificateOfReleaseToService
		{
			get
			{
				return GetReleaseToService();
			}
			set
			{
				SetReleaseToService(value);
			}
		}

		#endregion

		#region  public string ListViewChecksPerformed
		/// <summary>
		/// Чеки, которые были выполнены перед полетом
		/// </summary>
		public string ListViewChecksPerformed
		{
			get
			{
				var rts = GetReleaseToService();
				if (rts != null)
				{
					return rts.CheckPerformed;
				}
				return "";
			}

		}
		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion


		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// Подсветка
		/// </summary>
		[TableColumnAttribute("Highlight")]
		public Highlight Highlight { get; set; }

		#endregion

		#region public Boolean Correct { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Correct")]
		public Boolean Correct { get; set; }
		#endregion

		#region public String Reference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Reference")]
		public String Reference { get; set; }
		#endregion

		#region public Int32 AircraftId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("AircraftId")]
		public Int32 AircraftId { get; set; }

		public static PropertyInfo AircraftIdProperty
		{
			get { return GetCurrentType().GetProperty("AircraftId"); }
		}
		
		#endregion

		#region public Int32 Cycles { get; set; }
		[TableColumnAttribute("Cycles")]
		public Int32 Cycles{get ; set ; }

		#endregion

		#region public String PageNo { get; set; }

		[TableColumnAttribute("PageNo")]
		public String PageNo { get; set; }

		#endregion

		
		public Aircraft Aircraft { get; set; }

		public AircraftModel AircraftModel { get {return Aircraft?.Model ?? AircraftModel.Unknown; } }

		public Specialization Specialization
		{
			get
			{
				return FlightCrewRecords.First()?.Specialization ?? Specialization.Unknown;
			}
		}

		/*
				 * Вложенные коллекции
				 */

		#region public CommonCollection<ComponentOilCondition> OilConditionCollection { get; set; }

		private CommonCollection<ComponentOilCondition> _oilConditionCollection;
		/// <summary>
		/// Уровни масла по агрегатам
		/// </summary>
		public CommonCollection<ComponentOilCondition> OilConditionCollection
		{
			get { return _oilConditionCollection ?? (_oilConditionCollection = new CommonCollection<ComponentOilCondition>());}
			set
			{
				if (_oilConditionCollection != value)
				{
					if (_oilConditionCollection != null)
						_oilConditionCollection.Clear();
					if (value != null)
						_oilConditionCollection = value;
				}
			}
		}
		#endregion

		#region public CommonCollection<EngineAccelerationTime> EngineAccelerationTimeCollection { get; set; }

		private CommonCollection<EngineAccelerationTime> _engineAccelerationTimeCollection;
		/// <summary>
		/// Коллекция записей о приёмистости двигателей
		/// </summary>
		public CommonCollection<EngineAccelerationTime> EngineAccelerationTimeCollection
		{
			get { return _engineAccelerationTimeCollection ?? (_engineAccelerationTimeCollection = new CommonCollection<EngineAccelerationTime>()); }
			set
			{
				if (_engineAccelerationTimeCollection != value)
				{
					if (_engineAccelerationTimeCollection != null)
						_engineAccelerationTimeCollection.Clear();
					if (value != null)
						_engineAccelerationTimeCollection = value;
				}
			}
		}
		#endregion

		#region public BaseRecordCollection<EngineCondition> EngineConditionCollection { get; set; }

		private BaseRecordCollection<EngineCondition> _engineConditions;
		/// <summary>
		/// Записи о состоянии силовых установок (Двигатели, ВСУ)
		/// </summary>
		public BaseRecordCollection<EngineCondition> EngineConditionCollection
		{
			get { return _engineConditions ?? (_engineConditions = new BaseRecordCollection<EngineCondition>()); }
			set
			{
				if (_engineConditions != value)
				{
					if (_engineConditions != null)
						_engineConditions.Clear();
					if (value != null)
						_engineConditions = value;
				}
			}
		}
		#endregion

		#region public CommonCollection<HydraulicCondition> HydraulicConditionCollection { get; set; }

		private CommonCollection<HydraulicCondition> _hydraulicConditionCollection;
		/// <summary>
		/// Уровни гидравлики по агрегатам
		/// </summary>
		public CommonCollection<HydraulicCondition> HydraulicConditionCollection
		{
			get { return _hydraulicConditionCollection ?? (_hydraulicConditionCollection = new CommonCollection<HydraulicCondition>());}
			set
			{
				if (_hydraulicConditionCollection != value)
				{
					if (_hydraulicConditionCollection != null)
						_hydraulicConditionCollection.Clear();
					if (value != null)
						_hydraulicConditionCollection = value;
				}
			}
		}
		#endregion

		#region public CommonCollection<EngineTimeInRegime> PowerUnitTimeInRegimeCollection { get; set; }

		private CommonCollection<EngineTimeInRegime> _powerUnitTimeInRegineCollection;
		/// <summary>
		/// Коллекция записей о работе силовых установок в различных режимах
		/// </summary>
		public CommonCollection<EngineTimeInRegime> PowerUnitTimeInRegimeCollection
		{
			get { return _powerUnitTimeInRegineCollection ?? (_powerUnitTimeInRegineCollection = new CommonCollection<EngineTimeInRegime>());}
			set
			{
				if (_powerUnitTimeInRegineCollection != value)
				{
					if (_powerUnitTimeInRegineCollection != null)
						_powerUnitTimeInRegineCollection.Clear();
					if (value != null)
						_powerUnitTimeInRegineCollection = value;
				}
			}
		}
		#endregion

		#region public BaseRecordCollection<LandingGearCondition> LandingGearConditions { get; set; }

		private BaseRecordCollection<LandingGearCondition> _landingGearConditions;
		/// <summary>
		/// Коллекция записей о состоянии шасси
		/// </summary>
		public BaseRecordCollection<LandingGearCondition> LandingGearConditions
		{
			get 
			{
				return _landingGearConditions ?? (_landingGearConditions = new BaseRecordCollection<LandingGearCondition>());
			}
			set
			{
				if (_landingGearConditions != value)
				{
					if (_landingGearConditions != null)
						_landingGearConditions.Clear();
					if (value != null)
						_landingGearConditions = value;
				}
			}
		}
		#endregion

		#region public RunupsCollection RunupsCollection { get; set; }

		private RunupsCollection _runupsCollection;
		/// <summary>
		/// Коллекция записей о пусках силовых установок
		/// </summary>
		public RunupsCollection RunupsCollection
		{
			get { return _runupsCollection ?? (_runupsCollection = new RunupsCollection()); }
			set
			{
				if (_runupsCollection != value)
				{
					if (_runupsCollection != null)
						_runupsCollection.Clear();
					if (value != null)
						_runupsCollection = value;
				}
			}
		}
		#endregion

		#region public BaseRecordCollection<Event> Events  { get; set; }

		private BaseRecordCollection<Event> _events = new BaseRecordCollection<Event>();

		public BaseRecordCollection<Event> Events
		{
			get { return _events ?? (_events = new BaseRecordCollection<Event>()); }
			set { _events = value; }
		}

		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// Унаследовано от AbstractRecord. Используется для хранения заметок
		/// </summary>
		[TableColumnAttribute("Remarks")]
		public override String Remarks { get; set; }
		#endregion

		#region public override DateTime RecordDate
		/// <summary>
		/// Уналедовано от AbstractRecord. Используется для сортировки по дате
		/// </summary>
		public override DateTime RecordDate
		{
			get{ return  _flightDate; }
			set{ _flightDate = value; }
		}
		#endregion

		#region public override Lifelength OnLifelength { get; set; }
		/// <summary>
		/// Унаследовано от AbstractRecord. Неиспользуется
		/// </summary>
		public override Lifelength OnLifelength { get; set; }
		#endregion

		/*
		 * Дополнительные свойства (вычисляемые)
		 */

		#region public TimeSpan BlockTime
		/// <summary>
		/// Время полета ВС по Out-In
		/// </summary>
		public TimeSpan BlockTime
		{
			get
			{
				int blockTime = InTime - OutTime;
				if (blockTime < 0) blockTime += 24 * 60;
				return new TimeSpan(blockTime / 60, blockTime - (blockTime / 60) * 60, 0);
			}
		}

		#endregion

		#region public TimeSpan FlightTime
		/// <summary>
		/// Время полета ВС по Takeoff-LDG
		/// </summary>
		public TimeSpan FlightTime
		{
			get
			{
				int flightTime = LDGTime - TakeOffTime;
				if (flightTime < 0) flightTime += 24 * 60;

				TimeSpan time = new TimeSpan(flightTime / 60, flightTime - (flightTime / 60) * 60, 0);

				return time;
			}
		}
		#endregion

		#region public TimeSpan TimespanLDGTime
		/// <summary>
		/// Время посадки воздушного судна
		/// </summary>
		public TimeSpan TimespanLDGTime
		{
			get
			{
				TimeSpan time = new TimeSpan(LDGTime / 60, LDGTime - (LDGTime / 60) * 60, 0);
				return time;
			}
		}
		#endregion

		#region public TimeSpan TimespanTakeOffTime
		/// <summary>
		/// Время посадки воздушного судна
		/// </summary>
		public TimeSpan TimespanTakeOffTime
		{
			get
			{
				TimeSpan time = new TimeSpan(TakeOffTime / 60, TakeOffTime - (TakeOffTime / 60) * 60, 0);
				return time;
			}
		}
		#endregion

		#region public TimeSpan TimespanInTime
		/// <summary>
		/// Время посадки воздушного судна
		/// </summary>
		public TimeSpan TimespanInTime
		{
			get
			{
				TimeSpan time = new TimeSpan(InTime / 60, InTime - (InTime / 60) * 60, 0);
				return time;
			}
		}
		#endregion

		#region public TimeSpan TimespanOutTime
		/// <summary>
		/// Время посадки воздушного судна
		/// </summary>
		public TimeSpan TimespanOutTime
		{
			get
			{
				TimeSpan time = new TimeSpan(OutTime / 60, OutTime - (OutTime / 60) * 60, 0);
				return time;
			}
		}
		#endregion

		#region public ATLB ParentATLB { get; internal set; }

		private ATLB _parentATLB;
		/// <summary>
		/// Обратная ссылка борт журнал (родительский ATLB)
		/// </summary>
		public ATLB ParentATLB
		{
			get { return _parentATLB; }
			set { _parentATLB = value; }
		}
		#endregion

		private BaseRecordCollection<CertificateOfReleaseToService> _releaseToServiceCollection;

		private CertificateOfReleaseToService _certificateOfReleaseToService;

		public EnginesGeneralCondition EnginesGeneralConditions = new EnginesGeneralCondition();

		public FluidsCondition FluidsCondition = new FluidsCondition();

		public List<Discrepancy> Discrepancies = new List<Discrepancy>();
		private FlightNum _flightNumber;

		/// <summary>
		/// Коллекция незакрытых отклонений (созданных раньше этого полета)
		/// </summary>
		public CommonCollection<Discrepancy> UnclosedDiscrepancies { get; set; }

		/*
		*  Методы 
		*/
		
		#region public AircraftFlight()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public AircraftFlight()
		{
			_atlbRecordType = AtlbRecordType.Flight;
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.AircraftFlight;

			FlightDate= DateTime.Today;
			Cycles = 1;
			FlightCrewRecords = new List<FlightCrewRecord>();
			FlightPassengerRecords = new List<FlightPassengerRecord>();
			FlightCargoRecords = new List<FlightCargoRecord>();

			Highlight = Highlight.White;
			/*       FuelTankCondition newTank = new FuelTankCondition();
			newTank.OnBoard = 480.00;
			newTank.Remaining = 450.50;
			newTank.Correction = 330.30;
			FuelTankCollection.Add(newTank);

			FuelTankCondition newTank1 = new FuelTankCondition();
			newTank1.OnBoard = 780.00;
			newTank1.Remaining = 750.50;
			newTank1.Correction = 630.30;

			FuelTankCollection.Add(newTank1);*/
		}
		#endregion

		#region public override string ToString()

		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FlightNumber + " " + StationFromId.ShortName + " - " + StationToId.ShortName;
		}
		#endregion   

		#region private CertificateOfReleaseToService GetReleaseToService()
		/// <summary>
		/// Возвращает CorrectiveAction в зависимоти от условия существоваяния в базе данных
		/// </summary>
		/// <returns></returns>
		private CertificateOfReleaseToService GetReleaseToService()
		{
			if (_releaseToServiceCollection == null)
				_releaseToServiceCollection = new BaseRecordCollection<CertificateOfReleaseToService>();
			if (_certificateOfReleaseToService == null)
			{
				if (_releaseToServiceCollection.Count == 0)
				{
					_certificateOfReleaseToService = new CertificateOfReleaseToService {RecordDate = DateTimeExtend.GetCASMinDateTime() };
					_releaseToServiceCollection.Add(_certificateOfReleaseToService);
				}
				else
				{
					_certificateOfReleaseToService = _releaseToServiceCollection[0];
				}
			}
			return _certificateOfReleaseToService;
		} 
		#endregion

		#region private void SetReleaseToService(CertificateOfReleaseToService releaseToService)
		/// <summary>
		/// Записывает ReleaseToService в CorrectiveAction в завсимоти от существования данного(this) обекта в базе данных
		/// </summary>
		/// <param name="releaseToService"></param>
		private void SetReleaseToService(CertificateOfReleaseToService releaseToService)
		{
			if (_releaseToServiceCollection == null)
				_releaseToServiceCollection = new BaseRecordCollection<CertificateOfReleaseToService>();
			if (releaseToService != null)
			{
				if (_certificateOfReleaseToService != null || _releaseToServiceCollection.Count > 0)
				{
					_releaseToServiceCollection.Clear();
					_releaseToServiceCollection.Add(releaseToService);
				}
				else
					_releaseToServiceCollection.Add(releaseToService);
			}
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(AircraftFlight));
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var aircraftFlight = (AircraftFlight)MemberwiseClone();
			aircraftFlight.ItemId = -1;
			if (marked)
			{
				aircraftFlight.PageNo += " Copy";
				aircraftFlight.FlightNo += " Copy";
			}

			aircraftFlight.UnSetEvents();

			return aircraftFlight;
		}

		#endregion

		/*
		 * Математический аппарат
		 */


		#region public Int32 BlockTimeTotalMinutes { get; }
		/// <summary>
		/// Возвращает время полета ВС по BlockTime(Out-In)
		/// </summary>

		public Int32 BlockTimeTotalMinutes
		{
			get
			{
				Int32 blockTime = InTime - OutTime;
				if (blockTime < 0) blockTime += 24 * 60;
				return blockTime;
			}
		}

		#endregion

		#region public Lifelength BlockTimeLifelenght { get; }
		/// <summary> 
		/// Возвращает наработку на основе BlockTime(In - Out) за заданный полет
		/// </summary>
		public Lifelength BlockTimeLifelenght
		{
			get { return new Lifelength(null, Cycles, BlockTimeTotalMinutes); }
		}
		#endregion

		#region public Int32 FlightTimeTotalMinutes { get; }
		/// <summary>
		/// Возвращает время полета воздушного судна
		/// </summary>
		public Int32 FlightTimeTotalMinutes
		{
			get 
			{
				Int32 x = LDGTime - TakeOffTime;
				if (x < 0) x += 24 * 60;
				return x;
			}
		}
		#endregion

		#region public Lifelength FlightTimeLifelength { get; }
		/// <summary> 
		/// Возвращает наработку на основе FlightTime(Ldg - TakeOff) за заданный полет
		/// </summary>
		public Lifelength FlightTimeLifelength
		{
			get { return new Lifelength(null, Cycles, FlightTimeTotalMinutes); }
		}
		#endregion

		#region public int CompareTo(object y) 

		public override int CompareTo(object y)
		{
			if (y is AircraftFlight && FlightDate.CompareTo(((AircraftFlight)y).FlightDate) == 0)
				return OutTime.CompareTo(((AircraftFlight)y).OutTime);

			return TakeOffTime.CompareTo(((AircraftFlight)y).TakeOffTime);
		}

		#endregion

		#region public List<FlightCrewRecord> FlightCrewRecords { get; set; }

		public List<FlightCrewRecord> FlightCrewRecords { get; set; }

		#endregion

		#region public List<FlightPassengerRecord> FlightPassengerRecords { get; set; }

		public List<FlightPassengerRecord> FlightPassengerRecords { get; set; }

		#endregion

		#region public List<FlightCargoRecord> FlightCargoRecords { get; set; }

		public List<FlightCargoRecord> FlightCargoRecords { get; set; }

		#endregion

		#region public List<Specialist> Specialist

		public List<Specialist> Specialist
		{
			get
			{
				return FlightCrewRecords.Select(record => record.Specialist).ToList();
			}
		}
		
		#endregion

		#region public Specialist GetSpecialist(SpecializationCollection specialization_Name)
		///// <summary>
		///// Возвращает одного специалиста из коллекции по названию специальности
		///// </summary>
		///// <param name="specialization_Name"></param>
		///// <returns></returns>
		/*     public Specialist GetSpecialist(SpecializationCollection specialization_Name)
		   {
			   foreach (Specialist item in Specialist)
			   {
				   if (item. == SpecializationID)
					   return item;
			   }

			   return null;  
		   }*/

		#endregion

		#region public Specialist GetSpecialistBySpecializationId(int specializationId)
		/// <summary>
		/// Возвращает одного специалиста из коллекции
		/// </summary>
		/// <param name="specializationId"></param>
		/// <returns></returns>
		public Specialist GetSpecialistBySpecializationId(int specializationId)
		{
			foreach (FlightCrewRecord item in FlightCrewRecords)
			{
			   if (item.Specialization.ItemId == specializationId)
					return item.Specialist;
			}
			
			return null;
		}

		#endregion

	}
}
