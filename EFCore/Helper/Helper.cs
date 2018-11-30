using System.Collections.Specialized;
using System.Configuration;

namespace EFCore.Helper
{
	public static class Helper
	{
		public static string GetConnectionString()
		{
			var section = ConfigurationManager.GetSection("connectionSettings") as NameValueCollection;

			var password = section["Password"];
			var serverName = section["ServerName"];
			var userName = section["UserName"];
			var databaseName = section["DatabaseName"];

			return $"data source={serverName};initial catalog={databaseName};user id={userName};password={password};MultipleActiveResultSets=True;App=EntityFramework";
		}
	}
}