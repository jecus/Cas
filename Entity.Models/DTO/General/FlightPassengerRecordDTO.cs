using System;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("FlightPassengerRecords", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class FlightPassengerRecordDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int? FlightId { get; set; }

		
		[Column("PassengerCategory")]
		public int? PassengerCategoryId { get; set; }

		
		[Column("CountEconomy")]
		public short? CountEconomy { get; set; }

		
		[Column("CountBusiness")]
		public short? CountBusiness { get; set; }

		
		[Column("CountFirst")]
		public short? CountFirst { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Include]
		public AGWCategorieDTO PassengerCategory { get; set; }
	}
}