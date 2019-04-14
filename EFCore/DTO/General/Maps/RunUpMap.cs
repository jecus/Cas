using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class RunUpMap : BaseMap<RunUpDTO>
	{
		public RunUpMap() : base()
		{
			ToTable("dbo.Runups");
			
			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.StartTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StartTime");

			Property(i => i.RunUpType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RunUpType");

			Property(i => i.RunUpPhase)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RunUpPhase");

			Property(i => i.RunUpCondition)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RunUpCondition");

			Property(i => i.EndTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EndTime");

			Property(i => i.EndPhase)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EndPhase");

			Property(i => i.ShutDownReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShutDownReasonId");

			Property(i => i.ShutDownType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShutDownType");

			Property(i => i.LandTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LandTime");

			Property(i => i.AirTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AirTime");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.OnLifelength)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnLifelength");

			Property(i => i.BaseComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BaseComponentId");
		}
	}
}