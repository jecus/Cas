using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class VehicleMap : BaseMap<VehicleDTO>
	{
		public VehicleMap() : base()
		{
			ToTable("dbo.Vehicles");

			Property(i => i.OperatorId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OperatorId");

			Property(i => i.RegistrationNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RegistrationNumber");

			Property(i => i.ModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ModelId");

			Property(i => i.ManufactureDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManufactureDate");

			Property(i => i.Owner)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Owner");

			Property(i => i.CockpitSeating)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CockpitSeating");

			Property(i => i.DeliveryDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeliveryDate");

			Property(i => i.AcceptanceDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AcceptanceDate");

			Property(i => i.Schedule)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Schedule");


			HasRequired(i => i.Model)
				.WithMany(i => i.VehicleDtos)
				.HasForeignKey(i => i.ModelId);
		}
	}
}