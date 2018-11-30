using System.Drawing;
using System.Windows.Forms;
using Controls.AvButtonT;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления, предназначеный для отображения отдельной информации об агрегате
    /// </summary>
    public partial class InfoViewerWide : FlowLayoutPanel
    {
        #region Fields

        private static readonly Size defaultSize = new Size(515, 200);
        private readonly Font fontUnderline = new Font("Verdana", 15F, FontStyle.Underline, GraphicsUnit.Pixel);
        private readonly Color defaultForeColor = Color.FromArgb(122, 122, 122);
        private int leftHeaderWidth = 155;

        private readonly AvButtonT buttonTitle = new AvButtonT();
        private readonly LifelengthViewer lifelengthViewer1 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer2 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer3 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer4 = new LifelengthViewer();
        private readonly LifelengthViewer lifelengthViewer5 = new LifelengthViewer();
        private DetailInformationMode mode = DetailInformationMode.View;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения отдельной информации об агрегате
        /// </summary>
        public InfoViewerWide()
        {
            Size = defaultSize;
            FlowDirection = FlowDirection.TopDown;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //
            // buttonTitle
            //
            buttonTitle.Cursor = Cursors.Default;
            buttonTitle.Font = fontUnderline;
            buttonTitle.ForeColor = defaultForeColor;
            buttonTitle.IconLayout = ImageLayout.Center;
            buttonTitle.Location = new Point(0, 0);
            buttonTitle.Padding = new Padding(3);
            buttonTitle.Size = new Size(defaultSize.Width, defaultSize.Height / 5);
            buttonTitle.TextAlignMain = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewer1
            //
            LifelengthViewer1.Location = new Point(0, buttonTitle.Bottom);
            //LifelengthViewer1.ShowHeaders = false;
            //LifelengthViewer1.Size = new Size(Width, Height / 6);
            LifelengthViewer1.ReadOnly = true;
            LifelengthViewer1.BackColor = Color.Transparent;
            LifelengthViewer2.ShowHeaders = true;
            LifelengthViewer1.LeftHeader = "1";
            LifelengthViewer1.LeftHeaderWidth = leftHeaderWidth;
            //
            // lifelengthViewer2
            //
            LifelengthViewer2.Location = new Point(0, lifelengthViewer1.Bottom);
            //LifelengthViewer2.ShowHeaders = false;
            //LifelengthViewer2.Size = new Size(Width, Height / 6);
            LifelengthViewer2.ReadOnly = true;
            LifelengthViewer2.BackColor = Color.Transparent;
            LifelengthViewer2.ShowHeaders = false;
            LifelengthViewer2.LeftHeader = "2";
            LifelengthViewer2.LeftHeaderWidth = leftHeaderWidth;
            //
            // lifelengthViewer3
            //
            LifelengthViewer3.Location = new Point(0, LifelengthViewer2.Bottom);
           // LifelengthViewer3.ShowHeaders = false;
            //LifelengthViewer3.Size = new Size(Width, Height / 6);
            LifelengthViewer3.ReadOnly = true;
            LifelengthViewer3.LeftHeader = "3";
            LifelengthViewer3.LeftHeaderWidth = leftHeaderWidth;
            LifelengthViewer3.BackColor = Color.Transparent;
            LifelengthViewer3.ShowHeaders = false;
            //
            // LifelengthViewer4
            //
            LifelengthViewer4.Location = new Point(0, LifelengthViewer3.Bottom);
           // LifelengthViewer4.ShowHeaders = false;
            //LifelengthViewer4.Size = new Size(Width, Height / 6);
            LifelengthViewer4.ReadOnly = true;
            LifelengthViewer4.LeftHeader = "4";
            LifelengthViewer4.LeftHeaderWidth = leftHeaderWidth;
            LifelengthViewer4.BackColor = Color.Transparent;
            LifelengthViewer4.ShowHeaders = false;
            //
            // LifelengthViewer5
            //
            LifelengthViewer5.Location = new Point(0, LifelengthViewer4.Bottom);
            // LifelengthViewer5.ShowHeaders = false;
            //LifelengthViewer5.Size = new Size(Width, Height / 6);
            LifelengthViewer5.ReadOnly = true;
            LifelengthViewer5.LeftHeader = "4";
            LifelengthViewer5.LeftHeaderWidth = leftHeaderWidth;
            LifelengthViewer5.BackColor = Color.Transparent;
            LifelengthViewer5.ShowHeaders = false;

            LifelengthViewer5Enabled = true;

            Controls.Add(buttonTitle);
            Controls.Add(LifelengthViewer1);
            Controls.Add(LifelengthViewer2);
            Controls.Add(LifelengthViewer3);
            Controls.Add(LifelengthViewer4);
            Controls.Add(LifelengthViewer5);
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Ширина левого заголовка
        /// </summary>
        public int LeftHeaderWidth
        {
            get { return leftHeaderWidth; }
            set
            {
                leftHeaderWidth = value;
                LifelengthViewer5.LeftHeaderWidth = leftHeaderWidth;
                LifelengthViewer4.LeftHeaderWidth = leftHeaderWidth;
                LifelengthViewer3.LeftHeaderWidth = leftHeaderWidth;
                LifelengthViewer2.LeftHeaderWidth = leftHeaderWidth;
                LifelengthViewer1.LeftHeaderWidth = leftHeaderWidth;

            }
        }

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

        /// <summary>
        /// Возвращает первый сверху LifelengthViewer
        /// </summary>
        public LifelengthViewer LifelengthViewer1
        {
            get
            {
                return lifelengthViewer1;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer2

        /// <summary>
        /// Возвращает второй сверху LifelengthViewer
        /// </summary>
        public LifelengthViewer LifelengthViewer2
        {
            get
            {
                return lifelengthViewer2;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer3

        /// <summary>
        /// Возвращает третий сверху LifelengthViewer
        /// </summary>
        public LifelengthViewer LifelengthViewer3
        {
            get
            {
                return lifelengthViewer3;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer4

        /// <summary>
        /// Возвращает четвертый сверху LifelengthViewer
        /// </summary>
        public LifelengthViewer LifelengthViewer4
        {
            get
            {
                return lifelengthViewer4;
            }
        }

        #endregion

        #region public LifelengthViewer LifelengthViewer5

        /// <summary>
        /// Возвращает пятый сверху LifelengthViewer
        /// </summary>
        public LifelengthViewer LifelengthViewer5
        {
            get
            {
                return lifelengthViewer5;
            }
        }

        #endregion

        #region public bool LifelengthViewer5Enabled

        /// <summary>
        /// Показывать ли 5-й элемент гы гы
        /// </summary>
        public bool LifelengthViewer5Enabled
        {
            get
            {
                return lifelengthViewer5.Enabled;
            }
            set
            {
                lifelengthViewer5.Enabled = value;
                lifelengthViewer5.Visible = value;
            }
        }

        #endregion
        
        #region public Button ButtonTitle

        /// <summary>
        /// Возвращает кнопку, для отображения заголовка
        /// </summary>
        public AvButtonT ButtonTitle
        {
            get
            {
                return buttonTitle;
            }
        }

        #endregion

        #region public DetailInformationMode Mode

        /// <summary>
        /// Возвращает или устанавливает текущее состояние элемента управления
        /// </summary>
        public DetailInformationMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                if (mode == DetailInformationMode.Edit)
                {
                    //LifelengthViewer1.ShowHeaders = true;
                    LifelengthViewer1.ReadOnly = false;
                    LifelengthViewer2.ReadOnly = false;
                    LifelengthViewer3.ReadOnly = false;
                    LifelengthViewer4.ReadOnly = false;
                    LifelengthViewer5.ReadOnly = false;
                }
                else
                {
                    //LifelengthViewer1.ShowHeaders = false;
                    LifelengthViewer1.ReadOnly = true;
                    LifelengthViewer2.ReadOnly = true;
                    LifelengthViewer3.ReadOnly = true;
                    LifelengthViewer4.ReadOnly = true;
                    LifelengthViewer5.ReadOnly = true;
                }
            }
        }

        #endregion

        #endregion

    }

}