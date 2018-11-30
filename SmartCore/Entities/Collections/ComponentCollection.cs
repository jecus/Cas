using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция агрегатов с удобным доступом к агрегатам
    /// </summary>
    public class ComponentCollection : CommonCollection<General.Accessory.Component>
    {

		#region public ComponentCollection()
		/// <summary>
		/// Создает пустую коллекцию агрегатов
		/// </summary>
		public ComponentCollection()
        {
        }
		#endregion

		#region public ComponentCollection(List<Component> components)
		/// <summary>
		/// Создает коллекцию агрегатов на основе передаваемого листа агрегатов
		/// </summary>
		/// <param name="components"></param>
		public ComponentCollection(List<General.Accessory.Component> components)
        {
            Items = components;
            Items.Sort();
        }
		#endregion

		#region public ComponentCollection(IEnumerable<Component> components)
		/// <summary>
		/// Создает коллекцию агрегатов на основе передаваемого листа агрегатов
		/// </summary>
		/// <param name="components"></param>
		public ComponentCollection(IEnumerable<General.Accessory.Component> components) : base(components)
        {
        }
		#endregion

		#region public Component[] GetLastInstalledComponentsOn(BaseComponent baseComponent)

		public General.Accessory.Component[] GetLastInstalledComponentsOn(BaseComponent baseComponent)
        {
            //if(countDetails <= 0) countDetails = 1;
            
            //LINQ запрос для сортировки записей по дате
            var sortrecords = (from component in Items
                               orderby component.TransferRecords.GetLast().TransferDate descending
                               select component).ToList();
            ////////////////////////////////////////////

            return sortrecords.Where(component => component.TransferRecords.GetLast().DestinationObjectId == baseComponent.ItemId 
												&& component.TransferRecords.GetLast().DestinationObjectType == baseComponent.SmartCoreObjectType
											    && component.TransferRecords.GetLast().DODR == false).ToArray();
        }
		#endregion

		#region public IEnumerable<Component> GetLastInstalledComponentsOn(Store store)

		public IEnumerable<General.Accessory.Component> GetLastInstalledComponentsOn(Store store)
        {
            //LINQ запрос для сортировки записей по дате
            var sortrecords = (from component in Items
                               orderby component.TransferRecords.GetLast().TransferDate descending
                               select component).ToList();
            ////////////////////////////////////////////

            var resultList = new List<General.Accessory.Component>();
            foreach (var component in sortrecords)
            {
                if (component.TransferRecords.GetLast().DestinationObjectId == store.ItemId &&
                    component.TransferRecords.GetLast().DestinationObjectType == store.SmartCoreObjectType &&
                    component.TransferRecords.GetLast().DODR == false)
                    resultList.Add(component);
            }

            return resultList.ToArray();
        }
		#endregion

	    public IEnumerable<General.Accessory.Component> GetLastInstalledComponentsOnProcessing()
	    {
		    //LINQ запрос для сортировки записей по дате
		    var sortrecords = (from component in Items
			    orderby component.TransferRecords.GetLast().TransferDate descending
			    select component).ToList();
		    ////////////////////////////////////////////

		    var resultList = new List<General.Accessory.Component>();
		    foreach (var component in sortrecords)
		    {
			    if (component.TransferRecords.GetLast().DODR == false &&
					(component.TransferRecords.GetLast().DestinationObjectType == SmartCoreType.Supplier ||
					component.TransferRecords.GetLast().DestinationObjectType == SmartCoreType.Employee))
			        
				    resultList.Add(component);
		    }

		    return resultList.ToArray();
	    }

		#region public IEnumerable<Component> GetLastInstalledComponentsOn(Operator parentOperator)

		public IEnumerable<General.Accessory.Component> GetLastInstalledComponentsOn(Operator parentOperator)
        {
            //LINQ запрос для сортировки записей по дате
            var sortrecords = (from component in Items
                               orderby component.TransferRecords.GetLast().TransferDate descending
                               select component).ToList();
            ////////////////////////////////////////////

            var resultList = new List<General.Accessory.Component>();
            foreach (var component in sortrecords)
            {
                if (component.TransferRecords.GetLast().DestinationObjectId == parentOperator.ItemId &&
                    component.TransferRecords.GetLast().DestinationObjectType == parentOperator.SmartCoreObjectType &&
                    component.TransferRecords.GetLast().DODR == false)
                    resultList.Add(component);
            }

            return resultList.ToArray();
        }
		#endregion

		#region public Component[] GetWaitRemoveConfirmComponents(BaseComponent baseComponent)

		public General.Accessory.Component[] GetWaitRemoveConfirmComponents(BaseComponent baseComponent)
        {
            //LINQ запрос для сортировки записей по дате
            var sortrecords = (from component in Items
                               orderby component.TransferRecords.GetLast().TransferDate descending
                               select component).ToList();
            ////////////////////////////////////////////

            var resultList = new List<General.Accessory.Component>();
            foreach (var component in sortrecords)
            {
                if (component.TransferRecords.GetLast().FromBaseComponentId == baseComponent.ItemId &&
                    component.TransferRecords.GetLast().DODR == false)
                    resultList.Add(component);
            }

            return resultList.ToArray();
        }
		#endregion

		#region public Component[] GetWaitRemoveConfirmComponents(Store store)

		public General.Accessory.Component[] GetWaitRemoveConfirmComponents(Store store)
        {
            //LINQ запрос для сортировки записей по дате
            var sortrecords = (from component in Items
                               orderby component.TransferRecords.GetLast().TransferDate descending
                               select component).ToList();
            ////////////////////////////////////////////

            var resultList = new List<General.Accessory.Component>();
            foreach (var component in sortrecords)
            {
                if (component.TransferRecords.GetLast().FromStoreId == store.ItemId &&
                    component.TransferRecords.GetLast().DODR == false)
                    resultList.Add(component);
            }

            return resultList.ToArray();
        }
		#endregion

		#region  public new IEnumerator<Component> GetEnumerator()
		/// <summary>
		/// Реализация цикла foreach 
		/// </summary>
		/// <returns></returns>
		public new IEnumerator<General.Accessory.Component> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        /*
         * Реализация
         */
    }
}
