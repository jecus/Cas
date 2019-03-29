using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Store
{
	[Serializable]
	[Table("ProductCost", "dbo", "ItemId")]
	[Dto(typeof(ProductCostDTO))]
	[Condition("IsDeleted", "0")]
	public class ProductCost : BaseEntityObject
	{
		private static Type _thisType;
		private double _qtyIn;
		private Сurrency _currency;

		#region public int ParentTypeId { get; set; }

		[TableColumn("ParentTypeId")]
		public int ParentTypeId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentTypeId"); }
		}

		#endregion

		#region public int ParentId { get; set; }

		[TableColumn("ParentId")]
		public int ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		#endregion

		#region public Accessory.Component ParentComponent { get; set; }

		public Accessory.Component ParentComponent { get; set; }
			#endregion

		#region public int SupplierId { get; set; }

		[TableColumn("SupplierId")]
		public int SupplierId { get; set; }

		public static PropertyInfo SupplierIdProperty
		{
			get { return GetCurrentType().GetProperty("SupplierId"); }
		}

		#endregion

		#region public int KitId { get; set; }

		[TableColumn("KitId")]
		public int KitId { get; set; }

		#endregion

		#region public double QtyIn { get; set; }

		[TableColumn("QtyIn")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Qty In", 4, true)]
		public double QtyIn
		{
			get { return ParentComponent?.QuantityIn ?? _qtyIn; }
			set { _qtyIn = value; }
		}

		public static PropertyInfo QtyInProperty
		{
			get { return GetCurrentType().GetProperty("QtyIn"); }
		}

		#endregion

		#region public double UnitPrice { get; set; }

		[TableColumn("UnitPrice")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Unit Price", 5)]
		public double UnitPrice { get; set; }

		public static PropertyInfo UnitPriceProperty
		{
			get { return GetCurrentType().GetProperty("UnitPrice"); }
		}
		#endregion

		#region public double TotalPrice { get; set; }

		[TableColumn("TotalPrice")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Total Price", 6, true)]
		public double TotalPrice { get; set; }

		public static PropertyInfo TotalPriceProperty
		{
			get { return GetCurrentType().GetProperty("TotalPrice"); }
		}
		#endregion

		#region public double ShipPrice { get; set; }

		[TableColumn("ShipPrice")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Ship Price", 7)]
		public double ShipPrice { get; set; }

		public static PropertyInfo ShipPriceProperty
		{
			get { return GetCurrentType().GetProperty("ShipPrice"); }
		}
		#endregion

		#region public double SubTotal { get; set; }

		[TableColumn("SubTotal")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "SubTotal", 8, true)]
		public double SubTotal { get; set; }

		public static PropertyInfo SubTotalProperty
		{
			get { return GetCurrentType().GetProperty("SubTotal"); }
		}
		#endregion

		#region public double Tax { get; set; }

		[TableColumn("Tax")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Tax", 9)]
		public double Tax { get; set; }

		public static PropertyInfo TaxProperty
		{
			get { return GetCurrentType().GetProperty("Tax"); }
		}
		#endregion

		#region public double Tax1 { get; set; }

		[TableColumn("Tax1")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Tax1", 10)]
		public double Tax1 { get; set; }

		public static PropertyInfo Tax1Property
		{
			get { return GetCurrentType().GetProperty("Tax1"); }
		}
		#endregion

		#region public double Tax2 { get; set; }

		[TableColumn("Tax2")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Tax2", 11)]
		public double Tax2 { get; set; }

		public static PropertyInfo Tax2Property
		{
			get { return GetCurrentType().GetProperty("Tax2"); }
		}
		#endregion

		#region public double Total { get; set; }

		[TableColumn("Total")]
		[MinMaxValueAttribute(0, 1000000000), ListViewData(70, "Total", 12, true)]
		public double Total { get; set; }

		public static PropertyInfo TotalProperty
		{
			get { return GetCurrentType().GetProperty("Total"); }
		}

		#endregion

		#region public  Сurrency Currency { get; set; }

		[TableColumn("CurrencyId")]
		[ListViewData(70, "Currency", 13)]
		public  Сurrency Currency
		{
			get { return _currency ?? Сurrency.UNK; }
			set { _currency = value; }
		}

		public static PropertyInfo CurrencyProperty
		{
			get { return GetCurrentType().GetProperty("Currency"); }
		}

		#endregion


		[ListViewData(70, "PartNumber",1, true)]
		public string PartNumber { get { return ParentComponent?.PartNumber ?? ""; } }
		public static PropertyInfo PartNumberProperty
		{
			get { return GetCurrentType().GetProperty("PartNumber"); }
		}

		[ListViewData(150, "Description",2, true)]
		public string Description { get { return ParentComponent?.Description ?? ""; } }
		public static PropertyInfo DescriptionProperty
		{
			get { return GetCurrentType().GetProperty("Description"); }
		}

		[ListViewData(70, "Class",3, true)]
		public string Class { get { return ParentComponent?.GoodsClass.ToString() ?? GoodsClass.Unknown.ToString(); } }
		public static PropertyInfo ClassProperty
		{
			get { return GetCurrentType().GetProperty("Class"); }
		}

		#region public ProductCost()

		public ProductCost()
		{
			ParentId = -1;
			SupplierId = -1;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(ProductCost));
		}
		#endregion

	}
}