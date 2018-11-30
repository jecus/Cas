using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.Dictionaries
{
	//AirportsCodes
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AirportDTO : BaseEntity
	{
		[DataMember]
		public string ShortName { get; set; }

		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public int? LocalityId { get; set; }

		[DataMember]
		public int? Altitude { get; set; }

		[DataMember]
		public int? TimeBeginning { get; set; }

		[DataMember]
		public int? TimeEnd { get; set; }
	}
	
}
