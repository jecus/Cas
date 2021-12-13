using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;

namespace Entity.Models.DTO.General
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