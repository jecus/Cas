﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Abstractions;
using Entity.Core;
using Entity.Core.Repository;
using Entity.Models.DTO;
using Entity.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers
{
	[ApiController]
	public class BaseController<T> : ControllerBase where  T : BaseEntity
	{
		protected readonly ILogger<BaseController<T>> _logger;
		protected readonly Repository<T> _repository;

		public BaseController(DataContext context, ILogger<BaseController<T>> logger)
		{
			_logger = logger;
			_repository = new Repository<T>(context);
		}

		[HttpPost("getcolumn")]
		public virtual async Task<ActionResult<List<int>>> GetSelectColumnOnly(IEnumerable<Filter> filters, string selectProperty)
		{
            var res = await _repository.GetSelectColumnOnlyAsync(filters, selectProperty);
            return Ok(res);
		}

		[HttpGet("getbyid")]
		public virtual async Task<ActionResult<T>> GetObjectById(int id, bool loadChild = false)
		{
            var res = await _repository.GetObjectByIdAsync(id, loadChild);
            return Ok(res);
		}

		[HttpPost("get")]
		public virtual async Task<ActionResult<T>> GetObject(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
		{
            var res = await _repository.GetObjectAsync(filters, loadChild, getDeleted, getAll);
            return Ok(res);
		}

		[HttpPost("getlist")]
		public virtual async Task<ActionResult<List<T>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
            var res = await _repository.GetObjectListAsync(filters, loadChild, getDeleted);
            return Ok(res);
		}

		[HttpPost("getlistall")]
		public virtual async Task<ActionResult<List<T>>> GetObjectListAll(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
            var res = await _repository.GetObjectListAllAsync(filters, loadChild, getDeleted);
            return Ok(res);
		}

		[HttpPost("delete")]
		public virtual async Task<ActionResult> Delete(T entity)
		{
            await _repository.DeleteAsync(entity);
            return Ok();
		}

		[HttpPost("save")]
		public virtual async Task<ActionResult<int>> Save(T entity)
		{
            var res = await _repository.SaveAsync(entity);
            return Ok(res);
		}

		[HttpPost("bulkinsert")]
		public virtual async Task<ActionResult<Dictionary<string, int>>> BulkInsert(IEnumerable<T> entity, int? batchSize = null)
		{
			try
			{
				await _repository.BulkInsertASync(entity, batchSize);
				return Ok(entity.ToDictionary(i => i.Guid, i => i.ItemId));
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				foreach (var baseEntity in entity)
					await _repository.SaveAsync(baseEntity);

				return Ok(entity.ToDictionary(i => i.Guid, i => i.ItemId));
			}
		}

		[HttpPost("bulkupdate")]
		public virtual async Task<ActionResult> BulkUpdate(IEnumerable<T> entity, int? batchSize = null)
		{
			try
			{
				await _repository.BulkUpdateAsync(entity, batchSize);
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				foreach (var baseEntity in entity)
					await _repository.SaveAsync(baseEntity);

				return Ok();
			}
		}

		[HttpPost("bulkdelete")]
		public virtual async Task<ActionResult> BulkDelete(IEnumerable<T> entity, int? batchSize = null)
		{
			try
			{
				await  _repository.BulkDeleteAsync(entity, batchSize);
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				foreach (var baseEntity in entity)
					await _repository.DeleteAsync(baseEntity);

				return Ok();
			}
		}
	}
}