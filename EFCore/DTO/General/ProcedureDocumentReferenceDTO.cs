using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProcedureDocumentReferenceDTO : BaseEntity
	{
		[DataMember]
		public int? ProcedureId { get; set; }

		[DataMember]
		public int? DocumentId { get; set; }

		[DataMember]
		[Include]
		public ProcedureDTO Procedure { get; set; }

		[DataMember]
		[Child]
		public DocumentDTO Document { get; set; }

		#region Navigation Property

		[DataMember]
		public ProcedureDTO ProcedureDto { get; set; }

		#endregion
	}
}