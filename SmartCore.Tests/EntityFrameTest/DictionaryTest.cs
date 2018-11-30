using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class DictionaryTest
	{
		[TestMethod]
		public void NonRoutineJobDTOTest()
		{
			var context = new DataContext();
			var newAtaChapter = new ATAChapterDTO
			{
				FullName = "Test",
				ShortName = "Test"
			};

			context.ATAChapterDtos.Add(newAtaChapter);
			context.SaveChanges();

			var nrj = new NonRoutineJobDTO()
			{
				ATAChapterId = newAtaChapter.ItemId,
				Cost = 10,
				Title = "NRJTest"
			};

			context.NonRoutineJobDtos.Add(nrj);
			context.SaveChanges();

			var find = context.NonRoutineJobDtos.Include(i => i.ATAChapter).FirstOrDefault(i => i.ATAChapterId == newAtaChapter.ItemId && i.Title == "NRJTest");

			Assert.IsNotNull(nrj.ATAChapter);
			Assert.AreEqual(nrj.ATAChapter.ShortName, "Test");
			Assert.AreEqual(nrj.Title, find.Title);
			Assert.AreEqual(nrj.ATAChapterId, find.ATAChapterId);
			Assert.AreEqual(nrj.Cost, find.Cost);

			context.NonRoutineJobDtos.Remove(nrj);
			context.ATAChapterDtos.Remove(newAtaChapter);
			context.SaveChanges();

		}

		[TestMethod]
		public void AccessoryDescriptionDTOTest()
		{
			var context = new DataContext();

			var newAtaChapter = new ATAChapterDTO
			{
				FullName = "Test",
				ShortName = "Test"
			};

			context.ATAChapterDtos.Add(newAtaChapter);
			context.SaveChanges();

			var newStandatr = new GoodStandartDTO
			{
				Name = "123"
			};

			context.GoodStandartDtos.Add(newStandatr);
			context.SaveChanges();

			var adt = new AccessoryDescriptionDTO
			{
				AtaChapterId = newAtaChapter.ItemId,
				StandartId = newStandatr.ItemId,
				FullName = "testET1",
				DefaultProduct = "dvigatel"
			};

			context.AccessoryDescriptionDtos.Add(adt);
			context.SaveChanges();

			var find = context.AccessoryDescriptionDtos.Include(i => i.ATAChapter).FirstOrDefault(i => i.AtaChapterId == newAtaChapter.ItemId && i.FullName == "testET1");

			Assert.IsNotNull(adt.ATAChapter);
			Assert.IsNotNull(adt.GoodStandart);
			Assert.AreEqual(adt.ATAChapter.ShortName, "Test");
			Assert.AreEqual(adt.GoodStandart.Name, "123");
			Assert.AreEqual(adt.FullName, find.FullName);
			Assert.AreEqual(adt.DefaultProduct, find.DefaultProduct);

			context.AccessoryDescriptionDtos.Remove(adt);
			context.ATAChapterDtos.Remove(newAtaChapter);
			context.GoodStandartDtos.Remove(newStandatr);
			context.SaveChanges();
		}

		[TestMethod]
		public void AGWCategorieDTOTest()
		{
			var context = new DataContext();
			var tagwcat = new AGWCategorieDTO
			{
				MaxAge = 123,
				FullName = "testET123",
				WeightWinter = 789
			};

			context.AGWCategorieDtos.Add(tagwcat);
			context.SaveChanges();

			var find = context.AGWCategorieDtos.FirstOrDefault(i => i.MaxAge == 123 && i.FullName == "testET123");

			Assert.AreEqual(tagwcat.MaxAge, find.MaxAge);
			Assert.AreEqual(tagwcat.FullName, find.FullName);
			Assert.AreEqual(tagwcat.WeightWinter, find.WeightWinter);

			context.AGWCategorieDtos.Remove(tagwcat);
			context.SaveChanges();
		}

		[TestMethod]
		public void AircraftOtherParameterDTOTest()
		{
			var context = new DataContext();
			var aop = new AircraftOtherParameterDTO
			{
				Name = "TestETqwe",
				FullName = "testETasd",
			};

			context.AircraftOtherParameterDtos.Add(aop);
			context.SaveChanges();

			var find = context.AircraftOtherParameterDtos.FirstOrDefault(i =>
				i.Name == "TestETqwe" && i.FullName == "testETasd");

			Assert.AreEqual(aop.Name, find.Name);
			Assert.AreEqual(aop.FullName, find.FullName);

			context.AircraftOtherParameterDtos.Remove(aop);
			context.SaveChanges();
		}

		[TestMethod]
		public void AirportCodeDTOTest()
		{
			var context = new DataContext();
			var atc = new AirportCodeDTO()
			{
				Country = "TestETKyrg",
				FullName = "testETVadya",
				City = "testBiishh",
			};

			context.AirportCodeDtos.Add(atc);
			context.SaveChanges();

			var find = context.AirportCodeDtos.FirstOrDefault(i => i.Country == "TestETKyrg" && i.FullName == "testETVadya");

			Assert.AreEqual(atc.Country, find.Country);
			Assert.AreEqual(atc.FullName, find.FullName);

			context.AirportCodeDtos.Remove(atc);
			context.SaveChanges();

		}

		[TestMethod]
		public void ATAChapterDTOTest()
		{
			var context = new DataContext();
			var atcp = new ATAChapterDTO
			{
				FullName = "testETatachapt",
				ShortName = "testETatcp",
			};

			context.ATAChapterDtos.Add(atcp);
			context.SaveChanges();

			var find = context.ATAChapterDtos.FirstOrDefault(i => i.ShortName == "testETatcp" && i.FullName == "testETatachapt");

			Assert.AreEqual(atcp.ShortName, find.ShortName);
			Assert.AreEqual(atcp.FullName, find.FullName);

			context.ATAChapterDtos.Remove(atcp);
			context.SaveChanges();

		}

		[TestMethod]
		public void CruiseLevelDTOTest()
		{
			var context = new DataContext();
			var crl = new CruiseLevelDTO()
			{
				FullName = "testETcrl",
				Track = "crt",
			};

			context.CruiseLevelDtos.Add(crl);
			context.SaveChanges();

			var find = context.CruiseLevelDtos.FirstOrDefault(i => i.FullName == "testETcrl" && i.Track == "crt");

			Assert.AreEqual(crl.FullName, find.FullName);
			Assert.AreEqual(crl.Track, find.Track);

			context.CruiseLevelDtos.Remove(crl);
			context.SaveChanges();

		}

		[TestMethod]
		public void DamageChartDTOTest()
		{
			var context = new DataContext();

			var newAccessoryDescription = new AccessoryDescriptionDTO()
			{
				 Model = "testdmg",
			};
			context.AccessoryDescriptionDtos.Add(newAccessoryDescription);
			context.SaveChanges();

			var dgc = new DamageChartDTO()
			{
				AircraftModelId = newAccessoryDescription.ItemId,
				ChartName = "6666",
			};

			context.DamageChartDtos.Add(dgc);
			context.SaveChanges();

			var find = context.DamageChartDtos.Include(i => i.AccessoryDescription).FirstOrDefault(i => i.ItemId == newAccessoryDescription.ItemId && i.ChartName == "6666");

			Assert.IsNotNull(dgc.AccessoryDescription);
			Assert.AreEqual(dgc.AccessoryDescription.Model, "testdmg");
			Assert.AreEqual(dgc.ChartName, "6666");
			
			context.DamageChartDtos.Remove(dgc);
			context.AccessoryDescriptionDtos.Remove(newAccessoryDescription);
			context.SaveChanges();

		}

		[TestMethod]
		public void DefferedCategorieDTOTest()
		{
			var context = new DataContext();
			var newAccessoryDescription = new AccessoryDescriptionDTO()
			{
				Model = "testdfc",
			};
			context.AccessoryDescriptionDtos.Add(newAccessoryDescription);
			context.SaveChanges();

			var dfc = new DefferedCategorieDTO()
			{
				AircraftModelId = newAccessoryDescription.ItemId,
				CategoryName = "testETdfc",
			};

			context.DefferedCategorieDtos.Add(dfc);
			context.SaveChanges();

			var find = context.DefferedCategorieDtos.Include(i => i.AccessoryDescription).FirstOrDefault(i => i.AircraftModelId == newAccessoryDescription.ItemId && i.CategoryName == "testETdfc");
			
			Assert.IsNotNull(dfc.AccessoryDescription);
			Assert.AreEqual(dfc.AccessoryDescription.Model, "testdfc");
			Assert.AreEqual(dfc.CategoryName, find.CategoryName);
			
			context.DefferedCategorieDtos.Remove(dfc);
			context.AccessoryDescriptionDtos.Remove(newAccessoryDescription);
			context.SaveChanges();

		}

		[TestMethod]
		public void DepartmentDTOTest()
		{
			var context = new DataContext();
			var det = new DepartmentDTO()
			{
				FullName = "testETdet",
				Name = "testd",
			};

			context.DepartmentDtos.Add(det);
			context.SaveChanges();

			var find = context.DepartmentDtos.FirstOrDefault(i => i.FullName == "testETdet" && i.Name == "testd");

			Assert.AreEqual(det.FullName, find.FullName);
			Assert.AreEqual(det.Name, find.Name);

			context.DepartmentDtos.Remove(det);
			context.SaveChanges();

		}

		[TestMethod]
		public void DocumentSubTypeDTOTest()
		{
			var context = new DataContext();
			var dst = new DocumentSubTypeDTO()
			{
				Name = "testETdst",
				DocumentTypeId = 123321,
			};

			context.DocumentSubTypeDtos.Add(dst);
			context.SaveChanges();

			var find = context.DocumentSubTypeDtos.FirstOrDefault(i => i.Name == "testETdst" && i.DocumentTypeId == 123321);

			Assert.AreEqual(dst.Name, find.Name);
			Assert.AreEqual(dst.DocumentTypeId, find.DocumentTypeId);

			context.DocumentSubTypeDtos.Remove(dst);
			context.SaveChanges();

		}

		[TestMethod]
		public void EmployeeSubjectDTOTest()
		{
			var context = new DataContext();
			var esub = new EmployeeSubjectDTO()
			{
				FullName = "testETesub",
				LicenceTypeId = 2500,
			};

			context.EmployeeSubjectDtos.Add(esub);
			context.SaveChanges();

			var find = context.EmployeeSubjectDtos.FirstOrDefault(i => i.FullName == "testETesub" && i.LicenceTypeId == 2500);

			Assert.AreEqual(esub.FullName, find.FullName);
			Assert.AreEqual(esub.LicenceTypeId, find.LicenceTypeId);

			context.EmployeeSubjectDtos.Remove(esub);
			context.SaveChanges();

		}

		[TestMethod]
		public void EventCategorieDTOTest()
		{
			var context = new DataContext();
			var evc = new EventCategorieDTO()
			{
				EventCountMaxPeriod = 789,
				Weight = 654,
			};

			context.EventCategorieDtos.Add(evc);
			context.SaveChanges();

			var find = context.EventCategorieDtos.FirstOrDefault(i => i.EventCountMaxPeriod == 789 && i.Weight == 654);

			Assert.AreEqual(evc.EventCountMaxPeriod, find.EventCountMaxPeriod);
			Assert.AreEqual(evc.Weight, find.Weight);

			context.EventCategorieDtos.Remove(evc);
			context.SaveChanges();

		}

		[TestMethod]
		public void EventClassDTOTest()
		{
			var context = new DataContext();
			var ecss = new EventClassDTO()
			{
				FullName = "testETecss",
				Weight = 753,
			};

			context.EventClassDtos.Add(ecss);
			context.SaveChanges();

			var find = context.EventClassDtos.FirstOrDefault(i => i.FullName == "testETecss" && i.Weight == 753);

			Assert.AreEqual(ecss.FullName, find.FullName);
			Assert.AreEqual(ecss.Weight, find.Weight);

			context.EventClassDtos.Remove(ecss);
			context.SaveChanges();

		}

		[TestMethod]
		public void FlightNumDTOTest()
		{
			var context = new DataContext();
			var fgn = new FlightNumDTO()
			{
				FlightNumber = "fgn333",
			};

			context.FlightNumDtos.Add(fgn);
			context.SaveChanges();

			var find = context.FlightNumDtos.FirstOrDefault(i => i.FlightNumber == "fgn333");

			Assert.AreEqual(fgn.FlightNumber, find.FlightNumber);
			
			context.FlightNumDtos.Remove(fgn);
			context.SaveChanges();

		}

		[TestMethod]
		public void GoodStandartDTOTest()
		{
			var context = new DataContext();
			var gsdt = new GoodStandartDTO()
			{
				Description = "testETgst",
				Measure = 987,
			};

			context.GoodStandartDtos.Add(gsdt);
			context.SaveChanges();

			var find = context.GoodStandartDtos.FirstOrDefault(i => i.Description == "testETgst" && i.Measure == 987);

			Assert.AreEqual(gsdt.Description, find.Description);
			Assert.AreEqual(gsdt.Measure, find.Measure);

			context.GoodStandartDtos.Remove(gsdt);
			context.SaveChanges();

		}

		[TestMethod]
		public void LicenseRemarkRightDTOTest()
		{
			var context = new DataContext();
			var lrr = new LicenseRemarkRightDTO()
			{
				FullName = "testETecss",
				Name = "753",
			};

			context.LicenseRemarkRightDtos.Add(lrr);
			context.SaveChanges();

			var find = context.LicenseRemarkRightDtos.FirstOrDefault(i => i.FullName == "testETecss" && i.Name == "753");

			Assert.AreEqual(lrr.FullName, find.FullName);
			Assert.AreEqual(lrr.Name, find.Name);

			context.LicenseRemarkRightDtos.Remove(lrr);
			context.SaveChanges();

		}

		[TestMethod]
		public void LifeLimitCategorieDTOTest()
		{
			var context = new DataContext();
			var newAccessoryDescription = new AccessoryDescriptionDTO()
			{
				SubModel = "testlifelimit"
			};
			context.AccessoryDescriptionDtos.Add(newAccessoryDescription);
			context.SaveChanges();

			var llc = new LifeLimitCategorieDTO()
			{
				AircraftModelId = newAccessoryDescription.ItemId,
				CategoryName = "testETllc",
			};

			context.LifeLimitCategorieDtos.Add(llc);
			context.SaveChanges();

			var find = context.LifeLimitCategorieDtos.Include(i => i.AccessoryDescription).FirstOrDefault(i => i.AircraftModelId == newAccessoryDescription.ItemId && i.CategoryName == "testETllc");

			Assert.IsNotNull(llc.AccessoryDescription);
			Assert.AreEqual(llc.AccessoryDescription.SubModel, "testlifelimit");
			Assert.AreEqual(llc.CategoryName, find.CategoryName);

			context.LifeLimitCategorieDtos.Remove(llc);
			context.AccessoryDescriptionDtos.Remove(newAccessoryDescription);
			context.SaveChanges();

		}

		[TestMethod]
		public void LocationDTOTest()
		{
			var context = new DataContext();
			var newLocationsType = new LocationsTypeDTO()
			{
				FullName = "testloctype",
			};
			context.LocationsTypeDtos.Add(newLocationsType);
			context.SaveChanges();

			var lon = new LocationDTO()
			{
				LocationsTypeId = newLocationsType.ItemId,
				FullName = "testETlon",
				Name = "852",
			};

			context.LocationDtos.Add(lon);
			context.SaveChanges();

			var find = context.LocationDtos.Include(i => i.LocationsType).FirstOrDefault(i => i.LocationsTypeId == newLocationsType.ItemId && i.Name == "852");

			Assert.IsNotNull(lon.LocationsType);
			Assert.AreEqual(lon.LocationsType.FullName, "testloctype");
			Assert.AreEqual(lon.FullName, find.FullName);
			Assert.AreEqual(lon.Name, find.Name);

			context.LocationDtos.Remove(lon);
			context.LocationsTypeDtos.Remove(newLocationsType);
			context.SaveChanges();

		}

		[TestMethod]
		public void LocationsTypeDTOTest()
		{
			var context = new DataContext();
			var loct = new LocationsTypeDTO()
			{
				FullName = "testETloct",
				Name = "loct",
			};

			context.LocationsTypeDtos.Add(loct);
			context.SaveChanges();

			var find = context.LocationsTypeDtos.FirstOrDefault(i => i.FullName == "testETloct" && i.Name == "loct");

			Assert.AreEqual(loct.FullName, find.FullName);
			Assert.AreEqual(loct.Name, find.Name);

			context.LocationsTypeDtos.Remove(loct);
			context.SaveChanges();

		}

		[TestMethod]
		public void NomenclatureDTOTest()
		{
			var context = new DataContext();

			var newDepartment = new DepartmentDTO()
			{
				Name = "TestNomen",
				FullName = "asdzxcqw"
			};

			context.DepartmentDtos.Add(newDepartment);
			context.SaveChanges();

			var nle = new NomenclatureDTO()
			{
				DepartmentId = newDepartment.ItemId,
				FullName = "testETnle",
				Name = "nle",
			};

			context.NomenclatureDtos.Add(nle);
			context.SaveChanges();

			var find = context.NomenclatureDtos.Include(i => i.Department).FirstOrDefault(i => i.DepartmentId == newDepartment.ItemId && i.Name == "nle");

			Assert.IsNotNull(nle.Department);
			Assert.AreEqual(nle.Department.FullName, "asdzxcqw");
			Assert.AreEqual(nle.FullName, find.FullName);
			Assert.AreEqual(nle.Name, find.Name);

			context.NomenclatureDtos.Remove(nle);
			context.DepartmentDtos.Remove(newDepartment);
			context.SaveChanges();

		}

		[TestMethod]
		public void ReasonDTOTest()
		{
			var context = new DataContext();
			var rsn= new ReasonDTO()
			{
				Name = "testETrsn",
				Category = "rsn",
			};

			context.ReasonDtos.Add(rsn);
			context.SaveChanges();

			var find = context.ReasonDtos.FirstOrDefault(i => i.Name == "testETrsn" && i.Category == "rsn");

			Assert.AreEqual(rsn.Name, find.Name);
			Assert.AreEqual(rsn.Category, find.Category);

			context.ReasonDtos.Remove(rsn);
			context.SaveChanges();

		}

		[TestMethod]
		public void RestrictionDTOTest()
		{
			var context = new DataContext();
			var rtn = new RestrictionDTO()
			{
				FullName = "testETrtn",
				Name = "rtn",
			};

			context.RestrictionDtos.Add(rtn);
			context.SaveChanges();

			var find = context.RestrictionDtos.FirstOrDefault(i => i.FullName == "testETrtn" && i.Name == "rtn");

			Assert.AreEqual(rtn.FullName, find.FullName);
			Assert.AreEqual(rtn.Name, find.Name);

			context.RestrictionDtos.Remove(rtn);
			context.SaveChanges();

		}

		[TestMethod]
		public void SchedulePeriodDTOTest()
		{
			var context = new DataContext();
			var sdp= new SchedulePeriodDTO()
			{
				Schedule = 4587,
			};

			context.SchedulePeriodDtos.Add(sdp);
			context.SaveChanges();

			var find = context.SchedulePeriodDtos.FirstOrDefault(i => i.Schedule == 4587);

			Assert.AreEqual(sdp.Schedule, find.Schedule);
			
			context.SchedulePeriodDtos.Remove(sdp);
			context.SaveChanges();

		}

		[TestMethod]
		public void ServiceTypeDTOTest()
		{
			var context = new DataContext();
			var svt = new ServiceTypeDTO()
			{
				FullName = "testETsvt",
				Name = "svt",
			};

			context.ServiceTypeDtos.Add(svt);
			context.SaveChanges();

			var find = context.ServiceTypeDtos.FirstOrDefault(i => i.FullName == "testETsvt" && i.Name == "svt");

			Assert.AreEqual(svt.FullName, find.FullName);
			Assert.AreEqual(svt.Name, find.Name);

			context.ServiceTypeDtos.Remove(svt);
			context.SaveChanges();

		}

		[TestMethod]
		public void SpecializationDTOTest()
		{
			var context = new DataContext();

			var newDepartment = new DepartmentDTO()
			{
				Name = "TestSpec",
				FullName = "qweasd"
			};

			context.DepartmentDtos.Add(newDepartment);
			context.SaveChanges();

			var spcn = new SpecializationDTO()
			{
				DepartmentId = newDepartment.ItemId,
				FullName = "testETspcn",
				ShortName = "spcn",
			};

			context.SpecializationDtos.Add(spcn);
			context.SaveChanges();

			var find = context.SpecializationDtos.Include(i => i.Department).FirstOrDefault(i => i.DepartmentId == newDepartment.ItemId && i.ShortName == "spcn");

			Assert.IsNotNull(spcn.Department);
			Assert.AreEqual(spcn.Department.Name, "TestSpec");
			Assert.AreEqual(spcn.FullName, find.FullName);
			Assert.AreEqual(spcn.ShortName, find.ShortName);
			
			context.SpecializationDtos.Remove(spcn);
			context.DepartmentDtos.Remove(newDepartment);
			context.SaveChanges();

		}

		[TestMethod]
		public void TripNameDTOTest()
		{
			var context = new DataContext();
			var tpn= new TripNameDTO()
			{
				TripName = "testETtpn",
			};

			context.TripNameDtos.Add(tpn);
			context.SaveChanges();

			var find = context.TripNameDtos.FirstOrDefault(i => i.TripName == "testETtpn");

			Assert.AreEqual(tpn.TripName, find.TripName);
			
			context.TripNameDtos.Remove(tpn);
			context.SaveChanges();

		}
	}
}


