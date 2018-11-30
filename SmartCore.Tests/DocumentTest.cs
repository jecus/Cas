using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Mail;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;
using SmartCore.WorkPackages;

namespace SmartCore.Tests
{
	[TestClass]
	public class DocumentTest
	{
		[TestMethod]
		public void CreateDocumentFromWorkPackage()
		{
			var enviroment = GetEnviroment();


			var qr = BaseQueries.GetSelectQueryWithWhere<WorkPackage>(loadChild: true);
			var ds = enviroment.DatabaseManager.Execute(qr);
			var wps = BaseQueries.GetObjectList<WorkPackage>(ds.Tables[0], true).Where(w => w.Status == WorkPackageStatus.Closed);


			foreach (var wp in wps)
			{
				if (wp.Files.Count > 0)
				{
					
				}
			}

		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "casadmin", "casadmin001", "SkyKGDBTest");
			DbTypes.CasEnvironment = cas;
			cas.Loader.FirstLoad();
			return cas;
		}

	}
}