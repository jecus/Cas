#region

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace AvControls.AvMultitabControl.Auxiliary
{
    internal class AvProfessionalColorTable : ProfessionalColorTable
    {
        public AvProfessionalColorTable(AvMultitabControl owner)
        {
            Owner = owner;
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(0xfe, 0xfe, 0xfb); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(0xc4, 0xc3, 0xac); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(0xec, 230, 0xdf); }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(0x8a, 0x86, 0x7a); }
        }

        public override Color MenuItemBorder
        {
            get { return Owner.ActiveElementBorderColor; }
        }

        public override Color MenuItemSelected
        {
            get { return Owner.ActiveElementBgColor; }
        }

        private AvMultitabControl Owner { get; set; }
    }
}