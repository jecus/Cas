using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckList", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListDTO : BaseEntity,IOperatable
    {
        [Column("Source")]
        public string Source { get; set; }
        
        [Column("EditionId")]
        public int  EditionId{ get; set; }
        
        [Column("ManualId")]
        public int  ManualId{ get; set; }

        public string SettingsJSON { get; set; }
        
        #region Navigation Property

        [Child]
        public ICollection<CheckListRecordDTO> CheckListRecords { get; set; }

        #endregion

        [Column("OperatorId")]
        public int OperatorId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ProgramTypeId { get; set; }
    }
    
    
     [Serializable]
    public class CheckListSettingsSAFA
    {
        
        [JsonProperty("Item")]
        public string Item { get; set; }
        
        [JsonProperty("ItemNumber")]
        public string ItemNumber { get; set; }
        
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        [JsonProperty("Standard")]
        public string Standard { get; set; }
        
        [JsonProperty("StandardRef")]
        public string StandardRef { get; set; }
        
        [JsonProperty("PdfCode")]
        public string PdfCode { get; set; }
        
        [JsonProperty("StandardText")]
        public string StandardText { get; set; }
        
        [JsonProperty("PreDescribedFinding")]
        public string PreDescribedFinding { get; set; }
        
        [JsonProperty("Instruction")]
        public string Instruction { get; set; }
        
        [JsonProperty("ManHours")]
        public double MH { get; set; }

        [JsonProperty("ProgramTypeId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int ProgramTypeId { get; set; }
    }
    

    [Serializable]
    public class CheckListSettings
    {
        public CheckListSettings()
        {
            Phase = "N/A";
            MH = 0.0;
        }
        
        [JsonProperty("SectionNumber")]
        public string SectionNumber { get; set; }

        [JsonProperty("SectionName")]
        public string SectionName { get; set; }

        [JsonProperty("PartNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("PartName")]
        public string PartName { get; set; }

        [JsonProperty("SubPartNumber")]
        public string SubPartNumber { get; set; }

        [JsonProperty("SubPartName")]
        public string SubPartName { get; set; }

        [JsonProperty("ItemNumber")]
        public string ItemNumber { get; set; }

        [JsonProperty("ItemtName")]
        public string ItemtName { get; set; }

        [JsonProperty("Requirement")]
        public string Requirement { get; set; }
        
        [JsonProperty("Reference")]
        public string Reference { get; set; }
        
        [JsonProperty("LevelId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int LevelId { get; set; }

        [JsonProperty("Phase", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("N/A")]
        public string Phase { get; set; }

        [JsonProperty("ManHours")]
        public double MH { get; set; }

        [JsonProperty("ProgramTypeId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int ProgramTypeId { get; set; }
    }


}
