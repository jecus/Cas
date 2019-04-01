using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.Queries;
using SmartCore.RegisterPerformances;

namespace SmartCore.Audits
{
	public class AuditCore :IAuditCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly INewLoader _newLoader;
		private readonly INewKeeper _newKeeper;
		private readonly ICalculator _calculator;
		private readonly IPerformanceCalculator _performanceCalculator;
		private readonly IPerformanceCore _performanceCore;

		private ILoader _loader;
		//TODO:(Evgenii Babak) мы не должно использовать DataBaseManager в core напрямую, это должно делаться через Loader

		//TODO:(Evgenii Babak) Убрать использование CasEnviroment после того как введем полноценных пользователей и ролей
		public AuditCore(ICasEnvironment casEnvironment, ILoader loader, INewLoader newLoader,
						 INewKeeper newKeeper, ICalculator calculator,IPerformanceCalculator performanceCalculator,
						 IPerformanceCore performanceCore)
		{
			_casEnvironment = casEnvironment;
			_loader = loader;
			_newLoader = newLoader;
			_newKeeper = newKeeper;
			_calculator = calculator;
			_performanceCalculator = performanceCalculator;
			_performanceCore = performanceCore;
		}

		#region public List<Audit> GetAudits(Operator op = null, WorkPackageStatus status = WorkPackageStatus.All, bool loadWorkPackageItems = false)

		/// <summary>
		/// Возвращает рабочие пакеты воздушного судна
		/// </summary>
		/// <param name="op">Оператор. При пережаче null вернет все рабочие пакеты</param>
		/// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
		/// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		public List<Audit> GetAudits(Operator op = null,
									 WorkPackageStatus status = WorkPackageStatus.All,
									 bool loadWorkPackageItems = false,
									 ICommonCollection includedTasks = null)
		{
			var filters = new List<ICommonFilter>();

			if (op != null)
				filters.Add(new CommonFilter<int>(Audit.ParentTypeIdProperty, op.ItemId));
			if (status != WorkPackageStatus.All)
				filters.Add(new CommonFilter<int>(Audit.StatusProperty, (int)status));
			if (includedTasks != null)
			{
				var filterString = "";
				if (includedTasks.Count == 0)
					filterString += "(AuditItemTypeId = 0 and DirectivesId in (0))";
				else
				{
					var subs = new Dictionary<int, string>();
					foreach (BaseEntityObject task in includedTasks)
					{
						if (subs.ContainsKey(task.SmartCoreObjectType.ItemId))
						{
							var s = subs[task.SmartCoreObjectType.ItemId];
							if (s != "")
								s += ", ";

							s += task.ItemId;
							subs[task.SmartCoreObjectType.ItemId] = s;
						}
						else subs.Add(task.SmartCoreObjectType.ItemId, task.ItemId.ToString());
					}

					filterString = "";
					foreach (var sub in subs)
					{
						if (filterString != "") filterString += "\n or";
						filterString += $"(AuditItemTypeId = {sub.Key} and DirectivesId in ({sub.Value}))";
					}
				}

				var auditRecordIn = $"{BaseQueries.GetSelectQueryColumnOnly<AuditRecord>(AuditRecord.AuditIdProperty)} and {filterString}";
				filters.Add(new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] { auditRecordIn }));
			}

			var wps = _loader.GetObjectListAll<Audit>(filters.ToArray(), true);

			foreach (var wp in wps)
			{
				//Обратная ссылка на родительский самолет
				wp.Operator = op;
				//загрузка элементов рабочих пакетов (если требуется)
				if (loadWorkPackageItems)
					LoadAuditItems(wp);
			}
			return wps;
		}

		#endregion

		#region public List<Audit> GetAuditsLite(Operator op, WorkPackageStatus status = WorkPackageStatus.All, ICommonCollection includedTasks = null)

		/// <summary>
		/// Возвращает аудиты оператора (Для аудитов грузятся только записи о включенных в них задачах)
		/// </summary>
		/// <param name="op">Воздушное судно. При пережаче null вернет все рабочие пакеты</param>
		/// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		public List<Audit> GetAuditsLite(Operator op,
										 WorkPackageStatus status = WorkPackageStatus.All,
										 ICommonCollection includedTasks = null)
		{
			var filters = new List<ICommonFilter>();

			if (op != null)
				filters.Add(new CommonFilter<int>(Audit.ParentTypeIdProperty, op.ItemId));
			if (status != WorkPackageStatus.All)
				filters.Add(new CommonFilter<int>(Audit.StatusProperty, (int)status));
			if (includedTasks != null)
			{
				var filterString = "";
				if (includedTasks.Count == 0)
					filterString += "(AuditItemTypeId = 0 and DirectivesId in (0))";
				else
				{
					var subs = new Dictionary<int, string>();
					foreach (BaseEntityObject task in includedTasks)
					{
						if (subs.ContainsKey(task.SmartCoreObjectType.ItemId))
						{
							var s = subs[task.SmartCoreObjectType.ItemId];
							if (s != "")
								s += ", ";

							s += task.ItemId;
							subs[task.SmartCoreObjectType.ItemId] = s;
						}
						else subs.Add(task.SmartCoreObjectType.ItemId, task.ItemId.ToString());
					}

					filterString = "";
					foreach (var sub in subs)
					{
						if (filterString != "") filterString += "\n or";
						filterString += $"(AuditItemTypeId = {sub.Key} and DirectivesId in ({sub.Value}))";
					}
				}

				var auditRecordIn =$"{BaseQueries.GetSelectQueryColumnOnly<AuditRecord>(AuditRecord.AuditIdProperty)} and {filterString}";
				filters.Add(new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] { auditRecordIn }));
			}

			var wps = _loader.GetObjectListAll<Audit>(filters.ToArray(), true);

			if (wps.Count == 0)
				return wps;
			int[] wpIds = wps.Select(wp => wp.ItemId).ToArray();

			var wprs = _newLoader.GetObjectList<AuditRecordDTO, AuditRecord>(new Filter("AuditId", wpIds));

			foreach (var audit in wps)
			{
				audit.Operator = op;

				var curWpRecords = wprs.Where(r => r.AuditId == audit.ItemId);
				foreach (var curWpRecord in curWpRecords)
					curWpRecord.Audit = audit;

				audit.AuditRecords.Clear();
				audit.AuditRecords.AddRange(curWpRecords);
			}

			return wps;
		}

		#endregion

		#region public void LoadAuditItems(Audit audit)

		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="audit"></param>
		public void LoadAuditItems(Audit audit)
		{
			audit.CanPublish = audit.CanClose = true;
			audit.BlockPublishReason = "";
			audit.MinClosingDate = null;
			audit.MaxClosingDate = null;
			// Компоненты
			audit.AuditRecords.Clear();


			audit.AuditRecords.AddRange(_newLoader.GetObjectList<AuditRecordDTO, AuditRecord>(new Filter("AuditId", audit.ItemId)));

			foreach (var record in audit.AuditRecords)
				record.Audit = audit;


			#region загрузка процедур

			var adWprs = audit.AuditRecords.Where(w => w.AuditItemTypeId == SmartCoreType.Procedure.ItemId).ToList();
			if (adWprs.Count > 0)
			{
				var ids = adWprs.Select(wpr => wpr.DirectiveId);
				var directiveCollection = new CommonCollection<Procedure>(_newLoader.GetObjectListAll<ProcedureDTO, Procedure>(new Filter("ItemId", ids), true, true));

				if (directiveCollection.Count > 0)
				{
					foreach (var adWpr in adWprs)
					{
						var d = directiveCollection.GetItemById(adWpr.DirectiveId);
						if (d != null)
							adWpr.Task = d;
						else audit.AuditRecords.RemoveById(adWpr.ItemId);
					}
				}

				directiveCollection.Clear();
			}

			#endregion

			// ставим флаг о том, что все элементы рабочего пакета считаны
			audit.AuditItemsLoaded = true;
		}

		#endregion

		#region public Audit AddAudit(IEnumerable<NextPerformance> auditItems, Operator parentOperator, out string message)

		/// <summary>
		/// Создание Рабочего пакета
		/// </summary>
		/// <param name="auditItems"></param>
		/// <param name="parentOperator"></param>
		/// <param name="message"></param>
		public Audit AddAudit(IEnumerable<NextPerformance> auditItems, Operator parentOperator, out string message)
		{
			if (auditItems == null || parentOperator == null)
			{
				throw new NullReferenceException("1504: NullReferenceException");
			}

			#region Проверка Переданных элементов для формирования рабочего пакета

			if (auditItems.Count() == 0)
			{
				message = "Selected tasks not have a performances." +
						  "\nFailed to create empty Audit";
				return null;
			}

			var openPubWorkPackages = new CommonCollection<Audit>();
			openPubWorkPackages.Clear();
			openPubWorkPackages.AddRange(GetAudits(parentOperator, WorkPackageStatus.Opened, true));
			openPubWorkPackages.AddRange(GetAudits(parentOperator, WorkPackageStatus.Published, true));

			//1.есть ли в выбранных элементах 2 и более выполнения одной задачи
			//2.есть ли в выбранных элементах, элементы, блокированные рабочими пакетами
			//3.есть ли в выбранных элементах 2-е и последующее выполнения по замене детали
			//4.есть ли в выбранных элементах выполнения с разными датами
			//5.есть ли в выбранных элементах выполнения, перекрещающиеся с выполнениями в других рабочих пакетах

			bool blockedBy = false;
			bool crossPerformances = false;
			bool dateMultiply = false;
			bool invalidComponentExcange = false;
			bool multiply = false;
			string blockingWorkPackage = "";
			string errorTaskDescription = "";

			foreach (var o in auditItems)
			{
				if (o.BlockedByPackage != null)
				{
					//Выбранное выполнение блокировано другим рабочим рабочим пакетом
					errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
					blockingWorkPackage = o.BlockedByPackage.Title;
					blockedBy = true;
					break;
				}
				if (auditItems.Count(i => i.Parent == o.Parent) > 1)
				{
					//если объект является след. выполнением
					//и в выбранных элементах есть "Выполнения" имеющие того же родителя
					//(т.е. выбрано 2 выполнения одного родителя)
					errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
					multiply = true;
					break;
				}
				if (o.PerformanceDate.HasValue &&
					auditItems.FirstOrDefault(i => i.PerformanceDate.HasValue &&
														 i.PerformanceDate.Value.Date != o.PerformanceDate.Value.Date) != null)
				{
					var np =
						auditItems.First(i => i.PerformanceDate != o.PerformanceDate);
					//если объект является след. выполнением
					//и в выбранных элементах есть "Выполнения" имеющие другую дату выполнения
					//(т.е. выбрано 2 выполнения одного родителя)
					errorTaskDescription = string.Format("{0} \n{1} \nperformance date:{2} and \n{3} \n{4} \nperformance date:{5}",
														   o.Title, o.WorkType,
														   Auxiliary.Convert.GetDateFormat((DateTime)o.PerformanceDate),
														   np.Title, np.WorkType,
														   np.PerformanceDate == null
														   ? "N/A" : Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate));
					dateMultiply = true;
					break;
				}
				if (o.Parent is Entities.General.Accessory.Component)
				{
					var det = (Entities.General.Accessory.Component)o.Parent;
					if (det.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали  
						errorTaskDescription = string.Format("{0} {1} {2}", o.Title, o.Description, o.WorkType);
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
						errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
						invalidComponentExcange = true;
						break;
					}
				}
			}

			var dictionary = new Dictionary<AuditRecord, NextPerformance>();
			foreach (var workPackage in openPubWorkPackages)
			{
				dictionary.Clear();

				foreach (var nextPerformance in auditItems)
				{
					var p = (BaseEntityObject)nextPerformance.Parent;
					var record =
						workPackage.AuditRecords.FirstOrDefault(wpr => wpr.DirectiveId == p.ItemId &&
																	   wpr.AuditItemTypeId == p.SmartCoreObjectType.ItemId);
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
						leftTask = string.Format("{0} {1}", np.Title, np.WorkType);
						leftPerfNum1 = wpr.PerformanceNumFromStart;
						leftPerfNum2 = np.PerformanceNum;
					}
					if (wpr.PerformanceNumFromStart < perfNum)
					{
						rigth = true;
						rigthTask = string.Format("{0} {1}", np.Title, np.WorkType);
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
					errorTaskDescription = string.Format(@"2 or more tasks for selected performances are in the audit:
                                                           \n{0} 
                                                           \nthe task {1} has the number of performance:{2}, 
                                                           \nbut in the selected items has performance:{3}.
                                                           \nthe task {4} has the number of performance:{5}, 
                                                           \nbut in the selected items has performance:{6}.",
														   workPackage.Title,
														   leftTask, leftPerfNum1, leftPerfNum2,
														   rigthTask, rightPerfNum1, rightPerfNum2);
					crossPerformances = true;
					break;
				}
			}

			if (blockedBy)
			{
				message = "Perform of the task:" +
						  "\n" + errorTaskDescription +
						  "\nblocked by Audit:" +
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
				message = "A Audit can only put the first performance" +
						  "\nof the task of replacing component." +
						  "\nTask:" + errorTaskDescription;
				return null;
			}
			if (multiply)
			{
				message = "You can not put two and more perform a task:" +
						  "\n" + errorTaskDescription +
						  "\nin a one Audit!";
				return null;
			}
			#endregion

			#region Формирование Рабочего пакета

			#region Номер и ревизия

			var lastWP =
				GetAudits(parentOperator)
					.OrderByDescending(w => w.OpeningDate)
					.FirstOrDefault();

			string revision = lastWP != null ? lastWP.Revision : "";
			string lastNumberString = "";
			int lastNumber;
			string curNumberString;
			if (lastWP != null)
			{
				for (int i = lastWP.Number.Length - 1; i >= 0; i--)
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

			//Добавление в название присутствующих директив летной годности
			var adPerformances = auditItems.Where(np => np.Parent != null && np.Parent is Procedure);
			if (adPerformances.Any())
			{
				if (titleString != "")
					titleString += " + ";
				titleString += "Procedure";
			}

			if (titleString == "")
			{
				titleString = auditItems.First().Title;
			}


			#endregion

			var wp = new Audit
			{
				Description = "",
				Status = WorkPackageStatus.Opened,
				Author = _casEnvironment.IdentityUser.Login,
				CreateDate = DateTime.Now,
				OpeningDate = DateTime.Today,
				PublishingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = DateTimeExtend.GetCASMinDateTime(),
				ClosingRemarks = "",
				Operator = parentOperator,
				ParentId = parentOperator.ItemId,
#if KAC
                Number = parentOperator.Name + "-AU-" + DateTime.Now,
#else
				Number = parentOperator.Name + "-AU-" + DateTime.Now,
#endif
				Title = titleString,
				Revision = revision
			};
			#endregion

			#region Формирование записей рабочего пакета
			foreach (var item in auditItems)
			{
				int performanceNum;
				int countRecords = 0;
				AuditRecord record = new AuditRecord();

				//performanceNum = item.Parent.NextPerformances.IndexOf(item) + 1;
				performanceNum = item.PerformanceNum;
				if (item.Parent is Procedure ||
					item.Parent is Directive ||
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

				record.AuditItemTypeId = item.Parent.SmartCoreObjectType.ItemId;
				record.DirectiveId = item.Parent.ItemId;
				record.Task = item.Parent;
				//record.PerformanceNumFromStart = countRecords + performanceNum;
				//record.PerformanceNumFromRecord = performanceNum;
				record.PerformanceNumFromStart = performanceNum;
				record.PerformanceNumFromRecord = performanceNum - countRecords;

				wp.AuditRecords.Add(record);

				if (wp.Description != "") wp.Description += "; ";
				wp.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));
			}
			#endregion

			#region Сохранение рабочего пакета и его записей

			_newKeeper.Save(wp);
			message = "Audit created successfull";

			foreach (var item in wp.AuditRecords)
			{
				item.AuditId = wp.ItemId;
				item.Audit = wp;
				_newKeeper.Save(item);
			}

			#endregion

			return wp;
		}
		#endregion

		#region public bool AddToAudit(List<NextPerformance> auditItems, int auditId, out string message)

		/// <summary>
		/// Добавление элементов в существующий открытый или опубликованный рабочий пакет
		/// </summary>
		/// <param name="workPackageItems">Элементы, которые необходимо добавить</param>
		/// <param name="auditId">ID рабочего пакета, в который добавляютя элементы</param>
		/// <param name="parentOperator">Опреатор, которому должен пренадлежать рабочий пакет</param>
		/// <param name="message">Сообщение о статусе добавления-корректно или описание ошибки при добавлении</param>
		/// <return>true - если добавление прошло успешно или false в случае провала </return>
		public bool AddToAudit(List<NextPerformance> workPackageItems, int auditId, Operator parentOperator, out string message)
		{
			if (workPackageItems == null || parentOperator == null || auditId <= 0)
			{
				throw new NullReferenceException("1504: NullReferenceException");
			}

			#region Проверка состояния рабочего пакета

			var addToWP = _newLoader.GetObject<AuditDTO, Audit>(new Filter("ItemId", auditId), getDeleted: true);

			if (addToWP == null)
			{
				message = "Audit with id: " + auditId + " does not exist." +
				"\nFailed to add items to audit";
				return false;
			}

			if (addToWP.IsDeleted)
			{
				message = "Audit: " + addToWP.Title + " is deleted." +
						  "\nFailed to add items to deleted audit";
				return false;
			}

			if (addToWP.Status == WorkPackageStatus.Closed)
			{
				message = "Audit: " + addToWP.Title + " is Closed." +
						  "\nFailed to add items to closed audit";
				return false;
			}

			#endregion

			#region Проверка Переданных элементов для формирования рабочего пакета)

			if (!workPackageItems.Any())
			{
				message = "Selected tasks not have a performances." +
						  "\nFailed to add items to audit";
				return false;
			}

			var openPubWorkPackages = new CommonCollection<Audit>();
			openPubWorkPackages.Clear();
			openPubWorkPackages.AddRange(GetAudits(parentOperator, WorkPackageStatus.Opened, true));
			openPubWorkPackages.AddRange(GetAudits(parentOperator, WorkPackageStatus.Published, true));

			var openPubWpRecords = openPubWorkPackages.SelectMany(wp => wp.AuditRecords).ToArray();
			var includedInWp = openPubWpRecords
				.Where(rec => rec.AuditId == auditId)
				.Select(record => workPackageItems.FirstOrDefault(wpr => wpr.Parent is MaintenanceDirective &&
																		 record.Task is MaintenanceDirective &&
																		 wpr.Parent.ItemId == record.Task.ItemId))
				.Where(np => np != null)
				.ToList();
			foreach (var nextPerformance in includedInWp)
			{
				workPackageItems.Remove(nextPerformance);
			}
			//1.есть ли в выбранных элементах 2 и более выполнения одной задачи
			//2.есть ли в выбранных элементах, элементы, блокированные рабочими пакетами
			//3.есть ли в выбранных элементах 2-е и последующее выполнения по замене детали
			//4.есть ли в выбранных элементах выполнения с разными датами
			//5.есть ли в выбранных элементах выполнения, перекрещающиеся с выполнениями в других рабочих пакетах

			bool blockedBy = false;
			bool crossPerformances = false;
			//bool dateMultiply = false;
			bool invalidComponentExcange = false;
			bool multiply = false;
			string blockingWorkPackage = "";
			string errorTaskDescription = "";

			foreach (var o in workPackageItems)
			{
				if (o.BlockedByPackage != null)
				{
					//Выбранное выполнение блокировано другим рабочим рабочим пакетом
					errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
					blockingWorkPackage = o.BlockedByPackage.Title;
					blockedBy = true;
					break;
				}
				if (workPackageItems.Count(i => i.Parent == o.Parent) > 1 ||
					openPubWpRecords.Count(wpr => wpr.Task != null &&
												  wpr.Task.SmartCoreObjectType == o.Parent.SmartCoreObjectType &&
												  wpr.Task.ItemId == o.Parent.ItemId &&
												  wpr.Audit.ItemId == auditId) > 0)
				{
					//если объект является след. выполнением
					//и в выбранных элементах есть "Выполнения" имеющие того же родителя
					//(т.е. выбрано 2 выполнения одного родителя)
					errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
					multiply = true;
					break;
				}
				//if (o.PerformanceDate.HasValue &&
				//    ( auditItems.Count(i => i.PerformanceDate.HasValue &&
				//                                  i.PerformanceDate.Value.Date != o.PerformanceDate.Value.Date) > 0 ||
				//      openPubWpRecords.Count(wpr => wpr.Task != null && wpr.Task.NextPerformances.Count > 0 &&
				//                                    wpr.Task.NextPerformances[0].PerformanceDate.HasValue &&
				//                                    wpr.Task.NextPerformances[0].PerformanceDate.Value.Date != o.PerformanceDate.Value.Date) > 0))
				//{
				//    NextPerformance np =
				//        auditItems.Where(i => i.PerformanceDate != o.PerformanceDate).First();
				//    //если объект является след. выполнением
				//    //и в выбранных элементах есть "Выполнения" имеющие другую дату выполнения
				//    //(т.е. выбрано 2 выполнения одного родителя)
				//    errorTaskDescription = string.Format("{0} \n{1} \nperformance date:{2} and \n{3} \n{4} \nperformance date:{5}",
				//                                           o.Title, o.WorkType,
				//                                           SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)o.PerformanceDate),
				//                                           np.Title, np.WorkType,
				//                                           np.PerformanceDate == null
				//                                           ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate));
				//    dateMultiply = true;
				//    break;
				//}
				if (o.Parent is Entities.General.Accessory.Component)
				{
					Entities.General.Accessory.Component det = (Entities.General.Accessory.Component)o.Parent;
					if (det.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали  
						errorTaskDescription = string.Format("{0} {1} {2}", o.Title, o.Description, o.WorkType);
						invalidComponentExcange = true;
						break;
					}
				}
				if (o.Parent is ComponentDirective)
				{
					ComponentDirective detDir = (ComponentDirective)o.Parent;
					if (detDir.DirectiveTypeId == ComponentRecordType.Overhaul.ItemId && detDir.NextPerformances.IndexOf(o) > 0)
					{
						//если взято не ПЕРВОЕ выполнение по замене детали 
						errorTaskDescription = string.Format("{0} {1}", o.Title, o.WorkType);
						invalidComponentExcange = true;
						break;
					}
				}
			}

			var dictionary =
				new Dictionary<AuditRecord, NextPerformance>();
			foreach (Audit workPackage in openPubWorkPackages)
			{
				dictionary.Clear();

				foreach (var nextPerformance in workPackageItems)
				{
					var p = (BaseEntityObject)nextPerformance.Parent;
					var record =
						workPackage.AuditRecords.FirstOrDefault(wpr => wpr.DirectiveId == p.ItemId &&
																	   wpr.AuditItemTypeId == p.SmartCoreObjectType.ItemId);
					if (record != null)
					{
						dictionary.Add(record, nextPerformance);
					}
				}

				bool left = false, rigth = false;
				string leftTask = "", rigthTask = "";
				int leftPerfNum1 = 0, leftPerfNum2 = 0, rightPerfNum1 = 0, rightPerfNum2 = 0;
				foreach (KeyValuePair<AuditRecord, NextPerformance> pair in dictionary)
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
						leftTask = string.Format("{0} {1}", np.Title, np.WorkType);
						leftPerfNum1 = wpr.PerformanceNumFromStart;
						leftPerfNum2 = np.PerformanceNum;
					}
					if (wpr.PerformanceNumFromStart < perfNum)
					{
						rigth = true;
						rigthTask = string.Format("{0} {1}", np.Title, np.WorkType);
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
					errorTaskDescription = string.Format("2 or more tasks for selected performances are in the work package:" +
														 "\n{0}" +
														 "\nthe task {1} has the number of performance:{2}," +
														 "\nbut in the selected items has performance:{3}." +
														 "\nthe task {4} has the number of performance:{5}," +
														 "\nbut in the selected items has performance:{6}.",
														   workPackage.Title,
														   leftTask, leftPerfNum1, leftPerfNum2,
														   rigthTask, rightPerfNum1, rightPerfNum2);
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
				AuditRecord record = new AuditRecord();

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
						var maintRecord = new AuditRecord
						{
							AuditItemTypeId = check.SmartCoreObjectType.ItemId,
							DirectiveId = check.ItemId,
							Task = check,
							PerformanceNumFromStart = mnp.PerformanceGroupNum,
							PerformanceNumFromRecord = performanceNum,
							FromRecordId = check.LastPerformance != null
											   ? check.LastPerformance.ItemId
											   : -1,
						};
						addToWP.AuditRecords.Add(maintRecord);
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
						foreach (var check in mnp.PerformanceGroup.Checks)
						{
							//performanceNum = check.NextPerformances.IndexOf(
							//    check.NextPerformances.Cast<MaintenanceNextPerformance>()
							//                          .Where(p => p.PerformanceGroupNum == mnp.PerformanceGroupNum)
							//                          .First()) + 1;
							performanceNum = mnp.PerformanceNum;
							var maintRecord = new AuditRecord
							{
								AuditItemTypeId = check.SmartCoreObjectType.ItemId,
								DirectiveId = check.ItemId,
								Task = check,
								PerformanceNumFromStart = mnp.PerformanceGroupNum,
								PerformanceNumFromRecord = performanceNum,
								FromRecordId = check.LastPerformance != null
												   ? check.LastPerformance.ItemId
												   : -1,
							};
							addToWP.AuditRecords.Add(maintRecord);
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

				record.AuditItemTypeId = item.Parent.SmartCoreObjectType.ItemId;
				record.DirectiveId = item.Parent.ItemId;
				record.Task = item.Parent;
				//record.PerformanceNumFromStart = countRecords + performanceNum;
				//record.PerformanceNumFromRecord = performanceNum;
				record.PerformanceNumFromStart = performanceNum;
				record.PerformanceNumFromRecord = performanceNum - countRecords;

				addToWP.AuditRecords.Add(record);

				if (addToWP.Description != "") addToWP.Description += "; ";
				addToWP.Description += (item.Title + (item.Description != "" ? " " + item.Description : ""));
			}
			#endregion

			#region Сохранение рабочего пакета и его записей

			foreach (var item in addToWP.AuditRecords.Where(wpr => wpr.ItemId <= 0))
			{
				item.AuditId = addToWP.ItemId;
				item.Audit = addToWP;
				_newKeeper.Save(item);
			}

			message = "Items added successfully";

			#endregion

			return true;
		}
		#endregion

		#region public void GetAuditItemsWithCalculate(Audit audit)
		/// <summary>
		/// загружает элементы рабочего пакета, и производит их калькуляцмю.
		/// </summary>
		/// <param name="audit"></param>
		public void GetAuditItemsWithCalculate(Audit audit)
		{
			LoadAuditItems(audit);

			audit.MaxClosingDate = DateTime.Today;
			audit.MinClosingDate = DateTimeExtend.GetCASMinDateTime();

			foreach (var record in audit.AuditRecords)
			{
				if (record.Task.ItemId < 0)
					continue;

				NextPerformance nextPerformance = null;
				AbstractPerformanceRecord apr = null;

				apr = record.Task.PerformanceRecords
					   .Cast<AbstractPerformanceRecord>()
					   .FirstOrDefault(r => r.DirectivePackageId == audit.ItemId);

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
						apr.PrevPerformanceDate = _calculator.GetStartDate(record.Task); //TODO:(Evgenii Babak) GetStartDate вынести из calculator
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
							NextPerformance np =
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
					IDirective task = record.Task;

					if (!task.IsClosed)
					{
						if (task is Entities.General.Accessory.Component)
							_performanceCalculator.GetPerformance((Entities.General.Accessory.Component)task, record.PerformanceNumFromStart);
						else _performanceCalculator.GetPerformance(task, record.PerformanceNumFromStart);

						nextPerformance =
							task.NextPerformances.FirstOrDefault(np => np.PerformanceNum == record.PerformanceNumFromStart);
					}
				}

				if (nextPerformance != null)
				{
					if (nextPerformance.PrevPerformanceDate != null &&
						audit.MinClosingDate < nextPerformance.PrevPerformanceDate)
						audit.MinClosingDate = nextPerformance.PrevPerformanceDate;
					if (nextPerformance.NextPerformanceDate != null &&
						audit.MaxClosingDate > nextPerformance.NextPerformanceDate)
						audit.MaxClosingDate = nextPerformance.NextPerformanceDate;
				}

				if (apr != null)
				{
					if (apr.PrevPerformanceDate != null && audit.MinClosingDate < apr.PrevPerformanceDate)
						audit.MinClosingDate = apr.PrevPerformanceDate;
					if (apr.NextPerformanceDate != null && audit.MaxClosingDate > apr.NextPerformanceDate)
						audit.MaxClosingDate = apr.NextPerformanceDate;
				}
			}

			if (audit.MaxClosingDate < audit.MinClosingDate)
				audit.CanClose = false;
			var wpItems = new CommonCollection<BaseEntityObject>();
			foreach (AuditRecord record in audit.AuditRecords)
				wpItems.Add((BaseEntityObject)record.Task);
			var relatedWorkPackages = new CommonCollection<Audit>();
			if (audit.Status != WorkPackageStatus.Closed)
			{
				relatedWorkPackages.AddRange(GetAudits(audit.Operator,
																			  WorkPackageStatus.Opened,
																			  true,
																			  wpItems));
				relatedWorkPackages.AddRange(GetAudits(audit.Operator,
																			  WorkPackageStatus.Published,
																			  true,
																			  wpItems));

				//сбор всех записей рабочих пакетов для удобства фильтрации
				var openWPRecords = new List<AuditRecord>();
				foreach (var openWorkPackage in relatedWorkPackages)
					openWPRecords.AddRange(openWorkPackage.AuditRecords);

				foreach (var record in audit.AuditRecords)
				{
					var workPackageRecord =
							openWPRecords.FirstOrDefault(wpr => wpr.AuditId != record.AuditId
															 && wpr.AuditItemTypeId == record.AuditItemTypeId
															 && wpr.DirectiveId == record.DirectiveId
															 && wpr.PerformanceNumFromStart <= record.PerformanceNumFromStart);
					if (workPackageRecord != null)
					{
						//у одной из задач данного рабочего пакета,
						//есть выполнение с меньшим порядковым номером 
						//в другом открытом рабочем пакете
						//поэтому данный рабочий пакет закрыть нельзя
						audit.CanClose = false;
						if (record.Task.NextPerformances.Count > 0)
						{
							record.Task.NextPerformances[0].BlockedByPackage
								= relatedWorkPackages.GetItemById(workPackageRecord.AuditId);
						}
					}
				}
			}
			else
			{
				//При закоытом Рабочем пакете, в список попадают записи о выполении
				//сделанные в рамках данного рабочего пакета
				relatedWorkPackages.AddRange(GetAudits(audit.Operator,
																			  WorkPackageStatus.Closed,
																			  true,
																			  wpItems));
				//сбор всех записей рабочих пакетов для удобства фильтрации
				var closeWPRecords = new List<AuditRecord>();
				foreach (var closedWorkPackage in relatedWorkPackages)
					closeWPRecords.AddRange(closedWorkPackage.AuditRecords);
				foreach (var record in audit.AuditRecords)
				{
					if (closeWPRecords.FirstOrDefault(wpr => wpr.AuditId != record.AuditId
														  && wpr.AuditItemTypeId == record.AuditItemTypeId
														  && wpr.DirectiveId == record.DirectiveId
														  && wpr.PerformanceNumFromStart > record.PerformanceNumFromStart) != null)
					{
						//у одной из задач данного рабочего пакета,
						//есть выполнение с большим порядковым номером 
						//в другом закрытом рабочем пакете
						audit.CanPublish = false;
						audit.BlockPublishReason =
							"From one of the task of this audit," +
							"\nhave the execution of a large atomic number" +
							"\nin other enclosed audit";

					}
				}
			}

			wpItems.Clear();
			relatedWorkPackages.Clear();
		}
		#endregion

		#region public void DeleteFromAudit(IBaseEntityObject record, Audit audit)
		/// <summary>
		/// Удаляет запись из рабочего пакета
		/// </summary>
		/// <param name="record"></param>
		/// <param name="audit"></param>
		public void DeleteFromAudit(IBaseEntityObject record, Audit audit)
		{
			var wpRecord =
				audit.AuditRecords.FirstOrDefault(wpr => wpr.DirectiveId == record.ItemId &&
														 wpr.AuditItemTypeId == record.SmartCoreObjectType.ItemId);
			if (wpRecord == null)
			{
				wpRecord = _newLoader.GetObject<AuditRecordDTO, AuditRecord>(new List<Filter>()
				{
					new Filter("DirectivesId", record.ItemId),
					new Filter("AuditItemTypeId", record.SmartCoreObjectType.ItemId),
					new Filter("AuditId",audit.ItemId)
				});
			}
			if (wpRecord != null)
				_newKeeper.Delete(wpRecord);
		}
		#endregion

		#region public void Publish(Audit audit, DateTime date, String remarks)
		/// <summary>
		/// Публикует рабочий пакет - выдает рабочий пакет на перрон
		/// </summary>
		/// <param name="wp"></param>
		/// <param name="date"></param>
		/// <param name="remarks"></param>
		public void Publish(Audit wp, DateTime date, String remarks)
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
				LoadAuditItems(wp);

				foreach (var item in wp.Procedures)
				{
					var records = new List<DirectiveRecord>(item.PerformanceRecords.ToArray());
					foreach (var record in records)
					{
						if (record.DirectivePackageId == wp.ItemId)
							_performanceCore.Delete(record);
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
	}
}