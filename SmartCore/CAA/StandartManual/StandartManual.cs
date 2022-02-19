using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Auxiliary.Extentions;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.CAA.StandartManual
{
    [CAADto(typeof(CheckListDTO))]
    [Serializable]
    public class StandartManual : BaseEntityObject, IOperatable
    {
        public string Source { get; set; }
        
        public int OperatorId { get; set; }

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
