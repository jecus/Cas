using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("Aircrafts", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
	public class CAAAircraftDTO : BaseEntity
	{
		
		[NotMapped]
		public int AircraftFrameId { get; set; }

		
		[Column("APUFH")]
		public double APUFH { get; set; }

		
		[Column("OperatorID")]
		public int OperatorID { get; set; }

		
		[Column("AircraftTypeID")]
		public int AircraftTypeID { get; set; }

		
		[Column("ModelId")]
		public int? ModelId { get; set; }

		
		[Column("TypeCertificateNumber"), MaxLength(75)]
		public string TypeCertificateNumber { get; set; }

		
		[Column("ManufactureDate")]
		public DateTime ManufactureDate { get; set; }

		
		[Column("RegistrationNumber"), MaxLength(50)]
		public string RegistrationNumber { get; set; }

		
		[Column("SerialNumber"), MaxLength(25)]
		public string SerialNumber { get; set; }

		
		[Column("VariableNumber"), MaxLength(25)]
		public string VariableNumber { get; set; }

		
		[Column("LineNumber"), MaxLength(25)]
		public string LineNumber { get; set; }

		
		[Column("Owner"), MaxLength(125)]
		public string Owner { get; set; }

		
		[Column("BasicEmptyWeight")]
		public double? BasicEmptyWeight { get; set; }

		
		[Column("BasicEmptyWeightCargoConfig")]
		public double? BasicEmptyWeightCargoConfig { get; set; }

		
		[Column("CargoCapacityContainer"), MaxLength(150)]
		public string CargoCapacityContainer { get; set; }

		
		[Column("Cruise"), MaxLength(150)]
		public string Cruise { get; set; }

		
		[Column("CruiseFuelFlow"), MaxLength(150)]
		public string CruiseFuelFlow { get; set; }

		
		[Column("FuelCapacity"), MaxLength(150)]
		public string FuelCapacity { get; set; }

		
		[Column("MaxCruiseAltitude"), MaxLength(150)]
		public string MaxCruiseAltitude { get; set; }

		
		[Column("MaxLandingWeight")]
		public double? MaxLandingWeight { get; set; }

		
		[Column("MaxPayloadWeight")]
		public double? MaxPayloadWeight { get; set; }

		
		[Column("MaxTakeOffCrossWeight")]
		public double? MaxTakeOffCrossWeight { get; set; }

		
		[Column("MaxTaxiWeight")]
		public double? MaxTaxiWeight { get; set; }

		
		[Column("MaxZeroFuelWeight")]
		public double? MaxZeroFuelWeight { get; set; }

		
		[Column("OperationalEmptyWeight")]
		public double? OperationalEmptyWeight { get; set; }

		
		[Column("CockpitSeating"), MaxLength(150)]
		public string CockpitSeating { get; set; }

		
		[Column("Galleys"), MaxLength(150)]
		public string Galleys { get; set; }

		
		[Column("Lavatory"), MaxLength(150)]
		public string Lavatory { get; set; }

		
		[Column("SeatingEconomy")]
		public short? SeatingEconomy { get; set; }

		
		[Column("SeatingBusiness")]
		public short? SeatingBusiness { get; set; }

		
		[Column("SeatingFirst")]
		public short? SeatingFirst { get; set; }

		
		[Column("Oven"), MaxLength(50)]
		public string Oven { get; set; }

		
		[Column("Boiler"), MaxLength(50)]
		public string Boiler { get; set; }

		
		[Column("AirStairDoors"), MaxLength(50)]
		public string AirStairDoors { get; set; }

		
		[Column("Tanks")]
		public int? Tanks { get; set; }

		
		[Column("AircraftAddress24Bit")]
		public string AircraftAddress24Bit { get; set; }

		
		[Column("ELTIdHexCode")]
		public string ELTIdHexCode { get; set; }

		
		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		
		[Column("AcceptanceDate")]
		public DateTime? AcceptanceDate { get; set; }

		
		[Column("Schedule")]
		public bool Schedule { get; set; }

		
		[Column("MSG")]
		public short MSG { get; set; }

		
		[Column("CheckNaming")]
		public bool CheckNaming { get; set; }

		
		[Column("NoiceCategory")]
		public int NoiceCategory { get; set; }

		
		[Column("FADEC")]
		public bool FADEC { get; set; }

		
		[Column("LandingCategory")]
		public int LandingCategory { get; set; }

		
		[Column("EFIS")]
		public bool EFIS { get; set; }

		
		[Column("Brakes")]
		public short Brakes { get; set; }

		
		[Column("Winglets")]
		public bool Winglets { get; set; }

		
		[Column("ApuUtizationPerFlightinMinutes")]
		public short? ApuUtizationPerFlightinMinutes { get; set; }


		
		[Child]
		public CAAAccessoryDescriptionDTO Model { get; set; }

		//[Child(RelationType.OneToMany, "ParentAircraftId", "ParentAircraft")]
		
		[Child]
		public ICollection<CAAMaintenanceProgramChangeRecordDTO> MaintenanceProgramChangeRecords { get; set; }
	}
}