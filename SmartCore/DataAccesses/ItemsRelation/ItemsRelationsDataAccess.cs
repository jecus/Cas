﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SmartCore.Entities.General;
using SmartCore.Queries;

namespace SmartCore.DataAccesses.ItemsRelation
{
	public class ItemsRelationsDataAccess : IItemsRelationsDataAccess
	{
		private readonly ICasEnvironment _casEnvironment;

		public ItemsRelationsDataAccess(ICasEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
		}


		public IList<Relation.ItemsRelation> GetCustomRelations(IEnumerable<int> directiveIds, params int[] type)
		{
			if(!directiveIds.Any())
				return new List<Relation.ItemsRelation>();
			//TODO:(Evgenii Babak) не использовать рукописные запросы
			var qr = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
			         $" WHERE (FirstItemId IN ({string.Join(",", directiveIds)}) or SecondItemId In ({string.Join(",", directiveIds)})) and (FirtsItemTypeId in ({string.Join(",", type)}) or SecondItemTypeId in ({string.Join(",", type)})) AND IsDeleted = 0";

			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<Relation.ItemsRelation>(ds.Tables[0]);
		}

		public IList<Relation.ItemsRelation> GetRelations(int directiveId, int typeId)
		{
			//TODO:(Evgenii Babak) не использовать рукописные запросы
			var qr = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
					 $" WHERE (FirstItemId = {directiveId} AND FirtsItemTypeId = {typeId} OR SecondItemId = {directiveId} AND SecondItemTypeId = {typeId}) AND IsDeleted = 0";

			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<Relation.ItemsRelation>(ds.Tables[0]);
		}

		public IList<Relation.ItemsRelation> CheckRelations(BaseEntityObject first, BaseEntityObject second)
		{
			var qr = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
			         $" WHERE (FirstItemId = {first.ItemId} AND FirtsItemTypeId = {first.SmartCoreObjectType.ItemId} AND SecondItemTypeId = {second.SmartCoreObjectType.ItemId}) " +
			         $" OR (SecondItemId = {first.ItemId} AND SecondItemTypeId = {first.SmartCoreObjectType.ItemId} AND FirtsItemTypeId = {second.SmartCoreObjectType.ItemId}) " +
			         $"AND (SecondItemTypeId != FirtsItemTypeId) AND IsDeleted = 0";

			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<Relation.ItemsRelation>(ds.Tables[0]);
		}

		public IList<Relation.ItemsRelation> GetRelations(IEnumerable<int> directiveIds, int typeId)
		{
			var idsString = string.Join(",", directiveIds.Select(d => d.ToString(CultureInfo.InvariantCulture)).ToArray());

			//TODO:(Evgenii Babak) не использовать рукописные запросы
			var qr1 = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
					 $" WHERE (FirstItemId in ({idsString}) AND FirtsItemTypeId = {typeId}) AND IsDeleted = 0";

            var qr2 = BaseQueries.GetSelectQuery<Relation.ItemsRelation>(true) +
                      $" WHERE (SecondItemId in ({idsString}) AND SecondItemTypeId = {typeId}) AND IsDeleted = 0";

			var ds1 = _casEnvironment.Execute(qr1);
			var ds2 = _casEnvironment.Execute(qr2);
            var res = new List<Relation.ItemsRelation>();
			res.AddRange(BaseQueries.GetObjectList<Relation.ItemsRelation>(ds1.Tables[0]));
			res.AddRange(BaseQueries.GetObjectList<Relation.ItemsRelation>(ds2.Tables[0]));

			return res;
		}
	}
}