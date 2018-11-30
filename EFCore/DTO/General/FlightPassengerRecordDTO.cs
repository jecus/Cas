using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class FlightPassengerRecordDTO : BaseEntity
	{
		[DataMember]
		public int? FlightId { get; set; }

		[DataMember]
		public int? PassengerCategoryId { get; set; }

		[DataMember]
		public short? CountEconomy { get; set; }

		[DataMember]
		public short? CountBusiness { get; set; }

		[DataMember]
		public short? CountFirst { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Include]
		public AGWCategorieDTO PassengerCategory { get; set; }
	}
}