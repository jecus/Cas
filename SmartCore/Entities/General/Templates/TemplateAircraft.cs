using System;
using System.Collections.Generic;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{
    #region TemplateAircraft
    /// <summary>
    /// Класс описывает воздушное судно
    /// </summary>
    [Serializable]
    [Table("Aircrafts", "Template", "ItemId")]
    public class TemplateAircraft : BaseEntityObject, IComparable<TemplateAircraft>
    {

        /*
        * Свойства
        */

        #region public Int32 TemplateId { get; set; }
        /// <summary>
        /// Код шаблона, которому принадлежит данный шаблон самолета
        /// </summary>
        [TableColumnAttribute("TemplateId")]
        public Int32 TemplateId { get; set; }
        #endregion

        #region public Int32 AircraftTypeID { get; set; }
        /// <summary>
        /// Тип воздушного судна
        /// </summary>
        [TableColumnAttribute("AircraftTypeId")]
        public Int32 AircraftTypeId { get; set; }
        #endregion

        #region public DateTime ManufactureDate { get; set; }
        /// <summary>
        /// День производства воздушного судна
        /// </summary>
        [ListViewData("Manufacture Date")]
        public DateTime ManufactureDate { get; set; }
        #endregion

        #region public String RegistrationNumber { get; set; }
        /// <summary>
        /// Регистрационный номер ВС. Например EX 001
        /// </summary>
        [ListViewData("Reg.Num.")]
        [NotNull]
        public String RegistrationNumber { get; set; }
        #endregion

        #region public String SerialNumber { get; set; }
        /// <summary>
        /// Серийный (заводской) номер ВС
        /// </summary>
        [ListViewData("Serial Num.")]
        public String SerialNumber { get; set; }
        #endregion

        #region public String VariableNumber { get; set; }
        /// <summary>
        /// Вариационный номер ВС
        /// </summary>
        [ListViewData("Varialbe Num.")]
        public String VariableNumber { get; set; }
        #endregion

        #region public String LineNumber { get; set; }
        /// <summary>
        /// Линейный номер ВС
        /// </summary>
        [ListViewData("Line Num.")]
        public String LineNumber { get; set; }
        #endregion

        #region public AircraftModel Model { get; set; }
        /// <summary>
        /// Модель воздушного судна
        /// </summary>
        [TableColumnAttribute("ModelId"), ListViewData(100, "Model", true)]
        [NotNull]
        [Child(false)]
        public AircraftModel Model { get; set; }
        #endregion

        #region public double BasicEmptyWeight { get; set; }
        /// <summary>
        /// Параметр Basic Empty Weight
        /// </summary>
        [TableColumnAttribute("BasicEmptyWeight"), ListViewData("Basic Empty Weight")]
        [MinMaxValue(0, 1000000)]
        public double BasicEmptyWeight { get; set; }
        #endregion

        #region public double BasicEmptyWeightCargoConfig { get; set; }
        /// <summary>
        /// Параметр Basic Empty Weight Cargo Config
        /// </summary>
        [TableColumnAttribute("BasicEmptyWeightCargoConfig"), ListViewData("Basic Empty Weight Cargo Config")]
        [MinMaxValue(0, 1000000)]
        public double BasicEmptyWeightCargoConfig { get; set; }
        #endregion

        #region public double OperationalEmptyWeight { get; set; }
        /// <summary>
        /// Параметр OperationalEmptyWeight
        /// </summary>
        [TableColumnAttribute("OperationalEmptyWeight"), ListViewData("Operational Empty Weight")]
        [MinMaxValue(0, 1000000)]
        public double OperationalEmptyWeight { get; set; }
        #endregion

        #region public String CargoCapacityContainer { get; set; }
        /// <summary>
        /// Параметр Cargo Capacity Container
        /// </summary>
        [TableColumnAttribute("CargoCapacityContainer"), ListViewData("Cargo Capacity Container")]
        public String CargoCapacityContainer { get; set; }
        #endregion

        #region public String Cruise { get; set; }
        /// <summary>
        /// Параметр Cruise
        /// </summary>
        [TableColumnAttribute("Cruise"), ListViewData("Cruise")]
        public String Cruise { get; set; }
        #endregion

        #region public String CruiseFuelFlow { get; set; }
        /// <summary>
        /// Параметр Cruise Fuel Flow
        /// </summary>
        [TableColumnAttribute("CruiseFuelFlow"), ListViewData("Cruise Fuel Flow")]
        public String CruiseFuelFlow { get; set; }
        #endregion

        #region public String FuelCapacity { get; set; }
        /// <summary>
        /// Параметр Fuel Capacity
        /// </summary>
        [TableColumnAttribute("FuelCapacity"), ListViewData("Fuel Capacity")]
        public String FuelCapacity { get; set; }
        #endregion

        #region public MSG MSG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[TableColumnAttribute("MSG")]
        [ListViewData("MSG")]
        public MSG MSG { get; set; }

        #endregion

        #region public String MaxCruiseAltitude { get; set; }
        /// <summary>
        /// Параметр Max Cruise Altitude
        /// </summary>
        [TableColumnAttribute("MaxCruiseAltitude"), ListViewData("Max Cruise Altitude")]
        public String MaxCruiseAltitude { get; set; }
        #endregion

        #region public double MaxLandingWeight { get; set; }
        /// <summary>
        /// Параметр Max Landing Weight
        /// </summary>
        [TableColumnAttribute("MaxLandingWeight"), ListViewData("Max Landing Weight")]
        [MinMaxValue(0, 1000000)]
        public double MaxLandingWeight { get; set; }
        #endregion

        #region public double MaxPayloadWeight { get; set; }
        /// <summary>
        /// Параметр Максимальная коммерческая нагрузка
        /// </summary>
        [TableColumnAttribute("MaxPayloadWeight")]
        [ListViewData("Max Payload Weight")]
        [MinMaxValue(0, 1000000)]
        public double MaxPayloadWeight { get; set; }
        #endregion

        #region public double MaxTakeOffCrossWeight { get; set; }
        /// <summary>
        /// Параметр Max Take Off Cross Weight
        /// </summary>
        [TableColumnAttribute("MaxTakeOffCrossWeight"), ListViewData("Max TakeOff Cross Weight")]
        [MinMaxValue(0, 1000000)]
        public double MaxTakeOffCrossWeight { get; set; }
        #endregion

        #region public double MaxTaxiWeight { get; set; }
        /// <summary>
        /// Параметр MaxTaxiWeight
        /// </summary>
        [TableColumnAttribute("MaxTaxiWeight"), ListViewData("Max Taxi Weight")]
        [MinMaxValue(0, 1000000)]
        public double MaxTaxiWeight { get; set; }
        #endregion

        #region public double MaxZeroFuelWeight { get; set; }
        /// <summary>
        /// Параметр Max Zero Fuel Weight
        /// </summary>
        [TableColumnAttribute("MaxZeroFuelWeight"), ListViewData("Max ZeroFuel Weight")]
        [MinMaxValue(0,1000000)]
        public double MaxZeroFuelWeight { get; set; }
        #endregion

        #region public String CockpitSeating { get; set; }
        /// <summary>
        /// Параметр Cockpit Seating
        /// </summary>
        [TableColumnAttribute("CockpitSeating"), ListViewData("Cockpit Seating")]
        public String CockpitSeating { get; set; }
        #endregion

        #region public String Galleys { get; set; }
        /// <summary>
        /// Параметр Galleys
        /// </summary>
        [TableColumnAttribute("Galleys"), ListViewData("Galleys") ]
        public String Galleys { get; set; }
        #endregion

        #region public String Lavatory { get; set; }
        /// <summary>
        /// Параметр Lavatory
        /// </summary>
        [TableColumnAttribute("Lavatory"), ListViewData("Lavatory")]
        public String Lavatory { get; set; }
        #endregion

        #region public int SeatingEconomy { get; set; }
        /// <summary>
        /// Количество сидений эконом класса
        /// </summary>
        [TableColumnAttribute("SeatingEconomy"), ListViewData("Seating Economy")]
        [MinMaxValue(0,1000)]
        public int SeatingEconomy { get; set; }
        #endregion

        #region public int SeatingEconomy { get; set; }
        /// <summary>
        /// Количество сидений бизнес класса
        /// </summary>
        [TableColumnAttribute("SeatingBusiness")]
        [ListViewData("Seating Business")]
        [MinMaxValue(0, 1000)]
        public int SeatingBusiness { get; set; }
        #endregion

        #region public int SeatingFirst { get; set; }
        /// <summary>
        /// Количество сидений первого класса
        /// </summary>
        [TableColumnAttribute("SeatingFirst")]
        [ListViewData("Seating First")]
        [MinMaxValue(0, 1000)]
        public int SeatingFirst { get; set; }
        #endregion

        #region public String Boiler { get; set; }
        /// <summary>
        /// Кол-во котлов
        /// </summary>
        [TableColumnAttribute("Boiler"), ListViewData("Boiler")]
        public String Boiler { get; set; }
        #endregion

        #region public String Oven { get; set; }
        /// <summary>
        /// Кол-во печек
        /// </summary>
        [TableColumnAttribute("Oven"), ListViewData("Oven")]
        public String Oven { get; set; }
        #endregion

        #region public String AirStairsDoors { get; set; }
        /// <summary>
        /// Кол-во дверей с лестницами
        /// </summary>
        [TableColumnAttribute("AirStairsDoors"), ListViewData("Air Stairs Doors")]
        public String AirStairsDoors { get; set; }
        #endregion

        #region public Int32 Tanks { get; set; }
        /// <summary>
        /// Топливные баки
        /// </summary>
        [TableColumnAttribute("Tanks"), ListViewData("Tanks")]
        [MinMaxValue(0, 8)]
        public Int32 Tanks { get; set; }
        #endregion


        /*
		*  Методы 
		*/

        public List<TemplateBaseComponent> BaseComponents { get; set; }
        public List<TemplateMaintenanceCheck> MaintenanceChecks { get; set; }
        /*
		*  Методы 
		*/

        #region public TemplateAircraft()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public TemplateAircraft()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Aircraft;

            ManufactureDate = DateTimeExtend.GetCASMinDateTime();
            MSG = MSG.Unknown;
            RegistrationNumber = "";
            BaseComponents = new List<TemplateBaseComponent>();
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Model.ToString();
        }


        #endregion

        #region public int CompareTo(TemplateAircraft y)

        public int CompareTo(TemplateAircraft y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

    #endregion
}
