using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceCheckTypeMap : BaseMap<MaintenanceCheckTypeDTO>
	{
		public MaintenanceCheckTypeMap() : base()
		{
			ToTable("dbo.Cas3MaintenanceCheckType");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.Priority)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Priority");

			Property(i => i.ShortName)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");
		}
	}
}