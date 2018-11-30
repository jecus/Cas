using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentWorkInRegimeParamDTO : BaseEntity
	{
		[DataMember]
		public int? FlightRegime { get; set; }

		[DataMember]
		public int? TimeInRegimeMax { get; set; }

		[DataMember]
		public double? EPRMin { get; set; }

		[DataMember]
		public double? EPRMax { get; set; }

		[DataMember]
		public double? N1Min { get; set; }

		[DataMember]
		public double? N1Max { get; set; }

		[DataMember]
		public double? EGTMin { get; set; }

		[DataMember]
		public double? EGTMax { get; set; }

		[DataMember]
		public int? EGTMeasure { get; set; }

		[DataMember]
		public double? N2Min { get; set; }

		[DataMember]
		public double? N2Max { get; set; }

		[DataMember]
		public double? OilTemperatureMin { get; set; }

		[DataMember]
		public double? OilTemperatureMax { get; set; }

		[DataMember]
		public int? OilTemperatureMeasure { get; set; }

		[DataMember]
		public double? OilPressureMin { get; set; }

		[DataMember]
		public double? OilPressureMax { get; set; }

		[DataMember]
		public int? OilPressureMeasure { get; set; }

		[DataMember]
		public double? FuelPressMin { get; set; }

		[DataMember]
		public double? FuelPressMax { get; set; }

		[DataMember]
		public int? FuelPresseMeasure { get; set; }

		[DataMember]
		public double? OilPressTorqueMin { get; set; }

		[DataMember]
		public double? OilPressTorqueMax { get; set; }

		[DataMember]
		public int? OilPressTorqueMeasure { get; set; }

		[DataMember]
		public double? FuelFlowMin { get; set; }

		[DataMember]
		public double? FuelFlowMax { get; set; }

		[DataMember]
		public int? FuelFlowMeasure { get; set; }

		[DataMember]
		public double? FuelBurnMin { get; set; }

		[DataMember]
		public double? FuelBurnMax { get; set; }

		[DataMember]
		public int? FuelBurnMeasure { get; set; }

		[DataMember]
		public double? VibroOverloadMin { get; set; }

		[DataMember]
		public double? VibroOverloadMax { get; set; }

		[DataMember]
		public double? VibroOverload2Min { get; set; }

		[DataMember]
		public double? VibroOverload2Max { get; set; }

		[DataMember]
		public short? GroundAir { get; set; }

		[DataMember]
		public double? PersentTime { get; set; }

		[DataMember]
		public int? ResorceProvider { get; set; }

		[DataMember]
		public int? ResorceProviderId { get; set; }

		[DataMember]
		public double? TLAMin { get; set; }

		[DataMember]
		public double? TLAMax { get; set; }

		[DataMember]
		public bool? TLAMinEnabled { get; set; }

		[DataMember]
		public bool? TLAMaxEnabled { get; set; }

		[DataMember]
		public bool? EPRMinEnabled { get; set; }

		[DataMember]
		public bool? EPRMaxEnabled { get; set; }

		[DataMember]
		public bool? N1MinEnabled { get; set; }

		[DataMember]
		public bool? N1MaxEnabled { get; set; }

		[DataMember]
		public bool? EGTMinEnabled { get; set; }

		[DataMember]
		public bool? EGTMaxEnabled { get; set; }

		[DataMember]
		public bool? N2MinEnabled { get; set; }

		[DataMember]
		public bool? N2MaxEnabled { get; set; }

		[DataMember]
		public bool? OilTemperatureMinEnabled { get; set; }

		[DataMember]
		public bool? OilTemperatureMaxEnabled { get; set; }

		[DataMember]
		public bool? OilPressureMinEnabled { get; set; }

		[DataMember]
		public bool? OilPressureMaxEnabled { get; set; }

		[DataMember]
		public double? OilFlowMin { get; set; }

		[DataMember]
		public double? OilFlowMax { get; set; }

		[DataMember]
		public bool? OilFlowMinEnabled { get; set; }

		[DataMember]
		public bool? OilFlowMaxEnabled { get; set; }

		[DataMember]
		public int? OilFlowMeasure { get; set; }

		[DataMember]
		public bool? FuelPressMinEnabled { get; set; }

		[DataMember]
		public bool? FuelPressMaxEnabled { get; set; }

		[DataMember]
		public bool? OilPressTorqueMinEnabled { get; set; }

		[DataMember]
		public bool? OilPressTorqueMaxEnabled { get; set; }

		[DataMember]
		public bool? FuelFlowMinEnabled { get; set; }

		[DataMember]
		public bool? FuelFlowMaxEnabled { get; set; }

		[DataMember]
		public bool? FuelBurnMinEnabled { get; set; }

		[DataMember]
		public bool? FuelBurnMaxEnabled { get; set; }

		[DataMember]
		public bool? VibroOverloadMinEnabled { get; set; }

		[DataMember]
		public bool? VibroOverloadMaxEnabled { get; set; }

		[DataMember]
		public bool? VibroOverload2MinEnabled { get; set; }

		[DataMember]
		public bool? VibroOverload2MaxEnabled { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public double? TLARecomended { get; set; }

		[DataMember]
		public bool? TLARecomendedEnabled { get; set; }

		[DataMember]
		public double? EPRRecomended { get; set; }

		[DataMember]
		public bool? EPRRecomendedEnabled { get; set; }

		[DataMember]
		public double? N1Recomended { get; set; }

		[DataMember]
		public bool? N1RecomendedEnabled { get; set; }

		[DataMember]
		public double? EGTRecomended { get; set; }

		[DataMember]
		public bool? EGTRecomendedEnabled { get; set; }

		[DataMember]
		public double? N2Recomended { get; set; }

		[DataMember]
		public bool? N2RecomendedEnabled { get; set; }

		[DataMember]
		public double? OilTemperatureRecomended { get; set; }

		[DataMember]
		public bool? OilTemperatureRecomendedEnabled { get; set; }

		[DataMember]
		public double? OilPressureRecomended { get; set; }

		[DataMember]
		public bool? OilPressureRecomendedEnabled { get; set; }

		[DataMember]
		public double? OilFlowRecomended { get; set; }

		[DataMember]
		public bool? OilFlowRecomendedEnabled { get; set; }

		[DataMember]
		public double? FuelPressRecomended { get; set; }

		[DataMember]
		public bool? FuelPressRecomendedEnabled { get; set; }

		[DataMember]
		public double? OilPressTorqueRecomended { get; set; }

		[DataMember]
		public bool? OilPressTorqueRecomendedEnabled { get; set; }

		[DataMember]
		public double? FuelFlowRecomended { get; set; }

		[DataMember]
		public bool? FuelFlowRecomendedEnabled { get; set; }

		[DataMember]
		public double? FuelBurnRecomended { get; set; }

		[DataMember]
		public bool? FuelBurnRecomendedEnabled { get; set; }

		[DataMember]
		public double? VibroOverloadRecomended { get; set; }

		[DataMember]
		public bool? VibroOverloadRecomendedEnabled { get; set; }

		[DataMember]
		public double? VibroOverload2Recomended { get; set; }

		[DataMember]
		public bool? VibroOverload2RecomendedEnabled { get; set; }

		[DataMember]
		public int? ComponentId { get; set; }
	}
}