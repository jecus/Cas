using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Содержит список Ata глав
    /// </summary>
    public class AtaChapterCollection : CommonDictionaryCollection<AtaChapter>//CommonCollection<AtaChapter> //IEnumerable
    {

        #region public  AtaChapterCollection()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public AtaChapterCollection()
        {

        }

        #endregion

        #region public  AtaChapterCollection(AtaChapter[] ataChapters)
        /// <summary>
        /// Создает лист из массива AtaChapter
        /// </summary>
        /// <param name="ataChapters"></param>
        public AtaChapterCollection(AtaChapter[] ataChapters) :base(ataChapters)
        {
        }

        #endregion

        #region public IEnumerator GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<AtaChapter> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region  public AtaChapter GetAtaChapterByShortName(string shortName)
        /// <summary>
        /// Возвращает AtaChapter делая поиск по shortName
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        public AtaChapter GetAtaChapterByShortName(string shortName)
        {
            return Items.FirstOrDefault(ataChapter => ataChapter.ShortName.ToUpper() == shortName.ToUpper());
        }

        #endregion

        #region public override AtaChapter GetItemById(Int32 id)
        /// <summary>
        /// Возвращает объект заданному ItemID или создает новый объект по умолчанию
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        public override AtaChapter GetItemById(Int32 id)
        {
            if (id == 0) id = 21;
            AtaChapter result = Items.FirstOrDefault(list => list.ItemId == id);
            return result ?? new AtaChapter { FullName = "Can't Find item with id:" + id, ItemId = id };
        }
        #endregion

        #region public override IDictionaryItem GetByShortName(string fullName)
        /// <summary>
        /// Возвращает AtaChapter делая поиск по FullName
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public override IDictionaryItem GetByFullName(string fullName)
        {
            AtaChapter result = Items.FirstOrDefault(ad => ad.FullName.ToUpper() == fullName.ToUpper());
            return result ?? GetItemById(21);
        }

        #endregion
 
     }

}
