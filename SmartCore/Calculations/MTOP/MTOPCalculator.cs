using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Aircrafts;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace SmartCore.Calculations.MTOP
{
	public class MTOPCalculator : IMTOPCalculator
	{
		private readonly ICalculator _calculator;
		private readonly IAircraftsCore _aircraftsCore;

		#region Constructor

		public MTOPCalculator(ICalculator calculator, IAircraftsCore aircraftsCore)
		{
			_calculator = calculator;
			_aircraftsCore = aircraftsCore;
		}

		#endregion

		public void CalculateMtopChecks(List<MTOPCheck> checks, AverageUtilization averageUtilization)
		{
			foreach (var check in checks)
			{
				check.PhaseThreshLimit = new Lifelength(0, 0, 0);

				double hours, cycles, days;
				double hoursPhase = -1, cyclesPhase = -1, daysPhase = -1;

				if (check.Thresh.Days.HasValue)
				{
					hours = (double) (check.Thresh.Days * averageUtilization.Hours);
					cycles = hours / averageUtilization.Cycles;
					days = (double)check.Thresh.Days;
				}
				else if(check.Thresh.Hours.HasValue)
				{
					hours = (double) check.Thresh.Hours;
					cycles = hours / averageUtilization.Cycles;
					days = (double)(check.Thresh.Hours / averageUtilization.HoursPerDay);
				}
				else
				{
					cycles = (double) check.Thresh.Cycles;
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
					var cycleDays = (int) (check.PhaseThresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

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
						var cycleDays = (int) (check.PhaseRepeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

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
				if(ingoneCompliance)
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

							if(ingoneCompliance)
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

		public void CalculateDirective(MaintenanceDirective directive,AverageUtilization averageUtilization)
		{
			double hours = 0, cycles = 0, days = 0;
			double hoursPhase = -1, cyclesPhase = -1, daysPhase = -1;

			directive.PhaseThresh = new Lifelength(0,0,0);

			var thresh = !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero() ? directive.Threshold.FirstPerformanceSinceNew : directive.Threshold.FirstPerformanceSinceEffectiveDate;

			var threshHours = thresh.Hours;
			if (directive.APUCalc && threshHours.HasValue)
			{
				var aircraft = _aircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);
				threshHours = (int?)(thresh.Hours / aircraft.APUFH);
			}

			if (thresh.Days.HasValue)
			{
				hours = (double)(thresh.Days * averageUtilization.Hours);
				cycles = hours / averageUtilization.Cycles;
				days = (double) thresh.Days;
			}
			else if (threshHours.HasValue)
			{
				hours = (double)threshHours;
				cycles = hours / averageUtilization.Cycles;
				days = (double)(threshHours / averageUtilization.HoursPerDay);
			}
			else if(thresh.Cycles.HasValue)
			{
				cycles = (double) thresh.Cycles;
				days = (double)(thresh.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
				hours = days * averageUtilization.Hours;
			}


			if (cycles > thresh.Cycles && hours > threshHours)
			{
				var cycleDays = (int)(cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

				if (cycleDays > days)
				{
					daysPhase = (int) (threshHours / averageUtilization.HoursPerDay);
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
			else if (cycles> thresh.Cycles)
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
					var aircraft = _aircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);
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
					days = (double) repeat.Days;
				}
				else if (repeatHours.HasValue)
				{
					hours = (double)repeatHours;
					cycles = hours / averageUtilization.Cycles;
					days = (double)(repeatHours / averageUtilization.HoursPerDay);
				}
				else if (repeat.Cycles.HasValue)
				{
					cycles = (double) repeat.Cycles;
					days = (double)(repeat.Cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));
					hours = days * averageUtilization.Hours;
				}


				if (cycles > repeat.Cycles && hours > repeatHours)
				{
					var cycleDays = (int) (cycles / (averageUtilization.Hours / averageUtilization.CyclesPerDay));

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

		public void CalculatePhase(CommonCollection<MaintenanceDirective> directives, List<MTOPCheck> checks, AverageUtilization averageUtilization, bool isZeroPhase = false)
		{
			foreach (var directive in directives)
				calculatePhase(directive, checks, averageUtilization, isZeroPhase);
		}

		public void CalculatePhaseWithPerformance(CommonCollection<MaintenanceDirective> directives, List<MTOPCheck> checks, AverageUtilization averageUtilization, DateTime from, DateTime to, bool isZeroPhase = false)
		{
			foreach (var directive in directives)
			{
				if(directive.ItemId == 57907)
					Console.WriteLine();

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

				var group = checksForPeriod.Any(i => i.Group == directive.MTOPPhase.FirstPhase) ? directive.MTOPPhase.FirstPhase:directive.MTOPPhase.SecondPhase;

				for (; ;)
				{
					if(directive.MTOPPhase.Difference == 0)
						break;
					NextPerformance record;
					if (isZeroPhase)
					{
						//record = checksForPeriod.FirstOrDefault(i => i.PerformanceSource.Days.Value >= tempHours.Days);
						record = checksForPeriod.LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days);
						//if (record == null) break;
						if (record == null)
						{
							if (checksForPeriod.All(i => i.PerformanceSource.Days > tempHours.Days))
								record = checksForPeriod.FirstOrDefault();
							else break;
						}
					}
					else
					{
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
						if(record == null)
							break;
					}


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
							np = new NextPerformance { Parent = directive};
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
						np.Condition = computeConditionState(directive, np.LimitNotify, np.LimitOverdue, np.Remains, current, notify, x => x.IsOverdue(), x => x.IsLessByAnyParameter(notify));

					}
					else // whichever later
					{
						// директива просрочена только в том случае, когда она просрочена по всем параметрам
						np.Condition = computeConditionState(directive, np.LimitNotify, np.LimitOverdue, np.Remains, current, notify, x => x.IsAllOverdue(), x => x.IsLess(notify));
					}


					np.Group = record?.Group ?? -1;


					if (np.PerformanceDate >= from &&np.PerformanceDate <= to)
						directive.MtopNextPerformances.Add(np);
					else break;

					group += directive.MTOPPhase.Difference;

					if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
						tempHours += directive.PhaseRepeat;
					else tempHours += directive.PhaseThresh;
				}

				//if (directive.MtopNextPerformances.Count > 0)
				//{
				//	directive.MTOPPhase.FirstPhase = directive.MtopNextPerformances[0].Group;

				//	if (directive.MtopNextPerformances.Count > 1)
				//		directive.MTOPPhase.SecondPhase = directive.MtopNextPerformances[1].Group;
				//	else directive.MTOPPhase.SecondPhase = directive.MTOPPhase.FirstPhase * 2;
				//}
			}
		}

		private void calculatePhase(MaintenanceDirective directive, List<MTOPCheck> checks, AverageUtilization averageUtilization, bool isZeroPhase = false)
		{
			CalculateDirective(directive, averageUtilization);

			directive.MtopNextPerformances = new List<NextPerformance>();

			if (directive.Condition.Equals(ConditionState.NotEstimated))
				return;

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
			if(check?.NextPerformancesWithIgnorLast == null) return;

			foreach (var n in check.NextPerformancesWithIgnorLast)
			{
				if (directive.MTOPPhase.FirstPhase != 0 && directive.MTOPPhase.SecondPhase != 0 && directive.MTOPPhase.FirstPhase != directive.MTOPPhase.SecondPhase)
					break;

				if (directive.MTOPPhase.FirstPhase == 0)
					directive.MTOPPhase.FirstPhase = check.NextPerformancesWithIgnorLast.LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days)?.Group ?? 0;
				else if (directive.MTOPPhase.SecondPhase == 0 || directive.MTOPPhase.FirstPhase == directive.MTOPPhase.SecondPhase)
				{

					if (directive.PhaseThresh.Equals(directive.PhaseRepeat))
					{
						directive.MTOPPhase.SecondPhase = directive.MTOPPhase.FirstPhase * 2;
					}
					else
					{
						if (check.NextPerformancesWithIgnorLast.LastOrDefault().PerformanceSource.Days >= tempHours.Days)
							directive.MTOPPhase.SecondPhase = check.NextPerformancesWithIgnorLast
								.LastOrDefault(i => i.PerformanceSource.Days.Value <= tempHours.Days).Group;
						else
							directive.MTOPPhase.SecondPhase = directive.MTOPPhase.FirstPhase * 2;
					}
				}

				if (directive.PhaseRepeat != null && !directive.PhaseRepeat.IsNullOrZero())
					tempHours += directive.PhaseRepeat;
				else tempHours += directive.PhaseThresh;
			}

			//if (directive.MTOPPhase != null)
			//{
			//	if (check.PerformanceRecords.Count > 0)
			//	{
			//		var dif = directive.MTOPPhase.Difference;
			//		directive.MTOPPhase.FirstPhase += check.PerformanceRecords.Last().GroupName;
			//		directive.MTOPPhase.SecondPhase = directive.MTOPPhase.FirstPhase + dif;

			//	}
			//}
		}


		private ConditionState computeConditionState(IDirective directive, Lifelength limitNotify, Lifelength limitOverdue, Lifelength remains,		Lifelength current, Lifelength notify, Func<Lifelength, bool> getIsOverdueFunc, Func<Lifelength, bool> getIsLessFunc)
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