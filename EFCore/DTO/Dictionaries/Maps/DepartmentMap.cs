using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DepartmentMap : EntityTypeConfiguration<DepartmentDTO>
	{
		public DepartmentMap()
		{
			ToTable("Dictionaries.Departments");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId).HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

		}
	}
}