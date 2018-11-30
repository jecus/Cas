using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using EFCore.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class PerformanceTest
	{
		[TestMethod]
		public void Test()
		{
			HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

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
