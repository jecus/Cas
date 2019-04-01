using System;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{
    public interface IRecordCollection<T> : IRecordCollection where T : AbstractRecord
    {

        #region new T this[DateTime date] { get; }

        /// <summary>
        /// Возвращает запись по указанной дате, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        new T this[DateTime date] { get; }
        #endregion

        #region new T this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        new T this[Int32 indexCollection] { get; }

        #endregion

        #region new T[] GetRecords(DateTime dateFrom, DateTime dateTo)

        /// <summary>
        /// Возвращает список записей за указанный период. При этом самым первым будет запись, которая предшествует дате dateFrom
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        new T[] GetRecords(DateTime dateFrom, DateTime dateTo);
        #endregion

        #region new T[] GetRecords(DateTime toDate)

        /// <summary>
        /// Возвращает записи до указанной даты
        /// </summary>
        /// <param name="toDate"></param>
        /// <returns></returns>
        new T[] GetRecords(DateTime toDate);
        #endregion

        #region new T GetFirst();

        /// <summary>
        /// Возвращает первую запись
        /// </summary>
        new T GetFirst();
        #endregion

        #region new T GetLast();

        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        new T GetLast();
        #endregion

        #region new T GetPreviousKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой строго меньше указанной даты.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        new T GetPreviousKnownRecord(DateTime date);

        #endregion

        #region new T GetLastKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        new T GetLastKnownRecord(DateTime date);
        #endregion

        #region new T GetFirstKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой больше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        new T GetFirstKnownRecord(DateTime date);

        #endregion
    }
}
