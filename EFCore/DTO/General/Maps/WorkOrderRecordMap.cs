using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkOrderRecordMap : BaseMap<WorkOrderRecordDTO>
	{
		public WorkOrderRecordMap() : base()
		{
			ToTable("dbo.WorkOrderRecords");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.DirectivesId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectivesId");

			Property(i => i.PackageItemTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PackageItemTypeId");
		}
	}
}