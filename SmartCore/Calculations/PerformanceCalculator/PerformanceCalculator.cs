using System;
using System.Linq;
using SmartCore.Analyst;
using SmartCore.AverageUtilizations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations.PerformanceCalculator
{
	//TODO (Evgenii Babak): рассмотреть код и избавиться от повторений
	public class PerformanceCalculator : IPerformanceCalculator
	{
		private readonly ICalculator _calculator;
		private readonly IAverageUtilizationCore _averageUtilizationCore;
		private readonly IMTOPCalculator _mtopCalculator;

		public PerformanceCalculator(ICalculator calculator, IAverageUtilizationCore averageUtilizationCore, IMTOPCalculator mtopCalculator)
		{
			_calculator = calculator;
			_averageUtilizationCore = averageUtilizationCore;
			_mtopCalculator = mtopCalculator;
		}

		#region public void GetNextPerformance(Document directive)
		/// <summary>
		/// Расчитывает следующее выполнение Document вместе с дополнительными параметрами
		/// </summary>
		/// <param name="directive">Принимает документ</param>
		public void GetNextPerformance(Document directive)
		{
			// Если следующего выполнения нет - то все остальные данные не имеют смысла
			if ((directive.IssueValidTo == false && directive.RevisionValidTo == false) || directive.IsClosed)
			{
				directive.Remains = null;
				directive.RevisionRemains = null;
				directive.NextPerformanceDate = null;
				directive.Condition = ConditionState.NotEstimated;
			}
			else // Директива имеет следующее выполнение 
			{
				Lifelength issueNotify = null, revisionNotify = null, performanceSource = null;

				// расчитываем remains
				if (directive.IssueValidTo)
				{
					var t = directive.IssueDateValidTo - DateTime.Today;
					directive.Remains = new Lifelength(t.Days, null, null);

					issueNotify = directive.IssueNotify > 0
								  ? new Lifelength(directive.IssueNotify, null, null)
								  : null;
					performanceSource = new Lifelength(directive.Remains);//TODO:(Evgenii Babak) выяснить почему у performanceSource такое же значение, что и у Remains
				}

				if (directive.RevisionValidTo)
				{
					var t = directive.RevisionDateValidTo - DateTime.Today;
					directive.RevisionRemains = new Lifelength(t.Days, null, null);

					revisionNotify = directive.RevisionNotify > 0
								  ? new Lifelength(directive.RevisionNotify, null, null)
								  : null;
					performanceSource = new Lifelength(directive.RevisionRemains);//TODO:(Evgenii Babak) выяснить почему у performanceSource такое же значение, что и у RevisionRemains
				}

				if (directive.Remains != null && directive.RevisionRemains != null)
				{
					//if (directive.Remains.IsLessOrEqualByAnyParameter(directive.RevisionRemains))
					//{
					//	directive.Condition = computeConditionState(performanceSource, directive.Remains, null, issueNotify, x => x.IsOverdue());
					//	directive.NextPerformanceDate = directive.IssueDateValidTo;
					//}
					//else
					//{
						directive.Condition = computeConditionState(performanceSource, directive.RevisionRemains, null, revisionNotify, x => x.IsOverdue());
						directive.NextPerformanceDate = directive.RevisionDateValidTo;
					//}
				}
				else if (directive.Remains != null)
				{
					directive.Condition = computeConditionState(performanceSource, directive.Remains, null, issueNotify, x => x.IsOverdue());
					directive.NextPerformanceDate = directive.IssueDateValidTo;
				}
				else
				{
					directive.Condition = computeConditionState(performanceSource, directive.RevisionRemains, null, revisionNotify, x => x.IsOverdue());
					directive.NextPerformanceDate = directive.RevisionDateValidTo;
				}
			}
		}

		#endregion

		#region public void GetPerformance(IDirective directive, int performanceNum, bool reset = true)

		/// <summary>
		/// Поиск выполнения директивы с заданным номером
		/// </summary>
		/// <param name="directive"></param>
		/// <param name="performanceNum"></param>
		/// <param name="reset"></param>
		/// <returns></returns>
		public bool GetPerformance(IDirective directive, int performanceNum, bool reset = true)
		{
			if (directive == null || performanceNum <= 0) return false;

			if (reset)
				directive.ResetMathData();

			IThreshold threshold;
			if (directive is MaintenanceDirective && ((MaintenanceDirective)directive).MaintenanceCheck != null)
				threshold = ((MaintenanceDirective)directive).MaintenanceCheck.Threshold;
			else threshold = directive.Threshold;
			AbstractPerformanceRecord pr = null;

			var au = _averageUtilizationCore.GetAverageUtillization(directive);
			Lifelength current = _calculator.GetCurrentFlightLifelength(directive.LifeLengthParent);
			//разница в ресурсе от текущей точки до точки выполнения директивы
			var difference = Lifelength.Null;
			var nextDifference = Lifelength.Null;
			var prevDifference = Lifelength.Null;
			NextPerformance np;

			if (directive.LastPerformance == null)
			{
				if (threshold.FirstPerformanceSinceNew.IsNullOrZero() &&
					threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					//небыло ни одного выполнения, 
					//и не заданы ресурсы первого выполнения
					//расчитать выполнение нельзя
					return false;
				}

				np = new NextPerformance { Parent = directive, PerformanceNum = performanceNum };
				Lifelength sinceEffDate = Lifelength.Null;
				if (threshold.FirstPerformanceSinceEffectiveDate != null &&
					!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					sinceEffDate = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, threshold.EffectiveDate);
					sinceEffDate.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
					sinceEffDate.Add(threshold.FirstPerformanceSinceEffectiveDate);
				}

				// с момента производства
				Lifelength sinceNew = Lifelength.Null;
				if (threshold.FirstPerformanceSinceNew != null &&
					!threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					sinceNew = threshold.FirstPerformanceSinceNew;
				}
				np.PerformanceSource = new Lifelength(sinceNew);
				if (threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
					np.PerformanceSource.SetMin(sinceEffDate);
				else np.PerformanceSource.SetMax(sinceEffDate);


				if (performanceNum != 1)
				{
					if (threshold.RepeatInterval.IsNullOrZero())
					{
						//ведется поиск непервого выполнения, но у задачи нет повторяющегося интервала
						//т.е. расчитать ресурс и дату выполнения нельзя
						return false;
					}
					//расчет добавочного ресурса
					var rep = new Lifelength(threshold.RepeatInterval);
					rep *= (performanceNum - 1);
					//добавление добавочного ресурса 
					//и приведение результата к ресурсу повторяющегося интервала
					np.PerformanceSource.Add(rep);
					np.PerformanceSource.Resemble(threshold.RepeatInterval);

					//ресурс выполнения, последующего расчитываемому 
					//(для определения ограничения по верхней дате выполнения)
					nextDifference = np.PerformanceSource + threshold.RepeatInterval;
					prevDifference = np.PerformanceSource - threshold.RepeatInterval;
				}

				difference = np.PerformanceSource;
			}
			else
			{
				#region У задачи есть выполнения

				//для начала производится поиск 1 выполнения, 
				//имеющего порядковый номер ниже либо равный искомому
				//результатом может быть 
				//1.искомое выполнение
				//  Н: сделано 10 записей, искомая 10-я
				//2.последнее выполнение (если искомый номер имеет "след.выполнение") 
				//  Н: сделано 10 записей, искомая 20-я
				//3.запись о выполении, предшествующая искомой (запись и искомым номером была удалена) 
				//  Н: сделано 10 записей, 8 запись удалена, искомая 8-я
				//4.NULL если все записи, сделанные раньше искомой, удалены
				//List<AbstractPerformanceRecord> pl = directive.PerformanceRecords.Cast<AbstractPerformanceRecord>().
				//    OrderByDescending(rec => rec.RecordDate).ToList();
				//pr = pl.FirstOrDefault(record => record.PerformanceNum <= performanceNum);
				pr = directive.PerformanceRecords.Cast<AbstractPerformanceRecord>().
					 OrderByDescending(rec => rec.RecordDate).
					 FirstOrDefault(record => record.PerformanceNum <= performanceNum);

				if (pr != null)
				{
					if (pr.PerformanceNum <= 0) pr.PerformanceNum = 1;

					if (pr.PerformanceNum == performanceNum)
					{
						//ситуация 1
						np = new NextPerformance
						{
							Parent = directive,
							PerformanceDate = pr.RecordDate,
							//TODO:(EvgeniiBabak) Выяснить почему расчитываем , а не берем OnLifeLenght
							PerformanceSource = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, directive.LastPerformance.RecordDate),
							PerformanceNum = performanceNum,
						};
					}
					else
					{
						//ситуация 2 и 3
						np = new NextPerformance
						{
							Parent = directive,
							PerformanceDate = pr.RecordDate,
							PerformanceSource = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, directive.LastPerformance.RecordDate),
							PerformanceNum = performanceNum,
						};

						//расчет добавочного ресурса
						difference = new Lifelength(threshold.RepeatInterval);
						difference *= (performanceNum - pr.PerformanceNum);
						//добавление добавосного ресурса 
						//и приведение результата к ресурсу повторяющегося интервала
						np.PerformanceSource.Add(difference);
						np.PerformanceSource.Resemble(threshold.RepeatInterval);
					}

					var prevPr = directive.PerformanceRecords.Cast<AbstractPerformanceRecord>().
						OrderByDescending(rec => rec.RecordDate).
						FirstOrDefault(record => record.PerformanceNum < performanceNum
											  && record.OnLifelength.IsLessIgnoreNulls(np.PerformanceSource));

					var nextPr = directive.PerformanceRecords.Cast<AbstractPerformanceRecord>().
						OrderByDescending(rec => rec.RecordDate).
						FirstOrDefault(record => record.PerformanceNum > performanceNum
											  && record.OnLifelength.IsGratherIgnoreNulls(np.PerformanceSource));


					if (prevPr != null)
					{
						np.PrevPerformanceDate = prevPr.RecordDate;
						np.PrevPerformanceSource = prevPr.OnLifelength;
					}
					else
					{
						np.PrevPerformanceDate = _calculator.GetStartDate(directive);
					}

					if (nextPr != null)
					{
						np.NextPerformanceDate = nextPr.RecordDate;
						np.NextPerformanceSource = nextPr.OnLifelength;
					}
					else
					{
						if (difference.IsNullOrZero())
							nextDifference = new Lifelength(threshold.RepeatInterval);
						else nextDifference = difference + threshold.RepeatInterval;
					}
				}
				else
				{
					//ситуация 4.
					if (threshold.FirstPerformanceSinceNew.IsNullOrZero() &&
					threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
					{
						//небыло ни одного выполнения, 
						//и не заданы ресурсы первого выполнения
						//расчитать выполнение нельзя
						return false;
					}

					np = new NextPerformance { Parent = directive, PerformanceNum = performanceNum };
					var sinceEffDate = Lifelength.Null;
					if (threshold.FirstPerformanceSinceEffectiveDate != null &&
						!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
					{
						sinceEffDate = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, threshold.EffectiveDate);
						sinceEffDate.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
						sinceEffDate.Add(threshold.FirstPerformanceSinceEffectiveDate);
					}

					// с момента производства
					var sinceNew = Lifelength.Null;
					if (threshold.FirstPerformanceSinceNew != null &&
						!threshold.FirstPerformanceSinceNew.IsNullOrZero())
					{
						sinceNew = threshold.FirstPerformanceSinceNew;
					}
					np.PerformanceSource = new Lifelength(sinceNew);
					if (threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
						np.PerformanceSource.SetMin(sinceEffDate);
					else np.PerformanceSource.SetMax(sinceEffDate);


					if (performanceNum != 1)
					{
						if (threshold.RepeatInterval.IsNullOrZero())
						{
							//ведется поиск непервого выполнения, но у задачи нет повторяющегося интервала
							//т.е. расчитать ресурс и дату выполнения нельзя
							return false;
						}
						//расчет добавочного ресурса
						Lifelength rep = new Lifelength(threshold.RepeatInterval);
						rep *= (performanceNum - 1);
						//добавление добавосного ресурса 
						//и приведение результата к ресурсу повторяющегося интервала
						np.PerformanceSource.Add(rep);
						np.PerformanceSource.Resemble(threshold.RepeatInterval);

						prevDifference = np.PerformanceSource - threshold.RepeatInterval;
						nextDifference = np.PerformanceSource + threshold.RepeatInterval;
					}
					difference = np.PerformanceSource;
				}
				#endregion
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
			Lifelength notify;
			if (directive.LastPerformance == null)
			{
				conditionType = threshold.FirstPerformanceConditionType;
				notify = threshold.FirstNotification != null
							 ? new Lifelength(threshold.FirstNotification)
							 : null;
			}
			else if (threshold.RepeatInterval != null && !threshold.RepeatInterval.IsNullOrZero())
			{
				conditionType = directive.Threshold.RepeatPerformanceConditionType;
				notify = directive.Threshold.RepeatNotification != null
							 ? new Lifelength(directive.Threshold.RepeatNotification)
							 : null;
			}
			else
			{
				conditionType = threshold.FirstPerformanceConditionType;
				notify = Lifelength.Null;
			}

			//расчет approximate date - для этого нам нужен AverageUtilization
			if (au != null)
			{
				DateTime start = pr != null
					? pr.RecordDate
					: _calculator.GetManufactureDate(directive.LifeLengthParent);

				if ((np.Remains.IsAllOverdue() && conditionType == ThresholdConditionType.WhicheverLater) ||
					(np.Remains.IsOverdue() && conditionType == ThresholdConditionType.WhicheverFirst))
				{
					//к дате пред. выполнения добавляется количество дней
					//за которое будет израсходован повторяющийся интервал директивы
					//с учетом заданной средней утилизации
					np.PerformanceDate = start.AddDays(Convert.ToDouble(AnalystHelper.GetApproximateDays(difference, au, conditionType)));
				}
				else
				{
					np.PerformanceDate = AnalystHelper.GetApproximateDate(np.Remains, au, conditionType);
				}

				if (!prevDifference.IsNullOrZero())
					np.PrevPerformanceDate = start.AddDays(Convert.ToDouble(AnalystHelper.GetApproximateDays(prevDifference, au, conditionType)));
				if (!nextDifference.IsNullOrZero())
				{
					np.NextPerformanceSource = np.PerformanceSource + nextDifference;
					if (nextDifference.Days != null)
						np.NextPerformanceDate = start.AddDays(Convert.ToDouble(AnalystHelper.GetApproximateDays(nextDifference, au, conditionType)));
				}
			}
			else
			{
				np.PerformanceDate = null;
			}
			#endregion

			#region Расчет текущего состояния задачи в зависимости от условий выполнения

			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				// задано только одно условие выполнения - считаем по whichever first
				// whichever first

				// состояние директивы - просрочена или нормально
				np.Condition = computeConditionState(np.PerformanceSource, np.Remains, current, notify, x => x.IsOverdue());
			}
			else // whichever later
			{
				// директива просрочена только в том случае, когда она просрочена по всем параметрам
				np.Condition = computeConditionState(np.PerformanceSource, np.Remains, current, notify, x => x.IsAllOverdue());
			}

			#endregion

			directive.NextPerformances.Add(np);

			return true;
		}

		#endregion

		#region public bool GetPerformance(Component component, int performanceNum)

		/// <summary>
		/// Поиск перемещения для детали с заданным номером
		/// </summary>
		/// <param name="component"></param>
		/// <param name="performanceNum"></param>
		/// <returns></returns>
		public bool GetPerformance(Entities.General.Accessory.Component component, int performanceNum)
		{
			if (component == null || performanceNum <= 0) return false;


			IThreshold threshold = component.Threshold;

			var au = _averageUtilizationCore.GetAverageUtillization(component);
			Lifelength current = _calculator.GetCurrentFlightLifelength(component.LifeLengthParent);
			//разница в ресурсе от текущей точки до точки выполнения директивы
			NextPerformance np;

			#region У задачи есть выполнения

			//для начала производится поиск 1 выполнения, 
			//имеющего порядковый номер ниже либо равный искомому
			//результатом может быть 
			//1.искомое выполнение
			//  Н: сделано 10 записей, искомая 10-я
			//2.последнее выполнение (если искомый номер имеет "след.выполнение") 
			//  Н: сделано 10 записей, искомая 20-я
			//3.запись о выполении, предшествующая искомой (запись и искомым номером была удалена) 
			//  Н: сделано 10 записей, 8 запись удалена, искомая 8-я
			//4.NULL если все записи, сделанные раньше искомой, удалены

			AbstractPerformanceRecord pr = component.TransferRecords.
				OrderByDescending(rec => rec.RecordDate).
				FirstOrDefault(record => record.PerformanceNum <= performanceNum);

			if (pr != null)
			{
				TransferRecord prevTr = component.TransferRecords.
					OrderByDescending(rec => rec.RecordDate).
					FirstOrDefault(record => record.PerformanceNum < performanceNum);

				TransferRecord nextTr = component.TransferRecords.
					OrderByDescending(rec => rec.RecordDate).
					FirstOrDefault(record => record.PerformanceNum > performanceNum);

				if (pr.PerformanceNum == performanceNum)
				{
					//ситуация 1
					np = new NextPerformance
					{
						Parent = component,
						PerformanceDate = pr.RecordDate,
						PerformanceSource = component.LifeLimit,
						PerformanceNum = performanceNum,
					};
				}
				else
				{
					//ситуация 2 и 3
					np = new NextPerformance
					{
						Parent = component,
						PerformanceDate = pr.RecordDate,
						PerformanceSource = component.LifeLimit,
						PerformanceNum = performanceNum,
					};
				}
				if (prevTr != null)
				{
					np.PrevPerformanceDate = prevTr.RecordDate;
					np.PrevPerformanceSource = prevTr.OnLifelength;
				}
				else
				{
					np.PrevPerformanceDate = component.ManufactureDate;
				}

				if (nextTr != null)
				{
					np.NextPerformanceDate = nextTr.RecordDate;
					np.NextPerformanceSource = nextTr.OnLifelength;
				}
				else
				{
					np.NextPerformanceDate = DateTime.Today;
					np.NextPerformanceSource = Lifelength.Null;
				}
			}
			else
			{
				//ситуация 4.
				TransferRecord nextTr = component.TransferRecords.
					OrderByDescending(rec => rec.RecordDate).
					FirstOrDefault(record => record.PerformanceNum > performanceNum);

				if (threshold.FirstPerformanceSinceNew.IsNullOrZero() &&
					threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					//небыло ни одного выполнения, 
					//и не заданы ресурсы первого выполнения
					//расчитать выполнение нельзя
					return false;
				}

				np = new NextPerformance
				{
					Parent = component,
					PerformanceNum = performanceNum,
					PerformanceDate = component.ManufactureDate,
					PrevPerformanceDate = component.ManufactureDate
				};
				if (nextTr != null)
				{
					np.NextPerformanceDate = nextTr.RecordDate;
					np.NextPerformanceSource = _calculator.GetFlightLifelengthOnEndOfDay(component.LifeLengthParent, nextTr.RecordDate);//TODO:(Evgenii Babak) вызов одного и того же метода с одинаковыми параметрами.
					np.PerformanceSource = _calculator.GetFlightLifelengthOnEndOfDay(component.LifeLengthParent, nextTr.RecordDate);
				}
				else
				{
					np.PerformanceSource = component.LifeLimit;
				}
			}
			#endregion

			#region Определение остатка ресурса (Remain), ресурса предупреждения(Notify),
			//условия(ThresholdConditionType) и 
			//приблизительной даты (approximate date) следующего выполнения

			np.Remains = new Lifelength(np.PerformanceSource);
			np.Remains.Substract(current); // remains = next - current
			np.Remains.Resemble(np.PerformanceSource);

			// Condition State и Approximate Date расчитывается по разному в зависимости от Whichever First и Whichever Later 
			// Whichever First и Whichever Later - разные для первого выполнения и повтороного выполнения
			Lifelength notifyRemains;
			ThresholdConditionType conditionType = threshold.FirstPerformanceConditionType;
			Lifelength notify = threshold.FirstNotification != null
									? new Lifelength(threshold.FirstNotification)
									: null;

			//расчет approximate date - для этого нам нужен AverageUtilization
			if (au != null)
			{
				if ((np.Remains.IsAllOverdue() && conditionType == ThresholdConditionType.WhicheverLater) ||
					(np.Remains.IsOverdue() && conditionType == ThresholdConditionType.WhicheverFirst))
				{
					//к дате пред. выполнения добавляется количество дней
					//за которое будет израсходован повторяющийся интервал директивы
					//с учетом заданной средней утилизации
					np.PerformanceDate = component.ManufactureDate.AddDays(Convert.ToDouble(AnalystHelper.GetApproximateDays(component.LifeLimit, au, conditionType)));
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

			#region Расчет текущего состояния задачи в зависимости от условий выполнения

			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				// задано только одно условие выполнения - считаем по whichever first
				// whichever first

				// состояние директивы - просрочена или нормально
				np.Condition = computeConditionState(np.PerformanceSource, np.Remains, current, notify, x => x.IsOverdue());
			}
			else // whichever later
			{
				// директива просрочена только в том случае, когда она просрочена по всем параметрам
				np.Condition = computeConditionState(np.PerformanceSource, np.Remains, current, notify, x => x.IsAllOverdue());
			}

			#endregion

			component.NextPerformances.Add(np);

			return true;
		}

		#endregion

		#region public void GetPerformance(MaintenanceCheckCollection groupChecks, int performanceNum)
		/// <summary>
		/// Поиск выполнения директивы с заданным номером
		/// </summary>
		/// <param name="groupChecks"></param>
		/// <param name="performanceNum"></param>
		/// <returns></returns>
		public void GetPerformance(MaintenanceCheckGroupByType groupChecks, int performanceNum)
		{
			if (groupChecks == null || groupChecks.Checks.Count <= 0 || performanceNum <= 0) return;

			MaintenanceCheck minCheck = groupChecks.GetMinIntervalCheck();
			if (GetPerformance(minCheck, performanceNum, false))
			{
				//функция GetPerformance добавит в чек одно выполнение,
				//которое не является MaintenanceNextPerformance. Это выполнение
				//нужно изъять и коллекции выполнений и использоваеть его данные
				//для заполнения нового MaintenanceNextPerformance
				NextPerformance np = minCheck.NextPerformances.Last();
				minCheck.NextPerformances.Remove(np);
				foreach (MaintenanceCheck check in groupChecks.Checks)
				{
					//след. выполнение
					MaintenanceNextPerformance mnp = new MaintenanceNextPerformance
					{
						Condition = np.Condition,
						NextPerformanceDate = np.NextPerformanceDate,
						NextPerformanceSource = np.NextPerformanceSource,
						Parent = check,
						PerformanceGroup = groupChecks,
						PerformanceGroupNum = performanceNum,
						PerformanceNum = performanceNum,
						PerformanceDate = np.PerformanceDate,
						PerformanceSource = np.PerformanceSource,
						PrevPerformanceDate = np.PrevPerformanceDate,
						Remains = np.Remains,
					};
					//группа чеков выполнения
					//группа выполнения
					//дата выполнения
					//ресурс выполнения      

					check.NextPerformances.Add(mnp);
				}
			}
		}

		#endregion

		#region public void GetNextPerformance(IDirective directive, ForecastData forecast = null)

		/// <summary>
		/// Расчитывает следующее выполнение directive вместе с дополнительными параметрами
		/// </summary>
		/// <param name="directive">Принимает директиву</param>
		/// <param name="forecast"></param>
		public void GetNextPerformance(IDirective directive, ForecastData forecast = null)
		{
			if (directive == null)
				return;

			directive.ResetMathData();

			if (directive.IsClosed || directive.Threshold == null)
				return;

			IThreshold threshold;
			if (directive is MaintenanceDirective && ((MaintenanceDirective)directive).MaintenanceCheck != null)
				threshold = ((MaintenanceDirective)directive).MaintenanceCheck.Threshold;
			else threshold = directive.Threshold;

			var last = Lifelength.Null;
			var current = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, DateTime.Today);
			NextPerformance np;
			NextPerformance lastNp;

			var au = _averageUtilizationCore.GetAverageUtillization(directive, forecast);

			for (;;)
			{
				np = null;

				#region Определение возможности след. выполения и ресурса на котором оно произойдет

				if (directive.NextPerformances.Count == 0)
				{
					if (directive.LastPerformance == null) // директива ни разу не выполнялась
					{
						// Расчитываем условие первого выполнения 
						// получаем ресурс агрегата при котором директива должна будет выполнена с момента вступления директивы в действие
						if ((threshold.FirstPerformanceSinceEffectiveDate != null &&
							 !threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
							||
							(threshold.FirstPerformanceSinceNew != null &&
							 !threshold.FirstPerformanceSinceNew.IsNullOrZero()))
						{
							np = new NextPerformance { Parent = directive };

							Lifelength sinceEffDate = Lifelength.Null;
							if (threshold.FirstPerformanceSinceEffectiveDate != null &&
								!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
							{
								sinceEffDate = _calculator.GetFlightLifelengthOnStartOfDay(directive.LifeLengthParent, threshold.EffectiveDate);
								sinceEffDate.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
								if (threshold.RepeatInterval.CalendarValue != null)
									sinceEffDate.Add(threshold.EffectiveDate, threshold.FirstPerformanceSinceEffectiveDate);
								else sinceEffDate.Add(threshold.FirstPerformanceSinceEffectiveDate);
							}

							// с момента производства
							Lifelength sinceNew = Lifelength.Null;
							if (threshold.FirstPerformanceSinceNew != null &&
								!threshold.FirstPerformanceSinceNew.IsNullOrZero())
							{
								sinceNew = threshold.FirstPerformanceSinceNew;

								if (directive is MaintenanceDirective)
								{
									var d = directive as MaintenanceDirective;

									_mtopCalculator.CalculateDirective(d, au);
									sinceNew = d.PhaseThresh;
								}
							}

							if (directive is Entities.General.Accessory.Component)
							{
								TransferRecord lastTr = ((Entities.General.Accessory.Component)directive).TransferRecords.GetLast();
								if (lastTr != null)
									np.PerformanceNum = 1 + (lastTr.PerformanceNum <= 0 ? 1 : lastTr.PerformanceNum);
								else np.PerformanceNum = 1;
							}
							else np.PerformanceNum = directive.NextPerformances.Count + 1;

							
							np.PerformanceSource = new Lifelength(sinceNew);
							if (threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
								np.PerformanceSource.SetMin(sinceEffDate);
							else np.PerformanceSource.SetMax(sinceEffDate);
						}
					}
					else // Директива уже выполнялась 
					{
						// Расчитываем условие следующего выполнения
						// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
						if (threshold.PerformRepeatedly && threshold.RepeatInterval != null &&
							!threshold.RepeatInterval.IsNullOrZero())
						{
							np = new NextPerformance { Parent = directive };

							last = directive.LastPerformance.OnLifelength;


							if (directive is MaintenanceDirective)
							{
								var d = directive as MaintenanceDirective;

								_mtopCalculator.CalculateDirective(d, au);
								int lastPerfNum = directive.LastPerformance.PerformanceNum <= 0 ? 1 : directive.LastPerformance.PerformanceNum;
								np.PerformanceNum = lastPerfNum + directive.NextPerformances.Count + 1;
								np.PerformanceSource = new Lifelength(last);
								if (d.PhaseRepeat != null && !d.PhaseRepeat.IsNullOrZero())
									np.PerformanceSource.Add(Convert.ToDateTime(directive.LastPerformance.RecordDate), d.PhaseRepeat);
								else np.PerformanceSource.Add(d.PhaseThresh);
								// Убираем не нужные параметры

								if (d.PhaseRepeat != null && !d.PhaseRepeat.IsNullOrZero())
									np.PerformanceSource.Resemble(d.PhaseRepeat);
								else np.PerformanceSource.Resemble(d.PhaseThresh);
							}
							else
							{
								int lastPerfNum = directive.LastPerformance.PerformanceNum <= 0 ? 1 : directive.LastPerformance.PerformanceNum;
								np.PerformanceNum = lastPerfNum + directive.NextPerformances.Count + 1;
								np.PerformanceSource = new Lifelength(last);
								if (threshold.RepeatInterval.CalendarValue != null)
									np.PerformanceSource.Add(Convert.ToDateTime(directive.LastPerformance.RecordDate), threshold.RepeatInterval);
								else np.PerformanceSource.Add(threshold.RepeatInterval);
								// Убираем не нужные параметры
								np.PerformanceSource.Resemble(threshold.RepeatInterval);
							}
						}
					}
				}
				else
				{
					// Расчитываем условие следующего выполнения
					// Следующее выполнение = ресурс базового агрегата на момент прошлого выполнения директивы + repeat interval
					if (threshold.PerformRepeatedly && threshold.RepeatInterval != null &&
						!threshold.RepeatInterval.IsNullOrZero())
					{
						np = new NextPerformance { Parent = directive };

						lastNp = directive.NextPerformances.Last();
						last = lastNp.PerformanceSource;

						if (directive is MaintenanceDirective)
						{
							var d = directive as MaintenanceDirective;

							_mtopCalculator.CalculateDirective(d, au);

							np.PerformanceNum = lastNp.PerformanceNum + 1;
							np.PerformanceSource = new Lifelength(last);
							if (d.PhaseRepeat != null && !d.PhaseRepeat.IsNullOrZero())
								np.PerformanceSource.Add(d.PhaseRepeat);
							else np.PerformanceSource.Add(d.PhaseThresh);
							// Убираем не нужные параметры
							if (d.PhaseRepeat != null && !d.PhaseRepeat.IsNullOrZero())
								np.PerformanceSource.Resemble(d.PhaseRepeat);
							else np.PerformanceSource.Resemble(d.PhaseThresh);
						}
						else
						{
							np.PerformanceNum = lastNp.PerformanceNum + 1;
							np.PerformanceSource = new Lifelength(last);
							if (lastNp.PerformanceDate != null && threshold.RepeatInterval.CalendarValue != null)
								np.PerformanceSource.Add(Convert.ToDateTime(lastNp.PerformanceDate), threshold.RepeatInterval);
							else np.PerformanceSource.Add(threshold.RepeatInterval);
							// Убираем не нужные параметры
							np.PerformanceSource.Resemble(threshold.RepeatInterval);
						}
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


				if (directive is Entities.General.Accessory.Component && ((Entities.General.Accessory.Component)directive).LLPMark && ((Entities.General.Accessory.Component)directive).LLPCategories)
				{
					np.Remains = ((Entities.General.Accessory.Component)directive).LLPRemains;
				}
				else
				{
					if (directive.LastPerformance != null)
					{
						np.LimitOverdue = new Lifelength(directive.Threshold.RepeatInterval);
						np.LimitNotify = new Lifelength(directive.Threshold.RepeatInterval);
						np.LimitNotify.Substract(directive.Threshold.FirstNotification);

						np.LimitOverdue.Add(directive.LastPerformance.OnLifelength);
						np.LimitNotify.Add(directive.LastPerformance.OnLifelength);

						np.LimitOverdue.Resemble(directive.Threshold.RepeatInterval);
						np.LimitNotify.Resemble(directive.Threshold.RepeatInterval);
					}
					else
					{
						if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null && !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
						{
							np.LimitOverdue = new Lifelength(np.PerformanceSource);
							np.LimitNotify = new Lifelength(np.PerformanceSource);
							np.LimitNotify.Substract(directive.Threshold.FirstNotification);

							np.LimitOverdue.Resemble(np.PerformanceSource);
							np.LimitNotify.Resemble(np.PerformanceSource);
						}
						else
						{
							np.LimitOverdue = new Lifelength(directive.Threshold.FirstPerformanceSinceNew);
							np.LimitNotify = new Lifelength(directive.Threshold.FirstPerformanceSinceNew);
							np.LimitNotify.Substract(directive.Threshold.FirstNotification);

							np.LimitOverdue.Resemble(directive.Threshold.FirstPerformanceSinceNew);
							np.LimitNotify.Resemble(directive.Threshold.FirstPerformanceSinceNew);
						}
					}

					//np.Remains = new Lifelength(np.LimitOverdue);
					np.Remains = new Lifelength(np.PerformanceSource);
					np.Remains.Substract(current); // remains = next - current

					np.Remains.Resemble(np.LimitOverdue);
				}

				if(np.Remains == null)
					np.Remains = Lifelength.Null;
				

				// Condition State и Approximate Date расчитывается по разному в зависимости от Whichever First и Whichever Later 
				// Whichever First и Whichever Later - разные для первого выполнения и повтороного выполнения
				ThresholdConditionType conditionType;
				Lifelength notify, notifyRemains;
				if (directive.LastPerformance == null)
				{
					conditionType = threshold.FirstPerformanceConditionType;
					notify = threshold.FirstNotification != null
								 ? new Lifelength(threshold.FirstNotification)
								 : null;
				}
				else if (threshold.RepeatInterval != null && !threshold.RepeatInterval.IsNullOrZero())
				{
					conditionType = directive.Threshold.RepeatPerformanceConditionType;
					notify = directive.Threshold.RepeatNotification != null
								 ? new Lifelength(directive.Threshold.RepeatNotification)
								 : null;
				}
				else
				{
					throw new Exception("1234: Incorrect directive status");
				}

				//расчет approximate date - для этого нам нужен AverageUtilization
				if (au != null)
				{
						//DateTime? dt = GetApproximateDate(directive.LifeLengthParent, np.PerformanceSource, conditionType);
						//if (dt != null)
						//{

						//}
						if (directive.NextPerformances.Count > 0 &&
							directive.NextPerformances.Last().PerformanceDate != null)
						{
							//к дате пред. выполнения добавляется количество дней
							//за которое будет израсходован повторяющийся интервал директивы
							//с учетом заданной средней утилизации
							double? days;
							if (directive is MaintenanceDirective)
							{
								var d = directive as MaintenanceDirective;
								days =
									AnalystHelper.GetApproximateDays(Convert.ToDateTime(directive.NextPerformances.Last().PerformanceDate),
										d.PhaseRepeat, au, conditionType);
							}
							else
							{
								days =
									AnalystHelper.GetApproximateDays(Convert.ToDateTime(directive.NextPerformances.Last().PerformanceDate),
										threshold.RepeatInterval, au, conditionType);
							}

							
							if (days != null)
								np.PerformanceDate = directive.NextPerformances.Last().PerformanceDate.Value.AddDays(Convert.ToDouble(days));
							else np.PerformanceDate = null;
						}
						else if (directive.LastPerformance != null)
						{
							double? days;
							if (directive is MaintenanceDirective)
							{
								var d = directive as MaintenanceDirective;
								days =
									AnalystHelper.GetApproximateDays(directive.LastPerformance.RecordDate,
										d.PhaseRepeat, au, conditionType);
							}
							else
							{
								days =
									AnalystHelper.GetApproximateDays(directive.LastPerformance.RecordDate,
										threshold.RepeatInterval, au, conditionType);
							}


							
							if (days != null)
								np.PerformanceDate = directive.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
							else np.PerformanceDate = null;
						}
						else
						{
							double? days = AnalystHelper.GetApproximateDays(np.PerformanceSource, au, conditionType);
							if (days != null)
							{
								if (directive is MaintenanceDirective && np.PerformanceSource.Days.HasValue)
								{
									np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(np.PerformanceSource.Days.Value);
								}
								else
								{
									if (days <= current.Days)
										np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(Convert.ToDouble(days));
									else np.PerformanceDate = AnalystHelper.GetApproximateDate(np.Remains, au, conditionType);
								}
								
							}
							else np.PerformanceDate = null;
						}
				}
				else
				{
					np.PerformanceDate = null;

					if (directive.NextPerformances.Count > 0 &&
						directive.NextPerformances.Last().PerformanceDate != null)
					{
						//к дате пред. выполнения добавляется количество дней
						//за которое будет израсходован повторяющийся интервал директивы
						//с учетом заданной средней утилизации
						double? days = threshold.RepeatInterval.Days;
						if (days != null)
							np.PerformanceDate = directive.NextPerformances.Last().PerformanceDate.Value.AddDays(Convert.ToDouble(days));
						else np.PerformanceDate = null;
					}
					else if (directive.LastPerformance != null)
					{
						double? days = threshold.RepeatInterval.Days;
						if (days != null)
							np.PerformanceDate = directive.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
						else np.PerformanceDate = null;
					}
					else
					{
						double? days = np.PerformanceSource.Days;
						if (days != null)
						{
							np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(Convert.ToDouble(days));
						}
						else np.PerformanceDate = null;
					}
				}
				#endregion

				directive.NextPerformances.Add(np);

				#region Расчет текущего состояния задачи в зависимости от условий выполнения

				if (conditionType == ThresholdConditionType.WhicheverFirst)
				{
					// задано только одно условие выполнения - считаем по whichever first
					// whichever first

					// состояние директивы - просрочена или нормально
					np.Condition = computeConditionState(directive, np.LimitNotify, np.LimitOverdue, np.Remains, current, notify, x =>x.IsOverdue(), x => x.IsLessByAnyParameter(notify), ThresholdConditionType.WhicheverFirst);
					
				}
				else // whichever later
				{
					// директива просрочена только в том случае, когда она просрочена по всем параметрам
					np.Condition = computeConditionState(directive, np.LimitNotify, np.LimitOverdue, np.Remains, current, notify, x => x.IsAllOverdue(), x => x.IsLess(notify), ThresholdConditionType.WhicheverLater);
				}

				#endregion

				#region Определение остатков ресурсов (при наличии прогноза)

				if (forecast == null) break;

				directive.ForecastLifelength = _calculator.GetCurrentFlightLifelength(directive.LifeLengthParent, forecast);
				np.BeforeForecastResourceRemain = new Lifelength(directive.ForecastLifelength);

				//Производится расчет ресурса директивы, который проидет от
				//ее начальной точки (или последнего выполнения) до ресурса прогноза
				if (last.IsNullOrZero())
				{
					//ресурса последнего выполнения перед прогнозом нет
					//значит точка прогноза находится между начальной точкой директивы 
					//и первым выполнением директивы

					//определение положения текущей точки (сегодняшней даты и наработки на сегодня)
					if (directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero() &&
						!directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
					{
						if (DateTime.Today < directive.Threshold.EffectiveDate)
						{
							//расчет директивы произодится по эффективной дате и 
							//эффективная дата выше сегодняшней 
							//(т.е. начальная точка директивы еще не подошла)

							//Прогнозирование ресурса на начальную точку директивы
							Lifelength effDateLifeLenght = new Lifelength();
							//Берется ресурс на сегодня
							effDateLifeLenght.Add(current);
							//и добавляется прогнозируемый ресурс = средняя утилизация * кол-во дней
							effDateLifeLenght.Add(AnalystHelper.GetUtilization(forecast.AverageUtilization,
																		 (directive.Threshold.EffectiveDate -
																		  DateTime.Today).Days));
							//расчет ресурса между начальной точкой и точкой прогноза
							np.BeforeForecastResourceRemain.NullSubstract(effDateLifeLenght);
						}
						else
						{
							//эффективная дата ниже сегодняшней 

							//Наработка на эффективную дату
							Lifelength effDateLifeLenght = _calculator.GetFlightLifelengthOnEndOfDay(directive.LifeLengthParent, directive.Threshold.EffectiveDate);
							//эффективная дата ниже сегодняшней 
							np.BeforeForecastResourceRemain.NullSubstract(effDateLifeLenght);
						}
					}
					else
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
					if (np.PerformanceSource.IsLessOrEqualByAnyParameter(directive.ForecastLifelength) &&
						directive.Threshold.RepeatInterval.IsNullOrZero())
					{
						//точка следующего выполнения меньше точки прогноза
						//и повторяющегося инервала нет
						//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
						directive.AfterForecastResourceRemain = Lifelength.Null;
						directive.Percents = null;
						break;
					}

					if (np.PerformanceSource.IsGreaterNullable(directive.ForecastLifelength) ||
						directive.Threshold.RepeatInterval.IsNullOrZero())
					{
						//точка следующего выполнения больше точки прогноза
						//или повторяющегося инервала нет
						//ресурс между точкой прогноза и точкой следующего выполнения 
						//равняется directive.NextCompliance - forecast.ForecastLifelength
						directive.AfterForecastResourceRemain = new Lifelength(np.PerformanceSource);
						directive.AfterForecastResourceRemain.NullSubstract(directive.ForecastLifelength);
						break;
					}
				}
				else // whichever later
				{
					// директива просрочена только в том случае, когда она просрочена по всем параметрам
					if (np.PerformanceSource.IsLessByAnyParameterNullable(directive.ForecastLifelength) &&
						directive.Threshold.RepeatInterval.IsNullOrZero())
					{
						//ресурс между точкой прогноза и точкой следующего выполнения отсутствует
						directive.AfterForecastResourceRemain = Lifelength.Null;
						directive.Percents = null;
						break;
					}

					if (np.PerformanceSource.IsGreaterByAnyParameter(directive.ForecastLifelength) ||
						directive.Threshold.RepeatInterval.IsNullOrZero())
					{
						directive.AfterForecastResourceRemain = new Lifelength(np.PerformanceSource);
						directive.AfterForecastResourceRemain.NullSubstract(directive.ForecastLifelength);
						//directive.AfterForecastResourceRemain.Resemble(directive.NextCompliance);
						break;
					}
				}

				// расчет остатка в процентах
				if (directive.AfterForecastResourceRemain != null && !directive.AfterForecastResourceRemain.IsNullOrZero())
				{
					Lifelength full = new Lifelength(np.BeforeForecastResourceRemain);
					full.Add(directive.AfterForecastResourceRemain);
					directive.Percents = full.GetPercents(directive.AfterForecastResourceRemain, conditionType);
				}

				#endregion
			}
		}

		#endregion


		// Директивы 

		#region public ConditionState GetConditionState(Component component, bool parentOnly)

		/// <summary>
		/// Расчитывает состояние компонента и его директив(открыта, просрочена или близкое ожидание)
		/// </summary>
		/// <param name="component"></param>
		/// <param name="parentOnly"></param>
		/// <returns></returns>
		public ConditionState GetConditionState(Entities.General.Accessory.Component component, bool parentOnly = false)
		{
			ConditionState componentStatus = ConditionState.NotEstimated, cond;
			GetNextPerformance(component);
			cond = component.Condition;

			if (cond == ConditionState.NotEstimated)
				componentStatus = ConditionState.NotEstimated;
			if (cond == ConditionState.Satisfactory)
				componentStatus = ConditionState.Satisfactory;
			if (cond == ConditionState.Notify)
				componentStatus = ConditionState.Notify;
			if (cond == ConditionState.Overdue)
			{
				return ConditionState.Overdue;
			}

			if (parentOnly) return componentStatus;

			foreach (var componentDirective in component.ComponentDirectives)
			{
				cond = GetConditionState(componentDirective);

				if (cond == ConditionState.NotEstimated &&
					componentStatus == ConditionState.NotEstimated)
					componentStatus = ConditionState.NotEstimated;

				if (cond == ConditionState.Satisfactory &&
					componentStatus != ConditionState.Notify)
					componentStatus = ConditionState.Satisfactory;

				if (cond == ConditionState.Notify &&
					componentStatus != ConditionState.Overdue)
					componentStatus = ConditionState.Notify;

				if (cond == ConditionState.Overdue)
				{
					return ConditionState.Overdue;
				}
			}

			return componentStatus;
		}
		#endregion

		#region public ConditionState GetConditionState(ComponentDirective componentDirective)

		/// <summary>
		/// Расчитывает состояние директивы (открыта, просрочена или близкое ожидание)
		/// </summary>
		/// <param name="componentDirective"></param>
		/// <returns></returns>
		public ConditionState GetConditionState(ComponentDirective componentDirective)
		{
			GetNextPerformance(componentDirective);//TODO:(Evgenii Babak) Пересмотреть подход , метод возвращает Condition а мы считаем весь NextPerformance
			return componentDirective.Condition;
		}
		#endregion

		#region public ConditionState GetConditionState(Directive directive)
		/// <summary>
		/// Расчитывает состояние компонента и его директив(открыта, просрочена или близкое ожидание)
		/// </summary>
		/// <param name="directive"></param>
		/// <returns></returns>
		public ConditionState GetConditionState(Directive directive)
		{
			GetNextPerformance(directive);//TODO:(Evgenii Babak) Пересмотреть подход , метод возвращает Condition а мы считаем весь NextPerformance
			return directive.Condition;
		}
		#endregion

		#region public ConditionState GetConditionState(IDirective directive)
		/// <summary>
		/// Расчитывает состояние компонента и его директив(открыта, просрочена или близкое ожидание)
		/// </summary>
		/// <param name="directive"></param>
		/// <returns></returns>
		public ConditionState GetConditionState(IDirective directive)
		{
			GetNextPerformance(directive);//TODO:(Evgenii Babak) Пересмотреть подход , метод возвращает Condition а мы считаем весь NextPerformance
			return directive.Condition;
		}
		#endregion


		// Вспомогательные методы

		private ConditionState computeConditionState(Lifelength performanceSource, Lifelength remains, Lifelength current, Lifelength notify, Func<Lifelength, bool> getIsOverdueFunc)
		{
			if (notify != null && !notify.IsNullOrZero())
			{
				if (getIsOverdueFunc(remains))
					return ConditionState.Overdue;

				var notifyRemains = new Lifelength(performanceSource);
				notifyRemains.Substract(notify);

				if (current != null && !current.IsNullOrZero())
					notifyRemains.Substract(current);

				notifyRemains.Resemble(notify);
				return getIsOverdueFunc(notifyRemains) ? ConditionState.Notify : ConditionState.Satisfactory;
			}

			return getIsOverdueFunc(remains) ? ConditionState.Overdue : ConditionState.Satisfactory;
		}


		private ConditionState computeConditionState(IDirective directive, Lifelength limitNotify,
			Lifelength limitOverdue, Lifelength remains,
			Lifelength current, Lifelength notify, Func<Lifelength, bool> getIsOverdueFunc,
			Func<Lifelength, bool> getIsLessFunc, ThresholdConditionType whicheverFirst)
		{
			if (notify != null && !notify.IsNullOrZero())
			{
				if (directive is Entities.General.Accessory.Component && ((Entities.General.Accessory.Component) directive).LLPMark && ((Entities.General.Accessory.Component) directive).LLPCategories)
				{
					return getIsOverdueFunc(remains)
									? ConditionState.Overdue
									: (getIsLessFunc(notify)
											? ConditionState.Notify
											: ConditionState.Satisfactory);
				}


					if (current.IsGreaterByAnyParameter(limitOverdue))
						return ConditionState.Overdue;

					if (limitOverdue.IsGreaterByAnyParameter(current) && current.IsGreaterByAnyParameter(limitNotify))
						return ConditionState.Notify;

				return ConditionState.Satisfactory;
				
			}

			return getIsOverdueFunc(remains) ? ConditionState.Overdue : ConditionState.Satisfactory;
		}

	}
}