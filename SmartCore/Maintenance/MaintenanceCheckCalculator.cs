using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Analyst;
using SmartCore.AverageUtilizations;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Maintenance
{
	public class MaintenanceCheckCalculator : IMaintenanceCheckCalculator
	{
		private readonly ICalculator _calculator;
		private readonly IAverageUtilizationCore _averageUtilizationCore;
		private readonly IPerformanceCalculator _performanceCalculator;

		public MaintenanceCheckCalculator(ICalculator calculator, IAverageUtilizationCore averageUtilizationCore,
										  IPerformanceCalculator performanceCalculator)
		{
			_calculator = calculator;
			_averageUtilizationCore = averageUtilizationCore;
			_performanceCalculator = performanceCalculator;
		}

		#region public void GetNextPerformanceGroup(MaintenanceCheckCollection sourceCollection, ForecastData forecast = null)
		/// <summary>
		/// Расчитывает следующую группу выполнения для каждого чека в коллекции, параметр "Плановый/НЕПлановый" которого соответствует заданному значению
		/// <br/> При задании параметра forecast не равным null, расчет групп выполения для каждого чека ведется до тех пор,
		/// <br/> пока ресурс следующего выполения группы не привысит или не сравняется с ресурсом прогноза
		/// </summary>
		/// <param name="sourceCollection">Коллекция чеков, для которых нужно расчитать выполения</param>
		/// <param name="schedule">параметр "План/Хранение"</param>
		/// <param name="forecast">Прогноз, по умолчанию null</param>
		public void GetNextPerformanceGroup(MaintenanceCheckCollection sourceCollection, bool schedule, ForecastData forecast = null)
		{
			if (sourceCollection == null || sourceCollection.Count <= 0) return;

			Lifelength last = Lifelength.Null;
			Lifelength next = Lifelength.Null;
			Lifelength current = _calculator.GetCurrentFlightLifelength(sourceCollection[0].LifeLengthParent);
			MaintenanceNextPerformance mnp;

			var au = _averageUtilizationCore.GetAverageUtillization(sourceCollection[0], forecast);

			MaintenanceCheckGroupCollection[] checksGroupsCollections = sourceCollection.GroupingCheckByType(schedule);

			foreach (MaintenanceCheckGroupCollection checksGroupsCollection in checksGroupsCollections)
			{
				LifelengthSubResource sub = checksGroupsCollection.Resource;

				if (checksGroupsCollection.Grouping)
				{
					if (checksGroupsCollection.Count == 0)
						continue;
					//поиск минимального шага
					Lifelength minStepLifeLenght = checksGroupsCollection.GetMinStepCheck().Interval;
					int? minStep = minStepLifeLenght.GetSubresource(checksGroupsCollection.Resource);
					if (minStep == null)
						continue;

					//Фактический ресурс последнего выполнения
					Lifelength factLastComplianceLifelength = checksGroupsCollection[0].LastGroupComplianceLifelength;
					//Расчетный ресурс последнего выполнения
					Lifelength calcLastComplianceLifelength = minStepLifeLenght * checksGroupsCollection[0].LastComplianceGroupNum;
					//определение смещения в графике выполнения
					Lifelength globalOffsetLifelength = factLastComplianceLifelength - calcLastComplianceLifelength;
					//Приведение смещения к нужному виду (отбрасывание лишних пареметров) 
					globalOffsetLifelength.Resemble(minStepLifeLenght);
					//ресурс смещения для данного типа программы (Schedule/Store)
					int globalOffset = Convert.ToInt32(globalOffsetLifelength.GetSubresource(sub));

					//расчетный (с учетом смещения) ресурс 1-го выполнения маскимального чека после ресурса прогноза
					//Lifelength calcWithOffsetMaxStepCheckX2 = Lifelength.Null;
					Lifelength maxAfterForecastSource = Lifelength.Null;
					//Этот ресурс необходим для расчета выполнения всех чеков, 
					//чей ресурс меньше ресурса максимального чека.
					//Выполнение самого максимального чека как правило требует выполенения всех чеков с меньшим ресурсом
					//Поэтому выполнения чеков с меньшим ресурсом нужно расчитывать вплоть до ресурса выполнения
					//самого максимального чека.
					if (forecast != null)
					{
						maxAfterForecastSource.Add(forecast.ForecastLifelength);
						//int? forecastSource = forecast.ForecastLifelength.GetSubresource(sub);
						//calcWithOffsetMaxStepCheckX2.Add(globalOffsetLifelength);

						//do calcWithOffsetMaxStepCheckX2.Add(maxStepLifeLenght);    
						//while (calcWithOffsetMaxStepCheckX2.GetSubresource(sub) < forecastSource););
						if (forecast.IncludePercents)
						{
							foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in checksGroupsCollection)
							{
								foreach (MaintenanceCheck check in maintenanceCheckGroup.Checks)
								{
									Lifelength localAfterForecastSource = Lifelength.Null;
									int cyclesCount = 0;
									int performanceGroupNUm = 0;

									#region Определение начального значения
									//точки первого выполнения после ресурса прогноза для данного чека
									//Определение кол-ва пройденых циклов
									if (factLastComplianceLifelength.GetSubresource(sub).HasValue)
									{
										//определение ресурса последнего выполнения
										int res = Convert.ToInt32(factLastComplianceLifelength.GetSubresource(sub));
										res -= globalOffset;
										cyclesCount = (res - res % maintenanceCheckGroup.CheckCycle) / maintenanceCheckGroup.CheckCycle;
									}

									if (check.LastPerformance == null) // директива ни разу не выполнялась
									{
										// Расчитываем условие первого выполнения 
										// получаем ресурс агрегата при котором директива должна будет выполнена с момента вступления директивы в действие
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											// с момента производства
											Lifelength sinceNew = check.Interval;
											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											int? resource = sinceNew.GetSubresource(sub);
											if (resource != null && resource >= maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												//вычисление нового ресурса выполнения = ресурсу выполнения минимального чека в вышестоящей группе
												performanceGroupNUm = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
												sinceNew = minStepLifeLenght * performanceGroupNUm;
												localAfterForecastSource.Reset();
												if (minStepLifeLenght.CalendarValue != null)
													localAfterForecastSource.Add(forecast.ForecastDate, sinceNew);
												else localAfterForecastSource.Add(sinceNew);
											}
											else
											{
												performanceGroupNUm = Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
												localAfterForecastSource.Reset();
												if (minStepLifeLenght.CalendarValue != null)
													localAfterForecastSource.Add(forecast.ForecastDate, sinceNew);
												else localAfterForecastSource.Add(sinceNew);
											}
											localAfterForecastSource.Add(globalOffsetLifelength);
											// Убираем ненужные параметры
											localAfterForecastSource.Resemble(sinceNew);
										}
									}
									else // Директива уже выполнялась 
									{
										// Расчитываем условие следующего выполнения
										// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											performanceGroupNUm = check.LastPerformance.NumGroup;
											last = (minStepLifeLenght * performanceGroupNUm);
											localAfterForecastSource.Reset();
											localAfterForecastSource.Add(last);
											localAfterForecastSource.Add(check.Interval);
											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											int? resource = localAfterForecastSource.GetSubresource(sub);
											if (resource != null && resource >= maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												localAfterForecastSource.Reset();
												//вычисление нового ресурса выполнения
												//1.возвращается предыдущее значение выполнения
												localAfterForecastSource.Add(last);
												if (check.Interval.GetSubresource(sub) >= maintenanceCheckGroup.CheckCycle)
												{
													int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
													performanceGroupNUm += countSteps;
													//если интервал выполнения чека больше цикла группы чеков 
													localAfterForecastSource.Add(minStepLifeLenght * countSteps);
												}
												else
												{
													int countSteps =
														Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep) -
														check.LastPerformance.NumGroup;
													performanceGroupNUm += countSteps;
													localAfterForecastSource.Add(minStepLifeLenght * countSteps);
												}
											}
											else
											{
												performanceGroupNUm = check.LastPerformance.NumGroup +
													Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
											}
											localAfterForecastSource.Add(globalOffsetLifelength);
											// Убираем ненужные параметры
											localAfterForecastSource.Resemble(check.Interval);
										}
									}
									#endregion

									#region Определение финального значения
									//точки первого выполнения после ресурса прогноза для данного чека

									//int? forecastSource = forecast.ForecastLifelength.GetSubresource(sub);
									while ((localAfterForecastSource - forecast.ForecastLifelength).GetSubresource(sub) < 0)
									{
										// Расчитываем условие следующего выполнения
										// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											last.Reset(); next.Reset();
											last.Add(localAfterForecastSource);
											next.Add(last);
											next.Add(check.Interval);
											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											if (next.GetSubresource(sub) != null && (next - globalOffsetLifelength).GetSubresource(sub)
												>= maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												if (check.Interval.GetSubresource(sub) >= maintenanceCheckGroup.CheckCycle)
												{
													//если интервал выполнения чека больше цикла группы чеков 
													int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
													performanceGroupNUm += countSteps;
													localAfterForecastSource.Add(minStepLifeLenght * countSteps);
												}
												else
												{
													//если интервал выполнения чека меньше цикла группы чеков 
													//2. расчитывается кол-во минимальных шагов, оставшихся между ресурсом
													//предыдущего выполнения и границей цикла (с учетом смещения)
													int countSteps =
														Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep) - performanceGroupNUm;
													performanceGroupNUm += countSteps;
													localAfterForecastSource.Add(minStepLifeLenght * countSteps);
												}
											}
											else
											{
												performanceGroupNUm = performanceGroupNUm + Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
												localAfterForecastSource.Reset();
												localAfterForecastSource.Add(next);
											}

											localAfterForecastSource.Resemble(check.Interval);
										}
									}
									#endregion

									int checkInt = Convert.ToInt32(check.Interval.GetSubresource(sub));

									Lifelength localX2Source = localAfterForecastSource - forecast.ForecastLifelength;
									double percents = Convert.ToDouble((double)Convert.ToInt32(localX2Source.GetSubresource(sub)) / checkInt) * 100;
									if (percents > forecast.Percents || !localAfterForecastSource.IsGreaterNullable(maxAfterForecastSource)) continue;

									maxAfterForecastSource.Reset();
									maxAfterForecastSource.Add(localAfterForecastSource);
								}
							}
						}
					}

					MaintenanceCheckGroupCollection performancesGroups = new MaintenanceCheckGroupCollection();

					foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in checksGroupsCollection)
					{
						foreach (MaintenanceCheck check in maintenanceCheckGroup.Checks)
						{
							//Фактический ресурс последнего выполнения данного чека
							Lifelength factCheckLastComplianceLifelength = check.LastPerformance != null
								? check.LastPerformance.OnLifelength
								: Lifelength.Null;
							//Расчетный ресурс последнего выполнения данного чека
							Lifelength calcCheckLastComplianceLifelength =
								minStepLifeLenght * (check.LastPerformance != null ? check.LastPerformance.NumGroup : 0);
							//определение смещения в графике выполнения
							Lifelength checkOffsetLifelength = factCheckLastComplianceLifelength - calcCheckLastComplianceLifelength;
							//Приведение смещения к нужному виду (отбрасывание лишних пареметров) 
							checkOffsetLifelength.Resemble(minStepLifeLenght);
							//ресурс смещения для данного типа программы (Schedule/Store)
							int checkOffset = Convert.ToInt32(checkOffsetLifelength.GetSubresource(sub));
							//Определение кол-ва пройденых циклов
							int cyclesCount = 0;
							if (factCheckLastComplianceLifelength.GetSubresource(sub).HasValue)
							{
								//определение ресурса последнего выполнения
								int res = Convert.ToInt32(factCheckLastComplianceLifelength.GetSubresource(sub));
								res -= checkOffset;
								cyclesCount = (res - res % maintenanceCheckGroup.CheckCycle) / maintenanceCheckGroup.CheckCycle;
							}

							//if (check.Name == "6A")
							//{

							//}
							check.ResetMathData();
							for (;;)
							{
								mnp = null;

								#region Определение возможности след. выполения и ресурса на котором оно произойдет

								if (check.NextPerformances.Count == 0)
								{
									if (check.LastPerformance == null) // директива ни разу не выполнялась
									{
										// Расчитываем условие первого выполнения 
										// получаем ресурс агрегата при котором директива должна будет выполнена с момента вступления директивы в действие
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											mnp = new MaintenanceNextPerformance { Parent = check };
											last.Reset();
											// с момента производства
											Lifelength sinceNew = check.Interval;
											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											int? resource = sinceNew.GetSubresource(sub);
											if (resource != null && resource > maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												if (check.ParentAircraft != null && check.ParentAircraft.MSG >= MSG.MSG3)
												{
													//Если интервал чека больше интервала всей группы и ВС
													//ведет свое обслуживание по программе MSG3,
													//то дальнейшая калькуляция данного чека не имеет смысла
													break;
												}
											}
											if (resource != null && resource == maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												//вычисление нового ресурса выполнения = ресурсу выполнения минимального чека в вышестоящей группе
												int countStep = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
												sinceNew = minStepLifeLenght * countStep;
												mnp.PerformanceGroupNum = countStep;
												mnp.PerformanceNum = 1;
												mnp.PerformanceSource.Reset();
												if (sinceNew.CalendarValue != null)
													mnp.PerformanceSource.Add(check.ParentAircraft.ManufactureDate, sinceNew);
												else mnp.PerformanceSource.Add(sinceNew);
											}
											else
											{
												mnp.PerformanceGroupNum = Convert.ToInt32(sinceNew.GetSubresource(sub) / minStep);
												mnp.PerformanceNum = 1;
												mnp.PerformanceSource.Reset();
												if (sinceNew.CalendarValue != null)
													mnp.PerformanceSource.Add(check.ParentAircraft.ManufactureDate, sinceNew);
												else mnp.PerformanceSource.Add(sinceNew);
											}

											MaintenanceProgramChangeRecord mpcr =
												check.ParentAircraft.MaintenanceProgramChangeRecords
													.OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
													.LastOrDefault(r => r.CalculatedPerformanceSource.GetSubresource(sub) <= mnp.PerformanceSource.GetSubresource(sub));
											if (mpcr != null && mpcr.MSG >= MSG.MSG3)
											{
												if (mpcr.CalculatedPerformanceSource != null && !mpcr.CalculatedPerformanceSource.IsNullOrZero())
													mnp.PerformanceSource.Add(mpcr.OnLifelength - mpcr.CalculatedPerformanceSource);
												else mnp.PerformanceSource.Add(globalOffsetLifelength);
											}
											else
											{
												mnp.PerformanceSource.Add(globalOffsetLifelength);
											}
											// Убираем ненужные параметры
											mnp.PerformanceSource.Resemble(sinceNew);
										}
									}
									else // Директива уже выполнялась 
									{
										// Расчитываем условие следующего выполнения
										// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											mnp = new MaintenanceNextPerformance { Parent = check };
											last = (minStepLifeLenght * check.LastPerformance.NumGroup);
											next.Reset();
											next.Add(last);
											if (check.Interval.CalendarValue != null)
												next.Add(check.LastPerformance.RecordDate, check.Interval);
											else next.Add(check.Interval);

											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											int? resource = next.GetSubresource(sub);
											if (resource != null &&
												resource > maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												mnp.PerformanceSource.Reset();
												//вычисление нового ресурса выполнения
												//1.возвращается предыдущее значение выполнения
												mnp.PerformanceSource.Add(last);
												if (check.Interval.GetSubresource(sub) > maintenanceCheckGroup.CheckCycle)
												{
													if (check.ParentAircraft != null && check.ParentAircraft.MSG >= MSG.MSG3)
													{
														//Если интервал чека больше интервала всей группы и ВС
														//ведет свое обслуживание по программе MSG3,
														//то дальнейшая калькуляция данного чека не имеет смысла
														break;
													}
													int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
													mnp.PerformanceGroupNum = check.LastPerformance.NumGroup + countSteps;
													mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;
													//если интервал выполнения чека больше цикла группы чеков 
													if (minStepLifeLenght.CalendarValue != null)
														mnp.PerformanceSource.Add(check.LastPerformance.RecordDate, minStepLifeLenght * countSteps);
													else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
												}
												else if (check.Interval.GetSubresource(sub) == maintenanceCheckGroup.CheckCycle)
												{
													int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
													mnp.PerformanceGroupNum = check.LastPerformance.NumGroup + countSteps;
													mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;
													//если интервал выполнения чека больше цикла группы чеков 
													if (minStepLifeLenght.CalendarValue != null)
														mnp.PerformanceSource.Add(check.LastPerformance.RecordDate, minStepLifeLenght * countSteps);
													else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
												}
												else
												{
													if (check.ParentAircraft != null && check.ParentAircraft.MSG >= MSG.MSG3)
													{
														//Если СЛЕД. ВЫПОЛЕНИЕ чека больше интервала всей группы и ВС
														//ведет свое обслуживание по программе MSG3,
														//то НУЖНО ПРОИЗВЕСТИ РАСЧЕТ ВЫПОЛНЕНИЯ НА СЛЕД. ЦИКЛЕ
														mnp.PerformanceGroupNum =
															Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep) +
															Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
														mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;

														int countSteps = mnp.PerformanceGroupNum - check.LastPerformance.NumGroup;

														if (minStepLifeLenght.CalendarValue != null)
															mnp.PerformanceSource.Add(check.LastPerformance.RecordDate, minStepLifeLenght * countSteps);
														else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
													}
													else
													{
														mnp.PerformanceGroupNum =
															Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep) +
															Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
														mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;
														//если интервал выполнения чека меньше цикла группы чеков 
														//2. расчитывается кол-во минимальных шагов, оставшихся между ресурсом
														//предыдущего выполнения и границей цикла (с учетом смещения)

														int countSteps = mnp.PerformanceGroupNum - check.LastPerformance.NumGroup;
														if (minStepLifeLenght.CalendarValue != null)
															mnp.PerformanceSource.Add(check.LastPerformance.RecordDate, minStepLifeLenght * countSteps);
														else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
													}
												}
											}
											else if (resource != null && resource == maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
											{
												cyclesCount += 1;
												mnp.PerformanceSource.Reset();
												//вычисление нового ресурса выполнения
												//1.возвращается предыдущее значение выполнения
												mnp.PerformanceSource.Add(last);
												mnp.PerformanceGroupNum = Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep);
												mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;
												//если интервал выполнения чека меньше цикла группы чеков 
												//2. расчитывается кол-во минимальных шагов, оставшихся между ресурсом
												//предыдущего выполнения и границей цикла (с учетом смещения)
												int countSteps = mnp.PerformanceGroupNum - check.LastPerformance.NumGroup;
												if (minStepLifeLenght.CalendarValue != null)
													mnp.PerformanceSource.Add(check.LastPerformance.RecordDate, minStepLifeLenght * countSteps);
												else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
											}
											else
											{
												mnp.PerformanceGroupNum = check.LastPerformance.NumGroup +
													Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
												mnp.PerformanceNum = check.LastPerformance.PerformanceNum + 1;
												mnp.PerformanceSource.Reset();
												mnp.PerformanceSource.Add(next);
											}

											MaintenanceProgramChangeRecord mpcr =
												check.ParentAircraft.MaintenanceProgramChangeRecords
													.OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
													.LastOrDefault(r => r.CalculatedPerformanceSource.GetSubresource(sub) <= mnp.PerformanceSource.GetSubresource(sub));
											if (mpcr != null && mpcr.MSG >= MSG.MSG3)
											{
												if (mpcr.CalculatedPerformanceSource != null && !mpcr.CalculatedPerformanceSource.IsNullOrZero())
												{
													last.Add(mpcr.OnLifelength - mpcr.CalculatedPerformanceSource);
													mnp.PerformanceSource.Add(mpcr.OnLifelength - mpcr.CalculatedPerformanceSource);
												}
												else
												{
													last.Add(globalOffsetLifelength);
													mnp.PerformanceSource.Add(globalOffsetLifelength);
												}
											}
											else
											{
												last.Add(globalOffsetLifelength);
												mnp.PerformanceSource.Add(globalOffsetLifelength);
											}
											// Убираем ненужные параметры
											mnp.PerformanceSource.Resemble(check.Interval);
										}
									}
								}
								else
								{
									// Расчитываем условие следующего выполнения
									// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
									if (check.Interval != null && !check.Interval.IsNullOrZero())
									{
										mnp = new MaintenanceNextPerformance { Parent = check };

										MaintenanceNextPerformance perf = (MaintenanceNextPerformance)check.NextPerformances.Last();
										//last.Reset(); next.Reset();
										//last.Add(perf.PerformanceSource);
										//next.Add(last);
										//if(perf.PerformanceDate != null && check.Interval.CalendarValue != null)
										//    next.Add(Convert.ToDateTime(perf.PerformanceDate), check.Interval);
										//else next.Add(check.Interval);

										Lifelength currentOffset = Lifelength.Null;
										Lifelength calculatedNext = (minStepLifeLenght * perf.PerformanceGroupNum) + check.Interval;
										MaintenanceProgramChangeRecord mpcr =
												check.ParentAircraft.MaintenanceProgramChangeRecords
													.OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
													.LastOrDefault(r => r.CalculatedPerformanceSource.GetSubresource(sub) <= calculatedNext.GetSubresource(sub));
										if (mpcr != null && mpcr.MSG >= MSG.MSG3)
										{
											if (mpcr.CalculatedPerformanceSource != null && !mpcr.CalculatedPerformanceSource.IsNullOrZero())
											{
												currentOffset.Reset();
												currentOffset.Add(mpcr.OnLifelength - mpcr.CalculatedPerformanceSource);

												last.Reset(); next.Reset();
												last.Add(minStepLifeLenght * perf.PerformanceGroupNum);
												last.Add(currentOffset);
												next.Add(last);
												if (perf.PerformanceDate != null && check.Interval.CalendarValue != null)
													next.Add(Convert.ToDateTime(perf.PerformanceDate), check.Interval);
												else next.Add(check.Interval);
											}
											else
											{
												currentOffset.Reset();
												currentOffset.Add(globalOffsetLifelength);

												last.Reset(); next.Reset();
												last.Add(perf.PerformanceSource);
												next.Add(last);
												if (perf.PerformanceDate != null && check.Interval.CalendarValue != null)
													next.Add(Convert.ToDateTime(perf.PerformanceDate), check.Interval);
												else next.Add(check.Interval);
											}
										}
										else
										{
											currentOffset.Reset();
											currentOffset.Add(globalOffsetLifelength);

											last.Reset(); next.Reset();
											last.Add(perf.PerformanceSource);
											next.Add(last);
											if (perf.PerformanceDate != null && check.Interval.CalendarValue != null)
												next.Add(Convert.ToDateTime(perf.PerformanceDate), check.Interval);
											else next.Add(check.Interval);
										}
										//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
										//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
										if (next.GetSubresource(sub) != null && (next - currentOffset).GetSubresource(sub)
											> maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
										{
											cyclesCount += 1;
											mnp.PerformanceSource.Reset();
											//вычисление нового ресурса выполнения
											//1.возвращается предыдущее значение выполнения
											mnp.PerformanceSource.Add(last);
											if (check.Interval.GetSubresource(sub) > maintenanceCheckGroup.CheckCycle)
											{
												if (check.ParentAircraft != null && check.ParentAircraft.MSG >= MSG.MSG3)
												{
													//Если интервал чека больше интервала всей группы и ВС
													//ведет свое обслуживание по программе MSG3,
													//то дальнейшая калькуляция данного чека не имеет смысла
													break;
												}
												//если интервал выполнения чека больше цикла группы чеков 
												int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
												mnp.PerformanceGroupNum = perf.PerformanceGroupNum + countSteps;
												mnp.PerformanceNum = perf.PerformanceNum + 1;
												if (perf.PerformanceDate != null && minStepLifeLenght.CalendarValue != null)
													mnp.PerformanceSource.Add(Convert.ToDateTime(perf.PerformanceDate), minStepLifeLenght * countSteps);
												else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
											}
											else if (check.Interval.GetSubresource(sub) == maintenanceCheckGroup.CheckCycle)
											{
												//если интервал выполнения чека больше цикла группы чеков 
												int countSteps = Convert.ToInt32(maintenanceCheckGroup.CheckCycle / minStep);
												mnp.PerformanceGroupNum = perf.PerformanceGroupNum + countSteps;
												mnp.PerformanceNum = perf.PerformanceNum + 1;
												if (perf.PerformanceDate != null && minStepLifeLenght.CalendarValue != null)
													mnp.PerformanceSource.Add(Convert.ToDateTime(perf.PerformanceDate), minStepLifeLenght * countSteps);
												else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
											}
											else
											{
												if (check.ParentAircraft != null && check.ParentAircraft.MSG >= MSG.MSG3)
												{
													//Если СЛЕД. ВЫПОЛЕНИЕ чека больше интервала всей группы и ВС
													//ведет свое обслуживание по программе MSG3,
													//то НУЖНО ПРОИЗВЕСТИ РАСЧЕТ ВЫПОЛНЕНИЯ НА СЛЕД. ЦИКЛЕ
													mnp.PerformanceGroupNum =
														Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep) +
														Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
													mnp.PerformanceNum = perf.PerformanceNum + 1;

													int countSteps = mnp.PerformanceGroupNum - perf.PerformanceGroupNum;
													if (perf.PerformanceDate != null && minStepLifeLenght.CalendarValue != null)
														mnp.PerformanceSource.Add(Convert.ToDateTime(perf.PerformanceDate), minStepLifeLenght * countSteps);
													else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
												}
												else
												{
													mnp.PerformanceGroupNum =
														Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep);
													mnp.PerformanceNum = perf.PerformanceNum + 1;
													//если интервал выполнения чека меньше цикла группы чеков 
													//2. расчитывается кол-во минимальных шагов, оставшихся между ресурсом
													//предыдущего выполнения и границей цикла (с учетом смещения)
													int countSteps = mnp.PerformanceGroupNum - perf.PerformanceGroupNum;
													if (perf.PerformanceDate != null && minStepLifeLenght.CalendarValue != null)
														mnp.PerformanceSource.Add(Convert.ToDateTime(perf.PerformanceDate), minStepLifeLenght * countSteps);
													else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
												}
											}
										}
										else if (next.GetSubresource(sub) != null && (next - currentOffset).GetSubresource(sub)
												 == maintenanceCheckGroup.CheckCycle * (cyclesCount + 1))
										{
											cyclesCount += 1;
											mnp.PerformanceSource.Reset();
											//вычисление нового ресурса выполнения
											//1.возвращается предыдущее значение выполнения
											mnp.PerformanceSource.Add(last);

											mnp.PerformanceGroupNum =
														Convert.ToInt32(cyclesCount * maintenanceCheckGroup.CheckCycle / minStep);
											mnp.PerformanceNum = perf.PerformanceNum + 1;
											//если интервал выполнения чека меньше цикла группы чеков 
											//2. расчитывается кол-во минимальных шагов, оставшихся между ресурсом
											//предыдущего выполнения и границей цикла (с учетом смещения)
											int countSteps = mnp.PerformanceGroupNum - perf.PerformanceGroupNum;
											if (perf.PerformanceDate != null && minStepLifeLenght.CalendarValue != null)
												mnp.PerformanceSource.Add(Convert.ToDateTime(perf.PerformanceDate), minStepLifeLenght * countSteps);
											else mnp.PerformanceSource.Add(minStepLifeLenght * countSteps);
										}
										else
										{
											mnp.PerformanceGroupNum = perf.PerformanceGroupNum + Convert.ToInt32(check.Interval.GetSubresource(sub) / minStep);
											mnp.PerformanceNum = perf.PerformanceNum + 1;
											mnp.PerformanceSource.Reset();
											mnp.PerformanceSource.Add(next);
										}

										mnp.PerformanceSource.Resemble(check.Interval);
									}
								}

								#endregion

								if (mnp == null)
									break;

								#region Определение остатка ресурса (Remain), ресурса предупреждения(Notify),
								//условия(ThresholdConditionType) и 
								//приблизительной даты (approximate date) следующего выполнения

								mnp.Remains = new Lifelength(mnp.PerformanceSource);
								mnp.Remains.Substract(current); // remains = next - current
								mnp.Remains.Resemble(mnp.PerformanceSource);

								// Condition State и Approximate Date расчитывается по разному в зависимости от Whichever First и Whichever Later 
								// Whichever First и Whichever Later - разные для первого выполнения и повтороного выполнения
								ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst;
								Lifelength notifyRemains;
								Lifelength notify = new Lifelength(check.Notify);
								// расчитываем approximate date - для этого нам нужен AverageUtilization
								mnp.PerformanceDate =
									au != null ? AnalystHelper.GetApproximateDate(mnp.Remains, au, conditionType)
										: null;

								#region расчет approximate date - для этого нам нужен AverageUtilization
								if (au != null)
								{
									if ((mnp.Remains.IsAllOverdue() && conditionType == ThresholdConditionType.WhicheverLater) ||
										(mnp.Remains.IsOverdue() && conditionType == ThresholdConditionType.WhicheverFirst))
									{
										//DateTime? dt = GetApproximateDate(directive.LifeLengthParent, np.PerformanceSource, conditionType);
										//if (dt != null)
										//{

										//}
										if (check.NextPerformances.Count > 0 &&
											check.NextPerformances.Last().PerformanceDate != null)
										{
											//к дате пред. выполнения добавляется количество дней
											//за которое будет израсходован повторяющийся интервал директивы
											//с учетом заданной средней утилизации
											double? days =
												AnalystHelper.GetApproximateDays(Convert.ToDateTime(check.NextPerformances.Last().PerformanceDate),
																		   check.Interval, au, conditionType);
											if (days != null)
												mnp.PerformanceDate = check.NextPerformances.Last().PerformanceDate.Value.AddDays(Convert.ToDouble(days));
											else mnp.PerformanceDate = null;
										}
										else if (check.LastPerformance != null)
										{
											double? days =
												AnalystHelper.GetApproximateDays(check.LastPerformance.RecordDate,
																		   check.Interval, au, conditionType);
											if (days != null)
												mnp.PerformanceDate = check.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
											else mnp.PerformanceDate = null;
										}
										else
										{
											double? days = AnalystHelper.GetApproximateDays(mnp.PerformanceSource, au, conditionType);
											if (days != null)
												mnp.PerformanceDate = _calculator.GetManufactureDate(check.LifeLengthParent).AddDays(Convert.ToDouble(days));
											else mnp.PerformanceDate = null;
										}
									}
									else
									{
										//if (directive is MaintenanceCheck && ((MaintenanceCheck)directive).Name == "DY")
										//{
										//    directive.ToString();
										//}

										mnp.PerformanceDate = AnalystHelper.GetApproximateDate(mnp.Remains, au, conditionType);
									}
								}
								else
								{
									mnp.PerformanceDate = null;
								}
								#endregion

								#endregion

								//Добавление нового выполнения в текущий расчитываемый чек
								if (forecast == null ||
									(forecast != null && (mnp.PerformanceSource - maxAfterForecastSource).GetSubresource(sub) <= 0))
									check.NextPerformances.Add(mnp);

								#region Добавление нового выполнения в коллекцию групп выполнений
								//1. Определение конкретной группы выполнения, в которой может выполнится 
								//   только что расчитанное "След. выполнение"
								MaintenanceCheckGroupByType performanceGroup = null;
								for (int i = performancesGroups.Count - 1; i >= 0; i--)
								{
									//Поиск с конца коллекции групп, группы, чей ресурс выполнения
									//равен ресурсу выполнения только что расчитанного "След. выполнения"
									int? source = performancesGroups[i].GroupComplianceLifelength.GetSubresource(sub);
									int? npSource = mnp.PerformanceSource.GetSubresource(sub);
									if (source != null && npSource != null)
									{
										if (source < npSource)
										{
											//Если ресурс выполнения performancesGroups[i] группы меньше
											//искомого, то продолжения проверки не имеет смысла
											break;
										}
										if (source == npSource)
										{
											//Если ресурс выполнения performancesGroups[i] группы равен
											//искомому, то искомая группа наидена
											performanceGroup = performancesGroups[i];
											break;
										}
									}
								}
								if (performanceGroup == null)
								{
									//Если группа выполнения для данного "След.выполнения" не найдена
									//то необходимо создать новую группу
									performanceGroup = new MaintenanceCheckGroupByType(check.Schedule);
									performanceGroup.GroupComplianceLifelength = mnp.PerformanceSource;
									performanceGroup.GroupComplianceNum = mnp.PerformanceGroupNum;
									performanceGroup.CheckCycle = maintenanceCheckGroup.CheckCycle;
									performancesGroups.Add(performanceGroup);
									performancesGroups.OrderByGroupComplianceNum();
								}
								//2. Добавление текущего рассчитываемого чека в определенную группу
								if (!performanceGroup.Checks.Contains(check))
								{
									performanceGroup.Checks.Add(check);
									if (performanceGroup.CheckCycle < maintenanceCheckGroup.CheckCycle)
										performanceGroup.CheckCycle = maintenanceCheckGroup.CheckCycle;
								}
								#endregion

								#region Расчет текущего состояния задачи в зависимости от условий выполнения

								if (conditionType == ThresholdConditionType.WhicheverFirst)
								{
									// задано только одно условие выполнения - считаем по whichever first
									// whichever first

									// состояние директивы - просрочена или нормально

									if (notify != null && !notify.IsNullOrZero())
									{
										notifyRemains = new Lifelength(mnp.PerformanceSource);
										notifyRemains.Substract(notify);
										notifyRemains.Substract(current);
										notifyRemains.Resemble(notify);
										mnp.Condition = mnp.Remains.IsOverdue()
														   ? ConditionState.Overdue
														   : (notifyRemains.IsOverdue()
																  ? ConditionState.Notify
																  : ConditionState.Satisfactory);
									}
									else
									{
										mnp.Condition = mnp.Remains.IsOverdue() ? ConditionState.Overdue : ConditionState.Satisfactory;
									}

								}
								else // whichever later
								{
									// директива просрочена только в том случае, когда она просрочена по всем параметрам
									if (notify != null && !notify.IsNullOrZero())
									{
										notifyRemains = new Lifelength(mnp.PerformanceSource);
										notifyRemains.Substract(notify);
										notifyRemains.Substract(current);
										notifyRemains.Resemble(notify);
										mnp.Condition = mnp.Remains.IsAllOverdue()
														   ? ConditionState.Overdue
														   : (notifyRemains.IsAllOverdue()
																  ? ConditionState.Notify
																  : ConditionState.Satisfactory);
									}
									else
									{
										mnp.Condition = mnp.Remains.IsAllOverdue() ? ConditionState.Overdue : ConditionState.Satisfactory;
									}
								}

								#endregion

								#region Определение остатков ресурсов (при наличии прогноза)

								if (forecast == null) break;

								check.ForecastLifelength = _calculator.GetCurrentFlightLifelength(check.LifeLengthParent, forecast);
								mnp.BeforeForecastResourceRemain = new Lifelength(check.ForecastLifelength);

								//Производится расчет ресурса директивы, который проидет от
								//ее начальной точки (или последнего выполнения) до ресурса прогноза
								if (last.IsNullOrZero())
								{
									//ресурса последнего выполнения перед прогнозом нет
									//значит точка прогноза находится между начальной точкой директивы 
									//и первым выполнением директивы

									//определение положения текущей точки (сегодняшней даты и наработки на сегодня)
									if (!check.Interval.IsNullOrZero())
									{
										//в противном случае ресурс меджу точкои прогноза и начальной точкой
										//равен самому ресурсу прогноза, т.к. ресурс начальной точки равен 0
										mnp.BeforeForecastResourceRemain.NullSubstract(last);
									}

								}
								else
								{
									//ресурс последнего выполнения перед прогнозом есть.
									//значит точка прогноза находится между точкой последнего выполнения 
									//и точкой следующего выполнения директивы 
									mnp.BeforeForecastResourceRemain.NullSubstract(last);
								}

								mnp.BeforeForecastResourceRemain.Resemble(mnp.PerformanceSource);

								if (maxAfterForecastSource.GetSubresource(sub) != null)
								{
									int? npSource = mnp.PerformanceSource.GetSubresource(sub);
									if (npSource > forecast.ForecastLifelength.GetSubresource(sub) &&
									   npSource <= maxAfterForecastSource.GetSubresource(sub))
									{
										mnp.CalcForHight = true;
									}
									//выполнение происходит по принципу "что первее")
									if (mnp.PerformanceSource.GetSubresource(sub) > check.ForecastLifelength.GetSubresource(sub))
									{
										//точка следующего выполнения меньше точки прогноза
										//и повторяющегося инервала нет
										//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
										//расчет остатка в процентах
										if (check.Percents == null)
										{
											check.AfterForecastResourceRemain = new Lifelength(mnp.PerformanceSource);
											check.AfterForecastResourceRemain.NullSubstract(check.ForecastLifelength);
											Lifelength full = new Lifelength(mnp.BeforeForecastResourceRemain);
											full.Add(check.AfterForecastResourceRemain);
											check.Percents = full.GetPercents(check.AfterForecastResourceRemain);
										}
									}

									if (mnp.PerformanceSource.GetSubresource(sub) <= maxAfterForecastSource.GetSubresource(sub) &&
										check.Interval.IsNullOrZero())
									{
										//точка следующего выполнения меньше точки прогноза
										//и повторяющегося инервала нет
										//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
										break;
									}

									if (mnp.PerformanceSource.GetSubresource(sub) >= maxAfterForecastSource.GetSubresource(sub) ||
										check.Interval.IsNullOrZero())
									{
										//точка следующего выполнения больше точки прогноза
										//или повторяющегося инервала нет
										//ресурс между точкой прогноза и точкой следующего выполнения 
										//равняется directive.NextCompliance - forecast.ForecastLifelength
										break;
									}
								}
								else
								{
									//выполнение происходит по принципу "что первее"
									if (mnp.PerformanceSource.GetSubresource(sub) <= check.ForecastLifelength.GetSubresource(sub) &&
										check.Interval.IsNullOrZero())
									{
										//точка следующего выполнения меньше точки прогноза
										//и повторяющегося инервала нет
										//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
										check.AfterForecastResourceRemain = Lifelength.Null;
										check.Percents = null;
										break;
									}

									if (mnp.PerformanceSource.GetSubresource(sub) > check.ForecastLifelength.GetSubresource(sub) ||
										check.Interval.IsNullOrZero())
									{
										//точка следующего выполнения больше точки прогноза
										//или повторяющегося инервала нет
										//ресурс между точкой прогноза и точкой следующего выполнения 
										//равняется directive.NextCompliance - forecast.ForecastLifelength
										check.AfterForecastResourceRemain = new Lifelength(mnp.PerformanceSource);
										check.AfterForecastResourceRemain.NullSubstract(check.ForecastLifelength);
										break;
									}
									// расчет остатка в процентах
									if (check.AfterForecastResourceRemain != null && !check.AfterForecastResourceRemain.IsNullOrZero())
									{
										Lifelength full = new Lifelength(mnp.BeforeForecastResourceRemain);
										full.Add(check.AfterForecastResourceRemain);
										check.Percents = full.GetPercents(check.AfterForecastResourceRemain);
									}
								}
								#endregion
							}
						}
					}

					foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in checksGroupsCollection)
					{
						foreach (MaintenanceCheck check in maintenanceCheckGroup.Checks)
						{
							foreach (MaintenanceNextPerformance nextPerformance in check.NextPerformances)
							{
								nextPerformance.PerformanceGroup =
									performancesGroups.Where(p => p.GroupComplianceNum == nextPerformance.PerformanceGroupNum).FirstOrDefault();
							}
						}
					}
				}
				else
				{
					NextPerformance np;
					NextPerformance lastNp;
					foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in checksGroupsCollection)
					{
						maintenanceCheckGroup.Sort();
						if (maintenanceCheckGroup.GetMinIntervalCheck() == null)
							continue;
						if (maintenanceCheckGroup.CheckType.Priority > 0 &&
							maintenanceCheckGroup.GetMinIntervalCheck().ParentAircraft.MSG >= MSG.MSG3)
						{
							foreach (MaintenanceCheck check in maintenanceCheckGroup.Checks)
							{
								//if (check.Name == "DY")
								//{
								//    check.Name.ToString();
								//}
								check.ResetMathData();
								for (;;)
								{
									np = null;

									#region Определение возможности след. выполения и ресурса на котором оно произойдет

									if (check.NextPerformances.Count == 0)
									{
										if (check.LastPerformance == null) // директива ни разу не выполнялась
										{
											np = new NextPerformance { Parent = check };
											last.Reset();
											// с момента производства
											Lifelength sinceNew = check.Interval;
											//Провекра, не выходит ли расчитанное "След.Выполнение" (с учетом смещения) за границы
											//цикла тек. группы чеков данного типа (см. своиство check.CheckType)
											np.PerformanceNum = 1;
											np.PerformanceSource.Reset();
											if (sinceNew.CalendarValue != null)
												np.PerformanceSource.Add(check.ParentAircraft.ManufactureDate, sinceNew);
											else np.PerformanceSource.Add(sinceNew);

											MaintenanceCheckRecord mcr = checksGroupsCollection.SelectMany(g => g.Checks)
																				.Where(c => c.CheckType.Priority > 0)
																				.SelectMany(c => c.PerformanceRecords.Where(r => r.IsControlPoint))
																				.OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
																				.LastOrDefault(r => (r.ParentCheck.Interval * r.PerformanceNum).GetSubresource(sub) <= np.PerformanceSource.GetSubresource(sub));
											if (mcr != null)
											{
												if (mcr.CalculatedPerformanceSource != null && !mcr.CalculatedPerformanceSource.IsNullOrZero())
													np.PerformanceSource.Add(mcr.OnLifelength - mcr.CalculatedPerformanceSource);
												else np.PerformanceSource.Add(mcr.OnLifelength - (mcr.ParentCheck.Interval * mcr.PerformanceNum));
											}
											// Убираем ненужные параметры
											np.PerformanceSource.Resemble(sinceNew);
										}
										else // Директива уже выполнялась 
										{
											// Расчитываем условие следующего выполнения
											// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
											if (check.Interval != null && !check.Interval.IsNullOrZero())
											{
												np = new NextPerformance { Parent = check };

												last = check.LastPerformance.OnLifelength;

												int lastPerfNum = check.LastPerformance.PerformanceNum <= 0 ? 1 : check.LastPerformance.PerformanceNum;
												np.PerformanceNum = lastPerfNum + check.NextPerformances.Count + 1;
												np.PerformanceSource.Reset();
												if (check.Interval.CalendarValue != null)
													np.PerformanceSource.Add(check.LastPerformance.RecordDate, (check.Interval * np.PerformanceNum));
												else np.PerformanceSource.Add(check.Interval * np.PerformanceNum);

												MaintenanceCheckRecord mcr = checksGroupsCollection.SelectMany(g => g.Checks)
																				 .Where(c => c.CheckType.Priority > 0)
																				 .SelectMany(c => c.PerformanceRecords.Where(r => r.IsControlPoint))
																				 .OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
																				 .LastOrDefault(r => (r.ParentCheck.Interval * r.PerformanceNum).GetSubresource(sub) <= np.PerformanceSource.GetSubresource(sub));
												if (mcr != null)
												{
													if (mcr.CalculatedPerformanceSource != null && !mcr.CalculatedPerformanceSource.IsNullOrZero())
														np.PerformanceSource.Add(mcr.OnLifelength - mcr.CalculatedPerformanceSource);
													else np.PerformanceSource.Add(mcr.OnLifelength - (mcr.ParentCheck.Interval * mcr.PerformanceNum));
												}
												// Убираем не нужные параметры
												np.PerformanceSource.Resemble(check.Interval);
											}
										}
									}
									else
									{
										// Расчитываем условие следующего выполнения
										// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
										if (check.Interval != null && !check.Interval.IsNullOrZero())
										{
											np = new NextPerformance { Parent = check };

											lastNp = check.NextPerformances.Last();
											np.PerformanceNum = lastNp.PerformanceNum + 1;
											np.PerformanceSource.Reset();
											if (lastNp.PerformanceDate != null && check.Interval.CalendarValue != null)
												np.PerformanceSource.Add(Convert.ToDateTime(lastNp.PerformanceDate), (check.Interval * np.PerformanceNum));
											else np.PerformanceSource.Add(check.Interval * np.PerformanceNum);

											MaintenanceCheckRecord mcr = checksGroupsCollection.SelectMany(g => g.Checks)
																				.Where(c => c.CheckType.Priority > 0)
																				.SelectMany(c => c.PerformanceRecords.Where(r => r.IsControlPoint))
																				.OrderByDescending(r => r.OnLifelength.GetSubresource(sub))
																				.LastOrDefault(r => (r.ParentCheck.Interval * r.PerformanceNum).GetSubresource(sub) <= np.PerformanceSource.GetSubresource(sub));
											if (mcr != null)
											{
												if (mcr.CalculatedPerformanceSource != null && !mcr.CalculatedPerformanceSource.IsNullOrZero())
													np.PerformanceSource.Add(mcr.OnLifelength - mcr.CalculatedPerformanceSource);
												else np.PerformanceSource.Add(mcr.OnLifelength - (mcr.ParentCheck.Interval * mcr.PerformanceNum));
											}
											// Убираем не нужные параметры
											np.PerformanceSource.Resemble(check.Interval);
										}
									}

									#endregion

									if (np == null)
									{
										break;
									}

									#region Определение остатка ресурса (Remain), ресурса предупреждения(Notify),
									//условия(ThresholdConditionType) и 
									//приблизительной даты (approximate date) следующего выполнения

									np.Remains = new Lifelength(np.PerformanceSource);
									np.Remains.Substract(current); // remains = next - current
									np.Remains.Resemble(np.PerformanceSource);

									// Condition State и Approximate Date расчитывается по разному в зависимости от Whichever First и Whichever Later 
									// Whichever First и Whichever Later - разные для первого выполнения и повтороного выполнения
									ThresholdConditionType conditionType;
									Lifelength notify, notifyRemains;
									if (check.LastPerformance == null)
									{
										conditionType = check.Threshold.FirstPerformanceConditionType;
										notify = check.Notify != null
													 ? new Lifelength(check.Notify)
													 : null;
									}
									else if (check.Interval != null && !check.Interval.IsNullOrZero())
									{
										conditionType = check.Threshold.RepeatPerformanceConditionType;
										notify = check.Threshold.RepeatNotification != null
													 ? new Lifelength(check.Threshold.RepeatNotification)
													 : null;
									}
									else
									{
										throw new Exception("1234: Incorrect directive status");
									}

									//расчет approximate date - для этого нам нужен AverageUtilization
									if (au != null)
									{
										if ((np.Remains.IsAllOverdue() && conditionType == ThresholdConditionType.WhicheverLater) ||
											(np.Remains.IsOverdue() && conditionType == ThresholdConditionType.WhicheverFirst))
										{
											//DateTime? dt = GetApproximateDate(directive.LifeLengthParent, np.PerformanceSource, conditionType);
											//if (dt != null)
											//{

											//}
											if (check.NextPerformances.Count > 0 &&
												check.NextPerformances.Last().PerformanceDate != null)
											{
												//к дате пред. выполнения добавляется количество дней
												//за которое будет израсходован повторяющийся интервал директивы
												//с учетом заданной средней утилизации
												double? days =
													AnalystHelper.GetApproximateDays(Convert.ToDateTime(check.NextPerformances.Last().PerformanceDate),
																			   check.Interval, au, conditionType);
												if (days != null)
													np.PerformanceDate = check.NextPerformances.Last().PerformanceDate.Value.AddDays(Convert.ToDouble(days));
												else np.PerformanceDate = null;
											}
											else if (check.LastPerformance != null)
											{
												double? days =
													AnalystHelper.GetApproximateDays(check.LastPerformance.RecordDate,
																			   check.Interval, au, conditionType);
												if (days != null)
													np.PerformanceDate = check.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
												else np.PerformanceDate = null;
											}
											else
											{
												double? days = AnalystHelper.GetApproximateDays(np.PerformanceSource, au, conditionType);
												if (days != null)
													np.PerformanceDate = _calculator.GetManufactureDate(check.LifeLengthParent).AddDays(Convert.ToDouble(days));
												else np.PerformanceDate = null;
											}
										}
										else
										{
											np.PerformanceDate = AnalystHelper.GetApproximateDate(np.Remains, au, conditionType);
										}
									}
									else
									{
										np.PerformanceDate = null;
									}
									#endregion

									check.NextPerformances.Add(np);

									#region Расчет текущего состояния задачи в зависимости от условий выполнения

									if (conditionType == ThresholdConditionType.WhicheverFirst)
									{
										// задано только одно условие выполнения - считаем по whichever first
										// whichever first

										// состояние директивы - просрочена или нормально

										if (notify != null && !notify.IsNullOrZero())
										{
											notifyRemains = new Lifelength(np.PerformanceSource);
											notifyRemains.Substract(notify);
											notifyRemains.Substract(current);
											notifyRemains.Resemble(notify);
											np.Condition = np.Remains.IsOverdue()
															   ? ConditionState.Overdue
															   : (notifyRemains.IsOverdue()
																	  ? ConditionState.Notify
																	  : ConditionState.Satisfactory);
										}
										else
										{
											np.Condition = np.Remains.IsOverdue() ? ConditionState.Overdue : ConditionState.Satisfactory;
										}
									}
									else // whichever later
									{
										// директива просрочена только в том случае, когда она просрочена по всем параметрам
										if (notify != null && !notify.IsNullOrZero())
										{
											notifyRemains = new Lifelength(np.PerformanceSource);
											notifyRemains.Substract(notify);
											notifyRemains.Substract(current);
											notifyRemains.Resemble(notify);
											np.Condition = np.Remains.IsAllOverdue()
															   ? ConditionState.Overdue
															   : (notifyRemains.IsAllOverdue()
																	  ? ConditionState.Notify
																	  : ConditionState.Satisfactory);
										}
										else
										{
											np.Condition = np.Remains.IsAllOverdue() ? ConditionState.Overdue : ConditionState.Satisfactory;
										}
									}

									#endregion

									#region Определение остатков ресурсов (при наличии прогноза)

									if (forecast == null) break;

									check.ForecastLifelength = _calculator.GetCurrentFlightLifelength(check.LifeLengthParent, forecast);
									np.BeforeForecastResourceRemain = new Lifelength(check.ForecastLifelength);

									//Производится расчет ресурса директивы, который проидет от
									//ее начальной точки (или последнего выполнения) до ресурса прогноза
									if (last.IsNullOrZero())
									{
										//ресурса последнего выполнения перед прогнозом нет
										//значит точка прогноза находится между начальной точкой директивы 
										//и первым выполнением директивы

										//определение положения текущей точки (сегодняшней даты и наработки на сегодня)
										if (!check.Interval.IsNullOrZero())
										{
											//в противном случае ресурс меджу точкои прогноза и начальной точкой
											//равен самому ресурсу прогноза, т.к. ресурс начальной точки равен 0
											np.BeforeForecastResourceRemain.NullSubstract(last);
										}

									}
									else
									{
										//ресурс последнего выполнения перед прогнозом есть.
										//значит точка прогноза находится между точкой последнего выполнения 
										//и точкой следующего выполнения директивы 
										np.BeforeForecastResourceRemain.NullSubstract(last);
									}

									np.BeforeForecastResourceRemain.Resemble(np.PerformanceSource);

									if (conditionType == ThresholdConditionType.WhicheverFirst)
									{
										//выполнение происходит по принципу "что первее"
										if (np.PerformanceSource.IsLessOrEqualByAnyParameter(check.ForecastLifelength) &&
											check.Interval.IsNullOrZero())
										{
											//точка следующего выполнения меньше точки прогноза
											//и повторяющегося инервала нет
											//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
											check.AfterForecastResourceRemain = Lifelength.Null;
											check.Percents = null;
											break;
										}

										if (np.PerformanceSource.IsGreaterNullable(check.ForecastLifelength) ||
											check.Interval.IsNullOrZero())
										{
											//точка следующего выполнения больше точки прогноза
											//или повторяющегося инервала нет
											//ресурс между точкой прогноза и точкой следующего выполнения 
											//равняется directive.NextCompliance - forecast.ForecastLifelength
											check.AfterForecastResourceRemain = new Lifelength(np.PerformanceSource);
											check.AfterForecastResourceRemain.NullSubstract(check.ForecastLifelength);
											break;
										}
									}
									else // whichever later
									{
										// директива просрочена только в том случае, когда она просрочена по всем параметрам
										if (np.PerformanceSource.IsLessByAnyParameterNullable(check.ForecastLifelength) &&
											check.Interval.IsNullOrZero())
										{
											//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
											check.AfterForecastResourceRemain = Lifelength.Null;
											check.Percents = null;
											break;
										}

										if (np.PerformanceSource.IsGreaterByAnyParameter(check.ForecastLifelength) ||
											check.Interval.IsNullOrZero())
										{
											check.AfterForecastResourceRemain = new Lifelength(np.PerformanceSource);
											check.AfterForecastResourceRemain.NullSubstract(check.ForecastLifelength);
											//directive.AfterForecastResourceRemain.Resemble(directive.NextCompliance);
											break;
										}
									}

									// расчет остатка в процентах
									if (check.AfterForecastResourceRemain != null && !check.AfterForecastResourceRemain.IsNullOrZero())
									{
										Lifelength full = new Lifelength(np.BeforeForecastResourceRemain);
										full.Add(check.AfterForecastResourceRemain);
										check.Percents = full.GetPercents(check.AfterForecastResourceRemain, conditionType);
									}

									#endregion
								}
							}
						}
						else
						{
							foreach (MaintenanceCheck check in maintenanceCheckGroup.Checks)
							{
								//if (check.Name == "DY")
								//{
								//    check.Name.ToString();
								//}

								check.ResetMathData();
								_performanceCalculator.GetNextPerformance(check, forecast);
							}
						}
					}
				}
			}
		}
		#endregion

		#region public MaintenanceCheckGroupByType GetNextCheckComplianceGroup(MaintenanceCheckCollection collection, bool schedule, Aircraft aircraft)
		public MaintenanceCheckGroupByType GetNextCheckComplianceGroup(MaintenanceCheckCollection collection, bool schedule, Aircraft aircraft)
		{
			if (aircraft == null || collection == null) return null;

			List<MaintenanceCheck> aircraftScheduleChecks = collection.GetChecksByAircraftId(aircraft.ItemId, schedule);
			Lifelength aircraftll = _calculator.GetCurrentFlightLifelength(aircraft);
			MaintenanceCheckGroupCollection groupCollection;
			if (aircraftScheduleChecks.All(check => check.LastPerformance == null))
			{
				//по данному типу чеков не было ни единого выполнения
				//задание начальной точки
				groupCollection = aircraftScheduleChecks.GetFirstCheckBySource(schedule, aircraftll.Hours);
				if (groupCollection == null || groupCollection.Count == 0) return null;
				Lifelength minStep = new MaintenanceCheckCollection(aircraftScheduleChecks.ToArray()).GetMinStepCheck(schedule).Interval;

				foreach (MaintenanceCheckGroupByType item in groupCollection)
				{
					MaintenanceCheck maxIntervalCheckInGroup;
					if ((maxIntervalCheckInGroup = item.GetMaxIntervalCheck()) == null) continue;
					item.Sort();
					//Lifelength minStep = item.GetMinIntervalCheck().Interval;
					item.GroupComplianceLifelength = new Lifelength
					{
						Hours = minStep.Hours * item.GroupComplianceNum,
						Cycles = minStep.Cycles * item.GroupComplianceNum,
						Days = minStep.Days * item.GroupComplianceNum
					};
					//дата следующего выполнения группы чеков
					item.GroupComplianceLifelength.Resemble(maxIntervalCheckInGroup.Interval);
					item.GroupComplianceDate =
						maxIntervalCheckInGroup.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(item.GroupComplianceLifelength.Days));
				}
			}
			else //для заданного типа чеков есть последнее выаолнение
			{
				//вычисление самого последнего выполненного чека, вне зависимости от типа
				//последний выполненый чек по типу может нессответствовать текущему типу программы 
				//в случае переключения
				MaintenanceCheck lastComplianceCheck =
					aircraftScheduleChecks.Where(c => c.LastPerformance != null).OrderByDescending(c => c.LastPerformance.RecordDate).First();
				if (lastComplianceCheck.Schedule != schedule && schedule)
				{
					//тип программмы Maintenance был переключен, переключение с Unschedule на Schedule
					//вычисление самого последнего выполненного чека, заданного типа
					MaintenanceCheck lastComplianceScheduleTypeCheck =
						 aircraftScheduleChecks.Where(c => c.LastPerformance != null && c.Schedule == schedule).OrderByDescending(c => c.LastPerformance.RecordDate).First();

					MaintenanceCheckGroupByType group = aircraftScheduleChecks.GetNextCheckBySourceDifference(lastComplianceScheduleTypeCheck, aircraftll.Days);
					return group;
				}
				groupCollection = aircraftScheduleChecks.GetNextCheckByLastCompliane(schedule);

				foreach (MaintenanceCheckGroupByType item in groupCollection)
				{
					if (item.GetMaxIntervalCheck() == null) continue;
					item.Sort();

					List<MaintenanceCheck> checkLast;
					if (schedule)
					{
						checkLast = (from check in item.Checks
									 where
										 check.LastPerformance != null &&
										 check.LastPerformance.OnLifelength != null &&
										 check.LastPerformance.OnLifelength.Hours != null &&
										 check.Schedule == schedule
									 orderby check.Interval.Hours
									 select check).ToList();
					}
					else
					{
						checkLast = (from check in item.Checks
									 where
										 check.LastPerformance != null &&
										 check.LastPerformance.OnLifelength != null &&
										 check.LastPerformance.OnLifelength.Days != null &&
										 check.Schedule == schedule
									 orderby check.Interval.Days
									 select check).ToList();
					}
					if (checkLast.Count() == 0 || checkLast.First() == null) continue;


					//дата следующего выполнения группы чеков
					item.GroupComplianceDate = checkLast.First().LastPerformance.RecordDate.AddDays(Convert.ToInt32(checkLast.First().Interval.Days));
					//tRemainDays += maxIntervalCheckInGroup.Name + " (" + (int)(nextDate - DateTime.Now).TotalDays + "d) ";
					//ресурс, на котором надо поризвести выполнение
					item.GroupComplianceLifelength = new Lifelength
					{
						Hours = Convert.ToInt32(checkLast.First().LastPerformance.OnLifelength.Hours) +
																	 Convert.ToInt32(checkLast.First().Interval.Hours),
						Cycles = Convert.ToInt32(checkLast.First().LastPerformance.OnLifelength.Cycles) +
																	  Convert.ToInt32(checkLast.First().Interval.Cycles),
						Days = Convert.ToInt32(checkLast.First().LastPerformance.OnLifelength.Days) +
																	Convert.ToInt32(checkLast.First().Interval.Days)
					};
				}
			}
			return groupCollection[0];
		}
		#endregion
	}
}