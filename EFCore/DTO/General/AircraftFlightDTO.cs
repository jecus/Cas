using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General 
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftFlightDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int ATLBID { get; set; }

		[DataMember]
		public int? AircraftId { get; set; }

		[DataMember]
		public string FlightNo { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public DateTime? FlightDate { get; set; }

		[DataMember]
		public string StationFrom { get; set; }

		[DataMember]
		public string StationTo { get; set; }

		[DataMember]
		public short? DelayTime { get; set; }

		[DataMember]
		public int? DelayReasonId { get; set; }

		[DataMember]
		public int? OutTime { get; set; }

		[DataMember]
		public int? InTime { get; set; }

		[DataMember]
		public int? TakeOffTime { get; set; }

		[DataMember]
		public int? LDGTime { get; set; }

		[DataMember]
		public int? NightTime { get; set; }

		[DataMember]
		public int? CRSID { get; set; }

		[DataMember]
		public int? FileID { get; set; }

		[DataMember]
		public string Tanks { get; set; }

		[DataMember]
		public string Fluids { get; set; }

		[DataMember]
		public string EnginesGeneralCondition { get; set; }

		[DataMember]
		public int? Highlight { get; set; }

		[DataMember]
		public bool Correct { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public int Cycles { get; set; }

		[DataMember]
		public string PageNo { get; set; }

		[DataMember]
		public short? FlightType { get; set; }

		[DataMember]
		public int? LevelId { get; set; }

		[DataMember]
		public int? Distance { get; set; }

		[DataMember]
		public int? DistanceMeasure { get; set; }

		[DataMember]
		public double? TakeOffWeight { get; set; }

		[DataMember]
		public double? AlignmentBefore { get; set; }

		[DataMember]
		public double? AlignmentAfter { get; set; }

		[DataMember]
		public short? FlightCategory { get; set; }

		[DataMember]
		public short AtlbRecordType { get; set; }

		[DataMember]
		public short? FlightAircraftCode { get; set; }

		[DataMember]
		public int? CancelReasonId { get; set; }

		[DataMember]
		public int StationFromId { get; set; }

		[DataMember]
		public int StationToId { get; set; }

		[DataMember]
		public int FlightNumberId { get; set; }


		[DataMember]
		[Include]
		public FlightNumDTO FlightNumber { get; set; }

		[DataMember]
		[Include]
		public CruiseLevelDTO Level { get; set; }

		[DataMember]
		[Include]
		public AirportCodeDTO StationFromDto { get; set; }

		[DataMember]
		[Include]
		public AirportCodeDTO StationToDto { get; set; }

		[DataMember]
		[Include]
		public ReasonDTO DelayReason { get; set; }

		[DataMember]
		[Include]
		public ReasonDTO CancelReason { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 13)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

	}
}