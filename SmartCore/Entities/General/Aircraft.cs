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
    /// ����� ��������� ��������� �����
    /// </summary>
    [Serializable]
    [Table("Aircrafts", "dbo", "ItemId")]
    [Condition("IsDeleted", "0")]
	[Dto(typeof(AircraftDTO))]
	[CAADto(typeof(CAAAircraftDTO))]
	public class Aircraft : BaseEntityObject, IComparable<Aircraft>, IComponentContainer, IAircraftFilter
    {

        /*
        * ��������
        */
		[TableColumn("APUFH")]
		public double APUFH { get; set; }

		/// <summary>
		/// �����������, � �������� ��������� ��
		/// </summary>
		[TableColumnAttribute("OperatorId")]
        public int OperatorId { get; set; }
		/// <summary>
		/// ��� ���������� �����
		/// </summary>
        [TableColumnAttribute("AircraftTypeId")]
        public int AircraftTypeId { get; set; }
        /// <summary>
        /// ��������������� ����� ��. �������� EX 001
        /// </summary>
        [TableColumnAttribute("RegistrationNumber")]
        [FormControl(120,"Reg. Num")]
        public string RegistrationNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
        private AircraftModel _model;
        /// <summary>
        /// ������ ���������� �����
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
		/// ����� �����������
		/// </summary>
        [TableColumnAttribute("TypeCertificateNumber")]
        public string TypeCertificateNumber { get; set; }
		/// <summary>
		/// ���� ������������ �� 
		/// ����������� � ��, �� �� �����������
		/// </summary>
        [TableColumn("ManufactureDate")]
        public DateTime ManufactureDate { get; set; }
		/// <summary>
		/// �������� (���������) ����� ��
		/// </summary>
        [TableColumnAttribute("SerialNumber")]
        public string SerialNumber { get; set; }
		/// <summary>
		/// ������������ ����� ��
		/// </summary>
        [TableColumnAttribute("VariableNumber")]
        public string VariableNumber { get; set; }
		/// <summary>
		/// �������� ����� ��
		/// </summary>
        [TableColumnAttribute("LineNumber")]
        public string LineNumber { get; set; }
		/// <summary>
		/// �������� ��
		/// </summary>
        [TableColumnAttribute("Owner")]
        public string Owner { get; set; }
        /// <summary>
		/// �������� Basic Empty Weight
		/// </summary>
        [TableColumnAttribute("BasicEmptyWeight")]
        public double BasicEmptyWeight { get; set; }
        /// <summary>
		/// �������� Basic Empty Weight Cargo Config
		/// </summary>
        [TableColumnAttribute("BasicEmptyWeightCargoConfig")]
        public double BasicEmptyWeightCargoConfig { get; set; }
        /// <summary>
        /// �������� OperationalEmptyWeight
        /// </summary>
        [TableColumnAttribute("OperationalEmptyWeight")]
        public double OperationalEmptyWeight { get; set; }
		/// <summary>
		/// �������� Cargo Capacity Container
		/// </summary>
        [TableColumnAttribute("CargoCapacityContainer")]
        public string CargoCapacityContainer { get; set; }
		/// <summary>
		/// �������� Cruise
		/// </summary>
        [TableColumnAttribute("Cruise")]
        public string Cruise { get; set; }
		/// <summary>
		/// �������� Cruise Fuel Flow
		/// </summary>
        [TableColumnAttribute("CruiseFuelFlow")]
        public string CruiseFuelFlow { get; set; }
		/// <summary>
		/// �������� Fuel Capacity
		/// </summary>
        [TableColumnAttribute("FuelCapacity")]
        public string FuelCapacity { get; set; }
		/// <summary>
		/// �������� Max Cruise Altitude
		/// </summary>
        [TableColumnAttribute("MaxCruiseAltitude")]
        public string MaxCruiseAltitude { get; set; }
        /// <summary>
		/// �������� Max Landing Weight
		/// </summary>
        [TableColumnAttribute("MaxLandingWeight")]
        public double MaxLandingWeight { get; set; }
        /// <summary>
        /// �������� MaxPayloadWeight
        /// </summary>
        [TableColumnAttribute("MaxPayloadWeight")]
        public double MaxPayloadWeight { get; set; }
        /// <summary>
		/// �������� Max Take Off Cross Weight
		/// </summary>
        [TableColumnAttribute("MaxTakeOffCrossWeight")]
        public double MaxTakeOffCrossWeight { get; set; }
        /// <summary>
        /// �������� MaxTaxiWeight
        /// </summary>
        [TableColumnAttribute("MaxTaxiWeight")]
        public double MaxTaxiWeight { get; set; }
        /// <summary>
		/// �������� Max Zero Fuel Weight
		/// </summary>
        [TableColumnAttribute("MaxZeroFuelWeight")]
        public double MaxZeroFuelWeight { get; set; }
		/// <summary>
		/// �������� Cockpit Seating
		/// </summary>
        [TableColumnAttribute("CockpitSeating")]
        public string CockpitSeating { get; set; }
		/// <summary>
		/// �������� Galleys
		/// </summary>
        [TableColumnAttribute("Galleys")]
        public string Galleys { get; set; }
		/// <summary>
		/// �������� Lavatory
		/// </summary>
        [TableColumnAttribute("Lavatory")]
        public string Lavatory { get; set; }
        /// <summary>
		/// ���������� ������� ������ ������
		/// </summary>
        [TableColumnAttribute("SeatingEconomy")]
        public int SeatingEconomy { get; set; }
        /// <summary>
        /// ���������� ������� ������ ������
        /// </summary>
        [TableColumnAttribute("SeatingBusiness")]
        public int SeatingBusiness { get; set; }
        /// <summary>
        /// ���������� ������� ������� ������
        /// </summary>
        [TableColumnAttribute("SeatingFirst")]
        public int SeatingFirst { get; set; }
        /// <summary>
        /// ���-�� ������
        /// </summary>
        [TableColumnAttribute("Boiler")]
        public string Boiler { get; set; }
        /// <summary>
        /// ���-�� �����
        /// </summary>
        [TableColumnAttribute("Oven")]
        public string Oven { get; set; }
        /// <summary>
        /// ���-�� ������ � ����������
        /// </summary>
        [TableColumnAttribute("AirStairDoors")]
        public string AirStairsDoors { get; set; }
        /// <summary>
		/// ��������� ����
		/// </summary>
        [TableColumnAttribute("Tanks")]
        public int Tanks { get; set; }
		/// <summary>
		/// ���� �������� ���������� �����
		/// </summary>
        [TableColumnAttribute("DeliveryDate")]
        public DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// ���� �������� ���������� �����
		/// </summary>
        [TableColumnAttribute("AcceptanceDate")]
        public DateTime? AcceptanceDate { get; set; }
        /// <summary>
        /// Id �������� �������� Frame ��������
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
        /// �������� AircraftAddress24Bit
        /// </summary>
        [TableColumnAttribute("AircraftAddress24Bit")]
        public string AircraftAddress24Bit { get; set; }
        /// <summary>
        /// �������� Max Zero Fuel Weight
        /// </summary>
        [TableColumnAttribute("ELTIdHexCode")]
        public string ELTIdHexCode { get; set; }
        /// <summary>
        /// ��������� ��� �� ��������� ������(true) ��� ���������� �� ���������(false)
        /// </summary>
        [TableColumnAttribute("Schedule")]
        public bool Schedule { get; set; }
        /// <summary>
        /// ��������� ��� ������������ ������������ ����� ��������� ������������
        /// <br/> false - �� ������������ ����� ����
        /// <br/> true - �� ����������� ������
        /// </summary>
        [TableColumnAttribute("CheckNaming")]
        public bool MaintenanceProgramCheckNaming { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("MSG")]
        public MSG MSG { get; set; }
        /// <summary>
        /// ��������� ���� ��
        /// </summary>
        [TableColumnAttribute("NoiceCategory")]
        public int NoiceCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FADEC")]
        public bool FADEC { get; set; }
        /// <summary>
        /// ��������� ������� ��
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
         * ��������������, ����������� ��������
         */

	    /*
		*  ������ 
		*/

	    /// <summary>
	    /// ������� ��������� ����� ��� �������������� ����������
	    /// </summary>
	    public Aircraft()
        {
            ItemId = -1;
            AircraftFrameId = -1;
            MSG = MSG.Unknown;
            Brakes = Brakes.Carbon;
            //AverageUtilization = new AverageUtilization(150, 500);

            SmartCoreObjectType = SmartCoreType.Aircraft;
            // ������ ����, ��� ������� �� ������� ������ Insert
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
            // ��������� ������� � ���������
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
        /// ����������� ��� �������
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
         * ��������������� ������� ���������� ����� ��������� �� Frame
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
