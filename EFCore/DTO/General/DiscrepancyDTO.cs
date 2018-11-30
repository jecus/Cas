using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class DiscrepancyDTO : BaseEntity
	{
		[DataMember]
		public int FlightID { get; set; }

		[DataMember]
		public bool FilledBy { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string PilotRemarks { get; set; }

		[DataMember]
		public int ATAChapterID { get; set; }

		[DataMember]
		public int DirectiveId { get; set; }

		[DataMember]
		public int? Num { get; set; }

		[DataMember]
		public int DeffeсtPhase { get; set; }

		[DataMember]
		public int DeffeсtCategory { get; set; }

		[DataMember]
		public int DeffectConfirm { get; set; }

		[DataMember]
		public int ActionType { get; set; }

		[DataMember]
		public int ConsequenceFault { get; set; }

		[DataMember]
		public int ConsequenceOps { get; set; }

		[DataMember]
		public int TimeDelay { get; set; }

		[DataMember]
		public int ConsequenceType { get; set; }

		[DataMember]
		public int InterruptionType { get; set; }

		[DataMember]
		public int Occurrence { get; set; }

		[DataMember]
		public int AuthId { get; set; }

		[DataMember]
		public int BaseComponentId { get; set; }

		[DataMember]
		public bool IsOccurrence { get; set; }

		[DataMember]
		public bool Substruction { get; set; }

		[DataMember]
		public bool EngineShutUp { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string EngineRemarks { get; set; }

		[DataMember]
		public string Messages { get; set; }

		[DataMember]
		public string FDR { get; set; }

		[DataMember]
		public int? WorkPackageId { get; set; }

		[DataMember]
		public int Status { get; set; }

		[DataMember]
		public bool IsReliability { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO Auth { get; set; }
	}
}