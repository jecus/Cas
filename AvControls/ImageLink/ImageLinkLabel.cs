#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace AvControls.ImageLink
{
    [Designer(typeof (ImageLinkLabelDesigner)), DefaultEvent("Click")]
    public class ImageLinkLabel : UserControl
    {
        private static readonly Size DefaultControlSize = new Size(150, 20);
        private readonly LinkLabel _linkLabel = new LinkLabel();
        private readonly PictureBox _pictureBox = new PictureBox();
        private Color _activeLinkColor = Color.FromArgb(0x43, 0xf8, 0xff);
        private IContainer components;
        private Color _hoveredLinkColor = Color.FromArgb(0xa5, 0xa3, 0xff);
        private Color _linkColor = Color.FromArgb(0x3e, 0x9b, 0xf6);
        private Point _linkLocation;
        private int _oldHeight;
        private int _oldWidth;
        private Padding _padding = new Padding(0);

        protected ImageLinkLabel()
        {
            Initialize();
        }

        public Color ActiveLinkColor
        {
            get { return _activeLinkColor; }
            set
            {
                _activeLinkColor = value;
                _linkLabel.ActiveLinkColor = value;
            }
        }

        [Category("Appearance"), Description("Размер элемента управления по умолчанию")]
        public static Size DefaultContolSize
        {
            get { return DefaultControlSize; }
        }

        public Color HoveredLinkColor
        {
            get { return _hoveredLinkColor; }
            set { _hoveredLinkColor = value; }
        }

        [Category("Appearance"), Description("Изображение данного элемента управления")]
        public Image Image
        {
            get { return _pictureBox.BackgroundImage; }
            set { _pictureBox.BackgroundImage = value; }
        }

        [Category("Appearance"), Description("Цвет фона")]
        public Color ImageBackColor
        {
            get { return _pictureBox.BackColor; }
            set { _pictureBox.BackColor = value; }
        }

        [Category("Appearance"), Description("Image Layout")]
        public ImageLayout ImageLayout
        {
            get { return _pictureBox.BackgroundImageLayout; }
            set { _pictureBox.BackgroundImageLayout = value; }
        }

        public Color LinkColor
        {
            get { return _linkColor; }
            set
            {
                _linkColor = value;
                _linkLabel.LinkColor = value;
            }
        }

        public LinkLabel LinkLabel
        {
            get { return _linkLabel; }
        }

        [Category("Appearance"), Description("Цвеи текста при выделении")]
        public Color LinkMouseCapturedColor { get; set; }

        public new Padding Padding
        {
            get { return _padding; }
            set
            {
                _padding = value;
                ApplyPadding();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true),
         Description(" Текст отображаемый элементом управления"), Category("Appearance")]
        public override string Text
        {
            get { return _linkLabel.Text; }
            set
            {
                base.Text = value;
                _linkLabel.Text = value;
            }
        }

        [Category("Appearance"), Description("Выравнивание текста")]
        public ContentAlignment TextAlign
        {
            get { return _linkLabel.TextAlign; }
            set { _linkLabel.TextAlign = value; }
        }

        [Description("Шрифт текста"), Category("Appearance")]
        public Font TextFont
        {
            get { return _linkLabel.Font; }
            set { _linkLabel.Font = value; }
        }

        private void ApplyPadding()
        {
            LinkLabel.Location = new Point(_linkLocation.X + _padding.Left, _linkLocation.Y + _padding.Top);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Initialize()
        {
            InitializeComponent();
            Size = DefaultControlSize;
            //Enabled = false;
            _pictureBox.Location = new Point(0, 0);
            _pictureBox.BackColor = Color.Transparent;
            _pictureBox.Size = new Size(DefaultControlSize.Height, DefaultControlSize.Height);
            _pictureBox.BackgroundImageLayout = ImageLayout.Center;
            _linkLabel.BackColor = Color.Transparent;
            _linkLabel.Padding = Padding;
            _linkLabel.TextAlign = ContentAlignment.MiddleLeft;
            _linkLabel.Location = new Point(_pictureBox.Right, 0);
            _linkLabel.ForeColor = Color.Transparent;
            _linkLabel.MouseMove += LinkLabelMouseMove;
            _linkLabel.MouseLeave += LinkLabelMouseLeave;
            _linkLabel.LinkClicked += LinkLabelLinkClicked;
            BackColor = Color.Transparent;
            Name = "ImageLinkLabel";
            ResumeLayout(false);
            _linkLocation = _linkLabel.Location;
            Controls.Add(_pictureBox);
            Controls.Add(_linkLabel);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
        }

        private void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OnClick(e);
            }
        }

        private void LinkLabelMouseLeave(object sender, EventArgs e)
        {
            _linkLabel.LinkColor = _linkColor;
        }

        private void LinkLabelMouseMove(object sender, MouseEventArgs e)
        {
            _linkLabel.LinkColor = _hoveredLinkColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            SetEnabled(Enabled);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Width != _oldWidth)
            {
                _oldWidth = Width;
                _linkLabel.Width = Width - _pictureBox.Height;
            }
            if (Height != _oldHeight)
            {
                _oldHeight = Height;
                _pictureBox.Size = new Size(Height, Height);
                _linkLabel.Left = _pictureBox.Right;
                _linkLabel.Height = Height;
                _linkLabel.Width = Width - _pictureBox.Width;
            }
        }

        private void SetEnabled(bool value)
        {
            _linkLabel.Enabled = value;
            _pictureBox.Enabled = value;
        }
    }
}