using System;
using System.Text;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Quality;
using SmartCore.Packages;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Класс, описывает след выполнение задачи
    /// </summary>
    [Serializable]
    public class NextPerformance : BaseEntityObject, IWorkPackageItemFilterParams, IForecastMtopFilterParams
	{
        #region public DateTime? PrevPerformanceDate { get; set; }
        /// <summary>
        /// Приблизительная дата предыдущего выполнения
        /// </summary>
        public DateTime? PrevPerformanceDate { get; set; }
        #endregion

        #region public Lifelength PrevPerformanceSource { get; set; }

        private Lifelength _prevPerformanceSource;
        /// <summary>
        /// Ресурс, на котором произошло (произойдет) пред. выполнение
        /// </summary>
        public Lifelength PrevPerformanceSource
        {
            get { return _prevPerformanceSource ?? (_prevPerformanceSource = Lifelength.Null); }
            set { _prevPerformanceSource = value; }
        }
        #endregion

        #region public DateTime? PerformanceDate { get; set; }
        /// <summary>
        /// Приблизительная дата выполнения
        /// </summary>
        public DateTime? PerformanceDate { get; set; }
        #endregion

        #region public DateTime? NextPerformanceDate { get; set; }
        /// <summary>
        /// Приблизительная дата следующего выполнения
        /// </summary>
        public DateTime? NextPerformanceDate { get; set; }
        #endregion

        #region public Lifelength NextPerformanceSource { get; set; }

        private Lifelength _nextPerformanceSource;
        /// <summary>
        /// Ресурс, на котором произойдет след. выполнение
        /// </summary>
        public Lifelength NextPerformanceSource
        {
            get { return _nextPerformanceSource ?? (_nextPerformanceSource = Lifelength.Null); }
            set { _nextPerformanceSource = value; }
        }
        #endregion

        #region public int PerformanceNum { get; set; }
        /// <summary>
        /// Порядковый номер выполнения
        /// </summary>
        public int PerformanceNum { get; set; }
        #endregion

        #region public Lifelength PerformanceSource { get; set; }

        private Lifelength _performanceSource;
        /// <summary>
        /// Ресурс, на котором произойдет выполнение
        /// </summary>
        public Lifelength PerformanceSource
        {
            get { return _performanceSource ?? (_performanceSource = Lifelength.Null); }
            set { _performanceSource = value; }
        }
        #endregion

        #region public Lifelength Remains { get; set; }
        /// <summary>
        /// остаток до выполнения (до NextPerformanceSource)
        /// </summary>
        public Lifelength Remains { get; set; }
		#endregion

		public Lifelength WarrantlyRemains { get; set; }

		public Lifelength LimitNotify { get; set; }
		public Lifelength LimitOverdue { get; set; }

		public int Group { get; set; }
		public MTOPCheck ParentCheck { get; set; }

		#region public Lifelength BeforeForecastResourceRemain { get; set; }
		/// <summary>
		/// Остаток ресурса между точкой прогноза и последним выполнением(или начальной точки) до прогноза (вычисляется только в прогнозе)
		/// </summary>
		public Lifelength BeforeForecastResourceRemain { get; set; }
        #endregion

        #region public ConditionState Condition { get; set; }
        /// <summary>
        /// Текущее состояние задачи
        /// </summary>
        [Filter("Condition:")]
        public ConditionState Condition { get; set; }
        #endregion

        #region public DirectiveStatus Status { get; set; }

        private DirectiveStatus _status;
        /// <summary>
        /// Текущее состояние задачи
        /// </summary>
        [Filter("Status:")]
        public DirectiveStatus Status
        {
            get { return _status; }
        }
        #endregion

        #region public IDirective Parent { get; set; }

        private IDirective _parent;
        /// <summary>
        /// Родительская задача
        /// </summary>
        public IDirective Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                UpdateInformation();
            }
        }
        #endregion

        #region public AtaChapter AtaChapter{ get; }

        private AtaChapter _ataChapter;
        /// <summary>
        /// Возвращает ATA главу выполнения (как правило, берется описание род. задачи)
        /// </summary>
        [Filter("ATA Chapter:")]
        public AtaChapter ATAChapter
		{
            get { return _ataChapter; }
        }
        #endregion

        #region public virtual string Title { get; }

        private string _title;
        /// <summary>
        /// Возвращает НАЗВАНИЕ выполнения (как правило, берется описание род. задачи)
        /// </summary>
        [Filter("Title:",Order = 1)]
        public virtual string Title
        {
            get { return _title; }
        }
        #endregion

        #region public string Description { get; }

        private string _description;
        /// <summary>
        /// Возвращает описание выполнения (как правило, берется описание род. задачи)
        /// </summary>
        [Filter("Description:", Order = 2)]
        public string Description
        {
            get { return _description; }
        }

		#endregion

        #region public String TaskRemarks { get; }

        private string _taskRemarks;
        /// <summary>
        /// Заметки по родительской задаче
        /// </summary>
        //[Filter("Remarks:", Order = 3)]
        public String TaskRemarks
        {
            get { return _taskRemarks; }
        }
        #endregion

        #region public String TaskHiddenRemarks { get; }

        private string _taskHiddenRemarks;
        /// <summary>
        /// дополнительные заметки по родительской задаче
        /// </summary>
        //[Filter("Hidden Remarks:", Order = 4)]
        public String TaskHiddenRemarks
        {
            get { return _taskHiddenRemarks; }
        }
        #endregion

        #region public SmartCoreType SmartCoreType { get; set; }

        private SmartCoreType _smartCoreType;
		/// <summary>
        /// Тип родительской задачи
        /// </summary>
        [Filter("Task type:", Order = 5)]
        public SmartCoreType SmartCoreType
        {
            get { return _smartCoreType; }
        }
        #endregion

        #region public MaintenanceCheckType _maintenanceCheckType { get; set; }

        private MaintenanceCheckType _maintenanceCheckType = MaintenanceCheckType.Unknown;
        /// <summary>
        /// Возвращает тип чека, если родительской задачей является Чек программы обслуживания или MaintenanceCheckType.Unknown
        /// </summary>
        [Filter("Check type:", Order = 6)]
        public MaintenanceCheckType MaintenanceCheckType
        {
            get { return _maintenanceCheckType; }
        }
        #endregion

        #region public string Type { get; }

        private string _type;
        /// <summary>
        /// Возвращает тип родительской задачи (AD, MPD, HT и т.д.) (как правило, берется описание род. задачи)
        /// </summary>
        public string Type
        {
            get
            {
                if (string.IsNullOrEmpty(_type))
                {
                    if (_parent == null)
                    {
                        _type = "UNK";
                    }
                    else
                    {
                        if (_parent is Directive)
                        {
                            Directive d = _parent as Directive;
                            _type = d.DirectiveType.ShortName;
                        }
                        else if (_parent is ComponentDirective)
                        {
                            ComponentDirective dd = _parent as ComponentDirective;
                            _type = dd.ParentComponent != null ? dd.ParentComponent.MaintenanceControlProcess.ToString() : "UNK";
                        }
                        else if (_parent is Entities.General.Accessory.Component)
                        {
                            _type = ((Entities.General.Accessory.Component)_parent).MaintenanceControlProcess.ShortName;
                        }
                        else if (_parent is MaintenanceDirective)
                        {
                            MaintenanceDirective mpd = _parent as MaintenanceDirective;
                            _type = mpd.MaintenanceCheck != null ? mpd.MaintenanceCheck.Name : "MPD";
                        }
                        else if (_parent is MaintenanceCheck)
                        {
                            MaintenanceCheck mc = _parent as MaintenanceCheck;
                            if (mc.Grouping && this is MaintenanceNextPerformance)
                            {
                                MaintenanceNextPerformance mnp = this as MaintenanceNextPerformance;
                                _type = mnp != null ? mnp.PerformanceGroup.GetGroupName() : mc.Name;
                            }
                            else _type = mc.Name;
                        }
                    }
                }
                return _type;
            }
        }
		#endregion

		#region public string NDTString { get; set; }

	    private string _ndtString;

	    public string NDTString
	    {
		    get
		    {
			    if (string.IsNullOrEmpty(_ndtString))
			    {
					if (_parent == null)
					{
						_ndtString = null;
					}
					else
					{
						if (_parent is ComponentDirective)
						{
							ComponentDirective dd = _parent as ComponentDirective;
							_ndtString = dd.NDTType.ShortName;
						}
						else if (_parent is MaintenanceDirective)
						{
							MaintenanceDirective mpd = _parent as MaintenanceDirective;
							_ndtString = mpd.NDTType.ShortName;
						}
						else if (_parent is Directive)
						{
							Directive d = _parent as Directive;
							_ndtString = d.NDTType.ShortName;
						}
						else
						{
							_ndtString = null;
						}
					}
				}
			   
				return _ndtString;
			}
	    }

	    #endregion

        #region public string WorkType { get; }

        private string _workType;
        /// <summary>
        /// Возвращает тип работ выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public string WorkType
        {
            get {  return _workType; }
        }
        #endregion

        #region public virtual ICommonCollection<Kit> Kits { get; }
        /// <summary>
        /// Возвращает КИТы выполнения (как правило, берется из род. задачи)
        /// </summary>
        public virtual ICommonCollection<AccessoryRequired> Kits
        {
            get { return Parent != null && Parent as IKitRequired != null ? ((IKitRequired)Parent).Kits : null; }
        }
        #endregion

        #region public virtual string KitsToString { get; }
        /// <summary>
        /// Возвращает КИТы выполнения (как правило, берется из род. задачи)
        /// </summary>
        public virtual string KitsToString
        {
            get
            {
                return Kits != null && Kits.Count > 0 ? Kits.Count + " kits" : "";
            }
        }
        #endregion

        #region public Lifelength FirstPerformanceSinceNew { get; }

        private Lifelength _firstPerformanceSinceNew;
        /// <summary>
        /// Условие первого выполнения с момента производства детали/ВС
        /// </summary>
        [Filter("1st. Perf:")]
        public Lifelength FirstPerformanceSinceNew
        {
            get { return _firstPerformanceSinceNew ?? (_firstPerformanceSinceNew = Lifelength.Null); }
        }
        #endregion

        #region public Lifelength RepeatInterval{ get; }

        private Lifelength _repeatInterval;
        /// <summary>
        /// Интервал выполнения директивы
        /// </summary>
        [Filter("Rpt. Int:")]
        public Lifelength RepeatInterval
        {
            get { return _repeatInterval ?? (_repeatInterval = Lifelength.Null); }
        }

		#endregion

        #region public MaintenanceCheck MaintenanceCheck { get; }

        private MaintenanceCheck _check;
        /// <summary>
        /// Чек программы обслуживания, к которому привязана задача
        /// </summary>
        [Filter("Check:", Order = 7)]
        public MaintenanceCheck MaintenanceCheck
        {
            get { return _check; }
        }
        #endregion

        #region public IDirectivePackage BlockedByPackage { get; set; }
        /// <summary>
        /// Рабочий пакет, в котором задеиствовано данное выполнение
        /// </summary>
        public IDirectivePackage BlockedByPackage { get; set; }
		#endregion

		#region public bool HasKits { get;}

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTString != "UNK"; } }

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
        {
            if (_parent == null)
            {
                _ataChapter = new AtaChapter { ItemId = -1 };
                _title = _description = _type = _workType = _taskRemarks = _taskHiddenRemarks = "";
                _smartCoreType = SmartCoreType.Unknown;
            }
            else
            {
                _firstPerformanceSinceNew = _parent.Threshold.FirstPerformanceSinceNew;
                _repeatInterval = _parent.Threshold.RepeatInterval;
                _status = _parent.Status;

                if (_parent is Directive)
                {
                    Directive d = _parent as Directive;

                    _ataChapter = d.ATAChapter;
                    _title = d.Title + " | " + d.EngineeringOrders;
                    _description = d.Description + (string.IsNullOrEmpty(d.Paragraph) ? "" : " " + d.Paragraph);
                    _workType = d.WorkType.ToString();
                    _type = d.DirectiveType.ShortName;
                    _taskRemarks = d.Remarks;
                    _taskHiddenRemarks = d.HiddenRemarks;
                    _smartCoreType = SmartCoreType.Directive;
                }
                else if (_parent is ComponentDirective)
                {
                    ComponentDirective dd = _parent as ComponentDirective;

                    if (dd.ParentComponent != null)
                    {
                        if (dd.MaintenanceDirective != null)
                        {
                            _ataChapter = dd.MaintenanceDirective.ATAChapter;
                            _title = dd.MaintenanceDirective.TaskNumberCheck + " for " + dd.ParentComponent;
                            _description = dd.MaintenanceDirective.Description;
                            _workType = dd.MaintenanceDirective.WorkType.ToString();
                            _taskRemarks = dd.MaintenanceDirective.Remarks;
                            _taskHiddenRemarks = dd.MaintenanceDirective.HiddenRemarks;
                        }
                        else
                        {
                            _ataChapter = dd.ParentComponent.ATAChapter;
                            _title = dd.ParentComponent.ToString();
                            _description = dd.ParentComponent.Description;
                            _workType = dd.DirectiveType.ToString();
                            _taskRemarks = dd.Remarks;
                            _taskHiddenRemarks = dd.HiddenRemarks;
                        }
                        _type = dd.ParentComponent.MaintenanceControlProcess.ToString();
                    }
                    else
                    {
                        _title = "";
                        _description = "";
                        _workType = "";
                        _type = "";
                        _taskRemarks = "";
                        _taskHiddenRemarks = "";
                    }
                    _smartCoreType = SmartCoreType.ComponentDirective;
                }
                else if (_parent is Entities.General.Accessory.Component)
                {
                    Entities.General.Accessory.Component d = _parent as Entities.General.Accessory.Component;
                    _ataChapter = d.ATAChapter;
                    _title = d.ToString();
                    _description = d.Description;
                    _workType = ComponentRecordType.Remove.ToString();
                    _type = d.MaintenanceControlProcess.ShortName;
                    _taskRemarks = d.Remarks;
                    _taskHiddenRemarks = d.HiddenRemarks;
                    _smartCoreType = SmartCoreType.Component;
                }
                else if (_parent is MaintenanceDirective)
                {
                    MaintenanceDirective md = _parent as MaintenanceDirective;
                    _ataChapter = md.ATAChapter;
                    _title = md.ToString();
                    _description = md.Description;
                    _workType = md.WorkType.ToString();
                    _type = md.MaintenanceCheck != null ? md.MaintenanceCheck.Name : "MPD";
                    _check = md.MaintenanceCheck;
                    _taskRemarks = md.Remarks;
                    _taskHiddenRemarks = md.HiddenRemarks;
                    _smartCoreType = SmartCoreType.MaintenanceDirective;
                }
                else if (_parent is Procedure)
                {
                    Procedure md = _parent as Procedure;
                    _ataChapter = new AtaChapter { ItemId = -1 };
                    _title = md.Title;
                    _description = md.Description;
                    _workType = md.ProcedureType.ToString();
                    _type = "Procedure";
                    _taskRemarks = md.Remarks;
                    _taskHiddenRemarks = md.HiddenRemarks;
                    _smartCoreType = SmartCoreType.Procedure;
                }
                else if (_parent is MaintenanceCheck)
                {
                    MaintenanceCheck mc = _parent as MaintenanceCheck;
                    _ataChapter = new AtaChapter { ItemId = -1 };
                    _title = mc.ToString();
                    _workType = mc.Schedule ? "Schedule" : "Store";
                    _smartCoreType = SmartCoreType.MaintenanceCheck;
                    _maintenanceCheckType = mc.CheckType;
                    _taskRemarks = "";
                    _taskHiddenRemarks = "";
                }
            }
        }
        #endregion

        #region public DateTime GetPerformanceDateOrDefault()
        /// <summary>
        /// Возвращает дату выполнения или дату по умолчанию
        /// </summary>
        /// <returns></returns>
        public DateTime GetPerformanceDateOrDefault()
        {
            return PerformanceDate.HasValue ? PerformanceDate.Value : DateTimeExtend.GetCASMinDateTime();
        }

        #endregion

        #region public new NextPerformance GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        public new NextPerformance GetCopyUnsaved()
        {
            NextPerformance newObject = (NextPerformance)MemberwiseClone();
            newObject.ItemId = -1;
            newObject.PrevPerformanceSource = new Lifelength(PrevPerformanceSource);
            newObject.NextPerformanceSource = new Lifelength(NextPerformanceSource);
            newObject.PerformanceSource = new Lifelength(PerformanceSource);
            newObject.Remains = new Lifelength(Remains);
            newObject.BeforeForecastResourceRemain = new Lifelength(BeforeForecastResourceRemain);

            return newObject;
        }
        #endregion

        #region public override string ToString()

        public override string ToString()
        {
            string result = "";
            if (PerformanceDate != null)
                result = Auxiliary.Convert.GetDateFormat(PerformanceDate.Value) + " ";
            if (PerformanceDate != null && !PerformanceSource.IsNullOrZero())
                result += PerformanceSource.ToString();
            return result;

        }
        #endregion

        #region public string ToStrings()
        /// <summary>
        /// Представляем запись ввиде строк. (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string ToStrings(string dateSeparator = "-")
        {
            StringBuilder stringBuilder = new StringBuilder();
            if(PerformanceDate != null)
                stringBuilder.AppendLine(Auxiliary.Convert.GetDateFormat(PerformanceDate.Value, dateSeparator));
            if (PerformanceSource != null && !PerformanceSource.IsNullOrZero())
                stringBuilder.AppendLine(PerformanceSource.ToHoursMinutesAndCyclesStrings("FH", "FC"));
            return stringBuilder.ToString();
        }
        #endregion  
    }
}
