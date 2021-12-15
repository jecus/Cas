using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.DataAccesses.WorkPackageRecords
{
	public class WorkPackageRecordsDataAccess : IWorkPackageRecordsDataAccess
	{
		private readonly ICasEnvironment _environment;

		public WorkPackageRecordsDataAccess(ICasEnvironment environment)
		{
			_environment = environment;
		}

		public void DeleteFromWorkPackage(int workPackageId, IEnumerable<IBaseEntityObject> recordsToDelete)
		{
			var recordsIds = recordsToDelete.Select(r => r.ItemId).ToArray();
			var recordsTypesIds = recordsToDelete.Select(r => r.SmartCoreObjectType.ItemId).Distinct().ToArray();

			var query = BaseQueries.GetDeleteQuery<WorkPackageRecord>(new ICommonFilter[]
			{
				new CommonFilter<int>(WorkPackageRecord.DirectiveIdProperty, FilterType.In, recordsIds),
				new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, FilterType.In, recordsTypesIds),
				new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId)
			});

			_environment.Execute(query);
		}
	}
}