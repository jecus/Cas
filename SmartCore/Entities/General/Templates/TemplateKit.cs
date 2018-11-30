using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    [Table("Kits", "Template", "ItemId")]
    public class TemplateKit : BaseEntityObject
    {
        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит данный элемент
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        private BaseEntityObject _parent;

        #region public Int32 ParentId { get; set; }
        /// <summary>
        /// Id родительского элемента 
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public Int32 ParentId { get; set; }
        #endregion

        #region public Int16 ParentTypeId { get; set; }
        /// <summary>
        /// Тип родительского элемента 
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public Int16 ParentTypeId { get; set; }
        #endregion

        #region public bool IsNonRoutineKit { get; private set; }
        [TableColumnAttribute("IsNonRoutineKit")]
        public bool IsNonRoutineKit { get; private set; }
        #endregion

        #region public AircraftModel AircraftModel  { get; set; }
        [TableColumnAttribute("AircraftModelId"), ListViewData("Aircraft Model")]
        public AircraftModel AircraftModel { get; set; }
        #endregion

        #region public String PartNumber { get; set; }
        /// <summary>
        /// партийный номер KIT - а
        /// </summary>
        [TableColumnAttribute("PartNumber"), ListViewData("P/N")]
        public String PartNumber { get; set; }
        #endregion
        
        #region public String Description { get; set; }
        /// <summary>
        /// описание KIT - а
        /// </summary>
        [TableColumnAttribute("Description"), ListViewData("Description")]
        public String Description { get; set; }
        #endregion

        #region public String Manufacturer { get; set; }
        /// <summary>
        /// производитель KIT - а 
        /// </summary>
        [TableColumnAttribute("Manufacturer"), ListViewData("Manufacturer")]
        public String Manufacturer { get; set; }
        #endregion

        #region public int Quantity { get; set; }
        /// <summary>
        /// количество 
        /// </summary>
        [TableColumnAttribute("Quantity"), ListViewData("Q-ty")]
        public int Quantity { get; set; }
        #endregion

        #region public double CostNew { get; set; }
        /// <summary>
        /// стоимость нового
        /// </summary>
        [TableColumnAttribute("CostNew"), ListViewData("Cost New")]
        public double CostNew { get; set; }
        #endregion

        #region public double CostServiceable { get; set; }
        /// <summary>
        /// стоимость после обслуживания 
        /// </summary>
        [TableColumnAttribute("CostServiceable"), ListViewData("Cost Serviceable")]
        public double CostServiceable { get; set; }
        #endregion

        #region public double CostOverhaul { get; set; }
        /// <summary>
        /// стоимость после ремонта
        /// </summary>
        [TableColumnAttribute("CostOverhaul"), ListViewData("Cost Overhaul")]
        public double CostOverhaul { get; set; }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Замечания по KIT - у 
        /// </summary>
        [TableColumnAttribute("Remarks"), ListViewData("Remarks")]
        public String Remarks { get; set; }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PartNumber + " " + Description;
        }
        #endregion

        #region public int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is TemplateKit) return PartNumber.CompareTo(((TemplateKit)y).PartNumber);
            return 0;
        }
        #endregion

        #region public TemplateKit()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public TemplateKit()
        {
            ItemId = -1;
            ParentId = -1;
            IsNonRoutineKit = false;
            Description = "";
            PartNumber = "";
            Remarks = "";
            Manufacturer = "";
            
            _parent = new BaseEntityObject();
        }
        #endregion

        #region public TemplateKit(BaseSmartCoreObject parent)
        /// <summary>
        /// Конструктор создает объект с привязкой родительского объекта
        /// </summary>
        public TemplateKit(BaseEntityObject parent)
            : this()
        {
            if(parent != null)ParentId = parent.ItemId;
        }
        #endregion

        #region public TemplateKit(bool isNonRoutineKit, AircraftModel aircraftModel)
        /// <summary>
        /// Конструктор создае Не рутинного кита
        /// </summary>
        public TemplateKit(bool isNonRoutineKit, AircraftModel aircraftModel)
            : this()
        {
            IsNonRoutineKit = isNonRoutineKit;
            AircraftModel = aircraftModel;
        }
        #endregion
    }
}
