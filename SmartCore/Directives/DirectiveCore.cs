using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Directives
{
	public class DirectiveCore : IDirectiveCore
	{
		private readonly INewKeeper _newKeeper;
		private readonly INewLoader _newLoader;
		private readonly IKeeper _keeper;
		private readonly ILoader _loader;
		private readonly IItemsRelationsDataAccess _itemsRelationsDataAccess;

		public DirectiveCore(INewKeeper newKeeper, INewLoader newLoader, IKeeper keeper,
							 ILoader loader, IItemsRelationsDataAccess itemsRelationsDataAccess)
		{
			_newKeeper = newKeeper;
			_newLoader = newLoader;
			_keeper = keeper;
			_loader = loader;
			_itemsRelationsDataAccess = itemsRelationsDataAccess;
		}

		#region public DirectiveCollection GetDirectives(params object [] parametres)
		/// <summary>
		/// Возвращает все директивы определенного типа для самолета или null вслучае неверных параметров
		/// Первый параметр должен быть Aircraft или BaseComponent
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDirectives(params object[] parametres)
		{
			if (parametres == null || parametres.Length < 2 || parametres[0] == null)
				return null;
			if (parametres[0] is Aircraft)
				return GetDirectives(null, (Aircraft)parametres[0], null, parametres[1] as DirectiveType);
			if (parametres[0] is AircraftFlight)
				return GetDirectives(null, null, (AircraftFlight)parametres[0], parametres[1] as DirectiveType);
			if (parametres[0] is BaseComponent)
				return GetDirectives((BaseComponent)parametres[0], null, null, parametres[1] as DirectiveType);
			throw new ArgumentException("must be Aircraft or BaseComponent or AircraftFlight", "parametres");
		}

		#endregion

		#region public DirectiveCollection GetDirectives(Aircraft parentAircraft, PrimaryDirectiveType directiveType)
		/// <summary>
		/// Возвращает все директивы определенного типа для самолета
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDirectives(Aircraft parentAircraft, DirectiveType directiveType)
		{
			return GetDirectives(null, parentAircraft, null, directiveType);
		}

		#endregion

		#region public DirectiveCollection GetDirectives(BaseComponent parentBaseComponent, PrimaryDirectiveType directiveType)
		/// <summary>
		/// Возвращает все директивы определенного типа для базового агрегата
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDirectives(BaseComponent parentBaseComponent, DirectiveType directiveType)
		{
			return GetDirectives(parentBaseComponent, null, null, directiveType);
		}

		#endregion

		#region public DirectiveCollection GetDeferredItems(params object [] parametres)
		/// <summary>
		/// Возвращает все директивы базового агрегата, самолета, или задачи созданные в рамках страницы бортжурнала
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDeferredItems(params object[] parametres)
		{
			if (parametres == null || parametres.Length < 1 || parametres[0] == null)
				return null;
			if (parametres[0] is Aircraft)
				return GetDeferredItems(null, (Aircraft)parametres[0]);
			if (parametres[0] is AircraftFlight)
				return GetDeferredItems(null, null, (AircraftFlight)parametres[0]);
			if (parametres[0] is BaseComponent)
				return GetDeferredItems((BaseComponent)parametres[0]);
			throw new ArgumentException("must be Aircraft or BaseComponent or AircraftFlight", "parametres");
		}

		#endregion

		#region public DirectiveCollection GetDeferredItems(BaseComponent parentComponent, Aircraft parentAircraft, PrimaryDirectiveType directiveType)
		/// <summary>
		/// Возвращает все директивы базового агрегата, самолета, или задачи созданные в рамках страницы бортжурнала
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDeferredItems(BaseComponent parentBaseComponent = null,
													 Aircraft parentAircraft = null,
													 AircraftFlight parentFlight = null,
													 IEnumerable<ICommonFilter> filters = null)
		{
			if (parentAircraft == null && parentBaseComponent == null && parentFlight == null && filters == null)
				throw new ArgumentNullException();

			List<DbQuery> qrs;
			if (parentBaseComponent != null)
				qrs = DeferredItemQueries.GetSelectQuery(parentBaseComponent, filters, true);
			else if (parentAircraft != null)
				qrs = DeferredItemQueries.GetSelectQuery(parentAircraft.ItemId, filters, true);
			else if (parentFlight != null)
				qrs = DeferredItemQueries.GetSelectQuery(parentFlight, filters, true);
			else qrs = BaseQueries.GetSelectQueryWithWhereAll<DeferredItem>(filters.ToArray(), true);

			var directives = new DirectiveCollection();
			directives.AddRange(_loader.GetObjectListAll<DeferredItem>(qrs, true).ToArray());

			if (directives.Count == 0)
				return directives;

			var directiveIds = directives.Select(d => d.ItemId).ToList();
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directiveIds, SmartCoreType.Directive.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var directive in directives)
					directive.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == directive.ItemId || i.SecondItemId == directive.ItemId));
			}
			
			return directives;
		}

		#endregion

		#region public DirectiveCollection GetDamageItems(BaseComponent parentComponent, Aircraft parentAircraft, PrimaryDirectiveType directiveType)
		/// <summary>
		/// Возвращает все повреждения базового агрегата, самолета, или задачи созданные в рамках страницы бортжурнала
		/// </summary>
		/// <returns></returns>
		public DirectiveCollection GetDamageItems(BaseComponent parentBaseComponent = null,
												  Aircraft parentAircraft = null,
												  ICommonFilter[] filters = null)
		{
			if (parentAircraft == null && parentBaseComponent == null)
				throw new ArgumentNullException();

			List<DbQuery> qrs;
			if (parentBaseComponent != null)
				qrs = DirectiveQueries.GetDamageItemSelectQuery(parentBaseComponent, filters, true);
			else qrs = DirectiveQueries.GetAircraftDamageItemSelectQuery(parentAircraft.ItemId, filters, true);

			var directives = new DirectiveCollection();
			directives.AddRange(_loader.GetObjectListAll<DamageItem>(qrs, true).ToArray());

			if (directives.Count == 0)
				return directives;

			var directiveIds = directives.Select(d => d.ItemId).ToList();
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directiveIds, SmartCoreType.Directive.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var directive in directives)
					directive.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == directive.ItemId || i.SecondItemId == directive.ItemId));
			}

			return directives;
		}

		#endregion

		#region public Directive GetDirectiveById(Int32 itemID, PrimaryDirectiveType directiveType, bool loadChild = true)

		/// <summary>
		/// Полность загружает директиву делая запрос по заданному ID
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="directiveType"></param>
		/// <param name="loadChild"></param>
		public Directive GetDirectiveById(Int32 itemId, DirectiveType directiveType, bool loadChild = true)
		{
			if (directiveType == null)
				directiveType = DirectiveType.AirworthenessDirectives;

			var qrs = DirectiveQueries.GetSelectQueryById(itemId, directiveType, loadChild: loadChild);

			var directive = _loader.GetObjectListAll<Directive>(qrs, true).FirstOrDefault();

			if (directive == null)
				return null;

			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directive.ItemId, directive.SmartCoreObjectType.ItemId);

			directive.ItemRelations.AddRange(itemsRelations);

			return directive;

			// Примечание - загрузка всех связанных данных должна идти вместе с выставлением Parent
		}

		#endregion

		#region public IList<Directive> GetDirectivesList(int aircraftId, DirectiveType directiveType, IList<int> directiveIds)

		public IList<Directive> GetDirectivesList(int aircraftId, DirectiveType directiveType, IList<int> directiveIds, bool loadDeleted = false)
		{
			var directives = new List<Directive>();

			if (directiveIds.Count == 0)
				return directives;

			var qrs = DirectiveQueries.GetAircraftDirectivesSelectQuery(aircraftId, directiveType,
				new ICommonFilter[]
				{
					new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In,
						directiveIds.ToArray())
				}, true, loadDeleted);

			directives.AddRange(_loader.GetObjectListAll<Directive>(qrs, true));

			if (directives.Count == 0)
				return directives;

			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directiveIds, SmartCoreType.Directive.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var directive in directives)
					directive.ItemRelations.AddRange(
						itemsRelations.Where(i => i.FirstItemId == directive.ItemId || i.SecondItemId == directive.ItemId));
						//TODO:(Evgenii Babak)не использовать Where 
			}

			return directives;
		}

		#endregion

		#region public IList<Directive> GetDirectivesByDirectiveType(int directiveTypeId)

		public IList<Directive> GetDirectivesByDirectiveType(int directiveTypeId)
		{
			return _newLoader.GetObjectListAll<DirectiveDTO, Directive>(new Filter("DirectiveType", directiveTypeId));
		}

		#endregion

		#region private DirectiveCollection GetDirectives(BaseComponent parentComponent Aircraft parentAircraft, PrimaryDirectiveType directiveType)
		/// <summary>
		/// Возвращает все директивы базового агрегата, самолета, или задачи созданные в рамках страницы бортжурнала
		/// </summary>
		/// <returns></returns>
		private DirectiveCollection GetDirectives(BaseComponent parentBaseComponent,
												  Aircraft parentAircraft,
												  AircraftFlight parentFlight,
												  DirectiveType directiveType)
		{
			if (parentAircraft == null && parentBaseComponent == null && parentFlight == null)
				throw new ArgumentNullException();
			if (directiveType == null)
				directiveType = DirectiveType.AirworthenessDirectives;

			List<DbQuery> qrs;
			if (parentBaseComponent != null)
				qrs = DirectiveQueries.GetSelectQuery(parentBaseComponent, directiveType, loadChild: true);
			else if (parentAircraft != null)
				qrs = DirectiveQueries.GetAircraftDirectivesSelectQuery(parentAircraft.ItemId, directiveType, loadChild: true);
			else qrs = DirectiveQueries.GetSelectQuery(parentFlight, directiveType, loadChild: true);

			var directives = new DirectiveCollection();
			directives.AddRange(_loader.GetObjectListAll<Directive>(qrs, true));

			if (directives.Count == 0)
				return directives;

			var directiveIds = directives.Select(d => d.ItemId).ToList();
			var itemsRelations = _itemsRelationsDataAccess.GetRelations(directiveIds, SmartCoreType.Directive.ItemId);

			if (itemsRelations.Count > 0)
			{
				foreach (var directive in directives)
					directive.ItemRelations.AddRange(itemsRelations.Where(i => i.FirstItemId == directive.ItemId || i.SecondItemId == directive.ItemId));
			}

			return directives;
		}

		#endregion

		#region public void AddDamageDocument(DamageDocument damageDocument)
		/// <summary>
		/// Добавляет DamageChart на воздушное судно
		/// </summary>
		/// <param name="damageDocument"></param>
		public void AddDamageDocument(DamageDocument damageDocument)
		{
			// Дополняем необходимые свойства и сохраняем в базе данных
			_newKeeper.Save(damageDocument);

			List<DamageSector> sectorsToDelete = new List<DamageSector>();
			foreach (DamageSector damageSector in damageDocument.DamageSectors)
			{
				_newKeeper.Save(damageSector);

				if (damageSector.IsDeleted)
					sectorsToDelete.Add(damageSector);
			}

			foreach (DamageSector sector in sectorsToDelete)
			{
				damageDocument.DamageSectors.Remove(sector);
			}
		}
		#endregion

		#region public void AddDamageChart(DamageChart damageChart)
		/// <summary>
		/// Добавляет DamageChart на воздушное судно
		/// </summary>
		/// <param name="damageChart"></param>
		public void AddDamageChart(DamageChart damageChart)
		{
			// Дополняем необходимые свойства и сохраняем в базе данных
			_newKeeper.Save(damageChart);
		}
		#endregion

		#region public void Save(Directive directive)

		/// <summary>
		/// Сохраняет объект Directive в БД сохраняет если такой уже есть или создает новый если такой объект появляется первый раз
		/// </summary>
		/// <param name="directive">Принимает Directive</param>
		public void Save(Directive directive)
		{
			_newKeeper.Save(directive);

			foreach (AccessoryRequired accessoryRequired in directive.Kits)
			{
				accessoryRequired.ParentObject = directive;
				accessoryRequired.ParentId = directive.ItemId;

				_keeper.Save(accessoryRequired);
			}

			foreach (DirectiveRecord directiveRecord in directive.PerformanceRecords)
			{
				directiveRecord.Parent = directive;
				directiveRecord.ParentId = directive.ItemId;

				_newKeeper.Save(directiveRecord);
			}

			DamageItem damageItem = directive as DamageItem;
			if (damageItem == null || damageItem.DamageDocs.Count == 0)
				return;
			foreach (DamageDocument doc in damageItem.DamageDocs)
			{
				_newKeeper.Save(doc);
			}
		}

		#endregion

		#region public void Delete(Directive directive)
		/// <summary>
		/// Удаление Directive
		/// </summary>
		/// <param name="directive"></param>
		public void Delete(Directive directive)
		{
			directive.IsDeleted = true;
			_newKeeper.Save(directive);
		}

		#endregion
	}
}