using System;
using Auxiliary;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Quality;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Purchase;
using SmartCore.Queries;

namespace SmartCore.Tests
{
	[TestClass]
	public class SmartCoreFileTest
	{
		[TestMethod]
		public void SmartCoreFileTest_InsertLinksForOneFile()
		{
			var dbManager = GetEnviroment();
			var fileSmartCore = new FilesSmartCore(dbManager);

			//Константа =999 для того что бы в тестах было проще искать в бд линки для удаления данных перед вставкой 
			const int linkTypeId = 999;
			const int directiveId1 = 1;
			const int directiveId2 = 2;
			int directiveTypeId1 = SmartCoreType.Directive.ItemId;

			//Создаем линк с новым файлом 
			var link1 = CreateItemFileLink(directiveId1, directiveTypeId1, linkTypeId);
			var fileId1 = fileSmartCore.SaveAttachedFile(link1);

			//Создаем линк с новым файлом(таким же как и в 1 линке) и новым parentId 
			var link2 = CreateItemFileLink(directiveId2, directiveTypeId1, linkTypeId);
			var fileId2 = fileSmartCore.SaveAttachedFile(link2);

			Assert.AreEqual(fileId1, fileId2, "Id файла должны быть одинаковыми");

			var dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] {link1.ItemId, link2.ItemId}));
			var dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));

			Assert.AreEqual(2, dsLinks.Tables[0].Rows.Count, "Должно быть 2 линка на 1 файл");
			Assert.AreEqual(1, dsFiles.Tables[0].Rows.Count, "Должен вернуть 1 файл ");

			var getFirstLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[0]);
			var getSecondLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[1]);
			Assert.AreEqual(fileId1, getFirstLink.File.ItemId, $"File Id первого линка должен быть равен {fileId1}");
			Assert.AreEqual(fileId2, getSecondLink.File.ItemId, $"File Id второго линка должен быть равен {fileId2}");
			Assert.AreEqual(linkTypeId, getFirstLink.LinkType, $"LinkType первого линка должен быть равен {linkTypeId}");
			Assert.AreEqual(linkTypeId, getSecondLink.LinkType, $"LinkType второго линка должен быть равен {linkTypeId}");
			Assert.AreEqual(directiveTypeId1, getFirstLink.ParentTypeId, $"ParentTypeId первого линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveTypeId1, getSecondLink.ParentTypeId, $"ParentTypeId второго линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveId1, getFirstLink.ParentId, $"ParentId первого линка должен быть равен {directiveId1}");
			Assert.AreEqual(directiveId2, getSecondLink.ParentId, $"ParentId второго линка должен быть равен {directiveId2}");

			fileSmartCore.DeleteAttachedFile(link1);
			fileSmartCore.DeleteAttachedFile(link2);

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(0, dsLinks.Tables[0].Rows.Count, "Должно быть 0 линков");

			dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));
			Assert.AreEqual(0, dsFiles.Tables[0].Rows.Count, "Файла не должно быть");
		}

		[TestMethod]
		public void SmartCoreFileTest_InsertLinksOnOneFileAndChangeFileInLastLink()
		{
			var dbManager = GetEnviroment();
			var fileSmartCore = new FilesSmartCore(dbManager);

			//Константа =999 для того что бы в тестах было проще искать в бд линки для удаления данных перед вставкой 
			const int linkTypeId = 999;
			const int directiveId1 = 3;
			const int directiveId2 = 4;
			var directiveTypeId1 = SmartCoreType.Directive.ItemId;
			
			//Создаем линк с новым файлом 
			var link1 = CreateItemFileLink(directiveId1, directiveTypeId1, linkTypeId);
			var fileId1 = fileSmartCore.SaveAttachedFile(link1);
			
			//Создаем линк с новым файлом(таким же как и в 1 линке) и новым parentId 
			var link2 = CreateItemFileLink(directiveId2, directiveTypeId1, linkTypeId);
			var fileId2 = fileSmartCore.SaveAttachedFile(link2);
			Assert.AreEqual(fileId1, fileId2, "Id файла должны быть одинаковыми");

			var dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(2, dsLinks.Tables[0].Rows.Count, "Должно быть 2 линка на 1 файл");

			//обновляем линк ссылку на файл
			UpdateFileLink(link2);
		    fileId2 = fileSmartCore.SaveAttachedFile(link2);
			Assert.AreNotEqual(fileId1, fileId2, "Id файла не должны быть одинаковыми");

			var dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));
			Assert.AreEqual(1, dsFiles.Tables[0].Rows.Count, "Файла должно быть");
			dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link2.File.FileName, Convert.ToInt32(link2.File.FileSize)));
			Assert.AreEqual(1, dsFiles.Tables[0].Rows.Count, "Файла должно быть");

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(2, dsLinks.Tables[0].Rows.Count, "Должно быть 2 линка");
			var getFirstLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[0]);
			var getSecondLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[1]);
			Assert.AreNotEqual(getFirstLink.File.ItemId, getSecondLink.File.ItemId, "Id на файлы должны отличаться");
			Assert.AreEqual(fileId1, getFirstLink.File.ItemId, $"File Id первого линка должен быть равен {fileId1}");
			Assert.AreEqual(fileId2, getSecondLink.File.ItemId, $"File Id второго линка должен быть равен {fileId2}");
			Assert.AreEqual(linkTypeId, getFirstLink.LinkType, $"LinkType первого линка должен быть равен {linkTypeId}");
			Assert.AreEqual(linkTypeId, getSecondLink.LinkType, $"LinkType второго линка должен быть равен {linkTypeId}");
			Assert.AreEqual(directiveTypeId1, getFirstLink.ParentTypeId, $"ParentTypeId первого линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveTypeId1, getSecondLink.ParentTypeId, $"ParentTypeId второго линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveId1, getFirstLink.ParentId, $"ParentId первого линка должен быть равен {directiveId1}");
			Assert.AreEqual(directiveId2, getSecondLink.ParentId, $"ParentId второго линка должен быть равен {directiveId2}");

			fileSmartCore.DeleteAttachedFile(link1);
			fileSmartCore.DeleteAttachedFile(link2);

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(0, dsLinks.Tables[0].Rows.Count, "Должно быть 0 линков");

			dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));
			Assert.AreEqual(0, dsFiles.Tables[0].Rows.Count, "Файла не должно быть");
			dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link2.File.FileName, Convert.ToInt32(link2.File.FileSize)));
			Assert.AreEqual(0, dsFiles.Tables[0].Rows.Count, "Файла не должно быть");

		}

		[TestMethod]
		public void SmartCoreFileTest_InsertLinksAndRemoveFileLinkForLastFile()
		{
			var dbManager = GetEnviroment();
			var fileSmartCore = new FilesSmartCore(dbManager);

			//Константа =999 для того что бы в тестах было проще искать в бд линки для удаления данных перед вставкой 
			const int linkTypeId = 999;
			const int directiveId1 = 5;
			const int directiveId2 = 6;
			int directiveTypeId1 = SmartCoreType.Directive.ItemId;

			//Создаем линк с новым файлом 
			var link1 = CreateItemFileLink(directiveId1, directiveTypeId1, linkTypeId);
			var fileId1 = fileSmartCore.SaveAttachedFile(link1);

			//Создаем линк с новым файлом(таким же как и в 1 линке) и новым parentId 
			var link2 = CreateItemFileLink(directiveId2, directiveTypeId1, linkTypeId);
			var fileId2 = fileSmartCore.SaveAttachedFile(link2);

			Assert.AreEqual(fileId1, fileId2, "Id файла должны быть одинаковыми");

			var dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(2, dsLinks.Tables[0].Rows.Count, "Должно быть 2 линка на 1 файл");

			//Удаляем 2й линк
			fileSmartCore.DeleteAttachedFile(link2);

			var dsFiles = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));
			Assert.AreEqual(1, dsFiles.Tables[0].Rows.Count, "Файла должно быть");

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(1, dsLinks.Tables[0].Rows.Count, "Должно быть 1 линк");

			fileSmartCore.DeleteAttachedFile(link1);

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(0, dsLinks.Tables[0].Rows.Count, "Должно быть 0 линков");
		}

		[TestMethod]
		public void SmartCoreFileTest_InsertLinksForAnotherFiles()
		{
			var dbManager = GetEnviroment();
			var fileSmartCore = new FilesSmartCore(dbManager);

			//Константа =999 для того что бы в тестах было проще искать в бд линки для удаления данных перед вставкой 
			const int linkTypeId = 999;
			const int directiveId1 = 7;
			const int directiveId2 = 8;
			int directiveTypeId1 = SmartCoreType.Directive.ItemId;

			//Создаем линк с новым файлом 
			var link1 = CreateItemFileLink(directiveId1, directiveTypeId1, linkTypeId);
			var fileId1 = fileSmartCore.SaveAttachedFile(link1);

			//Создаем линк с новым файлом(таким же как и в 1 линке) и новым parentId 
			var link2 = CreateItemFileLink(directiveId2, directiveTypeId1, linkTypeId);
			UpdateFileLink(link2);//Присваиваем другой файл для линка 
			var fileId2 = fileSmartCore.SaveAttachedFile(link2);

			Assert.AreNotEqual(fileId1, fileId2, "Id файла не должны быть одинаковыми");

			var dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));

			Assert.AreEqual(2, dsLinks.Tables[0].Rows.Count, "Должно быть 2 линка");
			var getFirstLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[0]);
			var getSecondLink = ItemFileLinksQueries.Fill(dsLinks.Tables[0].Rows[1]);
			Assert.AreNotEqual(getFirstLink.File.ItemId, getSecondLink.File.ItemId, "Id на файлы должны отличаться");
			Assert.AreEqual(fileId1, getFirstLink.File.ItemId, $"File Id первого линка должен быть равен {fileId1}");
			Assert.AreEqual(fileId2, getSecondLink.File.ItemId, $"File Id второго линка должен быть равен {fileId2}");
			Assert.AreEqual(linkTypeId, getFirstLink.LinkType, $"LinkType первого линка должен быть равен {linkTypeId}");
			Assert.AreEqual(linkTypeId, getSecondLink.LinkType, $"LinkType второго линка должен быть равен {linkTypeId}");
			Assert.AreEqual(directiveTypeId1, getFirstLink.ParentTypeId, $"ParentTypeId первого линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveTypeId1, getSecondLink.ParentTypeId, $"ParentTypeId второго линка должен быть равен {directiveTypeId1}");
			Assert.AreEqual(directiveId1, getFirstLink.ParentId, $"ParentId первого линка должен быть равен {directiveId1}");
			Assert.AreEqual(directiveId2, getSecondLink.ParentId, $"ParentId второго линка должен быть равен {directiveId2}");

			var dsFiles1 = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link1.File.FileName, Convert.ToInt32(link1.File.FileSize)));
			var dsFiles2 = dbManager.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(link2.File.FileName, Convert.ToInt32(link2.File.FileSize)));
			Assert.AreEqual(1, dsFiles1.Tables[0].Rows.Count, $"Должен вернуть 1 файл {link1.File.FileName}");
			Assert.AreEqual(1, dsFiles2.Tables[0].Rows.Count, $"Должен вернуть 1 файл {link2.File.FileName}");

			fileSmartCore.DeleteAttachedFile(link1);
			fileSmartCore.DeleteAttachedFile(link2);

			dsLinks = dbManager.Execute(ItemFileLinksQueries.GetSelectQuery(new[] { link1.ItemId, link2.ItemId }));
			Assert.AreEqual(0, dsLinks.Tables[0].Rows.Count, "Должно быть 0 линков");

		}

		[TestMethod]
		public void SmartCoreFileTest_Directive()
		{
			var enviroment = GetEnviroment();
			
			var directive = new Directive
			{
				ADNoFile = new AttachedFile { FileName = "ADTest.test"},
				ServiceBulletinFile = new AttachedFile { FileName = "SBTest.test"},
				EngineeringOrderFile = new AttachedFile { FileName = "EOFile.test"},
			};

			enviroment.NewKeeper.Save(directive);

			Assert.IsTrue(directive.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<DirectiveDTO,Directive>(new Filter("ItemId", directive.ItemId), true);
			enviroment.NewKeeper.Delete(directive);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 3, "Кол-во файлов должно быть 3");
			Assert.IsTrue(forCheck.ADNoFile != null);
			Assert.AreEqual(forCheck.ADNoFile.FileName, "ADTest.test");
			Assert.IsTrue(forCheck.ServiceBulletinFile != null);
			Assert.AreEqual(forCheck.ServiceBulletinFile.FileName, "SBTest.test");
			Assert.IsTrue(forCheck.EngineeringOrderFile != null);
			Assert.AreEqual(forCheck.EngineeringOrderFile.FileName, "EOFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_MaintenanceDirective()
		{
			var enviroment = GetEnviroment();

			var maintenanceDirective = new MaintenanceDirective
			{
				MaintenanceManualFile = new AttachedFile { FileName = "MaintenanceManualFile.test" },
				TaskNumberCheckFile = new AttachedFile { FileName = "TaskNumberCheckFile.test" },
				MRBFile = new AttachedFile { FileName = "MRBFile.test" },
				TaskCardNumberFile = new AttachedFile { FileName = "TaskCardNumberFile.test" }
			};

			enviroment.NewKeeper.Save(maintenanceDirective);

			Assert.IsTrue(maintenanceDirective.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<MaintenanceDirectiveDTO,MaintenanceDirective>(new Filter("ItemId", maintenanceDirective.ItemId), true);
			enviroment.NewKeeper.Delete(maintenanceDirective);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 4, "Кол-во файлов должно быть 4");
			Assert.IsTrue(forCheck.MaintenanceManualFile != null);
			Assert.AreEqual(forCheck.MaintenanceManualFile.FileName, "MaintenanceManualFile.test");
			Assert.IsTrue(forCheck.TaskNumberCheckFile != null);
			Assert.AreEqual(forCheck.TaskNumberCheckFile.FileName, "TaskNumberCheckFile.test");
			Assert.IsTrue(forCheck.MRBFile != null);
			Assert.AreEqual(forCheck.MRBFile.FileName, "MRBFile.test");
			Assert.IsTrue(forCheck.TaskCardNumberFile != null);
			Assert.AreEqual(forCheck.TaskCardNumberFile.FileName, "TaskCardNumberFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_Detail()
		{
			var enviroment = GetEnviroment();

			var detail = new Entities.General.Accessory.Component
			{
				FaaFormFile = new AttachedFile { FileName = "FaaFormFile.test" },
			};

			enviroment.NewKeeper.Save(detail);

			Assert.IsTrue(detail.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<ComponentDTO, Entities.General.Accessory.Component>(new Filter("ItemId", detail.ItemId), true);
			enviroment.NewKeeper.Delete(detail);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.FaaFormFile != null);
			Assert.AreEqual(forCheck.FaaFormFile.FileName, "FaaFormFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DetailDirective()
		{
			var enviroment = GetEnviroment();

			var detailDirective = new ComponentDirective
			{
				FaaFormFile = new AttachedFile { FileName = "FaaFormFile.test" },
			};

			enviroment.NewKeeper.Save(detailDirective);

			Assert.IsTrue(detailDirective.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<ComponentDirectiveDTO,ComponentDirective>(new Filter("ItemId", detailDirective.ItemId), true);
			enviroment.NewKeeper.Delete(detailDirective);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.FaaFormFile != null);
			Assert.AreEqual(forCheck.FaaFormFile.FileName, "FaaFormFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_Document()
		{
			var enviroment = GetEnviroment();

			var document = new Document
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
				DocumentSubType = new DocumentSubType() { CommonName = "Test"}
			};

			enviroment.NewKeeper.Save(document);

			Assert.IsTrue(document.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<DocumentDTO,Document>(new Filter("ItemId", document.ItemId), true);
			enviroment.NewKeeper.Delete(document);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_ATLB()
		{
			var enviroment = GetEnviroment();

			var atlb = new ATLB
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(atlb);

			Assert.IsTrue(atlb.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<ATLBDTO, ATLB>(new Filter("ItemId", atlb.ItemId), true);
			enviroment.NewKeeper.Delete(atlb);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_TransferRecord()
		{
			var enviroment = GetEnviroment();

			var transferRecord = new TransferRecord
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" }
			};

			enviroment.NewKeeper.Save(transferRecord);

			Assert.IsTrue(transferRecord.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<TransferRecordDTO,TransferRecord>(new Filter("ItemId", transferRecord.ItemId), true);
			enviroment.NewKeeper.Delete(transferRecord);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_Specialist()
		{
			var enviroment = GetEnviroment();

			var specialist = new Specialist
			{
				ResumeFile = new AttachedFile { FileName = "ResumeFile.test" },
				PassportCopyFile = new AttachedFile { FileName = "PassportCopyFile.test" },
				Specialization = new Specialization(1, "test")
			};

			enviroment.NewKeeper.Save(specialist);

			Assert.IsTrue(specialist.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<SpecialistDTO,Specialist>(new Filter("ItemId", specialist.ItemId), true);
			enviroment.NewKeeper.Delete(specialist);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 2, "Кол-во файлов должно быть 2");
			Assert.IsTrue(forCheck.ResumeFile != null);
			Assert.AreEqual(forCheck.ResumeFile.FileName, "ResumeFile.test");
			Assert.IsTrue(forCheck.PassportCopyFile != null);
			Assert.AreEqual(forCheck.PassportCopyFile.FileName, "PassportCopyFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DirectiveRecord()
		{
			var enviroment = GetEnviroment();

			var directiveRecord = new DirectiveRecord
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
				Parent = new Document()
			};

			enviroment.NewKeeper.Save(directiveRecord, true);

			Assert.IsTrue(directiveRecord.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<DirectiveRecordDTO,DirectiveRecord>(new Filter("ItemId", directiveRecord.ItemId), true);
			enviroment.NewKeeper.Delete(directiveRecord);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_Audit()
		{
			var enviroment = GetEnviroment();

			var audit = new Audit
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(audit);

			Assert.IsTrue(audit.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<AuditDTO,Audit>(new Filter("ItemId", audit.ItemId), true);
			enviroment.NewKeeper.Delete(audit);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_Procedure()
		{
			var enviroment = GetEnviroment();

			var audit = new Procedure
			{
				CheckListFile = new AttachedFile { FileName = "CheckListFile.test" },
				ProcedureFile = new AttachedFile { FileName = "ProcedureFile.test" }
			};

			enviroment.NewKeeper.Save(audit);

			Assert.IsTrue(audit.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<ProcedureDTO,Procedure>(new Filter("ItemId", audit.ItemId), true);
			enviroment.NewKeeper.Delete(audit);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 2, "Кол-во файлов должно быть 2");
			Assert.IsTrue(forCheck.CheckListFile != null);
			Assert.AreEqual(forCheck.CheckListFile.FileName, "CheckListFile.test");
			Assert.IsTrue(forCheck.ProcedureFile != null);
			Assert.AreEqual(forCheck.ProcedureFile.FileName, "ProcedureFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DetailLLPCategoryChangeRecord()
		{
			var enviroment = GetEnviroment();

			var detailLLPCategoryChangeRecord = new ComponentLLPCategoryChangeRecord
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(detailLLPCategoryChangeRecord);

			Assert.IsTrue(detailLLPCategoryChangeRecord.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<ComponentLLPCategoryChangeRecordDTO,ComponentLLPCategoryChangeRecord>(new Filter("ItemId", detailLLPCategoryChangeRecord.ItemId), true);
			enviroment.NewKeeper.Delete(detailLLPCategoryChangeRecord);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_SupplierDocument()
		{
			var enviroment = GetEnviroment();

			var supplierDocument = new SupplierDocument
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(supplierDocument);

			Assert.IsTrue(supplierDocument.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<SupplierDocumentDTO,SupplierDocument>(new Filter("ItemId", supplierDocument.ItemId), true);
			enviroment.NewKeeper.Delete(supplierDocument);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DamageChart()
		{
			var enviroment = GetEnviroment();

			var damageChart = new DamageChart
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(damageChart);

			Assert.IsTrue(damageChart.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<DamageChartDTO,DamageChart>(new Filter("ItemId", damageChart.ItemId), true);
			enviroment.NewKeeper.Delete(damageChart);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_AircraftFlight()
		{
			var enviroment = GetEnviroment();

			var aircraftFlight = new AircraftFlight
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(aircraftFlight);

			Assert.IsTrue(aircraftFlight.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<AircraftFlightDTO,AircraftFlight>(new Filter("ItemId", aircraftFlight.ItemId), true);
			enviroment.NewKeeper.Delete(aircraftFlight);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DamageDocument()
		{
			var enviroment = GetEnviroment();

			var damageDocument = new DamageDocument
			{
				DamageDocFile = new AttachedFile { FileName = "DamageDocFile.test" },
			};

			enviroment.NewKeeper.Save(damageDocument);

			Assert.IsTrue(damageDocument.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<DamageDocumentDTO,DamageDocument>(new Filter("ItemId", damageDocument.ItemId), true);
			enviroment.NewKeeper.Delete(damageDocument);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.DamageDocFile != null);
			Assert.AreEqual(forCheck.DamageDocFile.FileName, "DamageDocFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_DamageItem()
		{
			var enviroment = GetEnviroment();

			var damageItem = new DamageItem
			{
				InspectionDocumentsFile = new AttachedFile { FileName = "InspectionDocumentsFile.test" },
			};

			enviroment.NewKeeper.Save(damageItem);

			Assert.IsTrue(damageItem.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.Loader.GetObject<DamageItem>(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, damageItem.ItemId) }, true);
			enviroment.NewKeeper.Delete(damageItem);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.InspectionDocumentsFile != null);
			Assert.AreEqual(forCheck.InspectionDocumentsFile.FileName, "InspectionDocumentsFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_PurchaseRequestRecord()
		{
			var enviroment = GetEnviroment();

			var purchaseRequestRecord = new PurchaseRequestRecord
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(purchaseRequestRecord);

			Assert.IsTrue(purchaseRequestRecord.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<PurchaseRequestRecordDTO, PurchaseRequestRecord>(new Filter("ItemId", purchaseRequestRecord.ItemId), true);
			enviroment.NewKeeper.Delete(purchaseRequestRecord);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_InitialOrder()
		{
			var enviroment = GetEnviroment();

			var initialOrder = new InitialOrder
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(initialOrder);

			Assert.IsTrue(initialOrder.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<InitialOrderDTO,InitialOrder>(new Filter("ItemId", initialOrder.ItemId), true);
			enviroment.NewKeeper.Delete(initialOrder);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_PurchaseOrder()
		{
			var enviroment = GetEnviroment();

			var purchaseOrder = new PurchaseOrder
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(purchaseOrder);

			Assert.IsTrue(purchaseOrder.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<PurchaseOrderDTO,PurchaseOrder>(new Filter("ItemId", purchaseOrder.ItemId), true);
			enviroment.NewKeeper.Delete(purchaseOrder);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}

		[TestMethod]
		public void SmartCoreFileTest_RequestForQuotation()
		{
			var enviroment = GetEnviroment();

			var requestForQuotation = new RequestForQuotation
			{
				AttachedFile = new AttachedFile { FileName = "AttachedFile.test" },
			};

			enviroment.NewKeeper.Save(requestForQuotation);

			Assert.IsTrue(requestForQuotation.ItemId > 0, "ItemId должен быть больше 0");

			var forCheck = enviroment.NewLoader.GetObject<RequestForQuotationDTO,RequestForQuotation>(new Filter("ItemId", requestForQuotation.ItemId), true);
			enviroment.NewKeeper.Delete(requestForQuotation);

			Assert.IsTrue(forCheck != null, "значение не должно быть null");
			Assert.AreEqual(forCheck.Files.Count, 1, "Кол-во файлов должно быть 1");
			Assert.IsTrue(forCheck.AttachedFile != null);
			Assert.AreEqual(forCheck.AttachedFile.FileName, "AttachedFile.test");
		}



		private DatabaseManager CreateConnetion()
		{
			var dbmanager = new DatabaseManager();
			dbmanager.Connect("91.213.233.139", "CASTest", "castester", "castester1");
			return dbmanager;
		}

		private ItemFileLink CreateItemFileLink(int parentId, int parentTypeId, int linkTypeId)
		{
			var fileData = UsefulMethods.GetByteArrayFromFile(@"D:\LinkTest.pdf");

			return new ItemFileLink
			{
				ParentId = parentId,
				ParentTypeId = parentTypeId,
				LinkType = (short) linkTypeId,
				File = new AttachedFile
				{
					FileData = fileData,
					FileName = "LinkTest.pdf",
					FileSize = fileData.Length
				}
			};
		}

		private void UpdateFileLink(ItemFileLink link)
		{
			var fileData = UsefulMethods.GetByteArrayFromFile(@"D:\NewLinkTest.pdf");
			link.File = new AttachedFile
			{
				FileData = fileData,
				FileName = "NewLinkTest.pdf",
				FileSize = fileData.Length
			};
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