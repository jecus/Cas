using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.DTO.General.Maps;
using Microsoft.EntityFrameworkCore;

namespace EFCore.DTO
{
	public class DataContext : DbContext
	{
		private const string _connection = "data source=91.213.233.139;initial catalog=ScatDBTest;user id=casadmin;password=casadmin001;MultipleActiveResultSets=True;App=EntityFramework";

		#region Constructor

		public DataContext() : base(new DbContextOptionsBuilder().UseSqlServer(_connection).Options)
		{
			this.Database.SetCommandTimeout(180);
		}

		public DataContext(string connectionString) : base(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
		{
			this.Database.SetCommandTimeout(180);
		}

		#endregion

		#region Dictionary

		public DbSet<NonRoutineJobDTO> NonRoutineJobDtos { get; set; }
		public DbSet<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		public DbSet<AGWCategorieDTO> AGWCategorieDtos { get; set; }
		public DbSet<AircraftOtherParameterDTO> AircraftOtherParameterDtos { get; set; }
		public DbSet<AirportCodeDTO> AirportCodeDtos { get; set; }
		public DbSet<AirportDTO> AirportDtos { get; set; }
		public DbSet<ATAChapterDTO> ATAChapterDtos { get; set; }
		public DbSet<CruiseLevelDTO> CruiseLevelDtos { get; set; }
		public DbSet<DamageChartDTO> DamageChartDtos { get; set; }
		public DbSet<DefferedCategorieDTO> DefferedCategorieDtos { get; set; }
		public DbSet<DepartmentDTO> DepartmentDtos { get; set; }
		public DbSet<DocumentSubTypeDTO> DocumentSubTypeDtos { get; set; }
		public DbSet<EmployeeSubjectDTO> EmployeeSubjectDtos { get; set; }
		public DbSet<EventCategorieDTO> EventCategorieDtos { get; set; }
		public DbSet<EventClassDTO> EventClassDtos { get; set; }
		public DbSet<FlightNumDTO> FlightNumDtos { get; set; }
		public DbSet<GoodStandartDTO> GoodStandartDtos { get; set; }
		public DbSet<LicenseRemarkRightDTO> LicenseRemarkRightDtos { get; set; }
		public DbSet<LifeLimitCategorieDTO> LifeLimitCategorieDtos { get; set; }
		public DbSet<LocationDTO> LocationDtos { get; set; }
		public DbSet<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		public DbSet<NomenclatureDTO> NomenclatureDtos { get; set; }
		public DbSet<ReasonDTO> ReasonDtos { get; set; }
		public DbSet<RestrictionDTO> RestrictionDtos { get; set; }
		public DbSet<SchedulePeriodDTO> SchedulePeriodDtos { get; set; }
		public DbSet<ServiceTypeDTO> ServiceTypeDtos { get; set; }
		public DbSet<SpecializationDTO> SpecializationDtos { get; set; }
		public DbSet<TripNameDTO> TripNameDtos { get; set; }

		#endregion

		#region dbo

		public DbSet<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
		public DbSet<ActualStateRecordDTO> ActualStateRecordDtos { get; set; }
		public DbSet<AircraftDTO> AircraftDtos { get; set; }
		public DbSet<AircraftEquipmentDTO> AircraftEquipmentDtos { get; set; }
		public DbSet<AircraftFlightDTO> AircraftFlightDtos { get; set; }
		public DbSet<AircraftWorkerCategoryDTO> AircraftWorkerCategoryDtos  { get; set; }
		public DbSet<ATLBDTO> Atlbdtos { get; set; }
		public DbSet<AttachedFileDTO> AttachedFileDtos { get; set; }
		public DbSet<AuditDTO> AuditDtos { get; set; }
		public DbSet<AuditRecordDTO> AuditRecordDtos { get; set; }
		public DbSet<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		public DbSet<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceDtos { get; set; }
		public DbSet<ComponentDirectiveDTO> ComponentDirectiveDtos { get; set; }
		public DbSet<ComponentDTO> ComponentDtos { get; set; }
		public DbSet<ComponentLLPCategoryChangeRecordDTO> ComponentLLPCategoryChangeRecordDtos { get; set; }
		public DbSet<ComponentLLPCategoryDataDTO> ComponentLLPCategoryDataDtos { get; set; }
		public DbSet<ComponentOilConditionDTO> ComponentOilConditionDtos { get; set; }
		public DbSet<ComponentWorkInRegimeParamDTO> ComponentWorkInRegimeParamDtos { get; set; }
		public DbSet<CorrectiveActionDTO> CorrectiveActionDtos { get; set; }
		public DbSet<DamageDocumentDTO> DamageDocumentDtos { get; set; }
		public DbSet<DamageSectorDTO> DamageSectorDtos { get; set; }
		public DbSet<DirectiveDTO> DirectiveDtos  { get; set; }
		public DbSet<DirectiveRecordDTO> DirectiveRecordDtos { get; set; }
		public DbSet<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		public DbSet<DocumentDTO> DocumentDtos { get; set; }
		public DbSet<EngineAccelerationTimeDTO> EngineAccelerationTimeDtos { get; set; }
		public DbSet<EngineConditionDTO> EngineConditionDtos { get; set; }
		public DbSet<EngineTimeInRegimeDTO> EngineTimeInRegimeDtos { get; set; }
		public DbSet<EventConditionDTO> EventConditionDtos { get; set; }
		public DbSet<EventDTO> EventDtos { get; set; }
		public DbSet<EventTypeRiskLevelChangeRecordDTO> EventTypeRiskLevelChangeRecordDtos { get; set; }
		public DbSet<FlightCargoRecordDTO> FlightCargoRecordDtos { get; set; }
		public DbSet<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
		public DbSet<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
		public DbSet<FlightNumberAirportRelationDTO> FlightNumberAirportRelationDtos { get; set; }
		public DbSet<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
		public DbSet<FlightNumberDTO> FlightNumberDtos { get; set; }
		public DbSet<FlightNumberPeriodDTO> FlightNumberPeriodDtos { get; set; }
		public DbSet<FlightPassengerRecordDTO> FlightPassengerRecordDtos { get; set; }
		public DbSet<FlightPlanOpsDTO> FlightPlanOpsDtos { get; set; }
		public DbSet<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }
		public DbSet<FlightTrackDTO> FlightTrackDtos { get; set; }
		public DbSet<FlightTrackRecordDTO> FlightTrackRecordDtos { get; set; }
		public DbSet<HangarDTO> HangarDtos { get; set; }
		public DbSet<HydraulicConditionDTO> HydraulicConditionDtos { get; set; }
		public DbSet<InitialOrderDTO> InitialOrderDtos { get; set; }
		public DbSet<InitialOrderRecordDTO> InitialOrderRecordDtos { get; set; }
		public DbSet<ItemFileLinkDTO> ItemFileLinkDtos { get; set; }
		public DbSet<ItemsRelationDTO> ItemsRelationDtos { get; set; }
		public DbSet<JobCardDTO> JobCardDtos { get; set; }
		public DbSet<JobCardTaskDTO> JobCardTaskDtos { get; set; }
		public DbSet<KitSuppliersRelationDTO> KitSuppliersRelationDtos { get; set; }
		public DbSet<KnowledgeModuleDTO> KnowledgeModuleDtos { get; set; }
		public DbSet<LandingGearConditionDTO> LandingGearConditionDtos { get; set; }
		public DbSet<MaintenanceCheckBindTaskRecordDTO> MaintenanceCheckBindTaskRecordDtos { get; set; }
		public DbSet<MaintenanceCheckDTO> MaintenanceCheckDtos { get; set; }
		public DbSet<MaintenanceCheckTypeDTO> MaintenanceCheckTypeDtos { get; set; }
		public DbSet<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		public DbSet<MaintenanceProgramChangeRecordDTO> MaintenanceProgramChangeRecordDtos { get; set; }
		public DbSet<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		public DbSet<MTOPCheckDTO> MtopCheckDtos { get; set; }
		public DbSet<MTOPCheckRecordDTO> MtopCheckRecordDtos { get; set; }
		public DbSet<OperatorDTO> OperatorDtos { get; set; }
		public DbSet<ProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }
		public DbSet<ProcedureDTO> ProcedureDtos { get; set; }
		public DbSet<ProductCostDTO> ProductCostDtos { get; set; }
		public DbSet<PurchaseOrderDTO> PurchaseOrderDtos { get; set; }
		public DbSet<PurchaseRequestRecordDTO> PurchaseRequestRecordDtos { get; set; }
		public DbSet<RequestDTO> RequestDtos { get; set; }
		public DbSet<RequestForQuotationDTO> RequestForQuotationDtos { get; set; }
		public DbSet<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		public DbSet<RequestRecordDTO> RequestRecordDtos { get; set; }
		public DbSet<RunUpDTO> RunUpDtos { get; set; }
		public DbSet<SmsEventTypeDTO> SmsEventTypeDtos { get; set; }
		public DbSet<SpecialistCAADTO> SpecialistCaadtos { get; set; }
		public DbSet<SpecialistDTO> SpecialistDtos { get; set; }
		public DbSet<SpecialistInstrumentRatingDTO> SpecialistInstrumentRatingDtos { get; set; }
		public DbSet<SpecialistLicenseDetailDTO> SpecialistLicenseDetailDtos { get; set; }
		public DbSet<SpecialistLicenseDTO> SpecialistLicenseDtos { get; set; }
		public DbSet<SpecialistLicenseRatingDTO> SpecialistLicenseRatingDtos { get; set; }
		public DbSet<SpecialistLicenseRemarkDTO> SpecialistLicenseRemarkDtos { get; set; }
		public DbSet<SpecialistMedicalRecordDTO> SpecialistMedicalRecordDtos { get; set; }
		public DbSet<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
		public DbSet<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }
		public DbSet<StoreDTO> StoreDtos { get; set; }
		public DbSet<SupplierDocumentDTO> SupplierDocumentDtos { get; set; }
		public DbSet<SupplierDTO> SupplierDtos { get; set; }
		public DbSet<TransferRecordDTO> TransferRecordDtos { get; set; }
		public DbSet<VehicleDTO> VehicleDtos { get; set; }
		public DbSet<WorkOrderDTO> WorkOrderDtos { get; set; }
		public DbSet<WorkOrderRecordDTO> WorkOrderRecordDtos { get; set; }
		public DbSet<WorkPackageDTO> WorkPackageDtos { get; set; }
		public DbSet<WorkPackageRecordDTO> WorkPackageRecordDtos { get; set; }
		public DbSet<WorkPackageSpecialistsDTO> WorkPackageSpecialistsDtos { get; set; }
		public DbSet<WorkShopDTO> WorkShopDtos { get; set; }
		public DbSet<UserDTO> UserDtos { get; set; }
		public DbSet<QuotationCostDTO> QuotationCostDtos { get; set; }

		#endregion
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region DictionaryMap

			modelBuilder.Entity<NonRoutineJobDTO>()
				.HasOne(i => i.ATAChapter)
				.WithMany(i => i.NonRoutineJobDtos)
				.HasForeignKey(i => i.ATAChapterId);


			modelBuilder.Entity<AccessoryDescriptionDTO>()
				.HasOne(i => i.ATAChapter)
				.WithMany(i => i.AccessoryDescriptionDtos)
				.HasForeignKey(i => i.AtaChapterId);
			modelBuilder.Entity<AccessoryDescriptionDTO>()
				.HasOne(i => i.GoodStandart)
				.WithMany(i => i.AccessoryDescriptionDtos)
				.HasForeignKey(i => i.StandartId);
			modelBuilder.Entity<AccessoryDescriptionDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.AccessoryDescription)
				.HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<AccessoryDescriptionDTO>()
				.HasMany(i => i.SupplierRelations)
				.WithOne(i => i.AccessoryDescriptionDto)
				.HasForeignKey(i => i.KitId);

			modelBuilder.Entity<DamageChartDTO>()
				.HasOne(i => i.AccessoryDescription)
				.WithMany(i => i.DamageChartDtos)
				.HasForeignKey(i => i.AircraftModelId);
			modelBuilder.Entity<DamageChartDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.DamageChart)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<DefferedCategorieDTO>()
				.HasOne(i => i.AccessoryDescription)
				.WithMany(i => i.DefferedCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			modelBuilder.Entity<LifeLimitCategorieDTO>()
				.HasOne(i => i.AccessoryDescription)
				.WithMany(i => i.LifeLimitCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			modelBuilder.Entity<LocationDTO>()
				.HasOne(i => i.LocationsType)
				.WithMany(i => i.LocationDtos)
				.HasForeignKey(i => i.LocationsTypeId);

			modelBuilder.Entity<LocationsTypeDTO>()
				.HasOne(i => i.Department)
				.WithMany(i => i.LocationsTypeDtos)
				.HasForeignKey(i => i.DepartmentId);


			modelBuilder.Entity<NomenclatureDTO>()
				.HasOne(i => i.Department)
				.WithMany(i => i.NomenclatureDtos)
				.HasForeignKey(i => i.DepartmentId);

			modelBuilder.Entity<SpecializationDTO>()
				.HasOne(i => i.Department)
				.WithMany(i => i.SpecializationDtos)
				.HasForeignKey(i => i.DepartmentId);


			#endregion

			#region dboMap

			modelBuilder.Entity<AccessoryRequiredDTO>()
				.HasOne(i => i.Product)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.AccessoryDescriptionId);
			modelBuilder.Entity<AccessoryRequiredDTO>()
				.HasOne(i => i.Standart)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.GoodStandartId);

			modelBuilder.Entity<AircraftDTO>()
				.HasOne(i => i.Model)
				.WithMany(i => i.AircraftDtos)
				.HasForeignKey(i => i.ModelId);
			modelBuilder.Entity<AircraftDTO>()
				.HasMany(i => i.MaintenanceProgramChangeRecords)
				.WithOne(i => i.ParentAircraftDto)
				.HasForeignKey(i => i.ParentAircraftId);

			modelBuilder.Entity<AircraftEquipmentDTO>()
				.HasOne(i => i.AircraftOtherParameter)
				.WithMany(i => i.AircraftEquipmentDtos)
				.HasForeignKey(i => i.AircraftOtherParameterId);

			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.FlightNumber)
				.WithMany(i => i.AircraftFlightDtos)
				.HasForeignKey(i => i.FlightNumberId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.Level)
				.WithMany(i => i.AircraftFlightDtos)
				.HasForeignKey(i => i.LevelId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.StationFromDto)
				.WithMany(i => i.AircraftFlightsFrom)
				.HasForeignKey(i => i.StationFromId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.StationToDto)
				.WithMany(i => i.AircraftFlightsTo)
				.HasForeignKey(i => i.StationToId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.CancelReason)
				.WithMany(i => i.AircraftFlightsCancel)
				.HasForeignKey(i => i.CancelReasonId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasOne(i => i.DelayReason)
				.WithMany(i => i.AircraftFlightsDelay)
				.HasForeignKey(i => i.DelayReasonId);
			modelBuilder.Entity<AircraftFlightDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.AircraftFlight)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<ATLBDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.Atlb)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<AuditDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.Audit)
				.HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<AuditDTO>()
				.HasMany(i => i.AuditRecords)
				.WithOne(i => i.Audit)
				.HasForeignKey(i => i.AuditId);

			modelBuilder.Entity<CategoryRecordDTO>()
			.HasOne(i => i.AircraftModel)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftTypeId);
			modelBuilder.Entity<CategoryRecordDTO>()
			.HasOne(i => i.AircraftWorkerCategory)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);

			modelBuilder.Entity<CertificateOfReleaseToServiceDTO>()
			.HasOne(i => i.AuthorizationB1)
				.WithMany(i => i.CertificateOfReleaseToServiceB1Dtos)
				.HasForeignKey(i => i.AuthorizationB1Id);
			modelBuilder.Entity<CertificateOfReleaseToServiceDTO>()
			.HasOne(i => i.AuthorizationB2)
				.WithMany(i => i.CertificateOfReleaseToServiceB2Dtos)
				.HasForeignKey(i => i.AuthorizationB2Id);


			modelBuilder.Entity<ComponentDirectiveDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.ComponentDirective)
				.HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<ComponentDirectiveDTO>()
				.HasMany(i => i.PerformanceRecords)
				.WithOne(i => i.ComponentDirective)
				.HasForeignKey(i => i.ParentID);
			modelBuilder.Entity<ComponentDirectiveDTO>()
				.HasMany(i => i.Kits)
				.WithOne(i => i.ComponentDirective)
				.HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<ComponentDirectiveDTO>()
				.HasMany(i => i.CategoriesRecords)
				.WithOne(i => i.ComponentDirective)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<ComponentLLPCategoryChangeRecordDTO>()
			.HasOne(i => i.ToCategory)
				.WithMany(i => i.CategoryChangeRecordDto)
				.HasForeignKey(i => i.ToCategoryId);
			modelBuilder.Entity<ComponentLLPCategoryChangeRecordDTO>()
				.HasMany(i => i.Files)
				.WithOne(i => i.CategoryChangeRecord)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<ComponentLLPCategoryDataDTO>()
			.HasOne(i => i.ParentCategory)
				.WithMany(i => i.CategoryDataDtos)
				.HasForeignKey(i => i.LLPCategoryId);

			modelBuilder.Entity<ComponentDTO>()
			.HasOne(i => i.ATAChapter)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ATAChapterId);
			modelBuilder.Entity<ComponentDTO>()
				.HasOne(i => i.Model)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ModelId);
			modelBuilder.Entity<ComponentDTO>()
				.HasOne(i => i.Location)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.LocationId);
			modelBuilder.Entity<ComponentDTO>()
				.HasOne(i => i.FromSupplier)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.FromSupplierId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.SupplierRelations).WithOne(i => i.Component).HasForeignKey(i => i.KitId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.Files).WithOne(i => i.Component).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.LLPData).WithOne(i => i.Component).HasForeignKey(i => i.ComponentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.CategoriesRecords).WithOne(i => i.Component).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.Component).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.ActualStateRecords).WithOne(i => i.Component).HasForeignKey(i => i.ComponentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.TransferRecords).WithOne(i => i.Component).HasForeignKey(i => i.ParentID);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.ComponentDirectives).WithOne(i => i.Component).HasForeignKey(i => i.ComponentId);
			modelBuilder.Entity<ComponentDTO>()
				.HasMany(i => i.ChangeLLPCategoryRecords).WithOne(i => i.Component).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<DamageDocumentDTO>()
				.HasMany(i => i.Files).WithOne(i => i.DamageDocument).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<DamageDocumentDTO>()
				.HasMany(i => i.DamageSectors).WithOne(i => i.DamageDocument).HasForeignKey(i => i.DamageDocumentId);

			modelBuilder.Entity<DirectiveDTO>()
				.HasOne(i => i.ATAChapter)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasOne(i => i.DeferredCategory)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.DeferredCategoryId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasOne(i => i.BaseComponent)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ComponentId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasMany(i => i.Files).WithOne(i => i.Directive).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasMany(i => i.DamageDocs).WithOne(i => i.Directive).HasForeignKey(i => i.DirectiveId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasMany(i => i.PerformanceRecords).WithOne(i => i.Directive).HasForeignKey(i => i.ParentID);
			modelBuilder.Entity<DirectiveDTO>()
				.HasMany(i => i.CategoriesRecords).WithOne(i => i.Directive).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<DirectiveDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.Directive).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<DirectiveRecordDTO>()
				.HasMany(i => i.Files).WithOne(i => i.DirectiveRecord).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<DirectiveRecordDTO>()
				.HasMany(i => i.FilesForMaintenanceCheckRecord).WithOne(i => i.MaintenanceCheckRecord).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<DiscrepancyDTO>()
				.HasOne(i => i.ATAChapter)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.ATAChapterID);
			modelBuilder.Entity<DiscrepancyDTO>()
				.HasOne(i => i.Auth)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.AuthId);

			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.DocumentSubType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SubTypeId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.Supplier)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SupplierId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.ResponsibleOccupation)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ResponsibleOccupationId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.Nomenсlature)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.NomenсlatureId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.ServiceType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ServiceTypeId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.Department)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.DepartmentId);
			modelBuilder.Entity<DocumentDTO>()
				.HasOne(i => i.Location)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.LocationId);

			modelBuilder.Entity<EventDTO>()
				.HasOne(i => i.EventType)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventTypeId);
			modelBuilder.Entity<EventDTO>()
				.HasOne(i => i.EventCategory)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventCategoryId);
			modelBuilder.Entity<EventDTO>()
				.HasOne(i => i.EventClass)
				.WithMany(i => i.EventDtos)
				.HasForeignKey(i => i.EventClassId);
			modelBuilder.Entity<EventDTO>()
				.HasMany(i => i.EventConditions).WithOne(i => i.Event).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<EventTypeRiskLevelChangeRecordDTO>()
				.HasOne(i => i.EventCategory)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.EventCategoryId);
			modelBuilder.Entity<EventTypeRiskLevelChangeRecordDTO>()
				.HasOne(i => i.EventClass)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.EventClassId);
			modelBuilder.Entity<EventTypeRiskLevelChangeRecordDTO>()
				.HasOne(i => i.ParentEventType)
				.WithMany(i => i.ChangeRecordDtos)
				.HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<FlightCrewRecordDTO>()
				.HasOne(i => i.Specialist)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecialistID);
			modelBuilder.Entity<FlightCrewRecordDTO>()
				.HasOne(i => i.Specialization)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationID);

			modelBuilder.Entity<FlightNumberAircraftModelRelationDTO>()
				.HasOne(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);
			modelBuilder.Entity<FlightNumberAircraftModelRelationDTO>()
				.HasOne(i => i.AircraftModel)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.AircraftModelId);

			modelBuilder.Entity<FlightNumberAirportRelationDTO>()
				.HasOne(i => i.FlightNumber)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);
			modelBuilder.Entity<FlightNumberAirportRelationDTO>()
				.HasOne(i => i.Airport)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.AirportId);

			modelBuilder.Entity<FlightNumberCrewRecordDTO>()
				.HasOne(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.FlightNumberId);
			modelBuilder.Entity<FlightNumberCrewRecordDTO>()
				.HasOne(i => i.Specialization)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationId);

			modelBuilder.Entity<FlightNumberDTO>()
				.HasOne(i => i.StationFrom)
				.WithMany(i => i.From)
				.HasForeignKey(i => i.StationFromId);
			modelBuilder.Entity<FlightNumberDTO>()
				.HasOne(i => i.StationTo)
				.WithMany(i => i.To)
				.HasForeignKey(i => i.StationToId);
			modelBuilder.Entity<FlightNumberDTO>()
				.HasOne(i => i.MinLevel)
				.WithMany(i => i.FlightNumberDtos)
				.HasForeignKey(i => i.MinLevelId);
			modelBuilder.Entity<FlightNumberDTO>()
				.HasOne(i => i.FlightNo)
				.WithMany(i => i.FlightNumberDtos)
				.HasForeignKey(i => i.FlightNoId);

			modelBuilder.Entity<FlightPassengerRecordDTO>()
				.HasOne(i => i.PassengerCategory)
				.WithMany(i => i.FlightPassengerRecordDtos)
				.HasForeignKey(i => i.PassengerCategoryId);

			modelBuilder.Entity<FlightPlanOpsRecordsDTO>()
				.HasOne(i => i.ParentFlightPlanOps)
				.WithMany(i => i.FlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.FlightPlanOpsId);
			modelBuilder.Entity<FlightPlanOpsRecordsDTO>()
				.HasOne(i => i.DelayReason)
				.WithMany(i => i.DelayFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.DelayReasonId);
			modelBuilder.Entity<FlightPlanOpsRecordsDTO>()
				.HasOne(i => i.Reason)
				.WithMany(i => i.ReasonFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.ReasonId);
			modelBuilder.Entity<FlightPlanOpsRecordsDTO>()
				.HasOne(i => i.CancelReason)
				.WithMany(i => i.CancelFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.CancelReasonId);

			modelBuilder.Entity<FlightTrackDTO>()
				.HasOne(i => i.TripName)
				.WithMany(i => i.FlightTrackDtos)
				.HasForeignKey(i => i.TripNameId);
			modelBuilder.Entity<FlightTrackDTO>()
				.HasOne(i => i.Supplier)
				.WithMany(i => i.FlightTrackDtos)
				.HasForeignKey(i => i.SupplierID);
			modelBuilder.Entity<FlightTrackDTO>()
				.HasMany(i => i.FlightTripRecord).WithOne(i => i.FlightTrack).HasForeignKey(i => i.FlightTripId);


			modelBuilder.Entity<InitialOrderDTO>()
				.HasMany(i => i.Files).WithOne(i => i.InitialOrderDto).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<InitialOrderDTO>()
				.HasMany(i => i.PackageRecords).WithOne(i => i.InitialOrderDto).HasForeignKey(i => i.ParentPackageId);

			modelBuilder.Entity<InitialOrderRecordDTO>()
				.HasOne(i => i.DeferredCategory)
				.WithMany(i => i.InitialOrderRecordDto)
				.HasForeignKey(i => i.DefferedCategory);

			modelBuilder.Entity<ItemFileLinkDTO>()
				.HasOne(i => i.File)
				.WithMany(i => i.ItemFileLinkDto)
				.HasForeignKey(i => i.FileId);


			modelBuilder.Entity<JobCardDTO>()
				.HasOne(i => i.PreparedBy)
				.WithMany(i => i.PreparedJobCardDtos)
				.HasForeignKey(i => i.PreparedById);
			modelBuilder.Entity<JobCardDTO>()
				.HasOne(i => i.CheckedBy)
				.WithMany(i => i.CheckedJobCardDtos)
				.HasForeignKey(i => i.CheckedById);
			modelBuilder.Entity<JobCardDTO>()
				.HasOne(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedJobCardDtos)
				.HasForeignKey(i => i.ApprovedById);
			modelBuilder.Entity<JobCardDTO>()
				.HasOne(i => i.AtaChapter)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.AtaChapterId);
			modelBuilder.Entity<JobCardDTO>()
				.HasOne(i => i.Qualification)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.QualificationId);
			modelBuilder.Entity<JobCardDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.JobCardDto).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<JobCardDTO>()
				.HasMany(i => i.JobCardTasks).WithOne(i => i.JobCardDto).HasForeignKey(i => i.JobCardId);

			modelBuilder.Entity<JobCardTaskDTO>()
				.HasOne(i => i.JobCard)
				.WithMany(i => i.JobCardTaskDtos)
				.HasForeignKey(i => i.JobCardId);

			modelBuilder.Entity<KitSuppliersRelationDTO>()
				.HasOne(i => i.Supplier)
				.WithMany(i => i.KitSuppliersRelationDtos)
				.HasForeignKey(i => i.SupplierId);

			modelBuilder.Entity<MaintenanceCheckDTO>()
				.HasOne(i => i.CheckType)
				.WithMany(i => i.MaintenanceCheckDtos)
				.HasForeignKey(i => i.CheckTypeId);
			modelBuilder.Entity<MaintenanceCheckDTO>()
				.HasMany(i => i.PerformanceRecords).WithOne(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentID);
			modelBuilder.Entity<MaintenanceCheckDTO>()
				.HasMany(i => i.CategoriesRecords).WithOne(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<MaintenanceCheckDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<MaintenanceCheckDTO>()
				.HasMany(i => i.BindMpds).WithOne(i => i.MaintenanceCheckDto).HasForeignKey(i => i.MaintenanceCheckId);

			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasOne(i => i.ATAChapter)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasOne(i => i.BaseComponent)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ComponentId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasOne(i => i.MaintenanceCheck)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.MaintenanceCheckId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasOne(i => i.JobCard)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.JobCardId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasMany(i => i.Files).WithOne(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasMany(i => i.PerformanceRecords).WithOne(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentID);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasMany(i => i.CategoriesRecords).WithOne(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<MaintenanceDirectiveDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<ModuleRecordDTO>()
				.HasOne(i => i.AircraftWorkerCategory)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);
			modelBuilder.Entity<ModuleRecordDTO>()
				.HasOne(i => i.KnowledgeModule)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.KnowledgeModuleId);

			modelBuilder.Entity<MTOPCheckDTO>()
				.HasOne(i => i.CheckType)
				.WithMany(i => i.MtopCheckDtos)
				.HasForeignKey(i => i.CheckTypeId);
			modelBuilder.Entity<MTOPCheckDTO>()
				.HasMany(i => i.PerformanceRecords).WithOne(i => i.MtopCheckDto).HasForeignKey(i => i.ParentId);


			modelBuilder.Configurations.Add(new ProcedureDocumentReferenceMap());
			modelBuilder.Configurations.Add(new ProcedureMap());
			modelBuilder.Configurations.Add(new ProductCostMap());
			modelBuilder.Configurations.Add(new PurchaseOrderMap());
			modelBuilder.Configurations.Add(new PurchaseRequestRecordMap());
			modelBuilder.Configurations.Add(new RequestForQuotationMap());
			modelBuilder.Configurations.Add(new RequestForQuotationRecordMap());
			modelBuilder.Configurations.Add(new RequestMap());
			modelBuilder.Configurations.Add(new RequestRecordMap());
			modelBuilder.Configurations.Add(new RunUpMap());
			modelBuilder.Configurations.Add(new SmsEventTypeMap());
			modelBuilder.Configurations.Add(new SpecialistCAAMap());
			modelBuilder.Configurations.Add(new SpecialistInstrumentRatingMap());
			modelBuilder.Configurations.Add(new SpecialistLicenseDetailMap());
			modelBuilder.Configurations.Add(new SpecialistLicenseMap());
			modelBuilder.Configurations.Add(new SpecialistLicenseRatingMap());
			modelBuilder.Configurations.Add(new SpecialistLicenseRemarkMap());
			modelBuilder.Configurations.Add(new SpecialistMap());
			modelBuilder.Configurations.Add(new SpecialistMedicalRecordMap());
			modelBuilder.Configurations.Add(new SpecialistTrainingMap());
			modelBuilder.Configurations.Add(new StockComponentInfoMap());
			modelBuilder.Configurations.Add(new StoreMap());
			modelBuilder.Configurations.Add(new SupplierDocumentMap());
			modelBuilder.Configurations.Add(new SupplierMap());


			modelBuilder.Entity<TransferRecordDTO>()
				.HasOne(i => i.ReceivedSpecialist)
				.WithMany(i => i.RecivedSpecialist)
				.HasForeignKey(i => i.ReceivedSpecialistId);
			modelBuilder.Entity<TransferRecordDTO>()
				.HasOne(i => i.ReleasedSpecialist)
				.WithMany(i => i.ReleasedSpecialist)
				.HasForeignKey(i => i.ReleasedSpecialistId);
			modelBuilder.Entity<TransferRecordDTO>()
				.HasMany(i => i.Files).WithOne(i => i.TransferRecord).HasForeignKey(i => i.ParentId);

			modelBuilder.Entity<VehicleDTO>()
				.HasOne(i => i.Model)
				.WithMany(i => i.VehicleDtos)
				.HasForeignKey(i => i.ModelId);

			modelBuilder.Entity<WorkOrderDTO>()
				.HasOne(i => i.PreparedBy)
				.WithMany(i => i.PreparedWorkOrderDtos)
				.HasForeignKey(i => i.PreparedById);
			modelBuilder.Entity<WorkOrderDTO>()
				.HasOne(i => i.CheckedBy)
				.WithMany(i => i.CheckedWorkOrderDtos)
				.HasForeignKey(i => i.CheckedById);
			modelBuilder.Entity<WorkOrderDTO>()
				.HasOne(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedWorkOrderDtos)
				.HasForeignKey(i => i.ApprovedById);
			modelBuilder.Entity<WorkOrderDTO>()
				.HasMany(i => i.Kits).WithOne(i => i.WorkOrder).HasForeignKey(i => i.ParentId);
			modelBuilder.Entity<WorkOrderDTO>()
				.HasMany(i => i.PackageRecords).WithOne(i => i.WorkOrder).HasForeignKey(i => i.ParentId);


			modelBuilder.Entity<WorkPackageDTO>()
				.HasMany(i => i.Files).WithOne(i => i.WorkPackage).HasForeignKey(i => i.ParentId);


			#endregion

		}
	}
}