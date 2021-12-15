using System.Collections.Generic;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Aircrafts
{
	public interface IAircraftsCore
	{
		void LoadAllAircrafts();
		Aircraft GetAircraftById(int aircraftId);
		IList<Aircraft> GetAllAircrafts();
		int GetAircraftsCount();
		void RegisterAircraft(Aircraft aircraft, int operatorId);
		void DeleteAircraft(int aircraftId);
		void UpdateAircraft(Aircraft aircraft);
        Aircraft GetParentAircraft(IBaseEntityObject item);

	}
}