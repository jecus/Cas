using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Accessory;

namespace SmartCore.Filters
{
    public class ProductCollectionFilter : ProductFilter
    {
        #region Fields
        /// <summary>
        /// Исходная коллекция директив
        /// </summary>
        private List<Product> _initialCollection;

        /// <summary>
        /// Список фильтров выборки
        /// </summary>
        private List<ProductFilter> _filters;

        /// <summary>
        /// тип фильтрации - true-и, false-или
        /// </summary>
        private bool _filterTypeAnd;

        #endregion

        #region Constructors

        #region public ProductCollectionFilter(PrimaryDirectiveFilter[] filters, bool filterTyprAnd): this(new PrimaryDirective[0], filters, filterTyprAnd)
        ///<summary>
        /// Создается объект для выборки директив
        ///</summary>
        ///<param name="filters">Применяемые для выборки фильтры</param>
        ///<param name="filterTyprAnd"></param>
        public ProductCollectionFilter(List<ProductFilter> filters, bool filterTyprAnd)
            : this(new List<Product>(), filters, filterTyprAnd)
        {
        }

        #endregion

        #region public ProductCollectionFilter(Kit[] initialCollection, List<KitFilter> filters)

        ///<summary>
        /// Создается объект для выборки директив
        ///</summary>
        ///<param name="initialCollection">Исходная коллекция директив</param>
        ///<param name="filters">Применяемые для выборки фильтры</param>
        ///<param name="filterTypeAnd">Тип фильтрации true-и false-или</param>
        public ProductCollectionFilter(List<Product> initialCollection, List<ProductFilter> filters, bool filterTypeAnd)
        {
            _initialCollection = initialCollection;
            _filters = filters;
            _filterTypeAnd = filterTypeAnd;
        }

        #endregion

        #region public ProductCollectionFilter()

        ///<summary>
        /// Создается объект для выборки директив
        ///</summary>
        public ProductCollectionFilter()
        {
            _initialCollection = new List<Product>();
            _filters = new List<ProductFilter>();
            _filterTypeAnd = false;
        }

        #endregion

        #endregion

        #region Properties

        #region public List<Product> InitialCollection
        /// <summary>
        /// Исходная коллекция директив
        /// </summary>
        public List<Product> InitialCollection
        {
            get { return _initialCollection; }
            set { _initialCollection = value; }
        }
        #endregion

        #region public List<ProductFilter> Filters

        /// <summary>
        /// Список фильтров выборки
        /// </summary>
        public List<ProductFilter> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }

        #endregion

        #region public bool FilterTypeAnd

        /// <summary>
        /// Тип фильтрации true-и, false - или
        /// </summary>
        public bool FilterTypeAnd
        {
            get { return _filterTypeAnd; }
            set { _filterTypeAnd = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public List<Product> GatherDirectives()
        ///<summary>
        /// Производится выборка директив
        ///</summary>
        ///<returns>Выбранные директивы</returns>
        public List<Product> GatherDirectives()
        {
            return _initialCollection.Where(Acceptable).ToList();
        }

        #endregion

        #region public bool Acceptable(Product item)
        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        public override bool Acceptable(Product item)
        {
            return _filters.All(t => t.Acceptable(item));
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
            if (!(obj is ProductCollectionFilter)) return false;
            ProductCollectionFilter collectionFilter = (ProductCollectionFilter)obj;
            if (_filters.Count != collectionFilter._filters.Count)
                return false;
            if (_filterTypeAnd != collectionFilter._filterTypeAnd)
                return false;
            return !_filters.Where((t, i) => !(t.Equals(collectionFilter._filters[i]))).Any();
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

        #endregion
    }
}
