using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция директив с удобным доступом
    /// </summary>
    [Serializable]
    public class ComponentLLPDataCollection : CommonCollection<ComponentLLPCategoryData>
    {

		#region public ComponentLLPDataCollection()
		/// <summary>
		/// Создает пустую коллекцию DetailLLPDataCollection
		/// </summary>
		public ComponentLLPDataCollection()
        {
        }
		#endregion

		#region public ComponentLLPDataCollection(List<ComponentLLPCategoryData> kits) : base(kits.ToArray())
		/// <summary>
		/// Создает коллекцию cpcp на основе переданного листа
		/// </summary>
		/// <param name="kits"></param>
		public ComponentLLPDataCollection(List<ComponentLLPCategoryData> kits) : base(kits.ToArray())
        {
        }
		#endregion

		#region public public ComponentLLPDataCollection(ComponentLLPCategoryData[] kits) : base(kits)
		/// <summary>
		/// Создает коллекцию cpcp на основе переданного листа
		/// </summary>
		/// <param name="kits"></param>
		public ComponentLLPDataCollection(ComponentLLPCategoryData[] kits) : base(kits)
        {
        }
		#endregion

		#region public ComponentLLPCategoryData GetItemByCatagory(LLPLifeLimitCategory llpLifeLimitCategory)
		/// <summary>
		/// Возвращает директиву  с указанным номером, либо null если директива не был найден в коллекции
		/// </summary>
		/// <param name="llpLifeLimitCategory"></param>
		/// <returns></returns>
		public ComponentLLPCategoryData GetItemByCatagory(LLPLifeLimitCategory llpLifeLimitCategory)
        {
            return Items.Where(llp => llp.ParentCategory.ItemId == llpLifeLimitCategory.ItemId).FirstOrDefault();
        }
        #endregion

        #region public void Reset()

        public void Reset()
        {
            foreach (ComponentLLPCategoryData data in Items) data.LLPLifelength.Reset();
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

            return Items.Aggregate("", (current, item) => current + (item.LLPLifeLimit.ToString() + "; "));
        }
        #endregion
    }
}
