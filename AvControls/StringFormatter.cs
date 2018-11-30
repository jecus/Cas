#region

using System.Drawing;

#endregion

namespace AvControls
{
    public class StringFormatter
    {
        public static string TruncateString(string value, int freeWidth, Font font)
        {
            Image image = new Bitmap(0x500, 40);
            using (Graphics graphics = Graphics.FromImage(image))
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