using System;
using System.Reflection;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает категорию работы вращающихся агрегатов на самолетах выше B737-300
    /// </summary>
    [Table("LifeLimitCategories", "Dictionaries", "ItemId")]
	[Dto(typeof(LifeLimitCategorieDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class LLPLifeLimitCategory : AbstractDictionary
    {
        private static Type _thisType;

        private static LLPLifeLimitCategory _unknown;

        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        /// <summary>
        /// Полное название Категории
        /// </summary>
        public override string FullName { get; set; }

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

        #region public override String Category { get; set; }

        private string _category;
        /// <summary>
        /// Название типа катеогрии для данной модели самолета (A - 3A1, B - 3B2 и т.д.)
        /// </summary>
        [TableColumnAttribute("CategoryName")]
        public override String Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        #endregion

        #endregion

        #region public LLPLifeLimitCategoryType CategoryType { get; set; }

        private LLPLifeLimitCategoryType _categoryType;
        /// <summary>
        /// Типа категории (A,B,C,D) 
        /// </summary>
        [TableColumnAttribute("CategoryType")]
        public LLPLifeLimitCategoryType CategoryType
        {
            get { return _categoryType ?? (_categoryType = LLPLifeLimitCategoryType.Unknown); }
            set
            {
                if (_categoryType != value)
                {
                    _categoryType = value;
                    OnPropertyChanged("CategoryType");
                }
            }
        }
        #endregion

        #region  public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Модель самолета
        /// </summary>
        [TableColumnAttribute("AircraftModelId")]
        [Child(false)]
        public AircraftModel AircraftModel { get; set; }

        public static PropertyInfo AircraftModelProperty
        {
            get { return GetCurrentType().GetProperty("AircraftModel"); }
        }

        #endregion

        #region char GetChar()
        ///<summary>
        /// возвращает первую букву из типа категории
        ///</summary>
        ///<returns></returns>
        public char GetChar()
        {
            return char.ToUpper(CategoryType.FullName.ToCharArray()[0]);
        }
        #endregion

        #region public static LLPLifeLimitCategory Unknown
        /// <summary>
        /// Возвращает неизвестную категорию работы вращающихся агрегатов на самолетах выше B737-300
        /// </summary>
        public static LLPLifeLimitCategory Unknown
        {
            get
            {
                return _unknown ??
                       (_unknown = new LLPLifeLimitCategory
                       {
                           FullName = "Unknown",
                           ShortName = "UNK",
                           Category = "UNK",
                           CommonName = "Unknown",
                           CategoryType = LLPLifeLimitCategoryType.Unknown,
                           AircraftModel = AircraftModel.Unknown
                       });
            }
        }
        #endregion

        #region public LLPLifeLimitCategory()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public LLPLifeLimitCategory()
        {
            SmartCoreObjectType = SmartCoreType.LLPLifeLimitCategory;
            IsDeleted = false;
            ItemId = -1;
            _category = "";
            AircraftModel = new AircraftModel();
            
        }
        #endregion

        #region public LLPLifeLimitCategory(LLPLifeLimitCategoryType categoryType, String categoryName, AircraftModel aircraftModel) : this()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="categoryType"></param>
        /// <param name="categoryName"></param>
        /// <param name="aircraftModel"></param>
        public LLPLifeLimitCategory(LLPLifeLimitCategoryType categoryType, String categoryName, AircraftModel aircraftModel) : this()
        {
            _categoryType = categoryType;
            _category = categoryName;
            AircraftModel = aircraftModel;
        }
        #endregion

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is LLPLifeLimitCategory)
                SetProperties((LLPLifeLimitCategory)dictionary);
        }
        #endregion

        #region public void SetProperties(LLPLifeLimitCategory dictionary)
        public void SetProperties(LLPLifeLimitCategory dictionary)
        {
            Category = dictionary.Category;
            CategoryType = dictionary.CategoryType;
            AircraftModel = dictionary.AircraftModel;

            OnPropertyChanged("FullName");
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(LLPLifeLimitCategory));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Category;
        }
        #endregion
    }
}
