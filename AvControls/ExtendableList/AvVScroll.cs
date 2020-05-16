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
            get => approximateHeigth;
            set
            {
	            approximateHeigth = value;
	            base.Visible = value > base.Height;
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