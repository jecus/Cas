using System;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.daCore.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.UI.Messages;
using CASTerms;

namespace CAS.UI.Management
{
    /// <summary>
    /// Класс, хранящий информацию о лицензиях 
    /// </summary>
    public static class LicenseDispatcher
    {

        #region Fields

        private static readonly Timer timer;
        private static int time = 1000000;
        private static MessageForm messageForm;
        private static Form form;
        private static bool isLicenseFound = false;
        private static bool isUSBKeyFound = false;
        private static string companyName;
        
        #endregion

        #region Constructors


        #region LicenseDispatcher


        static LicenseDispatcher()
        {

            timer = new Timer();
            timer.Interval = time;
            timer.Tick += timer_Tick;
            timer.Enabled = true;


        }

        #endregion


        #endregion

        #region Properties

        #region public static Form Form
        /// <summary>
        /// Main program form
        /// </summary>
        public static Form Form
        {
            get { return form; }
            set { form = value; }
        }

        #endregion

        #region public static bool IsLicenseFound
        /// <summary>
        /// Найден ли файл лицензии
        /// </summary>
        public static bool IsLicenseFound
        {
            get { return isLicenseFound; }
        }

        #endregion

        #region public static bool IsUSBKeyFound
        /// <summary>
        /// Найден ли USB ключ
        /// </summary>
        public static bool IsUSBKeyFound
        {
            get { return isUSBKeyFound; }
        }

        #endregion

        #region public static string CompanyName

        /// <summary>
        /// Имя компании
        /// </summary>
        public static string CompanyName
        {
            get { return companyName; }
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region public static void CheckLicenseInformation()
        
        /// <summary>
        /// Проверить поля ProductKey и ComponyName в USB ключе и реестре
        /// </summary>
        public static void CheckLicenseInformation()
        {
            timer.Enabled = false;
            isUSBKeyFound = false;
            isLicenseFound = false;
            LicenseInformation windowsRegistryLicenseInformation =
                WindowsRegistryDataManager.GetRegistryInformation();
            if (windowsRegistryLicenseInformation == null)
            {
                CASMessage.Show(MessageType.LicenseInformationNotEqual);
                Environment.Exit(Environment.ExitCode);
            }
            LicenseInformation usbLicenseInformation = USBKeyDataManager.GetUSBKeyData();
            if (usbLicenseInformation == null)
            {


                

                isLicenseFound = true;


                if (DateTime.Now.Date > windowsRegistryLicenseInformation.Expires.Date)
                {
                    CASMessage.Show(MessageType.LicenseExpired);
                    Environment.Exit(Environment.ExitCode);
                    return;
                }

                if (DateTime.Now.Date < windowsRegistryLicenseInformation.Expires.Date && (windowsRegistryLicenseInformation.Expires.Date - DateTime.Now.Date).TotalDays > 45)
                {
                    CASMessage.Show(MessageType.LicenseViolation);
                    Environment.Exit(Environment.ExitCode);
                    return;
                }

                form.Text = new TermsProvider()["SystemName"] + ". Evaluation copy. Valid till " +
                            windowsRegistryLicenseInformation.Expires.ToString(
                                new TermsProvider()["DateFormat"].ToString());
            }
            else
            {
                if (usbLicenseInformation.Company!=windowsRegistryLicenseInformation.Company)
                {
                    form.Enabled = false; 
                    if (messageForm!=null)
                        messageForm.Close();
                    messageForm = new MessageForm();

                    messageForm.MessageText =
                        string.Format(new MessageInfoProvider()[MessageType.USBKeyNotValid.ToString()].ToString(),
                                      windowsRegistryLicenseInformation.Company);
                    messageForm.Text = MessageType.USBKeyNotValid.ToString();
                    messageForm.ShowDialog();
                    form.Enabled = true; 
                    if (messageForm.IsRetryButtonPushed)
                    {
                        CheckLicenseInformation();
                        return;
                    }
                    ConnectionManager.Disconnect();
                    Environment.Exit(Environment.ExitCode);                    
                }
                isUSBKeyFound = true;

                if (messageForm != null)
                    messageForm.Close();
                form.Text = new TermsProvider()["SystemName"] + ". Licensed to " +
                    windowsRegistryLicenseInformation.Company;

            }
            timer.Enabled = true;

        }

        #endregion

        #region static void timer_Tick(object sender, EventArgs e) 

        static void timer_Tick(object sender, EventArgs e)
        {
            CheckLicenseInformation();            
        }

        #endregion


        
        #endregion

    }
}