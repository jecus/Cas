using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{
    public interface IDictionaryCollection :ICommonCollection// IEnumerable, INotifyCollectionChanged
    {
        #region new IDictionaryItem GetItemById(Int32 id);
        /// <summary>
        /// Возвращает объект заданному ItemID или создает новый объект по умолчанию
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        new IDictionaryItem GetItemById(Int32 id);
        #endregion

        #region new IDictionaryItem this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        new IDictionaryItem this[Int32 indexCollection] { get; }

        #endregion

        #region void Add(IDictionaryItem addedObject)

        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void Add(IDictionaryItem addedObject);
        #endregion

        #region void AddRange(IEnumerable<IDictionaryItem> objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void AddRange(IEnumerable<IDictionaryItem> objects);
        #endregion

        #region bool CompareAndAdd(IDictionaryItem addedObject)

        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool CompareAndAdd(IDictionaryItem addedObject);
        #endregion

        #region new IDictionaryItem[] ToArray();

        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        new IDictionaryItem[] ToArray();
        #endregion

        #region void Remove(IDictionaryItem removedObject)

        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void Remove(IDictionaryItem removedObject);

        #endregion

        #region void Clear()

        ///// <summary>
        ///// очистка всех элементов коллекции
        ///// </summary>
        //void Clear();

        #endregion

        #region  public IDictionaryItem GetByShortName(string shortName)

        /// <summary>
        /// Возвращает AbstractDictionary делая поиск по shortName
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        IDictionaryItem GetByShortName(string shortName);

        #endregion

        #region  public IDictionaryItem GetByFullName(string shortName)

        /// <summary>
        /// Возвращает AbstractDictionary делая поиск по FullName
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        IDictionaryItem GetByFullName(string shortName);

        #endregion
    }
}
