using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IOccurenceFilterParams
	{
		[Filter("IsReliability:", Order = 1)]
		bool IsReliability { get; }

		[Filter("IsSubstruction:", Order = 2)]
		bool Substruction { get; }

		[Filter("HasFDR:", Order = 3)]
		bool HasFDR { get; }

		[Filter("Occurrence:", Order = 4)]
		bool IsOccurrence { get; set; }

		[Filter("FDR:", Order = 5)]
		string FDR { get; set; }

		[Filter("PageNo:", Order = 6)]
		string PageNo { get; }

		[Filter("Description:", Order = 7)]
		string Description { get;}

		[Filter("Route:", Order = 8)]
		string ParentFlightRoute { get; }

		[Filter("MEL:", Order = 9)]
		string DeferredCategory { get; }


		[Filter("FilledBy:", Order = 10)]
		string FilledByString { get; }

		[Filter("MRO:", Order = 11)]
		string MRO { get; }

		[Filter("Comp. Off P/N:", Order = 12)]
		string PartNumberOff { get; }

		[Filter("Comp. Off S/N:", Order = 13)]
		string SerialNumberOff { get; }

		[Filter("Comp. On P/N:", Order = 14)]
		string PartNumberOn { get; }

		[Filter("Comp. On S/N:", Order = 15)]
		string SerialNumberOn { get; }


		[Filter("SRC Record Date:", Order = 16)]
		DateTime? CertificateOfReleaseToServiceRecordDate { get; }

		[Filter("Aircraft:", Order = 21)]
		Aircraft Aircraft { get; }

		[Filter("Status:", Order = 36)]
		CorrectiveActionStatus Status { get;}

		[Filter("ATA:", Order = 23)]
		AtaChapter ATAChapter { get; }

		[Filter("DeffeсtPhase:", Order = 24)]
		DeffeсtPhase DeffeсtPhase { get; }

		[Filter("DeffectConfirm:", Order = 25)]
		DeffectConfirm DeffectConfirm { get; }

		[Filter("DeffeсtCategory:", Order = 26)]
		DeffeсtCategory DeffeсtCategory { get; }

		[Filter("ActionType:", Order = 27)]
		ActionType ActionType { get; }

		[Filter("ConsequenceFault:", Order = 28)]
		ConsequenceFaults ConsequenceFault { get; }

		[Filter("ConsequenceOps:", Order = 29)]
		ConsequenceOPS ConsequenceOps { get; }

		[Filter("ConsequenceType:", Order = 30)]
		IncidentType ConsequenceType { get; }

		[Filter("Occurrence:", Order = 31)]
		OccurrenceType Occurrence { get; }

		[Filter("InterruptionType:", Order = 32)]
		InterruptionType InterruptionType { get; }

		[Filter("Station:", Order = 33)]
		AirportsCodes StationTo { get; }

		[Filter("Auth B1:", Order = 34)]
		Specialist CertificateOfReleaseToServiceAuthorizationB1 { get; }

		[Filter("Auth B2:", Order = 35)]
		Specialist CertificateOfReleaseToServiceAuthorizationB2 { get; }

		[Filter("Model:", Order = 22)]
		AircraftModel Model { get; }
	}
}