using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LocationMap : EntityTypeConfiguration<LocationDTO>
	{
		public LocationMap()
		{
			ToTable("Dictionaries.Locations");

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

			Property(i => i.LocationsTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LocationsTypeId");

			#region relation

			HasRequired(i => i.LocationsType)
				.WithMany(i => i.LocationDtos)
				.HasForeignKey(i => i.LocationsTypeId);

			#endregion

		}
	}
}