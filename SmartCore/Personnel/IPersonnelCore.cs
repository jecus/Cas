using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Personnel
{
	public interface IPersonnelCore
	{
		void Save(Specialist specialist, bool isCAA = false);
		void Delete(Occupation occupation);
		void Delete(SpecialistLicense license);
	}
}