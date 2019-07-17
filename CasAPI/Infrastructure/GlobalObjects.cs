using System;
using System.Collections.Generic;
using EntityCore.DTO;

namespace CasAPI.Infrastructure
{
	public  static class GlobalObjects
	{
		private static Dictionary<Type, List<IBaseDictionary>> _dictionaries;

		public static Dictionary<Type, List<IBaseDictionary>> Dictionaries
		{
			get => _dictionaries ?? (_dictionaries = new Dictionary<Type, List<IBaseDictionary>>());
			set => _dictionaries = value;
		}
	}
}