using System.Collections.Generic;
using System.Linq;
using SmartCore.Component;
using SmartCore.Directives;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Maintenance;

namespace SmartCore.Relation
{
	public class BindedItemsCore : IBindedItemsCore
	{
		private readonly IComponentCore _componentCore;
		private readonly IDirectiveCore _directiveCore;
		private readonly IMaintenanceCore _maintenanceCore;


		public BindedItemsCore(IComponentCore componentCore, IDirectiveCore directiveCore, IMaintenanceCore maintenanceCore)
		{
			_componentCore = componentCore;
			_directiveCore = directiveCore;
			_maintenanceCore = maintenanceCore;
		}

		public IList<IDirective> GetBindedItemsFor(int aircraftId, IBindedItem bindedItem)
		{
			var resultCollection = new List<IDirective>();

			if (bindedItem.ItemRelations.Count == 0)
				return resultCollection;

			if (bindedItem.IsFirst == null)
				bindedItem.NormalizeItemRelations();

			var direrctiveList = bindedItem.IsFirst == true 
				? bindedItem.ItemRelations.Select(i => new { ItemId = i.SecondItemId, TypeId = i.SecondItemTypeId }) 
				: bindedItem.ItemRelations.Select(i => new { ItemId = i.FirstItemId, TypeId = i.FirtsItemTypeId });

			var groupedDirective = direrctiveList.GroupBy(g => g.TypeId);

			foreach (var grouping in groupedDirective)
			{
				if (grouping.Key == SmartCoreType.ComponentDirective.ItemId)
					resultCollection.AddRange(_componentCore.GetAircraftComponentDirectives(aircraftId, grouping.Select(g => g.ItemId).ToList()).Cast<IDirective>());
				else if(grouping.Key == SmartCoreType.Directive.ItemId)
					resultCollection.AddRange(_directiveCore.GetDirectivesList(aircraftId, DirectiveType.All, grouping.Select(g => g.ItemId).ToList()).Cast<IDirective>());
				else resultCollection.AddRange(_maintenanceCore.GetMaintenanceDirectiveList(grouping.Select(g => g.ItemId).ToList(), aircraftId).Cast<IDirective>());
			}

			return resultCollection;
		}

		public Dictionary<IBindedItem, List<IDirective>> GetBindedItemsFor(int aircraftId, IEnumerable<IBindedItem> bindedItems, IEnumerable<int> loadOnlyBindedItemsWithProvidedTypes = null)
		{
			var resultDict = new Dictionary<IBindedItem, List<IDirective>>();
			var bindedDirectives = new List<IDirective>();
			var itemIdItemTypeIdList = new List<BindedItemIdTypeId>();

			foreach (var bindedItem in bindedItems)
			{
				if (bindedItem.ItemRelations.Count == 0)
					continue;

				if (!resultDict.ContainsKey(bindedItem))
					resultDict.Add(bindedItem, new List<IDirective>());

				if (bindedItem.IsFirst == null)
					bindedItem.NormalizeItemRelations();

				IEnumerable<BindedItemIdTypeId> itemIdItemTypeIds;

				if (loadOnlyBindedItemsWithProvidedTypes == null)
				{
					itemIdItemTypeIds = bindedItem.IsFirst == true
						? bindedItem.ItemRelations.Select(i => new BindedItemIdTypeId(i.SecondItemId, i.SecondItemTypeId))
						: bindedItem.ItemRelations.Select(i => new BindedItemIdTypeId(i.FirstItemId, i.FirtsItemTypeId));
				}
				else
				{
					itemIdItemTypeIds = bindedItem.IsFirst == true
						? bindedItem.ItemRelations.Where(i => loadOnlyBindedItemsWithProvidedTypes.Contains(i.SecondItemTypeId)).Select(i => new BindedItemIdTypeId(i.SecondItemId, i.SecondItemTypeId))
						: bindedItem.ItemRelations.Where(i => loadOnlyBindedItemsWithProvidedTypes.Contains(i.FirtsItemTypeId)).Select(i => new BindedItemIdTypeId(i.FirstItemId, i.FirtsItemTypeId));
				}
					
				itemIdItemTypeIdList.AddRange(itemIdItemTypeIds);
			}

			var groupedByDirectiveType = itemIdItemTypeIdList.ToLookup(g => g.ItemTypeId, g => g.ItemId)
															 .Select(g => new
															 {
																 Type = g.Key,
																 DirectiveIds = g.ToArray()
															 }).ToList();

			foreach (var grouping in groupedByDirectiveType)
			{
				if (grouping.Type == SmartCoreType.ComponentDirective.ItemId)
					bindedDirectives.AddRange(_componentCore.GetAircraftComponentDirectives(aircraftId, grouping.DirectiveIds).Cast<IDirective>());
				else if (grouping.Type == SmartCoreType.Directive.ItemId)
					bindedDirectives.AddRange(_directiveCore.GetDirectivesList(aircraftId, DirectiveType.All, grouping.DirectiveIds).Cast<IDirective>());
				else bindedDirectives.AddRange(_maintenanceCore.GetMaintenanceDirectiveList(grouping.DirectiveIds, aircraftId).Cast<IDirective>());
			}

			foreach (var bindedItem in bindedItems)
			{
				foreach (var itemsRelation in bindedItem.ItemRelations)
				{
					resultDict[bindedItem].AddRange(bindedItem.IsFirst == true
						? bindedDirectives.Where(x => x.ItemId == itemsRelation.SecondItemId && x.SmartCoreObjectType.ItemId == itemsRelation.SecondItemTypeId)
						: bindedDirectives.Where(x => x.ItemId == itemsRelation.FirstItemId && x.SmartCoreObjectType.ItemId == itemsRelation.FirtsItemTypeId));
				}
			}

			return resultDict;
		}

		internal class BindedItemIdTypeId
		{
			public int ItemId { get; }
			public int ItemTypeId { get; }

			public BindedItemIdTypeId(int itemId, int itemTypeId)
			{
				ItemId = itemId;
				ItemTypeId = itemTypeId;
			}
		}
	}
}