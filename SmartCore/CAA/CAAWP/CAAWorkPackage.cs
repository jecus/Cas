using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.CAAWP
{
    [CAADto(typeof(CAAWorkPackageDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CAAWorkPackage : BaseEntityObject
    {
        public string Title { get; set; }
        public int OperatorId { get; set; }
        
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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new CAAWorkPackagekSettings() : JsonConvert.DeserializeObject<CAAWorkPackagekSettings>(value);
        }

        public CAAWorkPackagekSettings Settings { get; set; }
        


        public CAAWorkPackage()
        {
            Settings = new CAAWorkPackagekSettings()
            {
                Status = WPStatus.Open
            };
            ItemId = -1;
        }
    }

    
    public enum WPStatus
    {
        Open,
        Published,
        Closed
    }

    [Serializable]
    public  class CAAWorkPackagekSettings
    {
        [JsonProperty]
        public string Number { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        
        [JsonProperty]
        public DateTime CreateDate { get; set; }
        
        [JsonProperty]
        public DateTime PublishingDate { get; set; }
        
        [JsonProperty]
        public string Author { get; set; }
        
        [JsonProperty]
        public string ClosedBy { get; set; }
        
        [JsonProperty]
        public string PublishingRemarks { get; set; }
        
        [JsonProperty]
        public WPStatus Status { get; set; }
        
        [JsonProperty]
        public DateTime OpeningDate { get; set; }
        
        [JsonProperty]
        public DateTime ClosingDate { get; set; }
        
        [JsonProperty]
        public string PublishedBy { get; set; }
        
        [JsonProperty]
        public string Remarks { get; set; }
        
        [JsonProperty]
        public string ClosingRemarks { get; set; }
        
        [JsonProperty]
        public string Location { get; set; }
        
        [JsonProperty]
        public string Duration { get; set; }
        
        [JsonProperty]
        public DateTime PerformDate { get; set; }
        
        [JsonIgnore]
        public List<Document> ClosingDocument { get; set; }
        
    }

    
}
