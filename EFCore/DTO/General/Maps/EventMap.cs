using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EventMap : BaseMap<EventDTO>
	{
		public EventMap() : base()
		{
			HasRequired(i => i.EventType)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventTypeId);

			HasRequired(i => i.EventCategory)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventCategoryId);

			HasRequired(i => i.EventClass)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventClassId);

			HasMany(i => i.EventConditions).WithRequired(i => i.Event).HasForeignKey(i => i.ParentId);
		}
	}
}