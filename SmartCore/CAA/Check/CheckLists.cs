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
using SmartCore.CAA.RoutineAudits;
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
    public class CheckLists : BaseEntityObject, ICheckListFilterParams,ICheckListSafaFilterParams, IFileContainer, IOperatable
    {
        public string Source { get; set; }
        public int EditionId { get; set; }
        public int OperatorId { get; set; }
        public int ManualId { get; set; }


        public List<CheckListRecords> CheckListRecords { get; set; }
        public List<EditionRevisionView> AllRevisions { get; set; }
        
        #region File

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

        #endregion
        
        public Lifelength Remains { get; set; }
        public ConditionState Condition { get; set; }
        
        public string SettingsJSON
        {
            get
            {
                if (CheckUIType == CheckUIType.Iosa)
                {
                    return JsonConvert.SerializeObject(Settings,
                        Formatting.Indented,
                        new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
                }
                else
                {
                    return JsonConvert.SerializeObject(SettingsSafa,
                        Formatting.Indented,
                        new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
                }
            }

            set
            {
                if (CheckUIType == CheckUIType.Iosa) 
                {
                    Settings = string.IsNullOrWhiteSpace(value)
                        ? new CheckListSettings()
                        : JsonConvert.DeserializeObject<CheckListSettings>(value);
                }
                else
                {
                    SettingsSafa = string.IsNullOrWhiteSpace(value)
                        ? new CheckListSettingsSAFA()
                        : JsonConvert.DeserializeObject<CheckListSettingsSAFA>(value);
                }
            }
        }

        public CheckListSettings Settings { get; set; }
        public CheckListSettingsSAFA SettingsSafa { get; set; }
        
        
        public string NextEditionNumber  { get; set; }
        public string NextRevisionNumber  { get; set; }
        public int EditionNumber  { get; set; }
        public int RevisionNumber  { get; set; }
        
        public RevisionCheckType RevisionStatus { get; set; }

        #region ICheckListFilterParams
        
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

        #endregion
        
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
        


        
        public ProgramType ProgramType { get; set; }

        public CheckUIType CheckUIType
        {
            get
            {
                if (new[] { ProgramType.IOSA, ProgramType.ISAGO, ProgramType.CAAKG, }.Contains(ProgramType))
                    return CheckUIType.Iosa;
                else if (new[] { ProgramType.SAFA, ProgramType.SACA, ProgramType.SANAKG, }.Contains(ProgramType))
                    return CheckUIType.Safa;

                return CheckUIType.None;
            }
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
        
        public CheckLists()
        {
            ItemId = -1;
            CheckListRecords = new List<CheckListRecords>();
            AllRevisions = new List<EditionRevisionView>();
            SmartCoreObjectType = SmartCoreType.CheckLists;
        }
    }
    

    [Serializable]
    public class EditionRevisionView
    {
        public int Number { get; set; }

        public RevisionType Type { get; set; }

        public DateTime Date { get; set; }

        public DateTime EffDate { get; set; }
        public string Remark { get; set; }
    }
}
