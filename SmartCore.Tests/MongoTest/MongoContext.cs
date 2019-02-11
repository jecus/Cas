using MongoDB.Driver;

namespace SmartCore.Tests.MongoTest
{
	public class MongoContext : MongoClient
	{
		public IMongoCollection<AircraftFlightMongo> Flights { get; set; }

		public MongoContext(string con) : base(con)
		{
			var url = MongoUrl.Create(con);
			var database = GetDatabase(url.DatabaseName);

			Flights = database.GetCollection<AircraftFlightMongo>(nameof(AircraftFlightMongo));
		}
	}
}