using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Models.DTO.Dictionaries;

namespace Entity.Models.DTO.General 
{
	[Table("AircraftFlights", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AircraftFlightDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("ATLBID")]
		public int ATLBID { get; set; }

		
		[Column("AircraftId")]
		public int? AircraftId { get; set; }

		
		[Column("FlightNo"), MaxLength(128)]
		public string FlightNo { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("FlightDate")]
		public DateTime? FlightDate { get; set; }

		
		[Column("StationFrom"), MaxLength(128)]
		public string StationFrom { get; set; }

		
		[Column("StationTo"), MaxLength(128)]
		public string StationTo { get; set; }

		
		[Column("DelayTime")]
		public short? DelayTime { get; set; }

		
		[Column("DelayReasonId")]
		public int? DelayReasonId { get; set; }

		
		[Column("OutTime")]
		public int? OutTime { get; set; }

		
		[Column("InTime")]
		public int? InTime { get; set; }

		
		[Column("TakeOffTime")]
		public int? TakeOffTime { get; set; }

		
		[Column("LDGTime")]
		public int? LDGTime { get; set; }

		
		[Column("NightTime")]
		public int? NightTime { get; set; }

		
		[Column("CRSID")]
		public int? CRSID { get; set; }

		
		[Column("FileID")]
		public int? FileID { get; set; }

		
		[Column("Tanks")]
		public string Tanks { get; set; }

		
		[Column("Fluids")]
		public string Fluids { get; set; }

		
		[Column("EnginesGeneralCondition")]
		public string EnginesGeneralCondition { get; set; }

		
		[Column("Highlight")]
		public int? Highlight { get; set; }

		
		[Column("Correct")]
		public bool Correct { get; set; }

		
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

		
		[Column("Cycles")]
		public int Cycles { get; set; }

		
		[Column("PageNo"), MaxLength(128)]
		public string PageNo { get; set; }

		
		[Column("FlightType")]
		public short? FlightType { get; set; }

		
		[Column("Level")]
		public int? LevelId { get; set; }

		
		[Column("Distance")]
		public int? Distance { get; set; }

		
		[Column("DistanceMeasure")]
		public int? DistanceMeasure { get; set; }

		
		[Column("TakeOffWeight")]
		public double? TakeOffWeight { get; set; }

		
		[Column("AlignmentBefore")]
		public double? AlignmentBefore { get; set; }

		
		[Column("AlignmentAfter")]
		public double? AlignmentAfter { get; set; }

		
		[Column("FlightCategory")]
		public short? FlightCategory { get; set; }

		
		[Column("AtlbRecordType")]
		public short AtlbRecordType { get; set; }

		
		[Column("FlightAircraftCode")]
		public short? FlightAircraftCode { get; set; }

		
		[Column("CancelReasonId")]
		public int? CancelReasonId { get; set; }

		
		[Column("StationFromId")]
		public int? StationFromId { get; set; }

		
		[Column("StationToId")]
		public int? StationToId { get; set; }

		
		[Column("FlightNumber")]
		public int? FlightNumberId { get; set; }


		
		[Include]
		public FlightNumDTO FlightNumber { get; set; }

		
		[Include]
		public CruiseLevelDTO Level { get; set; }

		
		[Include]
		public AirportCodeDTO StationFromDto { get; set; }

		
		[Include]
		public AirportCodeDTO StationToDto { get; set; }

		
		[Include]
		public ReasonDTO DelayReason { get; set; }

		
		[Include]
		public ReasonDTO CancelReason { get; set; }


		
		[Child(FilterType.Equal, "ParentTypeId", 13)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

	}
}