using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Management;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class PerformanceTest
	{
		[TestMethod]
		public void Test()
		{
			//HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "casadmin", "casadmin001", "ScatDBTest");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}

	}
}
