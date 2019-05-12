using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class ProductImport
	{
		[TestMethod]
		public void ImportProduct()
		{
			var env = GetEnviroment();

			var products = env.Loader.GetObjectList<Product>();
			var standarts = env.Loader.GetObjectList<GoodStandart>();
			var ata = env.Loader.GetObjectList<AtaChapter>();

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\1.xlsx");
			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var prod = products.FirstOrDefault(i => i.Name.ToLower().Equals(row[3].ToString().ToLower()));

					if (prod == null)
						prod = new Product{DescRus = "NEW"};

					

					if (!string.IsNullOrEmpty(row[2].ToString()))
					{
						var standart = standarts.FirstOrDefault(i => i.FullName.ToLower().Contains(row[2].ToString().ToLower()));

						if (standart == null)
						{
							standart = new GoodStandart()
							{
								FullName = row[2].ToString(),
								Description = row[1].ToString(),
								PartNumber = "*"
							};
							env.NewKeeper.Save(standart);
							standarts.Add(standart);
						}

						prod.Standart = standart;
					}

					var goodClass = row[6].ToString().Replace('−', '-');

					prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Equals(i.FullName.ToLower()));
					if (prod.GoodsClass == null)
						prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.FullName.ToLower()));
					if (prod.GoodsClass == null)
						prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.ShortName.ToLower()));

					prod.Reference = row[0].ToString().Replace('−', '-');
					prod.Description = row[1].ToString();
					prod.Name = !string.IsNullOrEmpty(row[3].ToString()) ? row[3].ToString() : "*";
					prod.IsEffectivity = row[7].ToString();
					prod.Remarks = row[8].ToString();
					prod.PartNumber = row[9].ToString();
					prod.AltPartNumber = row[10].ToString();
					prod.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(row[11].ToString()));

					env.Keeper.Save(prod);
				}
			}
		}


		[TestMethod]
		public void ImportProductStoreCIT()
		{
			var env = GetEnviroment();

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\B737.757.767 CIT 08.05.2019 E&M.xls");

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if(string.IsNullOrEmpty(row[4].ToString()) && string.IsNullOrEmpty(row[5].ToString()) && string.IsNullOrEmpty(row[6].ToString()))
						continue;

					var prod = new Product { DescRus = "CIT EM" };

					var goodClass = row[0].ToString().Replace('−', '-');

					prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Equals(i.FullName.ToLower()));
					if (prod.GoodsClass == null)
						prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.FullName.ToLower()));
					if (prod.GoodsClass == null)
						prod.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.ShortName.ToLower()));

					prod.Name = !string.IsNullOrEmpty(row[4].ToString()) ? row[4].ToString() : "*";
					prod.PartNumber = row[5].ToString();
					prod.AltPartNumber = row[6].ToString();
					prod.IsEffectivity = row[19].ToString();

					prod.Reference = "*";
					prod.Remarks = "*";


					env.Keeper.Save(prod);
				}
			}
		}


		[TestMethod]
		public void ImportComponentStoreCIT()
		{
			var env = GetEnviroment();

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\B737.757.767 CIT 11.05.2019 Компоненты.xls");

			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					if (string.IsNullOrEmpty(row[1].ToString()) && string.IsNullOrEmpty(row[4].ToString()) && string.IsNullOrEmpty(row[5].ToString()))
						continue;

					var model = new ComponentModel { DescRus = "CIT Comp" };

					var goodClass = row[0].ToString().Replace('−', '-');

					model.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Equals(i.FullName.ToLower()));
					if (model.GoodsClass == null)
						model.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.FullName.ToLower()));
					if (model.GoodsClass == null)
						model.GoodsClass = GoodsClass.Items.FirstOrDefault(i => goodClass.ToLower().Contains(i.ShortName.ToLower()));

					model.Name = !string.IsNullOrEmpty(row[4].ToString()) ? row[4].ToString() : "*";
					model.Description = model.Name;
					model.PartNumber = row[5].ToString();
					model.AltPartNumber = row[6].ToString();
					model.IsEffectivity = row[19].ToString();

					model.Reference = "*";
					model.Remarks = "*";


					env.Keeper.Save(model);
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