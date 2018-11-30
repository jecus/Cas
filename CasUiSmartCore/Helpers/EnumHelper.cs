using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.Helpers
{
	public static class EnumHelper
	{
		#region public static List<KeyValuePair<string, T>> GetDisplayValueMemberDict<T>() where T : struct 

		public static List<KeyValuePair<string, T>> GetDisplayValueMemberDict<T>() where T : struct
		{
			var type = typeof (T);
			if (!type.IsEnum)
				throw new ArgumentException("T should be enum.");

			var list = new List<KeyValuePair<string, T>>();
			foreach (T engineUtilization in Enum.GetValues(type))
			{
				var name = Enum.GetName(typeof (T), engineUtilization);
				var desc = name;
				var fi = typeof (T).GetField(name);
				var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
				if (attributes.Length > 0)
				{
					var s = attributes[0].Description;
					if (!string.IsNullOrEmpty(s))
					{
						desc = s;
					}
				}
				list.Add(new KeyValuePair<string, T>(desc, engineUtilization));
			}

			return list;
		}

		#endregion


		#region public static string EnumToString(Enum item)

		/// <summary>
		/// Метод преобразования перечисления в строковое представление
		/// </summary>
		/// <param name="item">Значение, которое надо преобразовать</param>
		/// <returns></returns>
		public static string EnumToString(Enum item)
		{
			var info = item.GetType().GetField(item.ToString());
			var descriptionAttributes = info.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (descriptionAttributes.Length < 1)
				return item.ToString();
			return ((DescriptionAttribute)descriptionAttributes[0]).Description;
		}

		#endregion


	}
}