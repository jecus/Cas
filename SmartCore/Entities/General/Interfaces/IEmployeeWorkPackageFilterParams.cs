using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IEmployeeWorkPackageFilterParams
	{
		#region string FirstName { get; }

		[Filter("First Name:", Order = 1)]
		string FirstName { get; }
		#endregion

		#region string LastName { get; }

		[Filter("Last Name:", Order = 2)]
		string LastName { get; }
		#endregion

		#region Specialization Specialization { get; }

		[Filter("Occupation:", Order = 3)]
		Occupation Occupation { get; }
			#endregion

		#region List<AircraftModel> LicenseAircrafts { get; }

		[Filter("Aircraft Model:", Order = 11)]
		List<AircraftModel> LicenseAircrafts { get; }
		#endregion

		#region List<LicenseFunction> LicenseFunctions { get; }

		[Filter("Function:", Order = 12)]
		List<LicenseFunction> LicenseFunctions { get; }
		#endregion

		#region List<LicenseRights> LicenseRights { get; }

		[Filter("Rights:", Order = 13)]
		List<LicenseRights> LicenseRights { get; }

		#endregion
	}
}