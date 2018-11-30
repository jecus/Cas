using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ATLBDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int? AircraftID { get; set; }

		[DataMember]
		public string ATLBNo { get; set; }

		[DataMember]
		public int? StartPageNo { get; set; }

		[DataMember]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string Revision { get; set; }

		[DataMember]
		public int? PageFlightCount { get; set; }

		[DataMember]
		public int AtlbStatus { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1040)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}