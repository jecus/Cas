#region

using System;

#endregion

namespace AvControls.StatusImageLink
{
    public class StatusEventArgs : EventArgs
    {
        private readonly Statuses _controlStatus;

        public StatusEventArgs()
        {
        }

        public StatusEventArgs(Statuses controlStatus)
        {
            _controlStatus = controlStatus;
        }

        public Statuses ControlStatus
        {
            get { return _controlStatus; }
        }
    }
}