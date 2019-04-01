using System;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Templates;

namespace SmartCore.Entities.General
{
    #region Aircraft
    /// <summary>
    /// Класс описывает назамное транспортное срелство
    /// </summary>
    [Serializable]
    [Table("Vehicles", "dbo", "ItemId")]
    [Dto(typeof(VehicleDTO))]
	public class Vehicle : BaseEntityObject, IComparable<Vehicle>, IComponentContainer
	{

        /*
        * Свойства
        */

        #region public Int32 OperatorId { get; set; }
        /// <summary>
		/// Эксплуатант, к которому относится ЕС
		/// </summary>
        [TableColumnAttribute("OperatorId")]
        public Int32 OperatorId { get; set; }
		#endregion

        #region public String RegistrationNumber { get; set; }
        /// <summary>
        /// Регистрационный номер ВС. Например EX 001
        /// </summary>
        [TableColumnAttribute("RegistrationNumber")]
        [FormControl(120,"Reg. Num")]
        public String RegistrationNumber { get; set; }
        #endregion

        #region public AircraftModel Model { get; set; }

        private AircraftModel _model;
        /// <summary>
        /// Модель ТС
        /// </summary>
        [TableColumnAttribute("ModelId")]
        [FormControl(80, "Model")]
        [Child(false)]
        public AircraftModel Model
        {
            get { return _model ?? (_model = AircraftModel.Unknown); }
            set { _model = value; }
        }
		#endregion
		
		#region public DateTime ManufactureDate { get; set; }
		/// <summary>
		/// Дата производства ВС 
		/// сохраняется в БД, но не загружается
		/// </summary>
        [TableColumn("ManufactureDate", ColumnAccessType.WriteOnly)]
        public DateTime ManufactureDate 
        {
            get
		    {
		        return Frame.ManufactureDate;
		    } 
            set
            {
                Frame.ManufactureDate = value;
            }
        }
		#endregion

		#region public String Owner { get; set; }
		/// <summary>
		/// Владелец ВС
		/// </summary>
        [TableColumnAttribute("Owner")]
        public String Owner { get; set; }
		#endregion

		#region public String CockpitSeating { get; set; }
		/// <summary>
		/// Параметр Cockpit Seating
		/// </summary>
        [TableColumnAttribute("CockpitSeating")]
        public String CockpitSeating { get; set; }
		#endregion

		#region public DateTime DeliveryDate { get; set; }
		/// <summary>
		/// День доставки воздушного судна
		/// </summary>
        [TableColumnAttribute("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }
		#endregion

		#region public DateTime AcceptanceDate { get; set; }
		/// <summary>
		/// День принятия воздушного судна
		/// </summary>
        [TableColumnAttribute("AcceptanceDate")]
        public DateTime AcceptanceDate { get; set; }
		#endregion

        #region public Int32 VehicleFrameId { get; set; }
        /// <summary>
        /// Id базового агрегата Frame самолета
        /// </summary>
        [SubQueryAttribute("VehicleFrameId", @"(Select top 1 ItemID from dbo.Components
                                                 where IsBaseComponent = 1 and BaseComponentTypeId=4 and IsDeleted=0 and
	                                             (Select top 1 DestinationObjectId from dbo.TransferRecords Where 
					                              ParentType = 6 
                                                  and DestinationObjectType = 2455
					                              and ParentId = dbo.Components.ItemId 
					                              and IsDeleted = 0
					                              order by dbo.TransferRecords.TransferDate Desc) = dbo.Vehicles.ItemId)")]
        public Int32 VehicleFrameId { get; set; }
        #endregion

        #region public bool Shesule
        /// <summary>
        /// Указывает что ВС совершает полеты(true) или находиться на карантине(false)
        /// </summary>
        [TableColumnAttribute("Schedule")]
        public bool Schedule { get; set; }

        #endregion

        /*
         * Дополнительные, вычисляемые свойства
         */

        #region public Operator Operator { get; internal set; }

        private Operator _operator;

        /// <summary>
        /// Оператор, которому принадлежит воздушное судно
        /// </summary>
        public Operator Operator
        {
            get { return _operator; } 
            set
            {
                _operator = value;
            }
        }
        #endregion

        #region public AverageUtilization AverageUtilization { get }
        /// <summary>
        /// Среднестатистическая наработка 
        /// </summary>
        public AverageUtilization AverageUtilization
        {
            get
            {
                if (Frame != null) return Frame.AverageUtilization;
                return null;
            }
        }
        #endregion

        /*
		*  Методы 
		*/
		
		#region public Vehicle()
        /// <summary>
        /// Создает транспортное средство без дополнительной информации
        /// </summary>
        public Vehicle()
        {
            ItemId = -1;
            VehicleFrameId = -1;

            //AverageUtilization = new AverageUtilization(150, 500);

            SmartCoreObjectType = SmartCoreType.Vehicle;
            // задаем поля, без которых не пройдет запрос Insert

            // связанные объекты и коллекции
            Frame = new BaseComponent {BaseComponentType = BaseComponentType.Frame};
        }
        #endregion

        #region public Vehicle(TemplateAircraft templateAircraft)
        public Vehicle(TemplateAircraft templateAircraft)
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Aircraft;

            RegistrationNumber = templateAircraft.RegistrationNumber;
            Model = templateAircraft.Model;
            CockpitSeating = templateAircraft.CockpitSeating;
        }
		#endregion

		#region public Vehicle(TemplateAircraft templateAircraft, BaseComponent frame) : this(templateAircraft)
		public Vehicle(TemplateAircraft templateAircraft, BaseComponent frame)
            : this(templateAircraft)
        {
            if (frame != null && templateAircraft != null) frame.SerialNumber = templateAircraft.SerialNumber;
            Frame = frame;
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RegistrationNumber;
        }

       
        #endregion

        #region public int CompareTo(Vehicle y)

        public int CompareTo(Vehicle y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

		#endregion

		/*
         * Математичесский аппарат транспортного средства находится во Frame
         */

		#region public BaseComponent Frame { get; internal set; }
		/// <summary>
		/// Возвращате Frame данного воздушного судна
		/// </summary>
		public BaseComponent Frame { get; internal set; }
        #endregion
    }
    #endregion
}
