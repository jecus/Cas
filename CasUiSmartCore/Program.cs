using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Logging;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CASTerms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartCore;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Analyst;
using SmartCore.AuditMongo;
using SmartCore.AuditMongo.Repository;
using SmartCore.Audits;
using SmartCore.AverageUtilizations;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Calculations.PlanOpsCalculator;
using SmartCore.Calculations.StockCalculator;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.DataAccesses.WorkPackageRecords;
using SmartCore.Directives;
using SmartCore.Discrepancies;
using SmartCore.Documents;
using SmartCore.Files;
using SmartCore.Kits;
using SmartCore.Maintenance;
using SmartCore.Management;
using SmartCore.NonRoutineJobs;
using SmartCore.Packages;
using SmartCore.Personnel;
using SmartCore.Purchase;
using SmartCore.RegisterPerformances;
using SmartCore.Relation;
using SmartCore.Sms;
using SmartCore.Stores;
using SmartCore.TrackCore;
using SmartCore.TransferRec;
using SmartCore.WorkPackages;

namespace CAS.UI
{
    static class Program
    {
        private static Dispatcher _mainDispatcher;
        private static Dictionary<String, ModeProvider> _loadingVariants;
        /// <summary>
        /// Поставщик режима приложения
        /// </summary>
        private static ModeProvider _provider;

        public static ModeProvider Provider
        {
            get { return _provider; }
        }

        public static Dispatcher MainDispatcher
        {
            get { return _mainDispatcher; }
        }

       /* public static Presenters Presenters
        {
            get { return presenters; }
        }*/

        static Program()
        {
	        var exePath = Path.GetDirectoryName(Application.ExecutablePath);
	        var path = Path.Combine(exePath, "AppSettings.json");
	        var json = File.ReadAllText(path);
	        GlobalObjects.Config = JsonConvert.DeserializeObject<JObject>(json);

	        AuditContext auditContext = null;

			try
	        {
		        auditContext = new AuditContext((string)GlobalObjects.Config["ConnectionStrings"]["Audit"]);
			}
	        catch {}
	        GlobalObjects.AuditRepository = new AuditRepository(auditContext);
	        GlobalObjects.AuditContext = auditContext;

			var environment = DbTypes.CasEnvironment = new CasEnvironment();
			environment.AuditRepository = GlobalObjects.AuditRepository;
			environment.ApiProvider = new ApiProvider((string)GlobalObjects.Config["ConnectionStrings"]["ScatTest"]);

			var nonRoutineJobDataAccess = new NonRoutineJobDataAccess(environment.Loader, environment.Keeper);
			var itemsRelationsDataAccess = new ItemsRelationsDataAccess(environment);
			var filesDataAccess = new FilesDataAccess(environment.NewLoader);
			var workPackageRecordsDataAccess = new WorkPackageRecordsDataAccess(environment);
			

			var storeService = new StoreCore(environment);
			var aircraftService = new AircraftsCore(environment.Loader, environment.NewKeeper, environment.NewLoader);
			var compontntService = new ComponentCore(environment, environment.Loader, environment.NewLoader, environment.NewKeeper, aircraftService, itemsRelationsDataAccess);
			var averageUtilizationService = new AverageUtilizationCore(aircraftService, storeService, compontntService);
			var directiveService = new DirectiveCore(environment.NewKeeper, environment.NewLoader, environment.Keeper,  environment.Loader, itemsRelationsDataAccess);
			var aircraftFlightService = new AircraftFlightCore(environment, environment.Loader, environment.NewLoader, directiveService, environment.Manipulator, compontntService, environment.NewKeeper,aircraftService);
			var flightTrackService = new FlightTrackCore(environment.NewLoader);
			var calculator = new Calculator(environment,compontntService, aircraftFlightService, aircraftService);
	        var mtopCalculator = new MTOPCalculator(calculator);
			var planOpsCalculator = new PlanOpsCalculator(environment.NewLoader, environment.NewKeeper, aircraftService,flightTrackService);
			var performanceCalculator = new PerformanceCalculator(calculator, averageUtilizationService, mtopCalculator);
			var packageService = new PackagesCore(environment, environment.NewKeeper, environment.Loader, aircraftService, compontntService);
            var purchaseService = new PurchaseCore(environment, environment.NewLoader, environment.Loader, packageService, environment.NewKeeper, performanceCalculator);
			var calcStockService = new StockCalculator(environment, environment.NewLoader, compontntService);
			var documentService = new DocumentCore(environment, environment.NewLoader, environment.Loader, aircraftService, environment.NewKeeper, compontntService);
	        var maintenanceService = new MaintenanceCore(environment, environment.NewLoader, environment.NewKeeper, itemsRelationsDataAccess, aircraftService);
			var maintenanceCheckCalculator = new MaintenanceCheckCalculator(calculator, averageUtilizationService, performanceCalculator);
			var analystService = new AnalystCore(compontntService, maintenanceService, directiveService, maintenanceCheckCalculator, performanceCalculator);
	        var discrepanciesService = new DiscrepanciesCore(environment.Loader, environment.NewLoader, directiveService,  aircraftFlightService);
			var kitsService = new KitsCore(environment, environment.Loader, environment.NewKeeper, compontntService, nonRoutineJobDataAccess);
			var smsService = new SMSCore(environment.Manipulator);
	        var personelService = new PersonnelCore(environment);
			var transferRecordCore = new TransferRecordCore(environment.NewLoader, environment.NewKeeper, compontntService, aircraftService, calculator, storeService, filesDataAccess);		
			var bindedItemsService = new BindedItemsCore(compontntService, directiveService, maintenanceService);
			var performanceService = new PerformanceCore(environment.NewKeeper, environment.Keeper, calculator, bindedItemsService);
			var workPackageService = new WorkPackageCore(environment, environment.NewLoader, maintenanceService, environment.NewKeeper, calculator, compontntService, aircraftService, nonRoutineJobDataAccess, directiveService, filesDataAccess, performanceCalculator, performanceService, bindedItemsService, workPackageRecordsDataAccess, mtopCalculator, averageUtilizationService);
			var nonRoutineJobService = new NonRoutineJobCore(environment, workPackageService, nonRoutineJobDataAccess, environment.NewLoader);
			var auditService = new AuditCore(environment, environment.Loader, environment.NewLoader, environment.NewKeeper, calculator, performanceCalculator, performanceService);

			DbTypes.AircraftsCore = aircraftService;

			GlobalObjects.CasEnvironment = environment;
            GlobalObjects.PackageCore = packageService;
            GlobalObjects.PurchaseCore = purchaseService;
	        GlobalObjects.ComponentCore = compontntService;
	        GlobalObjects.AnalystCore = analystService;
	        GlobalObjects.StockCalculator = calcStockService;
	        GlobalObjects.DocumentCore = documentService;
	        GlobalObjects.AuditCore = auditService;
	        GlobalObjects.MaintenanceCore = maintenanceService;
	        GlobalObjects.WorkPackageCore = workPackageService;
	        GlobalObjects.NonRoutineJobCore = nonRoutineJobService;
	        GlobalObjects.DirectiveCore = directiveService;
	        GlobalObjects.AircraftFlightsCore = aircraftFlightService;
	        GlobalObjects.DiscrepanciesCore = discrepanciesService;
	        GlobalObjects.KitsCore = kitsService;
	        GlobalObjects.SmsCore = smsService;
	        GlobalObjects.PersonnelCore = personelService;
	        GlobalObjects.TransferRecordCore = transferRecordCore;
	        GlobalObjects.AircraftsCore = aircraftService;
	        GlobalObjects.ItemsRelationsDataAccess = itemsRelationsDataAccess;
	        GlobalObjects.StoreCore = storeService;
	        GlobalObjects.BindedItemsCore = bindedItemsService;
	        GlobalObjects.AverageUtilizationCore = averageUtilizationService;
	        GlobalObjects.MaintenanceCheckCalculator = maintenanceCheckCalculator;
	        GlobalObjects.MTOPCalculator = mtopCalculator;
	        GlobalObjects.PerformanceCalculator = performanceCalculator;
	        GlobalObjects.PlanOpsCalculator = planOpsCalculator;
	        GlobalObjects.PerformanceCore = performanceService;
	        GlobalObjects.FlightTrackCore = flightTrackService;

			environment.SetAircraftCore(aircraftService);
			environment.Calculator = calculator;
            environment.Manipulator.PurchaseService = GlobalObjects.PurchaseCore;
	        environment.Manipulator.MaintenanceCore = GlobalObjects.MaintenanceCore;
	        environment.Manipulator.WorkPackageCore = GlobalObjects.WorkPackageCore;
	        environment.Manipulator.AircraftFlightCore = GlobalObjects.AircraftFlightsCore;
	        environment.Manipulator.ComponentCore = GlobalObjects.ComponentCore;
	        environment.Manipulator.AircraftsCore = GlobalObjects.AircraftsCore;
	        environment.Manipulator.BindedItemCore = GlobalObjects.BindedItemsCore;

            InitLoadingVariants();
            InitializePresenters();
        }

        private static void InitializePresenters()
        {
            //presenters = new Presenters(
               // new AircraftsPresenter(), 
               // new StoresPresenter(),
                //new DetailsPresenter());
        }
       

        /// <summary>
        /// Инициализация вариантов загрузки приложения
        /// </summary>
        private static void InitLoadingVariants()
        {
            _loadingVariants = new Dictionary<string, ModeProvider>();
            //Инициализация загрузки "Release"
            _loadingVariants.Add("release", new ModeProvider( new MailFileLogger(),
                                                              delegate(Object state)
                                                              {
                                                                  formMain mainForm = InitProgram();
                                                                  Application.ThreadException += ApplicationThreadException;
                                                                  try
                                                                  {
                                                                      Application.Run(mainForm);
                                                                  }
                                                                  catch (Exception ex)
                                                                  {
                                                                      _provider.Logger.Log("Error while execution the program",ex);
                                                                  }
                                                                  finally
                                                                  {
                                                                      GlobalObjects.CasEnvironment.Disconnect();
                                                                  }
                                                              }
                                                              )
                               );
            _loadingVariants.Add("debug", new ModeProvider( new RethrowableFileLogger(),
                                                            delegate(Object state)
                                                            {
                                                                formMain mainForm = InitProgram();
                                                                Application.ThreadException += ApplicationThreadException;
                                                                //Application.Run(mainForm););
                                                                try
                                                                {
    	                                                            Application.Run(mainForm);
                                                                }
                                                                catch (Exception exception)
                                                                {
                                                                    MessageBox.Show(exception.Message + 
                                                                                    (exception.InnerException != null 
                                                                                        ? "    " + exception.InnerException 
                                                                                        : ""),
                                                                                    "Error confirmation",
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Warning,
                                                                                    MessageBoxDefaultButton.Button1);
                                                                }
                                                                finally
                                                                {
                                                                    // if (ConnectionManager.IsConnected)
                                                                    GlobalObjects.CasEnvironment.Disconnect();   
                                                                }
                                                            } 
                                                            )
                                );
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new CultureInfo("en-US");

            // Предварительно проверяем некоторые вещи
            Launcher.Prepare();
            // Определения варианта запуска приложения
            String mode = "release";
#if RELEASE
            mode = "release";
#endif
#if DEBUG
            mode = "debug";
#endif
            _provider = _loadingVariants[mode];
            _provider.Logger.BeginProcess(_provider.Action, new Object());
        }

        private static formMain InitProgram()
        {
            formMain mainForm = new formMain();
            mainForm.Closing += MainFormClosing;
            //Screen startScreen = new Screen();

            _mainDispatcher = new Dispatcher(mainForm.dispatcheredMultitabControl, mainForm);
            return mainForm;
        }

        private static void MainFormClosing(object sender, CancelEventArgs e)
        {
            IDisplayer[] displayers = _mainDispatcher.DefaultProxy.ContainedDisplayers;
            if (displayers.Length>0)
            {

                foreach (IDisplayer displayer in displayers)
                {
                    displayer.OnClosingWindow();
                }

                string message = "All the tabs will be closed.\nDo your really want to exit the program?";
                DialogResult result = MessageBox.Show(message, "Closing confirmation", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
               if (result == DialogResult.No)
                {
                    foreach (IDisplayer displayer in displayers)
                    {
                        displayer.OnCancelClosingWindow();
                    }

                    e.Cancel = true;
                    return;
                }

            }
            foreach (IDisplayer displayer in displayers)
            {
                DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
                //Оповещение о начале удаления вкладки
                displayer.OnDisplayerRemoving(arguments);
                //Если вкладка запросила отменить удаление, операция прекращается
                if (arguments.Cancel)
                {
                    e.Cancel = true;
                    break;
                }

                if ((displayer.Entity is DispatcheredOperatorCollectionScreen)) continue;

                //Оповещение о окончании удаления вкладки
                displayer.OnDisplayerRemoved(arguments);
                //Если вкладка запросила отменить закрытие, операция прекращается
                if (arguments.Cancel)
                {
                    e.Cancel = true;
                    break;
                }
                _mainDispatcher.DefaultProxy.Remove(displayer, false);
            }

            var user = GlobalObjects.CasEnvironment.IdentityUser;
			if(user.ItemId > 0)
				GlobalObjects.AuditRepository.WriteAsync(new SmartCore.Entities.User(user), AuditOperation.SignOut, user);
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Provider.Logger.Log(e.Exception);
        }

        internal delegate void Action(Object state);
    }
}

