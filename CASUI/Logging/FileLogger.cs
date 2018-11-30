using System;
using System.IO;
using System.Text;
using CAS.Core.ProjectTerms;

namespace CAS.UI.Logging
{
    internal abstract class FileLogger : ILogger
    {
        private static Object syncObject = new Object();

        public abstract void BeginProcess(Program.Action action, object state);

        public virtual void Log(Exception ex)
        {
            Log("", ex);
        }

        public virtual void Log(String message, Exception ex)
        {
            StringBuilder content = new StringBuilder();

            content.AppendLine("-----------------------");
            content.AppendLine(DateTime.Now.ToString());

            if (ex != null)
            {
                content.AppendLine("" + ex.GetType());
                content.AppendLine("Message: " + ex.Message);
                content.AppendLine("Inner: " + ex.InnerException != null ? "" : ex.InnerException.ToString());
                content.AppendLine("Source: " + ex.Source);
                content.AppendLine(ex.StackTrace);
            }

            lock (syncObject)
            {
                String localApplicationData = TermsProvider.GetTempFolderPath();
                String logFile = Path.Combine(localApplicationData, "error.log");
                try
                {
                    File.AppendAllText(logFile, content.ToString());
                }
                catch (Exception e)
                {
                    // Ошибка возникает при сохранении ошибки....
                }
            }
        }
    }
}