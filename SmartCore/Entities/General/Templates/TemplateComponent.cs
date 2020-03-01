using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Templates
{
    #region TemplateComponent
    /// <summary>
    /// Класс описывает шаблон компонента
    /// </summary>
    [Serializable]
    [Table("Components", "Template", "ItemId")]
    [Condition("IsBaseComponent", "0")]
    public class TemplateComponent : BaseEntityObject, IKitRequired, IComparable<Accessory.Component>
    {

        /*
        *  Свойства
        */
        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит данная деталь
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public Int32 ParentId { get; set; }
        /// <summary>
        /// Код родитнльской детали, которой принадлежит данная деталь
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public Int32 ParentId { get; set; }
        #endregion

        #region public AtaChapter ATAChapter { get; set; }
        /// <summary>
        /// Внешний ключ на идентификатор записи со справочной информацией
        /// </summary>
        [TableColumnAttribute("ATAChapterId"), ListViewData("ATA Chapter")]
        public AtaChapter ATAChapter { get; set; }
        #endregion

        #region public String PartNumber { get; set; }
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [TableColumnAttribute("PartNumber"), ListViewData("P/N")]
        public String PartNumber { get; set; }
        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [TableColumnAttribute("Description"), ListViewData("Description")]
        public String Description { get; set; }
        #endregion

        #region public String SerialNumber { get; set; }
        /// <summary>
        /// Серийный номер агреагата
        /// </summary>
        [TableColumnAttribute("SerialNumber"), ListViewData("S/N")]
        public String SerialNumber { get; set; }
        #endregion

        #region public String BatchNumber { get; set; }
        /// <summary>
        /// Пакетный номер агреагата
        /// </summary>
        [TableColumnAttribute("BatchNumber"), ListViewData("B/N")]
        public String BatchNumber { get; set; }
        #endregion

        #region public MaintenanceControlProcess MaintenanceControlProcess { get; set; }
        /// <summary>
        /// Идентификатор записи с типом технического обслуживания
        /// </summary>
        [TableColumnAttribute("MaintenanceType"), ListViewData("Maint. Proc.")]
        public MaintenanceControlProcess MaintenanceControlProcess { get; set; }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [TableColumnAttribute("Remarks"), ListViewData("Remarks")]
        public String Remarks { get; set; }
		#endregion

		#region public ComponentModel Model { get; set; }
		/// <summary>
		/// Модель агрегата
		/// </summary>
		[TableColumnAttribute("Model"), ListViewData("Model")]
        public ComponentModel Model { get; set; }
        #endregion

        #region public String Manufacturer { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [TableColumnAttribute("Manufacturer"), ListViewData("Manufacturer")]
        public String Manufacturer { get; set; }
		#endregion

		#region public Boolean IsBaseComponent { get; set; }
		/// <summary>
		/// Флаг, показывающий, является ли агрегат базовым
		/// </summary>
		[TableColumnAttribute("IsBaseComponent")]
        public bool IsBaseComponent { get; set; }
        #endregion

        #region public Boolean LLPMark { get; set; }
        /// <summary>
        /// Отметка LLP
        /// </summary>
        [TableColumnAttribute("LLPMark"), ListViewData("Is LLP")]
        public Boolean LLPMark { get; set; }
        #endregion

        #region public Boolean LLPCategories { get; set; }
        /// <summary>
        /// Отметка о том, что наработка по LLP ведется согласно LLP категориям
        /// </summary>
        [TableColumnAttribute("LLPCategories")]
        public Boolean LLPCategories { get; set; }
        #endregion

        #region public LandingGearMarkType LandingGear { get; set; }
        /// <summary>
        /// Отметка Landing Gear
        /// </summary>
        [TableColumnAttribute("LandingGear"), ListViewData("Landing Gear")]
        public LandingGearMarkType LandingGear { get; set; }
        #endregion

        #region public AvionicsInventoryMarkType AvionicsInventory { get; set; }
        /// <summary>
        /// Отметка Avionics Inventory
        /// </summary>
        [TableColumnAttribute("AvionicsInventory"), ListViewData("Avionx. Inv-ry")]
        public AvionicsInventoryMarkType AvionicsInventory { get; set; }
        #endregion

        #region public String ALTPartNumber { get; set; }
        /// <summary>
        /// Alternative part number
        /// </summary>
        [TableColumnAttribute("ALTPartNumber"), ListViewData("ALT P/N")]
        public String ALTPartNumber { get; set; }
        #endregion

        #region public String MTOGW { get; set; }
        /// <summary>
        /// Максимальный взлетный вес
        /// </summary>
        [TableColumnAttribute("MTOGW"), ListViewData("MTOGW")]
        public String MTOGW { get; set; }
        #endregion

        #region public String HushKit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("HushKit"), ListViewData("Hush Kit")]
        public String HushKit { get; set; }
        #endregion

        #region public Double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Cost"), ListViewData("Cost"), MinMaxValueAttribute(0, 1000000000)]
        public Double Cost { get; set; }
        #endregion

        #region public Double CostOverhaul { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("CostOverhaul"), ListViewData("Cost Overhaul"), MinMaxValueAttribute(0, 1000000000)]
        public Double CostOverhaul { get; set; }
        #endregion

        #region public Double CostServiceable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("CostServiceable"), ListViewData("Cost Serviceable"), MinMaxValueAttribute(0, 1000000000)]
        public Double CostServiceable { get; set; }
        #endregion

        #region public public Int32 Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Quantity"), ListViewData("Q-ty"), MinMaxValueAttribute(0, 1000000000)]
        public Int32 Quantity { get; set; }
        #endregion

        #region public Double ManHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("ManHours"), ListViewData("Man Hours"), MinMaxValueAttribute(0, 100000)]
        public Double ManHours { get; set; }
		#endregion

		//TODO: переделать на использование нового fileCore
		#region public AttachedFile FaaFormFile { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("FaaFormFileId"), ListViewData("FAA Form File")]
        public AttachedFile FaaFormFile { get; set; }
        #endregion

        #region public Lifelength Warranty { get; set; }
        /// <summary>
        /// Гарантийный срок на деталь 
        /// </summary>
        [TableColumnAttribute("Warranty"), ListViewData("Warranty")]
        public Lifelength Warranty { get; set; }
        #endregion

        #region public Lifelength WarrantyNotify { get; set; }
        /// <summary>
        /// Предупреждение об истечении гарантии
        /// </summary>
        [TableColumnAttribute("WarrantyNotify"), ListViewData("Notify")]
        public Lifelength WarrantyNotify { get; set; }
        #endregion

        #region public Boolean Serviceable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Serviceable"), ListViewData("Serviceable")]
        public Boolean Serviceable { get; set; }
		#endregion

		#region public GoodsClass GoodsClass { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Type")]
        public GoodsClass GoodsClass { get; set; }
        #endregion

        #region public String ShelfLife { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("ShelfLife"), ListViewData("Shelf Life")]
        public String ShelfLife { get; set; }
        #endregion

        #region public String MPDItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("MPDItem"), ListViewData("MPD Item")]
        public String MPDItem { get; set; }
        #endregion

        #region public SupplierCollection Supplier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SupplierCollection Suppliers { get; set; }
        #endregion

        #region public Lifelength LifeLimit { get; set; }
        /// <summary>
        /// Ограничение срока эксплуатации агрегата
        /// </summary>
        [TableColumnAttribute("LifeLimit"), ListViewData("LifeLimit")]
        public Lifelength LifeLimit { get; set; }
        #endregion

        #region public Lifelength LifeLimitNotify { get; set; }
        /// <summary>
        /// Уведомление до ограничения срока эксплуатации агрегата
        /// </summary>
        [TableColumnAttribute("LifeLimitNotify"), ListViewData("Notify")]
        public Lifelength LifeLimitNotify { get; set; }
		#endregion

		#region public TemplateComponent()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public TemplateComponent()
        {
            SmartCoreObjectType = SmartCoreType.Component;
            // Отрицательный индекс свидетельствует о том, что агрегат не сохранен в базе данных
            ItemId = -1;

            // Все ресурсы должны быть заполнеными - иначе исключение при сохранении в базу данных
            Warranty = Lifelength.Null;
            WarrantyNotify = Lifelength.Null;
            LifeLimit = Lifelength.Null;
            LifeLimitNotify = Lifelength.Null;

            // Задаем Maintenance Type
            MaintenanceControlProcess = MaintenanceControlProcess.OC;

            // String тоже не должны быть равны null
            PartNumber = Description = SerialNumber = Remarks = Manufacturer = ALTPartNumber = MTOGW = HushKit = ShelfLife
                = BatchNumber = MPDItem;
            Suppliers = new SupplierCollection();
            Kits = new CommonCollection<AccessoryRequired>();
            ComponentDirectives = new List<TemplateComponentDirective>();
        }
        #endregion

        public List<TemplateComponentDirective> ComponentDirectives { get; set; }

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SerialNumber + " " + PartNumber + " " + Description;
        }
		#endregion

		#region public int CompareTo(Component y)

		public int CompareTo(Accessory.Component y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        #region Implement IkitRequired

        #region public string KitParentString { get; }
        /// <summary>
        /// Возвращает строку для описания родителя КИТа
        /// </summary>
        public string KitParentString
        {
            get
            {
                return $"Templ.Compnt.:{this} {Description}";
            }
        }
        #endregion

        public CommonCollection<AccessoryRequired> Kits { get; set; }

        #endregion

    }
    #endregion
}
