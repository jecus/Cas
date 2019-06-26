using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Supplier", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SupplierDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		[DataMember]
		[Column("ShortName"), MaxLength(50)]
		public string ShortName { get; set; }

		[DataMember]
		[Column("AirCode"), MaxLength(256)]
		public string AirCode { get; set; }

		[DataMember]
		[Column("VendorCode"), MaxLength(50)]
		public string VendorCode { get; set; }

		[DataMember]
		[Column("Phone"), MaxLength(50)]
		public string Phone { get; set; }

		[DataMember]
		[Column("Fax"), MaxLength(50)]
		public string Fax { get; set; }

		[DataMember]
		[Column("Address"), MaxLength(200)]
		public string Address { get; set; }

		[DataMember]
		[Column("ContactPerson"), MaxLength(50)]
		public string ContactPerson { get; set; }

		[DataMember]
		[Column("Email"), MaxLength(50)]
		public string Email { get; set; }

		[DataMember]
		[Column("WebSite"), MaxLength(50)]
		public string WebSite { get; set; }

		[DataMember]
		[Column("Products"), MaxLength(200)]
		public string Products { get; set; }

		[DataMember]
		[Column("Approved")]
		public bool? Approved { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(200)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("SupplierClassId"), Required]
		public int SupplierClassId { get; set; }

		[DataMember]
		[Column("Subject")]
		public string Subject { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2048)]
		public ICollection<DocumentDTO> SupplierDocs { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		[DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
		[DataMember]
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }
		[DataMember]
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
		[DataMember]
		public ICollection<KitSuppliersRelationDTO> KitSuppliersRelationDtos { get; set; }

		#endregion
	}
}