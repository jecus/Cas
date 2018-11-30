using System;
using System.Collections.Generic;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{
    public interface IRecordCollection :ICommonCollection// IEnumerable, INotifyCollectionChanged
    {
        #region new AbstractRecord GetItemById(Int32 id);
        /// <summary>
        /// Возвращает объект заданному ItemID или создает новый объект по умолчанию
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        new AbstractRecord GetItemById(Int32 id);
        #endregion

        #region new AbstractRecord this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        new AbstractRecord this[Int32 indexCollection] { get; }

        #endregion

        #region void Add(AbstractRecord addedObject)

        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void Add(AbstractRecord addedObject);
        #endregion

        #region void AddRange(IEnumerable<AbstractRecord> objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void AddRange(IEnumerable<AbstractRecord> objects);
        #endregion

        #region bool CompareAndAdd(AbstractRecord addedObject)

        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool CompareAndAdd(AbstractRecord addedObject);
        #endregion

        #region new AbstractRecord[] ToArray();

        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        new AbstractRecord[] ToArray();
        #endregion

        #region void Remove(AbstractRecord removedObject)

        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void Remove(AbstractRecord removedObject);

        #endregion

        #region AbstractRecord this[DateTime date] { get; }

        /// <summary>
        /// Возвращает запись по указанной дате, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord this[DateTime date] { get; }
        #endregion

        #region AbstractRecord[] GetRecords(DateTime dateFrom, DateTime dateTo)

        /// <summary>
        /// Возвращает список записей за указанный период. При этом самым первым будет запись, которая предшествует дате dateFrom
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        AbstractRecord[] GetRecords(DateTime dateFrom, DateTime dateTo);
        #endregion

        #region AbstractRecord[] GetRecords(DateTime toDate)

        /// <summary>
        /// Возвращает записи до указанной даты
        /// </summary>
        /// <param name="toDate"></param>
        /// <returns></returns>
        AbstractRecord[] GetRecords(DateTime toDate);
        #endregion

        #region AbstractRecord GetFirst();

        /// <summary>
        /// Возвращает первую запись
        /// </summary>
        AbstractRecord GetFirst();
        #endregion

        #region AbstractRecord GetLast();

        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        AbstractRecord GetLast();
        #endregion

        #region AbstractRecord GetPreviousKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой строго меньше указанной даты.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord GetPreviousKnownRecord(DateTime date);

        #endregion

        #region AbstractRecord GetLastKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord GetLastKnownRecord(DateTime date);

        #endregion

        #region AbstractRecord GetFirstKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой больше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord GetFirstKnownRecord(DateTime date);

        #endregion

        #region int IndexOf(AbstractRecord item);
        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        int IndexOf(AbstractRecord item);
        #endregion
    }
}
