using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;

namespace CAS.API.Infrastructure
{
	public  static class GlobalObjects
	{
		private static Dictionary<Type, List<IBaseDictionary>> _dictionaries;
		private static List<BaseComponentDTO> _baseComponents;

		public static Dictionary<Type, List<IBaseDictionary>> Dictionaries
		{
			get => _dictionaries ?? (_dictionaries = new Dictionary<Type, List<IBaseDictionary>>());
			set => _dictionaries = value;
		}


		public static List<BaseComponentDTO> BaseComponents
		{
			get => _baseComponents ?? (_baseComponents = new List<BaseComponentDTO>());
			set => _baseComponents = value;
		}
	}
}