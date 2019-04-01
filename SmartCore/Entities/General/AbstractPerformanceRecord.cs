using System;
using System.Text;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Packages;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Абстрактный класс для всех записей
    /// </summary>
    [Serializable]
    public abstract class AbstractPerformanceRecord : AbstractRecord, IWorkPackageItemFilterParams
	{
        #region public abstract Int32 ParentId { get; set; }
        /// <summary>
        /// Родитель данной записи о выполнении
        /// </summary>
        public abstract Int32 ParentId { get; set; }
        #endregion

        #region public abstract Int32 PerformanceNum { get; set; }
        /// <summary>
        /// Номер записи о выполнении
        /// </summary>
        public abstract Int32 PerformanceNum { get; set; }
        #endregion

        #region public abstract SmartCoreType ParentType

        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        public abstract SmartCoreType ParentType { get; internal set; }
        #endregion

        #region public abstract IDirective Parent { get; set; }
        /// <summary>
        /// Родитель данной записи о выполнении
        /// </summary>
        public abstract IDirective Parent { get; set; }
        #endregion

        #region public abstract Lifelength Unused { get; set; }
        /// <summary>
        /// неизрасходованный ресурс 
        /// ресурс, на котором надо выполнить директиву - ресурс, на котором она была выполнена
        /// записываются только положительные значения, включая 0
        /// </summary>
        public abstract Lifelength Unused { get; set; }
        #endregion

        #region public abstract Lifelength Overused { get; set; }
        /// <summary>
        /// перерасходованный ресурс 
        /// ресурс, на котором она была выполнена - ресурс, на котором надо выполнить директиву 
        /// записываются только положительные значения, включая 0
        /// </summary>
        public abstract Lifelength Overused { get; set; }
        #endregion

        #region public abstract Int32 DirectivePackageId { get; set; }
        /// <summary>
        /// используется, только если запись создана в рамках выполнения пакета задач
        /// </summary>
        public abstract Int32 DirectivePackageId { get; set; }
        #endregion

        #region public abstract IDirectivePackage DirectivePackage { get; set; }
        /// <summary>
        /// используется, только если запись создана в рамках выполнения пакета задач (Рабочего пакета, Аудита и т.д.)
        /// </summary>
        public abstract IDirectivePackage DirectivePackage{ get; set; }
        #endregion

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

        #region public AtaChapter AtaChapter{ get; }
        /// <summary>
        /// Возвращает ATA главу выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public AtaChapter ATAChapter
		{
            get
            {
                if (Parent == null)
                {
                    return new AtaChapter { ItemId = -1 };
                }
                if (Parent is Directive)
                {
                    Directive d = Parent as Directive;
                    return d.ATAChapter;
                }
                if (Parent is ComponentDirective)
                {
                    ComponentDirective dd = Parent as ComponentDirective;
                    return dd.ParentComponent != null ? dd.ParentComponent.ATAChapter : new AtaChapter { ItemId = -1 };
                }
                if (Parent is Accessory.Component)
                {
                    Accessory.Component d = Parent as Accessory.Component;
                    return d.ATAChapter;
                }
                if (Parent is MaintenanceDirective)
                {
                    MaintenanceDirective d = Parent as MaintenanceDirective;
                    return d.ATAChapter;
                }
                return new AtaChapter { ItemId = -1 };
            }
        }

		#endregion

        #region public string Title { get; }
        /// <summary>
        /// Возвращает НАЗВАНИЕ выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public string Title
        {
            get
            {
                if (Parent == null)
                {
                    return "";
                }
                if (Parent is Directive)
                {
                    Directive d = Parent as Directive;
                    return d.Title;
                }
                if (Parent is ComponentDirective)
                {
                    ComponentDirective dd = Parent as ComponentDirective;
                    return dd.ParentComponent != null ? dd.ParentComponent.ToString() : "";
                }
                if (Parent is Accessory.Component)
                {
                    Accessory.Component d = Parent as Accessory.Component;
                    return d.ToString();
                }
                if (Parent is MaintenanceDirective)
                {
                    MaintenanceDirective d = Parent as MaintenanceDirective;
                    return d.ToString();
                }
                if (Parent is MaintenanceCheck)
                {
                    MaintenanceCheck mc = Parent as MaintenanceCheck;
                    return mc + (mc.Schedule ? " Schedule" : " Store");
                }
                return "";
            }
        }
        #endregion

        #region public string Description { get; }
        /// <summary>
        /// Возвращает описание выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public string Description
        {
            get
            {
                if (Parent == null)
                {
                    return "";
                }
                if (Parent is Directive)
                {
                    Directive d = Parent as Directive;
                    return d.Description;
                }
                if (Parent is ComponentDirective)
                {
                    ComponentDirective dd = Parent as ComponentDirective;
                    return dd.ParentComponent != null ? dd.ParentComponent.Description : "";
                }
                if (Parent is Accessory.Component)
                {
                    Accessory.Component d = Parent as Accessory.Component;
                    return d.Description;
                }
                if (Parent is MaintenanceDirective)
                {
                    MaintenanceDirective d = Parent as MaintenanceDirective;
                    return d.Description;
                }
                return "";
            }
        }
        #endregion

        #region public string WorkType { get; }
        /// <summary>
        /// Возвращает тип работ выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public string WorkType
        {
            get
            {
                if (Parent == null)
                {
                    return "";
                }
                if (Parent is Directive)
                {
                    Directive d = Parent as Directive;
                    return d.WorkType.ToString();
                }
                if (Parent is ComponentDirective)
                {
                    ComponentDirective dd = Parent as ComponentDirective;
                    return dd.DirectiveType.ToString();
                }
                if (Parent is Accessory.Component)
                {
                    return ComponentRecordType.Remove.ToString();
                }
                if (Parent is MaintenanceDirective)
                {
                    MaintenanceDirective dd = Parent as MaintenanceDirective;
                    return dd.WorkType.ToString();
                }
                if (Parent is MaintenanceCheck)
                {
                    MaintenanceCheck mc = Parent as MaintenanceCheck;
                    return mc.Schedule ? "Schedule" : "Store";
                }
                return "";
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
					if (Parent == null)
					{
						_ndtString = null;
					}
					else
					{
						if (Parent is ComponentDirective)
						{
							ComponentDirective dd = Parent as ComponentDirective;
							_ndtString = dd.NDTType.ShortName;
						}
						else if (Parent is MaintenanceDirective)
						{
							MaintenanceDirective mpd = Parent as MaintenanceDirective;
							_ndtString = mpd.NDTType.ShortName;
						}
						else if (Parent is Directive)
						{
							Directive d = Parent as Directive;
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

		#region public ICommonCollection<Kit> Kits { get; }
		/// <summary>
		/// Возвращает КИТы выполнения (как правило, берется из род. задачи)
		/// </summary>
		public ICommonCollection<AccessoryRequired> Kits
        {
            get { return Parent != null && Parent as IKitRequired != null ? ((IKitRequired)Parent).Kits : null; }
        }
        #endregion

        #region public string KitsToString { get; }
        /// <summary>
        /// Возвращает КИТы выполнения (как правило, берется из род. задачи)
        /// </summary>
        public string KitsToString
        {
            get
            {
                return Kits != null && Kits.Count > 0 ? Kits.Count + " kits" : "";
            }
        }
        #endregion

        #region public abstract AttachedFile AttachedFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract AttachedFile AttachedFile { get; set; }
        #endregion

        #region public string ToStrings(string dateSeparator = "-")
        /// <summary>
        /// Представляем запись ввиде строк. (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string ToStrings(string dateSeparator = "-")
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Auxiliary.Convert.GetDateFormat(RecordDate, dateSeparator));
            stringBuilder.AppendLine(OnLifelength.ToHoursMinutesAndCyclesStrings("FH", "FC"));
            return stringBuilder.ToString();
        }
		#endregion

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType {get;}

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get;}

		public Lifelength RepeatInterval { get { return Parent.Threshold.RepeatInterval ?? Lifelength.Null; } }

		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get;}

		public Lifelength FirstPerformanceSinceNew { get { return Parent.Threshold.FirstPerformanceSinceNew ?? Lifelength.Null; } }


		#endregion

		#region public bool HasKits { get;} 

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTString != "UNK"; } }

		#endregion

		#endregion
	}
}
