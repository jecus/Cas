using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{

	/// <summary>
	/// ������� ����� ��������
	/// </summary>
	[Table("OilConditions", "dbo", "ItemId")]
	[Dto(typeof(ComponentOilConditionDTO))]
	[Serializable]
	public class ComponentOilCondition : BaseEntityObject
	{
		private static Type _thisType;
		/*
		 * ��������
		 */

		#region public string ComponentId
		private Int32 _componentId;
		/// <summary>
		/// �������
		/// </summary>
		[TableColumnAttribute("ComponentId")]
		public int ComponentId
		{
			get { return _componentId; }
			set
			{
				_componentId = value;
		   //     OnDataChange();
			}
		}
		#endregion

		#region public string FlightId

		/// <summary>
		/// �����, � ������ �������� ������� ������
		/// </summary>
		[TableColumnAttribute("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public double Remain
		/// <summary>
		/// ���������� ����� ����� ����. ������ (Qts.)
		/// </summary>
		private double _remain;
		/// <summary>
		/// ���������� ����� ����� ����. ������ (Qts.)
		/// </summary>
		[TableColumnAttribute("Remain")]
		public double Remain
		{
			get { return _remain; }
			set
			{
				_remain = value;
			}
		}
		#endregion

		#region public double OilAdded
		/// <summary>
		/// ���������� ������������ ����� (Qts.)
		/// </summary>
		private double _oilAdded;
		/// <summary>
		/// ���������� ������������ ����� (Qts.)
		/// </summary>
		[TableColumnAttribute("OilAdded")]
		public double OilAdded
		{
			get { return _oilAdded; }
			set
			{
				_oilAdded = value;
			}
		}
		#endregion

		#region public double OnBoard
		/// <summary>
		/// ���������� ����� ����� ������� (Qts.)
		/// </summary>
		private double _onBoard;
		/// <summary>
		/// ���������� ����� ����� ������� (Qts.)
		/// </summary>
		[TableColumnAttribute("OnBoard")]
		public double OnBoard
		{
			get { return _onBoard; }
			set
			{
				_onBoard = value;
			}
		}
		#endregion

		#region public double Spent
		/// <summary>
		/// ���������� ����� ��������������� � ������ (Qts.)
		/// </summary>
		private double _spent;
		/// <summary>
		/// ���������� ����� ��������������� � ������ (Qts.)
		/// </summary>
		[TableColumnAttribute("Spent")]
		public double Spent
		{
			get { return _spent; }
			set
			{
				_spent = value;
			}
		}
		#endregion

		#region public double RemainAfter
		/// <summary>
		/// ���������� ����� ����� ������ (Qts.)
		/// </summary>
		private double _remainAfter;
		/// <summary>
		/// ���������� ����� ����� ������ (Qts.)
		/// </summary>
		[TableColumnAttribute("RemainAfter")]
		public double RemainAfter
		{
			get { return _remainAfter; }
			set
			{
				_remainAfter = value;
			}
		}
		#endregion

		/*
		 * �����������
		 */
		#region public BaseComponent BaseComponent { get; set; }

		public BaseComponent BaseComponent { get; set; }
		#endregion

		#region public ComponentOilCondition()
		/// <summary>
		/// ������� ����� ��������
		/// </summary>
		public ComponentOilCondition()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.ComponentOilCondition;
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// �������������� ������� � ������. �������� ������� ��������� ���������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _oilAdded + " " + _onBoard + " " + _remain + " " + _spent + " " + _remainAfter;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(ComponentOilCondition));
		}
		#endregion

	}
}
