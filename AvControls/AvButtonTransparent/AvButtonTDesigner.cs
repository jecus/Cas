#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.AvButtonTransparent
{
    internal class AvButtonTDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BackgroundImage");
            properties.Remove("Font");
            properties.Remove("ForeColor");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("Padding");
            properties.Remove("Text");
            properties.Remove("TextAlign");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("UseMnemonic");
            properties.Remove("UseVisualStyleBackColor");
        }
    }
}