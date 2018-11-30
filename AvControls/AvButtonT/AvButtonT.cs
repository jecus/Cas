#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls.AvButtonTransparent;

#endregion

namespace AvControls.AvButtonT
{
    [DefaultEvent("Click"), Designer(typeof(AvButtonTDesigner)), DefaultProperty("TextMain")]
    public class AvButtonT : UserControl
    {
        private readonly Size DEFAULT_SIZE = new Size(0xc2, 0x36);
        private readonly Label mainLabel = new Label();
        private readonly PictureBox pictureBoxIcon = new PictureBox();
        private readonly Label secondaryLabel = new Label();
        private Color activeBackColor = Color.Transparent;
        private Image activeBackgroundImage;
        private IContainer components;
        private bool hoverable;
        private Image icon;
        private Image iconNotEnabled;
        private Image normalBackgroundImage;
        private int oldHeight;
        private int oldWidth;
        private Color tempBackColor = Color.Transparent;

        private bool _showToolTip;
        private ToolTip toolTip;
        private bool _toolTipTextVisible;
        private string _toolTipText;

        public AvButtonT()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = DEFAULT_SIZE;
            IconLayout = ImageLayout.Center;
            pictureBoxIcon.Location = new Point(0, 0);
            pictureBoxIcon.Size = new Size(base.Height, base.Height);
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Cursor = Cursors.Hand;
            pictureBoxIcon.Visible = false;
            mainLabel.Location = new Point(0, 0);
            mainLabel.Size = new Size(base.Width, base.Height);
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Cursor = Cursors.Hand;
            mainLabel.Font = new Font("Verdana", 14.25f, FontStyle.Regular);
            mainLabel.Text = "AvButtonT";
            mainLabel.TextAlign = ContentAlignment.MiddleLeft;
            secondaryLabel.Location = new Point(0, base.Height / 2);
            secondaryLabel.Size = new Size(base.Width, base.Height - mainLabel.Height);
            secondaryLabel.BackColor = Color.Transparent;
            secondaryLabel.Cursor = Cursors.Hand;
            secondaryLabel.Font = new Font("Verdana", 9.75f, FontStyle.Regular);
            secondaryLabel.Text = "";
            secondaryLabel.TextAlign = ContentAlignment.MiddleLeft;
            base.Controls.Add(pictureBoxIcon);
            base.Controls.Add(mainLabel);
            base.Controls.Add(secondaryLabel);
            for (int i = 0; i < base.Controls.Count; i++)
            {
                base.Controls[i].Click += AvButtonTClick;
                base.Controls[i].MouseHover += AvButtonTMouseHover;
                base.Controls[i].MouseMove += AvButtonTMouseMove;
                base.Controls[i].MouseLeave += AvButtonTMouseLeave;
                base.Controls[i].MouseClick += AvButtonTMouseClick;
            }
            base.EnabledChanged += AvButtonTEnabledChanged;
            SetIcon();
        }

        [Description("Цвет кнопки, при наведении на неё мыши"), Category("Appearance")]
        public Color ActiveBackColor
        {
            get { return activeBackColor; }
            set { activeBackColor = value; }
        }

        [Description("Активная фоновая картинка"), Category("Appearance")]
        public Image ActiveBackgroundImage
        {
            get { return activeBackgroundImage; }
            set { activeBackgroundImage = value; }
        }

        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set
            {
                base.Cursor = value;
                pictureBoxIcon.Cursor = value;
                mainLabel.Cursor = value;
                secondaryLabel.Cursor = value;
            }
        }

        [Description("Шрифт первого текста"), Category("Appearance")]
        public Font FontMain
        {
            get { return mainLabel.Font; }
            set { mainLabel.Font = value; }
        }

        [Category("Appearance"), Description("Шрифт второго текста")]
        public Font FontSecondary
        {
            get { return secondaryLabel.Font; }
            set { secondaryLabel.Font = value; }
        }

        [Category("Appearance"), Description("Цвет первого текста")]
        public Color ForeColorMain
        {
            get { return mainLabel.ForeColor; }
            set { mainLabel.ForeColor = value; }
        }

        [Category("Appearance"), Description("Цвет второго текста")]
        public Color ForeColorSecondary
        {
            get { return secondaryLabel.ForeColor; }
            set { secondaryLabel.ForeColor = value; }
        }

        [Description("Иконка"), Category("Appearance")]
        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                if (value != null)
                {
                    mainLabel.Left = pictureBoxIcon.Right;
                    mainLabel.Width = base.Width - pictureBoxIcon.Width;
                    secondaryLabel.Left = pictureBoxIcon.Right;
                    secondaryLabel.Width = base.Width - pictureBoxIcon.Width;
                    pictureBoxIcon.Visible = true;
                }
                else
                {
                    mainLabel.Left = 0;
                    mainLabel.Width = base.Width;
                    secondaryLabel.Left = 0;
                    secondaryLabel.Width = base.Width;
                    pictureBoxIcon.Visible = false;
                }
                SetIcon();
            }
        }

        [Category("Appearance"), Description("Расположение иконки")]
        public ImageLayout IconLayout
        {
            get { return pictureBoxIcon.BackgroundImageLayout; }
            set { pictureBoxIcon.BackgroundImageLayout = value; }
        }

        [Description("Иконка при Enabled = false"), Category("Appearance")]
        public Image IconNotEnabled
        {
            get { return iconNotEnabled; }
            set
            {
                iconNotEnabled = value;
                SetIcon();
            }
        }

        [Description("Фоновая картинка"), Category("Appearance")]
        public Image NormalBackgroundImage
        {
            get { return normalBackgroundImage; }
            set
            {
                normalBackgroundImage = value;
                BackgroundImage = value;
            }
        }

        [Description("Отступы первого текста"), Category("Layout")]
        public Padding PaddingMain
        {
            get { return mainLabel.Padding; }
            set { mainLabel.Padding = value; }
        }

        [Description("Отступы второго текста"), Category("Layout")]
        public Padding PaddingSecondary
        {
            get { return secondaryLabel.Padding; }
            set { secondaryLabel.Padding = value; }
        }

        [Category("Appearance"), Description("Показывать текст всплывающей подсказки")]
        public bool ShowToolTip
        {
            get { return _showToolTip; }
            set { _showToolTip = value; }
        }

        [Description("Выравнивание первого текста"), Category("Appearance")]
        public ContentAlignment TextAlignMain
        {
            get { return mainLabel.TextAlign; }
            set { mainLabel.TextAlign = value; }
        }

        [Category("Appearance"), Description("Выравнивание второго текста")]
        public ContentAlignment TextAlignSecondary
        {
            get { return secondaryLabel.TextAlign; }
            set { secondaryLabel.TextAlign = value; }
        }

        [Description("Первый текст"), Category("Appearance")]
        public string TextMain
        {
            get { return mainLabel.Text; }
            set { mainLabel.Text = value; }
        }

        [Category("Appearance"), Description("Второй текст")]
        public string TextSecondary
        {
            get { return secondaryLabel.Text; }
            set
            {
                secondaryLabel.Text = value;
                if (value == "")
                {
                    mainLabel.Height = Height;
                }
                else
                {
                    mainLabel.Height = Height / 2;
                    secondaryLabel.Top = Height / 2;
                    secondaryLabel.Height = Height - mainLabel.Height;
                }
            }
        }

        [Category("Appearance"), Description("Текст всплывающей подсказки")]
        public string ToolTipText
        {
            get { return _toolTipText; }
            set { _toolTipText = value ?? "";}
        }

        private void AvButtonTClick(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void AvButtonTEnabledChanged(object sender, EventArgs e)
        {
            SetIcon();
        }

        private void AvButtonTMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                base.OnClick(new EventArgs());
            }
        }

        void AvButtonTMouseHover(object sender, EventArgs e)
        {
            if (_showToolTip && !_toolTipTextVisible && _toolTipText.Trim() != "")
            {
                Graphics graphics = CreateGraphics();
                SizeF ef = graphics.MeasureString(_toolTipText, new Font("Tahoma", 8.25f, FontStyle.Regular));
                graphics.Dispose();
                int num = ((int)(ef.Width / 2f));
                toolTip.Show(_toolTipText, this, num, Bottom - 5, 5000);
                _toolTipTextVisible = true;
            }
        }

        private void AvButtonTMouseLeave(object sender, EventArgs e)
        {
            if (activeBackgroundImage != null)
            {
                BackgroundImage = normalBackgroundImage;
            }
            if (hoverable)
            {
                BackColor = tempBackColor;
            }
            if (toolTip.Active)
            {
                toolTip.Hide(this);
                _toolTipTextVisible = false;
            }
        }

        private void AvButtonTMouseMove(object sender, MouseEventArgs e)
        {
            if (hoverable && (activeBackColor != BackColor))
            {
                tempBackColor = BackColor;
                BackColor = activeBackColor;
            }
            if (activeBackgroundImage != null)
            {
                BackgroundImage = activeBackgroundImage;
            }
        }

        public void ChangeWidth()
        {
            int num = 7;
            try
            {
                Graphics graphics = CreateGraphics();
                Width = ((int)graphics.MeasureString(TextMain, FontMain).Width) + num;
                graphics.Dispose();
            }
            catch (Exception ex)
            {
                if (ex as ObjectDisposedException == null)
                    throw;
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
            toolTip = new ToolTip();
            toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            toolTip.ShowAlways = true;
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            Cursor = Cursors.Hand;
            base.Name = "AvButtonT";
            base.MouseHover += new EventHandler(AvButtonTMouseHover);
            base.MouseMove += AvButtonTMouseMove;
            base.MouseLeave += AvButtonTMouseLeave;
            base.ResumeLayout(false);
        }

        protected override void OnClick(EventArgs e)
        {
            base.Focus();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            base.BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.KeyData == Keys.Space) || (e.KeyData == Keys.Return))
            {
                base.OnClick(new EventArgs());
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.BorderStyle = BorderStyle.None;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (base.Width != oldWidth)
            {
                oldWidth = base.Width;
                if (Icon != null)
                {
                    mainLabel.Left = pictureBoxIcon.Right;
                    secondaryLabel.Left = pictureBoxIcon.Right;
                    mainLabel.Width = base.Width - pictureBoxIcon.Width;
                    secondaryLabel.Width = base.Width - pictureBoxIcon.Width;
                }
                else
                {
                    mainLabel.Left = 0;
                    secondaryLabel.Left = 0;
                    mainLabel.Width = base.Width;
                    secondaryLabel.Width = base.Width;
                }
            }
            if (base.Height != oldHeight)
            {
                oldHeight = base.Height;
                pictureBoxIcon.Size = new Size(base.Height, base.Height);
                if (TextSecondary == "")
                {
                    if (Icon != null)
                    {
                        mainLabel.Location = new Point(pictureBoxIcon.Right, 0);
                        mainLabel.Size = new Size(base.Width - pictureBoxIcon.Width, base.Height);
                    }
                    else
                    {
                        mainLabel.Location = new Point(0, 0);
                        mainLabel.Size = new Size(base.Width, base.Height);
                    }
                }
                else if (Icon != null)
                {
                    mainLabel.Location = new Point(pictureBoxIcon.Right, 0);
                    secondaryLabel.Location = new Point(pictureBoxIcon.Right, base.Height / 2);
                    mainLabel.Size = new Size(base.Width - pictureBoxIcon.Width, base.Height / 2);
                    secondaryLabel.Size = new Size(base.Width - pictureBoxIcon.Width,
                                                   base.Height - mainLabel.Height);
                }
                else
                {
                    mainLabel.Location = new Point(0, 0);
                    secondaryLabel.Location = new Point(0, base.Height / 2);
                    mainLabel.Size = new Size(base.Width, base.Height / 2);
                    secondaryLabel.Size = new Size(base.Width, base.Height - mainLabel.Height);
                }
            }
        }

        private void SetIcon()
        {
            if (Enabled)
            {
                pictureBoxIcon.BackgroundImage = icon;
            }
            else if (icon != null)
            {
                pictureBoxIcon.BackgroundImage = iconNotEnabled ?? icon;
            }
        }
    }
}