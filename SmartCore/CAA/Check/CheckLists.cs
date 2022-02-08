using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Auxiliary.Extentions;
using SmartCore.CAA.Audit;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListDTO))]
    [Serializable]
    public class CheckLists : BaseEntityObject, ICheckListFilterParams, IFileContainer, IOperatable
    {
        public string Source { get; set; }



        public List<CheckListRecords> CheckListRecords { get; set; }
        public List<CheckListRevision> AllRevisions { get; set; }

        public List<CheckListRevision> Revisions => 
            AllRevisions?.Where(i => i.Type == RevisionType.Revision)
            .OrderBy(i => i.EffDate)
                .ToList() ?? new List<CheckListRevision>();

        public List<CheckListRevision> Editions =>
            AllRevisions?.Where(i => i.Type == RevisionType.Edition)
                .OrderBy(i => i.EffDate)
                .ToList() ?? new List<CheckListRevision>();


        private CommonCollection<ItemFileLink> _files;

        public CommonCollection<ItemFileLink> Files
        {
            get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
            set
            {
                if (_files != value)
                {
                    if (_files != null)
                        _files.Clear();
                    if (value != null)
                        _files = value;
                }
            }
        }


        #region public AttachedFile FaaFormFile { get; set; }

        [NonSerialized] private AttachedFile _file;

        public AttachedFile File
        {
            get { return _file ?? (Files?.GetFileByFileLinkType(FileLinkType.CheckList)); }
            set
            {
                _file = value;
                Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.CheckList);
            }
        }

        #endregion


        public Lifelength Remains { get; set; }
        public ConditionState Condition { get; set; }



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
                ? new CheckListSettings()
                : JsonConvert.DeserializeObject<CheckListSettings>(value);
        }

        public CheckListSettings Settings { get; set; }



        public CheckLists()
        {
            ItemId = -1;
            CheckListRecords = new List<CheckListRecords>();
            AllRevisions = new List<CheckListRevision>();
            Settings = new CheckListSettings();
            SmartCoreObjectType = SmartCoreType.CheckLists;
        }

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            var clone = (CheckLists) MemberwiseClone();
            clone.ItemId = -1;
            clone.UnSetEvents();

            if (marked)
                clone.Source += " Copy";

            clone.Files?.Clear();
            clone.CheckListRecords?.Clear();

            return clone;
        }

        public string NextEditionNumber  { get; set; }
        public string NextRevisionNumber  { get; set; }
        public string EditionNumber  { get; set; }
        public string RevisionNumber  { get; set; }
        
        public string SectionNumber => Settings.SectionNumber;
        public string SectionName => Settings.SectionName;
        public string PartNumber => Settings.PartNumber;
        public string PartName => Settings.PartName;
        public string SubPartNumber => Settings.SubPartNumber;
        public string SubPartName => Settings.SubPartName;
        public string ItemNumber => Settings.ItemNumber;
        public string ItemName => Settings.ItemtName;
        public string Requirement => Settings.Requirement;
        public FindingLevels Level { get; set; }

        public string[] Group
        {
            get
            {
                var g = Regex.Replace($"{SectionNumber} {PartNumber} {SubPartNumber}", @"\s+", " ");
                var n = Regex.Replace(g, "[^0-9.]", "").Split('.');
                return n;
            }
        }

        public AuditCheck AuditCheck { get; set; }
        public int OperatorId { get; set; }
        
    }


[Serializable]
    public class CheckListSettings
    {
        public CheckListSettings()
        {
            Phase = "N/A";
            MH = 0.0;
        }

        
        [JsonProperty("SectionNumber")]
        public string SectionNumber { get; set; }

        [JsonProperty("SectionName")]
        public string SectionName { get; set; }

        [JsonProperty("PartNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("PartName")]
        public string PartName { get; set; }

        [JsonProperty("SubPartNumber")]
        public string SubPartNumber { get; set; }

        [JsonProperty("SubPartName")]
        public string SubPartName { get; set; }

        [JsonProperty("ItemNumber")]
        public string ItemNumber { get; set; }

        [JsonProperty("ItemtName")]
        public string ItemtName { get; set; }

        [JsonProperty("Requirement")]
        public string Requirement { get; set; }

        [JsonProperty("RevisonValidToNotify")]
        public int RevisonValidToNotify { get; set; }
        
        [JsonProperty("RevisonValidToDate")]
        public DateTime RevisonValidToDate { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("Described")]
        public string Described { get; set; }

        [JsonProperty("Instructions")]
        public string Instructions { get; set; }

        [JsonProperty("LevelId", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(-1)]
        public int LevelId { get; set; }

        [JsonProperty("Phase", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("N/A")]
        public string Phase { get; set; }

        [JsonProperty("ManHours")]
        public double MH { get; set; }
    }
}
