using System;
using System.Drawing;
using System.Windows.Forms;
using Controls.AvButtonT;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления, предназначеный для отображения отдельной информации об агрегате
    /// </summary>
    public partial class DetailInfoViewer : UserControl
    {
        /// <summary>
        /// Создает элемент управления для отображения отдельной информации об агрегате
        /// </summary>
        /// <param name="detail">Текущий агрегат</param>
        /// <param name="readMode">Только для чтения</param>
        public DetailInfoViewer(Detail detail, bool readMode)
        {
            Size = defaultSize;
            BackColor = Color.Transparent;
            //
            // buttonTitle
            //
            buttonTitle.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonTitle.Font = fontUnderline;
            buttonTitle.ForeColor = defaultForeColor;
            buttonTitle.IconLayout = ImageLayout.Center;
            buttonTitle.Location = new Point(0, 0);
            buttonTitle.Padding = new Padding(3);
            buttonTitle.Size = new Size(defaultSize.Width, defaultSize.Height / 5);
            //
            // lifelengthViewerHeader
            //
            lifelengthViewerHeader.Location = new Point(0, buttonTitle.Bottom);
            if (readMode)
                lifelengthViewerHeader.Size = new Size(Width, 0);
            else
            {
                lifelengthViewerHeader.Size = new Size(Width, Height/6);
                lifelengthViewerHeader.Lifelength = new Lifelength(new TimeSpan(12,12,12),12,new TimeSpan(12,12,12)); //todo названия
            }
            //
            // lifelengthViewer1
            //
            lifelengthViewer1.Location = new Point(0, lifelengthViewerHeader.Bottom);
            lifelengthViewer1.Size = new Size(Width, Height / 6);
            lifelengthViewer1.ReadOnly = readMode;
            //
            // lifelengthViewer2
            //
            LifelengthViewer2.Location = new Point(0, lifelengthViewer1.Bottom);
            LifelengthViewer2.Size = new Size(Width, Height / 6);
            LifelengthViewer2.ReadOnly = readMode;
            //
            // lifelengthViewer3
            //
            LifelengthViewer3.Location = new Point(0, LifelengthViewer2.Bottom);
            LifelengthViewer3.Size = new Size(Width, Height / 6);
            LifelengthViewer3.ReadOnly = readMode;
            //
            // LifelengthViewer4
            //
            LifelengthViewer4.Location = new Point(0, LifelengthViewer3.Bottom);
            LifelengthViewer4.Size = new Size(Width, Height / 6);
            LifelengthViewer4.ReadOnly = readMode;

            Controls.Add(buttonTitle);
            Controls.Add(lifelengthViewer1);
            Controls.Add(LifelengthViewer2);
            Controls.Add(LifelengthViewer3);
            Controls.Add(LifelengthViewer4);
        }

        #region Fields

        private static readonly Size defaultSize = new Size(390, 180);
        private readonly Font fontUnderline = new Font("Verdana", 15F, FontStyle.Underline, GraphicsUnit.Pixel);
        private readonly Color defaultForeColor = Color.FromArgb(122, 122, 122);

        private readonly AvButtonT buttonTitle = new AvButtonT();
        private readonly LifelengthViewer lifelengthViewerHeader = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer1 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer2 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer3 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer4 = new LifelengthViewer();

        #endregion

        #region Properties

        #region public Size DefaultSize

        /// <summary>
        /// Возвращает размер по умолчанию данного элемента управления
        /// </summary>
        public static new Size DefaultSize
        {
            get
            {
                return defaultSize;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer1

        public LifelengthViewer LifelengthViewer1
        {
            get
            {
                return lifelengthViewer1;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer2

        public LifelengthViewer LifelengthViewer2
        {
            get
            {
                return lifelengthViewer2;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer3

        public LifelengthViewer LifelengthViewer3
        {
            get
            {
                return lifelengthViewer3;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer4

        public LifelengthViewer LifelengthViewer4
        {
            get
            {
                return lifelengthViewer4;
            }
        }

        #endregion

        #region public Button ButtonTitle

        public AvButtonT ButtonTitle
        {
            get
            {
                return buttonTitle;
            }
        }

        #endregion

        #endregion

    }

}