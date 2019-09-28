using System;
using System.Collections.Generic;
using EntityCore.DTO.General;
using Newtonsoft.Json;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Setting
{
	[Table("Setting", "dbo", "ItemId")]
	[Dto(typeof(SettingDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Settings : BaseEntityObject
	{
		private  PurchaseSetting _purchaseSettings;

		[TableColumn("SettingsJSON")]
		public string SettingsJSON
		{
			get => JsonConvert.SerializeObject(PurchaseSettings, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => PurchaseSettings = JsonConvert.DeserializeObject<PurchaseSetting>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		public PurchaseSetting PurchaseSettings
		{
			get => _purchaseSettings ?? (_purchaseSettings = new PurchaseSetting());
			set => _purchaseSettings = value;
		}
	}

	[JsonObject]
	public class PurchaseSetting
	{
		public PurchaseSetting()
		{
			
		}

		public Dictionary<string, List<Lifelength>> Parameters { get; set; }
	}
}