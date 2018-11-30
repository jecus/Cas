using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberDTO : BaseEntity
	{
		[DataMember]
		public int FlightNoId { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public double? MaxFuelAmount { get; set; }

		[DataMember]
		public double? MinFuelAmount { get; set; }

		[DataMember]
		public double? MaxPayload { get; set; }

		[DataMember]
		public double? MaxCargoWeight { get; set; }

		[DataMember]
		public double? MaxTakeOffWeight { get; set; }

		[DataMember]
		public double? MaxLandWeight { get; set; }

		[DataMember]
		public int? FlightAircraftCode { get; set; }

		[DataMember]
		public int FlightType { get; set; }

		[DataMember]
		public int? FlightCategory { get; set; }

		[DataMember]
		public int? Distance { get; set; }

		[DataMember]
		public int? DistanceMeasure { get; set; }

		[DataMember]
		public int? StationFromId { get; set; }

		[DataMember]
		public int? StationToId { get; set; }

		[DataMember]
		public int? MinLevelId { get; set; }

		[DataMember]
		public int? MaxPassengerAmount { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
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