using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListTransferDTO))]
    [Serializable]
    public class CheckListTransfer: BaseEntityObject
    {
        public DateTime Created { get; set; }
        public int FileId { get; set; }
        public int AuditId { get; set; }
        public int CheckListId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
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
                ? new CheckListTransferSettings()
                : JsonConvert.DeserializeObject<CheckListTransferSettings>(value);
        }

        public CheckListTransferSettings Settings { get; set; }

        public CheckListTransfer()
        {
            Settings = new CheckListTransferSettings();
        }
    }

    public class CheckListTransferSettings
    {
        
    }
}