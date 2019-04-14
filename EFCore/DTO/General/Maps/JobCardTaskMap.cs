using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class JobCardTaskMap : BaseMap<JobCardTaskDTO>
	{
		public JobCardTaskMap() : base()
		{
			ToTable("dbo.JobCardTasks");

			Property(i => i.JobCardId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardId");

			Property(i => i.ParentTaskId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTaskId");

			Property(i => i.Number)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Number");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.Man)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Man");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			HasRequired(i => i.JobCard)
				.WithMany(i => i.JobCardTaskDtos)
				.HasForeignKey(i => i.JobCardId);

		}
	}
}