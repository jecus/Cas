using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAS.API.Infrastructure;
using CAS.Entity.Core;
using CAS.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers
{
    public class BaseDictionaryController<T> : BaseController<T> where T : BaseEntity
    {
        public BaseDictionaryController(DataContext context, ILogger<BaseController<T>> logger) : base(context, logger)
        {
        }


		#region Overrides of BaseController<T>

		public async override Task<ActionResult<T>> GetObjectById(int id, bool loadChild = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(typeof(T)))
				return GlobalObjects.Dictionaries[typeof(T)].Cast<T>().FirstOrDefault(i => i.ItemId == id);

			return await base.GetObjectById(id, loadChild);
		}

		public async override Task<ActionResult<List<T>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(typeof(T)) && filters.IsNullOrEmpty())
				return GlobalObjects.Dictionaries[typeof(T)].Cast<T>().ToList();

			return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		public async override Task<ActionResult<int>> Save(T entity)
		{
			try
			{
				var res = await _repository.SaveAsync(entity);

				if (GlobalObjects.Dictionaries.ContainsKey(typeof(T)))
				{
					var find = GlobalObjects.Dictionaries[typeof(T)].FirstOrDefault(i => i.ItemId == entity.ItemId);
					if (find == null)
						GlobalObjects.Dictionaries[typeof(T)].Add((IBaseDictionary)entity);
					else
					{
						GlobalObjects.Dictionaries[typeof(T)].Remove(find);
						GlobalObjects.Dictionaries[typeof(T)].Add((IBaseDictionary)entity);
					}

				}

				return Ok(res);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		public async override Task<ActionResult> Delete(T entity)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(typeof(T)))
			{
				var find = GlobalObjects.Dictionaries[typeof(T)].FirstOrDefault(i => i.ItemId == entity.ItemId);
				if (find != null)
					GlobalObjects.Dictionaries[typeof(T)].Remove(find);
			}

			return await base.Delete(entity);
		}

		public async override Task<ActionResult> BulkDelete(IEnumerable<T> entity, int? batchSize = null)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(typeof(T)))
			{
				var ids = entity.Select(i => i.ItemId);
				var find = GlobalObjects.Dictionaries[typeof(T)].Where(i => ids.Contains(i.ItemId)).OfType<T>().ToList();
				foreach (var dto in find)
					GlobalObjects.Dictionaries[typeof(T)].Remove((IBaseDictionary)dto);
			}

			return await base.BulkDelete(entity, batchSize);
		}


		#endregion
	}
}
