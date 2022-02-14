using System;
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
            
        }
        
        [JsonProperty("RevisionCheckType", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(RevisionCheckType.None)]
        public RevisionCheckType RevisionCheckType { get; set; }
    }
    
    [Serializable]
    public enum RevisionCheckType : byte
    {
        None = 0,
        New = 1,
        Del = 2,
        Mod =3
       
    }
    
            
    
    
    
}
