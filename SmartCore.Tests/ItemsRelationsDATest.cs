using EFCore.DTO.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;

namespace SmartCore.Tests
{
	[TestClass]
	public class ItemsRelationsDATest
	{

		[TestMethod]
		public void LoadRelations()
		{
			var firstRelation = new ItemsRelation
			{
				FirstItemId = 1,
				FirtsItemTypeId = SmartCoreType.MaintenanceDirective.ItemId,
				SecondItemId = 2,
				SecondItemTypeId = SmartCoreType.Directive.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationAffect
			};

			var secondRelation = new ItemsRelation
			{
				FirstItemId = 4,
				FirtsItemTypeId = SmartCoreType.Directive.ItemId,
				SecondItemId = 1,
				SecondItemTypeId = SmartCoreType.MaintenanceDirective.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationDepend
			};
			var thirdRelation = new ItemsRelation
			{
				FirstItemId = 5,
				FirtsItemTypeId = SmartCoreType.Component.ItemId,
				SecondItemId = 6,
				SecondItemTypeId = SmartCoreType.Directive.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationAffect
			};

			var enviroment = GetEnviroment();
			var itemRelationDa = new ItemsRelationsDataAccess(enviroment);

			enviroment.NewKeeper.Save(firstRelation);
			enviroment.NewKeeper.Save(secondRelation);
			enviroment.NewKeeper.Save(thirdRelation);

			var res = itemRelationDa.GetRelations(1, 14);

			enviroment.NewKeeper.Delete(firstRelation);
			enviroment.NewKeeper.Delete(secondRelation);
			enviroment.NewKeeper.Delete(thirdRelation);

			Assert.AreEqual(2, res.Count);

			var forCheckFirst = res[0];
			var forCheckSecond = res[1];

			Assert.AreEqual(1, forCheckFirst.FirstItemId);
			Assert.AreEqual(SmartCoreType.MaintenanceDirective.ItemId, forCheckFirst.FirtsItemTypeId);
			Assert.AreEqual(2, forCheckFirst.SecondItemId);
			Assert.AreEqual(SmartCoreType.Directive.ItemId, forCheckFirst.SecondItemTypeId);
			Assert.AreEqual(WorkItemsRelationType.CalculationAffect, forCheckFirst.RelationTypeId);


			Assert.AreEqual(4, forCheckSecond.FirstItemId);
			Assert.AreEqual(SmartCoreType.Directive.ItemId, forCheckSecond.FirtsItemTypeId);
			Assert.AreEqual(1, forCheckSecond.SecondItemId);
			Assert.AreEqual(SmartCoreType.MaintenanceDirective.ItemId, forCheckSecond.SecondItemTypeId);
			Assert.AreEqual(WorkItemsRelationType.CalculationDepend, forCheckSecond.RelationTypeId);



		}

		[TestMethod]
		public void SaveDirectiveWithItemsRelation()
		{
			var enviroment = GetEnviroment();

			var directive = new Directive
			{
				Description = "Test Directive",
				ADType = ADType.Engine,
				Title = "Test Directive"
			};

			directive.ItemRelations.Add(new ItemsRelation
			{
				FirstItemId = 333,
				FirtsItemTypeId = 333,
				SecondItemId = 444,
				SecondItemTypeId = 444,
				RelationTypeId = WorkItemsRelationType.CalculationDepend
			});

			enviroment.Keeper.SaveAll(directive, true);

			Assert.IsTrue(directive.ItemId > 0);

			enviroment.NewKeeper.Delete(directive);

			var forCheck = enviroment.NewLoader.GetObject<ItemsRelationDTO, ItemsRelation>();

			Assert.IsTrue(forCheck != null);
			Assert.AreEqual(forCheck.FirstItemId, 333);
			Assert.AreEqual(forCheck.FirtsItemTypeId, 333);
			Assert.AreEqual(forCheck.SecondItemId, 444);
			Assert.AreEqual(forCheck.SecondItemTypeId, 444);
			Assert.AreEqual(forCheck.RelationTypeId, WorkItemsRelationType.CalculationDepend);

			enviroment.NewKeeper.Delete(forCheck);

		}

		[TestMethod]
		public void SaveMaintenanceDirectiveWithItemsRelation()
		{
			var enviroment = GetEnviroment();

			var maintenanceDirective = new MaintenanceDirective
			{
				Description = "Test Maintenance Directive"
			};

			maintenanceDirective.ItemRelations.Add(new ItemsRelation
			{
				FirstItemId = 555,
				FirtsItemTypeId = 555,
				SecondItemId = 666,
				SecondItemTypeId = 666,
				RelationTypeId = WorkItemsRelationType.CalculationDepend
			});

			enviroment.Keeper.SaveAll(maintenanceDirective, true);

			Assert.IsTrue(maintenanceDirective.ItemId > 0);

			enviroment.NewKeeper.Delete(maintenanceDirective);


			var forCheck = enviroment.NewLoader.GetObject<ItemsRelationDTO, ItemsRelation>();

			Assert.IsTrue(forCheck != null);
			Assert.AreEqual(forCheck.FirstItemId, 555);
			Assert.AreEqual(forCheck.FirtsItemTypeId, 555);
			Assert.AreEqual(forCheck.SecondItemId, 666);
			Assert.AreEqual(forCheck.SecondItemTypeId, 666);
			Assert.AreEqual(forCheck.RelationTypeId, WorkItemsRelationType.CalculationDepend);

			enviroment.NewKeeper.Delete(forCheck);

		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");

			return cas;
		}
	}
}