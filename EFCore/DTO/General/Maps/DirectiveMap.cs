using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DirectiveMap : BaseMap<DirectiveDTO>
	{
		public DirectiveMap() : base()
		{
			ToTable("dbo.Directives");

			Property(i => i.Title)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.IsApplicability)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsApplicability");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.Threshold)
				.HasMaxLength(1000)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.ThldTypeCond)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ThldTypeCond");

			Property(i => i.Applicability)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Applicability");

			Property(i => i.ATAChapterId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATAChapter");

			Property(i => i.DirectiveType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveType");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.EngineeringOrders)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineeringOrders");

			Property(i => i.EngineeringOrderFileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineeringOrderFileID");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.Highlight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Highlight");

			Property(i => i.Paragraph)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Paragraph");

			Property(i => i.KitRequired)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitRequired");

			Property(i => i.HiddenRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.ADType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ADType");

			Property(i => i.WorkType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkType");

			Property(i => i.ServiceBulletinNo)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ServiceBulletinNo");

			Property(i => i.StcNo)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StcNo");

			Property(i => i.ServiceBulletinFileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ServiceBulletinFileID");

			Property(i => i.ADFileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ADFileID");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.AircraftFlight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftFlight");
			
			Property(i => i.NDTType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NDTType");

			Property(i => i.DirectiveOrder)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveOrder");

			Property(i => i.ComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");

			Property(i => i.DeferredExtention)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DefferedExtention");

			Property(i => i.DeferredMelCdlItem)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DefferedMelCdlItem");

			Property(i => i.DeferredLogBookRef)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DefferedLogBookRef");

			Property(i => i.DeferredCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DefferedCategory");

			Property(i => i.Number)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Number");

			Property(i => i.Location)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Location");

			Property(i => i.IsTemporary)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsTemporary");

			Property(i => i.DamageLenght)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageLenght");

			Property(i => i.DamageWidth)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageWidth");

			Property(i => i.DamageDepth)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageDepth");

			Property(i => i.DamageLenghtLimit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageLenghtLimit");

			Property(i => i.DamageWidthLimit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageWidthLimit");

			Property(i => i.DamageDepthLimit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageDepthLimit");

			Property(i => i.DamageMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageMeasure");

			Property(i => i.DamageType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageType");

			Property(i => i.DamageClass)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageClass");

			Property(i => i.SupersedesId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupersedesId");

			Property(i => i.SupersededId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupersededId");

			Property(i => i.CorrectiveAction)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CorrectiveAction");

			Property(i => i.InspectionDocumentsNo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("InspectionDocumentsNo");


			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);

			HasRequired(i => i.DeferredCategory)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.DeferredCategoryId);

			HasRequired(i => i.BaseComponent)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ComponentId);

			HasMany(i => i.Files).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);
			HasMany(i => i.DamageDocs).WithRequired(i => i.Directive).HasForeignKey(i => i.DirectiveId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentID);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);

			HasMany(i => i.Kits).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);


		}
	}
}