using System;
using System.Text;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// класс события в системе безопасности полетов
    /// </summary>
    [Table("EventClasses", "Dictionaries", "ItemId")]
	[Dto(typeof(EventClassDTO))]
    [DictionaryCollection(typeof(CommonDictionaryCollection<EventClass>))]
    [Condition("IsDeleted", "0")]
    public class EventClass : AbstractDictionary
    {
        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        private string _fullName;
        /// <summary>
        /// Полное название Категории
        /// </summary>
        [TableColumn("FullName")]
        [FormControl(250, "Name", 1, Order = 1)]
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


        /*
         * Свойства 
         */

        #region public HumanDamage PeopleDamage { get; set; }
        /// <summary>
        /// Ущерб людям
        /// </summary>
        private HumanDamage _peopleDamage;

        [TableColumnAttribute("People")]
        [FormControl(250, "People")]
        [ListViewData(0.2f, "People")]
        [NotNull]
        public HumanDamage PeopleDamage
        {
            get { return _peopleDamage; }
            set
            {
                if (_peopleDamage != value)
                {
                    _peopleDamage = value;
                    OnPropertyChanged("PeopleDamage");
                }
            }
        }
        #endregion

        #region public FailureViolationDeviation FailureViolationDeviation { get; set; }
        /// <summary>
        /// Отказы, неисправности, отклонения
        /// </summary>
        private FailureViolationDeviation _failureViolationDeviation;

        [TableColumnAttribute("Failure")]
        [FormControl(250, "Fail. Viol-n. Devia-n.")]
        [ListViewData(0.15f, "Fail. Viol-n. Devia-n.")]
        [NotNull]
        public FailureViolationDeviation FailureViolationDeviation
        {
            get { return _failureViolationDeviation; }
            set
            {
                if (_failureViolationDeviation != value)
                {
                    _failureViolationDeviation = value;
                    OnPropertyChanged("FailureViolationDeviation");
                }
            }
        }
        #endregion

        #region public Regularity Regularity{ get; set; }
        /// <summary>
        /// Регулярность
        /// </summary>
        private Regularity _regularity;

        [TableColumnAttribute("Regularity")]
        [FormControl(250, "Regularity", 1)]
        [ListViewData(0.15f, "Regularity")]
        [NotNull]
        public Regularity Regularity
        {
            get { return _regularity; }
            set
            {
                if (_regularity != value)
                {
                    _regularity = value;
                    OnPropertyChanged("Regularity");
                }
            }
        }
        #endregion

        #region public PropertyDamage PropertyDamage { get; set; }
        /// <summary>
        /// Имущественный вред
        /// </summary>
        private PropertyDamage _propertyDamage;

        [TableColumnAttribute("Property")]
        [FormControl(250, "Property")]
        [ListViewData(0.15f, "Property")]
        [NotNull]
        public PropertyDamage PropertyDamage
        {
            get { return _propertyDamage; }
            set
            {
                if (_propertyDamage != value)
                {
                    _propertyDamage = value;
                    OnPropertyChanged("PropertyDamage");
                }
            }
        }
        #endregion

        #region public EnvironmentalDamage EnvironmentalDamage { get; set; }
        /// <summary>
        /// Ущерб окружающей среде
        /// </summary>
        private EnvironmentalDamage _environmentalDamage;

        [TableColumnAttribute("Environmental")]
        [FormControl(250, "Environmental")]
        [ListViewData(0.15f, "Environmental")]
        [NotNull]
        public EnvironmentalDamage EnvironmentalDamage
        {
            get { return _environmentalDamage; }
            set
            {
                if (_environmentalDamage != value)
                {
                    _environmentalDamage = value;
                    OnPropertyChanged("EnvironmentalDamage");
                }
            }
        }
        #endregion

        #region public ReputationDamage ReputationDamage { get; set; }
        /// <summary>
        /// Ущерб репутации
        /// </summary>
        private ReputationDamage _reputationDamage;

        [TableColumnAttribute("Reputation")]
        [FormControl(250, "Reputation", 1)]
        [ListViewData(0.1f, "Reputation")]
        [NotNull]
        public ReputationDamage ReputationDamage
        {
            get { return _reputationDamage; }
            set
            {
                if (_reputationDamage != value)
                {
                    _reputationDamage = value;
                    OnPropertyChanged("ReputationDamage");
                }
            }
        }
        #endregion

        /*
         * Свойства 
         */

        #region public int Weight
        /// <summary>
        /// Возвращает вес события. 
        /// <br/>(Определяется максимумом веса среди элементов входящих в класс)
        /// </summary>
        [TableColumnAttribute("Weight",ColumnAccessType.WriteOnly)]
        [ListViewData(0.1f, "Class",2)]
        public int Weight
        {
            get
            {
                int max = 0;
                if(_peopleDamage != null && _peopleDamage.Weight > max)
                    max = _peopleDamage.Weight;
                if(_failureViolationDeviation != null && _failureViolationDeviation.Weight > max)
                    max = _failureViolationDeviation.Weight;
                if(_regularity != null && _regularity.Weight > max)
                    max = _regularity.Weight;
                if(_propertyDamage != null && _propertyDamage.Weight > max)
                    max = _propertyDamage.Weight;
                if(_environmentalDamage != null && _environmentalDamage.Weight > max)
                    max = _environmentalDamage.Weight;
                if(_reputationDamage != null && _reputationDamage.Weight > max)
                    max = _reputationDamage.Weight;

                return max;
            }
        }
        #endregion

        /*
         * Методы
         */

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is EventClass)
                SetProperties((EventClass)dictionary);
        }
        #endregion

        #region public void SetProperties(EventClass dictionary)
        public void SetProperties(EventClass dictionary)
        {
            _fullName = dictionary.FullName;
            _peopleDamage = dictionary.PeopleDamage;
            _failureViolationDeviation = dictionary.FailureViolationDeviation;
            _regularity = dictionary.Regularity;
            _propertyDamage = dictionary.PropertyDamage;
            _environmentalDamage = dictionary.EnvironmentalDamage;
            _reputationDamage = dictionary.ReputationDamage;

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
            StringBuilder builder = new StringBuilder(Weight + " " + _fullName + " ");
            if (_peopleDamage != null && _peopleDamage != HumanDamage.UNK)
                builder.Append("H:" + _peopleDamage.Weight + " ");
            if (_failureViolationDeviation != null && _failureViolationDeviation != FailureViolationDeviation.UNK)
                builder.Append("F:" + _failureViolationDeviation.Weight + " ");
            if (_regularity != null && _regularity != Regularity.UNK)
                builder.Append("Rg:" + _regularity.Weight + " ");
            if (_propertyDamage != null && _propertyDamage != PropertyDamage.UNK)
                builder.Append("Pr:" + _propertyDamage.Weight + " ");
            if (_environmentalDamage != null && _environmentalDamage != EnvironmentalDamage.UNK)
                builder.Append("En:" + _environmentalDamage.Weight + " ");
            if (_reputationDamage != null && _reputationDamage != ReputationDamage.UNK)
                builder.Append("Rp:" + _reputationDamage.Weight);
           
            return builder.ToString();
        }
        #endregion

        /*
         * Реализация
         */
        #region public EventClass()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EventClass()
        {
            _fullName = "";
            _peopleDamage = HumanDamage.UNK;
            _failureViolationDeviation = FailureViolationDeviation.UNK;
            _regularity = Regularity.UNK;
            _propertyDamage = PropertyDamage.UNK;
            _environmentalDamage = EnvironmentalDamage.UNK;
            _reputationDamage = ReputationDamage.UNK;
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.EventClass;
        }
        #endregion

        #region public EventClass(string manufacturer, String shortName, String fullName, AircraftManufactureRegion region)

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="fullName">Название</param>
        /// <param name="people">Ущерб людям</param>
        /// <param name="failureViolationDeviation">Отказы, неисправности, отклонения</param>
        /// <param name="regularity">регулярность</param>
        /// <param name="propertyDamage">Ущерб имуществу</param>
        /// <param name="environmentalDamage">Ущерб окружаюшей среде</param>
        /// <param name="reputationDamage">Ушерб репутации</param>
        public EventClass(String fullName, HumanDamage people, 
                          FailureViolationDeviation failureViolationDeviation, 
                          Regularity regularity, 
                          PropertyDamage propertyDamage,
                          EnvironmentalDamage environmentalDamage, 
                          ReputationDamage reputationDamage)
        {
            _fullName = fullName;
            _peopleDamage = people;
            _failureViolationDeviation = failureViolationDeviation;
            _regularity = regularity;
            _propertyDamage = propertyDamage;
            _environmentalDamage = environmentalDamage;
            _reputationDamage = reputationDamage;
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is EventClass)
                return FullName.CompareTo(((EventClass)y).FullName);
            return 0;
        }
        #endregion
    }
}
