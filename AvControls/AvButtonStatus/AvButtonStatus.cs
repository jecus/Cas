#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls.Properties;

#endregion

namespace AvControls.AvButtonStatus
{
    [Designer(typeof (AvButtonStatusDesigner)), DefaultProperty("TextMain"), DefaultEvent("Click")]
    public class AvButtonStatus : AvButtonT.AvButtonT
    {
        private readonly Size DEFAULT_SIZE = new Size(220, 0x36);
        private readonly Image[] imageArray;
        private IContainer components;
        private Statuses statusImage;

        public AvButtonStatus()
        {
            InitializeComponent();
            base.Size = DEFAULT_SIZE;
            base.TextMain = "AvButtonStatus";
            imageArray = new Image[]
                             {
                                 Resources.SatisfactoryArrow, Resources.NotifyArrow, Resources.NotSatisfactoryArrow,
                                 Resources.NotActiveArrow
                             };
            base.Icon = imageArray[3];
            Status = Statuses.NotActive;
        }

        [Description("Cтатус элемента управления"), Category("Appearance"), DefaultValue(4)]
        public Statuses Status
        {
            get { return statusImage; }
            set
            {
                statusImage = value;
                base.Icon = imageArray[statusImage.GetHashCode()];
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
            base.AutoScaleMode = AutoScaleMode.Font;
        }
    }
}