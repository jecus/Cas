using System;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Directives
{
    /// <summary>
    /// Описывает класс Deffered Item
    /// </summary>
    [Table("Directives", "dbo", "ItemId")]
    [Dto(typeof(DirectiveDTO))]
	[Condition("DirectiveType","5")]
    [Condition("IsDeleted", "0")]
	[Serializable]
    public class DeferredItem : Directive
    {

        /*
         * Свойства
         */

        #region public DeferredCategory DeferredCategory { get; set; }

        private DeferredCategory _deferredCategory;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefferedCategory")]
        public DeferredCategory DeferredCategory
        {
            get { return _deferredCategory ?? (_deferredCategory = DeferredCategory.Unknown); }
            set { _deferredCategory = value; }
        }

        #endregion

        #region public string DeferredLogBookRef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefferedLogBookRef")]
        public string DeferredLogBookRef { get; set; }

        #endregion

        #region public string DeferredMelCdlItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefferedMelCdlItem")]
        public string DeferredMelCdlItem { get; set; }

        #endregion

        #region public string DeferredExtention { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefferedExtention")]
        public string DeferredExtention { get; set; }

        #endregion

        /*
         * Методы
         */

        #region public DefferedItem()
        /// <summary>
        /// Конструктор без дополнительных параметров
        /// </summary>
        public DeferredItem()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.DeferredItem;
            DirectiveType = DirectiveType.DeferredItems;
        }

        #endregion

        #region public String ToString()
        /// <summary>
        /// Служит для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return Title + " " + Description + (_deferredCategory !=null ? " Cat:" + _deferredCategory : "");
        }

        #endregion

    }
}
