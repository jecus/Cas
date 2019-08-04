
using EntityCore.DTO.General;
using EntityCore.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.DataAccesses.WorkPackageRecords;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Management;

namespace SmartCore.Tests
{
	[TestClass]
	public class WorkPackageRecordsDATest
	{
		[TestMethod]
		public void DeleteFromWorkPackageTest()
		{
			const int aircraftId = 2316;//4LimaTest

			var enviroment = GetEnviroment();
			var wrpDataAccess = new WorkPackageRecordsDataAccess(enviroment);

			var workPackage = new WorkPackage()
			{
				ParentId = aircraftId,
				Title = "TestWp",
				ClosingRemarks = "Test"
			};

			var directive = new Directive {Description = "Test"};
			var nrj = new NonRoutineJob {Description = "Test"};

			enviroment.NewKeeper.Save(workPackage);
			enviroment.NewKeeper.Save(directive);
			enviroment.NewKeeper.Save(nrj);

			workPackage.WorkPakageRecords.Add(new WorkPackageRecord
			{
				DirectiveId = nrj.ItemId,
				WorkPakageId = workPackage.ItemId,
				WorkPackageItemType = nrj.SmartCoreObjectType.ItemId
			});
			workPackage.WorkPakageRecords.Add(new WorkPackageRecord
			{
				DirectiveId = directive.ItemId,
				WorkPakageId = workPackage.ItemId,
				WorkPackageItemType = directive.SmartCoreObjectType.ItemId
			});

			foreach (var workPackageRecord in workPackage.WorkPakageRecords)
				enviroment.NewKeeper.Save(workPackageRecord);

			var forCheck = enviroment.NewLoader.GetObjectListAll<WorkPackageRecordDTO,WorkPackageRecord>(new Filter("WorkPakageId", workPackage.ItemId));
			Assert.AreEqual(forCheck.Count, 2, "Должно быть 2 записи в рабочем пакете");

			
			enviroment.NewKeeper.Delete(workPackage);
			enviroment.NewKeeper.Delete(directive);
			enviroment.NewKeeper.Delete(nrj);

			wrpDataAccess.DeleteFromWorkPackage(workPackage.ItemId, new BaseEntityObject[] { directive, nrj });
			forCheck = enviroment.NewLoader.GetObjectListAll<WorkPackageRecordDTO, WorkPackageRecord>(new Filter("WorkPakageId", workPackage.ItemId));
			Assert.AreEqual(forCheck.Count, 0, "Записей быть не должно");
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