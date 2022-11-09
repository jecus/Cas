using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class LicenseRights :  StaticDictionary
	{
		#region private static CommonDictionaryCollection<LicenseRights> _Items = new CommonDictionaryCollection<LicenseRights>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<LicenseRights> _Items = new CommonDictionaryCollection<LicenseRights>();
		#endregion

		public static LicenseRights A1AeroplanesTurbine = new LicenseRights(1, "A1", "A1 Aeroplanes Turbine", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights A2AeroplanesPiston = new LicenseRights(2, "A2", "A2 Aeroplanes Piston", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights A3HelicoptersTurbine = new LicenseRights(3, "A3", "A3 Helicopters Turbine", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights A4HelicoptersPiston = new LicenseRights(4, "A4", "A3 Helicopters Piston", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B1AeroplanesTurbine = new LicenseRights(5, "B1.1", "B1.1 Aeroplanes Turbine", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B2AeroplanesPiston = new LicenseRights(6, "B1.2", "B1.2 Aeroplanes Piston", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B3HelicoptersTurbine = new LicenseRights(7, "B1.3", "B1.3 Helicopters Turbine", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B4HelicoptersPiston = new LicenseRights(8, "B1.4", "B1.4 Helicopters Piston", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B3 = new LicenseRights(9, "B3", "B3", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights C = new LicenseRights(10, "C", "C", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B12C = new LicenseRights(11, "B1.2/C", "B1.2/C", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B1C = new LicenseRights(12, "B1/C", "B1/C", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B2 = new LicenseRights(13, "B2", "B2", PersonnelCategory.OtherThanFlightCrewMembers);
		public static LicenseRights B1B2 = new LicenseRights(14, "B1/B2", "B1/B2", PersonnelCategory.OtherThanFlightCrewMembers);


		public static LicenseRights Instructors = new LicenseRights(15, "Instructors", "Instructors", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights InstructorsMPL = new LicenseRights(16, "MPL", "Instructors for the MPL", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights FlightInstructorsFi = new LicenseRights(17, "FI", "Flight instructor — FI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights TypeRatingInstructorTRI = new LicenseRights(18, "TRI", "Type rating instructor — TRI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights ClassRatingInstructorCRI = new LicenseRights(19, "CRI", "Class rating instructor — CRI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights SyntheticFlightInstructorSFI = new LicenseRights(20, "SFI", "Synthetic flight instructor — SFI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights MultiCrewCooperationInstructorMCCI = new LicenseRights(21, "MCCI", "Multi-crew cooperation instructor — MCCI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights SyntheticTrainingInstructorSTI = new LicenseRights(22, "STI", "Synthetic training instructor — STI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights MountainRratingInstructorMI = new LicenseRights(23, "MI", "Mountain rating instructor — MI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights FlightTestInstructorFTI = new LicenseRights(24, "FTI", "Flight test instructor — FTI", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights Examiners = new LicenseRights(25, "EXAMINERS", "EXAMINERS", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights FlightExaminersFE = new LicenseRights(26, "FE ", "Flight examiners — FE ", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights TypeRatingExaminersTRE = new LicenseRights(27, "TRE", "Type rating examiners — TRE", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights ClassRatingExaminerCRE = new LicenseRights(28, "CRE", "Class Rating Examiner — CRE", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights InstrumentRatingExaminerIRE = new LicenseRights(29, "IRE", "Instrument Rating Examiner — IRE", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights SyntheticFlightExaminerSFE = new LicenseRights(30, "SFE", "Synthetic Flight Examiner — SFE", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseRights FlightInstructorExaminerFIE = new LicenseRights(31, "FIE", "Flight instructor examiner — FIE", PersonnelCategory.FlightCrewMembersPilots);

		#region public static LicenseRights UNK = new LicenseRights(-1, "N/A", "N/A");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static LicenseRights UNK = new LicenseRights(-1, "N/A", "N/A");
		#endregion

		/*
		* Методы
		*/

		#region public static LicenseRights GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static LicenseRights GetItemById(Int32 maintenanceTypeId)
		{
			foreach (LicenseRights t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<LicenseRights> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<LicenseRights> Items
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
			return FullName;
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public LicenseRights()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public LicenseRights()
		{
		}
		#endregion

		#region public LicenseRights(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="personnelCategory"></param>
		/// <param name="weight"></param>
		public LicenseRights(int itemId, string shortName, string fullName, PersonnelCategory personnelCategory)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			Category = personnelCategory;
			_Items.Add(this);
		}

		#endregion

		public LicenseRights(int itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}

		public PersonnelCategory Category { get; set; }

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is LicenseRights)
				return FullName.CompareTo(((LicenseRights)y).FullName);
			return 0;
		}
		#endregion
	}
}