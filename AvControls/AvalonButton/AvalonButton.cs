#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

#endregion

namespace AvControls.AvalonButton
{
    [Designer(typeof (AvalonButtonDesigner))]
    public class AvalonButton : Button
    {
        private static readonly Color StandardActiveColor = Color.FromArgb(250, 200, 40);
        private static readonly Color StandardExtendedColor = Color.FromArgb(0xff, 0xff, 0xff);
        private static readonly Color StandardInactiveColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
        private static readonly Color StandardMouseDownColor = Color.Orange;
        private static readonly Color StandardNormalColor = Color.FromArgb(0xd0, 0xdf, 0xfe);
        private Color _activeColor = StandardActiveColor;
        private IContainer components;
        private Color _currentColor = StandardNormalColor;
        private Color _extendedColor = StandardExtendedColor;
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        private bool _hoverable = true;
        private Image _icon;
        private Image _iconNotEnabled;
        private Color _inactiveColor = StandardInactiveColor;
        private Size innerSize;
        private bool isHovered;
        private bool mouseDown;
        private Color mouseDownColor = StandardMouseDownColor;
        private Color normalColor = StandardNormalColor;
        private bool selectButton;
        private float shadowLineWidth = 2.5f;
        private Padding textPadding = new Padding(0);

        public AvalonButton()
        {
            InitializeComponent();
            base.EnabledChanged += AvalonButton_EnabledChanged;
        }

        [Category("Appearance"), Description("Цвет кнопки при её выделении")]
        public Color ActiveColor
        {
            get { return _activeColor; }
            set
            {
                _activeColor = value;
                RefreshButton();
            }
        }

        private Color CurrentColor
        {
            get { return _currentColor; }
            set { _currentColor = value; }
        }

        [Category("Appearance"), Description("Второй цвет градиента")]
        public Color ExtendedColor
        {
            get { return _extendedColor; }
            set
            {
                _extendedColor = value;
                RefreshButton();
            }
        }

        [Category("Appearance"), Description("Направление градиента заливки")]
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value;
                Invalidate();
            }
        }

        [Category("Behavior"),
         Description("Выделение кнопки при наведении на неё мышкой \n true - выделять \n false - не выделять")]
        public bool Hoverable
        {
            get { return _hoverable; }
            set { _hoverable = value; }
        }

        [Description("Иконка"), Category("Appearance")]
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Иконка при Enabled = false")]
        public Image IconNotEnabled
        {
            get { return _iconNotEnabled; }
            set
            {
                _iconNotEnabled = value;
                base.Invalidate();
            }
        }

        [Description("Цвет кнопки при значении Enabled = false"), Category("Appearance")]
        public Color InactiveColor
        {
            get { return _inactiveColor; }
            set
            {
                _inactiveColor = value;
                RefreshButton();
            }
        }

        [Description("Размер элемента управления, не учитывая тень"), Category("Layout")]
        public Size InnerSize
        {
            get { return innerSize; }
            set
            {
                innerSize = value;
                base.Size = new Size(value.Width + 30, value.Height + 30);
            }
        }

        [Description("Цвет градиента при нажатии мыши"), Category("Appearance")]
        public Color MouseDownColor
        {
            get { return mouseDownColor; }
            set
            {
                mouseDownColor = value;
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
                RefreshButton();
            }
        }

        [Category("Appearance"), Description("Необходимо, если вы хотите чтобы кнопка была выделена постоянно")]
        public bool Selected
        {
            get { return selectButton; }
            set
            {
                selectButton = value;
                RefreshButton();
            }
        }

        [Category("Layout"), Description("Отступы текста в данном элементе управления")]
        public Padding TextPadding
        {
            get { return textPadding; }
            set
            {
                textPadding = value;
                base.Invalidate();
            }
        }

        private void AvalonButton_EnabledChanged(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBorder(Graphics gfx, Rectangle rect, int radius)
        {
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = GetPath(rect, radius);
            gfx.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), path);
        }

        private void DrawForeground(Graphics gfx, Rectangle rect, int radius, Color topColor, Color bottomColor)
        {
            Brush brush;
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = GetPath(rect, radius);
            if (topColor.Equals(bottomColor))
            {
                brush = new SolidBrush(topColor);
            }
            else
            {
                brush = new LinearGradientBrush(TruncateRectangle(rect, -1), topColor, bottomColor, GradientMode);
            }
            gfx.FillPath(brush, path);
            brush.Dispose();
        }

        private void DrawImage(Graphics gfx)
        {
            Image icon;
            Rectangle rectangle;
            if (base.Enabled && (this._icon != null))
            {
                icon = this._icon;
            }
            else
            {
                if (base.Enabled || (this._icon == null))
                {
                    return;
                }
                if (_iconNotEnabled != null)
                {
                    icon = _iconNotEnabled;
                }
                else
                {
                    icon = this._icon;
                }
            }
            ImageAttributes imageAttr = new ImageAttributes();
            if ((icon.Width > InnerSize.Height) || (icon.Height > InnerSize.Height))
            {
                rectangle = new Rectangle(15, 15, InnerSize.Height, InnerSize.Height);
                imageAttr.SetWrapMode(WrapMode.TileFlipXY);
            }
            else
            {
                rectangle = new Rectangle(15 + ((InnerSize.Height - icon.Width)/2),
                                          15 + ((InnerSize.Height - icon.Height)/2), icon.Height, icon.Height);
            }
            gfx.DrawImage(icon, rectangle, 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, imageAttr);
        }

        private void DrawShadow(Graphics gfx, Rectangle rect, int radius)
        {
            Pen[] penArray = new Pen[3];
            for (int i = 0; i < 3; i++)
            {
                penArray[i] = new Pen(Color.FromArgb(0x17 - i, Color.Gray), shadowLineWidth*i);
            }
            GraphicsPath path = GetPath(rect, radius);
            for (int j = 0; j < 3; j++)
            {
                gfx.DrawPath(penArray[j], path);
            }
        }

        protected virtual void DrawText(Graphics gfx)
        {
            Rectangle rectangle;
            Image icon = null;
            if (base.Enabled && (this._icon != null))
            {
                icon = this._icon;
            }
            else if (!base.Enabled && (this._icon != null))
            {
                if (_iconNotEnabled != null)
                {
                    icon = _iconNotEnabled;
                }
                else
                {
                    icon = this._icon;
                }
            }
            if (icon == null)
            {
                rectangle = new Rectangle(15 + TextPadding.Left, 15 + TextPadding.Top,
                                          ((base.Width - 30) - TextPadding.Left) - TextPadding.Right,
                                          ((base.Height - 30) - TextPadding.Top) - TextPadding.Bottom);
            }
            else
            {
                rectangle = new Rectangle((InnerSize.Height + 15) + TextPadding.Left, 15 + TextPadding.Top,
                                          (((base.Width - InnerSize.Height) - 30) - TextPadding.Left) -
                                          TextPadding.Right, ((base.Height - 30) - TextPadding.Top) - TextPadding.Bottom);
            }
            gfx.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, SetTextAligment(TextAlign));
        }

        private GraphicsPath GetPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new RectangleF(new PointF(rect.Left, rect.Top), new SizeF((2*radius), (2*radius))), 180f, 90f);
            path.AddLine(new PointF((rect.Left + radius), rect.Top),
                         new PointF(((rect.Width + rect.Left) - (2*radius)), rect.Top));
            path.AddArc(
                new RectangleF(new PointF(((rect.Width + rect.Left) - (2*radius)), rect.Top),
                               new SizeF((2*radius), (2*radius))), -90f, 90f);
            path.AddLine(new PointF((rect.Width + rect.Left), (rect.Top + radius)),
                         new PointF((rect.Width + rect.Left), ((rect.Height + rect.Top) - radius)));
            path.AddArc(
                new RectangleF(
                    new PointF(((rect.Width + rect.Left) - (2*radius)), ((rect.Height + rect.Top) - (2*radius))),
                    new SizeF((2*radius), (2*radius))), 0f, 90f);
            path.AddLine(new PointF(((rect.Width + rect.Left) - radius), (rect.Height + rect.Top)),
                         new PointF((rect.Left + radius), (rect.Height + rect.Top)));
            path.AddArc(
                new RectangleF(new PointF(rect.Left, ((rect.Height + rect.Top) - (2*radius))),
                               new SizeF((2*radius), (2*radius))), 90f, 90f);
            path.CloseFigure();
            return path;
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            Cursor = Cursors.Hand;
            base.FlatAppearance.BorderSize = 0;
            base.FlatAppearance.MouseDownBackColor = Color.Transparent;
            base.FlatAppearance.MouseOverBackColor = Color.Transparent;
            base.FlatStyle = FlatStyle.Flat;
            Font = new Font("Verdana", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            MinimumSize = new Size(0x69, 80);
            base.Padding = new Padding(20);
            base.Size = new Size(230, 90);
            TextAlign = ContentAlignment.MiddleLeft;
            base.UseVisualStyleBackColor = false;
            base.ResumeLayout(false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            RefreshButton();
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            mouseDown = true;
            shadowLineWidth = 6.5f;
            RefreshButton();
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

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            mouseDown = false;
            shadowLineWidth = 4.8f;
            RefreshButton();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawShadow(e.Graphics, TruncateRectangle(base.ClientRectangle, 15), 0x12);
            DrawForeground(e.Graphics, TruncateRectangle(base.ClientRectangle, 15), 7, CurrentColor, ExtendedColor);
            DrawBorder(e.Graphics, TruncateRectangle(base.ClientRectangle, 15), 7);
            DrawImage(e.Graphics);
            DrawText(e.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InnerSize = new Size(base.Width - 30, base.Height - 30);
        }

        private void RefreshButton()
        {
            if (base.Enabled)
            {
                if (mouseDown)
                {
                    CurrentColor = MouseDownColor;
                }
                else if (Selected || (isHovered && _hoverable))
                {
                    CurrentColor = _activeColor;
                }
                else
                {
                    CurrentColor = normalColor;
                }
            }
            else
            {
                CurrentColor = _inactiveColor;
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

        private Rectangle TruncateRectangle(Rectangle rectangle, int offset)
        {
            Point location = new Point(rectangle.Left + offset, rectangle.Top + offset);
            return new Rectangle(location, new Size(rectangle.Width - (2*offset), rectangle.Height - (2*offset)));
        }
    }
}