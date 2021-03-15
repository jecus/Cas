using System.Collections.Generic;
using SmartCore.Entities.General;

namespace SmartCore.DataAccesses.ItemsRelation
{
	public interface IItemsRelationsDataAccess
	{
		IList<Relation.ItemsRelation> GetCustomRelations(IEnumerable<int> directiveIds, params int[] type);
		IList<Relation.ItemsRelation> GetRelations(int directiveId, int typeId);

		IList<Relation.ItemsRelation> CheckRelations(BaseEntityObject first, BaseEntityObject second);

		IList<Relation.ItemsRelation> GetRelations(IEnumerable<int> directiveIds, int typeId);
	}
}