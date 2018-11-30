using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{
    /// <summary>
    /// Базовая коллекция работающая с записями о выполнении
    /// </summary>
    [Serializable]
    public class BaseRecordCollection<T> : CommonCollection<T>,IRecordCollection<T> where T : AbstractRecord
    {

        /*
         * Реализация
         */

        #region public BaseRecordCollection()
        /// <summary>
        /// Создает коллекцию записей о переносе на основе передаваемого массива 
        /// </summary>
        public BaseRecordCollection()
        {
        }
        #endregion

        #region public BaseRecordCollection(IEnumerable<T> records)
        /// <summary>
        /// Создает коллекцию записей о переносе на основе передаваемого массива 
        /// </summary>
        /// <param name="records"></param>
        public BaseRecordCollection(IEnumerable<T> records) : base(records)
        {
        }
        #endregion

        #region Члены IRecordCollection<T>

        #region public T this[DateTime date] { get; }
        /// <summary>
        /// Возвращает запись по указанной дате, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public T this[DateTime date]
        {
            get
            {
                return Items.FirstOrDefault(t => t.RecordDate.Date == date.Date);
            }
        }
        #endregion

        #region public T[] GetRecords(DateTime dateFrom, DateTime dateTo)
        /// <summary>
        /// Возвращает список записей за указанный период. При этом самым первым будет запись, которая предшествует дате dateFrom
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public T[] GetRecords(DateTime dateFrom, DateTime dateTo)
        {
            dateFrom = dateFrom.Date;
            dateTo = dateTo.Date;
            List<T> res = new List<T>();

            // Если все записи сделаны раньше dateFrom
            if (Items[Items.Count - 1].RecordDate.Date <= dateFrom)
            {
                // В этом случае возвращаем только одну запись
                res.Add(Items[Items.Count - 1]);
                return res.ToArray();
            }

            return Items.Where(i => i.RecordDate.Date >= dateFrom && i.RecordDate.Date <= dateTo).ToArray();
        }
        #endregion

        #region public T[] GetRecords(DateTime toDate)
        /// <summary>
        /// Возвращает записи до указанной даты
        /// </summary>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public T[] GetRecords(DateTime toDate)
        {
            //
            List<T> res;
            toDate = toDate.Date;

            // Если последняя запись о перемещении входит в запрошенный диапазон возвращаем все перемещения
            if (Items.Count > 0 && Items[Items.Count - 1].RecordDate.Date <= toDate)
            {
                return Items.ToArray();
            }

            // Находим последнее перемещение удовлетворяющее запрошенному интервалу
            for (int i = Items.Count - 1; i >= 0; i--)
                if (Items[i].RecordDate.Date <= toDate)
                {
                    res = new List<T>();
                    for (int j = 0; j <= i; j++)
                        res.Add(Items[j]);
                    return res.ToArray();
                }

            //
            return null;
        }
        #endregion

        #region public T GetFirst()
        /// <summary>
        /// Возвращает первую запись
        /// </summary>
        public T GetFirst()
        {
            if (Items.Count == 0) return null;
            return Items.OrderBy(r => r.RecordDate).First();
        }
        #endregion

        #region public T GetLast()
        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        public T GetLast()
        {
            return Items.Count == 0 ? null : Items.OrderBy(r=>r.RecordDate).Last();
        }

        #endregion

        #region public T GetPreviousKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой строго меньше указанной даты.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public T GetPreviousKnownRecord(DateTime date)
        {
            T preceding = null;
            foreach (T t in Items)
            {
                if (t.RecordDate >= date) return preceding;
                if (preceding == null || preceding.RecordDate < t.RecordDate)
                    preceding = t; // выбираем самую близкую
            }
            // возвращаем самую близкую дату
            return preceding;
        }

        #endregion

        #region public T GetLastKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public T GetLastKnownRecord(DateTime date)
        {
            date = date.Date;
            T preceding = null;
            foreach (T t in Items)
            {
                if (t.RecordDate.Date == date) return t;
                if (t.RecordDate.Date > date) return preceding;
                if (preceding == null || preceding.RecordDate.Date < t.RecordDate)
                    preceding = t; // выбираем самую близкую
            }
            // возвращаем самую близкую дату
            return preceding;
        }

        #endregion

        #region public T GetFirstKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой больше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public T GetFirstKnownRecord(DateTime date)
        {
            date = date.Date;

            return Items.OrderBy(r=>r.RecordDate).FirstOrDefault(i => i.RecordDate >= date);
            //T preceding = null;
            //foreach (T t in Items)
            //{
            //    if (t.RecordDate.Date == date) return t;
            //    if (t.RecordDate.Date > date) return preceding;
            //    if (preceding == null || preceding.RecordDate.Date < t.RecordDate)
            //        preceding = t; // выбираем самую близкую
            //}
            //// возвращаем самую близкую дату
            //return preceding;
        }

        #endregion

        #endregion

        #region Члены IRecordCollection

        #region AbstractRecord IRecordCollection.GetItemById(int id)
        /// <summary>
        /// Возвращает объект заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.GetItemById(int id)
        {
            return GetItemById(id);
        }
        #endregion

        #region AbstractRecord IRecordCollection.this[int indexCollection]
        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.this[int indexCollection]
        {
            get { return this[indexCollection]; }
        }
        #endregion

        #region void IRecordCollection.Add(AbstractRecord addedObject)
        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void IRecordCollection.Add(AbstractRecord addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                Add(addedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region void IRecordCollection.AddRange(IEnumerable<AbstractRecord> objects)
        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void IRecordCollection.AddRange(IEnumerable<AbstractRecord> objects)
        {
            if (objects == null)
                throw new ArgumentNullException("objects", "must be not null");
            if (objects is IEnumerable<T>)
                AddRange(objects as IEnumerable<T>);
            else throw new ArgumentException("must be not of type:" + typeof(IEnumerable<T>), "objects");
        }
        #endregion

        #region bool IRecordCollection.CompareAndAdd(AbstractRecord addedObject)
        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool IRecordCollection.CompareAndAdd(AbstractRecord addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                return CompareAndAdd(addedObject as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region AbstractRecord[] IRecordCollection.ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        AbstractRecord[] IRecordCollection.ToArray()
        {
            return ToArray();
        }
        #endregion

        #region void IRecordCollection.Remove(AbstractRecord removedObject)
        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void IRecordCollection.Remove(AbstractRecord removedObject)
        {
            if (removedObject == null) return;
            if (removedObject is T) Remove(removedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "removedObject");
        }
        #endregion

        #region AbstractRecord IRecordCollection.this[DateTime date] { get; }
        /// <summary>
        /// Возвращает запись по указанной дате, либо null если запись  не была найдена в коллекции
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.this[DateTime date]
        {
            get { return this[date]; }
        }
        #endregion

        #region AbstractRecord[] IRecordCollection.GetRecords(DateTime dateFrom, DateTime dateTo)
        /// <summary>
        /// Возвращает список записей за указанный период. При этом самым первым будет запись, которая предшествует дате dateFrom
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        AbstractRecord[] IRecordCollection.GetRecords(DateTime dateFrom, DateTime dateTo)
        {
            return GetRecords(dateFrom, dateTo);
        }
        #endregion

        #region AbstractRecord[] IRecordCollection.GetRecords(DateTime toDate)
        /// <summary>
        /// Возвращает записи до указанной даты
        /// </summary>
        /// <param name="toDate"></param>
        /// <returns></returns>
        AbstractRecord[] IRecordCollection.GetRecords(DateTime toDate)
        {
            return GetRecords(toDate);
        }
        #endregion

        #region AbstractRecord IRecordCollection.GetFirst()
        /// <summary>
        /// Возвращает первую запись
        /// </summary>
        AbstractRecord IRecordCollection.GetFirst()
        {
            return GetFirst();
        }
        #endregion

        #region AbstractRecord IRecordCollection.GetLast()
        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        AbstractRecord IRecordCollection.GetLast()
        {
            return GetLast();
        }
        #endregion

        #region AbstractRecord IRecordCollection.GetPreviousKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой строго меньше указанной даты.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.GetPreviousKnownRecord(DateTime date)
        {
            return GetPreviousKnownRecord(date);
        }

        #endregion

        #region AbstractRecord IRecordCollection.GetLastKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой меньше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.GetLastKnownRecord(DateTime date)
        {
            return GetLastKnownRecord(date);
        }
        #endregion

        #region AbstractRecord IRecordCollection.GetFirstKnownRecord(DateTime date)

        /// <summary>
        /// Возвращает самую близкую к указанной дате запись, дата которой больше либо равна указанной дате.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        AbstractRecord IRecordCollection.GetFirstKnownRecord(DateTime date)
        {
            return GetFirstKnownRecord(date);
        }
        #endregion

        #region int IRecordCollection.IndexOf(AbstractRecord item)
        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        /// <param name="item">Искомый объект</param>
        /// <returns></returns>
        int IRecordCollection.IndexOf(AbstractRecord item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "must be not null");
            if (item is T)
                return IndexOf(item as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "item");
        }
        #endregion

        #endregion
    }
}
