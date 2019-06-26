﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("RequestsForQuotation", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class RequestForQuotationDTO : BaseEntity
	{
		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("Status")]
		public int? Status { get; set; }

		[DataMember]
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("ToSupplier")]
		public int? ToSupplierId { get; set; }

		[DataMember]
		[Column("PublishedById")]
		public int PublishedById { get; set; }

		[DataMember]
		[Column("ClosedById")]
		public int ClosedById { get; set; }

		[DataMember]
		[Column("PublishedByUser"), MaxLength(128)]
		public string PublishedByUser { get; set; }

		[DataMember]
		[Column("CloseByUser"), MaxLength(128)]
		public string CloseByUser { get; set; }

		[DataMember]
		[Column("Number"), MaxLength(128)]
		public string Number { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1900)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child]
		public ICollection<RequestForQuotationRecordDTO> PackageRecords { get; set; }
	}
}