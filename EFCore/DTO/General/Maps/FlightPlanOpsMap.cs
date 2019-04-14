using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightPlanOpsMap : BaseMap<FlightPlanOpsDTO>
	{
		public FlightPlanOpsMap() : base()
		{
			ToTable("dbo.FlightPlanOps");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.DateFrom)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DateFrom");

			Property(i => i.DateTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DateTo");
		}
	}
}