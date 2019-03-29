using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DocumentDTO : BaseEntity
	{
	    [DataMember]
		public int ParentID { get; set; }

		[DataMember]
		public int ParentTypeId { get; set; }

		[DataMember]
		public int DocTypeId { get; set; }

		[DataMember]
		public int SubTypeId { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public DateTime IssueDateValidFrom { get; set; }

		[DataMember]
		public bool? IssueValidTo { get; set; }

		[DataMember]
		public DateTime IssueDateValidTo { get; set; }

		[DataMember]
		public int? IssueNotify { get; set; }

		[DataMember]
		public string ContractNumber { get; set; }

		[DataMember]
		public bool? Revision { get; set; }

		[DataMember]
		public string RevNumber { get; set; }

		[DataMember]
		public DateTime? RevisionDateFrom { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public int? DepartmentId { get; set; }

		[DataMember]
		public bool? RevisionValidTo { get; set; }

		[DataMember]
		public DateTime? RevisionDateValidTo { get; set; }

		[DataMember]
		public int? RevisionNotify { get; set; }

		[DataMember]
		public bool Aboard { get; set; }

		[DataMember]
		public bool Privy { get; set; }

		[DataMember]
		public string IssueNumber { get; set; }

		[DataMember]
		public int? NomenсlatureId { get; set; }

		[DataMember]
		public int? ProlongationWayId { get; set; }

		[DataMember]
		public int? ServiceTypeId { get; set; }

		[DataMember]
		public int ResponsibleOccupationId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int LocationId { get; set; }

		[DataMember]
		public int SupplierId { get; set; }

		[DataMember]
		public int? ParentAircraftId { get; set; }

        [DataMember]
        public string IdNumber { get; set; }

        [DataMember]
		[Include]
		public DocumentSubTypeDTO DocumentSubType { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Include]
		public SpecializationDTO ResponsibleOccupation { get; set; }

		[DataMember]
		[Child]
		public NomenclatureDTO Nomenсlature { get; set; }

		[DataMember]
		[Child]
		public ServiceTypeDTO ServiceType { get; set; }

		[DataMember]
		[Child]
		public DepartmentDTO Department { get; set; }

		[DataMember]
		[Include]
		public LocationDTO Location { get; set; }


		#region Navigation Property

		[DataMember]
		public SupplierDTO SupplieDto { get; set; }
		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }
		[DataMember]
		public ICollection<ProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }

		#endregion
	}
}