using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Relation;

namespace SmartCore.Tests
{
	[TestClass]
	public class DirectiveTest
	{
		[TestMethod]
		public void TestDirective_NormalizeItemRelationsMethod()
		{
			var d = new Directive
			{
				ItemId = 10
			};

			d.ItemRelations.Add(new ItemsRelation
			{
				FirstItemId = 10,
				FirtsItemTypeId = SmartCoreType.Directive.ItemId,
				SecondItemId = 11,
				SecondItemTypeId = SmartCoreType.ComponentDirective.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationAffect
			});

			d.ItemRelations.Add(new ItemsRelation
			{

				FirstItemId = 12,
				FirtsItemTypeId = SmartCoreType.MaintenanceDirective.ItemId,
				SecondItemId = 10,
				SecondItemTypeId = SmartCoreType.Directive.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationDepend
			});

			Assert.AreEqual(d.IsFirst, null);

			d.NormalizeItemRelations();

			var forCheckFirst = d.ItemRelations[0];

			Assert.AreEqual(forCheckFirst.FirstItemId, 10);
			Assert.AreEqual(forCheckFirst.FirtsItemTypeId, SmartCoreType.Directive.ItemId);
			Assert.AreEqual(forCheckFirst.SecondItemId, 11);
			Assert.AreEqual(forCheckFirst.SecondItemTypeId, SmartCoreType.ComponentDirective.ItemId);
			Assert.AreEqual(forCheckFirst.RelationTypeId, WorkItemsRelationType.CalculationAffect);

			var forCheckSecond = d.ItemRelations[1];

			Assert.AreEqual(forCheckSecond.FirstItemId, 10);
			Assert.AreEqual(forCheckSecond.FirtsItemTypeId, SmartCoreType.Directive.ItemId);
			Assert.AreEqual(forCheckSecond.SecondItemId, 12);
			Assert.AreEqual(forCheckSecond.SecondItemTypeId, SmartCoreType.MaintenanceDirective.ItemId);
			Assert.AreEqual(forCheckSecond.RelationTypeId, WorkItemsRelationType.CalculationAffect);
		}


	}
}