using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Component;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.NonRoutineJobs;
using SmartCore.Purchase;
using SmartCore.Queries;

namespace SmartCore.Kits
{
	public class KitsCore:IKitsCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly ILoader _loader;
		private readonly INewKeeper _newKeeper;
		private readonly IComponentCore _componentCore;
		private readonly INonRoutineJobDataAccess _nonRoutineJobDataAccess;


		public KitsCore(ICasEnvironment casEnvironment, ILoader loader, 
			INewKeeper newKeeper, IComponentCore componentCore, INonRoutineJobDataAccess nonRoutineJobDataAccess)
		{
			_casEnvironment = casEnvironment;
			_loader = loader;
			_newKeeper = newKeeper;
			_componentCore = componentCore;
			_nonRoutineJobDataAccess = nonRoutineJobDataAccess;
		}

		#region public List<AbstractAccessory> GetAllAircraftKits(Aircraft parentAircraft)

		public List<AbstractAccessory> GetAllAircraftKits(int aircraftId, int aircraftModelId)
		{
			var resultKits = new List<AbstractAccessory>();

			#region Поиск Директив летной годности с КИТами

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			var accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
				 new ICommonFilter[] { new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.Directive.ItemId) }
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
															  FilterType.In,
															  new[] { accessoryParentId });
			//создаются запросы на выборку задач по компонентам с заданного ВС
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//задач по компонентам ВС должно быть среди идентификатор родительских задач КИТов
			var qrs = DirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId, DirectiveType.All,
																		new[] { idFilter }, true);

			var directives = _loader.GetObjectListAll<Directive>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var directive in directives)
				resultKits.AddRange(directive.Kits.ToArray());

			#endregion

			#region Поиск Директив деталей с КИТами
			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
				 new ICommonFilter[] { new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.ComponentDirective.ItemId) }
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
												FilterType.In,
												new[] { accessoryParentId });
			//создаются запросы на выборку задач по компонентам с заданного ВС
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//задач по компонентам ВС должно быть среди идентификатор родительских задач КИТов
			qrs = ComponentDirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId,
																		  new[] { idFilter },
																		  true);

			var componentDirectives = _loader.GetObjectListAll<ComponentDirective>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var dd in componentDirectives)
			{
				dd.ParentComponent = _componentCore.GetComponentById(dd.ComponentId);
				resultKits.AddRange(dd.Kits.ToArray());
			}

			#endregion

			#region Поиск КИТ-ов Maintenance чеков

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
				 new ICommonFilter[] { new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.MaintenanceCheck.ItemId) }
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
												FilterType.In,
												new[] { accessoryParentId });
			//создаются запросы на выборку чеков с заданного ВС
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//чека ВС должно быть среди идентификатор родительских задач КИТов
			var checks =
				_loader.GetObjectListAll<MaintenanceCheck>(new[]
				{
					new CommonFilter<int>(MaintenanceCheck.ParentAircraftIdProperty, aircraftId),
					idFilter
				}, true);

			//связь КИТов с родительскими деталями
			foreach (var dd in checks)
				resultKits.AddRange(dd.Kits.ToArray());
			#endregion

			#region Поиск КИТ-ов NonRoutine Job-ов

			var jobDTOs = _nonRoutineJobDataAccess.GetNonRoutineJobDTOsWithKits();

			//связь КИТов с родительскими деталями
			foreach (var jobDTO in jobDTOs)
			{
				var nonRoutineJob = NonRoutineJobHelper.Convert(jobDTO, _casEnvironment);
				resultKits.AddRange(nonRoutineJob.Kits.ToArray());
			}


			#endregion

			#region Поиск КИТ-ов Базовых деталей
			//TODO:(Evgenii Babak) выделить в отдельный класс и не использовать рукописные запросы
			//TODO:(Evgenii Babak) нужно реализовать TablePrefix в методе BaseComponentQueries.GetSelectQueryPrimaryColumnOnly

			var bdFilter = String.Format("Select ComponentsItemId from ({0}) directiveSelect ",
						BaseQueries.GetSelectQueryWithWhere<BaseComponent>() +
						String.Format(@" and (Select top 1 DestinationObjectId from dbo.TransferRecords Where 
            					ParentType = {0} 
            					and ParentId = dbo.Components.ItemId  
            					and IsDeleted = 0
            					order by dbo.TransferRecords.TransferDate Desc) = {1}",
								SmartCoreType.BaseComponent.ItemId, aircraftId));

			var preResult = _loader.GetObjectListAll<AccessoryRequired>(new ICommonFilter[]
			{
				new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.BaseComponent.ItemId), 
				new CommonFilter<string>(AccessoryRequired.ParentIdProperty, FilterType.In , new []{ bdFilter }) 
			});


			// поиск поставщиков и связей с ними
			var kitsIds = preResult.Select(k => k.ItemId).ToArray();
			var ksrs = new List<KitSuppliersRelation>();
			if (kitsIds.Length > 0)
				_loader.GetObjectListAll<KitSuppliersRelation>(new CommonFilter<int>(KitSuppliersRelation.KitIdProperty, FilterType.In, kitsIds));

			var kitSupplierIds = ksrs.Select(k => k.SupplierId).ToArray();
			var suppliers = new List<Supplier>();
			if (kitSupplierIds.Length > 0)
				suppliers = _loader.GetObjectListAll<Supplier>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, kitSupplierIds));

			foreach (var kit in preResult)
			{
				var supls = (from sup in suppliers
										from k in ksrs
										where k.KitId == kit.ItemId &&
											  sup.ItemId == k.SupplierId
										select sup).ToList();
				kit.Suppliers.AddRange(supls.ToArray());
			}

			//поиск чеков, который пренадлежат КИТы
			var kitParentIds = preResult.Select(k => k.ParentId).ToArray();
			var baseComponents = new List<BaseComponent>();
			if (kitParentIds.Length > 0)
				baseComponents = _loader.GetObjectListAll<BaseComponent>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, kitParentIds));

			//связь КИТов с родительскими деталями
			foreach (var baseComponent in baseComponents)
			{
				baseComponent.Kits.Clear();
				baseComponent.Kits.AddRange(preResult.Where(k => k.ParentId == baseComponent.ItemId));
				foreach (var kit in baseComponent.Kits)
					kit.ParentObject = baseComponent;
			}
			resultKits.AddRange(preResult.ToArray());
			#endregion

			#region поиск КИТ-ов деталей

			var componentQuery = $"(Select ComponentsItemId from ({ComponentQueries.GetSelectQuery(aircraftId)}) directiveSelect )";
			preResult = _loader.GetObjectListAll<AccessoryRequired>(new ICommonFilter[]
			{
				new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.Component.ItemId),
				new CommonFilter<string>(AccessoryRequired.ParentIdProperty, FilterType.In, new []{componentQuery}),  
			});

			//поиск деталей, который пренадлежат КИТы
			kitParentIds = preResult.Select(k => k.ParentId).ToArray();
			var components = new List<BaseComponent>();
			if (kitParentIds.Length > 0)
				components = _loader.GetObjectListAll<BaseComponent>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, kitParentIds));

			//связь КИТов с родительскими деталями
			foreach (var baseComponent in components)
			{
				baseComponent.Kits.Clear();
				baseComponent.Kits.AddRange(preResult.Where(k => k.ParentId == baseComponent.ItemId));
				foreach (var kit in baseComponent.Kits)
					kit.ParentObject = baseComponent;
			}
			resultKits.AddRange(preResult.ToArray());

			#endregion

			#region Поиск MPD с КИТами
			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
				 new ICommonFilter[] { new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.MaintenanceDirective.ItemId) }
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
												FilterType.In,
												new[] { accessoryParentId });
			//создаются запросы на выборку задач с заданного ВС
			//дополнительно фильтруя ключевое поле. значение ключевого поля
			//задач по компонентам ВС должно быть среди идентификатор родительских задач КИТов
			qrs = MaintenanceDirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId,
																			   new[] { idFilter },
																			   true);

			var maintenanceDirectives = _loader.GetObjectListAll<MaintenanceDirective>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var mpd in maintenanceDirectives)
				resultKits.AddRange(mpd.Kits.ToArray());

			#endregion

			#region Поиск Нерутинных КИТов 
			//добавление не рутинных кит-ов
			preResult = _loader.GetObjectListAll<AccessoryRequired>(new CommonFilter<int>(AccessoryRequired.AircraftModelIdProperty, aircraftModelId));

			// поиск поставщиков и связей с ними
			kitsIds = preResult.Select(k => k.ItemId).ToArray();
			if(kitsIds.Length > 0)
				ksrs = _loader.GetObjectListAll<KitSuppliersRelation>(new CommonFilter<int>(KitSuppliersRelation.KitIdProperty, FilterType.In, kitsIds));

			kitSupplierIds = ksrs.Select(k => k.SupplierId).ToArray();
			if(kitSupplierIds.Length > 0)
				suppliers = _loader.GetObjectListAll<Supplier>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, kitSupplierIds));
			foreach (var kit in preResult)
			{
				var supls = (from sup in suppliers
										from k in ksrs
										where k.KitId == kit.ItemId &&
											  sup.ItemId == k.SupplierId
										select sup).ToList();
				kit.Suppliers.AddRange(supls.ToArray());
			}


			resultKits.AddRange(preResult.ToArray());

			#endregion

			return resultKits;
		}

		#endregion

		#region public List<AbstractAccessory> GetAllWorkPackageKits(int workPackageId)

		public List<AbstractAccessory> GetAllWorkPackageKits(int workPackageId)
		{
			var resultKits = new List<AbstractAccessory>();

			#region Поиск Директив летной годности с КИТами

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			var accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
					new ICommonFilter[] {new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.Directive.ItemId)}
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] {accessoryParentId});
			//создаются запросы на выборку задач по компонентам с заданного рабочего пакета
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//задач по компонентам рабочего пакета должно быть среди идентификатор родительских задач КИТов
			var qrs = DirectiveQueries.GetSelectQueryForWp(workPackageId, DirectiveType.All, new[] {idFilter}, true);
			var directives = _loader.GetObjectListAll<Directive>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var directive in directives)
				resultKits.AddRange(directive.Kits.ToArray());

			#endregion

			#region Поиск Директив деталей с КИТами

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
					new ICommonFilter[]
					{new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.ComponentDirective.ItemId)}
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] {accessoryParentId});
			//создаются запросы на выборку задач по компонентам с заданного рабочего пакета
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//задач по компонентам рабочего пакета должно быть среди идентификатор родительских задач КИТов
			qrs = ComponentDirectiveQueries.GetSelectQueryForWp(workPackageId, new[] {idFilter}, true);

			var componentDirectives = _loader.GetObjectListAll<ComponentDirective>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var dd in componentDirectives)
			{
				dd.ParentComponent = _componentCore.GetComponentById(dd.ComponentId);
				resultKits.AddRange(dd.Kits.ToArray());
			}

			#endregion

			#region Поиск КИТ-ов Maintenance чеков

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
					new ICommonFilter[]
					{new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.MaintenanceCheck.ItemId)}
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] {accessoryParentId});

			var directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
				new ICommonFilter[]
				{
					new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.MaintenanceCheck.ItemId)
				});

			//создаются запросы на выборку чеков с заданного рабочего пакета
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//чека рабочего пакета должно быть среди идентификатор родительских задач КИТов
			var checks =
				_loader.GetObjectListAll<MaintenanceCheck>(new[]
				{
					new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn}),
					idFilter
				}, true);

			//связь КИТов с родительскими деталями
			foreach (var dd in checks)
				resultKits.AddRange(dd.Kits.ToArray());

			#endregion

			#region Поиск КИТ-ов NonRoutine Job-ов

			var jobDTOs = _nonRoutineJobDataAccess.GetNonRoutineJobDTOsWithKitsByWorkPackageId(workPackageId);

			//связь КИТов с родительскими деталями
			foreach (var jobDTO in jobDTOs)
			{
				var nonRoutineJob = NonRoutineJobHelper.Convert(jobDTO, _casEnvironment);
				resultKits.AddRange(nonRoutineJob.Kits.ToArray());
			}


			#endregion

			#region Поиск КИТ-ов Базовых деталей

			directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
				new ICommonFilter[]
				{
					new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.BaseComponent.ItemId)
				});

			var kitQrs = BaseQueries.GetSelectQueryWithWhereAll<AccessoryRequired>(new ICommonFilter[]
			{
				new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.BaseComponent.ItemId),
				new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn})
			}, true);

			var kits = _loader.GetObjectListAll<AccessoryRequired>(kitQrs, true);

			var baseComponents = _loader.GetObjectList<BaseComponent>(new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] { directiveIn }));

			//связь КИТов с родительскими деталями
			foreach (var baseComponent in baseComponents)
			{
				baseComponent.Kits.Clear();
				baseComponent.Kits.AddRange(kits.Where(k => k.ParentId == baseComponent.ItemId));
				foreach (var kit in baseComponent.Kits)
					kit.ParentObject = baseComponent;
			}
			resultKits.AddRange(kits.ToArray());

			#endregion

			#region поиск КИТ-ов деталей

			directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
				new ICommonFilter[]
				{
					new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.Component.ItemId)
				});

			kitQrs = BaseQueries.GetSelectQueryWithWhereAll<AccessoryRequired>(new ICommonFilter[]
			{
				new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.Component.ItemId),
				new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn})
			}, true);

			kits = _loader.GetObjectListAll<AccessoryRequired>(kitQrs, true);
			var components = _loader.GetObjectList<Entities.General.Accessory.Component>(new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] { directiveIn }));

			//связь КИТов с родительскими деталями
			foreach (var component in components)
			{
				component.Kits.Clear();
				component.Kits.AddRange(kits.Where(k => k.ParentId == component.ItemId));
				foreach (var kit in component.Kits)
					kit.ParentObject = component;
			}
			resultKits.AddRange(kits.ToArray());

			#endregion

			#region Поиск MPD с КИТами

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
				(AccessoryRequired.ParentIdProperty,
					new ICommonFilter[]
					{new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.MaintenanceDirective.ItemId)}
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] {accessoryParentId});
			//создаются запросы на выборку задач с заданного рабочего пакета
			//дополнительно фильтруя ключевое поле. значение ключевого поля
			//задач по компонентам рабочего пакета должно быть среди идентификатор родительских задач КИТов
			qrs = MaintenanceDirectiveQueries.GetSelectQueryForWp(workPackageId, new[] {idFilter}, true);

			var maintenanceDirectives = _loader.GetObjectListAll<MaintenanceDirective>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var mpd in maintenanceDirectives)
				resultKits.AddRange(mpd.Kits.ToArray());

			#endregion

			return resultKits;
		}

		#endregion

		#region public void SetStandartAndProduct(AbstractAccessory accessory, string standartName, string partialNumber, string description, string remarks, string manufacturer, DetailClass detailClass, DetailType detailType, Measure measure, double costNew, double costOverhaul, double costServiceable, IEnumerable<Supplier> suppliers)
		///<summary>
		/// Проставляет товар и стандарт для комплектующего
		///</summary>
		///<returns>true - если удалось определеить и проставить продукт и стандарт для комплектующего</returns>
		public bool SetStandartAndProduct(AbstractAccessory accessory,
										  string standartName, string partialNumber, string description, string remarks, string manufacturer,
										  GoodsClass goodsClass, Measure measure,
										  double costNew, double costOverhaul, double costServiceable,
										  IEnumerable<Supplier> suppliers)
		{
			if (accessory == null)
				throw new ArgumentException("must be not null", "accessory");

			if (accessory.Product != null && accessory.Product.ItemId > 0)
				return true;

			string standart = standartName.Replace(" ", "").ToLower();
			string partNumber = partialNumber.Replace(" ", "").ToLower();
			bool needToSaveAccessory = false;
			bool result = true;
			GoodStandart goodStandart = null;

			List<GoodStandart> goodStandarts = _loader.GetObjectList<GoodStandart>();
			List<Product> products;
			if (accessory is Entities.General.Accessory.Component)
			{
				products = new List<Product>(_loader.GetObjectList<ComponentModel>(loadChild: true).ToArray());
			}
			else
			{
				products = _loader.GetObjectList<Product>(loadChild: true);
			}
			if (goodStandarts != null && !string.IsNullOrEmpty(standart))
			{
				goodStandart = goodStandarts
					.FirstOrDefault(ad => ad.PartNumber.Replace(" ", "").ToLower() == partNumber
									   && ad.FullName.Replace(" ", "").ToLower() == standart);
				if (goodStandart == null)
				{
					goodStandart = new GoodStandart
					{
						GoodsClass = goodsClass,
						PartNumber = partialNumber,
						Description = description,
						FullName = standartName,
						//CostNew = costNew,
						//CostServiceable = costServiceable,
						//CostOverhaul = costOverhaul,
						Remarks = remarks,
						//Measure = measure
					};

					_newKeeper.Save(goodStandart);
				}
				accessory.Standart = goodStandart;

				needToSaveAccessory = true;
			}
			if ((manufacturer != "" || suppliers != null && suppliers.Any()) && products != null)
			{
				Product product = products
					.FirstOrDefault(p => p.PartNumber.Replace(" ", "").ToLower() == partNumber
									  && p.Standart != null && p.Standart.FullName.Replace(" ", "").ToLower() == standart);
				if (product == null)
				{
					if (accessory is Entities.General.Accessory.Component)
					{
						ComponentModel dm = new ComponentModel
						{
							BatchNumber = "",
							CostNew = costNew,
							CostOverhaul = costOverhaul,
							CostServiceable = costServiceable,
							Description = description,
							GoodsClass = goodsClass,
							Manufacturer = manufacturer,
							Measure = measure,
							PartNumber = partNumber,
							Remarks = remarks,
						};
						product = dm;
					}
					else
					{
						product = new Product
						{
							GoodsClass = goodsClass,
							PartNumber = partialNumber,
							Description = description,
							Manufacturer = manufacturer,
							Standart = goodStandart,
							CostNew = costNew,
							CostServiceable = costServiceable,
							CostOverhaul = costOverhaul,
							Remarks = remarks,
							Measure = measure
						};
					}

					_newKeeper.Save(product);

					if (goodStandart != null && goodStandart.DefaultProductId <= 0)
					{
						goodStandart.DefaultProductId = product.ItemId;
						_newKeeper.Save(goodStandart);
					}

					product.SupplierRelations.Clear();
					foreach (KitSuppliersRelation ksr in accessory.SupplierRelations)
					{
						if (ksr.SupplierId != 0)
						{

							product.SupplierRelations.Add(ksr);
							ksr.KitId = product.ItemId;
							ksr.ParentTypeId = product.SmartCoreObjectType.ItemId;

							_newKeeper.Save(ksr);
						}
					}
				}

				Entities.General.Accessory.Component component = accessory as Entities.General.Accessory.Component;
				if (component != null)
				{
					component.Model = product as ComponentModel;
				}
				else accessory.Product = product;

				needToSaveAccessory = true;
			}
			else
			{
				accessory.Product = null;
				result = false;
			}

			if (needToSaveAccessory)
				_newKeeper.Save(accessory);

			return result;
		}
		#endregion

		#region public void SetStandartAndProduct(AbstractAccessory accessory, string standartName, )
		///<summary>
		/// Проставляет товар и стандарт для комплектующего
		///</summary>
		///<returns>true - если удалось определеить и проставить продукт и стандарт для комплектующего</returns>
		public bool SetStandartAndProduct(AbstractAccessory accessory, string standartName)
		{
			if (accessory == null)
				throw new ArgumentException("must be not null", "accessory");

			if (accessory.Product != null && accessory.Product.ItemId > 0)
				return true;

			return SetStandartAndProduct(accessory, standartName, accessory.PartNumber, accessory.Description,
										 accessory.Remarks, accessory.Manufacturer,
										 accessory.GoodsClass, accessory.Measure, accessory.CostNew,
										 accessory.CostOverhaul, accessory.CostServiceable,
										 accessory.Suppliers);
		}
		#endregion

		#region public List<AbstractAccessory> GetMpdKits(int aircraftId, IEnumerable<int> mpdIds)

		public List<AbstractAccessory> GetMpdKits(int aircraftId, IEnumerable<int> mpdIds)
		{
			var resultKits = new List<AbstractAccessory>();

			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			var accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<AccessoryRequired>
			(AccessoryRequired.ParentIdProperty,
				new ICommonFilter[] { new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.MaintenanceDirective.ItemId) }
			);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			var idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] { accessoryParentId });
			//создаются запросы на выборку задач с заданного ВС
			//дополнительно фильтруя ключевое поле. значение ключевого поля
			//задач по компонентам ВС должно быть среди идентификатор родительских задач КИТов
			var qrs = MaintenanceDirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId,
				new[] { idFilter },
				true);

			var maintenanceDirectives = _loader.GetObjectListAll<MaintenanceDirective>(qrs, true);
			//связь КИТов с родительскими деталями
			foreach (var mpd in maintenanceDirectives)
				resultKits.AddRange(mpd.Kits.ToArray());

			return resultKits;
		}

		#endregion
	}
}