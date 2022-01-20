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
        public string AuditNumber { get; set; }

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

        public AllOperators Operator { get; set; }


        public CAAAudit()
        {
            Settings = new CAAAuditSettings();
            SmartCoreObjectType = SmartCoreType.CAAAudit;
            ItemId = -1;
        }
    }


    [Serializable]
    public class CAAAuditSettings
    {
        public CAAAuditSettings()
        {

        }

        //public CAARoutineStatus Status { get; set; }

        //private WorkFlowStage _workflowStage;
        //public WorkFlowStage WorkflowStage
        //{
        //    get => _workflowStage ?? WorkFlowStage.Unknown;
        //    set => _workflowStage = value;
        //}

        //private WorkFlowStatus _workflowStatus;
        //public WorkFlowStatus WorkflowStatus
        //{
        //    get => _workflowStatus ?? WorkFlowStatus.Unknown;
        //    set => _workflowStatus = value;
        //}


        //private AuditType _auditType;
        //public AuditType AuditType
        //{
        //    get => _auditType ?? AuditType.Unknown;
        //    set => _auditType = value;
        //}

        [JsonProperty("OperatorId")]
        public int OperatorId { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("AutorId")]
        public int AutorId { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }


    }

}
