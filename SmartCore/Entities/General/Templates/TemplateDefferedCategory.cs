using System;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    [Table("DefferedCategories", "Template", "ItemId")]
    public class TemplateDefferedCategory : BaseEntityObject
    {
        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит элемент
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public String CategoryName { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        [TableColumnAttribute("CategoryName"), ListViewData("Category Name")]
        public String CategoryName { get; set; }
        #endregion

        #region  public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [TableColumnAttribute("AircraftModelId"), ListViewData("Aircraft Model")]
        public AircraftModel AircraftModel { get; set; }
        #endregion

        #region public DirectiveThreshold Threshold { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        [TableColumnAttribute("Threshold"), ListViewData("Threshold")]
        public DirectiveThreshold Threshold { get; set; }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CategoryName;
        }
        #endregion

        #region public TemplateDefferedCategory()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public TemplateDefferedCategory()
        {
            IsDeleted = false;
            ItemId = -1;
            CategoryName = "";
            AircraftModel = new AircraftModel {ItemId = -1};
            Threshold = new DirectiveThreshold{
                FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst,
                FirstPerformanceSinceEffectiveDate = Lifelength.Null,PerformSinceNew = true, PerformSinceEffectiveDate = true};
        }
        #endregion

        #region public TemplateDefferedCategory(Int32 itemID, String categoryName, AircraftModel aircraftModel, DirectiveThreshold threshold)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="categoryName"></param>
        /// <param name="aircraftModel"></param>
        /// <param name="threshold"></param>
        public TemplateDefferedCategory(Int32 itemId, String categoryName, AircraftModel aircraftModel, DirectiveThreshold threshold)
        {
            IsDeleted = false;
            ItemId = itemId;
            CategoryName = categoryName;
            AircraftModel = aircraftModel;
            Threshold = threshold;
        }
        #endregion
    }
}
