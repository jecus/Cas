using System.Collections.Generic;
using Newtonsoft.Json;

namespace CASTerms
{
	[JsonObject]
	public class JsonSettings
	{
		[JsonProperty("ConnectionStrings")]
		public Dictionary<string, string> ConnectionStrings { get; set; }
	}
}