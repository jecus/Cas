using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests
{
	[TestClass]
	public class NonRoutineJobDATest
	{
		[TestMethod]
		public void LoadNonRoutineJobIfFileNotExistInDb()
		{
			var enviroment = GetLoader();
			var loader = enviroment.Loader;
			var keeper = enviroment.Keeper;
			var da = new NonRoutineJobDataAccess(loader, keeper);
			var nrj = new NonRoutineJobDTO
			{
				ATAChapterId = 1,
				Cost = 2,
				Description = "NRJDADescription",
				KitRequired = "NRJDAKitRequired",
				ManHours = 3,
				Title = "NRJDATitle"
			};

			enviroment.NewKeeper.Save(nrj);

			var res = da.GetNonRoutineJobDTOs(new List<int> {nrj.ItemId});
			
			enviroment.NewKeeper.Delete(nrj);

			Assert.AreEqual(res.Count, 1, "Ожидается 1");
			var forCheck = res[0];
			Assert.AreEqual(forCheck.ATAChapterId, 1);
			Assert.AreEqual(forCheck.Cost, 2);
			Assert.AreEqual(forCheck.ManHours, 3);
			Assert.AreEqual(forCheck.Description, "NRJDADescription");
			Assert.AreEqual(forCheck.KitRequired, "NRJDAKitRequired");
			Assert.AreEqual(forCheck.Title, "NRJDATitle");
		}


		[TestMethod]
		public void LoadNonRoutineJobIfFileExistInDb()
		{
			var enviroment = GetLoader();
			var loader = enviroment.Loader;
			var keeper = enviroment.Keeper;
			var da = new NonRoutineJobDataAccess(loader, keeper);

			var res = da.GetNonRoutineJobDTOs(new List<int> { 67 });

			Assert.AreEqual(res.Count, 1);
			var forCheck = res[0];
			Assert.AreEqual(forCheck.ATAChapterId, 22);
			Assert.AreEqual(forCheck.Cost, 1);
			Assert.AreEqual(forCheck.ManHours, 1);
			Assert.AreEqual(forCheck.Description, "NRJDataAccess");
			Assert.AreEqual(forCheck.Title, "NRJDataAccess");
			Assert.AreEqual(forCheck.Files.Count, 1);
			Assert.AreEqual(forCheck.Files[0].File.FileName, "NRJDA.pdf");
			Assert.AreEqual(forCheck.Files[0].LinkType, 9);
			Assert.AreEqual(forCheck.Files[0].ParentTypeId, 4);
			Assert.AreEqual(forCheck.Kits.Count, 1);
		}

		private CasEnvironment GetLoader()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");

			return cas;
		}
	}
}