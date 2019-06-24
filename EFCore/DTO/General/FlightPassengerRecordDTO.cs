using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("FlightPassengerRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class FlightPassengerRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int? FlightId { get; set; }

		[DataMember]
		[Column("PassengerCategory")]
		public int? PassengerCategoryId { get; set; }

		[DataMember]
		[Column("CountEconomy")]
		public short? CountEconomy { get; set; }

		[DataMember]
		[Column("CountBusiness")]
		public short? CountBusiness { get; set; }

		[DataMember]
		[Column("CountFirst")]
		public short? CountFirst { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Include]
		public AGWCategorieDTO PassengerCategory { get; set; }
	}
}