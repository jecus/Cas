using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class NonRoutineJobMap : BaseMap<NonRoutineJobDTO>
	{
		public NonRoutineJobMap() : base()
		{
			#region MyRegion

			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.NonRoutineJobDtos)
				.HasForeignKey(i => i.ATAChapterId);

			#endregion
		}
	}
}