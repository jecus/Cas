using System;
using SmartCore.Auxiliary;
using SmartCore.Calculations;

namespace SmartCore.Analyst
{
	public class AnalystHelper
	{
		#region public static Double? GetApproximateDays(DateTime from, Lifelength remains, AverageUtilization average, ThresholdConditionType conditionType)

		/// <summary>
		/// Возвращает приблизительное количество дней, за которое наберется ресурс remains с заданной среднестатистической наработкой
		/// </summary>
		/// <param name="from"></param>
		/// <param name="remains"></param>
		/// <param name="average"></param>
		/// <param name="conditionType"></param>
		/// <returns></returns>
		public static Double? GetApproximateDays(DateTime from,
												 Lifelength remains, AverageUtilization average,
												 ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)
		{
			//
			if (remains == null || average == null) return null;

			if (remains.CalendarValue != null && remains.CalendarValue != 0)
			{
				DateTime to = from.AddCalendarSpan(remains.CalendarSpan);
				return (to - from).Days;
			}

			Double? d1 = average.CyclesPerMonth != 0 && remains.Cycles != null ? new Double?(remains.Cycles.Value / (average.Hours/average.Cycles)) : null;
			Double? d2 = average.HoursPerMonth != 0 && remains.Hours != null ? remains.Hours * 30 / average.HoursPerMonth : null;
			Double? d3 = remains.Days;

			// Whichever First vs. Whichever Later
			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				// Выбираем минимум 
				Double? min = null;
				if (d1 != null) min = d1;
				if (d2 != null && (min == null || d2 < min)) min = d2;
				if (d3 != null && (min == null || d3 < min)) min = d3;
				// Возвращаем результат
				return min;
			}

			// Выбираем максимум
			Double? max = null;
			if (d1 != null) max = d1;
			if (d2 != null && (max == null || d2 > max)) max = d2;
			if (d3 != null && (max == null || d3 > max)) max = d3;
			// Возвращаем результат
			return max;
		}
		#endregion

		#region public static Double? GetApproximateDays(Lifelength remains, AverageUtilization average, ThresholdConditionType conditionType)
		/// <summary>
		/// Возвращает приблизительное количество дней, за которое наберется ресурс remains с заданной среднестатистической наработкой
		/// </summary>
		/// <param name="remains"></param>
		/// <param name="average"></param>
		/// <param name="conditionType"></param>
		/// <returns></returns>
		public static Double? GetApproximateDays(Lifelength remains, AverageUtilization average,
												 ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)
		{
			//
			if (remains == null || average == null) return null;
			//if (average.CyclesPerMonth == 0 && average.HoursPerMonth == 0) return null;
			if (remains.Days != null && remains.Days != 0) return remains.Days;
			// 
			Double? d1 = average.CyclesPerMonth != 0 && remains.Cycles != null ? new Double?(remains.Cycles.Value / (average.Hours / average.Cycles)) : null;
			Double? d2 = average.HoursPerMonth != 0 && remains.Hours != null ? remains.Hours * 30 / average.HoursPerMonth : null;
			Double? d3 = remains.Days;

			// Whichever First vs. Whichever Later
			if (conditionType == ThresholdConditionType.WhicheverFirst)
			{
				// Выбираем минимум 
				Double? min = null;
				if (d1 != null) min = d1;
				if (d2 != null && (min == null || d2 < min)) min = d2;
				if (d3 != null && (min == null || d3 < min)) min = d3;
				// Возвращаем результат
				return min;
			}

			// Выбираем максимум
			Double? max = null;
			if (d1 != null) max = d1;
			if (d2 != null && (max == null || d2 > max)) max = d2;
			if (d3 != null && (max == null || d3 > max)) max = d3;
			// Возвращаем результат
			return max;
		}
		#endregion

		#region public static DateTime? GetApproximateDate(Lifelength remains, AverageUtilization average, ThresholdConditionType conditionType)
		/// <summary>
		/// Возвращает дату, когда наберется ресурс remains с заданной среднестатистической наработкой 
		/// </summary>
		/// <param name="remains"></param>
		/// <param name="average"></param>
		/// <param name="conditionType"></param>
		/// <returns></returns>
		public static DateTime? GetApproximateDate(Lifelength remains, AverageUtilization average, ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)
		{
			// 
			if (remains == null || average == null) return null;

			// расчитываем количество дней
			Double? days = GetApproximateDays(DateTime.Today, remains, average, conditionType);
			if (days == null) return null;

			// возвращаем дату
			return (DateTime.Today.AddDays(days.Value));
		}
		#endregion

		#region public static Lifelength GetUtilization(AverageUtilization average, Int32 days)

		/// <summary>
		/// Возвращает наработку агрегата или налет воздушного судна за указанный период времени
		/// </summary>
		/// <param name="average"></param>
		/// <param name="days"></param>
		/// <returns></returns>
		public static Lifelength GetUtilization(AverageUtilization average, Int32 days)
		{
			Lifelength res = Lifelength.Zero;

			if (average != null && average.CyclesPerMonth != 0 && average.HoursPerMonth != 0)
			{
				res.Cycles = (int)(days * average.CyclesPerMonth / 30);
				res.TotalMinutes = (int)(days * average.HoursPerMonth * 60 / 30);
			}

			res.Days = days;
			return res;
		}



		public static Lifelength GetUtilizationNew(AverageUtilization average, int days)
		{
			var res = Lifelength.Zero;

			if (average != null && average.CyclesPerMonth != 0 && average.HoursPerMonth != 0)
			{
				res.Cycles = (int)(days * average.CyclesPerMonth / 30);
				res.TotalMinutes = ((int)average.HoursPerDay * 60);


				var decimalParts = average.HoursPerDay.ToString("F").Split('.');
				string decimalPart = decimalParts[1];
				if (decimalPart.StartsWith("0"))
					decimalPart = decimalPart.Substring(1);
				res.TotalMinutes += int.Parse(decimalPart);


			}

			res.Days = days;
			return res;
		}

		#endregion
	}
}