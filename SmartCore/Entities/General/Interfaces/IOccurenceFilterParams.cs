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

		[Filter("FDR:", Order = 4)]
		string FDR { get; set; }

		[Filter("PageNo:", Order = 5)]
		string PageNo { get; }

		[Filter("Description:", Order = 6)]
		string Description { get;}

		[Filter("Route:", Order = 7)]
		string ParentFlightRoute { get; }

		[Filter("MEL:", Order = 8)]
		string DeferredCategory { get; }


		[Filter("FilledBy:", Order = 9)]
		string FilledByString { get; }

		[Filter("MRO:", Order = 10)]
		string MRO { get; }

		[Filter("Comp. Off P/N:", Order = 11)]
		string PartNumberOff { get; }

		[Filter("Comp. Off S/N:", Order = 12)]
		string SerialNumberOff { get; }

		[Filter("Comp. On P/N:", Order = 13)]
		string PartNumberOn { get; }

		[Filter("Comp. On S/N:", Order = 14)]
		string SerialNumberOn { get; }


		[Filter("SRC Record Date:", Order = 15)]
		DateTime? CertificateOfReleaseToServiceRecordDate { get; }

		[Filter("Aircraft:", Order = 20)]
		Aircraft Aircraft { get; }

		[Filter("Status:", Order = 35)]
		CorrectiveActionStatus Status { get;}

		[Filter("ATA:", Order = 22)]
		AtaChapter ATAChapter { get; }

		[Filter("DeffeсtPhase:", Order = 23)]
		DeffeсtPhase DeffeсtPhase { get; }

		[Filter("DeffectConfirm:", Order = 24)]
		DeffectConfirm DeffectConfirm { get; }

		[Filter("DeffeсtCategory:", Order = 25)]
		DeffeсtCategory DeffeсtCategory { get; }

		[Filter("ActionType:", Order = 26)]
		ActionType ActionType { get; }

		[Filter("ConsequenceFault:", Order = 27)]
		ConsequenceFaults ConsequenceFault { get; }

		[Filter("ConsequenceOps:", Order = 28)]
		ConsequenceOPS ConsequenceOps { get; }

		[Filter("ConsequenceType:", Order = 29)]
		IncidentType ConsequenceType { get; }

		[Filter("Occurrence:", Order = 30)]
		OccurrenceType Occurrence { get; }

		[Filter("InterruptionType:", Order = 31)]
		InterruptionType InterruptionType { get; }

		[Filter("Station:", Order = 32)]
		AirportsCodes StationTo { get; }

		[Filter("Auth B1:", Order = 33)]
		Specialist CertificateOfReleaseToServiceAuthorizationB1 { get; }

		[Filter("Auth B2:", Order = 34)]
		Specialist CertificateOfReleaseToServiceAuthorizationB2 { get; }

		[Filter("Model:", Order = 21)]
		AircraftModel Model { get; }
	}
}