using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Supplier", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SupplierDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("ShortName"), MaxLength(50)]
		public string ShortName { get; set; }

		
		[Column("AirCode"), MaxLength(256)]
		public string AirCode { get; set; }

		
		[Column("VendorCode"), MaxLength(50)]
		public string VendorCode { get; set; }

		
		[Column("Phone"), MaxLength(50)]
		public string Phone { get; set; }

		
		[Column("Fax"), MaxLength(50)]
		public string Fax { get; set; }

		
		[Column("Address"), MaxLength(200)]
		public string Address { get; set; }

		
		[Column("ContactPerson"), MaxLength(50)]
		public string ContactPerson { get; set; }

		
		[Column("Email"), MaxLength(50)]
		public string Email { get; set; }

		
		[Column("WebSite"), MaxLength(50)]
		public string WebSite { get; set; }

		
		[Column("Products"), MaxLength(200)]
		public string Products { get; set; }

		
		[Column("Approved")]
		public bool? Approved { get; set; }

		
		[Column("Remarks"), MaxLength(200)]
		public string Remarks { get; set; }

		
		[Column("SupplierClassId"), Required]
		public int SupplierClassId { get; set; }

		
		[Column("Subject")]
		public string Subject { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2048)]
		public ICollection<DocumentDTO> SupplierDocs { get; set; }


		#region Navigation Property

		
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
		
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }
		
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
		
		public ICollection<KitSuppliersRelationDTO> KitSuppliersRelationDtos { get; set; }

		#endregion
	}
}