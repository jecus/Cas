using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MTOP;
using SmartCore.Files;
using SmartCore.Relation;

namespace SmartCore.Entities.General.MaintenanceWorkscope
{

	/// <summary>
	/// Класс описывает директиву
	/// </summary>
	[Table("MaintenanceDirectives", "dbo", "ItemId")]
	[Dto(typeof(MaintenanceDirectiveDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class MaintenanceDirective : BaseEntityObject, IEngineeringDirective, IKitRequired,
		IComparable<MaintenanceDirective>, IEquatable<MaintenanceDirective>, IFileContainer, IBindedItem, IWorkPackageItemFilterParams, IMTOPFilterParams, IMtopCalc
	{
		private static Type _thisType;
		/*
		*  Свойства
		*/

		#region public String TaskNumberCheck { get; set; }

		/// <summary>
		/// Номер чека задачи
		/// </summary>
		[TableColumnAttribute("TaskNumberCheck"), ListViewData("MPD Item")]
		[Filter("MPD Item:", Order = 1)]
		public String TaskNumberCheck { get; set; }

		#endregion

		#region public MaintenanceDirectiveTaskType WorkType { get; set; }

		/// <summary>
		/// Тип директивы
		/// </summary>
		[TableColumnAttribute("DirectiveTypeId"), ListViewData("Directive Type")]
		[Filter("Work Type:", Order = 16)]
		public MaintenanceDirectiveTaskType WorkType { get; set; }

		#endregion

		#region public String MPDTaskNumber { get; set; }

		/// <summary>
		/// Номер задачи MPD
		/// </summary>
		[TableColumnAttribute("MPDTaskNumber"), ListViewData("MPD Number")]
		public String MPDTaskNumber { get; set; }

		#endregion

		#region public String MPDNumber { get; set; }

		/// <summary>
		/// Номер MPD
		/// </summary>
		[TableColumnAttribute("MPDNumber"), ListViewData("MPD №")]
		public String MPDNumber { get; set; }

		#endregion

		#region public String MaintenanceManual { get; set; }

		/// <summary>
		/// Руководство к обслуживанию
		/// </summary>
		[TableColumnAttribute("MaintenanceManual", 512), ListViewData("Maint. Manual")]
		public String MaintenanceManual { get; set; }

		#endregion

		#region public AttachedFile MaintenanceManualFile { get; set; }
		[NonSerialized]
		private AttachedFile _maintenanceManualFile;
		/// <summary>
		/// Файл карты задачи
		/// </summary>
		public AttachedFile MaintenanceManualFile
		{
			get
			{
				return _maintenanceManualFile ?? (_maintenanceManualFile = Files.GetFileByFileLinkType(FileLinkType.MaintenanceManualFile));
			}
			set
			{
				_maintenanceManualFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MaintenanceManualFile);
			}
		}

		#endregion

		#region public String Zone { get; set; }

		/// <summary>
		/// Зона
		/// </summary>
		[TableColumnAttribute("Zone"), ListViewData("Zone")]
		[Filter("Zone:", Order = 4)]
		public String Zone { get; set; }

		#endregion

		#region public String Access { get; set; }

		/// <summary>
		/// Доступ
		/// </summary>
		[TableColumnAttribute("Access"), ListViewData("Access")]
		[Filter("Access:", Order = 5)]
		public String Access { get; set; }

		#endregion

		#region public String Applicability { get; set; }

		/// <summary>
		/// Применимость
		/// </summary>
		[TableColumnAttribute("Applicability"), ListViewData("Applicability")]
		public String Applicability { get; set; }

		#endregion

		#region public bool IsApplicability { get; set; }

		[TableColumn("IsApplicability")]
		[Filter("IsApplicability:", Order = 11)]
		public bool IsApplicability { get; set; }

		#endregion

		#region public bool IsOperatorTask { get; set; }

		[TableColumn("IsOperatorTask")]
		[Filter("IsOperatorTask:", Order = 10)]
		public bool IsOperatorTask { get; set; }

		#endregion

		#region public AtaChapter ATAChapter { get; set; }

		/// <summary>
		/// ATA глава, к которой директива относится
		/// </summary>
		[TableColumnAttribute("ATAChapter"), ListViewData("ATA №")]
		[Filter("ATA Chapter:", Order = 14)]
		public AtaChapter ATAChapter { get; set; }

		#endregion

		public Aircraft ParentAircraft { get; set; }

		#region public BaseComponent ParentBaseComponent { get; set; }

		[NonSerialized]
		private BaseComponent _parentBaseComponent;

		/// <summary>
		/// Обратная ссылка на базовый агрегат
		/// </summary>
		[TableColumnAttribute("ComponentId")]
		public BaseComponent ParentBaseComponent
		{
			get { return _parentBaseComponent; }
			set { _parentBaseComponent = value; }
		}

		public static PropertyInfo ParentBaseComponentProperty
		{
			get { return GetCurrentType().GetProperty("ParentBaseComponent"); }
		}

		#endregion

		#region public int ForComponentId { get; set; }

		/// <summary>
		/// Ид агрегата, для которого предназначена директива
		/// <br/>(Обычно является одним из агрегатов родительского базового агрегата) 
		/// </summary>
		[TableColumnAttribute("ForComponentId")]
		public int ForComponentId { get; set; }

		public static PropertyInfo ForComponentIdProperty
		{
			get { return GetCurrentType().GetProperty("ForComponentId"); }
		}

		#endregion

		#region public String Description { get; set; }

		/// <summary>
		/// Описание директивы
		/// </summary>
		[TableColumnAttribute("Description", 3072), ListViewData("Description")]
		[Filter("Description:", Order = 9)]
		public String Description { get; set; }

		#endregion

		#region public bool KitsApplicable { get; set; }

		[TableColumnAttribute("KitsApplicable")]
		public bool KitsApplicable { get; set; }

		#endregion

		#region public bool APUCalc { get; set; }

		[TableColumn("APUCalc")]
		[Filter("APUCalc:", Order = 13)]
		public bool APUCalc { get; set; }

		#endregion

		#region public String EngineeringOrders { get; set; }

		/// <summary>
		/// Параметр Engineering orders
		/// </summary>
		[TableColumnAttribute("EngineeringOrders"), ListViewData("Engineering Orders")]
		public String EngineeringOrders { get; set; }

		#endregion

		#region  public AttachedFile EngineeringOrderFile { get; set; }
		[NonSerialized]
		private AttachedFile _engineeringOrderFile;
		/// <summary>
		/// Связь с файлом описания инженерного ордера
		/// </summary>
		public AttachedFile EngineeringOrderFile
		{
			get
			{
				return _engineeringOrderFile ?? (Files.GetFileByFileLinkType(FileLinkType.EOFile));
			}
			set
			{
				_engineeringOrderFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.EOFile);
			}
		}

		#endregion

		#region public String ServiceBulletinNo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ServiceBulletinNo"), ListViewData("SB №")]
		public String ServiceBulletinNo { get; set; }

		#endregion

		#region  public AttachedFile ServiceBulletinFile { get; set; }
		[NonSerialized]
		private AttachedFile _serviceBulletinFile;
		/// <summary>
		/// Связь с файлом описания сервисного бюллетеня
		/// </summary>
		public AttachedFile ServiceBulletinFile
		{
			get
			{
				return _serviceBulletinFile ?? (Files.GetFileByFileLinkType(FileLinkType.SBFile));
			}
			set
			{
				_serviceBulletinFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.SBFile);
			}
		}

		#endregion

		#region  public AttachedFile TaskNumberCheckFile { get; set; }
		[NonSerialized]
		private AttachedFile _taskNumberCheckFile;
		/// <summary>
		/// Связь с файлом описания директивы летной годности
		/// </summary>
		public AttachedFile TaskNumberCheckFile
		{
			get
			{
				return _taskNumberCheckFile ?? (Files.GetFileByFileLinkType(FileLinkType.MaintenanceTaskNumberCheckFile));
			}
			set
			{
				_taskNumberCheckFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MaintenanceTaskNumberCheckFile);
			}
		}

		#endregion

		#region public String MRB { get; set; }

		/// <summary>
		/// Maintenance Review Board
		/// </summary>
		[TableColumnAttribute("MRB"), ListViewData("MRB")]
		public String MRB { get; set; }

		#endregion

		#region public AttachedFile MRBFile { get; set; }
		[NonSerialized]
		private AttachedFile _mrbFile;
		/// <summary>
		/// Связь с файлом описания директивы летной годности
		/// </summary>
		public AttachedFile MRBFile
		{
			get
			{
				return _mrbFile ?? (Files.GetFileByFileLinkType(FileLinkType.MaintenanceMRBFile));
			}
			set
			{
				_mrbFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MaintenanceMRBFile);
			}
		}

		#endregion

		#region public String TaskCardNumber { get; set; }

		/// <summary>
		/// Номер карты задачи
		/// </summary>
		[TableColumnAttribute("TaskCardNumber"), ListViewData("Task Card №")]
		[Filter("Task Card №:", Order = 3)]
		public String TaskCardNumber { get; set; }

		#endregion

		#region public AttachedFile TaskCardNumberFile { get; set; }
		[NonSerialized]
		private AttachedFile _taskCardNumberFile;
		/// <summary>
		/// Файл карты задачи
		/// </summary>
		public AttachedFile TaskCardNumberFile
		{
			get
			{
				return _taskCardNumberFile ?? (Files.GetFileByFileLinkType(FileLinkType.MaintenanceTaskCardNumberFile));
			}
			set
			{
				_taskCardNumberFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MaintenanceTaskCardNumberFile);
			}
		}

		#endregion

		#region public MaintenanceDirectiveProgramType Program { get; set; }
		private MaintenanceDirectiveProgramType _program;
		/// <summary>
		/// Программа (CPCP, Structure, System), к которой директива относится
		/// </summary>
		[TableColumnAttribute("Program"), ListViewData("Program")]
		[Filter("Program:", Order = 15)]
		public MaintenanceDirectiveProgramType Program
		{
			get { return _program ?? MaintenanceDirectiveProgramType.Unknown; }
			set { _program = value; }
		}

		public static PropertyInfo ProgramProperty
		{
			get { return GetCurrentType().GetProperty("Program"); }
		}

		#endregion

		#region public MaintenanceDirectiveProgramIndicator ProgramIndicator

		private MaintenanceDirectiveProgramIndicator _programIndicator;

		[TableColumn("ProgramIndicator")]
		[Filter("Program Indicator:")]
		public MaintenanceDirectiveProgramIndicator ProgramIndicator
		{
			get { return _programIndicator ?? MaintenanceDirectiveProgramIndicator.Unknown; }
			set { _programIndicator = value; }
		}

			#endregion

		#region public CriticalSystemList CriticalSystem { get; set; }

		/// <summary>
		/// Критическая система, к которой может относится директива
		/// </summary>
		[TableColumnAttribute("CriticalSystem"), ListViewData("Critical System")]
		public CriticalSystemList CriticalSystem
		{
			get { return _criticalSystem ?? CriticalSystemList.Unknown; }
			set { _criticalSystem = value; }
		}

		#endregion

		#region public MaintenanceCheck MaintenanceCheck { get; set; }
		[NonSerialized]
		private MaintenanceCheck _maintenanceCheck;
		/// <summary>
		/// Чек программы обслуживания, к которому может относится директива
		/// </summary>
		[TableColumnAttribute("MaintenanceCheck"), ListViewData("Maintenance Check")]
		[Child(false)]
		[Filter("Check:")]
		public MaintenanceCheck MaintenanceCheck
		{
			get { return _maintenanceCheck; }
			set { _maintenanceCheck = value; }
		}

		public static PropertyInfo MaintenanceCheckProperty
		{
			get { return GetCurrentType().GetProperty("MaintenanceCheck"); }
		}

		#endregion

		#region public JobCard JobCard { get; set; }

		private JobCard _jobCard;

		/// <summary>
		/// Рабочая карта данной директивы
		/// </summary>
		[TableColumnAttribute("JobCard"), ListViewData("Job Card")]
		[Child(false)]
		//[Filter("Check:", Order = 13)]
		public JobCard JobCard
		{
			get { return _jobCard; }
			set
			{
				_jobCard = value;
				if (_jobCard != null)
				{
					_jobCard.Parent = this;
				}
			}
		}

		public static PropertyInfo JobCardProperty
		{
			get { return GetCurrentType().GetProperty("JobCard"); }
		}

		#endregion

		#region public string MpdRef { get; set; }

		[TableColumn("MpdRef")]
		public string MpdRef { get; set; }

		#endregion

		#region public string MpdRevisionNum { get; set; }

		[TableColumn("MpdRevisionNum")]
		public string MpdRevisionNum { get; set; }

		#endregion

		#region public string ScheduleRef { get; set; }

		[TableColumn("ScheduleRef")]
		public string ScheduleRef { get; set; }

		#endregion

		#region public string ScheduleRevisionNum { get; set; }

		[TableColumn("ScheduleRevisionNum")]
		public string ScheduleRevisionNum { get; set; }

		#endregion

		#region public string ScheduleItem { get; set; }

		[TableColumn("ScheduleItem")]
		[Filter("AMP:", Order = 2)]
		public string ScheduleItem { get; set; }

			#endregion

		#region public string MpdOldTaskCard { get; set; }

		[TableColumn("MpdOldTaskCard")]
		public string MpdOldTaskCard { get; set; }

		#endregion

		#region public string Workarea { get; set; }

		[Filter("Work Area:", Order = 8)]
		[TableColumn("Workarea")]
		public string Workarea { get; set; }

		#endregion

		#region public int Category { get; set; }

		[TableColumn("Category")]
		[Filter("Category:", Order = 20)]
		public MpdCategory Category
		{
			get { return _category ?? MpdCategory.UNK; }
			set { _category = value; }
		}

		#endregion

		#region public DateTime MpdRevisionDate { get; set; }

		[TableColumn("MpdRevisionDate")]
		public DateTime MpdRevisionDate
		{
			get { return _mpdRevisionDate; }
			set
			{
				DateTime min = DateTimeExtend.GetCASMinDateTime();
				if (_mpdRevisionDate < min || _mpdRevisionDate != value)
				{
					_mpdRevisionDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		#endregion

		#region public DateTime ScheduleRevisionDate { get; set; }

		private DateTime _scheduleRevisionDate;

		[TableColumn("ScheduleRevisionDate")]
		public DateTime ScheduleRevisionDate
		{
			get { return _scheduleRevisionDate; }
			set
			{
				DateTime min = DateTimeExtend.GetCASMinDateTime();
				if (_scheduleRevisionDate < min || _scheduleRevisionDate != value)
				{
					_scheduleRevisionDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 14)]
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

		/*
		 * Дополнительные свойства
		 */
		#region public Highlight Highlight { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Highlight Highlight { get; set; }

		#endregion

		#region public NDTType NDTType { get; set; }

		/// <summary>
		/// Тип производимого Non-Destructive-Test
		/// </summary>
		[TableColumnAttribute("NDTType"), ListViewData("NDT")]
		[Filter("NDT:")]
		public NDTType NDTType { get; set; }

		#endregion

		#region public Skill Skill { get; set; }

		[TableColumn("Skill")]
		[Filter("Skill:", Order = 18)]
		public Skill Skill
		{
			get { return _skill ?? Skill.UNK; }
			set { _skill = value; }
		}

		#endregion

		#region public MaintenanceDirectiveThreshold Threshold { get; set; }

		private MaintenanceDirectiveThreshold _threshold;

		/// <summary>
		/// Условие выполнения директивы
		/// </summary>
		[TableColumnAttribute("Threshold"), ListViewData("Threshold")]
		public MaintenanceDirectiveThreshold Threshold
		{
			get { return _threshold; }
			set { _threshold = value; }
		}

		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get; }

		/// <summary>
		/// Условие первого выполнения с момента производства детали/ВС
		/// </summary>
		[Filter("1st. Perf:")]
		public Lifelength FirstPerformanceSinceNew
		{
			get { return _threshold != null ? _threshold.FirstPerformanceSinceNew : Lifelength.Null; }
		}

		#endregion

		#region public Lifelength RepeatInterval{ get; }

		/// <summary>
		/// Интервал выполнения директивы
		/// </summary>
		[Filter("Rpt. Int:")]
		public Lifelength RepeatInterval
		{
			get { return _threshold != null ? _threshold.RepeatInterval : Lifelength.Null; }
		}

		#endregion

		#region public String Remarks { get; set; }

		/// <summary>
		/// Заметки по директиве
		/// </summary>
		[TableColumnAttribute("Remarks", 512), ListViewData("Remarks")]
		[Filter("Remarks:", Order = 6)]
		public String Remarks { get; set; }

		#endregion

		#region public String HiddenRemarks { get; set; }

		/// <summary>
		/// Скрытые заметки
		/// </summary>
		[TableColumnAttribute("HiddenRemarks", 512), ListViewData("HiddenRemarks")]
		[Filter("Hidden Remarks:", Order = 7)]
		public String HiddenRemarks { get; set; }

		#endregion

		#region public DirectiveRecord LastPerformance { get; }

		/// <summary>
		/// Последнее выполнение 
		/// </summary>
		public DirectiveRecord LastPerformance
		{
			get { return PerformanceRecords.GetLast(); }
		}

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
				if (_performanceRecords != value)
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
		[Filter("Status:", Order = 17)]
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

		#region Implement of IEngineeringDirective

		//Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
		//у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
		// дату след. выполнения и наработку на которой это выполнение произоидет

		#region String Title { get; }

		/// <summary>
		/// Название директивы
		/// </summary>
		public String Title
		{
			get { return TaskNumberCheck; }
		}

		#endregion

		#region public StaticDictionary WorkType { get; }

		/// <summary>
		/// Тип/Вид Работ
		/// </summary>
		StaticDictionary IEngineeringDirective.WorkType
		{
			get { return WorkType; }
		}

		#endregion

		#region public String Phase { get; }

		/// <summary>
		/// Фаза
		/// </summary>
		public String Phase { get; set; }

		#endregion

		#region public CommonCollection<CategoryRecord> CategoriesRecords

		private CommonCollection<CategoryRecord> _aircraftWorkerCategories;

		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 14, "Parent")]
		public CommonCollection<CategoryRecord> CategoriesRecords
		{
			get
			{
				return _aircraftWorkerCategories ?? (_aircraftWorkerCategories = new CommonCollection<CategoryRecord>());
			}
			internal set
			{
				if (_aircraftWorkerCategories != value)
				{
					if (_aircraftWorkerCategories != null)
						_aircraftWorkerCategories.Clear();
					if (value != null)
						_aircraftWorkerCategories = value;
				}
			}
		}

		#endregion

		#region BaseEntityObject LifeLengthParent { get; }

		/// <summary>
		/// Возвращает объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
		{
			get { return ParentBaseComponent; }
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
			get { return PerformanceRecords.GetLast(); }
		}

		#endregion

		#region public List<NextPerformance> NextPerformances { get; set; }
		[NonSerialized]
		private List<NextPerformance> _nextPerformances;

		/// <summary>
		/// Список последующих выполнений задачи
		/// </summary>
		public List<NextPerformance> NextPerformances
		{
			get { return _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); }
		}

		#endregion


		#region public NextPerformance NextPerformance { get; }

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
		[Filter("Condition:", Order = 19)]
		public ConditionState Condition
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return ConditionState.NotEstimated;
				return _nextPerformances[0].Condition;
			}
		}

		#endregion

		#region public Lifelength NextPerformanceSource { get; }

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
		/// Сколько раз выполнится директива (применяется только в прогнозах)
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

		#region public Double ManHours { get; set; }

		/// <summary>
		/// Параметр чистых трудозатрат
		/// </summary>
		[TableColumnAttribute("ManHours"), ListViewData("Man Hours"), MinMaxValue(0, 100000)]
		public Double ManHours { get; set; }

		public static PropertyInfo ManHoursProperty
		{
			get { return GetCurrentType().GetProperty("ManHours"); }
		}

		#endregion

		#region public int Mans { get; set; }

		/// <summary>
		/// Количество сотрудников для выполнения задачи
		/// </summary>
		public int Mans { get; set; }

		#endregion

		#region public Double Elapsed { get; set; }

		/// <summary>
		/// Параметр полных трудозатрат 
		/// </summary>
		[TableColumnAttribute("Elapsed"), ListViewData("Elapsed"), MinMaxValue(0, 100000)]
		public Double Elapsed { get; set; }

		#endregion

		#region public Double Cost { get; set; }

		/// <summary>
		/// Стоимость выполения
		/// </summary>
		[TableColumnAttribute("Cost"), ListViewData("Cost"), MinMaxValue(0, 1000000000)]
		public Double Cost { get; set; }

		#endregion

		#region public void ResetMathData()

		public void ResetMathData()
		{
			AfterForecastResourceRemain = null;
			NextPerformances.Clear();
		}

		#endregion

		#endregion

		#region Implement of IKitRequired

		#region public string KitParentString { get; }

		/// <summary>
		/// Возвращает строку для описания родителя КИТа
		/// </summary>
		public string KitParentString
		{
			//get { return string.Format("MPD.:{0}:{1}:{2}", TaskNumberCheck, MPDTaskNumber, Description); }
			get { return string.Format("MPD.:{0}", TaskCardNumber); }
		}

		#endregion

		#region public ICommonCollection<KitRequired> Kits

		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 14, "ParentObject")]
		public CommonCollection<AccessoryRequired> Kits
		{
			get { return _kits ?? (_kits = new CommonCollection<AccessoryRequired>()); }
			internal set
			{
				if (_kits != value)
				{
					if (_kits != null)
						_kits.Clear();
					if (value != null)
						_kits = value;
				}
			}
		}

		#endregion

		#endregion

		#region Implement of IBindedItem

		#region public CommonCollection<ItemsRelation> ItemRelations { get; set; }

		private CommonCollection<ItemsRelation> _itemRelations;
		private DateTime _mpdRevisionDate;
		private Skill _skill;
		private MpdCategory _category;
		private CriticalSystemList _criticalSystem;

		[Child(RelationType.OneToMany, ColumnAccessType.WriteOnly)]
		public CommonCollection<ItemsRelation> ItemRelations
		{
			get { return _itemRelations ?? (_itemRelations = new CommonCollection<ItemsRelation>()); }
			set
			{
				if (_itemRelations != value)
				{
					if (_itemRelations != null)
						_itemRelations.Clear();
					if (value != null)
						_itemRelations = value;
				}
			}
		}

		#endregion

		#region public WorkItemsRelationType WorkItemsRelationType

		public WorkItemsRelationType WorkItemsRelationType
		{
			get
			{
				var relationTypesIds = ItemRelations.Select(i => i.RelationTypeId).Distinct().ToList();

				if (relationTypesIds.Count > 1)
					return WorkItemsRelationType.Incorrect;
				if (relationTypesIds.Count == 1)
					return relationTypesIds[0];

				return WorkItemsRelationType.None;
			}
			set
			{
				foreach (var itemRelation in ItemRelations)
					itemRelation.RelationTypeId = value;
			}
		}

		#endregion

		#region public bool? IsFirst

		public bool? IsFirst
		{
			get
			{
				if (ItemRelations.Count == 0)
					return true;

				var isFirst = false;
				var isSecond = false;

				foreach (var itemRelation in ItemRelations)
				{
					if (itemRelation.FirstItemId == ItemId && itemRelation.FirtsItemTypeId == SmartCoreObjectType.ItemId)
						isFirst = true;
					if (itemRelation.SecondItemId == ItemId && itemRelation.SecondItemTypeId == SmartCoreObjectType.ItemId)
						isSecond = true;

					if (isFirst && isSecond)
						return null;
				}

				return isFirst;
			}
		}

		#endregion

		#region public NextPerformance BindedItemNextPerformance { get; set; }

		public NextPerformance BindedItemNextPerformance { get; set; }

		#endregion

		#region public ConditionState BindedItemCondition { get; set; }

		public ConditionState BindedItemCondition { get; set; }

		#endregion

		#region public Lifelength BindedItemNextPerformanceSource { get; set; }

		public Lifelength BindedItemNextPerformanceSource { get; set; }

		#endregion

		#region public Lifelength BindedItemRemains { get; set; }

		public Lifelength BindedItemRemains { get; set; }

		#endregion

		#region public DateTime? BindedItemNextPerformanceDate { get; set; }

		public DateTime? BindedItemNextPerformanceDate { get; set; }

		#endregion


		#endregion

		#region public int CountForPrint { get; set; }

		/// <summary>
		/// Количество копий карты данной задачи для печати при наличий связных задач по компонентам
		/// <br/> Используется в Рабочих пакетах
		/// </summary>
		public int CountForPrint { get; set; }

		#endregion

		#region Implement IPrintSettings

		#region public bool PrintInWorkPackage { get; set; }

		/// <summary>
		/// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
		/// </summary>
		[TableColumnAttribute("PrintInWP")]
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

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTType != NDTType.UNK; } }

		#endregion

		#region public bool HasKits { get; }

		[Filter("HasKits:", Order = 12)]
		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#endregion

		#region Implement of IMtopCalc

		public Lifelength PhaseThresh { get; set; }
		public Lifelength PhaseRepeat { get; set; }
		public int ParentAircraftId => ParentBaseComponent?.ParentAircraftId ?? -1;
		public List<NextPerformance> MtopNextPerformances { get; set; }
		public Phase MTOPPhase { get; set; }
		public bool RecalculateTenPercent { get; set; }
		#endregion


		public string CompnentPN { get; set; }
		public string CompnentSN { get; set; }

		public ComponentDirective ParentComponentDirective { get; set; }
		/*
		*  Методы 
		*/


		#region public MaintenanceDirective()

		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public MaintenanceDirective()
		{
			SmartCoreObjectType = SmartCoreType.MaintenanceDirective;
			//задаем все ID в -1
			ItemId = -1;

			// Ad директива
			WorkType = MaintenanceDirectiveTaskType.Unknown;
			Program = MaintenanceDirectiveProgramType.Unknown;
			CriticalSystem = CriticalSystemList.Unknown;
			NDTType = NDTType.UNK;
			MpdRevisionDate = DateTime.Today;
			ScheduleRevisionDate = DateTime.Today;
			// Задаем все String
			TaskNumberCheck = MPDTaskNumber = Remarks = Description = EngineeringOrders = HiddenRemarks = "";

			ForComponentId = -1;
			_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			_threshold = new MaintenanceDirectiveThreshold();

			PrintInWorkPackage = true;
		}

		#endregion

		#region private static Type GetCurrentType()

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof (MaintenanceDirective));
		}

		#endregion

		#region public override string ToString()

		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return TaskNumberCheck + " " + TaskCardNumber + " " + Description;
		}

		#endregion

		#region public int CompareTo(MaintenanceDirective y)

		public int CompareTo(MaintenanceDirective y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region public override int CompareTo(object y)

		public override int CompareTo(object y)
		{
			if (y is MaintenanceDirective) return ItemId.CompareTo(((MaintenanceDirective) y).ItemId);
			return 0;
		}

		#endregion

		#region public bool Equals(MaintenanceDirective other)

		public bool Equals(MaintenanceDirective other)
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

		#region public new MaintenanceDirective GetCopyUnsaved()

		public new MaintenanceDirective GetCopyUnsaved()
		{
			var maintenanceDirective = (MaintenanceDirective) MemberwiseClone();
			maintenanceDirective.ItemId = -1;
			maintenanceDirective.UnSetEvents();

			maintenanceDirective.TaskNumberCheck += " Copy";

			if (JobCard != null)
			{
				maintenanceDirective.JobCard = JobCard.GetCopyUnsaved();
				JobCard.Parent = maintenanceDirective;
			}

			maintenanceDirective.Threshold = MaintenanceDirectiveThreshold.ConvertFromByteArray(_threshold.ToBinary());

			maintenanceDirective._performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			foreach (var directiveRecord in PerformanceRecords)
			{
				var newObject = directiveRecord.GetCopyUnsaved();
				newObject.Parent = maintenanceDirective;
				maintenanceDirective._performanceRecords.Add(newObject);
			}

			maintenanceDirective.CategoriesRecords = new CommonCollection<CategoryRecord>();
			foreach (var categoryRecord in CategoriesRecords)
			{
				var newObject = categoryRecord.GetCopyUnsaved();
				newObject.Parent = maintenanceDirective;
				maintenanceDirective.CategoriesRecords.Add(newObject);
			}

			maintenanceDirective._files = new CommonCollection<ItemFileLink>();
			foreach (var file in Files)
			{
				var newObject = file.GetCopyUnsaved();
				maintenanceDirective._files.Add(newObject);
			}

			maintenanceDirective._kits = new CommonCollection<AccessoryRequired>();
			foreach (var kit in Kits)
			{
				var newObject = kit.GetCopyUnsaved();
				maintenanceDirective._kits.Add(newObject);
			}

			return maintenanceDirective;
		}

		#endregion

		#region public void NormalizeItemRelations()

		public void NormalizeItemRelations()
		{
			if (ItemRelations.Count == 0 || IsFirst != null)
				return;

			foreach (var itemRelation in ItemRelations.Where(i => i.FirstItemId != ItemId && i.FirtsItemTypeId != SmartCoreObjectType.ItemId))
			{
				itemRelation.SecondItemId = itemRelation.FirstItemId;
				itemRelation.SecondItemTypeId = itemRelation.FirtsItemTypeId;

				itemRelation.FirstItemId = ItemId;
				itemRelation.FirtsItemTypeId = SmartCoreObjectType.ItemId;

				if (itemRelation.RelationTypeId == WorkItemsRelationType.CalculationAffect)
					itemRelation.RelationTypeId = WorkItemsRelationType.CalculationDepend;
				else if (itemRelation.RelationTypeId == WorkItemsRelationType.CalculationDepend)
					itemRelation.RelationTypeId = WorkItemsRelationType.CalculationAffect;
			}
		}

		#endregion

	}
}
