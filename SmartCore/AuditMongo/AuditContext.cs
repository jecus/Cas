using MongoDB.Driver;

namespace SmartCore.AuditMongo
{
	public class AuditContext : MongoClient
	{
		public IMongoCollection<AuditEntity> AuditCollection { get; }

		public AuditContext(string connectionString) : base(connectionString)
		{
            var dbName = MongoUrl.Create(connectionString).DatabaseName;
			AuditCollection = GetDatabase(dbName).GetCollection<AuditEntity>("Audit");
		}
	}
}