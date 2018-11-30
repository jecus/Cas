using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{
    /// <summary>
    /// Базовая коллекция работающая со словарями
    /// </summary>
    [Serializable]
    public class CommonDictionaryCollection<T> : CommonCollection<T>, IDictionaryCollection where T : class, IDictionaryItem
    {

        #region public CommonDictionaryCollection()
        /// <summary>
        /// Создает коллекцию записей о переносе на основе передаваемого массива 
        /// </summary>
        public CommonDictionaryCollection()
        {
        }
        #endregion

        #region  public CommonDictionaryCollection(IEnumerable<T> items) : base(items)
        /// <summary>
        /// Создает коллекцию записей о переносе на основе передаваемого массива 
        /// </summary>
        /// <param name="items"></param>
        public CommonDictionaryCollection(IEnumerable<T> items) : base(items)
        {
        }
        #endregion

        #region Члены ICommonCollection<T>

        #region public override T GetItemById(Int32 id)
        ///// <summary>
        ///// Возвращает объект заданному ItemID или null
        ///// </summary>
        ///// <param name="id">ItemID</param>
        ///// <returns></returns>
        //public override T GetItemById(Int32 id)
        //{
        //    return Items.FirstOrDefault(item => item.ItemId == id);
        //}
        #endregion

        #endregion

        #region Члены IDictionaryCollection

        #region IDictionaryItem IDictionaryCollection.GetItemById(int id)
        /// <summary>
        /// Возвращает объект заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        IDictionaryItem IDictionaryCollection.GetItemById(int id)
        {
            return GetItemById(id);
        }
        #endregion

        #region IDictionaryItem IDictionaryCollection.this[int indexCollection]
        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        IDictionaryItem IDictionaryCollection.this[int indexCollection]
        {
            get { return this[indexCollection]; }
        }
        #endregion

        #region void IDictionaryCollection.Add(IDictionaryItem addedObject)
        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void IDictionaryCollection.Add(IDictionaryItem addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                Add(addedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region void IDictionaryCollection.AddRange(IEnumerable<IDictionaryItem> objects)
        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void IDictionaryCollection.AddRange(IEnumerable<IDictionaryItem> objects)
        {
            if (objects == null)
                throw new ArgumentNullException("objects", "must be not null");
            if (objects is IEnumerable<T>)
                AddRange(objects as IEnumerable<T>);
            else throw new ArgumentException("must be not of type:" + typeof(IEnumerable<T>), "objects");
        }
        #endregion

        #region bool IDictionaryCollection.CompareAndAdd(IDictionaryItem addedObject)
        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool IDictionaryCollection.CompareAndAdd(IDictionaryItem addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                return CompareAndAdd(addedObject as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region IDictionaryItem[] IDictionaryCollection.ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        IDictionaryItem[] IDictionaryCollection.ToArray()
        {
            return ToArray();
        }
        #endregion

        #region void IDictionaryCollection.Remove(IDictionaryItem removedObject)
        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void IDictionaryCollection.Remove(IDictionaryItem removedObject)
        {
            if (removedObject == null) return;
            if (removedObject is T) Remove(removedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "removedObject");
        }
        #endregion

        #region  public IDictionaryItem GetByShortName(string shortName)
        /// <summary>
        /// Возвращает AtaChapter делая поиск по shortName
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        public IDictionaryItem GetByShortName(string shortName)
        {
            return Items.FirstOrDefault(ad => ad.ShortName.ToUpper() == shortName.ToUpper());
        }

        #endregion

        #region public virtual IDictionaryItem GetByShortName(string fullName)
        /// <summary>
        /// Возвращает AbstractDictionary делая поиск по FullName
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public virtual IDictionaryItem GetByFullName(string fullName)
        {
            return Items.FirstOrDefault(ad => ad.FullName.ToUpper() == fullName.ToUpper());
        }

        #endregion

        #endregion

        #region override public String ToString()

        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "Count = " + Count;
        }
        #endregion
    }
}
