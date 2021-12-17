using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{

	/// <summary>
	/// ����� ��������� ��������� �����
	/// </summary>
	[Table("LandingGearCondition", "dbo", "ItemId")]
	[Dto(typeof(LandingGearConditionDTO))]
	[Serializable]
	public class LandingGearCondition : AbstractRecord
	{
		private BaseComponent _landingGear;
		private readonly AircraftFlight _parentAircraftFlight;
		private static Type _thisType;

		/*
		*  ��������
		*/

		#region public Int32 FlightID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public Int32 LandingGearID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("LandingGearId")]
		public Int32 LandingGearId { get; set; }
		#endregion

		#region public Double TirePressure1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("TirePressure1")]
		public Double TirePressure1 { get; set; }
		#endregion

		#region public Double TirePressure2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("TirePressure2")]
		public Double TirePressure2 { get; set; }
		#endregion

		#region public GearAssembly LandingGear
		/// <summary>
		/// ������� ������� ��� �������� ������� ���������
		/// </summary>
		public BaseComponent LandingGear
		{
			get
			{
				return _landingGear;
			}
			set
			{
				_landingGear = value;
				if (value != null)
					LandingGearId = value.ItemId;
			}
		}

		#endregion
		
		/*
		*  ������ 
		*/
		
		#region public LandingGearCondition()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public LandingGearCondition()
		{
			_parentAircraftFlight = null;
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.LandingGearCondition;
		}
		#endregion
	 
		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"TP1: {TirePressure1}, TP2: {TirePressure2}";
		}
		#endregion   

		#region public override DateTime RecordDate { get; set; }
		/// <summary>
		/// ���� ���������� ������
		/// </summary>
		[TableColumnAttribute("RecordDate")]
		public override DateTime RecordDate { get; set; }
		#endregion

		#region public override Lifelength OnLifelength { get; set; }
		/// <summary>
		/// ������������ �� AbstractRecord � �� �� �����������
		/// </summary>
		public override Lifelength OnLifelength { get; set; }
		#endregion

		#region override public string Remarks { get; set; }
		/// <summary>
		/// ������������ �� AbstractRecord � �� �� �����������
		/// </summary>
		public override string Remarks { get; set; }
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(LandingGearCondition));
		}
		#endregion
	}

}
