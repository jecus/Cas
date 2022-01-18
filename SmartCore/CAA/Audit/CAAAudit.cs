using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Audit
{
    public enum CAARoutineStatus
    {
        Open,
        Workflow,
        Closed
    }

    [CAADto(typeof(CAAAuditDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CAAAudit : BaseEntityObject , IAuditFilterParams
    {
        public int OperatorId { get; set; }
        
        public string AuditNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string SettingsJSON
        {
            get
            {
                if (Settings == null)
                    return null;

                return JsonConvert.SerializeObject(Settings,
                    Formatting.Indented,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            }

            set => Settings = string.IsNullOrWhiteSpace(value) ? new CAAAuditSettings() : JsonConvert.DeserializeObject<CAAAuditSettings>(value);
        }

        public CAAAuditSettings Settings { get; set; }


        private List<Document> _document;
        public List<Document> Documents
        {
            get => _document ?? (_document = new List<Document>());
            set => _document = value;
        }

        public CAAAudit()
        {
            Settings = new CAAAuditSettings();
            SmartCoreObjectType = SmartCoreType.CAAAudit;
            ItemId = -1;
        }
    }


    public class CAAAuditSettings
    {
        public CAAAuditSettings()
        {
            OpeningDate = DateTimeExtend.GetCASMinDateTime();
            ClosingDate = DateTimeExtend.GetCASMinDateTime();
            PublishingDate = DateTimeExtend.GetCASMinDateTime();
            CreateDate = DateTime.Now;
        }

        public CAARoutineStatus Status { get; set; }

        private WorkFlowStage _workflowStage;
        public WorkFlowStage WorkflowStage
        {
            get => _workflowStage ?? WorkFlowStage.Unknown;
            set => _workflowStage = value;
        }

        private WorkFlowStatus _workflowStatus;
        public WorkFlowStatus WorkflowStatus
        {
            get => _workflowStatus ?? WorkFlowStatus.Unknown;
            set => _workflowStatus = value;
        }


        private AuditType _auditType;
        public AuditType AuditType
        {
            get => _auditType ?? AuditType.Unknown;
            set => _auditType = value;
        }

        


        #region public DateTime CreateDate { get; set; }

        private DateTime _createDate;

        [JsonProperty("CreateDate")]
        public DateTime CreateDate
		{
			get => _createDate;
            set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_createDate < min || _createDate != value)
				{
					_createDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		#endregion

		#region public DateTime OpeningDate { get; set; }

		private DateTime _openingDate;

        [JsonProperty("OpeningDate")]
        public DateTime OpeningDate
		{
			get => _openingDate;
            set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_openingDate < min || _openingDate != value)
				{
					_openingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

        [JsonIgnore]
        public DateTime? ListViewOpeningDate
		{
			get
			{
				if (_openingDate < (DateTimeExtend.GetCASMinDateTime())) return null;
				return _openingDate;
			}
		}
		#endregion

		#region public DateTime PublishingDate { get; set; }

		private DateTime _publishingDate;

        [JsonProperty("PublishingDate")]
        public DateTime PublishingDate
		{
			get => _publishingDate;
            set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_publishingDate < min || _publishingDate != value)
				{
					_publishingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}


		#endregion

        #region public DateTime ClosingDate { get; set; }

        private DateTime _closingDate;

        [JsonProperty("ClosingDate")]
        public DateTime ClosingDate
        {
            get => _closingDate;
            set
            {
                var min = DateTimeExtend.GetCASMinDateTime();
                if (_closingDate < min || _closingDate != value)
                {
                    _closingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
                }
            }
        }


        #endregion

		[JsonProperty("AuthorId")]
        public int AuthorId { get; set; }

        [JsonProperty("PublishedById")]
        public int PublishedById { get; set; }

        [JsonProperty("PublishedRemark")]
        public string PublishedRemark { get; set; }

        [JsonProperty("ClosedById")]
        public int ClosedById { get; set; }

        [JsonProperty("ClosedRemark")]
        public string ClosedRemark { get; set; }

        [JsonProperty("Station")]
        public string Station { get; set; }

        [JsonProperty("KMH")]
        public decimal KMH { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

    }

}
