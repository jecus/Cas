using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AuditRecordMap : BaseMap<AuditRecordDTO>
	{
		public AuditRecordMap() : base()
		{
			ToTable("dbo.AuditRecords");

			Property(i => i.AuditId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuditId");

			Property(i => i.DirectivesId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectivesId");

			Property(i => i.AuditItemTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuditItemTypeId");

			Property(i => i.PerfNumFromStart)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerfNumFromStart");

			Property(i => i.PerfNumFromRecord)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerfNumFromRecord");

			Property(i => i.FromRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromRecordId");

			Property(i => i.JobCardNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardNumber");

		}
	}
}