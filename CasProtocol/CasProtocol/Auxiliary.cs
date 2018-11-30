namespace CasProtocol
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Auxiliary
    {
        private static FileInfo _LogFile;

        public static void ClearLog()
        {
            if (_LogFile == null)
            {
                SetDefaultLogFile();
            }
            if (_LogFile.Exists)
            {
                try
                {
                    _LogFile.Delete();
                }
                catch
                {
                }
            }
        }

        public static void ReadConfigFile(string ConfigFilePath, ReadConfigLineDelegate ReadConfigLine)
        {
            if (ReadConfigLine != null)
            {
                FileInfo info = new FileInfo(ConfigFilePath);
                if (info.Exists)
                {
                    try
                    {
                        string str = "";
                        using (StreamReader reader = new StreamReader(info.FullName, Encoding.Default))
                        {
                            str = reader.ReadToEnd();
                        }
                        string[] strArray = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            string str2 = strArray[i].Trim();
                            if (!str2.StartsWith("#"))
                            {
                                int index = str2.IndexOf('=');
                                if (index > 0)
                                {
                                    string parameter = str2.Substring(0, index).Trim();
                                    string str4 = str2.Substring(index + 1).Trim();
                                    ReadConfigLine(parameter, str4);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        WriteLog("Exception while reading config file:\r\n" + exception.ToString());
                    }
                }
            }
        }

        private static void SetDefaultLogFile()
        {
            _LogFile = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Avalon Worldgroup Inc\Continuing Airworthiness System\network.log.txt"));
        }

        public static void ViewLog()
        {
            if (_LogFile == null)
            {
                SetDefaultLogFile();
            }
            _LogFile.Refresh();
            if (_LogFile.Exists)
            {
                try
                {
                    new Process { StartInfo = { FileName = _LogFile.FullName } }.Start();
                }
                catch
                {
                }
            }
        }

        public static void WriteLog(object o)
        {
            if (_LogFile == null)
            {
                SetDefaultLogFile();
            }
            try
            {
                FileStream stream = null;
                if (!_LogFile.Exists)
                {
                    stream = _LogFile.Create();
                }
                else
                {
                    stream = new FileStream(_LogFile.FullName, FileMode.Append, FileAccess.Write);
                }
                byte[] bytes = Encoding.Default.GetBytes(DateTime.Now.ToString() + "\r\n" + o.ToString() + "\r\n\r\n\r\n");
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
            catch
            {
            }
        }

        public static FileInfo LogFile
        {
            get
            {
                return _LogFile;
            }
            set
            {
                _LogFile = value;
            }
        }

        public delegate void ReadConfigLineDelegate(string parameter, string value);
    }
}

