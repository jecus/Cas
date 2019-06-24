using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class InitialOrderRecordMap : BaseMap<InitialOrderRecordDTO>
	{
		public InitialOrderRecordMap() : base()
		{
			HasRequired(i => i.DeferredCategory)
				.WithMany(i => i.InitialOrderRecordDto)
				.HasForeignKey(i => i.DefferedCategory);
		}
	}
}