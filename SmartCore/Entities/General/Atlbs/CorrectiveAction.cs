using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{
    #region public enum CorrectiveActionStatus
    /// <summary>
    /// ������ ���������� ��������������� ��������
    /// </summary>
    public enum CorrectiveActionStatus
    {
        /// <summary>
        /// �������������� �������� �� ���������
        /// </summary>
        Open = 0,
        /// <summary>
        /// �������������� �������� ���������
        /// </summary>
        Close = 1,
        Publish = 2
    }
	#endregion

	/// <summary>
	/// ����� ��������� ��������� �����
	/// </summary>
	//TODO:(Evgenii Babak) ����������� � ������������ ������� ������
	[Serializable]
	[Table("CorrectiveActions", "dbo", "ItemId")]
	[Dto(typeof(CorrectiveActionDTO))]
	public class CorrectiveAction : BaseEntityObject
    {
        /// <summary>
        /// ��������� ������������ � ������� ������������
        /// </summary>
        private BaseRecordCollection<CertificateOfReleaseToService> _releaseToServiceCollection;
	    private static Type _thisType;
		private CertificateOfReleaseToService _releaseToService;

		/*
		*  ��������
		*/

        #region public CorrectiveAction Status
        /// <summary>
        /// ������ ���������� ��������������� ��������
        /// </summary>
        private CorrectiveActionStatus _status;
        /// <summary>
        /// ������ ���������� ��������������� ��������
        /// </summary>
        public CorrectiveActionStatus Status
        {
            get { return _status; }
            set
            {
            //    ModificationApplied(_Status, value);
                _status = value;
            }
        }
        #endregion

		#region public Int32 DiscrepancyID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("DiscrepancyID")]
		public int DiscrepancyId { get; set; }


	    public static PropertyInfo DiscrepancyIdProperty
		{
		    get { return GetCurrentType().GetProperty("DiscrepancyId"); }
	    }


		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Description")]
		public string Description { get; set; }
		#endregion

		#region public String ShortDescription { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ShortDescription")]
		public string ShortDescription { get; set; }
		#endregion

		#region public String ADDNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ADDNo")]
		public string AddNo { get; set; }
		#endregion

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("IsClosed")]
		public bool IsClosed { get; set; }
		#endregion

		#region public String PartNumberOff { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("PartNumberOff")]
		public string PartNumberOff { get; set; }
		#endregion

		#region public String SerialNumberOff { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("SerialNumberOff")]
		public string SerialNumberOff { get; set; }
		#endregion

		#region public String PartNumberOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("PartNumberOn")]
		public string PartNumberOn { get; set; }
		#endregion

		#region public String SerialNumberOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("SerialNumberOn")]
		public String SerialNumberOn { get; set; }
		#endregion

		#region public Int32 CRSID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CRSID")]
		public int CRSID { get; set; }
		#endregion

        #region private void AddReleaseToService()
        /// <summary>
        /// ���������� ReleaseToService � ���� ������
        /// </summary>
        private void AddReleaseToService(CertificateOfReleaseToService releaseToService)
        {
            _releaseToServiceCollection.Add(releaseToService);
         //   ((ICRSContains)this).CRSID = _releaseToService.ID;
        }

        #endregion
        
        #region public CertificateOfReleaseToService CertificateOfReleaseToService
        /// <summary>
        /// C��������� � ������� � ������������
        /// </summary>
        public CertificateOfReleaseToService CertificateOfReleaseToService
        {
            get
            {
                return GetReleaseToService();
            }
            set
            {
                SetReleaseToService(value);
            }
        }

		#endregion

		/*
		*  ������ 
		*/

		#region private static Type GetCurrentType()
	    private static Type GetCurrentType()
	    {
		    return _thisType ?? (_thisType = typeof(CorrectiveAction));
	    }
	    #endregion

		#region public CorrectiveAction()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public CorrectiveAction()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.CorrectiveAction;
        }
        #endregion

        #region private CertificateOfReleaseToService GetReleaseToService()
        /// <summary>
        /// ���������� CorrectiveAction � ���������� �� ������� �������������� � ���� ������
        /// </summary>
        /// <returns></returns>
        private CertificateOfReleaseToService GetReleaseToService()
        {
            if (_releaseToServiceCollection == null)
                _releaseToServiceCollection = new BaseRecordCollection<CertificateOfReleaseToService>();
            if (_releaseToService == null)
            {
                if (_releaseToServiceCollection.Count == 0)
                {
                    _releaseToService = new CertificateOfReleaseToService();
                    AddReleaseToService(_releaseToService);
                }
                else
                {
                    _releaseToService = _releaseToServiceCollection[0];
                }
            }
            return _releaseToService;
        }

        #endregion

        #region private void SetReleaseToService(CertificateOfReleaseToService _releaseToService)
        /// <summary>
        /// ���������� ReleaseToService � CorrectiveAction � ��������� �� ������������� �������(this) ������ � ���� ������
        /// </summary>
        /// <param name="releaseToService"></param>
        private void SetReleaseToService(CertificateOfReleaseToService releaseToService)
        {
            if (_releaseToServiceCollection == null)
                _releaseToServiceCollection = new BaseRecordCollection<CertificateOfReleaseToService>();
            if (releaseToService != null)
            {
                if (_releaseToService != null || _releaseToServiceCollection.Count > 0)
                {
                //    releaseToServiceCollection.Clear();
                    AddReleaseToService(releaseToService);
                }
                else
                    AddReleaseToService(releaseToService);
            }
        }

        #endregion
      
        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   

    }

}
