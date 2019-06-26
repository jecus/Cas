using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("ATLBs", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ATLBDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("AircraftID")]
		public int? AircraftID { get; set; }

		[DataMember]
		[Column("ATLBNo"), MaxLength(128)]
		public string ATLBNo { get; set; }

		[DataMember]
		[Column("StartPageNo")]
		public int? StartPageNo { get; set; }

		[DataMember]
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Revision"), MaxLength(128)]
		public string Revision { get; set; }

		[DataMember]
		[Column("PageFlightCount")]
		public int? PageFlightCount { get; set; }

		[DataMember]
		[Column("AtlbStatus"), Required]
		public int AtlbStatus { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1040)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}