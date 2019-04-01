using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    [Table("DamageCharts","Template","ItemId")]
    public class TemplateDamageChart : BaseEntityObject
    {
        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит элемент
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public String ChartName { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        [TableColumnAttribute("ChartName"), ListViewData("Chart Name")]
        public String ChartName { get; set; }
        #endregion

        #region  public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Модель самолета
        /// </summary>
        [TableColumnAttribute("AircraftModelID"), ListViewData("Aircraft Model")]
        public AircraftModel AircraftModel { get; set; }
        #endregion

        #region  Implement of ISingleFileContainer

        #region public int FileId { get; set; }
        /// <summary>
        /// ИД фаила листа повреждений
        /// </summary>
        [TableColumnAttribute("FileId")]
        public int FileId { get; set; }
		#endregion

		//TODO: переделать на использование нового fileCore
		#region  public AttachedFile AttachedFile { get; set; }
		/// <summary>
		/// Файл листа повреждений
		/// </summary>
		public AttachedFile AttachedFile { get; set; }
        #endregion

        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ChartName;
        }
        #endregion

        #region public TemplateDamageChart()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public TemplateDamageChart()
        {
            IsDeleted = false;
            ItemId = -1;
            ChartName = "";
            AircraftModel = new AircraftModel {ItemId = -1};
            FileId = -1;
            AttachedFile = null;
        }
        #endregion

        #region public TemplateDamageChart(Int32 itemId, String chartName, AircraftModel aircraftModel, int fileId)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="chartName"></param>
        /// <param name="aircraftModel"></param>
        /// <param name="fileId"></param>
        public TemplateDamageChart(Int32 itemId, String chartName, AircraftModel aircraftModel, int fileId)
        {
            IsDeleted = false;
            ItemId = itemId;
            ChartName = chartName;
            AircraftModel = aircraftModel;
            FileId = fileId;
        }
        #endregion
    }
}
