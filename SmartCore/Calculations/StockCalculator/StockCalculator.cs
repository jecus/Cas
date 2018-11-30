using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Calculations.StockCalculator
{
	public class StockCalculator : IStockCalculator
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly INewLoader _newLoader;
		private readonly IComponentCore _componentCore;
		
		public StockCalculator(ICasEnvironment casEnvironment, INewLoader newLoader, IComponentCore componentCore)
		{
			_casEnvironment = casEnvironment;
			_newLoader = newLoader;
			_componentCore = componentCore;
		}

		#region public void CalculateStock(IEnumerable<StockComponentInfo> itemsStock, Store store)
		/// <summary>
		/// Расчитывает тек. кол-во комплектующих, переданных в записях о неснижаемых запасах на заданном складу
		/// </summary>
		/// <param name="itemsStock">Записи о неснижаемом запасе</param>
		/// <param name="store">Задает склад, на котором надо проверить данные о неснижаемых запасах</param>
		public void CalculateStock(IEnumerable<StockComponentInfo> itemsStock, Store store)
		{
			var allStorescomponents = new List<Entities.General.Accessory.Component>();
			var baseComponentCollection = new List<BaseComponent>(_componentCore.GetStoreBaseComponents(store.ItemId));

			allStorescomponents.AddRange(_componentCore.GetStoreComponents(store).ToArray());

			//////////////////////////////////////////////////////
			//   проверка на установленные базовые компоненты   //
			//////////////////////////////////////////////////////
			var lastInstalledBaseComponents = _casEnvironment.BaseComponents.GetLastInstalledComponentsOn(store);
			foreach (var baseComponent in lastInstalledBaseComponents)
			{
				//удаление данного компонента из коллекции
				//т.к. его отображать не нужно
				baseComponentCollection.Remove(baseComponent);
			}

			if (baseComponentCollection.Count > 0)
			{
				allStorescomponents.AddRange(baseComponentCollection.ToArray());
				allStorescomponents.AddRange(_componentCore.GetComponents(baseComponentCollection).ToArray());
			}

			foreach (var component in allStorescomponents)
			{
				foreach (StockComponentInfo t in itemsStock)
				{
					if (t.GoodsClass != component.GoodsClass ||
						t.PartNumber.Replace(" ", "").ToLower() != component.PartNumber.Replace(" ", "").ToLower())
						continue;

					if (component.Quantity <= 0)
						component.Quantity = 1;
					t.Current += component.Quantity;
				}
			}
		}

		#endregion

		#region public void CalculateStock(StockComponentInfo itemStock)
		/// <summary>
		/// Расчитывает тек. кол-во комплектующих, переданных в записях о неснижаемых запасах
		/// </summary>
		/// <param name="itemStock">Записи о неснижаемом запасе</param>
		public void CalculateStock(StockComponentInfo itemStock)
		{
			if (itemStock == null || _casEnvironment.Stores.GetItemById(itemStock.StoreId) == null)
				return;

			itemStock.Current = 0;
			var store = _casEnvironment.Stores.GetItemById(itemStock.StoreId);

			var allStorescomponents = new List<Entities.General.Accessory.Component>();
			allStorescomponents.AddRange(_componentCore.GetStoreBaseComponents(store.ItemId));
			allStorescomponents.AddRange(_componentCore.GetStoreComponents(store).ToArray());

			foreach (var component in allStorescomponents)
			{
				if (itemStock.GoodsClass == component.GoodsClass &&
					itemStock.PartNumber.Replace(" ", "").ToLower() == component.PartNumber.Replace(" ", "").ToLower())
				{
					if (component.Quantity <= 0)
						component.Quantity = 1;
					itemStock.Current += component.Quantity;
				}
			}
		}

		#endregion

		#region public void CalculateStock(Component[] components, Store store)
		/// <summary>
		/// Расчитывает тек. кол-во комплектующих, и необходимый запас каждого комплектующего на заданном складу
		/// </summary>
		/// <param name="components">записи о неснижаемом запасе"></param>
		/// <param name="store">Задает склад, на котором надо проверить данные о неснижаемых запасах</param>
		public void CalculateStock(Entities.General.Accessory.Component[] components, Store store)
		{
			List<StockComponentInfo> allShouldBe = new List<StockComponentInfo>();
			
			allShouldBe.AddRange(_newLoader.GetObjectListAll<StockComponentInfoDTO, StockComponentInfo>(new Filter("StoreID", store.ItemId),true));

			foreach (var stock in allShouldBe)
			{
				IEnumerable<Entities.General.Accessory.Component> currentStock =
					components.Where(t => t.GoodsClass == stock.GoodsClass &&
									   t.PartNumber.Replace(" ", "").ToLower() ==
									   stock.PartNumber.Replace(" ", "").ToLower()).ToArray();

				if (!currentStock.Any())
					continue;
				var current = currentStock.Sum(component => component.Quantity <= 0 ? 1 : component.Quantity);

				foreach (Entities.General.Accessory.Component t in currentStock)
				{
					t.Current = current;
					t.ShouldBeOnStock = stock.ShouldBeOnStock;
				}
			}
		}

		#endregion

		#region public void CalculateStock(IEnumerable<Component> components, IEnumerable<StockComponentInfo> stockComponentInfos)
		/// <summary>
		/// Расчитывает тек. кол-во комплектующих, и необходимый запас каждого комплектующего
		/// </summary>
		/// <param name="stockComponentInfos">Записи о неснижаемом запасе</param>
		/// <param name="components">комплектующие, имеющиеся в наличии></param>
		public void CalculateStock(Entities.General.Accessory.Component[] components, IEnumerable<StockComponentInfo> stockComponentInfos)
		{
			var dontHaveStockInfo = new List<Entities.General.Accessory.Component>(components);

			foreach (var stock in stockComponentInfos)
			{
				IEnumerable<Entities.General.Accessory.Component> currentStock =
					components.Where(t => t.GoodsClass == stock.GoodsClass &&
									   t.PartNumber.Replace(" ", "").ToLower() ==
									   stock.PartNumber.Replace(" ", "").ToLower()).ToArray();

				foreach (var component in currentStock)
				{
					if (component.Quantity <= 0)
						component.Quantity = 1;
					stock.Current += component.Quantity;
				}

				foreach (var t in currentStock)
				{
					t.Current = stock.Current;
					t.ShouldBeOnStock = stock.ShouldBeOnStock;
					dontHaveStockInfo.Remove(t);
				}
			}

			foreach (var component in dontHaveStockInfo)
			{
				component.ShouldBeOnStock = 0;
				component.Current = 0;

				IEnumerable<Entities.General.Accessory.Component> currentStock =
					components.Where(t => t.GoodsClass == component.GoodsClass &&
									   t.PartNumber.Replace(" ", "").ToLower() ==
									   component.PartNumber.Replace(" ", "").ToLower());

				foreach (Entities.General.Accessory.Component stock in currentStock)
				{
					if (stock.Quantity <= 0)
						stock.Quantity = 1;
					component.Current += stock.Quantity;
				}
			}
		}

		#endregion

		#region public void CalculateStock(Component component, Store store)
		/// <summary>
		/// Расчитывает тек. кол-во комплектующего, и его необходимый запас на заданном складу
		/// </summary>
		/// <param name="component">записи о неснижаемом запасе"></param>
		/// <param name="store">Задает склад, на котором надо проверить данные о неснижаемых запасах</param>
		public void CalculateStock(Entities.General.Accessory.Component component, Store store)
		{
			component.Current = 0;
			component.ShouldBeOnStock = 0;

			var allShouldBe = new List<StockComponentInfo>(_newLoader.GetObjectListAll<StockComponentInfoDTO, StockComponentInfo>(new List<Filter>()
			{
				new Filter("StoreID",store.ItemId),
				new Filter("ComponentClass",component.GoodsClass.ItemId),
				new Filter("PartNumber",component.PartNumber.Replace(" ", ""))
			}, true));

			foreach (var stock in allShouldBe)
			{
				component.ShouldBeOnStock += stock.ShouldBeOnStock;
			}

			var allStorescomponents = new List<Entities.General.Accessory.Component>();
			allStorescomponents.AddRange(_componentCore.GetStoreBaseComponents(store.ItemId));
			allStorescomponents.AddRange(_componentCore.GetStoreComponents(store).ToArray());

			component.Current =
				allStorescomponents.Count(t => t.GoodsClass == component.GoodsClass &&
											   t.PartNumber.Replace(" ", "").ToLower() ==
											   component.PartNumber.Replace(" ", "").ToLower());
		}

		#endregion

		#region public StockComponentInfo[] GetStockComponentInfosWithCalculation(Store store)

		/// <summary>
		/// Возвращает все детали, которые должны быть на складе
		/// </summary>
		/// <returns></returns>
		public StockComponentInfo[] GetStockComponentInfosWithCalculation(Store store)
		{
			var qr = StockComponentInfoQueries.GetSelectQuery(store);
			var ds = _casEnvironment.Execute(qr);
			return CalculateCurrents(StockComponentInfoQueries.GetStockComponentInfoList(ds.Tables[0]).ToArray(), store);
		}

		#endregion

		#region private StockComponentInfo[] CalculateCurrents(StockComponentInfo[] itemsStock, Store store)

		private StockComponentInfo[] CalculateCurrents(StockComponentInfo[] itemsStock, Store store)
		{
			var allStorescomponents = new List<object>();
			allStorescomponents.AddRange(_componentCore.GetStoreBaseComponents(store.ItemId));
			allStorescomponents.AddRange(_componentCore.GetStoreComponents(store).ToArray());

			foreach (object o in allStorescomponents)
			{
				foreach (StockComponentInfo t in itemsStock)
				{
					if (o is BaseComponent)
					{
						if (((BaseComponent)o).PartNumber == t.PartNumber)
							t.Current++;
					}
					else
					{
						if (((Entities.General.Accessory.Component)o).PartNumber == t.PartNumber) t.Current++;
					}
				}
			}
			return itemsStock;
		}

		#endregion
	}
}