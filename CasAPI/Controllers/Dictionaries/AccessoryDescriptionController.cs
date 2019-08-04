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
	[Route("accessorydescription")]
	public class AccessoryDescriptionController : BaseController<AccessoryDescriptionDTO>
	{
		private Type _type = typeof(AccessoryDescriptionDTO);


		public AccessoryDescriptionController(DataContext context, ILogger<BaseController<AccessoryDescriptionDTO>> logger) : base(context, logger)
		{
			
		}

		#region Overrides of BaseController<T>

		public async override Task<ActionResult<AccessoryDescriptionDTO>> GetObjectById(int id, bool loadChild = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
				return GlobalObjects.Dictionaries[_type].Cast<AccessoryDescriptionDTO>().FirstOrDefault(i => i.ItemId == id);

			return await base.GetObjectById(id, loadChild);
		}

		public async override Task<ActionResult<List<AccessoryDescriptionDTO>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type) && filters.IsNullOrEmpty())
				return GlobalObjects.Dictionaries[_type].Cast<AccessoryDescriptionDTO>().ToList();

			if (GlobalObjects.Dictionaries.ContainsKey(_type) && !filters.IsNullOrEmpty())
			{
				var filter = filters.FirstOrDefault(i => i.FilterProperty == "ModelingObjectTypeId");
				if (filter != null)
					return GlobalObjects.Dictionaries[_type].Cast<AccessoryDescriptionDTO>().Where(i => i.ModelingObjectTypeId == Convert.ToInt64(filter.Value)).ToList();
			}

				return await base.GetObjectList(filters, loadChild, getDeleted);
		}

		public async override Task<ActionResult<int>> Save(AccessoryDescriptionDTO entity)
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

		public async override Task<ActionResult> Delete(AccessoryDescriptionDTO entity)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var find = GlobalObjects.Dictionaries[_type].FirstOrDefault(i => i.ItemId == entity.ItemId);
				if (find != null)
					GlobalObjects.Dictionaries[_type].Remove(find);
			}

			return await base.Delete(entity);
		}

		public async override Task<ActionResult> BulkDelete(IEnumerable<AccessoryDescriptionDTO> entity, int? batchSize = null)
		{
			if (GlobalObjects.Dictionaries.ContainsKey(_type))
			{
				var ids = entity.Select(i => i.ItemId);
				var find = GlobalObjects.Dictionaries[_type].Where(i => ids.Contains(i.ItemId)).OfType<AccessoryDescriptionDTO>().ToList();
				foreach (var dto in find)
					GlobalObjects.Dictionaries[_type].Remove(dto);
			}

			return await base.BulkDelete(entity, batchSize);
		}


		#endregion

	}
}