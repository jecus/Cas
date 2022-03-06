using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.Check;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.CAA.PEL
{
    public interface IAuditPelRecordFilterParams
    {
        
    }
    
    [CAADto(typeof(AuditPelRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class AuditPelRecord : BaseEntityObject, IAuditPelRecordFilterParams
    {
        public int AuditId { get; set; }
        
        public int CheckListId { get; set; }
        
        public int AuditorId { get; set; }
        
        public int AuditeeId { get; set; }
        
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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new AuditPelRecordSettings() : JsonConvert.DeserializeObject<AuditPelRecordSettings>(value);
        }
        
        public AuditPelRecordSettings Settings { get; set; }
        public CheckLists CheckList { get; set; }
        public Specialist Auditor { get; set; }
        public Specialist Auditee { get; set; }

        public AuditPelRecord()
        {
            Settings = new AuditPelRecordSettings();
        }
    }

    [Serializable]
    public class AuditPelRecordSettings
    {
        [JsonProperty("AuditorRoleId")]
        public int AuditorRoleId { get; set; }
        [JsonProperty("AuditorPELId")]
        public int AuditorPELResponsibilitiesId { get; set; }
        
        [JsonProperty("AuditeeRoleId")]
        public int AuditeeRoleId { get; set; }
        [JsonProperty("AuditeePELId")]
        public int AuditeePELResponsibilitiesId { get; set; }
        [JsonProperty("AuditorPELPosition")]
        public int AuditorPELPosition { get; set; }
        
        [JsonProperty("AuditeePELPosition")]
        public int AuditeePELPosition { get; set; }
    }
}