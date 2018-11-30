using System.Collections.Generic;

namespace SmartCore.DataAccesses.ItemsRelation
{
	public interface IItemsRelationsDataAccess
	{
		IList<Relation.ItemsRelation> GetRelations(int directiveId, int typeId);

		IList<Relation.ItemsRelation> GetRelations(IEnumerable<int> directiveIds, int typeId);
	}
}