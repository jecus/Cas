using System;

namespace CAS.UI.Logging
{
    internal class RethrowableFileLogger : FileLogger
    {
        public override void BeginProcess(Program.Action action, Object state)
        {
            action(state);
        }

        public override void Log(Exception ex)
        {
            base.Log(ex);
            throw new Exception("\r\n" + ex.StackTrace, ex);
        }

        public override void Log(string message, Exception ex)
        {
            base.Log(message, ex);
            throw new Exception("\r\n" + ex.StackTrace, ex);
        }
    }
}