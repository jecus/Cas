using System;
using EFCore.DTO.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Table("Cas3MaintenanceCheckType", "dbo", "ItemId")]
	[Dto(typeof(MaintenanceCheckTypeDTO))]
    [Serializable]
    public class MaintenanceCheckType : AbstractDictionary
    {
        private static MaintenanceCheckType _unknown;
        /*
         *  Свойства
         */
        #region Implement of Dictionary

        #region  public override string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string _name;

        [TableColumnAttribute("Name", 50)]
        [FormControl(150, "Name", 1, Order = 1)]
        [ListViewData(0.2f, "Name", 1)]
        [NotNull]
        public override string FullName
        {
            get { return _name; }
            set
            {
                if (_name!=value)
                {
                    _name = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        #endregion

        #region  public override string ShortName
        /// <summary>
        /// 
        /// </summary>
        private string _shortName;

        [TableColumnAttribute("ShortName", 50)]
        [FormControl(150, "ShortName", 1, Order = 2)]
        [ListViewData(0.2f, "ShortName", 2)]
        [NotNull]

        public override string ShortName
        {
            get { return _shortName; }
            set
            {
                if (_shortName != value)
                {
                    _shortName = value;
                    OnPropertyChanged("ShortName");
                }
            }
        }
        #endregion

        public override string CommonName
        {
            get { return FullName; }
            set { FullName = value; }
        }

        public override string Category
        {
            get { return FullName; }
            set { FullName = value; }
        }

        #endregion

        #region public int Priority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private int _priority;

        [TableColumnAttribute("Priority")]
        [FormControl(150, "Priority", 1, Order = 3)]
        [ListViewData(0.2f, "Priority", 3)]
        [MinMaxValue(0,30)]
        [NotNull]
        public int Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }

        #endregion


       /*
		*  Методы 
		*/
        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is MaintenanceCheckType)
                SetProperties((MaintenanceCheckType)dictionary);
        }
        #endregion

        #region public void SetProperties(MaintenanceCheckType dictionary)
        public void SetProperties(MaintenanceCheckType dictionary)
        {
            Priority = dictionary.Priority;
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion 
  
        #region public MaintenanceCheckType()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public MaintenanceCheckType()
        {
            ItemId = -1;
            _priority = 0;
        }
        #endregion

        #region public static MaintenanceCheckType Unknown
        /// <summary>
        /// Возвращает неизвестный тип чека
        /// </summary>
        public static MaintenanceCheckType Unknown
        {
            get
            {
                return _unknown ?? (_unknown = new MaintenanceCheckType
                                       {
                                           Priority = -1,
                                           FullName = "",
                                           ShortName = "",
                                           Category = "",
                                           CommonName = "",
                                       });
            }
        }
        #endregion
    }
}
