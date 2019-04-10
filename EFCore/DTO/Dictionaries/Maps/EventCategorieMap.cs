using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class EventCategorieMap : BaseMap<EventCategorieDTO>
	{
		public EventCategorieMap() : base()
		{
			ToTable("Dictionaries.EventCategories");

			Property(i => i.Weight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Weight");

			Property(i => i.MinCompareOp)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MinCompareOp");

			Property(i => i.EventCountMinPeriod)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EventCountMinPeriod");

			Property(i => i.MinReportPeriod)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MinReportPeriod");

			Property(i => i.MaxCompareOp)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxCompareOp");

			Property(i => i.EventCountMaxPeriod)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EventCountMaxPeriod");

			Property(i => i.MaxReportPeriod)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxReportPeriod");
		}
	}
}