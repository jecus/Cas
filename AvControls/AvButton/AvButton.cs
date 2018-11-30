#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

#endregion

namespace AvControls.AvButton
{
    [Designer(typeof (AvButtonDesigner)), ToolboxBitmap(typeof (AvButton), "AvButton")]
    public class AvButton : Button
    {
        protected static readonly Color StandardActiveBorderColor = Color.FromArgb(50, 50, 50);
        protected static readonly Color StandardActiveColor = Color.FromArgb(250, 200, 40);
        protected static readonly Color StandardBorderColor = Color.FromArgb(0x94, 0x94, 0x94);
        protected static readonly Color StandardExtendedColor = Color.FromArgb(0xff, 0xff, 0xff);
        protected static readonly Color StandardInactiveColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
        protected static readonly Color StandardNormalColor = Color.FromArgb(0xd0, 0xdf, 0xfe);
        private Color activeColor = StandardActiveColor;
        private IContainer components;
        private Color currentBorderColor = StandardBorderColor;
        private Color currentColor = StandardNormalColor;
        private Color extendedColor = StandardExtendedColor;
        private LinearGradientMode gradientMode;
        private bool hoverable = true;
        private Image icon;
        private Color inactiveColor = StandardInactiveColor;
        private bool isHovered;
        private Color normalColor = StandardNormalColor;
        private bool selectButton;

        public AvButton()
        {
            InitializeComponent();
        }

        [Description("Цвет кнопки при её выделении"), Category("Appearance")]
        public Color ActiveColor
        {
            get { return activeColor; }
            set
            {
                activeColor = value;
                RefreshButton();
            }
        }

        private Color CurrentBorderColor
        {
            get { return currentBorderColor; }
            set { currentBorderColor = value; }
        }

        private Color CurrentColor
        {
            get { return currentColor; }
            set { currentColor = value; }
        }

        [Description("Второй цвет градиента"), Category("Appearance")]
        public Color ExtendedColor
        {
            get { return extendedColor; }
            set
            {
                extendedColor = value;
                RefreshButton();
            }
        }

        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                base.Invalidate();
            }
        }

        [Category("Behavior"),
         Description("Выделение кнопки при наведении на неё мышкой \n true - выделять \n false - не выделять")]
        public bool Hoverable
        {
            get { return hoverable; }
            set { hoverable = value; }
        }

        [Description("Иконка"), Category("Appearance")]
        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                base.Invalidate();
            }
        }

        [Description("Цвет кнопки при значении Enabled = false"), Category("Appearance")]
        public Color InactiveColor
        {
            get { return inactiveColor; }
            set
            {
                inactiveColor = value;
                RefreshButton();
            }
        }

        [Description("Первый цвет градиента"), Category("Appearance")]
        public Color NormalColor
        {
            get { return normalColor; }
            set
            {
                normalColor = value;
                CurrentBorderColor = base.FlatAppearance.BorderColor;
                RefreshButton();
            }
        }

        [Description("Необходимо, если вы хотите чтобы кнопка была выделена постоянно"), Category("Appearance")]
        public bool Selected
        {
            get { return selectButton; }
            set
            {
                selectButton = value;
                RefreshButton();
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

        private void DrawForeground(Graphics gfx, Rectangle rect, Color topColor, Color bottomColor)
        {
            Brush brush;
            if (topColor.Equals(bottomColor))
            {
                brush = new SolidBrush(topColor);
            }
            else
            {
                brush = new LinearGradientBrush(rect, topColor, bottomColor, GradientMode);
            }
            gfx.FillRectangle(brush, rect);
            ControlPaint.DrawBorder(gfx, rect, CurrentBorderColor, base.FlatAppearance.BorderSize,
                                    ButtonBorderStyle.Solid, CurrentBorderColor, base.FlatAppearance.BorderSize,
                                    ButtonBorderStyle.Solid, CurrentBorderColor, base.FlatAppearance.BorderSize,
                                    ButtonBorderStyle.Solid, CurrentBorderColor, base.FlatAppearance.BorderSize,
                                    ButtonBorderStyle.Solid);
            brush.Dispose();
        }

        private void DrawImage(Graphics gfx)
        {
            if (Icon != null)
            {
                Rectangle rectangle;
                ImageAttributes imageAttr = new ImageAttributes();
                if ((Icon.Width > base.Size.Width) || (Icon.Height > base.Size.Height))
                {
                    rectangle = new Rectangle(0, 0, base.Size.Height, base.Size.Height);
                    imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                }
                else
                {
                    rectangle = new Rectangle((base.Size.Height - Icon.Width)/2, (base.Size.Height - Icon.Height)/2,
                                              Icon.Height, Icon.Height);
                }
                gfx.DrawImage(Icon, rectangle, 0, 0, Icon.Width, Icon.Height, GraphicsUnit.Pixel, imageAttr);
            }
        }

        protected virtual void DrawText(Graphics gfx)
        {
            Rectangle rectangle;
            if (Icon == null)
            {
                rectangle = new Rectangle(base.Padding.Left, base.Padding.Top,
                                          (base.Width - base.Padding.Left) - base.Padding.Top,
                                          (base.Height - base.Padding.Top) - base.Padding.Bottom);
            }
            else
            {
                rectangle = new Rectangle(base.Height + base.Padding.Left, base.Padding.Top,
                                          ((base.Width - base.Height) - base.Padding.Left) - base.Padding.Right,
                                          (base.Height - base.Padding.Top) - base.Padding.Bottom);
            }
            gfx.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, SetTextAligment(TextAlign));
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            Cursor = Cursors.Hand;
            base.FlatAppearance.BorderColor = Color.FromArgb(0x94, 0x94, 0x94);
            base.FlatAppearance.BorderSize = 2;
            base.FlatStyle = FlatStyle.Flat;
            Font = new Font("Verdana", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            base.Padding = new Padding(2);
            base.Size = new Size(0xc2, 0x36);
            TextAlign = ContentAlignment.MiddleLeft;
            base.TextImageRelation = TextImageRelation.ImageBeforeText;
            base.UseVisualStyleBackColor = true;
            base.ResumeLayout(false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            RefreshButton();
            base.OnEnabledChanged(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            CurrentBorderColor = base.FlatAppearance.BorderColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            CurrentBorderColor = StandardActiveBorderColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            RefreshButton();
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            isHovered = true;
            RefreshButton();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawForeground(e.Graphics, base.ClientRectangle, CurrentColor, ExtendedColor);
            DrawImage(e.Graphics);
            DrawText(e.Graphics);
        }

        private void RefreshButton()
        {
            if (base.Enabled)
            {
                if (Selected || (isHovered && hoverable))
                {
                    CurrentColor = activeColor;
                    CurrentBorderColor = StandardActiveBorderColor;
                }
                else
                {
                    CurrentColor = normalColor;
                    CurrentBorderColor = StandardBorderColor;
                }
            }
            else
            {
                CurrentColor = inactiveColor;
                CurrentBorderColor = StandardBorderColor;
            }
            base.Invalidate();
        }

        protected StringFormat SetTextAligment(ContentAlignment textAlign)
        {
            StringFormat format = new StringFormat();
            if (((textAlign == ContentAlignment.TopLeft) || (textAlign == ContentAlignment.MiddleLeft)) ||
                (textAlign == ContentAlignment.BottomLeft))
            {
                format.Alignment = StringAlignment.Near;
            }
            if (((textAlign == ContentAlignment.TopCenter) || (textAlign == ContentAlignment.MiddleCenter)) ||
                (textAlign == ContentAlignment.BottomCenter))
            {
                format.Alignment = StringAlignment.Center;
            }
            if (((textAlign == ContentAlignment.TopRight) || (textAlign == ContentAlignment.MiddleRight)) ||
                (textAlign == ContentAlignment.BottomRight))
            {
                format.Alignment = StringAlignment.Far;
            }
            if (((textAlign == ContentAlignment.TopLeft) || (textAlign == ContentAlignment.TopCenter)) ||
                (textAlign == ContentAlignment.TopRight))
            {
                format.LineAlignment = StringAlignment.Near;
            }
            if (((textAlign == ContentAlignment.MiddleLeft) || (textAlign == ContentAlignment.MiddleCenter)) ||
                (textAlign == ContentAlignment.MiddleRight))
            {
                format.LineAlignment = StringAlignment.Center;
            }
            if (((textAlign == ContentAlignment.BottomLeft) || (textAlign == ContentAlignment.BottomCenter)) ||
                (textAlign == ContentAlignment.BottomRight))
            {
                format.LineAlignment = StringAlignment.Far;
            }
            return format;
        }
    }
}