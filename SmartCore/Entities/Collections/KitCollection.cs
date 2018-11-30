using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция директив с удобным доступом
    /// </summary>
    [Serializable]
    public class SupplierCollection : CommonCollection<Supplier>
    {

        #region public SupplierCollection()
        /// <summary>
        /// Создает пустую коллекцию DefferedItem
        /// </summary>
        public SupplierCollection()
        {
        }
        #endregion

        #region public SupplierCollection(List<Kit> kits)
        /// <summary>
        /// Создает коллекцию поставщиков на основе переданного листа
        /// </summary>
        /// <param name="kits"></param>
        public SupplierCollection(IEnumerable<Supplier> kits) : base(kits)
        {
        }
        #endregion

        #region override public String ToString()
        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            if (Items.Count == 0) return "";

            return Items.Aggregate("", (current, item) => current + (item.Name + "; "));
        }
        #endregion

        /*
         * Реализация
         */

    }
}
