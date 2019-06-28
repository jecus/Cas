using System.Collections.Generic;
using System.Data.SqlClient;

namespace EntityCore.Interfaces.ExecutorServices.Arcitecture
{
	public class QueryParams
	{
		public string Query { get; set; }
		public  SqlParameter[]  SqlParams { get; set; }
	}
}