using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartCore.Tests.DataAccess
{
	[TestClass]
	public class EfTest
	{
		[TestMethod]
		public void TestConnection()
		{
			var context = new DataContext();
			var res = TestConnect(context);

			Assert.AreEqual(res, true);
		}

		[TestMethod]
		public void LoadAllNonRoutineJob()
		{
			var context = new DataContext();
			var res = context.NonRoutineJobs.ToList();

			Assert.AreEqual(res.Count, 36);
		}

		[TestMethod]
		public void LoadNonRoutineJobById()
		{
			var context = new DataContext();
			var res = context.NonRoutineJobs.Where(n => n.ItemId == 67).ToList();

			Assert.AreEqual(res.Count, 1);
			var forCheck = res.First();
			Assert.AreEqual(forCheck.ATAChapterId, 22);
			Assert.AreEqual(forCheck.Cost, 1);
			Assert.AreEqual(forCheck.ManHours, 1);
			Assert.AreEqual(forCheck.Description, "NRJDataAccess");
			Assert.AreEqual(forCheck.Title, "NRJDataAccess");
		}

		[TestMethod]
		public void LoadNonRoutineJobByIds()
		{
			var context = new DataContext();
			var ids = new[] {2, 67};

			var res = (from n in context.NonRoutineJobs
				where (ids.Contains(n.ItemId))
				select n).ToList();

			Assert.AreEqual(res.Count, 2);
			var forCheckFirst = res[0];
			var forCheckSecond = res[1];
			Assert.AreEqual(forCheckFirst.ItemId, 2);
			Assert.AreEqual(forCheckSecond.ItemId, 67);
		}

		[TestMethod]
		public void LoadNonRoutineJobWhereAtaChapterIsNull()
		{
			var context = new DataContext();
			var res = context.NonRoutineJobs.Where(n => n.ATAChapterId == null).ToList();

			Assert.AreEqual(res.Count, 1);
			var forCheck = res.First();
			Assert.AreEqual(forCheck.ATAChapterId, null);
		}


		[TestMethod]
		public void LoadAllItemFileLink()
		{
			var context = new DataContext();

			var nrj = context.NonRoutineJobs.Where(n => n.ItemId == 28).Include(a => a.ItemFileLinks).FirstOrDefault();


			Trace.WriteLine(nrj.Title);
			Trace.WriteLine(nrj.ItemFileLinks.Count);

				
		}

		private bool TestConnect(DataContext context)
		{
			try
			{
				context.Database.CommandTimeout = 1;
				context.Database.Connection.Open();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}