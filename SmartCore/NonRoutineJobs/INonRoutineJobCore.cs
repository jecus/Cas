using System.Collections.Generic;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;

namespace SmartCore.NonRoutineJobs
{
	public interface INonRoutineJobCore
	{
		NonRoutineJob[] GetNonRoutineJobsStatus(Aircraft aircraft);
		IEnumerable<NonRoutineJob> GetNonRoutineJobs();
		void Save(NonRoutineJob nonRoutineJob);
		void Delete(NonRoutineJob nonRoutineJob);
	}
}