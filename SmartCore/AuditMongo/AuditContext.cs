using MongoDB.Driver;

namespace SmartCore.AuditMongo
{
	public class AuditContext : MongoClient
	{
		public IMongoCollection<AuditEntity> AuditCollection { get; }

		public AuditContext(string connectionString) : base(connectionString)
		{
			AuditCollection = GetDatabase("Audit").GetCollection<AuditEntity>("Audit");
		}
	}
}