using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;

namespace SmartCore.Component
{
	public interface IComponentCore
	{
		IList<Entities.General.Accessory.Component> GetComponents();
		ComponentCollection GetComponents(params object[] parametres);

		ComponentCollection GetComponents(int aircraftId, bool loadChild = true);

		ComponentCollection GetComponents(Store store);

		ComponentCollection GetComponents(BaseComponent baseComponent);

		ComponentCollection GetComponents(List<BaseComponent> baseComponents);

		ComponentCollection GetComponents(BaseComponent baseComponent, bool llpMark);

		ComponentCollection GetStoreComponents(Store store);

		ComponentCollection GetSupplierProcessing(bool loadChild = true);

		ComponentCollection GetSupplierProcessingById(int supplierId, bool loadChild = true);

		ComponentCollection GetOperatorComponents(Operator @operator);

		List<ComponentDirective> GetComponentDirectives(BaseComponent baseComponent, bool loadChild = false);

		List<ComponentDirective> GetComponentDirectives(IList<int> componentDirectiveIds, bool getDeleted = false);

		List<ComponentDirective> GetAircraftComponentDirectives(int aircraftId, IList<int> componentDirectiveIds, bool getDeleted = false);

		void AddComponentDirective(Entities.General.Accessory.Component component, ComponentDirective componentDirective);

		void UpdateComponent(Entities.General.Accessory.Component component, DateTime installationDate, string position, ComponentStorePosition state, Lifelength installationLifelength);

		void AddComponent(Entities.General.Accessory.Component component, IComponentContainer destination, DateTime installationDate, string position, ComponentStorePosition state,
						  Lifelength installationLifelength = null, Lifelength lastKnownLifelength = null, DateTime? lastKnownLifelenghtDate = null,
						  bool destinationResponsible = false);

		void Save(Entities.General.Accessory.Component component);

		void AddBaseComponent(BaseComponent baseComponent, Aircraft aircraft, DateTime date,
						   string position, Lifelength installationActualState,
						   bool destinationResponsible = false, bool reload = true);

		void AddBaseComponent(BaseComponent baseComponent, Store store, DateTime date, string position, Lifelength installationData);

		void DeleteLLPCategoryChangeRecord(ComponentLLPCategoryChangeRecord componentLLPCategoryChangeRecord);

		void DeleteComponentDirective(ComponentDirective componentDirective);

		void DeleteComponent(Entities.General.Accessory.Component component);

		void DeleteBaseComponent(BaseComponent baseComponent); 

		void DeleteActualStateRecord(ActualStateRecord actualStateRecord);

		void RegisterActualState(BaseEntityObject entityObject, DateTime actualDate, Lifelength actualState);

		void RegisterActualState(Entities.General.Accessory.Component component, ActualStateRecord actualState);

		void RegisterChangeLLPCategory(Entities.General.Accessory.Component component, ComponentLLPCategoryChangeRecord performance);


		void MoveToStore(Entities.General.Accessory.Component component, Store store, DateTime transferDate,
						 double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, string remarks, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null);

		void MoveToAircraft(Entities.General.Accessory.Component component, BaseComponent baseComponent, Aircraft aircraft, DateTime transferDate,
			double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null);

		void MoveToStore(BaseComponent baseComponent, Store store, DateTime transferDate, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null);

		void MoveToAircraft(BaseComponent baseComponent, Aircraft aircraft, DateTime transferDate, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null);

		void LoadRelatedObjectds(Entities.General.Accessory.Component[] components, bool loadChild = true);

		Entities.General.Accessory.Component GetComponentById(int componentId, bool getDeleted = false);

		IList<Entities.General.Accessory.Component> GetComponentByIds(IList<int> componentIds);

		BaseComponent GetFullBaseComponent(int baseComponentId);

		/// <summary>
		/// берет базовый компонент их кэша
		/// </summary>
		/// <param name="baseComponentId"></param>
		/// <returns></returns>
		BaseComponent GetBaseComponentById(int baseComponentId);

		void LoadBaseComponentsDirectives(Aircraft aircraft = null);

		void LoadBaseComponentsActualStateRecords();

		void LoadBaseComponentsTransferRecords();



		BaseComponent[] GetAicraftBaseComponents(int aircraftId, int? baseComponentTypeId = null);

		BaseComponent[] GetAicraftBaseComponents(int aircraftId, IEnumerable<int> baseComponentTypeIds);

		BaseComponent[] GetStoreBaseComponents(int storeId, int? baseComponentTypeId = null);

		BaseComponent[] GetOperatorBaseComponents(int operatorId, int? baseComponentTypeId = null);

		BaseComponent[] GetAircraftLandingGears(int aircraftId);

		BaseComponent[] GetAircraftEngines(int aircraftId);

		BaseComponent GetAircraftFrame(int aircraftId);

		BaseComponent GetAircraftApu(int aircraftId);

		void MoveToProcessing(Entities.General.Accessory.Component component, int destinationSupplierId, int destinationSpecialistId, DateTime transferDate, double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, string remarks, InitialReason reason, Specialist released, Specialist received, WorkPackage currentWorkPackage, AttachedFile transferRecordAttachedFile, DateTime receipDate, Lifelength notify);
	}
}