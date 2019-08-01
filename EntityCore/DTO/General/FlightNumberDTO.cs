using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("FlightNumbers", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightNumberDTO : BaseEntity
	{
		
		[Column("FlightNo")]
		public int? FlightNoId { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		
		[Column("MaxFuelAmount")]
		public double? MaxFuelAmount { get; set; }

		
		[Column("MinFuelAmount")]
		public double? MinFuelAmount { get; set; }

		
		[Column("MaxPayload")]
		public double? MaxPayload { get; set; }

		
		[Column("MaxCargoWeight")]
		public double? MaxCargoWeight { get; set; }

		
		[Column("MaxTakeOffWeight")]
		public double? MaxTakeOffWeight { get; set; }

		
		[Column("MaxLandWeight")]
		public double? MaxLandWeight { get; set; }

		
		[Column("FlightAircraftCode")]
		public int? FlightAircraftCode { get; set; }

		
		[Column("FlightType")]
		public int FlightType { get; set; }

		
		[Column("FlightCategory")]
		public int? FlightCategory { get; set; }

		
		[Column("Distance")]
		public int? Distance { get; set; }

		
		[Column("DistanceMeasure")]
		public int? DistanceMeasure { get; set; }

		
		[Column("StationFrom")]
		public int? StationFromId { get; set; }

		
		[Column("StationTo")]
		public int? StationToId { get; set; }

		
		[Column("MinLevel")]
		public int? MinLevelId { get; set; }

		
		[Column("MaxPassengerAmount")]
		public int? MaxPassengerAmount { get; set; }

		
		[Column("Threshold"), MaxLength(21)]
		public byte[] Threshold { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }


		
		[Include]
		public FlightNumDTO FlightNo { get; set; }

		
		[Include]
		public AirportCodeDTO StationFrom { get; set; }

		
		[Include]
		public AirportCodeDTO StationTo { get; set; }

		
		[Include]
		public CruiseLevelDTO MinLevel { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberAirportRelationDTO> AirportRelationDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }

		#endregion
	}
}