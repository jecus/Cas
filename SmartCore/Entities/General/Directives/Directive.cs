using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP.Interfaces;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Templates;
using SmartCore.Files;
using SmartCore.Relation;

namespace SmartCore.Entities.General.Directives
{
	/// <summary>
	/// Класс описывает директиву
	/// </summary>
	[Table("Directives", "dbo", "ItemId")]
	[Dto(typeof(DirectiveDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Directive : BaseEntityObject, IEngineeringDirective, IKitRequired, IComparable<Directive>, IFileContainer, IBindedItem, IWorkPackageItemFilterParams, IMtopCalc
	{
		private static Type _thisType;

		#region public String Title { get; set; }
		/// <summary>
		/// Название директивы
		/// </summary>
		[TableColumn("Title")]
		[Filter("AD No:", Order = 1)]
		[ExcelImport("AD No:", Order = 1)]
		public String Title { get; set; }
		#endregion

		#region  public AttachedFile ADNoFile { get; set; }
		[NonSerialized]
		private AttachedFile _aDNoFile;
		/// <summary>
		/// Связь с файлом описания директивы летной годности
		/// </summary>    
		public AttachedFile ADNoFile
		{
			get
			{
				//TODO:Требуется использование Dictionary. Необходимо разделить на объект Bl и DA
				return _aDNoFile ?? (Files.GetFileByFileLinkType(FileLinkType.ADFile));
			}
			set
			{
				_aDNoFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ADFile);
			}
		}
		#endregion

		#region public String Applicability { get; set; }
		/// <summary>
		/// Применимость директивы
		/// </summary>
		[TableColumn("Applicability", -1)]
		[ExcelImport("Applicability:", Order = 4)]
		public String Applicability { get; set; }
		#endregion

		#region public bool IsApplicability { get; set; }

		[TableColumn("IsApplicability")]
		[Filter("Applicability:")]
		public bool IsApplicability { get; set; }

		#endregion

		#region public AtaChapter ATAChapter { get; set; }
		/// <summary>
		/// ATA глава, к которой директива относится
		/// </summary>
		[TableColumn("ATAChapter")]
		[Filter("Ata Chapter:", Order = 10)]
		[ExcelImport("Ata Chapter:", Order = 5)]
		public AtaChapter ATAChapter { get; set; }
		#endregion

		#region public DirectiveType DirectiveType { get; set; }

		private DirectiveType _directiveType;
		/// <summary>
		/// Тип директивы
		/// </summary>
		[TableColumn("DirectiveType")]
		public DirectiveType DirectiveType
		{
			get { return _directiveType ?? (_directiveType = DirectiveType.Unknown); }
			set
			{
				if (_directiveType != value)
				{
					_directiveType = value;
					OnPropertyChanged("DirectiveType");
				}
			}
		} 

		public static PropertyInfo DirectiveTypeProperty
		{
			get { return GetCurrentType().GetProperty("DirectiveType"); }
		}

		#endregion

		#region public int16 ADType{ get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ADType")]
		[Filter("AD Type:", Order = 11)]
		[ExcelImport("AD Type:")]
		public ADType ADType { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// Описание директивы
		/// </summary>
		[TableColumn("Description", -1)]
		[Filter("Description:", Order = 2)]
		[ExcelImport("Description:", Order = 3)]
		public String Description { get; set; }

		#endregion

		#region public String Paragraph { get; set; }
		/// <summary>
		/// Параметр трудозатрат
		/// </summary>
		[TableColumn("Paragraph")]
		[ExcelImport("Paragraph:", Order = 2)]
		public String Paragraph { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// Заметки по директиве
		/// </summary>
		[TableColumn("Remarks")]
		[Filter("Remarks:")]
		public String Remarks { get; set; }
		#endregion

		#region public NDTType NDTType { get; set; }
		/// <summary>
		/// Тип производимого Non-Destructive-Test
		/// </summary>
		[TableColumn("NDTType")]
		[Filter("NDT:", Order = 15)]
		public NDTType NDTType { get; set; }
		#endregion

		[TableColumn("DirectiveOrder")]
		public DirectiveOrder DirectiveOrder { get; set; }

		[TableColumn("SBType")]
		public DirectiveSbType SBType { get; set; }

		#region public string Workarea { get; set; }

		[Filter("Work Area:", Order = 8)]
		[TableColumn("Workarea")]
		public string Workarea { get; set; }

		#endregion

		#region public String Zone { get; set; }

		[TableColumn("Zone")]
		[Filter("Zone:", Order = 7)]
		public string DirectiveZone { get; set; }

		#endregion

		#region public String Access { get; set; }

		[TableColumn("Access")]
		[Filter("Access:", Order = 9)]
		public string DirectiveAccess { get; set; }

		#endregion

		#region public String ServiceBulletinNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ServiceBulletinNo")]
		[Filter("SB:", Order = 3)]
		[ExcelImport("SB:")]
		public String ServiceBulletinNo { get; set; }
		#endregion

		#region public string StcNo { get; set; }

		[TableColumn("StcNo")]
		[Filter("STC:", Order = 5)]
		public string StcNo { get; set; }

		#endregion

		#region  public AttachedFile ServiceBulletinFile { get; set; }
		[NonSerialized]
		private AttachedFile _stcile;
		/// <summary>
		/// Связь с файлом описания сервисного бюллетеня
		/// </summary>
		public AttachedFile STCFile
		{
			get
			{
				//TODO:Требуется использование Dictionary. Необходимо разделить на объект Bl и DA
				return _stcile ?? (Files.GetFileByFileLinkType(FileLinkType.STCFile));
			}
			set
			{
				_stcile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.STCFile);
			}
		}
		#endregion

		[TableColumn("SupersedesId")]
		public int? SupersedesId { get; set; }

		[TableColumn("SupersededId")]
		public int? SupersededId { get; set; }

		[TableColumn("SBSubjects")]
		public string SBSubjects { get; set; }

		[TableColumn("AffectedBy")]
		public string AffectedBy { get; set; }

		[TableColumn("Affects")]
		public DirectiveAffects Affects { get; set; }

		[TableColumn("Reason")]
		public DirectiveReason Reason { get; set; }
		
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
				//TODO:Требуется использование Dictionary. Необходимо разделить на объект Bl и DA
				return _serviceBulletinFile ?? (Files.GetFileByFileLinkType(FileLinkType.SBFile));
			}
			set
			{
				_serviceBulletinFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.SBFile);
			}
		}
		#endregion

		#region public String EngineeringOrders { get; set; }
		/// <summary>
		/// Параметр Engineering orders
		/// </summary>
		[TableColumn("EngineeringOrders")]
		[Filter("EO:", Order = 4)]
		[ExcelImport("EO:")]
		public String EngineeringOrders { get; set; }

		public static PropertyInfo EngineeringOrdersProperty
		{
			get { return GetCurrentType().GetProperty("EngineeringOrders"); }
		}

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
				//TODO:Требуется использование Dictionary. Необходимо разделить на объект Bl и DA
				return _engineeringOrderFile ?? (Files.GetFileByFileLinkType(FileLinkType.EOFile));
			}
			set
			{
				_engineeringOrderFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.EOFile);
			}
		}

		public static PropertyInfo EngineeringOrderFileProperty
		{
			get { return GetCurrentType().GetProperty("EngineeringOrderFile"); }
		}

		#endregion

		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Highlight")]
		public Highlight Highlight { get; set; }
		#endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("KitRequired")]
		public String KitRequired { get; set; }
		#endregion

		#region public String HiddenRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("HiddenRemarks", -1)]
		[Filter("Hidden Remarks:", Order = 6)]
		public String HiddenRemarks { get; set; }
		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1)]
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

		#region public BaseComponent ParentBaseComponent { get; set; }

		[NonSerialized]
		private BaseComponent _parentBaseComponent;

		/// <summary>
		/// Обратная ссылка на базовый агрегат
		/// </summary>
		[TableColumn("ComponentId")]
		[Filter("Base Detail:")]
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

		#region public Int32 AircraftFlightId { get; set; }
		/// <summary>
		/// Id Полета, в рамках которого могло быть создано данное отклонение
		/// </summary>
		[TableColumn("AircraftFlight")]
		public Int32 AircraftFlightId { get; internal set; }

		public static PropertyInfo AircraftFlightIdProperty
		{
			get { return GetCurrentType().GetProperty("AircraftFlightId"); }
		}

		#endregion

		#region public DirectiveWorkType WorkType { get; set; }

		private DirectiveWorkType _workType;
		/// <summary>
		/// Тип директивы
		/// </summary>
		[TableColumn("WorkType")]
		[Filter("Work Type:")]
		[ExcelImport("Work Type:")]
		public DirectiveWorkType WorkType
		{
			get { return _workType ?? (_workType = DirectiveWorkType.Unknown); }
			set
			{
				if (_workType != value)
				{
					_workType = value;
					OnPropertyChanged("WorkType");
				}
			}
		}

		public static PropertyInfo WorkTypeProperty
		{
			get { return GetCurrentType().GetProperty("WorkType"); }
		}

		#endregion

		#region public DirectiveThreshold Threshold { get; set; }

		private DirectiveThreshold _threshold;
		/// <summary>
		/// Условие выполнения директивы
		/// </summary>
		[TableColumn("Threshold")]
		[ExcelImport("Threshold:")]
		public DirectiveThreshold Threshold
		{
			get { return _threshold; }
			set { _threshold = value; }
		}

		[TableColumn("ThldTypeCond", 2)]
		public byte[] ThrldTypeCond
		{
			get { return _threshold != null ? _threshold.ThrldTypeToBinary() : new byte[2]; }
			set 
			{
				if(_threshold != null) 
					_threshold.ConvertToCondition(value); 
			}
		}
		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get; }

		/// <summary>
		/// Возвращает порог первого выполнения задачи
		/// </summary>
		[Filter("1st. Perf.:")]
		public Lifelength FirstPerformanceSinceNew
		{
			get { return _threshold != null ? _threshold.FirstPerformanceSinceNew : Lifelength.Null; }
		}
		#endregion

		#region public Lifelength Interval { get; }

		/// <summary>
		/// Возвращает интервал повторного выполнения задачи или Lifelength.Null
		/// </summary>
		[Filter("Rpt. Int.:")]
		public Lifelength Interval
		{
			get{ return _threshold != null ? _threshold.RepeatInterval : Lifelength.Null; }
		}
		#endregion

		#region public BaseRecordCollection<DirectiveRecord>PerformanceRecords { get; private set; }

		private BaseRecordCollection<DirectiveRecord> _performanceRecords;
		/// <summary>
		/// Коллекция содержит все записи о выполнении директивы
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1, "Parent")]
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

		#region public DirectiveRecord LastPerformance { get; }
		/// <summary>
		/// Последнее выполнение 
		/// </summary>
		[ExcelImport("Last Performance:")]
		public DirectiveRecord LastPerformance { get { return PerformanceRecords.GetLast(); } }
		#endregion

		/*
		 * Математический аппарат
		 */

		#region Implement of IEngineeringDirective
		//Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
		//у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
		// дату след. выполнения и наработку на которой это выполнение произоидет

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
		StaticDictionary IEngineeringDirective.WorkType { get { return WorkType; } }
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
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1, "Parent")]
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
			set { _threshold = value as DirectiveThreshold; }
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
		AbstractPerformanceRecord IDirective.LastPerformance { get { return PerformanceRecords.GetLast(); } }
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
			set { _nextPerformances = value; }
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

		#region public DirectiveStatus Status { get; }
		/// <summary>
		/// Статус директивы
		/// </summary>
		[Filter("Status:", Order = 13)]
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

		#region public ConditionState Condition { get; set; }
		/// <summary>
		/// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
		/// </summary>
		[Filter("Condition:", Order = 14)]
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
				if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
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

		#region public DateTime? NextPerformanceDate{ get; set; }
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
		[TableColumn("IsClosed")]
		public Boolean IsClosed { get; set; }
		#endregion

		#region public Boolean NextPerformanceIsBlocked { get; }
		///
		/// Логический флаг, показывающий, заблокировано ли след. выполенение директивы рабочим пакетом
		/// 
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
		/// Параметр трудозатрат
		/// </summary>
		[TableColumn("ManHours")]
		public double ManHours { get; set; }


		public static PropertyInfo ManHoursProperty
		{
			get { return GetCurrentType().GetProperty("ManHours"); }
		}
		#endregion

		#region public int Mans{ get; set; }
		/// <summary>
		/// Количество сотрудников для выполнения задачи
		/// </summary>
		public int Mans{ get; set; }
		#endregion

		#region public Double Elapsed { get; set; }
		/// <summary>
		/// Параметр полных трудозатрат 
		/// </summary>
		public double Elapsed { get; set; }
		#endregion

		#region public Double Cost { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Cost")]
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
			get { return string.Format("Dir.:{0}:{1}", Title, WorkType); }
		}
		#endregion

		#region public CommonCollection<AccessoryRequired> Kits

		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1, "ParentObject")]
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

		#region Implement of ICompdreble

		public int CompareTo(Directive y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region Implement IPrintSettings

		#region public bool PrintInWorkPackage { get; set; }
		/// <summary>
		/// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
		/// </summary>
		public bool PrintInWorkPackage { get; set; }

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

		#endregion

		#region Implement of IBindedItem

		#region public CommonCollection<ItemsRelation> ItemRelations { get; set; }

		private CommonCollection<ItemsRelation> _itemRelations;
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

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return _threshold.RepeatInterval ?? Lifelength.Null; } }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTType != NDTType.UNK; } }

		#endregion

		#endregion

		#region public new Directive GetCopyUnsaved()
		/// <summary>
		/// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
		/// <br/>с ItemId равным -1
		/// </summary>
		/// <returns></returns>
		public new Directive GetCopyUnsaved()
		{
			var directive = (Directive)MemberwiseClone();
			directive.ItemId = -1;
			directive.UnSetEvents();

			directive.Threshold = new DirectiveThreshold(Threshold.ToBinary(),ThrldTypeCond);
			directive.ForecastLifelength = new Lifelength(ForecastLifelength);
			directive.AfterForecastResourceRemain = new Lifelength(AfterForecastResourceRemain);

			directive._performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			//TODO:не копируем записи о перемещении если надо то раскоментить
			//foreach (var performanceRecord in PerformanceRecords)
			//{
			//	var newObject = performanceRecord.GetCopyUnsaved();
			//	newObject.Parent = directive;
			//	directive._performanceRecords.Add(newObject);
			//}
			
			directive._aircraftWorkerCategories = new CommonCollection<CategoryRecord>();
			foreach (var categoryRecord in CategoriesRecords)
			{
				var newObject = categoryRecord.GetCopyUnsaved();
				newObject.Parent = directive;
				directive._aircraftWorkerCategories.Add(newObject);
			}

			directive.NextPerformances = new List<NextPerformance>();
			foreach (var nextPerformance in NextPerformances)
			{
				var newObject = nextPerformance.GetCopyUnsaved();
				newObject.Parent = directive;
				directive.NextPerformances.Add(newObject);
			}

			directive._kits = new CommonCollection<AccessoryRequired>();
			foreach (var accessoryRequired in Kits)
			{
				var newObject = accessoryRequired.GetCopyUnsaved();
				newObject.ParentObject = directive;
				directive._kits.Add(newObject);
			}

			directive._files = new CommonCollection<ItemFileLink>();
			foreach (var file in Files)
			{
				var newObject = file.GetCopyUnsaved();
				directive._files.Add(newObject);
			}

			return directive;
		}
		#endregion
		/*
		*  Методы 
		*/

		#region public Directive()
		/// <summary>
		/// Создает директиву без дополнительной информации
		/// </summary>
		public Directive()
		{
			SmartCoreObjectType = SmartCoreType.Directive;
			// Задаем все String
			Title = Remarks = Applicability = Description = EngineeringOrders =
					KitRequired = HiddenRemarks = "";

			ATAChapter = new AtaChapter {ItemId = -1}; 
			
			IsClosed = false;
			// Ad директива
			DirectiveType = DirectiveType.AirworthenessDirectives;
			// тип работ данной директивы
			WorkType = DirectiveWorkType.Inspection;

			// Задаем все String
			Title = Remarks = EngineeringOrders = Paragraph = KitRequired = HiddenRemarks = "";

			// Создаем объекты, чтобы они были не null
			_threshold = new DirectiveThreshold();

			// Создаем колелкции
			_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			Kits = new CommonCollection<AccessoryRequired>();
			NDTType = NDTType.UNK;
			PrintInWorkPackage = true;
		}
		#endregion

		#region public Directive(TemplateDirective templateDirective) : this()
		/// <summary>
		/// Создает директиву на основе шаблона
		/// </summary>
		public Directive(TemplateDirective templateDirective) : this()
		{
			ADNoFile = templateDirective.ADNoFile;
			ADType = templateDirective.ADType;
			Applicability = templateDirective.Applicability;
			ATAChapter = templateDirective.ATAChapter ?? new AtaChapter { ItemId = -1 };
			Cost = templateDirective.Cost;
			Description = templateDirective.Description;
			DirectiveType = templateDirective.DirectiveType;
			EngineeringOrders = templateDirective.EngineeringOrders;
			EngineeringOrderFile = templateDirective.EngineeringOrderFile;
			Highlight = templateDirective.Highlight;
			HiddenRemarks = templateDirective.HiddenRemarks;
			KitRequired = templateDirective.KitRequired;
			ManHours = templateDirective.ManHours;
			NDTType = templateDirective.NDTType;
			Paragraph = templateDirective.Paragraph;
			Remarks = templateDirective.Remarks;
			ServiceBulletinNo = templateDirective.ServiceBulletinNo;
			ServiceBulletinFile = templateDirective.ServiceBulletinFile;
			Title = templateDirective.Title;
			_threshold = templateDirective.Threshold;
			WorkType = templateDirective.DirectiveWorkType;
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if(y is Directive) return ItemId.CompareTo(((Directive) y).ItemId);
			return 0;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Directive));
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Title + " " + Description;
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

		#region Implementation of IMtopCalc

		public Lifelength PhaseThresh { get; set; }
		public Lifelength PhaseRepeat { get; set; }
		public Phase MTOPPhase { get; set; }
		public bool RecalculateTenPercent { get; set; }
		public bool APUCalc { get; set; }
		public int ParentAircraftId => ParentBaseComponent?.ParentAircraftId ?? -1;
		public List<NextPerformance> MtopNextPerformances { get; set; }

		#endregion
	}

}
