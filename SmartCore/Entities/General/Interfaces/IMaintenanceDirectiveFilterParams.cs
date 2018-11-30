using System;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IMaintenanceDirectiveFilterParams : IWorkPackageItemFilterParams
	{
		[Filter("MPD Item:", Order = 1)]
		string TaskNumberCheck { get; }

		[Filter("Task Card №:", Order = 3)]
		string TaskCardNumber { get; }

		[Filter("Zone:", Order = 4)]
		string Zone { get; }

		[Filter("Access:", Order = 5)]
		string Access { get;}


		[Filter("ATA Chapter:", Order = 12)]
		AtaChapter ATAChapter { get; }

		[Filter("Work Type:", Order = 10)]
		MaintenanceDirectiveTaskType WorkType { get; }

		[Filter("Status:", Order = 14)]
		DirectiveStatus Status { get; }

		[Filter("1st. Perf:")]
		Lifelength FirstPerformanceSinceNew { get; }

		[Filter("Rpt. Int:")]
		Lifelength RepeatInterval { get; }

		[Filter("Remarks:", Order = 6)]
		string Remarks { get; }

		[Filter("Hidden Remarks:", Order = 7)]
		string HiddenRemarks { get; }

		[Filter("Condition:", Order = 16)]
		ConditionState Condition { get; }


		[Filter("Phase")]
		Phase MTOPPhase { get; }

	}
}