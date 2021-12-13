﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("PurchaseOrders", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class PurchaseOrderDTO : BaseEntity
	{
		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("ParentID")]
		public int? ParentID { get; set; }

		
		[Column("ParentQuotationId")]
		public int? ParentQuotationId { get; set; }

		
		[Column("Status")]
		public int? Status { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("PublishedById")]
		public int? PublishedById { get; set; }

		
		[Column("ClosedById")]
		public int? ClosedById { get; set; }

		
		[Column("PublishedByUser"), MaxLength(128)]
		public string PublishedByUser { get; set; }

		
		[Column("CloseByUser"), MaxLength(128)]
		public string CloseByUser { get; set; }

		
		[Column("Number"), MaxLength(128)]
		public string Number { get; set; }

		[Column("DesignationId")]
		public int DesignationId { get; set; }

		[Column("PayTermId")]
		public int PayTermId { get; set; }

		[Column("IncoTermId")]
		public int IncoTermId { get; set; }

		[Column("ShipCompanyId")]
		public int ShipCompanyId { get; set; }

		[Column("CargoVolume")]
		public string CargoVolume { get; set; }

		[Column("BruttoWeight")]
		public string BruttoWeight { get; set; }

		[Column("NettoWeight")]
		public string NettoWeight { get; set; }

		[Column("ShipToId")]
		public int ShipToId { get; set; }

		[Column("Net")]
		public double Net { get; set; }

		[Column("IncoTermRef")]
		public string IncoTermRef { get; set; }

		[Column("StationId")]
		public int StationId { get; set; }

		[Column("TrackingNo")]
		public string TrackingNo { get; set; }

		[Column("AdditionalInformationJSON")]
		public string AdditionalInformationJSON { get; set; }

		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}