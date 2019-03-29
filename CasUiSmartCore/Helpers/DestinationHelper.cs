using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;
using TempUIExtentions;

namespace CAS.UI.Helpers
{
	public static class DestinationHelper
	{
		public static string GetDestinationObjectString(TransferRecord record)
		{
			var destination = "";
			var destinationObject = record.DestinationObject;
			if (destinationObject != null)
			{
				if (destinationObject is Aircraft)
					destination = "Aircraft: " + destinationObject;
				if (destinationObject is Store)
					destination = "Store: " + destinationObject;
				if (destinationObject is Supplier)
					destination = "Supplier: " + destinationObject;
				if (destinationObject is Specialist)
					destination = "Employee: " + destinationObject;
				if (destinationObject is BaseComponent)
				{
					var bd = (BaseComponent)destinationObject;
					var parentStore = GlobalObjects.StoreCore.GetStoreById(bd.ParentStoreId);
					if (parentStore != null)
						destination = $"Store: {parentStore}";
					if (bd.ParentAircraftId > 0)
						destination = $"Aircraft: {bd.GetParentAircraftRegNumber()}";
					if (destination != "") destination += ", ";
					destination += destinationObject;
				}
			}
			return destination;
		}

		public static string GetDestinationObjectString(BaseComponent baseComponent)
		{
			var psn = baseComponent.PartNumber;
			if (baseComponent.ParentAircraftId > 0)
				return $"{baseComponent.GetParentAircraftRegNumber()}. Component {psn}";
			return $"{baseComponent.ParentStoreId}. Component {psn}";
		}

		public static string GetDestinationString(int aircraftId, int storeId)
		{
			return aircraftId > 0
								? $" Aircraft:{getDestinationStringFromAircraft(aircraftId, false, null)} "
								: storeId > 0
										? $" Store:{getDestinationStringFromStore(storeId, null, true)} "
										: " ";
		}

		public static string GetDestinationStringFromAircraft(int aircraftId, bool includeFrame, int? baseComponentId, char separator = '|')
		{
			return getDestinationStringFromAircraft(aircraftId, includeFrame, baseComponentId, separator);
		}

		public static string GetDestinationStringFromStore(int storeId, int? baseComponentId, bool includeStoreName, char separator = '|')
		{
			return getDestinationStringFromStore(storeId, baseComponentId, includeStoreName, separator);
		}

		public static string FromObjectString(TransferRecord record)
		{
			string from = "";
			if (record.FromAircraft != null)
				from = "Aircraft: " + record.FromAircraft;
			if (record.FromStore != null)
				from = "Store: " + record.FromStore;
			if (record.FromSpecialist != null)
				from = "Employee: " + record.FromSpecialist;
			if (record.FromSupplier != null)
				from = "Supplier: " + record.FromSupplier;
			if (record.FromBaseComponent != null)
			{
				if (from != "") from += " ";
				from += "Base Component:" + record.FromBaseComponent;
			}
			return from;
		}

		public static void GetDestination(TransferRecord transferRecord, out string currentDestination, out string destinatedObject)
		{
			destinatedObject = "";

			if (transferRecord.ParentComponent != null)
				destinatedObject = transferRecord.ParentComponent.Description;

			currentDestination = getCurrentDestination(transferRecord);
		}

		public static void GetPreviosAndCurrentDestination(TransferRecord transferRecord, out string lastDestination, out string currentDestination)
		{
			lastDestination = "";

			if (transferRecord.FromAircraftId > 0)
			{
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(transferRecord.FromAircraftId);
				if (parentAircraft != null)
				{
					var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
					lastDestination = parentAircraft.RegistrationNumber + " " + aircraftFrame;
				}
				else lastDestination = "error: can't find aircraft";
			}

			if (transferRecord.FromStoreId > 0)
			{
				var parentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(transferRecord.FromStoreId);
				lastDestination = parentStore.Name;
			}

			if (transferRecord.FromSupplierId > 0)
				lastDestination = "Supplier";

			if (transferRecord.FromSpecialistId > 0)
				lastDestination = "Employee";

			if (transferRecord.FromBaseComponentId > 0)
			{
				//объект перемещается на базовую деталь
				var destinationBaseComponent = GlobalObjects.CasEnvironment.BaseComponents.
					GetItemById(transferRecord.FromBaseComponentId);

				if (destinationBaseComponent == null)
				{
					//Назначенная базовая отсутствует
					lastDestination += " error: can't find base component ";
				}
				else
				{
					//Назначенная базовая деталь находится на самолете
					lastDestination += destinationBaseComponent.Description;
				}
			}

			currentDestination = getCurrentDestination(transferRecord);
		}

		public static string GetCurrentDestination(TransferRecord transferRecord)
		{
			return getCurrentDestination(transferRecord);
		}

		private static string getCurrentDestination(TransferRecord transferRecord)
		{
			var currentDestination = "";

			if (transferRecord.DestinationObjectType == SmartCoreType.Store)
			{
				var parentStore = GlobalObjects.CasEnvironment.Stores.GetItemById(transferRecord.DestinationObjectId) ??
														              GlobalObjects.CasEnvironment.Stores[0];
				currentDestination = parentStore.Name;
			}
			else if (transferRecord.DestinationObjectType == SmartCoreType.BaseComponent)
			{
				//объект перемещается на базовую деталь
				var destinationBaseComponent =
					GlobalObjects.CasEnvironment.BaseComponents.
					GetItemById(transferRecord.DestinationObjectId);

				if (destinationBaseComponent == null)
				{
					//Назначенная базовая отсутствует
					currentDestination = "error: can't base component";
				}
				else if (destinationBaseComponent.ParentAircraftId > 0)
				{
					//Назначенная базовая деталь находится на самолете
					currentDestination = $"{destinationBaseComponent.GetParentAircraftRegNumber()} {destinationBaseComponent.Description}";
				}
				else if (destinationBaseComponent.ParentStoreId > 0)//TODO:(Evgenii Babak) Пересмотреть код здесь
				{
					//Назначенная базовая деталь находится на складу
					currentDestination = $"{GlobalObjects.StoreCore.GetStoreById(destinationBaseComponent.ParentStoreId).Name} {destinationBaseComponent.Description}";
				}
			}
			else if (transferRecord.DestinationObjectType == SmartCoreType.Aircraft)
			{
				//Объект перемещается на самолет 
				var parentAircraft =
					GlobalObjects.AircraftsCore.GetAircraftById(transferRecord.DestinationObjectId);
					//TODO:(Evgenii Babak) пересмотреть использование DestinationObjectId здесь
				if (transferRecord.ParentComponent != null && parentAircraft != null)
				{
					if (transferRecord.ParentComponent is BaseComponent &&
					    ((BaseComponent) transferRecord.ParentComponent).BaseComponentTypeId != BaseComponentType.Frame.ItemId)
					{
						var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
						currentDestination = parentAircraft.RegistrationNumber + " Frame: " + aircraftFrame;
					}
					else currentDestination = parentAircraft.RegistrationNumber;
				}
			}
			else if (transferRecord.DestinationObjectType == SmartCoreType.Supplier)
			{
				currentDestination = "Supplier";
			}
			else if (transferRecord.DestinationObjectType == SmartCoreType.Employee)
			{
				currentDestination = "Employee";
			}
			else currentDestination = "error: can't find destination object";

			return currentDestination;
		}

		private static string getDestinationStringFromAircraft(int aircraftId, bool includeFrame, int? baseComponentId, char separator = '|')
		{
			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(aircraftId);
			if (parentAircraft == null)
				return "Can not find aircraft";

			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
			var result = includeFrame ? $"{parentAircraft.RegistrationNumber} {separator} {aircraftFrame} "
										: parentAircraft.RegistrationNumber;

			if (baseComponentId.HasValue)
			{
				var baseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(baseComponentId.Value);
				return $"{result} {separator} {baseComponent} ";
			}

			return result;
		}

		private static string getDestinationStringFromStore(int storeId, int? baseComponentId, bool includeStoreName, char separator = '|')
		{
			var parentStore = GlobalObjects.StoreCore.GetStoreById(storeId);

			var result = includeStoreName ? $"{parentStore.Name} {separator} {parentStore.Location}" : parentStore.Location;

			if (baseComponentId.HasValue)
			{
				var baseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(baseComponentId.Value);
				return $"{result} {separator} {baseComponent} ";
			}

			return result;
		}

	}
}