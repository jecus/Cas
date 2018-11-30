using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class VehicleDTO : BaseEntity
	{
		[DataMember]
		public int? OperatorId { get; set; }

		[DataMember]
		public string RegistrationNumber { get; set; }

		[DataMember]
		public int? ModelId { get; set; }

		[DataMember]
		public DateTime? ManufactureDate { get; set; }

		[DataMember]
		public string Owner { get; set; }

		[DataMember]
		public string CockpitSeating { get; set; }

		[DataMember]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		public DateTime? AcceptanceDate { get; set; }

		[DataMember]
		public bool? Schedule { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO Model { get; set; }

	}
}