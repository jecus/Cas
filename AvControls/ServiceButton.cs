#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace AvControls
{
    [ToolboxItem(false)]
    public class ServiceButton : Button
    {
        private Color activeBorderColor = Color.Black;
        private IContainer components;

        public ServiceButton(Image activeImage, Image inactiveImage)
        {
            InitializeComponent();
            ActiveImage = activeImage;
            InactiveImage = inactiveImage;
        }

        public Color ActiveBorderColor
        {
            get { return activeBorderColor; }
            set { activeBorderColor = value; }
        }

        public Image ActiveImage { get; set; }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.FlatAppearance.BorderColor = value;
                base.BackColor = value;
            }
        }

        public Image InactiveImage { get; set; }

        protected override bool ShowFocusCues
        {
            get { return false; }
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
            base.SuspendLayout();
            base.FlatStyle = FlatStyle.Flat;
            base.TabStop = false;
            base.ResumeLayout(false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (base.Enabled)
            {
                BackgroundImage = ActiveImage;
            }
            else
            {
                BackgroundImage = InactiveImage;
            }
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.FlatAppearance.BorderColor = BackColor;
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            base.FlatAppearance.BorderColor = ActiveBorderColor;
        }
    }
}