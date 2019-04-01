using EFCore.DTO.Dictionaries;
using EFCore.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests
{
	[TestClass]
	public class DepartmentDATest
	{
		[TestMethod]
		public void LoadDepartment()
		{
			var firstDepartment = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDepartment"
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstDepartment);

			var res = enviroment.NewLoader.GetObjectListAll<DepartmentDTO,Department>(new Filter("FullName", firstDepartment.FullName));

			enviroment.NewKeeper.Delete(firstDepartment);

			Assert.AreEqual(1, res.Count);

			var forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("firstDepartment", forCheckFirst.FullName);
			Assert.AreEqual("firstDepartment", forCheckFirst.ShortName);
		}

		[TestMethod]
		public void DeleteDepartment()
		{
			var firstDepartment = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDepartment"
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstDepartment);

			var res = enviroment.NewLoader.GetObjectListAll<DepartmentDTO, Department>(new Filter("FullName", firstDepartment.FullName));

			enviroment.NewKeeper.Delete(firstDepartment);
			Assert.AreEqual(1, res.Count);

			res = enviroment.NewLoader.GetObjectListAll<DepartmentDTO, Department>(new Filter("FullName", firstDepartment.FullName));
			Assert.AreEqual(0, res.Count);
		}

		[TestMethod]
		public void UpdateDepartment()
		{
			var firstDepartment = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDepartment"
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(firstDepartment);

			var res = enviroment.NewLoader.GetObjectListAll<DepartmentDTO, Department>(new Filter("FullName", firstDepartment.FullName));

			Assert.AreEqual(1, res.Count);

			var forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("firstDepartment", forCheckFirst.FullName);
			Assert.AreEqual("firstDepartment", forCheckFirst.ShortName);


			firstDepartment.FullName = "Updated";
			enviroment.NewKeeper.Save(firstDepartment);

			res = enviroment.NewLoader.GetObjectListAll<DepartmentDTO, Department>(new Filter("FullName", firstDepartment.FullName));

			enviroment.NewKeeper.Delete(firstDepartment);

			Assert.AreEqual(1, res.Count);

			forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("Updated", forCheckFirst.FullName);
			Assert.AreEqual("firstDepartment", forCheckFirst.ShortName);

		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");

			return cas;
		}
	}
}