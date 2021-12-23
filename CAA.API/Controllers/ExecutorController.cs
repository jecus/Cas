using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using CAA.Entity.Core.ExecutorServices;
using CAA.Entity.Core.ExecutorServices.Arcitecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace CAA.API.Controllers
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
            var s = new XmlSerializer(typeof(DataSet));
            string xml;

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    s.Serialize(writer, NormalizeDate(_executor.Execute(p.Query)));
                    xml = sww.ToString();
                }
            }
            return Ok(xml);
		}

		[HttpPost("queryparams")]
		public ActionResult<string> ExecuteWithParams(QueryParams p)
		{
            var param = new List<SerializedSqlParam>();
            var serializer = new XmlSerializer(typeof(List<SerializedSqlParam>));
            using (TextReader reader = new StringReader(p.SqlParams))
                param.AddRange((IEnumerable<SerializedSqlParam>)serializer.Deserialize(reader));

            var s = new XmlSerializer(typeof(DataSet));
            string xml;

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    s.Serialize(writer, NormalizeDate(_executor.Execute(p.Query, param.Select(i => i.GetSqlParameter(i)).ToArray())));
                    xml = sww.ToString();
                }
            }
            return Ok(xml);
		}


		private DataSet NormalizeDate(DataSet data)
		{
			foreach (DataTable table in data.Tables)
			{
				foreach (DataColumn item in table.Columns)
				{
					// Switching from UnspecifiedLocal to Unspecified is allowed even after the DataSet has rows.
					if (item.DataType == typeof(DateTime) && item.DateTimeMode == DataSetDateTime.UnspecifiedLocal)
						item.DateTimeMode = DataSetDateTime.Unspecified;
				}
			}

			return data;
		}
	}

}