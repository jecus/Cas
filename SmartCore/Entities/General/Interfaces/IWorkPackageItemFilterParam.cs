using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IWorkPackageItemFilterParams : IBaseEntityObject
	{
		#region string Title { get; }

		[Filter("Title:", Order = 1)]
		string Title { get; }

		#endregion

		#region string Description { get; }

		[Filter("Description:", Order = 2)]
		string Description { get; }

		#endregion

		#region bool NDTString { get; }

		[Filter("NDT:", Order = 3)]
		bool HasNDT { get; }
		#endregion

		#region bool HasKits { get; }

		[Filter("Kits:", Order = 4)]
		bool HasKits { get; }
			#endregion

		#region SmartCoreType SmartCoreObjectType { get; }

		[Filter("Task type:", Order = 5)]
		SmartCoreType SmartCoreType { get; }

		#endregion

		#region AtaChapter AtaChapter { get; }

		[Filter("ATA Chapter:", Order = 6)]
		AtaChapter ATAChapter { get; }

		#endregion

		#region Lifelength RepeatInterval { get; }

		[Filter("Rpt. Int:", Order = 7)]
		Lifelength RepeatInterval { get; }

		#endregion

		#region Lifelength FirstPerformanceSinceNew { get; }

		[Filter("1st. Perf:", Order = 8)]
		Lifelength FirstPerformanceSinceNew { get; }

		#endregion


	}
}
