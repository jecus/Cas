using System.Collections.Generic;
using System.Linq;
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
		public virtual ActionResult<List<int>> GetSelectColumnOnly(IEnumerable<EntityCore.Filter.Filter> filters, string selectProperty)
		{
			var res = _repository.GetSelectColumnOnly(filters, selectProperty);
			return Ok(res);
		}

		[HttpPost("GetObjectById")]
		public virtual ActionResult<T> GetObjectById(int id, bool loadChild = false)
		{
			var res = _repository.GetObjectById(id, loadChild);
			return Ok(res);
		}

		[HttpPost("GetObject")]
		public virtual ActionResult<T> GetObject(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
		{
			var res = _repository.GetObject(filters, loadChild, getDeleted, getAll);
			return Ok(res);
		}

		[HttpPost("GetObjectList")]
		public virtual ActionResult<List<T>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var res = _repository.GetObjectList(filters, loadChild, getDeleted);
			return Ok(res);
		}

		[HttpPost("GetObjectListAll")]
		public virtual ActionResult<List<T>> GetObjectListAll(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var res = _repository.GetObjectListAll(filters, loadChild, getDeleted);
			return Ok(res);
		}

		[HttpPost("Delete")]
		public virtual ActionResult Delete(T entity)
		{
			_repository.Delete(entity);
			return Ok();
		}

		[HttpPost("Save")]
		public virtual ActionResult<int> Save(T entity)
		{
			var res = _repository.Save(entity);
			return Ok(res);
		}

		[HttpPost("BulkInsert")]
		public virtual ActionResult BulkInsert(IEnumerable<T> entity, int? batchSize = null)
		{
			_repository.BulkInsert(entity, batchSize);
			return Ok();
		}

		[HttpPost("BulkUpdate")]
		public virtual ActionResult BulkUpdate(IEnumerable<T> entity, int? batchSize = null)
		{
			_repository.BulkUpdate(entity, batchSize);
			return Ok();
		}

		[HttpPost("BulkDelete")]
		public virtual ActionResult BulkDelete(IEnumerable<T> entity, int? batchSize = null)
		{
			_repository.BulkDelete(entity, batchSize);
			return Ok();
		}
	}
}