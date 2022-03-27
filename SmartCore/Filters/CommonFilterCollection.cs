using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Filters
{
    ///<summary>
    /// Класс для выборки директив из коллекции директив
    ///</summary>
    public class CommonFilterCollection: IEnumerable<ICommonFilter>
    {

        #region Fields
        /// <summary>
        /// Исходная коллекция директив
        /// </summary>
        private BaseEntityObject[] _initialCollection;
        /// <summary>
        /// Список фильтров выборки
        /// </summary>
        private List<ICommonFilter> Items = new List<ICommonFilter>();
        /// <summary>
        /// Тип для фильтрации
        /// </summary>
        private Type _filteredType;

        #endregion

        #region Constructors

        #region public CommonFilterCollection(Type filteredType)

        ///<summary>
        /// Создается объект для выборки элементов
        ///</summary>
        ///<param name="filteredType">Тип для фильтрации</param>
        public CommonFilterCollection(Type filteredType)
        {
            _initialCollection = new BaseEntityObject[0];
            _filteredType = filteredType;
            FilterTypeAnd = true;

            if (_filteredType == null) 
                return;
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                _filteredType.GetProperties().Where(p => p.GetCustomAttributes(typeof(FilterAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                FilterAttribute lvda = (FilterAttribute)
                    propertyInfo.GetCustomAttributes(typeof(FilterAttribute), false).First();
                if (lvda.Order > 0) orderedProperties.Add(lvda.Order, propertyInfo);
                else unOrderedProperties.Add(propertyInfo);
            }

            var ordered = orderedProperties.OrderBy(p => p.Key).ToList();

            properties.Clear();
            properties.AddRange(ordered.Select(keyValuePair => keyValuePair.Value));
            properties.AddRange(unOrderedProperties);

            foreach (PropertyInfo property in properties)
            {
                Type propertyType = property.PropertyType;

                #region фильтр для IEmunerable

                if (propertyType.Name.ToLower() != "string" && 
                    propertyType.GetInterface(typeof(IEnumerable<>).Name) != null)
                {
                    //Если свойство не string (string реализует интерфейс IEnumerable<>)
                    //и реализует интерфейс IEnumerable<> то
                    //производится поиск параметра универсального типа
                    Type t = propertyType;

                    while (t != null)
                    {
                        if (t.IsGenericType)
                        {
                            propertyType = t.GetGenericArguments().FirstOrDefault();
                            break;
                        }
                        t = t.BaseType;
                    }
                }
                #endregion

                if(propertyType == null)
                    continue;

                #region фильтр для StaticDictionary

                if (propertyType.IsSubclassOf(typeof(StaticDictionary)) ||
                    propertyType.IsSubclassOf(typeof(AbstractDictionary)))
                {
                    Type genericType = typeof(CommonFilter<>);
                    Type genericList = genericType.MakeGenericType(propertyType);

                    ICommonFilter commonFilter = (ICommonFilter)Activator.CreateInstance(genericList,new object[]{property, FilterType.Equal, null});

                    Items.Add(commonFilter);
                }
                #endregion

                #region фильтр для Lifelength

                else if (propertyType.Name == typeof(Lifelength).Name)
                {
                    Items.Add(new CommonFilter<Lifelength>(property, FilterType.Equal, new Lifelength[0]));
                }
                #endregion

                #region фильтр для BaseEntityObject

                else if (propertyType.GetInterface(typeof(IBaseEntityObject).Name) != null)
                {
                    Type genericType = typeof(CommonFilter<>);
                    Type genericList = genericType.MakeGenericType(propertyType);

                    ICommonFilter commonFilter = (ICommonFilter)Activator.CreateInstance(genericList, new object[] { property, FilterType.Equal, null });

                    Items.Add(commonFilter);
                }

                #endregion

                #region фильтр для ENUM

                else if (propertyType.IsEnum)
                {
                    Type genericType = typeof(CommonFilter<>);
                    Type genericList = genericType.MakeGenericType(propertyType);

                    ICommonFilter commonFilter = (ICommonFilter)Activator.CreateInstance(genericList, new object[] { property, FilterType.Equal, null });

                    Items.Add(commonFilter);
                }

                #endregion

                #region фильтр для базовых типов

                string typeName = propertyType.Name.ToLower();
                switch (typeName)
                {
                    case "bool":
                    case "boolean":
                        {
                            Items.Add(new CommonFilter<bool>(property, FilterType.Equal, new bool[0]));
                        }
                        break;
					case "int32":
					case "int":
                        {
                            Items.Add(new CommonFilter<int>(property, FilterType.Equal, new int[0]));
                        }
                        break;
                    case "string":
                        {
                            Items.Add(new CommonFilter<string>(property, FilterType.Equal, new string[0]));
                        }
                        break;
                    case "datetime":
                        {
                            Items.Add(new CommonFilter<DateTime>(property, FilterType.Between, new DateTime[0]));
                        }
                        break;
                }
                #endregion
            }
        }

        #endregion

        #region public CommonFilterCollection(IEnumerable<ICommonFilter> filters, bool filterTypeAnd = true)
        /// <summary>
        ///  Создается объект для выборки элементов
        /// </summary>
        /// <param name="filters">Применяемые для выборки фильтры</param>
        /// <param name="filterTypeAnd">Задает значение использования фильтров
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр</param>
        public CommonFilterCollection(IEnumerable<ICommonFilter> filters, bool filterTypeAnd = true)
        {
            Items.AddRange(filters);
            FilterTypeAnd = filterTypeAnd;
        }

        #endregion

        #region public CommonFilterCollection(Type filteredType, IEnumerable<ICommonFilter> filters) : this(new BaseEntityObject[0], filteredType, filters)

        ///<summary>
        /// Создается объект для выборки элементов
        ///</summary>
        ///<param name="filteredType">Тип для фильтрации</param>
        ///<param name="filters">Применяемые для выборки фильтры</param>
        public CommonFilterCollection(Type filteredType, IEnumerable<ICommonFilter> filters)
            : this(new BaseEntityObject[0], filteredType, filters)
        {
        }

        #endregion

        #region public CommonFilterCollection(BaseEntityObject[] initialCollection, Type filteredType, IEnumerable<ICommonFilter> filters)

        ///<summary>
        /// Создается объект для выборки директив
        ///</summary>
        ///<param name="initialCollection">Исходная коллекция директив</param>
        ///<param name="filteredType">Тип для фильтрации</param>
        ///<param name="filters">Применяемые для выборки фильтры</param>
        public CommonFilterCollection(BaseEntityObject[] initialCollection, Type filteredType, IEnumerable<ICommonFilter> filters)
        {
            _initialCollection = initialCollection;
            _filteredType = filteredType;
            
            Items.AddRange(filters);
        }

        #endregion

        #endregion

        #region Properties

        #region public ICommonFilter this[Int32 indexCollection]

        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        public ICommonFilter this[Int32 indexCollection]
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

        #region public BaseEntityObject InitialCollection
        /// <summary>
        /// Исходная коллекция директив
        /// </summary>
        public BaseEntityObject[] InitialCollection
        {
            get { return _initialCollection; }
            set { _initialCollection = value; }
        }
        #endregion

        #region public bool FilterTypeAnd { get; set; }
        /// <summary>
        /// Возвращает или задает значение исрльзования фильтраов
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр
        /// </summary>
        public bool FilterTypeAnd { get; set; }
        #endregion

        #region public Type FilteredType { get; }
        /// <summary>
        /// Возвращает значение типа для фильтрации
        /// </summary>
        public Type FilteredType { get { return _filteredType; } }
        #endregion

        #region public int Count
        /// <summary>
        /// Возвращает количество фильтров в коллекции
        /// </summary>
        public int Count { get { return Items.Count; } }
        #endregion

        #region public bool IsEmpty
        /// <summary>
        /// Возвращает значение, является ли фильтр пустым. Т.е. для всех фильтров в колллекции не щаданы значения фильтрации
        /// </summary>
        public bool IsEmpty
        {
            get { return Items.Count(i => i.Values.Length > 0) == 0; }
        }
        #endregion

        #region public List<ICommonFilter> Filters
        /// <summary>
        /// Возвращает все фильтры в коллекции
        /// </summary>
        public List<ICommonFilter> Filters
        {
            get { return Items; }
        }
        #endregion

        #endregion

        #region Methods

        #region public BaseEntityObject[] GatherDirectives()

        ///<summary>
        /// Производится выборка директив
        ///</summary>
        ///<returns>Выбранные директивы</returns>
        public BaseEntityObject[] GatherDirectives()
        {
            List<BaseEntityObject> directives = new List<BaseEntityObject>();
            for (int i = 0; i < _initialCollection.Length; i++)
            {
                if (Acceptable(_initialCollection[i])) directives.Add(_initialCollection[i]);
            }
            return directives.ToArray();
        }

        #endregion

        #region public Acceptable(BaseEntityObject item)
        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        public bool Acceptable(BaseEntityObject item)
        {
            bool acceptable = true;
            for (int j = 0; j < Items.Count; j++)
            {
                if (!Items[j].Acceptable(item))
                {
                    acceptable = false;
                    break;
                }
            }
            return acceptable;
        }
        #endregion

        #region public override bool Equals(object obj)
        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (!(obj is CommonFilterCollection)) return false;
            CommonFilterCollection collectionFilter = (CommonFilterCollection)obj;
            if (Items.Count != collectionFilter.Items.Count)
                return false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (!(Items[i].Equals(collectionFilter.Items[i])))
                    return false;
            }
            return true;
        }

        #endregion
       
        #region public override int GetHashCode()
        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return Items.Where(filter => filter.GetValidValuesCount() > 0).Aggregate("", (current, filter) => current + (filter + "    "));
        }
        #endregion

        #region public string ToStrings()
        public string ToStrings()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ICommonFilter filter in Items.Where(filter => filter.GetValidValuesCount() > 0))
            {
                stringBuilder.AppendLine(filter.ToString());
            }

            return stringBuilder.ToString();
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
        public IEnumerator<ICommonFilter> GetEnumerator()
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
    }
}