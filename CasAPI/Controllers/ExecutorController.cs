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
	public class ExecutorController : ControllerBase
	{
		private readonly IExecutor _executor;
		private readonly ILogger<ExecutorController> _logger;

		public ExecutorController(IConfiguration configuration, ILogger<ExecutorController> logger)
		{
			_executor = new Executor(configuration);
			_logger = logger;
		}

		[HttpPost("execute")]
		public ActionResult<DataSet> Execute(string sql)
		{
			return _executor.Execute(sql);
		}

		[HttpPost("executeQueries")]
		public ActionResult<DataSet> Execute(IEnumerable<DbQuery> dbQueries)
		{
			return _executor.Execute(dbQueries, out var results);
		}

		[HttpPost("executeWithParams")]
		public ActionResult<DataSet> Execute(string query, List<SerializedSqlParam> parameters)
		{
			return _executor.Execute(query, parameters);
		}
	}
}