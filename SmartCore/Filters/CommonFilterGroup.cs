using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCore.Filters
{
    ///<summary>
    /// Класс, продставляет группу фильтров
    ///</summary>
    public class CommonFilterGroup: IEnumerable<ICommonFilter>
    {

        #region Fields
        /// <summary>
        /// Список фильтров выборки
        /// </summary>
        private List<ICommonFilter> Items = new List<ICommonFilter>();
        /// <summary>
        /// Значение использования фильтров
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр
        /// </summary>
        private bool _filterTypeAnd;
        /// <summary>
        /// Значение использования со след фильтром
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр
        /// </summary>
        private bool _nextFilterTypeAnd;
        #endregion

        #region Constructors

        #region public CommonFilterGroup(IEnumerable<ICommonFilter> filters, bool filterTypeAnd = true, bool nextFilterTypeAnd = true)
        /// <summary>
        ///  Создается объект для выборки элементов
        /// </summary>
        /// <param name="filters">Применяемые для выборки фильтры</param>
        /// <param name="filterTypeAnd">Задает значение использования фильтров
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр</param>
        /// <param name="nextFilterTypeAnd">Задает значение использования со след. фильтром
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр</param>
        public CommonFilterGroup(IEnumerable<ICommonFilter> filters, bool filterTypeAnd = true, bool nextFilterTypeAnd = true)
        {
            Items.AddRange(filters);
            _filterTypeAnd = filterTypeAnd;
            _nextFilterTypeAnd = nextFilterTypeAnd;
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

        #region public bool FilterTypeAnd { get; set; }

        /// <summary>
        /// Возвращает значение исрльзования фильтраов
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр
        /// </summary>
        public bool FilterTypeAnd
        {
            get { return _filterTypeAnd; }
        }
        #endregion

        #region public bool NextFilterTypeAnd { get; set; }

        /// <summary>
        /// Возвращает значение исрльзования со след фильтром
        /// <br/> true - Проверяемый элемент должен подходить под все фильтры, 
        /// <br/> false - Проверяемый элемент должен подходить хотя бы под один фильтр
        /// </summary>
        public bool NextFilterTypeAnd
        {
            get { return _nextFilterTypeAnd; }
        }
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
            if (!(obj is CommonFilterGroup)) return false;
            CommonFilterGroup collectionFilter = (CommonFilterGroup)obj;
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