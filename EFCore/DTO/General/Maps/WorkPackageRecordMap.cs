using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkPackageRecordMap : BaseMap<WorkPackageRecordDTO>
	{
		public WorkPackageRecordMap() : base()
		{
			ToTable("dbo.Cas3WorkPakageRecord");

			Property(i => i.WorkPakageId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPakageId");

			Property(i => i.DirectivesId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectivesId");

			Property(i => i.WorkPackageItemType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageItemType");

			Property(i => i.PerfNumFromStart)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerfNumFromStart");

			Property(i => i.PerfNumFromRecord)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerfNumFromRecord");

			Property(i => i.FromRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromRecordId");


			Property(i => i.Group)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GroupNumber");

			Property(i => i.ParentCheckId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentCheckId");

			Property(i => i.JobCardNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardNumber");
		}	
	}
}