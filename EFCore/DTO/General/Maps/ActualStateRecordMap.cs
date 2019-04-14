using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ActualStateRecordMap : BaseMap<ActualStateRecordDTO>
	{
		public ActualStateRecordMap() : base()
		{
			ToTable("dbo.ActualStateRecords");

			Property(i => i.FlightRegimeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightRegimeId");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.OnLifelength)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnLifelength");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.WorkRegimeTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkRegimeTypeId");

			Property(i => i.ComponentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");
		}
	}
}