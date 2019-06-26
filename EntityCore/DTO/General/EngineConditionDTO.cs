using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("EngineConditions", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class EngineConditionDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightID"), Required]
		public int FlightID { get; set; }

		[DataMember]
		[Column("EngineID"), Required]
		public int EngineID { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("TimeGMT")]
		public int? TimeGMT { get; set; }

		[DataMember]
		[Column("FlightRegime")]
		public int? FlightRegime { get; set; }

		[DataMember]
		[Column("TimeInRegime")]
		public short? TimeInRegime { get; set; }

		[DataMember]
		[Column("Weather")]
		public short? Weather { get; set; }

		[DataMember]
		[Column("PressAlt")]
		public int? PressAlt { get; set; }

		[DataMember]
		[Column("IAS")]
		public double? IAS { get; set; }

		[DataMember]
		[Column("TAT")]
		public double? TAT { get; set; }

		[DataMember]
		[Column("OAT")]
		public double? OAT { get; set; }

		[DataMember]
		[Column("Mach")]
		public double? Mach { get; set; }

		[DataMember]
		[Column("GrossWeight")]
		public double? GrossWeight { get; set; }

		[DataMember]
		[Column("ERP")]
		public double? ERP { get; set; }

		[DataMember]
		[Column("N1")]
		public double? N1 { get; set; }

		[DataMember]
		[Column("EGT")]
		public double? EGT { get; set; }

		[DataMember]
		[Column("N2")]
		public double? N2 { get; set; }

		[DataMember]
		[Column("OilTemperature")]
		public double? OilTemperature { get; set; }

		[DataMember]
		[Column("OilPressure")]
		public double? OilPressure { get; set; }

		[DataMember]
		[Column("FuelFlow")]
		public double? FuelFlow { get; set; }

		[DataMember]
		[Column("FuelBurn")]
		public double? FuelBurn { get; set; }

		[DataMember]
		[Column("ThrottleLeverAngle")]
		public int? ThrottleLeverAngle { get; set; }

		[DataMember]
		[Column("FuelPress")]
		public double? FuelPress { get; set; }

		[DataMember]
		[Column("OilPressTorque")]
		public double? OilPressTorque { get; set; }

		[DataMember]
		[Column("VibroOverload")]
		public double? VibroOverload { get; set; }

		[DataMember]
		[Column("VibroOverload2")]
		public double? VibroOverload2 { get; set; }

		[DataMember]
		[Column("GroundAir")]
		public short? GroundAir { get; set; }

		[DataMember]
		[Column("OilFlow")]
		public double? OilFlow { get; set; }
	}
}