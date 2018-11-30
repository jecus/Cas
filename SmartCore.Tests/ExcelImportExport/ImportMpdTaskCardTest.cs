﻿using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Auxiliary;
using EFCore.DTO.General;
using EFCore.Filter;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class ImportMpdTaskCardTest
	{
		[TestMethod]
		public void ImportTaskCard()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, null);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var maintenanceCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore , aircraftCore);

			var aircraft = env.NewLoader.GetObject<AircraftDTO,Aircraft>(new Filter("ItemId", 2332));

			var mpdList = maintenanceCore.GetMaintenanceDirectives(aircraft);

			var d = new DirectoryInfo(@"D:\123\LY-AWD TC");
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
					Trace.WriteLine(mpd);
				}
			}
		}

		[TestMethod]
		public void Test()
		{
			var env = GetEnviroment();

			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, null);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var maintenanceCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);

			var aircraft = env.NewLoader.GetObject<AircraftDTO, Aircraft>(new Filter("ItemId", 2348));

			var mpdList = maintenanceCore.GetMaintenanceDirectives(aircraft);

			var bd = componentCore.GetAicraftBaseComponents(2348, BaseComponentType.Frame.ItemId).FirstOrDefault();

			var d = new DirectoryInfo(@"H:\TaskCard\ALL for Yevhenij");
			var files = d.GetFiles();

			var ds = ExcelToDataTableUsingExcelDataReader(@"H:\Card.xlsx");

			var dict = new Dictionary<string, List<DataRow>>();

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if(!dict.ContainsKey(row[1].ToString()))
						dict.Add(row[1].ToString(), new List<DataRow>{row});
					else dict[row[1].ToString()].Add(row);
				}
			}

			foreach (var mpd in mpdList)
			{
				int counter = 1;
				var description = mpd.Description;

				if(mpd.Program.ItemId == MaintenanceDirectiveProgramType.StructuresMaintenance.ItemId || mpd.Program.ItemId == MaintenanceDirectiveProgramType.SystemsAndPowerPlants.ItemId ||
				   mpd.Program.ItemId == MaintenanceDirectiveProgramType.ZonalInspection.ItemId)
				{ 


				if (!dict.ContainsKey(mpd.TaskNumberCheck))
				{
					Trace.WriteLine(mpd.TaskNumberCheck);
					continue;
				}

				foreach (var row in dict[mpd.TaskNumberCheck])
				{
					if (counter == 1)
					{
						mpd.TaskCardNumber = row[0].ToString();

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

							mpd.Description += $" / TaskCard : {row[2]}";
							mpd.TaskCardNumberFile = attachedFile;
						}

						if (dict[mpd.TaskNumberCheck].Count > 1)
							mpd.TaskNumberCheck += $" ({counter})";
						
						env.NewKeeper.Save(mpd);
						counter++;
					}
					else
					{
						var newMpd = mpd.GetCopyUnsaved();
						newMpd.TaskCardNumber = row[0].ToString();
						newMpd.TaskCardNumberFile = null;

						var file = files.FirstOrDefault(f => f.Name.Replace(".pdf", "") == newMpd.TaskCardNumber);
						if (file != null)
						{
							var _fileData = UsefulMethods.GetByteArrayFromFile(file.FullName);
							var attachedFile = new AttachedFile
							{
								FileData = _fileData,
								FileName = file.Name,
								FileSize = _fileData.Length
							};
							
							newMpd.TaskCardNumberFile = attachedFile;
							newMpd.Description = $"{description} / TaskCard : {row[2]}";
						}

						newMpd.TaskNumberCheck = $"{row[1]} ({counter})";
						newMpd.ParentBaseComponent = bd;
						env.NewKeeper.Save(newMpd);
						counter++;
					}
				}
			}
		}
		}


		[TestMethod]
		public void ImportAdTAskCArd()
		{
			var env = GetEnviroment();

			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var directiveCore = new DirectiveCore(env.NewKeeper, env.NewLoader, env.Loader, itemRelationCore);

			var aircraft = env.NewLoader.GetObject<AircraftDTO, Aircraft>(new Filter("ItemId", 2348));

			var directiveList = directiveCore.GetDirectives(aircraft, DirectiveType.AirworthenessDirectives);

			var d = new DirectoryInfo(@"H:\CRJ200 27.02.18 AD");
			var files = d.GetFiles();

			foreach (var mpd in directiveList)
			{
				var file = files.FirstOrDefault(f => mpd.Title.Contains(f.Name.Replace(" ", "").Replace(".pdf", "")));
				if (file != null)
				{
					var _fileData = UsefulMethods.GetByteArrayFromFile(file.FullName);
					var attachedFile = new AttachedFile
					{
						FileData = _fileData,
						FileName = file.Name,
						FileSize = _fileData.Length
					};
					mpd.ADNoFile = attachedFile;
					env.NewKeeper.Save(mpd);
				}
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("92.47.31.254:45617", "casadmin", "casadmin001", "ScatDBTest");
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