
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.DTO.General.Maps;
using EFCore.DTO.Maps;
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

			modelBuilder.Configurations.Add(new NonRoutineJobMap());
			modelBuilder.Configurations.Add(new AccessoryDescriptionMap());
			modelBuilder.Configurations.Add(new AGWCategorieMap());
			modelBuilder.Configurations.Add(new AircraftOtherParameterMap());
			modelBuilder.Configurations.Add(new AirportCodeMap());
			modelBuilder.Configurations.Add(new AirportMap());
			modelBuilder.Configurations.Add(new ATAChapterMap());
			modelBuilder.Configurations.Add(new CruiseLevelMap());
			modelBuilder.Configurations.Add(new DamageChartMap());
			modelBuilder.Configurations.Add(new DefferedCategorieMap());
			modelBuilder.Configurations.Add(new DepartmentMap());
			modelBuilder.Configurations.Add(new DocumentSubTypeMap());
			modelBuilder.Configurations.Add(new EmployeeSubjectMap());
			modelBuilder.Configurations.Add(new EventCategorieMap());
			modelBuilder.Configurations.Add(new EventClassMap());
			modelBuilder.Configurations.Add(new FlightNumMap());
			modelBuilder.Configurations.Add(new GoodStandartMap());
			modelBuilder.Configurations.Add(new LicenseRemarkRightMap());
			modelBuilder.Configurations.Add(new LifeLimitCategorieMap());
			modelBuilder.Configurations.Add(new LocationMap());
			modelBuilder.Configurations.Add(new LocationsTypeMap());
			modelBuilder.Configurations.Add(new NomenclatureMap());
			modelBuilder.Configurations.Add(new ReasonMap());
			modelBuilder.Configurations.Add(new RestrictionMap());
			modelBuilder.Configurations.Add(new SchedulePeriodMap());
			modelBuilder.Configurations.Add(new ServiceTypeMap());
			modelBuilder.Configurations.Add(new SpecializationMap());
			modelBuilder.Configurations.Add(new TripNameMap());

			#endregion

			#region dboMap

			modelBuilder.Configurations.Add(new AccessoryRequiredMap());
			modelBuilder.Configurations.Add(new ActualStateRecordMap());
			modelBuilder.Configurations.Add(new AircraftMap());
			modelBuilder.Configurations.Add(new AircraftEquipmentMap());
			modelBuilder.Configurations.Add(new AircraftFlightMap());
			modelBuilder.Configurations.Add(new AircraftWorkerCategoryMap());
			modelBuilder.Configurations.Add(new ATLBMap());
			modelBuilder.Configurations.Add(new AttachedFileMap());
			modelBuilder.Configurations.Add(new AuditMap());
			modelBuilder.Configurations.Add(new AuditRecordMap());
			modelBuilder.Configurations.Add(new CategoryRecordMap());
			modelBuilder.Configurations.Add(new CertificateOfReleaseToServiceMap());
			modelBuilder.Configurations.Add(new ComponentDirectiveMap());
			modelBuilder.Configurations.Add(new ComponentLLPCategoryChangeRecordMap());
			modelBuilder.Configurations.Add(new ComponentLLPCategoryDataMap());
			modelBuilder.Configurations.Add(new ComponentMap());
			modelBuilder.Configurations.Add(new ComponentOilConditionMap());
			modelBuilder.Configurations.Add(new ComponentWorkInRegimeParamMap());
			modelBuilder.Configurations.Add(new CorrectiveActionMap());
			modelBuilder.Configurations.Add(new DamageDocumentMap());
			modelBuilder.Configurations.Add(new DamageSectorMap());
			modelBuilder.Configurations.Add(new DirectiveMap());
			modelBuilder.Configurations.Add(new DirectiveRecordMap());
			modelBuilder.Configurations.Add(new DiscrepancyMap());
			modelBuilder.Configurations.Add(new DocumentMap());
			modelBuilder.Configurations.Add(new EngineAccelerationTimeMap());
			modelBuilder.Configurations.Add(new EngineConditionMap());
			modelBuilder.Configurations.Add(new EngineTimeInRegimeMap());
			modelBuilder.Configurations.Add(new EventConditionMap());
			modelBuilder.Configurations.Add(new EventMap());
			modelBuilder.Configurations.Add(new EventTypeRiskLevelChangeRecordMap());
			modelBuilder.Configurations.Add(new FlightCargoRecordMap());
			modelBuilder.Configurations.Add(new FlightCrewRecordMap());
			modelBuilder.Configurations.Add(new FlightNumberAircraftModelRelationMap());
			modelBuilder.Configurations.Add(new FlightNumberAirportRelationMap());
			modelBuilder.Configurations.Add(new FlightNumberCrewRecordMap());
			modelBuilder.Configurations.Add(new FlightNumberMap());
			modelBuilder.Configurations.Add(new FlightNumberPeriodMap());
			modelBuilder.Configurations.Add(new FlightPassengerRecordMap());
			modelBuilder.Configurations.Add(new FlightPlanOpsMap());
			modelBuilder.Configurations.Add(new FlightPlanOpsRecordsMap());
			modelBuilder.Configurations.Add(new FlightTrackMap());
			modelBuilder.Configurations.Add(new FlightTrackRecordMap());
			modelBuilder.Configurations.Add(new HangarMap());
			modelBuilder.Configurations.Add(new HydraulicConditionMap());
			modelBuilder.Configurations.Add(new InitialOrderMap());
			modelBuilder.Configurations.Add(new InitialOrderRecordMap());
			modelBuilder.Configurations.Add(new ItemFileLinkMap());
			modelBuilder.Configurations.Add(new ItemsRelationMap());
			modelBuilder.Configurations.Add(new JobCardMap());
			modelBuilder.Configurations.Add(new JobCardTaskMap());
			modelBuilder.Configurations.Add(new KitSuppliersRelationMap());
			modelBuilder.Configurations.Add(new KnowledgeModuleMap());
			modelBuilder.Configurations.Add(new LandingGearConditionMap());
			modelBuilder.Configurations.Add(new MaintenanceCheckBindTaskRecordMap());
			modelBuilder.Configurations.Add(new MaintenanceCheckMap());
			modelBuilder.Configurations.Add(new MaintenanceCheckTypeMap());
			modelBuilder.Configurations.Add(new MaintenanceDirectiveMap());
			modelBuilder.Configurations.Add(new MaintenanceProgramChangeRecordMap());
			modelBuilder.Configurations.Add(new ModuleRecordMap());
			modelBuilder.Configurations.Add(new MTOPCheckMap());
			modelBuilder.Configurations.Add(new MTOPCheckRecordMap());
			modelBuilder.Configurations.Add(new OperatorMap());
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
			modelBuilder.Configurations.Add(new TransferRecordMap());
			modelBuilder.Configurations.Add(new VehicleMap());
			modelBuilder.Configurations.Add(new WorkOrderMap());
			modelBuilder.Configurations.Add(new WorkOrderRecordMap());
			modelBuilder.Configurations.Add(new WorkPackageMap());
			modelBuilder.Configurations.Add(new WorkPackageRecordMap());
			modelBuilder.Configurations.Add(new WorkPackageSpecialistsMap());
			modelBuilder.Configurations.Add(new WorkShopMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new QuotationCostMap());



			#endregion

		}
	}
}