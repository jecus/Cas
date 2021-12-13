using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("ComponentWorkInRegimeParams", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ComponentWorkInRegimeParamDTO : BaseEntity
	{
		
		[Column("FlightRegime")]
		public int? FlightRegime { get; set; }

		
		[Column("TimeInRegimeMax")]
		public int? TimeInRegimeMax { get; set; }

		
		[Column("EPRMin")]
		public double? EPRMin { get; set; }

		
		[Column("EPRMax")]
		public double? EPRMax { get; set; }

		
		[Column("N1Min")]
		public double? N1Min { get; set; }

		
		[Column("N1Max")]
		public double? N1Max { get; set; }

		
		[Column("EGTMin")]
		public double? EGTMin { get; set; }

		
		[Column("EGTMax")]
		public double? EGTMax { get; set; }

		
		[Column("EGTMeasure")]
		public int? EGTMeasure { get; set; }

		
		[Column("N2Min")]
		public double? N2Min { get; set; }

		
		[Column("N2Max")]
		public double? N2Max { get; set; }

		
		[Column("OilTemperatureMin")]
		public double? OilTemperatureMin { get; set; }

		
		[Column("OilTemperatureMax")]
		public double? OilTemperatureMax { get; set; }

		
		[Column("OilTemperatureMeasure")]
		public int? OilTemperatureMeasure { get; set; }

		
		[Column("OilPressureMin")]
		public double? OilPressureMin { get; set; }

		
		[Column("OilPressureMax")]
		public double? OilPressureMax { get; set; }

		
		[Column("OilPressureMeasure")]
		public int? OilPressureMeasure { get; set; }

		
		[Column("FuelPressMin")]
		public double? FuelPressMin { get; set; }

		
		[Column("FuelPressMax")]
		public double? FuelPressMax { get; set; }

		
		[Column("FuelPresseMeasure")]
		public int? FuelPresseMeasure { get; set; }

		
		[Column("OilPressTorqueMin")]
		public double? OilPressTorqueMin { get; set; }

		
		[Column("OilPressTorqueMax")]
		public double? OilPressTorqueMax { get; set; }

		
		[Column("OilPressTorqueMeasure")]
		public int? OilPressTorqueMeasure { get; set; }

		
		[Column("FuelFlowMin")]
		public double? FuelFlowMin { get; set; }

		
		[Column("FuelFlowMax")]
		public double? FuelFlowMax { get; set; }

		
		[Column("FuelFlowMeasure")]
		public int? FuelFlowMeasure { get; set; }

		
		[Column("FuelBurnMin")]
		public double? FuelBurnMin { get; set; }

		
		[Column("FuelBurnMax")]
		public double? FuelBurnMax { get; set; }

		
		[Column("FuelBurnMeasure")]
		public int? FuelBurnMeasure { get; set; }

		
		[Column("VibroOverloadMin")]
		public double? VibroOverloadMin { get; set; }

		
		[Column("VibroOverloadMax")]
		public double? VibroOverloadMax { get; set; }

		
		[Column("VibroOverload2Min")]
		public double? VibroOverload2Min { get; set; }

		
		[Column("VibroOverload2Max")]
		public double? VibroOverload2Max { get; set; }

		
		[Column("GroundAir")]
		public short? GroundAir { get; set; }

		
		[Column("PersentTime")]
		public double? PersentTime { get; set; }

		
		[Column("ResorceProvider")]
		public int? ResorceProvider { get; set; }

		
		[Column("ResorceProviderId")]
		public int? ResorceProviderId { get; set; }

		
		[Column("TLAMin")]
		public double? TLAMin { get; set; }

		
		[Column("TLAMax")]
		public double? TLAMax { get; set; }

		
		[Column("TLAMinEnabled")]
		public bool? TLAMinEnabled { get; set; }

		
		[Column("TLAMaxEnabled")]
		public bool? TLAMaxEnabled { get; set; }

		
		[Column("EPRMinEnabled")]
		public bool? EPRMinEnabled { get; set; }

		
		[Column("EPRMaxEnabled")]
		public bool? EPRMaxEnabled { get; set; }

		
		[Column("N1MinEnabled")]
		public bool? N1MinEnabled { get; set; }

		
		[Column("N1MaxEnabled")]
		public bool? N1MaxEnabled { get; set; }

		
		[Column("EGTMinEnabled")]
		public bool? EGTMinEnabled { get; set; }

		
		[Column("EGTMaxEnabled")]
		public bool? EGTMaxEnabled { get; set; }

		
		[Column("N2MinEnabled")]
		public bool? N2MinEnabled { get; set; }

		
		[Column("N2MaxEnabled")]
		public bool? N2MaxEnabled { get; set; }

		
		[Column("OilTemperatureMinEnabled")]
		public bool? OilTemperatureMinEnabled { get; set; }

		
		[Column("OilTemperatureMaxEnabled")]
		public bool? OilTemperatureMaxEnabled { get; set; }

		
		[Column("OilPressureMinEnabled")]
		public bool? OilPressureMinEnabled { get; set; }

		
		[Column("OilPressureMaxEnabled")]
		public bool? OilPressureMaxEnabled { get; set; }

		
		[Column("OilFlowMin")]
		public double? OilFlowMin { get; set; }

		
		[Column("OilFlowMax")]
		public double? OilFlowMax { get; set; }

		
		[Column("OilFlowMinEnabled")]
		public bool? OilFlowMinEnabled { get; set; }

		
		[Column("OilFlowMaxEnabled")]
		public bool? OilFlowMaxEnabled { get; set; }

		
		[Column("OilFlowMeasure")]
		public int? OilFlowMeasure { get; set; }

		
		[Column("FuelPressMinEnabled")]
		public bool? FuelPressMinEnabled { get; set; }

		
		[Column("FuelPressMaxEnabled")]
		public bool? FuelPressMaxEnabled { get; set; }

		
		[Column("OilPressTorqueMinEnabled")]
		public bool? OilPressTorqueMinEnabled { get; set; }

		
		[Column("OilPressTorqueMaxEnabled")]
		public bool? OilPressTorqueMaxEnabled { get; set; }

		
		[Column("FuelFlowMinEnabled")]
		public bool? FuelFlowMinEnabled { get; set; }

		
		[Column("FuelFlowMaxEnabled")]
		public bool? FuelFlowMaxEnabled { get; set; }

		
		[Column("FuelBurnMinEnabled")]
		public bool? FuelBurnMinEnabled { get; set; }

		
		[Column("FuelBurnMaxEnabled")]
		public bool? FuelBurnMaxEnabled { get; set; }

		
		[Column("VibroOverloadMinEnabled")]
		public bool? VibroOverloadMinEnabled { get; set; }

		
		[Column("VibroOverloadMaxEnabled")]
		public bool? VibroOverloadMaxEnabled { get; set; }

		
		[Column("VibroOverload2MinEnabled")]
		public bool? VibroOverload2MinEnabled { get; set; }

		
		[Column("VibroOverload2MaxEnabled")]
		public bool? VibroOverload2MaxEnabled { get; set; }

		
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		
		[Column("TLARecomended")]
		public double? TLARecomended { get; set; }

		
		[Column("TLARecomendedEnabled")]
		public bool? TLARecomendedEnabled { get; set; }

		
		[Column("EPRRecomended")]
		public double? EPRRecomended { get; set; }

		
		[Column("EPRRecomendedEnabled")]
		public bool? EPRRecomendedEnabled { get; set; }

		
		[Column("N1Recomended")]
		public double? N1Recomended { get; set; }

		
		[Column("N1RecomendedEnabled")]
		public bool? N1RecomendedEnabled { get; set; }

		
		[Column("EGTRecomended")]
		public double? EGTRecomended { get; set; }

		
		[Column("EGTRecomendedEnabled")]
		public bool? EGTRecomendedEnabled { get; set; }

		
		[Column("N2Recomended")]
		public double? N2Recomended { get; set; }

		
		[Column("N2RecomendedEnabled")]
		public bool? N2RecomendedEnabled { get; set; }

		
		[Column("OilTemperatureRecomended")]
		public double? OilTemperatureRecomended { get; set; }

		
		[Column("OilTemperatureRecomendedEnabled")]
		public bool? OilTemperatureRecomendedEnabled { get; set; }

		
		[Column("OilPressureRecomended")]
		public double? OilPressureRecomended { get; set; }

		
		[Column("OilPressureRecomendedEnabled")]
		public bool? OilPressureRecomendedEnabled { get; set; }

		
		[Column("OilFlowRecomended")]
		public double? OilFlowRecomended { get; set; }

		
		[Column("OilFlowRecomendedEnabled")]
		public bool? OilFlowRecomendedEnabled { get; set; }

		
		[Column("FuelPressRecomended")]
		public double? FuelPressRecomended { get; set; }

		
		[Column("FuelPressRecomendedEnabled")]
		public bool? FuelPressRecomendedEnabled { get; set; }

		
		[Column("OilPressTorqueRecomended")]
		public double? OilPressTorqueRecomended { get; set; }

		
		[Column("OilPressTorqueRecomendedEnabled")]
		public bool? OilPressTorqueRecomendedEnabled { get; set; }

		
		[Column("FuelFlowRecomended")]
		public double? FuelFlowRecomended { get; set; }

		
		[Column("FuelFlowRecomendedEnabled")]
		public bool? FuelFlowRecomendedEnabled { get; set; }

		
		[Column("FuelBurnRecomended")]
		public double? FuelBurnRecomended { get; set; }

		
		[Column("FuelBurnRecomendedEnabled")]
		public bool? FuelBurnRecomendedEnabled { get; set; }

		
		[Column("VibroOverloadRecomended")]
		public double? VibroOverloadRecomended { get; set; }

		
		[Column("VibroOverloadRecomendedEnabled")]
		public bool? VibroOverloadRecomendedEnabled { get; set; }

		
		[Column("VibroOverload2Recomended")]
		public double? VibroOverload2Recomended { get; set; }

		
		[Column("VibroOverload2RecomendedEnabled")]
		public bool? VibroOverload2RecomendedEnabled { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }
	}
}