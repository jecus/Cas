using System;
using System.Collections.Generic;
using System.ComponentModel;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListRevisionRecordDTO))]
    [Serializable]
    public class CheckListRevisionRecord : BaseEntityObject
    {
        public int CheckListId { get; set; }
        public int ParentId { get; set; }
        
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
                ? new CheckListRevisionRecordSettings()
                : JsonConvert.DeserializeObject<CheckListRevisionRecordSettings>(value);
        }

        public CheckListRevisionRecordSettings Settings { get; set; }
        
        public CheckListRevisionRecord()
        {
            Settings = new CheckListRevisionRecordSettings();
        }
    }

    
    public class CheckListRevisionRecordSettings
    {
        public CheckListRevisionRecordSettings()
        {
            ModData = new Dictionary<string, object>();
        }
        
        [JsonProperty("RevisionCheckType", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(RevisionCheckType.None)]
        public RevisionCheckType RevisionCheckType { get; set; }
        
        [JsonProperty("ModData", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> ModData { get; set; }
    }
    
}
