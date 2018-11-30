using System;
using SmartCore.Entities.General.Store;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Stores
{
	public class StoreCore : IStoreCore
	{
		private readonly ICasEnvironment _casEnvironment;

		public StoreCore(ICasEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
		}

		#region public Store GetStoreById(int storeId)

		public Store GetStoreById(int storeId)
		{
			return _casEnvironment.Stores.GetItemById(storeId);
		}

		#endregion

		#region public IList<Store> GetAllStores()

		public IList<Store> GetAllStores()
		{
			return _casEnvironment.Stores.GetValidEntries().ToList();
		}

		#endregion

		#region public Store GetParentStore(IBaseEntityObject parent)

		/// <summary>
		/// Пытается получить Склад для всех типов объектов
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public Store GetParentStore(IBaseEntityObject parent)
		{
			if (parent == null)
				return null;

			var storeId = -1;

			if (parent is ComponentDirective)
			{
				var componentDirective = parent as ComponentDirective;
				if (componentDirective.ParentComponent != null)
					storeId = componentDirective.ParentComponent.ParentStoreId;
				else
					throw new Exception($"0927: Parent object is not set to component directive {componentDirective.ItemId}");
			}
			if (parent is Directive)
			{
				var directive = parent as Directive;
				if (directive.ParentBaseComponent != null)
					storeId = directive.ParentBaseComponent.ParentStoreId;
				else
					throw new Exception($"1156: Parent object is not set to directive {directive.ItemId}");
			}
			if (parent is BaseComponent)
			{
				var baseComponent = parent as BaseComponent;
				storeId = baseComponent.ParentStoreId;
			}
			if (parent is Entities.General.Accessory.Component)
			{
				var component = parent as Entities.General.Accessory.Component;
				storeId = component.ParentStoreId;
			}
			if (parent is MaintenanceCheck)
				storeId = -1;

			return getStoreById(storeId);
		}
		#endregion



		private Store getStoreById(int storeId)
		{
			return _casEnvironment.Stores.GetItemById(storeId);
		}

	}
}