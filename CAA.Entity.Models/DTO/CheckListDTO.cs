using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckList", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListDTO : BaseEntity
    {
        [Column("Source")]
        public string Source { get; set; }

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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new CheckListSettings() : JsonConvert.DeserializeObject<CheckListSettings>(value);
        }

        [NotMapped]
        public CheckListSettings Settings { get; set; }


        #region Navigation Property

        [Child]
        public ICollection<CheckListRecordDTO> CheckListRecords { get; set; }

        #endregion



    }

    public class CheckListSettings
    {
        public CheckListSettings()
        {
            EditionDate = DateTime.Today;
            EffEditionDate = DateTime.Today;
            RevisonDate = DateTime.Today;
            EffRevisonDate = DateTime.Today;
        }

        [JsonProperty("EditionNumber")]
        public string EditionNumber { get; set; }

        [JsonProperty("EditionDate")]
        public DateTime EditionDate { get; set; }

        [JsonProperty("EffEditionDate")]
        public DateTime EffEditionDate { get; set; }

        [JsonProperty("RevisonNumber")]
        public string RevisonNumber { get; set; }

        [JsonProperty("RevisonnDate")]
        public DateTime RevisonDate { get; set; }

        [JsonProperty("EffRevisonDate")]
        public DateTime EffRevisonDate { get; set; }

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
    }
}
