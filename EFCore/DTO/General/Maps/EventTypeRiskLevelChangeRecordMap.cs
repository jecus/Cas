using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EventTypeRiskLevelChangeRecordMap : BaseMap<EventTypeRiskLevelChangeRecordDTO>
	{
		public EventTypeRiskLevelChangeRecordMap() : base()
		{
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