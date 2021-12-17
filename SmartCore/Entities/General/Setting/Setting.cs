using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
using Newtonsoft.Json;
using SmartCore.Calculations;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Setting
{
	[Table("Setting", "dbo", "ItemId")]
	[Dto(typeof(SettingDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Settings : BaseEntityObject
	{
		private GlobalSetting _globalSetting;


		[TableColumn("SettingsJSON")]
		public string SettingsJSON
		{
			get => JsonConvert.SerializeObject(GlobalSetting, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => GlobalSetting = JsonConvert.DeserializeObject<GlobalSetting>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}


		public GlobalSetting GlobalSetting
		{
			get => _globalSetting ?? (_globalSetting = new GlobalSetting());
			set => _globalSetting = value;
		}
	}

	public class GlobalSetting
	{
		private PurchaseSetting _purchaseSettings;
		private QuotationSupplierSetting _quotationSupplierSetting;
		private MailSettings _mailSettings ;

		public GlobalSetting()
		{
			
		}

		public PurchaseSetting PurchaseSettings
		{
			get => _purchaseSettings ?? (_purchaseSettings = new PurchaseSetting());
			set => _purchaseSettings = value;
		}

		public QuotationSupplierSetting QuotationSupplierSetting
		{
			get => _quotationSupplierSetting ?? (_quotationSupplierSetting = new QuotationSupplierSetting());
			set => _quotationSupplierSetting = value;
		}

		public MailSettings MailSettings
		{
			get => _mailSettings ?? (_mailSettings = new MailSettings());
			set => _mailSettings  = value;
		}
	}


	[JsonObject]
	public class QuotationSupplierSetting
	{
		private Dictionary<string, List<int>> _parameters;

		public QuotationSupplierSetting()
		{

		}

		public Dictionary<string, List<int>> Parameters
		{
			get => _parameters ?? (_parameters = new Dictionary<string, List<int>>());
			set => _parameters = value;
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

	[JsonObject]
	public class OperatorSettings
	{
		public MailSettings MailSettings { get; set; }
	}

	[JsonObject]
	public class MailSettings
	{
		public string Host { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public int Port { get; set; }
		public bool SSl { get; set; }
	}
}