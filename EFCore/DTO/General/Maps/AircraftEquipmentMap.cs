using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class AircraftEquipmentMap : EntityTypeConfiguration<AircraftEquipmentDTO>
	{
		public AircraftEquipmentMap()
		{
			ToTable("dbo.AircraftEquipments");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.Description)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.AircraftId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftId");

			Property(i => i.AircraftOtherParameterId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftOtherParameter");

			Property(i => i.AircraftEquipmetType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftEquipmetType");


			HasRequired(i => i.AircraftOtherParameter)
				.WithMany(i => i.AircraftEquipmentDtos)
				.HasForeignKey(i => i.AircraftOtherParameterId);

		}
	}
}