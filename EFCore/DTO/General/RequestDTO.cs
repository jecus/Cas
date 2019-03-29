using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class RequestDTO : BaseEntity
	{
		[DataMember]
		public DateTime? PreparedByDate { get; set; }

		[DataMember]
		public int? PreparedById { get; set; }

		[DataMember]
		public DateTime? CheckedByDate { get; set; }

		[DataMember]
		public int? CheckedById { get; set; }

		[DataMember]
		public DateTime? ApprovedByDate { get; set; }

		[DataMember]
		public int? ApprovedById { get; set; }

		[DataMember]
		public string RequestdHeader { get; set; }

		[DataMember]
		public string RequestFooter { get; set; }

		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public short? Status { get; set; }

		[DataMember]
		public DateTime? CreateDate { get; set; }

		[DataMember]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		public int? FileId { get; set; }

		[DataMember]
		public string PublishedBy { get; set; }

		[DataMember]
		public string ClosedBy { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string PublishingRemarks { get; set; }

		[DataMember]
		public string ClosingRemarks { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO PreparedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO CheckedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO ApprovedBy { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1450)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<RequestRecordDTO> PackageRecords { get; set; }
	}
}