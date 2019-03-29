using System.Collections.Generic;
using System.Linq;
using SmartCore.DataAccesses.Kits;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.DataAccesses.NonRoutines
{
	public class NonRoutineJobDataAccess : INonRoutineJobDataAccess
	{
		private readonly ILoader _loader;
		private readonly IKeeper _keeper;

		public NonRoutineJobDataAccess(ILoader loader, IKeeper keeper)
		{
			_loader = loader;
			_keeper = keeper;
		}

		#region public IList<NonRoutineJobDTO> GetNonRoutineJobDTOs(IEnumerable<int> nonRoutineIds)

		public IList<NonRoutineJobDTO> GetNonRoutineJobDTOs(IEnumerable<int> nonRoutineIds)
		{
			return _loader.GetObjectListAll<NonRoutineJobDTO>(new ICommonFilter[]
			{
				new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, nonRoutineIds.ToArray())
			}
				, true);
		}

		#endregion

		#region public IEnumerable<NonRoutineJobDTO> GetNonRoutineJobDTOs())

		public IEnumerable<NonRoutineJobDTO> GetNonRoutineJobDTOs()
		{
			return _loader.GetObjectListAll<NonRoutineJobDTO>(loadChild:true);
		}

		#endregion

		#region public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKits()

		public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKits()
		{
			//Строка запроса, выдающая идентификаторы родительских задач КИТов
			var accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<KitDTO>
				(AccessoryRequired.ParentIdProperty,
					new ICommonFilter[]
					{new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.NonRoutineJob.ItemId)}
				);

			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			var idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {accessoryParentId});

			return _loader.GetObjectListAll<NonRoutineJobDTO>(new ICommonFilter[] {idFilter}, true);
		}

		#endregion

		#region public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKitsByWorkPackageId(int workPackageId)

		public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsWithKitsByWorkPackageId(int workPackageId)
		{
			var accessoryParentId = BaseQueries.GetSelectQueryColumnOnly<KitDTO>
				(AccessoryRequired.ParentIdProperty,
				 new ICommonFilter[]
				{new CommonFilter<int>(AccessoryRequired.ParentTypeIdProperty, SmartCoreType.NonRoutineJob.ItemId)}
				);
			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач КИТов
			var idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {accessoryParentId});

			var directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
				new ICommonFilter[]
				{
					new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.NonRoutineJob.ItemId)
				});

			//создаются запросы на выборку чеков с заданного рабочего пакета 
			//дополнительно фильтрую ключевое поле. значение ключевого поля
			//чека рабочего пакета должно быть среди идентификатор родительских задач КИТов
			return _loader.GetObjectListAll<NonRoutineJobDTO>(new ICommonFilter[]
			{
				new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn}),
				idFilter
			}, true);

		}

		#endregion

		#region public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsFromAircraftWorkPackages(int aircraftId)

		public IList<NonRoutineJobDTO> GetNonRoutineJobDTOsFromAircraftWorkPackages(int aircraftId)
		{
			//Строка запроса, выдающая идентификаторы Рабочих пакетов данного ВС
			var wpParentId = BaseQueries.GetSelectQueryColumnOnly<WorkPackage>
				(BaseEntityObject.ItemIdProperty,
					new ICommonFilter[] {new CommonFilter<int>(WorkPackage.ParentIdProperty, aircraftId)}
				);

			//Строка запроса, выдающая идентификаторы Записей рабочих пакетов данного ВС
			var wprParentId = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>
				(WorkPackageRecord.DirectiveIdProperty,
					new ICommonFilter[]
					{
						new CommonFilter<string>(WorkPackageRecord.WorkPakageIdProperty, FilterType.In, new[] {wpParentId}),
						new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.NonRoutineJob.ItemId)
					}
				);

			//Фильтр по ключевому полю таблицы обозначающий 
			//что значения ключевого поля таблицы должны быть
			//среди идентификаторов родительских задач записей в рабочих пакетах данного ВС
			ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
				FilterType.In,
				new[] {wprParentId});


			return _loader.GetObjectListAll<NonRoutineJobDTO>(new[] {idFilter}, true);
		}

		#endregion

		#region public void Save(NonRoutineJobDTO nrjDTO)

		public void Save(NonRoutineJobDTO nrjDTO)
		{
			_keeper.SaveAll(nrjDTO, true);
		}

		#endregion

		#region public void Delete(NonRoutineJobDTO nrjDTO)

		public void Delete(NonRoutineJobDTO nrjDTO)
		{
			_keeper.Delete(nrjDTO, true);
		}

		#endregion

	}
}