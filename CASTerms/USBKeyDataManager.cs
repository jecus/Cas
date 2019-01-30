using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CASTerms
{
    /// <summary>
    /// Класс отвечающий за доступ к данным USB ключа
    /// </summary>
    public static class USBKeyDataManager
    {

        private static string vendorCode =
                               "kopFebk9Tqyv2aruCd5mR0eow8yvJU95CtULInXsXNItmcIaO8bH0IEPFGM7L9n/xxqTo4tc3SQbdkNm"+
                                "56xgahE5KKbV14TELYbvKY5+1qruRIG3p1dbItYC5GVaX9EE6Xg0s7VHw8G+IYOjy9HDzehsU38m6t9E"+
                                "aSohH1nBTF1FWOw4MV1AHWuWxVlwsc8BAMmoD6pPJTjn0BIJmNd39yJMDRU5sFFesPELgHl4p6IBWrsm"+
                                "9zImJ+AbKdYDZj5QQDizgnIkjUChOJB4wTFXKR3ihIPq7Hx4ODWPD81374exRoZV2fYTw59Ld3jfH/FN"+
                                "A3JLnnwRC6hMyzD6qbZ4t9NN1tZCyDtit9oLFp6hyHgVCa78Uq2WQFRlgFpxixrV2NMSDN5HCDl2QejZ"+
                                "qf1c1Dwz4lWj/ELhucrWB2sep7AMUx/BOA4/j6yJrzYqUmJqySAOV8o+yAj6QLS2tPTLv63EwyufPPDH"+
                                "V3+27kMsCktJ9spPuexcSePMuMCg9VX4WCgKVKRKs2F3ma4WZkl8wDG5RMBtWXa3r5C9r1TmFfkhpqBu"+
                                "PzhrRPek7NkNs/WTW4OD5zD5iMKqPrnGwaYYP7geXx6NskfEmqsO9tlS98vukYuvHwA/4GdtvWFBshGV"+
                                "8H07lMw2OqSy7RGB9wzCmKWC09TSUECW0N2D+0Cf9ZTHKp5N4d15BhxfOS4tRMcorOKZ9RcOuIaoYN50"+
                                "0Z+/zERiHxA3h2kDmJW30YsDUq6tmMJBKvxd7aCoaw9DnaF59g0lm23iVHTYcPHFPWk8rsHkPBHZ9Pcm"+
                                "I3nCng2j+w+YzKo7lZeFT8MWxf2J503jbSU1c3mTSP9IBbfa/UfuFCOZ/xvEx/rH5HINFiiaZl+g1VUf"+
                                "oqTi4GUSlrOxbqOmVEnavI64x4HETnG4Aze+ue3vKvwSju93vGy0dOtyZTo=";




        #region public static LicenseInformation GetUSBKeyData()

        //<summary>
        // Получить данные от USB ключа
        //</summary>
        //<returns></returns>
        //public static LicenseInformation GetOldUSBKeyData()
        //{
        //    throw new Exception();
        //    try
        //    {
        //        HaspFeature feature = HaspFeature.Default;


        //        Hasp hasp = new Hasp(feature);
        //        HaspStatus status = hasp.Login(vendorCode);
        //        if (HaspStatus.StatusOk != status)
        //        {
        //            return null;
        //        }

        //        HaspFile file = hasp.GetFile(HaspFileId.ReadWrite);
        //        int size = 2;
        //        byte[] data = new byte[size];
        //        status = file.Read(data, 0, data.Length);

        //        if (HaspStatus.StatusOk != status)
        //        {
        //            MessageBox.Show(status.ToString());
        //        }

        //        string version = Encoding.ASCII.GetString(data);


        //        size = 29;
        //        file.FilePos = 3;
        //        data = new byte[size];
        //        status = file.Read(data, 0, data.Length);

        //        if (HaspStatus.StatusOk != status)
        //        {
        //            return null;
        //        }

        //        string productKey = Encoding.ASCII.GetString(data);

        //        size = 70;
        //        file.FilePos = 33;
        //        data = new byte[size];
        //        status = file.Read(data, 0, data.Length);

        //        if (HaspStatus.StatusOk != status)
        //        {
        //            return null;
        //        }

        //        string company = Encoding.ASCII.GetString(data);
        //        company = company.Trim(new char[] { '\0' });
        //        hasp.Logout();

        //        return
        //            new LicenseInformation(company, new DateTime(), productKey, "", version, false, 50, true,
        //                                   true);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        #endregion
        
        #region public static LicenseInformation GetUSBKeyData()

        ///<summary>
        /// Получить данные от USB ключа
        ///</summary>
        ///<returns></returns>
        public static LicenseInformation GetUSBKeyData()
        {
            String dllName = "hasp_net_windows.dll";
            String dllPath = Path.Combine(Application.StartupPath, dllName);
            Assembly haspAssembly = null;
            

            if (!File.Exists(dllPath))
            {
                MessageBox.Show(
                    "CAS system can not find essential components. Please reinstall the CAS information system " +
                    "and consult with your system administrator.",
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            try
            {
                haspAssembly = Assembly.LoadFile(dllPath);
            }
            catch
            {
                MessageBox.Show(
                    "CAS system can not find essential components. Please reinstall the CAS information system " + 
                    "and consult with your system administrator.",
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            Type HaspFeatureType = haspAssembly.GetType("Aladdin.HASP.HaspFeature");
            Type HaspType = haspAssembly.GetType("Aladdin.HASP.Hasp");
            Type HaspStatusType = haspAssembly.GetType("Aladdin.HASP.HaspStatus");
            Type HaspFileType = haspAssembly.GetType("Aladdin.HASP.HaspFile");
            Type HaspFileIdType = haspAssembly.GetType("Aladdin.HASP.HaspFileId");

            try
            {
                PropertyInfo haspFeatureDefault = HaspFeatureType.GetProperty("Default");
                Object feature = haspFeatureDefault.GetGetMethod().Invoke(null, null);
                //HaspFeature _feature = HaspFeature.Default;

                Object hasp = haspAssembly.CreateInstance(
                    HaspType.FullName, 
                    false, 
                    BindingFlags.ExactBinding, 
                    null,
                    new Object[] {feature}, 
                    null, 
                    null);
                //Hasp _hasp = new Hasp(_feature);

                MethodInfo loginMethod = HaspType.GetMethod("Login", new[] { vendorCode.GetType() });
                Object status = loginMethod.Invoke(hasp, new Object[] {vendorCode});
                //HaspStatus _status = _hasp.Login(vendorCode);
                if ((Int32)status != 0)
                    return null;
                //if (HaspStatus.StatusOk != _status)
                //    return null;
                //throw new Exception();

                MethodInfo getFileMethod =  HaspType.GetMethod("GetFile", new[] {HaspFileIdType});
                Object HaspFileIdReadWrite = HaspFileIdType.GetField("ReadWrite").GetRawConstantValue();
                Object file = getFileMethod.Invoke(hasp, new[] {HaspFileIdReadWrite});
                //HaspFile _file = _hasp.GetFile(HaspFileId.ReadWrite);

                Int32 size = 2;
                Byte[] data = new Byte[size];
                MethodInfo readMethod = HaspFileType.GetMethod("Read", new[] { data.GetType(), typeof(Int32), typeof(Int32) });
                status = readMethod.Invoke(file, new Object[] {data, 0, data.Length});
                //_status = _file.Read(data, 0, data.Length);

                if ((Int32)status != 0)
                    MessageBox.Show(status.ToString());
                //if (HaspStatus.StatusOk != _status)
                //    MessageBox.Show(_status.ToString());

                String version = Encoding.ASCII.GetString(data);
                
                MethodInfo setFilePos = HaspFileType.GetProperty("FilePos").GetSetMethod();
                setFilePos.Invoke(file, new Object[] {3});
                //_file.FilePos = 3;

                size = 29;
                data = new byte[size];
                status = readMethod.Invoke(file, new Object[] { data, 0, data.Length });
                //_status = _file.Read(data, 0, data.Length);

                if ((Int32)status != 0)
                    return null;
                //if (HaspStatus.StatusOk != _status)
                //    return null;

                String productKey = Encoding.ASCII.GetString(data);

                setFilePos.Invoke(file, new Object[] { 33 });
                //_file.FilePos = 33;
                size = 70;
                data = new byte[size];
                status = readMethod.Invoke(file, new Object[] { data, 0, data.Length });
                //_status = _file.Read(data, 0, data.Length);

                if ((Int32)status != 0)
                    return null;
                //if (HaspStatus.StatusOk != _status)
                //    return null;

                String company = Encoding.ASCII.GetString(data);
                company = company.Trim(new char[] { '\0' });
                MethodInfo logoutMethod = HaspType.GetMethod("Logout");
                logoutMethod.Invoke(hasp, new Object[0]);
                //_hasp.Logout();

                return
                    new LicenseInformation(
                        company, 
                        new DateTime(), 
                        productKey, 
                        "", 
                        version, 
                        false, 
                        50, 
                        true,
                        true);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
