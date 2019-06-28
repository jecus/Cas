using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CAS.UI.Helpers;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.DtoHelper;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Queries;

namespace SmartCore.Entities.NewLoader
{
	public class NewLoader : INewLoader
	{
		#region Fields

		private readonly CasEnvironment _casEnvironment;
		private readonly ApiProvider _provider;

		#endregion

		#region Constructor

		public NewLoader(CasEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
			_provider = _casEnvironment.ApiProvider;
		}

		#endregion

		#region Async

		public async Task<TOut> GetObjectByIdAsync<T, TOut>(int id, bool loadChild = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var dto = await repo.GetObjectByIdAsync(id, loadChild);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);

			return InvokeConverter<T, TOut>(dto, method);
		}

		public async Task<TOut> GetObjectAsync<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var dto = await repo.GetObjectAsync(filters, loadChild, getDeleted, getAll);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			return InvokeConverter<T, TOut>(dto, method);
		}

		public async Task<TOut> GetObjectAsync<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var dto = await repo.GetObjectAsync(new[] { filter }, loadChild, getDeleted, getAll);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			return InvokeConverter<T, TOut>(dto, method);
		}

		public async Task<List<TOut>> GetObjectListAsync<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var res = new List<TOut>();
			var dtos = await repo.GetObjectListAsync(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public async Task<List<TOut>> GetObjectListAsync<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");
			var res = new List<TOut>();
			var dtos = await repo.GetObjectListAsync(new[] { filter }, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public async Task<List<TOut>> GetObjectListAllAsync<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var res = new List<TOut>();
			var dtos = await repo.GetObjectListAllAsync(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public async Task<List<TOut>> GetObjectListAllAsync<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var res = new List<TOut>();
			var dtos = await repo.GetObjectListAllAsync(filter != null ? new[] { filter } : null, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}


		#endregion

		public IList<TU> GetSelectColumnOnly<T, TU>(Expression<Func<T, bool>> exp, Expression<Func<T, TU>> columns) where T : BaseEntity where TU : new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<T>();

			return repo.GetSelectColumnOnly(exp, columns);
		}

		public IList<int> GetSelectColumnOnly<T>(IEnumerable<Filter> filters, string selectProperty) where T : BaseEntity
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			return _provider.GetSelectColumnOnly<T>(filters, selectProperty);
		}

		public TOut GetObjectById<T, TOut>(int id, bool loadChild = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var dto = _provider.GetObjectById<T>(id, loadChild);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);

			return InvokeConverter<T,TOut>(dto, method);
		}

		public TOut GetObject<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var dto = _provider.GetObject<T>(filters, loadChild, getDeleted, getAll);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			return InvokeConverter<T, TOut>(dto, method);
		}

		public TOut GetObject<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObject<T, TOut>(new[] {filter}, loadChild, getDeleted, getAll);
		}

		public IList<TOut> GetObjectList<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var res = new List<TOut>();
			var dtos = _provider.GetObjectList<T>(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public IList<TOut> GetObjectList<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObjectList<T, TOut>(new[] {filter}, loadChild, getDeleted);
		}

		public IList GetObjectList(Type dtoType, Type blType, bool loadChild = false, bool getDeleted = false)
		{
			var method = typeof(INewLoader).GetMethods().FirstOrDefault(i => i.Name == "GetObjectList")?.MakeGenericMethod(dtoType, blType);

			if (dtoType.Name == "AccessoryDescriptionDTO")
			{
				var filter = new List<Filter>();
				if(blType.Name == "AircraftModel")
					filter.Add(new Filter("ModelingObjectTypeId", 7));
				else if (blType.Name == "ComponentModel")
					filter.Add(new Filter("ModelingObjectTypeId", 5));
				else if (blType.Name == "Product")
					filter.Add(new Filter("ModelingObjectTypeId", -1));

				return (IList)method.Invoke(this, new object[] { filter, loadChild, getDeleted });
			}

			return (IList)method.Invoke(this, new object[] { null, loadChild, getDeleted });
		}

		public IList<TOut> GetObjectListAll<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var res = new List<TOut>();
			var dtos = _provider.GetObjectListAll<T>(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public IList<TOut> GetObjectListAll<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObjectListAll<T, TOut>(new[] {filter}, loadChild, getDeleted);
		}

		public void GetDictionaries()
		{
			_casEnvironment.ClearDictionaries();

			var assembly = Assembly.GetAssembly(typeof(BaseEntityObject));
			var types = assembly.GetTypes()
				.Where(t => t.Namespace != null && t.IsClass && t.Namespace.StartsWith("SmartCore.Entities.Dictionaries"));

			var staticDictionaryType = types.Where(t => t.IsSubclassOf(typeof(StaticDictionary))
															&& t.GetCustomAttributes(typeof(TableAttribute), false).Length > 0).ToList();

			foreach (var type in staticDictionaryType)
			{
				try
				{
					string qr = BaseQueries.GetSelectQueryWithWhere(type, loadChild: true);
					DataSet ds = _casEnvironment.Execute(qr);

					//поиск в типе своиства Items
					PropertyInfo itemsProp = type.GetProperty("Items");
					//поиск у типа конструктора беза параметров
					ConstructorInfo ci = type.GetConstructor(new Type[0]);
					//создание экземпляра статического словаря 
					//(при этом будут созданы все его статические элементы, 
					// которые будут доступны через статическое своиство Items)
					StaticDictionary instance = (StaticDictionary)ci.Invoke(null);
					//Получение элементов статического своиства Items
					IEnumerable staticList = (IEnumerable)itemsProp.GetValue(instance, null);

					BaseQueries.SetFields(staticList, ds);
				}
				catch (Exception)
				{
					continue;
					//throw ex;
				}
			}

			var abstractDictionaryTypes = types.Where(t => t.IsSubclassOf(typeof(AbstractDictionary))
															   && !t.IsAbstract)
													  .ToList();
			//коллекция дл типов, которые не удалось загрузить сразу
			//по причине отсутствия другого словаря в коллекции словарей ядра
			var defferedTypes = new List<Type>();
			foreach (var type in abstractDictionaryTypes)
			{
				try
				{
					var dca = (DictionaryCollectionAttribute)type.GetCustomAttributes(typeof(DictionaryCollectionAttribute), false).FirstOrDefault();
					var bl = (DtoAttribute)type.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();

					var typeDict = dca == null
						? new CommonDictionaryCollection<AbstractDictionary>()
						: dca.GetInstance();

					IEnumerable items = GetObjectList(bl.Type, type, true);
					typeDict.AddRange((IEnumerable<IDictionaryItem>)items);
					_casEnvironment.AddDictionary(type, typeDict);

				}
				catch (KeyNotFoundException)
				{
					defferedTypes.Add(type);
					continue;
				}
				catch (Exception)
				{
					continue;
					//throw ex;
				}
			}

			//Повторная попытка загрузить типы данных, которые не удалось загрузить с первого раза
			foreach (var type in defferedTypes)
			{
				try
				{
					var dca = (DictionaryCollectionAttribute)type.GetCustomAttributes(typeof(DictionaryCollectionAttribute), false).FirstOrDefault();
					var bl = (DtoAttribute)type.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
					var typeDict = dca == null
						? new CommonDictionaryCollection<AbstractDictionary>()
						: dca.GetInstance();
					IEnumerable items = GetObjectList(bl.Type, type, true);
					typeDict.AddRange((IEnumerable<IDictionaryItem>)items);
					_casEnvironment.AddDictionary(type, typeDict);
				}
				catch (Exception)
				{
					continue;
					//throw ex;
				}
			}
		}

		#region public void FirstLoad()

		/// <summary>
		/// Выполняет первую загрузку ядра
		/// </summary>
		public void FirstLoad()
		{
			//Временные коллекции
			_casEnvironment.TempCollections = new Dictionary<string, ICommonCollection>();

			//Загрузка всех словарей
			GetDictionaries();

			// Загрузка всех операторов
			_casEnvironment.Operators = new OperatorCollection(GetObjectList<OperatorDTO, Operator>().ToArray());

			// Загрузка всех воздушных судов 

#if !KAC
			//Загрузка всех транспортный средств
			_casEnvironment.Vehicles = new CommonCollection<Vehicle>(GetObjectListAll<VehicleDTO, Vehicle>());
			//Загрузка всех ангаров
			_casEnvironment.Hangars = new CommonCollection<Hangar>(GetObjectListAll<HangarDTO, Hangar>());
#endif
			// Загрузка всех складов
			_casEnvironment.Stores = new CommonCollection<Store>(GetObjectListAll<StoreDTO, Store>());
			//Загрузка всех лабораторий
#if !KAC
			_casEnvironment.WorkShops = new CommonCollection<WorkShop>(GetObjectListAll<WorkShopDTO, WorkShop>());
#endif
			// Загрузка всех базовых агрегатов
			_casEnvironment.BaseComponents = new BaseComponentCollection(GetObjectListAll<ComponentDTO, BaseComponent>(new Filter("IsBaseComponent", true),true)); //GetBaseDetails();

			// Выставляем ссылки между объектами

			SetParentsToStores();
			SetParentsToBaseComponents();
#if !KAC
			foreach (var store in _casEnvironment.Hangars)
				store.Operator = _casEnvironment.Operators.GetOperatorById(store.OperatorId);
			foreach (var store in _casEnvironment.WorkShops)
				store.Operator = _casEnvironment.Operators.GetOperatorById(store.OperatorId);
#endif
		}

		#endregion


		#region public void SetParentsToStores()

		public void SetParentsToStores()
		{
			foreach (var store in _casEnvironment.Stores)
				store.Operator = _casEnvironment.Operators.GetOperatorById(store.OperatorId);
		}

		#endregion

		#region public void SetParentsToBaseComponents()

		public void SetParentsToBaseComponents()
		{
			foreach (var baseComponent in _casEnvironment.BaseComponents)
				SetDestinations(baseComponent);
		}

		#endregion

		#region public void SetDestinations(BaseComponent baseComponent)

		public void SetDestinations(BaseComponent baseComponent)
		{
			baseComponent.ParentStoreId = 0;
			baseComponent.ParentAircraftId = 0;

			if (baseComponent.TransferRecords.Count == 0)
			{
				// сюда мы попадаем при первой загрузке ядра
				if (baseComponent.LastDestinationObjectType.ItemId == SmartCoreType.Aircraft.ItemId)
					baseComponent.ParentAircraftId = baseComponent.LastDestinationObjectId;
				else if (baseComponent.LastDestinationObjectType.ItemId == SmartCoreType.Store.ItemId)
					baseComponent.ParentStoreId = baseComponent.LastDestinationObjectId;
			}
			else
			{
				// если все связанные данные (в том числе Transfer Records) загружены
				var lastTransferRecord = baseComponent.TransferRecords.GetLast();
				if (lastTransferRecord.DestinationObjectType.ItemId == SmartCoreType.Aircraft.ItemId)
					baseComponent.ParentAircraftId = lastTransferRecord.DestinationObjectId;
				else if (lastTransferRecord.DestinationObjectType.ItemId == SmartCoreType.Store.ItemId)
					baseComponent.ParentStoreId = lastTransferRecord.DestinationObjectId;
			}
			//
			if (baseComponent.ParentAircraftId <= 0 && baseComponent.ParentStoreId <= 0)
				throw new Exception($"1304: Failed to specify parent object to base Component {baseComponent.ItemId}");
		}

		#endregion

		#region public void SetParents(Component component)

		/// <summary>
		/// Выставляет родителей для агрегата
		/// </summary>
		/// <param name="component"></param>
		/// <returns></returns>
		public void SetDestinations(General.Accessory.Component component)
		{
			TransferRecord lastTransfer = component.TransferRecords.GetLast();
			if (lastTransfer == null)
				throw new Exception($"1513: Component {component.ItemId} has no transfer records");
			//
			if (lastTransfer.DestinationObjectType == SmartCoreType.Store)
			{
				var store = _casEnvironment.Stores.GetItemById(lastTransfer.DestinationObjectId);
				if (store == null)
				{
					// перемещение вникуда !
					throw new Exception($"1552: Destination object ID:{lastTransfer.DestinationObjectId} was not found");
				}
				component.ParentStoreId = store.ItemId;
			}
			else if (lastTransfer.DestinationObjectType == SmartCoreType.Operator)
			{
				var op = _casEnvironment.Operators.GetItemById(lastTransfer.DestinationObjectId);
				if (op == null)
				{
					// перемещение вникуда !
					throw new Exception($"1552: Destination object ID:{lastTransfer.DestinationObjectId} was not found");
				}
				component.ParentOperator = op;
			}
			else if (lastTransfer.DestinationObjectType == SmartCoreType.BaseComponent)
			{
				var baseComponent = _casEnvironment.BaseComponents.GetItemById(lastTransfer.DestinationObjectId);//TODO(Evgenii Babak): использовать ComponentCore
				if (baseComponent != null)
				{
					component.ParentBaseComponent = baseComponent;
					if (baseComponent.LastDestinationObjectType == SmartCoreType.Aircraft)
						component.ParentAircraftId = baseComponent.LastDestinationObjectId;
					else if (baseComponent.LastDestinationObjectType == SmartCoreType.Store)
						component.ParentStoreId = baseComponent.LastDestinationObjectId;
				}
			}
			else if (lastTransfer.DestinationObjectType == SmartCoreType.Aircraft)
			{
				component.ParentAircraftId = lastTransfer.DestinationObjectId;
			}
			else if (lastTransfer.DestinationObjectType == SmartCoreType.Supplier)
			{
				component.ParentSupplierId = lastTransfer.DestinationObjectId;
			}
			else if (lastTransfer.DestinationObjectType == SmartCoreType.Employee)
			{
				component.ParentSpecialistId = lastTransfer.DestinationObjectId;
			}
			if (component.ParentStoreId <= 0 && component.ParentAircraftId <= 0 && component.ParentSupplierId <= 0 && component.ParentSpecialistId <= 0 && component.ParentOperator == null)
				throw new Exception("1453: Failed to specify parent object to detail");
		}

		#endregion

		#region public void LoadBaseComponents(Aircraft aircraft)

		public void LoadBaseComponents(Aircraft aircraft)
		{
			if (aircraft == null)
				return;

			//TODO пересмотреть подход!!!!!!!!!!
			var bc = GetObjectListAll<ComponentDTO, BaseComponent>(new Filter("IsBaseComponent", true));
			var baseComponents = bc.Where(i => i.TransferRecords.OrderBy(t => t.TransferDate).Any(q => q.DestinationObjectId == aircraft.ItemId));
			
			foreach (var baseComponent in baseComponents)
				foreach (var directive in baseComponent.ComponentDirectives)
					directive.ParentComponent = baseComponent;

			#region Проверка на еквивалентность базовых агрегатов ВС содержащийхся в ядре

			bool equals = true;
			foreach (var baseComponent in baseComponents)
			{
				var envBaseComponent = _casEnvironment.BaseComponents.GetItemById(baseComponent.ItemId);//TODO(Evgenii Babak): использовать ComponentCore
				if (envBaseComponent != null && envBaseComponent.Equals(baseComponent))
					continue;
				equals = false;
				break;
			}

			//Если коллекции идентичны, то никаких изменений производить не нужно
			if (equals)
				return;

			#endregion

			foreach (var baseComponent in baseComponents)
			{
				_casEnvironment.BaseComponents.RemoveById(baseComponent.ItemId);
				_casEnvironment.BaseComponents.Add(baseComponent);
			}
		}

		#endregion


		#region public BaseItemsCollection<DamageChart> GetDamageChartsByAircraftModel(AircraftModel aircraftModel)

		public IList<DamageChart> GetDamageChartsByAircraftModel(AircraftModel aircraftModel)
		{
			return GetObjectListAll<DamageChartDTO,DamageChart>(new Filter("AircraftModelId", aircraftModel.ItemId),true);
		}
		#endregion

		#region public AttachedFile GetAttachedFileById(Int32 id)

		public AttachedFile GetAttachedFileById(int id)
		{
			AttachedFile attachedFile = null;

			if (id > 0)
				attachedFile = GetObject<AttachedFileDTO, AttachedFile>(new Filter("ItemId", id));

			return attachedFile;
		}

		#endregion

		#region public ICommonCollection<EmployeeSubject> GetEmployeeSubject(params object[] parametres)

		public ICommonCollection<EmployeeSubject> GetEmployeeSubject(params object[] parametres)
		{
			if (parametres[0] is int)
			{
				var type = (int)parametres[0];
				return new CommonCollection<EmployeeSubject>(GetObjectListAll<EmployeeSubjectDTO,EmployeeSubject>(new Filter("LicenceTypeId", type), true));
			}
			throw new ArgumentException("must be EmployeeLicenceType", "parametres");
		}

		#endregion

		#region public ICommonCollection<JobCard> GetJobCard(params object[] parametres)

		public ICommonCollection<JobCard> GetJobCard(params object[] parametres)
		{
			if (parametres == null || parametres.Length == 0 || parametres[0] == null)
				return null;
			if (parametres[0] is BaseEntityObject)
			{
				var a = (BaseEntityObject)parametres[0];
				if (a.ItemId == -1)
					return null;
				return new CommonCollection<JobCard>(GetObjectListAll<JobCardDTO, JobCard>(new List<Filter>()
				{
					new Filter("ParentId",a.ItemId),
					new Filter("ParentTypeId",  a.SmartCoreObjectType.ItemId)
				}, true, true));
			}
			throw new ArgumentException("must be Aircraft or BaseComponent or Store or List<BaseComponent>", "parametres");
		}

		#endregion


		#region private string GetConverterMethodName(Type TOut)

		private string GetConverterMethodName(Type TOut)
		{
			var methodName = "Convert";
			if (TOut.Name.Equals("AircraftModel"))
				methodName = "ConvertToAircraftModel";
			else if (TOut.Name.Equals("ComponentModel"))
				methodName = "ConvertToComponentModel";
			else if (TOut.Name.Equals("Product"))
				methodName = "ConvertToProduct";
			else if (TOut.Name.Equals("BaseComponent"))
				methodName = "ConvertToBaseComponent";
			else if (TOut.Name.Equals("MaintenanceCheckRecord"))
				methodName = "ConvertToMaintenanceCheckRecord";
			else if (TOut.Name.Equals("DeferredItem"))
				methodName = "ConvertToDeffered";
			else if (TOut.Name.Equals("DamageItem"))
				methodName = "ConvertToDamage";

			return methodName;
		}

		#endregion

		#region private MethodInfo GetMethod(Type t, string methodName)

		private MethodInfo GetMethod(Type t, string methodName)
		{
			var method = typeof(GeneralConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);
			if (method == null)
				method = typeof(DictionaryConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);

			if (method == null)
				throw new ArgumentNullException(methodName, $"В конвертере не содержится метод для {nameof(t)}");

			return method;
		}

		#endregion

		#region private TOut InvokeConverter<T, TOut>(T value)

		private TOut InvokeConverter<T, TOut>(T value, MethodInfo method) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			var instance = Activator.CreateInstance(typeof(TOut));
			return method.Invoke(instance, new object[] { value }) as TOut;
		}

		#endregion

	}
}