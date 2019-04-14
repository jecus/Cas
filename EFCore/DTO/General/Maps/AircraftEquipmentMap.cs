using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AircraftEquipmentMap : BaseMap<AircraftEquipmentDTO>
	{
		public AircraftEquipmentMap() : base()
		{
			ToTable("dbo.AircraftEquipments");

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