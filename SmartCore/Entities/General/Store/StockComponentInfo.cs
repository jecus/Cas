using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Store
{

	/// <summary>
	/// ����� ��������� ����������� ����� ���������� ��������������
	/// </summary>
	[Table("StockComponentInfos", "dbo", "ItemId")]
	[Dto(typeof(StockComponentInfoDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class StockComponentInfo : BaseEntityObject
	{
		private static Type _thisType;
		/*
		*  ��������
		*/
		#region public Int32 StoreID { get; set; }
		/// <summary>
		/// ������������� ������
		/// </summary>
		[TableColumn("StoreId")]
		public Int32 StoreId { get; set; }

		public static PropertyInfo StoreIdProperty
		{
			get { return GetCurrentType().GetProperty("StoreId"); }
		}

		#endregion

		#region public override GoodStandart Standart { get; set; }

		private GoodStandart _standart;
		/// <summary>
		/// �������� ����� ��������
		/// </summary>
		[ListViewData(0.1f, "Standart", 1)]
		[Filter("Standart:", Order = 1)]
		[TableColumn("GoodStandartId")]
		[Child(false)]
		public GoodStandart Standart
		{
			get { return _accessoryDescription != null ? _accessoryDescription.Standart : _standart; }
			set
			{
				//if (_accessoryDescription != null)
				//{
				//    if (_accessoryDescription.Standart != value)
				//    {
				//        _accessoryDescription.Standart = value;
				//        OnPropertyChanged("Standart");    
				//    }
				//}
				//else 
				if (_accessoryDescription == null && _standart != value)
				{
					_standart = value;
					OnPropertyChanged("Standart");
				}
			}
		}
		#endregion

		#region public GoodsClass GoodsClass { get; set; }
		/// <summary>
		/// ����� �������������� (���������, ���, ��������� � �.�.)
		/// </summary>
		[TableColumn("ComponentClass")]
		[ListViewData(0.1f, "Class")]
		[FormControl(250, "Class:",
			TreeDictRootNodes = new[]
			{
				"ComponentsAndParts", "ProductionAuxiliaryEquipment", "OfficeEquipment",
				"MaintenanceMaterials", "Tools"
			}, Order = 10)]
		[NotNull]
		public GoodsClass GoodsClass { get; set; }

		public static PropertyInfo GoodsClassProperty
		{
			get { return GetCurrentType().GetProperty("GoodsClass"); }
		}

		#endregion

		#region public String PartNumber { get; set; }
		/// <summary>
		/// ��������� ����� ��������
		/// </summary>
		[TableColumn("PartNumber")]
		[ListViewData(0.15f, "Part Number")]
		[NotNull]
		public String PartNumber { get; set; }

		public static PropertyInfo PartNumberProperty
		{
			get { return GetCurrentType().GetProperty("PartNumber"); }
		}

		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// �������� ��������������
		/// </summary>
		[TableColumn("Description")]
		[ListViewData(0.2f, "Description")]
		[NotNull]
		public String Description { get; set; }
		#endregion

		#region public override Product Product { get; set; }

		private Product _accessoryDescription;
		/// <summary>
		/// �������� ��������
		/// </summary>
		[TableColumn("ComponentModel")]
		[Child(true)]
		public Product AccessoryDescription
		{
			get { return _accessoryDescription; }
			set
			{
				if (_accessoryDescription != value)
				{
					_accessoryDescription = value;
					OnPropertyChanged("Product");
				}
			}
		}


		[ListViewData(0.15f, "Product")]
		public string ProductName => _accessoryDescription?.Name;
		#endregion

		#region public double Current { get; set; }
		/// <summary>
		/// ������� ���-�� �������������� �� ������
		/// </summary>
		[ListViewData(0.05f, "Current")]
		public double Current { get; set; }
		#endregion

		#region public double Amount { get; set; }
		/// <summary>
		/// ����������� ���-�� �������������� �� �����
		/// </summary>
		[TableColumn("Amount")]
		[ListViewData(0.05f, "Amount")]
		[NotNull]
		public double ShouldBeOnStock { get; set; }
		#endregion

		#region public Measure Measure { get; set; }
		/// <summary>
		/// ������� ���������
		/// </summary>
		[TableColumn("Measure")]
		[ListViewData(0.05f, "Measure")]
		[NotNull]
		public Measure Measure { get; set; }
		#endregion


		/*
		*  ������ 
		*/

		#region public StockComponentInfo()
		/// <summary>
		/// ������� ������ ��� �������������� ����������
		/// </summary>
		public StockComponentInfo()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.StockComponentInfo;
			GoodsClass = GoodsClass.MaintenanceMaterials;
		}
		#endregion

		#region public StockComponentInfo(Store strore) : this()
		/// <summary>
		/// ������� ������ ��� �������������� ����������
		/// </summary>
		public StockComponentInfo(Store strore) : this()
		{
			StoreId = strore.ItemId;
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "P/N:" + PartNumber + " Desc:" + Description;
		}
		#endregion   

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(StockComponentInfo));
		}
		#endregion

	}

}
