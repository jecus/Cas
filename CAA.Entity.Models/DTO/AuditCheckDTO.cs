using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("AuditChecks", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class AuditCheckDTO : BaseEntity
    {
        [Column("AuditId")]
        public int AuditId { get; set; }

        [Column("CheckListId")]
        public int CheckListId { get; set; }

        [Column("SettingsJSON")]
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

        [NotMapped]
        public AuditCheckSettings Settings { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int WorkflowStatusId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int WorkflowStageId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsApplicable { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsSatisfactory { get; set; }
    }
    
    
    [Serializable]
    public class AuditCheckSettings
    {
        public AuditCheckSettings()
        {
            RootCauseIds = new List<int>();
        }
        
        [JsonProperty("IsApplicable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsApplicable { get; set; }

        [JsonProperty("IsSatisfactory", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSatisfactory { get; set; }

        [JsonProperty("Findings")]
        public string Findings { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("RootCause")]
        public string RootCause { get; set; }
        
        [JsonProperty("RootCauseIds")]
        public List<int> RootCauseIds { get; set; }

        [JsonProperty("WorkflowStatusId")]
        public int WorkflowStatusId { get; set; }
        
        [JsonProperty("WorkflowStageId")]
        public int WorkflowStageId { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? FromWorkflowStageId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? FromWorkflowStatusId { get; set; }

        [JsonProperty("IsAuditorReview")]
        public bool? IsAuditorReview { get; set; }
        
        [JsonProperty("IsAuditeeReview")]
        public bool? IsAuditeeReview { get; set; }

        [JsonProperty("FatComments")]
        public string FatComments { get; set; }
    }
}
