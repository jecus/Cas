using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EntityCore.Interfaces;
using EntityCore.Interfaces.ExecutorServices;
using EntityCore.Interfaces.ExecutorServices.Arcitecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
		public ActionResult<string> Execute(QueryParams p)
		{
			try
			{
				var s = new XmlSerializer(typeof(DataSet));
				string xml;

				using (var sww = new StringWriter())
				{
					using (var writer = XmlWriter.Create(sww))
					{
						s.Serialize(writer, _executor.Execute(p.Query));
						xml = sww.ToString(); 
					}
				}
				return Ok(xml);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpPost("queryparams")]
		public ActionResult<string> ExecuteWithParams(QueryParams p)
		{
			try
			{
				var s = new XmlSerializer(typeof(DataSet));
				string xml;

				using (var sww = new StringWriter())
				{
					using (var writer = XmlWriter.Create(sww))
					{
						s.Serialize(writer, _executor.Execute(p.Query, p.SqlParams));
						xml = sww.ToString();
					}
				}
				return Ok(xml);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}
	}
}