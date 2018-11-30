#region

using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.AvMultitabControl.Design
{
    public class MultitabPageDesigner : ParentControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get { return SelectionRules.None; }
        }

        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            return (parentDesigner.Component is AvMultitabControl);
        }

        protected override void PostFilterEvents(IDictionary events)
        {
            base.PostFilterEvents(events);
            events.Remove("AutoSizeChanged");
            events.Remove("DockChanged");
            events.Remove("EnabledChanged");
            events.Remove("LocationChanged");
            events.Remove("TabIndexChanged");
            events.Remove("TabStopChanged");
            events.Remove("VisibleChanged");
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties.Remove("Anchor");
            properties.Remove("AutoSize");
            properties.Remove("AutoSizeMode");
            properties.Remove("Dock");
            properties.Remove("Font");
            properties.Remove("ForeColor");
            properties.Remove("Enabled");
            properties.Remove("Location");
            properties.Remove("MaximumSize");
            properties.Remove("MinimumSize");
            properties.Remove("PreferredSize");
            properties.Remove("TabIndex");
            properties.Remove("TabStop");
            properties.Remove("Visible");
        }
    }
}