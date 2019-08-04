using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CAS.UI.Helpers;
using EntityCore.DTO.General;
using EntityCore.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.DtoHelper;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Maintenance;
using SmartCore.Management;

namespace SmartCore.Tests
{
	[TestClass]
	public class AircraftCopyTest
	{



		[TestMethod]
		public void CopyAircraft()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader,env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var directiveCore = new DirectiveCore(env.NewKeeper, env.NewLoader,env.Keeper, env.Loader, itemRelationCore);
			var maintenanceCore = new MaintenanceCore(env, env.NewLoader, env.NewKeeper, itemRelationCore, aircraftCore);

			var newBaseComponent = new List<BaseComponent>();
			var newComponents = new List<Entities.General.Accessory.Component>();
			var directives = new List<Directive>();
			var maintenanceDirective = new List<MaintenanceDirective>();

			//Грузим ВС, делаем с него копию и сохраняем
			var aircrafts = env.NewLoader.GetObject<AircraftDTO, Aircraft>(new Filter("ItemId", 2346), true);
			var newAircraft = aircrafts.GetCopyUnsaved();
			//newAircraft.RegistrationNumber += "- COPY";

			env.NewKeeper.Save(newAircraft);

			//Грузим базовые агрегаты ВС, делаем с копии и сохраняем
			var baseComponents = new BaseComponentCollection(componentCore.GetAicraftBaseComponents(aircrafts.ItemId));
			LoadDocuments(baseComponents, env);

			foreach (var baseComponent in baseComponents)
			{
				var newComponent = (BaseComponent)baseComponent.GetCopyUnsaved();
				newComponent.ParentAircraftId = newAircraft.ItemId;


				env.NewKeeper.Save(newComponent);
				newBaseComponent.Add(newComponent);

				foreach (var transferRecord in baseComponent.TransferRecords)
				{
					var newTransferRecord = transferRecord.GetCopyUnsaved();
					if(newTransferRecord.DestinationObjectType == SmartCoreType.Aircraft)
						newTransferRecord.DestinationObjectId = newAircraft.ItemId;
					newTransferRecord.ParentId = newComponent.ItemId;

					env.NewKeeper.Save(newTransferRecord);
				}

				foreach (var componentDirective in baseComponent.ComponentDirectives)
				{
					var newcomponentDirective = componentDirective.GetCopyUnsaved();

					newcomponentDirective.ComponentId = newComponent.ItemId;
					env.NewKeeper.Save(newcomponentDirective);
				}
			}

			//Грузим агрегаты ВС, делаем с копии и сохраняем
			var components = componentCore.GetComponents(aircrafts.ItemId);

			foreach (var component in components)
			{
				var newComponent = component.GetCopyUnsaved();
				newComponent.ParentAircraftId = newAircraft.ItemId;

				env.NewKeeper.Save(newComponent);
				newComponents.Add(newComponent);

				foreach (var transferRecord in component.TransferRecords)
				{
					var newTransferRecord = transferRecord.GetCopyUnsaved();

					if (newTransferRecord.DestinationObjectType == SmartCoreType.BaseComponent)
						newTransferRecord.DestinationObjectId = newBaseComponent.FirstOrDefault(b => b.SerialNumber == ((BaseComponent)newTransferRecord.DestinationObject).SerialNumber).ItemId;
					newTransferRecord.ParentId = newComponent.ItemId;

					env.NewKeeper.Save(newTransferRecord);
				}

				foreach (var componentDirective in component.ComponentDirectives)
				{
					var newcomponentDirective = componentDirective.GetCopyUnsaved();

					newcomponentDirective.ComponentId = newComponent.ItemId;
					env.NewKeeper.Save(newcomponentDirective);
				}
			}

			//Грузим директивы ВС, делаем с копии и сохраняем
			directives.Clear();
			directives.AddRange(directiveCore.GetDirectives(aircrafts, DirectiveType.All));
			foreach (var directive in directives)
			{
				var newDirective = directive.GetCopyUnsaved();
				newDirective.ParentBaseComponent = newBaseComponent.FirstOrDefault(b => b.SerialNumber == newDirective.ParentBaseComponent.SerialNumber);


				newDirective.PerformanceRecords.Clear();
				newDirective.CategoriesRecords.Clear();

				env.NewKeeper.Save(newDirective);
			}

			//Грузим MPD ВС, делаем с копии и сохраняем
			maintenanceDirective.Clear();
			maintenanceDirective.AddRange(maintenanceCore.GetMaintenanceDirectives(aircrafts));
			foreach (var directive in maintenanceDirective)
			{
				var newDirective = directive.GetCopyUnsaved();
				if (directive.ParentBaseComponent != null)
					newDirective.ParentBaseComponent = newBaseComponent.FirstOrDefault(b => b.SerialNumber == directive.ParentBaseComponent.SerialNumber);

				newDirective.PerformanceRecords.Clear();
				newDirective.CategoriesRecords.Clear();

				env.NewKeeper.Save(newDirective);
			}
		}

		private void LoadDocuments(BaseComponentCollection baseComponents, CasEnvironment env)
		{
			var types = new[] {SmartCoreType.BaseComponent.ItemId, SmartCoreType.ComponentDirective.ItemId};
			//Загрузка документов
			var documents = env.NewLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ParentTypeId", types),true);

			if (documents.Count > 0)
			{
				foreach (var _currentComponent in baseComponents)
				{
					var crs = env.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
					var shipping = env.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;

					var docShipping = documents.FirstOrDefault(d => d.ParentId == _currentComponent.ItemId &&
					                                                d.ParentTypeId == SmartCoreType.BaseComponent.ItemId &&
					                                                d.DocumentSubType == shipping);
					if (docShipping != null)
					{
						_currentComponent.Document = docShipping;
						_currentComponent.Document.Parent = _currentComponent;
					}

					var docCrs = documents.FirstOrDefault(d => d.ParentId == _currentComponent.ItemId &&
					                                           d.ParentTypeId == SmartCoreType.Component.ItemId &&
					                                           d.DocumentSubType == crs);
					if (docCrs != null)
					{
						_currentComponent.DocumentCRS = docCrs;
						_currentComponent.DocumentCRS.Parent = _currentComponent;
					}

					if (_currentComponent.ComponentDirectives.Count > 0)
					{

						foreach (var directive in _currentComponent.ComponentDirectives)
						{
							var docCd = documents.FirstOrDefault(d => d.ParentId == directive.ItemId &&
							                                          d.ParentTypeId == SmartCoreType.ComponentDirective.ItemId);
							if (docCd != null)
							{
								directive.Document = docCd;
								directive.Document.Parent = directive;
							}
						}
					}
				}
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.ApiProvider = new ApiProvider("http://92.47.31.254:45616");
			cas.Connect("92.47.31.254:45616", "Admin", "Rfcgfhjkm", "ScatDB");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}