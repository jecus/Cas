using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Relation;

namespace SmartCore.Auxiliary.Extentions
{
	public static class ItemsRelationsCollectionExtention
	{
		public static IEnumerable<ItemsRelation> GetRelationsWith(this IEnumerable<ItemsRelation> relationsCollection, IBindedItem withItem)
		{
			if(relationsCollection == null || withItem == null)
				throw new ArgumentNullException("Input parameters can not be null");

			return relationsCollection.Where(i => i.FirstItemId == withItem.ItemId && i.FirtsItemTypeId == withItem.SmartCoreObjectType.ItemId ||
												  i.SecondItemId == withItem.ItemId && i.SecondItemTypeId == withItem.SmartCoreObjectType.ItemId);
		}

		public static bool IsAnyRelationWith(this IEnumerable<ItemsRelation> relationsCollection, IBindedItem withItem)
		{
			return relationsCollection.Any(i => i.FirstItemId == withItem.ItemId &&
			                                    i.FirtsItemTypeId == withItem.SmartCoreObjectType.ItemId ||
			                                    i.SecondItemId == withItem.ItemId &&
			                                    i.SecondItemTypeId == withItem.SmartCoreObjectType.ItemId);
		}

		public static bool IsAllRelationWith(this IEnumerable<ItemsRelation> relationsCollection, IBindedItem withItem)
		{
			return relationsCollection.All(i => i.FirstItemId == withItem.ItemId &&
												i.FirtsItemTypeId == withItem.SmartCoreObjectType.ItemId ||
												i.SecondItemId == withItem.ItemId &&
												i.SecondItemTypeId == withItem.SmartCoreObjectType.ItemId);
		}

		public static bool IsAllRelationWith(this IEnumerable<ItemsRelation> relationsCollection, SmartCoreType smartCoreType)
		{
			return relationsCollection.All(i => i.FirtsItemTypeId == smartCoreType.ItemId ||
			                                    i.SecondItemTypeId == smartCoreType.ItemId);
		}

	}
}