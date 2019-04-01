using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
    public interface IAllProductsFilterParams
    {
        [Filter("Part Number:", Order = 1)]
        string PartNumber { get; }

        [Filter("Standard:")]
        GoodStandart Standart { get; }

        [Filter("Description:", Order = 2)]
        string Description { get; }

        [Filter("Reference:", Order = 3)]
        string Reference { get; }

        [Filter("Product Code:", Order = 4)]
        string Code { get; }

        [Filter("Supplier:")]
        SupplierCollection Suppliers { get;  }

        [Filter("ATA:")]
        AtaChapter ATAChapter { get; }

        [Filter("Class:")]
        GoodsClass GoodsClass { get; }

        [Filter("IsDangerous:", Order = 6)]
        bool IsDangerous { get; }

        [Filter("Remarks:", Order = 5)]
        string Remarks { get; }
    }
}