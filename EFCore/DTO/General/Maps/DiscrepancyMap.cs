using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DiscrepancyMap : BaseMap<DiscrepancyDTO>
	{
		public DiscrepancyMap() : base()
		{
			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.ATAChapterID);

			HasRequired(i => i.Auth)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.AuthId);



		}
	}
}