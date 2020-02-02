using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.AverageUtilizations;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Calculations.MTOP;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Component;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.DataAccesses.WorkPackageRecords;
using SmartCore.Directives;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.NewLoader;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Maintenance;
using SmartCore.Management;
using SmartCore.NonRoutineJobs;
using SmartCore.Queries;
using SmartCore.RegisterPerformances;
using SmartCore.Relation;

namespace SmartCore.WorkPackages
{
	public class WorkPackageCore : IWorkPackageCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly INewLoader _newLoader;
		private readonly IMaintenanceCore _maintenanceCore;
		private readonly INewKeeper _newKeeper;
		private readonly ICalculator _calculator;
		private readonly IComponentCore _componentCore;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly INonRoutineJobDataAccess _nonRoutineJobDataAccess;
		private readonly IDirectiveCore _directiveCore;
		private readonly IFilesDataAccess _filesDataAccess;
		private readonly IPerformanceCalculator _performanceCalculator;
		private readonly IPerformanceCore _performanceCore;
		private readonly IBindedItemsCore _bindedItemsCore;
		private readonly IWorkPackageRecordsDataAccess _workPackageRecordsDataAccess;
		private readonly IMTOPCalculator _mtopCalculator;
		private readonly IAverageUtilizationCore _averageUtilizationCore;

		public WorkPackageCore(ICasEnvironment casEnvironment, INewLoader newLoader, IMaintenanceCore maintenanceCore,
							   INewKeeper newKeeper, ICalculator calculator, IComponentCore componentCore,
							   IAircraftsCore aircraftsCore, INonRoutineJobDataAccess nonRoutineJobDataAccess,
							   IDirectiveCore directiveCore, IFilesDataAccess filesDataAccess, IPerformanceCalculator performanceCalculator,
							   IPerformanceCore performanceCore, IBindedItemsCore bindedItemsCore, IWorkPackageRecordsDataAccess workPackageRecordsDataAccess, IMTOPCalculator mtopCalculator, IAverageUtilizationCore averageUtilizationCore)
		{
			_casEnvironment = casEnvironment;
			_newLoader = newLoader;
			_maintenanceCore = maintenanceCore;
			_newKeeper = newKeeper;
			_calculator = calculator;
			_componentCore = componentCore;
			_aircraftsCore = aircraftsCore;
			_nonRoutineJobDataAccess = nonRoutineJobDataAccess;
			_directiveCore = directiveCore;
			_filesDataAccess = filesDataAccess;
			_performanceCalculator = performanceCalculator;
			_performanceCore = performanceCore;
			_bindedItemsCore = bindedItemsCore;
			_workPackageRecordsDataAccess = workPackageRecordsDataAccess;
			_mtopCalculator = mtopCalculator;
			_averageUtilizationCore = averageUtilizationCore;
		}

		#region public List<WorkPackage> GetWorkPackages(Aircraft aircraft = null, WorkPackageStatus status = WorkPackageStatus.All, bool isLoadWorkPackageItems = false)

		/// <summary>
		/// Возвращает рабочие пакеты воздушного судна
		/// </summary>
		/// <param name="aircraft">Воздушное судно. При пережаче null вернет все рабочие пакеты</param>
		/// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
		/// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		public List<WorkPackage> GetWorkPackages(Aircraft aircraft = null,
												 WorkPackageStatus status = WorkPackageStatus.All,
												 bool loadWorkPackageItems = false,
												 IList<IDirective> includedTasks = null)
		{
			return getWorkPackages(aircraft, status, loadWorkPackageItems, includedTasks);
		}

		#endregion

		#region public List<WorkPackage> GetWorkPackagesLite(Aircraft aircraft, WorkPackageStatus status = WorkPackageStatus.All, ICommonCollection includedTasks = null)

		/// <summary>
		/// Возвращает рабочие пакеты воздушного судна (Для рабочих пакетов грузятся только записи о включенных в них задачах)
		/// </summary>
		/// <param name="aircraft">Воздушное судно. При пережаче null вернет все рабочие пакеты</param>
		/// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		public List<WorkPackage> GetWorkPackagesLite(Aircraft aircraft,
													 WorkPackageStatus status = WorkPackageStatus.All,
													 IList<IDirective> includedTasks = null)
		{
			var wps = getWorkPackages(aircraft, status, false, includedTasks);

			if (wps.Count == 0)
				return wps;
			var wpIds = wps.Select(wp => wp.ItemId).ToArray();

			var wprs = _newLoader.GetObjectList<WorkPackageRecordDTO, WorkPackageRecord>(new Filter("WorkPakageId", wpIds));
			
			foreach (var workPackage in wps)
			{
				workPackage.Aircraft = aircraft;

				IEnumerable<WorkPackageRecord> curWpRecords = wprs.Where(r => r.WorkPakageId == workPackage.ItemId).ToArray();
				foreach (var curWpRecord in curWpRecords)
					curWpRecord.WorkPackage = workPackage;

				workPackage.WorkPakageRecords.Clear();
				workPackage.WorkPakageRecords.AddRange(curWpRecords);
			}

			return wps;
		}

		#endregion

		#region public void LoadWorkPackageItems(WorkPackage workPackage)

		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="workPackage"></param>
		public void LoadWorkPackageItems(WorkPackage workPackage)
		{
			loadWorkPackageItems(workPackage);
		}

		#endregion

		#region public IEnumerable<WorkPackageRecord> GetWorkPackageRecords(WorkPackage wp, bool loadTasks = false, bool lastPerformanceOnly = true)

		/// <summary>
		/// Возвращает все записи заданного рабочего пакета
		/// </summary>
		/// <param name="wp">Заданный рабочий пакет</param>
		/// <param name="loadTasks">если true, то загружает связные с записями задачи</param>
		/// <param name="lastPerformanceOnly">загружать толлео последнее выполнение</param>
		/// <returns></returns>
		private IEnumerable<WorkPackageRecord> GetWorkPackageRecords(WorkPackage wp, bool loadTasks = false, bool lastPerformanceOnly = true)
		{
			var result = _newLoader.GetObjectList<WorkPackageRecordDTO, WorkPackageRecord>(new Filter("WorkPakageId", wp.ItemId));
			foreach (var record in result)
				record.WorkPackage = wp;
			
			if (!loadTasks) return result;

			#region загрузка директив летной годности

			var adWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.Directive.ItemId).ToList();
			if (adWprs.Count > 0)
			{
				var directivesIds = adWprs.Select(wpr => wpr.DirectiveId).ToArray();
				var directives = _directiveCore.GetDirectivesList(wp.Aircraft.ItemId, DirectiveType.All, directivesIds, true);
				if (directives.Count > 0)
				{
					foreach (var adWpr in adWprs)
					{
						var directive = directives.GetItemById(adWpr.DirectiveId);
						if (directive != null)
							adWpr.Task = directive;
						else result.Remove(adWpr);
					}
				}
			}

			#endregion

			#region загрузка деталей

			var detWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.Component.ItemId).ToList();
			if (detWprs.Count > 0)
			{
				var componentIds = detWprs.Select(d => d.DirectiveId).ToArray();
				var components = _componentCore.GetComponentByIds(componentIds);

				if (components.Count > 0)
				{
					foreach (WorkPackageRecord adWpr in detWprs)
						adWpr.Task = components.GetItemById(adWpr.DirectiveId);
				}
			}
			#endregion

			#region загрузка Базовых деталей

			var baseDetWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.BaseComponent.ItemId).ToList();
			if (baseDetWprs.Count > 0)
			{
				foreach (var t in baseDetWprs)
					t.Task = _componentCore.GetBaseComponentById(t.DirectiveId);
			}

			#endregion

			#region загрузка директив деталей

			var detDirWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.ComponentDirective.ItemId).ToList();
			if (detDirWprs.Count > 0)
			{
				var componentDirectivesIds = detDirWprs.Select(wpr => wpr.DirectiveId).ToArray();
				var componentDirectives = _componentCore.GetComponentDirectives(componentDirectivesIds, true);

				if (componentDirectives.Count > 0)
				{
					foreach (var adWpr in detDirWprs)
						adWpr.Task = componentDirectives.GetItemById(adWpr.DirectiveId);

					var bindedItems = _bindedItemsCore.GetBindedItemsFor(wp.ParentId, componentDirectives.Cast<IBindedItem>(),
																		 new[] {SmartCoreType.MaintenanceDirective.ItemId});
					//TODO:(Evgenii Babak) Посмотреть где используется свойство MaintenanceDirective и удостоверится нужна ли загрузка здесь
					if (bindedItems.Count > 0)
					{
						foreach (var componentDirective in componentDirectives)
						{
							if (bindedItems.ContainsKey(componentDirective))
							{
								var mpd = (MaintenanceDirective) bindedItems[componentDirective].SingleOrDefault();
								mpd.TaskCardNumberFile = _newLoader.GetAttachedFileById(mpd.TaskCardNumberFile.ItemId);
								componentDirective.MaintenanceDirective = mpd;
							}
						}
					}

					// загружаем все выполнения всех директив агрегата
					if (!lastPerformanceOnly)
					{
						 var dirids = componentDirectives.Select(dd => dd.ItemId).ToArray(); 
						 var directiveRecords = _newLoader.GetObjectListAll<DirectiveRecordDTO, DirectiveRecord>(new List<Filter>()
						 {
							 new Filter("ParentTypeId",SmartCoreType.ComponentDirective.ItemId ),
							 new Filter("ParentID",dirids)
						 });
						 ConnectRecordsWithComponentDirectives(componentDirectives, directiveRecords);
					}
				}
			}
			#endregion

			#region загрузка чеков обслуживания

			var maintCheckWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.MaintenanceCheck.ItemId).ToList();
			if (maintCheckWprs.Count > 0)
			{
				var maintenanceCheckIds = maintCheckWprs.Select(wpr => wpr.DirectiveId).ToArray();
				var maintenanceChecks = _maintenanceCore.GetMaintenanceCheckList(maintenanceCheckIds, true);

				if (maintenanceChecks.Count > 0)
				{
					foreach (var adWpr in maintCheckWprs)
						adWpr.Task = maintenanceChecks.GetItemById(adWpr.DirectiveId);
				}
			}
			#endregion

			#region загрузка директив обслуживания
			var mpdWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.MaintenanceDirective.ItemId).ToList();
			if (mpdWprs.Count > 0)
			{
				var ids = mpdWprs.Select(mpdr => mpdr.DirectiveId).ToArray();

				var mpds = _maintenanceCore.GetMaintenanceDirectiveList(ids);
				
				if (mpds.Count > 0)
				{
					foreach (var adWpr in mpdWprs)
					{
						var mpd = mpds.GetItemById(adWpr.DirectiveId);
						if (mpd != null)
							adWpr.Task = mpd;
						else result.Remove(adWpr);
					}
				}
			}

			#endregion

			#region загрузка нерутинных работ

			var nrjWprs = result.Where(w => w.WorkPackageItemType == SmartCoreType.NonRoutineJob.ItemId).ToList();
			if (nrjWprs.Count > 0)
			{
				var ids = nrjWprs.Select(mpdr => mpdr.DirectiveId);
				var jobDTOs = _nonRoutineJobDataAccess.GetNonRoutineJobDTOs(ids);

				if (jobDTOs.Count > 0)
				{
					var nrjWprsDict = nrjWprs.ToDictionary(n => n.DirectiveId);
					foreach (var jobDTO in jobDTOs)
					{
						var nonRoutineJob = NonRoutineJobHelper.Convert(jobDTO, _casEnvironment);
						nonRoutineJob.ParentWorkPackage = wp;

						var nrjRec = nrjWprsDict[nonRoutineJob.ItemId];

						nonRoutineJob.WorkPackageRecord = nrjRec;
						nrjRec.Task = nonRoutineJob;
					}
				}
			}
			#endregion

			return result;
		}

		#endregion

		#region public IEnumerable<MaintenanceCheckBindTaskRecord> GetMaintenanceBingTasksRecords(WorkPackage workPackage, bool loadTasks = true, bool lastPerformanceOnly = true)
		/// <summary>
		/// Возвращает все записи о привязку задач к определенному чеку программы обслуживания
		/// </summary>
		/// <returns></returns>
		public IEnumerable<MaintenanceCheckBindTaskRecord> GetMaintenanceBingTasksRecords(int workPackageId,
																						  bool loadTasks = true,
																						  bool lastPerformanceOnly = true)
		{
			var bindTaskRecords =
				_newLoader.GetObjectListAll<MaintenanceCheckBindTaskRecordDTO, MaintenanceCheckBindTaskRecord>(
					new Filter("WorkPackageId", workPackageId));
			
			if (!loadTasks) return bindTaskRecords;

			string qr;
			DataSet ds;

			#region загрузка директив летной годности

			var adBindRecords = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.Directive).ToList();
			if (adBindRecords.Count > 0)
			{
				var ids = adBindRecords.Select(wpr => wpr.TaskId).ToArray();
				var directiveCollection = new CommonCollection<Directive>(_newLoader.GetObjectListAll<DirectiveDTO, Directive>(new Filter("ItemId", ids)));

				if (directiveCollection.Count > 0)
				{
					foreach (var adWpr in adBindRecords)
					{
						var d = directiveCollection.GetItemById(adWpr.TaskId);
						if (d != null)
							adWpr.Task = d;
						else adWpr.Task = new Directive
						{
							ItemId = -1,
							Title = $"error: can't find directive with id {adWpr.TaskId}",
						};
					}

					if (!lastPerformanceOnly)
					{
						var dirids = directiveCollection.Select(dd => dd.ItemId).ToArray();
						var directiveRecords = _newLoader.GetObjectListAll<DirectiveRecordDTO, DirectiveRecord>(new List<Filter>()
						{
							new Filter("ParentTypeId",SmartCoreType.Directive.ItemId),
							new Filter("ParentID",dirids)
						});

						ConnectRecordsWithDirectives(directiveCollection, directiveRecords);
					}
				}
			}

			#endregion

			#region загрузка деталей

			var detBindRecords = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.Component).ToList();
			var components = new ComponentCollection();
			if (detBindRecords.Count > 0)
			{
				qr = BaseQueries.GetSelectQueryWithWhere<Entities.General.Accessory.Component>
					(
						new ICommonFilter[]
						 {
							 new CommonFilter<int>(BaseEntityObject.ItemIdProperty,
												   FilterType.In,
												   detBindRecords.Select(r => r.TaskId).ToArray())
						 },
						 getDeleted: true
					);
				ds = _casEnvironment.Execute(qr);
				components.AddRange(BaseQueries.GetObjectList<Entities.General.Accessory.Component>(ds.Tables[0]));
				_componentCore.LoadRelatedObjectds(components.ToArray());

				if (components.Count > 0)
				{
					foreach (var adWpr in detBindRecords)
					{
						var d = components.GetItemById(adWpr.TaskId);
						if (d != null)
							adWpr.Task = d;
						else adWpr.Task = new Entities.General.Accessory.Component
						{
							ItemId = adWpr.TaskId,
							Description = $"error: can't find component with id {adWpr.TaskId}",
						};
					}
				}
			}
			#endregion

			#region загрузка Базовых деталей

			var baseDetWprs = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.BaseComponent).ToList();
			if (baseDetWprs.Count > 0)
			{
				foreach (var t in baseDetWprs)
					t.Task = _componentCore.GetBaseComponentById(t.TaskId);
			}

			#endregion

			#region загрузка директив деталей

			var detDirWprs = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.ComponentDirective).ToList();
			if (detDirWprs.Count > 0)
			{
				var ids = detDirWprs.Select(wpr => wpr.TaskId).ToArray();
				var collection = new CommonCollection<ComponentDirective>(
					_newLoader.GetObjectListAll<ComponentDirectiveDTO, ComponentDirective>(
						new Filter("ItemId", ids)));

				if (collection.Count > 0)
				{
					foreach (var adWpr in detDirWprs)
						adWpr.Task = collection.GetItemById(adWpr.TaskId);

					foreach (var componentDirective in collection)
					{
						var bd = _componentCore.GetBaseComponentById(componentDirective.ComponentId);
						if (bd != null)
							componentDirective.ParentComponent = bd;
						else
						{
							var d = components.GetItemById(componentDirective.ComponentId);
							componentDirective.ParentComponent = d ?? _componentCore.GetComponentById(componentDirective.ComponentId);
						}
					}
					// загружаем все выполнения всех директив агрегата
					if (!lastPerformanceOnly)
					{
						var dirids = collection.Select(dd => dd.ItemId).ToArray();
						var directiveRecords = _newLoader.GetObjectListAll<DirectiveRecordDTO, DirectiveRecord>(new List<Filter>()
						{
							new Filter("ParentTypeId",SmartCoreType.ComponentDirective.ItemId),
							new Filter("ParentID",dirids)
						});
						ConnectRecordsWithComponentDirectives(collection.ToList(), directiveRecords);
					}
				}

				collection.Clear();
			}
			#endregion

			#region загрузка директив обслуживания

			var mpdWprs = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.MaintenanceDirective).ToList();
			if (mpdWprs.Count > 0)
			{
				var ids = mpdWprs.Select(mpdr => mpdr.TaskId).ToArray();

				var idFilter = new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids);
				var qrs = BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>(new ICommonFilter[] { idFilter }, true, true);
				List<ExecutionResultArgs> resultArgses;
				ds = _casEnvironment.Execute(qrs, out resultArgses);
				var resWithException = resultArgses.FirstOrDefault(r => r.Exception != null);
				if (resWithException != null)
					throw resWithException.Exception;

				var mpds = BaseQueries.GetObjectCollection<MaintenanceDirective>(ds, true);
				if (mpds.Count > 0)
				{
					foreach (var adWpr in mpdWprs)
					{
						var d = mpds.GetItemById(adWpr.TaskId);
						if (d != null)
							adWpr.Task = d;
						else adWpr.Task = new MaintenanceDirective
						{
							ItemId = -1,
							MPDTaskNumber = $"error: can't find MPD with id {adWpr.TaskId}",
						};
					}
				}
			}

			#endregion

			#region загрузка нерутинных работ

			var nrjWprs = bindTaskRecords.Where(w => w.TaskType == SmartCoreType.NonRoutineJob).ToList();
			if (nrjWprs.Count > 0)
			{
				var s = "";
				for (int i = 0; i < nrjWprs.Count; i++)
				{
					s += nrjWprs[i].TaskId;
					if (i < nrjWprs.Count - 1) s += ",";
				}
				qr = BaseQueries.GetSelectQueryWithWhere<NonRoutineJob>() + $" and ItemID in ({s})";
				ds = _casEnvironment.Execute(qr);
				var jobs = BaseQueries.GetObjectCollection<NonRoutineJob>(ds.Tables[0]);

				if (jobs.Count > 0)
				{
					foreach (MaintenanceCheckBindTaskRecord adWpr in nrjWprs)
					{
						adWpr.Task = jobs.GetItemById(adWpr.TaskId);
					}

					//поиск КИТ-ов директив

					qr = BaseQueries.GetSelectQueryWithWhere<AccessoryRequired>() + $@" and ParentTypeId = {SmartCoreType.NonRoutineJob.ItemId} and ParentId in ({s})";
					ds = _casEnvironment.Execute(qr);
					var kits = BaseQueries.GetObjectList<AccessoryRequired>(ds.Tables[0]);

					foreach (NonRoutineJob nonRoutineJob in jobs)
					{
						nonRoutineJob.Kits.Clear();
						nonRoutineJob.Kits.AddRange(kits.Where(k => k.ParentId == nonRoutineJob.ItemId));
					}
				}
			}
			#endregion

			return bindTaskRecords;
		}

		#endregion

		public void GetWorkPackageItemsWithCalculateNew(WorkPackage workPackage)
		{
			loadWorkPackageItems(workPackage);

			workPackage.MaxClosingDate = DateTime.Today;
			workPackage.MinClosingDate = workPackage.Aircraft != null ? workPackage.Aircraft.ManufactureDate : DateTimeExtend.GetCASMinDateTime();

			if (workPackage.Status == WorkPackageStatus.Opened)
			{
				var directives = new List<IMtopCalc>();
				directives.AddRange(workPackage.AdStatus.ToList());
				directives.AddRange(workPackage.SbStatus.ToList());
				directives.AddRange(workPackage.EoStatus.ToList());
				directives.AddRange(workPackage.Components.ToList());
				directives.AddRange(workPackage.BaseComponents.ToList());
				directives.AddRange(workPackage.ComponentDirectives.ToList());
				directives.AddRange(workPackage.MaintenanceDirectives.ToList());

				_mtopCalculator.CalculateDirectiveNew(directives);
			}
		}

		#region public void GetWorkPackageItemsWithCalculate(WorkPackage workPackage)
		/// <summary>
		/// загружает элементы рабочего пакета, и производит их калькуляцмю.
		/// </summary>
		/// <param name="workPackage"></param>
		public void GetWorkPackageItemsWithCalculate(WorkPackage workPackage)
		{
			loadWorkPackageItems(workPackage);

			workPackage.MaxClosingDate = DateTime.Today;
			workPackage.MinClosingDate = workPackage.Aircraft != null ? workPackage.Aircraft.ManufactureDate : DateTimeExtend.GetCASMinDateTime();
			//записи по чекам обслуживания нужно сгруппировать по типу чеков (Schedule/Store)
			//и номеру группы выполнения, после, для каждой группы расчитать ресурс и дату выполнения
			var maintenanceChecksWprs = workPackage.WorkPakageRecords.Where(w => w.Task?.SmartCoreObjectType == SmartCoreType.MaintenanceCheck
													  && w.Task?.ItemId > 0);
			var mcs = new List<MaintenanceCheck>();
			var rmcs = new List<MaintenanceCheck>();
			foreach (var maintenanceChecksWpr in maintenanceChecksWprs)
			{
				var mc = (MaintenanceCheck)maintenanceChecksWpr.Task;
				var apr =
					mc.PerformanceRecords
						.FirstOrDefault(pr => pr.NumGroup == maintenanceChecksWpr.PerformanceNumFromStart);
				if (apr != null)
				{
					mc.ComplianceGroupNum = apr.NumGroup;
					rmcs.Add(mc);
				}
				else
				{
					mc.ComplianceGroupNum = maintenanceChecksWpr.PerformanceNumFromStart;
					mcs.Add(mc);
				}
				mc.ResetMathData();
			}

			#region Добавление информации в запись о выполнении для чеков, имеющих записи в рамках данного рабочего пакета
			//группировка по типу (Schedule/Store)
			var groupRmcsByMaintenanceType = rmcs.GroupBy(mc => mc.Schedule);
			foreach (var maintenanceTypeGroup in groupRmcsByMaintenanceType)
			{
				var groupByMaintenanceNum = maintenanceTypeGroup.GroupBy(mc => mc.ComplianceGroupNum);
				foreach (var maintenanceComplianceGroup in groupByMaintenanceNum)
				{
					var mcg = new MaintenanceCheckGroupByType(maintenanceComplianceGroup.First().Schedule);
					foreach (var maintenanceCheck in maintenanceComplianceGroup)
						mcg.Checks.Add(maintenanceCheck);

					var minCheck = mcg.GetMinIntervalCheck();
					var apr =
						minCheck.PerformanceRecords
						   .Cast<AbstractPerformanceRecord>()
						   .FirstOrDefault(r => r.DirectivePackageId == workPackage.ItemId);

					#region Расчет ограничений по записи о выполнении
					if (apr != null)
					{
						var prevPr = minCheck.PerformanceRecords.Cast<AbstractPerformanceRecord>().
							OrderByDescending(rec => rec.RecordDate).
							FirstOrDefault(r => r.RecordDate < apr.RecordDate);

						var nextPr = minCheck.PerformanceRecords.Cast<AbstractPerformanceRecord>().
							OrderByDescending(rec => rec.RecordDate).
							FirstOrDefault(r => r.RecordDate > apr.RecordDate);

						if (prevPr != null)
						{
							apr.PrevPerformanceDate = prevPr.RecordDate;
							apr.PrevPerformanceSource = prevPr.OnLifelength;
						}
						else
						{
							apr.PrevPerformanceDate = _calculator.GetStartDate(minCheck);
							apr.PrevPerformanceSource = Lifelength.Zero;
						}

						if (nextPr != null)
						{
							apr.NextPerformanceDate = nextPr.RecordDate;
							apr.NextPerformanceSource = nextPr.OnLifelength;
						}
						else
						{
							if (!minCheck.IsClosed
								&& _performanceCalculator.GetPerformance(minCheck, apr.PerformanceNum + 1, false))
							{
								var np =
									minCheck.NextPerformances.FirstOrDefault(n => n.PerformanceNum == apr.PerformanceNum + 1);
								if (np != null)
								{
									minCheck.NextPerformances.Remove(np);
									apr.NextPerformanceDate = np.PerformanceDate;
									apr.NextPerformanceSource = np.PerformanceSource;
								}
							}
						}

						foreach (var check in mcg.Checks)
						{
							var mcr =
								check.PerformanceRecords.FirstOrDefault(r => r.DirectivePackageId == workPackage.ItemId);
							if (mcr != null)
							{
								mcr.PrevPerformanceDate = apr.PrevPerformanceDate;
								mcr.PrevPerformanceSource = apr.PrevPerformanceSource;
								mcr.NextPerformanceDate = apr.NextPerformanceDate;
								mcr.NextPerformanceSource = apr.NextPerformanceSource;
							}
						}
					}
					#endregion
				}
			}
			#endregion

			#region Расчет выполнения для чеков не имеющих записи в рамках данного рабочего пакета
			//группировка по типу (Schedule/Store)
			var groupByMaintenanceType = mcs.GroupBy(mc => mc.Schedule);
			foreach (var maintenanceTypeGroup in groupByMaintenanceType)
			{
				var groupByMaintenanceNum = maintenanceTypeGroup.GroupBy(mc => mc.ComplianceGroupNum);
				foreach (var maintenanceComplianceGroup in groupByMaintenanceNum)
				{
					var mcg = new MaintenanceCheckGroupByType(maintenanceComplianceGroup.First().Schedule);
					foreach (var maintenanceCheck in maintenanceComplianceGroup)
						mcg.Checks.Add(maintenanceCheck);
					//чеки выполнения
					_performanceCalculator.GetPerformance(mcg, maintenanceComplianceGroup.Key);
				}
			}
			#endregion

			foreach (var record in workPackage.WorkPakageRecords)
			{
				if (record.Task == null)
					continue;

				if (record.Task?.ItemId <= 0)
					continue;

				NextPerformance nextPerformance = null;
				AbstractPerformanceRecord apr = null;

				if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
				{
					//Ничего не делать, т.к. чеки обслуживания уже просчитаны 
					var task = (MaintenanceCheck)record.Task;
					nextPerformance =
						task.NextPerformances
						.OfType<MaintenanceNextPerformance>()
						.FirstOrDefault(np => np.PerformanceGroupNum == record.PerformanceNumFromStart);

					apr =
						task.PerformanceRecords
						.Cast<AbstractPerformanceRecord>()
						.FirstOrDefault(r => r.DirectivePackageId == workPackage.ItemId);
				}
				else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
				{

				}
				//else if ( record.Task.SmartCoreObjectType == SmartCoreType.Detail)
				//{
				//    Detail detail = record.Task as Detail;
				//    if (_casEnvironment.Calculator.GetPerformance(detail, apr.PerformanceNum + 1, false))
				//}
				//else if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceDirective)
				//{

				//}
				else if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceDirective)
				{
					var directive = record.Task as MaintenanceDirective;
					var au = _averageUtilizationCore.GetAverageUtillization(directive);
					_mtopCalculator.CalculateDirective(directive, au);


					nextPerformance = new NextPerformance
					{
						Parent = directive,
						PerformanceSource = Lifelength.Zero,
						PerformanceNum = record.PerformanceNumFromStart,
					};

					for (int i = 0; i < record.PerformanceNumFromStart; i++)
					{
						if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
							nextPerformance.PerformanceSource.Days += directive.PhaseRepeat.Days;
						else nextPerformance.PerformanceSource.Days += directive.PhaseThresh.Days;

						if (directive.LastPerformance == null)
							break;
					}


					nextPerformance.PerformanceSource.Cycles = (int?) Math.Round((double)(nextPerformance.PerformanceSource.Days * (au.Hours / au.CyclesPerDay)));
					nextPerformance.PerformanceSource.Hours = (int?)Math.Round((double)(nextPerformance.PerformanceSource.Days * au.Hours));

					var aircraft = _aircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);

					nextPerformance.NextPerformanceDate = aircraft.ManufactureDate.AddDays(nextPerformance.PerformanceSource.Days.Value);
					nextPerformance.PerformanceDate = aircraft.ManufactureDate.AddDays(nextPerformance.PerformanceSource.Days.Value);

					var current = _calculator.GetCurrentFlightLifelength(aircraft);


					if (directive.LastPerformance != null)
					{
						nextPerformance.LimitOverdue = new Lifelength(directive.Threshold.RepeatInterval);
						nextPerformance.LimitNotify = new Lifelength(directive.Threshold.RepeatInterval);
						nextPerformance.LimitNotify.Substract(directive.Threshold.FirstNotification);

						nextPerformance.LimitOverdue.Add(directive.LastPerformance.OnLifelength);
						nextPerformance.LimitNotify.Add(directive.LastPerformance.OnLifelength);

						nextPerformance.LimitOverdue.Resemble(directive.Threshold.RepeatInterval);
						nextPerformance.LimitNotify.Resemble(directive.Threshold.RepeatInterval);
					}
					else
					{
						if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null && !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
						{
							nextPerformance.LimitOverdue = new Lifelength(nextPerformance.PerformanceSource);
							nextPerformance.LimitNotify = new Lifelength(nextPerformance.PerformanceSource);
							nextPerformance.LimitNotify.Substract(directive.Threshold.FirstNotification);

							nextPerformance.LimitOverdue.Resemble(nextPerformance.PerformanceSource);
							nextPerformance.LimitNotify.Resemble(nextPerformance.PerformanceSource);
						}
						else
						{
							nextPerformance.LimitOverdue = new Lifelength(directive.Threshold.FirstPerformanceSinceNew);
							nextPerformance.LimitNotify = new Lifelength(directive.Threshold.FirstPerformanceSinceNew);
							nextPerformance.LimitNotify.Substract(directive.Threshold.FirstNotification);

							nextPerformance.LimitOverdue.Resemble(directive.Threshold.FirstPerformanceSinceNew);
							nextPerformance.LimitNotify.Resemble(directive.Threshold.FirstPerformanceSinceNew);
						}
					}

					nextPerformance.Remains = new Lifelength(nextPerformance.LimitOverdue);
					nextPerformance.Remains.Substract(current); // remains = next - current

					nextPerformance.Remains.Resemble(nextPerformance.LimitOverdue);

					record.Task.NextPerformances.Add(nextPerformance);

				}
				else
				{
					apr = record.Task.PerformanceRecords
					   .Cast<AbstractPerformanceRecord>()
					   .FirstOrDefault(r => r.DirectivePackageId == workPackage.ItemId);

					if (apr != null)
					{
						var prevPr = record.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>().
							OrderByDescending(rec => rec.RecordDate).
							FirstOrDefault(r => r.RecordDate < apr.RecordDate);

						var nextPr = record.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>().
							OrderByDescending(rec => rec.RecordDate).
							FirstOrDefault(r => r.RecordDate > apr.RecordDate);

						if (prevPr != null)
						{
							apr.PrevPerformanceDate = prevPr.RecordDate;
							apr.PrevPerformanceSource = prevPr.OnLifelength;
						}
						else
						{
							apr.PrevPerformanceDate = _calculator.GetStartDate(record.Task);
							apr.PrevPerformanceSource = Lifelength.Zero;
						}
						if (nextPr != null)
						{
							apr.NextPerformanceDate = nextPr.RecordDate;
							apr.NextPerformanceSource = nextPr.OnLifelength;
						}
						else
						{
							if (!record.Task.IsClosed
								&& _performanceCalculator.GetPerformance(record.Task, record.PerformanceNumFromStart + 1))
							{
								var np =
									record.Task.NextPerformances
									.FirstOrDefault(n => n.PerformanceNum == record.PerformanceNumFromStart + 1);

								record.Task.NextPerformances.Remove(np);
								apr.NextPerformanceDate = np.PerformanceDate;
								apr.NextPerformanceSource = np.PerformanceSource;
							}
						}
					}
					else
					{
						var task = record.Task;

						if (!task.IsClosed)
						{
							if (task is Entities.General.Accessory.Component)
								_performanceCalculator.GetPerformance((Entities.General.Accessory.Component)task, record.PerformanceNumFromStart);
							else _performanceCalculator.GetPerformance(task, record.PerformanceNumFromStart);

							nextPerformance =
								task.NextPerformances.FirstOrDefault(np => np.PerformanceNum == record.PerformanceNumFromStart);
						}
					}
				}

				if (nextPerformance != null)
				{
					if (nextPerformance.PrevPerformanceDate != null &&
						workPackage.MinClosingDate < nextPerformance.PrevPerformanceDate)
						workPackage.MinClosingDate = nextPerformance.PrevPerformanceDate;
					if (nextPerformance.NextPerformanceDate != null &&
						workPackage.MaxClosingDate < nextPerformance.NextPerformanceDate)
						workPackage.MaxClosingDate = nextPerformance.NextPerformanceDate;
				}

				if (apr != null)
				{
					if (apr.PrevPerformanceDate != null && workPackage.MinClosingDate < apr.PrevPerformanceDate)
						workPackage.MinClosingDate = apr.PrevPerformanceDate;
					if (apr.NextPerformanceDate != null && workPackage.MaxClosingDate > apr.NextPerformanceDate)
						workPackage.MaxClosingDate = apr.NextPerformanceDate;
				}
			}

			if (workPackage.MaxClosingDate < workPackage.MinClosingDate)
				workPackage.CanClose = false;
			var wpItems = workPackage.WorkPakageRecords.Where(i => i.Task != null).Select(record => record.Task).ToList();
			var relatedWorkPackages = new CommonCollection<WorkPackage>();
			if (workPackage.Status != WorkPackageStatus.Closed)
			{
				relatedWorkPackages.AddRange(getWorkPackages(null, WorkPackageStatus.Opened,
															 true, wpItems));
				relatedWorkPackages.AddRange(getWorkPackages(null, WorkPackageStatus.Published,
															 true, wpItems));

				//сбор всех записей рабочих пакетов для удобства фильтрации
				var openWPRecords = new List<WorkPackageRecord>();
				foreach (var openWorkPackage in relatedWorkPackages)
					openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

				foreach (var record in workPackage.WorkPakageRecords)
				{
					var workPackageRecord =
							openWPRecords.FirstOrDefault(wpr => wpr.WorkPakageId != record.WorkPakageId
																&& wpr.WorkPackageItemType == record.WorkPackageItemType
																&& wpr.DirectiveId == record.DirectiveId
																&& wpr.PerformanceNumFromStart <= record.PerformanceNumFromStart);
					if (workPackageRecord != null)
					{
						//у одной из задач данного рабочего пакета,
						//есть выполнение с меньшим порядковым номером 
						//в другом открытом рабочем пакете
						//поэтому данный рабочий пакет закрыть нельзя
						workPackage.CanClose = false;
						if (record.Task.NextPerformances.Count > 0)
						{
							record.Task.NextPerformances[0].BlockedByPackage
								= relatedWorkPackages.GetItemById(workPackageRecord.WorkPakageId);
						}
					}
				}
			}
			else
			{
				//При закоытом Рабочем пакете, в список попадают записи о выполении
				//сделанные в рамках данного рабочего пакета
				relatedWorkPackages.AddRange(getWorkPackages(null, WorkPackageStatus.Closed,
															 true, wpItems));
				//сбор всех записей рабочих пакетов для удобства фильтрации
				var closeWPRecords = new List<WorkPackageRecord>();
				foreach (var closedWorkPackage in relatedWorkPackages)
					closeWPRecords.AddRange(closedWorkPackage.WorkPakageRecords);
				foreach (var record in workPackage.WorkPakageRecords)
				{
					if (closeWPRecords.FirstOrDefault(wpr => wpr.WorkPakageId != record.WorkPakageId
															&& wpr.WorkPackageItemType == record.WorkPackageItemType
															&& wpr.DirectiveId == record.DirectiveId
															&& wpr.PerformanceNumFromStart > record.PerformanceNumFromStart) != null)
					{
						//у одной из задач данного рабочего пакета,
						//есть выполнение с большим порядковым номером 
						//в другом закрытом рабочем пакете
						workPackage.CanPublish = false;
						workPackage.BlockPublishReason =
							"From one of the task of this work package," +
							"\nhave the execution of a large atomic number" +
							"\nin other enclosed work package";

					}
					if (workPackage.WorkPakageRecords
						.Where(wpr => wpr.Task != null && wpr.Task is Entities.General.Accessory.Component)
						.Select(wpr => wpr.Task as Entities.General.Accessory.Component)
						.Where(d => d.TransferRecords.Where(tr => tr.DirectivePackageId == workPackage.ItemId && tr.DODR)
												   .Count() > 0).Count() > 0)
					{
						//Поиск записи в рабочем пакете по деталям(базовым деталям)
						//в записях о перемещении которых есть запись сделанная в рамках данного 
						//рабочего пакета, и подтвержденная на стороне получателя
						//Если такие записи есть, то рабочий пакет перепубликовать нельзя
						workPackage.CanPublish = false;
						if (workPackage.BlockPublishReason != "")
							workPackage.BlockPublishReason += "\n";
						workPackage.BlockPublishReason =
							"This work package has in its task of moving component," +
							"\nwhich was confirmed on the destination side";
					}
				}
			}

			wpItems.Clear();
			relatedWorkPackages.Clear();
		}
		#endregion

		#region public void Publish(WorkPackage wp, DateTime date, String remarks)
		/// <summary>
		/// Публикует рабочий пакет - выдает рабочий пакет на перрон
		/// </summary>
		/// <param name="wp"></param>
		/// <param name="date"></param>
		/// <param name="remarks"></param>
		public void Publish(WorkPackage wp, DateTime date, string remarks)
		{
			if (wp.Status != WorkPackageStatus.Closed)
			{
				wp.Status = WorkPackageStatus.Published;
				wp.PublishingDate = date;
				wp.PublishedBy = _casEnvironment.IdentityUser.Login;
				wp.Remarks = remarks;
			}
			else
			{
				loadWorkPackageItems(wp);

				foreach (var item in wp.AdStatus)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.DefferedItems)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.Damages)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.OutOfPhaseItems)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.ComponentDirectives)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.MaintenanceChecks)
				{
					var records = new List<MaintenanceCheckRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _maintenanceCore.Delete(record);
					}
				}
				foreach (var item in wp.MaintenanceDirectives)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _performanceCore.Delete(record);
					}
				}
				foreach (var item in wp.BaseComponents)
				{
					var records = new List<TransferRecord>(item.TransferRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _casEnvironment.Manipulator.Delete(record);
					}
				}
				foreach (var item in wp.Components)
				{
					var records = new List<TransferRecord>(item.TransferRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId) _casEnvironment.Manipulator.Delete(record);
					}
				}

				wp.Status = WorkPackageStatus.Published;
				wp.PublishingDate = date;
				wp.PublishedBy = _casEnvironment.IdentityUser.Login;
				wp.ClosedBy = "";
			}

			_newKeeper.Save(wp);
		}
		#endregion

		#region public WorkPackage AddWorkPakage(IEnumerable<NextPerformance> workPackageItems, Aircraft parentAircraft, out string message)

		/// <summary>
		/// Создание Рабочего пакета
		/// </summary>
		/// <param name="workPackageItems"></param>
		/// <param name="parentAircraft"></param>
		/// <param name="message"></param>
		public WorkPackage AddWorkPakage(IEnumerable<NextPerformance> workPackageItems, Aircraft parentAircraft, out string message)
		{
			if (workPackageItems == null || parentAircraft == null)
				throw new NullReferenceException("1504: NullReferenceException");

			#region Проверка Переданных элементов для формирования рабочего пакета

			if (!workPackageItems.Any())
			{
				message = "Selected tasks not have a performances." +
						  "\nFailed to create empty work package";
				return null;
			}

			var openPubWorkPackages = new CommonCollection<WorkPackage>();
			openPubWorkPackages.Clear();
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Opened, true));
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Published, true));

			//1.есть ли в выбранных элементах 2 и более выполнения одной задачи
			//2.есть ли в выбранных элементах, элементы, блокированные рабочими пакетами
			//3.есть ли в выбранных элементах 2-е и последующее выполнения по замене детали
			//4.есть ли в выбранных элементах выполнения с разными датами
			//5.есть ли в выбранных элементах выполнения, перекрещающиеся с выполнениями в других рабочих пакетах

			var blockedBy = false;
			var crossPerformances = false;
			var invalidComponentExcange = false;
			var multiply = false;
			var blockingWorkPackage = "";
			var errorTaskDescription = "";

			foreach (var o in workPackageItems)
			{
				if (o.BlockedByPackage != null)
				{
					//Выбранное выполнение блокировано другим рабочим рабочим пакетом
					errorTaskDescription = $"{o.Title} {o.WorkType}";
					blockingWorkPackage = o.BlockedByPackage.Title;
					blockedBy = true;
					break;
				}
				if (workPackageItems.Count(i => i.Parent == o.Parent) > 1)
				{
					//если объект является след. выполнением
					//и в выбранных элементах есть "Выполнения" имеющие того же родителя
					//(т.е. выбрано 2 выполнения одного родителя)
					errorTaskDescription = $"{o.Title} {o.WorkType}";
					multiply = true;
					break;
				}
				if (o.Parent is Entities.General.Accessory.Component)
				{
					var det = (Entities.General.Accessory.Component)o.Parent;
					if (det.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали  
						errorTaskDescription = $"{o.Title} {o.Description} {o.WorkType}";
						invalidComponentExcange = true;
						break;
					}
				}
				if (o.Parent is ComponentDirective)
				{
					var detDir = (ComponentDirective)o.Parent;
					if (detDir.DirectiveTypeId == ComponentRecordType.Overhaul.ItemId && detDir.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали 
						errorTaskDescription = $"{o.Title} {o.WorkType}";
						invalidComponentExcange = true;
						break;
					}
				}
			}

			var dictionary = new Dictionary<WorkPackageRecord, NextPerformance>();
			foreach (var workPackage in openPubWorkPackages)
			{
				dictionary.Clear();

				foreach (var nextPerformance in workPackageItems)
				{
					var p = (BaseEntityObject)nextPerformance.Parent;
					var record =
						workPackage.WorkPakageRecords.FirstOrDefault(wpr => wpr.DirectiveId == p.ItemId &&
																			wpr.WorkPackageItemType == p.SmartCoreObjectType.ItemId);
					if (record != null)
					{
						dictionary.Add(record, nextPerformance);
					}
				}

				bool left = false, rigth = false;
				string leftTask = "", rigthTask = "";
				int leftPerfNum1 = 0, leftPerfNum2 = 0, rightPerfNum1 = 0, rightPerfNum2 = 0;
				foreach (var pair in dictionary)
				{
					var wpr = pair.Key;
					var np = pair.Value;
					int perfNum;
					if (np is MaintenanceNextPerformance)
						perfNum = ((MaintenanceNextPerformance)np).PerformanceGroupNum;
					else perfNum = np.PerformanceNum;
					if (wpr.PerformanceNumFromStart > perfNum)
					{
						left = true;
						leftTask = $"{np.Title} {np.WorkType}";
						leftPerfNum1 = wpr.PerformanceNumFromStart;
						leftPerfNum2 = np.PerformanceNum;
					}
					if (wpr.PerformanceNumFromStart < perfNum)
					{
						rigth = true;
						rigthTask = $"{np.Title} {np.WorkType}";
						rightPerfNum1 = wpr.PerformanceNumFromStart;
						rightPerfNum2 = np.PerformanceNum;
					}
				}
				if (left && rigth)
				{
					//имеетя перекрещивание задач
					//2 и более задачи из выбранных выполнений имеются в одном рабочем пакете
					//при этом задача 1 (Т1) в рабочем пакете имеет порядковый номер выполнения н:5
					//а в выбранных элементах списка имеется выполнение Т1 н:6+
					//при этом задача 2 (Т2) в рабочем пакете имеет порядковый номер выполнения н:5
					//а в выбранных элементах списка имеется выполнение Т2 н:5-
					errorTaskDescription = $@"2 or more tasks for selected performances are in the work package:
                                                           \n{workPackage.Title} 
                                                           \nthe task {leftTask} has the number of performance:{leftPerfNum1}, 
                                                           \nbut in the selected items has performance:{leftPerfNum2}.
                                                           \nthe task {rigthTask} has the number of performance:{rightPerfNum1}, 
                                                           \nbut in the selected items has performance:{rightPerfNum2}.";
					crossPerformances = true;
					break;
				}
			}

			if (blockedBy)
			{
				message = "Perform of the task:" +
						  "\n" + errorTaskDescription +
						  "\nblocked by Work Package:" +
						  "\n" + blockingWorkPackage;
				return null;
			}
			if (crossPerformances)
			{
				message = errorTaskDescription + "\nAbort operation";

				return null;
			}
			//if (dateMultiply)
			//{
			//    message = "you can not put the task on different performance date " +
			//              "\nin a one Work Package!" +
			//              "\nTasks:" + errorTaskDescription;
			//    return null;
			//}
			if (invalidComponentExcange)
			{
				message = "A work package can only put the first performance" +
						  "\nof the task of replacing component." +
						  "\nTask:" + errorTaskDescription;
				return null;
			}
			if (multiply)
			{
				message = "You can not put two and more perform a task:" +
						  "\n" + errorTaskDescription +
						  "\nin a one Work Package!";
				return null;
			}
			#endregion

			#region Формирование Рабочего пакета

			#region Номер и ревизия

			var lastWP =
					 getWorkPackages(parentAircraft)
					.OrderByDescending(w => w.OpeningDate)
					.FirstOrDefault();

			var revision = lastWP != null ? lastWP.Revision : "";
			var lastNumberString = "";
			int lastNumber;
			string curNumberString;
			if (lastWP != null)
			{
				for (var i = lastWP.Number.Length - 1; i >= 0; i--)
				{
					if (char.IsDigit(lastWP.Number[i]))
						lastNumberString = lastWP.Number[i] + lastNumberString;
					else break;
				}

				if (!string.IsNullOrEmpty(lastNumberString))
				{
					if (int.TryParse(lastNumberString, out lastNumber))
					{
						string numFormat = lastNumberString.Substring(0,
																	  lastNumberString.Length -
																	  lastNumber.ToString().Length);
						lastNumber++;
						curNumberString = numFormat + lastNumber;
					}
					else curNumberString = "001";
				}
				else curNumberString = "001";
			}
			else curNumberString = "001";

			#endregion

			#region Title

			string titleString = "";
			var packageChecks =
				workPackageItems.Where(w => w.Parent != null && w.Parent is MaintenanceCheck)
								.Select(w => w.Parent as MaintenanceCheck)
								.ToList();
			if (packageChecks.Count > 0)
			{
				var maxGroupCheck =
					packageChecks.Where(c => c.Grouping)
								 .GroupBy(c => c.Resource)
								 .Select(groupCheck => groupCheck.OrderByDescending(c => c.Interval.GetSubresource(c.Resource))
																 .FirstOrDefault())
								 .Where(maxCheck => maxCheck != null)
								 .OrderByDescending(c => c.Interval.GetSubresource(c.Resource))
								 .FirstOrDefault();
				if (maxGroupCheck != null)
				{
					var mnp =
						maxGroupCheck.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault();
					titleString = mnp.Title;
				}
				else
				{
					var maxCheck =
					packageChecks.Where(c => !c.Grouping)
								 .GroupBy(c => c.Resource)
								 .Select(groupCheck => groupCheck.OrderByDescending(c => c.Interval.GetSubresource(c.Resource))
																 .FirstOrDefault())
								 .Where(c => c != null)
								 .OrderByDescending(c => c.Interval.GetSubresource(c.Resource))
								 .FirstOrDefault();
					if (maxCheck != null)
					{
						titleString = maxCheck.ToString();
					}
				}
			}
			//Добавление в название присутствующих на данную дату чеков программы обслуживания
			var maintenanceCheckPerformances = workPackageItems.Where(np => np.Parent != null && np.Parent is MaintenanceCheck);
			//Добавление в название присутствующих директив летной годности
			var adPerformances = workPackageItems.Where(np => np.Parent != null && np.Parent is Directive);
			if (adPerformances.Count() > 0)
			{
				if (titleString != "")
					titleString += " + ";
				titleString += "AD";
			}

			//Добавление в название присутствующих компонентов или задач по ним
			var componentPerformances = workPackageItems.Where(np => np.Parent != null && (np.Parent is Entities.General.Accessory.Component || np.Parent is ComponentDirective));
			if (componentPerformances.Count() > 0)
			{
				if (titleString != "")
					titleString += " + ";
				titleString += "Comp";
			}

			//Добавление в название присутствующих MPD
			var mpdPerformances = workPackageItems.Where(np => np.Parent != null && np.Parent is MaintenanceDirective);
			if (maintenanceCheckPerformances.Count() == 0 && mpdPerformances.Count() > 0)
			{
				if (titleString != "")
					titleString += " + ";
				titleString += "MPD";
			}

			if (titleString == "")
			{
				titleString = workPackageItems.First().Title;
			}


			#endregion

			var wp = new WorkPackage
			{
				Description = "",
				Status = WorkPackageStatus.Opened,
				Author = _casEnvironment.IdentityUser.Login,
				CreateDate = DateTime.Now,
				OpeningDate = DateTime.Today,
				PublishingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingRemarks = "",
				Aircraft = parentAircraft,
				ParentId = parentAircraft.ItemId,
#if KAC
                                     Number =  
                                        string.Format("{0}-{1}/{2}", parentAircraft.MSG, 
                                                                     parentAircraft.RegistrationNumber.Length <= 3 
                                                                        ? parentAircraft.RegistrationNumber 
                                                                        : parentAircraft.RegistrationNumber.Substring(parentAircraft.RegistrationNumber.Length - 3, 3),
                                                                     curNumberString),
#else
				Number = parentAircraft.RegistrationNumber + "-WP-" + DateTime.Now,
#endif
				Title = titleString,
				Revision = revision
			};
			#endregion

			#region Формирование записей рабочего пакета
			foreach (var item in workPackageItems)
			{
				int performanceNum;
				int countRecords = 0;
				var record = new WorkPackageRecord();

				if (item is MaintenanceNextPerformance)
				{
					//MaintenanceNextPerformance содержит, как правило, группу чеков
					//поэтому добавление чеков из этой группы будет полностью производится 
					//в рамках данного блока кода
					MaintenanceNextPerformance mnp = (MaintenanceNextPerformance)item;
					foreach (MaintenanceCheck check in mnp.PerformanceGroup.Checks)
					{
						//performanceNum = check.NextPerformances.IndexOf(
						//    check.NextPerformances.Cast<MaintenanceNextPerformance>()
						//                          .Where(p => p.PerformanceGroupNum == mnp.PerformanceGroupNum)
						//                          .First()) + 1;
						performanceNum = mnp.PerformanceNum;
						var maintRecord = new WorkPackageRecord
						{
							WorkPackageItemType = check.SmartCoreObjectType.ItemId,
							DirectiveId = check.ItemId,
							Task = check,
							PerformanceNumFromStart = mnp.PerformanceGroupNum,
							PerformanceNumFromRecord = performanceNum,
							FromRecordId = check.LastPerformance != null
																				   ? check.LastPerformance.ItemId
																				   : -1,
						};
						wp.WorkPakageRecords.Add(maintRecord);
					}

					if (wp.Description != "") wp.Description += "; ";
					wp.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));

					continue;
				}

				//performanceNum = item.Parent.NextPerformances.IndexOf(item) + 1;
				performanceNum = item.PerformanceNum;
				if (item.Parent is Directive ||
					item.Parent is ComponentDirective ||
					item.Parent is MaintenanceDirective)
				{
					if (item.Parent.LastPerformance != null)
					{
						countRecords = item.Parent.LastPerformance.PerformanceNum <= 0 ? 1 : item.Parent.LastPerformance.PerformanceNum;
						record.FromRecordId = item.Parent.LastPerformance.ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}
				else if (item.Parent is Entities.General.Accessory.Component)
				{
					var dir = (Entities.General.Accessory.Component)item.Parent;
					if (dir.TransferRecords.GetLast() != null)
					{
						countRecords = dir.TransferRecords.GetLast().PerformanceNum <= 0 ? 1 : dir.TransferRecords.GetLast().PerformanceNum;
						record.FromRecordId = dir.TransferRecords.GetLast().ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}
				else if (item.Parent is MaintenanceCheck)
				{
					//MaintenanceNextPerformance содержит, как правило, группу чеков
					//поэтому добавление чеков из этой группы будет полностью производится 
					//в рамках данного блока кода
					var dir = (MaintenanceCheck)item.Parent;
					if (dir.Grouping)
					{
						var mnp = dir.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault();
						if (mnp == null) throw new NullReferenceException("отсутствует первое выполнене у MaintenanceCheck");
						foreach (MaintenanceCheck check in mnp.PerformanceGroup.Checks)
						{
							//performanceNum = check.NextPerformances.IndexOf(
							//    check.NextPerformances.Cast<MaintenanceNextPerformance>()
							//                          .Where(p => p.PerformanceGroupNum == mnp.PerformanceGroupNum)
							//                          .First()) + 1;
							performanceNum = mnp.PerformanceNum;
							var maintRecord = new WorkPackageRecord
							{
								WorkPackageItemType = check.SmartCoreObjectType.ItemId,
								DirectiveId = check.ItemId,
								Task = check,
								PerformanceNumFromStart = mnp.PerformanceGroupNum,
								PerformanceNumFromRecord = performanceNum,
								FromRecordId = check.LastPerformance != null
												   ? check.LastPerformance.ItemId
												   : -1,
							};
							wp.WorkPakageRecords.Add(maintRecord);
						}

						if (wp.Description != "") wp.Description += "; ";
						wp.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));

						continue;
					}
					if (item.Parent.LastPerformance != null)
					{
						countRecords = item.Parent.LastPerformance.PerformanceNum <= 0 ? 1 : item.Parent.LastPerformance.PerformanceNum;
						record.FromRecordId = item.Parent.LastPerformance.ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}

				record.WorkPackageItemType = item.Parent.SmartCoreObjectType.ItemId;
				record.DirectiveId = item.Parent.ItemId;
				record.Task = item.Parent;
				//record.PerformanceNumFromStart = countRecords + performanceNum;
				//record.PerformanceNumFromRecord = performanceNum;
				record.PerformanceNumFromStart = performanceNum;
				record.PerformanceNumFromRecord = performanceNum - countRecords;


				record.Group = item.Group;
				record.ParentCheckId = item.ParentCheck?.ItemId ?? -1;

				wp.WorkPakageRecords.Add(record);

				if (wp.Description != "") wp.Description += "; ";
				wp.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));
			}
			#endregion

			#region Сохранение рабочего пакета и его записей
			_newKeeper.Save(wp);
			message = "Work package created successfull";

			foreach (var item in wp.WorkPakageRecords)
			{
				item.WorkPakageId = wp.ItemId;
				item.WorkPackage = wp;
				_newKeeper.Save(item);
			}

			#endregion

			return wp;
		}
		#endregion

		#region public WorkPackage AddWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, Aircraft parentAircraft, out string message)
		/// <summary>
		/// Создание Рабочего пакета
		/// </summary>
		/// <param name="nonRoutine"></param>
		/// <param name="parentAircraft"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public WorkPackage AddWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, Aircraft parentAircraft, out string message)
		{
			if (nonRoutine == null || parentAircraft == null)
				throw new NullReferenceException("1504: NullReferenceException");

			#region Номер и ревизия

			var lastWP =
					 getWorkPackages(parentAircraft)
					.OrderByDescending(w => w.OpeningDate)
					.FirstOrDefault();

			var revision = lastWP != null ? lastWP.Revision : "";
			var lastNumberString = "001";
			int lastNumber;
			string curNumberString;
			if (lastWP != null)
			{
				for (var i = lastWP.Number.Length - 1; i >= 0; i--)
				{
					if (char.IsDigit(lastWP.Number[i]))
						lastNumberString = lastWP.Number[i] + lastNumberString;
					else break;
				}

				if (!string.IsNullOrEmpty(lastNumberString))
				{
					if (int.TryParse(lastNumberString, out lastNumber))
					{
						string numFormat = lastNumberString.Substring(0,
							lastNumberString.Length -
							lastNumber.ToString().Length);
						lastNumber++;
						curNumberString = numFormat + lastNumber;
					}
				}
			}

			#endregion

			var wp = new WorkPackage
			{
				Description = nonRoutine.First().Title,
				Status = WorkPackageStatus.Opened,
				Author = _casEnvironment.IdentityUser.Login,
				CreateDate = DateTime.Now,
				OpeningDate = DateTime.Today,
				PublishingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingRemarks = "",
				Aircraft = parentAircraft,
				ParentId = parentAircraft.ItemId,

				Title = nonRoutine.First().Title,
				Revision = revision,
				Number = parentAircraft.RegistrationNumber + "-WP-" + DateTime.Now

			};

			foreach (var n in nonRoutine)
			{
				var Record = new WorkPackageRecord
				{
					WorkPackageItemType = n.SmartCoreObjectType.ItemId,
					DirectiveId = n.ItemId,
					Task = n
				};
				wp.WorkPakageRecords.Add(Record);
			}

			#region Сохранение рабочего пакета и его записей

			_newKeeper.Save(wp);
			message = "Work package created successfull";

			foreach (var item in wp.WorkPakageRecords)
			{
				item.WorkPakageId = wp.ItemId;
				item.WorkPackage = wp;
				_newKeeper.Save(item);
			}

			#endregion

			return wp;
		}

		#endregion

		#region public bool AddToWorkPakage(List<NextPerformance> workPackageItems, int workPackageId, out string message)

		/// <summary>
		/// Добавление элементов в существующий открытый или опубликованный рабочий пакет
		/// </summary>
		/// <param name="workPackageItems">Элементы, которые необходимо добавить</param>
		/// <param name="workPackageId">ID рабочего пакета, в который добавляютя элементы</param>
		/// <param name="parentAircraft">Воздушное судно, которому должен пренадлежать рабочий пакет</param>
		/// <param name="message">Сообщение о статусе добавления-корректно или описание ошибки при добавлении</param>
		/// <return>true - если добавление прошло успешно или false в случае провала </return>
		public bool AddToWorkPakage(List<NextPerformance> workPackageItems, int workPackageId, Aircraft parentAircraft, out string message)
		{
			if (workPackageItems == null || parentAircraft == null || workPackageId <= 0)
				throw new NullReferenceException("1504: NullReferenceException");

			#region Проверка состояния рабочего пакета

			var addToWP = _newLoader.GetObject<WorkPackageDTO, WorkPackage>(new Filter("ItemId", workPackageId), getDeleted: true);

			if (addToWP == null)
			{
				message = "Work Package with id: " + workPackageId + " does not exist." +
				"\nFailed to add items to work package";
				return false;
			}

			if (addToWP.IsDeleted)
			{
				message = "Work Package: " + addToWP.Title + " is deleted." +
						  "\nFailed to add items to deleted work package";
				return false;
			}

			if (addToWP.Status == WorkPackageStatus.Closed)
			{
				message = "Work Package: " + addToWP.Title + " is Closed." +
						  "\nFailed to add items to closed work package";
				return false;
			}

			#endregion

			#region Проверка Переданных элементов для формирования рабочего пакета)

			if (!workPackageItems.Any())
			{
				message = "Selected tasks not have a performances." +
						  "\nFailed to add items to work package";
				return false;
			}

			var openPubWorkPackages = new CommonCollection<WorkPackage>();
			openPubWorkPackages.Clear();
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Opened, true));
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Published, true));

			var openPubWpRecords = openPubWorkPackages.SelectMany(wp => wp.WorkPakageRecords);
			var includedInWp = openPubWpRecords
				.Where(rec => rec.WorkPakageId == workPackageId)
				.Select(record => workPackageItems.FirstOrDefault(wpr => wpr.Parent != null &&
																		 wpr.Parent is MaintenanceDirective &&
																		 record.Task != null &&
																		 record.Task is MaintenanceDirective &&
																		 wpr.Parent.ItemId == record.Task.ItemId))
				.Where(np => np != null)
				.ToList();

			foreach (var nextPerformance in includedInWp)
				workPackageItems.Remove(nextPerformance);

			//1.есть ли в выбранных элементах 2 и более выполнения одной задачи
			//2.есть ли в выбранных элементах, элементы, блокированные рабочими пакетами
			//3.есть ли в выбранных элементах 2-е и последующее выполнения по замене детали
			//4.есть ли в выбранных элементах выполнения с разными датами
			//5.есть ли в выбранных элементах выполнения, перекрещающиеся с выполнениями в других рабочих пакетах

			var blockedBy = false;
			var crossPerformances = false;
			var invalidComponentExcange = false;
			var multiply = false;
			var blockingWorkPackage = "";
			var errorTaskDescription = "";

			foreach (var o in workPackageItems)
			{
				if (o.BlockedByPackage != null)
				{
					//Выбранное выполнение блокировано другим рабочим рабочим пакетом
					errorTaskDescription = $"{o.Title} {o.WorkType}";
					blockingWorkPackage = o.BlockedByPackage.Title;
					blockedBy = true;
					break;
				}
				if (workPackageItems.Count(i => i.Parent == o.Parent) > 1 ||
					openPubWpRecords.Count(wpr => wpr.Task != null &&
												  wpr.Task.SmartCoreObjectType == o.Parent.SmartCoreObjectType &&
												  wpr.Task.ItemId == o.Parent.ItemId &&
												  wpr.WorkPackage.ItemId == workPackageId) > 0)
				{
					//если объект является след. выполнением
					//и в выбранных элементах есть "Выполнения" имеющие того же родителя
					//(т.е. выбрано 2 выполнения одного родителя)
					errorTaskDescription = $"{o.Title} {o.WorkType}";
					multiply = true;
					break;
				}
				if (o.Parent is Entities.General.Accessory.Component)
				{
					var det = (Entities.General.Accessory.Component)o.Parent;
					if (det.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали  
						errorTaskDescription = $"{o.Title} {o.Description} {o.WorkType}";
						invalidComponentExcange = true;
						break;
					}
				}
				if (o.Parent is ComponentDirective)
				{
					var detDir = (ComponentDirective)o.Parent;
					if (detDir.DirectiveTypeId == ComponentRecordType.Overhaul.ItemId && detDir.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали 
						errorTaskDescription = $"{o.Title} {o.WorkType}";
						invalidComponentExcange = true;
						break;
					}
				}
			}

			var dictionary = new Dictionary<WorkPackageRecord, NextPerformance>();
			foreach (var workPackage in openPubWorkPackages)
			{
				dictionary.Clear();

				foreach (var nextPerformance in workPackageItems)
				{
					var p = (BaseEntityObject)nextPerformance.Parent;
					var record =
						workPackage.WorkPakageRecords.FirstOrDefault(wpr => wpr.DirectiveId == p.ItemId &&
																			wpr.WorkPackageItemType == p.SmartCoreObjectType.ItemId);
					if (record != null)
						dictionary.Add(record, nextPerformance);
				}

				bool left = false, rigth = false;
				string leftTask = "", rigthTask = "";
				int leftPerfNum1 = 0, leftPerfNum2 = 0, rightPerfNum1 = 0, rightPerfNum2 = 0;
				foreach (KeyValuePair<WorkPackageRecord, NextPerformance> pair in dictionary)
				{
					var wpr = pair.Key;
					var np = pair.Value;
					int perfNum;
					if (np is MaintenanceNextPerformance)
						perfNum = ((MaintenanceNextPerformance)np).PerformanceGroupNum;
					else perfNum = np.PerformanceNum;
					if (wpr.PerformanceNumFromStart > perfNum)
					{
						left = true;
						leftTask = $"{np.Title} {np.WorkType}";
						leftPerfNum1 = wpr.PerformanceNumFromStart;
						leftPerfNum2 = np.PerformanceNum;
					}
					if (wpr.PerformanceNumFromStart < perfNum)
					{
						rigth = true;
						rigthTask = $"{np.Title} {np.WorkType}";
						rightPerfNum1 = wpr.PerformanceNumFromStart;
						rightPerfNum2 = np.PerformanceNum;
					}
				}
				if (left && rigth)
				{
					//имеетя перекрещивание задач
					//2 и более задачи из выбранных выполнений имеются в одном рабочем пакете
					//при этом задача 1 (Т1) в рабочем пакете имеет порядковый номер выполнения н:5
					//а в выбранных элементах списка имеется выполнение Т1 н:6+
					//при этом задача 2 (Т2) в рабочем пакете имеет порядковый номер выполнения н:5
					//а в выбранных элементах списка имеется выполнение Т2 н:5-
					errorTaskDescription = "2 or more tasks for selected performances are in the work package:" +
					                       $"\n{workPackage.Title}" +
					                       $"\nthe task {leftTask} has the number of performance:{leftPerfNum1}," +
					                       $"\nbut in the selected items has performance:{leftPerfNum2}." +
					                       $"\nthe task {rigthTask} has the number of performance:{rightPerfNum1}," +
					                       $"\nbut in the selected items has performance:{rightPerfNum2}.";
					crossPerformances = true;
					break;
				}
			}

			if (blockedBy)
			{
				message = "Perform of the task:" +
						  "\n" + errorTaskDescription +
						  "\nblocked by Work Package:" +
						  "\n" + blockingWorkPackage;
				return false;
			}
			if (crossPerformances)
			{
				message = errorTaskDescription + "\nAbort operation";

				return false;
			}
			if (invalidComponentExcange)
			{
				message = "A work package can only put the first performance" +
						  "\nof the task of replacing component." +
						  "\nTask:" + errorTaskDescription;
				return false;
			}
			if (multiply)
			{
				message = "You can not put two and more perform a task:" +
						  "\n" + errorTaskDescription +
						  "\nin a one Work Package!";
				return false;
			}
			#endregion

			#region Формирование записей рабочего пакета
			foreach (var item in workPackageItems)
			{
				int performanceNum;
				int countRecords = 0;
				var record = new WorkPackageRecord();

				if (item is MaintenanceNextPerformance)
				{
					//MaintenanceNextPerformance содержит, как правило, группу чеков
					//поэтому добавление чеков из этой группы будет полностью производится 
					//в рамках данного блока кода
					var mnp = (MaintenanceNextPerformance)item;
					foreach (var check in mnp.PerformanceGroup.Checks)
					{
						//performanceNum = check.NextPerformances.IndexOf(
						//    check.NextPerformances.Cast<MaintenanceNextPerformance>()
						//                          .Where(p => p.PerformanceGroupNum == mnp.PerformanceGroupNum)
						//                          .First()) + 1;
						performanceNum = mnp.PerformanceNum;
						var maintRecord = new WorkPackageRecord
						{
							WorkPackageItemType = check.SmartCoreObjectType.ItemId,
							DirectiveId = check.ItemId,
							Task = check,
							PerformanceNumFromStart = mnp.PerformanceGroupNum,
							PerformanceNumFromRecord = performanceNum,
							FromRecordId = check.LastPerformance != null
											   ? check.LastPerformance.ItemId
											   : -1,
						};
						addToWP.WorkPakageRecords.Add(maintRecord);
					}

					if (addToWP.Description != "") addToWP.Description += "; ";
					addToWP.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));

					continue;
				}

				//performanceNum = item.Parent.NextPerformances.IndexOf(item) + 1;
				performanceNum = item.PerformanceNum;
				if (item.Parent is Directive ||
					item.Parent is ComponentDirective ||
					item.Parent is MaintenanceDirective)
				{
					if (item.Parent.LastPerformance != null)
					{
						countRecords = item.Parent.LastPerformance.PerformanceNum <= 0 ? 1 : item.Parent.LastPerformance.PerformanceNum;
						record.FromRecordId = item.Parent.LastPerformance.ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}
				else if (item.Parent is Entities.General.Accessory.Component)
				{
					Entities.General.Accessory.Component dir = (Entities.General.Accessory.Component)item.Parent;
					if (dir.TransferRecords.GetLast() != null)
					{
						countRecords = dir.TransferRecords.GetLast().PerformanceNum <= 0 ? 1 : dir.TransferRecords.GetLast().PerformanceNum;
						record.FromRecordId = dir.TransferRecords.GetLast().ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}
				else if (item.Parent is MaintenanceCheck)
				{
					//MaintenanceNextPerformance содержит, как правило, группу чеков
					//поэтому добавление чеков из этой группы будет полностью производится 
					//в рамках данного блока кода
					var dir = (MaintenanceCheck)item.Parent;
					if (dir.Grouping)
					{
						var mnp = dir.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault();
						if (mnp == null) throw new NullReferenceException("отсутствует первое выполнене у MaintenanceCheck");
						foreach (MaintenanceCheck check in mnp.PerformanceGroup.Checks)
						{
							//performanceNum = check.NextPerformances.IndexOf(
							//    check.NextPerformances.Cast<MaintenanceNextPerformance>()
							//                          .Where(p => p.PerformanceGroupNum == mnp.PerformanceGroupNum)
							//                          .First()) + 1;
							performanceNum = mnp.PerformanceNum;
							var maintRecord = new WorkPackageRecord
							{
								WorkPackageItemType = check.SmartCoreObjectType.ItemId,
								DirectiveId = check.ItemId,
								Task = check,
								PerformanceNumFromStart = mnp.PerformanceGroupNum,
								PerformanceNumFromRecord = performanceNum,
								FromRecordId = check.LastPerformance != null
												   ? check.LastPerformance.ItemId
												   : -1,
							};
							addToWP.WorkPakageRecords.Add(maintRecord);
						}

						if (addToWP.Description != "") addToWP.Description += "; ";
						addToWP.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));

						continue;
					}
					if (item.Parent.LastPerformance != null)
					{
						countRecords = item.Parent.LastPerformance.PerformanceNum <= 0 ? 1 : item.Parent.LastPerformance.PerformanceNum;
						record.FromRecordId = item.Parent.LastPerformance.ItemId;
					}
					else
					{
						countRecords = 0;
					}
				}

				record.WorkPackageItemType = item.Parent.SmartCoreObjectType.ItemId;
				record.DirectiveId = item.Parent.ItemId;
				record.Task = item.Parent;
				//record.PerformanceNumFromStart = countRecords + performanceNum;
				//record.PerformanceNumFromRecord = performanceNum;
				record.PerformanceNumFromStart = performanceNum;
				record.PerformanceNumFromRecord = performanceNum - countRecords;

				record.Group = item.Group;
				record.ParentCheckId = item.ParentCheck?.ItemId ?? -1;


				addToWP.WorkPakageRecords.Add(record);

				if (addToWP.Description != "") addToWP.Description += "; ";
				addToWP.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));
			}
			#endregion

			#region Сохранение рабочего пакета и его записей

			foreach (var item in addToWP.WorkPakageRecords.Where(wpr => wpr.ItemId <= 0))
			{
				item.WorkPakageId = addToWP.ItemId;
				item.WorkPackage = addToWP;
				_newKeeper.Save(item);
			}

			message = "Items added successfully";

			#endregion

			return true;
		}
		#endregion

		#region public bool AddToWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, int workPackageId, Aircraft parentAircraft,out string message)
		/// <summary>
		/// Добавление элементов в существующий открытый или опубликованный рабочий пакет
		/// </summary>
		/// <param name="nonRoutine"></param>
		/// <param name="workPackageId"></param>
		/// <param name="parentAircraft"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public bool AddToWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, int workPackageId, Aircraft parentAircraft, out string message)
		{
			if (nonRoutine == null || parentAircraft == null || workPackageId <= 0)
				throw new NullReferenceException("1504: NullReferenceException");

			#region Проверка состояния рабочего пакета

			var addToWP = _newLoader.GetObject<WorkPackageDTO, WorkPackage>(new Filter("ItemId", workPackageId), getDeleted: true);

			if (addToWP == null)
			{
				message = "Work Package with id: " + workPackageId + " does not exist." +
						  "\nFailed to add items to work package";
				return false;
			}

			if (addToWP.IsDeleted)
			{
				message = "Work Package: " + addToWP.Title + " is deleted." +
						  "\nFailed to add items to deleted work package";
				return false;
			}

			if (addToWP.Status == WorkPackageStatus.Closed)
			{
				message = "Work Package: " + addToWP.Title + " is Closed." +
						  "\nFailed to add items to closed work package";
				return false;
			}

			#endregion

			var openPubWorkPackages = new CommonCollection<WorkPackage>();
			openPubWorkPackages.Clear();
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Opened, true));
			openPubWorkPackages.AddRange(getWorkPackages(parentAircraft, WorkPackageStatus.Published,
				true));

			foreach (var n in nonRoutine)
			{
				var openPubWpRecords =
				openPubWorkPackages.Where(wp => wp.ItemId == workPackageId)
					.SelectMany(wp => wp.WorkPakageRecords)
					.Where(packageRecord => packageRecord.DirectiveId == n.ItemId)
					.ToList();

				//Проверка добавлен ли NRJ в WorkPackage
				if (!openPubWpRecords.Any())
				{
					var record = new WorkPackageRecord
					{
						WorkPackageItemType = n.SmartCoreObjectType.ItemId,
						DirectiveId = n.ItemId,
						Task = n
					};

					addToWP.WorkPakageRecords.Add(record);

				}
			}



			#region Сохранение рабочего пакета и его записей

			foreach (var item in addToWP.WorkPakageRecords.Where(wpr => wpr.ItemId <= 0))
			{
				item.WorkPakageId = addToWP.ItemId;
				item.WorkPackage = addToWP;
				_newKeeper.Save(item);
			}

			message = "Items added successfully";

			#endregion

			return true;
		}

		#endregion

		#region public void DeleteFromWorkPackage(int workPackageId, IEnumerable<IBaseEntityObject> recordsToDelete)
		/// <summary>
		/// Удаляет запись из рабочего пакета
		/// </summary>
		/// <param name="workPackageId"></param>
		/// <param name="recordsToDelete"></param>
		public void DeleteFromWorkPackage(int workPackageId, IEnumerable<IBaseEntityObject> recordsToDelete)
		{
			_workPackageRecordsDataAccess.DeleteFromWorkPackage(workPackageId, recordsToDelete);
		}
		#endregion

		#region private void ConnectRecordsWithComponentDirectives(ICommonCollection<ComponentDirective> componentDirectives, IEnumerable<DirectiveRecord> records)

		/// <summary>
		/// Связывает записи о выполнении работ по директивам с работами по директивам
		/// </summary>
		/// <param name="componentDirectives"></param>
		/// <param name="records"></param>
		private void ConnectRecordsWithComponentDirectives(IList<ComponentDirective> componentDirectives,
														IEnumerable<DirectiveRecord> records)
		{
			// обнуляем коллекции от уже существующих записей
			foreach (var componentDirective in componentDirectives)
				componentDirective.PerformanceRecords = new BaseRecordCollection<DirectiveRecord>();

			// пробегаем по всем записям и добавляем их в соответствующие директивы
			foreach (var record in records)
			{
				var componentDirective = componentDirectives.GetItemById(record.ParentId);
				if (componentDirective != null)
				{
					componentDirective.PerformanceRecords.Add(record);
					record.Parent = componentDirective;
				}
			}
		}

		#endregion

		#region private void ConnectRecordsWithDirectives(ICommonCollection<Directive> directives, IEnumerable<DirectiveRecord> records)
		/// <summary>
		/// Связывает записи о выполнении работ по директивам с работами по директивам
		/// </summary>
		/// <param name="directives"></param>
		/// <param name="records"></param>
		private void ConnectRecordsWithDirectives(ICommonCollection<Directive> directives, IEnumerable<DirectiveRecord> records)
		{
			// обнуляем коллекции от уже существующих записей
			foreach (var directive in directives)
				directive.PerformanceRecords = new BaseRecordCollection<DirectiveRecord>();

			// пробегаем по всем записям и добавляем их в соответствующие директивы
			foreach (var record in records)
			{
				var directive = directives.GetItemById(record.ParentId);
				if (directive != null)
				{
					directive.PerformanceRecords.Add(record);
					record.Parent = directive;
				}
			}
		}

		#endregion

		#region private List<WorkPackage> getWorkPackages(Aircraft aircraft = null, WorkPackageStatus status = WorkPackageStatus.All, bool isLoadWorkPackageItems = false)

		/// <summary>
		/// Возвращает рабочие пакеты воздушного судна
		/// </summary>
		/// <param name="aircraft">Воздушное судно. При пережаче null вернет все рабочие пакеты</param>
		/// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="LoadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
		/// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		private List<WorkPackage> getWorkPackages(Aircraft aircraft = null,
												 WorkPackageStatus status = WorkPackageStatus.All,
												 bool LoadWorkPackageItems = false,
												 IList<IDirective> includedTasks = null)
		{
			var qr = BaseQueries.GetSelectQueryWithWhere<WorkPackage>(loadChild: true);
			if (aircraft != null)
				qr += " and ParentId = " + aircraft.ItemId;
			if (status != WorkPackageStatus.All)
				qr += " and Status = " + (Int16)status;
			if (includedTasks != null)
			{
				var filterString = "";
				if (includedTasks.Count == 0)
				{
					filterString += "(WorkPackageItemType = 0 and DirectivesId in (0))";
				}
				else
				{
					var subs = new Dictionary<int, string>();
					foreach (var task in includedTasks)
					{
						if (subs.ContainsKey(task.SmartCoreObjectType.ItemId))
						{
							var s = subs[task.SmartCoreObjectType.ItemId];
							if (s != "")
								s += ", ";

							s += task.ItemId;
							subs[task.SmartCoreObjectType.ItemId] = s;
						}
						else subs.Add(task.SmartCoreObjectType.ItemId, task.ItemId.ToString(CultureInfo.InvariantCulture));
					}

					filterString = "";
					foreach (var sub in subs)
					{
						if (filterString != "") filterString += "\n or";
						filterString += $"(WorkPackageItemType = {sub.Key} and DirectivesId in ({sub.Value}))";
					}
				}
				qr += $@" and WorkPackages.itemId in (select WorkPakageId from dbo.Cas3WorkPakageRecord where isDeleted = 0 and ({
						filterString}))";
			}
			var ds = _casEnvironment.Execute(qr);
			var wps = BaseQueries.GetObjectList<WorkPackage>(ds.Tables[0], true);

			if (wps.Count == 0)
				return wps;

			var wpIds = wps.Select(w => w.ItemId).ToList();
			var filesDict = _filesDataAccess.GetItemFileLinks(wpIds, SmartCoreType.WorkPackage.ItemId).ToDictionary(i => i.ParentId);

			var documents = _newLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ParentTypeId", SmartCoreType.WorkPackage.ItemId), true);

			foreach (var wp in wps)
			{
				wp.ClosingDocument.AddRange(documents.Where(d => d.ParentId == wp.ItemId));

				//Обратная ссылка на родительский самолет
				wp.Aircraft = _aircraftsCore.GetAircraftById(wp.ParentId);

				if(filesDict.ContainsKey(wp.ItemId))
					wp.Files.Add(filesDict[wp.ItemId]);

				//загрузка элементов рабочих пакетов (если требуется)
				if (LoadWorkPackageItems)
					loadWorkPackageItems(wp);
			}
			return wps;
		}

		#endregion

		#region private void loadWorkPackageItems(WorkPackage workPackage)

		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="workPackage"></param>
		private void loadWorkPackageItems(WorkPackage workPackage)
		{
			workPackage.CanPublish = workPackage.CanClose = true;
			workPackage.BlockPublishReason = "";
			workPackage.MinClosingDate = null;
			workPackage.MaxClosingDate = null;
			// Компоненты
			workPackage.WorkPakageRecords.Clear();
			workPackage.WorkPakageRecords.AddRange(GetWorkPackageRecords(workPackage, true, false));

			workPackage.MaintenanceCheckBindTaskRecords.Clear();
			workPackage.MaintenanceCheckBindTaskRecords.AddRange(GetMaintenanceBingTasksRecords(workPackage.ItemId));

			foreach (var record in workPackage.MaintenanceCheckBindTaskRecords)
				record.ParentCheck = workPackage.MaintenanceChecks.FirstOrDefault(mc => mc.ItemId == record.CheckId);

			// ставим флаг о том, что все элементы рабочего пакета считаны
			workPackage.WorkPackageItemsLoaded = true;
		}

		#endregion
	}
}