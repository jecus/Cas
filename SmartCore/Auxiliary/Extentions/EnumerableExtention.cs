using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Auxiliary.Extentions
{
	public static class EnumerableExtention
	{
		public static T GetItemById<T>(this IEnumerable<T> collection, int itemId) where T : class, IBaseEntityObject
		{
			if (collection == null)
				throw new ArgumentNullException("Input parameters can not be null");

			return collection.FirstOrDefault(c => c.ItemId == itemId);
		}

		public static IEnumerable<T> GetValidEntries<T>(this IEnumerable<T> collection) where T : class, IBaseEntityObject
		{
			if (collection == null)
				throw new ArgumentNullException("Input parameters can not be null");

			return collection.Where(c => c.IsDeleted == false).ToArray();
		}
	}
}