using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Содержит список Ata глав
    /// </summary>
    public class ReasonCollection : CommonCollection<Reason>
    {

        #region public ReasonCollection()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ReasonCollection()
        {

        }

        #endregion

        #region public ReasonCollection(ShutDownReason[] reasons)
        /// <summary>
        /// Создает лист из массива элементов
        /// </summary>
        /// <param name="reasons"></param>
        public ReasonCollection(Reason[] reasons)
        {
            Items.Clear();
			if(reasons != null)
				AddRange(reasons);  
        }

        #endregion

        #region public string ToString()

        /// <summary>
        /// Возвращает количество элементов в листе в формате ("Count = {list.count}")
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Count = " + Count;
        }

        #endregion

        #region public new IEnumerator<ShutDownReason> GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<Reason> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region public ShutDownReason GetItemByName(string name)
        /// <summary>
        /// Возвращает причину делая поиск по Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Reason GetItemByName(string name)
        {
            return Items.FirstOrDefault(t => t.FullName.ToUpper() == name.ToUpper());
        }
        #endregion

        #region public ShutDownReason[] GetItemsByCategory(string name)
        /// <summary>
        /// Возвращает причину делая поиск по Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Reason[] GetItemsByCategory(string category)
        {
            return Items.Where(t => t.Category.ToUpper() == category.ToUpper()).ToArray();
        }
        #endregion
 
     }

}
