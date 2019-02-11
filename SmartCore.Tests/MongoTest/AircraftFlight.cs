using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SmartCore.Entities.General.Atlbs;

namespace SmartCore.Tests.MongoTest
{
	public class AircraftFlightMongo
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }

		public int ItemId { get; set; }
		public bool IsDeleted { get; set; }

		public int ATLBID { get; set; }

		public int? AircraftId { get; set; }

		public string FlightNo { get; set; }

		public string Remarks { get; set; }

		public DateTime? FlightDate { get; set; }

		public string StationFrom { get; set; }

		public string StationTo { get; set; }

		public short? DelayTime { get; set; }

		public int? DelayReasonId { get; set; }

		public int? OutTime { get; set; }

		public int? InTime { get; set; }
		public int? TakeOffTime { get; set; }

		public int? LDGTime { get; set; }

		public int? NightTime { get; set; }

		public int? CRSID { get; set; }

		public int? FileID { get; set; }

		public string Tanks { get; set; }

		public string Fluids { get; set; }
		public string EnginesGeneralCondition { get; set; }
		public int? Highlight { get; set; }
		public bool Correct { get; set; }
		public string Reference { get; set; }
		public int Cycles { get; set; }
		public string PageNo { get; set; }
		public short? FlightType { get; set; }
		public int? LevelId { get; set; }
		public int? Distance { get; set; }
		public int? DistanceMeasure { get; set; }
		public double? TakeOffWeight { get; set; }
		public double? AlignmentBefore { get; set; }
		public double? AlignmentAfter { get; set; }
		public short? FlightCategory { get; set; }
		public short AtlbRecordType { get; set; }
		public short? FlightAircraftCode { get; set; }
		public int? CancelReasonId { get; set; }
		public int StationFromId { get; set; }
		public int StationToId { get; set; }
		public int FlightNumberId { get; set; }

		public AircraftFlightMongo()
		{
			
		}
		public AircraftFlightMongo(AircraftFlight arcf)
		{
			ItemId = arcf.ItemId;
			IsDeleted = arcf.IsDeleted;
			ATLBID = arcf.ATLBId;
			AircraftId = arcf.AircraftId;
			FlightNo = arcf.FlightNo;
			Remarks = arcf.Remarks;
			FlightDate = arcf.FlightDate;
			StationFrom = arcf.StationFrom;
			StationTo = arcf.StationTo;

			DelayTime = arcf.DelayTime;

			DelayReasonId = arcf.DelayReason?.ItemId;
			OutTime = arcf.OutTime;
			InTime = arcf.InTime;
			TakeOffTime = arcf.TakeOffTime;
			LDGTime = arcf.LDGTime;
			NightTime = arcf.NightTime;

			CRSID = arcf.CrsId;
			Tanks = arcf.Tanks;
			Fluids = arcf.Fluids;
			EnginesGeneralCondition = arcf.EnginesGeneralCondition;
			Highlight = arcf.Highlight?.ItemId;
			Correct = arcf.Correct;
			Reference = arcf.Reference;

			Cycles = arcf.Cycles;
			PageNo = arcf.PageNo;

			FlightType = (short?) arcf.FlightType?.ItemId;
			LevelId = arcf.Level?.ItemId;
			Distance = arcf.Distance;

			DistanceMeasure = arcf.DistanceMeasure?.ItemId;
			TakeOffWeight = arcf.TakeOffWeight;

			AlignmentBefore = arcf.AlignmentBefore;
			AlignmentAfter = arcf.AlignmentAfter;
			FlightCategory = (short?) arcf.FlightCategory;
			AtlbRecordType = (short) arcf.AtlbRecordType;
			FlightAircraftCode = (short?) arcf.FlightAircraftCode;
			CancelReasonId = arcf.CancelReason?.ItemId;
			StationFromId = arcf.StationFromId?.ItemId ?? -1;
			StationToId = arcf.StationToId?.ItemId ?? -1;
			FlightNumberId = arcf.FlightNumber?.ItemId ?? -1;
		}
	}
}