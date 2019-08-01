using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("FlightPassengerRecords", Schema = "dbo")]
	
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