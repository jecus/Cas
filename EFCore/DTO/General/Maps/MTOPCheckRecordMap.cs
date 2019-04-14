using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MTOPCheckRecordMap : BaseMap<MTOPCheckRecordDTO>
	{
		public MTOPCheckRecordMap() : base()
		{
			ToTable("dbo.MTOPCheckRecords");

			Property(i => i.CheckName)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckName");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.GroupName)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GroupName");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.IsControlPoint)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsControlPoint");

			Property(i => i.CalculatedPerformanceSource)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CalculatedPerformanceSource");

			Property(i => i.AverageUtilization)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AverageUtilization");
		}
	}
}