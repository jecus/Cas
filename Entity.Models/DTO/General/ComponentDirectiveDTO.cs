using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("ComponentDirectives", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ComponentDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("DirectiveType")]
		public int DirectiveType { get; set; }

		
		[Column("Threshold"), MaxLength(200)]
		public byte[] Threshold { get; set; }

		[Column("ExpiryRemainNotify")]
		public byte[]  ExpiryRemainNotify { get; set; }


		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("Highlight")]
		public int? Highlight { get; set; }

		
		[Column("KitRequired"), MaxLength(50)]
		public string KitRequired { get; set; }

		
		[Column("FaaFormFileID")]
		public int? FaaFormFileID { get; set; }

		
		[Column("HiddenRemarks"), MaxLength(128)]
		public string HiddenRemarks { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("MPDTaskTypeId")]
		public int? MPDTaskTypeId { get; set; }

		
		[Column("NDTType")]
		public short NDTType { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		
		[Column("ZoneArea"), MaxLength(256)]
		public string ZoneArea { get; set; }

		
		[Column("AccessDirective"), MaxLength(256)]
		public string AccessDirective { get; set; }

		
		[Column("AAM"), MaxLength(256)]
		public string AAM { get; set; }

		
		[Column("CMM"), MaxLength(256)]
		public string CMM { get; set; }

		[Column("ExpiryDate")]
		public DateTime? ExpiryDate { get; set; }

		[Column("IsExpiry")]
		public bool? IsExpiry { get; set; }



		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}