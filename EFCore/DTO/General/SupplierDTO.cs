using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SupplierDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string ShortName { get; set; }

		[DataMember]
		public string AirCode { get; set; }

		[DataMember]
		public string VendorCode { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Fax { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public string ContactPerson { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string WebSite { get; set; }

		[DataMember]
		public string Products { get; set; }

		[DataMember]
		public bool? Approved { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int SupplierClassId { get; set; }

		[DataMember]
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
		public ICollection<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		[DataMember]
		public ICollection<RequestForQuotationDTO> RequestForQuotationDtos { get; set; }
		[DataMember]
		public ICollection<PurchaseRequestRecordDTO> PurchaseRequestRecordDtos { get; set; }
		[DataMember]
		public ICollection<PurchaseOrderDTO> PurchaseOrderDtos { get; set; }
		[DataMember]
		public ICollection<KitSuppliersRelationDTO> KitSuppliersRelationDtos { get; set; }

		[DataMember]
		public ICollection<InitialOrderDTO> InitialOrderDtos { get; set; }

		[DataMember]
		public ICollection<RequestForQuotationDTO> QuotationDtos { get; set; }

		#endregion
	}
}