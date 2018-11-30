using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class MaintenanceJobCardSkillMap : EntityTypeConfiguration<MaintenanceJobCardSkillDTO>
	{
		public MaintenanceJobCardSkillMap()
		{
			ToTable("Dictionaries.MaintenanceJobCardSkills");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			
			Property(i => i.ShortName)
				.HasMaxLength(25)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");

			Property(i => i.FullName)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");
		}
	}
}