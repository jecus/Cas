using System;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Management;

namespace SmartCore.Tests
{
	[TestClass]
	public class DocumentDATests
	{
		[TestMethod]
		public void InsertAndLoadDocument()
		{
			var aboard = true;
			var issueDateValidFrom = new DateTime(2013, 11, 11);
			var issueDateValidTo = new DateTime(2013, 12, 12);
			var issueNotify = 5;
			var issueValidTo = true;
			var revisionDateValidFrom = new DateTime(2014, 11, 11);
			var revisionDateValidTo = new DateTime(2014, 12, 12);
			var revisioNotify = 1;
			var revisioValidTo = false;
			var prolongationWay = ProlongationWay.Manually;



			var nomenclature = new Nomenclatures
			{
				FullName = "TestDocument",
				Department = Department.Unknown
			};

			var department = new Department
			{
				FullName = "TestDocument"
			}; 

			var serciceType = new ServiceType
			{
				 FullName = "TestDocument",
				 ShortName = "TestDocument"
			};

			var document = new Document
			{
				Aboard = aboard,
				IssueDateValidFrom = issueDateValidFrom,
				IssueDateValidTo = issueDateValidTo,
				IssueNotify = issueNotify,
				IssueValidTo = issueValidTo,
				RevisionDateFrom = revisionDateValidFrom,
				RevisionDateValidTo = revisionDateValidTo,
				RevisionNotify = revisioNotify,
				RevisionValidTo = revisioValidTo,
				Nomenсlature = nomenclature,
				Department = department,
				ServiceType = serciceType,
				ProlongationWay = prolongationWay,
				DocumentSubType = DocumentSubType.Unknown
			};

			var enviroment = GetEnviroment();
			enviroment.NewKeeper.Save(nomenclature);
			enviroment.NewKeeper.Save(department);
			enviroment.NewKeeper.Save(serciceType);
			enviroment.NewKeeper.Save(document);

			var forCheckDocument = enviroment.NewLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ItemId", document.ItemId),true).SingleOrDefault();

			enviroment.NewKeeper.Delete(nomenclature);
			enviroment.NewKeeper.Delete(department);
			enviroment.NewKeeper.Delete(serciceType);
			enviroment.NewKeeper.Delete(document);

			Assert.IsTrue(forCheckDocument != null, "forCheckDocument не должен быть пустым");
			Assert.AreEqual(aboard, forCheckDocument.Aboard);
			Assert.AreEqual(issueDateValidFrom, forCheckDocument.IssueDateValidFrom);
			Assert.AreEqual(issueDateValidTo, forCheckDocument.IssueDateValidTo);
			Assert.AreEqual(issueNotify, forCheckDocument.IssueNotify);
			Assert.AreEqual(issueValidTo, forCheckDocument.IssueValidTo);
			Assert.AreEqual(revisionDateValidFrom, forCheckDocument.RevisionDateFrom);
			Assert.AreEqual(revisionDateValidTo, forCheckDocument.RevisionDateValidTo);
			Assert.AreEqual(revisioNotify, forCheckDocument.RevisionNotify);
			Assert.AreEqual(revisioValidTo, forCheckDocument.RevisionValidTo);
			Assert.AreEqual(prolongationWay, forCheckDocument.ProlongationWay);

			Assert.IsTrue(forCheckDocument.Nomenсlature != null, "Nomenсlature не должен быть пустым");
			Assert.AreEqual("TestDocument", forCheckDocument.Nomenсlature.FullName);

			Assert.IsTrue(forCheckDocument.Department != null, "Department не должен быть пустым");
			Assert.AreEqual("TestDocument", forCheckDocument.Department.FullName);

			Assert.IsTrue(forCheckDocument.ServiceType != null, "ServiceType не должен быть пустым");
			Assert.AreEqual("TestDocument", forCheckDocument.ServiceType.FullName);

		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");
			DbTypes.CasEnvironment = cas;

			return cas;
		}
	}
}