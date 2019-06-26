using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("ComponentWorkInRegimeParams", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentWorkInRegimeParamDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightRegime")]
		public int? FlightRegime { get; set; }

		[DataMember]
		[Column("TimeInRegimeMax")]
		public int? TimeInRegimeMax { get; set; }

		[DataMember]
		[Column("EPRMin")]
		public double? EPRMin { get; set; }

		[DataMember]
		[Column("EPRMax")]
		public double? EPRMax { get; set; }

		[DataMember]
		[Column("N1Min")]
		public double? N1Min { get; set; }

		[DataMember]
		[Column("N1Max")]
		public double? N1Max { get; set; }

		[DataMember]
		[Column("EGTMin")]
		public double? EGTMin { get; set; }

		[DataMember]
		[Column("EGTMax")]
		public double? EGTMax { get; set; }

		[DataMember]
		[Column("EGTMeasure")]
		public int? EGTMeasure { get; set; }

		[DataMember]
		[Column("N2Min")]
		public double? N2Min { get; set; }

		[DataMember]
		[Column("N2Max")]
		public double? N2Max { get; set; }

		[DataMember]
		[Column("OilTemperatureMin")]
		public double? OilTemperatureMin { get; set; }

		[DataMember]
		[Column("OilTemperatureMax")]
		public double? OilTemperatureMax { get; set; }

		[DataMember]
		[Column("OilTemperatureMeasure")]
		public int? OilTemperatureMeasure { get; set; }

		[DataMember]
		[Column("OilPressureMin")]
		public double? OilPressureMin { get; set; }

		[DataMember]
		[Column("OilPressureMax")]
		public double? OilPressureMax { get; set; }

		[DataMember]
		[Column("OilPressureMeasure")]
		public int? OilPressureMeasure { get; set; }

		[DataMember]
		[Column("FuelPressMin")]
		public double? FuelPressMin { get; set; }

		[DataMember]
		[Column("FuelPressMax")]
		public double? FuelPressMax { get; set; }

		[DataMember]
		[Column("FuelPresseMeasure")]
		public int? FuelPresseMeasure { get; set; }

		[DataMember]
		[Column("OilPressTorqueMin")]
		public double? OilPressTorqueMin { get; set; }

		[DataMember]
		[Column("OilPressTorqueMax")]
		public double? OilPressTorqueMax { get; set; }

		[DataMember]
		[Column("OilPressTorqueMeasure")]
		public int? OilPressTorqueMeasure { get; set; }

		[DataMember]
		[Column("FuelFlowMin")]
		public double? FuelFlowMin { get; set; }

		[DataMember]
		[Column("FuelFlowMax")]
		public double? FuelFlowMax { get; set; }

		[DataMember]
		[Column("FuelFlowMeasure")]
		public int? FuelFlowMeasure { get; set; }

		[DataMember]
		[Column("FuelBurnMin")]
		public double? FuelBurnMin { get; set; }

		[DataMember]
		[Column("FuelBurnMax")]
		public double? FuelBurnMax { get; set; }

		[DataMember]
		[Column("FuelBurnMeasure")]
		public int? FuelBurnMeasure { get; set; }

		[DataMember]
		[Column("VibroOverloadMin")]
		public double? VibroOverloadMin { get; set; }

		[DataMember]
		[Column("VibroOverloadMax")]
		public double? VibroOverloadMax { get; set; }

		[DataMember]
		[Column("VibroOverload2Min")]
		public double? VibroOverload2Min { get; set; }

		[DataMember]
		[Column("VibroOverload2Max")]
		public double? VibroOverload2Max { get; set; }

		[DataMember]
		[Column("GroundAir")]
		public short? GroundAir { get; set; }

		[DataMember]
		[Column("PersentTime")]
		public double? PersentTime { get; set; }

		[DataMember]
		[Column("ResorceProvider")]
		public int? ResorceProvider { get; set; }

		[DataMember]
		[Column("ResorceProviderId")]
		public int? ResorceProviderId { get; set; }

		[DataMember]
		[Column("TLAMin")]
		public double? TLAMin { get; set; }

		[DataMember]
		[Column("TLAMax")]
		public double? TLAMax { get; set; }

		[DataMember]
		[Column("TLAMinEnabled")]
		public bool? TLAMinEnabled { get; set; }

		[DataMember]
		[Column("TLAMaxEnabled")]
		public bool? TLAMaxEnabled { get; set; }

		[DataMember]
		[Column("EPRMinEnabled")]
		public bool? EPRMinEnabled { get; set; }

		[DataMember]
		[Column("EPRMaxEnabled")]
		public bool? EPRMaxEnabled { get; set; }

		[DataMember]
		[Column("N1MinEnabled")]
		public bool? N1MinEnabled { get; set; }

		[DataMember]
		[Column("N1MaxEnabled")]
		public bool? N1MaxEnabled { get; set; }

		[DataMember]
		[Column("EGTMinEnabled")]
		public bool? EGTMinEnabled { get; set; }

		[DataMember]
		[Column("EGTMaxEnabled")]
		public bool? EGTMaxEnabled { get; set; }

		[DataMember]
		[Column("N2MinEnabled")]
		public bool? N2MinEnabled { get; set; }

		[DataMember]
		[Column("N2MaxEnabled")]
		public bool? N2MaxEnabled { get; set; }

		[DataMember]
		[Column("OilTemperatureMinEnabled")]
		public bool? OilTemperatureMinEnabled { get; set; }

		[DataMember]
		[Column("OilTemperatureMaxEnabled")]
		public bool? OilTemperatureMaxEnabled { get; set; }

		[DataMember]
		[Column("OilPressureMinEnabled")]
		public bool? OilPressureMinEnabled { get; set; }

		[DataMember]
		[Column("OilPressureMaxEnabled")]
		public bool? OilPressureMaxEnabled { get; set; }

		[DataMember]
		[Column("OilFlowMin")]
		public double? OilFlowMin { get; set; }

		[DataMember]
		[Column("OilFlowMax")]
		public double? OilFlowMax { get; set; }

		[DataMember]
		[Column("OilFlowMinEnabled")]
		public bool? OilFlowMinEnabled { get; set; }

		[DataMember]
		[Column("OilFlowMaxEnabled")]
		public bool? OilFlowMaxEnabled { get; set; }

		[DataMember]
		[Column("OilFlowMeasure")]
		public int? OilFlowMeasure { get; set; }

		[DataMember]
		[Column("FuelPressMinEnabled")]
		public bool? FuelPressMinEnabled { get; set; }

		[DataMember]
		[Column("FuelPressMaxEnabled")]
		public bool? FuelPressMaxEnabled { get; set; }

		[DataMember]
		[Column("OilPressTorqueMinEnabled")]
		public bool? OilPressTorqueMinEnabled { get; set; }

		[DataMember]
		[Column("OilPressTorqueMaxEnabled")]
		public bool? OilPressTorqueMaxEnabled { get; set; }

		[DataMember]
		[Column("FuelFlowMinEnabled")]
		public bool? FuelFlowMinEnabled { get; set; }

		[DataMember]
		[Column("FuelFlowMaxEnabled")]
		public bool? FuelFlowMaxEnabled { get; set; }

		[DataMember]
		[Column("FuelBurnMinEnabled")]
		public bool? FuelBurnMinEnabled { get; set; }

		[DataMember]
		[Column("FuelBurnMaxEnabled")]
		public bool? FuelBurnMaxEnabled { get; set; }

		[DataMember]
		[Column("VibroOverloadMinEnabled")]
		public bool? VibroOverloadMinEnabled { get; set; }

		[DataMember]
		[Column("VibroOverloadMaxEnabled")]
		public bool? VibroOverloadMaxEnabled { get; set; }

		[DataMember]
		[Column("VibroOverload2MinEnabled")]
		public bool? VibroOverload2MinEnabled { get; set; }

		[DataMember]
		[Column("VibroOverload2MaxEnabled")]
		public bool? VibroOverload2MaxEnabled { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("TLARecomended")]
		public double? TLARecomended { get; set; }

		[DataMember]
		[Column("TLARecomendedEnabled")]
		public bool? TLARecomendedEnabled { get; set; }

		[DataMember]
		[Column("EPRRecomended")]
		public double? EPRRecomended { get; set; }

		[DataMember]
		[Column("EPRRecomendedEnabled")]
		public bool? EPRRecomendedEnabled { get; set; }

		[DataMember]
		[Column("N1Recomended")]
		public double? N1Recomended { get; set; }

		[DataMember]
		[Column("N1RecomendedEnabled")]
		public bool? N1RecomendedEnabled { get; set; }

		[DataMember]
		[Column("EGTRecomended")]
		public double? EGTRecomended { get; set; }

		[DataMember]
		[Column("EGTRecomendedEnabled")]
		public bool? EGTRecomendedEnabled { get; set; }

		[DataMember]
		[Column("N2Recomended")]
		public double? N2Recomended { get; set; }

		[DataMember]
		[Column("N2RecomendedEnabled")]
		public bool? N2RecomendedEnabled { get; set; }

		[DataMember]
		[Column("OilTemperatureRecomended")]
		public double? OilTemperatureRecomended { get; set; }

		[DataMember]
		[Column("OilTemperatureRecomendedEnabled")]
		public bool? OilTemperatureRecomendedEnabled { get; set; }

		[DataMember]
		[Column("OilPressureRecomended")]
		public double? OilPressureRecomended { get; set; }

		[DataMember]
		[Column("OilPressureRecomendedEnabled")]
		public bool? OilPressureRecomendedEnabled { get; set; }

		[DataMember]
		[Column("OilFlowRecomended")]
		public double? OilFlowRecomended { get; set; }

		[DataMember]
		[Column("OilFlowRecomendedEnabled")]
		public bool? OilFlowRecomendedEnabled { get; set; }

		[DataMember]
		[Column("FuelPressRecomended")]
		public double? FuelPressRecomended { get; set; }

		[DataMember]
		[Column("FuelPressRecomendedEnabled")]
		public bool? FuelPressRecomendedEnabled { get; set; }

		[DataMember]
		[Column("OilPressTorqueRecomended")]
		public double? OilPressTorqueRecomended { get; set; }

		[DataMember]
		[Column("OilPressTorqueRecomendedEnabled")]
		public bool? OilPressTorqueRecomendedEnabled { get; set; }

		[DataMember]
		[Column("FuelFlowRecomended")]
		public double? FuelFlowRecomended { get; set; }

		[DataMember]
		[Column("FuelFlowRecomendedEnabled")]
		public bool? FuelFlowRecomendedEnabled { get; set; }

		[DataMember]
		[Column("FuelBurnRecomended")]
		public double? FuelBurnRecomended { get; set; }

		[DataMember]
		[Column("FuelBurnRecomendedEnabled")]
		public bool? FuelBurnRecomendedEnabled { get; set; }

		[DataMember]
		[Column("VibroOverloadRecomended")]
		public double? VibroOverloadRecomended { get; set; }

		[DataMember]
		[Column("VibroOverloadRecomendedEnabled")]
		public bool? VibroOverloadRecomendedEnabled { get; set; }

		[DataMember]
		[Column("VibroOverload2Recomended")]
		public double? VibroOverload2Recomended { get; set; }

		[DataMember]
		[Column("VibroOverload2RecomendedEnabled")]
		public bool? VibroOverload2RecomendedEnabled { get; set; }

		[DataMember]
		[Column("ComponentId")]
		public int? ComponentId { get; set; }
	}
}