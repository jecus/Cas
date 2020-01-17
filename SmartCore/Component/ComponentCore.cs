using System;
using System.Collections.Generic;
using System.Linq;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.NewLoader;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Purchase;
using SmartCore.Queries;

namespace SmartCore.Component
{
	public class ComponentCore : IComponentCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly ILoader _loader;
		private readonly INewLoader _newLoader;
		private readonly INewKeeper _newKeeper;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly IItemsRelationsDataAccess _itemsRelationsDataAccess;


		public ComponentCore(ICasEnvironment casEnvironment, ILoader loader, INewLoader newLoader,
							 INewKeeper newKeeper, IAircraftsCore aircraftsCore,
							 IItemsRelationsDataAccess itemsRelationsDataAccess)
		{
			_casEnvironment = casEnvironment;
			_loader = loader;
			_newLoader = newLoader;
			_newKeeper = newKeeper;
			_aircraftsCore = aircraftsCore;
			_itemsRelationsDataAccess = itemsRelationsDataAccess;
		}

		public IList<Entities.General.Accessory.Component> GetComponents()
		{
			return _newLoader.GetObjectListAll<ComponentDTO, Entities.General.Accessory.Component>(new Filter("IsBaseComponent", false));
		}

		#region public ComponentCollection GetComponents(params object[] parametres)
		/// <summary>
		/// Возвращает все директивы определенного типа для самолета или null вслучае неверных параметров
		/// Первый параметр должен быть Aircraft или BaseComponent
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(params object[] parametres)
		{
			if (parametres == null || parametres.Length == 0 || parametres[0] == null)
				return null;
			if (parametres[0] is Aircraft)
				return GetComponents(((Aircraft)parametres[0]).ItemId, false);
			if (parametres[0] is Store)
				return GetComponents((Store)parametres[0]);
			if (parametres[0] is BaseComponent)
			{
				if (parametres.Length >= 2 && parametres[1] is bool)
					return GetComponents((BaseComponent)parametres[0], (bool)parametres[1]);
				return GetComponents((BaseComponent)parametres[0]);
			}
			if (parametres[0] is List<BaseComponent>)
				return GetComponents((List<BaseComponent>)parametres[0]);
			throw new ArgumentException("must be Aircraft or BaseComponent or Store or List<BaseComponent>", "parametres");
		}

		#endregion

		#region public ComponentCollection GetComponents(Aircraft aircraft, bool loadChild = true)

		/// <summary>
		/// Возвращает все компоненты воздушного судна
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(int aircraftId, bool loadChild = true)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(aircraftId, loadChild: loadChild), loadChild);
		}

		#endregion

		#region public ComponentCollection GetComponents(Store store)

		/// <summary>
		/// Возвращает все компоненты склада
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(Store store)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(store));
		}

		#endregion

		#region public ComponentCollection GetComponents(BaseComponent baseComponent)

		/// <summary>
		/// Возвращает все компоненты данного базового агрегата
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(BaseComponent baseComponent)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(baseComponent, loadChild: true));
		}

		#endregion

		#region public ComponentCollection GetComponents(List<BaseComponent> baseComponents)

		/// <summary>
		/// Возвращает все компоненты базовых агрегатов
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(List<BaseComponent> baseComponents)
		{
			if (baseComponents == null || baseComponents.Count == 0)
				return new ComponentCollection();
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(baseComponents, loadChild: true));
		}

		#endregion

		public ComponentCollection GetComponentsAll(string text)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQueryAll(text, loadChild: true ));
		}

		#region public ComponentCollection GetComponents(BaseComponent baseComponent, bool llpMark)

		/// <summary>
		/// Возвращает все компоненты данного базового агрегата
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetComponents(BaseComponent baseComponent, bool llpMark)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(baseComponent, llpMark));
		}

		#endregion

		#region public ComponentCollection GetStoreComponents(Store store)

		/// <summary>
		/// Возвращает все компоненты данного склада
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetStoreComponents(Store store)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectQuery(store, loadChild: true));
		}

		#endregion

		#region public ComponentCollection GetStoreComponents(Operator @operator)

		/// <summary>
		/// Возвращает все компоненты оператора(для наземного оборудования)
		/// </summary>
		/// <returns></returns>
		public ComponentCollection GetOperatorComponents(Operator @operator)
		{
			return GetComponentsByQuery(ComponentQueries.GetSelectComponentonOperatorQuery(@operator));
		}

		#endregion

		#region public List<ComponentDirective> GetComponentDirectives(BaseComponent baseComponent, bool loadChild = false)
		/// <summary>
		/// Загружает задачи по базовому компоненту. (Не удалять т.к. базовый компонент в задачах по компоненту через генератор запросов автоматически не проставляется)
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="loadChild"></param>
		/// <returns></returns>
		public List<ComponentDirective> GetComponentDirectives(BaseComponent baseComponent, bool loadChild = false)
		{
			var directives = _newLoader.GetObjectListAll<ComponentDirectiveDTO, ComponentDirective>(new Filter("ComponentId", baseComponent.ItemId), loadChild).ToList();

			if(directives.Count == 0)
				return directives;

			var directivesIds = directives.Select(d => d.ItemId);
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directivesIds, SmartCoreType.ComponentDirective.ItemId);

			foreach (var componentDirective in directives)
			{
				componentDirective.ParentComponent = baseComponent;
				componentDirective.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == componentDirective.ItemId || i.SecondItemId == componentDirective.ItemId));//TODO:(Evgenii Babak)не использовать Where 
			}

			return directives;
		}
		#endregion

		#region public List<ComponentDirective> GetComponentDirectives(IList<int> componentDirectiveIds, bool getDeleted = false)

		public List<ComponentDirective> GetComponentDirectives(IList<int> componentDirectiveIds, bool getDeleted = false)
		{
			var componentDirectives = new List<ComponentDirective>();

			if (componentDirectiveIds.Count == 0)
				return componentDirectives;

			componentDirectives.AddRange(_newLoader.GetObjectListAll<ComponentDirectiveDTO, ComponentDirective>(new Filter("ItemId", componentDirectiveIds), true, getDeleted));

			if (componentDirectives.Count == 0)
				return componentDirectives;

			var directivesIds = componentDirectives.Select(d => d.ItemId);
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directivesIds, SmartCoreType.ComponentDirective.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var componentDirective in componentDirectives)
					componentDirective.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == componentDirective.ItemId ||
																						i.SecondItemId == componentDirective.ItemId));
			}

			var componentIds = componentDirectives.Select(dd => dd.ComponentId).Distinct().ToArray();
			var components = _newLoader.GetObjectListAll<ComponentDTO, Entities.General.Accessory.Component>(new List<Filter>()
			{
				new Filter("IsBaseComponent",false),
				new Filter("ItemId", componentIds)
			}, getDeleted: getDeleted);
			var baseComponents = _newLoader.GetObjectListAll<BaseComponentDTO, BaseComponent>(new List<Filter>()
			{
				new Filter("IsBaseComponent", true),
				new Filter("ItemId", componentIds)
			}, getDeleted: getDeleted);

			var allComponents = components.Union(baseComponents.ToArray()).ToArray();

			if (allComponents.Length > 0)
			{
				LoadRelatedObjectds(allComponents, false);
				ConnectComponentDirectivesWithComponents(allComponents, componentDirectives.ToList());
			}

			return componentDirectives;
		}

		#endregion

		#region public List<ComponentDirective> GetAircraftComponentDirectives(int aircraftId, IList<int> detailDirectiveIds)

		public List<ComponentDirective> GetAircraftComponentDirectives(int aircraftId, IList<int> componentDirectiveIds, bool getDeleted = false)
		{
			var componentDirectives = new List<ComponentDirective>();

			if (componentDirectiveIds.Count == 0)
				return componentDirectives;

			var qrs = ComponentDirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId,
				new ICommonFilter[]
				{
					new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In,
						componentDirectiveIds.ToArray())
				}, true, getDeleted);

			componentDirectives.AddRange(_loader.GetObjectListAll<ComponentDirective>(qrs, true));

			if (componentDirectives.Count == 0)
				return componentDirectives;

			var directivesIds = componentDirectives.Select(d => d.ItemId);
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directivesIds, SmartCoreType.ComponentDirective.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var componentDirective in componentDirectives)
					componentDirective.ItemRelations.AddRange(
						itemsRelations.Where(i => i.FirstItemId == componentDirective.ItemId || i.SecondItemId == componentDirective.ItemId));
						//TODO:(Evgenii Babak)не использовать Where 
			}

			//Загрузка компонентов, которым пренадлежат задачи по компонентам
			var componentIds = componentDirectives.Select(dd => dd.ComponentId).Distinct().ToArray();
			var components = _newLoader.GetObjectListAll<ComponentDTO, Entities.General.Accessory.Component>(new List<Filter>()
			{
				new Filter("IsBaseComponent", false),
				new Filter("ItemId",componentIds)
			}).ToArray();
			if (components.Length == 0)
				return componentDirectives;

			LoadRelatedObjectds(components, false);
			ConnectComponentDirectivesWithComponents(components, componentDirectives.ToList());


			return componentDirectives;
		}

		#endregion

		#region private ComponentCollection GetComponentsByQuery(String query)

		/// <summary>
		/// Получает компоненты и все связанные c ними данные по запросу 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <returns></returns>
		private ComponentCollection GetComponentsByQuery(string query, bool loadChild = true)
		{
			var components = new ComponentCollection(_loader.GetObjectListAll<Entities.General.Accessory.Component>(query, loadChild));

			LoadRelatedObjectds(components.ToArray(), loadChild);

			return components;
		}

		#endregion

		public ComponentCollection GetSupplierProcessing(bool loadChild = true)
		{
			var filter = new CommonFilter<string>($@"({SmartCoreType.Supplier.ItemId} in (select top 1 [destinationobjecttype] 
                                        from dbo.TransferRecords 
                                        where dbo.Components.ItemId=Parentid and isdeleted=0 and 
                                        parenttype = {SmartCoreType.Component.ItemId}
                                        order by transferDate desc ))
										or (({SmartCoreType.Employee.ItemId} in (select top 1 [destinationobjecttype] 
                                        from dbo.TransferRecords 
                                        where dbo.Components.ItemId=Parentid and isdeleted=0 and 
                                        parenttype = {SmartCoreType.Component.ItemId}
                                        order by transferDate desc )))");

			var allFilters = new List<ICommonFilter>();
			allFilters.Add(filter);
			var qrs = BaseQueries.GetSelectQueryWithWhere<Entities.General.Accessory.Component>(allFilters.ToArray(), loadChild);

			return GetComponentsByQuery(qrs, loadChild);
		}


		public ComponentCollection GetSupplierProcessingById(int supplierId, bool loadChild = true)
		{
			var filter = new CommonFilter<string>($@"({SmartCoreType.Employee.ItemId} in (select top 1 [destinationobjecttype] 
                                        from dbo.TransferRecords 
                                        where dbo.Components.ItemId=Parentid and isdeleted=0 and DestinationObjectID = {supplierId} and
                                        parenttype = {SmartCoreType.Component.ItemId}
                                        order by transferDate desc ))");

			var allFilters = new List<ICommonFilter>();
			allFilters.Add(filter);
			var qrs = BaseQueries.GetSelectQueryWithWhere<Entities.General.Accessory.Component>(allFilters.ToArray(), loadChild);

			return GetComponentsByQuery(qrs, loadChild);
		}

		#region public void AddComponentDirective(Component component, ComponentDirective componentDirective)
		/// <summary>
		/// Добавляет работу на агрегат вместе с дополнительной информацией
		/// </summary>
		/// <param name="component">агрегат, которому добавляем работу></param>
		/// <param name="componentDirective">Работа, которую добавляем</param>
		public void AddComponentDirective(Entities.General.Accessory.Component component, ComponentDirective componentDirective)
		{
			// Не можем добавить актуальное состояние не существующему агрегату
			if (component.ItemId <= 0) throw new Exception("1026: Can not add component directive to not existing component");

			// Дополняем необходимые данные
			componentDirective.ComponentId = component.ItemId;

			// Сохраняем директиву
			_newKeeper.Save(componentDirective);

			if (componentDirective.Document != null)
			{
				componentDirective.Document.ParentId = componentDirective.ItemId;
				_newKeeper.Save(componentDirective.Document);
			}
				
			// Добавляем директиву в коллекцию
			component.ComponentDirectives.Add(componentDirective);

			// Выставляем родителя директиве
			componentDirective.ParentComponent = component;
		}

		#endregion

		#region public void AddComponent(Component component, IComponentContainer destination, DateTime installationDate, string position, Lifelength installationLifelength, Lifelength lastKnownLifelength = null, DateTime? lastKnownLifelenghtDate = null, bool destinationResponsible = false)

		/// <summary>
		/// Добавляет компонент на базовый агрегат
		/// </summary>
		/// <param name="component">Агрегат, который добавляем в базу данных></param>
		/// <param name="destination">Базовый агрегат, на который устанавливаем агрегат</param>
		/// <param name="installationDate">Дата, когда агрегат был установлен</param>
		/// <param name="position">На какую позицию был установлен агрегат (может быть null)</param>
		/// <param name="installationLifelength">Ресурс агрегата на момент установки (может быть null)</param>
		/// <param name="lastKnownLifelength">Ресурс агрегата на текущий момент (может быть null)</param>
		/// <param name="lastKnownLifelenghtDate">дата на которую нужно записать последний известный ресурс агрегата</param>
		/// <param name="destinationResponsible">Флаг подтверждения перемещения получателем</param>
		public void AddComponent(Entities.General.Accessory.Component component, IComponentContainer destination, DateTime installationDate, string position, ComponentStorePosition state,
								 Lifelength installationLifelength = null, Lifelength lastKnownLifelength = null, DateTime? lastKnownLifelenghtDate = null,
								 bool destinationResponsible = false)
		{
			// Небольшая проверка
			if (destination.ItemId <= 0) throw new Exception("1537: Can not add component to not existing base component");

			// сохраняем агрегат - берем его id - шник
			save(component);

			// создаем transfer record с id-шником созданного агрегата
			if (component.ItemId <= 0) throw new Exception("1536: Failed to insert component to database");
			var transfer = new TransferRecord
			{
				Position = position ?? "",
				DestinationObjectId = destination.ItemId,
				DestinationObjectType = destination.SmartCoreObjectType,
				TransferDate = installationDate,
				StartTransferDate = installationDate,
				ParentId = component.ItemId,
				ParentComponent = component,
				PODR = true,
				DODR = destinationResponsible,
				State = state
			};
			_newKeeper.Save(transfer);
			if (transfer.ItemId <= 0) throw new Exception("1006: Failed to save transfer record to database");

			// добавляем перемещение в коллекцию
			component.TransferRecords.Add(transfer);

			// если нужно добавляем аткуальное состояние агрегату на дату установки
			if (installationLifelength != null && !installationLifelength.IsNullOrZero())
			{
				var actual = new ActualStateRecord
				{
					OnLifelength = new Lifelength(installationLifelength),
					RecordDate = installationDate
				};
				registerActualState(component, actual);
			}

			// выставляем текущее актуальное состояние агрегату
			if (lastKnownLifelength != null && !lastKnownLifelength.IsNullOrZero() && lastKnownLifelenghtDate.HasValue)
			{
				var record = new ActualStateRecord
				{
					RecordDate = lastKnownLifelenghtDate.Value,
					OnLifelength = lastKnownLifelength
				};
				registerActualState(component, record);
			}

			foreach (var componentDirective in component.ComponentDirectives)
			{
				// Дополняем необходимые данные
				componentDirective.ComponentId = component.ItemId;

				// Сохраняем директиву
				_newKeeper.Save(componentDirective);

				// Выставляем родителя директиве
				componentDirective.ParentComponent = component;
			}

			foreach (var productCost in component.ProductCosts)
			{
				productCost.ParentId = component.ItemId;
				productCost.ParentTypeId = component.SmartCoreType.ItemId;
				productCost.SupplierId = component.FromSupplier.ItemId;
				productCost.KitId = component.Product?.ItemId ?? -1;
				_newKeeper.Save(productCost);
			}

			// выставляем родителей для агрегата
			_newLoader.SetDestinations(component);
		}
		#endregion

		#region public void UpdateComponent(Component component, DateTime installationDate, string position, Lifelength installationLifelength)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="component"></param>
		/// <param name="installationDate">Дата, когда агрегат был установлен</param>
		/// <param name="position">На какую позицию был установлен агрегат</param>
		/// <param name="installationLifelength">Ресурс агрегата на момент установки</param>
		/// <exception cref="ArgumentNullException">если component равен null</exception>
		public void UpdateComponent(Entities.General.Accessory.Component component, DateTime installationDate, string position, ComponentStorePosition state, Lifelength installationLifelength)
		{
			if (component == null)
				throw new ArgumentNullException(nameof(component), "component cannot be null");

			save(component);

			if (component is BaseComponent)
			{
				var baseComponent = component as BaseComponent;
				foreach (var componentWorkParam in baseComponent.ComponentWorkParams)
				{
					_newKeeper.Save(componentWorkParam);
				}
			}

			foreach (var componentDirective in component.ComponentDirectives)
			{
				// Дополняем необходимые данные
				componentDirective.ComponentId = component.ItemId;
				// Сохраняем директиву
				_newKeeper.Save(componentDirective);
				// Выставляем родителя директиве
				componentDirective.ParentComponent = component;

				var itemsRelation = componentDirective.ItemRelations.SingleOrDefault();
				if (itemsRelation != null)
				{
					if (itemsRelation.IsDeleted)
					{
						_newKeeper.Delete(itemsRelation);
						componentDirective.ItemRelations.Remove(itemsRelation);
					}
					else _newKeeper.Save(itemsRelation);
				}
			}

			foreach (var productCost in component.ProductCosts)
			{
				productCost.ParentId = component.ItemId;
				productCost.ParentTypeId = component.SmartCoreType.ItemId;
				productCost.SupplierId = component.FromSupplier.ItemId;
				productCost.KitId = component.Product?.ItemId ?? -1;
				_newKeeper.Save(productCost);
			}

			foreach (var relation in component.SupplierRelations)
			{
				if (relation.SupplierId != 0)
					_newKeeper.Save(relation);
			}

			var lastTransferRecord = component.TransferRecords.GetLast();

			if (installationLifelength != null)
			{
				var actual = component.ActualStateRecords[lastTransferRecord.TransferDate];
				if (actual != null)
				{
					if (lastTransferRecord.TransferDate >= installationDate)
					{
						//Дата установки изменена на более раннюю
						actual.OnLifelength = installationLifelength;
						actual.RecordDate = installationDate;
						_newKeeper.Save(actual);
					}
					else if (lastTransferRecord.TransferDate < installationDate)
					{
						//Дата установки изменена на более позднюю
						actual.OnLifelength = installationLifelength;
						actual.RecordDate = installationDate;
						registerActualState(component, actual);
					}
				}
				else
				{
					actual = new ActualStateRecord
					{
						ComponentId = component.ItemId,
						RecordDate = installationDate,
						OnLifelength = installationLifelength
					};
					registerActualState(component, actual);
				}				
				lastTransferRecord.TransferDate = installationDate;
			}
			lastTransferRecord.State = state;

			if (lastTransferRecord.ParentId != component.ItemId)
			{
				lastTransferRecord.ParentId = component.ItemId;
				lastTransferRecord.ParentComponent = component;
			}

			if(component.LLPCategories)
				lastTransferRecord.TransferDate = installationDate;

			lastTransferRecord.Position = position;
			_newKeeper.Save(lastTransferRecord);
		}

		#endregion


		#region public void AddBaseComponent(BaseComponent baseComponent, Aircraft aircraft, DateTime date, String position, Lifelength installationActualState)

		/// <summary>
		/// Добавляет базовый агрегат на воздушное судно
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="aircraft"></param>
		/// <param name="date">Дата установки агрегата на ВС</param>
		/// <param name="position"></param>
		/// <param name="installationActualState">Наработка базового агрегата на момент установки (может быть null)</param>
		/// <param name="destinationResponsible">Флаг подтверждения получателем, по умолчанию false</param>
		/// <param name="reload"></param>
		public void AddBaseComponent(BaseComponent baseComponent, Aircraft aircraft, DateTime date,
								   String position, Lifelength installationActualState,
								   bool destinationResponsible = false, bool reload = true)
		{
			if (baseComponent == null) throw new Exception("0946: Can not save base component to not existing aircraft");
			if (aircraft.ItemId <= 0) throw new Exception("0947: Can not save base component to not existing aircraft");

			// Сохраняем базовый агрегат
			save(baseComponent);
			if (baseComponent.ItemId <= 0)
				throw new Exception("0949: Failed to save base component to database");

			// Создаем transfer record для базового агрегата 
			var transfer = new TransferRecord
			{
				ParentComponent = baseComponent,
				ParentId = baseComponent.ItemId,
				Position = position ?? "",
				TransferDate = date,
				StartTransferDate = date,
				DestinationObjectId = aircraft.ItemId,
				DestinationObjectType = aircraft.SmartCoreObjectType,
				PODR = true,
				DODR = destinationResponsible
			};

			_newKeeper.Save(transfer);
			if (transfer.ItemId <= 0)
				throw new Exception("0950: Failed to save transfer record to base component");

			baseComponent.TransferRecords.Add(transfer);

			if (baseComponent.BaseComponentType == BaseComponentType.Frame)
				aircraft.AircraftFrameId = baseComponent.ItemId;
			// Добавляем актуальное состояние на момент установки агрегата 
			if (installationActualState != null)
			{
				var actual = new ActualStateRecord
				{
					OnLifelength = new Lifelength(installationActualState),
					RecordDate = date
				};
				registerActualState(baseComponent, actual);
			}

			if (reload)
			{
				// Перегружаем ядро
				_casEnvironment.Reset();

				// Выставляем родителей
				var reloaded = _casEnvironment.BaseComponents.GetItemById(baseComponent.ItemId);
				if (reloaded == null) throw new Exception("0951: Failed to load saved base component");

				if (reloaded.LastDestinationObjectType == SmartCoreType.Aircraft)
					baseComponent.ParentAircraftId = reloaded.LastDestinationObjectId;
			}
			else
			{
				_casEnvironment.BaseComponents.Add(baseComponent);
				baseComponent.ParentAircraftId = aircraft.ItemId;
			}
		}
		#endregion

		#region public void AddBaseComponent(BaseComponent baseComponent, Store store, DateTime date, String position, Lifelength installationData)
		/// <summary>
		/// Добавляет базовый агрегат на склад
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="store"></param>
		/// <param name="date"></param>
		/// <param name="position"></param>
		/// <param name="installationData"></param>
		public void AddBaseComponent(BaseComponent baseComponent, Store store, DateTime date, String position, Lifelength installationData)
		{
			// Процедура абсолютно аналогичная добавлению агрегата на воздушное судно
			var aircraft = new Aircraft { ItemId = store.ItemId };
			AddBaseComponent(baseComponent, aircraft, date, position, installationData);
		}
		#endregion

		#region public void Save(Component component)
		/// <summary>
		/// Сохраняет объект component в БД сохраняет если такой уже есть или создает новый если такой объект появляется первый раз
		/// </summary>
		/// <param name="component">принимает агрегат></param>
		public void Save(Entities.General.Accessory.Component component)
		{
			save(component);
		}

		#endregion

		#region private void save(Component component)

		private void save(Entities.General.Accessory.Component component)
		{
			//если есть файл исполнения работ - сохранить его

			if (component.ItemId <= 0)
			{
				var qr = BaseQueries.GetInsertQuery(component);
				var ds = _casEnvironment.Execute(qr, BaseQueries.GetParameters(component));
				component.ItemId = DbTypes.ToInt32(ds.Tables[0].Rows[0][0]);

				if (component.LLPData != null)
				{
					foreach (var data in component.LLPData)
					{
						data.ComponentId = component.ItemId;
						_newKeeper.Save(data);
					}
				}
			}
			else
			{
				if (component.LLPData != null)
				{
					foreach (var data in component.LLPData)
						_newKeeper.Save(data);
				}
				var qr = BaseQueries.GetUpdateQuery(component);
				_casEnvironment.Execute(qr, BaseQueries.GetParameters(component));
			}

			if (component is IFileContainer)
				_newKeeper.SaveAttachedFile(component);
		}

		#endregion

		#region public void Delete(ComponentLLPCategoryChangeRecord componentLLPCategoryChangeRecord)
		/// <summary>
		/// Удаление componentlLLPCategoryChangeRecord
		/// </summary>
		/// <param name="componentLLPCategoryChangeRecord"></param>
		public void DeleteLLPCategoryChangeRecord(ComponentLLPCategoryChangeRecord componentLLPCategoryChangeRecord)
		{
			// Добавление & удаление актуального состояния влияет на математический аппарат

			//componentLLPCategoryChangeRecord.IsDeleted = true;
			_newKeeper.Delete(componentLLPCategoryChangeRecord);

			// Обнуляем математический аппарат
			if (componentLLPCategoryChangeRecord.ParentComponent is BaseComponent)
			{
				componentLLPCategoryChangeRecord.ParentComponent.ChangeLLPCategoryRecords.Remove(componentLLPCategoryChangeRecord);

				var components = GetComponents(componentLLPCategoryChangeRecord.ParentComponent, true);
				foreach (var component in components)
				{
					var llp = component.ChangeLLPCategoryRecords.FirstOrDefault(i =>
						i.ToCategory.ItemId == componentLLPCategoryChangeRecord.ToCategory.ItemId && i.RecordDate.Equals(componentLLPCategoryChangeRecord.RecordDate));
					if (llp != null)
						_newKeeper.Delete(llp); 
				}


				_casEnvironment.Calculator.ResetMath((BaseComponent)componentLLPCategoryChangeRecord.ParentComponent);
			}
			else if (componentLLPCategoryChangeRecord.ParentComponent != null)
				componentLLPCategoryChangeRecord.ParentComponent.ChangeLLPCategoryRecords.Remove(componentLLPCategoryChangeRecord);
			else
				throw new Exception("1030: Failed to specify actual state parent type");
		}

		#endregion

		#region public void Delete(ComponentDirective componentDirective)
		/// <summary>
		/// Удаляет component Directive у агрегата 
		/// </summary>
		/// <param name="componentDirective"></param>
		public void DeleteComponentDirective(ComponentDirective componentDirective)
		{
			componentDirective.IsDeleted = true;
			_newKeeper.Save(componentDirective);

			// удаляем директиву из коллекции директив агрегата
			if (componentDirective.ParentComponent != null)
				componentDirective.ParentComponent.ComponentDirectives.Remove(componentDirective);
			else
				throw new Exception("1123: Failed to specify component directive parent type");
		}
		#endregion

		#region public void Delete(Component component)
		/// <summary>
		/// Удаление Component
		/// </summary>
		/// <param name="component"></param>
		public void DeleteComponent(Entities.General.Accessory.Component component)
		{
			// Не удаляем базовые агрегаты - для них есть соответствующий метод
			if (component.IsBaseComponent) throw new Exception("1149: Can not delete base component");

			//
			component.IsDeleted = true;
			save(component);
		}

		#endregion

		#region public void Delete(BaseComponent baseComponent)
		/// <summary>
		/// Удаление BaseComponent
		/// </summary>
		/// <param name="baseComponent"></param>
		public void DeleteBaseComponent(BaseComponent baseComponent)
		{
			// Не позволяем удалять Frame чтобы не нарушать целостность базы данных 
			if (baseComponent.BaseComponentType == BaseComponentType.Frame) throw new Exception("1129: Can not delete frame base component");

			// Сам объект остается в базе, т.к. через него могли проходить записи Transfer Record
			baseComponent.IsDeleted = true;

			save(baseComponent);
			_casEnvironment.BaseComponents.Remove(baseComponent);
		}

		#endregion

		#region public void Delete(ActualStateRecord actualStateRecord)
		/// <summary>
		/// Удаление actualStateRecord
		/// </summary>
		/// <param name="actualStateRecord"></param>
		public void DeleteActualStateRecord(ActualStateRecord actualStateRecord)
		{
			// Добавление & удаление актуального состояния влияет на математический аппарат

			actualStateRecord.IsDeleted = true;
			_newKeeper.Save(actualStateRecord);

			// Обнуляем математический аппарат
			if (actualStateRecord.ParentComponent is BaseComponent)
			{
				actualStateRecord.ParentComponent.ActualStateRecords.Remove(actualStateRecord);
				_casEnvironment.Calculator.ResetMath((BaseComponent)actualStateRecord.ParentComponent);
			}
			else if (actualStateRecord.ParentComponent != null)
				actualStateRecord.ParentComponent.ActualStateRecords.Remove(actualStateRecord);
			else
				throw new Exception("1030: Failed to specify actual state parent type");
		}

		#endregion

		#region public void RegisterActualState(BaseEntityObject entityObject, DateTime actualDate, Lifelength actualState)

		/// <summary>
		/// Добавляет актуальное состояние на воздушное судно
		/// </summary>
		/// <param name="actualDate"></param>
		/// <param name="actualState"></param>
		/// <param name="entityObject"></param>
		public void RegisterActualState(BaseEntityObject entityObject, DateTime actualDate, Lifelength actualState)
		{
			if (entityObject == null) throw new Exception("1539: Can not register actual state record for not existing object");
			if (entityObject.ItemId <= 0) throw new Exception("1540: Can not register actual state record for not existing object");
			if (actualDate < DateTimeExtend.GetCASMinDateTime()) throw new Exception("1540: Can not register actual state record for date less 1950,1,1");
			if (actualState == null ||
				actualState.IsNullOrZero()) throw new Exception("1540: Can not register actual state record for empty lifelength");
			if (entityObject is Aircraft)
			{
				var aircraftFrame = getBaseComponentById(((Aircraft)entityObject).AircraftFrameId);
				registerActualState(aircraftFrame, new ActualStateRecord { RecordDate = actualDate, OnLifelength = actualState });
			}
			else if (entityObject is BaseComponent)
				registerActualState((BaseComponent)entityObject, new ActualStateRecord { RecordDate = actualDate, OnLifelength = actualState });
			else if (entityObject is Entities.General.Accessory.Component)
				registerActualState((Entities.General.Accessory.Component)entityObject, new ActualStateRecord { RecordDate = actualDate, OnLifelength = actualState });
		}
		#endregion

		#region public void RegisterActualState(Component component, ActualStateRecord actualState)
		/// <summary>
		/// Добавляет агрегату его актуальное состояние 
		/// </summary>
		/// <param name="component"></param>
		/// <param name="actualState"></param>
		public void RegisterActualState(Entities.General.Accessory.Component component, ActualStateRecord actualState)
		{
			registerActualState(component, actualState);
		}
		#endregion

		#region private void registerActualState(Component component, ActualStateRecord actualState)
		/// <summary>
		/// Добавляет агрегату его актуальное состояние 
		/// </summary>
		/// <param name="component"></param>
		/// <param name="actualState"></param>
		private void registerActualState(Entities.General.Accessory.Component component, ActualStateRecord actualState)
		{
			// Не можем добавить актуальное состояние не существующему агрегату
			if (component.ItemId <= 0) throw new Exception("1009: Can not register actual state for not existing component");
			if (component == null) throw new Exception("1610: Can not register actual state for not existing component");
			// Если на данную дату уже существует актуальное состояние - 
			// мы должны изменить уже существующую запись вместо добавления еще одной записи 
			// на одну дату - последствия не предсказуемы

			var existing = component.ActualStateRecords[actualState.RecordDate.Date, actualState.WorkRegime ?? FlightRegime.UNK];
			if (existing != null)
			{
				// запись на указанную дату существует
				// а поэтому изменяем ее данные и сохраняем
				existing.ComponentId = component.ItemId;
				existing.OnLifelength = new Lifelength(actualState.OnLifelength); // изменяем актуальные данные
				existing.Remarks = actualState.Remarks; // перебиваем комментарии
				_newKeeper.Save(existing);
			}
			else
			{
				actualState.ComponentId = component.ItemId; // дополняем необходимые данные
				_newKeeper.Save(actualState); // добавляем в базу данных
				component.ActualStateRecords.Add(actualState); // дабавляем в коллекцию
				actualState.ParentComponent = component; // выставляем обратные ссылки
			}

			if (component is BaseComponent)
			{
				var baseComponent = component as BaseComponent;
				// обнуляем математический аппарат
				_casEnvironment.Calculator.ResetMath(baseComponent);
			}
		}
		#endregion


		#region public void RegisterChangeLLPCategory(Component component, ComponentLLPCategoryChangeRecord performance)
		/// <summary>
		/// Добавить выполнение работы по агрегату
		/// </summary>
		/// <param name="component"></param>
		/// <param name="performance"></param>
		public void RegisterChangeLLPCategory(Entities.General.Accessory.Component component, ComponentLLPCategoryChangeRecord performance)
		{

			// Не можем добавить выполнение для не существующей директивы
			if (component.ItemId <= 0) throw new Exception("1033: Can not register performance for not existing component directive");

			// Дополняем необходимые данные
			performance.ParentId = component.ItemId;

			// Выставляем родителя записи о выполнении
			performance.ParentComponent = component;

			// Сохраняем запись о выполнении
			_newKeeper.Save(performance);

			// Добавляем запись о выполнении в коллекцию
			if(!component.ChangeLLPCategoryRecords.Contains(performance))
				component.ChangeLLPCategoryRecords.Add(performance);

			//устанавливаем новые значения для LifeLimit детали
			var data = component.LLPData.GetItemByCatagory(performance.ToCategory);
			if (data != null)
			{
				component.LifeLimit = data.LLPLifeLimit;
				save(component);
			}

		}
		#endregion

		#region public void MoveToStore(Component component, Store store, DateTime date, String position, double beforeReplace, double replaced, Lifelength onLifeLength, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)

		/// <summary>
		/// Перемещает агрегат на склад
		/// </summary>
		/// <param name="component"></param>
		/// <param name="store"></param>
		/// <param name="transferDate">Дата перемещения</param>
		/// <param name="position"></param>
		/// <param name="beforeReplace">Кол-во комплектующих до перемещения (применяется в случае расходников)</param>
		/// <param name="replaced">Кол-во перемещенных комплектующих (применяется в случае расходников)</param>
		/// <param name="baseComponentLlOnTransferDate">Наработка Базового агрегата на дату перемещения</param>
		/// <param name="wp">рабочий пакет - если перемещение создается в рамках его выполнения. может быть равен null</param>
		/// <param name="transferRecordAttachedFile"></param>
		public void MoveToStore(Entities.General.Accessory.Component component, Store store, DateTime transferDate,
								double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, string remarks, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)
		{
			if (store.ItemId <= 0) throw new Exception("1527: Can not move component to not existing store");

			if (beforeReplace <= 0)
				beforeReplace = 1;
			if (replaced <= 0)
				replaced = 1;

			if (beforeReplace < replaced)
				throw new ArgumentNullException("beforeReplace", "The number of parts to move was less than the number of parts transported");

			var parentAircraft = _aircraftsCore.GetAircraftById(component.ParentAircraftId);
			// создаем запись о перемещении 
			var newTransferRecord = new TransferRecord
			{
				FromAircraftId = parentAircraft != null ? parentAircraft.ItemId : 0,
				FromBaseComponentId = component.ParentBaseComponent != null ? component.ParentBaseComponent.ItemId : 0,
				FromStoreId = component.ParentStoreId,
				FromSupplierId = component.ParentSupplierId,
				FromSpecialistId = component.ParentSpecialistId,
				ParentId = component.ItemId,
				DestinationObjectId = store.ItemId,
				DestinationObjectType = store.SmartCoreObjectType,
				ParentComponent = component,
				TransferDate = transferDate,
				StartTransferDate = transferDate,
				Position = "",
				DirectivePackageId = wp != null ? wp.ItemId : -1,
				AttachedFile = wp != null ? wp.AttachedFile : transferRecordAttachedFile,
				Description = description,
				Reason = reason,
				ReceivedSpecialist = received,
				ReleasedSpecialist = released,
				Remarks = remarks
			};

			if (beforeReplace != replaced)
			{
				//Кол-во исходных комплектующих понижается на кол-во перемещаемых комплектующих
				component.Quantity -= replaced;
				//Сохранение исходных комплектующих
				save(component);

				//Создание клона исходной детали
				//У клона детали кол-во задается равным кол-ву перемещаемых комплектующих
				var newComponent = new Entities.General.Accessory.Component(component) { Quantity = replaced, QuantityIn = replaced};
				newComponent.TransferRecords.Clear();
				//Сохранение агрегата в базе данных
				save(newComponent);
				if (newComponent.ItemId <= 0) throw new Exception("0956: Failed to save component to database");
				//Отметка исходной детали как источника расходника

				#region Сохранение актуальных состояний

				foreach (var asr in newComponent.ActualStateRecords)
				{
					asr.ParentComponent = newComponent;
					asr.ComponentId = newComponent.ItemId;
					_newKeeper.Save(asr);
				}
				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = ""
				};
				registerActualState(newComponent, newActualState);
				#endregion

				#region Сохранение записей о перемещении

				newTransferRecord.ConsumableId = component.ItemId;
				// проверка есть ли пемещения на данную дату
				if (newComponent.TransferRecords.Any(transferRecord => transferRecord.TransferDate == newTransferRecord.TransferDate))
					throw new Exception("1658: There can not be several transfer records at one day");
				// добавляем в коллекцию
				//foreach (var tr in newComponent.TransferRecords)
				//{
				//	//Для старых записей о перемещении надо проставить родителем новую деталь
				//	tr.ParentComponent = newComponent;
				//	tr.ParentId = newComponent.ItemId;
				//	//Сохранить старые записи о перемещении, не сохраняя при этом прикрепленный файл
				//	_keeper.Save(tr, false);
				//}
				//Сохранение новой записи о перемещении с сохранением прикрепленного файла
				newTransferRecord.ParentComponent = newComponent;
				newTransferRecord.ParentId = newComponent.ItemId;
				_newKeeper.Save(newTransferRecord);
				//Добавление новой записи о перемешении в коллекцию записей новой детали
				newComponent.TransferRecords.Add(newTransferRecord);
				#endregion

				#region Сохранение директив детали

				foreach (var directive in newComponent.ComponentDirectives)
				{
					directive.ParentComponent = newComponent;
					directive.ComponentId = newComponent.ItemId;

					_newKeeper.Save(directive, false);

					foreach (var kit in directive.Kits)
					{
						kit.ParentId = directive.ItemId;
						kit.ParentObject = directive;

						_newKeeper.Save(kit, false);

						foreach (var ksr in kit.SupplierRelations)
						{
							ksr.ParentTypeId = kit.SmartCoreObjectType.ItemId;
							ksr.KitId = kit.ItemId;
							_newKeeper.Save(ksr);
						}
					}

					foreach (var directiveRecord in directive.PerformanceRecords)
					{
						directiveRecord.Parent = directive;
						directiveRecord.ParentId = directive.ItemId;
						_newKeeper.Save(directiveRecord, false);
					}
				}
				#endregion

				#region Сохранение Записей о смене LLP категорий

				foreach (var changeRecord in newComponent.ChangeLLPCategoryRecords)
				{
					changeRecord.ParentComponent = newComponent;
					changeRecord.ParentId = newComponent.ItemId;
					_newKeeper.Save(changeRecord, false);
				}
				#endregion

				#region Сохранение связей с поставщиками детали

				foreach (var ksr in newComponent.SupplierRelations)
				{
					ksr.ParentTypeId = newComponent.SmartCoreObjectType.ItemId;
					ksr.KitId = newComponent.ItemId;
					_newKeeper.Save(ksr);
				}
				#endregion

				#region Сохранение КИТов

				foreach (var kit in newComponent.Kits)
				{
					kit.ParentId = newComponent.ItemId;
					kit.ParentObject = newComponent;
					_newKeeper.Save(kit);
				}
				#endregion
			}
			else
			{
				// Проверяем TransferRecord на перекрытие даты с Актульным состоянием
				//Check(detail, newTransferRecord);
				// проверяем есть ли пемещения на данную дату
				//if (component.TransferRecords.Any(transferRecord => transferRecord.TransferDate == newTransferRecord.TransferDate))
				//	throw new Exception("1658: There can not be several transfer records at one day");

				component.QuantityIn = replaced;
				_newKeeper.Save(component);

				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = "Actual state on transfer"
				};
				registerActualState(component, newActualState);

				_newKeeper.Save(newTransferRecord); // сохраняем запись
																// добавляем в коллекцию
				component.TransferRecords.Add(newTransferRecord);
			}
			// обновляем обратные ссылки
			_newLoader.SetDestinations(component);
			//MoveToBaseDetail(detail, store.Frame, date, position);   
		}
		#endregion


		public void MoveToProcessing(Entities.General.Accessory.Component component, int destinationSupplierId, int destinationSpecialistId, DateTime transferDate, double beforeReplace,
			double replaced, Lifelength baseComponentLlOnTransferDate, string description, string remarks, InitialReason reason,
			Specialist released, Specialist received, WorkPackage currentWorkPackage, AttachedFile transferRecordAttachedFile, DateTime receipDate, Lifelength notify)
		{
			if (destinationSupplierId <= 0 && destinationSpecialistId <=0) throw new Exception("1527: Can not move component to not existing specialist or supplier");

			if (beforeReplace <= 0)
				beforeReplace = 1;
			if (replaced <= 0)
				replaced = 1;

			if (beforeReplace < replaced)
				throw new ArgumentNullException("beforeReplace", "The number of parts to move was less than the number of parts transported");

			var parentAircraft = _aircraftsCore.GetAircraftById(component.ParentAircraftId);
			// создаем запись о перемещении 
			var newTransferRecord = new TransferRecord
			{
				FromAircraftId = parentAircraft != null ? parentAircraft.ItemId : 0,
				FromBaseComponentId = component.ParentBaseComponent != null ? component.ParentBaseComponent.ItemId : 0,
				FromStoreId = component.ParentStoreId,
				ParentId = component.ItemId,
				ParentComponent = component,
				TransferDate = transferDate,
				StartTransferDate = transferDate,
				Position = "",
				DirectivePackageId = currentWorkPackage != null ? currentWorkPackage.ItemId : -1,
				AttachedFile = currentWorkPackage != null ? currentWorkPackage.AttachedFile : transferRecordAttachedFile,
				Description = description,
				Reason = reason,
				ReceivedSpecialist = received,
				ReleasedSpecialist = released,
				Remarks = remarks,
				SupplierNotify = notify,
				SupplierReceiptDate = receipDate
			};

			if (destinationSpecialistId > 0)
			{
				newTransferRecord.DestinationObjectId = destinationSpecialistId;
				newTransferRecord.DestinationObjectType = SmartCoreType.Employee;
			}
			else if (destinationSupplierId > 0)
			{
				newTransferRecord.DestinationObjectId = destinationSupplierId;
				newTransferRecord.DestinationObjectType = SmartCoreType.Supplier;
			}

			if (beforeReplace != replaced)
			{
				//Кол-во исходных комплектующих понижается на кол-во перемещаемых комплектующих
				component.Quantity -= replaced;
				//Сохранение исходных комплектующих
				save(component);

				//Создание клона исходной детали
				//У клона детали кол-во задается равным кол-ву перемещаемых комплектующих
				var newComponent = new Entities.General.Accessory.Component(component) { Quantity = replaced, QuantityIn = replaced };
				newComponent.TransferRecords.Clear();
				//Сохранение агрегата в базе данных
				save(newComponent);
				if (newComponent.ItemId <= 0) throw new Exception("0956: Failed to save component to database");
				//Отметка исходной детали как источника расходника

				#region Сохранение актуальных состояний

				foreach (var asr in newComponent.ActualStateRecords)
				{
					asr.ParentComponent = newComponent;
					asr.ComponentId = newComponent.ItemId;
					_newKeeper.Save(asr);
				}
				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = ""
				};
				registerActualState(newComponent, newActualState);
				#endregion

				#region Сохранение записей о перемещении

				newTransferRecord.ConsumableId = component.ItemId;
				// проверка есть ли пемещения на данную дату
				if (newComponent.TransferRecords.Any(transferRecord => transferRecord.TransferDate == newTransferRecord.TransferDate))
					throw new Exception("1658: There can not be several transfer records at one day");
				// добавляем в коллекцию
				//foreach (var tr in newComponent.TransferRecords)
				//{
				//	//Для старых записей о перемещении надо проставить родителем новую деталь
				//	tr.ParentComponent = newComponent;
				//	tr.ParentId = newComponent.ItemId;
				//	//Сохранить старые записи о перемещении, не сохраняя при этом прикрепленный файл
				//	_keeper.Save(tr, false);
				//}
				//Сохранение новой записи о перемещении с сохранением прикрепленного файла
				newTransferRecord.ParentComponent = newComponent;
				newTransferRecord.ParentId = newComponent.ItemId;
				_newKeeper.Save(newTransferRecord);
				//Добавление новой записи о перемешении в коллекцию записей новой детали
				newComponent.TransferRecords.Add(newTransferRecord);
				#endregion

				#region Сохранение директив детали

				foreach (var directive in newComponent.ComponentDirectives)
				{
					directive.ParentComponent = newComponent;
					directive.ComponentId = newComponent.ItemId;

					_newKeeper.Save(directive, false);

					foreach (var kit in directive.Kits)
					{
						kit.ParentId = directive.ItemId;
						kit.ParentObject = directive;

						_newKeeper.Save(kit, false);

						foreach (var ksr in kit.SupplierRelations)
						{
							ksr.ParentTypeId = kit.SmartCoreObjectType.ItemId;
							ksr.KitId = kit.ItemId;
							_newKeeper.Save(ksr);
						}
					}

					foreach (var directiveRecord in directive.PerformanceRecords)
					{
						directiveRecord.Parent = directive;
						directiveRecord.ParentId = directive.ItemId;
						_newKeeper.Save(directiveRecord, false);
					}
				}
				#endregion

				#region Сохранение Записей о смене LLP категорий

				foreach (var changeRecord in newComponent.ChangeLLPCategoryRecords)
				{
					changeRecord.ParentComponent = newComponent;
					changeRecord.ParentId = newComponent.ItemId;
					_newKeeper.Save(changeRecord, false);
				}
				#endregion

				#region Сохранение связей с поставщиками детали

				foreach (var ksr in newComponent.SupplierRelations)
				{
					ksr.ParentTypeId = newComponent.SmartCoreObjectType.ItemId;
					ksr.KitId = newComponent.ItemId;
					_newKeeper.Save(ksr);
				}
				#endregion

				#region Сохранение КИТов

				foreach (var kit in newComponent.Kits)
				{
					kit.ParentId = newComponent.ItemId;
					kit.ParentObject = newComponent;
					_newKeeper.Save(kit);
				}
				#endregion
			}
			else
			{
				// Проверяем TransferRecord на перекрытие даты с Актульным состоянием
				//Check(detail, newTransferRecord);
				// проверяем есть ли пемещения на данную дату
				//if (component.TransferRecords.Any(transferRecord => transferRecord.TransferDate == newTransferRecord.TransferDate))
				//	throw new Exception("1658: There can not be several transfer records at one day");

				component.QuantityIn = replaced;
				_newKeeper.Save(component);

				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = "Actual state on transfer"
				};
				registerActualState(component, newActualState);

				_newKeeper.Save(newTransferRecord); // сохраняем запись
				// добавляем в коллекцию
				component.TransferRecords.Add(newTransferRecord);
			}
			// обновляем обратные ссылки
			_newLoader.SetDestinations(component);
			//MoveToBaseDetail(detail, store.Frame, date, position);   
		}

		#region public void MoveToAircraft(Component component, BaseComponent baseComponent, Aircraft aircraft, DateTime date, String position, double beforeReplace, double replaced, Lifelength onLifeLength, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)

		/// <summary>
		/// Перемещает агрегат на воздушное судно в заданную базовую деталь
		/// </summary>
		/// <param name="component"></param>
		/// <param name="baseComponent"></param>
		/// <param name="aircraft"></param>
		/// <param name="transferDate">Дата перемещения</param>
		/// <param name="position"></param>
		/// <param name="beforeReplace">Кол-во комплектующих до перемещения (применяется в случае расходников)</param>
		/// <param name="replaced">Кол-во перемещенных комплектующих (применяется в случае расходников)</param>
		/// <param name="baseComponentLlOnTransferDate">Наработка Базового агрегата на дату перемещения</param>
		/// <param name="wp"></param>
		/// <param name="transferRecordAttachedFile"></param>
		public void MoveToAircraft(Entities.General.Accessory.Component component, BaseComponent baseComponent, Aircraft aircraft, DateTime transferDate,
								   double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)
		{
			if (aircraft.ItemId <= 0) throw new Exception("1519: Can not move component to not existing aircraft");
			if (getBaseComponentById(aircraft.AircraftFrameId) == null) throw new Exception("1520: Can not move component to not existing aircraft");
			if (aircraft.AircraftFrameId <= 0) throw new Exception("1521: Can not move component to not existing aircraft");
			if (baseComponent.ItemId <= 0) throw new Exception("1518: Can not move to not existing base component");
			MoveToBaseComponent(component, baseComponent, transferDate, beforeReplace, replaced, baseComponentLlOnTransferDate, description, reason, released, received, wp, transferRecordAttachedFile);
		}
		#endregion

		#region public void MoveToStore(BaseComponent baseComponent, Store store, DateTime date, String position, Lifelength onLifeLength, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)

		/// <summary>
		/// Перемещает базовый агрегат на склад
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="store"></param>
		/// <param name="transferDate">Дата перемещения</param>
		/// <param name="position"></param>
		/// <param name="baseComponentLlOnTransferDate">Наработка Базового агрегата на дату перемещения</param>
		/// <param name="wp"></param>
		/// <param name="transferRecordAttachedFile"></param>
		public void MoveToStore(BaseComponent baseComponent, Store store, DateTime transferDate, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received,
			WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)
		{
			if (store.ItemId <= 0) throw new Exception("1527: Can not move component to not existing store");
			// Ограничения - агрегат должен существовать, вс должно существовать, агрегат не должен быть frame
			if (baseComponent == null) throw new Exception("1800: Can not move not existing base component");
			if (baseComponent.ItemId <= 0) throw new Exception("1801: Can not move not existing base component");
			if (baseComponent.BaseComponentType == BaseComponentType.Frame) throw new Exception("1803: Can not move frame base components");
			var parentAircraft = _aircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
			// Создаем запись о перемещении
			var newTransferRecord = new TransferRecord
			{
				FromAircraftId = parentAircraft != null
												? parentAircraft.ItemId
												: 0,
				FromStoreId = baseComponent.ParentStoreId,
				FromSupplierId = baseComponent.ParentSupplierId,
				FromSpecialistId = baseComponent.ParentSpecialistId,
				ParentId = baseComponent.ItemId,
				DestinationObjectId = store.ItemId,
				DestinationObjectType = store.SmartCoreObjectType,
				Position = "",
				DirectivePackageId = wp != null ? wp.ItemId : -1,
				AttachedFile = wp != null ? wp.AttachedFile : transferRecordAttachedFile,
				ParentComponent = baseComponent,
				TransferDate = transferDate,
				StartTransferDate = transferDate,
				Description = description,
				Reason = reason,
				ReleasedSpecialist = released,
				ReceivedSpecialist = received
			};

			// проверяем есть ли пемещения на данную дату
			if (baseComponent.TransferRecords.Any(transferRecord => transferRecord.TransferDate == newTransferRecord.TransferDate))
				throw new Exception("1658: There can not be several transfer records at one day");

			var newActualState = new ActualStateRecord
			{
				OnLifelength = baseComponentLlOnTransferDate,
				RecordDate = transferDate,
				Remarks = ""
			};
			registerActualState(baseComponent, newActualState);
			// сохраняем запись
			_newKeeper.Save(newTransferRecord);
			// добавляем в коллекцию
			baseComponent.TransferRecords.Add(newTransferRecord);

			// Обновляем обратные ссылки
			_newLoader.SetDestinations(baseComponent);

			// Обнуляем мат аппарат
			_casEnvironment.Calculator.ResetMath(baseComponent);
		}
		#endregion

		#region public void MoveToAircraft(BaseComponent baseComponent, Aircraft aircraft, DateTime date, String position, Lifelength onLifeLength, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)

		/// <summary> 
		/// Перемещает базовый агрегат на воздушное судно
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="aircraft"></param>
		/// <param name="transferDate">Дата перемещения</param>
		/// <param name="position"></param>
		/// <param name="baseComponentLlOnTransferDate">Наработка Базового агрегата на дату перемещения</param>
		/// <param name="wp"></param>
		/// <param name="transferRecordAttachedFile"></param>
		public void MoveToAircraft(BaseComponent baseComponent, Aircraft aircraft, DateTime transferDate, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp = null, AttachedFile transferRecordAttachedFile = null)
		{
			if (aircraft.ItemId <= 0) throw new Exception("1802: Can not move base detail to not existing aircraft");
			if (baseComponent == null) throw new Exception("1800: Can not move not existing base component");
			if (baseComponent.ItemId <= 0) throw new Exception("1801: Can not move not existing base component");
			if (baseComponent.BaseComponentType == BaseComponentType.Frame) throw new Exception("1803: Can not move frame base components");
			var parentAircraft = _aircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
			// Создаем запись о перемещении
			var transfer = new TransferRecord
			{
				FromAircraftId = parentAircraft != null
												 ? parentAircraft.ItemId
												: 0,
				FromStoreId = baseComponent.ParentStoreId,
				FromSupplierId = baseComponent.ParentSupplierId,
				FromSpecialistId = baseComponent.ParentSpecialistId,
				ParentId = baseComponent.ItemId,
				DestinationObjectId = aircraft.ItemId,
				DestinationObjectType = aircraft.SmartCoreObjectType,
				Position = "",
				AttachedFile = wp != null ? wp.AttachedFile : transferRecordAttachedFile,
				DirectivePackageId = wp != null ? wp.ItemId : -1,
				ParentComponent = baseComponent,
				TransferDate = transferDate,
				StartTransferDate = transferDate,
				Description = description,
				Reason = reason,
				ReleasedSpecialist = released,
				ReceivedSpecialist = received
			};

			// проверяем есть ли пемещения на данную дату
			if (baseComponent.TransferRecords.Any(transferRecord => transferRecord.TransferDate == transfer.TransferDate))
				throw new Exception("1658: There can not be several transfer records at one day");

			var newActualState = new ActualStateRecord
			{
				OnLifelength = baseComponentLlOnTransferDate,
				RecordDate = transferDate,
				Remarks = ""
			};
			registerActualState(baseComponent, newActualState);
			//сохранение записи
			_newKeeper.Save(transfer);
			// добавляем в коллекцию
			baseComponent.TransferRecords.Add(transfer);
			// Обновляем обратные ссылки
			_newLoader.SetDestinations(baseComponent);

			// Обнуляем мат аппарат
			_casEnvironment.Calculator.ResetMath(baseComponent);
		}

		#endregion

		#region private void MoveToBaseComponent(Component component, BaseComponent destination, DateTime date, String position, double beforeReplace, double replaced, Lifelength onLifeLength, WorkPackage wp, AttachedFile transferRecordAttachedFile = null)

		/// <summary>
		/// Перемещает агрегат на базовый агрегат
		/// </summary>
		/// <param name="component"></param>
		/// <param name="destination"></param>
		/// <param name="transferDate"></param>
		/// <param name="position"></param>
		/// <param name="beforeReplace">Кол-во комплектующих до перемещения (применяется в случае расходников)</param>
		/// <param name="replaced">Кол-во перемещенных комплектующих (применяется в случае расходников)</param>
		/// <param name="baseComponentLlOnTransferDate">Наработка Базового агрегата на дату перемещения</param>
		/// <param name="wp"></param>
		/// <param name="transferRecordAttachedFile"></param>
		private void MoveToBaseComponent(Entities.General.Accessory.Component component, BaseComponent destination, DateTime transferDate,
									  double beforeReplace, double replaced, Lifelength baseComponentLlOnTransferDate, string description, InitialReason reason, Specialist released, Specialist received, WorkPackage wp, AttachedFile transferRecordAttachedFile = null)
		{

			if (component.ItemId <= 0) throw new Exception("1517: Can not move not existing component");
			if (destination.ItemId <= 0) throw new Exception("1518: Can not move to not existing base component");

			if (beforeReplace <= 0)
				beforeReplace = 1;
			if (replaced <= 0)
				replaced = 1;

			if (beforeReplace < replaced)
				throw new ArgumentNullException("beforeReplace", "The number of parts to move was less than the number of parts transported");
			// создаем запись о перемещении 
			var parentAircraft = _aircraftsCore.GetAircraftById(destination.ParentAircraftId);
			var transfer = new TransferRecord
			{
				FromAircraftId = parentAircraft != null
									 ? parentAircraft.ItemId
									 : 0,
				FromBaseComponentId = component.ParentBaseComponent != null
									   ? component.ParentBaseComponent.ItemId//TODO:(Evgenii Babak) заменить на использование ComponentCore 
									   : 0,
				FromStoreId = component.ParentStoreId,
				FromSupplierId = component.ParentSupplierId,
				FromSpecialistId = component.ParentSpecialistId,
				ParentId = component.ItemId,
				DestinationObjectId = destination.ItemId,
				DestinationObjectType = destination.SmartCoreObjectType,
				ParentComponent = component,
				TransferDate = transferDate,
				StartTransferDate = transferDate,
				Position = "",
				DirectivePackageId = wp != null ? wp.ItemId : -1,
				AttachedFile = wp != null ? wp.AttachedFile : transferRecordAttachedFile,
				Description = description,
				Reason = reason,
				ReleasedSpecialist = released,
				ReceivedSpecialist = received
			};

			Check(component, transfer);// Проверяем TransferRecord на перекрытие даты с Актульным состоянием

			if (beforeReplace != replaced)
			{
				//Кол-во исходных комплектующих понижается на кол-во перемещаемых комплектующих
				component.Quantity -= replaced;
				//Сохранение исходных комплектующих
				save(component);

				//Создание клона исходной детали
				//У клона детали кол-во задается равным кол-ву перемещаемых комплектующих
				var newComponent = new Entities.General.Accessory.Component(component) { Quantity = replaced, QuantityIn =  replaced};
				newComponent.TransferRecords.Clear();
				//Сохранение агрегата в базе данных
				save(newComponent);
				if (newComponent.ItemId <= 0) throw new Exception("0956: Failed to save component to database");
				//Отметка исходной детали как источника расходника

				#region Сохранение актуальных состояний

				foreach (var asr in newComponent.ActualStateRecords)
				{
					asr.ParentComponent = newComponent;
					asr.ComponentId = newComponent.ItemId;
					_newKeeper.Save(asr);
				}
				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = ""
				};
				registerActualState(newComponent, newActualState);
				#endregion

				#region Сохранение записей о перемещении

				transfer.ConsumableId = component.ItemId;
				// проверка есть ли пемещения на данную дату
				if (newComponent.TransferRecords.Any(transferRecord => transferRecord.TransferDate == transfer.TransferDate))
					throw new Exception("1658: There can not be several transfer records at one day");
				// добавляем в коллекцию
				//foreach (var tr in newComponent.TransferRecords)
				//{
				//	//Для старых записей о перемещении надо проставить родителем новую деталь
				//	tr.ParentComponent = newComponent;
				//	tr.ParentId = newComponent.ItemId;
				//	//Сохранить старые записи о перемещении, не сохраняя при этом прикрепленный файл
				//	_keeper.Save(tr, false);
				//}
				//Сохранение новой записи о перемещении с сохранением прикрепленного файла
				transfer.ParentComponent = newComponent;
				transfer.ParentId = newComponent.ItemId;
				_newKeeper.Save(transfer);
				//Добавление новой записи о перемешении в коллекцию записей новой детали
				newComponent.TransferRecords.Add(transfer);
				#endregion

				#region Сохранение директив детали

				foreach (var directive in newComponent.ComponentDirectives)
				{
					directive.ParentComponent = newComponent;
					directive.ComponentId = newComponent.ItemId;

					_newKeeper.Save(directive, false);

					foreach (var kit in directive.Kits)
					{
						kit.ParentId = directive.ItemId;
						kit.ParentObject = directive;

						_newKeeper.Save(kit, false);

						foreach (var ksr in kit.SupplierRelations)
						{
							ksr.ParentTypeId = kit.SmartCoreObjectType.ItemId;
							ksr.KitId = kit.ItemId;
							_newKeeper.Save(ksr);
						}
					}

					foreach (var directiveRecord in directive.PerformanceRecords)
					{
						directiveRecord.Parent = directive;
						directiveRecord.ParentId = directive.ItemId;
						_newKeeper.Save(directiveRecord, false);
					}
				}
				#endregion

				#region Сохранение Записей о смене LLP категорий

				foreach (var changeRecord in newComponent.ChangeLLPCategoryRecords)
				{
					changeRecord.ParentComponent = newComponent;
					changeRecord.ParentId = newComponent.ItemId;
					_newKeeper.Save(changeRecord, false);
				}
				#endregion

				#region Сохранение связей с поставщиками детали

				foreach (var ksr in newComponent.SupplierRelations)
				{
					ksr.ParentTypeId = newComponent.SmartCoreObjectType.ItemId;
					ksr.KitId = newComponent.ItemId;
					_newKeeper.Save(ksr);
				}
				#endregion

				#region Сохранение КИТов

				foreach (var kit in newComponent.Kits)
				{
					kit.ParentId = newComponent.ItemId;
					kit.ParentObject = newComponent;
					_newKeeper.Save(kit);
				}
				#endregion

				_newLoader.SetDestinations(newComponent);
			}
			else
			{
				// Проверяем TransferRecord на перекрытие даты с Актульным состоянием
				//Check(detail, newTransferRecord);
				// проверяем есть ли пемещения на данную дату
				//if (component.TransferRecords.Any(transferRecord => transferRecord.TransferDate == transfer.TransferDate))
				//	throw new Exception("1658: There can not be several transfer records at one day");

				component.QuantityIn = replaced;
				_newKeeper.Save(component);

				var newActualState = new ActualStateRecord
				{
					OnLifelength = baseComponentLlOnTransferDate,
					RecordDate = transferDate,
					Remarks = ""
				};
				registerActualState(component, newActualState);
				// сохраняем запись
				_newKeeper.Save(transfer);
				// добавляем в коллекцию
				component.TransferRecords.Add(transfer);

				// обновляем обратные ссылки
				_newLoader.SetDestinations(component);
			}

		}
		#endregion

		#region private static void Check(Component component, TransferRecord transferRecord)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="component"></param>
		/// <param name="transferRecord"></param>
		private static void Check(Entities.General.Accessory.Component component, TransferRecord transferRecord)
		{
			if (transferRecord.ItemId > 0)
				if (transferRecord.TransferDate > component.ActualStateRecords[0].RecordDate.Date)
					throw new Exception("953: You can not change the date on TransferRecord bigger than the first ActualState");
		}

		#endregion

		#region public void LoadRelatedObjectds(Entities.General.Accessory.Component[] components, bool loadChild = true)

		/// <summary> 
		/// Подготавливает математический аппарат для списка агрегатов
		/// </summary>
		/// <param name="components"></param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		public void LoadRelatedObjectds(Entities.General.Accessory.Component[] components, bool loadChild = true)
		{
			// Создаем необходимые коллекции внутри агрегатов
			if (components.Length == 0)
				return;

			var componentids = components.Select(d => d.ItemId).ToArray();

			#region Загружаем привязанные файлы

			var fileLinksDict = _newLoader.GetObjectListAll<ItemFileLinkDTO,ItemFileLink>(new List<Filter>()
			{
				new Filter("ParentTypeId", SmartCoreType.Component.ItemId),
				new Filter("ParentId",componentids)
			},true).ToLookup(i => i.ParentId);

			foreach (var component in components.Where(component => fileLinksDict.Contains(component.ItemId)))
			{
				component.Files.AddRange(fileLinksDict[component.ItemId]);
			}

			#endregion

			#region Загружаем записи о перемещении
			//TODO:(Evgenii Babak) нужно использовать TransferRecordsDataAccess
			var transfers = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new Filter("ParentID", componentids),false).ToList();
			SetFromAndDestination(transfers);
			ConnectTransfersWithComponents(components, transfers);

			#endregion

			#region Загружаем актуальные состояния

			var actuals = _newLoader.GetObjectListAll<ActualStateRecordDTO,ActualStateRecord>(new Filter("ComponentId", componentids));
			ConnectActualsWithComponents(components, actuals);

			#endregion

			if (loadChild)
			{
				var kits = _newLoader.GetObjectListAll<AccessoryRequiredDTO, AccessoryRequired>(new List<Filter>()
				{
					new Filter("ParentTypeId", SmartCoreType.Component.ItemId),
					new Filter("ParentId", componentids)
				}, true);

				#region Поставщики
				var ksrs = _newLoader.GetObjectListAll<KitSuppliersRelationDTO,KitSuppliersRelation>(new List<Filter>()
				{
					new Filter("ParentTypeId",SmartCoreType.Component.ItemId),
					new Filter("KitId",componentids)
				});

				var ids = ksrs.Select(k => k.SupplierId).ToArray();
				var suppliers = new List<Supplier>();
				if(ids.Length > 0)
					suppliers.AddRange(_newLoader.GetObjectListAll<SupplierDTO,Supplier>(new Filter("ItemId", ids)));

				#endregion

				#region загрузка данных по LLP категориям

				var llpData = _newLoader.GetObjectListAll<ComponentLLPCategoryDataDTO, ComponentLLPCategoryData>(new Filter("ComponentId", componentids));
				foreach (var d in components)
					d.LLPData.AddRange(llpData.Where(k => k.ComponentId == d.ItemId).ToArray());

				#endregion

				#region загрузка записей о смене LLP категории

				var llpChangeRecords =  _newLoader.GetObjectListAll<ComponentLLPCategoryChangeRecordDTO,ComponentLLPCategoryChangeRecord>(new Filter("ParentId", componentids));

				#endregion
				var productCosts = _newLoader.GetObjectListAll<ProductCostDTO,ProductCost>(new List<Filter>()
				{
					new Filter("ParentTypeId", SmartCoreType.Component.ItemId),
					new Filter("ParentId", componentids)
				});


				if (components.Length == 0)
					return;
				// загрузка работ по агрегатам
				var componentIds = components.Select(d => d.ItemId).ToArray();
				var directives = _newLoader.GetObjectList<ComponentDirectiveDTO,ComponentDirective>(new Filter("ComponentId", componentIds),true);
				ConnectComponentDirectivesWithComponents(components, directives);


				if (directives.Count > 0)
				{
					var directivesIds = directives.Select(d => d.ItemId);
					var itemsRelations = _itemsRelationsDataAccess.GetRelations(directivesIds, SmartCoreType.ComponentDirective.ItemId);

					if (itemsRelations.Count > 0)
					{
						foreach (var componentDirective in directives)
							componentDirective.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == componentDirective.ItemId || i.SecondItemId == componentDirective.ItemId));//TODO:(Evgenii Babak)не использовать Where 
					}
				}

				var types = new[] {SmartCoreType.Component.ItemId, SmartCoreType.ComponentDirective.ItemId};
				//Загрузка документов
				//var documents = _newLoader.GetObjectListAll<DocumentDTO,Document>(new Filter("ParentTypeId", types), true);

				
				foreach (var component in components)
				{
					//if (documents.Count > 0)
					//{
					//	var crs = _casEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
					//	var shipping =
					//		_casEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;

					//	var docShipping = documents.FirstOrDefault(d =>
					//		d.ParentId == component.ItemId && d.ParentTypeId == SmartCoreType.Component.ItemId &&
					//		d.DocumentSubType == shipping);
					//	if (docShipping != null)
					//	{
					//		component.Document = docShipping;
					//		component.Document.Parent = component;
					//	}

					//	var docCrs = documents.FirstOrDefault(d =>
					//		d.ParentId == component.ItemId && d.ParentTypeId == SmartCoreType.Component.ItemId && d.DocumentSubType == crs);
					//	if (docCrs != null)
					//	{
					//		component.DocumentCRS = docCrs;
					//		component.DocumentCRS.Parent = component;
					//	}

					//	foreach (var directive in component.ComponentDirectives)
					//	{
					//		var docCd = documents.FirstOrDefault(d =>
					//			d.ParentId == directive.ItemId && d.ParentTypeId == SmartCoreType.ComponentDirective.ItemId);
					//		if (docCd != null)
					//		{
					//			directive.Document = docCd;
					//			directive.Document.Parent = directive;
					//		}
					//	}
					//}


					if (kits.Count > 0)
					{
						component.Kits.Clear();
						component.Kits.AddRange(kits.Where(k => k.ParentId == component.ItemId));
						foreach (AccessoryRequired kit in component.Kits) kit.ParentObject = component;
					}

					if (productCosts.Count > 0)
					{
						component.ProductCosts.AddRange(productCosts.Where(p => p.ParentId == component.ItemId));
						foreach (var productCost in component.ProductCosts)
							productCost.ParentComponent = component;
					}

					if (llpChangeRecords.Count > 0)
					{
						component.ChangeLLPCategoryRecords.AddRange(llpChangeRecords.Where(k => k.ParentId == component.ItemId).ToArray());
						foreach (ComponentLLPCategoryChangeRecord data in component.ChangeLLPCategoryRecords)
							data.ParentComponent = component;
					}

					component.SupplierRelations.AddRange(ksrs.Where(k => k.KitId == component.ItemId));
					var supls = (from sup in suppliers
						from k in ksrs
						where k.KitId == component.ItemId &&
						      sup.ItemId == k.SupplierId
						select sup).ToList();
					component.Suppliers.AddRange(supls.ToArray());


					_newLoader.SetDestinations(component);

				}
			}
			else
			{
				foreach (var component in components)
					_newLoader.SetDestinations(component);
			}
		}

		#endregion

		#region public Component GetComponentById(int componentId, bool getDeleted = false)

		/// <summary> 
		/// Полная загрузка объекта и его связанных данных
		/// </summary>
		/// <param name="componentId"></param>
		/// <param name="getDeleted">Загружать удаленные элементы</param>
		public Entities.General.Accessory.Component GetComponentById(int componentId, bool getDeleted = false)
		{
			var component = _loader.GetObject<Entities.General.Accessory.Component>(componentId, true, getDeleted, true);

			if (component == null)
				return null;

			component.Received = _loader.GetObject<Specialist>(component.ReceivedId);

			var types = new[] {SmartCoreType.Component.ItemId, SmartCoreType.ComponentDirective.ItemId};
			//Загрузка документов
			var documents = _newLoader.GetObjectListAll<DocumentDTO, Document>(new Filter[]
			{
				new Filter("ParentTypeId", types),
				new Filter("ParentID", componentId),
			} , true);

			if (documents.Count > 0)
			{
				var crs = _casEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
				var shipping = _casEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;

				var docShipping = documents.FirstOrDefault(d => d.ParentId == component.ItemId && d.ParentTypeId == SmartCoreType.Component.ItemId && d.DocumentSubType.ItemId == shipping.ItemId);
				if (docShipping != null)
				{
					component.Document = docShipping;
					component.Document.Parent = component;
				}

				var docCrs = documents.FirstOrDefault(d => d.ParentId == component.ItemId && d.ParentTypeId == SmartCoreType.Component.ItemId && d.DocumentSubType.ItemId == crs.ItemId);
				if (docCrs != null)
				{
					component.DocumentCRS = docCrs;
					component.DocumentCRS.Parent = component;
				}

				if (component.ComponentDirectives.Count > 0)
				{

					foreach (var directive in component.ComponentDirectives)
					{
						var docCd =documents.FirstOrDefault(d => d.ParentId == directive.ItemId && d.ParentTypeId == SmartCoreType.ComponentDirective.ItemId);
						if (docCd != null)
						{
							directive.Document = docCd;
							directive.Document.Parent = directive;
						}
					}
				}
			}
			

			if (component.ComponentDirectives.Count > 0)
			{
				var directivesIds = component.ComponentDirectives.Select(d => d.ItemId);
				var itemsRelations = _itemsRelationsDataAccess.GetRelations(directivesIds, SmartCoreType.ComponentDirective.ItemId);

				if (itemsRelations.Count > 0)
				{
					foreach (var componentDirective in component.ComponentDirectives)
						componentDirective.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == componentDirective.ItemId || i.SecondItemId == componentDirective.ItemId));//TODO:(Evgenii Babak)не использовать Where 
				}
			}

			// Примечание - загрузка всех связанных данных для агрегата должна идти вместе с заполнением Parent
			_newLoader.SetDestinations(component);

			return component;
		}

		#endregion

		public IList<Entities.General.Accessory.Component> GetComponentByIds(IList<int> componentIds)
		{
			var components = new ComponentCollection();
			components.AddRange(_newLoader.GetObjectList<ComponentDTO, Entities.General.Accessory.Component>(new List<Filter>()
			{
				new Filter("IsBaseComponent", false),
				new Filter("ItemId",componentIds)
			}));
			LoadRelatedObjectds(components.ToArray());

			return components.ToList();
		}

		#region public BaseComponent GetFullBaseComponent(Int32 baseComponentId)

		/// <summary>
		/// Полностью загружает базовый агрегат по его id
		/// </summary>
		/// <param name="baseComponentId"></param>
		/// <returns></returns>
		public BaseComponent GetFullBaseComponent(int baseComponentId)
		{
			//// Загружаем агрегат 
			var baseComponent = _newLoader.GetObject<BaseComponentDTO, BaseComponent>(new List<Filter>()
			{
				new Filter("IsBaseComponent", true),
				new Filter("ItemId",baseComponentId)
			}, true);

			// Выставляем обратные ссылки
			_newLoader.SetDestinations(baseComponent);

			// Возвращаем результат
			return baseComponent;
		}


		#endregion

		#region public BaseComponent GetBaseComponentById(int baseComponentId)

		public BaseComponent GetBaseComponentById(int baseComponentId)
		{
			return getBaseComponentById(baseComponentId);
		}

		#endregion

		private BaseComponent getBaseComponentById(int baseComponentId)
		{
			return _casEnvironment.BaseComponents.GetItemById(baseComponentId);
		}

		#region public void LoadBaseComponentsDirectives(Aircraft aircraft = null)

		/// <summary>
		/// Загружает работы для всех базовых агрегатов в ядре или пренадлежащих заданному ВС и связвает их
		/// </summary>
		/// <param name="aircraft">Заданное ВС. при передаче null загружает директивы для всех базовых агрегатов в ядре</param>
		public void LoadBaseComponentsDirectives(Aircraft aircraft = null)
		{
			var baseComponents = new List<BaseComponent>(aircraft != null ? getAicraftBaseComponents(aircraft.ItemId) : _casEnvironment.BaseComponents.ToArray());
			foreach (var baseComponent in baseComponents)
				baseComponent.ComponentDirectives.Clear();
			var ids = baseComponents.Select(bd => bd.ItemId).ToArray();

			var componentDirectives =
				_newLoader.GetObjectList<ComponentDirectiveDTO,ComponentDirective>(new Filter("ComponentId", ids), true);

			foreach (var componentDirective in componentDirectives)
			{
				var baseComponent = _casEnvironment.BaseComponents.GetItemById(componentDirective.ComponentId);

				if(baseComponent == null) continue;
				baseComponent.ComponentDirectives.Add(componentDirective);
				componentDirective.ParentComponent = baseComponent;
			}

			//Очистка коллекции директив, полученной в начале запроса
			//для предотвращения утечек памяти
			componentDirectives.Clear();
		}

		#endregion

		#region public void LoadBaseComponentsActualStateRecords()
		/// <summary> 
		/// Загружает все актуальные состояния для базовых агрегатов и разносит эти записи на все базовые агрегаты
		/// </summary>
		public void LoadBaseComponentsActualStateRecords()
		{
			var ids = _newLoader.GetSelectColumnOnly<BaseComponentDTO>(new []{ new Filter("IsBaseComponent", true) }, "ItemId");
			var actuals = _newLoader.GetObjectListAll<ActualStateRecordDTO,ActualStateRecord>(new Filter("ComponentId", ids));

			foreach (var t in actuals)
			{
				var baseComponent = _casEnvironment.BaseComponents.GetItemById(t.ComponentId);
				if (baseComponent != null)
				{
					// Добавляет актуальное состояние в коллекцию актуальных состояний базового агрегата
					if (!baseComponent.ActualStateRecords.Contains(t))
					{
						baseComponent.ActualStateRecords.Add(t);
						t.ParentComponent = baseComponent;
					}	
				}
			}
		}

		#endregion

		#region public void LoadBaseComponentsTransferRecords()

		/// <summary>
		/// Загружает все записи о перемещении базовых агргетов и разносит эти записи по базовым агрегатам
		/// </summary>
		public void LoadBaseComponentsTransferRecords()
		{
			//Строка запроса, выдающая идентификаторы базовых деталей
			var ids = _newLoader.GetSelectColumnOnly<BaseComponentDTO>( new []{ new Filter("IsBaseComponent", true) }, "ItemId");
			var transfers = _newLoader.GetObjectListAll<TransferRecordDTO,TransferRecord>(new Filter("ParentID", ids));

			foreach (var t in transfers)
			{
				var baseComponent = _casEnvironment.BaseComponents.GetItemById(t.ParentId);
				if (baseComponent != null)
				{
					// Добавляем записи о перемещении агрегата в коллекцию актуальных состояний базового агрегата
					baseComponent.TransferRecords.Add(t);
					t.ParentComponent = baseComponent;
				}
			}
		}

		#endregion

		#region public BaseComponent[] GetAicraftBaseComponents(int aircraftId, int? baseComponenTypeId = null)

		public BaseComponent[] GetAicraftBaseComponents(int aircraftId, int? baseComponentTypeId = null)
		{
			if(baseComponentTypeId == null)
				return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId).ToArray();

			return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId 
															   && candidate.BaseComponentType.ItemId == baseComponentTypeId).ToArray();
		}

		#endregion

		public void ReloadActualStateRecordForBaseComponents(int aircraftId)
		{
			var bs = _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId).ToList();
			var ids = bs.Select(i => i.ItemId);
			var actuals = _newLoader.GetObjectListAll<ActualStateRecordDTO, ActualStateRecord>(new Filter("ComponentId", ids));

			foreach (var component in bs)
			{
				component.ActualStateRecords.Clear();
				component.ActualStateRecords.AddRange(actuals.Where(i => i.ComponentId == component.ItemId));
			}
		}

		#region public BaseComponent[] GetAicraftBaseComponents(int aircraftId, IEnumerable<int> baseComponentTypeIds)

		public BaseComponent[] GetAicraftBaseComponents(int aircraftId, IEnumerable<int> baseComponentTypeIds)
		{
			if(baseComponentTypeIds == null && baseComponentTypeIds.Any())
				return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId).ToArray();

			return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId
															   && baseComponentTypeIds.Contains(candidate.BaseComponentTypeId)).ToArray();
		}

		#endregion

		#region public BaseComponent[] GetStoreBaseComponents(int storeId, int? baseComponentTypeId = null)
		/// <summary>
		/// Возвращает все базовые агрегаты указанного типа, находящиеся на складе. Frame скада в список не попадет
		/// </summary>
		/// <param name="storeId"></param>
		/// <param name="baseComponentTypeId"></param>
		/// <returns></returns>
		public BaseComponent[] GetStoreBaseComponents(int storeId, int? baseComponentTypeId = null)
		{
			if(baseComponentTypeId == null)
				return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentStoreId == storeId).ToArray();

			return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentStoreId == storeId && candidate.BaseComponentType.ItemId == baseComponentTypeId).ToArray();
		}
		#endregion

		#region public BaseComponent[] GetOperatorBaseComponents(int operatorId, int? baseComponentTypeId = null)

		/// <summary>
		/// Возвращает все базовые агрегаты указанного типа, находящиеся на операторе(для назамного оберудования).
		/// </summary>
		/// <param name="operatorId"></param>
		/// <param name="baseComponentTypeId"></param>
		/// <returns></returns>
		public BaseComponent[] GetOperatorBaseComponents(int operatorId, int? baseComponentTypeId = null)
		{
			// Пробегаем по всем базовым агрегатам и отбираем нужные
			//
			return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentOperator.ItemId == operatorId 
																&& candidate.BaseComponentType != BaseComponentType.Frame 
																&& candidate.BaseComponentType.ItemId == baseComponentTypeId).ToArray();
		}
		#endregion

		#region public BaseComponent[] GetAircraftLandingGears(int aircraftId)
		/// <summary> 
		/// Возвращает шасси заданного воздушного судна - метод не делает запроса к базе данных
		/// </summary>
		/// <param name="aircraftId"></param>
		/// <returns></returns>
		public BaseComponent[] GetAircraftLandingGears(int aircraftId)
		{
			return getAicraftBaseComponents(aircraftId, BaseComponentType.LandingGear.ItemId);
		}
		#endregion

		#region public BaseComponent[] GetAircraftEngines(int aircraftId)
		/// <summary>
		/// Возвращает двигатели воздушного судна - метод не делает запрос к базе данных
		/// </summary>
		/// <param name="aircraftId"></param>
		/// <returns></returns>
		public BaseComponent[] GetAircraftEngines(int aircraftId)
		{
			return getAicraftBaseComponents(aircraftId, BaseComponentType.Engine.ItemId);
		}
		#endregion

		#region public BaseComponent GetAircraftFrame(int aircraftId)
		/// <summary>
		/// Возвращает Frame для заданного воздушного судна
		/// </summary>
		/// <param name="aircraftId"></param>
		/// <returns></returns>
		public BaseComponent GetAircraftFrame(int aircraftId)
		{
			//TODO:(Evgenii Babak) нужно ввести ObjectNotFoundExeption
			return _casEnvironment.BaseComponents.SingleOrDefault(bd => bd.ParentAircraftId == aircraftId && !bd.IsDeleted && bd.BaseComponentTypeId == BaseComponentType.Frame.ItemId);
		}
		#endregion

		#region public BaseComponent GetAircraftApu(int aircraftId)
		/// <summary>
		/// Возвращает ВСУ для заданного воздушного судна
		/// </summary>
		/// <param name="aircraftId"></param>
		/// <returns></returns>
		public BaseComponent GetAircraftApu(int aircraftId)
		{
			var apus = getAicraftBaseComponents(aircraftId, BaseComponentType.Apu.ItemId);
			// на воздушном судне не может быть несколько Apu
			// Apu можно снять с ВС 
			if (apus.Length > 1) // более одного Apu
				throw new Exception("1530 Aircraft can not contain more than one APU");
			
			if (apus.Length == 0) return null;
			return apus[0];
		}
		#endregion

		#region private BaseComponent[] getAicraftBaseComponents(int aircraftId, int? baseComponentTypeId = null)

		private BaseComponent[] getAicraftBaseComponents(int aircraftId, int? baseComponentTypeId = null)
		{
			if (baseComponentTypeId == null)
				return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId).ToArray();

			return _casEnvironment.BaseComponents.Where(candidate => candidate.ParentAircraftId == aircraftId
															   && candidate.BaseComponentType.ItemId == baseComponentTypeId).ToArray();
		}

		#endregion

		#region private void ConnectComponentDirectivesWithComponents(ComponentCollection components, IEnumerable<ComponentDirective> directives)

		/// <summary>
		/// Связываем агрегаты с их работами
		/// </summary>
		/// <param name="components"></param>
		/// <param name="directives"></param>
		private void ConnectComponentDirectivesWithComponents(IEnumerable<Entities.General.Accessory.Component> components, IEnumerable<ComponentDirective> directives)
		{
			foreach (var directive in directives)
			{
				var component = components.GetItemById(directive.ComponentId);
				if (component == null)
					continue;

				component.ComponentDirectives.Add(directive);
				directive.ParentComponent = component;
				// Делаем обратную ссылку на саму директиву
				if (directive.LastPerformance != null) directive.LastPerformance.Parent = directive;
			}
		}

		#endregion

		#region private void SetFromAndDestination(List<TransferRecord> transfers)
		/// <summary>
		/// Возвращает все записи о перемешении агрегатов на переданное ВС
		/// </summary>
		/// <returns></returns>
		private void SetFromAndDestination(IEnumerable<TransferRecord> transfers)
		{
			if(!transfers.Any())
				return;

			var suppliersIds = new List<int>();
			suppliersIds.AddRange(transfers.Where(t => t.DestinationObjectType == SmartCoreType.Supplier).Select(t => t.DestinationObjectId));
			suppliersIds.AddRange(transfers.Select(t => t.FromSupplierId));
			var suppliers = _newLoader.GetObjectListAll<SupplierDTO, Supplier>(new Filter("ItemId", suppliersIds));

			var specialistIds = new List<int>();
			specialistIds.AddRange(transfers.Where(t => t.DestinationObjectType == SmartCoreType.Employee).Select(t => t.DestinationObjectId));
			specialistIds.AddRange(transfers.Select(t => t.FromSpecialistId));
			var specialists = _newLoader.GetObjectListAll<SpecialistDTO,Specialist>(new Filter("ItemId", specialistIds));


			foreach (var transfer in transfers)
			{
				#region Откуда перемещен

				if (transfer.FromAircraftId > 0)
				{
					var a = _aircraftsCore.GetAircraftById(transfer.FromAircraftId) ??
					new Aircraft
					{
						ItemId = transfer.FromAircraftId,
						IsDeleted = true,
						RegistrationNumber = "Can't Find Aircraft with id = " + transfer.FromAircraftId
					};
					transfer.FromAircraft = a;
				}

				if (transfer.FromBaseComponentId > 0)
				{
					var bd = _casEnvironment.BaseComponents.GetItemById(transfer.FromBaseComponentId) ??
					new BaseComponent
					{
						ItemId = transfer.FromBaseComponentId,
						IsDeleted = true,
						Description = "Can't Find Base Component with id = " + transfer.FromBaseComponentId,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};

					transfer.FromBaseComponent = bd;
				}

				if (transfer.FromStoreId > 0)
				{
					var store = _casEnvironment.Stores.GetItemById(transfer.FromStoreId) ??
					new Store
					{
						ItemId = transfer.FromStoreId,
						IsDeleted = true,
						Name = "Can't Find Store with id = " + transfer.FromStoreId,
					};

					transfer.FromStore = store;
				}

				if (transfer.FromSupplierId > 0)
				{
					var supplier = suppliers.FirstOrDefault(s => s.ItemId == transfer.FromSupplierId) ??
					new Supplier
					{
						ItemId = transfer.FromSupplierId,
						IsDeleted = true,
						Name = "Can't Find Supplier with id = " + transfer.FromSupplierId
					};

					transfer.FromSupplier = supplier;
				}

				if (transfer.FromSpecialistId > 0)
				{
					var specialist = specialists.FirstOrDefault(s => s.ItemId == transfer.FromSpecialistId) ??
					               new Specialist
					               {
						               ItemId = transfer.FromSpecialistId,
						               IsDeleted = true,
						               FirstName = "Can't Find Specialist with id = " + transfer.FromSpecialistId
								   };

					transfer.FromSpecialist = specialist;
				}

				#endregion

				#region Куда перемещен
				if (transfer.DestinationObjectType == SmartCoreType.Store)
				{
					var store = _casEnvironment.Stores.GetItemById(transfer.DestinationObjectId) ??
					new Store
					{
						ItemId = transfer.DestinationObjectId,
						IsDeleted = true,
						Name = "Can't Find Store with id = " + transfer.DestinationObjectId,
					};

					transfer.DestinationObject = store;
				}

				if (transfer.DestinationObjectType == SmartCoreType.BaseComponent)
				{
					var bd = _casEnvironment.BaseComponents.GetItemById(transfer.DestinationObjectId) ??
					new BaseComponent
					{
						ItemId = transfer.DestinationObjectId,
						IsDeleted = true,
						Description = "Can't Find Base Component with id = " + transfer.DestinationObjectId,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};

					transfer.DestinationObject = bd;
				}
				if (transfer.DestinationObjectType == SmartCoreType.Aircraft)
				{
					var a = _aircraftsCore.GetAircraftById(transfer.DestinationObjectId) ??
					new Aircraft
					{
						ItemId = transfer.DestinationObjectId,
						IsDeleted = true,
						RegistrationNumber = "Can't Find Aircraft with id = " + transfer.DestinationObjectId
					};
					transfer.DestinationObject = a;
				}

				if (transfer.DestinationObjectType == SmartCoreType.Supplier)
				{
					var supplier = suppliers.FirstOrDefault(s => s.ItemId == transfer.DestinationObjectId) ??
					               new Supplier
					               {
						               ItemId = transfer.DestinationObjectId,
						               IsDeleted = true,
						               Name = "Can't Find Supplier with id = " + transfer.DestinationObjectId
								   };

					transfer.DestinationObject = supplier;
				}

				if (transfer.DestinationObjectType == SmartCoreType.Employee)
				{
					var specialist = specialists.FirstOrDefault(s => s.ItemId == transfer.DestinationObjectId) ??
					                 new Specialist
					                 {
						                 ItemId = transfer.FromSpecialistId,
						                 IsDeleted = true,
						                 FirstName = "Can't Find Specialist with id = " + transfer.DestinationObjectId
									 };

					transfer.DestinationObject = specialist;
				}


				#endregion
			}
		}

		#endregion

		#region private void ConnectTransfersWithComponents(ComponentCollection components, List<TransferRecord> transfers)

		/// <summary>
		/// Связываем агрегаты с информацией об их перемещениях
		/// </summary>
		/// <param name="components"></param>
		/// <param name="transfers"></param>
		private void ConnectTransfersWithComponents(IEnumerable<Entities.General.Accessory.Component> components, List<TransferRecord> transfers)
		{
			foreach (TransferRecord transfer in transfers)
			{
				var component = components.GetItemById(transfer.ParentId);
				if (component != null)
				{
					component.TransferRecords.Add(transfer);
					transfer.ParentComponent = component;
				}
			}
		}

		#endregion

		#region private void ConnectActualsWithComponents(DetailCollection details, IEnumerable<ActualStateRecord> actuals)

		/// <summary>
		/// Связываем все агрегаты с их актуальными состояниями
		/// </summary>
		/// <param name="components"></param>
		/// <param name="actuals"></param>
		private void ConnectActualsWithComponents(IEnumerable<Entities.General.Accessory.Component> components, IEnumerable<ActualStateRecord> actuals)
		{
			foreach (var actual in actuals)
			{
				var component = components.GetItemById(actual.ComponentId);
				if (component != null)
				{
					if(!component.ActualStateRecords.Contains(actual))
						component.ActualStateRecords.Add(actual);
					actual.ParentComponent = component;
				}
			}
		}

		#endregion
	}
}