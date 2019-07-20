using System;
using System.Collections.Generic;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;

namespace SmartCore.Entities.General.Quality
{

    /// <summary>
    /// Класс описывает директиву
    /// </summary>
    [Table("Procedures", "dbo", "ItemId")]
    [Dto(typeof(ProcedureDTO))]
	[Condition("IsDeleted", "0")]
    public class Procedure : BaseEntityObject, IDirective, IKitRequired, IComparable<Procedure>, IEquatable<Procedure>, IFileContainer
	{
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public String Title { get; set; }
        /// <summary>
        /// Номер чека задачи
        /// </summary>
        [TableColumn("Title"), ListViewData("Title")]
        [Filter("Title:", Order = 1)]
        public String Title { get; set; }
        #endregion

        #region public ProcedureType ProcedureType { get; set; }
        /// <summary>
        /// Тип директивы
        /// </summary>
        [TableColumn("ProcedureTypeId"), ListViewData("Procedure Type")]
        [Filter("Procedure Type:", Order = 7)]
        public ProcedureType ProcedureType { get; set; }
        #endregion

        #region public ProcedureRating ProcedureRating { get; set; }
        /// <summary>
        /// Тип директивы
        /// </summary>
        [TableColumn("ProcedureRatingId"), ListViewData("Procedure Rating")]
        [Filter("Procedure Rating:", Order = 4)]
        public ProcedureRating ProcedureRating { get; set; }
        #endregion

        #region public String Applicability { get; set; }
        /// <summary>
        /// Применимость
        /// </summary>
        [TableColumn("Applicability"), ListViewData("Applicability")]
        public String Applicability { get; set; }
        #endregion

        #region public Operator ParentOperator { get; set; }
        /// <summary>
        /// Обратная ссылка на Оператора
        /// </summary>
        [TableColumn("OperatorId")]
        public Operator ParentOperator { get; set; }

        public static PropertyInfo ParentOperatorProperty
        {
            get { return GetCurrentType().GetProperty("ParentOperator"); }
        }
        #endregion

        #region public String AuditedObject { get; set; }
        /// <summary>
        /// Номер задачи MPD
        /// </summary>
        [TableColumnAttribute("AuditedObject"), ListViewData("AuditedObject")]
        public String AuditedObject { get; set; }
        #endregion

        #region public int AuditedObjectId { get; set; }
        /// <summary>
        /// Ид агрегата, для которого предназначена директива
        /// <br/>(Обычно является одним из агрегатов родительского базового агрегата) 
        /// </summary>
        [TableColumn("AuditedObjectId")]
        public int AuditedObjectId { get; set; }

        public static PropertyInfo AuditedObjectIdProperty
        {
            get { return GetCurrentType().GetProperty("AuditedObjectId"); }
        }
        #endregion

        #region public SmartCoreType AuditedObjectType { get; set; }
        /// <summary>
        /// Обратная ссылка на Оператора
        /// </summary>
        [TableColumn("AuditedObjectTypeId")]
        public SmartCoreType AuditedObjectType { get; set; }

        public static PropertyInfo AuditedObjectTypeProperty
        {
            get { return GetCurrentType().GetProperty("AuditedObjectType"); }
        }
        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// Описание директивы
        /// </summary>
        [TableColumn("Description", 3072), ListViewData("Description")]
        public String Description { get; set; }
        #endregion

        #region public String CheckList { get; set; }
        /// <summary>
        /// Параметр Engineering orders
        /// </summary>
        [TableColumn("CheckList"), ListViewData("Check List")]
        public String CheckList { get; set; }
		#endregion

		#region public AttachedFile CheckListFile { get; set; }

		private AttachedFile _checkListFile;
		/// <summary>
		/// Связь с файлом описания инженерного ордера
		/// </summary>
		[ListViewData("Check List File")]
	    public AttachedFile CheckListFile
	    {
			get
			{
				return _checkListFile ?? (Files.GetFileByFileLinkType(FileLinkType.ProcedureCheckListFile));
			}
			set
			{
				_checkListFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ProcedureCheckListFile);
			}
		}

		#endregion

		#region  public AttachedFile ProcedureFile { get; set; }

		private AttachedFile _procedureFile;

		/// <summary>
		/// Связь с файлом описания директивы летной годности
		/// </summary>
		[ListViewData("Procedure File")]
	    public AttachedFile ProcedureFile
	    {
			get
			{
				return _procedureFile ?? (Files.GetFileByFileLinkType(FileLinkType.ProcedureFile));
			}
			set
			{
				_procedureFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ProcedureFile);
			}
		}

	    #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840)]
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

		#region public JobCard JobCard { get; set; }

		private JobCard _jobCard;

        /// <summary>
        /// Рабочая карта данной директивы
        /// </summary>
        [TableColumn("JobCard"), ListViewData("Job Card")]
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

        #region public int Level { get; set; }

        private int _level;

        /// <summary>
        /// </summary>
        [TableColumn("Level")]
        public int Level
        {
            get { return (_level < 1 || _level > 4) ? 4 : _level; }
            set { _level = value; }
        }

        public static PropertyInfo LevelProperty
        {
            get { return GetCurrentType().GetProperty("Level"); }
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
        [TableColumn("Threshold"), ListViewData("Threshold")]
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
        [TableColumn("Remarks", 512), ListViewData("Remarks")]
        [Filter("Remarks:", Order = 5)]
        public String Remarks { get; set; }
        #endregion

        #region public String HiddenRemarks { get; set; }
        /// <summary>
        /// Скрытые заметки
        /// </summary>
        [TableColumn("HiddenRemarks", 512), ListViewData("HiddenRemarks")]
        [Filter("Hidden Remarks:", Order = 6)]
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
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840, "Parent")]
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
        [Filter("Status:", Order = 9)]
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

        #region public CommonCollection<ProcedureDocumentReference> DocumentReferences

        private CommonCollection<ProcedureDocumentReference> _documentReferences;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ProcedureId", "Procedure")]
        public CommonCollection<ProcedureDocumentReference> DocumentReferences
        {
            get { return _documentReferences ?? (_documentReferences = new CommonCollection<ProcedureDocumentReference>()); }
            internal set
            {
                if (_documentReferences != value)
                {
                    if (_documentReferences != null)
                        _documentReferences.Clear();
                    if (value != null)
                        _documentReferences = value;
                }
            }
        }
		#endregion

		#region Implement of IMathData
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
                return ParentOperator;
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
        [Filter("Condition:", Order = 10)]
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
        [TableColumn("IsClosed")]
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
        [TableColumn("ManHours"), ListViewData("Man Hours"), MinMaxValue(0, 100000)]
        public Double ManHours { get; set; }
        #endregion

        #region public Double Elapsed { get; set; }
        /// <summary>
        /// Параметр полных трудозатрат 
        /// </summary>
        [TableColumn("Elapsed"), ListViewData("Elapsed"), MinMaxValue(0, 100000)]
        public Double Elapsed { get; set; }
        #endregion

        #region public Double Cost { get; set; }
        /// <summary>
        /// Стоимость выполения
        /// </summary>
        [TableColumn("Cost"), ListViewData("Cost"), MinMaxValue(0, 1000000000)]
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
            get
            {
                return string.Format("MPD.:{0}:{1}", Title, Description);
            }
        }
        #endregion

        #region public ICommonCollection<KitRequired> Kits

        private CommonCollection<AccessoryRequired> _kits;

	    [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840, "ParentObject")]
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
        [TableColumn("PrintInWP")]
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

        /*
        *  Методы 
        */


        #region public Procedure()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public Procedure()
        {
            SmartCoreObjectType = SmartCoreType.Procedure;
            //задаем все ID в -1
            ItemId = -1;

            // Ad директива
            ProcedureType = ProcedureType.Unknown;
            ProcedureRating = ProcedureRating.Unknown;
            // Задаем все String
            Title = Remarks = Description = HiddenRemarks = "";

            AuditedObjectId = -1;
            _performanceRecords = new BaseRecordCollection<DirectiveRecord>();
            _threshold = new MaintenanceDirectiveThreshold();

            PrintInWorkPackage = true;
            Level = 4;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(Procedure));
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

        #region public int CompareTo(Procedure y)

        public int CompareTo(Procedure y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is Procedure) return ItemId.CompareTo(((Procedure)y).ItemId);
            return 0;
        }
        #endregion

        #region public bool Equals(Procedure other)
        public bool Equals(Procedure other)
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
	}
}
