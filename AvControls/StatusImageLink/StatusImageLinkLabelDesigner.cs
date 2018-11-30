#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.StatusImageLink
{
    internal class StatusImageLinkLabelDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("Image");
            properties.Remove("BackgroundImage");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("FlatAppearance");
            properties.Remove("MinimumSize");
            //properties.Remove("Font");
        }
    }
}