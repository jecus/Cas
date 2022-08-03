using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("AllOperators", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class AllOperatorsDTO : BaseEntity
    {
        [Column("FullName"), MaxLength(200)]
        public string FullName { get; set; }

        [Column("ShortName"), MaxLength(50)]
        public string ShortName { get; set; }

        [Column("ICAOCode"), MaxLength(200)]
        public string ICAOCode { get; set; }

        [Column("Address"), MaxLength(200)]
        public string Address { get; set; }

        [Column("Phone"), MaxLength(100)]
        public string Phone { get; set; }

        [Column("Fax"), MaxLength(100)]
        public string Fax { get; set; }

        [Column("Email"), MaxLength(50)]
        public string Email { get; set; }

        [Column("Web"), MaxLength(100)]
        public string Web { get; set; }


        [Column("LogoTypeWhite", TypeName = "image")]
        public byte[] LogoTypeWhite { get; set; }

        [Column("LogoType", TypeName = "image")]
        public byte[] LogoType { get; set; }

        [Column("LogotypeReportLarge", TypeName = "image")]
        public byte[] LogotypeReportLarge { get; set; }

        [Column("LogotypeReportVeryLarge", TypeName = "image")]
        public byte[] LogotypeReportVeryLarge { get; set; }


        [Column("SettingsJSON")]
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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new AllOperatorSettings() : JsonConvert.DeserializeObject<AllOperatorSettings>(value);
        }

        [NotMapped]
        public AllOperatorSettings Settings { get; set; }
    }

    public class AllOperatorSettings
    {
        [JsonProperty("IsCommertial")]
        public bool IsCommertial { get; set; }

        [JsonProperty("IsAEMS")]
        public bool IsAEMS { get; set; }

        [JsonProperty("IsAerodromOperator")]
        public bool IsAerodromOperator { get; set; }

        [JsonProperty("IsAMO")]
        public bool IsAMO { get; set; }

        [JsonProperty("IsTraningOperation")]
        public bool IsTraningOperation { get; set; }

        [JsonProperty("IsFuel")]
        public bool IsFuel { get; set; }

        [JsonProperty("IsATC")]
        public bool IsATC { get; set; }

        [JsonProperty("TypeOperation")]
        public string TypeOperation { get; set; }

        [JsonProperty("SpecialOperation")]
        public string SpecialOperation { get; set; }

        [JsonProperty("Fleet")]
        public string Fleet { get; set; }

        [JsonProperty("Ratings")]
        public string Ratings { get; set; }
        

        [JsonProperty("Privilages")]
        public string Privilages { get; set; }

        [JsonProperty("IATACode")]
        public string IATACode { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IsAirOperator")]
        public bool IsAirOperator { get; set; }

        [JsonProperty("IsCAMO")]
        public bool IsCAMO { get; set; }

        [JsonProperty("IsCAO")]
        public bool IsCAO { get; set; }
        
        [JsonProperty("CEO")]
        public string CEO { get; set; }
        
        [JsonProperty("IsOther")]
        public bool IsOther { get; set; }
        
        [JsonProperty("OperatorStatusId")]
        public int  OperatorStatusId { get; set; }
        
        [JsonProperty("Remark")]
        public string  Remark { get; set; }
    }
}
