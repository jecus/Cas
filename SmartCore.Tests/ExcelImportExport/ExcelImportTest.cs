using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using EntityCore.DTO.Dictionaries;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Discrepancies;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class ExcelImportTest
	{

		[TestMethod]
		public void ImportComponent()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader,env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\Components3720.xlsx");
			var baseComponents = componentCore.GetAicraftBaseComponents(2348);
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO,AtaChapter>();

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					BaseComponent baseComp;
					var description = row[0].ToString();
					var remarks  = $"Used On: {row[1]}";
					var partNumber = row[2].ToString();
					var serialNumber = row[5].ToString();
					var position = row[6].ToString();
					var ataNumber = Convert.ToInt32(row[11].ToString());
					var hiddenRemarks = $"X Station : {row[7]} \n Y Buttockline : {row[8]} \n Z Waterline : {row[9]} \n ";
					var instDate = new DateTime(2018,3,28);


					var component = new Entities.General.Accessory.Component
					{
						PartNumber = partNumber,
						SerialNumber = serialNumber,
						Description = description,
						Remarks = remarks,
						HiddenRemarks = hiddenRemarks,
						ManufactureDate = instDate,
						StartDate = instDate,
						DeliveryDate = instDate
					};

					if (ataNumber == 49)
					{
						baseComp = baseComponents.FirstOrDefault(i => i.BaseComponentType == BaseComponentType.Apu);
						component.ATAChapter = ata.FirstOrDefault(i => i.ShortName.Equals(ataNumber.ToString()));
						component.GoodsClass = GoodsClass.AircraftBaseComponentsApu;
					}
					else if (ataNumber == 32)
					{
						baseComp = baseComponents.FirstOrDefault(i => i.BaseComponentType == BaseComponentType.LandingGear);
						component.ATAChapter = ata.FirstOrDefault(i => i.ShortName.Equals(ataNumber.ToString()));
						component.GoodsClass = GoodsClass.AircraftBaseComponentsLandingGear;
					}
					else if (ataNumber >= 70)
					{
						baseComp = baseComponents.FirstOrDefault(i => i.BaseComponentType == BaseComponentType.Engine);
						component.ATAChapter = ata.FirstOrDefault(i => i.ShortName.Equals(ataNumber.ToString()));
						component.GoodsClass = GoodsClass.AircraftBaseComponentsEngine;
					}
					else
					{
						baseComp = baseComponents.FirstOrDefault(i => i.BaseComponentType == BaseComponentType.Frame);
						component.ATAChapter = ata.FirstOrDefault(i => i.ShortName.Equals(ataNumber.ToString()));
						component.GoodsClass = GoodsClass.AircraftBaseComponents;
					}

					componentCore.AddComponent(component, baseComp, instDate, position, null, null, null, null, true);

				}
			}

		}

		[TestMethod]
		public void ImportFlights()
		{
			var env = GetEnviroment();

			var codes = env.GetDictionary<AirportsCodes>().ToArray().Cast<AirportsCodes>();
			var flightNums = env.GetDictionary<FlightNum>().Cast<FlightNum>().ToList();

			//Экспортируем полеты в Dataset из Excel файла
			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\AZV.xlsx", false);

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var flight = new AircraftFlight();
					flight.ATLBId = 151;
					flight.AircraftId = 2335;
					flight.DistanceMeasure = Measure.Kilometres;
					flight.PageNo = row[0].ToString();
					flight.FlightDate = DateTime.Parse(row[1].ToString());

					var flightNum = flightNums.FirstOrDefault(x => x.FullName == row[2].ToString());
					if (flightNum != null)
					{
						flight.FlightNumber = flightNum;
					}
					else
					{
						var newFlightNum = new FlightNum { FullName = flight.FlightNo };
						env.NewKeeper.Save(newFlightNum);
						flightNums.Add(newFlightNum);

						flight.FlightNumber = newFlightNum;
					}

					if(row[3] != null)
						flight.StationFromId = codes.FirstOrDefault(c => c.ShortName.ToUpper() == row[3].ToString().Trim().ToUpper());
					if (row[4] != null)
						flight.StationToId = codes.FirstOrDefault(c => c.ShortName.ToUpper() == row[4].ToString().Trim().ToUpper());

					var dateOut = DateTime.Parse(row[5].ToString());
					var dateIn = DateTime.Parse(row[6].ToString());

					flight.OutTime = (int)dateOut.TimeOfDay.TotalMinutes;
					flight.InTime = (int)dateIn.TimeOfDay.TotalMinutes;
					flight.TakeOffTime = flight.OutTime;
					flight.LDGTime = flight.InTime;


					env.NewKeeper.Save(flight);
				}
			}
		}

		[TestMethod]
		public void FindFlights()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var directiveCore = new DirectiveCore(env.NewKeeper, env.NewLoader,env.Keeper, env.Loader, itemRelationCore);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var aircraftFlightCore = new AircraftFlightCore(env, env.Loader, env.NewLoader, directiveCore, env.Manipulator, componentCore, env.NewKeeper,aircraftCore);

			aircraftFlightCore.LoadAircraftFlights(2344);
			var flights = aircraftFlightCore.GetAircraftFlightsByAircraftId(2343);
			var codes = env.GetDictionary<AirportsCodes>().ToArray().Cast<AirportsCodes>();
			var flightNums = env.GetDictionary<FlightNum>().Cast<FlightNum>().ToList();

			//Экспортируем полеты в Dataset из Excel файла
			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\007.xlsx", false);


			int time = 0;

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var pageNo = row[0].ToString();

				
					AirportsCodes stationFromId = AirportsCodes.Unknown;
					AirportsCodes stationToId = AirportsCodes.Unknown;

					if (row[3] != null)
						stationFromId = codes.FirstOrDefault(c => c.ShortName.ToUpper() == row[3].ToString().Trim().ToUpper());

					if (row[4] != null)
						stationToId = codes.FirstOrDefault(c => c.ShortName.ToUpper() == row[4].ToString().Trim().ToUpper());

					var dateOut = DateTime.Parse(row[5].ToString());
					var dateIn = DateTime.Parse(row[6].ToString());

					var outTime = (int)dateOut.TimeOfDay.TotalMinutes;
					var inTime = (int)dateIn.TimeOfDay.TotalMinutes;
					var takeOffTime = outTime;
					var lDGTime = inTime;

					DateTime res;
					if (!DateTime.TryParse(row[1].ToString(), out res))
					{
						Trace.WriteLine($"!!!!!!!!!Нету: {pageNo} | {row[1]} | {row[3]} - {row[4]} | ({outTime}-{inTime})");

						if(outTime > inTime)
							time += outTime - inTime;
						else
						time += inTime - outTime;
						continue;
					}


					var flightDate = DateTime.Parse(row[1].ToString());
					var find = flights.Where(i => i.PageNo == pageNo);

					if (!find.Any())
					{
						Trace.WriteLine($"Нету: {pageNo} | {flightDate} | {row[3]} - {row[4]} | ({outTime}-{inTime})");

						time += inTime - outTime;
					}
				}


				Trace.WriteLine(time);
			}
		}

		[TestMethod]
		public void ImportReliability()
		{
			string reg = "";
			DateTime date = new DateTime();
			string flNum = "";

			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var directiveCore = new DirectiveCore(env.NewKeeper, env.NewLoader, env.Keeper, env.Loader, itemRelationCore);
			var aircraftFlightCore = new AircraftFlightCore(env, env.Loader, env.NewLoader, directiveCore, env.Manipulator, null,env.NewKeeper, aircraftCore);
			var discrepanciesCore = new DiscrepanciesCore(env.Loader, env.NewLoader, directiveCore, aircraftFlightCore);

			aircraftCore.LoadAllAircrafts();
			var res = discrepanciesCore.GetDiscrepancies().ToArray();

			foreach (var discrepancy in res)
			{
				discrepancy.ParentFlight.Aircraft = aircraftCore.GetAircraftById(discrepancy.ParentFlight.AircraftId);
			}


			//Экспортируем полеты в Dataset из Excel файла
			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\1.xlsx");

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if (!string.IsNullOrEmpty(row[0].ToString()) && !string.IsNullOrEmpty(row[1].ToString()))
					{
						reg = row[0].ToString();
						date = DateTime.Parse(row[1].ToString());
						flNum = $"{row[5]}";
					}


					var find = res.Where(i => i.ParentFlight.Aircraft != null).FirstOrDefault(i =>
						i.ParentFlight.FlightNumber.FullName.Contains(flNum) && i.ParentFlight.FlightDate.Date.Equals(date.Date) && i.ParentFlight.Aircraft.RegistrationNumber.Contains(reg));


					if (find != null)
					{

						if (!string.IsNullOrEmpty(row[6].ToString()))
						{
							find.FDR += $"{row[6]} | {row[7]} | {row[8]} | {row[9]} ";
							env.NewKeeper.Save(find);
						}
						

						Trace.WriteLine($"{reg} = {find.ParentFlight.Aircraft.RegistrationNumber} | {flNum} = {find.ParentFlight.FlightNumber} | {date} = {find.ParentFlight.FlightDate.Date}");
					}


				}
			}
		}

		[TestMethod]
		public void ImportMaintenanceDirectives()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\SCIAWL.xlsx");

			var bd = componentCore.GetAicraftBaseComponents(2348, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO,AtaChapter>();

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2348);

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			MaintenanceDirective savedMpd = null;

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{

					if(string.IsNullOrEmpty(row[0].ToString()))
						continue;

					var find = mpds.FirstOrDefault(i => i.TaskNumberCheck.ToLower().Equals(row[0].ToString().ToLower()));
					if (find != null)
					{
						if (find.MaintenanceManual != row[1].ToString())
						{
							find.HiddenRemarks += $"| AMM |";
							find.MaintenanceManual = row[1].ToString();
						}

						find.Program = MaintenanceDirectiveProgramType.SpecialCompliance;

						//if (!string.IsNullOrEmpty(row[3].ToString()))
						//{
						//	var value = row[3].ToString();
						//	if (value.Contains("SYSTEMS AND POWERPLANT"))
						//	{
						//		if (find.Program.ItemId != MaintenanceDirectiveProgramType.SystemsAndPowerPlants.ItemId)
						//		{
						//			find.HiddenRemarks += $"| Program |";
						//			find.Program = MaintenanceDirectiveProgramType.SystemsAndPowerPlants;
						//		}
						//	}
						//	else if (value.Contains("STRUCTURAL"))
						//	{
						//		if (find.Program.ItemId != MaintenanceDirectiveProgramType.StructuresMaintenance.ItemId)
						//		{
						//			find.HiddenRemarks += $"| Program |";
						//			find.Program = MaintenanceDirectiveProgramType.StructuresMaintenance;
						//		}
						//	}
						//	else if(value.Contains("ZONAL"))
						//	{
						//		if (find.Program.ItemId != MaintenanceDirectiveProgramType.ZonalInspection.ItemId)
						//		{
						//			find.HiddenRemarks += $"| Program |";
						//			find.Program = MaintenanceDirectiveProgramType.ZonalInspection;
						//		}
						//	}
						//}

						if (!string.IsNullOrEmpty(row[4].ToString()))
						{
							var category = MpdCategory.GetItemById(Convert.ToInt32(row[4].ToString()[0]));
							if (category != null && find.Category.ItemId != category.ItemId)
							{
								find.HiddenRemarks += $"| Category |";
								find.Category = category;
							}
						}

						if (!string.IsNullOrEmpty(row[5].ToString()))
						{
							var programIndicator = MaintenanceDirectiveProgramIndicator.Items.FirstOrDefault(i => i.ShortName.Contains(row[5].ToString()));
							if (programIndicator != null && find.ProgramIndicator.ItemId != programIndicator.ItemId)
							{
								find.HiddenRemarks += $"| ProgramIndicator |";
								find.ProgramIndicator = programIndicator;
							}
						}

						if (!string.IsNullOrEmpty(row[6].ToString()))
						{
							var workType = MaintenanceDirectiveTaskType.Items.FirstOrDefault(i => i.ShortName.Contains(row[6].ToString()));
							if (workType != null && find.WorkType.ItemId != workType.ItemId)
							{
								find.HiddenRemarks += $"| WorkType |";
								find.WorkType = workType;
							}
						}
						
						if (find.Zone != row[22].ToString())
						{
							find.HiddenRemarks += $"| Zone |";
							find.Zone = row[22].ToString().Replace("\n", " ");
						}

						if (find.Access != row[23].ToString())
						{
							find.HiddenRemarks += $"| Access |";
							find.Access = row[23].ToString().Replace("\n", " ");
						}

						if (find.Applicability != row[24].ToString())
						{
							find.HiddenRemarks += $"| Applicability |";
							find.Applicability = row[24].ToString();
						}

						if (!string.IsNullOrEmpty(row[26].ToString()))
						{
							var value = Convert.ToDouble(row[26].ToString());
							if (find.ManHours != value)
							{
								find.HiddenRemarks += $"| ManHours |";
								find.ManHours = value;
							}
						}

						if (find.Description != row[27].ToString())
						{
							find.HiddenRemarks += $"| Description |";
							find.Description = row[27].ToString();
						}

						if (find.Description != row[2].ToString())
						{
							find.HiddenRemarks += $"| Remarks |";
							find.Remarks = row[2].ToString();
						}

						if (find.Description != row[28].ToString())
						{
							find.HiddenRemarks += $"| Doc No |";
							find.MPDTaskNumber = row[28].ToString();
						}

						if (find.Description != row[28].ToString())
						{
							find.HiddenRemarks += $"| Workarea |";
							find.Workarea = row[29].ToString();
						}


						if (!string.IsNullOrEmpty(row[7].ToString()) && row[7].ToString() != "N/A")
						{
							var value = row[7].ToString();
							find.Threshold.FirstPerformanceSinceNew.Hours = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[8].ToString()) && row[8].ToString() != "N/A")
						{
							var value = row[8].ToString();
							find.Threshold.FirstPerformanceSinceNew.Cycles = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[9].ToString()) && row[9].ToString() != "N/A")
						{
							find.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Days;
							var value = row[9].ToString();
							find.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[10].ToString()) && row[10].ToString() != "N/A")
						{
							find.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Months;
							var value = row[10].ToString();
							find.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[11].ToString()) && row[11].ToString() != "N/A")
						{
							find.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Years;
							var value = row[11].ToString();
							find.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}

						///////////////////////////////////////////////////////////////////////////////
						if (!string.IsNullOrEmpty(row[15].ToString()) && row[15].ToString() != "N/A")
						{
							var value = row[15].ToString();
							find.Threshold.RepeatInterval.Hours = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[16].ToString()) && row[16].ToString() != "N/A")
						{
							var value = row[16].ToString();
							find.Threshold.RepeatInterval.Cycles = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[17].ToString()) && row[17].ToString() != "N/A")
						{
							find.Threshold.RepeatInterval.CalendarType = CalendarTypes.Days;
							var value = row[17].ToString();
							find.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[18].ToString()) && row[18].ToString() != "N/A")
						{
							find.Threshold.RepeatInterval.CalendarType = CalendarTypes.Months;
							var value = row[18].ToString();
							find.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[19].ToString()) && row[19].ToString() != "N/A")
						{
							find.Threshold.RepeatInterval.CalendarType = CalendarTypes.Years;
							var value = row[19].ToString();
							find.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}


						env.NewKeeper.Save(find);

					}
					else
					{
						var newMpd = new MaintenanceDirective
						{
							ParentBaseComponent = bd,
							HiddenRemarks = "NEW",
						};

						newMpd.TaskNumberCheck = row[0].ToString();
						newMpd.MaintenanceManual = row[1].ToString();

						newMpd.Program = MaintenanceDirectiveProgramType.SpecialCompliance;

						//if (!string.IsNullOrEmpty(row[3].ToString()))
						//{
						//	var value = row[3].ToString();
						//	if(value.Contains("SYSTEMS AND POWERPLANT"))
						//		newMpd.Program = MaintenanceDirectiveProgramType.SystemsAndPowerPlants;
						//	else if (value.Contains("STRUCTURAL"))
						//		newMpd.Program = MaintenanceDirectiveProgramType.StructuresMaintenance;
						//	else if (value.Contains("ZONAL"))
						//		newMpd.Program = MaintenanceDirectiveProgramType.ZonalInspection;
						//}


						if (!string.IsNullOrEmpty(row[4].ToString()))
							newMpd.Category = MpdCategory.GetItemById(Convert.ToInt32(row[4].ToString()));

						if (!string.IsNullOrEmpty(row[5].ToString()))
							newMpd.ProgramIndicator = MaintenanceDirectiveProgramIndicator.Items.FirstOrDefault(i => i.ShortName.Contains(row[5].ToString()));

						if (!string.IsNullOrEmpty(row[6].ToString()))
							newMpd.WorkType = MaintenanceDirectiveTaskType.Items.FirstOrDefault(i => i.ShortName.Contains(row[6].ToString()));

						newMpd.Zone = row[22].ToString().Replace("\n", " ");
						newMpd.Access = row[23].ToString().Replace("\n", " ");
						newMpd.Applicability = row[24].ToString();

						if (!string.IsNullOrEmpty(row[26].ToString()))
							newMpd.ManHours = Convert.ToDouble(row[26].ToString());

						newMpd.Remarks = row[2].ToString();
						newMpd.Description = row[27].ToString();
						newMpd.MPDTaskNumber = row[28].ToString();
						newMpd.Workarea = row[29].ToString();

						if (newMpd.TaskNumberCheck.Length > 2)
							newMpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(newMpd.TaskNumberCheck.Substring(0, 2)));


						newMpd.Threshold = new MaintenanceDirectiveThreshold();
						///////////////////////////////////////////////////////////////////////////////
						if (!string.IsNullOrEmpty(row[7].ToString()) && row[7].ToString() != "N/A")
						{
							var value = row[7].ToString();
							newMpd.Threshold.FirstPerformanceSinceNew.Hours = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[8].ToString()) && row[8].ToString() != "N/A")
						{
							var value = row[8].ToString();
							newMpd.Threshold.FirstPerformanceSinceNew.Cycles = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[9].ToString()) && row[9].ToString() != "N/A")
						{
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Days;
							var value = row[9].ToString();
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[10].ToString()) && row[10].ToString() != "N/A")
						{
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Months;
							var value = row[10].ToString();
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[11].ToString()) && row[11].ToString() != "N/A")
						{
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Years;
							var value = row[11].ToString();
							newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value);
						}

						///////////////////////////////////////////////////////////////////////////////
						if (!string.IsNullOrEmpty(row[15].ToString()) && row[15].ToString() != "N/A")
						{
							var value = row[15].ToString();
							newMpd.Threshold.RepeatInterval.Hours = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[16].ToString()) && row[16].ToString() != "N/A")
						{
							var value = row[16].ToString();
							newMpd.Threshold.RepeatInterval.Cycles = int.Parse(value);
						}

						if (!string.IsNullOrEmpty(row[17].ToString()) && row[17].ToString() != "N/A")
						{
							newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Days;
							var value = row[17].ToString();
							newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[18].ToString()) && row[18].ToString() != "N/A")
						{
							newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Months;
							var value = row[18].ToString();
							newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}
						else if (!string.IsNullOrEmpty(row[19].ToString()) && row[19].ToString() != "N/A")
						{
							newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Years;
							var value = row[19].ToString();
							newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value);
						}

						env.NewKeeper.Save(newMpd);
					}


					#region UP-B3

					//var newMpd = new MaintenanceDirective();
					//newMpd.TaskNumberCheck = row[0].ToString();
					//newMpd.Description = row[6].ToString();
					//newMpd.Applicability = row[5].ToString();

					//newMpd.WorkType = MaintenanceDirectiveTaskType.Items.FirstOrDefault(i => i.ShortName.Contains(row[2].ToString()));


					//newMpd.MPDTaskNumber = "D626A011-9-03";
					//newMpd.ParentBaseComponent = bd;
					//newMpd.Program = MaintenanceDirectiveProgramType.CertificationMaintenanceRequirement;
					//newMpd.MpdRevisionDate = new DateTime(2017, 9, 1);

					//if (newMpd.TaskNumberCheck.Length > 2)
					//	newMpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(newMpd.TaskNumberCheck.Substring(0, 2)));
					//env.Keeper.Save(newMpd);


					//env.Keeper.Save(newMpd);

					//DateTime d = new DateTime();

					//if(DateTime.TryParse(row[4].ToString(), out d))
					//	newMpd.MpdRevisionDate = d;

					//
					//
					//if (newMpd.TaskNumberCheck.Length > 2)
					//newMpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(newMpd.TaskNumberCheck.Substring(0, 2)));

					//newMpd.Threshold = new MaintenanceDirectiveThreshold();
					//if (!string.IsNullOrEmpty(row[6].ToString()))
					//{
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Days;
					//	var value = row[6].ToString();
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}
					//else if (!string.IsNullOrEmpty(row[7].ToString()))
					//{
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Months;
					//	var value = row[7].ToString();
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}
					//else if (!string.IsNullOrEmpty(row[8].ToString()))
					//{
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarType = CalendarTypes.Years;
					//	var value = row[8].ToString();
					//	newMpd.Threshold.FirstPerformanceSinceNew.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}

					//if (!string.IsNullOrEmpty(row[9].ToString()))
					//{
					//	var value = row[9].ToString();
					//	newMpd.Threshold.FirstPerformanceSinceNew.Days = int.Parse(value.Remove(value.IndexOf(' ')));
					//}

					//if (!string.IsNullOrEmpty(row[10].ToString()))
					//{
					//	var value = row[10].ToString();
					//	newMpd.Threshold.FirstPerformanceSinceNew.Cycles = int.Parse(value.Remove(value.IndexOf(' ')));
					//}


					//if (!string.IsNullOrEmpty(row[11].ToString()))
					//{
					//	newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Days;
					//	var value = row[11].ToString();
					//	newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}
					//else if (!string.IsNullOrEmpty(row[12].ToString()))
					//{
					//	newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Months;
					//	var value = row[12].ToString();
					//	newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}
					//else if (!string.IsNullOrEmpty(row[13].ToString()))
					//{
					//	newMpd.Threshold.RepeatInterval.CalendarType = CalendarTypes.Years;
					//	var value = row[13].ToString();
					//	newMpd.Threshold.RepeatInterval.CalendarValue = int.Parse(value.Remove(value.IndexOf(' ')));
					//}

					//if (!string.IsNullOrEmpty(row[14].ToString()))
					//{
					//	var value = row[14].ToString();
					//	newMpd.Threshold.RepeatInterval.Days = int.Parse(value.Remove(value.IndexOf(' ')));
					//}

					//if (!string.IsNullOrEmpty(row[15].ToString()))
					//{
					//	var value = row[15].ToString();
					//	newMpd.Threshold.RepeatInterval.Cycles = int.Parse(value.Remove(value.IndexOf(' ')));
					//}

					//env.Keeper.Save(newMpd);

					#endregion

					#region UP-B6703

					//if (row[0].ToString().Length == 0)
					//{
					//	savedMpd.Zone += $" {row[1]}";
					//	savedMpd.Access += $" {row[4]}";
					//	savedMpd.Description += $" {row[2]}";

					//	env.Keeper.Save(savedMpd);
					//}
					//else
					//{
					//	var mpd = new MaintenanceDirective();

					//	var taskNumberCheck = row[0].ToString().Split();
					//	var zone = row[1].ToString().Split();
					//	var access = row[4].ToString().Split();

					//	mpd.TaskNumberCheck = string.Join(" ", taskNumberCheck);
					//	mpd.TaskCardNumber = row[0].ToString();
					//	//mpd.TaskCardNumber = row[5].ToString();//690-694 756-802
					//	mpd.Zone = string.Join(" ", zone);
					//	mpd.Access = string.Join(" ", access);
					//	mpd.Description = row[2].ToString();
					//	//mpd.Description = $"{row[5]} {row[2]}";//669-689

					//	if (mpd.TaskNumberCheck.Length > 2)
					//		mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(mpd.TaskNumberCheck.Substring(0, 2)));


					//	mpd.ParentBaseComponent = bd;
					//	env.Keeper.Save(mpd);
					//	savedMpd = mpd;
					//}


					#endregion

					#region LY - FLG


					//mpd.TaskNumberCheck = row[0].ToString();
					//mpd.TaskCardNumber = row[0].ToString();
					//mpd.Zone = row[1].ToString();
					//mpd.Description = row[2].ToString();

					//if(table.Columns.Count > 3)
					//	mpd.Access = row[3].ToString();

					//if(mpd.TaskNumberCheck.Length > 2)
					//	mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(mpd.TaskNumberCheck.Substring(0, 2)));

					#endregion

					#region LY - AZV

					//if (row[0].ToString().Length == 0)
					//{
					//	savedMpd.TaskCardNumber += $" {row[2]}";
					//	savedMpd.Zone += $" {row[3]}";
					//	savedMpd.Access += $" {row[4]}";
					//	savedMpd.Description += $" {row[6]}";

					//	env.Keeper.Save(savedMpd);
					//}
					//else
					//{
					//	var mpd = new MaintenanceDirective();

					//	mpd.TaskNumberCheck = row[0].ToString();

					//	var maintenanceManual = row[1].ToString().Split();
					//	var cardNumber = row[2].ToString().Split();
					//	var zone = row[3].ToString().Split();
					//	var access = row[4].ToString().Split();


					//	mpd.MaintenanceManual = string.Join(" ", maintenanceManual);
					//	mpd.TaskCardNumber = string.Join(" ", cardNumber);
					//	mpd.Zone = string.Join(" ", zone);
					//	mpd.Access = string.Join(" ", access);

					//	//mpd.Description = $"{row[5]} {row[6]}";//271 - 294

					//	mpd.Description = row[6].ToString();
					//	if (!string.IsNullOrEmpty(row[5].ToString()))
					//		mpd.ManHours = Convert.ToDouble(row[5].ToString());

					//	if(mpd.TaskNumberCheck.Length > 2)
					//		mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(mpd.TaskNumberCheck.Substring(0, 2)));


					//	mpd.ParentBaseComponent = bd;
					//	env.Keeper.Save(mpd);
					//	savedMpd = mpd;
					//}

					#endregion

					#region CRJ

					//if (row[0].ToString().Length == 0)
					//	continue;

					//var mpd = new MaintenanceDirective();

					//var taskNumberCheck = row[1].ToString().Split();
					//var taskCardNumber = row[0].ToString().Split();
					//var access = row[3].ToString().Split();

					//mpd.TaskNumberCheck = string.Join(" ", taskNumberCheck);
					//mpd.TaskCardNumber = string.Join(" ", taskCardNumber);
					//mpd.Description = row[2].ToString();
					//mpd.Access = string.Join(" ", access);

					//double q;
					//if (!string.IsNullOrEmpty(row[4].ToString()) && double.TryParse(row[4].ToString(), out q))
					//	mpd.ManHours = Convert.ToDouble(row[4].ToString());

					//mpd.Remarks = $"{row[5]} {row[6]}";

					//if(mpd.TaskNumberCheck.Length > 2)
					//	mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(mpd.TaskNumberCheck.Substring(0, 2)));

					//mpd.ParentBaseComponent = bd;
					//env.Keeper.Save(mpd);

					#endregion
				}
			}
				
		}

        [TestMethod]
		public void ImportDirectivesAD()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, null);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);

			var bd = componentCore.GetAicraftBaseComponents(2341, BaseComponentType.Engine.ItemId).LastOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO,AtaChapter>();

			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\004ADEngine.xlsx");

			var status = Status.Create;
			Directive savedDirective = null;

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					//if(string.IsNullOrEmpty(row[2].ToString()))
					//	continue;

					var directive = new Directive();

					//var first = row[0].ToString();
					//var second = row[1].ToString();

					//if(!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
					//	directive.Title = $"{first} / {second}";
					//else if(!string.IsNullOrEmpty(first))
					//	directive.Title = $"{first}";
					//else if (!string.IsNullOrEmpty(first))
					//	directive.Title = $"{second}";
					////else continue;

					//directive.Description = row[2].ToString();
					//directive.ServiceBulletinNo = row[3].ToString();
					//directive.StcNo = row[4].ToString();
					//directive.Remarks = row[10].ToString();

					//if (row[11].ToString() == "CLOSED")
					//	directive.IsClosed = true;
					//else directive.IsApplicability = true;


					directive.Title = row[0].ToString();
					directive.Description = row[1].ToString();
					directive.ServiceBulletinNo = row[7].ToString();
					directive.HiddenRemarks = row[8].ToString();
					directive.Remarks = row[11].ToString();
					directive.IsApplicability = true;

					directive.DirectiveType = DirectiveType.AirworthenessDirectives;
					directive.WorkType = DirectiveWorkType.Modification;
					directive.ADType = ADType.Engine;
					directive.ParentBaseComponent = bd;

					env.NewKeeper.Save(directive);

					#region Кроме CRJ

					//if (row[0].Equals("Ref No(s)"))
					//{
					//	status = Status.Create;
					//	continue;
					//}
					//if (row[1].Equals("Paragraph"))
					//{
					//	status= Status.Modify;
					//	continue;
					//}

					//if (status == Status.Create)
					//{
					//	var directive = new Directive();

					//	var title = row[0].ToString();
					//	if(title.StartsWith("AD-"))
					//		title = title.Remove(0, 3);

					//	directive.Title = title;

					//	DateTime dateTime;
					//	if(DateTime.TryParse(row[7].ToString(), out dateTime))
					//		directive.Threshold.EffectiveDate = dateTime;

					//	directive.ATAChapter = ata.FirstOrDefault(a => a.ShortName == row[9].ToString());
					//	directive.Remarks = row[10].ToString();
					//	directive.ADType = ADType.Airframe;
					//	directive.DirectiveType = DirectiveType.AirworthenessDirectives;
					//	directive.ParentBaseComponent = bd;

					//	savedDirective = directive;
					//}
					//else if (status == Status.Modify)
					//{
					//	if (string.IsNullOrEmpty(row[1].ToString()))
					//	{
					//		savedDirective.Description += $" {row[4]}";
					//		savedDirective.HiddenRemarks += $"{row[6]}";
					//	}
					//	else
					//	{
					//		savedDirective.ItemId = -1;
					//		savedDirective.Paragraph = row[1].ToString();
					//		savedDirective.Description = row[4].ToString();
					//		savedDirective.HiddenRemarks = row[6].ToString();

					//		env.Keeper.Save(savedDirective);
					//	}
					//}

					#endregion

					#region CRJ

					//if(string.IsNullOrEmpty(row[0].ToString()) && string.IsNullOrEmpty(row[1].ToString()))
					//	continue;

					//var directive = new Directive();

					//directive.ServiceBulletinNo = row[0].ToString();
					//directive.Description = row[1].ToString();
					//directive.Remarks = row[2].ToString();

					//DateTime date;
					//if(DateTime.TryParse(row[3].ToString(), out date))
					//	directive.Threshold.EffectiveDate = date;

					//directive.HiddenRemarks = $"{row[4]} {row[5]} {row[6]}";

					//directive.ADType = ADType.Airframe;
					//directive.ParentBaseComponent = bd;


					//env.Keeper.Save(directive);

					#endregion
				}
			}

		}

		[TestMethod]
		public void ImportAirportsCodes()
		{
			var env = GetEnviroment();
			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\airports.xlsx");
			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var ac = new AirportsCodes
					{
						ShortName = row[0].ToString(),
						Icao = row[1].ToString(),
						FullName = row[2].ToString(),
						City = row[3].ToString(),
						Country = row[4].ToString(),
						Iso = row[5].ToString()
					};

					env.NewKeeper.Save(ac);
				}
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("92.47.31.254:45617", "casadmin", "casadmin001", "ScatDB");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}

		private DataSet ExcelToDataTableUsingExcelDataReader(string storePath, bool isFirstRowAsColumnNames = true)
		{
			var stream = File.Open(storePath, FileMode.Open, FileAccess.Read);

			string fileExtension = Path.GetExtension(storePath);
			IExcelDataReader excelReader = null;
			if (fileExtension == ".xls")
				excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
			else if (fileExtension == ".xlsx")
				excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);


			excelReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;

			return excelReader.AsDataSet();
		}

		public enum Status
		{
			Create, Modify
		}
	}
}