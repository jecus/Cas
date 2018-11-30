using System.Runtime.Serialization;

namespace EFCore.Contract
{
	[DataContract]
	public class Connection
	{
		[DataMember]
		public string ServerName { get; set; }

		[DataMember]
		public string DatabaseName { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string Password { get; set; }
	}
}