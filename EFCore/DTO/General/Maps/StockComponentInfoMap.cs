using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class StockComponentInfoMap : EntityTypeConfiguration<StockComponentInfoDTO>
	{
		public StockComponentInfoMap()
		{
			ToTable("dbo.StockComponentInfos");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.StoreID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StoreID");

			Property(i => i.PartNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PartNumber");

			Property(i => i.Amount)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Amount");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.AccessoryDescriptionId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccessoryDescriptionId");

			Property(i => i.Measure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Measure");

			Property(i => i.GoodStandartId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GoodStandartId");

			Property(i => i.ComponentClass)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentClass");

			Property(i => i.ComponentModel)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentModel");

			Property(i => i.ComponentType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentType");

			HasRequired(i => i.Standart)
				.WithMany(i => i.StockComponentInfoDtos)
				.HasForeignKey(i => i.GoodStandartId);

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.StockComponentInfoDtos)
				.HasForeignKey(i => i.ComponentModel);
		}
	}
}