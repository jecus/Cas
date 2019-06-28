using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCore.DTO;
using EntityCore.Filter;
using EntityCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers
{
	[ApiController]
	public class BaseController<T> : ControllerBase where  T : BaseEntity
	{
		private readonly ILogger<BaseController<T>> _logger;
		private readonly Repository<T> _repository;

		public BaseController(DataContext context, ILogger<BaseController<T>> logger)
		{
			_logger = logger;
			_repository = new Repository<T>(context);
		}

		[HttpPost("GetSelectColumnOnly")]
		public virtual async Task<ActionResult<List<int>>> GetSelectColumnOnly(IEnumerable<Filter> filters, string selectProperty)
		{
			var res = await _repository.GetSelectColumnOnlyAsync(filters, selectProperty);
			return Ok(res);
		}

		[HttpPost("GetObjectById")]
		public async Task<ActionResult<T>> GetObjectById(int id, bool loadChild = false)
		{
			var res = await _repository.GetObjectByIdAsync(id, loadChild);
			return Ok(res);
		}

		[HttpPost("GetObject")]
		public virtual async Task<ActionResult<T>> GetObject(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
		{
			var res = await _repository.GetObjectAsync(filters, loadChild, getDeleted, getAll);
			return Ok(res);
		}

		[HttpPost("GetObjectList")]
		public virtual async Task<ActionResult<List<T>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var res = await _repository.GetObjectListAsync(filters, loadChild, getDeleted);
			return Ok(res);
		}

		[HttpPost("GetObjectListAll")]
		public virtual async Task<ActionResult<List<T>>> GetObjectListAll(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var res = await _repository.GetObjectListAllAsync(filters, loadChild, getDeleted);
			return Ok(res);
		}

		[HttpPost("Delete")]
		public virtual async Task<ActionResult> Delete(T entity)
		{
			await _repository.DeleteAsync(entity);
			return Ok();
		}

		[HttpPost("Save")]
		public virtual async Task<ActionResult<int>> Save(T entity)
		{
			var res = await _repository.SaveAsync(entity);
			return Ok(res);
		}

		[HttpPost("BulkInsert")]
		public virtual async Task<ActionResult> BulkInsert(IEnumerable<T> entity, int? batchSize = null)
		{
			await _repository.BulkInsertASync(entity, batchSize);
			return Ok();
		}

		[HttpPost("BulkUpdate")]
		public virtual async Task<ActionResult> BulkUpdate(IEnumerable<T> entity, int? batchSize = null)
		{
			await _repository.BulkUpdateAsync(entity, batchSize);
			return Ok();
		}

		[HttpPost("BulkDelete")]
		public virtual async Task<ActionResult> BulkDelete(IEnumerable<T> entity, int? batchSize = null)
		{
			await  _repository.BulkDeleteAsync(entity, batchSize);
			return Ok();
		}
	}
}