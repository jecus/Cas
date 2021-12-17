using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General.Atlbs
{
    #region public enum DiscrepancyFilledByEnum
    /// <summary>
    /// ������������, ��� ���� ���������� ����������. 
    /// Crew = true
    /// MaintenanceStaff = false
    /// </summary>
    public enum DiscrepancyFilledByEnum
    {
        /// <summary>
        /// ���������� ���� ���������� ��������
        /// </summary>
        Crew  = 0,
        /// <summary>
        /// ���������� ���� ���������� ����������� ����������
        /// </summary>
        MaintenanceStaff = 1
    }
    #endregion

    /// <summary>
    /// ����� ��������� ��������� �����
    /// </summary>
    [Serializable]
    [Table("Discrepancies", "dbo", "ItemId")]
    [Dto(typeof(DiscrepancyDTO))]
	[Condition("IsDeleted", "0")]
    public class Discrepancy : BaseEntityObject, IOccurenceFilterParams
	{
        private static Type _thisType;

        private CorrectiveAction _correctiveAction;
        /*
        *  ��������
        */
        #region public Int32 Num { get; set; }
        /// <summary>
        /// ���������� ����� �������
        /// </summary>
        [TableColumnAttribute("Num")]
        public Int32 Num { get; set; }

        #endregion

        #region public Int32 FlightId { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("FlightId")]
        public Int32 FlightId { get; set; }

        /// <summary>
        /// ���������� �������� FlightId (������������� ������������� ������)
        /// </summary>
        public static PropertyInfo FlightIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightId"); }
        }

		#endregion

        #region public Int32 DirectiveId { get; set; }
        [TableColumnAttribute("DirectiveId")]
        public Int32 DirectiveId { get; set; }

        /// <summary>
        /// ���������� �������� DirectiveId (������������� ������-����������)
        /// </summary>
        public static PropertyInfo DirectiveIdProperty
        {
            get { return GetCurrentType().GetProperty("DirectiveId"); }
        }

        #endregion

        #region public Boolean FilledBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FilledBy")]
        public Boolean FilledBy { get; set; }

        [ListViewData(80, "Filled By")]
        public String FilledByString
        {
            get { return FilledBy == false ? "Crew" : "Maintenance Staff"; }
        }

        #endregion

		#region public String Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Description")]
        [ListViewData(120, "Description", 2)]
        public String Description { get; set; }
		#endregion

		#region public String PilotRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("PilotRemarks")]
        public String PilotRemarks { get; set; }
		#endregion

		#region public int WorkPackageId { get; set; }

		[TableColumn("WorkPackageId")]
	    public int WorkPackageId { get; set; }

	    public static PropertyInfo WorkPackageIdProperty
		{
		    get { return GetCurrentType().GetProperty("WorkPackageId"); }
	    }

		#endregion

		#region public bool IsReliability { get; set; }

		[TableColumn("IsReliability")]
	    public bool IsReliability { get; set; }

	    public static PropertyInfo IsReliabilityProperty
		{
		    get { return GetCurrentType().GetProperty("IsReliability"); }
	    }

		#endregion

		#region public ATAChapter ATAChapter
		/// <summary>
		/// ATA �����, � ������� ��������� ����������
		/// </summary>
		private AtaChapter _ataChapter;

	    private Specialist _auth;

	    /// <summary>
        /// ATA �����, � ������� ��������� ����������
        /// </summary>
        [ListViewData(80, "ATA", 1)]
        [TableColumnAttribute("ATAChapterId")]
        public AtaChapter ATAChapter
        {
            get { return _ataChapter; }
            set
            {
                _ataChapter = value;
            }
        }
		#endregion

	    [TableColumnAttribute("Deffe�tPhase")]
		public Deffe�tPhase Deffe�tPhase { get; set; }

	    [TableColumnAttribute("Deffe�tCategory")]
		public Deffe�tCategory Deffe�tCategory { get; set; }

		[TableColumnAttribute("DeffectConfirm")]
		public DeffectConfirm DeffectConfirm { get; set; }

	    [TableColumnAttribute("ActionType")]
		public ActionType ActionType { get; set; }

	    [TableColumnAttribute("ConsequenceOps")]
		public ConsequenceOPS ConsequenceOps { get; set; }

	    [TableColumnAttribute("ConsequenceFault")]
		public ConsequenceFaults ConsequenceFault { get; set; }

	    [TableColumnAttribute("ConsequenceType")]
		public IncidentType ConsequenceType { get; set; }

	    [TableColumnAttribute("InterruptionType")]
		public InterruptionType InterruptionType { get; set; }


	    [TableColumnAttribute("Occurrence")]
		public OccurrenceType Occurrence { get; set; }

	    [TableColumn("IsOccurrence")]
	    public bool IsOccurrence { get; set; }

	    public static PropertyInfo IsOccurrenceProperty
		{
		    get { return GetCurrentType().GetProperty("IsOccurrence"); }
	    }

		[TableColumn("Substruction")]
	    public bool Substruction { get; set; }

	    [TableColumn("EngineShutUp")]
	    public bool EngineShutUp { get; set; }

	    [TableColumn("TimeDelay")]
	    public int TimeDelay { get; set; }

	    [TableColumn("Remarks")]
	    public string Remark { get; set; }

	    [TableColumn("EngineRemarks")]
	    public string EngineRemarks { get; set; }

	    [TableColumn("Messages")]
	    public string Messages { get; set; }

	    [TableColumn("FDR")]
	    public string FDR { get; set; }

	    [TableColumn("BaseComponentId")]
	    public int BaseComponentId { get; set; }

	    [TableColumn("Auth")]
	    public Specialist Auth
	    {
		    get { return _auth ?? Specialist.Unknown; }
		    set { _auth = value; }
	    }


	    #region public CorrectiveActionCollection CorrectiveActionCollection { get; set; }

		public CorrectiveActionCollection CorrectiveActionCollection { get; set; }
        #endregion

        #region public CorrectiveAction CorrectiveAction
        /// <summary>
        /// �������������� �������� ��� ������� ����������
        /// </summary>
        public CorrectiveAction CorrectiveAction
        {
            get
            {
                return GetCorrectiveAction();
            }
            set
            {
                SetCorrectiveAction(value);
            }
        }
        #endregion
        
        #region public string CorrectiveActionDescription { get; }
        /// <summary>
        /// ����� ��������������� ��������
        /// </summary>
        [ListViewData(0.1f, "Corr. Action")]
        public string CorrectiveActionDescription
        {
            get
            {
                return string.IsNullOrEmpty(CorrectiveAction.Description) ? "No" : CorrectiveAction.Description;
            }
        }

        #endregion

        #region public string CorrectiveActionAddNo { get; }
        /// <summary>
        /// ����� ��������������� ��������
        /// </summary>
        [ListViewData(0.1f, "Corr. Action Add�")]
        public string CorrectiveActionAddNo
        {
            get
            {
                return string.IsNullOrEmpty(CorrectiveAction.AddNo) ? "No" : CorrectiveAction.AddNo;
            }
        }

        #endregion

        public Aircraft Aircraft { get; set; }

		public AircraftModel Model
		{
			get { return Aircraft != null ? Aircraft.Model : AircraftModel.Unknown; }
		}

		public string PageNo
		{
			get { return ParentFlight?.PageNo ?? ""; }
		}

		public AirportsCodes StationTo
		{
			get { return ParentFlight?.StationToId ?? AirportsCodes.Unknown; }
		}

		public string MRO
		{
			get { return CertificateOfReleaseToService?.Station ?? ""; }
		}

		public string PartNumberOff
		{
			get { return CorrectiveAction?.PartNumberOff ?? ""; }
		}

		public string SerialNumberOff
		{
			get { return CorrectiveAction?.SerialNumberOff ?? ""; }
		}

		public string PartNumberOn
		{
			get { return CorrectiveAction?.PartNumberOn ?? ""; }
		}

		public string SerialNumberOn
		{
			get { return CorrectiveAction?.SerialNumberOn ?? ""; }
		}

		public bool HasFDR
		{
			get { return !string.IsNullOrEmpty(FDR); }
		}


		#region public CertificateOfReleaseToService CertificateOfReleaseToService { get;}
		/// <summary>
		/// ������ �� ���������� ������������ ���������� �����
		/// </summary>
		public CertificateOfReleaseToService CertificateOfReleaseToService
        {
            get
            {
                if (CorrectiveAction == null) return null; // Aleksey
                return CorrectiveAction.CertificateOfReleaseToService;
            }
        }
        #endregion

        #region public string CertificateOfReleaseToServiceStation { get; }
        /// <summary>
        /// ����� ����������� ����������
        /// </summary>
        [ListViewData(60, "Station")]
        public string CertificateOfReleaseToServiceStation
        {
            get
            {
                return CertificateOfReleaseToService.Station;
            }
        }

        #endregion

        #region public string CertificateOfReleaseToServiceMRO { get; }
        /// <summary>
        /// �����������, ������������� ���������� �������
        /// </summary>
        [ListViewData(80, "MRO")]
        public string CertificateOfReleaseToServiceMRO
        {
            get
            {
                return CertificateOfReleaseToService.MRO;
            }
        }

        #endregion

        #region public DateTime? CertificateOfReleaseToServiceRecordDate { get; set; }
        /// <summary>
        /// ���� ���������� �������
        /// </summary>
        [ListViewData(0.1f, "CRS Record Date")]
        public DateTime? CertificateOfReleaseToServiceRecordDate
        {
            get
            {
                if (CertificateOfReleaseToService != null && CertificateOfReleaseToService.RecordDate >= (DateTimeExtend.GetCASMinDateTime()))
                    return CertificateOfReleaseToService.RecordDate;
                return null;
            }
        }

        #endregion

        #region public Specialist CertificateOfReleaseToServiceAuthorizationB1 { get; set; }
        /// <summary>
        /// ������� �1 ����������, ������������ ������
        /// </summary>
        [ListViewData(0.1f, "Auth. B1")]
        public Specialist CertificateOfReleaseToServiceAuthorizationB1
        {
            get
            {
                if (CertificateOfReleaseToService != null && CertificateOfReleaseToService.AuthorizationB1 != null)
                    return CertificateOfReleaseToService.AuthorizationB1;
                return null;
            }
        }

        #endregion

        #region public Specialist CertificateOfReleaseToServiceAuthorizationB2 { get; set; }
        /// <summary>
        /// ������� �2 ����������, ������������ ������
        /// </summary>
        [ListViewData(0.1f, "Auth. B2")]
        public Specialist CertificateOfReleaseToServiceAuthorizationB2
        {
            get
            {
                if (CertificateOfReleaseToService != null && CertificateOfReleaseToService.AuthorizationB2 != null)
                    return CertificateOfReleaseToService.AuthorizationB2;
                return null;
            }
        }

        #endregion


        #region public AircraftFlight ParentFlight { get; set; }
        public AircraftFlight ParentFlight { get; set; }

        #endregion

        #region public String ParentFlightDate { get; set; }
        /// <summary>
        /// ������������� ���� ������ � ������� ��������� ����������
        /// </summary>
        [ListViewData(0.1f, "Flight Date")]
        public DateTime? ParentFlightDate
        {
            get
            {
				//
                if (ParentFlight != null && ParentFlight.RecordDate >= (DateTimeExtend.GetCASMinDateTime()))
                    return ParentFlight.RecordDate;
                return null;
            }
        }

        #endregion

        #region public String ParentFlightRoute { get; set; }

        [ListViewData(80, "Route")]
        public String ParentFlightRoute
        {
            get { return ParentFlight != null ? ParentFlight.StationFromId.ShortName + " - " + ParentFlight.StationToId.ShortName : ""; }
        }

        #endregion

        #region public String ParentFlightDelayReason { get; set; }
        /// <summary>
        /// ��������� ������������� ������� �������� ������, � ������� ��������� ����������
        /// </summary>
        [ListViewData(80, "Delay")]
        public String ParentFlightDelayReason
        {
            get { return ParentFlight != null && ParentFlight.DelayReason != null ? ParentFlight.DelayReason.ToString() : ""; }
        }

        #endregion

        #region public String ParentFlightCancellation { get; set; }
        /// <summary>
        /// ��������� ������������� ������ �������� ������, � ������� ��������� ����������
        /// </summary>
        [ListViewData(80, "Cancellation")]
        public String ParentFlightCancellation
        {
            get { return ParentFlight != null && ParentFlight.CancelReason != null ? ParentFlight.CancelReason.ToString() : ""; }
        }

        #endregion


        #region public DefferedItem DeferredItem { get; set; }
        public DeferredItem DeferredItem { get; set; }
        #endregion

        #region public string DeferredCategory { get; }
        /// <summary>
        /// ��������� ���������� �������� MEL
        /// </summary>
        [ListViewData(60, "MEL")]
        public string DeferredCategory
        {
            get
            {
                return DeferredItem != null ? DeferredItem.DeferredCategory.ToString() : "N/A";
            }
        }

        #endregion

        #region public string Damage { get; }
        /// <summary>
        /// ��������� ���������� �������� ������� �����������
        /// </summary>
        [ListViewData(60, "Damage")]
        public string Damage
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string EventType { get; }
        /// <summary>
        /// ��� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Event Type")]
        public string EventType
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string EventClass { get; }
        /// <summary>
        /// ����� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Event Class")]
        public string EventClass
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string EventCategory { get; }
        /// <summary>
        /// ��������� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Event Category")]
        public string EventCategory
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string RiskIndex { get; }
        /// <summary>
        /// ������ ����� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Risk Index")]
        public string RiskIndex
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string Accident { get; }
        /// <summary>
        /// �������� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Accident")]
        public string Accident
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string Condition { get; }
        /// <summary>
        /// ������� ������� �������� SMS
        /// </summary>
        [ListViewData(60, "Condition")]
        public string Condition
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region public string Remarks { get; }
        /// <summary>
        /// �������
        /// </summary>
        [ListViewData(60, "Remarks")]
        public string Remarks
        {
            get
            {
                return "";
            }
        }

		[TableColumn("Status")]
	    public CorrectiveActionStatus Status { get; set; }

	    #endregion

        /*
		*  ������ 
		*/
		
		#region public Discrepancy()
        /// <summary>
        /// ������� ��������� ����� ��� �������������� ����������
        /// </summary>
        public Discrepancy()
        {
            ItemId = -1;
            Description = "No";
	        Status = CorrectiveActionStatus.Close;
	        Remark = "";
			EngineRemarks = "";
			Messages = "";
			FDR = "";
            SmartCoreObjectType = SmartCoreType.Discrepancy;
		}
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(Discrepancy));
        }
        #endregion

        #region private void SetCorrectiveAction(CorrectiveAction correctiveAction)
        /// <summary>
        /// ���������� CorrectiveAction � ���������� � ��������� �� ������������� �������(this) ������ � ���� ������
        /// </summary>
        /// <param name="correctiveAction"></param>
        private void SetCorrectiveAction(CorrectiveAction correctiveAction)
        {
            if (ItemId > 0)
            {
                if (_correctiveAction != null)
                {
                    if (CorrectiveActionCollection != null)
                    {
                        if (correctiveAction != null)
                        {
                            if (CorrectiveActionCollection.Contains(correctiveAction))
                                CorrectiveActionCollection.Remove(correctiveAction);
                            CorrectiveActionCollection.Add(_correctiveAction);
                            _correctiveAction = correctiveAction;
                        }
                    }
                }
            }
            else
            {
                _correctiveAction = correctiveAction; 
            }
        }

        #endregion

        #region private CorrectiveAction GetCorrectiveAction()
        /// <summary>
        /// ���������� CorrectiveAction � ���������� �� ������� �������������� � ���� ������
        /// </summary>
        /// <returns></returns>
        private CorrectiveAction GetCorrectiveAction()
        {

            //if (ItemID > 0)
            //{
            //    if (correctiveActionCollection != null)
            //    {
            //        if (correctiveAction == null)
            //        {
            //            if (correctiveActionCollection.Count == 0)
            //            {
            //                correctiveAction = new CorrectiveAction();
            //                correctiveActionCollection.Add(correctiveAction);
            //            }
            //            else
            //            {
            //                correctiveAction = correctiveActionCollection[0];
            //            }
            //            return correctiveAction;
            //        }
            //        else
            //        {
            //            return correctiveAction;
            //        }
            //    }
            //}
            //else
            //{
            //    if (correctiveAction == null)
            //        correctiveAction = new CorrectiveAction();
            //    return correctiveAction;
            //}

            //return null;

            if (CorrectiveActionCollection == null)
                CorrectiveActionCollection = new CorrectiveActionCollection(this);
            if (_correctiveAction == null)
            {
                if (CorrectiveActionCollection.Count == 0)
                {
                    _correctiveAction = new CorrectiveAction();
                    CorrectiveActionCollection.Add(_correctiveAction);
                }
                else
                {
                    _correctiveAction = CorrectiveActionCollection[0];
                }
            }
            return _correctiveAction;

        }

        #endregion

        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ATA: {ATAChapter?.ShortName} | Description: {Description} | ";
        }
		#endregion

		#region public override bool Equals(object obj)

		public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(obj, null)) return false;

		    //Check whether the compared object references the same data.
		    if (ReferenceEquals(this, obj)) return true;

		    var g = obj as Discrepancy;
		    if (g == null) return false;

		    if (ATAChapter != null)
				return g.ATAChapter.Equals(ATAChapter)&&
		           g.Description.Equals(Description) &&
		           g.CorrectiveAction.Description.Equals(CorrectiveAction.Description) &&
		           g.CorrectiveAction.PartNumberOn.Equals(CorrectiveAction.PartNumberOn) &&
		           g.CorrectiveAction.PartNumberOff.Equals(CorrectiveAction.PartNumberOff) &&
		           g.CorrectiveAction.SerialNumberOn.Equals(CorrectiveAction.SerialNumberOn) &&
		           g.CorrectiveAction.SerialNumberOff.Equals(CorrectiveAction.SerialNumberOff) &&
		           g.CertificateOfReleaseToService.AuthorizationB1.Equals(CertificateOfReleaseToService.AuthorizationB1) &&
		           g.CertificateOfReleaseToService.AuthorizationB2.Equals(CertificateOfReleaseToService.AuthorizationB2) &&
		           g.CertificateOfReleaseToService.Station.Equals(CertificateOfReleaseToService.Station) &&
		           g.CertificateOfReleaseToService.RecordDate.Equals(CertificateOfReleaseToService.RecordDate);

		    return
		           g.Description.Equals(Description) &&
		           g.CorrectiveAction.Description.Equals(CorrectiveAction.Description) &&
		           g.CorrectiveAction.PartNumberOn.Equals(CorrectiveAction.PartNumberOn) &&
		           g.CorrectiveAction.PartNumberOff.Equals(CorrectiveAction.PartNumberOff) &&
		           g.CorrectiveAction.SerialNumberOn.Equals(CorrectiveAction.SerialNumberOn) &&
		           g.CorrectiveAction.SerialNumberOff.Equals(CorrectiveAction.SerialNumberOff) &&
		           g.CertificateOfReleaseToService.AuthorizationB1.Equals(CertificateOfReleaseToService.AuthorizationB1) &&
		           g.CertificateOfReleaseToService.AuthorizationB2.Equals(CertificateOfReleaseToService.AuthorizationB2) &&
		           g.CertificateOfReleaseToService.Station.Equals(CertificateOfReleaseToService.Station) &&
		           g.CertificateOfReleaseToService.RecordDate.Equals(CertificateOfReleaseToService.RecordDate);
		}

		#endregion

		#region public override int GetHashCode()

		public override int GetHashCode()
	    {
			if(ATAChapter != null)
				return ATAChapter.GetHashCode() ^
				       CertificateOfReleaseToService.Station.GetHashCode() ^
				       CertificateOfReleaseToService.RecordDate.GetHashCode();

			return 
				   CertificateOfReleaseToService.Station.GetHashCode() ^
				   CertificateOfReleaseToService.RecordDate.GetHashCode();
	    }

	    #endregion
    }

}
 
