using System;

namespace SmartCore.DtoHelper
{
	public static class Extentions
	{
		public static string ToSqlDate(this DateTime date)
		{
			//return date.Date.ToString("MM/dd/yyyy");
			return $"convert(datetime, '{date.Date:yyyy-MM-dd}', 101)";
		}
	}
}