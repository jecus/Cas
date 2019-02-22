using System.Collections.Generic;
using Newtonsoft.Json;

namespace CASTerms
{
	[JsonObject]
	public class JsonSettings
	{
		[JsonProperty("ConnectionStrings")]
		public Dictionary<string, string> ConnectionStrings { get; set; }

		[JsonProperty("Last")]
		public LastInformation LastInformation { get; set; }
	}

	[JsonObject]
	public class LastInformation
	{
		[JsonProperty("Login")]
		public string Login { get; set; }

		[JsonProperty("Server")]
		public string Server { get; set; }
	}
}