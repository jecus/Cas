#region

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.AvalonButton
{
    internal class AvalonButtonDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BackgroundImage");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("FlatAppearance");
            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("MinimumSize");
            properties.Remove("Padding");
            properties.Remove("TextImageRelation");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("UseMnemonic");
            properties.Remove("UseVisualStyleBackColor");
        }
    }
}