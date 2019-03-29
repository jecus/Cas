using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфейс, обозначающий элемент, имеющий связь с поставщиками
    /// </summary>
    public interface ISupplied : IBaseEntityObject
    {
        #region SupplierCollection Suppliers  { get; set; }
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 4)]
        SupplierCollection Suppliers { get; set; }
        #endregion

        #region CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }
        /// <summary>
        /// связи с поставщиками
        /// </summary>
        CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }
        #endregion
    }
}
