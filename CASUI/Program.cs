using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Interfaces;
using CAS.UI.Logging;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CasPresenter;
using CasPresenter.Entities;
using System.Diagnostics;

namespace CAS.UI
{
    static class Program
    {
        private static Dispatcher mainDispatcher;
        private static Dictionary<String, ModeProvider> loadingVariants;
        private static ModeProvider provider;
        private static Presenters presenters;

        public static ModeProvider Provider
        {
            get { return provider; }
        }

        public static Presenters Presenters
        {
            get { return presenters; }
        }

        static Program()
        {   
            InitLoadingVariants();
            InitializePresenters();
        }

        private static void InitializePresenters()
        {
            presenters = new Presenters(
                new AircraftsPresenter(), 
                new StoresPresenter(),
                new DetailsPresenter());
        }

        private static void InitLoadingVariants()
        {
            loadingVariants = new Dictionary<string, ModeProvider>();
            loadingVariants.Add("release",
                                new ModeProvider(
                                    new MailFileLogger(),
                                    delegate(Object state)
                                    {
                                        formMain mainForm = InitProgram();
                                        Application.ThreadException += Application_ThreadException;
                                            Application.Run(mainForm);

                                        if (ConnectionManager.IsConnected)
                                            ConnectionManager.Disconnect();

                                        while (mainDispatcher.ActionApplied == ControlType.LogOut)
                                        {
                                            ConnectionManager.Disconnect();
                                            mainForm.Dispose();
                                            mainForm = InitProgram();

                                            Application.Run(mainForm);
                                        }
                                    }
                                    ));
            loadingVariants.Add("debug",
                                new ModeProvider(
                                    new RethrowableFileLogger(),
                                    delegate(Object state)
                                    {
                                        formMain mainForm = InitProgram();
                                        Application.Run(mainForm);

                                        if (ConnectionManager.IsConnected)
                                            ConnectionManager.Disconnect();

                                        while (mainDispatcher.ActionApplied == ControlType.LogOut)
                                        {
                                            ConnectionManager.Disconnect();
                                            mainForm.Dispose();
                                            mainForm = InitProgram();

                                            Application.Run(mainForm);
                                        }
                                    }
                                    ));
            loadingVariants.Add("domrachev",
                                new ModeProvider(
                                    new RethrowableFileLogger(),
                                    delegate(Object state)
                                    {
                                        Application.Run(new DomrachevSergeyVIPForm());
                                    }
                                    ));
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

            // ѕредварительно провер€ем некоторые вещи
            Launcher.Prepare();

            //
            String mode;
            mode = "release";
#if RELEASE
            mode = "release";
#endif
#if DEBUG
            mode = "debug";
#endif
            provider = loadingVariants[mode];
            provider.Logger.BeginProcess(provider.Action, new Object());
        }

        private static formMain InitProgram()
        {
            formMain mainForm = new formMain();
            mainForm.Closing += mainForm_Closing;
            //Screen startScreen = new Screen();

            mainDispatcher = new Dispatcher(mainForm.dispatcheredMultitabControl, mainForm);
            return mainForm;
        }

        private static void mainForm_Closing(object sender, CancelEventArgs e)
        {
            IDisplayer[] displayers = mainDispatcher.DefaultProxy.ContainedDisplayers;
            foreach (IDisplayer displayer in displayers)
            {
                DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
                displayer.OnDisplayerRemoved(arguments);
                if (arguments.Cancel)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    if (!(displayer.Entity is DispatcheredOperatorCollectionScreen))
                        mainDispatcher.DefaultProxy.Remove(displayer, false);
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Provider.Logger.Log(e.Exception);
        }

        internal delegate void Action(Object state);

    }
}

