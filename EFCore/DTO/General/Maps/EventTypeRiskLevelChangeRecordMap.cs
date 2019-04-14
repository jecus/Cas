using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EventTypeRiskLevelChangeRecordMap : BaseMap<EventTypeRiskLevelChangeRecordDTO>
	{
		public EventTypeRiskLevelChangeRecordMap() : base()
		{
			ToTable("dbo.EventTypeRiskLevelChangeRecords");

			Property(i => i.EventCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EventCategoryId");

			Property(i => i.EventClassId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EventClassId");

			Property(i => i.IncidentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IncidentTypeId");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.Remarks)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			HasRequired(i => i.EventCategory)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.EventCategoryId);


			HasRequired(i => i.EventClass)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.EventClassId);


			HasRequired(i => i.ParentEventType)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.ParentId);
		}
	}
}