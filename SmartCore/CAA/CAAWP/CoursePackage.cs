using System;
using System.Collections.Generic;
using System.ComponentModel;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;

namespace SmartCore.CAA.CAAWP
{
    [CAADto(typeof(CoursePackageDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CoursePackage : BaseEntityObject
    {
        public string Title { get; set; }
        public int OperatorId { get; set; }
        
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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new CAAWorkPackagekSettings() : JsonConvert.DeserializeObject<CAAWorkPackagekSettings>(value);
        }

        public CAAWorkPackagekSettings Settings { get; set; }
        
        
        
        public WPStatus Status { get; set; }
        
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case  WPStatus.Open : return $"{RoutineStatus.Open}";
                    case WPStatus.Published:
                        return "In progress";
                    case WPStatus.Closed:
                        return $"{RoutineStatus.Closed}";
                    default: return "";
                }
            }
        }
        


        public CoursePackage()
        {
            Status = WPStatus.Open;
            Settings = new CAAWorkPackagekSettings()
            {
                CreateDate = DateTime.Now,
                PublishingDate = DateTime.Now,
                ClosingDate = DateTime.Now,
                OpeningDate = DateTime.Now,
                PerformDate = DateTime.Now,
                Duration = Lifelength.Null,
                ClosingDocument =new List<Document>(),
                DocumentIds = new List<int>()
            };
            ItemId = -1;
        }
    }

    
    public enum WPStatus
    {
        Open,
        Published,
        Closed
    }

    [Serializable]
    public  class CAAWorkPackagekSettings
    {
        private Lifelength _duration;

        [JsonProperty]
        public string Number { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        
        [JsonProperty]
        public DateTime CreateDate { get; set; }
        
        [JsonProperty]
        public DateTime? PublishingDate { get; set; }
        
        [JsonProperty]
        public int Author { get; set; }
        
        [JsonProperty]
        public int ClosedBy { get; set; }
        
        [JsonProperty]
        public string PublishingRemarks { get; set; }
        
        [JsonProperty]
        public DateTime OpeningDate { get; set; }
        
        [JsonProperty]
        public DateTime? ClosingDate { get; set; }
        
        [JsonProperty]
        public int PublishedBy { get; set; }
        
        [JsonProperty]
        public string Remarks { get; set; }
        
        [JsonProperty]
        public string ClosingRemarks { get; set; }
        
        [JsonProperty]
        public string Location { get; set; }
        
        [JsonProperty]
        public byte[] DurationLifelength { get; set; }


        private List<CourseProviderPrice> _providerPrice;
        
        [JsonProperty]
        public List<CourseProviderPrice> ProviderPrice
        {
            get => _providerPrice ?? (_providerPrice = new List<CourseProviderPrice>());
            set => _providerPrice = value;
        }
        
        
        [JsonIgnore]
        public Lifelength Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                _durationByte = value.ConvertToByteArray();
            }
        }
        

        private byte[] _durationByte;
        [JsonProperty]
        public byte[] DurationyByte
        {
            get => _durationByte;
            set
            {
                _durationByte = value;
                _duration = Lifelength.ConvertFromByteArray(value);
            }
        }
        

        [JsonProperty]
        public DateTime PerformDate { get; set; }
        
        [JsonIgnore]
        public List<Document> ClosingDocument { get; set; }
        
        
        [JsonProperty]
        public List<int> DocumentIds { get; set; }

        [JsonProperty]
        public int? TaskId { get; set; }
    }
    
    
    [JsonObject]
    [Serializable]
    public class CourseProviderPrice : BaseEntityObject
    {
        [JsonIgnore] public Supplier Supplier { get; set; }

        [JsonIgnore] public CoursePackage Parent { get; set; }

        [JsonIgnore]
        [ListViewData(200, "Supplier", 1)]
        public string SupplierName
        {
            get => Supplier?.Name ?? Supplier.Unknown.Name;
        }

        [JsonProperty] public int SupplierId { get; set; }

        [ListViewData(80, "Offering", 2)]
        [JsonProperty]
        public decimal Offering { get; set; }

        [ListViewData(80, "Routine", 4)]
        [JsonProperty]
        public decimal Routine { get; set; }

        [ListViewData(80, "K for MH", 5)]
        [JsonProperty]
        public decimal RoutineKMH { get; set; }

        [ListViewData(80, "NDT", 6)]
        [JsonProperty]
        public decimal NDT { get; set; }

        [ListViewData(80, "K for MH", 7)]
        [JsonProperty]
        public decimal NDTKMH { get; set; }

        [ListViewData(80, "AD", 8)]
        [JsonProperty]
        public decimal AD { get; set; }

        [ListViewData(80, "K for MH", 9)]
        [JsonProperty]
        public decimal ADKMH { get; set; }

        [ListViewData(80, "NRC", 10)]
        [JsonProperty]
        public decimal NRC { get; set; }

        [ListViewData(80, "K for MH", 11)]
        [JsonProperty]
        public decimal NRCKMH { get; set; }

        [DefaultValue(-1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int CurrencyOfferingId { get; set; }
        
        [JsonIgnore]
        [ListViewData(80, "Currency", 12)]
        public Сurrency CurrencyOffering
        {
            get => Сurrency.GetItemById(CurrencyOfferingId);
            set => CurrencyOfferingId = value.ItemId;
        }
    }

    
}
