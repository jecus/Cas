using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Tests
{
	[TestClass]
	public class BaseQueriesTest
	{

		[TestMethod]
		public void DeleteQueryWithFilterTest()
		{
			var query = BaseQueries.GetDeleteQuery<WorkPackageRecord>(new ICommonFilter[]
			{
				new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, 12),
				new CommonFilter<int>(WorkPackageRecord.DirectiveIdProperty, FilterType.In, new []{1,2,3}), 
			});

			var forCheck = string.Format("Set dateformat dmy; DELETE FROM [dbo].Cas3WorkPakageRecord where Cas3WorkPakageRecord.WorkPakageId = 12\n" +
			                             "and Cas3WorkPakageRecord.DirectivesId in (1,2,3)");

			Assert.AreEqual(query, forCheck);
			Trace.WriteLine(query);
			Trace.WriteLine(forCheck);
		}

		[TestMethod]
		public void GetMarkAsDeletedQueryTest()
		{
			var query = BaseQueries.GetMarkAsDeletedQuery<DirectiveRecord>(new ICommonFilter[]
			{
				new CommonFilter<int>(DirectiveRecord.MaintenanceDirectiveRecordIdProperty, 15) 
			});

			var forCheck = "Set dateformat dmy; Update [dbo].DirectivesRecords Set IsDeleted = 1 where DirectivesRecords.MaintenanceDirectiveRecordId = 15";

			Assert.AreEqual(query, forCheck);
			Trace.WriteLine(query);
			Trace.WriteLine(forCheck);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetMarkAsDeletedQueryWhereFiltersIsNullTest()
		{
			BaseQueries.GetMarkAsDeletedQuery<DirectiveRecord>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetMarkAsDeletedQueryWhereFiltersIsEmptyTest()
		{
			BaseQueries.GetMarkAsDeletedQuery<DirectiveRecord>(new ICommonFilter[] {});
		}
	}
}