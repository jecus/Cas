using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Store
{

	/// <summary>
	/// Класс описывает неснижаемый запас некоторого комплектующего
	/// </summary>
	[Table("StockComponentInfos", "dbo", "ItemId")]
	[Dto(typeof(StockComponentInfoDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class StockComponentInfo : BaseEntityObject
	{
		private static Type _thisType;
		/*
		*  Свойства
		*/
		#region public Int32 StoreID { get; set; }
		/// <summary>
		/// Идентификатор склада
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
		/// Чертёжный номер агрегата
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
		/// класс комплектующего (Компонент, КИТ, расходник и т.д.)
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
		/// Чертежный номер агрегата
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
		/// Описание комплектующего
		/// </summary>
		[TableColumn("Description")]
		[ListViewData(0.2f, "Description")]
		[NotNull]
		public String Description { get; set; }
		#endregion

		#region public override Product Product { get; set; }

		private Product _accessoryDescription;
		/// <summary>
		/// Описание агрегата
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
		/// Текущее кол-во комплектующего на складе
		/// </summary>
		[ListViewData(0.05f, "Current")]
		public double Current { get; set; }
		#endregion

		#region public double Amount { get; set; }
		/// <summary>
		/// Минимальное кол-во комплектующего на скаде
		/// </summary>
		[TableColumn("Amount")]
		[ListViewData(0.05f, "Amount")]
		[NotNull]
		public double ShouldBeOnStock { get; set; }
		#endregion

		#region public Measure Measure { get; set; }
		/// <summary>
		/// Единица измерения
		/// </summary>
		[TableColumn("Measure")]
		[ListViewData(0.05f, "Measure")]
		[NotNull]
		public Measure Measure { get; set; }
		#endregion


		/*
		*  Методы 
		*/

		#region public StockComponentInfo()
		/// <summary>
		/// Создает объект без дополнительной информации
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
		/// Создает объект без дополнительной информации
		/// </summary>
		public StockComponentInfo(Store strore) : this()
		{
			StoreId = strore.ItemId;
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
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
