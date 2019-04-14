using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LocationMap : BaseMap<LocationDTO>
	{
		public LocationMap() : base()
		{
			ToTable("Dictionaries.Locations");

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