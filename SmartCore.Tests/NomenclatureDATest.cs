
using EntityCore.DTO.Dictionaries;
using EntityCore.Filter;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests
{
	[TestClass]
	public class NomenclatureDATest
	{
		[TestMethod]
		public void LoadNomenclature()
		{
			var firstDepartment = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDepartment"
			};

			var firstNomenclature = new Nomenclatures
			{
				FullName = "firstNomenclature",
				ShortName = "firstNomenclature",
				Department = firstDepartment
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstDepartment);
			enviroment.NewKeeper.Save(firstNomenclature);


			var res = enviroment.NewLoader.GetObjectListAll<NomenclatureDTO,Nomenclatures>(new Filter("FullName", firstNomenclature.FullName), true);

			enviroment.NewKeeper.Delete(firstNomenclature);
			enviroment.NewKeeper.Delete(firstDepartment);

			Assert.AreEqual(1, res.Count);

			var forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("firstNomenclature", forCheckFirst.FullName);
			Assert.AreEqual("firstNomenclature", forCheckFirst.ShortName);
			Assert.IsTrue(forCheckFirst.Department.ItemId > 0);
			Assert.AreEqual("firstDepartment", forCheckFirst.Department.ShortName);
			Assert.AreEqual("firstDepartment", forCheckFirst.Department.FullName);
		}

		[TestMethod]
		public void DeleteNomenclature()
		{
			var firstNomenclature = new Nomenclatures
			{
				FullName = "firstNomenclature",
				ShortName = "firstNomenclature",
				Department = new Department
				{
					FullName = "firstDepartment",
					ShortName = "firstDepartment"
				}
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstNomenclature);

			var res = enviroment.NewLoader.GetObjectListAll<NomenclatureDTO, Nomenclatures>(new Filter("FullName", firstNomenclature.FullName));

			enviroment.NewKeeper.Delete(firstNomenclature);
			Assert.AreEqual(1, res.Count);

			res = enviroment.NewLoader.GetObjectListAll<NomenclatureDTO, Nomenclatures>(new Filter("FullName", firstNomenclature.FullName));
			Assert.AreEqual(0, res.Count);
		}

		[TestMethod]
		public void UpdateNomenclature()
		{
			var firstDepartment = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDepartment"
			};

			var firstNomenclature = new Nomenclatures
			{
				FullName = "firstNomenclature",
				ShortName = "firstNomenclature",
				Department = firstDepartment
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstDepartment);
			enviroment.NewKeeper.Save(firstNomenclature);

			var res = enviroment.NewLoader.GetObjectListAll<NomenclatureDTO, Nomenclatures>(new Filter("FullName", firstNomenclature.FullName));

			Assert.AreEqual(1, res.Count);

			var forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("firstNomenclature", forCheckFirst.FullName);
			Assert.AreEqual("firstNomenclature", forCheckFirst.ShortName);


			firstNomenclature.FullName = "Updated";
			enviroment.NewKeeper.Save(firstNomenclature);

			res = enviroment.NewLoader.GetObjectListAll<NomenclatureDTO, Nomenclatures>(new Filter("ItemId", forCheckFirst.ItemId));

			enviroment.NewKeeper.Delete(firstNomenclature);
			enviroment.NewKeeper.Delete(firstDepartment);

			Assert.AreEqual(1, res.Count);

			forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("Updated", forCheckFirst.FullName);
			Assert.AreEqual("firstNomenclature", forCheckFirst.ShortName);

		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");

			return cas;
		}
	}
}