
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace CAA.Entity.Core
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions opt) : base(opt)
		{
			
		}

        #region Dictionary

        public DbSet<CAAAccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }

        public DbSet<CAAAircraftOtherParameterDTO> AircraftOtherParameterDtos { get; set; }
        public DbSet<CAAAGWCategorieDTO> AGWCategorieDtos { get; set; }
        public DbSet<CAAATAChapterDTO> ATAChapterDtos { get; set; }
        public DbSet<CAADepartmentDTO> DepartmentDtos { get; set; }
        public DbSet<CAADocumentSubTypeDTO> DocumentSubTypeDtos { get; set; }
        public DbSet<CAAEmployeeSubjectDTO> EmployeeSubjectDtos { get; set; }
        public DbSet<CAAGoodStandartDTO> GoodStandartDtos { get; set; }
        public DbSet<CAALicenseRemarkRightDTO> LicenseRemarkRightDtos { get; set; }
        public DbSet<CAALocationDTO> LocationDtos { get; set; }
        public DbSet<CAALocationsTypeDTO> LocationsTypeDtos { get; set; }
        public DbSet<CAANomenclatureDTO> NomenclatureDtos { get; set; }
        public DbSet<CAARestrictionDTO> RestrictionDtos { get; set; }
        public DbSet<CAAServiceTypeDTO> ServiceTypeDtos { get; set; }
        public DbSet<CAASpecializationDTO> SpecializationDtos { get; set; }
        public DbSet<FindingLevelsDTO> FindingLevelsDtos { get; set; }

        #endregion


        #region dbo

        public DbSet<CAAAircraftDTO> AircraftDtos { get; set; }
        public DbSet<RootCauseDTO> RootCauseDtos { get; set; }
        public DbSet<CAAMaintenanceProgramChangeRecordDTO> MaintenanceProgramChangeRecordDtos { get; set; }
        public DbSet<AllOperatorsDTO> AllOperatorsDtos { get; set; }
        public DbSet<RoutineAuditDTO> RoutineAuditDtos { get; set; }
		public DbSet<CAAAttachedFileDTO> AttachedFileDtos { get; set; }
        public DbSet<CAAAircraftEquipmentDTO> AircraftEquipmentDtos { get; set; }
        public DbSet<CAAItemFileLinkDTO> ItemFileLinkDtos { get; set; }
		public DbSet<CAAUserDTO> UserDtos { get; set; }
        public DbSet<CAAOperatorDTO> OperatorDtos { get; set; }
        public DbSet<CheckListDTO> CheckListDtos { get; set; }
        public DbSet<CheckListRecordDTO> CheckListRecordDtos { get; set; }
        public DbSet<CAACategoryRecordDTO> CategoryRecordDtos { get; set; }
        public DbSet<CAADocumentDTO> DocumentDtos { get; set; }

        public DbSet<CAAProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }


        public DbSet<CAASpecialistCAADTO> SpecialistCaadtos { get; set; }
        public DbSet<CAASpecialistDTO> SpecialistDtos { get; set; }
        public DbSet<CAASpecialistInstrumentRatingDTO> SpecialistInstrumentRatingDtos { get; set; }
        public DbSet<CAASpecialistLicenseDetailDTO> SpecialistLicenseDetailDtos { get; set; }
        public DbSet<CAASpecialistLicenseDTO> SpecialistLicenseDtos { get; set; }
        public DbSet<CAASpecialistLicenseRatingDTO> SpecialistLicenseRatingDtos { get; set; }
        public DbSet<CAASpecialistLicenseRemarkDTO> SpecialistLicenseRemarkDtos { get; set; }
        public DbSet<CAASpecialistMedicalRecordDTO> SpecialistMedicalRecordDtos { get; set; }
        public DbSet<CAASpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }

        public DbSet<CAASupplierDTO> SupplierDtos { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(i => i.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckListRecordDTO>()
                .HasOne(i => i.CheckList)
                .WithMany(i => i.CheckListRecords)
                .HasForeignKey(i => i.CheckListId);

            modelBuilder.Entity<CAAAircraftEquipmentDTO>()
                .HasOne(i => i.AircraftOtherParameter)
                .WithMany(i => i.AircraftEquipmentDtos)
                .HasForeignKey(i => i.AircraftOtherParameterId);

            modelBuilder.Entity<CAAAircraftDTO>()
                .HasOne(i => i.Model)
                .WithMany(i => i.AircraftDtos)
                .HasForeignKey(i => i.ModelId);
            modelBuilder.Entity<CAAAircraftDTO>()
                .HasMany(i => i.MaintenanceProgramChangeRecords)
                .WithOne(i => i.ParentAircraftDto)
                .HasForeignKey(i => i.ParentAircraftId);

            modelBuilder.Entity<CAAItemFileLinkDTO>()
                .HasOne(i => i.File)
                .WithMany(i => i.ItemFileLinkDto)
                .HasForeignKey(i => i.FileId);


            modelBuilder.Entity<CAAAccessoryDescriptionDTO>()
                .HasOne(i => i.ATAChapter)
                .WithMany(i => i.AccessoryDescriptionDtos)
                .HasForeignKey(i => i.AtaChapterId);
            modelBuilder.Entity<CAAAccessoryDescriptionDTO>()
                .HasOne(i => i.GoodStandart)
                .WithMany(i => i.AccessoryDescriptionDtos)
                .HasForeignKey(i => i.StandartId);

            modelBuilder.Entity<CAALocationDTO>()
                .HasOne(i => i.LocationsType)
                .WithMany(i => i.LocationDtos)
                .HasForeignKey(i => i.LocationsTypeId);

            modelBuilder.Entity<CAALocationsTypeDTO>()
                .HasOne(i => i.Department)
                .WithMany(i => i.LocationsTypeDtos)
                .HasForeignKey(i => i.DepartmentId);

            modelBuilder.Entity<CAANomenclatureDTO>()
                .HasOne(i => i.Department)
                .WithMany(i => i.NomenclatureDtos)
                .HasForeignKey(i => i.DepartmentId);

            modelBuilder.Entity<CAASpecializationDTO>()
                .HasOne(i => i.Department)
                .WithMany(i => i.SpecializationDtos)
                .HasForeignKey(i => i.DepartmentId);


            modelBuilder.Entity<CAACategoryRecordDTO>()
                .HasOne(i => i.AircraftModel)
                .WithMany(i => i.CategoryRecordDtos)
                .HasForeignKey(i => i.AircraftTypeId);


            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.DocumentSubType)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.SubTypeId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.Supplier)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.SupplierId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.ResponsibleOccupation)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.ResponsibleOccupationId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.Nomenсlature)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.NomenсlatureId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.ServiceType)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.ServiceTypeId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.Department)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.DepartmentId);
            modelBuilder.Entity<CAADocumentDTO>()
                .HasOne(i => i.Location)
                .WithMany(i => i.DocumentDtos)
                .HasForeignKey(i => i.LocationId);


            modelBuilder.Entity<CAAProcedureDocumentReferenceDTO>()
                .HasOne(i => i.Document)
                .WithMany(i => i.ProcedureDocumentReferenceDtos)
                .HasForeignKey(i => i.DocumentId);


            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                 .HasOne(i => i.AircraftType)
                 .WithMany(i => i.SpecialistLicenseDtos)
                 .HasForeignKey(i => i.AircraftTypeID);
            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                .HasMany(i => i.CaaLicense).WithOne(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);
            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                .HasMany(i => i.LicenseDetails).WithOne(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);
            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                .HasMany(i => i.LicenseRatings).WithOne(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);
            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                .HasMany(i => i.SpecialistInstrumentRatings).WithOne(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);
            modelBuilder.Entity<CAASpecialistLicenseDTO>()
                .HasMany(i => i.LicenseRemark).WithOne(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);

            modelBuilder.Entity<CAASpecialistLicenseRemarkDTO>()
                .HasOne(i => i.Rights)
                .WithMany(i => i.LicenseRemarkDtos)
                .HasForeignKey(i => i.RightsId);
            modelBuilder.Entity<CAASpecialistLicenseRemarkDTO>()
                .HasOne(i => i.LicenseRestriction)
                .WithMany(i => i.LicenseRemarkDtos)
                .HasForeignKey(i => i.RestrictionId);

            modelBuilder.Entity<CAASpecialistDTO>()
                .HasOne(i => i.AGWCategory)
                .WithMany(i => i.SpecialistDtos)
                .HasForeignKey(i => i.AGWCategoryId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasOne(i => i.Facility)
                .WithMany(i => i.SpecialistDtos)
                .HasForeignKey(i => i.Location);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasOne(i => i.Specialization)
                .WithMany(i => i.SpecialistDtos)
                .HasForeignKey(i => i.SpecializationID);

            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.Licenses).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.SpecialistTrainings).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.LicenseDetails).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.LicenseRemark).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.EmployeeDocuments).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.ParentID);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.CategoriesRecords).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.ParentId);
            modelBuilder.Entity<CAASpecialistDTO>()
                .HasMany(i => i.Files).WithOne(i => i.SpecialistDto).HasForeignKey(i => i.ParentId);

            modelBuilder.Entity<CAASpecialistTrainingDTO>()
                .HasOne(i => i.AircraftType)
                .WithMany(i => i.SpecialistTrainingDtos)
                .HasForeignKey(i => i.AircraftTypeID);
            modelBuilder.Entity<CAASpecialistTrainingDTO>()
                .HasOne(i => i.EmployeeSubject)
                .WithMany(i => i.SpecialistTrainingDtos)
                .HasForeignKey(i => i.EmployeeSubjectID);
            modelBuilder.Entity<CAASpecialistTrainingDTO>()
                .HasOne(i => i.Supplier)
                .WithMany(i => i.SpecialistTrainingDtos)
                .HasForeignKey(i => i.SupplierId);
            modelBuilder.Entity<CAASpecialistTrainingDTO>()
                .HasMany(i => i.Files).WithOne(i => i.SpecialistTraining).HasForeignKey(i => i.ParentId);


            modelBuilder.Entity<CAASupplierDTO>()
                .HasMany(i => i.SupplierDocs).WithOne(i => i.SupplieDto).HasForeignKey(i => i.ParentID);


        }

    }
}