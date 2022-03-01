using System;
using System.Collections;
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
        
        [Column("RevisionId")]
        public int? RevisionId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ProgramTypeId { get; set; }
        
        
        [NotMapped]
        public CheckUIType CheckUIType
        {
            get
            {
                if (((IList)new[] { 1, 6, 5 }).Contains(ProgramTypeId))
                    return CheckUIType.Iosa;
                if (((IList)new[] { 3, 7, 4 }).Contains(ProgramTypeId))
                    return CheckUIType.Safa;
                if (((IList)new[] { 8 }).Contains(ProgramTypeId))
                    return CheckUIType.Icao;

                return CheckUIType.None;
            }
        }
        
    }
    
    public enum CheckUIType
    {
        Iosa,
        Safa,
        Icao,
        None
    }
    
    
    [Serializable]
    public class CheckListICAOSettings
    {
        public CheckListICAOSettings()
        {
            MH = 0.0;
            LevelId = -1;
        }
        
        [JsonProperty("Reference")]
        public string Reference { get; set; }
        
        [JsonProperty("AnnexRef")]
        public string AnnexRef { get; set; }
        
        [JsonProperty("PartNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("PartName")]
        public string PartName { get; set; }
        
        [JsonProperty("ChapterNumber")]
        public string ChapterNumber { get; set; }

        [JsonProperty("ChapterName")]
        public string ChapterName { get; set; }

        [JsonProperty("ItemNumber")]
        public string ItemNumber { get; set; }

        [JsonProperty("ItemtName")]
        public string ItemtName { get; set; }

        [JsonProperty("Requirement")]
        public string Standard { get; set; }
        
        [JsonProperty("LevelId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int LevelId { get; set; }
        
        [JsonProperty("ManHours")]
        public double MH { get; set; }

        [JsonProperty("ProgramTypeId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int ProgramTypeId { get; set; }
    }
    
    [Serializable]
    public class CheckListSettingsSAFA
    {
        public CheckListSettingsSAFA()
        {
            MH = 0.0;
            LevelId = -1;
        }
        
        [JsonProperty("LevelId")]
        public int LevelId { get; set; }
        
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
            LevelId = -1;
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
