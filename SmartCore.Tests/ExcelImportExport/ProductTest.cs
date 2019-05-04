using System.Data;
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
	public class ProductTest
	{
		[TestMethod]
		public void ImportProduct()
		{
			var env = GetEnviroment();

			var products = env.Loader.GetObjectList<Product>();
			var standart = env.Loader.GetObjectList<GoodStandart>();
			var ata = env.Loader.GetObjectList<AtaChapter>();

			var ds = ExcelToDataTableUsingExcelDataReader(@"D:\1.xlsx");
			foreach (DataTable table in ds.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					var prod = products.FirstOrDefault(i => i.Name.ToLower().Equals(row[3].ToString().ToLower()));

					if (prod == null)
						prod = new Product{DescRus = "NEW"};

					prod.Description = row[1].ToString();
					prod.Standart = standart.FirstOrDefault(i => i.FullName.ToLower().Contains(row[2].ToString().ToLower()));
					prod.Name = !string.IsNullOrEmpty(row[3].ToString()) ? row[3].ToString() : "*";
					prod.GoodsClass = (GoodsClass) GoodsClass.Items.GetByFullName(row[6].ToString());
					prod.IsEffectivity = row[7].ToString();
					prod.Remarks = row[8].ToString();
					prod.PartNumber = row[9].ToString();
					prod.AltPartNumber = row[10].ToString();
					prod.ATAChapter = ata.FirstOrDefault(a => a.ShortName.Equals(row[11].ToString()));

					//env.Keeper.Save(prod);
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