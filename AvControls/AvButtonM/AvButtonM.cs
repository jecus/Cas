#region

using System.ComponentModel;
using System.Drawing;

#endregion

namespace AvControls.AvButtonM
{
    public class AvButtonM : AvButton.AvButton
    {
        private IContainer components;
        private Font _secondFont = new Font("Verdana", 9.75f, FontStyle.Bold);
        private Color _secondForeColor = Color.Black;
        private string _secondText = "";
        private ContentAlignment _secondTextAlign = ContentAlignment.TopLeft;

        public AvButtonM()
        {
            InitializeComponent();
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

        [Category("Appearance"), Description("Выравнивание второго текста")]
        public ContentAlignment SecondTextAlign
        {
            get { return _secondTextAlign; }
            set
            {
                _secondTextAlign = value;
                Invalidate();
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

        protected override void DrawText(Graphics gfx)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            if (Icon == null)
            {
                rectangle = new Rectangle(Padding.Left, Padding.Top,
                                          (Width - Padding.Left) - Padding.Right,
                                          (Height/2) - Padding.Top);
                rectangle2 = new Rectangle(Padding.Left, Height/2,
                                           (Width - Padding.Left) - Padding.Right,
                                           (Height/2) - Padding.Bottom);
            }
            else
            {
                rectangle = new Rectangle(Height + Padding.Left, Padding.Top,
                                          ((Width - Height) - Padding.Left) - Padding.Right,
                                          (Height/2) - Padding.Top);
                rectangle2 = new Rectangle(Height + Padding.Left, Height/2,
                                           ((Width - Height) - Padding.Left) - Padding.Right,
                                           (Height/2) - Padding.Bottom);
            }
            gfx.DrawString(Text, Font, new SolidBrush(ForeColor), rectangle, SetTextAligment(TextAlign));
            gfx.DrawString(SecondText, SecondFont, new SolidBrush(SecondForeColor), rectangle2,
                           SetTextAligment(SecondTextAlign));
        }

        private void InitializeComponent()
        {
            components = new Container();
        }
    }
}