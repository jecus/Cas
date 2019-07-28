using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Accessory
{

    /// <summary>
    /// Класс описывает параметры работы агрегата в определенном режиме
    /// </summary>
    [Table("ComponentWorkInRegimeParams", "dbo", "ItemId")]
    [Dto(typeof(ComponentWorkInRegimeParamDTO))]
	[Condition("IsDeleted", "0")]
    public class ComponentWorkInRegimeParams : BaseEntityObject
    {

        private static Type _thisType;

		/*
        *  Свойства
        */

		#region public Int32 ComponentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ComponentId")]
        public int ComponentId { get; set; }

        public static PropertyInfo ComponentIdProperty
        {
            get { return GetCurrentType().GetProperty("ComponentId"); }
        }

		#endregion

        #region public FlightRegime FlightRegime
        /// <summary>
        /// Режим работы
        /// </summary>
        [TableColumnAttribute("FlightRegime")]
        public FlightRegime FlightRegime{ get; set; }
        #endregion

        #region public GroundAir GroundAir { get; set; }
        /// <summary>
        /// Место работы в режиме - На земле / в воздухе
        /// </summary>
        [TableColumnAttribute("GroundAir")]
        public GroundAir GroundAir { get; set; }
        #endregion

        #region public TimeSpan TimeInRegimeMax
        /// <summary>
        /// Максимальное Время проведенное в указанном режиме
        /// </summary>
        [TableColumnAttribute("TimeInRegimeMax")]
        public TimeSpan TimeInRegimeMax { get; set; }
        #endregion

        #region public double PersentTime { get; set; }
        /// <summary>
        /// Ограничение по времени работы в процентах от ресурса детали или от определенного ремонта
        /// </summary>
        [TableColumnAttribute("PersentTime")]
        public double PersentTime { get; set; }
        #endregion

        #region public SmartCoreType ResorceProvider { get; set; }
        /// <summary>
        /// Что является источником ресурса для параметра PersentTime
        /// </summary>
        [TableColumnAttribute("ResorceProvider")]
        public SmartCoreType ResorceProvider { get; set; }
        #endregion

        #region public GroundAir GroundAir { get; set; }
        /// <summary>
        /// Идентификатор ресурса для параметра PersentTime
        /// </summary>
        [TableColumnAttribute("ResorceProviderId")]
        public int ResorceProviderId { get; set; }
        #endregion

        #region public Double TLAMin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLAMin")]
        public Double TLAMin { get; set; }
        #endregion

        #region public Double TLARecomended { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLARecomended")]
        public Double TLARecomended { get; set; }
        #endregion

        #region public Double TLAMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLAMax")]
        public Double TLAMax { get; set; }
        #endregion

        #region public Double TLAMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLAMinEnabled")]
        public bool TLAMinEnabled { get; set; }
        #endregion

        #region public Double TLARecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLARecomendedEnabled")]
        public bool TLARecomendedEnabled { get; set; }
        #endregion

        #region public Double TLAMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TLAMaxEnabled")]
        public bool TLAMaxEnabled { get; set; }
        #endregion

        #region public Double EPRMin { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("EPRMin")]
        public Double EPRMin { get; set; }
		#endregion

        #region public Double EPRRecomended { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EPRRecomended")]
        public Double EPRRecomended { get; set; }
        #endregion

        #region public Double EPRMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EPRMax")]
        public Double EPRMax { get; set; }
        #endregion

        #region public Double EPRMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EPRMinEnabled")]
        public bool EPRMinEnabled { get; set; }
        #endregion

        #region public Double EPRRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EPRRecomendedEnabled")]
        public bool EPRRecomendedEnabled { get; set; }
        #endregion

        #region public Double EPRMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EPRMaxEnabled")]
        public bool EPRMaxEnabled { get; set; }
        #endregion

        #region public Double N1Min { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("N1Min")]
        public Double N1Min { get; set; }
		#endregion

        #region public Double N1Recomended { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1Recomended")]
        public Double N1Recomended { get; set; }
        #endregion

        #region public Double N1Max { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1Max")]
        public Double N1Max { get; set; }
        #endregion

        #region public Double N1MinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1MinEnabled")]
        public bool N1MinEnabled { get; set; }
        #endregion

        #region public Double N1RecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1RecomendedEnabled")]
        public bool N1RecomendedEnabled { get; set; }
        #endregion

        #region public Double N1MaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1MaxEnabled")]
        public bool N1MaxEnabled { get; set; }
        #endregion

        #region public Double EGTMin { get; set; }
        /// <summary>
		/// Температура газа за турбиной минимальная
		/// </summary>
        [TableColumnAttribute("EGTMin")]
        public Double EGTMin { get; set; }
		#endregion

        #region public Double EGTRecomended { get; set; }
        /// <summary>
        /// Температура газа за турбиной минимальная
        /// </summary>
        [TableColumnAttribute("EGTRecomended")]
        public Double EGTRecomended { get; set; }
        #endregion

        #region public Double EGTMax { get; set; }
        /// <summary>
        /// Температура газа за турбиной максимальная
        /// </summary>
        [TableColumnAttribute("EGTMax")]
        public Double EGTMax { get; set; }
        #endregion

        #region public Double EGTMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EGTMinEnabled")]
        public bool EGTMinEnabled { get; set; }
        #endregion

        #region public Double EGTRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EGTRecomendedEnabled")]
        public bool EGTRecomendedEnabled { get; set; }
        #endregion

        #region public Double EGTMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EGTMaxEnabled")]
        public bool EGTMaxEnabled { get; set; }
        #endregion

        #region public Measure EGTMeasure { get; set; }
        /// <summary>
        /// Температура газа за турбиной Единица измерения
        /// </summary>
        [TableColumnAttribute("EGTMeasure")]
        public Measure EGTMeasure { get; set; }
        #endregion

        #region public Double N2Min { get; set; }
        /// <summary>
		/// Обороты двигателя 2 минимальная
		/// </summary>
        [TableColumnAttribute("N2Min")]
        public Double N2Min { get; set; }
		#endregion

        #region public Double N2Recomended { get; set; }
        /// <summary>
        /// Обороты двигателя 2 минимальная
        /// </summary>
        [TableColumnAttribute("N2Recomended")]
        public Double N2Recomended { get; set; }
        #endregion

        #region public Double N2Max { get; set; }
        /// <summary>
        /// Обороты двигателя 2 максимальная
        /// </summary>
        [TableColumnAttribute("N2Max")]
        public Double N2Max { get; set; }
        #endregion

        #region public Double N2MinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N2MinEnabled")]
        public bool N2MinEnabled { get; set; }
        #endregion

        #region public Double N2RecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N2RecomendedEnabled")]
        public bool N2RecomendedEnabled { get; set; }
        #endregion

        #region public Double N2MaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N2MaxEnabled")]
        public bool N2MaxEnabled { get; set; }
        #endregion

        #region public Double OilTemperatureMin { get; set; }
        /// <summary>
        /// Температура масла минимальная 
		/// </summary>
        [TableColumnAttribute("OilTemperatureMin")]
        public Double OilTemperatureMin { get; set; }
		#endregion

        #region public Double OilTemperatureRecomended { get; set; }
        /// <summary>
        /// Температура масла минимальная 
        /// </summary>
        [TableColumnAttribute("OilTemperatureRecomended")]
        public Double OilTemperatureRecomended { get; set; }
        #endregion

        #region public Double OilTemperatureMax { get; set; }
        /// <summary>
        /// Температура масла максимальная
        /// </summary>
        [TableColumnAttribute("OilTemperatureMax")]
        public Double OilTemperatureMax { get; set; }
        #endregion

        #region public Double OilTemperatureMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilTemperatureMinEnabled")]
        public bool OilTemperatureMinEnabled { get; set; }
        #endregion

        #region public Double OilTemperatureRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilTemperatureRecomendedEnabled")]
        public bool OilTemperatureRecomendedEnabled { get; set; }
        #endregion

        #region public Double OilTemperatureMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilTemperatureMaxEnabled")]
        public bool OilTemperatureMaxEnabled { get; set; }
        #endregion

        #region public Measure OilTemperatureMeasure { get; set; }
        /// <summary>
        /// Температура масла Единица измерения
        /// </summary>
        [TableColumnAttribute("OilTemperatureMeasure")]
        public Measure OilTemperatureMeasure { get; set; }
        #endregion

        #region public Double OilPressureMin { get; set; }
        /// <summary>
		/// Давление масла минимальное
		/// </summary>
        [TableColumnAttribute("OilPressureMin")]
        public Double OilPressureMin { get; set; }
		#endregion

        #region public Double OilPressureRecomended { get; set; }
        /// <summary>
        /// Давление масла минимальное
        /// </summary>
        [TableColumnAttribute("OilPressureRecomended")]
        public Double OilPressureRecomended { get; set; }
        #endregion

        #region public Double OilPressureMax { get; set; }
        /// <summary>
        /// Давление масла максимальная
        /// </summary>
        [TableColumnAttribute("OilPressureMax")]
        public Double OilPressureMax { get; set; }
        #endregion

        #region public Double OilPressureMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressureMinEnabled")]
        public bool OilPressureMinEnabled { get; set; }
        #endregion

        #region public Double OilPressureRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressureRecomendedEnabled")]
        public bool OilPressureRecomendedEnabled { get; set; }
        #endregion

        #region public Double OilPressureMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressureMaxEnabled")]
        public bool OilPressureMaxEnabled { get; set; }
        #endregion

        #region public Measure OilPressureMeasure { get; set; }
        /// <summary>
        /// Давление масла Единица измерения
        /// </summary>
        [TableColumnAttribute("OilPressureMeasure")]
        public Measure OilPressureMeasure { get; set; }
        #endregion

        #region public Double OilFlowMin { get; set; }
        /// <summary>
        /// Расход масла минимальное
        /// </summary>
        [TableColumnAttribute("OilFlowMin")]
        public Double OilFlowMin { get; set; }
        #endregion

        #region public Double OilFlowRecomended { get; set; }
        /// <summary>
        /// Расход масла минимальное
        /// </summary>
        [TableColumnAttribute("OilFlowRecomended")]
        public Double OilFlowRecomended { get; set; }
        #endregion

        #region public Double OilFlowMax { get; set; }
        /// <summary>
        /// Расход масла максимальная
        /// </summary>
        [TableColumnAttribute("OilFlowMax")]
        public Double OilFlowMax { get; set; }
        #endregion

        #region public Double OilFlowMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilFlowMinEnabled")]
        public bool OilFlowMinEnabled { get; set; }
        #endregion

        #region public Double OilFlowRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilFlowRecomendedEnabled")]
        public bool OilFlowRecomendedEnabled { get; set; }
        #endregion

        #region public Double OilFlowMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilFlowMaxEnabled")]
        public bool OilFlowMaxEnabled { get; set; }
        #endregion

        #region public Measure OilFlowMeasure { get; set; }
        /// <summary>
        /// Расход масла Единица измерения
        /// </summary>
        [TableColumnAttribute("OilFlowMeasure")]
        public Measure OilFlowMeasure { get; set; }
        #endregion

        #region public Double FuelPressMin { get; set; }
        /// <summary>
        /// Давление топлива перед форсунками минимальное
        /// </summary>
        [TableColumnAttribute("FuelPressMin")]
        public Double FuelPressMin { get; set; }
        #endregion

        #region public Double FuelPressRecomended { get; set; }
        /// <summary>
        /// Давление топлива перед форсунками минимальное
        /// </summary>
        [TableColumnAttribute("FuelPressRecomended")]
        public Double FuelPressRecomended { get; set; }
        #endregion

        #region public Double FuelPressMax { get; set; }
        /// <summary>
        /// Давление топлива перед форсунками максимальная
        /// </summary>
        [TableColumnAttribute("FuelPressMax")]
        public Double FuelPressMax { get; set; }
        #endregion

        #region public Double FuelPressMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelPressMinEnabled")]
        public bool FuelPressMinEnabled { get; set; }
        #endregion

        #region public Double FuelPressRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelPressRecomendedEnabled")]
        public bool FuelPressRecomendedEnabled { get; set; }
        #endregion

        #region public Double FuelPressMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelPressMaxEnabled")]
        public bool FuelPressMaxEnabled { get; set; }
        #endregion

        #region public Measure FuelPressMeasure { get; set; }
        /// <summary>
        /// Давление топлива перед форсунками Единица измерения
        /// </summary>
        [TableColumnAttribute("FuelPresseMeasure")]
        public Measure FuelPressMeasure { get; set; }
        #endregion

        #region public Double OilPressTorqueMin { get; set; }
        /// <summary>
        /// Давление масла в ИКМ минимальное
        /// </summary>
        [TableColumnAttribute("OilPressTorqueMin")]
        public Double OilPressTorqueMin { get; set; }
        #endregion

        #region public Double OilPressTorqueRecomended { get; set; }
        /// <summary>
        /// Давление масла в ИКМ минимальное
        /// </summary>
        [TableColumnAttribute("OilPressTorqueRecomended")]
        public Double OilPressTorqueRecomended { get; set; }
        #endregion

        #region public Double OilPressTorqueMax { get; set; }
        /// <summary>
        /// Давление масла в ИКМ максимальная
        /// </summary>
        [TableColumnAttribute("OilPressTorqueMax")]
        public Double OilPressTorqueMax { get; set; }
        #endregion

        #region public Double OilPressTorqueMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressTorqueMinEnabled")]
        public bool OilPressTorqueMinEnabled { get; set; }
        #endregion

        #region public Double OilPressTorqueRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressTorqueRecomendedEnabled")]
        public bool OilPressTorqueRecomendedEnabled { get; set; }
        #endregion

        #region public Double OilPressTorqueMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPressTorqueMaxEnabled")]
        public bool OilPressTorqueMaxEnabled { get; set; }
        #endregion

        #region public Measure OilPressTorqueMeasure { get; set; }
        /// <summary>
        /// Давление масла в ИКМ Единица измерения
        /// </summary>
        [TableColumnAttribute("OilPressTorqueMeasure")]
        public Measure OilPressTorqueMeasure { get; set; }
        #endregion

        #region public Double FuelFlowMin { get; set; }
        /// <summary>
		/// Расход топлива минимальный
		/// </summary>
        [TableColumnAttribute("FuelFlowMin")]
        public Double FuelFlowMin { get; set; }
		#endregion

        #region public Double FuelFlowRecomended { get; set; }
        /// <summary>
        /// Расход топлива минимальный
        /// </summary>
        [TableColumnAttribute("FuelFlowRecomended")]
        public Double FuelFlowRecomended { get; set; }
        #endregion

        #region public Double FuelFlowMax { get; set; }
        /// <summary>
        /// Расход топлива максимальная
        /// </summary>
        [TableColumnAttribute("FuelFlowMax")]
        public Double FuelFlowMax { get; set; }
        #endregion

        #region public Double FuelFlowMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelFlowMinEnabled")]
        public bool FuelFlowMinEnabled { get; set; }
        #endregion

        #region public Double FuelFlowRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelFlowRecomendedEnabled")]
        public bool FuelFlowRecomendedEnabled { get; set; }
        #endregion

        #region public Double FuelFlowMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelFlowMaxEnabled")]
        public bool FuelFlowMaxEnabled { get; set; }
        #endregion

        #region public Measure FuelFlowMeasure { get; set; }
        /// <summary>
        /// Расход топлива Единица измерения
        /// </summary>
        [TableColumnAttribute("FuelFlowMeasure")]
        public Measure FuelFlowMeasure { get; set; }
        #endregion

        #region public Double FuelBurnMin { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("FuelBurnMin")]
        public Double FuelBurnMin { get; set; }
		#endregion

        #region public Double FuelBurnRecomended { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelBurnRecomended")]
        public Double FuelBurnRecomended { get; set; }
        #endregion

        #region public Double FuelBurnMax { get; set; }
        /// <summary>
        /// Расход топлива максимальная
        /// </summary>
        [TableColumnAttribute("FuelBurnMax")]
        public Double FuelBurnMax { get; set; }
        #endregion

        #region public Double FuelBurnMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelBurnMinEnabled")]
        public bool FuelBurnMinEnabled { get; set; }
        #endregion

        #region public Double FuelBurnRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelBurnRecomendedEnabled")]
        public bool FuelBurnRecomendedEnabled { get; set; }
        #endregion

        #region public Double FuelBurnMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelBurnMaxEnabled")]
        public bool FuelBurnMaxEnabled { get; set; }
        #endregion

        #region public Measure FuelBurnMeasure { get; set; }
        /// <summary>
        /// Расход топлива Единица измерения
        /// </summary>
        [TableColumnAttribute("FuelBurnMeasure")]
        public Measure FuelBurnMeasure { get; set; }
        #endregion

        #region public Double VibroOverloadMin { get; set; }
        /// <summary>
        /// вибро-перегрузки 1 минимальное
        /// </summary>
        [TableColumnAttribute("VibroOverloadMin")]
        public Double VibroOverloadMin { get; set; }
        #endregion

        #region public Double VibroOverloadRecomended { get; set; }
        /// <summary>
        /// вибро-перегрузки 1 минимальное
        /// </summary>
        [TableColumnAttribute("VibroOverloadRecomended")]
        public Double VibroOverloadRecomended { get; set; }
        #endregion

        #region public Double VibroOverloadMax { get; set; }
        /// <summary>
        /// вибро-перегрузки 1 максимальное
        /// </summary>
        [TableColumnAttribute("VibroOverloadMax")]
        public Double VibroOverloadMax { get; set; }
        #endregion

        #region public Double VibroOverloadMinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverloadMinEnabled")]
        public bool VibroOverloadMinEnabled { get; set; }
        #endregion

        #region public Double VibroOverloadRecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverloadRecomendedEnabled")]
        public bool VibroOverloadRecomendedEnabled { get; set; }
        #endregion

        #region public Double VibroOverloadMaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverloadMaxEnabled")]
        public bool VibroOverloadMaxEnabled { get; set; }
        #endregion

        #region public Double VibroOverload2Min { get; set; }
        /// <summary>
        /// вибро-перегрузки2 минимальное
        /// </summary>
        [TableColumnAttribute("VibroOverload2Min")]
        public Double VibroOverload2Min { get; set; }
        #endregion

        #region public Double VibroOverload2Recomended { get; set; }
        /// <summary>
        /// вибро-перегрузки2 минимальное
        /// </summary>
        [TableColumnAttribute("VibroOverload2Recomended")]
        public Double VibroOverload2Recomended { get; set; }
        #endregion

        #region public Double VibroOverload2Max { get; set; }
        /// <summary>
        /// вибро-перегрузки2 максимальное
        /// </summary>
        [TableColumnAttribute("VibroOverload2Max")]
        public Double VibroOverload2Max { get; set; }
        #endregion

        #region public Double VibroOverload2MinEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverload2MinEnabled")]
        public bool VibroOverload2MinEnabled { get; set; }
        #endregion

        #region public Double VibroOverload2RecomendedEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverload2RecomendedEnabled")]
        public bool VibroOverload2RecomendedEnabled { get; set; }
        #endregion

        #region public Double VibroOverload2MaxEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("VibroOverload2MaxEnabled")]
        public bool VibroOverload2MaxEnabled { get; set; }
        #endregion

        #region public string Remarks { get; set; }
        /// <summary>
        /// Заметки
        /// </summary>
        [TableColumnAttribute("Remarks")]
        public string Remarks { get; set; }
        #endregion

        #region public Engine Engine

        private BaseComponent _engine;
        /// <summary>
        /// Двигатель
        /// </summary>
        public BaseComponent Engine
        {
            get
            {
                if (ItemId < 0)
                {
                    if (ComponentId == 0)
                        return null;
                    return _engine;
                    //if (m_parentAircraftFlight != null)
                    //    return m_parentAircraftFlight.parentAircraft.(EngineID);
                }
                return _engine;
            }
            set
            {
                _engine = value;
                if(value != null)
                    ComponentId = value.ItemId;
            }
        }

		#endregion

		/*
		*  Методы 
		*/

		#region public ComponentWorkInRegimeParams()
		/// <summary>
		/// Создает экземпляр параметров работы агрегата в различных режимах
		/// </summary>
		public ComponentWorkInRegimeParams()
        {
            TLAMaxEnabled = true;
            TLAMinEnabled = true;
            EPRMaxEnabled = true;
            EPRMinEnabled = true;
            N1MaxEnabled = true;
            N1MinEnabled = true;
            EGTMaxEnabled = true;
            EGTMinEnabled = true;
            N2MaxEnabled = true;
            N2MinEnabled = true;
            OilTemperatureMaxEnabled = true;
            OilTemperatureMinEnabled = true;
            OilPressureMaxEnabled = true;
            OilPressureMinEnabled = true;
            OilFlowMaxEnabled = true;
            OilFlowMinEnabled = true;
            FuelPressMaxEnabled = true;
            FuelPressMinEnabled = true;
            OilPressTorqueMaxEnabled = true;
            OilPressTorqueMinEnabled = true;
            FuelFlowMaxEnabled = true;
            FuelFlowMinEnabled = true;
            FuelBurnMaxEnabled = true;
            FuelBurnMinEnabled = true;
            VibroOverloadMaxEnabled = true;
            VibroOverloadMinEnabled = true;
            VibroOverload2MaxEnabled = true;
            VibroOverload2MinEnabled = true;
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.ComponentWorkInRegimeParams;
        }

        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(ComponentWorkInRegimeParams));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   
    }

}
