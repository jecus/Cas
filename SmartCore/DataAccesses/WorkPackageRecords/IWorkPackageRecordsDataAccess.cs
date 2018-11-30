using System.Collections.Generic;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.DataAccesses.WorkPackageRecords
{
	public interface IWorkPackageRecordsDataAccess
	{
		void DeleteFromWorkPackage(int workPackageId, IEnumerable<IBaseEntityObject> recordsToDelete);
	}
}