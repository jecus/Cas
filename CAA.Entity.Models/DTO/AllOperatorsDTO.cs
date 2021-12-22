﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("AllOperators", Schema = "dbo")]
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

        [JsonProperty("AemcPrivilages")]
        public string AemcPrivilages { get; set; }

        [JsonProperty("Ratings")]
        public string Ratings { get; set; }

        [JsonProperty("TraningOrgPrivilages")]
        public string TraningOrgPrivilages { get; set; }
    }
}
