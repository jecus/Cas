using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CASTerms
{
    /// <summary>
    /// Предоставляет информацию
    /// </summary>
    public static class WindowsRegistryDataManager
    {

        public static LicenseInformation GetRegistryInformation()
        {
            var termsProvider = new GlobalTermsProvider();
            try
            {
                RegistryKey software = Registry.LocalMachine.OpenSubKey("Software");
                if (software == null) return null;
                RegistryKey subKey = software.OpenSubKey("{132FS-54YHJ6-RH12655-5443DFH-435DF}");
                if (subKey == null) return null;
                RegistryKey companyName = software.OpenSubKey(termsProvider["CompanyName"].ToString());
                if (companyName == null) return null;
                RegistryKey cas = companyName.OpenSubKey("CAS");
                if (cas == null) return null;

	            long data;

#if DEBUG
				data = 636247008000000000;	
#else
				data = (long) subKey.GetValue("InstallationData");
#endif

				var date = DateTime.FromBinary(data);
                string company = cas.GetValue("Company").ToString();

                return new LicenseInformation(company, date);
            }
            catch
            {
                return null;
            }

        }

        public static bool Is64BitOs
        {
            get { return (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).IndexOf(" (x86)") != -1); }
        }
    }
}
