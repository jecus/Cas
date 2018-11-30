using System;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Templates
{
    [Table("MaintenanceCheck", "Template", "ItemId")]
    public class TemplateMaintenanceCheck : BaseEntityObject, IKitRequired
    {
        /*
         *  Свойства
         */

        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит элемент
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string _name;
        [TableColumnAttribute("Name"), ListViewData("Name")]
        public String Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region public Lifelength Interval { get; set; }

        private Lifelength _interval;
        [TableColumnAttribute("Interval"), ListViewData("Interval")]
        public Lifelength Interval
        {
            get
            {
                if (_interval == null)
                {
                    _interval = new Lifelength();
                }
                return _interval;
            }
            set
            {
                if (_interval != value)
                {
                    _interval = value;
                    OnPropertyChanged("Interval");
                }
            }
        }
        #endregion

        #region public Lifelength Notify { get; set; }

        private Lifelength _notify;
        [TableColumnAttribute("Notify"), ListViewData("Notify")]
        public Lifelength Notify
        {
            get
            {
                if (_notify == null)
                {
                    _notify = new Lifelength();
                }
                return _notify;
            }
            set
            {
                if (_notify != value)
                {
                    _notify = value;
                    OnPropertyChanged("Notify");
                }
            }
        }
        #endregion

        #region public TemplateAircraft ParentAircraft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private TemplateAircraft _parentAircraft;
        [TableColumnAttribute("ParentAircraft"), Parent]
        public TemplateAircraft ParentAircraft
        {
            get
            {
                return _parentAircraft;
            }
            set
            {
                if (_parentAircraft != value)
                {
                    _parentAircraft = value;
                    OnPropertyChanged("ParentAircraft");
                }
            }
        }
        #endregion

        #region public Cas3MaintenanceCheckType CheckType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private MaintenanceCheckType _checkType;
        [TableColumnAttribute("CheckType"), ListViewData("Check Type")]
        public MaintenanceCheckType CheckType
        {
            get
            {
                if (_checkType == null)
                {
                    _checkType = new MaintenanceCheckType();
                }
                return _checkType;
            }
            set
            {
                if (_checkType != value)
                {
                    _checkType = value;
                    OnPropertyChanged("CheckType");
                }
            }
        }
        #endregion

        #region  public double Cost
        private double _cost;
        [TableColumnAttribute("Cost"), ListViewData("Cost"), MinMaxValue(0, 1000000000 )]
        public double Cost
        {
            get { return _cost; }
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }
        #endregion

        #region public double ManHours
        private double _manHours;
        [TableColumnAttribute("ManHours"), ListViewData("Man Hours"),MinMaxValue(0,1000000)]
        public double ManHours
        {
            get { return _manHours; }
            set
            {
                if (_manHours != value)
                {
                    _manHours = value;
                    OnPropertyChanged("ManHours");
                }
            }
        }
        #endregion

        #region public bool Schedule


        private bool _schedule;
        /// <summary>
        ///true указывает на то что эта программа по обслуживанию во время полетов
        /// а false при простое самолета в ангаре
        /// </summary>
        [TableColumnAttribute("Schedule"), ListViewData("Schedule")]
        public bool Schedule
        {
            get { return _schedule; }
            set
            {
                if (_schedule != value)
                {
                    _schedule = value;
                    OnPropertyChanged("Schedule");
                }
            }
        }
        #endregion

        /*
		*  Методы 
		*/

        #region public TemplateMaintenanceCheck()

        public TemplateMaintenanceCheck()
        {
            SmartCoreObjectType = SmartCoreType.MaintenanceCheck;
            ItemId = -1;
            Kits = new CommonCollection<AccessoryRequired>();
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Implement of IKitRequired

        #region public string KitParentString { get; }
        /// <summary>
        /// Возвращает строку для описания родителя КИТа
        /// </summary>
        public string KitParentString
        {
            get
            {
                return string.Format("Templ.Maint.Check:{0} {1}", Name, Schedule ? "Schedule" : "Store");
            }
        }
        #endregion

        public CommonCollection<AccessoryRequired> Kits { get; set; }
        #endregion
    }
}
