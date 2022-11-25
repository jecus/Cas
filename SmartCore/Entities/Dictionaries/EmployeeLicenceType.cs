using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class EmployeeLicenceType : StaticDictionary
	{
		private PersonnelCategory _category;
		public PersonnelCategory Category
		{
			get { return _category; }
			set { _category = value; }
		}

		#region private static CommonDictionaryCollection<EmployeeLicenceType> _Items = new CommonDictionaryCollection<EmployeeLicenceType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<EmployeeLicenceType> _Items = new CommonDictionaryCollection<EmployeeLicenceType>();
		#endregion

		#region public static EmployeeLicenceType UNK = new EmployeeLicenceType(-1, "N/A", "N/A", 0);
		/// <summary>
		/// неизвестный
		/// </summary>
		public static EmployeeLicenceType UNK = new EmployeeLicenceType(-1, "", "N/A", PersonnelCategory.UNK);

		#endregion

		public static EmployeeLicenceType FlightNavigator  = new EmployeeLicenceType(1, "FN", "Flight navigator", PersonnelCategory.FlightCrewMembersOtherThanPilots);
		public static EmployeeLicenceType FlightEngineer = new EmployeeLicenceType(2, "FE", "Flight engineer", PersonnelCategory.FlightCrewMembersOtherThanPilots);
		public static EmployeeLicenceType FlightMechanic = new EmployeeLicenceType(3, "FM", "Flight mechanic", PersonnelCategory.FlightCrewMembersOtherThanPilots);
		public static EmployeeLicenceType FlightRadiotelephoneOperator  = new EmployeeLicenceType(4, "FR", "Flight radiotelephone operator", PersonnelCategory.FlightCrewMembersOtherThanPilots);
		public static EmployeeLicenceType FlightOperator = new EmployeeLicenceType(5, "FO", "Flight operator", PersonnelCategory.FlightCrewMembersOtherThanPilots);


		public static EmployeeLicenceType AircraftMaintenanceTechnician = new EmployeeLicenceType(6, "AMT", "Aircraft maintenance technician", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AircraftMaintenanceEngineer = new EmployeeLicenceType(7, "AME", "Aircraft maintenance engineer", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AircraftMaintenanceMechanic = new EmployeeLicenceType(8, "AMM", "Aircraft maintenance mechanic", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType Student = new EmployeeLicenceType(9, "", "Student air traffic controller", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AirTrafficController = new EmployeeLicenceType(10, "AC", "Air traffic controller", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AirTrafficControllerRatings = new EmployeeLicenceType(11, "", "Air traffic controller ratings", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType FlightOperations = new EmployeeLicenceType(12, "FP", "Flight operations officer/flight dispatcher", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AeronauticalStation = new EmployeeLicenceType(13, "", "Aeronautical station operator", PersonnelCategory.OtherThanFlightCrewMembers);
		public static EmployeeLicenceType AeronauticalMeteorological = new EmployeeLicenceType(14, "", "Aeronautical meteorological personnel", PersonnelCategory.OtherThanFlightCrewMembers);


		public static EmployeeLicenceType FlightAttendant = new EmployeeLicenceType(15, "FL", "Flight attendant", PersonnelCategory.CabinCrew);



		public static EmployeeLicenceType StudentPilot = new EmployeeLicenceType(16, "Student pilot", "Student pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType LightAircraftPilot = new EmployeeLicenceType(17, "LAPL", "Light aircraft pilot ", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType LightAircraftPilotAeroplanes = new EmployeeLicenceType(18, "LAPL(A)", "Light aircraft pilot for aeroplanes", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType LightAircraftPilotHelicopters = new EmployeeLicenceType(19, "LAPL(H)", "Light aircraft pilot for helicopters", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType LightAircraftPilotBalloons = new EmployeeLicenceType(20, "LAPL(B)", "Light aircraft pilot for balloons", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType PrivatePilotLicence = new EmployeeLicenceType(21, "PPL", "Private pilot licence", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType PrivatePilotAeroplanes = new EmployeeLicenceType(22, "PPL(A)", "Private pilot aeroplanes", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType PrivatePilotHelicopters = new EmployeeLicenceType(23, "PPL(H)", "Private pilot helicopters", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType PrivatePilotAirships = new EmployeeLicenceType(24, "PPL(As)", "Private pilot airships", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType SailplanePilot = new EmployeeLicenceType(25, "SPL", "Sailplane pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType BalloonPilot = new EmployeeLicenceType(26, "BPL", "Balloon pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType CommercialPilot = new EmployeeLicenceType(27, "CPL", "Commercial pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType CommercialPilotAeroplaneCategory = new EmployeeLicenceType(28, "CPL(A)", "Commercial pilot aeroplane category", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType MultiCrewPilot = new EmployeeLicenceType(29, "MPL", "Multi-crew pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType AirlineTransportPilot = new EmployeeLicenceType(30, "ATPL", "Airline transport pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType AirlineTransportPilotAeroplane = new EmployeeLicenceType(31, "ATPL(A)", "Airline transport pilot for the aeroplane category", PersonnelCategory.FlightCrewMembersPilots);
		public static EmployeeLicenceType AirlineTransportPilotHelicopter = new EmployeeLicenceType(32, "ATPL(H)", "Airline transport pilot for the helicopter category", PersonnelCategory.FlightCrewMembersPilots);

		/*
		* Методы
		*/

		#region public static EmployeeLicenceType GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static EmployeeLicenceType GetItemById(Int32 maintenanceTypeId)
		{
			foreach (EmployeeLicenceType t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<PersonnelCategory> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<EmployeeLicenceType> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.IsNullOrEmpty(ShortName) ? FullName : $"{FullName} - {ShortName}";
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public PersonnelCategory()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public EmployeeLicenceType()
		{
		}
		#endregion

		#region public EmployeeLicenceType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public EmployeeLicenceType(Int32 itemId, String shortName, String fullName, PersonnelCategory category)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_category = category;

			_Items.Add(this);
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is EmployeeLicenceType)
				return FullName.CompareTo(((EmployeeLicenceType)y).FullName);
			return 0;
		}
		#endregion
	}
}