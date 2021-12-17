using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General.Deprecated
{

    /// <summary>
    /// ����� ��������� ������� �����
    /// </summary>
    [Table("JobCards", "dbo", "ItemId")]
    [Dto(typeof(JobCardDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class JobCard : BaseEntityObject, IKitRequired
    {
        private static Type _thisType;
        /*
        *  ��������
        */

        #region public Int32 ParentId { get; set; }
        /// <summary>
		/// ������������� ��������
		/// </summary>
        [TableColumn("ParentId")]
        public Int32 ParentId { get; set; }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

		#endregion

        #region public SmartCoreType ParentType { get; set; }
        /// <summary>
        /// ������������� ��������
        /// </summary>
        [TableColumn("ParentTypeId")]
        public SmartCoreType ParentType { get; set; }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentTypeId"); }
        }

        #endregion

        #region public IDirective Parent

        private IDirective _parent;
        public IDirective Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    OnPropertyChanged("Parent");
                }

                if (_parent != null)
                {
                    ParentId = _parent.ItemId;
                    ParentType = _parent.SmartCoreObjectType;
                }
                else
                {
                    ParentId = -1;
                    ParentType = SmartCoreType.Unknown;
                }
            }
        }
        #endregion

        #region public String Form { get; set; }
        /// <summary>
        /// ����� ������� �����
        /// </summary>
        [TableColumn("Form")]
        public String Form { get; set; }
        #endregion

        #region public String FormRevision { get; set; }
        /// <summary>
        /// ������� ����� ������� �����
        /// </summary>
        [TableColumn("FormRevision")]
        public String FormRevision { get; set; }
        #endregion

        #region public DateTime FormDate { get; set; }
        /// <summary>
        /// ���� ����� ������� �����
        /// </summary>
        [TableColumn("FormDate")]
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
        [TableColumn("JobCardDate")]
        public DateTime JobCardDate { get; set; }
        #endregion

        #region public String JobCardRevision { get; set; }
        /// <summary>
        /// ������� ������� �����
        /// </summary>
        [TableColumn("JobCardRevision")]
        public String JobCardRevision { get; set; }
        #endregion

        #region public DateTime JobCardRevisionDate { get; set; }
        /// <summary>
        /// ���� ������� ������� �����
        /// </summary>
        [TableColumn("JobCardRevisionDate")]
        public DateTime JobCardRevisionDate { get; set; }
        #endregion

        #region public String Title { get; set; }
        /// <summary>
        /// �������� ������� �����
        /// </summary>
        [TableColumn("Title")]
        public String Title { get; set; }
        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// �������� ������� �����
        /// </summary>
        [TableColumn("Description")]
        public String Description { get; set; }
        #endregion

        #region public AtaChapter AtaChapter { get; set; }
        /// <summary>
        /// Ata-�����
        /// </summary>
        [TableColumn("AtaChapter")]
        public AtaChapter AtaChapter { get; set; }
        #endregion

        #region public String Zone { get; set; }
        /// <summary>
        /// ���� �� ��, ��� ����� ����������� ������ �� �����
        /// </summary>
        [TableColumn("Zone")]
        public String Zone { get; set; }
        #endregion

        #region public String Access { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Access")]
        public String Access { get; set; }
        #endregion

        #region public String Station { get; set; }
        /// <summary>
        /// ������� ������������ ��
        /// </summary>
        [TableColumn("Station")]
        public String Station { get; set; }
        #endregion

        #region public String MRO { get; set; }
        /// <summary>
        /// ����������� ������������ ��
        /// </summary>
        [TableColumn("MRO")]
        public String MRO { get; set; }
        #endregion

        #region public String Phase { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [TableColumn("Phase")]
        public String Phase { get; set; }
        #endregion

        #region public String WorkArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("WorkArea")]
        public String WorkArea { get; set; }
        #endregion

        #region public String Applicability { get; set; }
        /// <summary>
        /// ������������ ������� �����
        /// </summary>
        [TableColumn("Applicability")]
        public String Applicability { get; set; }
        #endregion

        #region public RefDocType MaintenanceManual { get; set; }
        /// <summary>
        /// ������ �� ������������ ��
        /// </summary>
        [TableColumn("RefDocType")]
        public RefDocType MaintenanceManual { get; set; }
        #endregion

        #region public String MaintenanceManualRevision { get; set; }
        /// <summary>
        /// ������� ������� �� ������������ ��
        /// </summary>
        [TableColumn("MaintenanceManualRevision")]
        public String MaintenanceManualRevision { get; set; }
        #endregion

        #region public DateTime MaintenanceManualRevisionDate { get; set; }
        /// <summary>
        /// ���� ������� ������� �� ������������ ��
        /// </summary>
        [TableColumn("MaintenanceManualRevisionDate")]
        public DateTime MaintenanceManualRevisionDate { get; set; }
        #endregion

        #region public MaintenanceDirectiveTaskType WorkType { get; set; }
        /// <summary>
        /// ��� ���������
        /// </summary>
        [TableColumnAttribute("DirectiveTypeId"), ListViewData("Directive Type")]
        [Filter("Work Type:", Order = 7)]
        public MaintenanceDirectiveTaskType WorkType { get; set; }
        #endregion

        #region public AircraftWorkerCategory Qualification { get; set; }
        /// <summary>
        /// ����������� ������������ ��������� ��� ��������� ������� �����
        /// </summary>
        [TableColumn("Qualification")]
        public AircraftWorkerCategory Qualification { get; set; }
        #endregion

        #region public int Man { get; set; }
        /// <summary>
        /// ���-�� ������� ��� ���������� ������� �����
        /// </summary>
        [TableColumn("Man"), MinMaxValueAttribute(1, 1000)]
        public int Man { get; set; }
        #endregion

        #region public Double ManHours { get; set; }
        /// <summary>
        /// �������� �����������
        /// </summary>
        [TableColumn("ManHours"), MinMaxValueAttribute(0, 1000000)]
        public Double ManHours { get; set; }
        #endregion

        #region public Double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Cost"), MinMaxValueAttribute(0, 1000000000)]
        public Double Cost { get; set; }
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

        #region public CommonCollection<JobCardTask> JobCardTasks

        private CommonCollection<JobCardTask> _jobCardTasks;

        [Child(RelationType.OneToMany, "JobCardId", "JobCard")]
        public CommonCollection<JobCardTask> JobCardTasks
        {
            get { return _jobCardTasks ?? (_jobCardTasks = new CommonCollection<JobCardTask>()); }
            internal set
            {
                if (_jobCardTasks != value)
                {
                    if (_jobCardTasks != null)
                        _jobCardTasks.Clear();
                    if (value != null)
                    {
                        List<JobCardTask> jcts = value.ToList();
                        value.Clear();

                        value.AddRange(jcts.Where(jct => jct.ParentTaskId <= 0));

                        IEnumerable<JobCardTask> previosTreeLevel = value;
                        List<JobCardTask> nextTreeLevel = new List<JobCardTask>();

                        while (previosTreeLevel.Any())
                        {
                            nextTreeLevel.Clear();

                            foreach (JobCardTask cardTask in previosTreeLevel)
                            {
                                cardTask.Tasks.Clear();
                                cardTask.Tasks.AddRange(jcts.Where(jct => jct.ParentTaskId == cardTask.ItemId));
                                foreach (JobCardTask subTask in cardTask.Tasks)
                                    subTask.ParentTask = cardTask;
                           
                                nextTreeLevel.AddRange(cardTask.Tasks);
                            }

                            previosTreeLevel = nextTreeLevel.ToArray();
                        }
                        _jobCardTasks = value;
                    }
                }
            }
        }
        #endregion

        #region public String JobCardFooter { get; set; }
        /// <summary>
        /// ������ ��������� ������� �����
        /// </summary>
        [TableColumn("JobCardFooter")]
        public String JobCardFooter { get; set; }
        #endregion

        /*
		*  ������ 
		*/

        #region public JobCard()
        /// <summary>
        /// ������� ��������� ����� ��� �������������� ����������
        /// </summary>
        public JobCard()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.JobCard;

            ApprovedByDate = DateTime.Today;
            CheckedByDate = DateTime.Today;
            FormDate = DateTime.Today;
            JobCardDate = DateTime.Today;
            JobCardRevisionDate = DateTime.Today;
            MaintenanceManualRevisionDate = DateTime.Today;
            PreparedByDate = DateTime.Today;

            JobCardTasks.Add(new JobCardTask());

            Man = 1;
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

        #region public new JobCard GetCopyUnsaved()

        public new JobCard GetCopyUnsaved(bool marked = true)
        {
            JobCard jobCard = (JobCard) MemberwiseClone();
            jobCard.ItemId = -1;
            jobCard.UnSetEvents();

            jobCard.JobCardTasks = new CommonCollection<JobCardTask>();
            foreach (JobCardTask jobCardTask in JobCardTasks)
            {
                JobCardTask newObject = jobCardTask.GetCopyUnsaved(marked);
                jobCard.JobCardTasks.Add(newObject);
            }

            return jobCard;
        }

        #endregion


    }

}
