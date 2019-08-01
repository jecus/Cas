using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{
    /// <summary>
    /// Класс для связи определенного рейса с определенной моделью ВС
    /// </summary>
    [Table("FlightNumberAircraftModelRelations", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberAircraftModelRelationDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumberAircraftModelRelation : BaseEntityObject
    {
        private static Type _thisType;

		#region public Int32 AircraftModelId { get; set; }
		/// <summary>
		/// ID модели ВС
		/// </summary>
        [TableColumnAttribute("AircraftModelId")]
        [FormControl("Model")]
        [ListViewData(230f, "Model")]
        [NotNull]
        [Child(true)]
		public AircraftModel AircraftModel { get; set; }

        public static PropertyInfo AircraftModelProperty
        {
            get { return GetCurrentType().GetProperty("AircraftModel"); }
        }

		#endregion

        #region public Int32 FlightNumber { get; set; }
        /// <summary>
        /// Идентификатор рейса
        /// </summary>
        [TableColumnAttribute("FlightNumberId")]
        [ParentAttribute]
        public FlightNumber FlightNumber { get; set; }

        public static PropertyInfo FlightNumberIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumber"); }
        }

        #endregion

       /*
		*  Методы 
		*/
		
		#region public FlightNumberAircraftModelRelation()
        /// <summary>
        /// Создает связь без параметров
        /// </summary>
        public FlightNumberAircraftModelRelation()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightNumberAircraftModelRelation;
        }
        #endregion

        #region public FlightNumberAircraftModelRelation(AircraftModel aircraftModel):this()
        /// <summary>
        /// Создает связь с определенной моделью
        /// </summary>
        public FlightNumberAircraftModelRelation(AircraftModel aircraftModel):this()
        {
            if(aircraftModel == null)
                throw new ArgumentNullException("aircraftModel","must be not null");
            
            AircraftModel = aircraftModel;
        }
        #endregion

        #region public FlightNumberAircraftModelRelation(FlightNumberAircraftModelRelation toCopy):this()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public FlightNumberAircraftModelRelation(FlightNumberAircraftModelRelation toCopy)
            : this()
        {
            if (toCopy == null)return;

            AircraftModel = toCopy.AircraftModel;
            FlightNumber = toCopy.FlightNumber;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightNumberAircraftModelRelation));
        }
		#endregion

		#region public override string ToString()

		public override string ToString()
	    {
		    return AircraftModel.ToString();
	    }

		#endregion

		public FlightNumberAircraftModelRelation GetCopyUnsaved()
		{
			var aircraftModelRelation = (FlightNumberAircraftModelRelation)MemberwiseClone();
			aircraftModelRelation.ItemId = -1;
			aircraftModelRelation.UnSetEvents();

			return aircraftModelRelation;
		}
	}
}
