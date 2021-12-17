using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General
{

	/// <summary>
	/// �����, ��������� ������ � ������ ������������� �����������
	/// </summary>
	[Table("FlightCrews", "dbo", "ItemId")]
	[Dto(typeof(FlightCrewRecordDTO))]
	[Serializable]
	public class FlightCrewRecord : BaseEntityObject
	{
		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public Int32 FlightId { get; set; }
		/// <summary>
		/// ������������� ������
		/// </summary>
		[TableColumnAttribute("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}

		#endregion

		#region public Int32 Specialist { get; set; }
		/// <summary>
		/// ������������� �����������
		/// </summary>
		[TableColumnAttribute("SpecialistId")]
		[Child(false)]
		public Specialist Specialist { get; set; }

		public static PropertyInfo SpecialistIdProperty
		{
			get { return GetCurrentType().GetProperty("Specialist"); }
		}

		#endregion

		#region public Int32 Specialization { get; set; }
		/// <summary>
		/// ������������� ������������� ����������� 
		/// </summary>
		[TableColumnAttribute("SpecializationId")]
		public Specialization Specialization { get; set; }
		#endregion

		#region public Int32 IDNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("IdNo")]
		public Int32 IdNo { get; set; }
		#endregion

		#region public String Limitations { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Limitations")]
		public String Limitations { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Remarks")]
		public String Remarks { get; set; }
		#endregion

		/*
		*  ������ 
		*/

		#region public FlightCrewRecord()
		/// <summary>
		/// ������� "������" ������ � ������ �����������
		/// </summary>
		public FlightCrewRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.FlightCrewRecord;

		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "";
		}
		#endregion   

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(FlightCrewRecord));
		}
		#endregion
	}
}
