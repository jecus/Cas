using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    #region TemplateAircraft
    /// <summary>
    /// Класс описывает шаблон воздушного судна
    /// </summary>
    [Serializable]
    [Table("Templates", "Template", "ItemId")]
    public class Template : BaseEntityObject, IComparable<Template>
    {

        /*
        * Свойства
        */

        #region public String Name { get; set; }
        /// <summary>
        /// Название шаблона
        /// </summary>
        [TableColumnAttribute("Name")]
        public String Name { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public TemplateAircraft TemplateAircraft { get; set; }
        /// <summary>
        /// ВС принадлежащее данному шаблону
        /// </summary>
        public TemplateAircraft TemplateAircraft { get; set; }
        #endregion

        #region public Template()
        /// <summary>
        /// Создает шаблон без доп информации
        /// </summary>
        public Template()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Aircraft;
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }


        #endregion

        #region public int CompareTo(Template y)

        public int CompareTo(Template y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

    #endregion
}
