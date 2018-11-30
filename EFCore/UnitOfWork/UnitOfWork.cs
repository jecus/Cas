using System;
using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using EFCore.Contract.Dictionaries;
using EFCore.Contract.General;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;
using BaseEntity = EFCore.DTO.BaseEntity;
using IRunUpService = EFCore.Contract.General.IRunUpService;
using RunUpDTO = EFCore.DTO.General.RunUpDTO;

namespace EFCore.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly string _ipAdress;
		private readonly string _connectionString;
		private DataContext _context;
		private Hashtable repositories = new Hashtable();
		private BasicHttpBinding _binding;

		public UnitOfWork(string ipAdress, bool isWcf)
		{
			_ipAdress = ipAdress;
			_binding = new BasicHttpBinding()
			{
				CloseTimeout = new TimeSpan(0, 10, 0),
				OpenTimeout = new TimeSpan(0, 10, 0),
				ReceiveTimeout = new TimeSpan(0, 10, 0),
				SendTimeout = new TimeSpan(0, 10, 0),
				MaxBufferPoolSize = Int32.MaxValue,
				MaxBufferSize = Int32.MaxValue,
				MaxReceivedMessageSize = Int32.MaxValue,
				TransferMode = TransferMode.Streamed,
				ReaderQuotas =
				{
					MaxArrayLength = Int32.MaxValue,
					MaxBytesPerRead = Int32.MaxValue,
					MaxDepth = Int32.MaxValue,
					MaxStringContentLength = Int32.MaxValue,
					MaxNameTableCharCount = Int32.MaxValue
				}
			};
		}

		public UnitOfWork(string connectionString)
		{
			_binding = new BasicHttpBinding
			{
				CloseTimeout = new TimeSpan(0, 10, 0),
				OpenTimeout = new TimeSpan(0, 10, 0),
				ReceiveTimeout = new TimeSpan(0, 10, 0),
				SendTimeout = new TimeSpan(0, 10, 0),
				MaxBufferPoolSize = Int32.MaxValue,
				MaxBufferSize = Int32.MaxValue,
				MaxReceivedMessageSize = Int32.MaxValue,
				TransferMode = TransferMode.Streamed,
				Security = new BasicHttpSecurity()
				{
					Mode = BasicHttpSecurityMode.None
				},
				ReaderQuotas =
				{
					MaxArrayLength = Int32.MaxValue,
					MaxBytesPerRead = Int32.MaxValue,
					MaxDepth = Int32.MaxValue,
					MaxNameTableCharCount = Int32.MaxValue,
					MaxStringContentLength = Int32.MaxValue
				}
			};
			_connectionString = connectionString;
			_context = new DataContext(connectionString);
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			//if (!repositories.Contains(typeof(T)))
			//	repositories.Add(typeof(T), new Repository<T>(_context));

			//return (IRepository<T>)repositories[typeof(T)];
			return new Repository<T>(_context = new DataContext());
		}

		public IRepository<T> GetRepositoryWcf<T>() where T : BaseEntity
		{
			EndpointAddress endPoint;

			if (typeof(T) == typeof(AircraftDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AircraftService.svc");
				var channelFactoryFoo = new ChannelFactory<IAircraftService>(_binding, endPoint);
				return (IRepository<T>) channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AttachedFileDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AttachedFileService.svc");
				var channelFactoryFoo = new ChannelFactory<IAttachedFileService>(_binding, endPoint);
				return (IRepository<T>) channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AccessoryDescriptionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AccessoryDescriptionService.svc");
				var channelFactoryFoo = new ChannelFactory<IAccessoryDescriptionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AccessoryRequiredDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AccessoryRequiredService.svc");
				var channelFactoryFoo = new ChannelFactory<IAccessoryRequiredService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ActualStateRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ActualStateRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IActualStateRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AGWCategorieDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AGWCategorieService.svc");
				var channelFactoryFoo = new ChannelFactory<IAGWCategorieService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AircraftEquipmentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AircraftEquipmentService.svc");
				var channelFactoryFoo = new ChannelFactory<IAircraftEquipmentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AircraftFlightDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AircraftFlightService.svc");
				var channelFactoryFoo = new ChannelFactory<IAircraftFlightService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AircraftOtherParameterDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AircraftOtherParameterService.svc");
				var channelFactoryFoo = new ChannelFactory<IAircraftOtherParameterService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AircraftWorkerCategoryDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AircraftWorkerCategoryService.svc");
				var channelFactoryFoo = new ChannelFactory<IAircraftWorkerCategoryService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AirportCodeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AirportCodeService.svc");
				var channelFactoryFoo = new ChannelFactory<IAirportCodeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AirportDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AirportService.svc");
				var channelFactoryFoo = new ChannelFactory<IAirportService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ATAChapterDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ATAChapterService.svc");
				var channelFactoryFoo = new ChannelFactory<IATAChapterService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ATLBDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ATLBService.svc");
				var channelFactoryFoo = new ChannelFactory<IATLBService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AuditRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AuditRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IAuditRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(AuditDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/AuditService.svc");
				var channelFactoryFoo = new ChannelFactory<IAuditService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(CategoryRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/CategoryRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<ICategoryRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentDirectiveDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentDirectiveService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentDirectiveService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentLLPCategoryChangeRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentLLPCategoryChangeRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentLLPCategoryChangeRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentLLPCategoryDataDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentLLPCategoryDataService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentLLPCategoryDataService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentOilConditionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentOilConditionService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentOilConditionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ComponentWorkInRegimeParamDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ComponentWorkInRegimeParamService.svc");
				var channelFactoryFoo = new ChannelFactory<IComponentWorkInRegimeParamService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(CorrectiveActionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/CorrectiveActionService.svc");
				var channelFactoryFoo = new ChannelFactory<ICorrectiveActionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(CertificateOfReleaseToServiceDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/CRSService.svc");
				var channelFactoryFoo = new ChannelFactory<ICRSService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(CruiseLevelDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/CruiseLevelService.svc");
				var channelFactoryFoo = new ChannelFactory<ICruiseLevelService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DamageChartDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DamageChartService.svc");
				var channelFactoryFoo = new ChannelFactory<IDamageChartService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DamageDocumentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DamageDocumentService.svc");
				var channelFactoryFoo = new ChannelFactory<IDamageDocumentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DamageSectorDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DamageSectorService.svc");
				var channelFactoryFoo = new ChannelFactory<IDamageSectorService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DefferedCategorieDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DefferedCategorieService.svc");
				var channelFactoryFoo = new ChannelFactory<IDefferedCategorieService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DepartmentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DepartmentService.svc");
				var channelFactoryFoo = new ChannelFactory<IDepartmentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DirectiveRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DirectiveRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IDirectiveRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DirectiveDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DirectiveService.svc");
				var channelFactoryFoo = new ChannelFactory<IDirectiveService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DiscrepancyDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DiscrepancyService.svc");
				var channelFactoryFoo = new ChannelFactory<IDiscrepancyService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DocumentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DocumentService.svc");
				var channelFactoryFoo = new ChannelFactory<IDocumentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(DocumentSubTypeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/DocumentSubTypeService.svc");
				var channelFactoryFoo = new ChannelFactory<IDocumentSubTypeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EmployeeSubjectDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EmployeeSubjectService.svc");
				var channelFactoryFoo = new ChannelFactory<IEmployeeSubjectService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EngineAccelerationTimeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EngineAccelerationTimeService.svc");
				var channelFactoryFoo = new ChannelFactory<IEngineAccelerationTimeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EngineConditionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EngineConditionService.svc");
				var channelFactoryFoo = new ChannelFactory<IEngineConditionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EngineTimeInRegimeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EngineTimeInRegimeService.svc");
				var channelFactoryFoo = new ChannelFactory<IEngineTimeInRegimeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EventCategorieDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EventCategorieService.svc");
				var channelFactoryFoo = new ChannelFactory<IEventCategorieService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EventClassDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EventClassService.svc");
				var channelFactoryFoo = new ChannelFactory<IEventClassService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EventConditionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EventConditionService.svc");
				var channelFactoryFoo = new ChannelFactory<IEventConditionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EventDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EventService.svc");
				var channelFactoryFoo = new ChannelFactory<IEventService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(EventTypeRiskLevelChangeRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/EventTypeRiskLevelChangeRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IEventTypeRiskLevelChangeRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightCargoRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightCargoRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightCargoRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightCrewRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightCrewRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightCrewRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumberAircraftModelRelationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumberAircraftModelRelationService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumberAircraftModelRelationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumberAirportRelationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumberAirportRelationService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumberAirportRelationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumberCrewRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumberCrewRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumberCrewRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumberPeriodDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumberPeriodService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumberPeriodService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumberDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumberService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumberService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightNumDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightNumService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightNumService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightPassengerRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightPassengerRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightPassengerRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightPlanOpsRecordsDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightPlanOpsRecordsService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightPlanOpsRecordsService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightPlanOpsDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightPlanOpsService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightPlanOpsService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightTrackRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightTrackRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightTrackRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(FlightTrackDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/FlightTrackService.svc");
				var channelFactoryFoo = new ChannelFactory<IFlightTrackService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(GoodStandartDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/GoodStandartService.svc");
				var channelFactoryFoo = new ChannelFactory<IGoodStandartService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(HangarDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/HangarService.svc");
				var channelFactoryFoo = new ChannelFactory<IHangarService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(HydraulicConditionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/HydraulicConditionService.svc");
				var channelFactoryFoo = new ChannelFactory<IHydraulicConditionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(InitialOrderRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/InitialOrderRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IInitialOrderRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(InitialOrderDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/InitialOrderService.svc");
				var channelFactoryFoo = new ChannelFactory<IInitialOrderService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ItemFileLinkDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ItemFileLinkService.svc");
				var channelFactoryFoo = new ChannelFactory<IItemFileLinkService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ItemsRelationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ItemsRelationService.svc");
				var channelFactoryFoo = new ChannelFactory<IItemsRelationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(JobCardDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/JobCardService.svc");
				var channelFactoryFoo = new ChannelFactory<IJobCardService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(JobCardTaskDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/JobCardTaskService.svc");
				var channelFactoryFoo = new ChannelFactory<IJobCardTaskService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(KitSuppliersRelationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/KitSuppliersRelationService.svc");
				var channelFactoryFoo = new ChannelFactory<IKitSuppliersRelationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(KnowledgeModuleDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/KnowledgeModuleService.svc");
				var channelFactoryFoo = new ChannelFactory<IKnowledgeModuleService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(LandingGearConditionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/LandingGearConditionService.svc");
				var channelFactoryFoo = new ChannelFactory<ILandingGearConditionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(LicenseRemarkRightDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/LicenseRemarkRightService.svc");
				var channelFactoryFoo = new ChannelFactory<ILicenseRemarkRightService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(LifeLimitCategorieDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/LifeLimitCategorieService.svc");
				var channelFactoryFoo = new ChannelFactory<ILifeLimitCategorieService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(LocationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/LocationService.svc");
				var channelFactoryFoo = new ChannelFactory<ILocationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(LocationsTypeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/LocationsTypeService.svc");
				var channelFactoryFoo = new ChannelFactory<ILocationsTypeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MaintenanceCheckBindTaskRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MaintenanceCheckBindTaskRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IMaintenanceCheckBindTaskRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MaintenanceCheckDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MaintenanceCheckService.svc");
				var channelFactoryFoo = new ChannelFactory<IMaintenanceCheckService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MaintenanceCheckTypeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MaintenanceCheckTypeService.svc");
				var channelFactoryFoo = new ChannelFactory<IMaintenanceCheckTypeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MaintenanceDirectiveDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MaintenanceDirectiveService.svc");
				var channelFactoryFoo = new ChannelFactory<IMaintenanceDirectiveService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MaintenanceProgramChangeRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MaintenanceProgramChangeRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IMaintenanceProgramChangeRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ModuleRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ModuleRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IModuleRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MTOPCheckRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MTOPCheckRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IMTOPCheckRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(MTOPCheckDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/MTOPCheckService.svc");
				var channelFactoryFoo = new ChannelFactory<IMTOPCheckService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(NomenclatureDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/NomenclatureService.svc");
				var channelFactoryFoo = new ChannelFactory<INomenclatureService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(NonRoutineJobDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/NonRoutineJobService.svc");
				var channelFactoryFoo = new ChannelFactory<INonRoutineJobService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(OperatorDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/OperatorService.svc");
				var channelFactoryFoo = new ChannelFactory<IOperatorService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ProcedureDocumentReferenceDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ProcedureDocumentReferenceService.svc");
				var channelFactoryFoo = new ChannelFactory<IProcedureDocumentReferenceService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ProcedureDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ProcedureService.svc");
				var channelFactoryFoo = new ChannelFactory<IProcedureService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ProductCostDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ProductCostService.svc");
				var channelFactoryFoo = new ChannelFactory<IProductCostService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(PurchaseOrderDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/PurchaseOrderService.svc");
				var channelFactoryFoo = new ChannelFactory<IPurchaseOrderService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(PurchaseRequestRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/PurchaseRequestRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IPurchaseRequestRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ReasonDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ReasonService.svc");
				var channelFactoryFoo = new ChannelFactory<IReasonService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RequestForQuotationRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RequestForQuotationRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IRequestForQuotationRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RequestForQuotationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RequestForQuotationService.svc");
				var channelFactoryFoo = new ChannelFactory<IRequestForQuotationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RequestRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RequestRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IRequestRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RequestDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RequestService.svc");
				var channelFactoryFoo = new ChannelFactory<IRequestService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RestrictionDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RestrictionService.svc");
				var channelFactoryFoo = new ChannelFactory<IRestrictionService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(RunUpDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/RunUpService.svc");
				var channelFactoryFoo = new ChannelFactory<IRunUpService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SchedulePeriodDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SchedulePeriodService.svc");
				var channelFactoryFoo = new ChannelFactory<ISchedulePeriodService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(ServiceTypeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/ServiceTypeService.svc");
				var channelFactoryFoo = new ChannelFactory<IServiceTypeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SmsEventTypeDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SmsEventTypeService.svc");
				var channelFactoryFoo = new ChannelFactory<ISmsEventTypeService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistCAADTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistCAAService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistCAAService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistInstrumentRatingDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistInstrumentRatingService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistInstrumentRatingService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistLicenseDetailDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistLicenseDetailService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistLicenseDetailService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistLicenseRatingDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistLicenseRatingService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistLicenseRatingService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistLicenseRemarkDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistLicenseRemarkService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistLicenseRemarkService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistLicenseDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistLicenseService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistLicenseService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistMedicalRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistMedicalRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistMedicalRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecialistTrainingDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecialistTrainingService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecialistTrainingService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SpecializationDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SpecializationService.svc");
				var channelFactoryFoo = new ChannelFactory<ISpecializationService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(StockComponentInfoDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/StockComponentInfoService.svc");
				var channelFactoryFoo = new ChannelFactory<IStockComponentInfoService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(StoreDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/StoreService.svc");
				var channelFactoryFoo = new ChannelFactory<IStoreService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SupplierDocumentDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SupplierDocumentService.svc");
				var channelFactoryFoo = new ChannelFactory<ISupplierDocumentService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(SupplierDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/SupplierService.svc");
				var channelFactoryFoo = new ChannelFactory<ISupplierService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(TransferRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/TransferRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<ITransferRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(TripNameDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/TripNameService.svc");
				var channelFactoryFoo = new ChannelFactory<ITripNameService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(VehicleDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/VehicleService.svc");
				var channelFactoryFoo = new ChannelFactory<IVehicleService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkOrderRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkOrderRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkOrderRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkOrderDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkOrderService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkOrderService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkPackageRecordDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkPackageRecordService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkPackageRecordService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkPackageDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkPackageService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkPackageService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkPackageSpecialistsDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkPackageSpecialistsService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkPackageSpecialistsService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(WorkShopDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/WorkShopService.svc");
				var channelFactoryFoo = new ChannelFactory<IWorkShopService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(QuotationCostDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/QuotationCostService.svc");
				var channelFactoryFoo = new ChannelFactory<IQuotationCostService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}
			if (typeof(T) == typeof(UserDTO))
			{
				endPoint = new EndpointAddress($"http://{_ipAdress}/Service/UserService.svc");
				var channelFactoryFoo = new ChannelFactory<IUserService>(_binding, endPoint);
				return (IRepository<T>)channelFactoryFoo.CreateChannel();
			}

			throw new Exception($"Type({nameof(T)}) has no containt service.");
		}
	}
}