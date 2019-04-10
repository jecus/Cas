using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class PurchaseRequestRecordMap : BaseMap<PurchaseRequestRecordDTO>
	{
		public PurchaseRequestRecordMap() : base()
		{
			ToTable("dbo.PurchaseRequestsRecords");

			Property(i => i.ParentPackageId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentPackageId");

			Property(i => i.PackageItemId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PackageItemId");

			Property(i => i.PackageItemTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PackageItemTypeId");

			Property(i => i.SupplierId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.Quantity)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Quantity");

			Property(i => i.Measure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Measure");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.CostCondition)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostCondition");

			Property(i => i.Processed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Processed");


			HasMany(i => i.Files).WithRequired(i => i.PurchaseRequestRecord).HasForeignKey(i => i.ParentId);
		}
	}
}