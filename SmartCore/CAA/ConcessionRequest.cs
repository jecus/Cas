using System;
using System.Collections.Generic;
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
        
        public ConcessionRequestStatus Status { get; set; }
        
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

        public ConcessionRequestSettings()
        {
            CAARecords = new List<ConcessionRequestRecord>();
            OperatorRecords = new List<ConcessionRequestRecord>();
        }
        
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
        
        [JsonProperty]
        public int OperatorId { get; set; }
        
        [JsonProperty]
        public List<ConcessionRequestRecord> CAARecords { get; set; }
        
        [JsonProperty]
        public List<ConcessionRequestRecord> OperatorRecords { get; set; }
    }
    
    [Serializable]
    public class ConcessionRequestRecord
    {
        public ConcessionRequestRecord()
        {
            Created = DateTime.Now;
            Permitted = DateTime.Now;
        }

        [JsonProperty]
        public Concession Concession { get; set; }

        [JsonProperty]
        public DateTime Permitted { get; set; }

        [JsonProperty]
        public string Remark { get; set; }

        [JsonProperty]
        public DateTime Created { get; set; }
    }
    
    public enum Concession
    {
        Granted,
        Rejected
    }

    public enum ConcessionRequestStatus
    {
        CAA,
        Operator
    }
    
    public enum Provider
    {
        Expedite,
        Routine,
        AOG
    }
}