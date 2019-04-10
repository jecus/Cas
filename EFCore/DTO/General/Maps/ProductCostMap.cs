using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ProductCostMap : BaseMap<ProductCostDTO>
	{
		public ProductCostMap() : base()
		{
			ToTable("dbo.ProductCost");
			
			Property(i => i.SupplierId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.KitId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitId");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.QtyIn)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("QtyIn");

			Property(i => i.UnitPrice)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("UnitPrice");

			Property(i => i.TotalPrice)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TotalPrice");

			Property(i => i.ShipPrice)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShipPrice");

			Property(i => i.SubTotal)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SubTotal");

			Property(i => i.Tax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Tax");

			Property(i => i.Tax1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Tax1");

			Property(i => i.Tax2)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Tax2");

			Property(i => i.Total)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Total");

			Property(i => i.CurrencyId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CurrencyId");

		}
	}
}