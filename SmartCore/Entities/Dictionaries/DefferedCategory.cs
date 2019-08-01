using System;
using System.Reflection;
using EntityCore.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Table("DefferedCategories","Dictionaries","ItemId")]
	[Dto(typeof(DefferedCategorieDTO))]
    [Condition("IsDeleted", "0")]
	[Serializable]
    public class DeferredCategory : AbstractDictionary
    {
        private static DeferredCategory _unknown;

        private static Type _thisType;

        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        private string _fullName;
        /// <summary>
        /// Полное название Эшелона
        /// </summary>
        [TableColumn("CategoryName")]
        [FormControl(150, "Category Name", 1, Order = 1)]
        [ListViewData(0.2f, "Category Name", 1)]
        [NotNull]
        public override string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        #endregion

        #region public override string ShortName { get; set; }

        public override string ShortName
        {
            get { return FullName; }
            set { FullName = value; }
        }

        #endregion

        #region public override string CommonName

        public override string CommonName
        {
            get { return FullName; }
            set { FullName = value; }
        }

        #endregion

        #region public override string Category
        /// <summary>
        /// Категория не сохраняется 
        /// </summary>
        public override string Category { get; set; }
        #endregion

        #endregion

        #region  public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [TableColumnAttribute("AircraftModelId")]
        [Child(false)]
        public AircraftModel AircraftModel { get; set; }

        public static PropertyInfo AircraftModelProperty
        {
            get { return GetCurrentType().GetProperty("AircraftModel"); }
        }
        #endregion

        #region public DirectiveThreshold Threshold { get; private set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        [TableColumnAttribute("Threshold")]
        public DirectiveThreshold Threshold { get; private set; }
        #endregion

        #region public static DefferedCategory Unknown
        /// <summary>
        /// Возвращает неизвестную категорию
        /// </summary>
        public static DeferredCategory Unknown
        {
            get
            {
                return _unknown ??
                       (_unknown = new DeferredCategory
                       {
                           IsDeleted = false,
                           ItemId = -1,
                           FullName = "Unknown",
                           AircraftModel = AircraftModel.Unknown,
                           Threshold = new DirectiveThreshold()
                       });
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
            return FullName;
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is DeferredCategory)
                return String.Compare(FullName, ((DeferredCategory)y).FullName, StringComparison.Ordinal);
            return 0;
        }
        #endregion

        #region public DefferedCategory()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public DeferredCategory()
        {
            IsDeleted = false;
            SmartCoreObjectType = SmartCoreType.DeferredCategory;
            _fullName = "";
            AircraftModel = null;
            Threshold = new DirectiveThreshold{
                FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst,
                FirstPerformanceSinceEffectiveDate = Lifelength.Null,PerformSinceNew = true, PerformSinceEffectiveDate = true};
        }
        #endregion

        #region public DefferedCategory(Int32 itemID, String categoryName, AircraftModel aircraftModel, DirectiveThreshold threshold)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="categoryName"></param>
        /// <param name="aircraftModel"></param>
        /// <param name="threshold"></param>
        public DeferredCategory(Int32 itemId, String categoryName, AircraftModel aircraftModel, DirectiveThreshold threshold)
        {
            IsDeleted = false;
            ItemId = itemId;
            _fullName = categoryName;
            AircraftModel = aircraftModel;
            Threshold = threshold;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(DeferredCategory));
        }
        #endregion

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is DeferredCategory)
                SetProperties((DeferredCategory)dictionary);
        }
        #endregion

        #region public void SetProperties(DefferedCategory dictionary)
        public void SetProperties(DeferredCategory dictionary)
        {
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
            Threshold = dictionary.Threshold;
        }
        #endregion
    }
}
