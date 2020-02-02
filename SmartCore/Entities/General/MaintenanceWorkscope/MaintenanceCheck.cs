using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Templates;

namespace SmartCore.Entities.General.MaintenanceWorkscope
{
    [Table("Cas3MaintenanceCheck", "dbo", "ItemId")]
    [Dto(typeof(MaintenanceCheckDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class MaintenanceCheck : BaseEntityObject, IEngineeringDirective, IKitRequired, IComparable<MaintenanceCheck>, IWorkPackageItemFilterParams
	{
        private static Type _thisType;
        /*
         *  Свойства
         */

        #region public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string _name;
        [TableColumnAttribute("Name")]
        public String Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region public Lifelength Interval { get; set; }
        [TableColumnAttribute("Interval")]
        public Lifelength Interval
        {
            get
            {
                return _threshold.FirstPerformanceSinceNew;
            }
            set
            {
                if (_threshold.FirstPerformanceSinceNew != value)
                {
                    _threshold.FirstPerformanceSinceNew = value;
                    OnPropertyChanged("Interval");
                }
            }
        }
        #endregion

        #region public Lifelength Notify { get; set; }
        [TableColumnAttribute("Notify")]
        public Lifelength Notify
        {
            get
            {
                return _threshold.FirstNotification;
            }
            set
            {
                if (_threshold.FirstNotification != value)
                {
                    _threshold.FirstNotification = value;
                    OnPropertyChanged("Notify");
                }
            }
        }
        #endregion

        #region public int ParentAircraftId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int _parentAircraftId;
        [TableColumnAttribute("ParentAircraft")]
        public int ParentAircraftId
        {
            get
            {
                return _parentAircraftId;
            }
            set
            {
                if (_parentAircraftId != value)
                {
                    _parentAircraftId = value;
                    OnPropertyChanged("ParentAircraftId");
                }
            }
        }

        public static PropertyInfo ParentAircraftIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentAircraftId"); }
        }

        #endregion

        #region public Aircraft ParentAircraft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private Aircraft _parentAircraft;
        public Aircraft ParentAircraft
        {
            get
            {
                return _parentAircraft;
            }
            set
            {
                if (_parentAircraft != value)
                {
                    _parentAircraft = value;
                    OnPropertyChanged("ParentAircraft");
                }
            }
        }
		#endregion

		#region public MaintenanceCheckType CheckType { get; set; }
		/// <summary>
		/// Тип чека программы обслуживания (A,B,C и т.д.)
		/// </summary>
		private MaintenanceCheckType _checkType;
        [TableColumnAttribute("CheckTypeId")]
        public MaintenanceCheckType CheckType
        {
            get { return _checkType ?? (_checkType = MaintenanceCheckType.Unknown); }
            set
            {
                if (_checkType != value)
                {
                    _checkType = value;
                    OnPropertyChanged("CheckType");
                }
            }
        }
        #endregion

        #region public Cas3MaintenanceSubCheckPerformanceItem LastPerformance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MaintenanceCheckRecord LastPerformance
        {
            get
            {
                return _performanceRecords != null ? _performanceRecords.GetLast() : null;
            }
        }
        #endregion

        #region public BaseRecordCollection<Cas3MaintenancePerformanceItem> PerformanceRecords

        private BaseRecordCollection<MaintenanceCheckRecord> _performanceRecords;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 3, "ParentCheck")]
        public BaseRecordCollection<MaintenanceCheckRecord> PerformanceRecords
        {
            get { return _performanceRecords ?? (_performanceRecords = new BaseRecordCollection<MaintenanceCheckRecord>()); }
            set { _performanceRecords = value; }
        }
        #endregion

        #region public bool Schedule

        private bool _schedule;
        /// <summary>
        /// true указывает на то что эта программа по обслуживанию во время полетов
        /// а false при простое самолета в ангаре
        /// </summary>
        [TableColumnAttribute("Schedule")]
        public bool Schedule
        {
            get { return _schedule; }
            set
            {
                if (_schedule != value)
                {
                    _schedule = value;
                    OnPropertyChanged("Schedule");
                }
            }
        }

        public static PropertyInfo ScheduleProperty
        {
            get { return GetCurrentType().GetProperty("Schedule"); }
        }

        #endregion

        #region public bool Grouping

        private bool _grouping;
        /// <summary>
        /// true указывает на то что данный чек группируется с остальными (Н:1А 2А 4А)
        /// false чек выполняется отдельно от остальных (последнее -> след. выполнение)
        /// </summary>
        [TableColumnAttribute("Grouping")]
        public bool Grouping
        {
            get { return _grouping; }
            set
            {
                if (_grouping != value)
                {
                    _grouping = value;
                    OnPropertyChanged("Grouping");
                }
            }
        }

        public static PropertyInfo Groupingroperty
        {
            get { return GetCurrentType().GetProperty("Grouping"); }
        }

        #endregion

        #region public LifelengthSubResource Resource { get; set; }

        private LifelengthSubResource _subResource;
        /// <summary>
        /// Ресурс по которому будут расчитыватся и группироватся чеки
        /// </summary>
        [TableColumnAttribute("Resource")]
        public LifelengthSubResource Resource
        {
            get
            {
                return _subResource;
            }
            set
            {
                if (_subResource != value)
                {
                    _subResource = value;
                    OnPropertyChanged("Resource");
                }
            }
        }
        #endregion

        #region public bool Dependent { get; set; }

        private bool _dependent;
        /// <summary>
        /// true указывает на то что выполнение данного чека зависит от выполнения другого чека
        /// </summary>
        public bool Dependent 
        {
            get { return _dependent; }
            set
            {
                if (_dependent != value)
                {
                    _dependent = value;
                    OnPropertyChanged("Dependent");
                }
            }
        }
        #endregion

        #region public int WhichDependsCheckId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int _whichDependsCheckId;
        public int WhichDependsCheckId
        {
            get
            {
                return _whichDependsCheckId;
            }
            set
            {
                if (_whichDependsCheckId != value)
                {
                    _whichDependsCheckId = value;
                    OnPropertyChanged("WhichDependsCheckId");
                }
            }
        }
        #endregion

        #region public LifelengthSubResource MainSubResource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private LifelengthSubResource _mainSubResource;
        public LifelengthSubResource MainSubResource
        {
            get
            {
                return _mainSubResource;
            }
            set
            {
                if (_mainSubResource != value)
                {
                    _mainSubResource = value;
                    OnPropertyChanged("MainSubResource");
                }
            }
        }
        #endregion

        #region public LifelengthSubResource DependSubResource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private LifelengthSubResource _dependSubResource;
        public LifelengthSubResource DependSubResource
        {
            get
            {
                return _dependSubResource;
            }
            set
            {
                if (_dependSubResource != value)
                {
                    _dependSubResource = value;
                    OnPropertyChanged("DependSubResource");
                }
            }
        }
        #endregion

        #region Tag
        /// <summary>
        /// Для хранения любой информации
        /// </summary>
        public object Tag { get; set; }

        #endregion

        #region public int ComplianceGroupNum
        /// <summary>
        /// для хранения номера группы в которой чек должен быть выполнен
        /// </summary>
        public int ComplianceGroupNum { get; set; }

        #endregion

        #region  public MaintenanceCheckThreshold Threshold

        private MaintenanceCheckThreshold _threshold;
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        public MaintenanceCheckThreshold Threshold
        {
            get { return _threshold ?? (_threshold = new MaintenanceCheckThreshold()); }
            set { _threshold = value; }
        }
        #endregion

        #region Implement of IEngineeringDirective
        //Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
        //у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
        // дату след. выполнения и наработку на которой это выполнение произоидет

        #region public AtaChapter ATAChapter { get; set; }
        public AtaChapter ATAChapter { get; set; }
        #endregion

        #region String Title { get; }

        /// <summary>
        /// Название директивы
        /// </summary>
        public String Title
        {
            get { return Name; }
        }
        #endregion

        #region public String Description{ get; set; }
        public String Description { get; set; }
        #endregion

        #region String Zone { get; }
        /// <summary>
        /// Зона
        /// </summary>
        public String Zone { get; set; }
        #endregion

        #region String Access { get; }
        /// <summary>
        /// Доступ
        /// </summary>
        public String Access { get; set; }
        #endregion

        #region public MaintenanceDirectiveProgramType Program { get; }

        /// <summary>
        /// Программа обслуживания
        /// </summary>
        public MaintenanceDirectiveProgramType Program
        {
            get { return MaintenanceDirectiveProgramType.Unknown; }
        }
        #endregion

        #region public StaticDictionary WorkType { get; }
        /// <summary>
        /// Тип/Вид Работ
        /// </summary>
        public StaticDictionary WorkType { get { return Schedule ? MaintenanceCheckScheduleType.Schedule : MaintenanceCheckScheduleType.Unschedule; } }
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
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 3, "Parent")]
        public CommonCollection<CategoryRecord> CategoriesRecords
        {
            get { return _aircraftWorkerCategories ?? (_aircraftWorkerCategories = new CommonCollection<CategoryRecord>()); }
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

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// Возвращает объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
        {
            get { return ParentAircraft; }
        }
        #endregion

        #region IThreshold IDirective.Threshold { get; set; }
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        IThreshold IDirective.Threshold
        {
            get { return _threshold ?? (_threshold = new MaintenanceCheckThreshold()); }
            set { _threshold = value as MaintenanceCheckThreshold; }
        }
        #endregion

        #region IRecordCollection IDirective.PerformanceRecords { get; }
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
        AbstractPerformanceRecord IDirective.LastPerformance { get { return PerformanceRecords.GetLast(); } }
        #endregion

        #region public List<NextPerformance> NextPerformances { get; }

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

        #region public ConditionState Condition { get; }
        /// <summary>
        /// Возвращает текущее состояние
        /// </summary>
        public ConditionState Condition
        {
            get
            {
                if (_grouping)
                {
                    return GetPergormanceGroupWhereCheckIsSenior().Count > 0
                        ? GetPergormanceGroupWhereCheckIsSenior()[0].Condition
                        : ConditionState.NotEstimated;
                }
                if (NextPerformances == null || NextPerformances.Count == 0) return ConditionState.NotEstimated;
                return NextPerformances[0].Condition;
            }
        }
        #endregion

        #region public DirectiveStatus Status { get; }
        /// <summary>
        /// Статус директивы
        /// </summary>
        [Filter("Status:", Order = 8)]
        public DirectiveStatus Status
        {
            get
            {
                if (IsClosed) return DirectiveStatus.Closed; //директива принудительно закрыта пользователем
                if (LastPerformance == null)
                {
                    if (!Interval.IsNullOrZero())
                        return DirectiveStatus.Open;

                    return DirectiveStatus.NotApplicable;
                }

                if (_threshold.RepeatInterval.IsNullOrZero()) return DirectiveStatus.Closed;

                return DirectiveStatus.Repetative;
            }
        }
        #endregion

        #region public Lifelength NextCompliance { get; }
        /// <summary>
        /// Возвращает наработку, при которой произоидет следующее выполнение
        /// </summary>
        public Lifelength NextPerformanceSource
        {
            get
            {
                if (_grouping)
                {
                    return GetPergormanceGroupWhereCheckIsSenior().Count > 0
                        ? GetPergormanceGroupWhereCheckIsSenior()[0].PerformanceSource
                        : Lifelength.Null;
                }

                if (NextPerformances == null || NextPerformances.Count == 0) return Lifelength.Null;
                return NextPerformances[0].PerformanceSource;
            }
        }
        #endregion

        #region public Lifelength Remains { get; }
        /// <summary>
        /// Возвращает остаток ресурса до следующего выполнения
        /// </summary>
        public Lifelength Remains
        {
            get
            {
                if (_grouping)
                {
                    return GetPergormanceGroupWhereCheckIsSenior().Count > 0
                        ? GetPergormanceGroupWhereCheckIsSenior()[0].Remains
                        : Lifelength.Null;
                }

                if (NextPerformances == null || NextPerformances.Count == 0) return Lifelength.Null;
                return NextPerformances[0].Remains;
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
                if (_grouping)
                {
                    return GetPergormanceGroupWhereCheckIsSenior().Count > 0
                        ? GetPergormanceGroupWhereCheckIsSenior()[0].BeforeForecastResourceRemain
                        : Lifelength.Null;
                }

                if (NextPerformances == null || NextPerformances.Count == 0) return Lifelength.Null;
                return NextPerformances[0].BeforeForecastResourceRemain;
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

        #region public DateTime? NextComplianceDate{ get; }
        /// <summary>
        /// Дата следующего выполнения
        /// </summary>
        public DateTime? NextPerformanceDate
        {
            get
            {
                if (_grouping)
                {
                    return GetPergormanceGroupWhereCheckIsSenior().Count > 0
                        ? GetPergormanceGroupWhereCheckIsSenior()[0].PerformanceDate
                        : null;
                }

                if (NextPerformances == null || NextPerformances.Count == 0) return null;
                return NextPerformances[0].PerformanceDate;
            }
        }
        #endregion

        #region public double? Percents { get; set; }
        /// <summary>
        /// Насколько процентов NextCompliance превосходит точку прогноза
        /// </summary>
        public double? Percents { get; set; }
        #endregion

        #region public string TimesToString { get; set; }
        /// <summary>
        /// Возвращает строковое представление количества "след. выполнений"
        /// </summary>
        public string TimesToString
        {
            get
            {
                string res = "";
                int countWhereSenior = GetPergormanceGroupWhereCheckIsSenior().Count;

                if (Times > 1)
                {
                    if (countWhereSenior > 0)
                        res += $"All: {Times} times (in {countWhereSenior} is senior)";
                    else
                        res += $"{Times} times";
                }
                return res;
            }
        }
        #endregion

        #region public Int32 Times { get;}
        /// <summary>
        /// Сколько раз выполнится директива (применяетмя только в прогнозах)
        /// </summary>
        public Int32 Times
        {
            get { return NextPerformances.Count > 1 ? NextPerformances.Count : -1; }
        }
        #endregion

        #region  public double Cost
        private double _cost;
        [TableColumnAttribute("Cost")]
        public double Cost
        {
            get { return _cost; }
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }
        #endregion

        #region public double ManHours
        private double _manHours;
        [TableColumnAttribute("ManHours")]
        public double ManHours
        {
            get { return _manHours; }
            set
            {
                if (_manHours != value)
                {
                    _manHours = value;
                    OnPropertyChanged("ManHours");
                }
            }
        }

		public static PropertyInfo ManHoursProperty
		{
			get { return GetCurrentType().GetProperty("ManHours"); }
		}
		#endregion

		#region Double Elapsed { get; set; }
		/// <summary>
		/// Параметр полных трудозатрат 
		/// </summary>
		public Double Elapsed { get; set; }
        #endregion

        #region public int Mans { get; set; }
        /// <summary>
        /// Количество сотрудников для выполнения задачи
        /// </summary>
        public int Mans { get; set; }
        #endregion

        #region public Boolean IsClosed { get; set; }
        /// <summary>
        /// Логический флаг, показывающий, закрыта ли директива
        /// </summary>
        public Boolean IsClosed { get; set; }
        #endregion

        #region public Boolean NextPerformanceIsBlocked { get; }
        ///
        /// Логический флаг, показывающий, заблокирована ли директивы рабочим пакетом
        /// 
        public Boolean NextPerformanceIsBlocked
        {
            get
            {
                if (NextPerformances == null || NextPerformances.Count == 0) return false;
                return NextPerformances[0].BlockedByPackage != null;
            }
        }

        #endregion

        #region public void ResetMathData()
        public void ResetMathData()
        {
            AfterForecastResourceRemain = null;
            Percents = null;
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
            get
            {
                return $"Maint.Check:{Name} {(Schedule ? "Schedule" : "Store")}";
            }
        }
        #endregion

        #region public CommonCollection<AccessoryRequired> Kits

        private CommonCollection<AccessoryRequired> _kits;

        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 3, "ParentObject")]
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

        #region Implement IPrintSettings

        #region public bool PrintInWorkPackage { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
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

        #region public MaintenanceNextPerformance GetNextPergormanceGroupWhereCheckIsSenior()
        /// <summary>
        /// Возвращает След. выполнение, в котором данный чек является старшим или null 
        /// </summary>
        /// <returns>"След. выполнение или null"</returns>
        public MaintenanceNextPerformance GetNextPergormanceGroupWhereCheckIsSenior()
        {
            return NextPerformances.OfType<MaintenanceNextPerformance>().
                Where(mnp => mnp.PerformanceGroup != null && mnp.PerformanceGroup.CheckIsSenior(this)).FirstOrDefault();
        }
        #endregion

        #region public List<MaintenanceNextPerformance> GetPergormanceGroupWhereCheckIsSenior()
        /// <summary>
        /// Возвращает "След. выполнения", в которых данный чек является старшим 
        /// </summary>
        /// <returns>Список "След. выполнений"</returns>
        public List<MaintenanceNextPerformance> GetPergormanceGroupWhereCheckIsSenior()
        {
            return NextPerformances.OfType<MaintenanceNextPerformance>().
                Where(mnp => mnp.PerformanceGroup != null && mnp.PerformanceGroup.CheckIsSenior(this)).ToList();
        }
        #endregion

        #region public List<MaintenanceNextPerformance> GetPergormanceGroupWhereCheckIsSeniorByGroupNum(int numGroup)
        /// <summary>
        /// Возвращает "След. выполнение" с заданным порядковым номером, в котором данный чек является старшим
        /// </summary>
        /// <returns>"След. выполнение" или null</returns>
        public MaintenanceNextPerformance GetPergormanceGroupWhereCheckIsSeniorByGroupNum(int numGroup)
        {
            return NextPerformances.OfType<MaintenanceNextPerformance>().FirstOrDefault(mnp => mnp.PerformanceGroup != null &&
                                                                                               mnp.PerformanceGroup.CheckIsSenior(this) &&
                                                                                               mnp.PerformanceGroupNum == numGroup);
        }
        #endregion

        #region public MaintenanceNextPerformance GetPergormanceGroupByGroupNum(int numGroup)
        /// <summary>
        /// Возвращает "След. выполнение" с заданным порядковым номером
        /// </summary>
        /// <returns>"След. выполнение" или null</returns>
        public MaintenanceNextPerformance GetPergormanceGroupByGroupNum(int numGroup)
        {
            return NextPerformances.OfType<MaintenanceNextPerformance>().FirstOrDefault(mnp => mnp.PerformanceGroup != null &&
                                                                                               mnp.PerformanceGroupNum == numGroup);
        }
        #endregion

        #region public CommonCollection<MaintenanceDirective> BindMpds

        private CommonCollection<MaintenanceDirective> _bindedMpds;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "MaintenanceCheck", "MaintenanceCheck")]
        public CommonCollection<MaintenanceDirective> BindMpds
        {
            get { return _bindedMpds ?? (_bindedMpds = new CommonCollection<MaintenanceDirective>()); }
            internal set
            {
                if (_bindedMpds != value)
                {
                    if (_bindedMpds != null)
                        _bindedMpds.Clear();
                    if (value != null)
                        _bindedMpds = value;
                }
            }
        }
		#endregion

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return Lifelength.Null; } }

		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get;}

		public Lifelength FirstPerformanceSinceNew { get { return Lifelength.Null; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get; }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#endregion

		/*
		*  Методы 
		*/

		#region public MaintenanceCheck()

		public MaintenanceCheck()
        {
            _grouping = true;
            _subResource = LifelengthSubResource.Hours;
            SmartCoreObjectType = SmartCoreType.MaintenanceCheck;
            ItemId = -1;
            Kits = new CommonCollection<AccessoryRequired>();
            _threshold = new MaintenanceCheckThreshold();
            _nextPerformances = new List<NextPerformance>();

            PrintInWorkPackage = true;
        }
        #endregion

        #region public MaintenanceCheck(TemplateMaintenanceCheck templateMaintenanceCheck) : this()

        public MaintenanceCheck(TemplateMaintenanceCheck templateMaintenanceCheck)
            : this()
        {
            Name = templateMaintenanceCheck.Name;
            Interval = templateMaintenanceCheck.Interval;
            Notify = templateMaintenanceCheck.Notify;
            CheckType = templateMaintenanceCheck.CheckType;
            Cost = templateMaintenanceCheck.Cost;
            ManHours = templateMaintenanceCheck.ManHours;
            Schedule = templateMaintenanceCheck.Schedule;
            PerformanceRecords = new BaseRecordCollection<MaintenanceCheckRecord>();
        }
        #endregion

        #region public int CompareTo(MaintenanceCheck y)

        public int CompareTo(MaintenanceCheck y)
        {
            if (y == null)
                return 0;
            if(Resource == LifelengthSubResource.Hours)
            {
                if (y.Resource == LifelengthSubResource.Cycles ||
                    y.Resource == LifelengthSubResource.Calendar)
                    return -1;
            }
            if (Resource == LifelengthSubResource.Cycles)
            {
                if (y.Resource == LifelengthSubResource.Hours)
                    return -1;
                if (y.Resource == LifelengthSubResource.Calendar)
                    return -1;

                //if (Grouping && !y.Grouping)
                //    return -1;
                //if (!Grouping && y.Grouping)
                //    return 1;

                //int checkTypeCompare = CheckType.ShortName.CompareTo(y.CheckType.ShortName);
                //if (checkTypeCompare != 0)
                //    return checkTypeCompare;
                //return ToString().CompareTo(y.ToString());
            }
            if (Resource == LifelengthSubResource.Calendar)
            {
                if (y.Resource == LifelengthSubResource.Cycles ||
                    y.Resource == LifelengthSubResource.Hours)
                    return 1;

                //if (Grouping && !y.Grouping)
                //    return -1;
                //if (!Grouping && y.Grouping)
                //    return 1;

                //int checkTypeCompare = CheckType.ShortName.CompareTo(y.CheckType.ShortName);
                //if (checkTypeCompare != 0)
                //    return checkTypeCompare;
                //return ToString().CompareTo(y.ToString());
            }

            if (Grouping && !y.Grouping)
                return -1;
            if (!Grouping && y.Grouping)
                return 1;

            int checkTypeCompare = CheckType.ShortName.CompareTo(y.CheckType.ShortName);
            if (checkTypeCompare != 0)
                return checkTypeCompare;
            return ToString().CompareTo(y.ToString());

            return 0;
        }

        #endregion

        #region public override bool Equals(object obj)

        public override bool Equals(object obj)
        {
            //Check whether the compared object is null.
            if (ReferenceEquals(obj, null) || !(obj is MaintenanceCheck)) 
                return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, obj)) 
                return true;

            //Check whether the products' properties are equal.
            return ItemId == ((MaintenanceCheck)obj).ItemId;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} | {Interval?.ToRepeatIntervalsFormat()}";
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(MaintenanceCheck));
        }
        #endregion
    }
}
