using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LocationsTypeMap : BaseMap<LocationsTypeDTO>
	{
		public LocationsTypeMap() : base()
		{
			ToTable("Dictionaries.LocationsType");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.DepartmentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DepartmentId");

			HasRequired(i => i.Department)
				.WithMany(i => i.LocationsTypeDtos)
				.HasForeignKey(i => i.DepartmentId);
		}
	}
}