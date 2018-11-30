using SmartCore.Entities.General.Accessory;

namespace SmartCore.Filters
{
    ///<summary>
    /// Класс, описывающий фильтр для директив
    ///</summary>
    public abstract class ProductFilter : IFilter
    {
        #region Methods

        #region public abstract bool Acceptable(Product item);

        ///<summary>
        /// Проверяется, подходит ли директива под фильтр
        ///</summary>
        ///<param name="item">Проверяемая директива</param>
        ///<returns>Результат - подходит ли директива</returns>
        public abstract bool Acceptable(Product item);


        #endregion

        #region public bool Acceptable(IFilteredItem item)
        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        public bool Acceptable(object item)
        {
            if (item is Product)
                return Acceptable(item as Product);
            
            return false;
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
            if (obj == null) return false;
            return obj.GetType() == GetType();
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
