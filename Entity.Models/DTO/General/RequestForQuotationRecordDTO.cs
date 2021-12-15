﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("RequestForQuotationRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class RequestForQuotationRecordDTO : BaseEntity
	{
		
		[Column("ParentPackageId")]
		public int? ParentPackageId { get; set; }

		
		[Column("PackageItemId")]
		public int PackageItemId { get; set; }

		
		[Column("CostCondition")]
		public short CostCondition { get; set; }

		
		[Column("Processed")]
		public bool Processed { get; set; }

		
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		
		[Column("Quantity")]
		public double? Quantity { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("CostNew")]
		public double? CostNew { get; set; }

		
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		
		[Column("ToSupplier")]
		public int? ToSupplierId { get; set; }

		
		[Column("Priority")]
		public int Priority { get; set; }

		
		[Column("DefferedCategory")]
		public int? DefferedCategoryId { get; set; }

		
		[Column("DestinationObjectId")]
		public int DestinationObjectId { get; set; }

		
		[Column("DestinationObjectType")]
		public int DestinationObjectType { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("LifeLimit"), MaxLength(21)]
		public byte[] LifeLimit { get; set; }

		
		[Column("LifeLimitNotify"), MaxLength(21)]
		public byte[] LifeLimitNotify { get; set; }

		
		[Column("SettingJSON")]
		public string SettingJSON { get; set; }

		
		[Include]
		public DefferedCategorieDTO DefferedCategory { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public RequestForQuotationDTO RequestForQuotationDto { get; set; }

		#endregion
	}
}