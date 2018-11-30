using System;
using SmartCore.DataAccesses.Kits;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий комплектующее
    /// </summary>
    [Serializable]
    [Dto(typeof(KitDTO))]
	public abstract class AbstractAccessory : BaseEntityObject, ISupplied
    {
        #region abstract Product Product { get; set; }
        /// <summary>
        /// Описание агрегата
        /// </summary>
        public abstract Product Product { get; set; }
        #endregion

        #region public abstract String SerialNumber { get; set; }
        /// <summary>
        /// серийный номер
        /// </summary>
        public abstract String SerialNumber { get; set; }
        #endregion

        #region public abstract GoodStandart Standart { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Standart", 1)]
        public abstract GoodStandart Standart { get; set; }
        #endregion

        #region public abstract String PartNumber { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Part Number", 1)]
        public abstract String PartNumber { get; set; }
        #endregion

        #region public abstract GoodsClass GoodsClass { get; set; }
        /// <summary>
        /// Класс
        /// </summary>
        public abstract GoodsClass GoodsClass { get; set; }

        #endregion

        #region public abstract String BatchNumber { get; set; }
        /// <summary>
        /// Пакетный номер
        /// </summary>
        public abstract String BatchNumber { get; set; }
        #endregion

        #region public abstract String Description { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        [ListViewData(0.12f, "Description", 2)]
        public abstract String Description { get; set; }
        #endregion

        #region public abstract String Manufacturer { get; set; }
        /// <summary>
        /// производитель
        /// </summary>
        [ListViewData(0.12f, "Manufacturer", 3)]
        public abstract String Manufacturer { get; set; }
        #endregion

        #region public abstract double Quantity { get; set; }
        /// <summary>
        /// количество 
        /// </summary>
        [ListViewData(0.08f, "Q-ty")]
        public abstract double Quantity { get; set; }
        #endregion

        #region public abstract Measure Measure { get; set; }
        /// <summary>
        /// единица измерения
        /// </summary>
        [ListViewData(0.1f, "Measure")]
        public abstract Measure Measure { get; set; }
        #endregion

        #region public abstract double CostNew { get; set; }
        /// <summary>
        /// стоимость нового
        /// </summary>
        [ListViewData(0.08f, "Cost new")]
        public abstract double CostNew { get; set; }
        #endregion

        #region public abstract double CostServiceable { get; set; }
        /// <summary>
        /// стоимость после обслуживания 
        /// </summary>
        [ListViewData(0.08f, "Cost Serv.")]
        public abstract double CostServiceable { get; set; }
        #endregion

        #region public abstract double CostOverhaul { get; set; }
        /// <summary>
        /// стоимость после ремонта
        /// </summary>
        [ListViewData(0.08f, "Cost OH")]
        public abstract double CostOverhaul { get; set; }
        #endregion

        #region public abstract String Remarks { get; set; }
        /// <summary>
        /// Замечания по KIT - у 
        /// </summary>
        [ListViewData(0.12f, "Remarks")]
        public abstract String Remarks { get; set; }
        #endregion

        #region public string KitParentString { get; }

        /// <summary>
        /// Строковое описание родителя
        /// </summary>
        [ListViewData(0.12f, "Parent", 5)]
        public abstract string ParentString { get; }
        #endregion

        #region public abstract SupplierCollection Suppliers  { get; set; }
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 4)]
        public abstract SupplierCollection Suppliers { get; set; }
        #endregion

        #region public abstract CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }
        /// <summary>
        /// связи с поставщиками данного KIT-а
        /// </summary>
        public abstract CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }
        #endregion

    }
}
