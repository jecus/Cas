#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.ImageLink
{
    internal class ImageLinkLabelDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("FlatAppearance");
            properties.Remove("MinimumSize");
            properties.Remove("Font");
        }
    }
}