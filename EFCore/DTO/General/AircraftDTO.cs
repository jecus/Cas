using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class AircraftDTO : BaseEntity
	{
		[DataMember]
		[NotMapped]
		public int AircraftFrameId { get; set; }

		[DataMember]
		public double APUFH { get; set; }

		[DataMember]
		public int OperatorID { get; set; }

		[DataMember]
		public int AircraftTypeID { get; set; }

		[DataMember]
		public int? ModelId { get; set; }

		[DataMember]
		public string TypeCertificateNumber { get; set; }

		[DataMember]
		public DateTime ManufactureDate { get; set; }

		[DataMember]
		public string RegistrationNumber { get; set; }

		[DataMember]
		public string SerialNumber { get; set; }

		[DataMember]
		public string VariableNumber { get; set; }

		[DataMember]
		public string LineNumber { get; set; }

		[DataMember]
		public string Owner { get; set; }

		[DataMember]
		public double? BasicEmptyWeight { get; set; }

		[DataMember]
		public double? BasicEmptyWeightCargoConfig { get; set; }

		[DataMember]
		public string CargoCapacityContainer { get; set; }

		[DataMember]
		public string Cruise { get; set; }

		[DataMember]
		public string CruiseFuelFlow { get; set; }

		[DataMember]
		public string FuelCapacity { get; set; }

		[DataMember]
		public string MaxCruiseAltitude { get; set; }

		[DataMember]
		public double? MaxLandingWeight { get; set; }

		[DataMember]
		public double? MaxPayloadWeight { get; set; }

		[DataMember]
		public double? MaxTakeOffCrossWeight { get; set; }

		[DataMember]
		public double? MaxTaxiWeight { get; set; }

		[DataMember]
		public double? MaxZeroFuelWeight { get; set; }

		[DataMember]
		public double? OperationalEmptyWeight { get; set; }

		[DataMember]
		public string CockpitSeating { get; set; }

		[DataMember]
		public string Galleys { get; set; }

		[DataMember]
		public string Lavatory { get; set; }

		[DataMember]
		public short? SeatingEconomy { get; set; }

		[DataMember]
		public short? SeatingBusiness { get; set; }

		[DataMember]
		public short? SeatingFirst { get; set; }

		[DataMember]
		public string Oven { get; set; }

		[DataMember]
		public string Boiler { get; set; }

		[DataMember]
		public string AirStairDoors { get; set; }

		[DataMember]
		public int? Tanks { get; set; }

		[DataMember]
		public string AircraftAddress24Bit { get; set; }

		[DataMember]
		public string ELTIdHexCode { get; set; }

		[DataMember]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		public DateTime? AcceptanceDate { get; set; }

		[DataMember]
		public bool Schedule { get; set; }

		[DataMember]
		public short MSG { get; set; }

		[DataMember]
		public bool CheckNaming { get; set; }

		[DataMember]
		public int NoiceCategory { get; set; }

		[DataMember]
		public bool FADEC { get; set; }

		[DataMember]
		public int LandingCategory { get; set; }

		[DataMember]
		public bool EFIS { get; set; }

		[DataMember]
		public short Brakes { get; set; }

		[DataMember]
		public bool Winglets { get; set; }

		[DataMember]
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