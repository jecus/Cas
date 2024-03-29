﻿using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.SMS
{
	/// <summary>
	/// Описывает запись о смене уровня риска для типа события в системе безопасности полетов
	/// </summary>
	[Table("EventTypeRiskLevelChangeRecords", "dbo", "ItemId")]
	[Dto(typeof(EventTypeRiskLevelChangeRecordDTO))]
	[Condition("IsDeleted","0")]
	[Serializable]
	public class EventTypeRiskLevelChangeRecord : AbstractRecord
	{
		private static Type _thisType;

		#region public EventCategory EventCategory { get; set; }
		/// <summary>
		/// Категория события, на которую была произведена смена
		/// </summary>
		[TableColumnAttribute("EventCategoryId")]
		[FormControl(150, "Category")]
		[ListViewData(0.2f, "Category")]
		[NotNull]
		public EventCategory EventCategory { get; set; }
		#endregion

		#region public EventClass EventClass { get; set; }
		/// <summary>
		/// Дата и время смены уровня риска
		/// </summary>
		[TableColumnAttribute("EventClassId")]
		[FormControl(150, "Class")]
		[ListViewData(0.2f, "Class")]
		[NotNull]
		public EventClass EventClass { get; set; }
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
		public SmsEventType ParentEventType { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("Parent"); }
		}

		#endregion

		#region  public EventTypeRiskLevelChangeRecord()

		public EventTypeRiskLevelChangeRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.EventTypeRiskLevelChangeRecord;
			_recordDate = DateTime.Now;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(EventTypeRiskLevelChangeRecord));
		}
		#endregion
	}
}
