using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IEmployeeFlightFilterParams : IBaseEntityObject
	{

		[Filter("Aircraft : ", Order = 0)]
		Aircraft Aircraft { get; }

		[Filter("Aircraft Type : ", Order = 1)]
		AircraftModel AircraftModel { get; }

		[Filter("Occupation : ", Order = 2)]
		Occupation Occupation { get; }
	}
}