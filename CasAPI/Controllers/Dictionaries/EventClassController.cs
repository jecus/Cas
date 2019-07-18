using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasAPI.Infrastructure;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using EntityCore.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("eventclass")]
	public class EventClassController : BaseController<EventClassDTO>
	{
		private Type _type = typeof(EventClassDTO);

		public EventClassController(DataContext context, ILogger<BaseController<EventClassDTO>> logger) : base(context, logger)
		{
			
		}

		#region Overrides of BaseController<T>

		public async override Task<ActionResult<EventClassDTO>> GetObjectById(int id, bool loadChild = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
				return GlobalObjects.Dictionaries[_type].Cast<EventClassDTO>().FirstOrDefault(i => i.ItemId == id);

			return await base.GetObjectById(id, loadChild);
		}

		public async override Task<ActionResult<List<EventClassDTO>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type) && filters == null)
				return GlobalObjects.Dictionaries[_type].Cast<EventClassDTO>().ToList();

			return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		public async override Task<ActionResult<int>> Save(EventClassDTO entity)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
				GlobalObjects.Dictionaries[_type].Add(entity);

			return await base.Save(entity);
		}

		public async override Task<ActionResult> Delete(EventClassDTO entity)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var find = GlobalObjects.Dictionaries[_type].FirstOrDefault(i => i.ItemId == entity.ItemId);
				if (find != null)
					GlobalObjects.Dictionaries[_type].Remove(find);
			}

			return await base.Delete(entity);
		}

		public async override Task<ActionResult> BulkDelete(IEnumerable<EventClassDTO> entity, int? batchSize = null)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var ids = entity.Select(i => i.ItemId);
				var find = GlobalObjects.Dictionaries[_type].Where(i => ids.Contains(i.ItemId)).OfType<EventClassDTO>().ToList();
				foreach (var dto in find)
					GlobalObjects.Dictionaries[_type].Remove(dto);
			}

			return await base.BulkDelete(entity, batchSize);
		}


		#endregion
	}
}