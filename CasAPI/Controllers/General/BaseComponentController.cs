using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasAPI.Infrastructure;
using EntityCore.DTO;
using EntityCore.DTO.General;
using EntityCore.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("basecomponent")]
	public class BaseComponentController : BaseController<BaseComponentDTO>
	{
		public BaseComponentController(DataContext context, ILogger<BaseController<BaseComponentDTO>> logger) : base(
			context, logger)
		{
		}



		#region Overrides of BaseController<T>

		public async override Task<ActionResult<BaseComponentDTO>> GetObjectById(int id, bool loadChild = false)
		{
			if (GlobalObjects.BaseComponents.Any(i => i.ItemId == id))
				return GlobalObjects.BaseComponents.FirstOrDefault(i => i.ItemId == id);

			return await base.GetObjectById(id, loadChild);
		}

		public async override Task<ActionResult<List<BaseComponentDTO>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (filters.IsNullOrEmpty())
				return GlobalObjects.BaseComponents.ToList();

			return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		#region Overrides of BaseController<BaseComponentDTO>

		public async override Task<ActionResult<List<BaseComponentDTO>>> GetObjectListAll(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (filters.IsNullOrEmpty())
				return GlobalObjects.BaseComponents.ToList();

			return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		#endregion

		public async override Task<ActionResult<int>> Save(BaseComponentDTO entity)
		{
			try
			{
				var res = await _repository.SaveAsync(entity);

				var find = GlobalObjects.BaseComponents.FirstOrDefault(i => i.ItemId == entity.ItemId);
				if (find == null)
					GlobalObjects.BaseComponents.Add(entity);
				else
				{
					GlobalObjects.BaseComponents.Remove(find);
					GlobalObjects.BaseComponents.Add(entity);
				}


				return Ok(res);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		public async override Task<ActionResult> Delete(BaseComponentDTO entity)
		{
			var find = GlobalObjects.BaseComponents.FirstOrDefault(i => i.ItemId == entity.ItemId);
			if (find != null)
				GlobalObjects.BaseComponents.Remove(find);


			return await base.Delete(entity);
		}

		public async override Task<ActionResult> BulkDelete(IEnumerable<BaseComponentDTO> entity, int? batchSize = null)
		{

			var ids = entity.Select(i => i.ItemId);
			var find = GlobalObjects.BaseComponents.Where(i => ids.Contains(i.ItemId)).ToList();
			foreach (var dto in find)
				GlobalObjects.BaseComponents.Remove(dto);


			return await base.BulkDelete(entity, batchSize);
		}


		#endregion
	}
}