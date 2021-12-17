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
	/// ����� ��������� ������������ ���������
	/// </summary>
	[Table("EngineAccelerationTime", "dbo", "ItemId")]
	[Dto(typeof(EngineAccelerationTimeDTO))]
	[Serializable]
	public class EngineAccelerationTime : AbstractRecord 
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

		#region public int AccelerationTime { get; set; }
		/// <summary>
		/// �����, ����������� � ������
		/// </summary>
		[TableColumnAttribute("AccelerationTime")]
		public int AccelerationTime { get; set; }
		#endregion

		#region public int AccelerationTimeAir { get; set; }
		/// <summary>
		/// �����, ����������� � ������ � �������
		/// </summary>
		[TableColumnAttribute("AccelerationTimeAir")]
		public int AccelerationTimeAir { get; set; }
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

		#region public EngineAccelerationTime()
		/// <summary>
		/// ������� ������ � ������� ������� ���������
		/// </summary>
		public EngineAccelerationTime()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.EngineAccelerationTime;
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
			return res;
		}
		#endregion   

		#region public void SetProperties(EngineAccelerationTime condition)
		/// <summary>
		/// �������� �������� ������� �� ����������� ������� � �������
		/// </summary>
		/// <param name="condition"></param>
		public void SetProperties(EngineAccelerationTime condition)
		{
			AccelerationTime = condition.AccelerationTime;
			AccelerationTimeAir = condition.AccelerationTimeAir;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(EngineAccelerationTime));
		}
		#endregion
	}

}
