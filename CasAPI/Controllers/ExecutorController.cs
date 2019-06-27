using System;
using System.Collections.Generic;
using System.Data;
using EntityCore.Interfaces;
using EntityCore.Interfaces.ExecutorServices;
using EntityCore.Interfaces.ExecutorServices.Arcitecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers
{
	[ApiController]
	[Route("executor")]
	public class ExecutorController : ControllerBase
	{
		private readonly IExecutor _executor;
		private readonly ILogger<ExecutorController> _logger;

		public ExecutorController(IConfiguration configuration, ILogger<ExecutorController> logger)
		{
			_executor = new Executor(configuration);
			_logger = logger;
		}

		[HttpPost("query")]
		public ActionResult<DataSet> Execute(string sql)
		{
			try
			{
				return Ok(_executor.Execute(sql));
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpPost("queries")]
		public ActionResult<DataSet> Execute(IEnumerable<DbQuery> dbQueries)
		{
			try
			{
				var res = _executor.Execute(dbQueries, out var results);
				if (results.Count > 0)
					return BadRequest();
				return Ok(res);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
			
		}

		[HttpPost("queryparams")]
		public ActionResult<DataSet> Execute(string query, List<SerializedSqlParam> parameters)
		{
			try
			{
				return Ok(_executor.Execute(query, parameters));
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}
	}
}