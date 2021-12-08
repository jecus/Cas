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
            InitLoadingVariants();
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
                                                                      GlobalObjects.CasEnvironment?.Disconnect();
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
                                                                    GlobalObjects.CasEnvironment?.Disconnect();   
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

            var user = GlobalObjects.CasEnvironment?.IdentityUser;
			if(user?.ItemId > 0)
				GlobalObjects.AuditRepository.WriteAsync(new SmartCore.Entities.User(user), AuditOperation.SignOut, user);
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Provider.Logger.Log(e.Exception);
        }

        internal delegate void Action(Object state);
    }
}

