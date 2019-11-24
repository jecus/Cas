using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace SmartCore.Purchase
{
    /// <summary>
    /// Класс описывает запись в Начальном акте
    /// </summary>
    [Table("InitionalOrderRecords", "dbo", "ItemId")]
    [Dto(typeof(InitialOrderRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class InitialOrderRecord : BasePackageRecord, IDirective
    {
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public InitionalReason InitialReason { get; set; }

        private InitialReason _initialReason;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("InitialReason")]
        public InitialReason InitialReason
        {
            get { return _initialReason ?? (_initialReason = InitialReason.Unknown); }
            set { _initialReason = value; }
        }

        #endregion

        #region public Int32 DestinationObjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DestinationObjectID")]
        public Int32 DestinationObjectId { get; set; }
        #endregion

        #region public IDirective Task { get; set; }

        /// <summary>
        /// Задача, с которой связан продукт
        /// </summary>
        [ListViewData(0.12f, "Task", 4)]
        public IDirective Task
        {
            get { return PackageItem as IDirective; }
            set { PackageItem = value; }
        }

        #endregion

        #region public SmartCoreType DestinationObjectType{ get; set; }
        /// <summary>
        /// Тип объекта назначения
        /// </summary>
        [TableColumn("DestinationObjectType")]
        public SmartCoreType DestinationObjectType { get; set; }
        #endregion 

        #region public BaseEntityObject DestinationObject{ get; set; }
        /// <summary>
        /// Объект назначения
        /// </summary>
        public BaseEntityObject DestinationObject{ get; set; }
        #endregion 

        #region public String AccessoryPartNumber { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Part Number", 1)]
        public String AccessoryPartNumber
        {
            get { return Product != null ? Product.PartNumber : ""; } 
            set
            {
                if (Product != null)
                    Product.PartNumber = value;
            }
        }
        #endregion

        #region public String Product { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        [ListViewData(0.12f, "Description", 2)]
        public String AccessoryDescription
        {
            get { return Product != null ? Product.Description : ""; }
            set
            {
                if (Product != null)
                    Product.Description = value;
            }
        }
        #endregion

        #region public String AccessoryManufacturer { get; set; }
        /// <summary>
        /// производитель
        /// </summary>
        [ListViewData(0.12f, "Manufacturer", 3)]
        public String AccessoryManufacturer
        {
            get { return Product != null ? Product.Manufacturer : ""; }
            set
            {
                if (Product != null)
                    Product.Manufacturer = value;
            }
        }
        #endregion

        #region public String CostConditionString { get; set; }
        /// <summary>
        /// Состояние закупаемых комплектующих
        /// </summary>
        [ListViewData(0.12f, "Condition")]
        public String CostConditionString
        {
            get { return CostCondition.ToString(); }
        }
        #endregion

        #region public Measure Measure { get; set; }

        private Measure _measure;
        /// <summary>
        /// единица измерения
        /// </summary>
        [TableColumn("Measure")]
        [ListViewData(0.1f, "Measure")]
        public Measure Measure
        {
            get { return _measure ?? (_measure = Measure.Unit); }
            set
            {
                if (_measure != value)
                {
                    _measure = value;
                    OnPropertyChanged("Measure");
                }
            }
        }
        #endregion

        #region public double Quantity { get; set; }

        private double _quantity;
        /// <summary>
        /// количество 
        /// </summary>
        [TableColumn("Quantity")]
        [ListViewData(0.08f, "Q-ty")]
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        #endregion

        #region public string PerformanceToString { get; }
        /// <summary>
        /// Возвращает строковое представление количества "след. выполнений"
        /// </summary>
        [ListViewData(0.12f, "Performance", 5)]
        public string PerformanceToString
        {
            get
            {
                if (IsSchedule && Task != null)
                {
                    AbstractPerformanceRecord apr = PerformanceRecords
                        .OfType<AbstractPerformanceRecord>()
                        .FirstOrDefault(r => r.PerformanceNum == PerformanceNumFromStart);
                    if (apr != null)
                        return apr.OnLifelength.ToString();

                    NextPerformance np = NextPerformances
                        .FirstOrDefault(n => n.PerformanceNum == PerformanceNumFromStart);
                    if (np != null)
                        return np.PerformanceSource.ToString();
                    return "";
                }
                return RepeatInterval;
            }
        }
        #endregion

        #region public String RepeatInterval { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Rpt. Int", 6)]
        public String RepeatInterval
        {
            get 
            {
                if (IsSchedule && Task != null)
                    return Task.Threshold.RepeatInterval.ToString();
                return Threshold.RepeatInterval.ToString();
            }
        }
        #endregion

        #region public String PerformanceDateString { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Perf. Date", 8)]
        public String PerformanceDateString
        {
            get
            {
                if (IsSchedule && Task != null)
                {
                    AbstractPerformanceRecord apr = PerformanceRecords
                        .OfType<AbstractPerformanceRecord>()
                        .FirstOrDefault(r => r.PerformanceNum == PerformanceNumFromStart);
                    if (apr != null)
                        return Auxiliary.Convert.GetDateFormat(apr.RecordDate);

                    NextPerformance np = NextPerformances
                        .FirstOrDefault(n => n.PerformanceNum == PerformanceNumFromStart);
                    if (np != null)
                        return np.PerformanceDate == null
                            ? "N/A"
                            : Auxiliary.Convert.GetDateFormat((DateTime) np.PerformanceDate);
                    return "";
                }
                return NextPerformanceDate == null ? "N/A" : Auxiliary.Convert.GetDateFormat((DateTime)NextPerformanceDate);
            }
        }
		#endregion

		#region public ComponentStatus CostCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CostCondition")]
        public ComponentStatus CostCondition { get; set; }
        #endregion

        #region public DeferredCategory DeferredCategory { get; set; }

        private DeferredCategory _deferredCategory;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefferedCategory")]
        public DeferredCategory DeferredCategory
        {
            get { return _deferredCategory ?? (_deferredCategory = DeferredCategory.Unknown); }
            set { _deferredCategory = value; }
        }

        #endregion

        #region public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Дата вступления директивы в действие - дата выпуска директивы
        /// </summary>
        [TableColumn("EffectiveDate")]
        public DateTime EffectiveDate
        {
            get { return Threshold.EffectiveDate; }
            set { Threshold.EffectiveDate = value; }
        }
        #endregion

        #region public Lifelength LifeLimit { get; set; }
        /// <summary>
        /// Ограничение срока эксплуатации агрегата
        /// </summary>
        [TableColumn("LifeLimit")]
        public Lifelength LifeLimit
        {
            get { return Threshold.FirstPerformanceSinceEffectiveDate; }
            set { Threshold.FirstPerformanceSinceEffectiveDate = value; }
        }
        #endregion

        #region public Lifelength LifeLimitNotify { get; set; }
        /// <summary>
        /// Уведомление до ограничения срока эксплуатации агрегата
        /// </summary>
        [TableColumn("LifeLimitNotify")]
        public Lifelength LifeLimitNotify
        {
            get { return Threshold.FirstNotification; }
            set { Threshold.FirstNotification = value; }
        }
        #endregion

        #region public Product Product { get; set; }

        public Product Product { get; set; }
        #endregion

        #region public Int32 ProductId { get; set; }
        /// <summary>
        /// ID директивы хранящейся в пакете
        /// </summary>
        [TableColumn("ProductId")]
        public Int32 ProductId { get; set; }

        public static PropertyInfo ProductIdProperty
        {
            get { return GetCurrentType().GetProperty("ProductId"); }
        }

        #endregion

        #region public SmartCoreType ProductType { get; set; }
        /// <summary>
        /// Тип придукта, которой пренадлежит данная запись
        /// </summary>
        [TableColumn("ProductType")]
        public SmartCoreType ProductType { get; set; }

        public static PropertyInfo ProductTypeProperty
        {
            get { return GetCurrentType().GetProperty("ProductType"); }
        }

        #endregion

        #region  public Int32 PerformanceNumFromStart { get; set; }
        /// <summary>
        /// Порядковый номер выполнения данной записи о задаче от начала выполнения задачи
        /// </summary>
        [TableColumn("PerfNumFromStart")]
        public Int32 PerformanceNumFromStart { get; set; }
        #endregion

        #region public Int32 PerformanceNumFromRecord { get; set; }
        /// <summary>
        /// Порядковый номер выполнения данной записи о задаче от какого-то выполнения задачи 
        /// </summary>
        [TableColumn("PerfNumFromRecord")]
        public Int32 PerformanceNumFromRecord { get; set; }
        #endregion

        #region public Int32 FromRecordId { get; set; }
        /// <summary>
        /// Идентификатор записи, от которой отчитываются выполнения PerformanceNumFromRecord
        /// </summary>
        [TableColumn("FromRecordId")]
        public Int32 FromRecordId { get; set; }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Замечания по KIT - у 
        /// </summary>
        [ListViewData(0.12f, "Remarks")]
        public String AccessoryRemarks
        {
            get { return Product != null ? Product.Remarks : ""; }
            set
            {
                if (Product != null)
                    Product.Remarks = value;
            }
        }
        #endregion

        #region public bool IsSchedule{ get; set }

        private bool _isSchedule;
        /// <summary>
        /// Флаг, указывает как нужно производить расчет выполнения данной записи
        /// <br/>True - по связанной задаче. False - по собственным данным
        /// </summary>
        [TableColumn("IsSchedule")]
        public bool IsSchedule
        {
            get { return _isSchedule; }
            set
            {
                if (_isSchedule != value)
                {
                    _isSchedule = value;
                    OnPropertyChanged("IsSchedule");
                }
            }
        }
		#endregion

		[TableColumn("Priority")]
	    public Priority Priority
	    {
		    get { return _priority ?? Priority.UNK; }
		    set { _priority = value; }
	    }

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
            get { return IsSchedule && Task != null ? Task.LifeLengthParent : DestinationObject as Aircraft; }
        }
        #endregion

        #region IThreshold IDirective.Threshold { get; set; }
        
        private DirectiveThreshold _threshold;
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        public IThreshold Threshold
        {
            get { return IsSchedule && Task != null ? Task.Threshold : _threshold ?? (_threshold = new DirectiveThreshold()); }
            set { _threshold = value as DirectiveThreshold; }
        }
        #endregion

        #region public IRecordCollection PerformanceRecords { get; set; }

        private BaseRecordCollection<DirectiveRecord> _recordsCollection;
        /// <summary>
        /// Коллекция содержит все записи о выполнении директивы
        /// </summary>
        public IRecordCollection PerformanceRecords
        {
            get
            {
                return IsSchedule && Task != null 
                    ? Task.PerformanceRecords 
                    : _recordsCollection ?? (_recordsCollection = new BaseRecordCollection<DirectiveRecord>());
            }
        }
        #endregion

        #region public AbstractPerformanceRecord LastPerformance { get; }

        /// <summary>
        /// Доступ к последней записи о выполнении задачи
        /// </summary>
        public AbstractPerformanceRecord LastPerformance
        {
            get { return PerformanceRecords.GetLast() as AbstractPerformanceRecord; }
        }
        #endregion

        #region public List<NextPerformance> NextPerformances { get; set; }
        [NonSerialized]
        private List<NextPerformance> _nextPerformances;

	    private Priority _priority;

	    /// <summary>
        /// Список последующих выполнений задачи
        /// </summary>
        public List<NextPerformance> NextPerformances
        {
            get 
            {
                return IsSchedule && Task != null 
                    ?  Task.NextPerformances 
                    :  _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); 
            }
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
                if (IsSchedule && Task != null)
                    return Task.NextPerformance;
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
        [Filter("Status:", Order = 9)]
        public DirectiveStatus Status
        {
            get
            {
                if (IsClosed) return DirectiveStatus.Closed; //директива принудительно закрыта пользователем
                if (LastPerformance == null)
                {
                    if (!Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero() ||
                        !Threshold.FirstPerformanceSinceNew.IsNullOrZero())
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
        [Filter("Condition:", Order = 11)]
        public ConditionState Condition
        {
            get
            {
                if (NextPerformances.Count == 0) return ConditionState.NotEstimated;
                return NextPerformances[0].Condition;
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
                if (NextPerformances.Count == 0) 
                    return Lifelength.Null;
                return NextPerformances[0].PerformanceSource;
            }
        }
        #endregion

        #region public Lifelength Remains { get; set; }
        /// <summary>
        /// Возвращает остаток ресурса до ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        [ListViewData(0.12f, "Remain", 7)]
        public Lifelength Remains
        {
            get
            {
                if (NextPerformances.Count == 0) 
                    return Lifelength.Null;
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
                if (NextPerformances.Count == 0) 
                    return Lifelength.Null;
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

        #region public DateTime? NextPerformanceDate{ get; set; }
        /// <summary>
        /// Возвращает прблизительную дату ближайшего выполнения задачи (если оно расчитано) или null
        /// </summary>
        public DateTime? NextPerformanceDate
        {
            get
            {
                if (NextPerformances.Count == 0) return null;
                return NextPerformances[0].PerformanceDate;
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
            get { return NextPerformances.Count > 1 ? NextPerformances.Count : -1; }
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
                if (NextPerformances.Count == 0) 
                    return false;
                return NextPerformances[0].BlockedByPackage != null;
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

        #region public SupplierCollection Suppliers  { get; set; }
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 10)]
        public SupplierCollection Suppliers
        {
            get { return Product != null ? Product.Suppliers : null; }
        }
        #endregion

		#region public Boolean Processed { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Processed")]
        public Boolean Processed { get; set; }
		#endregion

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		[TableColumn("AirportCodeId")]
		public int AirportCodeId { get; set; }

		[TableColumn("Reference")]
		public string Reference { get; set; }

		public AirportsCodes AirportCode { get; set; }

		/*
		*  Методы 
		*/

		#region public InitionalOrderRecord()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public InitialOrderRecord()
        {
            ItemId = -1;
            ParentPackageId = -1;
            PackageItemId = -1;
            SmartCoreObjectType = SmartCoreType.InitialOrderRecord;
	        Threshold.EffectiveDate = DateTimeExtend.GetCASMinDateTime();

        }
        #endregion

        #region public InitialOrderRecord(int rfqId, Product accessory, double quantity, DateTime effDate, DetailStatus costCondition, NextPerformance perfornamce = null, DeferredCategory category = null):this()
        /// <summary>
        /// Создает запись  без дополнительной информации
        /// </summary>
        public InitialOrderRecord(int rfqId, Product accessory, double quantity,
                                  BaseEntityObject parent,
                                  DateTime effDate,
                                  ComponentStatus costCondition,
                                  NextPerformance perfornamce = null,
                                  DeferredCategory category = null):this()
        {
            ParentPackageId = rfqId;

            if(accessory != null)
            {
                ProductId = accessory.ItemId;
                ProductType = accessory.SmartCoreObjectType;
                EffectiveDate = effDate;
                DeferredCategory = category ?? DeferredCategory.Unknown;
                CostCondition = costCondition;
                _quantity = quantity;

                if (perfornamce != null)
                {
                    Task = perfornamce.Parent;
                    PackageItemId = perfornamce.Parent.ItemId;
                    PackageItemType = perfornamce.Parent.SmartCoreObjectType;
                    PerformanceNumFromStart = perfornamce.PerformanceNum;
                    IsSchedule = true;
                }
                if (DeferredCategory != DeferredCategory.Unknown && DeferredCategory.Threshold != null)
                {
                    LifeLimit = DeferredCategory.Threshold.FirstPerformanceSinceEffectiveDate;
                    LifeLimitNotify = DeferredCategory.Threshold.FirstNotification;
                    IsSchedule = false;
                }
                if (parent != null && !parent.SmartCoreObjectType.Equals(SmartCoreType.Operator))
                {
                    DestinationObject = parent;
                    DestinationObjectType = parent.SmartCoreObjectType;
                    DestinationObjectId = parent.ItemId;
                }
            }
            else
            {
                PackageItemId = -1;
                EffectiveDate = DateTime.Today;
                costCondition = ComponentStatus.Unknown;
                PackageItemType = SmartCoreType.Unknown;
                DeferredCategory = DeferredCategory.Unknown;
                _quantity = 0;
                Task = null;
                ProductId = -1;
                ProductType = SmartCoreType.Unknown;
                PerformanceNumFromStart = -1;
                IsSchedule = false;
            }
        }
		#endregion

		public InitialOrderRecord(int rfqId, Product accessory, double quantity) : this()
		{
			ParentPackageId = rfqId;

			if (accessory != null)
			{
				ProductId = accessory.ItemId;
				ProductType = accessory.SmartCoreObjectType;
				_quantity = quantity;
			}
			else
			{
				PackageItemId = -1;
				EffectiveDate = DateTime.Today;
				PackageItemType = SmartCoreType.Unknown;
				DeferredCategory = DeferredCategory.Unknown;
				_quantity = 0;
				Task = null;
				ProductId = -1;
				ProductType = SmartCoreType.Unknown;
				PerformanceNumFromStart = -1;
				IsSchedule = false;
			}
		}

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(InitialOrderRecord));
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

    }

}
