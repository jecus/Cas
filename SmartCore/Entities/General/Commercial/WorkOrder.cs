using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Packages;

namespace SmartCore.Entities.General.Commercial
{

    /// <summary>
    /// ����� ��������� ������� �����
    /// </summary>
    [Table("WorkOrders", "dbo", "ItemId")]
    [Dto(typeof(WorkOrderDTO))]
	[Condition("IsDeleted", "0")]
    public class WorkOrder : AbstractDirectivePackage<WorkOrderRecord>, IKitRequired//, IDirectivePackage
    {
        private static Type _thisType;
        /*
        *  ��������
        */

        #region public String Form { get; set; }
        /// <summary>
        /// ����� ������� �����
        /// </summary>
        //[TableColumn("Form")]
        public String Form { get; set; }
        #endregion

        #region public String FormRevision { get; set; }
        /// <summary>
        /// ������� ����� ������� �����
        /// </summary>
        //[TableColumn("FormRevision")]
        public String FormRevision { get; set; }
        #endregion

        #region public DateTime FormDate { get; set; }
        /// <summary>
        /// ���� ����� ������� �����
        /// </summary>
        //[TableColumn("FormDate")]
        public DateTime FormDate { get; set; }
        #endregion

        #region public DateTime PreparedByDate { get; set; }
        /// <summary>
        /// ���� ���������� ������� �����
        /// </summary>
        [TableColumn("PreparedByDate")]
        public DateTime PreparedByDate { get; set; }
        #endregion

        #region public Specialist PreparedBy { get; set; }
        /// <summary>
        /// ���������, ������������� ������� �����
        /// </summary>
        [TableColumn("PreparedById")]
        //[Child]
        public Specialist PreparedBy { get; set; }
        #endregion

        #region public DateTime CheckedByDate { get; set; }
        /// <summary>
        /// ���� �������� ������� �����
        /// </summary>
        [TableColumn("CheckedByDate")]
        public DateTime CheckedByDate { get; set; }
        #endregion

        #region public Specialist CheckedBy { get; set; }
        /// <summary>
        /// ���������, ����������� ������� �����
        /// </summary>
        [TableColumn("CheckedById")]
        //[Child]
        public Specialist CheckedBy { get; set; }
        #endregion

        #region public DateTime ApprovedByDate { get; set; }
        /// <summary>
        /// ���� ������� ������� �����
        /// </summary>
        [TableColumn("ApprovedByDate")]
        public DateTime ApprovedByDate { get; set; }
        #endregion

        #region public Specialist ApprovedBy { get; set; }
        /// <summary>
        /// ���������, ����������� ������� �����
        /// </summary>
        [TableColumn("ApprovedById")]
        //[Child]
        public Specialist ApprovedBy { get; set; }
        #endregion

        #region public String JobCardNumber { get; set; }
        /// <summary>
        /// ����� ������� �����
        /// </summary>
        [TableColumn("JobCardNumber")]
        public String JobCardNumber { get; set; }
        #endregion

        #region public String JobCardHeader { get; set; }
        /// <summary>
        /// ��������� ������� �����
        /// </summary>
        [TableColumn("JobCardHeader")]
        public String JobCardHeader{ get; set; }
        #endregion

        //#region public String AircraftRegistrationNumber { get; set; }
        ///// <summary>
        ///// ��������������� ����� ��, ��� �������� ������� �����
        ///// </summary>
        //public String AircraftRegistrationNumber { get; set; }
        //#endregion

        //#region public AircraftModel AircraftModel { get; set; }
        ///// <summary>
        ///// ������ �� ��� �������� ������� ������� �����
        ///// </summary>
        //public AircraftModel AircraftModel { get; set; }
        //#endregion

        #region public DateTime JobCardDate { get; set; }
        /// <summary>
        /// ���� ������ ������� �����
        /// </summary>
        //[TableColumn("JobCardDate")]
        public DateTime JobCardDate { get; set; }
        #endregion

        #region public String JobCardRevision { get; set; }
        /// <summary>
        /// ������� ������� �����
        /// </summary>
        //[TableColumn("JobCardRevision")]
        public String JobCardRevision { get; set; }
        #endregion

        #region public DateTime JobCardRevisionDate { get; set; }
        /// <summary>
        /// ���� ������� ������� �����
        /// </summary>
        //[TableColumn("JobCardRevisionDate")]
        public DateTime JobCardRevisionDate { get; set; }
        #endregion

        #region Implement of IKitRequired

        #region public string KitParentString { get; }
        /// <summary>
        /// ���������� ������ ��� �������� �������� ����
        /// </summary>
        public string KitParentString
        {
            get { return $"Dir.:{Title}:{Description}"; }
        }
        #endregion

        #region public CommonCollection<AccessoryRequired> Kits

        private CommonCollection<AccessoryRequired> _kits;

        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1450, "ParentObject")]
        public CommonCollection<AccessoryRequired> Kits
        {
            get { return _kits ?? (_kits = new CommonCollection<AccessoryRequired>()); }
            internal set
            {
                if (_kits != value)
                {
                    if (_kits != null)
                        _kits.Clear();
                    if (value != null)
                        _kits = value;
                }
            }
        }
        #endregion

        #endregion

        #region public override CommonCollection<WorkOrderRecord> PakageRecords { get; }

        private CommonCollection<WorkOrderRecord> _packageRecords;
        /// <summary>
        /// ��������� ������ ��������� ��� �������� �������� � �������� ������
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentPackage", false)]
        public override CommonCollection<WorkOrderRecord> PackageRecords
        {
            get { return _packageRecords ?? (_packageRecords = new CommonCollection<WorkOrderRecord>()); }
            internal set
            {
                if (_packageRecords != value)
                {
                    if (_packageRecords != null)
                        _packageRecords.Clear();
                    if (value != null)
                        _packageRecords = value;
                }
            }
        }

        #endregion

        #region public String WorkOrderFooter { get; set; }
        /// <summary>
        /// ������ ��������� ������� �����
        /// </summary>
        [TableColumn("WorkOrderFooter")]
        public String WorkOrderFooter { get; set; }
        #endregion

        /*
		*  ������ 
		*/

        #region public WorkOrder()
        /// <summary>
        /// ������� ��������� ����� ��� �������������� ����������
        /// </summary>
        public WorkOrder()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.JobCard;

            ApprovedByDate = DateTime.Today;
            CheckedByDate = DateTime.Today;
            FormDate = DateTime.Today;
            JobCardDate = DateTime.Today;
            JobCardRevisionDate = DateTime.Today;
            PreparedByDate = DateTime.Today;

            Status = WorkPackageStatus.Opened;

            CreateDate = OpeningDate = PublishingDate = ClosingDate = DateTime.Today;

        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(JobCard));
        }
        #endregion
      
        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Title;
        }
        #endregion   

    }

}
