#region

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace AvControls.ExtendableList
{
    [ToolboxItem(true)]
    public class AvVScroll : VScrollBar
    {
        private int approximateHeigth;
        private IContainer components;

        public AvVScroll()
        {
            InitializeComponent();
        }

        public int ApproximateHeigth
        {
            get { return approximateHeigth; }
            set
            {
                approximateHeigth = value;
                if (value <= base.Height)
                {
                    base.Visible = false;
                }
                else
                {
                    base.Visible = true;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
        }
    }
}