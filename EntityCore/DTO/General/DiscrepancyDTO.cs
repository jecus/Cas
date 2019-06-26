using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("Discrepancies", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class DiscrepancyDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightID"), Required]
		public int FlightID { get; set; }

		[DataMember]
		[Column("FilledBy"), Required]
		public bool FilledBy { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("PilotRemarks")]
		public string PilotRemarks { get; set; }

		[DataMember]
		[Column("ATAChapterID")]
		public int? ATAChapterID { get; set; }

		[DataMember]
		[Column("DirectiveId")]
		public int DirectiveId { get; set; }

		[DataMember]
		[Column("Num")]
		public int? Num { get; set; }

		[DataMember]
		[Column("DeffeсtPhase")]
		public int DeffeсtPhase { get; set; }

		[DataMember]
		[Column("DeffeсtCategory")]
		public int DeffeсtCategory { get; set; }

		[DataMember]
		[Column("DeffectConfirm")]
		public int DeffectConfirm { get; set; }

		[DataMember]
		[Column("ActionType")]
		public int ActionType { get; set; }

		[DataMember]
		[Column("ConsequenceFault")]
		public int ConsequenceFault { get; set; }

		[DataMember]
		[Column("ConsequenceOps")]
		public int ConsequenceOps { get; set; }

		[DataMember]
		[Column("TimeDelay")]
		public int TimeDelay { get; set; }

		[DataMember]
		[Column("ConsequenceType")]
		public int ConsequenceType { get; set; }

		[DataMember]
		[Column("InterruptionType")]
		public int InterruptionType { get; set; }

		[DataMember]
		[Column("Occurrence")]
		public int Occurrence { get; set; }

		[DataMember]
		[Column("Auth")]
		public int? AuthId { get; set; }

		[DataMember]
		[Column("BaseComponentId")]
		public int BaseComponentId { get; set; }

		[DataMember]
		[Column("IsOccurrence")]
		public bool IsOccurrence { get; set; }

		[DataMember]
		[Column("Substruction")]
		public bool Substruction { get; set; }

		[DataMember]
		[Column("EngineShutUp")]
		public bool EngineShutUp { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("EngineRemarks")]
		public string EngineRemarks { get; set; }

		[DataMember]
		[Column("Messages")]
		public string Messages { get; set; }

		[DataMember]
		[Column("FDR")]
		public string FDR { get; set; }

		[DataMember]
		[Column("WorkPackageId")]
		public int? WorkPackageId { get; set; }

		[DataMember]
		[Column("Status")]
		public int Status { get; set; }

		[DataMember]
		[Column("IsReliability")]
		public bool IsReliability { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO Auth { get; set; }
	}
}