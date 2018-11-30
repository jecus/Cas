using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightTrackDTO : BaseEntity
	{
		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? DayOfWeek { get; set; }

		[DataMember]
		public int? TripNameId { get; set; }

		[DataMember]
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