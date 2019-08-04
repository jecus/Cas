using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("InitialOrders", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class InitialOrderDTO : BaseEntity
	{
		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("PublishedById")]
		public int? PublishedById { get; set; }

		
		[Column("ClosedById")]
		public int? ClosedById { get; set; }

		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("Status")]
		public short? Status { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("PublishedByUser"), MaxLength(128)]
		public string PublishedByUser { get; set; }

		
		[Column("CloseByUser"), MaxLength(128)]
		public string CloseByUser { get; set; }

		
		[Column("Number"), MaxLength(128)]
		public string Number { get; set; }


		//
		//[Include]
		//public SpecialistDTO PublishedBy { get; set; }

		//
		//[Include]
		//public SpecialistDTO ClosedBy { get; set; }


		
		[Child(FilterType.Equal, "ParentTypeId", 1560)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
		
		
		[Child]
		public ICollection<InitialOrderRecordDTO> PackageRecords { get; set; }
	}
}