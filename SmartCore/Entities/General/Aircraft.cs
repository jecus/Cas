using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.CAA.Aircraft;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Templates;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Класс описывает воздушное судно
    /// </summary>
    [Serializable]
    [Table("Aircrafts", "dbo", "ItemId")]
    [Condition("IsDeleted", "0")]
	[Dto(typeof(AircraftDTO))]
	[CAADto(typeof(CAAAircraftDTO))]
	public class Aircraft : BaseEntityObject, IComparable<Aircraft>, IComponentContainer, IAircraftFilter
    {

        /*
        * Свойства
        */
		[TableColumn("APUFH")]
		public double APUFH { get; set; }

		/// <summary>
		/// Эксплуатант, к которому относится ВС
		/// </summary>
		[TableColumnAttribute("OperatorId")]
        public int OperatorId { get; set; }
		/// <summary>
		/// Тип воздушного судна
		/// </summary>
        [TableColumnAttribute("AircraftTypeId")]
        public int AircraftTypeId { get; set; }
        /// <summary>
        /// Регистрационный номер ВС. Например EX 001
        /// </summary>
        [TableColumnAttribute("RegistrationNumber")]
        [FormControl(120,"Reg. Num")]
        public string RegistrationNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
        private AircraftModel _model;
        /// <summary>
        /// Модель воздушного судна
        /// </summary>
        [TableColumnAttribute("ModelId")]
        [FormControl(80, "Model")]
        [Child(false)]
        public AircraftModel Model
        {
            get => _model ?? (_model = AircraftModel.Unknown);
            set => _model = value;
        }
		/// <summary>
		/// Номер сертификата
		/// </summary>
        [TableColumnAttribute("TypeCertificateNumber")]
        public string TypeCertificateNumber { get; set; }
		/// <summary>
		/// Дата производства ВС 
		/// сохраняется в БД, но не загружается
		/// </summary>
        [TableColumn("ManufactureDate")]
        public DateTime ManufactureDate { get; set; }
		/// <summary>
		/// Серийный (заводской) номер ВС
		/// </summary>
        [TableColumnAttribute("SerialNumber")]
        public string SerialNumber { get; set; }
		/// <summary>
		/// Вариационный номер ВС
		/// </summary>
        [TableColumnAttribute("VariableNumber")]
        public string VariableNumber { get; set; }
		/// <summary>
		/// Линейный номер ВС
		/// </summary>
        [TableColumnAttribute("LineNumber")]
        public string LineNumber { get; set; }
		/// <summary>
		/// Владелец ВС
		/// </summary>
        [TableColumnAttribute("Owner")]
        public string Owner { get; set; }
        /// <summary>
		/// Параметр Basic Empty Weight
		/// </summary>
        [TableColumnAttribute("BasicEmptyWeight")]
        public double BasicEmptyWeight { get; set; }
        /// <summary>
		/// Параметр Basic Empty Weight Cargo Config
		/// </summary>
        [TableColumnAttribute("BasicEmptyWeightCargoConfig")]
        public double BasicEmptyWeightCargoConfig { get; set; }
        /// <summary>
        /// Параметр OperationalEmptyWeight
        /// </summary>
        [TableColumnAttribute("OperationalEmptyWeight")]
        public double OperationalEmptyWeight { get; set; }
		/// <summary>
		/// Параметр Cargo Capacity Container
		/// </summary>
        [TableColumnAttribute("CargoCapacityContainer")]
        public string CargoCapacityContainer { get; set; }
		/// <summary>
		/// Параметр Cruise
		/// </summary>
        [TableColumnAttribute("Cruise")]
        public string Cruise { get; set; }
		/// <summary>
		/// Параметр Cruise Fuel Flow
		/// </summary>
        [TableColumnAttribute("CruiseFuelFlow")]
        public string CruiseFuelFlow { get; set; }
		/// <summary>
		/// Параметр Fuel Capacity
		/// </summary>
        [TableColumnAttribute("FuelCapacity")]
        public string FuelCapacity { get; set; }
		/// <summary>
		/// Параметр Max Cruise Altitude
		/// </summary>
        [TableColumnAttribute("MaxCruiseAltitude")]
        public string MaxCruiseAltitude { get; set; }
        /// <summary>
		/// Параметр Max Landing Weight
		/// </summary>
        [TableColumnAttribute("MaxLandingWeight")]
        public double MaxLandingWeight { get; set; }
        /// <summary>
        /// Параметр MaxPayloadWeight
        /// </summary>
        [TableColumnAttribute("MaxPayloadWeight")]
        public double MaxPayloadWeight { get; set; }
        /// <summary>
		/// Параметр Max Take Off Cross Weight
		/// </summary>
        [TableColumnAttribute("MaxTakeOffCrossWeight")]
        public double MaxTakeOffCrossWeight { get; set; }
        /// <summary>
        /// Параметр MaxTaxiWeight
        /// </summary>
        [TableColumnAttribute("MaxTaxiWeight")]
        public double MaxTaxiWeight { get; set; }
        /// <summary>
		/// Параметр Max Zero Fuel Weight
		/// </summary>
        [TableColumnAttribute("MaxZeroFuelWeight")]
        public double MaxZeroFuelWeight { get; set; }
		/// <summary>
		/// Параметр Cockpit Seating
		/// </summary>
        [TableColumnAttribute("CockpitSeating")]
        public string CockpitSeating { get; set; }
		/// <summary>
		/// Параметр Galleys
		/// </summary>
        [TableColumnAttribute("Galleys")]
        public string Galleys { get; set; }
		/// <summary>
		/// Параметр Lavatory
		/// </summary>
        [TableColumnAttribute("Lavatory")]
        public string Lavatory { get; set; }
        /// <summary>
		/// Количество сидений эконом класса
		/// </summary>
        [TableColumnAttribute("SeatingEconomy")]
        public int SeatingEconomy { get; set; }
        /// <summary>
        /// Количество сидений бизнес класса
        /// </summary>
        [TableColumnAttribute("SeatingBusiness")]
        public int SeatingBusiness { get; set; }
        /// <summary>
        /// Количество сидений первого класса
        /// </summary>
        [TableColumnAttribute("SeatingFirst")]
        public int SeatingFirst { get; set; }
        /// <summary>
        /// Кол-во котлов
        /// </summary>
        [TableColumnAttribute("Boiler")]
        public string Boiler { get; set; }
        /// <summary>
        /// Кол-во печек
        /// </summary>
        [TableColumnAttribute("Oven")]
        public string Oven { get; set; }
        /// <summary>
        /// Кол-во дверей с лестницами
        /// </summary>
        [TableColumnAttribute("AirStairDoors")]
        public string AirStairsDoors { get; set; }
        /// <summary>
		/// Топливные баки
		/// </summary>
        [TableColumnAttribute("Tanks")]
        public int Tanks { get; set; }
		/// <summary>
		/// День доставки воздушного судна
		/// </summary>
        [TableColumnAttribute("DeliveryDate")]
        public DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// День принятия воздушного судна
		/// </summary>
        [TableColumnAttribute("AcceptanceDate")]
        public DateTime? AcceptanceDate { get; set; }
        /// <summary>
        /// Id базового агрегата Frame самолета
        /// </summary>
        [SubQueryAttribute("AircraftFrameId", 
	        @"(Select ItemID from dbo.Components comp
					 CROSS APPLY
					 (
						Select DestinationObjectId from dbo.TransferRecords Where 
										                              ParentType = 6 
					                                                  and DestinationObjectType = 7
										                              and ParentId = comp.ItemId 
										                              and IsDeleted = 0
					 ) T
					 where comp.IsBaseComponent = 1 and comp.BaseComponentTypeId=4 and comp.IsDeleted=0 and T.DestinationObjectID = dbo.Aircrafts.ItemId)")]
        public int AircraftFrameId { get; set; }
        /// <summary>
        /// Параметр AircraftAddress24Bit
        /// </summary>
        [TableColumnAttribute("AircraftAddress24Bit")]
        public string AircraftAddress24Bit { get; set; }
        /// <summary>
        /// Параметр Max Zero Fuel Weight
        /// </summary>
        [TableColumnAttribute("ELTIdHexCode")]
        public string ELTIdHexCode { get; set; }
        /// <summary>
        /// Указывает что ВС совершает полеты(true) или находиться на карантине(false)
        /// </summary>
        [TableColumnAttribute("Schedule")]
        public bool Schedule { get; set; }
        /// <summary>
        /// Указывает как производится наименование чеков программы обслуживания
        /// <br/> false - по собственному имени чека
        /// <br/> true - по порядковому номеру
        /// </summary>
        [TableColumnAttribute("CheckNaming")]
        public bool MaintenanceProgramCheckNaming { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("MSG")]
        public MSG MSG { get; set; }
        /// <summary>
        /// Категория шума ВС
        /// </summary>
        [TableColumnAttribute("NoiceCategory")]
        public int NoiceCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FADEC")]
        public bool FADEC { get; set; }
        /// <summary>
        /// Категория посадки ВС
        /// </summary>
        [TableColumnAttribute("LandingCategory")]
        public int LandingCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EFIS")]
        public bool EFIS { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Brakes")]
        public Brakes Brakes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Winglets")]
        public bool Winglets { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ApuUtizationPerFlightinMinutes")]
	    public short? ApuUtizationPerFlightinMinutes { get; set; }

	    public List<AircraftEquipments> AircraftEquipments
	    {
		    get => _aircraftEquipmets ?? (_aircraftEquipmets = new List<AircraftEquipments>());
            set
		    {
				if (_aircraftEquipmets != value)
				{
					if (_aircraftEquipmets != null)
						_aircraftEquipmets.Clear();
					if (value != null)
						_aircraftEquipmets = value;

					OnPropertyChanged("LLPData");
				}
		    }
	    }

	    /*
         * Дополнительные, вычисляемые свойства
         */

	    /*
		*  Методы 
		*/

	    /// <summary>
	    /// Создает воздушное судно без дополнительной информации
	    /// </summary>
	    public Aircraft()
        {
            ItemId = -1;
            AircraftFrameId = -1;
            MSG = MSG.Unknown;
            Brakes = Brakes.Carbon;
            //AverageUtilization = new AverageUtilization(150, 500);

            SmartCoreObjectType = SmartCoreType.Aircraft;
            // задаем поля, без которых не пройдет запрос Insert
            SerialNumber = "";
        }
        /// <summary>
		/// 
		/// </summary>
		/// <param name="templateAircraft"></param>
        public Aircraft(TemplateAircraft templateAircraft)
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Aircraft;

            AircraftTypeId = templateAircraft.AircraftTypeId;
            RegistrationNumber = templateAircraft.RegistrationNumber;
            SerialNumber = templateAircraft.SerialNumber;
            LineNumber = templateAircraft.LineNumber;
            VariableNumber = templateAircraft.VariableNumber;
            Model = templateAircraft.Model;
            BasicEmptyWeight = templateAircraft.BasicEmptyWeight;
            BasicEmptyWeightCargoConfig = templateAircraft.BasicEmptyWeightCargoConfig;
            OperationalEmptyWeight = templateAircraft.OperationalEmptyWeight;
            CargoCapacityContainer = templateAircraft.CargoCapacityContainer;
            Cruise = templateAircraft.Cruise;
            CruiseFuelFlow = templateAircraft.CruiseFuelFlow;
            FuelCapacity = templateAircraft.FuelCapacity;
	        ManufactureDate = templateAircraft.ManufactureDate;
            MaxCruiseAltitude = templateAircraft.MaxCruiseAltitude;
            MaxLandingWeight = templateAircraft.MaxLandingWeight;
            MaxPayloadWeight = templateAircraft.MaxPayloadWeight;
            MSG = templateAircraft.MSG;
            MaxTakeOffCrossWeight = templateAircraft.MaxTakeOffCrossWeight;
            MaxTaxiWeight = templateAircraft.MaxTaxiWeight;
            MaxZeroFuelWeight = templateAircraft.MaxZeroFuelWeight;
            CockpitSeating = templateAircraft.CockpitSeating;
            Galleys = templateAircraft.Galleys;
            Lavatory = templateAircraft.Lavatory;
            SeatingEconomy = templateAircraft.SeatingEconomy;
            SeatingBusiness = templateAircraft.SeatingBusiness;
            SeatingFirst = templateAircraft.SeatingFirst;
            Boiler = templateAircraft.Boiler;
            Oven = templateAircraft.Oven;
            AirStairsDoors = templateAircraft.AirStairsDoors;
            Tanks = templateAircraft.Tanks;
            // связанные объекты и коллекции
            // Frame = new BaseDetail { DetailType = DetailType.Frame };
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="templateAircraft"></param>
		/// <param name="frame"></param>
        public Aircraft(TemplateAircraft templateAircraft, BaseComponent frame) : this(templateAircraft)
        {
            if (frame != null && templateAircraft != null)
				frame.SerialNumber = templateAircraft.SerialNumber;
        }
        
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RegistrationNumber;
        }
        public int CompareTo(Aircraft y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        /*
         * Математичесский аппарат воздушного судна находится во Frame
         */
		/// <summary>
		/// 
		/// </summary>
        private BaseRecordCollection<MaintenanceProgramChangeRecord> _maintenanceProgramChangeRecords;

	    private List<AircraftEquipments> _aircraftEquipmets;

	    /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentAircraftId", "ParentAircraft")]
        public BaseRecordCollection<MaintenanceProgramChangeRecord> MaintenanceProgramChangeRecords
        {
            get => _maintenanceProgramChangeRecords ?? (_maintenanceProgramChangeRecords = new BaseRecordCollection<MaintenanceProgramChangeRecord>());
            internal set
            {
                if (_maintenanceProgramChangeRecords != value)
                {
                    if (_maintenanceProgramChangeRecords != null)
                        _maintenanceProgramChangeRecords.Clear();
                    if (value != null)
                        _maintenanceProgramChangeRecords = value;
                }
            }
        }

	    private static Aircraft _unknown;
		public static Aircraft Unknown =>
            _unknown ?? (_unknown = new Aircraft
            {
                RegistrationNumber = "N/A",
                ItemId = -1
            });


        public new Aircraft GetCopyUnsaved(bool marked = true)
	    {
		    var aircraft = (Aircraft) MemberwiseClone();
		    aircraft.ItemId = -1;
            if(marked)
				aircraft.RegistrationNumber += " Copy";
		    aircraft.UnSetEvents();

		    return aircraft;
	    }

    }
}
