using System.Collections.Generic;
using Newtonsoft.Json;

namespace CASTerms
{
	[JsonObject]
	public class JsonSettings
	{
		[JsonProperty("ConnectionStrings")]
		public Dictionary<string, ConnectionStrings> ConnectionStrings { get; set; }

		[JsonProperty("Last")]
		public LastInformation LastInformation { get; set; }
	}

    [JsonObject]
    public class ConnectionStrings
    {
        [JsonProperty("Connection")]
        public string Connection { get; set; }
        [JsonProperty("Audit")]
        public string Audit { get; set; }
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