#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace AvControls.AvalonButtonM
{
    public class AvalonButtonM : AvalonButton.AvalonButton
    {
        private IContainer components;
        private Font _secondFont = new Font("Verdana", 9.75f, FontStyle.Bold);
        private Color _secondForeColor = Color.Black;
        private string _secondText = "";
        private ContentAlignment _secondTextAlign = ContentAlignment.TopLeft;
        private Padding _secondTextPadding = new Padding(0);
        private int _secondaryTextPosition;
        private bool _truncatingNeeded;

        public AvalonButtonM()
        {
            InitializeComponent();
            SecondaryTextPosition = 50;
        }

        [Category("Layout"), Description("Граница по вертикали, с которой будет начинаться второй текст")]
        public int SecondaryTextPosition
        {
            get { return _secondaryTextPosition; }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    _secondaryTextPosition = value;
                    Invalidate();
                }
            }
        }

        [Description("Второй шрифт"), Category("Appearance")]
        public Font SecondFont
        {
            get { return _secondFont; }
            set
            {
                _secondFont = value;
                Invalidate();
            }
        }

        [Description("Цвет второго текста"), Category("Appearance")]
        public Color SecondForeColor
        {
            get { return _secondForeColor; }
            set
            {
                _secondForeColor = value;
                Invalidate();
            }
        }

        [Description("Второй текст текста"), Category("Appearance")]
        public string SecondText
        {
            get { return _secondText; }
            set
            {
                _secondText = value;
                Invalidate();
            }
        }

        [Description("Выравнивание второго текста"), Category("Appearance")]
        public ContentAlignment SecondTextAlign
        {
            get { return _secondTextAlign; }
            set
            {
                _secondTextAlign = value;
                Invalidate();
            }
        }

        [Description("Отступы текста в данном элементе управления"), Category("Layout")]
        public Padding SecondTextPadding
        {
            get { return _secondTextPadding; }
            set
            {
                _secondTextPadding = value;
                Invalidate();
            }
        }

        public bool TruncatingNeeded
        {
            get { return _truncatingNeeded; }
            set { _truncatingNeeded = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void DrawText(Graphics gfx)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            int num = (Height*_secondaryTextPosition)/100;
            if (Icon == null)
            {
                rectangle = new Rectangle(15 + TextPadding.Left, 15 + TextPadding.Top,
                                          ((Width - 30) - TextPadding.Left) - TextPadding.Right,
                                          ((num - 15) - TextPadding.Top) - TextPadding.Bottom);
                rectangle2 = new Rectangle(15 + _secondTextPadding.Left, num + _secondTextPadding.Top,
                                           ((Width - 30) - _secondTextPadding.Left) - _secondTextPadding.Right,
                                           (((Height - num) - 15) - _secondTextPadding.Top) -
                                           _secondTextPadding.Bottom);
            }
            else
            {
                rectangle = new Rectangle((InnerSize.Height + 15) + TextPadding.Left,
                                          15 + TextPadding.Top,
                                          (((Width - InnerSize.Height) - 30) - TextPadding.Left) -
                                          TextPadding.Right,
                                          ((num - 15) - TextPadding.Top) - TextPadding.Bottom);
                rectangle2 = new Rectangle((InnerSize.Height + 15) + _secondTextPadding.Left,
                                           num + _secondTextPadding.Top,
                                           (((Width - InnerSize.Height) - 30) - _secondTextPadding.Left) -
                                           _secondTextPadding.Right,
                                           (((Height - num) - 15) - _secondTextPadding.Top) -
                                           _secondTextPadding.Bottom);
            }
            string s = _truncatingNeeded ? TruncateString(Text, rectangle.Width, Font) : Text;
            gfx.DrawString(s, Font, new SolidBrush(ForeColor), rectangle, SetTextAligment(TextAlign));
            gfx.DrawString(SecondText, SecondFont, new SolidBrush(SecondForeColor), rectangle2,
                           SetTextAligment(SecondTextAlign));
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            TextAlign = ContentAlignment.BottomLeft;
            ResumeLayout(false);
        }

        protected string TruncateString(string value, int freeWidth, Font font)
        {
            using (Graphics graphics = CreateGraphics())
            {
                if (graphics.MeasureString(value, font, 0x500).Width <= freeWidth)
                {
                    return value;
                }
                for (int i = value.Length; i > 0; i--)
                {
                    string text = value.Substring(0, i) + "…";
                    if (graphics.MeasureString(text, font, 0x500).Width <= freeWidth)
                    {
                        return text;
                    }
                }
            }
            return "";
        }
    }
}