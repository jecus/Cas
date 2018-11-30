using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class VehicleMap : EntityTypeConfiguration<VehicleDTO>
	{
		public VehicleMap()
		{
			ToTable("dbo.Vehicles");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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