using System;

namespace CAS.UI.Logging
{
    internal interface ILogger
    {
        void BeginProcess(Program.Action action, Object state);
        void Log(Exception ex);
        void Log(String message, Exception ex);
    }
}