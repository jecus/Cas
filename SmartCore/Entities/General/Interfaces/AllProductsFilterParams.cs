using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IAllProductsFilterParams
	{
		[Filter("Part Number:", Order = 1)]
		string PartNumber { get; }

		[Filter("Alt Part Number:", Order = 2)]
		string AltPartNumber { get; }

		[Filter("Standard:")]
		GoodStandart Standart { get; }

		[Filter("Description:", Order = 3)]
		string Description { get; }

		[Filter("Reference:", Order = 4)]
		string Reference { get; }

		[Filter("Product Code:", Order = 5)]
		string Code { get; }

		[Filter("Supplier:")]
		SupplierCollection Suppliers { get;  }

		[Filter("ATA:")]
		AtaChapter ATAChapter { get; }

		[Filter("Class:")]
		GoodsClass GoodsClass { get; }

		[Filter("IsDangerous:", Order = 8)]
		bool IsDangerous { get; }

		[Filter("IsForbidden:", Order = 7)]
		bool IsForbidden { get; }

		[Filter("Remarks:", Order = 6)]
		string Remarks { get; }
	}
}