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
	/// ����� ��������� ������ ��������� � ������������ ������
	/// </summary>
	[Table("EngineTimeInRegimeRecords", "dbo", "ItemId")]
	[Dto(typeof(EngineTimeInRegimeDTO))]
	[Serializable]
	public class EngineTimeInRegime : AbstractRecord 
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

		#region public Int32 BaseComponentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("EngineId")]
		public int BaseComponentId { get; set; }
		#endregion

		#region public FlightRegime FlightRegime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FlightRegimeId")]
		public FlightRegime FlightRegime { get; set; }
		#endregion

		#region public TimeSpan TimeInRegime { get; set; }
		/// <summary>
		/// �����, ����������� � ������
		/// </summary>
		[TableColumnAttribute("TimeInRegime")]
		public TimeSpan TimeInRegime { get; set; }
		#endregion

		#region public TimeSpan TimeInRegime { get; set; }
		/// <summary>
		/// ����� ������ � ������
		/// </summary>
		[TableColumnAttribute("GroundAir")]
		public GroundAir GroundAir { get; set; }
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

		#region public BaseComponent BaseComponent

		private BaseComponent _baseComponent;
		/// <summary>
		/// ������� ���������
		/// </summary>
		public BaseComponent BaseComponent
		{
			get
			{
				if (ItemId < 0)
				{
					if (BaseComponentId == 0)
						return null;
					return _baseComponent;
					//if (m_parentAircraftFlight != null)
					//    return m_parentAircraftFlight.parentAircraft.(EngineID);
				}
				return _baseComponent;
			}
			set
			{
				_baseComponent = value;
				if(value != null)
					BaseComponentId = value.ItemId;
			}
		}

		#endregion

		/*
		*  ������ 
		*/

		#region public EngineTimeInRegime()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public EngineTimeInRegime()
		{
			FlightRegime = FlightRegime.UNK;
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.EngineTimeInRegime;
		}

		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string res = "";
			if (BaseComponent != null) res += (BaseComponent + " ");
			if (FlightRegime != null) res += FlightRegime.ToString();
			return res;
		}
		#endregion   

		#region public void SetProperties(EngineTimeInRegime condition)
		/// <summary>
		/// �������� �������� ������� �� ����������� ������� � �������
		/// </summary>
		/// <param name="condition"></param>
		public void SetProperties(EngineTimeInRegime condition)
		{
			FlightRegime = condition.FlightRegime;
			TimeInRegime = condition.TimeInRegime;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(EngineTimeInRegime));
		}
		#endregion
	}

}
