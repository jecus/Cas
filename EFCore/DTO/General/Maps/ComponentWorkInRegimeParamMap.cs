using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentWorkInRegimeParamMap : BaseMap<ComponentWorkInRegimeParamDTO>
	{
		public ComponentWorkInRegimeParamMap() : base()
		{
			ToTable("dbo.ComponentWorkInRegimeParams");

			Property(i => i.FlightRegime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightRegime");

			Property(i => i.TimeInRegimeMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeInRegimeMax");

			Property(i => i.EPRMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRMin");

			Property(i => i.EPRMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRMax");

			Property(i => i.N1Min)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1Min");

			Property(i => i.N1Max)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1Max");

			Property(i => i.EGTMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTMin");

			Property(i => i.EGTMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTMax");

			Property(i => i.EGTMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTMeasure");

			Property(i => i.N2Min)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2Min");

			Property(i => i.N2Max)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2Max");

			Property(i => i.OilTemperatureMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureMin");

			Property(i => i.OilTemperatureMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureMax");

			Property(i => i.OilTemperatureMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureMeasure");

			Property(i => i.OilPressureMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureMin");

			Property(i => i.OilPressureMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureMax");

			Property(i => i.OilPressureMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureMeasure");

			Property(i => i.FuelPressMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressMin");

			Property(i => i.FuelPressMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressMax");

			Property(i => i.FuelPresseMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPresseMeasure");

			Property(i => i.OilPressTorqueMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueMin");

			Property(i => i.OilPressTorqueMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueMax");

			Property(i => i.OilPressTorqueMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueMeasure");

			Property(i => i.FuelFlowMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowMin");

			Property(i => i.FuelFlowMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowMax");

			Property(i => i.FuelFlowMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowMeasure");

			Property(i => i.FuelBurnMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnMin");

			Property(i => i.FuelBurnMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnMax");

			Property(i => i.FuelBurnMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnMeasure");

			Property(i => i.VibroOverloadMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadMin");

			Property(i => i.VibroOverloadMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadMax");

			Property(i => i.VibroOverload2Min)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2Min");

			Property(i => i.VibroOverload2Max)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2Max");

			Property(i => i.GroundAir)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GroundAir");

			Property(i => i.PersentTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PersentTime");

			Property(i => i.ResorceProvider)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ResorceProvider");

			Property(i => i.ResorceProviderId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ResorceProviderId");

			Property(i => i.TLAMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLAMin");

			Property(i => i.TLAMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLAMax");

			Property(i => i.TLAMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLAMinEnabled");

			Property(i => i.TLAMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLAMaxEnabled");

			Property(i => i.EPRMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRMinEnabled");

			Property(i => i.EPRMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRMaxEnabled");

			Property(i => i.N1MinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1MinEnabled");

			Property(i => i.N1MaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1MaxEnabled");

			Property(i => i.EGTMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTMinEnabled");

			Property(i => i.EGTMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTMaxEnabled");

			Property(i => i.N2MinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2MinEnabled");

			Property(i => i.N2MaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2MaxEnabled");

			Property(i => i.OilTemperatureMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureMinEnabled");

			Property(i => i.OilTemperatureMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureMaxEnabled");

			Property(i => i.OilPressureMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureMinEnabled");

			Property(i => i.OilPressureMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureMaxEnabled");

			Property(i => i.OilFlowMin)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowMin");

			Property(i => i.OilFlowMax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowMax");

			Property(i => i.OilFlowMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowMinEnabled");

			Property(i => i.OilFlowMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowMaxEnabled");

			Property(i => i.OilFlowMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowMeasure");

			Property(i => i.FuelPressMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressMinEnabled");

			Property(i => i.FuelPressMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressMaxEnabled");

			Property(i => i.OilPressTorqueMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueMinEnabled");

			Property(i => i.OilPressTorqueMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueMaxEnabled");

			Property(i => i.FuelFlowMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowMinEnabled");

			Property(i => i.FuelFlowMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowMaxEnabled");

			Property(i => i.FuelBurnMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnMinEnabled");

			Property(i => i.FuelBurnMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnMaxEnabled");

			Property(i => i.VibroOverloadMinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadMinEnabled");

			Property(i => i.VibroOverloadMaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadMaxEnabled");

			Property(i => i.VibroOverload2MinEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2MinEnabled");

			Property(i => i.VibroOverload2MaxEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2MaxEnabled");

			Property(i => i.Remarks)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.TLARecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLARecomended");

			Property(i => i.TLARecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TLARecomendedEnabled");

			Property(i => i.EPRRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRRecomended");

			Property(i => i.EPRRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EPRRecomendedEnabled");

			Property(i => i.N1Recomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1Recomended");

			Property(i => i.N1RecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1RecomendedEnabled");

			Property(i => i.EGTRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTRecomended");

			Property(i => i.EGTRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGTRecomendedEnabled");

			Property(i => i.N2Recomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2Recomended");

			Property(i => i.N2RecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2RecomendedEnabled");

			Property(i => i.OilTemperatureRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureRecomended");

			Property(i => i.OilTemperatureRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperatureRecomendedEnabled");

			Property(i => i.OilPressureRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureRecomended");

			Property(i => i.OilPressureRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressureRecomendedEnabled");

			Property(i => i.OilFlowRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowRecomended");

			Property(i => i.OilFlowRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlowRecomendedEnabled");

			Property(i => i.FuelPressRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressRecomended");

			Property(i => i.FuelPressRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPressRecomendedEnabled");

			Property(i => i.OilPressTorqueRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueRecomended");

			Property(i => i.OilPressTorqueRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorqueRecomendedEnabled");

			Property(i => i.FuelFlowRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowRecomended");

			Property(i => i.FuelFlowRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlowRecomendedEnabled");

			Property(i => i.FuelBurnRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnRecomended");

			Property(i => i.FuelBurnRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurnRecomendedEnabled");

			Property(i => i.VibroOverloadRecomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadRecomended");

			Property(i => i.VibroOverloadRecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverloadRecomendedEnabled");

			Property(i => i.VibroOverload2Recomended)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2Recomended");

			Property(i => i.VibroOverload2RecomendedEnabled)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2RecomendedEnabled");

			Property(i => i.ComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");

		}
	}
}