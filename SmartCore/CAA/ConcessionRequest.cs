using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.CAA
{
    [CAADto(typeof(ConcessionRequestDTO))]
    [Serializable]
    public class ConcessionRequest: BaseEntityObject
    {
        public DateTime Created { get; set; }
        
        public int FromId { get; set; }
        
        public int ToId { get; set; }
        
        public int CurrentId { get; set; }
        
        public int Status { get; set; }
        
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
                ? new ConcessionRequestSettings()
                : JsonConvert.DeserializeObject<ConcessionRequestSettings>(value);
        }
        
        public ConcessionRequestSettings Settings { get; set; }
        
        public ConcessionRequest()
        {
            Settings = new ConcessionRequestSettings();
        }
        
        public Specialist From { get; set; }
        public Specialist To { get; set; }
        public Entities.General.Aircraft Aircraft { get; set; }
        
    }

    [Serializable]
    public class ConcessionRequestSettings
    {
        [JsonProperty]
        public string Station { get; set; }

        [JsonProperty]
        public string Reason { get; set; }

        [JsonProperty]
        public string Number { get; set; }
        
        [JsonProperty]
        public Provider Provider { get; set; }
        
        [JsonProperty]
        public int AircraftId { get; set; }
    }

    public enum Provider
    {
        Expedite,
        Routine,
        AOG
    }
}