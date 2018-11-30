#region

using System.ComponentModel;

#endregion

namespace AvControls
{
    public enum Statuses
    {
        [Description("Unknown")] NotActive = 4,
        [Description("Notification")] Notify = 1,
        [Description("Not Satisfactory")] NotSatisfactory = 2,
        [Description("Pending")] Pending = 3,
        [Description("Satisfactory")] Satisfactory = 0
    }
}