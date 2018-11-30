using System;

namespace SmartCore.Calculations
{
	public class DateTimeDiff
	{
		/// <summary>
		/// Поля
		/// </summary>
		/// 
		private int _years;
		private int _months;
		private int _days;
		static int[] monthDay = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		private DateTime _fromDate;
		private DateTime _toDate;
		private bool _negative;

		/// <summary>
		/// Свойства
		/// </summary>
		public int Years
		{
			get { return _years; }
		}

		public int Months
		{
			get { return _months; }
		}

		public int Days
		{
			get { return _days; }
		}


		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		public DateTimeDiff(DateTime fromDate, DateTime toDate)
		{

			if (fromDate > toDate)
			{
				_fromDate = toDate;
				_toDate = fromDate;
				_negative = true;
			}
			else
			{
				_fromDate = fromDate;
				_toDate = toDate;
				_negative = false;
			}

			//Считаем разницу для годов, месяцев и дней
			var yearDiff = _toDate.Year - _fromDate.Year;
			var monthDiff = _toDate.Month - _fromDate.Month;
			var dayDiff = _toDate.Day - _fromDate.Day;

			if (yearDiff > 0)//если считаем дату с разных годов
			{
				if (monthDiff > 0)
				{
					_years = yearDiff;
					if (dayDiff >= 0)
					{
						_months = monthDiff;
						_days = dayDiff;
					}
					else //dayDiff < 0
					{
						_months = monthDiff - 1;
						_days = dayDiff + monthDay[_fromDate.Month - 1];
						if (DateTime.IsLeapYear(_toDate.Year) && _toDate.Month - 1 == 2)//проверяет является ли год высокосным 
							_days += 1;
					}
				}
				else if (monthDiff < 0)
				{
					_years = yearDiff - 1;
					if (dayDiff >= 0)
					{
						_months = monthDiff + 12;
						_days = dayDiff;
					}
					else //dayDiff < 0
					{
						var needMonth = _toDate.Month - 2;
						_months = monthDiff + 11;// +11 т.к разница дней и месяцев меньше нуля выгдялело бы (monthDiff + 12 - 1) 
						_days = dayDiff + monthDay[needMonth >= 0 ? needMonth : needMonth + 12];
					}
				}
				else
				{
					_years = yearDiff;
					_months = monthDiff;
					_days = dayDiff;
				}
			}
			else//если считаем дату с однго года
			{
				if (monthDiff > 0)
				{
					_years = yearDiff;
					if (dayDiff >= 0)
					{
						_months = monthDiff;
						_days = dayDiff;
					}
					else //dayDiff < 0
					{
						_months = monthDiff - 1;
						_days = dayDiff + monthDay[_fromDate.Month - 1];
						if (DateTime.IsLeapYear(_toDate.Year) && _toDate.Month - 1 == 2)
							_days += 1;
					}
				}
				else
				{
					_months = monthDiff;
					_days = dayDiff;
				}
			}

			//Flag заведен на случай если разница будет отрицательной(для упрощения алгоритма) 
			if (_negative)
			{
				_years *= -1;
				_months *= -1;
				_days *= -1;
			}

		}
	}
}