#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace CAS.UI.UIControls.ComponentControls
{
    internal class AddNewComponentDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BaseDetailAddTo");
        }
    }
}