using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General 
{
	[Table("AircraftFlights", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftFlightDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("ATLBID")]
		public int ATLBID { get; set; }

		[DataMember]
		[Column("AircraftId")]
		public int? AircraftId { get; set; }

		[DataMember]
		[Column("FlightNo"), MaxLength(128)]
		public string FlightNo { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("FlightDate")]
		public DateTime? FlightDate { get; set; }

		[DataMember]
		[Column("StationFrom"), MaxLength(128)]
		public string StationFrom { get; set; }

		[DataMember]
		[Column("StationTo"), MaxLength(128)]
		public string StationTo { get; set; }

		[DataMember]
		[Column("DelayTime")]
		public short? DelayTime { get; set; }

		[DataMember]
		[Column("DelayReasonId")]
		public int? DelayReasonId { get; set; }

		[DataMember]
		[Column("OutTime")]
		public int? OutTime { get; set; }

		[DataMember]
		[Column("InTime")]
		public int? InTime { get; set; }

		[DataMember]
		[Column("TakeOffTime")]
		public int? TakeOffTime { get; set; }

		[DataMember]
		[Column("LDGTime")]
		public int? LDGTime { get; set; }

		[DataMember]
		[Column("NightTime")]
		public int? NightTime { get; set; }

		[DataMember]
		[Column("CRSID")]
		public int? CRSID { get; set; }

		[DataMember]
		[Column("FileID")]
		public int? FileID { get; set; }

		[DataMember]
		[Column("Tanks")]
		public string Tanks { get; set; }

		[DataMember]
		[Column("Fluids")]
		public string Fluids { get; set; }

		[DataMember]
		[Column("EnginesGeneralCondition")]
		public string EnginesGeneralCondition { get; set; }

		[DataMember]
		[Column("Highlight")]
		public int? Highlight { get; set; }

		[DataMember]
		[Column("Correct"), Required]
		public bool Correct { get; set; }

		[DataMember]
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

		[DataMember]
		[Column("Cycles"), Required]
		public int Cycles { get; set; }

		[DataMember]
		[Column("PageNo"), MaxLength(128)]
		public string PageNo { get; set; }

		[DataMember]
		[Column("FlightType")]
		public short? FlightType { get; set; }

		[DataMember]
		[Column("Level")]
		public int? LevelId { get; set; }

		[DataMember]
		[Column("Distance")]
		public int? Distance { get; set; }

		[DataMember]
		[Column("DistanceMeasure")]
		public int? DistanceMeasure { get; set; }

		[DataMember]
		[Column("TakeOffWeight")]
		public double? TakeOffWeight { get; set; }

		[DataMember]
		[Column("AlignmentBefore")]
		public double? AlignmentBefore { get; set; }

		[DataMember]
		[Column("AlignmentAfter")]
		public double? AlignmentAfter { get; set; }

		[DataMember]
		[Column("FlightCategory")]
		public short? FlightCategory { get; set; }

		[DataMember]
		[Column("AtlbRecordType"), Required]
		public short AtlbRecordType { get; set; }

		[DataMember]
		[Column("FlightAircraftCode")]
		public short? FlightAircraftCode { get; set; }

		[DataMember]
		[Column("CancelReasonId")]
		public int? CancelReasonId { get; set; }

		[DataMember]
		[Column("StationFromId")]
		public int? StationFromId { get; set; }

		[DataMember]
		[Column("StationToId")]
		public int? StationToId { get; set; }

		[DataMember]
		[Column("FlightNumber")]
		public int? FlightNumberId { get; set; }


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