using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Maintenance
{
	public class MaintenanceCore : IMaintenanceCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly INewLoader _newLoader;
		private readonly INewKeeper _newKeeper;
		private readonly IItemsRelationsDataAccess _itemsRelationsDataAccess;
		private readonly IAircraftsCore _aircraftsCore;

		public MaintenanceCore(ICasEnvironment casEnvironment, INewLoader newLoader,
								INewKeeper newKeeper, IItemsRelationsDataAccess itemsRelationsDataAccess, IAircraftsCore aircraftsCore)
		{
			_casEnvironment = casEnvironment;
			_newLoader = newLoader;
			_newKeeper = newKeeper;
			_itemsRelationsDataAccess = itemsRelationsDataAccess;
			_aircraftsCore = aircraftsCore;
		}

		#region public ICommonCollection<MaintenanceCheck> GetMaintenanceCheck(params object[] parametres)

		/// <summary>
		/// Возвращает все директивы определенного типа для самолета или null вслучае неверных параметров
		/// Первый параметр должен быть Aircraft или BaseComponent
		/// </summary>
		/// <returns></returns>
		public ICommonCollection<MaintenanceCheck> GetMaintenanceCheck(params object[] parametres)
		{
			if (parametres == null || parametres.Length == 0 || parametres[0] == null)
				return null;
			if (parametres[0] is Aircraft)
				return new CommonCollection<MaintenanceCheck>(GetMaintenanceCheck((Aircraft)parametres[0]));
			throw new ArgumentException("must be Aircraft or BaseComponent or Store or List<BaseComponent>", "parametres");
		}

		#endregion

		#region public List<MaintenanceCheck> GetMaintenanceCheck(Aircraft aircraft, bool? schedule = null)

		/// <summary>
		/// Возвращает список всех чеков для определенного борта
		/// </summary>
		/// <param name="aircraft">Родительский самолет</param>
		/// <param name="schedule">Тип программы (Schedule/Store) (По умолчанию null-загружаются все чеки для самолета)</param>
		/// <returns></returns>
		public List<MaintenanceCheck> GetMaintenanceCheck(Aircraft aircraft, bool? schedule = null)
		{
			var list = new List<MaintenanceCheck>(_newLoader.GetObjectListAll<MaintenanceCheckDTO, MaintenanceCheck>(new List<Filter>()
			{
				new Filter("ParentAircraft", aircraft.ItemId),
				new Filter("Schedule", schedule)
			}, true));

			if (list.Count == 0)
				return list;

			foreach (var item in list)
			{
				item.ParentAircraft = aircraft;
			}

			return list;
		}

		#endregion

		public IList<MaintenanceCheck> GetMaintenanceCheckList(IList<int> maintenanceCheckIds, bool getDeleted = false)
		{

			var maintenanceChecks = _newLoader.GetObjectListAll<MaintenanceCheckDTO, MaintenanceCheck>(new Filter("ItemId", maintenanceCheckIds),true, getDeleted);

			foreach (var maintenanceCheck in maintenanceChecks)
				maintenanceCheck.ParentAircraft = _aircraftsCore.GetAircraftById(maintenanceCheck.ParentAircraftId);

			return maintenanceChecks;
		}

		#region public ICommonCollection<MaintenanceDirective> GetMaintenanceDirectives(params object[] parametres)

		/// <summary>
		/// Возвращает все директивы определенного типа для самолета или null вслучае неверных параметров
		/// Первый параметр должен быть Aircraft или BaseComponent
		/// </summary>
		/// <returns></returns>
		public ICommonCollection<MaintenanceDirective> GetMaintenanceDirectives(params object[] parametres)
		{
			if (parametres == null || parametres.Length == 0 || parametres[0] == null)
				return null;
			BaseEntityObject param1;
			if (parametres[0] is BaseEntityObject)
				param1 = (BaseEntityObject)parametres[0];
			else throw new ArgumentException("must be Aircraft or BaseComponent", "parametres");

			IEnumerable<ICommonFilter> param2 = null;
			if (parametres.Length == 2 && parametres[1] is IEnumerable<ICommonFilter>)
				param2 = parametres[1] as IEnumerable<ICommonFilter>;

			return new CommonCollection<MaintenanceDirective>(GetMaintenanceDirectives(param1, param2));
		}

		#endregion

		#region public List<MaintenanceDirective> GetMaintenanceDirectives(BaseEntityObject parent, IEnumerable<ICommonFilter> filters = null)
		/// <summary>
		/// Возвращает все директивы базового агрегата, или самолета
		/// </summary>
		/// <returns></returns>
		public List<MaintenanceDirective> GetMaintenanceDirectives(BaseEntityObject parent, IEnumerable<ICommonFilter> filters = null)
		{
			if (parent == null || (!(parent is Aircraft) && !(parent is BaseComponent)))
				throw new ArgumentNullException();

			var qrs = parent is Aircraft
									? MaintenanceDirectiveQueries.GetAircraftDirectivesSelectQuery(((Aircraft)parent).ItemId, filters, true)
									: MaintenanceDirectiveQueries.GetSelectQuery((BaseComponent)parent, filters, true);
			List<ExecutionResultArgs> resultArgses;
			var ds = _casEnvironment.Execute(qrs, out resultArgses);
			if (resultArgses.Count(r => r.Exception != null) > 0)
				throw resultArgses.First(r => r.Exception != null).Exception;
			var directives = BaseQueries.GetObjectList<MaintenanceDirective>(ds, true);

			if (directives.Count == 0)
				return directives;

			var directiveIds = directives.Select(d => d.ItemId).ToList();

			//Загрузка задач по компонентам привязанных к задачам из MPD
			//Компонент, для которого привязаны задачи должен находится на том ВС что и задачи MPD
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directiveIds, SmartCoreType.MaintenanceDirective.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var mpd in directives)
				{
					mpd.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == mpd.ItemId || i.SecondItemId == mpd.ItemId));
				}
			}
			
			return directives;
		}

		#endregion

		#region public MaintenanceDirective GetMaintenanceDirective(Int32 itemId, Aircraft parentAircraft = null)
		/// <summary>
		/// Возвращает все директивы базового агрегата, или самолета
		/// </summary>
		/// <returns></returns>
		public MaintenanceDirective GetMaintenanceDirective(Int32 itemId, int? parentAircraftId = null)
		{
			List<DbQuery> qrs;
			if (parentAircraftId != null)
			{
				//Если задано родительское ВС, то директиву с заданный ID нужно искать среди директив ВС
				qrs =
				MaintenanceDirectiveQueries.GetAircraftDirectivesSelectQuery
					(parentAircraftId.Value,
					 new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, itemId) },
					 true,
					 true);
			}
			else
			{
				qrs =
				BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>
					(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, itemId) },
					 true,
					 true);
			}
			List<ExecutionResultArgs> resultArgses;
			var ds = _casEnvironment.Execute(qrs, out resultArgses);
			if (resultArgses.Count(r => r.Exception != null) > 0)
				throw resultArgses.First(r => r.Exception != null).Exception;
			var directive = BaseQueries.GetObjectList<MaintenanceDirective>(ds, true).FirstOrDefault();

			if (directive == null)
				return null;

			var itemRelation = _itemsRelationsDataAccess.GetRelations(directive.ItemId, directive.SmartCoreObjectType.ItemId);
			directive.ItemRelations.AddRange(itemRelation);

			return directive;
		}

		#endregion


		#region public IList<MaintenanceDirective> GetMaintenanceDirectiveList(IList<int> maintenanceDirectiveIds, int? parentAircraftId = null)
		/// <summary>
		/// Возвращает все директивы базового агрегата, или самолета
		/// </summary>
		/// <returns></returns>
		public IList<MaintenanceDirective> GetMaintenanceDirectiveList(IList<int> maintenanceDirectiveIds, int? parentAircraftId = null)
		{
			var directives = new List<MaintenanceDirective>();

			if (maintenanceDirectiveIds.Count == 0)
				return directives;

			List<DbQuery> qrs;
			if (parentAircraftId != null)
			{
				//Если задано родительское ВС, то директиву с заданный ID нужно искать среди директив ВС
				qrs =
				MaintenanceDirectiveQueries.GetAircraftDirectivesSelectQuery
					(parentAircraftId.Value,
					 new ICommonFilter[]
					 {
						 new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, maintenanceDirectiveIds.ToArray())
					 }, true, true);
			}
			else
			{
				qrs =
				BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>
					(new ICommonFilter[]
					{
						new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, maintenanceDirectiveIds.ToArray())
					}, true, true);
			}
			List<ExecutionResultArgs> resultArgses;
			var ds = _casEnvironment.Execute(qrs, out resultArgses);
			if (resultArgses.Count(r => r.Exception != null) > 0)
				throw resultArgses.First(r => r.Exception != null).Exception;
			directives.AddRange(BaseQueries.GetObjectList<MaintenanceDirective>(ds, true));

			if (directives.Count == 0)
				return directives;

			var itemsRelations = _itemsRelationsDataAccess.GetRelations(maintenanceDirectiveIds, SmartCoreType.MaintenanceDirective.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var directive in directives)
					directive.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == directive.ItemId || i.SecondItemId == directive.ItemId));
			}

			return directives;
		}

		#endregion

		#region public void AddMaintenanceCheck(MaintenanceCheck check, Aircraft aircraft)
		/// <summary>
		/// Добавляет чек обслуживания на воздушное судно
		/// </summary>
		/// <param name="check"></param>
		/// <param name="aircraft"></param>
		public void AddMaintenanceCheck(MaintenanceCheck check, Aircraft aircraft)
		{
			if (aircraft.ItemId <= 0) throw new Exception("0947: Can not save check to not existing aircraft");

			check.ParentAircraft = aircraft;
			check.ParentAircraftId = aircraft.ItemId;
			// Сохраняем базовый агрегат
			_newKeeper.Save(check);
		}
		#endregion

		#region public void RegisterMaintenanceProgramChangeRecord(Aircraft aircraft, MaintenanceProgramChangeRecord maintenanceProgramChangeRecord)
		/// <summary>
		/// Добавляет запись о смене программы обслуживания
		/// </summary>
		/// <param name="aircraft">ВС, на которое добавляется запись</param>
		/// <param name="maintenanceProgramChangeRecord">Запись о смене обслуживания</param>
		public void RegisterMaintenanceProgramChangeRecord(Aircraft aircraft, MaintenanceProgramChangeRecord maintenanceProgramChangeRecord)
		{
			// Проверка на возможность добавления записи о смене программы обслуживания
			if (aircraft.ItemId <= 0) throw new Exception("1009: Can not register actual state for not existing aircraft");
			if (aircraft == null) throw new Exception("1610: Can not register actual state for not existing aircraft");
			// Если на данную дату уже существует запись о смене программы обслуживания - 
			// мы должны изменить уже существующую запись вместо добавления еще одной записи 
			// на одну дату - последствия не предсказуемы

			var existing = aircraft.MaintenanceProgramChangeRecords[maintenanceProgramChangeRecord.RecordDate.Date];
			if (existing != null)
			{
				// запись на указанную дату существует
				// а поэтому изменяем ее данные и сохраняем
				existing.ParentAircraftId = aircraft.ItemId;
				existing.OnLifelength = new Lifelength(maintenanceProgramChangeRecord.OnLifelength); // изменяем актуальные данные
				existing.Remarks = maintenanceProgramChangeRecord.Remarks; // перебиваем комментарии
				_newKeeper.Save(existing);
			}
			else
			{
				maintenanceProgramChangeRecord.ParentAircraftId = aircraft.ItemId; // дополняем необходимые данные
				_newKeeper.Save(maintenanceProgramChangeRecord); // добавляем в базу данных
				aircraft.MaintenanceProgramChangeRecords.Add(maintenanceProgramChangeRecord); // дабавляем в коллекцию
			}
		}
		#endregion

		#region public void Delete(Cas3MaintenanceCheckRecord record)
		/// <summary>
		/// Удаляет запись о выполнении директивы
		/// </summary>
		/// <param name="record"></param>
		public void Delete(MaintenanceCheckRecord record)
		{
			record.IsDeleted = true;
			_newKeeper.Save(record);

			// нужно обнулить математический аппарат объекта, которому принадлежит запись о выполнении
			// а также удалить выполнение директивы из коллекции выполнений директивы
			if (record.ParentCheck != null && record.ParentCheck.PerformanceRecords != null)
				record.ParentCheck.PerformanceRecords.Remove(record);

			var ddr = _casEnvironment.NewLoader.GetObjectListAll<DirectiveRecordDTO, DirectiveRecord>(new Filter("MaintenanceCheckRecordId", record.ItemId));

			if (ddr.Count <= 0) return;

			foreach (var directiveRecord in ddr)
				_newKeeper.Delete(directiveRecord, true, false);
		}
		#endregion
	}
}