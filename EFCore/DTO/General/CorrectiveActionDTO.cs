using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class CorrectiveActionDTO : BaseEntity
	{
		[DataMember]
		public int DiscrepancyID { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string ShortDescription { get; set; }

		[DataMember]
		public string ADDNo { get; set; }

		[DataMember]
		public bool IsClosed { get; set; }

		[DataMember]
		public string PartNumberOff { get; set; }

		[DataMember]
		public string SerialNumberOff { get; set; }

		[DataMember]
		public string PartNumberOn { get; set; }

		[DataMember]
		public string SerialNumberOn { get; set; }

		[DataMember]
		public int CRSID { get; set; }
	}
}