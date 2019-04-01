using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations.Maintenance
{
	public static class MaintenanceCheckCollectionExtentions
	{
		#region public MaintenanceCheckComplianceGroup GetLastComplianceCheckGroup(bool schedule, int aircraftId, bool grouping = true, LifelengthSubResource resource = LifelengthSubResource.Hours)

		/// <summary>
		/// Возвращает последнюю выполненную группу чеков, чеки которой имеют заданные парамерты
		/// </summary>
		/// <param name="checks"></param>
		/// <param name="schedule">Чеки плановые или по программе хранения</param>
		/// <param name="aircraftId">Родительское ВС чеков</param>
		/// <param name="grouping">Чеки групповые или нет</param>
		/// <param name="resource">По какому из ресурсов (часы, циклы или календарь) группируются чеки</param>
		/// <param name="checkType">Тип чека (A B C D)</param>
		/// <returns></returns>
		public static MaintenanceCheckComplianceGroup GetLastComplianceCheckGroup(this ICommonCollection<MaintenanceCheck> checks,
			bool schedule, int aircraftId,
			bool grouping = true,
			LifelengthSubResource resource = LifelengthSubResource.Hours,
			MaintenanceCheckType checkType = null)
		{
			int last = 0;
			var aircraftScheduleChecks = checks.Where(c => c.Schedule == schedule &&
														   c.ParentAircraftId == aircraftId &&
								                           c.Grouping == grouping &&
								                           c.Resource == resource).ToList();
			if (checkType != null)
				aircraftScheduleChecks = aircraftScheduleChecks.Where(c => c.CheckType == checkType).ToList();

			foreach (MaintenanceCheck checkItem in aircraftScheduleChecks)
				if (checkItem.LastPerformance != null && last < checkItem.LastPerformance.NumGroup)
					last = checkItem.LastPerformance.NumGroup;

			if (last <= 0) return null;

			var lastComplianceGroup = new MaintenanceCheckComplianceGroup(schedule);
			foreach (MaintenanceCheck checkItem in aircraftScheduleChecks)
				if (checkItem.LastPerformance != null && last == checkItem.LastPerformance.NumGroup)
					lastComplianceGroup.Checks.Add(checkItem);

			if (lastComplianceGroup.GetMaxIntervalCheck() == null) return null;
			lastComplianceGroup.Sort();
			return lastComplianceGroup;
		}
		#endregion

		#region public IEnumerable<MaintenanceCheckComplianceGroup> GetNextComplianceCheckGroups(bool schedule)
		/// <summary>
		/// Возвращает чеки которые нужно выполнить на следующем шаге(должен быть выполнен хотя бы один шаг)
		/// <br/>если вернет null то значит входные данные не верны
		/// </summary>
		public static IEnumerable<MaintenanceCheckComplianceGroup> GetNextComplianceCheckGroups(this ICommonCollection<MaintenanceCheck> checks, bool schedule)
		{
			var checksGroupsCollections = checks.GroupingCheckByType(schedule);
			var complianceGroupCollection = new MaintenanceCheckComplianceGroupCollection();
			if (checksGroupsCollections.Length == 0)
				return complianceGroupCollection;
			foreach (var groupCollection in checksGroupsCollections)
			{
				if (groupCollection.Grouping)
				{
					//поиск минимального шага
					int? minStep = groupCollection.FindMinStep();
					if (minStep == null)
						continue;

					int num;
					if (schedule)
					{
						var nums = groupCollection.GetLastComplianceGroupNums();
						num = nums.Count == 0 ? 1 : nums.First() + 1;
					}
					else
					{
						var lastCheck = (from check in checks
										 where check.LastPerformance != null && check.Schedule == schedule
										 orderby check.LastPerformance.RecordDate descending
										 select check).ToList();
						if (lastCheck.Count == 0 || lastCheck.First().Schedule)
						{
							//Последним выполненым чеков на ВС бал чек по плановой программе обслуживания
							//т.е. после пред. выполнения программа обслуживания была изменена на "Хранение"
							//поэтому надо расчитать 1 группу чеков по Хранению
							num = 1;
						}
						else num = lastCheck.First().LastPerformance.NumGroup + 1;
					}
					int tableInterval = num * minStep.Value;

					foreach (var groupCheck in groupCollection)
					{
						int localInterval = tableInterval;
						if (groupCheck.CheckCycle <= tableInterval)
						{
							localInterval = tableInterval % groupCheck.CheckCycle;
							if (localInterval == 0)
							{
								//если локальный интервал равен нулю
								//то программа обслуживания находится на 
								//границе выполнения данного типа чеков (н: всех чеков А)
								//Поэтому в след. группу выполнения надо включить все чеки
								//данного типа.
								//На след. шаге к данной группе должен быть добавлен хотя бы один чек вышестоящего типа
								//(н: B или C)
								if (groupCheck.Checks.Count > 0 && groupCheck.Checks[0].ParentAircraft.MSG >= MSG.MSG3)
								{
									foreach (var check in groupCheck.Checks)
									{
										check.Tag = num;
										if (tableInterval % check.Interval.GetSubresource(groupCollection.Resource) == 0)
											complianceGroupCollection.Add(check, num, groupCheck.CheckCycle);
									}
								}
								else
								{
									foreach (var check in groupCheck.Checks)
									{
										check.Tag = num;
										complianceGroupCollection.Add(check, num, groupCheck.CheckCycle);
									}
								}
							}
						}
						if (localInterval == 0)
						{
							continue;
						}
						foreach (var check in groupCheck.Checks)
						{
							check.Tag = num;
							if (localInterval % check.Interval.GetSubresource(groupCollection.Resource) == 0)
								complianceGroupCollection.Add(check, num, groupCheck.CheckCycle);
						}
					}
				}
				else
				{
					foreach (var groupCheck in groupCollection)
					{
						foreach (var check in groupCheck.Checks)
						{
							var group = new MaintenanceCheckComplianceGroup(check.Schedule);
							group.Grouping = check.Grouping;
							group.Resource = check.Resource;
							group.GroupComplianceNum = check.LastPerformance != null ? check.LastPerformance.PerformanceNum : 1;
							group.CheckCycle = Convert.ToInt32(check.Interval.GetSubresource(check.Resource));
							group.Checks.Add(check);

							complianceGroupCollection.Add(group);
						}
					}
				}
			}
			return complianceGroupCollection;
		}
		#endregion

		#region public MaintenanceCheckGroup[] GroupingCheckByType(int? minStep, bool schedule)
		/// <summary>
		/// Сортирует чеки по интервалу выполнения в зависимости от свойства Schedule, 
		/// группирует по MaintenanceCheckType (A, B, C, D, etc),
		/// и проставляет связи между группами по приоритету MaintenanceCheckType
		/// </summary>
		public static IEnumerable<MaintenanceCheckGroupByType> GroupingCheckByType(this ICommonCollection<MaintenanceCheck> checks, int? minStep, bool schedule)
		{
			if (minStep == null) return null;

			var groupChecks = new List<MaintenanceCheckGroupByType>();
			Func<MaintenanceCheck, int?> predicate;
			if (schedule)
				predicate = check => check.Interval.Hours;
			else predicate = check => check.Interval.Days;

			var v = checks.Where(c => c.Schedule == schedule)
						  .OrderBy(predicate)
						  .ThenBy(c => c.CheckType.Priority)
						  .GroupBy(c => c.CheckType.FullName);

			foreach (var grouping in v)
			{
				var groupCheck = new MaintenanceCheckGroupByType(schedule);
				foreach (MaintenanceCheck check in grouping)
				{
					groupCheck.Checks.Add(check);
				}
				groupCheck.Sort();

				var last = groupChecks.LastOrDefault();
				if (last != null)
				{
					last.ParentGroup = groupCheck;
					last.CheckCycle = groupCheck.MinInterval();
				}

				groupCheck.ParentGroup = null;
				groupCheck.CheckCycle = groupCheck.MaxInterval();

				groupChecks.Add(groupCheck);
			}
			return groupChecks.ToArray();
		}
		#endregion

		#region public MaintenanceCheckGroupCollection [] GroupingCheckByType(bool schedule)
		/// <summary>
		/// Сортирует чеки по интервалу выполнения в зависимости от свойства Schedule, 
		/// группирует по MaintenanceCheckType (A, B, C, D, etc),
		/// и проставляет связи между группами по приоритету MaintenanceCheckType
		/// </summary>
		public static MaintenanceCheckGroupCollection[] GroupingCheckByType(this ICommonCollection<MaintenanceCheck> maintenanceChecks, bool schedule,
																	        bool? grouping = null, LifelengthSubResource? resource = null)
		{
			//Фильтрация чеков по Schedule и упорядочивание по приоритету и группировка по названию типа
			IEnumerable<MaintenanceCheck> preFilteredChecks = maintenanceChecks.Where(c => c.Schedule == schedule);
			if (grouping != null)
				preFilteredChecks = preFilteredChecks.Where(c => c.Grouping == grouping);
			if (resource != null)
				preFilteredChecks = preFilteredChecks.Where(c => c.Resource == resource);
			IEnumerable<IGrouping<MaintenanceCheckType, MaintenanceCheck>> filteredBySchedule =
				preFilteredChecks.OrderBy(c => c.CheckType.Priority)
								 .GroupBy(c => c.CheckType);
			//Формирование групп чеков по типам (A,B,C) с дополнительными критериями
			//1. Плановый чек/чек по хранению
			//2. Групповой/Одиночный
			//3. Основной ресурс (Часы/Циклы/Дни)
			List<MaintenanceCheckGroupCollection> checkGroupsCollections = new List<MaintenanceCheckGroupCollection>();
			foreach (IGrouping<MaintenanceCheckType, MaintenanceCheck> checks in filteredBySchedule)
			{
				foreach (MaintenanceCheck check in checks)
				{
					//Поиск коллекции групп, в которую входят группы с нужными критериями
					//по плану, группировка и основному ресурсу
					MaintenanceCheckGroupCollection collection = checkGroupsCollections
						.FirstOrDefault(g => g.Schedule == check.Schedule &&
											 g.Grouping == check.Grouping &&
											 g.Resource == check.Resource);
					if (collection != null)
					{
						//Коллекция найдена
						//Поиск в ней группы чеков с нужным типом
						MaintenanceCheckGroupByType groupByType = collection.FirstOrDefault(g => g.CheckType == check.CheckType);
						if (groupByType != null)
							groupByType.Checks.Add(check);
						else
						{
							//Группы с нужным типом нет
							//Инициализация и добавление
							groupByType = new MaintenanceCheckGroupByType(check.Schedule)
							{
								Grouping = check.Grouping,
								Resource = check.Resource,
								CheckType = check.CheckType,
							};
							groupByType.Checks.Add(check);
							collection.Add(groupByType);
						}
					}
					else
					{
						//Коллекции с нужными критериями нет
						//Созадние и добавление
						collection = new MaintenanceCheckGroupCollection
						{
							Schedule = check.Schedule,
							Grouping = check.Grouping,
							Resource = check.Resource,
						};
						MaintenanceCheckGroupByType groupByType = new MaintenanceCheckGroupByType(check.Schedule)
						{
							Grouping = check.Grouping,
							Resource = check.Resource,
							CheckType = check.CheckType,
						};
						groupByType.Checks.Add(check);
						collection.Add(groupByType);
						checkGroupsCollections.Add(collection);
					}
				}
			}
			//Упорядочивание каждой группы по ресурсам выполнения и проставление связей между ними
			foreach (MaintenanceCheckGroupCollection collection in checkGroupsCollections)
			{
				foreach (MaintenanceCheckGroupByType groupByType in collection)
				{
					groupByType.Sort();

					MaintenanceCheckGroupByType last =
						collection.LastOrDefault(gbt => gbt.CheckType.Priority < groupByType.CheckType.Priority);
					if (last != null)
					{
						last.ParentGroup = groupByType;
						last.CheckCycle = groupByType.MinIntervalByResource();
					}

					groupByType.ParentGroup = null;
					groupByType.CheckCycle = groupByType.MaxIntervalByResource();
				}
			}
			return checkGroupsCollections.ToArray();
		}
		#endregion

		#region public static MaintenanceCheckGroupCollection GetFirstCheckBySource(this IEnumerable<MaintenanceCheck> checkInput, bool schedule, int? lifeLenghtSource)
		/// <summary>
		/// Возвращает чеки которые нужно выполнить на назначенный ресурс lifeLenghtSourcе
		/// если вернет null то значит входные данные не верны
		/// </summary>
		/// <param name="checkInput"></param>
		/// <param name="schedule"></param>
		/// <param name="lifeLenghtSource"></param>
		/// <returns></returns>
		public static MaintenanceCheckGroupCollection GetFirstCheckBySource(this IEnumerable<MaintenanceCheck> checkInput, bool schedule, int? lifeLenghtSource)
		{
			//if (lifeLenghtSource == null || lifeLenghtSource.Value == 0) return null;
			if (lifeLenghtSource == null) return null;
			//сортировка коллекции по типу Shedule;
			MaintenanceCheckCollection sourceCollection = new MaintenanceCheckCollection(checkInput.Where(c => c.Schedule == schedule).ToList());
			//поиск минимального шага
			int? minStep = sourceCollection.FindMinStep(schedule);
			if (minStep == null) return null;

			List<MaintenanceCheckGroupByType> checksGroups = new List<MaintenanceCheckGroupByType>(sourceCollection.GroupingCheckByType(minStep, schedule));

			if (checksGroups.Count == 0)
			{
				return null;
			}

			return GetCheckBySource(checksGroups, lifeLenghtSource, minStep, schedule);
		}
		#endregion

		#region public static MaintenanceCheckGroupByType GetNextCheckBySourceDifference(this IEnumerable<MaintenanceCheck> checkInput, MaintenanceCheck lastComplianceCheck, int? lifeLenghtSource)
		/// <summary>
		/// Возвращает группу следующих чеков заданного типа, который должны быть выполнены до назначенного ресурса lifeLenghtSourcе
		/// если вернет null то значит входные данные неверны
		/// </summary>
		/// <param name="checkInput"></param>
		/// <param name="lastComplianceCheck"></param>
		/// <param name="lifeLenghtSource"></param>
		/// <returns></returns>
		public static MaintenanceCheckGroupByType GetNextCheckBySourceDifference(this IEnumerable<MaintenanceCheck> checkInput, MaintenanceCheck lastComplianceCheck, int? lifeLenghtSource)
		{
			if (lifeLenghtSource == null || lifeLenghtSource.Value == 0 || lastComplianceCheck == null) return null;
			//сортировка коллекции по типу Shedule;
			MaintenanceCheckCollection sourceCollection =
				new MaintenanceCheckCollection(checkInput.Where(c => c.Schedule == lastComplianceCheck.Schedule).ToList());
			//поиск минимального шага
			int? minStep = lastComplianceCheck.Interval.Days;
			if (minStep == null) return null;

			List<MaintenanceCheckGroupByType> checksGroups =
				new List<MaintenanceCheckGroupByType>(sourceCollection.GroupingCheckByType(minStep, lastComplianceCheck.Schedule));

			if (checksGroups.Count == 0)
			{
				return null;
			}

			return GetCheckPacketBySource(checksGroups, lifeLenghtSource, minStep, lastComplianceCheck);
		}
		#endregion

		#region public static MaintenanceCheckGroupCollection GetNextCheckByLastCompliane(this IEnumerable<MaintenanceCheck> checkInput, bool schedule)
		/// <summary>
		/// Возвращает чеки которые нужно выполнить на следующем шаге(должен быть выполнен хотя бы один шаг)
		/// если вернет null то значит входные данные не верны
		/// </summary>
		/// <param name="checkInput"></param>
		/// <param name="schedule"></param>
		/// <returns></returns>
		public static MaintenanceCheckGroupCollection GetNextCheckByLastCompliane(this IEnumerable<MaintenanceCheck> checkInput, bool schedule)
		{
			//сортировка коллекции по типу Shedule;
			MaintenanceCheckCollection sourceCollection = new MaintenanceCheckCollection(checkInput.Where(c => c.Schedule == schedule).ToList());
			//поиск минимального шага
			int? minStep = sourceCollection.FindMinStep(schedule);
			if (minStep == null) return null;

			List<MaintenanceCheckGroupByType> checksGroups = new List<MaintenanceCheckGroupByType>(sourceCollection.GroupingCheckByType(minStep, schedule));

			if (checksGroups.Count == 0)
			{
				return null;
			}

			return schedule
				? GetNextCheckSchedule(checkInput, checksGroups, minStep)
				: GetNextCheckUnschedule(checkInput, checksGroups, minStep);

		}
		#endregion


		#region MaintenanceCheckGroup GetCheckPacketBySource(List<GroupCheck> groupChecks, int? lifeLenghtResource, MaintenanceCheck lastComplianceCheck)
		/// <summary>
		/// Вернет пакет чеков заданного типа, которые хотя бы раз должны быть выполнены до заданного ресурса
		/// Исключит из пакета те чеки, которые по группе выполнения будут совпадать с выполненными чеками
		/// </summary>
		private static MaintenanceCheckGroupByType GetCheckPacketBySource(List<MaintenanceCheckGroupByType> groupChecks,
															int? lifeLenghtResource,
															int? minStep, MaintenanceCheck lastComplianceCheck)
		{
			if (lifeLenghtResource == null
				|| lifeLenghtResource == 0
				|| groupChecks == null
				|| minStep == null) return null;
			int intervalGroupNum, countCompliance;
			MaintenanceCheckGroupByType group = new MaintenanceCheckGroupByType(groupChecks[0].Checks[0].Schedule);
			//список чеков, с которым в последствии будет производится сравнения на группу последнего выполнения

			//Вычисление разницы ресурсов
			int differentOfSource = lifeLenghtResource.Value -
				Convert.ToInt32(lastComplianceCheck.LastPerformance.OnLifelength.Days);
			//Вычисление количества просроченных групп
			int countOfOverdueGroup = differentOfSource / minStep.Value;
			//Вычисление максимального ресурса
			int maxSource = (lastComplianceCheck.LastPerformance.NumGroup + countOfOverdueGroup) *
				Convert.ToInt32(lastComplianceCheck.Interval.Hours);
			//Максимальный ресурс и дальшенйшие вычисления производятся по часам,
			//т.к. их значение более точно, чем значение дней

			//Формирование пакета чеков
			foreach (MaintenanceCheckGroupByType groupCheck in groupChecks)
			{
				foreach (MaintenanceCheck check in groupCheck.Checks)
				{
					//Вычисление количества, сколько раз должен выполнится чек
					countCompliance =
						(maxSource -
						(maxSource % Convert.ToInt32(check.Interval.Hours))) /
						Convert.ToInt32(check.Interval.Hours);
					if (countCompliance != 0)
					{
						//чек выолняется хотя бы раз до заданного ресурса
						//вычисление группы, на которой должен выполнится чек
						intervalGroupNum =
							(maxSource -
							(maxSource % Convert.ToInt32(check.Interval.Hours))) /
							Convert.ToInt32(lastComplianceCheck.Interval.Hours);
						//включение чека в пакет
						check.ComplianceGroupNum = intervalGroupNum;
						group.Checks.Add(check);
					}
				}
			}

			if (group.Checks.Count == 0) return null;
			//исключение из пакета тех чеков, чья группа выполнения совпадает 
			//с группой последнего выполнения заданого чека
			foreach (MaintenanceCheck maintenanceCheck in group.Checks)
			{
				if (maintenanceCheck.LastPerformance != null
					&& maintenanceCheck.LastPerformance.NumGroup == maintenanceCheck.ComplianceGroupNum)
					group.Checks.Remove(maintenanceCheck);
			}
			//заполнение дополнительных данных по группе выполнения
			differentOfSource -= differentOfSource % Convert.ToInt32(lastComplianceCheck.Interval.Days);
			group.GroupComplianceNum = lastComplianceCheck.LastPerformance.NumGroup + countOfOverdueGroup;
			group.GroupComplianceDate = lastComplianceCheck.LastPerformance.RecordDate.AddDays(differentOfSource);
			group.GroupComplianceLifelength = new Lifelength(lastComplianceCheck.LastPerformance.OnLifelength);
			group.GroupComplianceLifelength.Days += differentOfSource;
			return group;
		}
		#endregion

		#region MaintenanceCheckGroupCollection GetCheckBySource(List<GroupCheck> groupChecks, int? lifeLenghtResource, bool schedule)
		private static MaintenanceCheckGroupCollection GetCheckBySource(List<MaintenanceCheckGroupByType> groupChecks, int? lifeLenghtResource, int? minStep, bool schedule)
		{
			if (lifeLenghtResource == null
				|| lifeLenghtResource == 0
				|| groupChecks == null
				|| minStep == null) return null;

			if (lifeLenghtResource < minStep) lifeLenghtResource = minStep;

			int tableInterval = lifeLenghtResource.Value;
			int intervalGroupNum;
			MaintenanceCheckGroupCollection groupCollection = new MaintenanceCheckGroupCollection();

			foreach (MaintenanceCheckGroupByType groupCheck in groupChecks)
			{
				int localInterval = tableInterval;
				if (groupCheck.CheckCycle <= tableInterval)
				{
					localInterval = tableInterval % groupCheck.CheckCycle;
					intervalGroupNum = (lifeLenghtResource.Value - (lifeLenghtResource.Value % groupCheck.CheckCycle)) / minStep.Value;

					foreach (MaintenanceCheck check in groupCheck.Checks)
					{
						check.ComplianceGroupNum = intervalGroupNum;
						groupCollection.Add(check, check.ComplianceGroupNum);
					}
				}
				if (localInterval == 0)
				{
					continue;
				}
				if (schedule)
				{
					//взятие всех чеков, интервал выполнения которых, меньше заданной наработки
					List<MaintenanceCheck> checks = (from check in groupCheck.Checks
													 where
														 check.Interval.Hours <= localInterval
													 orderby check.Interval.Hours ascending
													 select check).ToList();
					//если таковые чеки есть, то минусуется интервал их выполнения от текущей нарабтки
					//возвращая таким образом остаток
					if (checks.Count != 0)
					{
						intervalGroupNum = (lifeLenghtResource.Value - (lifeLenghtResource.Value % checks[0].Interval.Hours.Value)) / minStep.Value;
						int groupNum;
						foreach (MaintenanceCheck maintenanceCheck in checks)
						{
							groupNum = (lifeLenghtResource.Value - (lifeLenghtResource.Value % maintenanceCheck.Interval.Hours.Value)) / minStep.Value;
							if (groupNum == intervalGroupNum)
							{
								maintenanceCheck.ComplianceGroupNum = intervalGroupNum;
								groupCollection.Add(maintenanceCheck, maintenanceCheck.ComplianceGroupNum);
							}
						}
					}
				}
				else
				{
					//взятие всех чеков, интервал выполнения которых, меньше заданной наработки
					List<MaintenanceCheck> checks = (from check in groupCheck.Checks
													 where
														 check.Interval.Days <= localInterval
													 orderby check.Interval.Days ascending
													 select check).ToList();
					//если таковые чеки есть, то минусуется интервал их выполнения от ткеущей нарабтки
					//возвращая таким образом остаток
					if (checks.Count != 0)
					{
						intervalGroupNum = (lifeLenghtResource.Value - (lifeLenghtResource.Value % checks[0].Interval.Days.Value)) / minStep.Value;
						int groupNum = 0;
						foreach (MaintenanceCheck maintenanceCheck in checks)
						{
							if (maintenanceCheck.Interval.Days != null)
								groupNum = (lifeLenghtResource.Value - (lifeLenghtResource.Value % maintenanceCheck.Interval.Days.Value)) / minStep.Value;
							if (groupNum == intervalGroupNum)
							{
								maintenanceCheck.ComplianceGroupNum = intervalGroupNum;
								groupCollection.Add(maintenanceCheck, maintenanceCheck.ComplianceGroupNum);
							}
						}
					}
				}
			}
			return groupCollection;
		}
		#endregion

		#region MaintenanceCheckGroupCollection GetNextCheckSchedule(IEnumerable<MaintenanceCheck> sourceCollection, List<GroupCheck> groupChecks, int? minStep)
		private static MaintenanceCheckGroupCollection GetNextCheckSchedule(IEnumerable<MaintenanceCheck> sourceCollection,
															 List<MaintenanceCheckGroupByType> groupChecks, int? minStep)
		{
			var num = (from check in sourceCollection
					   where check.LastPerformance != null && check.Schedule
					   orderby check.LastPerformance.NumGroup descending
					   select check.LastPerformance.NumGroup).ToList();
			if (!num.Any())
			{
				return null;
			}

			return GetCheckByGroupNum(groupChecks, num.First() + 1, minStep, true);
		}
		#endregion

		#region MaintenanceCheckGroupCollection GetNextCheckUnschedule(IEnumerable<MaintenanceCheck> sourceCollection sourceCollection, List<GroupCheck> groupChecks, int? minStep)
		private static MaintenanceCheckGroupCollection GetNextCheckUnschedule(IEnumerable<MaintenanceCheck> sourceCollection,
															   List<MaintenanceCheckGroupByType> groupChecks, int? minStep)
		{
			var lastCheck = (from check in sourceCollection
							 where check.LastPerformance != null
							 orderby check.LastPerformance.RecordDate descending
							 select check).ToList();
			if (lastCheck.Count == 0 || lastCheck.First().Schedule)
			{
				return GetCheckByGroupNum(groupChecks, 1, minStep, false);
			}
			return GetCheckByGroupNum(groupChecks, lastCheck.First().LastPerformance.NumGroup + 1, minStep, false);
		}
		#endregion

		#region MaintenanceCheckGroupCollection GetCheckByGroupNum(List<GroupCheck> GroupChecks, int num, int? minStep, bool schedule)
		private static MaintenanceCheckGroupCollection GetCheckByGroupNum(List<MaintenanceCheckGroupByType> groupChecks, int num, int? minStep, bool schedule)
		{
			if (minStep == null || groupChecks == null) return null;

			int tableInterval = num * minStep.Value;
			MaintenanceCheckGroupCollection groupCollection = new MaintenanceCheckGroupCollection();

			foreach (MaintenanceCheckGroupByType groupCheck in groupChecks)
			{
				int localInterval = tableInterval;
				if (groupCheck.CheckCycle <= tableInterval)
				{
					localInterval = tableInterval % groupCheck.CheckCycle;
					if (localInterval == 0)
					{
						//если локальный интервал равен нулю
						//то программа обслуживания находится на 
						//границе выполнения данного типа чеков (н: всех чеков А)
						//Поэтому в след. группу выполнения надо включить все чеки
						//данного типа.
						//На след. шаге к данной группе должен быть добавлен хотя бы один чек вышестоящего типа
						//(н: B или C)
						foreach (MaintenanceCheck check in groupCheck.Checks)
						{
							check.Tag = num;
							groupCollection.Add(check, num);
						}
					}
				}
				if (localInterval == 0)
				{
					continue;
				}
				foreach (MaintenanceCheck check in groupCheck.Checks)
				{
					check.Tag = num;
					if (schedule)
					{
						if (localInterval % check.Interval.Hours == 0)
						{
							groupCollection.Add(check, num);
						}
					}
					else
					{
						if (localInterval % check.Interval.Days == 0)
						{
							groupCollection.Add(check, num);
						}
					}
				}
			}
			return groupCollection;
		}
		#endregion
	}
}
