using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartCore.AuditMongo
{
	public class AuditEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Action { get; set; }

		public int UserId { get; set; }

		[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
		public DateTime Date { get; set; }

		public int ObjectTypeId { get; set; }

		public int ObjectId { get; set; }
		public int? OperatorId { get; set; }

		public Dictionary<string, object> AdditionalParameters { get; set; }
	}
}