using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class SchedulePeriodMap : BaseMap<SchedulePeriodDTO>
	{
		public SchedulePeriodMap() : base()
		{
			ToTable("Dictionaries.SchedulePeriods");
			
			Property(i => i.Schedule)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Schedule");

			Property(i => i.DateFrom)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DateFrom");

			Property(i => i.DateTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DateTo");
		}
	}
}