using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Auxiliary;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class ImportExcelMpd
	{
		[TestMethod]
		public void ImportMaintenanceDirectives37XX()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\123\mpd.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2334);

			var bd = componentCore.GetAicraftBaseComponents(aircraft.ItemId, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO, AtaChapter>();

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);


			foreach (DataTable table in ds.Tables)
			{
				foreach (var row in table.Rows.OfType<DataRow>().GroupBy(i => i[1]))
				//foreach (DataRow row in table.Rows)
				{

                    #region Добавление Mpd TaskNumber(Appendix B - Old to New XRef)

                    //int counter = 1;
                    //var find = mpds.FirstOrDefault(i => i.TaskNumberCheck.ToLower().Trim().Equals(row.Key.ToString().ToLower()));
                    //if (find != null)
                    //{
                    //	foreach (var dataRow in row)
                    //	{
                    //		if (counter == 1)
                    //		{
                    //			if (row.Count() > 1)
                    //				find.TaskNumberCheck = $"{row.Key} ({counter})";

                    //			find.MpdOldTaskCard = dataRow[2].ToString();
                    //			find.TaskCardNumber = dataRow[3].ToString();
                    //			env.Keeper.Save(find);
                    //			counter++;
                    //		}
                    //		else
                    //		{

                    //			MaintenanceDirective mpd = find.GetCopyUnsaved();
                    //			mpd.ParentBaseComponent = bd;
                    //			mpd.TaskNumberCheck = $"{row.Key} ({counter})";
                    //			mpd.MpdOldTaskCard = dataRow[2].ToString();
                    //			mpd.TaskCardNumber = dataRow[3].ToString();
                    //			env.Keeper.Save(mpd);
                    //			counter++;

                    //		}
                    //	}
                    //}


                    #endregion


                    //var find = mpds.FirstOrDefault(i =>
                    //i.TaskNumberCheck.ToLower().Trim().Equals(row[0].ToString().ToLower()));

                    //MaintenanceDirective mpd;

                    //if (find != null)
                    //	mpd = find;
                    //else
                    //	mpd = new MaintenanceDirective()
                    //	{
                    //		ParentBaseComponent = bd,
                    //		HiddenRemarks = "NEW",
                    //	};

                    #region Основное добавление(Appendix G - ISIP)

                    //mpd.Program = MaintenanceDirectiveProgramType.ISIP;
                    //mpd.MpdRef = "Appendix G - ISIP";

                    //mpd.TaskNumberCheck = row[0].ToString();
                    //mpd.Zone = row[4].ToString();
                    //mpd.Access = row[3].ToString();
                    //mpd.Description = row[8].ToString();

                    //if (mpd.TaskNumberCheck.Length > 2)
                    //{
                    //	var shortName = mpd.TaskNumberCheck.Substring(1, 2);
                    //	mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(shortName));

                    //}
                    //mpd.MPDTaskNumber = "D6-38278";
                    //mpd.IsOperatorTask = false;
                    //mpd.MpdRevisionDate = new DateTime(2018, 9, 25);
                    //mpd.Threshold.EffectiveDate = new DateTime(2018, 10, 1);
                    //mpd.ScheduleRevisionDate = new DateTime(2018, 10, 1);
                    //mpd.ScheduleRevisionNum = "1";
                    //mpd.ScheduleRef = "SC-C011-MP";


                    #endregion

                    #region Основное добавление(Section 6 Systems и Section 7 Structures)

                    //mpd.Program = MaintenanceDirectiveProgramType.SystemsMaintenance;
                    //mpd.MpdRef = "Section 6 Systems";

                    //mpd.Program = MaintenanceDirectiveProgramType.StructuralInspection;
                    //mpd.MpdRef = "Section 7 Structures";

                    //mpd.TaskNumberCheck = row[0].ToString();
                    //mpd.MRB = row[1].ToString();
                    //mpd.Zone = row[4].ToString();
                    //mpd.Access = row[3].ToString();
                    //mpd.Description = row[8].ToString();

                    //var apl = row[5].ToString();
                    //if (apl.Contains("ALL"))
                    //{
                    //	mpd.IsApplicability = true;
                    //}
                    //else if (apl == "(1)")
                    //{
                    //	mpd.IsApplicability = true;
                    //	mpd.Applicability = apl;
                    //}


                    //if (mpd.TaskNumberCheck.Length > 2)
                    //{
                    //	var shortName = mpd.TaskNumberCheck.Substring(1, 2);
                    //	mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(shortName));

                    //}
                    //mpd.MPDTaskNumber = "D6-38278";
                    //mpd.IsOperatorTask = false;
                    //mpd.MpdRevisionDate = new DateTime(2018, 9, 25);
                    //mpd.Threshold.EffectiveDate = new DateTime(2018, 10, 1);
                    //mpd.ScheduleRevisionDate = new DateTime(2018, 10, 1);
                    //mpd.ScheduleRevisionNum = "1";
                    //mpd.ScheduleRef = "SC-C011-MP";


                    #endregion

                    //env.Keeper.Save(mpd);

                }
            }
		}

		[TestMethod]
		public void ImportMaintenanceDirectivesCRJ()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\MPD\CRJ\2.2.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2341);

			var bd = componentCore.GetAicraftBaseComponents(aircraft.ItemId, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO, AtaChapter>();

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{

                    if(string.IsNullOrEmpty(row[1].ToString()))
                        continue;

                    MaintenanceDirective find;
                    var finds = mpds
	                    .Where(i => i.TaskNumberCheck.ToLower().Trim().Equals(row[1].ToString().ToLower().Trim()))
	                    .OrderBy(i => i.PerformanceRecords.Count > 0)
	                    .ToList();
					
					//Такой колхоз сделан потому что бывает что mpd две с одинаковым названием
					var flag = false;


					find = finds.FirstOrDefault();

					MaintenanceDirective mpd;

					if (find != null)
					{
						mpd = find;
						finds.Remove(find);
					}
					else
					{
						mpd = new MaintenanceDirective()
						{
							ParentBaseComponent = bd,
							HiddenRemarks = "NEW",
						};
						flag = true;
					}

					SetupCRJ(mpd, row, ata, flag);
                    

					var taskCards = row[2].ToString().Split(new string[]{"\n"}, StringSplitOptions.None);
					var counter = 1;
					if (taskCards.Count() > 1)
					{
						foreach (var taskCard in taskCards)
						{
							if (string.IsNullOrEmpty(taskCard))
								continue;
							

							if (counter == 1)
							{
								mpd.TaskNumberCheck = $"{row[1]} ({counter})";
								mpd.TaskCardNumber = taskCard;

                                //env.Keeper.Save(mpd);
                                counter++;
							}
							else
							{
								var mpdExist = finds.FirstOrDefault();
								if (mpdExist != null)
								{
									SetupCRJ(mpdExist, row, ata, flag);
									mpdExist.TaskNumberCheck = $"{row[1]} ({counter})";
									mpdExist.TaskCardNumber = taskCard;

									//env.Keeper.Save(mpdExist);
									finds.Remove(mpdExist);
								}
								else
								{
									var newMpd = mpd.GetCopyUnsaved();
									SetupCRJ(newMpd, row, ata, flag);
									newMpd.ParentBaseComponent = bd;
									newMpd.TaskNumberCheck = $"{row[1]} ({counter})";
									newMpd.TaskCardNumber = taskCard;

									//env.Keeper.Save(newMpd);

									foreach (var record in mpd.PerformanceRecords)
									{
										var newRec = record.GetCopyUnsaved();
										newRec.ParentId = newMpd.ItemId;
										//env.Keeper.Save(newRec);
									}
								}
								counter++;
							}
						}	
					}
					else
					{
						mpd.TaskCardNumber = row[2].ToString();
						//env.Keeper.Save(mpd);
					}
				}
			}
		}

		[TestMethod]
		public void ImportMaintenanceDirectives757()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\111\737\zip.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2335);

			var bd = componentCore.GetAicraftBaseComponents(aircraft.ItemId, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO, AtaChapter>();

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if (string.IsNullOrEmpty(row[0].ToString()))
						continue;

                    MaintenanceDirective find = mpds.FirstOrDefault(i => i.TaskNumberCheck.ToLower().Trim().Equals(row[0].ToString().ToLower().Trim()));

                    //Такой колхоз сделан потому что бывает что mpd две с одинаковым названием
                    var flag = false;


					MaintenanceDirective mpd;

					if (find != null)
					{
						mpd = find;
					}
					else
					{
						mpd = new MaintenanceDirective()
						{
							ParentBaseComponent = bd,
							HiddenRemarks = "NEW",
						};
						flag = true;
					}

					
					mpd.TaskNumberCheck = row[0].ToString();
					mpd.MaintenanceManual = row[1].ToString();


                    #region SYSTEMS AND POWERPLANT MAINTENA

                    //mpd.Program = MaintenanceDirectiveProgramType.SystemsAndPowerPlants;
                    //mpd.MpdRef = "SYSTEMS AND POWERPLANT MAINTENA";

                    //if (!string.IsNullOrEmpty(row[2].ToString()))
                    //{
                    //    int res;
                    //    if (int.TryParse(row[2].ToString(), out res))
                    //        mpd.Category = MpdCategory.GetItemById(res);
                    //}

                    //mpd.Zone = row[6].ToString().Replace("\n", " ");
                    //mpd.Access = row[7].ToString().Replace("\n", " ");

                    //if (!string.IsNullOrEmpty(row[10].ToString()))
                    //{
                    //    double mhr;
                    //    if (double.TryParse(row[10].ToString(), out mhr))
                    //        mpd.ManHours = mhr;
                    //}

                    //var apl = row[8].ToString();
                    //if (apl.Contains("ALL"))
                    //{
                    //    mpd.IsApplicability = true;
                    //}

                    //mpd.Description = row[11].ToString();

                    #endregion

                    #region STRUCTURAL MAINTENANCE REQUIREM

                    //mpd.Program = MaintenanceDirectiveProgramType.StructuresMaintenance;
                    //mpd.MpdRef = "STRUCTURAL MAINTENANCE REQUIREM";

                    //if (!string.IsNullOrEmpty(row[9].ToString()))
                    //{
                    //    double mhr;
                    //    if (double.TryParse(row[9].ToString(), out mhr))
                    //        mpd.ManHours = mhr;
                    //}

                    //if (!string.IsNullOrEmpty(row[2].ToString()))
                    //    mpd.ProgramIndicator = MaintenanceDirectiveProgramIndicator.Items
                    //        .FirstOrDefault(i => i.ShortName.Contains(row[2].ToString()));

                    //mpd.Zone = row[3].ToString().Replace("\n", " ");
                    //mpd.Access = row[4].ToString().Replace("\n", " ");

                    //var apl = row[7].ToString();
                    //if (apl.Contains("ALL"))
                    //{
                    //    mpd.IsApplicability = true;
                    //}

                    //mpd.Description = row[10].ToString();

                    #endregion

                    #region ZONAL INSPECTION PROGRAM

                    //mpd.Program = MaintenanceDirectiveProgramType.ZonalInspection;
                    //mpd.MpdRef = "ZONAL INSPECTION PROGRAM";

                    //if (!string.IsNullOrEmpty(row[8].ToString()))
                    //{
                    //    double mhr;
                    //    if (double.TryParse(row[8].ToString(), out mhr))
                    //        mpd.ManHours = mhr;
                    //}

                    //mpd.Zone = row[2].ToString().Replace("\n", " ");
                    //mpd.Access = row[3].ToString().Replace("\n", " ");

                    //var apl = row[6].ToString();
                    //if (apl.Contains("ALL"))
                    //{
                    //    mpd.IsApplicability = true;
                    //}

                    //mpd.Description = row[9].ToString();

                    #endregion

                    if (flag)
						mpd.HiddenRemarks = "NEW";

					if (mpd.TaskNumberCheck.Length > 2)
					{
						var shortName = mpd.TaskNumberCheck.Substring(0, 2);
						mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(shortName));
					}

					mpd.MPDTaskNumber = "D626A001";
					mpd.IsOperatorTask = false;
					mpd.MpdRevisionDate = new DateTime(2019, 2, 15);
					mpd.Threshold.EffectiveDate = new DateTime(2018, 8, 23);
					mpd.ScheduleRevisionDate = new DateTime(2018, 8, 23);
					mpd.ScheduleRevisionNum = "0";
					mpd.ScheduleRef = "SC-C014-MP";
                    env.Keeper.Save(mpd);
                }
			}
		}

		[TestMethod]
		public void ImportMaintenanceDirectives757Total()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\111\737\task.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2335);

			var bd = componentCore.GetAicraftBaseComponents(aircraft.ItemId, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO, AtaChapter>();

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{

					if (string.IsNullOrEmpty(row[0].ToString()))
						continue;

					MaintenanceDirective find;
					var finds = mpds
						.Where(i => i.TaskNumberCheck.ToLower().Trim().Equals(row[0].ToString().ToLower().Trim()))
						.OrderBy(i => i.PerformanceRecords.Count > 0)
						.ToList();

					//Такой колхоз сделан потому что бывает что mpd две с одинаковым названием
					var flag = false;


					find = finds.FirstOrDefault();

					MaintenanceDirective mpd;

					if (find != null)
					{
						mpd = find;
						finds.Remove(find);
					}
					else
					{
						mpd = new MaintenanceDirective()
						{
							ParentBaseComponent = bd,
							HiddenRemarks = "NEW",
						};
						flag = true;
					}

					Setup757Total(mpd, row, ata, flag);


					var taskCards = row[2].ToString().Split(new string[] { "\n" }, StringSplitOptions.None);
					var counter = 1;
					if (taskCards.Count() > 1)
					{
						foreach (var taskCard in taskCards)
						{
							if (string.IsNullOrEmpty(taskCard))
								continue;


							if (counter == 1)
							{
								mpd.TaskNumberCheck = $"{row[0]} ({counter})";
								mpd.TaskCardNumber = taskCard;

								env.Keeper.Save(mpd);
								counter++;
							}
							else
							{
								var mpdExist = finds.FirstOrDefault();
								if (mpdExist != null)
								{
									Setup757Total(mpdExist, row, ata, flag);
									mpdExist.TaskNumberCheck = $"{row[0]} ({counter})";
									mpdExist.TaskCardNumber = taskCard;

									env.Keeper.Save(mpdExist);
									finds.Remove(mpdExist);
								}
								else
								{
									var newMpd = mpd.GetCopyUnsaved();
									Setup757Total(newMpd, row, ata, flag);
									newMpd.ParentBaseComponent = bd;
									newMpd.TaskNumberCheck = $"{row[0]} ({counter})";
									newMpd.TaskCardNumber = taskCard;

									env.Keeper.Save(newMpd);

									foreach (var record in mpd.PerformanceRecords)
									{
										var newRec = record.GetCopyUnsaved();
										newRec.ParentId = newMpd.ItemId;
										env.Keeper.Save(newRec);
									}
								}
								counter++;
							}
						}
					}
					else
					{
						mpd.TaskCardNumber = row[2].ToString();
						env.Keeper.Save(mpd);
					}
				}
			}
		}

		[TestMethod]
		public void ImportMaintenanceDirectives757TotalFinish()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore,
				itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\111\737\task.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2335);

			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if (string.IsNullOrEmpty(row[0].ToString()))
						continue;

					var taskCards = row[2].ToString().Split(new string[] { "\n" }, StringSplitOptions.None);

					foreach (var card in taskCards)
					{
						var finds = mpds
							.Where(i => i.TaskCardNumber.ToLower().Trim().Equals(card.ToLower().Trim()))
							.OrderBy(i => i.PerformanceRecords.Count > 0)
							.ToList();

						foreach (var mpd in finds)
						{
							mpd.TaskNumberCheck = row[0].ToString();
							env.NewKeeper.Save(mpd);
						}
					}
				}
			}
		}

		[TestMethod]
		public void ImportTaskCard()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, null);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var maintenanceCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var aircraft = env.NewLoader.GetObject<AircraftDTO, Aircraft>(new Filter("ItemId", 2340));

			var mpdList = maintenanceCore.GetMaintenanceDirectives(aircraft);

			var d = new DirectoryInfo(@"D:\MPD\All Task Cards for UP-B6703");
			var files = d.GetFiles();
			foreach (var mpd in mpdList)
			{
				var file = files.FirstOrDefault(f => f.Name.Replace(".pdf", "") == mpd.TaskCardNumber);
				if (file != null)
				{
					var _fileData = UsefulMethods.GetByteArrayFromFile(file.FullName);
					var attachedFile = new AttachedFile
					{
						FileData = _fileData,
						FileName = file.Name,
						FileSize = _fileData.Length
					};
					mpd.TaskCardNumberFile = attachedFile;
					env.NewKeeper.Save(mpd);
				}
				else
				{
					Trace.WriteLine(mpd.TaskNumberCheck);
				}
			}
		}

		[TestMethod]
		public void Test()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);
			aircraftCore.LoadAllAircrafts();
			var aircraftFrom = aircraftCore.GetAircraftById(2336);
			//var aircraftTo = aircraftCore.GetAircraftById(2347);

			var mpdsFrom = mpdCore.GetMaintenanceDirectives(aircraftFrom);
			//var mpdsTo = mpdCore.GetMaintenanceDirectives(aircraftTo);

			foreach (var maintenanceDirective in mpdsFrom.Where(i => i.IsOperatorTask))
			{
				maintenanceDirective.IsOperatorTask = false;
				env.Keeper.Save(maintenanceDirective);
				Trace.WriteLine($"{maintenanceDirective.TaskNumberCheck}");
				//var find = mpdsTo.FirstOrDefault(i => i.TaskNumberCheck.TrimEnd() == maintenanceDirective.TaskNumberCheck.TrimEnd());
				//if (find == null)
				//	continue;
				//Trace.WriteLine($"{maintenanceDirective.TaskNumberCheck} - {find?.TaskNumberCheck ?? "N/A"}");
				//Trace.WriteLine(maintenanceDirective.Kits.Count);
				//Trace.WriteLine("------------------------");

				//find.KitsApplicable = true;
				//env.Keeper.Save(find);

				//foreach (var accessoryRequired in find.Kits)
				//{
				//	env.Keeper.Delete(accessoryRequired);
				//}

				//foreach (var rec in maintenanceDirective.Kits)
				//{
				//	var newRec = rec.GetCopyUnsaved();
				//	newRec.ParentId = find.ItemId;
				//	env.Keeper.Save(newRec);
				//}
			}
		}

		private void SetupCRJ(MaintenanceDirective mpd, DataRow row, IList<AtaChapter> ata, bool isNew)
		{
			#region Appendix

			//Appendix
			//mpd.MpdRef = "Appendix G";

			// mpd.TaskNumberCheck = row[1].ToString();
			//mpd.Description = row[2].ToString();
			//mpd.MpdRef = "Appendix A";

			//var apl = row[5].ToString();
			//if (apl.Contains("ALL"))
			//{
			//	mpd.IsApplicability = true;
			//}

			//mpd.MPDTaskNumber = row[5].ToString();
			//mpd.MaintenanceManual = row[6].ToString();
			//mpd.Workarea = row[8].ToString();
			//mpd.Access = row[9].ToString();
			//mpd.Remarks = row[10].ToString();

			#endregion

			#region Section

			//Section 2.2
			mpd.Program = MaintenanceDirectiveProgramType.SystemsAndPowerPlants;
			mpd.MpdRef = "Section 2.2";

			//Section 2.3
			//mpd.Program = MaintenanceDirectiveProgramType.StructuresMaintenance;
			//mpd.MpdRef = "Section 2.3";

			//Section 2.4
			//mpd.Program = MaintenanceDirectiveProgramType.ZonalInspection;
			//mpd.MpdRef = "Section 2.4";

			//Section 2.5
			//mpd.Program = MaintenanceDirectiveProgramType.CPCP;
			//mpd.MpdRef = "Section 2.5";

			//Section 2.6
			//mpd.Program = MaintenanceDirectiveProgramType.CertificationMaintenanceRequirement;
			//mpd.MpdRef = "Section 2.6";

			//Section 2.7
			//mpd.Program = MaintenanceDirectiveProgramType.AWLandCMR;
			//mpd.MpdRef = "Section 2.7";

			//Section 2.8
			//mpd.Program = MaintenanceDirectiveProgramType.SupplementaryRequirements;
			//mpd.MpdRef = "Section 2.8";

			//Section 2.9
			//mpd.Program = MaintenanceDirectiveProgramType.FuelTankSystemMaintenanceProgram;
			//mpd.MpdRef = "Section 2.9";

			//Section 2.10
			//mpd.Program = MaintenanceDirectiveProgramType.ElectricalWipingInterconnectionSystem;
			//mpd.MpdRef = "Section 2.10";

			mpd.TaskNumberCheck = row[1].ToString();
			mpd.MaintenanceManual = row[3].ToString();

			#endregion

			if (isNew)
				mpd.HiddenRemarks = "NEW";

			if (mpd.TaskNumberCheck.Length > 2)
			{
				var shortName = mpd.TaskNumberCheck.Substring(0, 2);
				mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(shortName));
			}

			mpd.MPDTaskNumber = "CSP A-054-000";
			mpd.IsOperatorTask = false;
			mpd.MpdRevisionDate = new DateTime(2018, 10, 10);
			mpd.Threshold.EffectiveDate = new DateTime(2018, 1, 22);
			mpd.ScheduleRevisionDate = new DateTime(2018, 1, 22);
			mpd.ScheduleRevisionNum = "0";
			mpd.MpdRevisionNum = "38";
			mpd.ScheduleRef = "MP SCAT/CRJ/AMP/I4/R00";
		}

		private void Setup757Total(MaintenanceDirective mpd, DataRow row, IList<AtaChapter> ata, bool isNew)
		{
			mpd.TaskNumberCheck = row[0].ToString();
			mpd.MpdRevisionNum = row[1].ToString();
			mpd.Remarks = row[3].ToString();

			if (isNew)
				mpd.HiddenRemarks = "NEW";

			if (mpd.TaskNumberCheck.Length > 2)
			{
				var shortName = mpd.TaskNumberCheck.Substring(0, 2);
				mpd.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(shortName));
			}

            mpd.MPDTaskNumber = "D626A001";
            mpd.IsOperatorTask = false;
            mpd.MpdRevisionDate = new DateTime(2019, 2, 15);
            mpd.Threshold.EffectiveDate = new DateTime(2018, 8, 23);
            mpd.ScheduleRevisionDate = new DateTime(2018, 8, 23);
            mpd.ScheduleRevisionNum = "0";
            mpd.ScheduleRef = "SC-C014-MP";

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
	}
}