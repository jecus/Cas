using System.Collections.Generic;
using SmartCore.Entities.General.Store;

namespace SmartCore.Calculations.StockCalculator
{
	public interface IStockCalculator
	{
		void CalculateStock(IEnumerable<StockComponentInfo> itemsStock, Store store);
		void CalculateStock(StockComponentInfo itemStock);
		void CalculateStock(Entities.General.Accessory.Component[] components, Store store);
		void CalculateStock(Entities.General.Accessory.Component[] components, IEnumerable<StockComponentInfo> stockComponentInfos);
		void CalculateStock(Entities.General.Accessory.Component component, Store store);
		StockComponentInfo[] GetStockComponentInfosWithCalculation(Store store);
	}
}