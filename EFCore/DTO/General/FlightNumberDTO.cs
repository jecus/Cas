using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("FlightNumbers", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightNo")]
		public int? FlightNoId { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("MaxFuelAmount")]
		public double? MaxFuelAmount { get; set; }

		[DataMember]
		[Column("MinFuelAmount")]
		public double? MinFuelAmount { get; set; }

		[DataMember]
		[Column("MaxPayload")]
		public double? MaxPayload { get; set; }

		[DataMember]
		[Column("MaxCargoWeight")]
		public double? MaxCargoWeight { get; set; }

		[DataMember]
		[Column("MaxTakeOffWeight")]
		public double? MaxTakeOffWeight { get; set; }

		[DataMember]
		[Column("MaxLandWeight")]
		public double? MaxLandWeight { get; set; }

		[DataMember]
		[Column("FlightAircraftCode")]
		public int? FlightAircraftCode { get; set; }

		[DataMember]
		[Column("FlightType")]
		public int FlightType { get; set; }

		[DataMember]
		[Column("FlightCategory")]
		public int? FlightCategory { get; set; }

		[DataMember]
		[Column("Distance")]
		public int? Distance { get; set; }

		[DataMember]
		[Column("DistanceMeasure")]
		public int? DistanceMeasure { get; set; }

		[DataMember]
		[Column("StationFrom")]
		public int? StationFromId { get; set; }

		[DataMember]
		[Column("StationTo")]
		public int? StationToId { get; set; }

		[DataMember]
		[Column("MinLevel")]
		public int? MinLevelId { get; set; }

		[DataMember]
		[Column("MaxPassengerAmount")]
		public int? MaxPassengerAmount { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(21)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }


		[DataMember]
		[Include]
		public FlightNumDTO FlightNo { get; set; }

		[DataMember]
		[Include]
		public AirportCodeDTO StationFrom { get; set; }

		[DataMember]
		[Include]
		public AirportCodeDTO StationTo { get; set; }

		[DataMember]
		[Include]
		public CruiseLevelDTO MinLevel { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
		[DataMember]
		public ICollection<FlightNumberAirportRelationDTO> AirportRelationDtos { get; set; }
		[DataMember]
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }

		#endregion
	}
}