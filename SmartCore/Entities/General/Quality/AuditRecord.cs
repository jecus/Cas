using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Quality
{
	[Table("AuditRecords", "dbo", "ItemId")]
	[Dto(typeof(AuditRecordDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class AuditRecord : BaseEntityObject
	{
		private static Type _thisType;

		/*
		 *  Свойства
		 */

		#region public Int32 AuditId { get; set; }
		/// <summary>
		/// ID Аудита
		/// </summary>
		[TableColumn("AuditId")]
		public Int32 AuditId { get; set; }

		public static PropertyInfo AuditIdProperty
		{
			get { return GetCurrentType().GetProperty("AuditId"); }
		}

		#endregion

		#region public Int32 DirectiveId { get; set; }
		/// <summary>
		/// ID директивы хранящейся в пакете
		/// </summary>
		[TableColumn("DirectivesId")]
		public Int32 DirectiveId { get; set; }

		public static PropertyInfo DirectiveIdProperty
		{
			get { return GetCurrentType().GetProperty("DirectiveId"); }
		}

		#endregion

		#region public Int32 AuditItemTypeId { get; set; }
		/// <summary>
		/// Тип задачи, которой пренадлежит данная запись
		/// </summary>
		[TableColumn("AuditItemTypeId")]
		public Int32 AuditItemTypeId { get; set; }

		public static PropertyInfo AuditItemTypeProperty
		{
			get { return GetCurrentType().GetProperty("AuditItemType"); }
		}

		#endregion

		#region  public Int32 PerformanceNumFromStart { get; set; }
		/// <summary>
		/// Порядковый номер выполнения данной записи о задаче от начала выполнения задачи
		/// </summary>
		[TableColumn("PerfNumFromStart")]
		public Int32 PerformanceNumFromStart { get; set; }
		#endregion

		#region public Int32 PerformanceNumFromRecord { get; set; }
		/// <summary>
		/// Порядковый номер выполнения данной записи о задаче от какого-то выполнения задачи 
		/// </summary>
		[TableColumn("PerfNumFromRecord")]
		public Int32 PerformanceNumFromRecord { get; set; }
		#endregion

		#region public Int32 FromRecordId { get; set; }
		/// <summary>
		/// Идентификатор записи, от которой отчитываются выполнения PerformanceNumFromRecord
		/// </summary>
		[TableColumn("FromRecordId")]
		public Int32 FromRecordId { get; set; }
		#endregion

		#region public string JobCardNumber { get; set; }
		/// <summary>
		/// Названия карты нарадя. (Применяется только для NonRoutineJob)
		/// </summary>
		[TableColumn("JobCardNumber")]
		public string JobCardNumber { get; set; }
		#endregion

		#region public IDirective Task { get; set; }
		/// <summary>
		/// Задача, привязанная к данной записи
		/// </summary>
		public IDirective Task { get; set; }
		#endregion

		#region public Audit Audit { get; set; }
		/// <summary>
		/// Родительский рабочий пакет
		/// </summary>
		public Audit Audit { get; set; }
		#endregion
		/*
		*  Методы 
		*/
		
		#region public AuditRecord()
		/// <summary>
		/// Создает запись о задаче в рабочем пакете без дополнительной информации
		/// </summary>
		public AuditRecord()
		{
			ItemId = -1;
			DirectiveId = 0;
			AuditId = 0;
			AuditItemTypeId = 0;
		}
		/// <summary>
		/// Создает запись о задаче в рабочем пакете на основе переданных параметров
		/// </summary>
		public AuditRecord(int auditId, int directiveId, Int32 directiveType)
		{
			DirectiveId = directiveId;
			AuditId = auditId;
			AuditItemTypeId = directiveType;
		}
		#endregion

		#region public override string ToString()
		public override string ToString()
		{
			return $"Dir:id {DirectiveId} desc:{(Task != null ? Task.ToString() : "")} ";
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(AuditRecord));
		}
		#endregion
	}
}
