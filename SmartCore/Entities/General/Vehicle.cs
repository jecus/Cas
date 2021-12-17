using System;
using CAS.Entity.Models.DTO.General;
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
    /// ����� ��������� �������� ������������ ��������
    /// </summary>
    [Serializable]
    [Table("Vehicles", "dbo", "ItemId")]
    [Dto(typeof(VehicleDTO))]
	public class Vehicle : BaseEntityObject, IComparable<Vehicle>, IComponentContainer
	{

        /*
        * ��������
        */

        #region public Int32 OperatorId { get; set; }
        /// <summary>
		/// �����������, � �������� ��������� ��
		/// </summary>
        [TableColumnAttribute("OperatorId")]
        public Int32 OperatorId { get; set; }
		#endregion

        #region public String RegistrationNumber { get; set; }
        /// <summary>
        /// ��������������� ����� ��. �������� EX 001
        /// </summary>
        [TableColumnAttribute("RegistrationNumber")]
        [FormControl(120,"Reg. Num")]
        public String RegistrationNumber { get; set; }
        #endregion

        #region public AircraftModel Model { get; set; }

        private AircraftModel _model;
        /// <summary>
        /// ������ ��
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
		/// ���� ������������ �� 
		/// ����������� � ��, �� �� �����������
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
		/// �������� ��
		/// </summary>
        [TableColumnAttribute("Owner")]
        public String Owner { get; set; }
		#endregion

		#region public String CockpitSeating { get; set; }
		/// <summary>
		/// �������� Cockpit Seating
		/// </summary>
        [TableColumnAttribute("CockpitSeating")]
        public String CockpitSeating { get; set; }
		#endregion

		#region public DateTime DeliveryDate { get; set; }
		/// <summary>
		/// ���� �������� ���������� �����
		/// </summary>
        [TableColumnAttribute("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }
		#endregion

		#region public DateTime AcceptanceDate { get; set; }
		/// <summary>
		/// ���� �������� ���������� �����
		/// </summary>
        [TableColumnAttribute("AcceptanceDate")]
        public DateTime AcceptanceDate { get; set; }
		#endregion

        #region public Int32 VehicleFrameId { get; set; }
        /// <summary>
        /// Id �������� �������� Frame ��������
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
        /// ��������� ��� �� ��������� ������(true) ��� ���������� �� ���������(false)
        /// </summary>
        [TableColumnAttribute("Schedule")]
        public bool Schedule { get; set; }

        #endregion

        /*
         * ��������������, ����������� ��������
         */

        #region public Operator Operator { get; internal set; }

        private Operator _operator;

        /// <summary>
        /// ��������, �������� ����������� ��������� �����
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
        /// �������������������� ��������� 
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
		*  ������ 
		*/
		
		#region public Vehicle()
        /// <summary>
        /// ������� ������������ �������� ��� �������������� ����������
        /// </summary>
        public Vehicle()
        {
            ItemId = -1;
            VehicleFrameId = -1;

            //AverageUtilization = new AverageUtilization(150, 500);

            SmartCoreObjectType = SmartCoreType.Vehicle;
            // ������ ����, ��� ������� �� ������� ������ Insert

            // ��������� ������� � ���������
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
        /// ����������� ��� �������
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
         * ��������������� ������� ������������� �������� ��������� �� Frame
         */

		#region public BaseComponent Frame { get; internal set; }
		/// <summary>
		/// ���������� Frame ������� ���������� �����
		/// </summary>
		public BaseComponent Frame { get; internal set; }
        #endregion
    }
    #endregion
}
