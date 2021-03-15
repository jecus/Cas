using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Accessory
{
    [Table("ComponentLLPCategoryData", "dbo", "ItemId")]
    [Dto(typeof(ComponentLLPCategoryDataDTO))]
    [Condition("IsDeleted", "0")]
	[Serializable]
    public class ComponentLLPCategoryData : BaseEntityObject
    {
        private static Type _thisType;

		#region public Int32 ComponentId { get; set; }
		/// <summary>
		/// Id родительской детали 
		/// </summary>
		[TableColumnAttribute("ComponentId")]
        public Int32 ComponentId { get; set; }

        public static PropertyInfo ComponentIdProperty
        {
            get { return GetCurrentType().GetProperty("ComponentId"); }
        }

        #endregion

        #region public Lifelength LLPLifelength { get; set; }
        /// <summary>
        /// Наработка агрегата
        /// </summary>
        [TableColumnAttribute("LLPLifelength")]
        public Lifelength LLPLifelength
        {
            get; 
            set;
        }
		#endregion

		#region public Lifelength LLPLifeLengthCurrent { get; set; }

	    /// <summary>
	    /// Наработка агрегата
	    /// </summary>
	    [TableColumnAttribute("LLPLifeLengthCurrent")]
	    public Lifelength LLPLifelengthCurrent
	    {
		    get { return _llpLifelengthCurrent ?? Lifelength.Null; }
		    set { _llpLifelengthCurrent = value; }
	    }

		#endregion

		#region public Lifelength LLPTemp

		[TableColumn("LLPTemp")]
	    public Lifelength LLPTemp
	    {
		    get { return _llpTemp ?? Lifelength.Null; }
		    set { _llpTemp = value; }
	    }

	    #endregion

		#region public Lifelength LLPCurrent

		public Lifelength LLPCurrent
	    {
		    get { return _llpCurrent; }
		    set { _llpCurrent = value; }
	    }

		    #endregion

	    #region public Lifelength LLPLifeLengthForDate { get; set; }

		[TableColumnAttribute("LLPLifeLengthForDate")]
	    public Lifelength LLPLifeLengthForDate
	    {
		    get { return _llpLifeLengthForDate ?? Lifelength.Null; }
		    set { _llpLifeLengthForDate = value; }
	    }

	    #endregion

		#region public DateTime Date { get; set; }

		[TableColumn("Date")]
	    public DateTime FromDate
	    {
		    get { return _date > DateTimeExtend.GetCASMinDateTime() ? _date : DateTimeExtend.GetCASMinDateTime(); }
		    set
		    {
			    var min = DateTimeExtend.GetCASMinDateTime();
			    if (_date < min || _date != value)
				    _date = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
		    }
	    }

		    #endregion

	    #region public Lifelength LLPLifeLimit { get; set; }
		/// <summary>
		/// Наработка агрегата
		/// </summary>
		[TableColumnAttribute("LLPLifeLimit")]
        public Lifelength LLPLifeLimit { get; set; }
        #endregion

        #region public Lifelength Notify { get; set; }
        /// <summary>
        /// Время, за которое надо предупредить об окончании ресурса агрегата
        /// </summary>
        [TableColumnAttribute("Notify")]
        public Lifelength Notify { get; set; }
        #endregion

        #region public Lifelength Remain { get; set; }
        /// <summary>
        /// Остаток ресурса
        /// </summary>
        public Lifelength Remain { get; set; }
        #endregion

        #region public LLPLifeLimitCategory ParentCategory { get; set; }

        private LLPLifeLimitCategory _llpLifeLimitCategory;
	    private DateTime _date;
	    private Lifelength _llpLifeLengthForDate;
	    private Lifelength _llpLifelengthCurrent;
	    private Lifelength _llpTemp;
	    private Lifelength _llpCurrent;

	    /// <summary>
        /// родителькая категория
        /// </summary>
        [TableColumnAttribute("LLPCategoryId")]
        public LLPLifeLimitCategory ParentCategory
        {
            get { return _llpLifeLimitCategory ?? (_llpLifeLimitCategory = LLPLifeLimitCategory.Unknown); }
            set
            {
                if(_llpLifeLimitCategory != value)
                {
                    _llpLifeLimitCategory = value;
                    OnPropertyChanged("ParentCategory");
                }
            }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return LLPLifelength.ToString();
        }
        #endregion

        #region public int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is ComponentLLPCategoryData) return ItemId.CompareTo(((ComponentLLPCategoryData)y).ItemId);
            return 0;
        }
		#endregion

		#region public ComponentLLPCategoryData()
		/// <summary>
		/// Конструктор создает объект с параметрами по умолчанию
		/// </summary>
		public ComponentLLPCategoryData()
        {
            ItemId = -1;
            ComponentId = -1;
            ParentCategory = LLPLifeLimitCategory.Unknown;
            LLPLifeLimit = Lifelength.Null;
            LLPLifelength = Lifelength.Null;
            Notify = Lifelength.Null;
            SmartCoreObjectType = SmartCoreType.ComponentLLPCategoryData;
        }
		#endregion

		#region public ComponentLLPCategoryData(ComponentLLPCategoryData copyData) : this()
		/// <summary>
		/// Конструктор создает объект с параметрами по умолчанию
		/// </summary>
		public ComponentLLPCategoryData(ComponentLLPCategoryData copyData) : this()
        {
            ComponentId = copyData.ComponentId;
            ParentCategory = copyData.ParentCategory;
            LLPLifelength = new Lifelength(copyData.LLPLifelength);
            LLPLifeLimit = new Lifelength(copyData.LLPLifeLimit);
            Notify = new Lifelength(copyData.Notify);
            Remain = new Lifelength(copyData.Remain);
            ParentCategory = copyData.ParentCategory;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(ComponentLLPCategoryData));
        }
        #endregion

        public new ComponentLLPCategoryData GetCopyUnsaved(bool marked = true)
        {
            ComponentLLPCategoryData componentLLP = (ComponentLLPCategoryData) MemberwiseClone();
            componentLLP.ItemId = -1;
            componentLLP.UnSetEvents();

            componentLLP.LLPLifelength =new Lifelength(LLPLifelength);
            componentLLP.LLPLifeLimit =new Lifelength(LLPLifeLimit);
            componentLLP.Notify =new Lifelength(Notify);
            componentLLP.Remain =new Lifelength(Remain);
            componentLLP.LLPLifelengthCurrent = new Lifelength(LLPLifelengthCurrent);
            componentLLP.LLPLifeLengthForDate = new Lifelength(LLPLifeLengthForDate);
            componentLLP.FromDate = FromDate;

            return componentLLP;
        }
    }
}
