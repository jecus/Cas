using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    [Table("LLPLifeLimitCategory", "Template", "ItemId")]
    [Serializable]
	public class TemplateLLPLifeLimitCategory : BaseEntityObject
    {
        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит элемент
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public String CategoryType { get; set; }
        /// <summary>
        /// Типа категории (A,B,C,D) 
        /// </summary>
        [TableColumnAttribute("CategoryType"), ListViewData("Category Type")]
        public String CategoryType { get; set; }
        #endregion

        #region public String CategoryName { get; set; }
        /// <summary>
        /// Название типа катеогрии для данной модели самолета (A - 3A1, B - 3B2 и т.д.)
        /// </summary>
        [TableColumnAttribute("CategoryName"), ListViewData("Category Name")]
        public String CategoryName { get; set; }
        #endregion

        #region  public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Модель самолета
        /// </summary>
        [TableColumnAttribute("AircraftModelId"), ListViewData("Aircraft Model")]
        public AircraftModel AircraftModel { get; set; }
        #endregion

        #region char GetChar()
        ///<summary>
        /// возвращает первую букву из типа категории
        ///</summary>
        ///<returns></returns>
        public char GetChar()
        {
            return char.ToUpper(CategoryType.ToCharArray()[0]);
        }
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

        #region public TemplateLLPLifeLimitCategory()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public TemplateLLPLifeLimitCategory()
        {
            SmartCoreObjectType = SmartCoreType.Unknown;

            IsDeleted = false;
            ItemId = -1;
            CategoryName = "";
            AircraftModel = new AircraftModel {ItemId = -1};
            
        }
        #endregion

        #region public TemplateLLPLifeLimitCategory(Int32 itemID, String categoryName, AircraftModel aircraftModel)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="categoryType"></param>
        /// <param name="categoryName"></param>
        /// <param name="aircraftModel"></param>
        public TemplateLLPLifeLimitCategory(String categoryType, String categoryName, AircraftModel aircraftModel)
            : this()
        {
            CategoryType = categoryType;
            CategoryName = categoryName;
            AircraftModel = aircraftModel;
        }
        #endregion
    }
}
