using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("FlightTrips", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightTrackDTO : BaseEntity
	{
		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("DayOfWeek")]
		public int? DayOfWeek { get; set; }

		[DataMember]
		[Column("TripName")]
		public int? TripNameId { get; set; }

		[DataMember]
		[Column("SupplierID"), Required]
		public int SupplierID { get; set; }

		[DataMember]
		[Include]
		public TripNameDTO TripName { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Child]
		public ICollection<FlightTrackRecordDTO> FlightTripRecord { get; set; }
	}
}