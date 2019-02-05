using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using EFCore.DTO.Dictionaries;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class ImportExcelMpd
	{
		[TestMethod]
		public void ImportMaintenanceDirectivesTest()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\123\7.xlsx");

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2316);

			var bd = componentCore.GetAicraftBaseComponents(aircraft.ItemId, BaseComponentType.Frame.ItemId).FirstOrDefault();
			var ata = env.NewLoader.GetObjectListAll<ATAChapterDTO, AtaChapter>();



			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			MaintenanceDirective savedMpd = null;

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var find = mpds.FirstOrDefault(i =>
						i.TaskNumberCheck.ToLower().Equals(row[0].ToString().ToLower()));

					#region Добавление Mpd TaskNumber(Appendix B - Old to New XRef)

					//if (find != null)
					//{
					//	find.MpdOldTaskCard = row[2].ToString();
					//	find.TaskCardNumber = row[3].ToString();
					//	//env.Keeper.Save(find);
					//}

					#endregion


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

					//env.Keeper.Save(find);

				}
			}
		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139:45617", "casadmin", "casadmin001", "ScatDB");
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