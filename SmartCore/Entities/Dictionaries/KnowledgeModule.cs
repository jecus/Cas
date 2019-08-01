using System;
using EntityCore.DTO.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Table("KnowledgeModules", "dbo", "ItemId")]
	[Dto(typeof(KnowledgeModuleDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class KnowledgeModule : AbstractDictionary
    {
        #region public KnowledgeModule()

        public KnowledgeModule()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.KnowledgeModule;
        }

        #endregion

        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        /// <summary>
        /// Полное название Категории
        /// </summary>
        //[TableColumn("FullName")]
        //[FormControl(250, "Name", 1, Order = 1)]
        //[ListViewData(0.2f, "Name", 1)]
        //[NotNull]
        public override string FullName
        {
            get { return Title; }
            set
            {
                Title = value;
            }
        }

        #endregion

        #region public override string ShortName { get; set; }

        public override string ShortName
        {
            get { return Number; }
            set { Number = value; }
        }

        #endregion

        #region public override string CommonName

        public override string CommonName
        {
            get { return Description; }
            set { Description = value; }
        }
        #endregion

        #region public override string Category
        /// <summary>
        /// Категория не сохраняется 
        /// </summary>
        public override string Category { get; set; }
        #endregion

        #endregion

        #region public String Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Number")]
        [ListViewData(0.15f, "Module Number")]
        [FormControl(300, "Module Number")]
        [NotNull]
        public String Number { get; set; }
        #endregion

        #region public String Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Title")]
        [ListViewData(0.2f, "Title")]
        [FormControl(300, "Title")]
        [NotNull]
        public String Title { get; set; }
        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Description", 2048)]
        [ListViewData(0.3f, "Description")]
        [FormControl(300, "Description", 12)]
        [NotNull]
        public String Description { get; set; }
        #endregion

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is KnowledgeModule)
                SetProperties((KnowledgeModule)dictionary);
        }
        #endregion

        #region public void SetProperties(KnowledgeModule dictionary)
        public void SetProperties(KnowledgeModule dictionary)
        {
            Number = dictionary.Number;
            Title = dictionary.Title;
            Description = dictionary.Description;

            OnPropertyChanged("FullName");
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsDeleted)
                return Number + " " + Title + " is deleted.";
            return Number + " " + Title;
        }

        #endregion 

    }
}
