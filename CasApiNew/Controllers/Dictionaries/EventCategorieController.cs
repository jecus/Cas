using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasApiNew.Infrastructure;
using Entity.Core;
using Entity.Models.DTO.Dictionaries;
using Entity.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.Dictionaries
{
	[Route("eventcategorie")]
	public class EventCategorieController : BaseController<EventCategorieDTO>
	{
		private Type _type = typeof(EventCategorieDTO);

		public EventCategorieController(DataContext context, ILogger<BaseController<EventCategorieDTO>> logger) : base(context, logger)
		{
			
		}

		#region Overrides of BaseController<T>

		public async override Task<ActionResult<EventCategorieDTO>> GetObjectById(int id, bool loadChild = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
				return GlobalObjects.Dictionaries[_type].Cast<EventCategorieDTO>().FirstOrDefault(i => i.ItemId == id);

			return await base.GetObjectById(id, loadChild);
		}

		public async override Task<ActionResult<List<EventCategorieDTO>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type) && filters.IsNullOrEmpty())
				return GlobalObjects.Dictionaries[_type].Cast<EventCategorieDTO>().ToList();

			return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		public async override Task<ActionResult<int>> Save(EventCategorieDTO entity)
		{
			try
			{
				var res = await _repository.SaveAsync(entity);

				if (GlobalObjects.Dictionaries.ContainsKey(_type))
				{
					var find = GlobalObjects.Dictionaries[_type].FirstOrDefault(i => i.ItemId == entity.ItemId);
					if (find == null)
						GlobalObjects.Dictionaries[_type].Add(entity);
					else
					{
						GlobalObjects.Dictionaries[_type].Remove(find);
						GlobalObjects.Dictionaries[_type].Add(entity);
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

		public async override Task<ActionResult> Delete(EventCategorieDTO entity)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var find = GlobalObjects.Dictionaries[_type].FirstOrDefault(i => i.ItemId == entity.ItemId);
				if (find != null)
					GlobalObjects.Dictionaries[_type].Remove(find);
			}

			return await base.Delete(entity);
		}

		public async override Task<ActionResult> BulkDelete(IEnumerable<EventCategorieDTO> entity, int? batchSize = null)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var ids = entity.Select(i => i.ItemId);
				var find = GlobalObjects.Dictionaries[_type].Where(i => ids.Contains(i.ItemId)).OfType<EventCategorieDTO>().ToList();
				foreach (var dto in find)
					GlobalObjects.Dictionaries[_type].Remove(dto);
			}

			return await base.BulkDelete(entity, batchSize);
		}


		#endregion
	}
}