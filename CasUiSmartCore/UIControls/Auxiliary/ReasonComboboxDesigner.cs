#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace CAS.UI.UIControls.Auxiliary
{
    internal class ReasonComboboxDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("ReasonCategory");
        }
    }
}