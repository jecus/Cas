using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{

	/// <summary>
	/// �����, ��������� ���������� ����� �� ������������ ����
	/// </summary>
	[Table("FlightNumberPeriod s", "dbo", "ItemId")]
	[Dto(typeof(FlightNumberPeriodDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightNumberPeriodDaySchedule : BaseEntityObject
	{
		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public Int32 FlightNumberId { get; set; }
		/// <summary>
		/// ������������� �����
		/// </summary>
		[TableColumnAttribute("FlightNumberId")]
		[ParentAttribute]
		public FlightNumber FlightNumber { get; set; }

		public static PropertyInfo FlightNumberIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightNumber"); }
		}

		#endregion

		#region public Int32 FlightNumberPeriodId { get; set; }
		/// <summary>
		/// ��������� ������, �������� ����������� ���� ���������� �����
		/// </summary>
		[TableColumnAttribute("FlightNumberPeriodId")]
		[ParentAttribute]
		public FlightNumberPeriod FlightNumberPeriod { get; set; }

		public static PropertyInfo FlightNumberPeriodProperty
		{
			get { return GetCurrentType().GetProperty("FlightNumberPeriod"); }
		}

		#endregion

		#region public DateTime PeriodFrom { get; set; }
		/// <summary>
		/// ���� ������ ������� ����� 
		/// </summary>
		[TableColumnAttribute("PeriodFrom")]
		[FormControl("PeriodFrom")]
		[ListViewData(200f, "PeriodFrom")]
		[NotNull]
		public DateTime PeriodFrom { get; set; }
		#endregion

		#region public DateTime PeriodTo { get; set; }
		/// <summary>
		/// ���� ��������� ������� ����� 
		/// </summary>
		[TableColumnAttribute("PeriodTo")]
		[FormControl("PeriodTo")]
		[ListViewData(200f, "PeriodTo")]
		[NotNull]
		public DateTime PeriodTo { get; set; }
		#endregion

		/*
		*  ������ 
		*/

		#region public FlightNumberPeriodDaySchedule()
		/// <summary>
		/// ������� "������" ������ � ������� �������� ������������ �����
		/// </summary>
		public FlightNumberPeriodDaySchedule()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.FlightNumberPeriodDaySchedule;
			PeriodFrom = DateTime.Today;
			PeriodTo = DateTime.Today.AddDays(1);
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
			return _thisType ?? (_thisType = typeof(FlightNumberPeriod));
		}
		#endregion
	}
}
