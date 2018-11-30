using System;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Категория Возраст - Пол - Вес
    /// </summary>
    [Table("AGWCategories", "Dictionaries", "ItemId")]
	[Dto(typeof(AGWCategorieDTO))]
    [DictionaryCollection(typeof(CommonDictionaryCollection<AGWCategory>))]
    [Condition("IsDeleted", "0")]
    public class AGWCategory : AbstractDictionary
    {
        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        private string _fullName;
        /// <summary>
        /// Полное название Категории
        /// </summary>
        [TableColumn("FullName")]
        [FormControl(150, "Name", 1, Order = 1)]
        [ListViewData(0.2f, "Name",1)]
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

        public override string CommonName
        {
            get { return FullName; }
            set { FullName = value; }
        }

        #region public override string Category
        /// <summary>
        /// Категория не сохраняется 
        /// </summary>
        public override string Category { get; set; }
        #endregion

        #endregion


        /*
         * Свойства 
         */

        #region public Gender Gender { get; set; }
        /// <summary>
        /// пол
        /// </summary>
        private Gender _gender;

        [TableColumnAttribute("Gender")]
        [FormControl(150, "Sex", 1)]
        [ListViewData(0.1f, "Sex")]
        [NotNull]
        public Gender Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }
        #endregion

        #region public int MinAge { get; set; }
        /// <summary>
        /// минимальный возраст
        /// </summary>
        private int _minAge;

        [TableColumnAttribute("MinAge")]
        [FormControl(150, "Min age", 1)]
        [ListViewData(0.2f, "Min age")]
        [MinMaxValue(0,100)]
        [NotNull]
        public int MinAge
        {
            get { return _minAge; }
            set
            {
                if (_minAge != value)
                {
                    _minAge = value;
                    OnPropertyChanged("MinAge");
                }
            }
        }
        #endregion

        #region public int MaxAge { get; set; }
        /// <summary>
        /// максимальный возраст
        /// </summary>
        private int _maxAge;

        [TableColumnAttribute("MaxAge")]
        [FormControl(150, "Max age", 1)]
        [ListViewData(0.2f, "Max age")]
        [MinMaxValue(0, 100)]
        [NotNull]
        public int MaxAge
        {
            get { return _maxAge; }
            set
            {
                if (_maxAge != value)
                {
                    _maxAge = value;
                    OnPropertyChanged("MaxAge");
                }
            }
        }
        #endregion

        #region public int WeightSummer { get; set; }
        /// <summary>
        /// Вес летом
        /// </summary>
        private int _weightSummer;

        [TableColumnAttribute("WeightSummer")]
        [FormControl(150, "Weight Summer", 1)]
        [ListViewData(0.2f, "Weight Summer")]
        [MinMaxValue(0, 200)]
        [NotNull]
        public int WeightSummer
        {
            get { return _weightSummer; }
            set
            {
                if (_weightSummer != value)
                {
                    _weightSummer = value;
                    OnPropertyChanged("WeightSummer");
                }
            }
        }
        #endregion

        #region public int WeightWinter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private int _weightWinter;

        [TableColumnAttribute("WeightWinter")]
        [FormControl(150, "Weight Winter", 1)]
        [ListViewData(0.2f, "Weight Winter")]
        [MinMaxValue(0, 200)]
        [NotNull]
        public int WeightWinter
        {
            get { return _weightWinter; }
            set
            {
                if (_weightWinter != value)
                {
                    _weightWinter = value;
                    OnPropertyChanged("WeightWinter");
                }
            }
        }
        #endregion


        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is AGWCategory)
                SetProperties((AGWCategory)dictionary);
        }
        #endregion

        #region public void SetProperties(AGWCategory dictionary)
        public void SetProperties(AGWCategory dictionary)
        {
            _fullName = dictionary.FullName;
            _gender = dictionary.Gender;
            _minAge = dictionary.MinAge;
            _maxAge = dictionary.MaxAge;
            _weightSummer = dictionary.WeightSummer;
            _weightWinter = dictionary.WeightWinter;

            OnPropertyChanged("FullName");
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}-{3} kg", _fullName, _gender, _weightSummer, _weightWinter);
        }
        #endregion

        /*
         * Реализация
         */
        #region public AGWCategory()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AGWCategory()
        {
            _fullName = "";
            _gender = Gender.Male;
            _minAge = 0;
            _maxAge = 0;
            _weightSummer = 0;
            _weightWinter = 0;
        }
        #endregion

        #region public AGWCategory(string manufacturer, String shortName, String fullName, AircraftManufactureRegion region)

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="gender"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <param name="weightSummer"></param>
        /// <param name="weightWinter"></param>
        public AGWCategory(String fullName, Gender gender, int minAge, int maxAge, int weightSummer, int weightWinter)
        {
            _fullName = fullName;
            _gender = gender;
            _minAge = minAge;
            _maxAge = maxAge;
            _weightSummer = weightSummer;
            _weightWinter = weightWinter;
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is AGWCategory)
                return FullName.CompareTo(((AGWCategory)y).FullName);
            return 0;
        }
        #endregion
    }
}
