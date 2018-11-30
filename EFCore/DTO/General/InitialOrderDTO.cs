using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class InitialOrderDTO : BaseEntity
	{
		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string RFQ { get; set; }

		[DataMember]
		public string QR { get; set; }

		[DataMember]
		public string PO { get; set; }

		[DataMember]
		public string Invoice { get; set; }

		[DataMember]
		public string ShipTo { get; set; }

		[DataMember]
		public string PickUp { get; set; }

		[DataMember]
		public string Weight { get; set; }

		[DataMember]
		public string DIMS { get; set; }

		[DataMember]
		public int TypeOfOperation { get; set; }

		[DataMember]
		public int ApprovedById { get; set; }

		[DataMember]
		public int PublishedById { get; set; }

		[DataMember]
		public int ClosedById { get; set; }

		[DataMember]
		public int ShipBy { get; set; }

		[DataMember]
		public int IncoTerm { get; set; }

		[DataMember]
		public int CountryId { get; set; }

		[DataMember]
		public int CarrierId { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Author { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public short? Status { get; set; }

		[DataMember]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		[Include]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO ApprovedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO PublishedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO ClosedBy { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1560)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
		
		[DataMember]
		[Child]
		public ICollection<InitialOrderRecordDTO> PackageRecords { get; set; }
	}
}