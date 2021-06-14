using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CAS.UI.Helpers;
using Excel;
using SmartCore;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace Exporter
{
	[TestClass]
	public class MpdExport
	{
		[TestMethod]
		public void Export()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var mpdCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var frame = componentCore.GetAicraftBaseComponents(2316, BaseComponentType.Frame.ItemId).FirstOrDefault();

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\MPD.xlsx");
			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var mpd = new MaintenanceDirective();
					mpd.TaskNumberCheck = row[2].ToString();
					mpd.SourceTaskReference = row[3].ToString();
					mpd.Access = row[4].ToString();
					mpd.Zone = row[6].ToString();
					mpd.Description = row[7].ToString();
					mpd.Reference = row[17].ToString();
					//mpd.ManHours = double.Parse(row[19].ToString().Substring(0, 3).Replace('.',','));
					//mpd.Skill = row[7].ToString(); ????
					//mpd.WorkType = row[8].ToString(); ???
					mpd.Applicability = row[22].ToString();
					mpd.ParentBaseComponent = frame;

					env.NewKeeper.Save(mpd);
				}
			}

			Console.WriteLine();
			
		}



		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.ApiProvider = new ApiProvider("http://91.213.233.139:45620");
			cas.Connect("91.213.233.139:45620", "casadmin", "111111", "MoalemDB");
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
