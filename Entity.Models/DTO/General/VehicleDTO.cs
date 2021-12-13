using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;

namespace Entity.Models.DTO.General
{
	[Table("Vehicles", Schema = "dbo")]
	
	public class VehicleDTO : BaseEntity
	{
		
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		
		[Column("RegistrationNumber"), MaxLength(256)]
		public string RegistrationNumber { get; set; }

		
		[Column("ModelId")]
		public int? ModelId { get; set; }

		
		[Column("ManufactureDate")]
		public DateTime? ManufactureDate { get; set; }

		
		[Column("Owner"), MaxLength(256)]
		public string Owner { get; set; }

		
		[Column("CockpitSeating"), MaxLength(256)]
		public string CockpitSeating { get; set; }

		
		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		
		[Column("AcceptanceDate")]
		public DateTime? AcceptanceDate { get; set; }

		
		[Column("Schedule")]
		public bool? Schedule { get; set; }

		
		[Child]
		public AccessoryDescriptionDTO Model { get; set; }

	}
}