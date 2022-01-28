using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Audit
{
    public enum RoutineStatus
    {
        Open,
        Published,
        Closed
    }

    [CAADto(typeof(CAAAuditDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CAAAudit : BaseEntityObject , IAuditFilterParams
    {
        public double MH { get; set; }
        public string KMLW
        {
            get
            {
                var res = ((double) Settings.KMH) * MH;
                return res.ToString();
            }
        }


        public string WorkTime
        {
            get
            {
                if (Settings.Status == RoutineStatus.Closed)
                {
                    var diff = Settings.ClosingDate.Subtract(Settings.PublishingDate);
                    return diff.TotalDays > 0 ?  $"{diff.TotalDays}d {diff.Minutes}m" : $"{diff.Minutes}m";
                }
                return "";
            }
        }

        public string AuditNumber { get; set; }

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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new CAAAuditSettings() : JsonConvert.DeserializeObject<CAAAuditSettings>(value);
        }

        public CAAAuditSettings Settings { get; set; }

        public AllOperators Operator { get; set; }


        public CAAAudit()
        {
            Settings = new CAAAuditSettings()
            {
                Status = RoutineStatus.Open,
                WorkflowStageId = -1,
                PublishingDate =  DateTimeExtend.GetCASMinDateTime(),
                ClosingDate = DateTimeExtend.GetCASMinDateTime(),
                CreateDate = DateTime.Today
            };
            SmartCoreObjectType = SmartCoreType.CAAAudit;
            ItemId = -1;
        }
    }


    [Serializable]
    public class CAAAuditSettings
    {
        public CAAAuditSettings()
        {

        }

        [JsonProperty("Status")]
        public RoutineStatus Status { get; set; }

        [JsonProperty("WorkflowStageId")]
        public int WorkflowStageId { get; set; }


        #region public DateTime CreateDate { get; set; }

        private DateTime _createDate;
        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        [JsonProperty("CreateDate")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                var min = DateTimeExtend.GetCASMinDateTime();
                if (_createDate < min || _createDate != value)
                {
                    _createDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
                }
            }
        }

        #endregion

        #region public DateTime PublishingDate { get; set; }

        private DateTime _publishingDate;
        /// <summary>
        /// Дата публикации рабочего пакета 
        /// </summary>
        [JsonProperty("PublishingDate")]
        public DateTime PublishingDate
        {
            get { return _publishingDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _publishingDate; }
            set
            {
                var min = DateTimeExtend.GetCASMinDateTime();
                if (_publishingDate < min || _publishingDate != value)
                {
                    _publishingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
                }
            }
        }

        #endregion

        #region public DateTime ClosingDate { get; set; }

        private DateTime _closingDate;
        /// <summary>
        /// Дата закрытия рабочего пакета
        /// </summary>
        [JsonProperty("ClosingDate")]
        public DateTime ClosingDate
        {
            get { return _closingDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _closingDate; }
            set
            {
                var min = DateTimeExtend.GetCASMinDateTime();
                if (_closingDate < min || _closingDate != value)
                {
                    _closingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
                }
            }
        }

        #endregion


        [JsonProperty("OperatorId")]
        public int OperatorId { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("AuthorId")]
        public int AuthorId { get; set; }
        [JsonProperty("PublishedId")]
        public int PublishedId { get; set; }
        [JsonProperty("ClosedId")]
        public int ClosedId { get; set; }
        [JsonProperty("KMH")]
        public decimal KMH { get; set; }


    }

}
