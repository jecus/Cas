using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class JobCardMap : BaseMap<JobCardDTO>
	{
		public JobCardMap() : base()
		{
			HasRequired(i => i.PreparedBy)
				.WithMany(i => i.PreparedJobCardDtos)
				.HasForeignKey(i => i.PreparedById);

			HasRequired(i => i.CheckedBy)
				.WithMany(i => i.CheckedJobCardDtos)
				.HasForeignKey(i => i.CheckedById);

			HasRequired(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedJobCardDtos)
				.HasForeignKey(i => i.ApprovedById);

			HasRequired(i => i.AtaChapter)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.AtaChapterId);


			HasRequired(i => i.Qualification)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.QualificationId);

			HasMany(i => i.Kits).WithRequired(i => i.JobCardDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.JobCardTasks).WithRequired(i => i.JobCardDto).HasForeignKey(i => i.JobCardId);
		}
	}
}