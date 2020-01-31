using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Aircrafts;
using SmartCore.Analyst;
using SmartCore.AverageUtilizations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace SmartCore.Calculations.MTOP
{
	public class MTOPCalculator : IMTOPCalculator
	{
		private readonly ICalculator _calculator;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly IAverageUtilizationCore _averageUtilizationCore;

		#region Constructor

		public MTOPCalculator(ICalculator calculator, IAircraftsCore aircraftsCore, IAverageUtilizationCore averageUtilizationCore)
		{
			_calculator = calculator;
			_aircraftsCore = aircraftsCore;
			_averageUtilizationCore = averageUtilizationCore;
		}

		#endregion

		#region New

		public void CalculateDirectiveNew(List<IMtopCalc> directives)
		{
			foreach (var directive in directives)
				CalculateDirectiveNew(directive);
		}

		public void CalculateDirectiveNew(IMtopCalc directive)
		{
			if (directive == null)
				return;

			if (directive.IsClosed || directive.Threshold == null)
				return;

			ThresholdConditionType conditionType;
			Lifelength notify, iddc = Lifelength.Null, idd = Lifelength.Null, currentC = Lifelength.Null;
			bool alredyCalculate = false;
			var isComponent = directive is Entities.General.Accessory.Component || directive is ComponentDirective;

			int aircraftId;
			Entities.General.Accessory.Component component = null;
			BaseComponent basecomponent = null;

			directive.NextPerformances.Clear();
			var np = new NextPerformance { Parent = directive };
			var threshold = directive.Threshold;

			//ищем компонент и ВС
			//для поиска наработки
			if (directive is Directive d)
			{
				aircraftId = d.ParentAircraftId;
				basecomponent = d.ParentBaseComponent;
			}
			else if (directive is ComponentDirective cd)
			{
				aircraftId = cd.ParentAircraftId;
				if (cd.ParentComponent != null)
					component = cd.ParentComponent;
				else basecomponent = cd.ParentBaseComponent;
			}
			else if (directive is Entities.General.Accessory.Component c)
			{
				aircraftId = c.ParentAircraftId;
				if (c is BaseComponent baseComponent)
					basecomponent = baseComponent;
				else component = c;
			}
			else if (directive is MaintenanceDirective mpd)
			{
				aircraftId = mpd.ParentAircraftId;
				basecomponent = mpd.ParentBaseComponent;
			}
			else return;

			var aircraft = _aircraftsCore.GetAircraftById(aircraftId);
			if(aircraft == null)
				return;

			var current = _calculator.GetFlightLifelengthOnEndOfDay(aircraft, DateTime.Today);
			var au = _averageUtilizationCore.GetAverageUtillization(directive);

			if (isComponent)
			{
				if (component != null)
				{
					var lastTransferRecord = component.TransferRecords.GetLast();
					iddc = component.ActualStateRecords.GetLastKnownRecord(lastTransferRecord.RecordDate)?.OnLifelength ?? Lifelength.Null;
					idd = _calculator.GetFlightLifelengthOnStartOfDay(aircraft, lastTransferRecord.RecordDate);
					//currentC = _calculator.GetFlightLifelengthOnEndOfDay(component, DateTime.Today);
				}
				else if (basecomponent != null)
				{
					var lastTransferRecord = basecomponent.TransferRecords.GetLast();
					iddc = basecomponent.ActualStateRecords.GetLastKnownRecord(lastTransferRecord.RecordDate)?.OnLifelength ?? Lifelength.Null;
					idd = _calculator.GetFlightLifelengthOnStartOfDay(aircraft, lastTransferRecord.RecordDate);
					//currentC = _calculator.GetFlightLifelengthOnEndOfDay(basecomponent, DateTime.Today);
				}
				else return;
			}

			np.IDD = idd;
			np.IDDC = iddc;

			

			//Если деректива не выполнялась
			if (directive.LastPerformance == null)
			{
				conditionType = threshold.FirstPerformanceConditionType;
				notify = threshold.FirstNotification != null
					? new Lifelength(threshold.FirstNotification)
					: null;

				if (!threshold.FirstPerformanceSinceNew.IsNullOrZero() && !threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					alredyCalculate = true;

					var sn = new Lifelength(threshold.FirstPerformanceSinceNew);

					var sed = _calculator.GetFlightLifelengthOnStartOfDay(directive.LifeLengthParent, threshold.EffectiveDate);
					//Ситуация когда нет наработки
					if (sed.Hours == 0 && sed.Cycles == 0)
					{
						return;
					}
					//ситуация когда наработки нет в будующем(прогнозируем)
					if (current.Hours == sed.Hours && current.Cycles == sed.Cycles &&
					    current.Days < sed.Days)
					{
						var temp = Lifelength.Zero;
						temp.Days = sed.Days - current.Days;
						sed = new Lifelength(CalculateWithUtilization(temp, au));
						sed.Add(current);
					}

					sed.Add(threshold.FirstPerformanceSinceEffectiveDate);
					sed.Resemble(threshold.FirstPerformanceSinceEffectiveDate);

					var remainSn = new Lifelength(sn);
					remainSn.Substract(current);

					var remainSed = new Lifelength(sed);
					remainSed.Substract(current);

					remainSn.Resemble(threshold.FirstPerformanceSinceNew);
					remainSed.Resemble(threshold.FirstPerformanceSinceEffectiveDate);

					var snCalc = CalculateWithUtilization(remainSn, au, conditionType);
					var sedCalc = CalculateWithUtilization(remainSed, au, conditionType);


					if (conditionType == ThresholdConditionType.WhicheverFirst)
					{
						if (snCalc.IsLessByAnyParameter(sedCalc))
						{
							np.NextLimit = new Lifelength(sn);
							np.RemainLimit = new Lifelength(remainSn);
							np.Remains = new Lifelength(snCalc);
						}
						else
						{
							np.NextLimit = new Lifelength(sed);
							np.RemainLimit = new Lifelength(remainSed);
							np.Remains = new Lifelength(sedCalc);
						}
					}
					else
					{
						if (snCalc.IsGreaterByAnyParameter(sedCalc))
						{
							np.NextLimit = new Lifelength(sed);
							np.RemainLimit = new Lifelength(remainSed);
							np.Remains = new Lifelength(sedCalc);
						}
						else
						{
							np.NextLimit = new Lifelength(sn);
							np.RemainLimit = new Lifelength(remainSn);
							np.Remains = new Lifelength(snCalc);
						}
					}
				}
				else if (!threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					if (isComponent)
					{
						np.NextLimit = new Lifelength(threshold.FirstPerformanceSinceNew);
						np.NextLimit.Add(idd);
						np.NextLimit.Substract(iddc);
						

						np.NextLimitC = new Lifelength(threshold.FirstPerformanceSinceNew);
					}
					else
					{
						np.NextLimit = new Lifelength(threshold.FirstPerformanceSinceNew);
					}
				}
				else if (!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					var sinceEffDate = _calculator.GetFlightLifelengthOnStartOfDay(directive.LifeLengthParent, threshold.EffectiveDate);

					//Ситуация когда нет наработки
					if (sinceEffDate.Hours == 0 && sinceEffDate.Cycles == 0)
					{
						return;
					}
					//ситуация когда наработки нет в будующем(прогнозируем)
					if (current.Hours == sinceEffDate.Hours && current.Cycles == sinceEffDate.Cycles &&
					    current.Days < sinceEffDate.Days)
					{
						var temp = Lifelength.Zero;
						temp.Days = sinceEffDate.Days - current.Days;
						sinceEffDate = new Lifelength(CalculateWithUtilization(temp, au));
						sinceEffDate.Add(current);
					}

					sinceEffDate.Add(threshold.FirstPerformanceSinceEffectiveDate);
					sinceEffDate.Resemble(threshold.FirstPerformanceSinceEffectiveDate);

					np.NextLimit = new Lifelength(sinceEffDate);
				}
				else return;
			}
			else
			{
				conditionType = threshold.RepeatPerformanceConditionType;
				notify = directive.Threshold.RepeatNotification != null
					? new Lifelength(directive.Threshold.RepeatNotification)
					: null;

				if (isComponent)
				{
					//np.NextLimitC = new Lifelength(directive.LastPerformance.OnLifelength);
					np.NextLimitC = new Lifelength(_calculator.GetFlightLifelengthOnStartOfDay(component, directive.LastPerformance.RecordDate));

					//np.LastDataC = new Lifelength(component != null ? _calculator.GetFlightLifelengthOnStartOfDay(component, directive.LastPerformance.RecordDate) :
					//_calculator.GetFlightLifelengthOnStartOfDay(basecomponent, directive.LastPerformance.RecordDate));

					np.LastDataC = new Lifelength(_calculator.GetFlightLifelengthOnStartOfDay(aircraft, directive.LastPerformance.RecordDate));
					np.NextLimit = new Lifelength(np.LastDataC);

					if (!threshold.RepeatInterval.IsNullOrZero())
						np.NextLimitC.Add(threshold.RepeatInterval);
					else return;
				}
				else
				{
					np.NextLimit = new Lifelength(directive.LastPerformance.OnLifelength);
				}
				
				if (!threshold.RepeatInterval.IsNullOrZero())
					np.NextLimit.Add(threshold.RepeatInterval);
				else return;
			}

			//Ситуация когда есть sn и sed уже все посчитанно нет смысла гонять второй раз
			if (!alredyCalculate)
			{
				//Рассчитываем Remain
				np.RemainLimit = new Lifelength(np.NextLimit);
				np.RemainLimit.Substract(current);

				if (!threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					np.RemainLimit.Resemble(threshold.FirstPerformanceSinceNew);
					np.NextLimit.Resemble(threshold.FirstPerformanceSinceNew);
				}
				else if (!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					np.RemainLimit.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
					np.NextLimit.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
				}

				np.Remains = new Lifelength(CalculateWithUtilization(np.RemainLimit, au, conditionType));

				if (isComponent)
				{

					if (directive.LastPerformance == null)
					{
						np.RemainLimitC = new Lifelength(np.NextLimitC);
						np.RemainLimitC.Add(idd);
						np.RemainLimitC.Substract(iddc);
						np.RemainLimitC.Substract(current);
					}
					else
					{
						np.RemainLimitC = new Lifelength(np.NextLimitC);
						np.RemainLimitC.Add(idd);
						np.RemainLimitC.Substract(iddc);
						np.RemainLimitC.Substract(current);
					}

					

					if (!threshold.FirstPerformanceSinceNew.IsNullOrZero())
					{
						np.RemainLimitC.Resemble(threshold.FirstPerformanceSinceNew);
						np.NextLimitC.Resemble(threshold.FirstPerformanceSinceNew);
					}
					else if (!threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
					{
						np.RemainLimitC.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
						np.NextLimitC.Resemble(threshold.FirstPerformanceSinceEffectiveDate);
					}

					np.RemainsC = new Lifelength(CalculateWithUtilization(np.RemainLimitC, au, conditionType));


					np.PerformanceSourceC = new Lifelength(current);
					np.PerformanceSourceC.Substract(idd);
					np.PerformanceSourceC.Add(np.Remains);
					np.PerformanceSourceC.Add(iddc);

					//if (directive.LastPerformance == null)
					//	np.PerformanceSourceC.Add(iddc);
				}
				
				
			}
			
			np.PerformanceSource = new Lifelength(current); 
			np.PerformanceSource.Add(np.Remains);

			#region Расчет текущего состояния задачи в зависимости от условий выполнения

			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				// задано только одно условие выполнения - считаем по whichever first
				// whichever first

				// состояние директивы - просрочена или нормально
				np.Condition = computeConditionState(np.NextLimit, np.RemainLimit, current, notify, x => x.IsOverdue());
			}
			else // whichever later
			{
				// директива просрочена только в том случае, когда она просрочена по всем параметрам
				np.Condition = computeConditionState(np.NextLimit, np.RemainLimit, current, notify, x => x.IsAllOverdue());
			}

			#endregion

			#region Расчет даты

			double? days;
			//if (directive.LastPerformance != null)
			//{
			//	days = AnalystHelper.GetApproximateDays(directive.LastPerformance.RecordDate, threshold.RepeatInterval, au, conditionType);
			//	if (days != null)
			//	{
			//		np.NextPerformanceDateNew = directive.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
			//		np.PerformanceDate = directive.LastPerformance.RecordDate.AddDays(Convert.ToDouble(days));
			//	}
			//}
			//else
			//{
				days = AnalystHelper.GetApproximateDays(np.NextLimit, au, conditionType);
				if (days != null)
				{
					if (days <= current.Days)
					{
						if (isComponent)
							np.PerformanceDate = _calculator.GetManufactureDate(aircraft).AddDays(Convert.ToDouble(days));
						else np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(Convert.ToDouble(days));
					}
					else
						np.NextPerformanceDateNew = AnalystHelper.GetApproximateDate(np.RemainLimit, au, conditionType);
				}

				days = np.PerformanceSource.Days;
				if (days != null)
				{
					if (days <= current.Days)
					{
						if(isComponent)
							np.PerformanceDate = _calculator.GetManufactureDate(aircraft).AddDays(Convert.ToDouble(days));
						else np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(Convert.ToDouble(days));
					}
					else np.PerformanceDate = AnalystHelper.GetApproximateDate(np.Remains, au, conditionType);
				}
			//}

			

			#endregion}

			directive.NextPerformances.Add(np);
		}

		public Lifelength CalculateWithUtilization(Lifelength thresh, AverageUtilization averageUtilization, ThresholdConditionType conditionType)
		{
			if(thresh.IsNullOrZero())
				return Lifelength.Null;

			var dict = new Dictionary<string, double>();

			if (thresh.Days != null)
				dict.Add("Days", thresh.Days.Value);

			if (thresh.Hours != null)
				dict.Add("Hours", thresh.Hours.Value / averageUtilization.Hours);

			if (thresh.Cycles != null)
				dict.Add("Cycles", thresh.Cycles.Value / (averageUtilization.Hours / averageUtilization.Cycles));

			var res = Lifelength.Null;
			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				var min = dict.OrderBy(i => i.Value).FirstOrDefault();
				res.Days = (int?)(min.Value);
			}
			else
			{
				var min = dict.OrderByDescending(i => i.Value).FirstOrDefault();
				res.Days = (int?)(min.Value);
			}

			return CalculateWithUtilization(res, averageUtilization);
		}

		public Lifelength CalculateWithUtilization(Lifelength thresh, AverageUtilization averageUtilization)
		{
			double hours = 0, cycles = 0, days = 0;
			double hoursPhase = -1, cyclesPhase = -1, daysPhase = -1;

			var res = new Lifelength(0, 0, 0);

			var threshHours = thresh.Hours;
			if (thresh.Days.HasValue)
			{
				hours = (double)(thresh.Days * averageUtilization.Hours);
				cycles = hours / averageUtilization.Cycles;
				days = (double)thresh.Days;
			}
			else if (threshHours.HasValue)
			{
				hours = (double)threshHours;
				cycles = hours / averageUtilization.Cycles;
				days = (double)(threshHours / averageUtilization.HoursPerDay);
			}
			else if (thresh.Cycles.HasValue)
			{
				cycles = (double)thresh.Cycles;
				days = (double)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
				hours = days * averageUtilization.Hours;
			}

			res.Hours = (int)(hoursPhase > -1 ? hoursPhase : hours);
			res.Cycles = (int)(cyclesPhase > -1 ? cyclesPhase : cycles);
			res.Days = (int)(daysPhase > -1 ? daysPhase : days);

			return res;
		}

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

		#endregion


		#region Old

		public void CalculateMtopChecks(List<MTOPCheck> checks, AverageUtilization averageUtilization)
		{
			foreach (var check in checks)
			{
				check.PhaseThreshLimit = new Lifelength(0, 0, 0);

				double hours, cycles, days;
				double hoursPhase = -1, cyclesPhase = -1, daysPhase = -1;

				if (check.Thresh.Days.HasValue)
				{
					hours = (double)(check.Thresh.Days * averageUtilization.Hours);
					cycles = hours / averageUtilization.Cycles;
					days = (double)check.Thresh.Days;
				}
				else if (check.Thresh.Hours.HasValue)
				{
					hours = (double)check.Thresh.Hours;
					cycles = hours / averageUtilization.Cycles;
					days = (double)(check.Thresh.Hours / averageUtilization.HoursPerDay);
				}
				else
				{
					cycles = (double)check.Thresh.Cycles;
					days = (double)(check.Thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					hours = days * averageUtilization.Hours;
				}

				//check.PhaseThreshLimit.Hours = (int)Math.Round(hours);
				//check.PhaseThreshLimit.Cycles = (int)Math.Round(cycles);
				//check.PhaseThreshLimit.Days = (int)Math.Round(days);
				check.PhaseThreshLimit.Hours = (int)hours;
				check.PhaseThreshLimit.Cycles = (int)cycles;
				check.PhaseThreshLimit.Days = (int)days;
				check.PhaseThresh = new Lifelength(check.PhaseThreshLimit);

				if (check.PhaseThresh?.Cycles > check.Thresh.Cycles && check.PhaseThresh?.Hours > check.Thresh.Hours)
				{
					var cycleDays = (int)(check.PhaseThresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

					if (cycleDays > check.PhaseThresh.Days)
					{
						daysPhase = (int)(check.Thresh.Hours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;
					}
					else
					{
						daysPhase = (int)(check.Thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						hoursPhase = daysPhase * averageUtilization.Hours;
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);

						if (hoursPhase > check.Thresh.Hours)
						{
							daysPhase = (int)(check.Thresh.Hours / averageUtilization.HoursPerDay);
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
							hoursPhase = daysPhase * averageUtilization.Hours;
						}
					}
				}
				else if (check.PhaseThresh?.Cycles > check.Thresh.Cycles)
				{
					daysPhase = (int)(check.Thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					hoursPhase = daysPhase * averageUtilization.Hours;
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);

					if (hoursPhase > check.Thresh.Hours)
					{
						daysPhase = (int)(check.Thresh.Hours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;
					}

				}
				else if (check.PhaseThresh?.Hours > check.Thresh.Hours)
				{
					daysPhase = (int)(check.Thresh.Hours / averageUtilization.HoursPerDay);
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;

					if (cyclesPhase > check.Thresh.Cycles)
					{
						daysPhase = (int)(check.Thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						hoursPhase = daysPhase * averageUtilization.Hours;
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					}
				}

				//check.PhaseThresh.Hours = (int)Math.Round(hoursPhase > -1 ? hoursPhase : hours);
				//check.PhaseThresh.Cycles = (int)Math.Round(cyclesPhase > -1 ? cyclesPhase : cycles);
				//check.PhaseThresh.Days = (int)Math.Round(daysPhase > -1 ? daysPhase : days);
				check.PhaseThresh.Hours = (int)(hoursPhase > -1 ? hoursPhase : hours);
				check.PhaseThresh.Cycles = (int)(cyclesPhase > -1 ? cyclesPhase : cycles);
				check.PhaseThresh.Days = (int)(daysPhase > -1 ? daysPhase : days);

				if (check.Thresh.Days.HasValue)
					check.PhaseInMonth = (double)(check.Thresh.Days / 30.4375);

				if (!check.Repeat.IsNullOrZero())
				{
					hoursPhase = -1;
					cyclesPhase = -1;
					daysPhase = -1;

					check.PhaseRepeatLimit = new Lifelength(0, 0, 0);

					if (check.Repeat.Days.HasValue)
					{
						hours = (double)(check.Repeat.Days * averageUtilization.Hours);
						cycles = hours / averageUtilization.Cycles;
						days = (double)check.Repeat.Days;
					}
					else if (check.Repeat.Hours.HasValue)
					{
						hours = (double)check.Repeat.Hours;
						cycles = hours / averageUtilization.Cycles;
						days = (double)(check.Repeat.Hours / averageUtilization.HoursPerDay);
					}
					else if (check.Repeat.Cycles.HasValue)
					{
						cycles = (double)check.Repeat.Cycles;
						days = (double)(check.Repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						hours = days * averageUtilization.Hours;
					}

					//check.PhaseRepeatLimit.Hours = (int)Math.Round(hours);
					//check.PhaseRepeatLimit.Cycles = (int)Math.Round(cycles);
					//check.PhaseRepeatLimit.Days = (int)Math.Round(days);
					check.PhaseRepeatLimit.Hours = (int)hours;
					check.PhaseRepeatLimit.Cycles = (int)cycles;
					check.PhaseRepeatLimit.Days = (int)days;
					check.PhaseRepeat = new Lifelength(check.PhaseRepeatLimit);

					if (check.PhaseRepeat?.Cycles > check.Repeat.Cycles && check.PhaseRepeat?.Hours > check.Repeat.Hours)
					{
						var cycleDays = (int)(check.PhaseRepeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

						if (cycleDays > check.PhaseRepeat.Days)
						{
							daysPhase = (int)(check.Repeat.Hours / averageUtilization.HoursPerDay);
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
							hoursPhase = daysPhase * averageUtilization.Hours;
						}
						else
						{
							daysPhase = (int)(check.Repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
							hoursPhase = daysPhase * averageUtilization.Hours;
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);

							if (hoursPhase > check.Repeat.Hours)
							{
								daysPhase = (int)(check.Repeat.Hours / averageUtilization.HoursPerDay);
								cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
								hoursPhase = daysPhase * averageUtilization.Hours;
							}
						}
					}
					else if (check.PhaseRepeat?.Hours > check.Repeat.Hours)
					{
						daysPhase = (int)(check.Repeat.Hours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay); ;
						hoursPhase = daysPhase * averageUtilization.Hours;

						if (hoursPhase > check.Repeat.Hours)
						{
							daysPhase = (int)(check.Repeat.Hours / averageUtilization.HoursPerDay);
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
							hoursPhase = daysPhase * averageUtilization.Hours;
						}
					}
					else if (check.PhaseRepeat?.Cycles > check.Repeat.Cycles)
					{
						daysPhase = (int)(check.Repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						hoursPhase = daysPhase * averageUtilization.Hours; ;
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);

						if (cyclesPhase > check.Repeat.Cycles)
						{
							daysPhase = (int)(check.Repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
							hoursPhase = daysPhase * averageUtilization.Hours;
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						}
					}

					//check.PhaseRepeat.Hours = (int)Math.Round(hoursPhase > -1 ? hoursPhase : hours);
					//check.PhaseRepeat.Cycles = (int)Math.Round(cyclesPhase > -1 ? cyclesPhase : cycles);
					//check.PhaseRepeat.Days = (int)Math.Round(daysPhase > -1 ? daysPhase : days);
					check.PhaseRepeat.Hours = (int)(hoursPhase > -1 ? hoursPhase : hours);
					check.PhaseRepeat.Cycles = (int)(cyclesPhase > -1 ? cyclesPhase : cycles);
					check.PhaseRepeat.Days = (int)(daysPhase > -1 ? daysPhase : days);

				}
			}
		}

		public void CalculateNextPerformance(List<MTOPCheck> checks, DateTime frameStartDate,
			Dictionary<int, Lifelength> groupLifelengths, Aircraft currentAircraft, AverageUtilization averageUtilization,
			MTOPCheckRecord lastCompliance, bool ingoneCompliance = false)
		{
			foreach (var check in checks)
			{
				if (ingoneCompliance)
					check.NextPerformancesWithIgnorLast = new List<NextPerformance>();
				else
				{
					check.NextPerformance = new NextPerformance();
					check.NextPerformances = new List<NextPerformance>();
				}

				check.AverageUtilization = averageUtilization;

				var current = _calculator.GetCurrentFlightLifelength(currentAircraft);
				ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst;
				if (lastCompliance != null && !ingoneCompliance)
				{
					var tempHours = check.PhaseThresh;
					var value = Lifelength.Null;
					var lastGroup = 0;

					if (lastCompliance.ParentId == check.ItemId)
					{
						value = lastCompliance.CalculatedPerformanceSource;
						lastGroup = lastCompliance.GroupName + 1;
					}
					else if (check.PerformanceRecords.Count > 0)
					{
						var last = check.PerformanceRecords.OrderByDescending(i => i.RecordDate).FirstOrDefault();
						value = last?.CalculatedPerformanceSource;

						if (lastCompliance.Parent.IsZeroPhase == last.Parent.IsZeroPhase)
						{
							if (last.GroupName > lastCompliance.GroupName)
								lastGroup = last.GroupName + 1;
							else lastGroup = lastCompliance.GroupName + 1;
						}
						else lastGroup = last.GroupName + 1;


					}
					else
					{
						var q = check.PhaseThresh;

						while (q.Days < lastCompliance.CalculatedPerformanceSource.Days.Value)
						{

							if ((q + check.PhaseRepeat).Days >= lastCompliance.CalculatedPerformanceSource.Days.Value ||
							    (q + check.PhaseRepeat).Days >= lastCompliance.CalculatedPerformanceSource.Days.Value)
								break;

							if (check.PhaseRepeat != null && !check.PhaseRepeat.IsNullOrZero())
								q += check.PhaseRepeat;
							else q += check.PhaseThresh;
						}

						if (groupLifelengths.ContainsValue(q))
							lastGroup = groupLifelengths.FirstOrDefault(x => x.Value.Equals(q)).Key;
					}


					foreach (var lifelength in groupLifelengths)
					{
						if (tempHours.Hours == lifelength.Value.Hours)
						{
							if (lifelength.Key >= lastGroup)
							{
								var np = new NextPerformance();
								np.PerformanceSource = new Lifelength();

								if (value.IsNullOrZero())
									value = tempHours;
								else
								{
									if (check.PhaseRepeat != null && !check.PhaseRepeat.IsNullOrZero())
										value += check.PhaseRepeat;
									else value += check.PhaseThresh;
								}

								double hours = 0;
								double cycle = 0;

								if (checks.Any(i => i.PerformanceRecords.Count > 0))
								{
									hours = value.Hours.Value;
									cycle = value.Cycles.Value;
								}
								else
								{
									hours = (double)(value.Days * averageUtilization.Hours);
									cycle = (double)(value.Days * (averageUtilization.Hours / averageUtilization.CyclesPerDay));
								}



								np.PerformanceSource.Hours = (int?)Math.Round(hours);
								np.PerformanceSource.Cycles = (int?)Math.Round(cycle);
								np.PerformanceSource.Days = value.Days;


								np.Remains = new Lifelength(np.PerformanceSource);
								np.Remains.Substract(current); // remains = next - current
								np.Remains.Resemble(np.PerformanceSource);
								np.Group = lifelength.Key;
								np.ParentCheck = check;
								np.PerformanceDate = currentAircraft.ManufactureDate.AddDays(np.PerformanceSource.Days.Value);
								//averageUtilization != null ? AnalystHelper.GetApproximateDate(np.Remains, averageUtilization, conditionType)
								//	: null;

								if (current.Days > value.Days)
									np.Condition = ConditionState.Overdue;

								if (current.Hours == value.Hours || current.Cycles == value.Cycles || current.Days == value.Days)
									np.Condition = ConditionState.Notify;

								check.NextPerformances.Add(np);
							}

							if (check.PhaseRepeat != null && !check.PhaseRepeat.IsNullOrZero())
								tempHours += check.PhaseRepeat;
							else tempHours += check.PhaseThresh;


						}
					}
				}
				else
				{
					var tempHours = check.PhaseThresh;
					foreach (var lifelength in groupLifelengths)
					{
						//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
						if (tempHours.Hours == lifelength.Value.Hours)
						{
							var np = new NextPerformance();
							np.PerformanceSource = new Lifelength();

							var hours = (double)(tempHours.Days * averageUtilization.Hours);
							var cycle = (double)(tempHours.Days * (averageUtilization.Hours / averageUtilization.CyclesPerDay));

							np.PerformanceSource.Hours = (int?)Math.Round(hours);
							np.PerformanceSource.Cycles = (int?)Math.Round(cycle);
							np.PerformanceSource.Days = tempHours.Days;

							np.Remains = new Lifelength(np.PerformanceSource);
							np.Remains.Substract(current); // remains = next - current
							np.Remains.Resemble(np.PerformanceSource);
							np.Group = lifelength.Key;
							np.ParentCheck = check;
							np.PerformanceDate = currentAircraft.ManufactureDate.AddDays(np.PerformanceSource.Days.Value);
							//averageUtilization != null ? AnalystHelper.GetApproximateDate(np.Remains, averageUtilization, conditionType)
							//	: null;

							if (current.Hours == tempHours.Hours || current.Cycles == tempHours.Cycles || current.Days == tempHours.Days)
								np.Condition = ConditionState.Notify;

							if (current.Hours > tempHours.Hours || current.Cycles > tempHours.Cycles || current.Days > tempHours.Days)
								np.Condition = ConditionState.Overdue;

							if (ingoneCompliance)
								check.NextPerformancesWithIgnorLast.Add(np);
							else check.NextPerformances.Add(np);

							if (check.PhaseRepeat != null && !check.PhaseRepeat.IsNullOrZero())
								tempHours += check.PhaseRepeat;
							else tempHours += check.PhaseThresh;
						}
					}
				}

				check.NextPerformance = check.NextPerformances.FirstOrDefault();
				check.Group = check.NextPerformance?.Group ?? 1;


				#region Определение остатка ресурса (Remain)


				//check.NextPerformance.Remains = new Lifelength(check.NextPerformance.PerformanceSource);
				//check.NextPerformance.Remains.Substract(current); // remains = next - current
				//check.NextPerformance.Remains.Resemble(check.NextPerformance.PerformanceSource);


				//check.NextPerformance.PerformanceDate =
				//	averageUtilization != null ? AnalystHelper.GetApproximateDate(check.NextPerformance.Remains, averageUtilization, conditionType)
				//		: null;

				#endregion
			}
		}

		public Dictionary<int, Lifelength> CalculateGroupNew(List<MTOPCheck> checks)
		{
			var res = new Dictionary<int, Lifelength>();
			var list = new List<Lifelength>();
			foreach (var check in checks)
			{
				if (check.PhaseThresh.Hours == 0)
				{
					res.Add(1, new Lifelength(100, 100, 100));
					return res;
				}
				bool flag = true;
				var value = Lifelength.Zero;
				while (value.Hours < 100000)
				{
					if (flag)
					{
						value += check.PhaseThresh;
						flag = false;
					}
					else
					{
						if (check.PhaseRepeat != null && !check.PhaseRepeat.IsNullOrZero())
							value += check.PhaseRepeat;
						else value += check.PhaseThresh;
					}

					var ll = new Lifelength(value);
					ll.ParentCheck = check;
					list.Add(ll);
				}
			}

			var preRes = new Dictionary<int, Lifelength>();
			var q = 1;
			foreach (var lifelength in list.OrderBy(i => i.Hours))
			{
				if (!preRes.Any(i => i.Value.Hours == lifelength.Hours))
				{
					preRes.Add(q, lifelength);
					res.Add(q, lifelength);
					q++;
				}
			}

			list.Clear();

			return res;
		}

		public void CalculateDirective(IMtopCalc directive, AverageUtilization averageUtilization)
		{
			double hours = 0, cycles = 0, days = 0;
			double hoursPhase = -1, cyclesPhase = -1, daysPhase = -1;

			directive.PhaseThresh = new Lifelength(0, 0, 0);

			var thresh = !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero() ? directive.Threshold.FirstPerformanceSinceNew : directive.Threshold.FirstPerformanceSinceEffectiveDate;

			var threshHours = thresh.Hours;
			if (directive.APUCalc && threshHours.HasValue)
			{
				var aircraft = _aircraftsCore.GetAircraftById(directive.ParentAircraftId);
				threshHours = (int?)(thresh.Hours / aircraft.APUFH);
			}

			if (thresh.Days.HasValue)
			{
				hours = (double)(thresh.Days * averageUtilization.Hours);
				cycles = hours / averageUtilization.Cycles;
				days = (double)thresh.Days;
			}
			else if (threshHours.HasValue)
			{
				hours = (double)threshHours;
				cycles = hours / averageUtilization.Cycles;
				days = (double)(threshHours / averageUtilization.HoursPerDay);
			}
			else if (thresh.Cycles.HasValue)
			{
				cycles = (double)thresh.Cycles;
				days = (double)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
				hours = days * averageUtilization.Hours;
			}


			if (cycles > thresh.Cycles && hours > threshHours)
			{
				var cycleDays = (int)(cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

				if (cycleDays > days)
				{
					daysPhase = (int)(threshHours / averageUtilization.HoursPerDay);
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;
				}
				else
				{
					daysPhase = (int)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;

					if (hoursPhase > threshHours)
					{
						daysPhase = (int)(threshHours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;
					}
				}
			}
			else if (cycles > thresh.Cycles)
			{
				daysPhase = (int)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
				cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
				hoursPhase = daysPhase * averageUtilization.Hours;

				if (hoursPhase > threshHours)
				{
					daysPhase = (int)(threshHours / averageUtilization.HoursPerDay);
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;
				}
			}
			else if (hours > threshHours)
			{
				daysPhase = (int)(threshHours / averageUtilization.HoursPerDay);
				cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
				hoursPhase = daysPhase * averageUtilization.Hours;

				if (cyclesPhase > thresh.Cycles)
				{
					daysPhase = (int)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					hoursPhase = daysPhase * averageUtilization.Hours;
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
				}
			}

			directive.PhaseThresh.Hours = (int)Math.Round(hoursPhase > -1 ? hoursPhase : hours);
			directive.PhaseThresh.Cycles = (int)Math.Round(cyclesPhase > -1 ? cyclesPhase : cycles);
			directive.PhaseThresh.Days = (int)Math.Round(daysPhase > -1 ? daysPhase : days);



			var repeat = directive.Threshold.RepeatInterval;
			directive.PhaseRepeat = new Lifelength(0, 0, 0);

			if (!repeat.IsNullOrZero())
			{

				var repeatHours = repeat.Hours;

				if (directive.APUCalc && repeatHours.HasValue)
				{
					var aircraft = _aircraftsCore.GetAircraftById(directive.ParentAircraftId);
					//directive.PhaseRepeat = new Lifelength(repeat);
					repeatHours = (int?)(repeatHours / aircraft.APUFH);
				}

				hoursPhase = -1;
				cyclesPhase = -1;
				daysPhase = -1;

				if (repeat.Days.HasValue)
				{
					hours = (double)(repeat.Days * averageUtilization.Hours);
					cycles = hours / averageUtilization.Cycles;
					days = (double)repeat.Days;
				}
				else if (repeatHours.HasValue)
				{
					hours = (double)repeatHours;
					cycles = hours / averageUtilization.Cycles;
					days = (double)(repeatHours / averageUtilization.HoursPerDay);
				}
				else if (repeat.Cycles.HasValue)
				{
					cycles = (double)repeat.Cycles;
					days = (double)(repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					hours = days * averageUtilization.Hours;
				}


				if (cycles > repeat.Cycles && hours > repeatHours)
				{
					var cycleDays = (int)(cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

					if (cycleDays > days)
					{
						daysPhase = (int)(repeatHours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;
					}
					else
					{
						daysPhase = (int)(repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;

						if (hoursPhase > repeatHours)
						{
							daysPhase = (int)(repeatHours / averageUtilization.HoursPerDay);
							cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
							hoursPhase = daysPhase * averageUtilization.Hours;
						}
					}
				}
				else if (cycles > repeat.Cycles)
				{
					daysPhase = (int)(repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;

					if (hoursPhase > repeatHours)
					{
						daysPhase = (int)(repeatHours / averageUtilization.HoursPerDay);
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
						hoursPhase = daysPhase * averageUtilization.Hours;
					}
				}
				else if (hours > repeatHours)
				{
					daysPhase = (int)(repeatHours / averageUtilization.HoursPerDay);
					cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					hoursPhase = daysPhase * averageUtilization.Hours;

					if (cyclesPhase > repeat.Cycles)
					{
						daysPhase = (int)(repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
						hoursPhase = daysPhase * averageUtilization.Hours;
						cyclesPhase = daysPhase * (averageUtilization.Hours / averageUtilization.CyclesPerDay);
					}
				}

				directive.PhaseRepeat.Hours = (int)Math.Round(hoursPhase > -1 ? hoursPhase : hours);
				directive.PhaseRepeat.Cycles = (int)Math.Round(cyclesPhase > -1 ? cyclesPhase : cycles);
				directive.PhaseRepeat.Days = (int)Math.Round(daysPhase > -1 ? daysPhase : days);
			}

		}

		public void CalculatePhase(IEnumerable<IMtopCalc> directives, List<MTOPCheck> checks, AverageUtilization averageUtilization, bool isZeroPhase = false)
		{
			foreach (var directive in directives)
				calculatePhase(directive, checks, averageUtilization, isZeroPhase);
		}

		public void CalculatePhaseWithPerformance(IEnumerable<IMtopCalc> directives, List<MTOPCheck> checks, AverageUtilization averageUtilization, DateTime from, DateTime to, bool isZeroPhase = false)
		{
			foreach (var directive in directives)
			{
				calculatePhase(directive, checks, averageUtilization, isZeroPhase);

				directive.MtopNextPerformances = new List<NextPerformance>();

				if (directive.Condition.Equals(ConditionState.NotEstimated))
					continue;

				var tempHours = Lifelength.Null;

				if (directive.LastPerformance != null)
				{
					tempHours.Add(directive.LastPerformance.OnLifelength);
					if (directive.PhaseRepeat != null)
						tempHours.Add(directive.PhaseRepeat);
					else if (directive.PhaseThresh != null)
						tempHours.Add(directive.PhaseThresh);
				}
				else
				{
					if (directive.PhaseThresh != null)
						tempHours.Add(directive.PhaseThresh);
					else if (directive.PhaseRepeat != null)
						tempHours.Add(directive.PhaseRepeat);
				}



				//directive.MTOPPhase = new Phase();
				//directive.MTOPPhase.IsZeroPhase = isZeroPhase;

				var check = checks.LastOrDefault(i => i.PhaseThresh.Days <= tempHours.Days);
				if (check == null) continue;

				var checksForPeriod = check.NextPerformances.Where(i => i.PerformanceDate >= from &&
				                                                        i.PerformanceDate <= to);

				if (checksForPeriod.Count() == 0)
					continue;

				var current = _calculator.GetCurrentFlightLifelength(directive.LifeLengthParent);
				NextPerformance np = null;
				NextPerformance lastNp;
				var last = Lifelength.Null;

				var startGroup = directive.MTOPPhase.FirstPhase;

				if (check.PerformanceRecords.Count > 0)
				{
					if (isZeroPhase)
					{
						var q = checksForPeriod.FirstOrDefault(i => i.Group == startGroup);
						if (q != null)
							tempHours = q.PerformanceSource;
						else tempHours = checksForPeriod.FirstOrDefault().PerformanceSource;
					}
				}

				var group = checksForPeriod.Any(i => i.Group == directive.MTOPPhase.FirstPhase) ? directive.MTOPPhase.FirstPhase : directive.MTOPPhase.SecondPhase;

				for (; ; )
				{
					if (directive.MTOPPhase.Difference == 0)
						break;
					NextPerformance record;

					record = checksForPeriod.FirstOrDefault(i => i.Group == group);

					if (record == null)
					{
						record = checksForPeriod.FirstOrDefault(i => i.Group > group && i.Group % directive.MTOPPhase.Difference == 0);
						//record = checksForPeriod.FirstOrDefault(i => i.PerformanceSource.Days.Value >= tempHours.Days);
						if (record == null) break;
					}

					while (record.PerformanceSource.Days.Value > tempHours.Days)
					{
						if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
							tempHours += directive.PhaseRepeat;
						else tempHours += directive.PhaseThresh;
					}

					record = checksForPeriod.LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days);
					if (record == null)
						break;



					group = record.Group;

					if (directive.MtopNextPerformances.Count == 0)
					{
						if (directive.LastPerformance == null) // директива ни разу не выполнялась
						{
							if ((directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
							     !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
							    ||
							    (directive.Threshold.FirstPerformanceSinceNew != null &&
							     !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero()))
							{
								Lifelength sinceEffDate = Lifelength.Null;
								if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
								    !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
								{
									sinceEffDate = _calculator.GetFlightLifelengthOnStartOfDay(directive.LifeLengthParent, directive.Threshold.EffectiveDate);
									//sinceEffDate.Resemble(directive.Threshold.FirstPerformanceSinceEffectiveDate);
									if (directive.Threshold.RepeatInterval.CalendarValue != null)
										sinceEffDate.Add(directive.Threshold.EffectiveDate, directive.Threshold.FirstPerformanceSinceEffectiveDate);
									else sinceEffDate.Add(directive.Threshold.FirstPerformanceSinceEffectiveDate);
								}

								// с момента производства
								Lifelength sinceNew = Lifelength.Null;
								if (directive.Threshold.FirstPerformanceSinceNew != null &&
								    !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
								{
									sinceNew = directive.PhaseThresh;
								}

								var temp = new Lifelength(sinceNew);
								if (directive.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
									temp.SetMin(sinceEffDate);
								else temp.SetMax(sinceEffDate);


								if (tempHours.IsGreater(temp) && record != null)
								{
									np = record.GetCopyUnsaved();
									np.Parent = directive;
									np.PerformanceSource = new Lifelength(tempHours);
									np.PerformanceNum = record.Group;
								}
								else
								{
									record = checksForPeriod.LastOrDefault(i => i.PerformanceSource.Days.Value <= temp.Days);

									if (record != null)
									{
										np = record.GetCopyUnsaved();
										np.Parent = directive;
										np.PerformanceSource = new Lifelength(temp);
										np.PerformanceNum = record.Group;

										tempHours = new Lifelength(temp);
									}
								}
							}

						}
						else// Директива уже выполнялась 
						{
							np = new NextPerformance { Parent = directive };
							last = directive.LastPerformance.OnLifelength;

							int lastPerfNum = directive.LastPerformance.PerformanceNum <= 0 ? 1 : directive.LastPerformance.PerformanceNum;
							np.PerformanceNum = lastPerfNum + directive.MtopNextPerformances.Count + 1;
							np.PerformanceSource = new Lifelength(tempHours);

							// Убираем не нужные параметры
							if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
								np.PerformanceSource.Resemble(directive.PhaseRepeat);
							else np.PerformanceSource.Resemble(directive.PhaseThresh);
						}
					}
					else
					{
						np = new NextPerformance { Parent = directive };
						lastNp = directive.MtopNextPerformances.Last();
						last = lastNp.PerformanceSource;
						np.PerformanceNum = lastNp.PerformanceNum + 1;
						np.PerformanceSource = new Lifelength(tempHours);
						//if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
						//	np.PerformanceSource.Add(directive.PhaseRepeat);
						//else np.PerformanceSource.Add(directive.PhaseThresh);
						// Убираем не нужные параметры
						if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
							np.PerformanceSource.Resemble(directive.PhaseRepeat);
						else np.PerformanceSource.Resemble(directive.PhaseThresh);

					}

					if (np == null)
						break;

					if (directive.RecalculateTenPercent)
					{
						np.PerformanceSource.Hours += (int)(np.PerformanceSource.Hours * 0.1);
						np.PerformanceSource.Cycles += (int)(np.PerformanceSource.Cycles * 0.1);
						np.PerformanceSource.Days += (int)(np.PerformanceSource.Days * 0.1);

						record = checksForPeriod.LastOrDefault(i => i.PerformanceSource.Days.Value <= np.PerformanceSource.Days && i.Group >= startGroup);
					}

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


					np.Remains = new Lifelength(np.LimitOverdue);
					np.Remains.Substract(current); // remains = next - current

					np.Remains.Resemble(np.LimitOverdue);

					np.ParentCheck = check;
					np.PerformanceDate = _calculator.GetManufactureDate(directive.LifeLengthParent).AddDays(np.PerformanceSource.Days.Value);


					ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst;
					Lifelength notify = null;
					if (directive.LastPerformance == null)
					{
						conditionType = directive.Threshold.FirstPerformanceConditionType;
						notify = directive.Threshold.FirstNotification != null
							? new Lifelength(directive.Threshold.FirstNotification)
							: null;
					}
					else if (directive.Threshold.RepeatInterval != null && !directive.Threshold.RepeatInterval.IsNullOrZero())
					{
						conditionType = directive.Threshold.RepeatPerformanceConditionType;
						notify = directive.Threshold.RepeatNotification != null
							? new Lifelength(directive.Threshold.RepeatNotification)
							: null;
					}

					if (conditionType == ThresholdConditionType.WhicheverFirst)
					{
						// задано только одно условие выполнения - считаем по whichever first
						// whichever first

						// состояние директивы - просрочена или нормально
						np.Condition = computeConditionState(directive, np.LimitOverdue, np.Remains, current, notify, x => x.IsOverdue(), x => x.IsLessByAnyParameter(notify), conditionType);

					}
					else // whichever later
					{
						// директива просрочена только в том случае, когда она просрочена по всем параметрам
						np.Condition = computeConditionState(directive, np.LimitOverdue, np.Remains, current, notify, x => x.IsAllOverdue(), x => x.IsLess(notify), conditionType);
					}


					np.Group = record?.Group ?? -1;

					//if (np.PerformanceDate >= from && np.PerformanceDate <= to)
					//	directive.MtopNextPerformances.Add(np);
					//else break;

					if (np.PerformanceDate <= to)
						directive.MtopNextPerformances.Add(np);
					else
					{
						directive.MtopNextPerformances.RemoveAll(i => i.PerformanceDate > from);
						break;
					}

					group += directive.MTOPPhase.Difference;

					if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
						tempHours += directive.PhaseRepeat;
					else tempHours += directive.PhaseThresh;
				}
			}
		}

		private void calculatePhase(IMtopCalc directive, List<MTOPCheck> checks, AverageUtilization averageUtilization,
			bool isZeroPhase = false)
		{
			CalculateDirective(directive, averageUtilization);

			directive.MtopNextPerformances = new List<NextPerformance>();
			if (directive.PhaseThresh.IsNullOrZero())
				return;
			//if (directive.Condition.Equals(ConditionState.NotEstimated))
			//	return;

			var tempHours = Lifelength.Null;

			if (directive.LastPerformance != null)
			{
				tempHours.Add(directive.LastPerformance.OnLifelength);
				if (directive.PhaseRepeat != null)
					tempHours.Add(directive.PhaseRepeat);
				else if (directive.PhaseThresh != null)
					tempHours.Add(directive.PhaseThresh);
			}
			else
			{
				if (directive.PhaseThresh != null)
					tempHours.Add(directive.PhaseThresh);
				else if (directive.PhaseRepeat != null)
					tempHours.Add(directive.PhaseRepeat);
			}

			directive.MTOPPhase = new Phase();
			directive.MTOPPhase.IsZeroPhase = isZeroPhase;

	

			var check = checks.LastOrDefault(i => i.PhaseThresh.Days <= tempHours.Days);
			if (check?.NextPerformancesWithIgnorLast == null) return;


			directive.MTOPPhase.FirstPhase = check.NextPerformancesWithIgnorLast
				                                 .LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days)
				                                 ?.Group ?? 0;

			if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
				tempHours += directive.PhaseRepeat;
			else tempHours += directive.PhaseThresh;


			if (check.NextPerformancesWithIgnorLast.LastOrDefault().PerformanceSource.Days >= tempHours.Days)
				directive.MTOPPhase.SecondPhase = check.NextPerformancesWithIgnorLast
					.LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days).Group;
			else
				directive.MTOPPhase.SecondPhase = directive.MTOPPhase.FirstPhase * 2;


		}


		private ConditionState computeConditionState(IDirective directive, Lifelength limitOverdue, Lifelength remains,
			Lifelength current, Lifelength notify, Func<Lifelength, bool> getIsOverdueFunc,
			Func<Lifelength, bool> getIsLessFunc, ThresholdConditionType whicheverFirst)
		{
			if (notify != null && !notify.IsNullOrZero())
			{
				if (directive is Entities.General.Accessory.Component && ((Entities.General.Accessory.Component)directive).LLPMark && ((Entities.General.Accessory.Component)directive).LLPCategories)
				{
					return getIsOverdueFunc(remains)
						? ConditionState.Overdue
						: (getIsLessFunc(notify)
							? ConditionState.Notify
							: ConditionState.Satisfactory);
				}


				var optimizedCurrent = new Lifelength(current);
				optimizedCurrent.Resemble(limitOverdue);

				var optimizedCurrentNotify = new Lifelength(notify);
				optimizedCurrentNotify.Resemble(remains);

				if (whicheverFirst == ThresholdConditionType.WhicheverFirst)
				{
					if (optimizedCurrent.IsGreaterByAnyParameter(limitOverdue))
						return ConditionState.Overdue;

					if (remains.IsLessByAnyParameter(optimizedCurrentNotify))
						return ConditionState.Notify;
				}
				else
				{

					if (optimizedCurrent.IsGreaterNew(limitOverdue))
						return ConditionState.Overdue;

					if (remains.IsLessNew(optimizedCurrentNotify))
						return ConditionState.Notify;
				}


				return ConditionState.Satisfactory;

			}

			return getIsOverdueFunc(remains) ? ConditionState.Overdue : ConditionState.Satisfactory;
		}

		#endregion
	}
}