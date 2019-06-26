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
	
	[Condition("IsDeleted", 0)]
	public class ATLBDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("AircraftID")]
		public int? AircraftID { get; set; }

		
		[Column("ATLBNo"), MaxLength(128)]
		public string ATLBNo { get; set; }

		
		[Column("StartPageNo")]
		public int? StartPageNo { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("Revision"), MaxLength(128)]
		public string Revision { get; set; }

		
		[Column("PageFlightCount")]
		public int? PageFlightCount { get; set; }

		
		[Column("AtlbStatus"), Required]
		public int AtlbStatus { get; set; }


		
		[Child(FilterType.Equal, "ParentTypeId", 1040)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}