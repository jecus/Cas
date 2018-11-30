#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace AvControls.ExtendableList
{
    public class AvLayoutPanel : PictureBox
    {
        private IContainer components;

        public AvLayoutPanel()
        {
            InitializeComponent();
        }

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (((base.Controls.IndexOf(control) < (base.Controls.Count - 1)) && (base.Controls.IndexOf(control) >= 0)) &&
                (control != null))
            {
                int num = base.Controls.IndexOf(control) + 1;
                int count = base.Controls.Count;
                for (int i = num; i < count; i++)
                {
                    base.Controls[i].Location = new Point(base.Controls[i - 1].Left, base.Controls[i - 1].Bottom);
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

        private void FirstControl_LocationChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.Location = new Point(0, 0);
            }
        }

        private void InitializeComponent()
        {
            components = new Container();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            Point point;
            base.OnControlAdded(e);
            e.Control.Width = base.Width;
            if (base.Controls.IndexOf(e.Control) > 0)
            {
                Control control = base.Controls[base.Controls.IndexOf(e.Control) - 1];
                point = new Point(control.Left, control.Bottom);
                e.Control.Location = point;
                e.Control.SizeChanged += Control_SizeChanged;
            }
            else
            {
                point = new Point(0, 0);
                e.Control.Location = point;
                e.Control.LocationChanged += FirstControl_LocationChanged;
            }
        }
    }
}