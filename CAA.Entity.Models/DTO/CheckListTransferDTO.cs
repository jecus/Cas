using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckListTransfer", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListTransferDTO : BaseEntity
    {
        [Column("Created")]
        public DateTime Created { get; set; }

        [Column("AuditId")]
        public int AuditId { get; set; }
        
        [Column("CheckListId")]
        public int CheckListId { get; set; }
        
        [Column("From")]
        public int From { get; set; }
        
        [Column("To")]
        public int To { get; set; }
        
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

            set => Settings = string.IsNullOrWhiteSpace(value)
                ? new CheckListTransferSettings()
                : JsonConvert.DeserializeObject<CheckListTransferSettings>(value);
        }
        
        [NotMapped]
        public CheckListTransferSettings Settings { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int WorkflowStageId { get; set; }
    }
    
    [Serializable]
    public class CheckListTransferSettings
    {
        [JsonProperty]
        public string Remark { get; set; }
        
        [JsonProperty]
        public int WorkflowStageId { get; set; }

        [JsonProperty]
        public bool IsWorkFlowChanged { get; set; }
    }
}