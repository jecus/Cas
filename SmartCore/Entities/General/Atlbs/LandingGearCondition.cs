using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{

    /// <summary>
    /// Класс описывает состояние шасси
    /// </summary>
    [Table("LandingGearCondition", "dbo", "ItemId")]
	[Dto(typeof(LandingGearConditionDTO))]
    public class LandingGearCondition : AbstractRecord
    {
        private BaseComponent _landingGear;
        private readonly AircraftFlight _parentAircraftFlight;
		private static Type _thisType;

		/*
		*  Свойства
		*/

		#region public Int32 FlightID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("FlightId")]
        public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public Int32 LandingGearID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("LandingGearId")]
        public Int32 LandingGearId { get; set; }
		#endregion

		#region public Double TirePressure1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("TirePressure1")]
        public Double TirePressure1 { get; set; }
		#endregion

		#region public Double TirePressure2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("TirePressure2")]
        public Double TirePressure2 { get; set; }
		#endregion

        #region public GearAssembly LandingGear
        /// <summary>
        /// Базовый агрегат для которого создано состояние
        /// </summary>
        public BaseComponent LandingGear
        {
            get
            {
                return _landingGear;
            }
            set
            {
                _landingGear = value;
                if (value != null)
                    LandingGearId = value.ItemId;
            }
        }

        #endregion
		
		/*
		*  Методы 
		*/
		
		#region public LandingGearCondition()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public LandingGearCondition()
        {
            _parentAircraftFlight = null;
        }
        #endregion
     
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("TP1: {0}, TP2: {1}",TirePressure1,TirePressure2);
        }
        #endregion   

        #region public override DateTime RecordDate { get; set; }
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        [TableColumnAttribute("RecordDate")]
        public override DateTime RecordDate { get; set; }
        #endregion

        #region public override Lifelength OnLifelength { get; set; }
        /// <summary>
        /// Унаследовано от AbstractRecord в БД не сохраняется
        /// </summary>
        public override Lifelength OnLifelength { get; set; }
        #endregion

        #region override public string Remarks { get; set; }
        /// <summary>
        /// Унаследовано от AbstractRecord в БД не сохраняется
        /// </summary>
        public override string Remarks { get; set; }
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(LandingGearCondition));
		}
		#endregion
	}

}
