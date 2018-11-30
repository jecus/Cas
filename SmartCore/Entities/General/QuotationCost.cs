using System;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General
{
	[Table("QuotationCost", "dbo", "ItemId")]
	[Dto(typeof(QuotationCostDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class QuotationCost : BaseEntityObject
	{
		private Сurrency _currency;

		#region public double Cost { get; set; }

		[TableColumn("Cost")]
		public double Cost { get; set; }

		#endregion

		#region public int ProductId { get; set; }

		[TableColumn("ProductId")]
		public int ProductId { get; set; }

		#endregion

		#region public int SupplierId { get; set; }

		[TableColumn("SupplierId")]
		public int SupplierId { get; set; }

		#endregion

		#region public int QuotationId { get; set; }

		[TableColumn("QuotationId")]
		public int QuotationId { get; set; }

		#endregion

		#region public double CostServisible { get; set; }

		[TableColumn("CostServisible")]
		public double CostServisible { get; set; }

		#endregion

		#region public double CostOverhaul { get; set; }

		[TableColumn("CostOverhaul")]
		public double CostOverhaul { get; set; }

		#endregion

		#region public Сurrency Currency

		[TableColumn("CurrencyId")]
		public Сurrency Currency
		{
			get { return _currency ?? Сurrency.UNK; }
			set { _currency = value; }
		}

		#endregion

		public string SupplierName { get; set; }
	}
}