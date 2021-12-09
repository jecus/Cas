using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;

namespace Entity.Models.DTO.General
{
	[Table("EngineConditions", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class EngineConditionDTO : BaseEntity
	{
		
		[Column("FlightID")]
		public int FlightID { get; set; }

		
		[Column("EngineID")]
		public int EngineID { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("TimeGMT")]
		public int? TimeGMT { get; set; }

		
		[Column("FlightRegime")]
		public int? FlightRegime { get; set; }

		
		[Column("TimeInRegime")]
		public short? TimeInRegime { get; set; }

		
		[Column("Weather")]
		public short? Weather { get; set; }

		
		[Column("PressAlt")]
		public int? PressAlt { get; set; }

		
		[Column("IAS")]
		public double? IAS { get; set; }

		
		[Column("TAT")]
		public double? TAT { get; set; }

		
		[Column("OAT")]
		public double? OAT { get; set; }

		
		[Column("Mach")]
		public double? Mach { get; set; }

		
		[Column("GrossWeight")]
		public double? GrossWeight { get; set; }

		
		[Column("ERP")]
		public double? ERP { get; set; }

		
		[Column("N1")]
		public double? N1 { get; set; }

		
		[Column("EGT")]
		public double? EGT { get; set; }

		
		[Column("N2")]
		public double? N2 { get; set; }

		
		[Column("OilTemperature")]
		public double? OilTemperature { get; set; }

		
		[Column("OilPressure")]
		public double? OilPressure { get; set; }

		
		[Column("FuelFlow")]
		public double? FuelFlow { get; set; }

		
		[Column("FuelBurn")]
		public double? FuelBurn { get; set; }

		
		[Column("ThrottleLeverAngle")]
		public int? ThrottleLeverAngle { get; set; }

		
		[Column("FuelPress")]
		public double? FuelPress { get; set; }

		
		[Column("OilPressTorque")]
		public double? OilPressTorque { get; set; }

		
		[Column("VibroOverload")]
		public double? VibroOverload { get; set; }

		
		[Column("VibroOverload2")]
		public double? VibroOverload2 { get; set; }

		
		[Column("GroundAir")]
		public short? GroundAir { get; set; }

		
		[Column("OilFlow")]
		public double? OilFlow { get; set; }
	}
}