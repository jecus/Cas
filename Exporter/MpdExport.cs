using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;
using System.Linq;
using CAS.UI.Helpers;
using Excel;
using SmartCore;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities.General;
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
			var aircraftFlightCore = new AircraftFlightCore(env, env.Loader, env.NewLoader, null, null, componentCore, null, aircraftCore);
			var calc = new Calculator(env, componentCore, aircraftFlightCore, aircraftCore);
			
			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2316);
			var mpds = mpdCore.GetMaintenanceDirectives(aircraft);

			int q = 0;
			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\MPD.xlsx");
			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var mpd = mpds.FirstOrDefault(i => i.TaskNumberCheck == row[0].ToString());
					if(mpd == null)
						continue;
					
					var record = new DirectiveRecord
					{
						Parent = mpd,
						ParentId = mpd.ItemId,                                                
						OnLifelength = new Lifelength(),
					};
					
					if(int.TryParse(row[2].ToString(), out var hour))
						record.OnLifelength.Hours = hour;
					if(int.TryParse(row[3].ToString(), out var cycle))
						record.OnLifelength.Cycles = cycle;
					if(DateTime.TryParse(row[4].ToString(), out var date))
						record.RecordDate = date;

					var res = calc.GetFlightLifelengthOnStartOfDay(aircraft, date);
					
					if ((hour > 0 || cycle > 0) && date != DateTime.MinValue)
					{
						record.OnLifelength.Days = res.Days;
						//Trace.WriteLine(row[0].ToString());
						env.NewKeeper.Save(record);
					}

					
					
					
					
				}
			}
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
