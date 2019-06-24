using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("Documents", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DocumentDTO : BaseEntity
	{
	    [DataMember]
		[Column("ParentID"), Required]
		public int ParentID { get; set; }

		[DataMember]
		[Column("ParentTypeId"), Required]
		public int ParentTypeId { get; set; }

		[DataMember]
		[Column("DocTypeId"), Required]
		public int DocTypeId { get; set; }

		[DataMember]
		[Column("SubTypeId"), Required]
		public int SubTypeId { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("IssueDateValidFrom"), Required]
		public DateTime IssueDateValidFrom { get; set; }

		[DataMember]
		[Column("IssueValidTo")]
		public bool? IssueValidTo { get; set; }

		[DataMember]
		[Column("IssueDateValidTo"), Required]
		public DateTime IssueDateValidTo { get; set; }

		[DataMember]
		[Column("IssueNotify")]
		public int? IssueNotify { get; set; }

		[DataMember]
		[Column("ContractNumber"), MaxLength(128)]
		public string ContractNumber { get; set; }

		[DataMember]
		[Column("Revision")]
		public bool? Revision { get; set; }

		[DataMember]
		[Column("RevNumber"), MaxLength(128)]
		public string RevNumber { get; set; }

		[DataMember]
		[Column("RevisionDateFrom")]
		public DateTime? RevisionDateFrom { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		[DataMember]
		[Column("RevisionValidTo")]
		public bool? RevisionValidTo { get; set; }

		[DataMember]
		[Column("RevisionDateValidTo")]
		public DateTime? RevisionDateValidTo { get; set; }

		[DataMember]
		[Column("RevisionNotify")]
		public int? RevisionNotify { get; set; }

		[DataMember]
		[Column("Aboard"), Required]
		public bool Aboard { get; set; }

		[DataMember]
		[Column("Privy"), Required]
		public bool Privy { get; set; }

		[DataMember]
		[Column("IssueNumber"), MaxLength(128)]
		public string IssueNumber { get; set; }

		[DataMember]
		[Column("NomenсlatureId")]
		public int? NomenсlatureId { get; set; }

		[DataMember]
		[Column("ProlongationWayId")]
		public int? ProlongationWayId { get; set; }

		[DataMember]
		[Column("ServiceTypeId")]
		public int? ServiceTypeId { get; set; }

		[DataMember]
		[Column("ResponsibleOccupationId"), Required]
		public int ResponsibleOccupationId { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("LocationId"), Required]
		public int LocationId { get; set; }

		[DataMember]
		[Column("SupplierId"), Required]
		public int SupplierId { get; set; }

		[DataMember]
		[Column("ParentAircraftId"), Required]
		public int? ParentAircraftId { get; set; }

        [DataMember]
        [Column("IdNumber"), MaxLength(128)]
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