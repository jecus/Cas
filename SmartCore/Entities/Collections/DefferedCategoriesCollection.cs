using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция директив с удобным доступом
    /// </summary>
    public class DefferedCategoriesCollection : CommonCollection<DeferredCategory>
    {

        #region public DefferedCategoriesCollection()
        /// <summary>
        /// Создает пустую коллекцию директив
        /// </summary>
        public DefferedCategoriesCollection()
        {
        }
        #endregion

        #region public DefferedCategoriesCollection(List<DefferedCategory> directives)
        /// <summary>
        /// Создает коллекцию директив агрегатова на основе передаваемого листа директив агрегата
        /// </summary>
        /// <param name="directives"></param>
        public DefferedCategoriesCollection(List<DeferredCategory> directives) : base(directives.ToArray())
        {
        }
        #endregion

        #region public DefferedCategory GetDefferedCategoryById(Int32 defferedCategoryId)
        /// <summary>
        /// Возвращает категорию с указанным номером, либо null если категория не была найдена в коллекции
        /// </summary>
        /// <param name="defferedCategoryId"></param>
        /// <returns></returns>
        public DeferredCategory GetDefferedCategoryById(Int32 defferedCategoryId)
        {
            DeferredCategory result = Items.FirstOrDefault(item => item.ItemId == defferedCategoryId);
            return result ?? new DeferredCategory(-1, "unknown", new AircraftModel(), null);
        }
        #endregion
    }
}
