using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("Documents", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAADocumentDTO : BaseEntity
	{
	    
		[Column("ParentID")]
		public int? ParentID { get; set; }

		
		[Column("ParentTypeId")]
		public int ParentTypeId { get; set; }

		
		[Column("DocTypeId")]
		public int DocTypeId { get; set; }

		
		[Column("SubTypeId")]
		public int? SubTypeId { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("IssueDateValidFrom")]
		public DateTime IssueDateValidFrom { get; set; }

		
		[Column("IssueValidTo")]
		public bool? IssueValidTo { get; set; }

		
		[Column("IssueDateValidTo")]
		public DateTime IssueDateValidTo { get; set; }

		
		[Column("IssueNotify")]
		public int? IssueNotify { get; set; }

		
		[Column("ContractNumber"), MaxLength(128)]
		public string ContractNumber { get; set; }

		
		[Column("Revision")]
		public bool? Revision { get; set; }

		
		[Column("RevNumber"), MaxLength(128)]
		public string RevNumber { get; set; }

		
		[Column("RevisionDateFrom")]
		public DateTime? RevisionDateFrom { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		
		[Column("RevisionValidTo")]
		public bool? RevisionValidTo { get; set; }

		
		[Column("RevisionDateValidTo")]
		public DateTime? RevisionDateValidTo { get; set; }

		
		[Column("RevisionNotify")]
		public int? RevisionNotify { get; set; }

		
		[Column("Aboard")]
		public bool Aboard { get; set; }

		
		[Column("Privy")]
		public bool Privy { get; set; }

		
		[Column("IssueNumber"), MaxLength(128)]
		public string IssueNumber { get; set; }

		
		[Column("NomenсlatureId")]
		public int? NomenсlatureId { get; set; }

		
		[Column("ProlongationWayId")]
		public int? ProlongationWayId { get; set; }

		
		[Column("ServiceTypeId")]
		public int? ServiceTypeId { get; set; }

		
		[Column("ResponsibleOccupationId")]
		public int? ResponsibleOccupationId { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("LocationId")]
		public int? LocationId { get; set; }

		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("ParentAircraftId")]
		public int? ParentAircraftId { get; set; }

        
        [Column("IdNumber"), MaxLength(128)]
		public string IdNumber { get; set; }

        
		[Include]
		public CAADocumentSubTypeDTO DocumentSubType { get; set; }

		
		[Child]
		public CAASupplierDTO Supplier { get; set; }

		
		[Include]
		public CAASpecializationDTO ResponsibleOccupation { get; set; }

		
		[Child]
		public CAANomenclatureDTO Nomenсlature { get; set; }

		
		[Child]
		public CAAServiceTypeDTO ServiceType { get; set; }

		
		[Child]
		public CAADepartmentDTO Department { get; set; }

		
		[Include]
		public CAALocationDTO Location { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public CAASupplierDTO SupplieDto { get; set; }

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }

		[JsonIgnore]
		public ICollection<CAAProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }

		#endregion
	}
}