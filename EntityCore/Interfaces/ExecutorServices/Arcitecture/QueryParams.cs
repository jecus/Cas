using System.Collections.Generic;
using System.Data.SqlClient;

namespace EntityCore.Interfaces.ExecutorServices.Arcitecture
{
	public class QueryParams
	{
		public string Query { get; set; }
		public string SqlParams { get; set; }
	}
}