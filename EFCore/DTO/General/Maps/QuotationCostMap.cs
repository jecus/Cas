using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class QuotationCostMap : BaseMap<QuotationCostDTO>
	{
		public QuotationCostMap() : base()
		{
			ToTable("dbo.QuotationCost");
			
			Property(i => i.CostNew)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostNew");

			Property(i => i.ProductId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProductId");

			Property(i => i.SupplierId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.QuotationId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("QuotationId");

			Property(i => i.CostServisible)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostServisible");

			Property(i => i.CostOverhaul)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostOverhaul");

			Property(i => i.CurrencyId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CurrencyId");
		}
	}
}