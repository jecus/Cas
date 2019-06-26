using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("Aircrafts", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class AircraftDTO : BaseEntity
	{
		[DataMember]
		[NotMapped]
		public int AircraftFrameId { get; set; }

		[DataMember]
		[Column("APUFH")]
		public double APUFH { get; set; }

		[DataMember]
		[Column("OperatorID"), Required]
		public int OperatorID { get; set; }

		[DataMember]
		[Column("AircraftTypeID"), Required]
		public int AircraftTypeID { get; set; }

		[DataMember]
		[Column("ModelId")]
		public int? ModelId { get; set; }

		[DataMember]
		[Column("TypeCertificateNumber"), MaxLength(75)]
		public string TypeCertificateNumber { get; set; }

		[DataMember]
		[Column("ManufactureDate"), Required]
		public DateTime ManufactureDate { get; set; }

		[DataMember]
		[Column("RegistrationNumber"), MaxLength(50), Required]
		public string RegistrationNumber { get; set; }

		[DataMember]
		[Column("SerialNumber"), MaxLength(25), Required]
		public string SerialNumber { get; set; }

		[DataMember]
		[Column("VariableNumber"), MaxLength(25)]
		public string VariableNumber { get; set; }

		[DataMember]
		[Column("LineNumber"), MaxLength(25)]
		public string LineNumber { get; set; }

		[DataMember]
		[Column("Owner"), MaxLength(125)]
		public string Owner { get; set; }

		[DataMember]
		[Column("BasicEmptyWeight")]
		public double? BasicEmptyWeight { get; set; }

		[DataMember]
		[Column("BasicEmptyWeightCargoConfig")]
		public double? BasicEmptyWeightCargoConfig { get; set; }

		[DataMember]
		[Column("CargoCapacityContainer"), MaxLength(150)]
		public string CargoCapacityContainer { get; set; }

		[DataMember]
		[Column("Cruise"), MaxLength(150)]
		public string Cruise { get; set; }

		[DataMember]
		[Column("CruiseFuelFlow"), MaxLength(150)]
		public string CruiseFuelFlow { get; set; }

		[DataMember]
		[Column("FuelCapacity"), MaxLength(150)]
		public string FuelCapacity { get; set; }

		[DataMember]
		[Column("MaxCruiseAltitude"), MaxLength(150)]
		public string MaxCruiseAltitude { get; set; }

		[DataMember]
		[Column("MaxLandingWeight")]
		public double? MaxLandingWeight { get; set; }

		[DataMember]
		[Column("MaxPayloadWeight")]
		public double? MaxPayloadWeight { get; set; }

		[DataMember]
		[Column("MaxTakeOffCrossWeight")]
		public double? MaxTakeOffCrossWeight { get; set; }

		[DataMember]
		[Column("MaxTaxiWeight")]
		public double? MaxTaxiWeight { get; set; }

		[DataMember]
		[Column("MaxZeroFuelWeight")]
		public double? MaxZeroFuelWeight { get; set; }

		[DataMember]
		[Column("OperationalEmptyWeight")]
		public double? OperationalEmptyWeight { get; set; }

		[DataMember]
		[Column("CockpitSeating"), MaxLength(150)]
		public string CockpitSeating { get; set; }

		[DataMember]
		[Column("Galleys"), MaxLength(150)]
		public string Galleys { get; set; }

		[DataMember]
		[Column("Lavatory"), MaxLength(150)]
		public string Lavatory { get; set; }

		[DataMember]
		[Column("SeatingEconomy")]
		public short? SeatingEconomy { get; set; }

		[DataMember]
		[Column("SeatingBusiness")]
		public short? SeatingBusiness { get; set; }

		[DataMember]
		[Column("SeatingFirst")]
		public short? SeatingFirst { get; set; }

		[DataMember]
		[Column("Oven"), MaxLength(50)]
		public string Oven { get; set; }

		[DataMember]
		[Column("Boiler"), MaxLength(50)]
		public string Boiler { get; set; }

		[DataMember]
		[Column("AirStairDoors"), MaxLength(50)]
		public string AirStairDoors { get; set; }

		[DataMember]
		[Column("Tanks")]
		public int? Tanks { get; set; }

		[DataMember]
		[Column("AircraftAddress24Bit")]
		public string AircraftAddress24Bit { get; set; }

		[DataMember]
		[Column("ELTIdHexCode")]
		public string ELTIdHexCode { get; set; }

		[DataMember]
		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		[Column("AcceptanceDate")]
		public DateTime? AcceptanceDate { get; set; }

		[DataMember]
		[Column("Schedule"), Required]
		public bool Schedule { get; set; }

		[DataMember]
		[Column("MSG"), Required]
		public short MSG { get; set; }

		[DataMember]
		[Column("CheckNaming"), Required]
		public bool CheckNaming { get; set; }

		[DataMember]
		[Column("NoiceCategory"), Required]
		public int NoiceCategory { get; set; }

		[DataMember]
		[Column("FADEC"), Required]
		public bool FADEC { get; set; }

		[DataMember]
		[Column("LandingCategory"), Required]
		public int LandingCategory { get; set; }

		[DataMember]
		[Column("EFIS"), Required]
		public bool EFIS { get; set; }

		[DataMember]
		[Column("Brakes"), Required]
		public short Brakes { get; set; }

		[DataMember]
		[Column("Winglets"), Required]
		public bool Winglets { get; set; }

		[DataMember]
		[Column("ApuUtizationPerFlightinMinutes")]
		public short? ApuUtizationPerFlightinMinutes { get; set; }


		[DataMember]
		[Child]
		public AccessoryDescriptionDTO Model { get; set; }

		//[Child(RelationType.OneToMany, "ParentAircraftId", "ParentAircraft")]
		[DataMember]
		[Child]
		public ICollection<MaintenanceProgramChangeRecordDTO> MaintenanceProgramChangeRecords { get; set; }
	}
}