using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests
{
	[TestClass]
	public class SpecializationDATest
	{
		[TestMethod]
		public void LoadSpecialization()
		{
			var department = new Department
			{
				FullName = "firstDepartment",
				ShortName = "firstDep"
			};

			var specialization = new Specialization
			{
				FullName = "specialization",
				ShortName = "spec",
				Department = department
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(department);
			enviroment.NewKeeper.Save(specialization);


			var res = enviroment.NewLoader.GetObjectListAll<SpecializationDTO,Specialization>(new Filter("FullName", specialization.FullName),true);

			enviroment.NewKeeper.Delete(specialization);
			enviroment.NewKeeper.Delete(department);

			Assert.AreEqual(1, res.Count);

			var forCheckFirst = res[0];

			Assert.IsTrue(forCheckFirst.ItemId > 0, "Id не может быть меньше нуля");
			Assert.IsFalse(forCheckFirst.IsDeleted, "IsDelete не должен быть true");
			Assert.AreEqual("specialization", forCheckFirst.FullName);
			Assert.AreEqual("spec", forCheckFirst.ShortName);
			Assert.IsTrue(forCheckFirst.Department.ItemId > 0);
			Assert.AreEqual("firstDep", forCheckFirst.Department.ShortName);
			Assert.AreEqual("firstDepartment", forCheckFirst.Department.FullName);
		}


		[TestMethod]
		public void DeleteSpecialization()
		{
			var specialization = new Specialization
			{
				FullName = "Specialization",
				ShortName = "Specialization",
				Department = new Department
				{
					FullName = "Department",
					ShortName = "Department"
				}
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(specialization);

			var res = enviroment.NewLoader.GetObjectListAll<SpecializationDTO, Specialization>(new Filter("FullName", specialization.FullName), true);

			enviroment.NewKeeper.Delete(specialization);
			Assert.AreEqual(1, res.Count);

			res = enviroment.NewLoader.GetObjectListAll<SpecializationDTO, Specialization>(new Filter("FullName", specialization.FullName), true);
			Assert.AreEqual(0, res.Count);
		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");

			return cas;
		}
	}
}