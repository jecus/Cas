using System;
using System.Windows.Forms;
using CAS.UI.Messages;
using CASTerms;
//using SmartCore.Management.License;

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
        private static bool _isLicenseFound;
        private static bool _isUsbKeyFound;
        private static string companyName;
        
        #endregion

        #region Constructors


        #region LicenseDispatcher


        static LicenseDispatcher()
        {

            timer = new Timer();
            timer.Interval = time;
            timer.Tick += TimerTick;
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
            get { return _isLicenseFound; }
        }

        #endregion

        #region public static bool IsUSBKeyFound
        /// <summary>
        /// Найден ли USB ключ
        /// </summary>
        public static bool IsUSBKeyFound
        {
            get { return _isUsbKeyFound; }
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
	        _isUsbKeyFound = false;
	        _isLicenseFound = false;
	        var windowsRegistryLicenseInformation = WindowsRegistryDataManager.GetRegistryInformation();

	        if (windowsRegistryLicenseInformation == null)
	        {
		        CASMessage.Show(MessageType.LicenseInformationNotEqual);
		        Environment.Exit(Environment.ExitCode);
	        }

	        _isLicenseFound = true;


	        if (DateTime.Now.Date > windowsRegistryLicenseInformation.Expires.Date)
	        {
		        CASMessage.Show(MessageType.LicenseExpired);
		        Environment.Exit(Environment.ExitCode);
	        }

	        if (DateTime.Now.Date < windowsRegistryLicenseInformation.Expires.Date &&
	            (windowsRegistryLicenseInformation.Expires.Date - DateTime.Now.Date).TotalDays > 180)
	        {
		        CASMessage.Show(MessageType.LicenseViolation);
		        Environment.Exit(Environment.ExitCode);
	        }

	        form.Text = new GlobalTermsProvider()["SystemName"] + ". Evaluation copy. Valid till " +
	                    windowsRegistryLicenseInformation.Expires.ToString(
		                    new GlobalTermsProvider()["DateFormat"].ToString());

	        timer.Enabled = true;

        }

        #endregion

        #region static void TimerTick(object sender, EventArgs e)

        static void TimerTick(object sender, EventArgs e)
        {
            CheckLicenseInformation();            
        }

        #endregion


        
        #endregion

    }
}