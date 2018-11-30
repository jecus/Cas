using System.Collections.Specialized;
using System.Configuration;

namespace EFCore.Contract
{
	public class ConnectionService : IConnectionService
	{
		public Connection GetConnection()
		{
			var section = ConfigurationManager.GetSection("connectionSettings") as NameValueCollection;
			return new Connection
			{
				Password = section["Password"],
				ServerName = section["ServerName"],
				UserName = section["UserName"],
				DatabaseName = section["DatabaseName"]
			};
		}
	}
}