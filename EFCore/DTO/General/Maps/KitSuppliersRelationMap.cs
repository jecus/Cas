using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class KitSuppliersRelationMap : BaseMap<KitSuppliersRelationDTO>
	{
		public KitSuppliersRelationMap() : base()
		{
			ToTable("dbo.KitSuppliers");

			Property(i => i.KitId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitId");

			Property(i => i.SupplierId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.CostNew)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostNew");

			Property(i => i.CostOverhaul)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostOverhaul");

			Property(i => i.CostServiceable)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostServiceable");


			HasRequired(i => i.Supplier)
				.WithMany(i => i.KitSuppliersRelationDtos)
				.HasForeignKey(i => i.SupplierId);
		}
	}
}