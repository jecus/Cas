using System;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Класс описывает тип запуска двигателей/ВСУ
    /// </summary>
    [Table("Reasons", "dictionaries", "ItemId")]
	[Dto(typeof(ReasonDTO))]
    [DictionaryCollection(typeof(CommonDictionaryCollection<Reason>))]
    public class Reason : AbstractDictionary
    {

        #region public String ShortName { get; set; }

        /// <summary>
        /// Сокращенное название (4-х буквенное обозначение)
        /// </summary>
        //[TableColumn("ShortName")]
        //[FormControl("Index", Enabled = true, Order = 2)]
        //[ListViewData(100f, "Index", 2)]
        //[NotNull]
        public override String ShortName { get; set; }

        #endregion

        #region public String FullName { get; set; }

        private string _name;
        /// <summary>
        /// Полное название
        /// </summary>
        [TableColumn("Name")]
        [FormControl("Name", Enabled = true, Order = 1)]
        [ListViewData(200f, "Name", 1)]
        [NotNull]
        public override String FullName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("FullName");
            }
        }
        #endregion

        #region public override string CommonName { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        public override string CommonName
        {
            get { return FullName; }
            set { FullName = value; }
        }
        #endregion

        #region public override string Category { get; set; }
        /// <summary>
        /// категория записи
        /// </summary>
        [TableColumnAttribute("Category")]
        public override string Category { get; set; }
        #endregion

        public Reason()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Reason;
        }

        #region public override string ToString()
        public override string ToString()
        {
            return FullName;
        }
        #endregion


        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is Reason)
                SetProperties((Reason)dictionary);
        }
        #endregion

        #region public void SetProperties(Reason dictionary)
        public void SetProperties(Reason dictionary)
        {
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
        }
        #endregion
    }
}
