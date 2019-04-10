using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceProgramChangeRecordMap : BaseMap<MaintenanceProgramChangeRecordDTO>
	{
		public MaintenanceProgramChangeRecordMap() : base()
		{
			ToTable("dbo.MaintenanceProgramChangeRecords");

			Property(i => i.ParentAircraftId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentAircraftId");

			Property(i => i.MSG)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MSG");

			Property(i => i.MaintenanceCheckRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceCheckRecordId");

			Property(i => i.CalculatedPerformanceSource)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CalculatedPerformanceSource");

			Property(i => i.PerformanceNum)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerformanceNum");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.OnLifelength)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnLifelength");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");
		}
	}
}