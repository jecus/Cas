using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class JobCardTaskMap : BaseMap<JobCardTaskDTO>
	{
		public JobCardTaskMap() : base()
		{
			HasRequired(i => i.JobCard)
				.WithMany(i => i.JobCardTaskDtos)
				.HasForeignKey(i => i.JobCardId);

		}
	}
}