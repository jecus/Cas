using System;
using System.Data.Entity;
using System.Linq;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class GeneralTest
	{
		[TestMethod]
		public void AccessoryRequiredDTOTest()
		{
			var context = new DataContext();

			var adt = new AccessoryDescriptionDTO
			{
				FullName = "testET1",
				DefaultProduct = "dvigatel"
			};

			context.AccessoryDescriptionDtos.Add(adt);
			context.SaveChanges();

			var gsdt = new GoodStandartDTO()
			{
				Description = "testETgst",
				Measure = 987,
			};

			context.GoodStandartDtos.Add(gsdt);
			context.SaveChanges();

			var accrd = new AccessoryRequiredDTO
			{
				Measure = 159,
				PartNumber = "accr1",
				AccessoryDescriptionId = adt.ItemId,
				GoodStandartId = gsdt.ItemId
			};

			context.AccessoryRequiredDtos.Add(accrd);
			context.SaveChanges();


			var find = context.AccessoryRequiredDtos.Include(i => i.Product)
													.Include(i => i.Standart).FirstOrDefault(i => i.Measure == 159 && i.PartNumber == "accr1");

			Assert.AreEqual(accrd.Measure, find.Measure);
			Assert.AreEqual(accrd.PartNumber, find.PartNumber);
			Assert.IsNotNull(find.Product);
			Assert.IsNotNull(find.Standart);


			context.AccessoryDescriptionDtos.Remove(adt);
			context.AccessoryRequiredDtos.Remove(accrd);
			context.GoodStandartDtos.Remove(gsdt);
			context.SaveChanges();
		}

		[TestMethod]
		public void ActualStateRecordDTOTest()
		{
			var context = new DataContext();
			var acstr = new ActualStateRecordDTO
			{
				ComponentId = 258,
				WorkRegimeTypeId = 963,
				FlightRegimeId = 741
			};

			context.ActualStateRecordDtos.Add(acstr);
			context.SaveChanges();

			var find = context.ActualStateRecordDtos.FirstOrDefault(i => i.ComponentId == 258 && i.WorkRegimeTypeId == 963);

			Assert.IsNotNull(acstr.ComponentId);
			Assert.IsNotNull(acstr.FlightRegimeId);
			Assert.AreEqual(acstr.ComponentId, find.ComponentId);
			Assert.AreEqual(acstr.WorkRegimeTypeId, find.WorkRegimeTypeId);
			Assert.AreEqual(acstr.FlightRegimeId, find.FlightRegimeId);


			context.ActualStateRecordDtos.Remove(acstr);
			context.SaveChanges();

		}

		[TestMethod]
		public void AircraftDTOTest()
		{
			var context = new DataContext();

			var adt = new AccessoryDescriptionDTO
			{
				FullName = "testET1",
				DefaultProduct = "dvigatel"
			};

			context.AccessoryDescriptionDtos.Add(adt);
			context.SaveChanges();

			var airct = new AircraftDTO()
			{
				OperatorID = 235,
				Boiler = "aircttest",
				AcceptanceDate = DateTime.Today,
				DeliveryDate = DateTime.Today,
				ManufactureDate = DateTime.Today,
				RegistrationNumber = "testreg",
				SerialNumber = "89765",
				ModelId = adt.ItemId
				
			};

			context.AircraftDtos.Add(airct);
			context.SaveChanges();


			var mcr1 = new MaintenanceProgramChangeRecordDTO()
			{
				MaintenanceCheckRecordId = 3527,
				Remarks = "1",
				ParentAircraftId = airct.ItemId
			};
			var mcr2 = new MaintenanceProgramChangeRecordDTO()
			{
				MaintenanceCheckRecordId = 3527,
				Remarks = "2",
				ParentAircraftId = airct.ItemId
			};

			context.MaintenanceProgramChangeRecordDtos.Add(mcr1);
			context.MaintenanceProgramChangeRecordDtos.Add(mcr2);
			context.SaveChanges();

			var find = context.AircraftDtos.Include(i => i.Model)
										   .Include(i => i.MaintenanceProgramChangeRecords).FirstOrDefault(i => i.OperatorID == 235 && i.Boiler == "aircttest");

			Assert.AreEqual(airct.RegistrationNumber, find.RegistrationNumber);
			Assert.AreEqual(airct.AcceptanceDate, find.AcceptanceDate);
			Assert.AreEqual(airct.DeliveryDate, find.DeliveryDate);
			Assert.AreEqual(airct.ManufactureDate, find.ManufactureDate);
			Assert.AreEqual(airct.OperatorID, find.OperatorID);
			Assert.AreEqual(airct.SerialNumber, find.SerialNumber);
			Assert.AreEqual(airct.Boiler, find.Boiler);
			Assert.IsNotNull(airct.Model);
			Assert.IsNotNull(airct.MaintenanceProgramChangeRecords);
			Assert.AreEqual(airct.MaintenanceProgramChangeRecords.Count, 2);


			context.AircraftDtos.Remove(airct);
			context.AccessoryDescriptionDtos.Remove(adt);
			context.MaintenanceProgramChangeRecordDtos.Remove(mcr1);
			context.MaintenanceProgramChangeRecordDtos.Remove(mcr2);
			context.SaveChanges();
		}

		[TestMethod]
		public void AircraftEquipmentDTOTest()
		{
			var context = new DataContext();

			var aop = new AircraftOtherParameterDTO
			{
				Name = "TestETqwe",
				FullName = "testETasd",
			};

			context.AircraftOtherParameterDtos.Add(aop);
			context.SaveChanges();

			var aiceqt = new AircraftEquipmentDTO
			{
				AircraftEquipmetType = 951,
				Description = "aiceqttest",
				AircraftOtherParameterId = aop.ItemId
			};

			context.AircraftEquipmentDtos.Add(aiceqt);
			context.SaveChanges();

			var find = context.AircraftEquipmentDtos.Include(i => i.AircraftOtherParameter).FirstOrDefault(i => i.AircraftEquipmetType == 951 && i.Description == "aiceqttest");

			Assert.IsNotNull(aiceqt.AircraftEquipmetType);
			Assert.AreEqual(aiceqt.AircraftEquipmetType, find.AircraftEquipmetType);
			Assert.AreEqual(aiceqt.Description, find.Description);
			Assert.IsNotNull(find.AircraftOtherParameter);


			context.AircraftEquipmentDtos.Remove(aiceqt);
			context.AircraftOtherParameterDtos.Remove(aop);
			context.SaveChanges();

		}

		[TestMethod]
		public void AircraftFlightDTOTest()
		{
			var context = new DataContext();

			var fgn = new FlightNumDTO
			{
				FlightNumber = "fgn333",
			};

			context.FlightNumDtos.Add(fgn);
			context.SaveChanges();

			var crl = new CruiseLevelDTO
			{
				FullName = "testETcrl",
				Track = "crt",
			};

			context.CruiseLevelDtos.Add(crl);
			context.SaveChanges();


			var from = new AirportCodeDTO
			{
				Country = "from",
				FullName = "from",
				City = "from",
			};
			var to = new AirportCodeDTO
			{
				Country = "to",
				FullName = "to",
				City = "to",
			};

			context.AirportCodeDtos.Add(from);
			context.AirportCodeDtos.Add(to);
			context.SaveChanges();

			var delay = new ReasonDTO
			{
				Name = "delay",
				Category = "delay",
			};
			var cancel = new ReasonDTO
			{
				Name = "cancel",
				Category = "cancel",
			};

			context.ReasonDtos.Add(delay);
			context.ReasonDtos.Add(cancel);
			context.SaveChanges();


			var actf = new AircraftFlightDTO
			{
				Correct = true,
				Cycles = 55,
				AtlbRecordType = 77,
				StationFromId = from.ItemId,
				StationToId = to.ItemId,
				FlightNumberId = fgn.ItemId,
				LevelId = crl.ItemId,
				DelayReasonId = delay.ItemId,
				CancelReasonId = cancel.ItemId

			};

			context.AircraftFlightDtos.Add(actf);
			context.SaveChanges();

			var find = context.AircraftFlightDtos.Include(i => i.FlightNumber)
												 .Include(i => i.Level)
												 .Include(i => i.DelayReason)
												 .Include(i => i.CancelReason)
												 .Include(i => i.StationFromDto)
												 .Include(i => i.StationToDto).FirstOrDefault(i => i.Cycles == 55 && i.FlightNumberId == fgn.ItemId);

			Assert.IsNotNull(actf.Correct);
			Assert.IsNotNull(actf.Cycles);
			Assert.IsNotNull(actf.AtlbRecordType);
			Assert.IsNotNull(actf.StationFromId);
			Assert.IsNotNull(actf.StationToId);
			Assert.IsNotNull(actf.FlightNumberId);
			Assert.AreEqual(actf.Correct, find.Correct);
			Assert.AreEqual(actf.AtlbRecordType, find.AtlbRecordType);
			Assert.AreEqual(actf.Cycles, find.Cycles);
			Assert.AreEqual(actf.FlightNumberId, find.FlightNumberId);
			Assert.AreEqual(actf.StationFromId, find.StationFromId);
			Assert.AreEqual(actf.StationToId, find.StationToId);
			Assert.IsNotNull(actf.FlightNumber);
			Assert.IsNotNull(actf.Level);
			Assert.IsNotNull(actf.StationFromDto);
			Assert.IsNotNull(actf.StationToDto);
			Assert.IsNotNull(actf.DelayReason);
			Assert.IsNotNull(actf.CancelReason);


			context.AircraftFlightDtos.Remove(actf);
			context.FlightNumDtos.Remove(fgn);
			context.CruiseLevelDtos.Remove(crl);
			context.AirportCodeDtos.Remove(from);
			context.AirportCodeDtos.Remove(to);
			context.ReasonDtos.Remove(delay);
			context.ReasonDtos.Remove(cancel);
			context.SaveChanges();

		}

		[TestMethod]
		public void AircraftWorkerCategoryDTOTest()
		{
			var context = new DataContext();
			var aicwc = new AircraftWorkerCategoryDTO()
			{
				Category = "aicwct",
				
			};

			context.AircraftWorkerCategoryDtos.Add(aicwc);
			context.SaveChanges();

			var find = context.AircraftWorkerCategoryDtos.FirstOrDefault(i => i.Category == "aicwct");

			Assert.AreEqual(aicwc.Category, find.Category);
			
			context.AircraftWorkerCategoryDtos.Remove(aicwc);
			context.SaveChanges();

		}

		[TestMethod]
		public void ATLBDTOTest()
		{
			var context = new DataContext();
			var atlb = new ATLBDTO()
			{
				AtlbStatus = 761,
				Remarks = "atlbtest"
			};

			context.Atlbdtos.Add(atlb);
			context.SaveChanges();

			var find = context.Atlbdtos.FirstOrDefault(i => i.AtlbStatus == 761 && i.Remarks == "atlbtest");

			Assert.IsNotNull(atlb.AtlbStatus);
			Assert.AreEqual(atlb.AtlbStatus, find.AtlbStatus);
			Assert.AreEqual(atlb.Remarks, find.Remarks);


			context.Atlbdtos.Remove(atlb);
			context.SaveChanges();

		}

		[TestMethod]
		public void AttachedFileDTOTest()
		{
			var context = new DataContext();
			var atdf = new AttachedFileDTO()
			{
				StoreInDatabase = true,
				FilePath = "atdf"
			};

			context.AttachedFileDtos.Add(atdf);
			context.SaveChanges();

			var find = context.AttachedFileDtos.FirstOrDefault(i => i.StoreInDatabase == true && i.FilePath == "atdf");

			Assert.IsNotNull(atdf.StoreInDatabase);
			Assert.AreEqual(atdf.StoreInDatabase, find.StoreInDatabase);
			Assert.AreEqual(atdf.FilePath, find.FilePath);


			context.AttachedFileDtos.Remove(atdf);
			context.SaveChanges();

		}

		[TestMethod]
		public void AuditDTOTest()
		{
			var context = new DataContext();
			var audt = new AuditDTO()
			{
				ParentId = 854,
				Author = "audttest"
			};
			context.AuditDtos.Add(audt);
			context.SaveChanges();


			var a1 = new AuditRecordDTO
			{
				DirectivesId = 937,
				JobCardNumber = "1",
				AuditId = audt.ItemId
			};
			var a2 = new AuditRecordDTO
			{
				DirectivesId = 937,
				JobCardNumber = "2",
				AuditId = audt.ItemId
			};

			context.AuditRecordDtos.Add(a1);
			context.AuditRecordDtos.Add(a2);
			context.SaveChanges();

			var find = context.AuditDtos.Include(i => i.AuditRecords).FirstOrDefault(i => i.ParentId == 854 && i.Author == "audttest");

			Assert.AreEqual(audt.ParentId, find.ParentId);
			Assert.AreEqual(audt.Author, find.Author);

			Assert.IsNotNull(find.AuditRecords);
			Assert.AreEqual(audt.AuditRecords.Count, 2);


			context.AuditDtos.Remove(audt);
			context.AuditRecordDtos.Remove(a1);
			context.AuditRecordDtos.Remove(a2);
			context.SaveChanges();

		}

		[TestMethod]
		public void AuditRecordDTOTest()
		{
			var context = new DataContext();
			var audrd = new AuditRecordDTO
			{
				DirectivesId = 937,
				JobCardNumber = "audrdtest"
			};

			context.AuditRecordDtos.Add(audrd);
			context.SaveChanges();

			var find = context.AuditRecordDtos.FirstOrDefault(i => i.DirectivesId == 937 && i.JobCardNumber == "audrdtest");

			Assert.AreEqual(audrd.DirectivesId, find.DirectivesId);
			Assert.AreEqual(audrd.JobCardNumber, find.JobCardNumber);


			context.AuditRecordDtos.Remove(audrd);
			context.SaveChanges();

		}

		[TestMethod]
		public void CategoryRecordDTOTest()
		{
			var context = new DataContext();
			var catrd = new CategoryRecordDTO
			{
				EmployeeId = 768,
				ParentTypeId = 379
			};

			context.CategoryRecordDtos.Add(catrd);
			context.SaveChanges();

			var find = context.CategoryRecordDtos.FirstOrDefault(i => i.EmployeeId == 768 && i.ParentTypeId == 379);

			Assert.AreEqual(catrd.EmployeeId, find.EmployeeId);
			Assert.AreEqual(catrd.ParentTypeId, find.ParentTypeId);


			context.CategoryRecordDtos.Remove(catrd);
			context.SaveChanges();

		}

		[TestMethod]
		public void CertificateOfReleaseToServiceDTOTest()
		{
			var context = new DataContext();

			var b1 = new SpecialistDTO
			{
				SpecializationID = 2157,
				Address = "1"
			};
			var b2 = new SpecialistDTO
			{
				SpecializationID = 2157,
				Address = "1"
			};
			context.SpecialistDtos.Add(b1);
			context.SpecialistDtos.Add(b2);
			context.SaveChanges();


			var ccrofrserv = new CertificateOfReleaseToServiceDTO()
			{
				AuthorizationB1Id = b1.ItemId,
				AuthorizationB2Id = b2.ItemId,
				Station = "ccrofrservtest"
			};

			context.CertificateOfReleaseToServiceDtos.Add(ccrofrserv);
			context.SaveChanges();

			var find = context.CertificateOfReleaseToServiceDtos.Include(i => i.AuthorizationB1).Include(i => i.AuthorizationB2).FirstOrDefault(i => i.Station == "ccrofrservtest");

			Assert.AreEqual(ccrofrserv.AuthorizationB1Id, find.AuthorizationB1Id);
			Assert.AreEqual(ccrofrserv.Station, find.Station);
			Assert.IsNotNull(find.AuthorizationB1);
			Assert.IsNotNull(find.AuthorizationB2);


			context.CertificateOfReleaseToServiceDtos.Remove(ccrofrserv);
			context.SpecialistDtos.Remove(b1);
			context.SpecialistDtos.Remove(b2);
			context.SaveChanges();

		}

		[TestMethod]
		public void ComponentDirectiveDTOTest()
		{
			var context = new DataContext();
			var comdirve = new ComponentDirectiveDTO()
			{
				DirectiveType = 74,
				NDTType = 52,
				ComponentId = 99,Remarks = "qwe"
			};

			context.ComponentDirectiveDtos.Add(comdirve);
			context.SaveChanges();


			var d1 = new DirectiveRecordDTO {Remarks = "1", ParentID = comdirve.ItemId, ParentTypeId = 2, RecordDate = DateTime.Today};
			var d2 = new DirectiveRecordDTO {Remarks = "2", ParentID = comdirve.ItemId, ParentTypeId = 2, RecordDate = DateTime.Today };
			context.DirectiveRecordDtos.Add(d1);
			context.DirectiveRecordDtos.Add(d2);
			context.SaveChanges();


			var accrd = new AccessoryRequiredDTO
			{
				Measure = 159,
				PartNumber = "accr1",
				ParentId = comdirve.ItemId, ParentTypeId = 2
			};

			context.AccessoryRequiredDtos.Add(accrd);
			context.SaveChanges();

			var ca1 = new CategoryRecordDTO
			{
				EmployeeId = 768,
				ParentTypeId = 2,
				ParentId = comdirve.ItemId
			};
			var ca2 = new CategoryRecordDTO
			{
				EmployeeId = 768,
				ParentTypeId = 2,
				ParentId = comdirve.ItemId
			};
			context.CategoryRecordDtos.Add(ca1);
			context.CategoryRecordDtos.Add(ca2);
			context.SaveChanges();


			var find = context.ComponentDirectiveDtos.Include(i => i.PerformanceRecords)
				.Include(i => i.Kits)
				.Include(i => i.CategoriesRecords).FirstOrDefault(i => i.DirectiveType == 74 && i.NDTType == 52 && i.Remarks == "qwe");

			Assert.IsNotNull(comdirve.DirectiveType);
			Assert.IsNotNull(comdirve.NDTType);
			Assert.IsNotNull(comdirve.ComponentId);
			Assert.AreEqual(comdirve.ComponentId, find.ComponentId);
			Assert.AreEqual(comdirve.NDTType, find.NDTType);
			Assert.AreEqual(comdirve.DirectiveType, find.DirectiveType);
			Assert.IsNotNull(find.PerformanceRecords);
			Assert.AreEqual(find.PerformanceRecords.Count, 2);
			Assert.IsNotNull(find.Kits);
			Assert.AreEqual(find.Kits.Count, 1);
			Assert.IsNotNull(find.CategoriesRecords);
			Assert.AreEqual(find.CategoriesRecords.Count, 2);


			context.ComponentDirectiveDtos.Remove(comdirve);
			context.DirectiveRecordDtos.Remove(d1);
			context.DirectiveRecordDtos.Remove(d2);
			context.AccessoryRequiredDtos.Remove(accrd);
			context.CategoryRecordDtos.Remove(ca1);
			context.CategoryRecordDtos.Remove(ca2);
			context.SaveChanges();

		}

		[TestMethod]
		public void ComponentDTOTest()
		{
			var context = new DataContext();

			var ata = new ATAChapterDTO
			{
				FullName = "test",
				ShortName = "qwe"
			};
			context.ATAChapterDtos.Add(ata);
			context.SaveChanges();

			var adt = new AccessoryDescriptionDTO
			{
				FullName = "testET1",
				DefaultProduct = "dvigatel"
			};

			context.AccessoryDescriptionDtos.Add(adt);
			context.SaveChanges();

			var lon = new LocationDTO
			{
				LocationsTypeId = 0,
				FullName = "testETlon",
				Name = "852",
			};

			context.LocationDtos.Add(lon);
			context.SaveChanges();

			var splr = new SupplierDTO()
			{
				SupplierClassId = 746,
				Remarks = "splrtest"
			};

			context.SupplierDtos.Add(splr);
			context.SaveChanges();

			var comt = new ComponentDTO
			{
				ComponentCount = 63,
				LandingGear = 35,
				ATAChapterId = ata.ItemId,
				ModelId = adt.ItemId,
				LocationId = lon.ItemId,
				FromSupplierId = splr.ItemId,
			};

			context.ComponentDtos.Add(comt);
			context.SaveChanges();

			var ksr1 = new KitSuppliersRelationDTO
			{
				KitId = comt.ItemId,
				ParentTypeId = 5
			};
			var ksr2 = new KitSuppliersRelationDTO
			{
				KitId = comt.ItemId,
				ParentTypeId = 5
			};

			context.KitSuppliersRelationDtos.Add(ksr1);
			context.KitSuppliersRelationDtos.Add(ksr2);
			context.SaveChanges();

			var cmcatdat = new ComponentLLPCategoryDataDTO()
			{
				LLPCategoryId = 87,
				ComponentId = comt.ItemId
			};

			context.ComponentLLPCategoryDataDtos.Add(cmcatdat);
			context.SaveChanges();

			var ca1 = new CategoryRecordDTO
			{
				EmployeeId = 768,
				ParentTypeId = 5,
				ParentId = comt.ItemId
			};
			var ca2 = new CategoryRecordDTO
			{
				EmployeeId = 768,
				ParentTypeId = 5,
				ParentId = comt.ItemId
			};
			context.CategoryRecordDtos.Add(ca1);
			context.CategoryRecordDtos.Add(ca2);
			context.SaveChanges();


			var find = context.ComponentDtos.Include(i => i.ATAChapter)
				.Include(i => i.Model)
				.Include(i => i.FromSupplier)
				.Include(i => i.Location).FirstOrDefault(i => i.ComponentCount == 63 && i.LandingGear == 35);

			Assert.IsNotNull(comt.ComponentCount);
			Assert.IsNotNull(comt.LandingGear);
			Assert.AreEqual(comt.ComponentCount, find.ComponentCount);
			Assert.AreEqual(comt.LandingGear, find.LandingGear);
			Assert.IsNotNull(find.ATAChapter);
			Assert.IsNotNull(find.Model);
			Assert.IsNotNull(find.Location);
			Assert.IsNotNull(find.FromSupplier);
			Assert.IsNotNull(find.SupplierRelations);
			Assert.AreEqual(comt.SupplierRelations.Count, 2);
			Assert.IsNotNull(find.LLPData);
			Assert.AreEqual(comt.LLPData.Count, 1);
			Assert.IsNotNull(find.CategoriesRecords);
			Assert.AreEqual(comt.CategoriesRecords.Count, 2);


			context.ComponentDtos.Remove(comt);
			context.ATAChapterDtos.Remove(ata);
			context.LocationDtos.Remove(lon);
			context.AccessoryDescriptionDtos.Remove(adt);
			context.SupplierDtos.Remove(splr);
			context.KitSuppliersRelationDtos.Remove(ksr1);
			context.KitSuppliersRelationDtos.Remove(ksr2);
			context.ComponentLLPCategoryDataDtos.Remove(cmcatdat);
			context.CategoryRecordDtos.Remove(ca1);
			context.CategoryRecordDtos.Remove(ca2);
			context.SaveChanges();
		}

		[TestMethod]
		public void ComponentLLPCategoryChangeRecordDTOTest()
		{
			var context = new DataContext();

			var cat = new LifeLimitCategorieDTO {CategoryName = "test"};

			context.LifeLimitCategorieDtos.Add(cat);
			context.SaveChanges();

			var comcatcr = new ComponentLLPCategoryChangeRecordDTO()
			{
				ParentId = 29,
				Remarks = "comcatcrtest",
				ToCategoryId = cat.ItemId
			};

			context.ComponentLLPCategoryChangeRecordDtos.Add(comcatcr);
			context.SaveChanges();

			var find = context.ComponentLLPCategoryChangeRecordDtos.Include(i => i.ToCategory).FirstOrDefault(i => i.ParentId == 29 && i.Remarks == "comcatcrtest");

			Assert.IsNotNull(comcatcr.ParentId);
			Assert.AreEqual(comcatcr.ParentId, find.ParentId);
			Assert.AreEqual(comcatcr.Remarks, find.Remarks);
			Assert.IsNotNull(comcatcr.ToCategory);


			context.ComponentLLPCategoryChangeRecordDtos.Remove(comcatcr);
			context.LifeLimitCategorieDtos.Remove(cat);
			context.SaveChanges();
		}

		[TestMethod]
		public void ComponentLLPCategoryDataDTOTest()
		{
			var context = new DataContext();

			var cat = new LifeLimitCategorieDTO { CategoryName = "test" };

			context.LifeLimitCategorieDtos.Add(cat);
			context.SaveChanges();


			var cmcatdat = new ComponentLLPCategoryDataDTO
			{
				LLPCategoryId = cat.ItemId,
				ComponentId = 97
			};

			context.ComponentLLPCategoryDataDtos.Add(cmcatdat);
			context.SaveChanges();

			var find = context.ComponentLLPCategoryDataDtos.Include(i=>i.ParentCategory).FirstOrDefault(i => i.LLPCategoryId == cat.ItemId && i.ComponentId == 97);

			Assert.IsNotNull(cmcatdat.ComponentId);
			Assert.IsNotNull(cmcatdat.LLPCategoryId);
			Assert.AreEqual(cmcatdat.ComponentId, find.ComponentId);
			Assert.AreEqual(cmcatdat.LLPCategoryId, find.LLPCategoryId);
			Assert.IsNotNull(find.ParentCategory);


			context.ComponentLLPCategoryDataDtos.Remove(cmcatdat);
			context.ComponentLLPCategoryDataDtos.Remove(cmcatdat);
			context.SaveChanges();
		}

		[TestMethod]
		public void ComponentOilConditionDTOTest()
		{
			var context = new DataContext();
			var cmpoc = new ComponentOilConditionDTO()
			{
				FlightId = 25,
				Remain = 11
			};

			context.ComponentOilConditionDtos.Add(cmpoc);
			context.SaveChanges();

			var find = context.ComponentOilConditionDtos.FirstOrDefault(i => i.FlightId == 25 && i.Remain == 11);

			Assert.AreEqual(cmpoc.FlightId, find.FlightId);
			Assert.AreEqual(cmpoc.Remain, find.Remain);


			context.ComponentOilConditionDtos.Remove(cmpoc);
			context.SaveChanges();
		}

		[TestMethod]
		public void ComponentWorkInRegimeParamDTOTest()
		{
			var context = new DataContext();
			var cmpwrp = new ComponentWorkInRegimeParamDTO()
			{
				EGTMeasure = 63,
				OilFlowMeasure = 57
			};

			context.ComponentWorkInRegimeParamDtos.Add(cmpwrp);
			context.SaveChanges();

			var find = context.ComponentWorkInRegimeParamDtos.FirstOrDefault(i => i.EGTMeasure == 63 && i.OilFlowMeasure == 57);

			Assert.AreEqual(cmpwrp.EGTMeasure, find.EGTMeasure);
			Assert.AreEqual(cmpwrp.OilFlowMeasure, find.OilFlowMeasure);


			context.ComponentWorkInRegimeParamDtos.Remove(cmpwrp);
			context.SaveChanges();
		}

		[TestMethod]
		public void DamageDocumentDTOTest()
		{
			var context = new DataContext();
			var dmgdoc = new DamageDocumentDTO()
			{
				DamageChartId = 444,
				DamageLocation = "dmgdoctest"
			};

			context.DamageDocumentDtos.Add(dmgdoc);
			context.SaveChanges();

			var find = context.DamageDocumentDtos.FirstOrDefault(i => i.DamageChartId == 444 && i.DamageLocation == "dmgdoctest");

			Assert.AreEqual(dmgdoc.DamageChartId, find.DamageChartId);
			Assert.AreEqual(dmgdoc.DamageLocation, find.DamageLocation);


			context.DamageDocumentDtos.Remove(dmgdoc);
			context.SaveChanges();
		}

		[TestMethod]
		public void DamageSectorDTOTest()
		{
			var context = new DataContext();
			var dmgsec = new DamageSectorDTO()
			{
				DamageChartColumn = 666,
				Remarks = "dmgsectest"
			};

			context.DamageSectorDtos.Add(dmgsec);
			context.SaveChanges();

			var find = context.DamageSectorDtos.FirstOrDefault(i => i.DamageChartColumn == 666 && i.Remarks == "dmgsectest");

			Assert.AreEqual(dmgsec.Remarks, find.Remarks);
			Assert.AreEqual(dmgsec.DamageChartColumn, find.DamageChartColumn);


			context.DamageSectorDtos.Remove(dmgsec);
			context.SaveChanges();
		}

		[TestMethod]
		public void DirectiveDTOTest()
		{
			var context = new DataContext();

			var ata = new ATAChapterDTO
			{
				ShortName = "test",
				FullName = "test"
			};
			context.ATAChapterDtos.Add(ata);
			context.SaveChanges();

			var drct = new DirectiveDTO
			{
				NDTType = 555,
				Remarks = "drcttest",
				ATAChapterId =  ata.ItemId
			};

			context.DirectiveDtos.Add(drct);
			context.SaveChanges();

			var find = context.DirectiveDtos.Include(i => i.ATAChapter).FirstOrDefault(i => i.NDTType == 555 && i.Remarks == "drcttest");

			Assert.IsNotNull(drct.NDTType);
			Assert.IsNotNull(drct.ATAChapter);
			Assert.AreEqual(drct.NDTType, find.NDTType);
			Assert.AreEqual(drct.Remarks, find.Remarks);


			context.DirectiveDtos.Remove(drct);
			context.ATAChapterDtos.Remove(ata);
			context.SaveChanges();
		}

		/*[TestMethod]
		public void DirectiveRecordDTOTest()
		{
			var context = new DataContext();
			var drctrec = new DirectiveRecordDTO()
			{
				RecordTypeID = 458,
				ComplianceCheckName = "drctrectest"
			};

			context.DirectiveRecordDtos.Add(drctrec);
			context.SaveChanges();

			var find = context.DirectiveRecordDtos.FirstOrDefault(i => i.RecordTypeID == 458 && i.ComplianceCheckName == "drctrectest");

			Assert.AreEqual(drctrec.RecordTypeID, find.RecordTypeID);
			Assert.AreEqual(drctrec.ComplianceCheckName, find.ComplianceCheckName);


			context.DirectiveRecordDtos.Remove(drctrec);
			context.SaveChanges();
		}*/

		[TestMethod]
		public void DiscrepancyDTOTest()
		{
			var context = new DataContext();
			var dispcy = new DiscrepancyDTO()
			{
				FlightID = 57,
				FilledBy = true,
				ATAChapterID = 54
			};

			context.DiscrepancyDtos.Add(dispcy);
			context.SaveChanges();

			var find = context.DiscrepancyDtos.FirstOrDefault(i => i.ATAChapterID == 54 && i.FilledBy == true);

			Assert.IsNotNull(dispcy.ATAChapterID);
			Assert.IsNotNull(dispcy.FilledBy);
			Assert.IsNotNull(dispcy.FlightID);
			Assert.AreEqual(dispcy.ATAChapterID, find.ATAChapterID);
			Assert.AreEqual(dispcy.FilledBy, find.FilledBy);
			Assert.AreEqual(dispcy.FlightID, find.FlightID);


			context.DiscrepancyDtos.Remove(dispcy);
			context.SaveChanges();
		}

		[TestMethod]
		public void DocumentDTOTest()
		{
			var context = new DataContext();
			var dcmt = new DocumentDTO()
			{
				DocTypeId = 789,
				ContractNumber = "dcmttest",
				IssueDateValidFrom = DateTime.Today,
				IssueDateValidTo = DateTime.Today,
				RevisionDateFrom = DateTime.Today,
				RevisionDateValidTo = DateTime.Today
				

			};

			context.DocumentDtos.Add(dcmt);
			context.SaveChanges();

			var find = context.DocumentDtos.FirstOrDefault(i => i.DocTypeId == 789 && i.ContractNumber == "dcmttest");

			Assert.IsNotNull(dcmt.DocTypeId);
			Assert.IsNotNull(dcmt.IssueDateValidFrom);
			Assert.IsNotNull(dcmt.IssueDateValidTo);
			Assert.AreEqual(dcmt.DocTypeId, find.DocTypeId);
			Assert.AreEqual(dcmt.IssueDateValidFrom, find.IssueDateValidFrom);
			Assert.AreEqual(dcmt.IssueDateValidTo, find.IssueDateValidTo);
			Assert.AreEqual(dcmt.RevisionDateFrom, find.RevisionDateValidTo);
			Assert.AreEqual(dcmt.RevisionDateValidTo, find.RevisionDateValidTo);
			Assert.AreEqual(dcmt.ContractNumber, find.ContractNumber);


			context.DocumentDtos.Remove(dcmt);
			context.SaveChanges();
		}

		[TestMethod]
		public void EngineAccelerationTimeDTOTest()
		{
			var context = new DataContext();
			var engat = new EngineAccelerationTimeDTO()
			{
				AccelerationTime = 654,
				AccelerationTimeAir = 879
			};

			context.EngineAccelerationTimeDtos.Add(engat);
			context.SaveChanges();

			var find = context.EngineAccelerationTimeDtos.FirstOrDefault(i => i.AccelerationTime == 654 && i.AccelerationTimeAir == 879);

			Assert.AreEqual(engat.AccelerationTime, find.AccelerationTime);
			Assert.AreEqual(engat.AccelerationTimeAir, find.AccelerationTimeAir);


			context.EngineAccelerationTimeDtos.Remove(engat);
			context.SaveChanges();
		}

		[TestMethod]
		public void EngineConditionDTOTest()
		{
			var context = new DataContext();
			var engcond = new EngineConditionDTO()
			{
				FlightID = 741,
				EngineID = 852
			};

			context.EngineConditionDtos.Add(engcond);
			context.SaveChanges();

			var find = context.EngineConditionDtos.FirstOrDefault(i => i.FlightID == 741 && i.EngineID == 852);

			Assert.IsNotNull(engcond.FlightID);
			Assert.IsNotNull(engcond.EngineID);
			Assert.AreEqual(engcond.FlightID, find.FlightID);
			Assert.AreEqual(engcond.EngineID, find.EngineID);


			context.EngineConditionDtos.Remove(engcond);
			context.SaveChanges();
		}

		[TestMethod]
		public void EngineTimeInRegimeDTOTest()
		{
			var context = new DataContext();
			var engtir = new EngineTimeInRegimeDTO()
			{
				EngineId = 368,
				TimeInRegime = 247
			};

			context.EngineTimeInRegimeDtos.Add(engtir);
			context.SaveChanges();

			var find = context.EngineTimeInRegimeDtos.FirstOrDefault(i => i.EngineId == 368 && i.TimeInRegime == 247);

			Assert.AreEqual(engtir.EngineId, find.EngineId);
			Assert.AreEqual(engtir.TimeInRegime, find.TimeInRegime);


			context.EngineTimeInRegimeDtos.Remove(engtir);
			context.SaveChanges();
		}

		[TestMethod]
		public void EventConditionDTOTest()
		{
			var context = new DataContext();
			var evtcond = new EventConditionDTO()
			{
				ParentTypeId = 817,
				ValueId = 957
			};

			context.EventConditionDtos.Add(evtcond);
			context.SaveChanges();

			var find = context.EventConditionDtos.FirstOrDefault(i => i.ParentTypeId == 817 && i.ValueId == 957);

			Assert.AreEqual(evtcond.ParentTypeId, find.ParentTypeId);
			Assert.AreEqual(evtcond.ValueId, find.ValueId);


			context.EventConditionDtos.Remove(evtcond);
			context.SaveChanges();
		}

		[TestMethod]
		public void EventDTOTest()
		{
			var context = new DataContext();
			var evnt = new EventDTO()
			{
				AircraftId = 3248,
				Description = "evnttest"
			};

			context.EventDtos.Add(evnt);
			context.SaveChanges();

			var find = context.EventDtos.FirstOrDefault(i => i.AircraftId == 3248 && i.Description == "evnttest");

			Assert.AreEqual(evnt.AircraftId, find.AircraftId);
			Assert.AreEqual(evnt.Description, find.Description);


			context.EventDtos.Remove(evnt);
			context.SaveChanges();
		}

		[TestMethod]
		public void EventTypeRiskLevelChangeRecordDTOTest()
		{
			var context = new DataContext();
			var evttrlcr = new EventTypeRiskLevelChangeRecordDTO()
			{
				EventClassId = 647,
				Remarks = "evttrlcrtest"
			};

			context.EventTypeRiskLevelChangeRecordDtos.Add(evttrlcr);
			context.SaveChanges();

			var find = context.EventTypeRiskLevelChangeRecordDtos.FirstOrDefault(i => i.EventClassId == 647 && i.Remarks == "evttrlcrtest");

			Assert.AreEqual(evttrlcr.EventClassId, find.EventClassId);
			Assert.AreEqual(evttrlcr.Remarks, find.Remarks);


			context.EventTypeRiskLevelChangeRecordDtos.Remove(evttrlcr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightCargoRecordDTOTest()
		{
			var context = new DataContext();
			var flcr = new FlightCargoRecordDTO()
			{
				Measure = 249,
				CargoCategory = 247
			};

			context.FlightCargoRecordDtos.Add(flcr);
			context.SaveChanges();

			var find = context.FlightCargoRecordDtos.FirstOrDefault(i => i.Measure == 249 && i.CargoCategory == 247);

			Assert.AreEqual(flcr.Measure, find.Measure);
			Assert.AreEqual(flcr.CargoCategory, find.CargoCategory);


			context.FlightCargoRecordDtos.Remove(flcr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightCrewRecordDTOTest()
		{
			var context = new DataContext();
			var flcrrec = new FlightCrewRecordDTO()
			{
				FlightID = 789,
				Limitations = "flcrrectest"
			};

			context.FlightCrewRecordDtos.Add(flcrrec);
			context.SaveChanges();

			var find = context.FlightCrewRecordDtos.FirstOrDefault(i => i.FlightID == 789 && i.Limitations == "flcrrectest");

			Assert.IsNotNull(flcrrec.FlightID);
			Assert.AreEqual(flcrrec.FlightID, find.FlightID);
			Assert.AreEqual(flcrrec.Limitations, find.Limitations);


			context.FlightCrewRecordDtos.Remove(flcrrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightNumberAircraftModelRelationDTOTest()
		{
			var context = new DataContext();
			var flnumamr = new FlightNumberAircraftModelRelationDTO()
			{
				AircraftModelId = 527,
				FlightNumberId = 634
			};

			context.FlightNumberAircraftModelRelationDtos.Add(flnumamr);
			context.SaveChanges();

			var find = context.FlightNumberAircraftModelRelationDtos.FirstOrDefault(i => i.AircraftModelId == 527 && i.FlightNumberId == 634);

			Assert.AreEqual(flnumamr.AircraftModelId, find.AircraftModelId);
			Assert.AreEqual(flnumamr.FlightNumberId, find.FlightNumberId);


			context.FlightNumberAircraftModelRelationDtos.Remove(flnumamr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightNumberAirportRelationDTOTest()
		{
			var context = new DataContext();
			var flnar = new FlightNumberAirportRelationDTO()
			{
				FlightNumberId = 789,
				AirportId = 456
			};

			context.FlightNumberAirportRelationDtos.Add(flnar);
			context.SaveChanges();

			var find = context.FlightNumberAirportRelationDtos.FirstOrDefault(i => i.FlightNumberId == 789 && i.AirportId == 456);

			Assert.AreEqual(flnar.FlightNumberId, find.FlightNumberId);
			Assert.AreEqual(flnar.AirportId, find.AirportId);


			context.FlightNumberAirportRelationDtos.Remove(flnar);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightNumberCrewRecordDTOTest()
		{
			var context = new DataContext();
			var flncr = new FlightNumberCrewRecordDTO()
			{
				FlightNumberId = 174,
				SpecializationId = 285
			};

			context.FlightNumberCrewRecordDtos.Add(flncr);
			context.SaveChanges();

			var find = context.FlightNumberCrewRecordDtos.FirstOrDefault(i => i.FlightNumberId == 174 && i.SpecializationId == 285);

			Assert.AreEqual(flncr.FlightNumberId, find.FlightNumberId);
			Assert.AreEqual(flncr.SpecializationId, find.SpecializationId);


			context.FlightNumberCrewRecordDtos.Remove(flncr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightNumberDTOTest()
		{
			var context = new DataContext();
			var flnum = new FlightNumberDTO()
			{
				Distance = 394,
				Description = "flnumtest",
				FlightNoId = 1
			};

			context.FlightNumberDtos.Add(flnum);
			context.SaveChanges();

			var find = context.FlightNumberDtos.Include(i => i.FlightNo).FirstOrDefault(i => i.Distance == 394 && i.Description == "flnumtest");

			Assert.AreEqual(flnum.Distance, find.Distance);
			Assert.AreEqual(flnum.Description, find.Description);


			context.FlightNumberDtos.Remove(flnum);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightNumberPeriodDTOTest()
		{
			var context = new DataContext();
			var flnumper = new FlightNumberPeriodDTO()
			{
				Schedule = 451,
				PeriodFrom = 222
			};

			context.FlightNumberPeriodDtos.Add(flnumper);
			context.SaveChanges();

			var find = context.FlightNumberPeriodDtos.FirstOrDefault(i => i.Schedule == 451 && i.PeriodFrom == 222);

			Assert.AreEqual(flnumper.Schedule, find.Schedule);
			Assert.AreEqual(flnumper.PeriodFrom, find.PeriodFrom);


			context.FlightNumberPeriodDtos.Remove(flnumper);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightPassengerRecordDTOTest()
		{
			var context = new DataContext();
			var flpasr = new FlightPassengerRecordDTO()
			{
				FlightId = 161,
				PassengerCategoryId = 767
			};

			context.FlightPassengerRecordDtos.Add(flpasr);
			context.SaveChanges();

			var find = context.FlightPassengerRecordDtos.FirstOrDefault(i => i.FlightId == 161 && i.PassengerCategoryId == 767);

			Assert.AreEqual(flpasr.FlightId, find.FlightId);
			Assert.AreEqual(flpasr.PassengerCategory, find.PassengerCategory);


			context.FlightPassengerRecordDtos.Remove(flpasr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightPlanOpsDTOTest()
		{
			var context = new DataContext();
			var flplop = new FlightPlanOpsDTO()
			{
				DateFrom = DateTime.Today,
				Remarks = "flploptest"
			};

			context.FlightPlanOpsDtos.Add(flplop);
			context.SaveChanges();

			var find = context.FlightPlanOpsDtos.FirstOrDefault(i => i.DateFrom == DateTime.Today && i.Remarks == "flploptest");

			Assert.AreEqual(flplop.DateFrom, find.DateFrom);
			Assert.AreEqual(flplop.Remarks, find.Remarks);


			context.FlightPlanOpsDtos.Remove(flplop);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightPlanOpsRecordsDTOTest()
		{
			var context = new DataContext();
			var flpor = new FlightPlanOpsRecordsDTO()
			{
				StatusId = 155,
				HiddenRemarks = "flportest"
			};

			context.FlightPlanOpsRecordsDtos.Add(flpor);
			context.SaveChanges();

			var find = context.FlightPlanOpsRecordsDtos.FirstOrDefault(i => i.StatusId == 155 && i.HiddenRemarks == "flportest");

			Assert.IsNotNull(flpor.StatusId);
			Assert.AreEqual(flpor.StatusId, find.StatusId);
			Assert.AreEqual(flpor.HiddenRemarks, find.HiddenRemarks);


			context.FlightPlanOpsRecordsDtos.Remove(flpor);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightTrackDTOTest()
		{
			var context = new DataContext();
			var fltr = new FlightTrackDTO()
			{
				SupplierID = 998,
				Remarks = "fltrtest"
			};

			context.FlightTrackDtos.Add(fltr);
			context.SaveChanges();

			var find = context.FlightTrackDtos.FirstOrDefault(i => i.SupplierID == 998 && i.Remarks == "fltrtest");

			Assert.IsNotNull(fltr.SupplierID);
			Assert.AreEqual(fltr.Remarks, find.Remarks);
			Assert.AreEqual(fltr.SupplierID, find.SupplierID);
			
			context.FlightTrackDtos.Remove(fltr);
			context.SaveChanges();
		}

		[TestMethod]
		public void FlightTrackRecordDTOTest()
		{
			var context = new DataContext();
			var fltrrd = new FlightTrackRecordDTO()
			{
				FlightPeriodId = 228,
				FlightTripId = 128
			};

			context.FlightTrackRecordDtos.Add(fltrrd);
			context.SaveChanges();

			var find = context.FlightTrackRecordDtos.FirstOrDefault(i => i.FlightPeriodId == 228 && i.FlightTripId == 128);

			Assert.AreEqual(fltrrd.FlightPeriodId, find.FlightPeriodId);
			Assert.AreEqual(fltrrd.FlightTripId, find.FlightTripId);


			context.FlightTrackRecordDtos.Remove(fltrrd);
			context.SaveChanges();
		}

		[TestMethod]
		public void HangarDTOTest()
		{
			var context = new DataContext();
			var hangr = new HangarDTO()
			{
				OperatorId = 337,
				Remarks = "hangrtest"
			};

			context.HangarDtos.Add(hangr);
			context.SaveChanges();

			var find = context.HangarDtos.FirstOrDefault(i => i.OperatorId == 337 && i.Remarks == "hangrtest");

			Assert.AreEqual(hangr.OperatorId, find.OperatorId);
			Assert.AreEqual(hangr.Remarks, find.Remarks);


			context.HangarDtos.Remove(hangr);
			context.SaveChanges();
		}

		[TestMethod]
		public void HydraulicConditionDTOTest()
		{
			var context = new DataContext();
			var hdrcond = new HydraulicConditionDTO()
			{
				FlightId = 878,
				HydraulicSystem = "hdrcondtest"
			};

			context.HydraulicConditionDtos.Add(hdrcond);
			context.SaveChanges();

			var find = context.HydraulicConditionDtos.FirstOrDefault(i => i.FlightId == 878 && i.HydraulicSystem == "hdrcondtest");

			Assert.AreEqual(hdrcond.FlightId, find.FlightId);
			Assert.AreEqual(hdrcond.HydraulicSystem, find.HydraulicSystem);


			context.HydraulicConditionDtos.Remove(hdrcond);
			context.SaveChanges();
		}

		[TestMethod]
		public void InitialOrderDTOTest()
		{
			var context = new DataContext();
			var inor = new InitialOrderDTO()
			{
				ParentId = 788,
				Description = "inortest"
			};

			context.InitialOrderDtos.Add(inor);
			context.SaveChanges();

			var find = context.InitialOrderDtos.FirstOrDefault(i => i.ParentId == 788 && i.Description == "inortest");

			Assert.AreEqual(inor.ParentId, find.ParentId);
			Assert.AreEqual(inor.Description, find.Description);


			context.InitialOrderDtos.Remove(inor);
			context.SaveChanges();
		}

		[TestMethod]
		public void InitialOrderRecordDTOTest()
		{
			var context = new DataContext();
			var inorrec = new InitialOrderRecordDTO()
			{
				Measure = 557,
				ProductId = 556
			};

			context.InitialOrderRecordDtos.Add(inorrec);
			context.SaveChanges();

			var find = context.InitialOrderRecordDtos.FirstOrDefault(i => i.Measure == 557 && i.ProductId == 556);

			Assert.AreEqual(inorrec.Measure, find.Measure);
			Assert.AreEqual(inorrec.ProductId, find.ProductId);


			context.InitialOrderRecordDtos.Remove(inorrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void ItemFileLinkDTOTest()
		{
			var context = new DataContext();
			var itfl = new ItemFileLinkDTO()
			{
				ParentId = 337,
				FileId = 447
			};

			context.ItemFileLinkDtos.Add(itfl);
			context.SaveChanges();

			var find = context.ItemFileLinkDtos.FirstOrDefault(i => i.ParentId == 337 && i.FileId == 447);

			Assert.IsNotNull(itfl.ParentId);
			Assert.AreEqual(itfl.ParentId, find.ParentId);
			Assert.AreEqual(itfl.FileId, find.FileId);


			context.ItemFileLinkDtos.Remove(itfl);
			context.SaveChanges();
		}

		[TestMethod]
		public void ItemsRelationDTOTest()
		{
			var context = new DataContext();
			var itrel = new ItemsRelationDTO()
			{
				FirstItemId = 6678,
				SecondItemId = 5578
			};

			context.ItemsRelationDtos.Add(itrel);
			context.SaveChanges();

			var find = context.ItemsRelationDtos.FirstOrDefault(i => i.FirstItemId == 6678 && i.SecondItemId == 5578);
			
			Assert.IsNotNull(itrel.FirstItemId);
			Assert.IsNotNull(itrel.SecondItemId);
			Assert.AreEqual(itrel.FirstItemId, find.FirstItemId);
			Assert.AreEqual(itrel.SecondItemId, find.SecondItemId);


			context.ItemsRelationDtos.Remove(itrel);
			context.SaveChanges();
		}

		[TestMethod]
		public void JobCardDTOTest()
		{
			var context = new DataContext();
			var jobcrd = new JobCardDTO()
			{
				ParentId = 5522,
				Applicability = "jobcrdtest"
			};

			context.JobCardDtos.Add(jobcrd);
			context.SaveChanges();

			var find = context.JobCardDtos.FirstOrDefault(i => i.ParentId == 5522 && i.Applicability == "jobcrdtest");

			Assert.IsNotNull(jobcrd.ParentId);
			Assert.AreEqual(jobcrd.ParentId, find.ParentId);
			Assert.AreEqual(jobcrd.Applicability, find.Applicability);


			context.JobCardDtos.Remove(jobcrd);
			context.SaveChanges();
		}

		[TestMethod]
		public void JobCardTaskDTOTest()
		{
			var context = new DataContext();
			var jbcrdtsk = new JobCardTaskDTO()
			{
				JobCardId = 818,
				Number = "jbcrdtsktest"
			};

			context.JobCardTaskDtos.Add(jbcrdtsk);
			context.SaveChanges();

			var find = context.JobCardTaskDtos.FirstOrDefault(i => i.JobCardId == 818 && i.Number == "jbcrdtsktest");

			Assert.AreEqual(jbcrdtsk.JobCardId, find.JobCardId);
			Assert.AreEqual(jbcrdtsk.Number, find.Number);


			context.JobCardTaskDtos.Remove(jbcrdtsk);
			context.SaveChanges();
		}

		[TestMethod]
		public void KitSuppliersRelationDTOTest()
		{
			var context = new DataContext();
			var ktsuprel = new KitSuppliersRelationDTO()
			{
				KitId = 364,
				ParentTypeId = 245
			};

			context.KitSuppliersRelationDtos.Add(ktsuprel);
			context.SaveChanges();

			var find = context.KitSuppliersRelationDtos.FirstOrDefault(i => i.KitId == 364 && i.ParentTypeId == 245);

			Assert.AreEqual(ktsuprel.KitId, find.KitId);
			Assert.AreEqual(ktsuprel.ParentTypeId, find.ParentTypeId);


			context.KitSuppliersRelationDtos.Remove(ktsuprel);
			context.SaveChanges();
		}

		[TestMethod]
		public void KnowledgeModuleDTOTest()
		{
			var context = new DataContext();
			var knwmod = new KnowledgeModuleDTO()
			{
				Description = "knwmodtest1",
				Number = "knwmodtest2"
			};

			context.KnowledgeModuleDtos.Add(knwmod);
			context.SaveChanges();

			var find = context.KnowledgeModuleDtos.FirstOrDefault(i => i.Description == "knwmodtest1" && i.Number == "knwmodtest2");

			Assert.AreEqual(knwmod.Description, find.Description);
			Assert.AreEqual(knwmod.Number, find.Number);


			context.KnowledgeModuleDtos.Remove(knwmod);
			context.SaveChanges();
		}

		[TestMethod]
		public void LandingGearConditionDTOTest()
		{
			var context = new DataContext();
			var langc = new LandingGearConditionDTO()
			{
				LandingGearID = 446,
				FlightID = 776
			};

			context.LandingGearConditionDtos.Add(langc);
			context.SaveChanges();

			var find = context.LandingGearConditionDtos.FirstOrDefault(i => i.FlightID == 776 && i.LandingGearID == 446);

			Assert.IsNotNull(langc.FlightID);
			Assert.IsNotNull(langc.LandingGearID);
			Assert.AreEqual(langc.FlightID, find.FlightID);
			Assert.AreEqual(langc.LandingGearID, find.LandingGearID);


			context.LandingGearConditionDtos.Remove(langc);
			context.SaveChanges();
		}

		[TestMethod]
		public void MaintenanceCheckBindTaskRecordDTOTest()
		{
			var context = new DataContext();
			var mcbtr = new MaintenanceCheckBindTaskRecordDTO()
			{
				CheckId = 134,
				TaskTypeId = 142
			};

			context.MaintenanceCheckBindTaskRecordDtos.Add(mcbtr);
			context.SaveChanges();

			var find = context.MaintenanceCheckBindTaskRecordDtos.FirstOrDefault(i => i.CheckId == 134 && i.TaskTypeId == 142);

			Assert.AreEqual(mcbtr.CheckId, find.CheckId);
			Assert.AreEqual(mcbtr.TaskTypeId, find.TaskTypeId);


			context.MaintenanceCheckBindTaskRecordDtos.Remove(mcbtr);
			context.SaveChanges();
		}

		[TestMethod]
		public void MaintenanceCheckDTOTest()
		{
			var context = new DataContext();
			var mtcech = new MaintenanceCheckDTO()
			{
				ParentAircraft = 731,
				CheckTypeId = 152
			};

			context.MaintenanceCheckDtos.Add(mtcech);
			context.SaveChanges();

			var find = context.MaintenanceCheckDtos.FirstOrDefault(i => i.CheckTypeId == 152 && i.ParentAircraft == 731);

			Assert.IsNotNull(mtcech.CheckTypeId);
			Assert.IsNotNull(mtcech.ParentAircraft);
			Assert.AreEqual(mtcech.CheckTypeId, find.CheckTypeId);
			Assert.AreEqual(mtcech.ParentAircraft, find.ParentAircraft);


			context.MaintenanceCheckDtos.Remove(mtcech);
			context.SaveChanges();
		}

		[TestMethod]
		public void MaintenanceCheckTypeDTOTest()
		{
			var context = new DataContext();
			var mtcht = new MaintenanceCheckTypeDTO()
			{
				Priority = 893,
				ShortName = "mtchttest"
			};

			context.MaintenanceCheckTypeDtos.Add(mtcht);
			context.SaveChanges();

			var find = context.MaintenanceCheckTypeDtos.FirstOrDefault(i => i.Priority == 893 && i.ShortName == "mtchttest");

			Assert.AreEqual(mtcht.ShortName, find.ShortName);
			Assert.AreEqual(mtcht.Priority, find.Priority);


			context.MaintenanceCheckTypeDtos.Remove(mtcht);
			context.SaveChanges();
		}

		[TestMethod]
		public void MaintenanceDirectiveDTOTest()
		{
			var context = new DataContext();
			var mtcdir = new MaintenanceDirectiveDTO()
			{
				NDTType = 4327,
				Category = 235
			};

			context.MaintenanceDirectiveDtos.Add(mtcdir);
			context.SaveChanges();

			var find = context.MaintenanceDirectiveDtos.FirstOrDefault(i => i.Category == 235 && i.NDTType == 4327);
			
			Assert.IsNotNull(mtcdir.NDTType);
			Assert.IsNotNull(mtcdir.Category);
			Assert.AreEqual(mtcdir.Category, find.Category);
			Assert.AreEqual(mtcdir.NDTType, find.NDTType);


			context.MaintenanceDirectiveDtos.Remove(mtcdir);
			context.SaveChanges();
		}

		[TestMethod]
		public void MaintenanceProgramChangeRecordDTOTest()
		{
			var context = new DataContext();
			var mtprcgr = new MaintenanceProgramChangeRecordDTO()
			{
				MaintenanceCheckRecordId = 3527,
				Remarks = "mtprcgrtest"
			};

			context.MaintenanceProgramChangeRecordDtos.Add(mtprcgr);
			context.SaveChanges();

			var find = context.MaintenanceProgramChangeRecordDtos.FirstOrDefault(i => i.MaintenanceCheckRecordId == 3527 && i.Remarks == "mtprcgrtest");

			Assert.AreEqual(mtprcgr.MaintenanceCheckRecordId, find.MaintenanceCheckRecordId);
			Assert.AreEqual(mtprcgr.Remarks, find.Remarks);


			context.MaintenanceProgramChangeRecordDtos.Remove(mtprcgr);
			context.SaveChanges();
		}

		[TestMethod]
		public void ModuleRecordDTOTest()
		{
			var context = new DataContext();
			var mdrec = new ModuleRecordDTO()
			{
				KnowledgeLevel = 935,
				AircraftWorkerCategoryId = 612
			};

			context.ModuleRecordDtos.Add(mdrec);
			context.SaveChanges();

			var find = context.ModuleRecordDtos.FirstOrDefault(i => i.AircraftWorkerCategoryId == 612 && i.KnowledgeLevel == 935);

			Assert.AreEqual(mdrec.AircraftWorkerCategoryId, find.AircraftWorkerCategoryId);
			Assert.AreEqual(mdrec.KnowledgeLevel, find.KnowledgeLevel);

			context.ModuleRecordDtos.Remove(mdrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void MTOPCheckDTOTest()
		{
			var context = new DataContext();
			var mtopch = new MTOPCheckDTO()
			{
				ParentAircraftId = 373,
				CheckTypeId = 723
			};

			context.MtopCheckDtos.Add(mtopch);
			context.SaveChanges();

			var find = context.MtopCheckDtos.FirstOrDefault(i => i.ParentAircraftId == 373 && i.CheckTypeId == 723);

			Assert.IsNotNull(mtopch.CheckTypeId);
			Assert.IsNotNull(mtopch.ParentAircraftId);
			Assert.AreEqual(mtopch.CheckTypeId, find.CheckTypeId);
			Assert.AreEqual(mtopch.ParentAircraftId, find.ParentAircraftId);

			context.MtopCheckDtos.Remove(mtopch);
			context.SaveChanges();
		}

		[TestMethod]
		public void MTOPCheckRecordDTOTest()
		{
			var context = new DataContext();
			var mtchrec = new MTOPCheckRecordDTO()
			{
				IsControlPoint = true,
				Remarks = "mtchrectest"
			};

			context.MtopCheckRecordDtos.Add(mtchrec);
			context.SaveChanges();

			var find = context.MtopCheckRecordDtos.FirstOrDefault(i => i.IsControlPoint == true && i.Remarks == "mtchrectest");

			Assert.IsNotNull(mtchrec.IsControlPoint);
			Assert.AreEqual(mtchrec.IsControlPoint, find.IsControlPoint);
			Assert.AreEqual(mtchrec.Remarks, find.Remarks);

			context.MtopCheckRecordDtos.Remove(mtchrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void ProcedureDocumentReferenceDTOTest()
		{
			var context = new DataContext();
			var prdcr = new ProcedureDocumentReferenceDTO()
			{
				DocumentId = 346,
				ProcedureId = 215
			};

			context.ProcedureDocumentReferenceDtos.Add(prdcr);
			context.SaveChanges();

			var find = context.ProcedureDocumentReferenceDtos.FirstOrDefault(i => i.ProcedureId == 215 && i.DocumentId == 346);

			Assert.AreEqual(prdcr.DocumentId, find.DocumentId);
			Assert.AreEqual(prdcr.ProcedureId, find.ProcedureId);


			context.ProcedureDocumentReferenceDtos.Remove(prdcr);
			context.SaveChanges();
		}

		[TestMethod]
		public void ProcedureDTOTest()
		{
			var context = new DataContext();
			var prcd = new ProcedureDTO()
			{
				AuditedObjectId = 143,
				Description = "prcdtest"
			};

			context.ProcedureDtos.Add(prcd);
			context.SaveChanges();

			var find = context.ProcedureDtos.FirstOrDefault(i => i.AuditedObjectId == 143 && i.Description == "prcdtest");

			Assert.AreEqual(prcd.AuditedObjectId, find.AuditedObjectId);
			Assert.AreEqual(prcd.Description, find.Description);


			context.ProcedureDtos.Remove(prcd);
			context.SaveChanges();
		}

		[TestMethod]
		public void ProductCostDTOTest()
		{
			var context = new DataContext();
			var prcdct = new ProductCostDTO()
			{
				CurrencyId = 61,
				SupplierId = 21
			};

			context.ProductCostDtos.Add(prcdct);
			context.SaveChanges();

			var find = context.ProductCostDtos.FirstOrDefault(i => i.CurrencyId == 61 && i.SupplierId == 21);

			Assert.AreEqual(prcdct.CurrencyId, find.CurrencyId);
			Assert.AreEqual(prcdct.SupplierId, find.SupplierId);


			context.ProductCostDtos.Remove(prcdct);
			context.SaveChanges();
		}

		[TestMethod]
		public void PurchaseOrderDTOTest()
		{
			var context = new DataContext();
			var prcor = new PurchaseOrderDTO()
			{
				SupplierId = 1733,
				Author = "prcortest"
			};

			context.PurchaseOrderDtos.Add(prcor);
			context.SaveChanges();

			var find = context.PurchaseOrderDtos.FirstOrDefault(i => i.SupplierId == 1733 && i.Author == "prcortest");

			Assert.AreEqual(prcor.Author, find.Author);
			Assert.AreEqual(prcor.SupplierId, find.SupplierId);


			context.PurchaseOrderDtos.Remove(prcor);
			context.SaveChanges();
		}

		[TestMethod]
		public void PurchaseRequestRecordDTOTest()
		{
			var context = new DataContext();
			var phrrd = new PurchaseRequestRecordDTO()
			{
				Measure = 723,
				Remarks = "phrrdtest"
			};

			context.PurchaseRequestRecordDtos.Add(phrrd);
			context.SaveChanges();

			var find = context.PurchaseRequestRecordDtos.FirstOrDefault(i => i.Measure == 723 && i.Remarks == "phrrdtest");

			Assert.AreEqual(phrrd.Measure, find.Measure);
			Assert.AreEqual(phrrd.Remarks, find.Remarks);


			context.PurchaseRequestRecordDtos.Remove(phrrd);
			context.SaveChanges();
		}

		[TestMethod]
		public void RequestDTOTest()
		{
			var context = new DataContext();
			var rqt = new RequestDTO()
			{
				ApprovedById = 473,
				ClosedBy = "rqttest"
			};

			context.RequestDtos.Add(rqt);
			context.SaveChanges();

			var find = context.RequestDtos.FirstOrDefault(i => i.ApprovedById == 473 && i.ClosedBy == "rqttest");

			Assert.AreEqual(rqt.ApprovedById, find.ApprovedById);
			Assert.AreEqual(rqt.ClosedBy, find.ClosedBy);


			context.RequestDtos.Remove(rqt);
			context.SaveChanges();
		}

		[TestMethod]
		public void RequestForQuotationDTOTest()
		{
			var context = new DataContext();
			var reqfquot = new RequestForQuotationDTO()
			{
				Remarks = "reqfquottest"
			};

			context.RequestForQuotationDtos.Add(reqfquot);
			context.SaveChanges();

			var find = context.RequestForQuotationDtos.FirstOrDefault(i => i.Remarks == "reqfquottest");

			Assert.AreEqual(reqfquot.Remarks, find.Remarks);


			context.RequestForQuotationDtos.Remove(reqfquot);
			context.SaveChanges();
		}

		[TestMethod]
		public void RequestForQuotationRecordDTOTest()
		{
			var context = new DataContext();
			var rqfqotrec = new RequestForQuotationRecordDTO()
			{
				ParentPackageId = 754,
				PackageItemId = 345
			};

			context.RequestForQuotationRecordDtos.Add(rqfqotrec);
			context.SaveChanges();

			var find = context.RequestForQuotationRecordDtos.FirstOrDefault(i => i.ParentPackageId == 754 && i.PackageItemId == 345);

			Assert.IsNotNull(rqfqotrec.PackageItemId);
			Assert.IsNotNull(rqfqotrec.ParentPackageId);
			Assert.AreEqual(rqfqotrec.PackageItemId, find.PackageItemId);
			Assert.AreEqual(rqfqotrec.ParentPackageId, find.ParentPackageId);


			context.RequestForQuotationRecordDtos.Remove(rqfqotrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void RequestRecordDTOTest()
		{
			var context = new DataContext();
			var reqrec = new RequestRecordDTO()
			{
				DirectivesId = 436,
				ParentId = 125
			};

			context.RequestRecordDtos.Add(reqrec);
			context.SaveChanges();

			var find = context.RequestRecordDtos.FirstOrDefault(i => i.DirectivesId == 436 && i.ParentId == 125);

			Assert.AreEqual(reqrec.DirectivesId, find.DirectivesId);
			Assert.AreEqual(reqrec.ParentId, find.ParentId);


			context.RequestRecordDtos.Remove(reqrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void RunUpDTOTest()
		{
			var context = new DataContext();
			var rnup = new AccessoryRequiredDTO()
			{
				ParentId = 724,
				PartNumber = "rnuptest"
			};

			context.AccessoryRequiredDtos.Add(rnup);
			context.SaveChanges();

			var find = context.AccessoryRequiredDtos.FirstOrDefault(i => i.ParentId == 724 && i.PartNumber == "rnuptest");

			Assert.AreEqual(rnup.ParentId, find.ParentId);
			Assert.AreEqual(rnup.PartNumber, find.PartNumber);


			context.AccessoryRequiredDtos.Remove(rnup);
			context.SaveChanges();
		}

		[TestMethod]
		public void SmsEventTypeDTOTest()
		{
			var context = new DataContext();
			var smset = new SmsEventTypeDTO()
			{
				Description = "smsettest1",
				FullName = "smsettest2"
			};

			context.SmsEventTypeDtos.Add(smset);
			context.SaveChanges();

			var find = context.SmsEventTypeDtos.FirstOrDefault(i => i.Description == "smsettest1" && i.FullName == "smsettest2");

			Assert.AreEqual(smset.FullName, find.FullName);
			Assert.AreEqual(smset.Description, find.Description);


			context.SmsEventTypeDtos.Remove(smset);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistCAADTOTest()
		{
			var context = new DataContext();
			var speccaa = new SpecialistCAADTO()
			{
				CAAId = 234,
				CAAType = 521,
				IssueDate = DateTime.Today,
				ValidTo = DateTime.Today
			};

			context.SpecialistCaadtos.Add(speccaa);
			context.SaveChanges();

			var find = context.SpecialistCaadtos.FirstOrDefault(i => i.CAAId == 234 && i.CAAType == 521);

			Assert.IsNotNull(speccaa.CAAId);
			Assert.IsNotNull(speccaa.CAAType);
			Assert.IsNotNull(speccaa.ValidTo);
			Assert.AreEqual(speccaa.CAAId, find.CAAId);
			Assert.AreEqual(speccaa.ValidTo, find.ValidTo);
			Assert.AreEqual(speccaa.IssueDate, find.IssueDate);
			Assert.AreEqual(speccaa.CAAType, find.CAAType);


			context.SpecialistCaadtos.Remove(speccaa);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistDTOTest()
		{
			var context = new DataContext();
			var spect = new SpecialistDTO()
			{
				SpecializationID = 2157,
				Address = "specttest"
			};

			context.SpecialistDtos.Add(spect);
			context.SaveChanges();

			var find = context.SpecialistDtos.FirstOrDefault(i => i.SpecializationID == 2157 && i.Address == "specttest");

			Assert.IsNotNull(spect.SpecializationID);
			Assert.AreEqual(spect.Address, find.Address);
			Assert.AreEqual(spect.SpecializationID, find.SpecializationID);


			context.SpecialistDtos.Remove(spect);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistInstrumentRatingDTOTest()
		{
			var context = new DataContext();
			var spinsrat = new SpecialistInstrumentRatingDTO()
			{
				MC = 623,
				MV = 348,
				IssueDate = DateTime.Today
			};

			context.SpecialistInstrumentRatingDtos.Add(spinsrat);
			context.SaveChanges();

			var find = context.SpecialistInstrumentRatingDtos.FirstOrDefault(i => i.MC == 623 && i.MV == 348);

			Assert.IsNotNull(spinsrat.MC);
			Assert.IsNotNull(spinsrat.MV);
			Assert.IsNotNull(spinsrat.IssueDate);
			Assert.AreEqual(spinsrat.MC, find.MC);
			Assert.AreEqual(spinsrat.MV, find.MV);
			Assert.AreEqual(spinsrat.IssueDate, find.IssueDate);


			context.SpecialistInstrumentRatingDtos.Remove(spinsrat);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistLicenseDetailDTOTest()
		{
			var context = new DataContext();
			var splicdet = new SpecialistLicenseDetailDTO()
			{
				SpecialistId = 521,
				Description = "splicdettest",
				IssueDate = DateTime.Today
			};

			context.SpecialistLicenseDetailDtos.Add(splicdet);
			context.SaveChanges();

			var find = context.SpecialistLicenseDetailDtos.FirstOrDefault(i => i.SpecialistId == 521 && i.Description == "splicdettest");

			Assert.IsNotNull(splicdet.SpecialistId);
			Assert.IsNotNull(splicdet.IssueDate);
			Assert.AreEqual(splicdet.Description, find.Description);
			Assert.AreEqual(splicdet.IssueDate, find.IssueDate);
			Assert.AreEqual(splicdet.SpecialistId, find.SpecialistId);


			context.SpecialistLicenseDetailDtos.Remove(splicdet);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistLicenseDTOTest()
		{
			var context = new DataContext();
			var spclic = new SpecialistLicenseDTO()
			{
				LicenseTypeID = 163,
				AircraftTypeID = 173
			};

			context.SpecialistLicenseDtos.Add(spclic);
			context.SaveChanges();

			var find = context.SpecialistLicenseDtos.FirstOrDefault(i => i.LicenseTypeID == 163 && i.AircraftTypeID == 173);

			Assert.IsNotNull(spclic.AircraftTypeID);
			Assert.IsNotNull(spclic.LicenseTypeID);
			Assert.AreEqual(spclic.AircraftTypeID, find.AircraftTypeID);
			Assert.AreEqual(spclic.LicenseTypeID, find.LicenseTypeID);


			context.SpecialistLicenseDtos.Remove(spclic);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistLicenseRatingDTOTest()
		{
			var context = new DataContext();
			var spclicrat = new SpecialistLicenseRatingDTO()
			{
				SpecialistLicenseId = 187,
				FunctionId = 521,
				IssueDate = DateTime.Today
			};

			context.SpecialistLicenseRatingDtos.Add(spclicrat);
			context.SaveChanges();

			var find = context.SpecialistLicenseRatingDtos.FirstOrDefault(i => i.SpecialistLicenseId == 187 && i.FunctionId == 521);

			Assert.IsNotNull(spclicrat.FunctionId);
			Assert.IsNotNull(spclicrat.IssueDate);
			Assert.IsNotNull(spclicrat.SpecialistLicenseId);
			Assert.AreEqual(spclicrat.FunctionId, find.FunctionId);
			Assert.AreEqual(spclicrat.IssueDate, find.IssueDate);
			Assert.AreEqual(spclicrat.SpecialistLicenseId, find.SpecialistLicenseId);


			context.SpecialistLicenseRatingDtos.Remove(spclicrat);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistLicenseRemarkDTOTest()
		{
			var context = new DataContext();
			var spclicrem = new SpecialistLicenseRemarkDTO()
			{
				SpecialistLicenseId = 568,
				RestrictionId = 734,
				IssueDate = DateTime.Today
			};

			context.SpecialistLicenseRemarkDtos.Add(spclicrem);
			context.SaveChanges();

			var find = context.SpecialistLicenseRemarkDtos.FirstOrDefault(i => i.SpecialistLicenseId == 568 && i.RestrictionId == 734);

			Assert.IsNotNull(spclicrem.RestrictionId);
			Assert.IsNotNull(spclicrem.IssueDate);
			Assert.IsNotNull(spclicrem.SpecialistLicenseId);
			Assert.AreEqual(spclicrem.RestrictionId, find.RestrictionId);
			Assert.AreEqual(spclicrem.IssueDate, find.IssueDate);
			Assert.AreEqual(spclicrem.SpecialistLicenseId, find.SpecialistLicenseId);


			context.SpecialistLicenseRemarkDtos.Remove(spclicrem);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistMedicalRecordDTOTest()
		{
			var context = new DataContext();
			var spcmedrec = new SpecialistMedicalRecordDTO()
			{
				IssueDate = DateTime.Today,
				Remarks = "spcmedrectest"
			};

			context.SpecialistMedicalRecordDtos.Add(spcmedrec);
			context.SaveChanges();

			var find = context.SpecialistMedicalRecordDtos.FirstOrDefault(i => i.IssueDate == DateTime.Today && i.Remarks == "spcmedrectest");

			Assert.IsNotNull(spcmedrec.IssueDate);
			Assert.AreEqual(spcmedrec.IssueDate, find.IssueDate);
			Assert.AreEqual(spcmedrec.Remarks, find.Remarks);


			context.SpecialistMedicalRecordDtos.Remove(spcmedrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void SpecialistTrainingDTOTest()
		{
			var context = new DataContext();
			var spctrg = new SpecialistTrainingDTO()
			{
				SpecialistId = 215,
				AircraftTypeID = 1236
			};

			context.SpecialistTrainingDtos.Add(spctrg);
			context.SaveChanges();

			var find = context.SpecialistTrainingDtos.FirstOrDefault(i => i.SpecialistId == 215 && i.AircraftTypeID == 1236);

			Assert.IsNotNull(spctrg.AircraftTypeID);
			Assert.IsNotNull(spctrg.SpecialistId);
			Assert.AreEqual(spctrg.AircraftTypeID, find.AircraftTypeID);
			Assert.AreEqual(spctrg.SpecialistId, find.SpecialistId);


			context.SpecialistTrainingDtos.Remove(spctrg);
			context.SaveChanges();
		}

		[TestMethod]
		public void StockComponentInfoDTOTest()
		{
			var context = new DataContext();
			var stccominf = new StockComponentInfoDTO()
			{
				Amount = 742,
				Description = "stccominftest"
			};

			context.StockComponentInfoDtos.Add(stccominf);
			context.SaveChanges();

			var find = context.StockComponentInfoDtos.FirstOrDefault(i => i.Amount == 742 && i.Description == "stccominftest");

			Assert.IsNotNull(stccominf.Amount);
			Assert.AreEqual(stccominf.Amount, find.Amount);
			Assert.AreEqual(stccominf.Description, find.Description);


			context.StockComponentInfoDtos.Remove(stccominf);
			context.SaveChanges();
		}

		[TestMethod]
		public void StoreDTOTest()
		{
			var context = new DataContext();
			var str = new StoreDTO()
			{
				OperatorID = 7325,
				Remarks = "strtest"
			};

			context.StoreDtos.Add(str);
			context.SaveChanges();

			var find = context.StoreDtos.FirstOrDefault(i => i.OperatorID == 7325 && i.Remarks == "strtest");

			Assert.IsNotNull(str.OperatorID);
			Assert.AreEqual(str.OperatorID, find.OperatorID);
			Assert.AreEqual(str.Remarks, find.Remarks);


			context.StoreDtos.Remove(str);
			context.SaveChanges();
		}

		[TestMethod]
		public void SupplierDocumentDTOTest()
		{
			var context = new DataContext();
			var spdoc = new SupplierDocumentDTO()
			{
				FileId = 162,
				Name = "spdoctest"
			};

			context.SupplierDocumentDtos.Add(spdoc);
			context.SaveChanges();

			var find = context.SupplierDocumentDtos.FirstOrDefault(i => i.FileId == 162 && i.Name == "spdoctest");

			Assert.AreEqual(spdoc.Name, find.Name);
			Assert.AreEqual(spdoc.FileId, find.FileId);


			context.SupplierDocumentDtos.Remove(spdoc);
			context.SaveChanges();
		}

		[TestMethod]
		public void SupplierDTOTest()
		{
			var context = new DataContext();
			var splr = new SupplierDTO()
			{
				SupplierClassId = 746,
				Remarks = "splrtest"
			};

			context.SupplierDtos.Add(splr);
			context.SaveChanges();

			var find = context.SupplierDtos.FirstOrDefault(i => i.SupplierClassId == 746 && i.Remarks == "splrtest");

			Assert.IsNotNull(splr.SupplierClassId);
			Assert.AreEqual(splr.Remarks, find.Remarks);
			Assert.AreEqual(splr.SupplierClassId, find.SupplierClassId);


			context.SupplierDtos.Remove(splr);
			context.SaveChanges();
		}

		[TestMethod]
		public void TransferRecordDTOTest()
		{
			var context = new DataContext();
			var trfrec = new TransferRecordDTO()
			{
				FromStoreID = 273,
				Description = "trfrectest"
			};

			context.TransferRecordDtos.Add(trfrec);
			context.SaveChanges();

			var find = context.TransferRecordDtos.FirstOrDefault(i => i.FromStoreID == 273 && i.Description == "trfrectest");

			Assert.IsNotNull(trfrec.FromStoreID);
			Assert.AreEqual(trfrec.FromStoreID, find.FromStoreID);
			Assert.AreEqual(trfrec.Description, find.Description);


			context.TransferRecordDtos.Remove(trfrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void VehicleDTOTest()
		{
			var context = new DataContext();
			var vhle = new VehicleDTO()
			{
				OperatorId = 724,
				Owner = "vhletest"
			};

			context.VehicleDtos.Add(vhle);
			context.SaveChanges();

			var find = context.VehicleDtos.FirstOrDefault(i => i.OperatorId == 724 && i.Owner == "vhletest");

			Assert.AreEqual(vhle.OperatorId, find.OperatorId);
			Assert.AreEqual(vhle.Owner, find.Owner);


			context.VehicleDtos.Remove(vhle);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkOrderDTOTest()
		{
			var context = new DataContext();
			var wrkor = new WorkOrderDTO()
			{
				ApprovedById = 7234,
				ClosingRemarks = "wrkortest"
			};

			context.WorkOrderDtos.Add(wrkor);
			context.SaveChanges();

			var find = context.WorkOrderDtos.FirstOrDefault(i => i.ApprovedById == 7234 && i.ClosingRemarks == "wrkortest");

			Assert.AreEqual(wrkor.ApprovedById, find.ApprovedById);
			Assert.AreEqual(wrkor.ClosingRemarks, find.ClosingRemarks);


			context.WorkOrderDtos.Remove(wrkor);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkOrderRecordDTOTest()
		{
			var context = new DataContext();
			var wrkorrec = new WorkOrderRecordDTO()
			{
				DirectivesId = 5754,
				ParentId = 124
			};

			context.WorkOrderRecordDtos.Add(wrkorrec);
			context.SaveChanges();

			var find = context.WorkOrderRecordDtos.FirstOrDefault(i => i.DirectivesId == 5754 && i.ParentId == 124);

			Assert.AreEqual(wrkorrec.DirectivesId, find.DirectivesId);
			Assert.AreEqual(wrkorrec.ParentId, find.ParentId);


			context.WorkOrderRecordDtos.Remove(wrkorrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkPackageDTOTest()
		{
			var context = new DataContext();
			var wrkpac = new WorkPackageDTO()
			{
				Status = 347,
				Author = "wrkpactest",
				OpeningDate = DateTime.Today,
				ClosingRemarks = "closingremarkstest"
			};

			context.WorkPackageDtos.Add(wrkpac);
			context.SaveChanges();

			var find = context.WorkPackageDtos.FirstOrDefault(i => i.Status == 347 && i.Author == "wrkpactest");

			Assert.IsNotNull(wrkpac.Status);
			Assert.IsNotNull(wrkpac.OpeningDate);
			Assert.IsNotNull(wrkpac.ClosingRemarks);
			Assert.AreEqual(wrkpac.Author, find.Author);
			Assert.AreEqual(wrkpac.OpeningDate, find.OpeningDate);
			Assert.AreEqual(wrkpac.Status, find.Status);
			Assert.AreEqual(wrkpac.ClosingRemarks, find.ClosingRemarks);


			context.WorkPackageDtos.Remove(wrkpac);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkPackageRecordDTOTest()
		{
			var context = new DataContext();
			var wrkpacrec = new WorkPackageRecordDTO()
			{
				DirectivesId = 474,
				JobCardNumber = "wrkpacrectest"
			};

			context.WorkPackageRecordDtos.Add(wrkpacrec);
			context.SaveChanges();

			var find = context.WorkPackageRecordDtos.FirstOrDefault(i => i.DirectivesId == 474 && i.JobCardNumber == "wrkpacrectest");

			Assert.AreEqual(wrkpacrec.DirectivesId, find.DirectivesId);
			Assert.AreEqual(wrkpacrec.JobCardNumber, find.JobCardNumber);


			context.WorkPackageRecordDtos.Remove(wrkpacrec);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkPackageSpecialistsDTOTest()
		{
			var context = new DataContext();
			var wrlspelist = new WorkPackageSpecialistsDTO()
			{
				SpecialistId = 765,
				WorkPackageId = 643
			};

			context.WorkPackageSpecialistsDtos.Add(wrlspelist);
			context.SaveChanges();

			var find = context.WorkPackageSpecialistsDtos.FirstOrDefault(i => i.SpecialistId == 765 && i.WorkPackageId == 643);

			Assert.IsNotNull(wrlspelist.SpecialistId);
			Assert.IsNotNull(wrlspelist.WorkPackageId);
			Assert.AreEqual(wrlspelist.SpecialistId, find.SpecialistId);
			Assert.AreEqual(wrlspelist.WorkPackageId, find.WorkPackageId);


			context.WorkPackageSpecialistsDtos.Remove(wrlspelist);
			context.SaveChanges();
		}

		[TestMethod]
		public void WorkShopDTOTest()
		{
			var context = new DataContext();
			var wrkshp = new WorkShopDTO()
			{
				OperatorId = 941,
				Location = "wrkshptest"
			};

			context.WorkShopDtos.Add(wrkshp);
			context.SaveChanges();

			var find = context.WorkShopDtos.FirstOrDefault(i => i.OperatorId == 941 && i.Location == "wrkshptest");

			Assert.AreEqual(wrkshp.OperatorId, find.OperatorId);
			Assert.AreEqual(wrkshp.Location, find.Location);


			context.WorkShopDtos.Remove(wrkshp);
			context.SaveChanges();
		}

	}
}

