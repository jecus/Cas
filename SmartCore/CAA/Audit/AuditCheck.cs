using System;
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
                IsSatisfactory = false,
                WorkflowStatusId = -1
            };
            SmartCoreObjectType = SmartCoreType.AuditCheck;
            ItemId = -1;
        }
    }

    [Serializable]
    public class AuditCheckSettings
    {
        [JsonProperty("IsApplicable")]
        public bool IsApplicable { get; set; }

        [JsonProperty("IsSatisfactory")]
        public bool IsSatisfactory { get; set; }

        [JsonProperty("SubReference")]
        public string SubReference { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("RootCause")]
        public string RootCause { get; set; }

        [JsonProperty("WorkflowStatusId")]
        public int WorkflowStatusId { get; set; }
    }
}
