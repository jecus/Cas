using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// Класс, описывает отношение между планируемым рейсом и аэропортом
    /// </summary>
    [Table("FlightNumberAirportRelations", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberAirportRelationDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumberAirportRelation : BaseEntityObject
    {
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public FlightNumber FlightNumber{ get; set; }
        /// <summary>
        /// Планируемый рейс
		/// </summary>
        [TableColumnAttribute("FlightNumberId")]
        [ParentAttribute]
        public FlightNumber FlightNumber { get; set; }

        public static PropertyInfo FlightNumberProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumber"); }
        }

		#endregion

		#region public AirportsCodes Airport { get; set; }
		/// <summary>
		/// Аэропорт
		/// </summary>
		[TableColumnAttribute("AirportId")]
        [ListViewData(210f, "Alternate Airport")]
        [NotNull]
        public AirportsCodes Airport { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public FlightNumberAirportRelation()
        /// <summary>
        /// Создает "пустую" запись о должности члена экипажа на планируемый рейс
        /// </summary>
        public FlightNumberAirportRelation()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightNumberAirportRelation;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            if (FlightNumber != null)
                result += FlightNumber + ":";
            if (Airport != null)
                result += Airport.ToString();
            return result;
        }
        #endregion   

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightNumberAirportRelation));
        }
		#endregion

		public FlightNumberAirportRelation GetCopyUnsaved()
		{
			var airportRelation = (FlightNumberAirportRelation)MemberwiseClone();
			airportRelation.ItemId = -1;
			airportRelation.UnSetEvents();

			return airportRelation;
		}
	}
}
