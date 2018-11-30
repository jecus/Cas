#region

using System.Drawing;
using System.Windows.Forms;
using AvControls.AvalonButtonM;
using AvControls.ImageLink;
using AvControls.StatusImageLink;

#endregion

namespace Auxiliary
{
    /// <summary>
    /// «десь 
    /// </summary>
    public class Css
    {
        #region public static class CommonAppearance

        /// <summary>
        ///(.)(.)
        /// </summary>
        public static class CommonAppearance
        {
            #region Nested type: Colors

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Colors
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color BackColor = Color.FromArgb(241, 241, 241);
            }

            #endregion
        }

        #endregion

        #region public static class ImageLink

        /// <summary>
        ///(.)(.)
        /// </summary>
        public static class ImageLink
        {
            #region public static class Colors

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Colors
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color LinkColor = Auxiliary.Colors.MainLinkColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ActiveLinkColor = Auxiliary.Colors.MainLinkColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color HoveredLinkColor = Auxiliary.Colors.MainLinkColor;
            }

            #endregion

            #region public static class Fonts

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Fonts
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font Font = Auxiliary.Fonts.CommonRegularFont;
            }

            #endregion

            #region Methods

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static void Adjust(ImageLinkLabel label)
            {
                label.LinkColor = Colors.LinkColor;
                label.ActiveLinkColor = Colors.ActiveLinkColor;
                label.HoveredLinkColor = Colors.HoveredLinkColor;
                label.Font = Fonts.Font;
            }

            #endregion
        }

        #endregion

        #region public static class SimpleLink

        /// <summary>
        ///(.)(.)
        /// </summary>
        public static class SimpleLink
        {
            #region public static class Colors

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Colors
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color LinkColor = Auxiliary.Colors.MainLinkColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ActiveLinkColor = Auxiliary.Colors.MainLinkColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color VisitedLinkColor = Auxiliary.Colors.MainLinkColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ForeColor = Color.Transparent;
            }

            #endregion

            #region public static class Fonts

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Fonts
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font Font = Auxiliary.Fonts.CommonRegularFont;
            }

            #endregion

            #region Methods

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static void Adjust(LinkLabel label)
            {
                label.LinkColor = Colors.LinkColor;
                label.ActiveLinkColor = Colors.ActiveLinkColor;
                label.VisitedLinkColor = Colors.VisitedLinkColor;
                label.LinkBehavior = LinkBehavior.AlwaysUnderline;
                label.ForeColor = Color.Transparent;
                label.Font = Fonts.Font;
            }

            #endregion
        }

        #endregion

        #region public static class OrdinaryText

        /// <summary>
        ///(.)(.)
        /// </summary>
        public static class OrdinaryText
        {
            #region public static class Colors

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Colors
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ForeColor = Auxiliary.Colors.MainColor;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color DarkForeColor = Color.FromArgb(100, 100, 100);
            }

            #endregion

            #region public static class Fonts

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Fonts
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font RegularFont = Auxiliary.Fonts.CommonRegularFont;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font SmallRegularFont = Auxiliary.Fonts.CommonSmallRegularFont;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font BoldFont = new Font(Auxiliary.Fonts.CommonRegularFont, FontStyle.Bold);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font ItalicFont = new Font(Auxiliary.Fonts.CommonRegularFont, FontStyle.Italic);
            }

            #endregion

            #region Methods

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static void Adjust(Control control)
            {
                control.ForeColor = Colors.ForeColor;
                control.Font = Fonts.RegularFont;
            }

            #endregion
        }

        #endregion

        #region public static class SmallHeader

        /// <summary>
        ///(.)(.)
        /// </summary>
        public static class SmallHeader
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color ForeColor = Auxiliary.Colors.MainColor;

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color DarkForeColor = Color.LightGray;
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font RegularFont = Auxiliary.Fonts.CommonBoldFont;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font BoldFont = new Font(Auxiliary.Fonts.CommonBoldFont, FontStyle.Bold);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font ItalicFont = new Font(Auxiliary.Fonts.CommonBoldFont, FontStyle.Italic);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font MiddleHeaderFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point,
                                                               204);
            }

            #endregion

            #region Methods

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static void Adjust(Control control)
            {
                control.ForeColor = Colors.ForeColor;
                control.Font = Fonts.RegularFont;
            }

            #endregion
        }

        #endregion

        #region public static class HeaderText

        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class HeaderText
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color ForeColor = Auxiliary.Colors.MainColor;
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font Font = new Font("Verdana", 23.5F, GraphicsUnit.Pixel);

                /// <summary>
                /// (.)(.)
                /// </summary>
                public static Font FontMedium = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            #endregion

            #region Methods

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static void Adjust(Control control)
            {
                control.ForeColor = Colors.ForeColor;
                control.Font = Fonts.Font;
            }

            #endregion
        }

        #endregion

        #region public static class HeaderLinkLabel

        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class HeaderLinkLabel
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color LinkColor = Color.DimGray;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ActiveLinkColor = Color.Black;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color HoveredLinkColor = Color.Black;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color ForeColor = Color.Transparent;
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }

            #endregion

            #region Methods

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static void Adjust(StatusImageLinkLabel linkLabel)
            {
                linkLabel.LinkColor = Colors.LinkColor;
                linkLabel.ActiveLinkColor = Colors.ActiveLinkColor;
                linkLabel.HoveredLinkColor = Colors.HoveredLinkColor;
                linkLabel.ForeColor = Colors.ForeColor;
                linkLabel.TextFont = Fonts.Font;
            }

            #endregion
        }

        #endregion

        #region public static class BaseDetailInfoControl

        /// <summary>
        /// ќформление BaseDetailInfoControl
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class BaseDetailInfoControl
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                #region InactiveButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColor = Color.FromArgb(114, 189, 44);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColor = Color.FromArgb(166, 220, 135);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColor = Color.FromArgb(24, 129, 203);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColor = Color.FromArgb(144, 195, 230);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Color NotsatisfactoryTopColor = Color.FromArgb(231, 71, 14);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColor = Color.FromArgb(243, 132, 93);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColor = Color.FromArgb(240, 185, 15);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColor = Color.FromArgb(245, 208, 93);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColor = Color.FromArgb(221, 221, 221);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColor = Color.FromArgb(235, 235, 235);

                #endregion

                #region HoveredButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColorHovered = Color.FromArgb(157, 216, 122);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColorHovered = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColorHovered = Color.FromArgb(91, 166, 218);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColorHovered = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryTopColorHovered = Color.FromArgb(240, 99, 51);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColorHovered = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColorHovered = Color.FromArgb(242, 195, 50);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColorHovered = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColorHovered = Color.FromArgb(241, 241, 241);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColorHovered = Color.FromArgb(235, 235, 235);

                #endregion

                #region PressedButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColorPressed = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColorPressed = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColorPressed = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColorPressed = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryTopColorPressed = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColorPressed = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColorPressed = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColorPressed = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColorPressed = Color.FromArgb(245, 245, 245);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColorPressed = Color.FromArgb(245, 245, 245);

                #endregion

                #region ForeColors

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PrimaryForeColor = Color.FromArgb(122, 122, 122);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SecondaryForeColor = Color.FromArgb(122, 122, 122);

                #endregion
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font PrimaryFont = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font SecondaryFont = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
            }

            #endregion
        }

        #endregion

        #region public static class AvalonButtonMStyle

        /// <summary>
        /// ќформление AvalonButtonMStyle
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class AvalonButtonMStyle
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                #region InactiveButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColor = Color.FromArgb(114, 189, 44);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColor = Color.FromArgb(166, 220, 135);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColor = Color.FromArgb(24, 129, 203);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColor = Color.FromArgb(144, 195, 230);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryTopColor = Color.FromArgb(231, 71, 14);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColor = Color.FromArgb(243, 132, 93);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColor = Color.FromArgb(240, 185, 15);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColor = Color.FromArgb(245, 208, 93);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColor = Color.FromArgb(221, 221, 221);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColor = Color.FromArgb(235, 235, 235);

                #endregion

                #region HoveredButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColorHovered = Color.FromArgb(157, 216, 122);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColorHovered = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColorHovered = Color.FromArgb(91, 166, 218);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColorHovered = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryTopColorHovered = Color.FromArgb(240, 99, 51);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColorHovered = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColorHovered = Color.FromArgb(242, 195, 50);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColorHovered = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColorHovered = Color.FromArgb(241, 241, 241);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColorHovered = Color.FromArgb(235, 235, 235);

                #endregion

                #region PressedButtonState

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryTopColorPressed = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SatisfactoryBottomColorPressed = Color.FromArgb(193, 231, 171);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingTopColorPressed = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingBottomColorPressed = Color.FromArgb(180, 214, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryTopColorPressed = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotsatisfactoryBottomColorPressed = Color.FromArgb(245, 150, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyTopColorPressed = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyBottomColorPressed = Color.FromArgb(246, 215, 117);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveTopColorPressed = Color.FromArgb(245, 245, 245);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color InactiveBottomColorPressed = Color.FromArgb(245, 245, 245);

                #endregion

                #region ForeColors

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PrimaryForeColor = Color.FromArgb(122, 122, 122);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SecondaryForeColor = Color.FromArgb(132, 132, 132);

                #endregion
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font PrimaryFont = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font SecondaryFont = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
            }

            #endregion

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static void Adjust(AvalonButtonM button)
            {
                button.Font = Fonts.PrimaryFont;
                button.SecondFont = Fonts.SecondaryFont;

                button.ForeColor = Colors.PrimaryForeColor;
                button.SecondForeColor = Colors.SecondaryForeColor;

                button.NormalColor = Colors.InactiveTopColor;
                button.ExtendedColor = Colors.InactiveBottomColor;
                button.ActiveColor = Colors.InactiveTopColorHovered;

                button.MouseDownColor = Colors.InactiveTopColorPressed;
            }
        }

        #endregion

        #region public static class HeaderControl

        /// <summary>
        /// ќформление BaseDetailInfoControl
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class HeaderControl
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PrimaryColor = Auxiliary.Colors.HeaderLinkColor;

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color SecondaryColor = Auxiliary.Colors.MainColor;
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font PrimaryFont = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font PrimaryFontUnderlined = new Font("Verdana", 14F, FontStyle.Bold | FontStyle.Underline,
                                                                    GraphicsUnit.Pixel);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font SecondaryFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            }

            #endregion
        }

        #endregion

        #region public static class DetailParametersControl

        /// <summary>
        /// ќформление DetailParametersControl
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class DetailParametersControl
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PrimaryColor = Auxiliary.Colors.HeaderLinkColor;

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color LinkColor = Auxiliary.Colors.MainLinkColor;
            }

            #endregion

            #region public static class Fonts

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Fonts
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font PrimaryFont = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Font FontUnderlined = new Font("Verdana", 14F, FontStyle.Underline, GraphicsUnit.Pixel);
            }

            #endregion
        }

        #endregion

        #region public static class ListView

        /// <summary>
        /// ќформление ListView
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class ListView
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotifyColor = Color.FromArgb(255, 255, 180);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color NotSatisfactoryColor = Color.FromArgb(255, 170, 170);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color PendingColor = Color.FromArgb(200, 200, 255);
            }

            #endregion

            #region public static class Fonts

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Fonts
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font SmallRegularFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font RegularFont = new Font("Verdana", 13F, FontStyle.Regular, GraphicsUnit.Pixel);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font BoldFont = new Font("Verdana", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            #endregion

            #region Methods

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static void Adjust(Control control)
            {
                control.ForeColor = Auxiliary.Colors.MainColor;
                control.Font = Fonts.RegularFont;
            }

            #endregion
        }

        #endregion

        #region public static class ListView

        /// <summary>
        /// ќформление ListView
        /// </summary>
        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class WindowsForm
        {
            #region public static class Colors

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static class Colors
            {
                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color TabBackColor = SystemColors.ControlLight; // Color.FromArgb(244, 243, 238);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color ForeColor = Color.FromArgb(0, 0, 0);

                ///<summary>
                ///(.)(.)
                ///</summary>
                public static Color LinkLabelColor = Color.FromArgb(0, 0, 255);
            }

            #endregion

            #region public static class Fonts

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Fonts
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public static Font RegularFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }

            #endregion

            #region public static class Constants

            /// <summary>
            ///(.)(.)
            /// </summary>
            public static class Constants
            {
                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TOP_MARGIN = 7;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int LEFT_MARGIN = 6;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int RIGHT_MARGIN = 6;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int BOTTOM_MARGIN = 7;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TAB_TOP_MARGIN = 13;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TAB_LEFT_MARGIN = 7;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TAB_SEPARATOR_LEFT_MARGIN = 11;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TAB_RIGHT_MARGIN = 18;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int TAB_SEPARATOR_RIGHT_MARGIN = 19;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int BIG_TEXT_BOX_HEIGHT = 59;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int HEIGHT_INTERVAL = 6;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int SEPARATOR_INTERVAL = 11;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int BUTTON_WIDTH = 74;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int BUTTON_HEIGHT = 23;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public const int BUTTON_INTERVAL = 6;

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static readonly Size DefaultFormSize = new Size(361, 477);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static readonly Size DefaultLabelSize = new Size(88, 20);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static readonly Size DefaultPictureBoxSize = new Size(40, 34);

                /// <summary>
                ///(.)(.)
                /// </summary>
                public static readonly int TEXT_BOX_WITH_PICTURE_BOX_HEIGHT = 23;
            }

            #endregion
        }

        #endregion
    }

    #region public static class Auxiliary

    ///<summary>
    ///(.)(.)
    ///</summary>
    public static class Auxiliary
    {
        #region Nested type: Colors

        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class Colors
        {
            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Color MainColor = Color.FromArgb(122, 122, 122);

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Color MainLinkColor = Color.FromArgb(62, 155, 246);

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Color HeaderLinkColor = Color.FromArgb(49, 82, 128);
        }

        #endregion

        #region Nested type: Fonts

        ///<summary>
        ///(.)(.)
        ///</summary>
        public static class Fonts
        {
            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Font CommonRegularFont = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel);

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Font CommonSmallRegularFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            ///<summary>
            ///(.)(.)
            ///</summary>
            public static Font CommonBoldFont = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        #endregion
    }

    #endregion
}