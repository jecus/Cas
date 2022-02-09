using System;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListRevisionDTO))]
    [Serializable]
    public class CheckListRevision : BaseEntityObject, IOperatable
    {
        public int CheckListId { get; set; }

        public string Number { get; set; }

        public RevisionType Type { get; set; }

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

        public CheckListRevision()
        {
            Settings = new CheckListRevisionSettings();
        }

    }


    public class CheckListRevisionSettings
    {
        [JsonProperty("Remark")]
        public string Remark { get; set; }
    }
}
