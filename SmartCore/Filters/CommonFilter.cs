using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using TextProcessing;

namespace SmartCore.Filters
{
    #region public enum FilterType
    /// <summary>
    /// Описывает тип фильтрации
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// Находится в определенном множестве
        /// </summary>
        [Description("In")]
        In = 1,
        /// <summary>
        /// Меньше 
        /// </summary>
        [Description("<")]
        Less = 10,
        /// <summary>
        /// Меньше или равно
        /// </summary>
        [Description("<=")]
        LessOrEqual = 11,
        /// <summary>
        /// Эквивалентно (равно)
        /// </summary>
        [Description("=")]
        Equal = 12,
        /// <summary>
        /// Больше или равно
        /// </summary>
        [Description(">=")]
        GratherOrEqual = 13,
        /// <summary>
        /// Больше
        /// </summary>
        [Description(">")]
        Grather = 14,
        /// <summary>
        /// Не эквивалентно (не равно)
        /// </summary>
        [Description("!=")]
        NotEqual = 15,
        /// <summary>
        /// Между 2-мя значениями
        /// </summary>
        [Description("between")]
        Between = 20,
    }
    #endregion

    #region public interface CommonFilter
    /// <summary>
    /// описывает фильтр для запроса по определенному своиству и диапозону значений
    /// </summary>
    public interface ICommonFilter
    {
        PropertyInfo FilterProperty { get; }

        FilterType FilterType { get; }

        object [] Values { get; }

        object [] AllValues { get; }

        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        bool Acceptable(BaseEntityObject item);
        /// <summary>
        /// Возвращает кол-во действительных (not null) значений фильтра
        /// </summary>
        /// <returns>кол-во действительных элементов фильтра</returns>
        int GetValidValuesCount();

        #region void ClearFilter();

        /// <summary>
        /// Производит очистку фильтра
        /// </summary>
        void ClearFilter();

        #endregion

        //#region public void SetParameters(FilterType filterType, IEnumerable<object>  selectedValues)

        ///// <summary>
        ///// Задает параметр типа фильтрации и массива значений фильтра
        ///// </summary>
        ///// <param name="filterType"></param>
        ///// <param name="selectedValues"></param>
        //void SetParameters(FilterType filterType, IEnumerable<object> selectedValues);

        //#endregion

        #region void SetParameters(FilterType filterType, IEnumerable<object> selectedValues, IEnumerable<object> allValues);

        /// <summary>
        /// Задает параметры типа фильтрации, массив значений фильтра и массив всех возможных значений фильтруемого поля
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="selectedValues">Выбранные значения фильтра</param>
        /// <param name="allValues">Все возможные значения параметра фильтрации</param>
        void SetParameters(FilterType filterType, IEnumerable<object> selectedValues, IEnumerable<object> allValues = null);

		#endregion

	    void SetParameters(IEnumerable<object> values);

    }
    #endregion

    #region public interface ICommonFilter<out T> : ICommonFilter
    /// <summary>
    /// описывает фильтр для запроса по определенному своиству и диапозону значений
    /// </summary>
    public interface ICommonFilter<out T> : ICommonFilter 
    {
        new T[] Values { get; }

        new T[] AllValues { get; }
    }
    #endregion

    #region public class CommonFilter<T> : CommonFilter
    /// <summary>
    /// описывает фильтр для запроса по определенному своиству и диапозону значений
    /// </summary>
    public class CommonFilter<T> : ICommonFilter<T>, IEnumerable<T>
    {
        public PropertyInfo FilterProperty { get; private set; }

        public FilterType FilterType { get; private set; }

        public T[] Values { get; private set; }

        public T[] AllValues { get; private set; }

        object[] ICommonFilter.Values { get { return Values != null ? Values.Cast<object>().ToArray() : null; } }

        object[] ICommonFilter.AllValues { get { return AllValues != null ? AllValues.Cast<object>().ToArray() : null; } }

        #region public CommonFilter(T value)
        /// <summary>
        /// Создает объект фильтра для запроса
        /// </summary>
        /// <param name="value">Значения парамета для фильтрации</param>
        public CommonFilter(T value)
        {
            FilterProperty = null;
            FilterType = FilterType.Equal;
            Values = new[] { value };
        }
        #endregion

        #region public CommonFilter(PropertyInfo filterProperty, FilterType filterType, T[] values)
        /// <summary>
        /// Создает объект фильтра для запроса
        /// </summary>
        /// <param name="filterProperty">Свойство, по которому необходимо произвести фильтрацию</param>
        /// <param name="filterType">Тип фильтрации своиства (In, between и т.д.).</param>
        /// <param name="values">Значения парамета для фильтрации</param>
        public CommonFilter(PropertyInfo filterProperty, FilterType filterType, T[] values)
        {
            FilterProperty = filterProperty;
            FilterType = filterType;
            Values = values ?? new T[0];
        }
        #endregion

        #region public CommonFilter(PropertyInfo filterProperty, T value)

        /// <summary>
        /// Создает объект фильтра для запроса
        /// </summary>
        /// <param name="filterProperty">Свойство, по которому необходимо произвести фильтрацию</param>
        /// <param name="value">Значение парамета для фильтрации, значение не должно быть null
        /// <br/> Для создания пустого фильтра нужно использовать конструктор</param>
        public CommonFilter(PropertyInfo filterProperty, T value) : this(filterProperty, FilterType.Equal, new[]{value})
        {
        }
        #endregion

        #region public bool Acceptable(BaseEntityObject item)
        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        public bool Acceptable(BaseEntityObject item)
        {
            if (item == null || FilterProperty == null || Values.Length == 0)
                return true;
            PropertyInfo typeProp;
            if ((typeProp = item.GetType().GetProperty(FilterProperty.Name)) == null ||
                !FilterProperty.PropertyType.Name.Equals(typeProp.PropertyType.Name))
                return true;

            if (FilterProperty.PropertyType.Name.ToLower() != "string" && 
                FilterProperty.PropertyType.GetInterface(typeof(IEnumerable<>).Name) != null)
            {
                //Если свойство не string (string реализует интерфейс IEnumerable<>)
                //и реализует интерфейс IEnumerable<> то
                //производится поиск параметра универсального типа
                Type t = FilterProperty.PropertyType;

                while (t != null)
                {
                    if (t.IsGenericType)
                    {
                        t = t.GetGenericArguments().FirstOrDefault();
                        break;
                    }
                    t = t.BaseType;
                }
                if(t == null)
                    return false;
                if(t.Name != typeof(T).Name)
                    return false;
            }
            else if (FilterProperty.PropertyType.Name != typeof(T).Name)
                return false;

            object propertyValue = FilterProperty.GetValue(item, null);
            if (propertyValue == null)
                return false;

            //Тип свойства реалтзует интерфейс IEnumerable
            if (FilterProperty.PropertyType.Name.ToLower() != "string" &&
                FilterProperty.PropertyType.GetInterface(typeof(IEnumerable<>).Name) != null)
            {
                IEnumerable<T> convertedPropertyValue = ((IEnumerable<T>) propertyValue).ToArray();
                if (!convertedPropertyValue.Any())
                    return false;
                switch (FilterType)
                {
                    case FilterType.Equal:
                        return convertedPropertyValue.Contains(Values[0]);
                    case FilterType.NotEqual:
                        return !convertedPropertyValue.Contains(Values[0]);
                    case FilterType.In:
                        return convertedPropertyValue.Any(cpv => Values.Contains(cpv));
                        //return Values.Any(v => convertedPropertyValue.Contains(v));
                    default:
                        return false;
                }       
            }
            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (FilterProperty.PropertyType.IsSubclassOf(typeof(AbstractDictionary)) ||
                FilterProperty.PropertyType.IsSubclassOf(typeof(StaticDictionary)))
            {
                switch (FilterType)
                {
                    case FilterType.Equal:
                        return propertyValue.Equals(Values[0]);
                    case FilterType.NotEqual:
                        return !propertyValue.Equals(Values[0]);
                    case FilterType.In:
                        return Values.Any(v => propertyValue.Equals(v));
                    default:
                        return false;
                }
            }
            if (FilterProperty.PropertyType.GetInterface(typeof(IBaseEntityObject).Name) != null )
            {
                switch (FilterType)
                {
                    case FilterType.Equal:
                        return propertyValue.Equals(Values[0]);
                    case FilterType.NotEqual:
                        return !propertyValue.Equals(Values[0]);
                    case FilterType.In:
                        return Values.Any(v => propertyValue.Equals(v));
                    default:
                        return false;
                }
            }
            if (FilterProperty.PropertyType.Name == typeof(Lifelength).Name)
            {
                Lifelength convertedPropertyValue = (Lifelength)propertyValue;
                Lifelength convertedFilterValue = Values[0] as Lifelength ?? Lifelength.Null;

                switch (FilterType)
                {
                    case FilterType.Less:
                        return convertedPropertyValue.IsLessIgnoreNulls(convertedFilterValue);
                    case FilterType.LessOrEqual:
                        return convertedPropertyValue.IsLessOrEqualByAnyParameter(convertedFilterValue);
                    case FilterType.Equal:
                        return convertedPropertyValue.Equals(convertedFilterValue);
                    case FilterType.GratherOrEqual:
                        return convertedPropertyValue.IsGreaterOrEqualByAllParameters(convertedFilterValue);
                    case FilterType.Grather:
                        return convertedPropertyValue.IsGratherIgnoreNulls(convertedFilterValue);
                    case FilterType.NotEqual:
                        return !convertedPropertyValue.Equals(convertedFilterValue);
                    case FilterType.In:
                        return Values.OfType<Lifelength>().Any(convertedPropertyValue.Equals);
                    default:
                        return false;
                }
            }
            if (FilterProperty.PropertyType.IsEnum)
            {
                switch (FilterType)
                {
                    case FilterType.Equal:
                        return Equals(propertyValue, Values[0]);
                    case FilterType.NotEqual:
                        return !Equals(propertyValue, Values[0]);
                    case FilterType.In:
                        {
                            return Values.Any(value => Equals(value, propertyValue));
                        }
                    default:
                        return false;
                }
            }

            string typeName = FilterProperty.PropertyType.Name.ToLower();
            switch (typeName)
            {
                case "bool":
                case "boolean":
                    {
                        bool convertedPropertyValue = Convert.ToBoolean(propertyValue);
                        bool convertedFilterValue = Convert.ToBoolean(Values[0]);
                        switch (FilterType)
                        {
                            case FilterType.Equal:
                                return convertedPropertyValue == convertedFilterValue;
                            case FilterType.NotEqual:
                                return convertedPropertyValue != convertedFilterValue;
                            case FilterType.In:
                                return Values.Any(v => convertedFilterValue == Convert.ToBoolean(v));
                            default:
                                return false;
                        }
                    }
                case "datetime":
                    {
                        DateTime convertedPropertyValue = Convert.ToDateTime(propertyValue);
                        DateTime convertedFilterValue = Convert.ToDateTime(Values[0]);
                        switch (FilterType)
                        {
                            case FilterType.Less:
                                return convertedPropertyValue < convertedFilterValue;
                            case FilterType.LessOrEqual:
                                return convertedPropertyValue <= convertedFilterValue;
                            case FilterType.Equal:
                                return convertedPropertyValue == convertedFilterValue;
                            case FilterType.GratherOrEqual:
                                return convertedPropertyValue >= convertedFilterValue;
                            case FilterType.Grather:
                                return convertedPropertyValue > convertedFilterValue;
                            case FilterType.NotEqual:
                                return convertedPropertyValue != convertedFilterValue;
                            case FilterType.In:
                                return Values.Any(v => convertedFilterValue == Convert.ToDateTime(v));
                            case FilterType.Between:
								return Convert.ToDateTime(Values[0]) <= convertedPropertyValue && convertedPropertyValue <= Convert.ToDateTime(Values[1]);
	                        default:
                                return false;
                        }
                    }
                case "double":
                    {
                        double convertedPropertyValue = Convert.ToDouble(propertyValue);
                        double convertedFilterValue = Convert.ToDouble(Values[0]);
                        switch (FilterType)
                        {
                            case FilterType.Less:
                                return convertedPropertyValue < convertedFilterValue;
                            case FilterType.LessOrEqual:
                                return convertedPropertyValue <= convertedFilterValue;
                            case FilterType.Equal:
                                return convertedPropertyValue == convertedFilterValue;
                            case FilterType.GratherOrEqual:
                                return convertedPropertyValue >= convertedFilterValue;
                            case FilterType.Grather:
                                return convertedPropertyValue > convertedFilterValue;
                            case FilterType.NotEqual:
                                return convertedPropertyValue != convertedFilterValue;
                            case FilterType.In:
                                return Values.Any(v => convertedFilterValue == Convert.ToDouble(v));
                            default:
                                return false;
                        }
                    }
                case "int16":
                    {
                        Int16 convertedPropertyValue = Convert.ToInt16(propertyValue);
                        Int16 convertedFilterValue = Convert.ToInt16(Values[0]);
                        switch (FilterType)
                        {
                            case FilterType.Less:
                                return convertedPropertyValue < convertedFilterValue;
                            case FilterType.LessOrEqual:
                                return convertedPropertyValue <= convertedFilterValue;
                            case FilterType.Equal:
                                return convertedPropertyValue == convertedFilterValue;
                            case FilterType.GratherOrEqual:
                                return convertedPropertyValue >= convertedFilterValue;
                            case FilterType.Grather:
                                return convertedPropertyValue > convertedFilterValue;
                            case FilterType.NotEqual:
                                return convertedPropertyValue != convertedFilterValue;
                            case FilterType.In:
                                return Values.Any(v => convertedFilterValue == Convert.ToInt16(v));
                            default:
                                return false;
                        }
                    }
                case "int32":
                    {
                        Int32 convertedPropertyValue = Convert.ToInt32(propertyValue);
                        Int32 convertedFilterValue = Convert.ToInt32(Values[0]);
                        switch (FilterType)
                        {
                            case FilterType.Less:
                                return convertedPropertyValue < convertedFilterValue;
                            case FilterType.LessOrEqual:
                                return convertedPropertyValue <= convertedFilterValue;
                            case FilterType.Equal:
                                return convertedPropertyValue == convertedFilterValue;
                            case FilterType.GratherOrEqual:
                                return convertedPropertyValue >= convertedFilterValue;
                            case FilterType.Grather:
                                return convertedPropertyValue > convertedFilterValue;
                            case FilterType.NotEqual:
                                return convertedPropertyValue != convertedFilterValue;
                            case FilterType.In:
                                return Values.Any(v => convertedFilterValue == Convert.ToInt32(v));
                            default:
                                return false;
                        }
                    }
                case "string":
                    {
                        string convertedPropertyValue = propertyValue.ToString().Trim().ToLower();
                        //для строкового фильтра в FilterType.Equal и FilterType.NotEqual
                        //проверяются все значения 
                        switch (FilterType)
                        {
                            case FilterType.Equal:
                                return Values.Select(v => new Pattern(v.ToString().Trim().ToLower(), true, true)).All(p => p.IsMatch(convertedPropertyValue));
                            case FilterType.NotEqual:
                                return !Values.Select(v => new Pattern(v.ToString().Trim().ToLower(), true, true)).Any(p => p.IsMatch(convertedPropertyValue));
                            case FilterType.In:
                                return Values.Select(v => new Pattern(v.ToString().Trim().ToLower(), true, true)).Any(p => p.IsMatch(convertedPropertyValue));
                            default:
                                return false;
                        }
                    }
            }
            return true;
        }
        #endregion

        #region public void ClearFilter()
        /// <summary>
        /// Производит очистку фильтра
        /// </summary>
        public void ClearFilter()
        {
            FilterType = FilterType.Equal;
            Values = new T[0];
        }
        #endregion

        #region public int GetValidValuesCount()
        /// <summary>
        /// Возвращает кол-во действительных (not null) значений фильтра
        /// </summary>
        /// <returns>кол-во действительных элементов фильтра</returns>
        public int GetValidValuesCount()
        {
            //Если массив равен null или пуст
            //Возвращается 0
            if (Values == null || Values.Length == 0)
                return 0;
            return Values.Count(v => v != null);
        }
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
            return (IEnumerator<T>)Values.GetEnumerator();
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
            return Values.GetEnumerator();
        }
        #endregion

        #region public void SetParameters(FilterType filterType, object[] values)

        /// <summary>
        /// Задает параметры типа фильтрации, массив значений фильтра и массив всех возможных значений фильтруемого поля
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="values"></param>
        /// <param name="allValues"></param>
        public void SetParameters(FilterType filterType, IEnumerable<object> values, IEnumerable<object> allValues = null)
        {
            FilterType = filterType;
            Values = values.OfType<T>().ToArray();
            AllValues = allValues != null ? allValues.OfType<T>().ToArray() : null;
        }
		#endregion

		#region public void SetParameters(IEnumerable<object> values)

		public void SetParameters(IEnumerable<object> values)
	    {
		    Values = values.OfType<T>().ToArray();
	    }

	    #endregion

		#region public override string ToString()
		public override string ToString()
        {
            FilterAttribute lvda = (FilterAttribute)
                    FilterProperty.GetCustomAttributes(typeof(FilterAttribute), false).FirstOrDefault();
            if (lvda == null)
                return "";
            string res = lvda.Title + " ";

            if (AllValues != null && Values.Length == AllValues.Length)
            {
                res += "All";
                return res;
            }
            for (int i = 0; i < Values.Length; i++)
            {
                if(i > 0)
                    res += ",";
                res += Values[i].ToString();
            }
            return res;
        }
        #endregion
    }
    #endregion
}
