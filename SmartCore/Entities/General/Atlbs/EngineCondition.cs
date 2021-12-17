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
	/// ����� ��������� ��������� ���������
	/// </summary>
//    [Serializable]
	[Table("EngineConditions", "dbo", "ItemId")]
	[Dto(typeof(EngineConditionDTO))]
	[Serializable]
	public class EngineCondition : AbstractRecord 
	{
		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public Int32 FlightId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public Int32 EngineId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("EngineId")]
		public Int32 EngineId { get; set; }
		#endregion

		#region public string PressALT
		/// <summary>
		/// ����� ������
		/// </summary>
		[TableColumnAttribute("PressALT")]
		public int PressALT { get; set; }

		#endregion

		#region public TimeSpan TimeGMT
		/// <summary>
		/// ����� ���������� ���������
		/// </summary>
		[TableColumnAttribute("TimeGMT")]
		public TimeSpan TimeGMT { get; set; }

		#endregion

		#region public double GrossWeight

		/// <summary>
		/// �����
		/// </summary>
		[TableColumnAttribute("GrossWeight")]
		public double GrossWeight { get; set; }

		#endregion

		#region public double IAS
		/// <summary>
		/// ������������ �������� ������
		/// </summary>
		[TableColumnAttribute("IAS")]
		public double IAS { get; set; }

		#endregion

		#region public double Mach
		/// <summary>
		/// �������� �������� ������
		/// </summary>
		[TableColumnAttribute("Mach")]
		public double Mach { get; set; }

		#endregion

		#region public double TAT
		/// <summary>
		/// Total Air Temperature
		/// </summary>
		[TableColumnAttribute("TAT")]
		public double TAT { get; set; }

		#endregion

		#region public double OAT
		/// <summary>
		/// Outside Air Temperature
		/// </summary>
		[TableColumnAttribute("OAT")]
		public double OAT { get; set; }

		#endregion

		#region public FlightRegime FlightRegime
		/// <summary>
		/// ����� ������ �� ������� ��� ���������� �����
		/// </summary>
		[TableColumnAttribute("FlightRegime")]
		public FlightRegime FlightRegime{ get; set; }
		#endregion

		#region public GroundAir GroundAir { get; set; }
		/// <summary>
		/// ����� ������������ �������
		/// </summary>
		[TableColumnAttribute("GroundAir")]
		public GroundAir GroundAir { get; set; }
		#endregion

		#region public int16 TimeInRegime
		/// <summary>
		/// ����� ����������� � ��������� ������ ������
		/// </summary>
		[TableColumnAttribute("TimeInRegime")]
		public Int16 TimeInRegime { get; set; }
		#endregion

		#region public WeatherCondition Weather
		/// <summary>
		/// �������� ������� ��� ������� ��� ���������� �����
		/// </summary>
		[TableColumnAttribute("Weather")]
		public WeatherCondition Weather { get; set; }

		#endregion

		#region public int ThrottleLeverAngle { get; set; }
		/// <summary>
		/// ��������� ��������� ������ �������
		/// </summary>
		[TableColumnAttribute("ThrottleLeverAngle")]
		public int ThrottleLeverAngle { get; set; }
		#endregion

		#region public Double ERP { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ERP")]
		public Double ERP { get; set; }
		#endregion

		#region public Double N1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("N1")]
		public Double N1 { get; set; }
		#endregion

		#region public Double EGT { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("EGT")]
		public Double EGT { get; set; }
		#endregion

		#region public Double N2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("N2")]
		public Double N2 { get; set; }
		#endregion

		#region public Double OilTemperature { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("OilTemperature")]
		public Double OilTemperature { get; set; }
		#endregion

		#region public Double OilPressure { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("OilPressure")]
		public Double OilPressure { get; set; }
		#endregion

		#region public Double FuelPress { get; set; }
		/// <summary>
		/// �������� ������� ����� ����������
		/// </summary>
		[TableColumnAttribute("FuelPress")]
		public Double FuelPress { get; set; }
		#endregion

		#region public Double OilPressTorque { get; set; }
		/// <summary>
		/// �������� ����� � ���
		/// </summary>
		[TableColumnAttribute("OilPressTorque")]
		public Double OilPressTorque { get; set; }
		#endregion

		#region public Double OilFlow { get; set; }
		/// <summary>
		/// ������ �����
		/// </summary>
		[TableColumnAttribute("OilFlow")]
		public Double OilFlow { get; set; }
		#endregion

		#region public Double FuelFlow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FuelFlow")]
		public Double FuelFlow { get; set; }
		#endregion

		#region public Double FuelBurn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FuelBurn")]
		public Double FuelBurn { get; set; }
		#endregion

		#region public Double VibroOverload { get; set; }
		/// <summary>
		/// �����-����������
		/// </summary>
		[TableColumnAttribute("VibroOverload")]
		public Double VibroOverload { get; set; }
		#endregion

		#region public Double VibroOverload2 { get; set; }
		/// <summary>
		/// �����-����������2
		/// </summary>
		[TableColumnAttribute("VibroOverload2")]
		public Double VibroOverload2 { get; set; }
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

		#region public Engine Engine

		private BaseComponent _engine;
		/// <summary>
		/// ���������
		/// </summary>
		public BaseComponent Engine
		{
			get
			{
				if (ItemId < 0)
				{
					if (EngineId == 0)
						return null;
					return _engine;
					//if (m_parentAircraftFlight != null)
					//    return m_parentAircraftFlight.parentAircraft.(EngineID);
				}
				return _engine;
			}
			set
			{
				_engine = value;
				if(value != null)
					EngineId = value.ItemId;
			}
		}

		#endregion
		
		/*
		*  ������ 
		*/
		
		#region public EngineCondition()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public EngineCondition()
		{
			PressALT = 0;
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.EngineCondition;
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

		#region public void AddInformation(EnginesGeneralCondition general)

		public void AddInformation(EnginesGeneralCondition general)
		{
			PressALT = int.Parse(general.PressALT);
			TimeGMT = general.TimeGMT;
			GrossWeight = general.GrossWeight;
			IAS = general.IAS;
			Mach = general.Mach;
			TAT = general.TAT;
			OAT = general.OAT;
			FlightRegime = general.FlightRegime;
			GroundAir = general.GroundAir;
			Weather = general.Weather;
		}
		#endregion

		#region public void SetProperties(EngineCondition condition)
		/// <summary>
		/// �������� �������� ������� �� ����������� ������� � �������
		/// </summary>
		/// <param name="condition"></param>
		public void SetProperties(EngineCondition condition)
		{
			PressALT = condition.PressALT;
			TimeGMT = condition.TimeGMT;
			GrossWeight = condition.GrossWeight;
			IAS = condition.IAS;
			Mach = condition.Mach;
			TAT = condition.TAT;
			OAT = condition.OAT;
			FlightRegime = condition.FlightRegime;
			TimeInRegime = condition.TimeInRegime;
			ThrottleLeverAngle = condition.ThrottleLeverAngle;
			EGT = condition.EGT;
			ERP = condition.ERP;
			FuelBurn = condition.FuelBurn;
			FuelFlow = condition.FuelFlow;
			N1 = condition.N1;
			N2 = condition.N2;
			OilPressure = condition.OilPressure;
			OilPressTorque = condition.OilPressTorque;
			OilFlow = condition.OilFlow;
			FuelPress = condition.FuelPress;
			VibroOverload = condition.VibroOverload;
			VibroOverload2 = condition.VibroOverload2;
			OilTemperature = condition.OilTemperature;
			Weather = condition.Weather;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(EngineCondition));
		}
		#endregion
	}

}
