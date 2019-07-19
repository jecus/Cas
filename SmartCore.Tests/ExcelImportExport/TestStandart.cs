using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class TestStandart
	{

		[TestMethod]
		public void Snadart()
		{
			var env = GetEnviroment();

			var standarts = env.Loader.GetObjectList<GoodStandart>();
			var products = env.Loader.GetObjectList<Product>();
			var compModel = env.Loader.GetObjectList<ComponentModel>();
			var comp = env.Loader.GetObjectList<Entities.General.Accessory.Component>();
			var baseComponents = env.Loader.GetObjectList<BaseComponent>();

			foreach (var group in standarts.GroupBy(i => i.FullName))
			{
				if (group.Key == "")
				{
					foreach (var standart in group)
					{
						standart.FullName = "N/A";
						env.Keeper.Save(standart);
					}
				}
				else
				{
					if(group.Count() <=  1)
						continue;

					var st = group.First();
					foreach (var standart in group)
					{
						if(standart.ItemId == st.ItemId)
							continue;

						foreach (var prod in products.Where(i => i.Standart?.ItemId == st.ItemId))
						{
							prod.Standart = st;
							env.Keeper.Save(prod);
						}
						foreach (var prod in compModel.Where(i => i.Standart?.ItemId == st.ItemId))
						{
							prod.Standart = st;
							env.Keeper.Save(prod);
						}
						foreach (var prod in comp.Where(i => i.Standart?.ItemId == st.ItemId))
						{
							prod.Standart = st;
							env.Keeper.Save(prod);
						}
						foreach (var prod in baseComponents.Where(i => i.Standart?.ItemId == st.ItemId))
						{
							prod.Standart = st;
							env.Keeper.Save(prod);
						}

						env.Keeper.Delete(standart);
					}
				}
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139:45617", "casadmin", "casadmin001", "ScatDBTest");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}