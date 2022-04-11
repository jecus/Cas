using System;
using System.Linq;
using CAA.Entity.Models.DTO;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.SMS;

namespace SmartCore.CAA.Event
{
	[CAADto(typeof(CAASmsEventTypeDTO))]
	[Serializable]
	public class CAASmsEventType : AbstractDictionary, IComparable<CAASmsEventType>
	{

		#region Implement of Dictionary

		#region  public override string FullName { get; set; }

		private string _fullName;
		/// <summary>
		/// Полное название Категории
		/// </summary>
		[TableColumn("FullName")]
		[FormControl(150, "Name", 1, Order = 1)]
		[ListViewData(0.2f, "Name", 1)]
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
		/// <summary>
		/// Общее имя (не используется)
		/// </summary>
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
		*  Свойства
		*/
		#region public string Description { get; set; }

		private string _description;
		/// <summary>
		/// Описание типа 
		/// </summary>
		[TableColumn("Description")]
		[FormControl(150, "Description", 3)]
		[ListViewData(0.2f, "Description", 2)]
		[NotNull]
		public string Description
		{
			get { return _description; }
			set
			{
				if(_description != value)
				{
					_description = value;
					OnPropertyChanged("Description");
				}
			}
		}
	   
		#endregion

		#region public EventCategory EventCategory { get; set; }
		/// <summary>
		/// Категория события
		/// </summary>
		[FormControl(150, "Category", Enabled = false)]
		[ListViewData(0.15f, "Category", 3)]
		[NotNull]
		public EventCategory EventCategory
		{
			get { return LastChange != null ? LastChange.EventCategory : null; }
		}

		#endregion

		#region public EventClass EventClass{ get; set; }
		/// <summary>
		/// Класс события
		/// </summary>
		[FormControl(150, "Class", Enabled = false)]
		[ListViewData(0.15f, "Class", 4)]
		[NotNull]
		public EventClass EventClass
		{
			get { return LastChange != null ? LastChange.EventClass : null; }
		}

		#endregion

		#region public string RiskIndex { get; set; }
		/// <summary>
		/// Индекс риска
		/// </summary>
		[ListViewData(0.15f, "Risk Index",5)]
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

		#region public IncidentType IncidentType{ get; set; }
		/// <summary>
		/// тип инцидента
		/// </summary>
		[FormControl(150, "Incident/Accident", Enabled = false)]
		[ListViewData(0.15f, "Incident/Accident",6)]
		[NotNull]
		public IncidentType IncidentType
		{
			get { return LastChange != null ? LastChange.IncidentType : null; }
		}

		#endregion

		#region public DateTime RecordDate{ get; set; }
		/// <summary>
		/// дата ввода в систему (определяется датой последней записи от смене уровня риска)
		/// </summary>
		[FormControl(150, "Date", Enabled = false)]
		[ListViewData(0.15f, "Date")]
		[NotNull]
		public DateTime RecordDate
		{
			get { return LastChange != null ? LastChange.RecordDate : DateTimeExtend.GetCASMinDateTime(); }
		}

		#endregion

		/*
		 * Дополнительные свойства
		 */

		#region public CommonCollection<EventCondition> EventConditions { get; private set; }

		private CommonCollection<EventCondition> _eventConditions;
		/// <summary>
		/// Условия возникновения события
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 11)]
		public CommonCollection<EventCondition> EventConditions
		{
			get { return _eventConditions; }
			internal set { _eventConditions = value; }
		}

		[ListViewData(0.15f, "Conditions", 7)]
		public string ConditionsToString
		{
			get
			{
				if (_eventConditions == null || _eventConditions.Count == 0)
					return "";
				return _eventConditions.Aggregate("", (current, condition) => current + (condition + "; "));
			}
		}
	   
		#endregion

		#region public BaseRecordCollection<EventTypeRiskLevelChangeRecord> ChangeRecords { get; private set; }

		private BaseRecordCollection<EventTypeRiskLevelChangeRecord> _changeRecords;
		/// <summary>
		/// Коллекция содержит все записи о выполнении директивы
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentEventType")]
		public BaseRecordCollection<EventTypeRiskLevelChangeRecord> ChangeRecords
		{
			get { return _changeRecords; }
			internal set
			{
				if (_changeRecords != value)
				{
					if (_changeRecords != null)
						_changeRecords.Clear();
					if (value != null)
						_changeRecords = value;
				}
			}
		}
		#endregion

		#region public EventTypeRecord LastPerformance { get; }
		/// <summary>
		/// Последнее выполнение 
		/// </summary>
		public EventTypeRiskLevelChangeRecord LastChange { get { return _changeRecords.GetLast(); } }

		public int OperatorId { get; set; }

		#endregion

		/*
		 * Математический аппарат
		 */

		#region public override void SetProperties(AbstractDictionary dictionary)
		public override void SetProperties(AbstractDictionary dictionary)
		{
			if (dictionary is SmsEventType)
				SetProperties((SmsEventType)dictionary);
		}
		#endregion

		#region public void SetProperties(EventType dictionary)
		public void SetProperties(SmsEventType dictionary)
		{
			_fullName = dictionary.FullName;
			_description = dictionary.Description;

			OnPropertyChanged("FullName");
		}
		#endregion

		#region Implement of ICompdreble

		public int CompareTo(CAASmsEventType y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		/*
		*  Методы 
		*/

		#region public EventType()
		/// <summary>
		/// Создает директиву без дополнительной информации
		/// </summary>
		public CAASmsEventType()
		{
			SmartCoreObjectType = SmartCoreType.SmsEventType;
			//задаем все ID в -1
			ItemId = -1;
			_fullName = "";
			_description = "";
			_changeRecords = new BaseRecordCollection<EventTypeRiskLevelChangeRecord>();
			_eventConditions = new CommonCollection<EventCondition>();
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _fullName + " " + _description;
		}

		#endregion 
	}
}