using System;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    public interface ICheckListRevisionFilterParams
    {
        [Filter("Number", Order = 1)]
        int Number { get; set; }

        [Filter("Type", Order = 2)]
        RevisionType Type { get; set; }

        [Filter("Date", Order = 3)]
         DateTime Date { get; set; }

        [Filter("EffDate", Order = 4)]
         DateTime EffDate { get; set; }
    }
    
    [CAADto(typeof(CheckListRevisionDTO))]
    [Serializable]
    public class CheckListRevision : BaseEntityObject, IOperatable, ICheckListRevisionFilterParams
    {
        public int CheckListId { get; set; }

        public int Number { get; set; }
        public EditionRevisionStatus Status { get; set; }

        public RevisionType Type { get; set; }

        public DateTime Date { get; set; }

        public DateTime EffDate { get; set; }
        
        public int EditionId { get; set; }
        public int ManualId { get; set; }

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
                ? new CheckListRevisionSettings()
                : JsonConvert.DeserializeObject<CheckListRevisionSettings>(value);
        }

        public CheckListRevisionSettings Settings { get; set; }
        public int OperatorId { get; set; }
        public EditionRevisionStatus CurrentStatus { get; set; }

        public CheckListRevision()
        {
            Date = DateTime.Today;
            EffDate = DateTime.Today;
            Status = EditionRevisionStatus.Temporary;
            Settings = new CheckListRevisionSettings();
        }

    }


    public class CheckListRevisionSettings
    {
        [JsonProperty("EditionId")]
        public int EditionId { get; set; }
        
        [JsonProperty("Remark")]
        public string Remark { get; set; }
    }
}
