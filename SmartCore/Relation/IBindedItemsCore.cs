using System.Collections.Generic;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Relation
{
	public interface IBindedItemsCore
	{
		IList<IDirective> GetBindedItemsFor(int aircraftId, IBindedItem bindedItem);
		Dictionary<IBindedItem, List<IDirective>> GetBindedItemsFor(int aircraftId, IEnumerable<IBindedItem> bindedItems, IEnumerable<int> loadOnlyBindedItemsWithProvidedTypes = null);
	}
}