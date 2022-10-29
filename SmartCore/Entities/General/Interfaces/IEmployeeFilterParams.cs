using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IEmployeeFilterParams
	{
		#region SpecialistStatus Status { get; }

		[Filter("Status:", Order = 0)]
		SpecialistStatus Status { get; }
		#endregion

		#region string FirstName { get; }

		[Filter("First Name:", Order = 1)]
		string FirstName { get; }
		#endregion

		#region string LastName { get; }

		[Filter("Last Name:", Order = 2)]
		string LastName { get; }
		#endregion

		#region Specialization Specialization { get; }

		[Filter("Specialization:", Order = 3)]
		Occupation Occupation { get; }
		#endregion

		[Filter("Department:", Order = 6)]
		Department Department { get; }

		#region DateTime DateOfBirth { get;}

		[Filter("Date Of Birth:", Order = 4)]
		DateTime DateOfBirth { get;}
		#endregion

		#region SpecialistPosition Position { get;}

		[Filter("Position:", Order = 5)]
		SpecialistPosition Position { get;}
		#endregion

		#region Locations Location { get; }

		[Filter("Facility:", Order = 11)]
		LocationsType Facility { get; }
		#endregion

		#region Gender Gender { get; }

		[Filter("Sex:", Order = 7)]
		Gender Gender { get; }
		#endregion

		#region Citizenship Citizenship { get; }

		[Filter("Nationality:", Order = 8)]
		Citizenship Citizenship { get; }
		#endregion

		#region FamilyStatus FamilyStatus { get; }

		[Filter("FamilyStatus:", Order = 9)]
		FamilyStatus FamilyStatus { get; }
		#endregion

		#region Education Education { get; }

		[Filter("Education:", Order = 10)]
		Education Education { get; }

		#endregion

		#region List<AircraftModel> LicenseAircrafts { get; }

		[Filter("Aircraft Model:", Order = 12)]
		List<AircraftModel> LicenseAircrafts { get; }
		#endregion

		#region List<LicenseFunction> LicenseFunctions { get; }

		[Filter("Function:", Order = 13)]
		List<LicenseFunction> LicenseFunctions { get; }
		#endregion

		#region List<LicenseRights> LicenseRights { get; }

		[Filter("Rights:", Order = 14)]
		List<LicenseRights> LicenseRights { get; }

		#endregion
	}

	public interface ICAAEmployeeFilterParams 
	{
		#region SpecialistStatus Status { get; }

		[Filter("Status:", Order = 0)]
		SpecialistStatus Status { get; }
		#endregion

		#region string FirstName { get; }

		[Filter("First Name:", Order = 1)]
		string FirstName { get; }
		#endregion

		#region string LastName { get; }

		[Filter("Last Name:", Order = 2)]
		string LastName { get; }
		#endregion

		#region Specialization Specialization { get; }

		[Filter("Specialization:", Order = 3)]
		Occupation Occupation { get; }
		#endregion

		[Filter("Department:", Order = 6)]
		Department Department { get; }

		#region DateTime DateOfBirth { get;}

		[Filter("Date Of Birth:", Order = 4)]
		DateTime DateOfBirth { get;}
		#endregion

		#region SpecialistPosition Position { get;}

		[Filter("Position:", Order = 5)]
		SpecialistPosition Position { get;}
		#endregion

		#region Locations Location { get; }

		[Filter("Facility:", Order = 11)]
		LocationsType Facility { get; }
		#endregion

		#region Gender Gender { get; }

		[Filter("Sex:", Order = 7)]
		Gender Gender { get; }
		#endregion

		#region Citizenship Citizenship { get; }

		[Filter("Nationality:", Order = 8)]
		Citizenship Citizenship { get; }
		#endregion

		#region FamilyStatus FamilyStatus { get; }

		[Filter("FamilyStatus:", Order = 9)]
		FamilyStatus FamilyStatus { get; }
		#endregion

		#region Education Education { get; }

		[Filter("Education:", Order = 10)]
		Education Education { get; }

		#endregion

		#region List<AircraftModel> LicenseAircrafts { get; }

		[Filter("Aircraft Model:", Order = 12)]
		List<AircraftModel> LicenseAircrafts { get; }
		#endregion

		#region List<LicenseFunction> LicenseFunctions { get; }

		[Filter("Function:", Order = 13)]
		List<LicenseFunction> LicenseFunctions { get; }
		#endregion

		#region List<LicenseRights> LicenseRights { get; }

		[Filter("Rights:", Order = 14)]
		List<LicenseRights> LicenseRights { get; }

		#endregion
		
		[Filter("Condition:", Order = 15)]
		ConditionState Condition { get; set; }
	}
}