using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция базовых агрегатов с удобным доступом к базовым агрегатам 
    /// </summary>
    public class BaseComponentCollection : CommonCollection<BaseComponent>
    {

		#region public BaseComponentCollection()
		/// <summary>
		/// Создает пустую коллекцию базовых агрегатов
		/// </summary>
		public BaseComponentCollection()
        {
        }
		#endregion

		#region public BaseComponentCollectionIEnumerable<BaseComponent> baseComponents)
		/// <summary>
		/// Создает коллекцию базовых агрегатов на основе передаваемого массива 
		/// </summary>
		/// <param name="baseComponents"></param>
		public BaseComponentCollection(IEnumerable<BaseComponent> baseComponents)
        {
            Items.AddRange(baseComponents);
            Items.Sort();
        }
		#endregion

		#region public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Aircraft aircraft)

		public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Aircraft aircraft)
        {
            //if(countDetails <= 0) countDetails = 1;

            //LINQ запрос для сортировки записей по дате
            var sortRecords = (from baseComponent in Items
                               orderby baseComponent.TransferRecords.Last().TransferDate descending
                               select baseComponent).ToList();
            ////////////////////////////////////////////

            return sortRecords.Where(baseComponent => baseComponent.TransferRecords.GetLast().DestinationObjectId == aircraft.ItemId 
												  && baseComponent.TransferRecords.GetLast().DestinationObjectType == SmartCoreType.Aircraft 
                                                  && baseComponent.TransferRecords.GetLast().DODR == false).ToArray();
        }
		#endregion

		#region public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Store store)

		public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Store store)
        {
            //LINQ запрос для сортировки записей по дате
            var sortRecords = (from baseComponent in Items
                               orderby baseComponent.TransferRecords.GetLast().TransferDate descending
                               select baseComponent).ToList();
            ////////////////////////////////////////////

            return sortRecords.Where(baseComponent => baseComponent.TransferRecords.GetLast().DestinationObjectId == store.ItemId 
												  && baseComponent.TransferRecords.GetLast().DestinationObjectType == SmartCoreType.Store 
                                                  && baseComponent.TransferRecords.GetLast().DODR == false).ToArray();
        }
		#endregion

		#region public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Operator parentOperator)

		public IEnumerable<BaseComponent> GetLastInstalledComponentsOn(Operator parentOperator)
        {
            //LINQ запрос для сортировки записей по дате
            var sortRecords = (from baseComponent in Items
                               orderby baseComponent.TransferRecords.GetLast().TransferDate descending
                               select baseComponent).ToList();
            ////////////////////////////////////////////

            return sortRecords.Where(baseComponent => baseComponent.TransferRecords.GetLast().DestinationObjectId == parentOperator.ItemId
												  && baseComponent.TransferRecords.GetLast().DestinationObjectType == SmartCoreType.Operator
                                                  && baseComponent.TransferRecords.GetLast().DODR == false).ToArray();
        }
        #endregion

        #region override public String ToString()
        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "Count = " + Count;
        }
        #endregion

        /*
         * Реализация
         */

    }

}
