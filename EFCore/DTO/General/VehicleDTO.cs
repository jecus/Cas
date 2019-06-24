using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("Vehicles", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class VehicleDTO : BaseEntity
	{
		[DataMember]
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		[DataMember]
		[Column("RegistrationNumber"), MaxLength(256)]
		public string RegistrationNumber { get; set; }

		[DataMember]
		[Column("ModelId")]
		public int? ModelId { get; set; }

		[DataMember]
		[Column("ManufactureDate")]
		public DateTime? ManufactureDate { get; set; }

		[DataMember]
		[Column("Owner"), MaxLength(256)]
		public string Owner { get; set; }

		[DataMember]
		[Column("CockpitSeating"), MaxLength(256)]
		public string CockpitSeating { get; set; }

		[DataMember]
		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		[Column("AcceptanceDate")]
		public DateTime? AcceptanceDate { get; set; }

		[DataMember]
		[Column("Schedule")]
		public bool? Schedule { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO Model { get; set; }

	}
}