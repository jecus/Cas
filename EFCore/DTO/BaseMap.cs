using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO
{
	public class BaseMap<T> : EntityTypeConfiguration<T>  where T : BaseEntity 
	{
		public BaseMap()
		{
			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.CorrectorId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Corrector");
		}
	}
}
