using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceDirectiveMap : BaseMap<MaintenanceDirectiveDTO>
	{
		public MaintenanceDirectiveMap() : base()
		{
			ToTable("dbo.MaintenanceDirectives");

			Property(i => i.TaskNumberCheck)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskNumberCheck");

			Property(i => i.DirectiveTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveTypeId");

			Property(i => i.MPDTaskNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MPDTaskNumber");

			Property(i => i.MPDNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MPDNumber");

			Property(i => i.MaintenanceManual)
				.HasMaxLength(512)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceManual");

			Property(i => i.Zone)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Zone");

			Property(i => i.Access)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Access");

			Property(i => i.Applicability)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Applicability");

			Property(i => i.ATAChapterId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATAChapter");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.EngineeringOrders)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineeringOrders");

			Property(i => i.ServiceBulletinNo)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ServiceBulletinNo");

			Property(i => i.Threshold)
				.HasMaxLength(116)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.HiddenRemarks)
				.HasMaxLength(512)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.Elapsed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Elapsed");

			Property(i => i.MRB)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MRB");

			Property(i => i.TaskCardNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskCardNumber");

			Property(i => i.Program)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Program");

			Property(i => i.CriticalSystem)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CriticalSystem");

			Property(i => i.MaintenanceCheckId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceCheck");

			Property(i => i.PrintInWP)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PrintInWP");

			Property(i => i.JobCardId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCard");

			Property(i => i.NDTType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NDTType");

			Property(i => i.KitsApplicable)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitsApplicable");

			Property(i => i.ComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");

			Property(i => i.ForComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ForComponentId");

			Property(i => i.MpdRef)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MpdRef");

			Property(i => i.MpdRevisionNum)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MpdRevisionNum");

			Property(i => i.MpdOldTaskCard)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MpdOldTaskCard");

			Property(i => i.Workarea)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Workarea");

			Property(i => i.MpdRevisionDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MpdRevisionDate");

			Property(i => i.Category)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Category");

			Property(i => i.Skill)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Skill");

			Property(i => i.ScheduleItem)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ScheduleItem");

			Property(i => i.ScheduleRef)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ScheduleRef");

			Property(i => i.ScheduleRevisionNum)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ScheduleRevisionNum");

			Property(i => i.ScheduleRevisionDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ScheduleRevisionDate");

			Property(i => i.IsApplicability)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsApplicability");

			Property(i => i.IsOperatorTask)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsOperatorTask");

			Property(i => i.ProgramIndicator)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProgramIndicator");

			Property(i => i.APUCalc)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("APUCalc");

			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);


			HasRequired(i => i.BaseComponent)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ComponentId);


			HasRequired(i => i.MaintenanceCheck)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.MaintenanceCheckId);

			HasRequired(i => i.JobCard)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.JobCardId);

			HasMany(i => i.Files).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PerformanceRecords).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentID);
			HasMany(i => i.CategoriesRecords).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			HasMany(i => i.Kits).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);

		}
	}
}