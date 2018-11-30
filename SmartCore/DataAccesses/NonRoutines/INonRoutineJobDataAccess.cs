using System.Collections.Generic;

namespace SmartCore.DataAccesses.NonRoutines
{
	public interface INonRoutineJobDataAccess
	{
		IList<NonRoutineJobDTO> GetNonRoutineJobDTOs(IEnumerable<int> nonRoutineIds);

		IEnumerable<NonRoutineJobDTO> GetNonRoutineJobDTOs();

		IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKits();

		IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKitsByWorkPackageId(int workPackageId);

		IList<NonRoutineJobDTO> GetNonRoutineJobDTOsFromAircraftWorkPackages(int aircraftId);

		void Save(NonRoutineJobDTO nrjDTO);

		void Delete(NonRoutineJobDTO nrjDTO);
	}
}