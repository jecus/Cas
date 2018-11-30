using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Queries;
using SmartCore.Relation;

namespace SmartCore.DataAccesses.ItemsRelation
{
	public class ItemsRelationsDataAccess : IItemsRelationsDataAccess
	{
		private readonly ICasEnvironment _casEnvironment;

		public ItemsRelationsDataAccess(ICasEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
		}

		public IList<Relation.ItemsRelation> GetRelations(int directiveId, int typeId)
		{
			//TODO:(Evgenii Babak) не использовать рукописные запросы
			var qr = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
					 $" WHERE FirstItemId = {directiveId} AND FirtsItemTypeId = {typeId} OR SecondItemId = {directiveId} AND SecondItemTypeId = {typeId}";

			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<Relation.ItemsRelation>(ds.Tables[0]);
		}

		public IList<Relation.ItemsRelation> GetRelations(IEnumerable<int> directiveIds, int typeId)
		{
			var idsString = string.Join(",", directiveIds.Select(d => d.ToString(CultureInfo.InvariantCulture)).ToArray());

			//TODO:(Evgenii Babak) не использовать рукописные запросы
			var qr = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
					 $" WHERE FirstItemId in ({idsString}) AND FirtsItemTypeId = {typeId} OR SecondItemId in ({idsString}) AND SecondItemTypeId = {typeId}";

			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<Relation.ItemsRelation>(ds.Tables[0]);
		}
	}
}