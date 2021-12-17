using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Management;
using SmartCore.RegisterPerformances;

namespace SmartCore.Tests
{
	[TestClass]
	public class PerformanceCoreTest
	{
		[TestMethod]
		public void DeleteDirectiveRecordTest()
		{
			var enviroment = GetEnviroment();
			var performanceCore = new PerformanceCore(enviroment.NewKeeper, enviroment.Keeper, enviroment.Calculator, null);

			var mpd = new MaintenanceDirective
			{
				Remarks = "Test"
			};

			enviroment.NewKeeper.Save(mpd);

			var directiveRecordForMpdFirst = new DirectiveRecord
			{
				MaintenanceDirectiveRecordId = mpd.ItemId,
				Parent = mpd,
				Remarks = "Test"
			};
			enviroment.NewKeeper.Save(directiveRecordForMpdFirst);

			var directiveRecordForMpdSecond = new DirectiveRecord
			{
				MaintenanceDirectiveRecordId = directiveRecordForMpdFirst.ItemId,
				Remarks = "Test"
			};
			enviroment.NewKeeper.Save(directiveRecordForMpdSecond);


			performanceCore.Delete(directiveRecordForMpdFirst);

			//Загрузка 1 и 2 DirectiveRecord
			var forCheckFirst = enviroment.NewLoader.GetObject<DirectiveRecordDTO,DirectiveRecord>(new Filter("ItemId", directiveRecordForMpdFirst.ItemId),getDeleted:true);
			var forCheckSecond = enviroment.NewLoader.GetObject<DirectiveRecordDTO,DirectiveRecord>(new Filter("MaintenanceDirectiveRecordId", directiveRecordForMpdFirst.ItemId),getDeleted:true);

			//Проверка что оба DirectiveRecord - a помечены как удаленные
			Assert.IsTrue(forCheckFirst.IsDeleted);
			Assert.IsTrue(forCheckSecond.IsDeleted);

			//Удаление из БД
			enviroment.NewKeeper.Delete(mpd);
			enviroment.NewKeeper.Delete(directiveRecordForMpdFirst,false, false);
			enviroment.NewKeeper.Delete(directiveRecordForMpdSecond, false, false);
		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");
			DbTypes.CasEnvironment = cas;

			return cas;
		}
	}
}