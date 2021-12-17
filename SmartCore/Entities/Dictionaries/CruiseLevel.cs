using System;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает эшелон полета
    /// </summary>
    [Table("CruiseLevels", "Dictionaries", "ItemId")]
	[Dto(typeof(CruiseLevelDTO))]
    [DictionaryCollection(typeof(CommonDictionaryCollection<CruiseLevel>))]
    [Condition("IsDeleted", "0")]
	[Serializable]
	public class CruiseLevel : AbstractDictionary
    {
        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        private string _fullName;
        /// <summary>
        /// Полное название Эшелона
        /// </summary>
        [TableColumn("FullName")]
        [FormControl(150, "Flight Level", 1, Order = 1)]
        [ListViewData(0.2f, "Flight Level", 1)]
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

        #region Properties

        #region public int Meter

        private int _meter;
        /// <summary>
        /// Высота в метрах
        /// </summary>
        [TableColumn("Meter")]
        [FormControl(150, "Meters")]
        [ListViewData(0.2f, "Meters")]
        [MinMaxValue(0,30000)]
        [NotNull]
        public int Meter
        {
            get { return _meter; }
            set
            {
                if (_meter != value)
                {
                    _meter = value;
                    OnPropertyChanged("Meter");
                }
            }
        }

        #endregion

        #region public int Feet

        private int _feet;
        /// <summary>
        /// Высота в футах
        /// </summary>
        [TableColumn("Feet")]
        [FormControl(150, "Feets")]
        [ListViewData(0.2f, "Feets")]
        [MinMaxValue(0, 75000)]
        [NotNull]
        public int Feet
        {
            get { return _feet; }
            set
            {
                if (_feet != value)
                {
                    _feet = value;
                    OnPropertyChanged("Feet");
                }
            }
        }

        #endregion

        #region public string IVFR

        private string _ivfr;
        /// <summary>
        /// Режим полета (визуально/по приборам)
        /// </summary>
        [TableColumn("IVFR")]
        [FormControl(150, "IFR/VFR Flight",1)]
        [ListViewData(0.2f, "IFR/VFR Flight")]
        public string IVFR
        {
            get { return _ivfr; }
            set
            {
                if (_ivfr != value)
                {
                    _ivfr = value;
                    OnPropertyChanged("IVFR");
                }
            }
        }
        #endregion

        #region public string Track

        private string _track;
        /// <summary>
        /// Направление
        /// </summary>
        [TableColumn("Track")]
        [FormControl(150, "Track", 1)]
        [ListViewData(0.2f, "Track")]
        public string Track
        {
            get { return _track; }
            set
            {
                if (_track != value)
                {
                    _track = value;
                    OnPropertyChanged("Track");
                }
            }
        }
        #endregion

        #endregion

        /*
         * Методы
         */

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

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is CruiseLevel)
                SetProperties((CruiseLevel)dictionary);
        }
        #endregion

        #region public void SetProperties(CruiseLevel dictionary)
        public void SetProperties(CruiseLevel dictionary)
        {
            _fullName = dictionary.FullName;
            _meter = dictionary.Meter;
            _feet = dictionary.Feet;
            _ivfr = dictionary.IVFR;
            _track = dictionary.Track;

            OnPropertyChanged("FullName");
        }
        #endregion

        /*
         * Реализация
         */
        #region public CruiseLevel()
        /// <summary>
        /// Конструктор создает объект эшелона полета
        /// </summary>
        public CruiseLevel()
        {
            SmartCoreObjectType = SmartCoreType.CruiseLevel;
        }
        #endregion

        #region public CruiseLevel(Int32 itemId, string shortName, String fullName, int meter, int feet, string ivfr, string track)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId">Идентификатор</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="meter">Высота в метрах</param>
        /// <param name="feet">Высота в футах</param>
        /// <param name="ivfr">Режим полета (визуально/по приборам)</param>
        /// <param name="track">Направление полета</param>
        public CruiseLevel(Int32 itemId, String fullName, int meter, int feet, string ivfr, string track)
        {
            ItemId = itemId;
            _fullName = fullName;
            _meter = meter;
            _feet = feet;
            _ivfr = ivfr;
            _track = track;
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is CruiseLevel)
                return FullName.CompareTo(((CruiseLevel)y).FullName);
            return 0;
        }
		#endregion
    }
}
