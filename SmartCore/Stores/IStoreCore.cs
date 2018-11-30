using System.Collections.Generic;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;

namespace SmartCore.Stores
{
	public interface IStoreCore
	{
		Store GetStoreById(int storeId);
		IList<Store> GetAllStores();

		Store GetParentStore(IBaseEntityObject parent);
	}
}