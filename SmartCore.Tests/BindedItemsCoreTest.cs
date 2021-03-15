using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;
using SmartCore.Relation;

namespace SmartCore.Tests
{
	[TestClass]
	public class BindedItemsCoreTest
	{
		[TestMethod]
		public void GetBindedItemsForMpd()
		{
			const int aircraftId = 2316;// Воздушное судно 4LimaTest

			//инициализация core - ов
			var enviroment = GetEnviroment();
			var itemRelationDA = new ItemsRelationsDataAccess(enviroment);
			var airctaftCore = new AircraftsCore(enviroment.Loader, enviroment.NewKeeper, enviroment.NewLoader);
			airctaftCore.LoadAllAircrafts();
			var componentCore = new ComponentCore(enviroment, enviroment.Loader, enviroment.NewLoader, enviroment.NewKeeper, airctaftCore, itemRelationDA);
			var directiveCore = new DirectiveCore(enviroment.NewKeeper, enviroment.NewLoader, enviroment.Keeper, enviroment.Loader, itemRelationDA);
			var maintenanceCore = new MaintenanceCore(enviroment, enviroment.NewLoader, enviroment.NewKeeper, itemRelationDA, null);
			var bindedItemCore = new BindedItemsCore(componentCore, directiveCore, maintenanceCore);

			//Загрузка базового компонента для того что бы привязать его к mpd и ad
			var baseDetail = enviroment.BaseComponents.FirstOrDefault(x => x.ParentAircraftId == aircraftId);
			var detail = componentCore.GetComponents(baseDetail).FirstOrDefault();

			var mpd = new MaintenanceDirective {ParentBaseComponent = baseDetail};
			var dd = new ComponentDirective {ComponentId = detail.ItemId, Remarks = "DDTest"};
			var ad = new Directive {ParentBaseComponent = baseDetail, Remarks = "ADTest"};

			enviroment.NewKeeper.Save(dd);
			enviroment.NewKeeper.Save(ad);
			enviroment.NewKeeper.Save(mpd);

			mpd.ItemRelations.Add(new ItemsRelation
			{
				FirstItemId = mpd.ItemId,
				FirtsItemTypeId = mpd.SmartCoreObjectType.ItemId,
				SecondItemId = dd.ItemId,
				SecondItemTypeId = dd.SmartCoreObjectType.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationAffect
			});

			mpd.ItemRelations.Add(new ItemsRelation
			{
				FirstItemId = mpd.ItemId,
				FirtsItemTypeId = mpd.SmartCoreObjectType.ItemId,
				SecondItemId = ad.ItemId,
				SecondItemTypeId = ad.SmartCoreObjectType.ItemId,
				RelationTypeId = WorkItemsRelationType.CalculationAffect
			});

			foreach (var itemRelation in mpd.ItemRelations)
				enviroment.NewKeeper.Save(itemRelation);


			var bindedItemsADOnly = bindedItemCore.GetBindedItemsFor(aircraftId, new[] {mpd}, new [] {SmartCoreType.Directive.ItemId});
		    var bindedItemsDDOnly = bindedItemCore.GetBindedItemsFor(aircraftId, new[] {mpd}, new [] {SmartCoreType.ComponentDirective.ItemId});
		    var bindedItemsAll = bindedItemCore.GetBindedItemsFor(aircraftId, new[] {mpd});


			foreach (var itemRelation in mpd.ItemRelations)
				enviroment.NewKeeper.Delete(itemRelation);

			enviroment.NewKeeper.Delete(mpd);
			enviroment.NewKeeper.Delete(dd);
			enviroment.NewKeeper.Delete(ad);


			Assert.IsTrue(bindedItemsADOnly[mpd].Count == 1);
			var forCheckAd = (Directive)bindedItemsADOnly[mpd].Single();
			Assert.AreEqual(forCheckAd.Remarks, ad.Remarks);

			Assert.IsTrue(bindedItemsDDOnly[mpd].Count == 1);
			var forCheckDd = (ComponentDirective)bindedItemsDDOnly[mpd].Single();
			Assert.AreEqual(forCheckDd.Remarks, dd.Remarks);

			Assert.IsTrue(bindedItemsAll[mpd].Count == 2);
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");
			DbTypes.CasEnvironment = cas;

			cas.NewLoader.FirstLoad();
			
			return cas;
		}
	}
}