using System;
using System.Reflection;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.SMS;

namespace SmartCore.CAA.Event
{
	[CAADto(typeof(CAAEventTypeRiskLevelChangeRecordDTO))]
	[Condition("IsDeleted","0")]
	[Serializable]
	public class CAAEventTypeRiskLevelChangeRecord : AbstractRecord,IOperatable
	{
		private static System.Type _thisType;

		#region public EventCategory EventCategory { get; set; }
		/// <summary>
		/// Категория события, на которую была произведена смена
		/// </summary>
		[TableColumnAttribute("EventCategoryId")]
		[FormControl(150, "Category")]
		[ListViewData(0.2f, "Category")]
		[NotNull]
		public CAAEventCategory EventCategory { get; set; }
		#endregion

		#region public EventClass EventClass { get; set; }
		/// <summary>
		/// Дата и время смены уровня риска
		/// </summary>
		[TableColumnAttribute("EventClassId")]
		[FormControl(150, "Class")]
		[ListViewData(0.2f, "Class")]
		[NotNull]
		public CAAEventClass EventClass { get; set; }
		#endregion

		#region public string RiskIndex { get; set; }
		/// <summary>
		/// Индекс риска
		/// </summary>
		[ListViewData(0.2f, "Risk Index")]
		public string RiskIndex
		{
			get
			{
				if ( EventClass != null && EventCategory != null )
				{
					return EventClass.Weight + EventCategory.FullName + (EventClass.Weight * EventCategory.Weight);
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
		[ListViewData(0.2f, "Incident")]
		[NotNull]
		public IncidentType IncidentType { get; set; }
		#endregion

		#region public override DateTime RecordDate { get; set; }

		private DateTime _recordDate;
		/// <summary>
		/// Дата и время смены уровня риска
		/// </summary>
		[TableColumnAttribute("RecordDate")]
		[FormControl(150, "Date", Order = 1)]
		[ListViewData(0.2f, "Date", 1)]
		[NotNull]
		public override DateTime RecordDate
		{
			get { return _recordDate; }
			set
			{
				if(_recordDate  != value)
				{
					_recordDate = value;
					OnPropertyChanged("RecorDate");
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

		#region override public string Remarks { get; set; }
		/// <summary>
		/// Доп информация к записи
		/// </summary>
		[TableColumnAttribute("Remarks")]
		[FormControl(150, "Remarks", 3)]
		[ListViewData(0.2f, "Remarks")]
		public override string Remarks { get; set; }
		#endregion

		#region public Int32 ParentId { get; set; }
		/// <summary>
		/// ID родителя
		/// </summary>
		[TableColumnAttribute("ParentId")]
		[ParentAttribute]
		public CAASmsEventType ParentEventType { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("Parent"); }
		}

		public int OperatorId { get; set; }

		#endregion

		#region  public EventTypeRiskLevelChangeRecord()

		public CAAEventTypeRiskLevelChangeRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.EventTypeRiskLevelChangeRecord;
			_recordDate = DateTime.Now;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static System.Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(CAAEventTypeRiskLevelChangeRecord));
		}
		#endregion
	}
}