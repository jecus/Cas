using System;

namespace SmartCore.DtoHelper
{
	public static class Extentions
	{
		public static string ToSqlDate(this DateTime date)
		{
			return $"convert(datetime, '{date.Date}', 104)";
		}
	}
}