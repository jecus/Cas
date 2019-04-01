using System;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Ata Chapter
    /// </summary>
    [Table("ATAChapter","Dictionaries","ItemId")]
	[Dto(typeof(ATAChapterDTO))]
    [DictionaryCollection(typeof(AtaChapterCollection))]
    [Serializable]
    public class AtaChapter : AbstractDictionary
    {
        #region public AtaChapter()

        public AtaChapter()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.AtaChapter;
        }

            #endregion

        #region public String ShortName { get; set; }

        /// <summary>
        /// Сокращенное название
        /// </summary>
        [TableColumn("ShortName")]
        public override String ShortName { get; set; }

        #endregion

        #region public String FullName { get; set; }

        /// <summary>
        /// Полное название
        /// </summary>
        [TableColumn("FullName")]
        public override String FullName { get; set; }
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
        public override string Category
        {
            get { return FullName; }
            set { FullName = value; }
        }
        #endregion

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is AtaChapter)
                SetProperties((AtaChapter)dictionary);
        }
        #endregion

        #region public void SetProperties(AtaChapter dictionary)
        public void SetProperties(AtaChapter dictionary)
        {
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
        }
        #endregion

        #region  public override string ToString()

        /// <summary>
        /// Возвращает комбинацию полей ShortName+" "+ FullName;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName + " " + FullName;
        }

        #endregion

    }
}