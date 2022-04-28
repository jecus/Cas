using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.CAAWP
{
    [CAADto(typeof(CoursePackageDTO))]
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
        
        
        
        public WPStatus Status { get; set; }
        
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case  WPStatus.Open : return $"{RoutineStatus.Open}";
                    case WPStatus.Published:
                        return "In progress";
                    case WPStatus.Closed:
                        return $"{RoutineStatus.Closed}";
                    default: return "";
                }
            }
        }
        


        public CAAWorkPackage()
        {
            Status = WPStatus.Open;
            Settings = new CAAWorkPackagekSettings()
            {
                CreateDate = DateTime.Now,
                PublishingDate = DateTime.Now,
                ClosingDate = DateTime.Now,
                OpeningDate = DateTime.Now,
                PerformDate = DateTime.Now,
                ClosingDocument =new List<Document>(),
                DocumentIds = new List<int>()
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
        public DateTime? PublishingDate { get; set; }
        
        [JsonProperty]
        public int Author { get; set; }
        
        [JsonProperty]
        public int ClosedBy { get; set; }
        
        [JsonProperty]
        public string PublishingRemarks { get; set; }
        
        [JsonProperty]
        public DateTime OpeningDate { get; set; }
        
        [JsonProperty]
        public DateTime? ClosingDate { get; set; }
        
        [JsonProperty]
        public int PublishedBy { get; set; }
        
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
        
        
        [JsonProperty]
        public List<int> DocumentIds { get; set; }

        [JsonProperty]
        public int? TaskId { get; set; }
    }

    
}
