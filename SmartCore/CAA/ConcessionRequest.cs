using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA
{
    [CAADto(typeof(ConcessionRequestDTO))]
    [Serializable]
    public class ConcessionRequest: BaseEntityObject
    {
        public DateTime Created { get; set; }
        
        public int From { get; set; }
        
        public int To { get; set; }
        
        public int Current { get; set; }
        
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
    }
}