using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("Discrepancies", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class DiscrepancyDTO : BaseEntity
	{
		
		[Column("FlightID")]
		public int FlightID { get; set; }

		
		[Column("FilledBy")]
		public bool FilledBy { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("PilotRemarks")]
		public string PilotRemarks { get; set; }

		
		[Column("ATAChapterID")]
		public int? ATAChapterID { get; set; }

		
		[Column("DirectiveId")]
		public int DirectiveId { get; set; }

		
		[Column("Num")]
		public int? Num { get; set; }

		
		[Column("DeffeсtPhase")]
		public int DeffeсtPhase { get; set; }

		
		[Column("DeffeсtCategory")]
		public int DeffeсtCategory { get; set; }

		
		[Column("DeffectConfirm")]
		public int DeffectConfirm { get; set; }

		
		[Column("ActionType")]
		public int ActionType { get; set; }

		
		[Column("ConsequenceFault")]
		public int ConsequenceFault { get; set; }

		
		[Column("ConsequenceOps")]
		public int ConsequenceOps { get; set; }

		
		[Column("TimeDelay")]
		public int TimeDelay { get; set; }

		
		[Column("ConsequenceType")]
		public int ConsequenceType { get; set; }

		
		[Column("InterruptionType")]
		public int InterruptionType { get; set; }

		
		[Column("Occurrence")]
		public int Occurrence { get; set; }

		
		[Column("Auth")]
		public int? AuthId { get; set; }

		
		[Column("BaseComponentId")]
		public int BaseComponentId { get; set; }

		
		[Column("IsOccurrence")]
		public bool IsOccurrence { get; set; }

		
		[Column("Substruction")]
		public bool Substruction { get; set; }

		
		[Column("EngineShutUp")]
		public bool EngineShutUp { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("EngineRemarks")]
		public string EngineRemarks { get; set; }

		
		[Column("Messages")]
		public string Messages { get; set; }

		
		[Column("FDR")]
		public string FDR { get; set; }

		
		[Column("WorkPackageId")]
		public int? WorkPackageId { get; set; }

		
		[Column("Status")]
		public int Status { get; set; }

		
		[Column("IsReliability")]
		public bool IsReliability { get; set; }

		
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		
		[Include]
		public SpecialistDTO Auth { get; set; }
	}
}