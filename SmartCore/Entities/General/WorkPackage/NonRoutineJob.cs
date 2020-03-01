using System;
using System.Collections.Generic;
using System.Reflection;
using EntityCore.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace SmartCore.Entities.General.WorkPackage
{

	/// <summary>
	/// Нерутинная операция (процедура)
	/// </summary>
	[Table("NonRoutineJobs", "Dictionaries", "ItemId")]
	[Condition("IsDeleted","0")]
	[Dto(typeof(NonRoutineJobDTO))]
	[Serializable]
	public class NonRoutineJob : BaseEntityObject, IKitRequired, IEngineeringDirective, IWorkPackageItemFilterParams
	{
		private static Type _thisType;
		/*
		*  Свойства
		*/

		#region public AtaChapter ATAChapter { get; set; }

		/// <summary>
		/// Часть воздушного судна, где требуется провести работу
		/// </summary>
		[ListViewData(0.22f, "Ata Chapter"), TableColumnAttribute("AtaChapterId")]
		public AtaChapter ATAChapter { get; set; }

		#endregion

		#region public String Title { get; set; }
		/// <summary>
		/// название работы
		/// </summary>
		[ListViewData(0.2f, "Title"), TableColumnAttribute("Title")]
		public String Title { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// описание работы
		/// </summary>
		[ListViewData(0.2f, "Description"), TableColumnAttribute("Description")]
		public String Description { get; set; }
		#endregion

		#region public WorkPackage ParentWorkPackage { get; set; }
		[NonSerialized]
		private WorkPackage _parentWorkPackage;

		//TODO:(Evgenii Babak) проревьюировать использование данного свойства
		[ListViewData(0.2f, "Work Package")]
		public WorkPackage ParentWorkPackage
		{
			get { return _parentWorkPackage; }
			set { _parentWorkPackage = value; }
		}

		#endregion

		#region public WorkPackageRecord WorkPackageRecord { get; internal set; }
		[NonSerialized]
		private WorkPackageRecord _workPackageRecord;
		/// <summary>
		/// Используется в работе с NonRoutineJobsStatus
		/// </summary>
		public WorkPackageRecord WorkPackageRecord
		{
			get { return _workPackageRecord; }
			set { _workPackageRecord = value; }
		}

		#endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ListViewData(0.1f, "Kit Required"), TableColumnAttribute("KitRequired")]
		public String KitRequired { get; set; }
		#endregion

		//TODO: переделать на использование нового fileCore
		#region public AttachedFile AttachedFile
		[NonSerialized]
		private AttachedFile _attachedFile;
		/// <summary>
		/// Файл карты задачи
		/// </summary>
		[TableColumnAttribute("FileId")]
		[Child]
		public AttachedFile AttachedFile
		{
			get { return _attachedFile; }
			set { _attachedFile = value; }
		}

		#endregion

		#region public IDirectivePackage BlockedByPackage { get; set; }
		/// <summary>
		/// Рабочий пакет, в котором задеиствовано данное выполнение
		/// </summary>
		public IDirectivePackage BlockedByPackage { get; set; }
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
				return $"N-Rout. job:{ATAChapter} {Title}";
			}
		}
		#endregion

		#region public ICommonCollection<KitRequired> Kits

		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4, "ParentObject")]
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

		#region  Implement of IEngineeringDirective
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
		public StaticDictionary WorkType { get { return DirectiveWorkType.Unknown; } }
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
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4, "Parent")]
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
			get { return null; }
		}
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }
		/// <summary>
		/// порог первого и посделующего выполнений
		/// </summary>
		IThreshold IDirective.Threshold { get; set; }
		#endregion

		#region IRecordCollection IDirective.PerformanceRecords { get; }
		/// <summary>
		/// Коллекция содержит все записи о выполнении директивы
		/// </summary>
		IRecordCollection IDirective.PerformanceRecords { get { return null; } }
		#endregion

		#region AbstractPerformanceRecord IDirective.LastPerformance { get; }
		/// <summary>
		/// Доступ к последней записи о выполнении задачи
		/// </summary>
		AbstractPerformanceRecord IDirective.LastPerformance { get { return null; } }
		#endregion

		#region public List<NextPerformance> NextPerformances { get; set; }

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
				return null;
			}
		}
		#endregion

		#region public ConditionState Condition { get; set; }

		private ConditionState _conditionState;
		/// <summary>
		/// Текущее состояние
		/// </summary>
		public ConditionState Condition
		{
			get { return _conditionState ?? (_conditionState = ConditionState.Satisfactory); }
			set
			{
				if (_conditionState != value)
				{
					_conditionState = value;
					OnPropertyChanged("Condition");
				}
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
				return DirectiveStatus.Open;
			}
		}
		#endregion

		#region public Lifelength NextCompliance { get; set; }
		/// <summary>
		/// Наработка, при которой произоидет следующее выполнение
		/// </summary>
		public Lifelength NextPerformanceSource { get; set; }
		#endregion

		#region public Lifelength Remains { get; set; }

		private Lifelength _remains;
		/// <summary>
		/// Остаток ресурса до следующего выполнения
		/// </summary>
		public Lifelength Remains
		{
			get { return _remains ?? (_remains = Lifelength.Null); }
			set
			{
				if(_remains != value)
				{
					_remains = value;
					OnPropertyChanged("Remains");
				}
			}
		}
		#endregion

		#region public Lifelength BeforeForecastResourceRemain { get; set; }
		/// <summary>
		/// Остаток ресурса до прогноза (вычисляется только в прогнозе)
		/// </summary>
		public Lifelength BeforeForecastResourceRemain { get; set; }
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
		/// Дата следующего выполнения
		/// </summary>
		public DateTime? NextPerformanceDate { get; set; }
		#endregion

		#region public double? Percents { get; set; }
		/// <summary>
		/// Насколько процентов NextCompliance превосходит точку прогноза
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
			get { return 0; }
		}
		#endregion

		#region public Double ManHours { get; set; }
		/// <summary>
		/// Количество человеко часов, необходимых для выполнения работы
		/// </summary>
		[ListViewData(0.1f, "MH"), TableColumnAttribute("ManHours")]
		public Double ManHours { get; set; }

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

		#region public Double Cost { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ListViewData(0.1f, "Cost"), TableColumnAttribute("Cost")]
		public Double Cost { get; set; }
		#endregion

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// Логический флаг, показывающий, закрыта ли директива
		/// </summary>
		public Boolean IsClosed { get; set; }
		#endregion

		#region public Boolean IsBlocked { get; }
		///
		/// Логический флаг, показывающий, заблокирована ли директивы рабочим пакетом
		/// 
		public Boolean NextPerformanceIsBlocked
		{
			get
			{
				return  false;
			}
		}

		#endregion

		#region public void ResetMathData()
		public void ResetMathData()
		{
			Condition = ConditionState.NotEstimated;
			NextPerformanceSource = null;
			Remains = null;
			BeforeForecastResourceRemain = null;
			AfterForecastResourceRemain = null;
			NextPerformanceDate = null;
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

		#region private static Type GetCurrentType()

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(NonRoutineJob));
		}

		#endregion

		#region public NonRoutineJob()
		/// <summary>
		/// Создает нерутинную работу без дополнительной информации
		/// </summary>
		public NonRoutineJob()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.NonRoutineJob;

			Kits = new CommonCollection<AccessoryRequired>();
			PrintInWorkPackage = true;
		}
		#endregion
	  
		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return (ATAChapter != null ? "ata: "+ ATAChapter.ShortName + " ": "") +  Title;
		}
		#endregion

		#region public new NonRoutineJob GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved()
		{
			var nrj = (NonRoutineJob) MemberwiseClone();

			nrj.ItemId = -1;

			nrj.Title += " Copy";

			nrj.NextPerformanceSource = new Lifelength(NextPerformanceSource);
			nrj.Remains = new Lifelength(Remains);
			nrj.BeforeForecastResourceRemain = new Lifelength(BeforeForecastResourceRemain);
			nrj.ForecastLifelength = new Lifelength(ForecastLifelength);
			nrj.AfterForecastResourceRemain = new Lifelength(AfterForecastResourceRemain);

			nrj._kits = new CommonCollection<AccessoryRequired>();
			foreach (var accessory in Kits)
			{
				var newObject = accessory.GetCopyUnsaved();
				newObject.ParentId = nrj.ItemId;
				nrj._kits.Add(newObject);
			}

			return nrj;
		}

		#endregion

	}

}
