using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
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
	public class Aircraft : BaseEntityObject, IComparable<Aircraft>, IComponentContainer
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
        public Int32 OperatorId { get; set; }
		/// <summary>
		/// ��� ���������� �����
		/// </summary>
        [TableColumnAttribute("AircraftTypeId")]
        public Int32 AircraftTypeId { get; set; }
        /// <summary>
        /// ��������������� ����� ��. �������� EX 001
        /// </summary>
        [TableColumnAttribute("RegistrationNumber")]
        [FormControl(120,"Reg. Num")]
        public String RegistrationNumber { get; set; }

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
            get { return _model ?? (_model = AircraftModel.Unknown); }
            set { _model = value; }
        }
		/// <summary>
		/// ����� �����������
		/// </summary>
        [TableColumnAttribute("TypeCertificateNumber")]
        public String TypeCertificateNumber { get; set; }
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
        public String SerialNumber { get; set; }
		/// <summary>
		/// ������������ ����� ��
		/// </summary>
        [TableColumnAttribute("VariableNumber")]
        public String VariableNumber { get; set; }
		/// <summary>
		/// �������� ����� ��
		/// </summary>
        [TableColumnAttribute("LineNumber")]
        public String LineNumber { get; set; }
		/// <summary>
		/// �������� ��
		/// </summary>
        [TableColumnAttribute("Owner")]
        public String Owner { get; set; }
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
        public String CargoCapacityContainer { get; set; }
		/// <summary>
		/// �������� Cruise
		/// </summary>
        [TableColumnAttribute("Cruise")]
        public String Cruise { get; set; }
		/// <summary>
		/// �������� Cruise Fuel Flow
		/// </summary>
        [TableColumnAttribute("CruiseFuelFlow")]
        public String CruiseFuelFlow { get; set; }
		/// <summary>
		/// �������� Fuel Capacity
		/// </summary>
        [TableColumnAttribute("FuelCapacity")]
        public String FuelCapacity { get; set; }
		/// <summary>
		/// �������� Max Cruise Altitude
		/// </summary>
        [TableColumnAttribute("MaxCruiseAltitude")]
        public String MaxCruiseAltitude { get; set; }
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
        public String CockpitSeating { get; set; }
		/// <summary>
		/// �������� Galleys
		/// </summary>
        [TableColumnAttribute("Galleys")]
        public String Galleys { get; set; }
		/// <summary>
		/// �������� Lavatory
		/// </summary>
        [TableColumnAttribute("Lavatory")]
        public String Lavatory { get; set; }
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
        public String Boiler { get; set; }
        /// <summary>
        /// ���-�� �����
        /// </summary>
        [TableColumnAttribute("Oven")]
        public String Oven { get; set; }
        /// <summary>
        /// ���-�� ������ � ����������
        /// </summary>
        [TableColumnAttribute("AirStairDoors")]
        public String AirStairsDoors { get; set; }
        /// <summary>
		/// ��������� ����
		/// </summary>
        [TableColumnAttribute("Tanks")]
        public Int32 Tanks { get; set; }
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
        public Int32 AircraftFrameId { get; set; }
        /// <summary>
        /// �������� AircraftAddress24Bit
        /// </summary>
        [TableColumnAttribute("AircraftAddress24Bit")]
        public String AircraftAddress24Bit { get; set; }
        /// <summary>
        /// �������� Max Zero Fuel Weight
        /// </summary>
        [TableColumnAttribute("ELTIdHexCode")]
        public String ELTIdHexCode { get; set; }
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
		    get { return _aircraftEquipmets ?? (_aircraftEquipmets = new List<AircraftEquipments>()); }
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
            get { return _maintenanceProgramChangeRecords ?? (_maintenanceProgramChangeRecords = new BaseRecordCollection<MaintenanceProgramChangeRecord>()); }
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
		public static Aircraft Unknown
	    {
		    get
		    {
				return _unknown ?? (_unknown = new Aircraft
				{
					RegistrationNumber = "N/A",
					ItemId = -1
				});
			}
	    }


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
