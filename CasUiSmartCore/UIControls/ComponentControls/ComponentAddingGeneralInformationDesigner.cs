#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace CAS.UI.UIControls.ComponentControls
{
    internal class ComponentAddingGeneralInformationDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("ATAChapter");
            properties.Remove("ComponentCurrentTSNCSN");
            properties.Remove("ComponentTCSI");
            properties.Remove("ComponentTCSNOnInstall");
            properties.Remove("AircraftTCSNOnInstall");
            properties.Remove("MaintenanceType");
        }
    }
}