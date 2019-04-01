using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("EmployeeMedicalRecors", "dbo", "ItemId")]
	[Dto(typeof(SpecialistMedicalRecordDTO))]
	[Condition("IsDeleted", "0")]
	public class SpecialistMedicalRecord : BaseEntityObject
	{
		private static Type _thisType;

		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate { get; set; }
		#endregion

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		public static PropertyInfo SpecialistIdProperty
		{
			get { return GetCurrentType().GetProperty("SpecialistId"); }
		}

		#endregion

		#region public int ClassNumber { get; set; }

		[TableColumn("ClassId")]
		public int ClassNumber { get; set; }
		#endregion

		#region public Lifelength NotifyLifelength { get; set; }

		[TableColumn("Notify")]
		public Lifelength NotifyLifelength { get; set; }

		#endregion

		#region public Lifelength RepeatLifelength { get; set; }

		[TableColumn("Repeat")]
		public Lifelength RepeatLifelength { get; set; }

		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

			#endregion

		#region public string Remarks { get; set; }

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		#endregion


		public SpecialistMedicalRecord()
        {
            ItemId = -1;
			IssueDate = DateTime.Today;
			SmartCoreObjectType = SmartCoreType.SpecialistMedicalRecord;
		}

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(SpecialistMedicalRecord));
		}
		#endregion
	}
}