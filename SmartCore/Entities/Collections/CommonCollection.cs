using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.Collections
{
    /// <summary>
    /// Базовая коллекция для работы с объектами сохранения системы CAS
    /// </summary>
    [Serializable]
    public class CommonCollection<T> : ICommonCollection<T> where T : class, IBaseEntityObject 
    {

        #region public CommonCollection()
        /// <summary>
        /// Создает пустую коллекцию
        /// </summary>
        public CommonCollection()
        {
        }
        #endregion

        #region public CommonCollection(IEnumerable<T> items)
        /// <summary>
        /// Создает коллекцию на основе передаваемого массива 
        /// </summary>
        /// <param name="items"></param>
        public CommonCollection(IEnumerable<T> items)
        {
            Items.Clear();
			if(items != null)
				AddRange(items);
        }
        #endregion

        #region Члены ICommonCollection<T>

        #region public virtual T GetItemById(Int32 id)
        /// <summary>
        /// Возвращает объект заданному ItemID или null
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        public virtual T GetItemById(Int32 id)
        {
            return Items.FirstOrDefault(item => item.ItemId == id);
        }
        #endregion

        #region public T this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        public T this[Int32 indexCollection]
        {
            get
            {
                try
                {
                    return Items[indexCollection];
                }
                catch
                {
                    //return default(T);
                    //применять если не задано ограничение класс/структура для объектов, реализующих интерфейс IBaseEntityObject
                    return null;
                }
            }
        }

        #endregion

        #region public void Add(T addedObject)
        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        public void Add(T addedObject)
        {
            if(addedObject == null)
                throw new ArgumentNullException("addedObject","must be not null");
            if(addedObject.ItemId > 0)
            {
                //if (GetItemById(addedObject.ItemId) != null) return;
                if (Items.Any(i=>i.ItemId == addedObject.ItemId))
                {
                    addedObject.ToString();//TODO:(Evgenii Babak) проверить этот код
                    //return;
                }
                Items.Add(addedObject);
                Items.Sort();
            }
            else Items.Add(addedObject);

            addedObject.PropertyChanged += OnItemPropertyChanged;
           
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, addedObject));
        }
        #endregion

        #region public void AddRange(IEnumerable<T> objects)

        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        public void AddRange(IEnumerable<T> objects, bool ignoreSort = false)
        {
            Items.AddRange(objects);
			if(!ignoreSort)
				Items.Sort();

            foreach (T o in objects)
                o.PropertyChanged += OnItemPropertyChanged;

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, objects.ToList()));
        }
        #endregion

        #region public void AddRange(ICommonCollection objects)
        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        public void AddRange(ICommonCollection objects)
        {
            foreach (T o in objects)
            {
                o.PropertyChanged += OnItemPropertyChanged;
                Items.Add(o);
            }
            Items.Sort();

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, 
                                                                     objects.OfType<IBaseEntityObject>().ToList()));
        }
        #endregion

        #region public bool CompareAndAdd(T addedObject)
        /// <summary>
        /// Сравнивает объекты имеющиеся в коллекции с добавляемым объектом по их ID
        /// если объект с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели объект с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        public bool CompareAndAdd(T addedObject)
        {
            if (Items.Any(@object => @object.ItemId == addedObject.ItemId))
            {
                return false;
            }
            Items.Add(addedObject);
            Items.Sort();
            
            addedObject.PropertyChanged += OnItemPropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, addedObject));
            
            return true;
        }
        #endregion

        #region public bool Contains(T coreObject)
        /// <summary>
        /// проверяет наличие объекта в списке
        /// </summary>
        /// <param name="coreObject"></param>
        public bool Contains(T coreObject)
        {
            if (coreObject == null)
                throw new ArgumentNullException("coreObject", "must be not null");
            return Items.Contains(coreObject);
        }
        #endregion

        #region public int IndexOf(T item)
        /// <summary>
        ///Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        /// <param name="item"></param>
        public int IndexOf(T item)
        {
            return Items.IndexOf(item);
        }
        #endregion

        #region public T[] ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return Items.ToArray();
        }
        #endregion

        #region public T[] GetValidEntries()
        /// <summary>
        /// Возвращает массив действительных записей (где IsDeleted = false)
        /// </summary>
        /// <returns></returns>
        public T[] GetValidEntries()
        {
            return Items.Where(item => !item.IsDeleted).ToArray();
        }
        #endregion

        #region public void Remove(T removedObject)
        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        public void Remove(T removedObject)
        {
            T item = Contains(removedObject) ? removedObject : GetItemById(removedObject.ItemId);

            if (item == null) return;

            Items.Remove(item);
            item.PropertyChanged -= OnItemPropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedObject));
        }

        #endregion

        #endregion

        #region Члены ICommonCollection

        #region public int Count { get; }
        /// <summary>
        /// Возвращает количество полетов в коллекции
        /// </summary>
        public int Count { get { return Items.Count; } }

        #endregion

        #region public void Clear()
        /// <summary>
        /// очистка всех элементов коллекции
        /// </summary>
        public void Clear()
        {
            foreach (T item in Items)
                item.PropertyChanged -= OnItemPropertyChanged;
            Items.Clear();
        }
        #endregion

        #region IBaseEntityObject ICommonCollection.GetItemById(int id)
        /// <summary>
        /// Возвращает объект заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        IBaseEntityObject ICommonCollection.GetItemById(int id)
        {
            return GetItemById(id);
        }
        #endregion

        #region IBaseEntityObject ICommonCollection.this[int indexCollection]
        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        IBaseEntityObject ICommonCollection.this[int indexCollection]
        {
            get { return this[indexCollection]; }
        }
        #endregion

        #region void ICommonCollection.Add(IBaseEntityObject addedObject)
        /// <summary>
        /// Добавляет объект в коллекцию
        /// </summary>
        /// <param name="addedObject"></param>
        void ICommonCollection.Add(IBaseEntityObject addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                Add(addedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region void ICommonCollection.AddRange(IEnumerable<IBaseEntityObject> objects)
        /// <summary>
        /// Добавляет массив агрегатов в коллекцию
        /// </summary>
        /// <param name="objects"></param>
        void ICommonCollection.AddRange(IEnumerable<IBaseEntityObject> objects)
        {
            if (objects == null)
                throw new ArgumentNullException("objects", "must be not null");
            if (objects is IEnumerable<T>)
                AddRange(objects as IEnumerable<T>);
            else
            {
                foreach (IBaseEntityObject o in objects)
                {
                    if (o is T)
                        Add(o as T);
                    else
                    {
                        throw new ArgumentException("must be of type:" + typeof(T), "objects");
                    }
                }    
            }
        }
        #endregion

        #region bool ICommonCollection.CompareAndAdd(IBaseEntityObject addedObject)
        /// <summary>
        /// Сравнивает детали имебщиеся в коллекции с добавляемой по их ID
        /// если деталь с подобным ID в коллекции не существует, 
        /// то она добавляется в коллекцию и возвращается true
        /// ежели деталь с подобным ID в коллекции есть
        /// то она НЕ добавляется в коллекцию и возвращается false
        /// </summary>
        /// <param name="addedObject"></param>
        bool ICommonCollection.CompareAndAdd(IBaseEntityObject addedObject)
        {
            if (addedObject == null)
                throw new ArgumentNullException("addedObject", "must be not null");
            if (addedObject is T)
                return CompareAndAdd(addedObject as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "addedObject");
        }
        #endregion

        #region  bool ICommonCollection.Contains(IBaseEntityObject coreObject)
        /// <summary>
        /// проверяет наличие объекта в списке объект
        /// </summary>
        /// <param name="coreObject"></param>
        bool ICommonCollection.Contains(IBaseEntityObject coreObject)
        {
            if (coreObject == null)
                throw new ArgumentNullException("coreObject", "must be not null");
            if (coreObject is T)
                return Contains(coreObject as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "coreObject");
        }
        #endregion

        #region public bool ContainsById(int itemId)
        /// <summary>
        /// проверяет наличие объекта с заданным ID в списке объектов 
        /// </summary>
        /// <param name="itemId"></param>
        public bool ContainsById(int itemId)
        {
            return GetItemById(itemId) != null ? true : false;
        }
        #endregion

        #region int ICommonCollection.IndexOf(IBaseEntityObject item)
        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        /// <param name="item"></param>
        int ICommonCollection.IndexOf(IBaseEntityObject item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "must be not null");
            if (item is T)
                return IndexOf(item as T);
            throw new ArgumentException("must be not of type:" + typeof(T), "item");
        }
        #endregion

        #region IBaseEntityObject[] ICommonCollection.ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        IBaseEntityObject[] ICommonCollection.ToArray()
        {
            return ToArray();
        }
        #endregion

        #region IBaseEntityObject[] ICommonCollection.GetValidEntries()
        /// <summary>
        ///Возвращает массив действительных записей (где IsDeleted = false)
        /// </summary>
        /// <returns></returns>
        IBaseEntityObject[] ICommonCollection.GetValidEntries()
        {
            return GetValidEntries();
        }
        #endregion

        #region void ICommonCollection.Remove(IBaseEntityObject removedObject)
        /// <summary>
        /// Удаляет объект из списка 
        /// </summary>
        /// <param name="removedObject"></param>
        void ICommonCollection.Remove(IBaseEntityObject removedObject)
        {
            if (removedObject == null)return;
            if (removedObject is T)Remove(removedObject as T);
            else throw new ArgumentException("must be not of type:" + typeof(T), "removedObject");
        }
        #endregion

        #region public void RemoveById(int itemId)
        /// <summary>
        /// удаляет объект с заданным ID из списка объектов 
        /// </summary>
        /// <param name="itemId"></param>
        public void RemoveById(int itemId)
        {
            T item = GetItemById(itemId);

            if (item == null) return;
            
            Items.Remove(item);
            item.PropertyChanged -= OnItemPropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
        }
        #endregion

        #endregion

        #region Члены IEnumerable<T>
        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region Члены IEnumerable
        /// <summary>
        /// Возвращает перечислитель, который осуществляет перебор элементов коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region Члены INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged;

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

        #region private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, args);
            }
        }
        #endregion

        #region private void OnItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        private void OnItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCollectionChanged(null);
        }
        #endregion
        
        /*
         * Реализация
         */

        #region protected List<T> Items = new List<T>();
        /// <summary>
        /// Содержит список объектов
        /// </summary>
        protected List<T> Items = new List<T>();
        #endregion
    }
}
