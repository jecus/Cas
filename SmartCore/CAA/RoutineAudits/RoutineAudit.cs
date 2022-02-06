using System;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.Check;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    [CAADto(typeof(RoutineAuditDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class RoutineAudit : BaseEntityObject, IRoutineAuditFilterParams, IOperatable
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Remark { get; set; }


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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new RoutineAuditSettings() : JsonConvert.DeserializeObject<RoutineAuditSettings>(value);
        }

        public RoutineAuditSettings Settings { get; set; }


        private ProgramType _type;
        private RoutineObject _routineObject;

        public ProgramType Type
        {
            get
            {
                _type = ProgramType.GetItemById(Settings.TypeId) ?? ProgramType.Unknown;
                return _type;
            }
            set
            {
                Settings.TypeId = value.ItemId;
                _type = value;
            }
        }

        public RoutineObject RoutineObject
        {
            get
            {
                _routineObject = RoutineObject.GetItemById(Settings.RoutineObjectId) ?? RoutineObject.Unknown;
                return _routineObject;
            }
            set
            {
                Settings.RoutineObjectId = value.ItemId;
                _routineObject = value;
            }
        }


        public RoutineAudit()
        {
            Settings = new RoutineAuditSettings();
            SmartCoreObjectType = SmartCoreType.RoutineAudit;
            ItemId = -1;
        }

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            var clone = (RoutineAudit)MemberwiseClone();
            clone.ItemId = -1;
            clone.UnSetEvents();

            if (marked)
                clone.Title += " Copy";


            return clone;
        }

        public int OperatorId { get; set; }
    }

    [Serializable]
    public class RoutineAuditSettings
    {

        [JsonProperty("TypeId")]
        public int TypeId { get; set; }

        [JsonProperty("RoutineObjectId")]
        public int RoutineObjectId { get; set; }

        [JsonProperty("AuthorId")]
        public int AuthorId { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }
    }
}
