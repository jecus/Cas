using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Logging;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CASTerms;
using SmartCore.AuditMongo.Repository;

namespace CAS.UI
{
    static class Program
    {
        private static Dispatcher _mainDispatcher;
        private static Dictionary<String, ModeProvider> _loadingVariants;
        /// <summary>
        /// ��������� ������ ����������
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
        /// ������������� ��������� �������� ����������
        /// </summary>
        private static void InitLoadingVariants()
        {
            _loadingVariants = new Dictionary<string, ModeProvider>();
            //������������� �������� "Release"
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

            // �������������� ��������� ��������� ����
            Launcher.Prepare();
            // ����������� �������� ������� ����������
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
                //���������� � ������ �������� �������
                displayer.OnDisplayerRemoving(arguments);
                //���� ������� ��������� �������� ��������, �������� ������������
                if (arguments.Cancel)
                {
                    e.Cancel = true;
                    break;
                }

                if ((displayer.Entity is DispatcheredOperatorCollectionScreen)) continue;

                //���������� � ��������� �������� �������
                displayer.OnDisplayerRemoved(arguments);
                //���� ������� ��������� �������� ��������, �������� ������������
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

