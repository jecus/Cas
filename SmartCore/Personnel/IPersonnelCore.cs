using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Personnel
{
	public interface IPersonnelCore
	{
		void Save(Specialist specialist, bool isCAA = false);
		void Delete(Specialization specialization);
		void Delete(SpecialistLicense license);
	}
}