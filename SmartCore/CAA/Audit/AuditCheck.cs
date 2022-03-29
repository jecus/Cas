using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Audit
{
    [CAADto(typeof(AuditCheckDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class AuditCheck : BaseEntityObject
    {
        public int AuditId { get; set; }
        public int CheckListId { get; set; }
        
        public int WorkflowStatusId { get; set; }
        public int WorkflowStageId { get; set; }

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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new AuditCheckSettings() : JsonConvert.DeserializeObject<AuditCheckSettings>(value);
        }

        public AuditCheckSettings Settings { get; set; }


        public AuditCheck()
        {
            Settings = new AuditCheckSettings()
            {
                WorkflowStatusId = WorkFlowStatus.Open.ItemId,
                WorkflowStageId = WorkFlowStage.View.ItemId
            };
            SmartCoreObjectType = SmartCoreType.AuditCheck;
            ItemId = -1;
        }
    }

    
}
