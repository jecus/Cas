using System;
using System.Linq;
using System.Reflection;
using CAA.Entity.Models.DTO;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.SMS;


namespace SmartCore.CAA.Event
{
    [CAADto(typeof(CAAEventDTO))]
	[Serializable]
    public class CAAEvent : AbstractRecord, IComparable<CAAEvent>
    {
        private static System.Type _thisType;

        /*
        *  Свойства
        */
       
        #region public string Description { get; set; }

        private string _description;
        /// <summary>
        /// Описание типа 
        /// </summary>
        [TableColumn("Description")]
        [FormControl(150, "Description", 3)]
        [ListViewData(0.2f, "Description", 1)]
        [NotNull]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        #endregion

        #region public EventType EventType { get; set; }

        private SmsEventType _eventType;
        /// <summary>
        /// Тип события
        /// </summary>
        [TableColumnAttribute("EventTypeId")]
        [FormControl(150, "Event type")]
        [NotNull]
        public CAASmsEventType EventType
        {
            get { return _eventType; }
            set
            {
                if(_eventType != value)
                {
                    _eventType = value;
                    OnPropertyChanged("EventType");
                }
            }
        }

        #endregion

        #region public EventCategory EventCategory { get; set; }
        /// <summary>
        /// Категория события, на которую была произведена смена
        /// </summary>
        [TableColumnAttribute("EventCategoryId")]
        [FormControl(150, "Category")]
        [ListViewData(0.05f, "Category",2)]
        [NotNull]
        public CAAEventCategory EventCategory { get; set; }
        #endregion

        #region public EventClass EventClass { get; set; }
        /// <summary>
        /// Дата и время смены уровня риска
        /// </summary>
        [TableColumnAttribute("EventClassId")]
        [FormControl(150, "Class")]
        [ListViewData(0.2f, "Class", 3)]
        [NotNull]
        public CAAEventClass EventClass { get; set; }
        #endregion

        #region public string RiskIndex { get; set; }
        /// <summary>
        /// Индекс риска
        /// </summary>
        [ListViewData(0.05f, "Risk Index", 4)]
        public string RiskIndex
        {
            get
            {
                if (EventClass != null && EventCategory != null)
                {
                    return EventClass.Weight + EventCategory.ShortName + (EventClass.Weight * EventCategory.Weight);
                }
                return "";
            }
        }
        #endregion

        #region public IncidentType IncidentType { get; set; }
        /// <summary>
        /// Дата и время смены уровня риска
        /// </summary>
        [TableColumnAttribute("IncidentTypeId")]
        [FormControl(150, "Incident")]
        [ListViewData(0.05f, "Incident/Accident", 5)]
        public IncidentType IncidentType { get; set; }
        #endregion

        #region public SmsEventStatus EventStatus { get; set; }
        /// <summary>
        /// Статус события системы безопасности полетов
        /// </summary>
        [TableColumnAttribute("EventStatusId")]
        [FormControl(150, "Status")]
        public SmsEventStatus EventStatus { get; set; }

        /// <summary>
        /// Отраженное своиство EventStatus
        /// </summary>
        public static PropertyInfo EventStatusProperty
        {
            get { return GetCurrentType().GetProperty("EventStatus"); }
        }

        #endregion

        #region public override DateTime RecordDate { get; set; }

        private DateTime _recordDate;
        /// <summary>
        /// Дата и время смены уровня риска
        /// </summary>
        [TableColumnAttribute("RecordDate")]
        [FormControl(150, "Date")]
        [ListViewData(0.15f, "Date")]
        [NotNull]
        public override DateTime RecordDate
        {
            get { return _recordDate; } 
            set
            {
                if (_recordDate != value)
                {
                    _recordDate = value;
                    OnPropertyChanged("RecordDate");
                }
            }
        }
        #endregion

        #region public override Lifelength OnLifelength { get; set; }
        /// <summary>
        /// наработка при которой была выполнена запись (не используется)
        /// </summary>
        public override Lifelength OnLifelength { get; set; }
        #endregion

        #region public BaseEntityObject Parent { get; set; }
        /// <summary>
        /// Родитель данной записи
        /// </summary>
        public BaseEntityObject Parent { get; set; }

        #endregion

        #region public SmartCoreType ParentType { get; set; }
        /// <summary>
        /// Тип родителя данной записи
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public SmartCoreType ParentType { get; set; }

        public static PropertyInfo ParentTypeProperty
        {
            get { return GetCurrentType().GetProperty("ParentType"); }
        }

        #endregion

        #region public int ParentId { get; set; }
        /// <summary>
        /// Id родителя записи
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public int ParentId { get; set; }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

        #endregion

        #region public int AircraftId { get; set; }
        /// <summary>
        /// Id ВС на котором произошло событие
        /// </summary>
        [TableColumnAttribute("AircraftId")]
        public int AircraftId { get; set; }

        public static PropertyInfo AircraftIdProperty
        {
            get { return GetCurrentType().GetProperty("AircraftId"); }
        }

        #endregion

        #region override public string Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Доп информация к записи
        /// </summary>
        [TableColumnAttribute("Remarks")]
        [FormControl(150, "Remarks", 3)]
        [ListViewData(0.2f, "Remarks")]
        [NotNull]
        public override string Remarks
        {
            get { return _remarks; }
            set
            {
                if (_remarks != value)
                {
                    _remarks = value;
                    OnPropertyChanged("Remarks");
                }
            }
        }
        #endregion

        /*
         * Дополнительные свойства
         */

        #region public CommonCollection<EventCondition> EventConditions { get; private set; }

        private CommonCollection<CAAEventCondition> _eventConditions;
        /// <summary>
        /// Условия возникновения события
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 12)]
        public CommonCollection<CAAEventCondition> EventConditions
        {
            get { return _eventConditions ?? (_eventConditions = new CommonCollection<CAAEventCondition>()); }
            internal set
            {
                if(_eventConditions != value)
                {
                    if (_eventConditions != null)
                        _eventConditions.Clear();
                    _eventConditions = value;
                    OnPropertyChanged("EventConditions");
                }
            }
        }

        [ListViewData(0.15f, "Conditions", 6)]
        public string ConditionsToString
        {
            get
            {
                if (_eventConditions == null || _eventConditions.Count == 0)
                    return "";
                return _eventConditions.Aggregate("", (current, condition) => current + (condition + "; "));
            }
        }

        public int OperatorId { get; set; }

        #endregion

        /*
         * Математический аппарат
         */

        #region Implement of ICompdreble

        public int CompareTo(CAAEvent y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        /*
		*  Методы 
		*/

        #region public Event()
        /// <summary>
        /// Создает событие без дополнительной информации
        /// </summary>
        public CAAEvent()
        {
            //задаем все ID в -1
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.SmsEvent;
            _recordDate = DateTime.Today;
            _eventConditions = new CommonCollection<EventCondition>();

            EventStatus = SmsEventStatus.Discovered;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (_eventType != null ? _eventType + " ": "") + _recordDate;
        }

        #endregion 

        #region private static Type GetCurrentType()
        private static System.Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(CAAEvent));
        }
        #endregion
    }
}