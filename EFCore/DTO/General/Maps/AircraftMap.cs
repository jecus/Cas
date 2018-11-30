using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class AircraftMap : EntityTypeConfiguration<AircraftDTO>
	{
		public AircraftMap()
		{
			ToTable("dbo.Aircrafts");
				
			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.OperatorID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OperatorID");

			Property(i => i.AircraftTypeID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftTypeID");

			Property(i => i.ModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ModelId");
			
			Property(i => i.APUFH)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("APUFH");

			Property(i => i.TypeCertificateNumber)
				.HasMaxLength(75)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TypeCertificateNumber");

			Property(i => i.ManufactureDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManufactureDate");

			Property(i => i.RegistrationNumber)
				.IsRequired()
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RegistrationNumber");

			Property(i => i.SerialNumber)
				.IsRequired()
				.HasMaxLength(25)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SerialNumber");

			Property(i => i.VariableNumber)
				.HasMaxLength(25)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VariableNumber");

			Property(i => i.LineNumber)
				.HasMaxLength(25)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LineNumber");

			Property(i => i.Owner)
				.HasMaxLength(125)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Owner");

			Property(i => i.BasicEmptyWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BasicEmptyWeight");

			Property(i => i.BasicEmptyWeightCargoConfig)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BasicEmptyWeightCargoConfig");

			Property(i => i.CargoCapacityContainer)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CargoCapacityContainer");

			Property(i => i.Cruise)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cruise");

			Property(i => i.CruiseFuelFlow)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CruiseFuelFlow");

			Property(i => i.FuelCapacity)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelCapacity");

			Property(i => i.MaxCruiseAltitude)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxCruiseAltitude");

			Property(i => i.MaxLandingWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxLandingWeight");

			Property(i => i.MaxPayloadWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxPayloadWeight");

			Property(i => i.MaxTakeOffCrossWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxTakeOffCrossWeight");

			Property(i => i.MaxTaxiWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxTaxiWeight");

			Property(i => i.MaxZeroFuelWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxZeroFuelWeight");

			Property(i => i.OperationalEmptyWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OperationalEmptyWeight");

			Property(i => i.CockpitSeating)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CockpitSeating");

			Property(i => i.Galleys)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Galleys");

			Property(i => i.Lavatory)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Lavatory");

			Property(i => i.SeatingEconomy)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SeatingEconomy");

			Property(i => i.SeatingBusiness)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SeatingBusiness");

			Property(i => i.SeatingFirst)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SeatingFirst");

			Property(i => i.Oven)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Oven");

			Property(i => i.Boiler)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Boiler");

			Property(i => i.AirStairDoors)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AirStairDoors");

			Property(i => i.Tanks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Tanks");

			Property(i => i.AircraftAddress24Bit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftAddress24Bit");

			Property(i => i.ELTIdHexCode)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ELTIdHexCode");

			Property(i => i.DeliveryDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeliveryDate");

			Property(i => i.AcceptanceDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AcceptanceDate");

			Property(i => i.Schedule)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Schedule");

			Property(i => i.MSG)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MSG");

			Property(i => i.CheckNaming)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckNaming");

			Property(i => i.NoiceCategory)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NoiceCategory");

			Property(i => i.FADEC)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FADEC");

			Property(i => i.LandingCategory)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LandingCategory");

			Property(i => i.EFIS)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EFIS");

			Property(i => i.Brakes)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Brakes");

			Property(i => i.Winglets)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Winglets");

			Property(i => i.ApuUtizationPerFlightinMinutes)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ApuUtizationPerFlightinMinutes");


			HasRequired(i => i.Model)
				.WithMany(i => i.AircraftDtos)
				.HasForeignKey(i => i.ModelId);

			HasMany(i => i.MaintenanceProgramChangeRecords).WithRequired(i => i.ParentAircraftDto).HasForeignKey(i => i.ParentAircraftId);

		}
	}
}