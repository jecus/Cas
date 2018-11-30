using System;
using System.Windows.Forms;
using CASTerms;

namespace CAS.UI.Logging
{
    internal class SafeFileLogger : FileLogger
    {
        public override void BeginProcess(Program.Action action, Object state)
        {
            try
            {
                action(state);
            }
            catch (Exception anyException)
            {
                Log(anyException);
            }
        }

        public void Log(Exception ex)
        {
            base.Log("Uncaught exception", ex);
        }

        public override void Log(String message, Exception ex)
        {
            base.Log(message, ex);
            String tehnicalInfo = "";
            if (ex != null && !String.IsNullOrEmpty(ex.Message))
                tehnicalInfo = String.Format("\r\n\r\nTechnical information:\r\n{0}", ex.Message);

            //String data = String.Format("{0}{1}", message, tehnicalInfo);
            String[] messageLines = message.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            Int32 width = 90;
            if (messageLines[0].Length < 90)
                messageLines[0] = messageLines[0].PadRight(width);
            message = String.Join(Environment.NewLine, messageLines);
            String data = String.Format("{0}", message);
            MessageBox.Show(data, new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
        }
    }
}