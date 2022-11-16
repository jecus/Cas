using System;
using System.Linq;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.Check;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.StandartManual
{
    
    public interface IStandartManualFilterParams
    {
        [Filter("Source:", Order = 1)]
        string Source { get; }
        
        [Filter("ProgramType:", Order = 2)]
        ProgramType ProgramType { get; }
        
        [Filter("Description:", Order = 3)]
        string Description { get; }
        
        [Filter("Remark:", Order = 4)]
        string Remark { get; }
        
        [Filter("CheckValid:", Order = 5)]
        DateTime ValidTo { get; }
        
        [Filter("Notify:", Order = 6)]
        int Notify { get; }
        
    }
    
    [CAADto(typeof(StandartManualDTO))]
    [Serializable]
    public class StandartManual : BaseEntityObject, IOperatable,IStandartManualFilterParams
    {
        public string Source { get; set; }
        
        public int OperatorId { get; set; }
        
        public int ProgramTypeId { get; set; }

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
                ? new StandartManualSettings()
                : JsonConvert.DeserializeObject<StandartManualSettings>(value);
        }

        public StandartManualSettings Settings { get; set; }
        
        public ProgramType ProgramType => ProgramType.GetItemById(Settings.ProgramTypeId);
        public CheckUIType CheckUIType
        {
            get
            {
                if (new[] { ProgramType.IOSA, ProgramType.ISAGO, ProgramType.CAAKG,ProgramType.EASA, ProgramType.EASAMed,  }.Contains(ProgramType))
                    return CheckUIType.Iosa;
                if (new[] { ProgramType.SAFA, ProgramType.SACA, ProgramType.SANAKG, }.Contains(ProgramType))
                    return CheckUIType.Safa;
                if (new[] { ProgramType.ICAO }.Contains(ProgramType))
                    return CheckUIType.Icao;

                return CheckUIType.None;
            }
        }
        
        
        public string Description => Settings.Description;
        public string Remark => Settings.Remark;
        public DateTime ValidTo => Settings.ValidTo;
        public int Notify => Settings.Notify;
        public Lifelength Remains { get; set; }
        public ConditionState Condition { get; set; }

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            var clone = (StandartManual) MemberwiseClone();
            clone.ItemId = -1;
            clone.UnSetEvents();

            if (marked)
                clone.Source += " Copy";
            return clone;
        }
        
        public StandartManual()
        {
            ItemId = -1;
            Settings = new StandartManualSettings();
            SmartCoreObjectType = SmartCoreType.StandartManual;
        }

        
    }


    [Serializable]
    public class StandartManualSettings
    {
        public StandartManualSettings()
        {
            ProgramTypeId = -1;
            ValidTo = DateTime.Today;
        }
        
        [JsonProperty("ProgramTypeId")]
       public int ProgramTypeId { get; set; }
       
       [JsonProperty("Description")]
       public string Description { get; set; }
       
       [JsonProperty("Remark")]
       public string Remark { get; set; }
       
       [JsonProperty("ValidTo")]
       public DateTime ValidTo { get; set; }
       
       [JsonProperty("Notify")]
       public int Notify { get; set; }
    }
}
