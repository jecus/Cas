using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.DTO.General.Maps;
using EFCore.DTO.Maps;

namespace EFCore.DTO
{
	public class DataContext : DbContext
	{
		private const string _connection = "data source=91.213.233.139;initial catalog=ScatDBTest;user id=casadmin;password=casadmin001;MultipleActiveResultSets=True;App=EntityFramework";

		#region Constructor

		public DataContext() : base(_connection)
		{
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.LazyLoadingEnabled = false;


			Database.Log = s => System.Diagnostics.Trace.WriteLine(s);

			((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
		}

		public DataContext(string connectionString) : base(connectionString)
		{
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.LazyLoadingEnabled = false;
			((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
		}

		#endregion

		#region Dictionary

		public IDbSet<NonRoutineJobDTO> NonRoutineJobDtos { get; set; }
		public IDbSet<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		public IDbSet<AGWCategorieDTO> AGWCategorieDtos { get; set; }
		public IDbSet<AircraftOtherParameterDTO> AircraftOtherParameterDtos { get; set; }
		public IDbSet<AirportCodeDTO> AirportCodeDtos { get; set; }
		public IDbSet<AirportDTO> AirportDtos { get; set; }
		public IDbSet<ATAChapterDTO> ATAChapterDtos { get; set; }
		public IDbSet<CruiseLevelDTO> CruiseLevelDtos { get; set; }
		public IDbSet<DamageChartDTO> DamageChartDtos { get; set; }
		public IDbSet<DefferedCategorieDTO> DefferedCategorieDtos { get; set; }
		public IDbSet<DepartmentDTO> DepartmentDtos { get; set; }
		public IDbSet<DocumentSubTypeDTO> DocumentSubTypeDtos { get; set; }
		public IDbSet<EmployeeSubjectDTO> EmployeeSubjectDtos { get; set; }
		public IDbSet<EventCategorieDTO> EventCategorieDtos { get; set; }
		public IDbSet<EventClassDTO> EventClassDtos { get; set; }
		public IDbSet<FlightNumDTO> FlightNumDtos { get; set; }
		public IDbSet<GoodStandartDTO> GoodStandartDtos { get; set; }
		public IDbSet<LicenseRemarkRightDTO> LicenseRemarkRightDtos { get; set; }
		public IDbSet<LifeLimitCategorieDTO> LifeLimitCategorieDtos { get; set; }
		public IDbSet<LocationDTO> LocationDtos { get; set; }
		public IDbSet<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		public IDbSet<NomenclatureDTO> NomenclatureDtos { get; set; }
		public IDbSet<ReasonDTO> ReasonDtos { get; set; }
		public IDbSet<RestrictionDTO> RestrictionDtos { get; set; }
		public IDbSet<SchedulePeriodDTO> SchedulePeriodDtos { get; set; }
		public IDbSet<ServiceTypeDTO> ServiceTypeDtos { get; set; }
		public IDbSet<SpecializationDTO> SpecializationDtos { get; set; }
		public IDbSet<TripNameDTO> TripNameDtos { get; set; }

		#endregion

		#region dbo

		public IDbSet<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
		public IDbSet<ActualStateRecordDTO> ActualStateRecordDtos { get; set; }
		public IDbSet<AircraftDTO> AircraftDtos { get; set; }
		public IDbSet<AircraftEquipmentDTO> AircraftEquipmentDtos { get; set; }
		public IDbSet<AircraftFlightDTO> AircraftFlightDtos { get; set; }
		public IDbSet<AircraftWorkerCategoryDTO> AircraftWorkerCategoryDtos  { get; set; }
		public IDbSet<ATLBDTO> Atlbdtos { get; set; }
		public IDbSet<AttachedFileDTO> AttachedFileDtos { get; set; }
		public IDbSet<AuditDTO> AuditDtos { get; set; }
		public IDbSet<AuditRecordDTO> AuditRecordDtos { get; set; }
		public IDbSet<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		public IDbSet<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceDtos { get; set; }
		public IDbSet<ComponentDirectiveDTO> ComponentDirectiveDtos { get; set; }
		public IDbSet<ComponentDTO> ComponentDtos { get; set; }
		public IDbSet<ComponentLLPCategoryChangeRecordDTO> ComponentLLPCategoryChangeRecordDtos { get; set; }
		public IDbSet<ComponentLLPCategoryDataDTO> ComponentLLPCategoryDataDtos { get; set; }
		public IDbSet<ComponentOilConditionDTO> ComponentOilConditionDtos { get; set; }
		public IDbSet<ComponentWorkInRegimeParamDTO> ComponentWorkInRegimeParamDtos { get; set; }
		public IDbSet<CorrectiveActionDTO> CorrectiveActionDtos { get; set; }
		public IDbSet<DamageDocumentDTO> DamageDocumentDtos { get; set; }
		public IDbSet<DamageSectorDTO> DamageSectorDtos { get; set; }
		public IDbSet<DirectiveDTO> DirectiveDtos  { get; set; }
		public IDbSet<DirectiveRecordDTO> DirectiveRecordDtos { get; set; }
		public IDbSet<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		public IDbSet<DocumentDTO> DocumentDtos { get; set; }
		public IDbSet<EngineAccelerationTimeDTO> EngineAccelerationTimeDtos { get; set; }
		public IDbSet<EngineConditionDTO> EngineConditionDtos { get; set; }
		public IDbSet<EngineTimeInRegimeDTO> EngineTimeInRegimeDtos { get; set; }
		public IDbSet<EventConditionDTO> EventConditionDtos { get; set; }
		public IDbSet<EventDTO> EventDtos { get; set; }
		public IDbSet<EventTypeRiskLevelChangeRecordDTO> EventTypeRiskLevelChangeRecordDtos { get; set; }
		public IDbSet<FlightCargoRecordDTO> FlightCargoRecordDtos { get; set; }
		public IDbSet<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
		public IDbSet<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
		public IDbSet<FlightNumberAirportRelationDTO> FlightNumberAirportRelationDtos { get; set; }
		public IDbSet<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
		public IDbSet<FlightNumberDTO> FlightNumberDtos { get; set; }
		public IDbSet<FlightNumberPeriodDTO> FlightNumberPeriodDtos { get; set; }
		public IDbSet<FlightPassengerRecordDTO> FlightPassengerRecordDtos { get; set; }
		public IDbSet<FlightPlanOpsDTO> FlightPlanOpsDtos { get; set; }
		public IDbSet<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }
		public IDbSet<FlightTrackDTO> FlightTrackDtos { get; set; }
		public IDbSet<FlightTrackRecordDTO> FlightTrackRecordDtos { get; set; }
		public IDbSet<HangarDTO> HangarDtos { get; set; }
		public IDbSet<HydraulicConditionDTO> HydraulicConditionDtos { get; set; }
		public IDbSet<InitialOrderDTO> InitialOrderDtos { get; set; }
		public IDbSet<InitialOrderRecordDTO> InitialOrderRecordDtos { get; set; }
		public IDbSet<ItemFileLinkDTO> ItemFileLinkDtos { get; set; }
		public IDbSet<ItemsRelationDTO> ItemsRelationDtos { get; set; }
		public IDbSet<JobCardDTO> JobCardDtos { get; set; }
		public IDbSet<JobCardTaskDTO> JobCardTaskDtos { get; set; }
		public IDbSet<KitSuppliersRelationDTO> KitSuppliersRelationDtos { get; set; }
		public IDbSet<KnowledgeModuleDTO> KnowledgeModuleDtos { get; set; }
		public IDbSet<LandingGearConditionDTO> LandingGearConditionDtos { get; set; }
		public IDbSet<MaintenanceCheckBindTaskRecordDTO> MaintenanceCheckBindTaskRecordDtos { get; set; }
		public IDbSet<MaintenanceCheckDTO> MaintenanceCheckDtos { get; set; }
		public IDbSet<MaintenanceCheckTypeDTO> MaintenanceCheckTypeDtos { get; set; }
		public IDbSet<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		public IDbSet<MaintenanceProgramChangeRecordDTO> MaintenanceProgramChangeRecordDtos { get; set; }
		public IDbSet<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		public IDbSet<MTOPCheckDTO> MtopCheckDtos { get; set; }
		public IDbSet<MTOPCheckRecordDTO> MtopCheckRecordDtos { get; set; }
		public IDbSet<OperatorDTO> OperatorDtos { get; set; }
		public IDbSet<ProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }
		public IDbSet<ProcedureDTO> ProcedureDtos { get; set; }
		public IDbSet<ProductCostDTO> ProductCostDtos { get; set; }
		public IDbSet<PurchaseOrderDTO> PurchaseOrderDtos { get; set; }
		public IDbSet<PurchaseRequestRecordDTO> PurchaseRequestRecordDtos { get; set; }
		public IDbSet<RequestDTO> RequestDtos { get; set; }
		public IDbSet<RequestForQuotationDTO> RequestForQuotationDtos { get; set; }
		public IDbSet<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		public IDbSet<RequestRecordDTO> RequestRecordDtos { get; set; }
		public IDbSet<RunUpDTO> RunUpDtos { get; set; }
		public IDbSet<SmsEventTypeDTO> SmsEventTypeDtos { get; set; }
		public IDbSet<SpecialistCAADTO> SpecialistCaadtos { get; set; }
		public IDbSet<SpecialistDTO> SpecialistDtos { get; set; }
		public IDbSet<SpecialistInstrumentRatingDTO> SpecialistInstrumentRatingDtos { get; set; }
		public IDbSet<SpecialistLicenseDetailDTO> SpecialistLicenseDetailDtos { get; set; }
		public IDbSet<SpecialistLicenseDTO> SpecialistLicenseDtos { get; set; }
		public IDbSet<SpecialistLicenseRatingDTO> SpecialistLicenseRatingDtos { get; set; }
		public IDbSet<SpecialistLicenseRemarkDTO> SpecialistLicenseRemarkDtos { get; set; }
		public IDbSet<SpecialistMedicalRecordDTO> SpecialistMedicalRecordDtos { get; set; }
		public IDbSet<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
		public IDbSet<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }
		public IDbSet<StoreDTO> StoreDtos { get; set; }
		public IDbSet<SupplierDocumentDTO> SupplierDocumentDtos { get; set; }
		public IDbSet<SupplierDTO> SupplierDtos { get; set; }
		public IDbSet<TransferRecordDTO> TransferRecordDtos { get; set; }
		public IDbSet<VehicleDTO> VehicleDtos { get; set; }
		public IDbSet<WorkOrderDTO> WorkOrderDtos { get; set; }
		public IDbSet<WorkOrderRecordDTO> WorkOrderRecordDtos { get; set; }
		public IDbSet<WorkPackageDTO> WorkPackageDtos { get; set; }
		public IDbSet<WorkPackageRecordDTO> WorkPackageRecordDtos { get; set; }
		public IDbSet<WorkPackageSpecialistsDTO> WorkPackageSpecialistsDtos { get; set; }
		public IDbSet<WorkShopDTO> WorkShopDtos { get; set; }
		public IDbSet<UserDTO> UserDtos { get; set; }
		public IDbSet<QuotationCostDTO> QuotationCostDtos { get; set; }

		#endregion
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
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