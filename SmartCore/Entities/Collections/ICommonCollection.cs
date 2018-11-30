using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.Collections
{
    /// <summary>
    /// Интерфейс, определяющий нетипизированную коллекцию объектов, 
    /// реализующих интерфейс IBaseEntityObject и методы для удобной работы с ними
    /// Реализует интерфейсы IEnumerable, INotifyCollectionChanged
    /// </summary>
    public interface ICommonCollection : IEnumerable, INotifyCollectionChanged
    {
        #region IBaseEntityObject GetItemById(Int32 id)

        /// <summary>
        /// Возвращает объект заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        IBaseEntityObject GetItemById(Int32 id);

        #endregion

        #region IBaseEntityObject this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        IBaseEntityObject this[Int32 indexCollection] { get; }

        #endregion

        #region void Add(IBaseEntityObject addedObject)

        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void Add(IBaseEntityObject addedObject);
        #endregion

        #region void AddRange(IEnumerable<IBaseEntityObject> objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void AddRange(IEnumerable<IBaseEntityObject> objects);
        #endregion

        #region void AddRange(ICommonCollection objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void AddRange(ICommonCollection objects);
        #endregion

        #region int Count { get; }
        /// <summary>
        /// Возвращает количество элементов в коллекции
        /// </summary>
        int Count { get; }
        #endregion

        #region bool Contains(IBaseEntityObject coreObject);
        /// <summary>
        /// проверяет наличие объекта в списке объектов
        /// </summary>
        /// <param name="coreObject"></param>
        bool Contains(IBaseEntityObject coreObject);

        #endregion

        #region bool ContainsById(int itemId);
        /// <summary>
        /// проверяет наличие объекта с заданным Id в списке объектов 
        /// </summary>
        /// <param name="itemId"></param>
        bool ContainsById(int itemId);

        #endregion

        #region bool CompareAndAdd(IBaseEntityObject addedObject)

        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool CompareAndAdd(IBaseEntityObject addedObject);
        #endregion

        #region int IndexOf(IBaseEntityObject item);

        /// <summary>
        /// Возвращает индекс элемента в коллекции или -1 если его в коллекции нет
        /// </summary>
        int IndexOf(IBaseEntityObject item);
        #endregion

        #region IBaseEntityObject[] ToArray()

        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        IBaseEntityObject[] ToArray();
        #endregion

        #region IBaseEntityObject[] GetValidEntries();

        /// <summary>
        /// Возвращает массив действительных записей (где IsDeleted = false)
        /// </summary>
        /// <returns></returns>
        IBaseEntityObject[] GetValidEntries();

        #endregion

        #region void Remove(IBaseEntityObject removedObject)

        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void Remove(IBaseEntityObject removedObject);

        #endregion

        #region void RemoveById(int itemId);

        /// <summary>
        /// Удаляет объект с заданным ID из списка 
        /// </summary>
        /// <param name="itemId"></param>
        void RemoveById(int itemId);

        #endregion

        #region void Clear()

        /// <summary>
        /// очистка всех элементов коллекции
        /// </summary>
        void Clear();

        #endregion
    }
}
