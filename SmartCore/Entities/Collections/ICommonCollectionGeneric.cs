using System;
using System.Collections.Generic;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.Collections
{
    public interface ICommonCollection<T>: ICommonCollection, IEnumerable<T> where T : IBaseEntityObject
    {
        #region new T GetItemById(Int32 id)

        /// <summary>
        /// Возвращает объект заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        new T GetItemById(Int32 id);

        #endregion

        #region new T this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        new T this[Int32 indexCollection] { get; }

        #endregion

        #region void Add(T addedObject)

        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void Add(T addedObject);
        #endregion

        #region void AddRange(IEnumerable<T> objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void AddRange(IEnumerable<T> objects, bool ignoreSort = false);
        #endregion

        #region bool CompareAndAdd(T addedObject)

        /// <summary>
        /// Сравнивает объекты имеющиеся в коллекции с добавляемым объектом по их ID
        /// если объект с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели объект с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool CompareAndAdd(T addedObject);
        #endregion

        #region bool Contains(T coreObject);

        /// <summary>
        /// проверяет наличие объекта в списке
        /// </summary>
        /// <param name="coreObject"></param>
        bool Contains(T coreObject);
        #endregion

        #region int IndexOf(T item);

        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        /// <param name="item"></param>
        int IndexOf(T item);
        #endregion

        #region new T[] ToArray()

        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        new T[] ToArray();
        #endregion

        #region new T[] GetValidEntries();

        /// <summary>
        /// Возвращает массив действительных записей (где IsDeleted = false)
        /// </summary>
        /// <returns></returns>
        new T[] GetValidEntries();

        #endregion

        #region void Remove(T removedObject)

        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void Remove(T removedObject);

        #endregion
    }
}
