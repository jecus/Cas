using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class ServiceTypeMap : BaseMap<ServiceTypeDTO>
	{
		public ServiceTypeMap() : base()
		{
			ToTable("Dictionaries.ServiceTypes");

			Property(i => i.Name)
				.IsRequired()
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");
		}
	}
}