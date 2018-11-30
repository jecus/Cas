using SmartCore.Entities.General.Accessory;
using TextProcessing;

namespace SmartCore.Filters
{
    public class ProductSuppliersFilter : ProductFilter
    {
        #region Fields
        /// <summary>
        /// Маска для фильтрации
        /// </summary>
        private string _mask;
        Pattern _pattern;
        #endregion

        #region Constructors

        #region public ProductSuppliersFilter():this("*")
        /// <summary>
        /// Создается фильтр по какому-то полю по заданной маске. Маска = "*"
        /// </summary>
        public ProductSuppliersFilter()
            : this("*")
        {
        }
        #endregion

        #region protected ProductSuppliersFilter(string mask)
        /// <summary>
        /// Создается фильтр по какому-то полю по заданной маске
        /// </summary>
        /// <param name="mask">Маска поиска</param>
        public ProductSuppliersFilter(string mask)
        {
            Mask = mask;
        }
        #endregion

        #endregion

        #region Properties

        #region public string Mask
        /// <summary>
        /// Маска для фильтрации
        /// </summary>
        public string Mask
        {
            get { return _mask; }
            set
            {
                _mask = value;
                _pattern = new Pattern(_mask);
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public override bool Acceptable(Product item)
        ///<summary>
        /// Проверяется, подходит ли агрегат под фильтр
        ///</summary>
        ///<param name="item">Проверяемый агрегат</param>
        ///<returns>Результат - подходит ли агрегат</returns>
        public override bool Acceptable(Product item)
        {
            return _pattern.IsMatch(item.Suppliers.ToString());
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
            if (!base.Equals(obj)) return false;
            return _mask == ((ProductSuppliersFilter)obj)._mask;
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
