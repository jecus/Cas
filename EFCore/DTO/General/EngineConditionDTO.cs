using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class EngineConditionDTO : BaseEntity
	{
		[DataMember]
		public int FlightID { get; set; }

		[DataMember]
		public int EngineID { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? TimeGMT { get; set; }

		[DataMember]
		public int? FlightRegime { get; set; }

		[DataMember]
		public short? TimeInRegime { get; set; }

		[DataMember]
		public short? Weather { get; set; }

		[DataMember]
		public int? PressAlt { get; set; }

		[DataMember]
		public double? IAS { get; set; }

		[DataMember]
		public double? TAT { get; set; }

		[DataMember]
		public double? OAT { get; set; }

		[DataMember]
		public double? Mach { get; set; }

		[DataMember]
		public double? GrossWeight { get; set; }

		[DataMember]
		public double? ERP { get; set; }

		[DataMember]
		public double? N1 { get; set; }

		[DataMember]
		public double? EGT { get; set; }

		[DataMember]
		public double? N2 { get; set; }

		[DataMember]
		public double? OilTemperature { get; set; }

		[DataMember]
		public double? OilPressure { get; set; }

		[DataMember]
		public double? FuelFlow { get; set; }

		[DataMember]
		public double? FuelBurn { get; set; }

		[DataMember]
		public int? ThrottleLeverAngle { get; set; }

		[DataMember]
		public double? FuelPress { get; set; }

		[DataMember]
		public double? OilPressTorque { get; set; }

		[DataMember]
		public double? VibroOverload { get; set; }

		[DataMember]
		public double? VibroOverload2 { get; set; }

		[DataMember]
		public short? GroundAir { get; set; }

		[DataMember]
		public double? OilFlow { get; set; }
	}
}