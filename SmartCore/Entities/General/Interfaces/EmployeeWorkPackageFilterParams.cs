using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface EmployeeWorkPackageFilterParams
	{
		#region string Title { get;}

		[Filter("Title:", Order = 1)]
		string Title { get;}
			#endregion

		#region DateTime ClosingDate { get; }

		[Filter("Closing Date:", Order = 2)]
		DateTime ClosingDate { get; }
			#endregion

		#region string Station { get; }

		[Filter("Closing Date:", Order = 3)]
		string Station { get; }
			#endregion

		#region List<AircraftModel> LicenseAircrafts { get; }

		[Filter("Aircraft:", Order = 4)]

		Aircraft Aircraft { get; }
		#endregion

		#region List<LicenseFunction> LicenseFunctions { get; }

		[Filter("Function:", Order = 5)]
		List<LicenseFunction> LicenseFunctions { get; }
		#endregion

		#region List<LicenseRights> LicenseRights { get; }

		[Filter("Rights:", Order = 6)]
		List<LicenseRights> LicenseRights { get; }

		#endregion
	}
}