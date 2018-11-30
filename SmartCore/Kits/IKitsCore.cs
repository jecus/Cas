using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace SmartCore.Kits
{
	public interface IKitsCore
	{
		List<AbstractAccessory> GetAllAircraftKits(int aircraftId, int aircraftModelId);

		List<AbstractAccessory> GetAllWorkPackageKits(int workPackageId);

		List<AbstractAccessory> GetMpdKits(int aircraftId, IEnumerable<int> mpdIds);

		bool SetStandartAndProduct(AbstractAccessory accessory, string standartName,
								   string partialNumber, string description,
								   string remarks, string manufacturer,
								   GoodsClass goodsClass, Measure measure,
								   double costNew, double costOverhaul,
								   double costServiceable, IEnumerable<Supplier> suppliers);

		bool SetStandartAndProduct(AbstractAccessory accessory, string standartName);

	}
}