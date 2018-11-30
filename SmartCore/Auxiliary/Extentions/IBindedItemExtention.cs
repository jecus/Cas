using SmartCore.Entities.Dictionaries;
using SmartCore.Relation;

namespace SmartCore.Auxiliary.Extentions
{
	public static class IBindedItemExtention
	{
		public static bool? IsAffect(this IBindedItem bindedItem)
		{
			if (bindedItem.ItemRelations.Count == 0)
				return null;
			if (!bindedItem.IsFirst.HasValue)
				return null;
			if (bindedItem.IsFirst == true && bindedItem.WorkItemsRelationType == WorkItemsRelationType.CalculationAffect)
				return true;
			if (bindedItem.IsFirst == false && bindedItem.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend)
				return true;

			return false;
		}
	}
}