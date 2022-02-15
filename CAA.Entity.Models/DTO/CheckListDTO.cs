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

        public string SettingsJSON
        {
            get
            {
                if (Settings == null)
                    return null;

                return JsonConvert.SerializeObject(Settings,
                    Formatting.Indented,
                    new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
            }

            set => Settings = string.IsNullOrWhiteSpace(value)
                ? new CheckListDTOSettings()
                : JsonConvert.DeserializeObject<CheckListDTOSettings>(value);
        }

        public CheckListDTOSettings Settings { get; set; }



        #region Navigation Property

        [Child]
        public ICollection<CheckListRecordDTO> CheckListRecords { get; set; }

        #endregion

        [Column("OperatorId")]
        public int OperatorId { get; set; }
    }
    
    
    [Serializable]
    public class CheckListDTOSettings
    {
        public CheckListDTOSettings()
        {
            Phase = "N/A";
            MH = 0.0;
            RevisonValidToDate = DateTime.Today;
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

        [JsonProperty("RevisonValidToNotify")]
        public int RevisonValidToNotify { get; set; }
        
        [JsonProperty("RevisonValidToDate")]
        public DateTime RevisonValidToDate { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("Described")]
        public string Described { get; set; }

        [JsonProperty("Instructions")]
        public string Instructions { get; set; }

        [JsonProperty("LevelId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int LevelId { get; set; }

        [JsonProperty("Phase", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("N/A")]
        public string Phase { get; set; }

        [JsonProperty("ManHours")]
        public double MH { get; set; }
    }


}
