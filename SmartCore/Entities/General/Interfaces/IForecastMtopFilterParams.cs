using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.MTOP;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IForecastMtopFilterParams
	{
		[Filter("Condition:")]
		ConditionState Condition { get;}

		[Filter("Status:")]
		DirectiveStatus Status { get; }

		[Filter("ATA Chapter:")]
		AtaChapter ATAChapter { get; }

		[Filter("Title:", Order = 1)]
		string Title { get; }

		[Filter("Description:", Order = 2)]
		string Description { get; }

		[Filter("Task type:", Order = 5)]
		SmartCoreType SmartCoreType { get; }

		[Filter("Check type:", Order = 6)]
		MaintenanceCheckType MaintenanceCheckType { get; }

		[Filter("1st. Perf:")]
		Lifelength FirstPerformanceSinceNew { get; }

		[Filter("Rpt. Int:")]
		Lifelength RepeatInterval { get; }

		[Filter("Check:", Order = 7)]
		MTOPCheck ParentCheck { get; }
	}
}