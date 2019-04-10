using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ItemsRelationMap : BaseMap<ItemsRelationDTO>
	{
		public ItemsRelationMap() : base()
		{
			ToTable("dbo.ItemsRelations");

			Property(i => i.FirstItemId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FirstItemId");

			Property(i => i.FirtsItemTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FirtsItemTypeId");

			Property(i => i.SecondItemId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SecondItemId");

			Property(i => i.SecondItemTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SecondItemTypeId");

			Property(i => i.RelationTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RelationTypeId");

		}
	}
}