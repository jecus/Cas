using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartControls.General
{

    #region public enum DelimiterStyle
    /// <summary>
    /// Определяет вид разделителя
    /// </summary>
    public enum DelimiterStyle
    {
        /// <summary>
        /// Разделитель в виде точек
        /// </summary>
        Dotted,

        /// <summary>
        /// Сплошной разделитель в виде линии
        /// </summary>
        Solid,
    }
    #endregion

    #region public enum DelimiterOrientation
    /// <summary>
    /// Направление разделителя
    /// </summary>
    public enum DelimiterOrientation
    {
        /// <summary>
        /// Горизонтальный (слева направо)
        /// </summary>
        Horizontal, 
        /// <summary>
        /// Вертикальный (сверху вниз)
        /// </summary>
        Vertical,
    }
    #endregion


    /// <summary>
    /// Разделитель
    /// </summary>
    public partial class Delimiter : UserControl
    {

        #region public DelimiterStyle Style
        /// <summary>
        /// Вид разделителя
        /// </summary>
        private DelimiterStyle _style;
        /// <summary>
        /// Вид разделителя 
        /// </summary>
        public DelimiterStyle Style
        {
            get { return _style; }
            set { _style = value; ChangeStyle(); }
        }
        #endregion

        #region public DelimiterOrientation Orientation
        /// <summary>
        /// Направление разделителя
        /// </summary>
        private DelimiterOrientation _Orientation;
        /// <summary>
        /// Направление разделителя 
        /// </summary>
        public DelimiterOrientation Orientation
        {
            get { return _Orientation; }
            set { _Orientation = value; ChangeOrientation(); }
        }
        #endregion

        /*
         * Конструктор
         */

        #region Delimiter()
        /// <summary>
        /// Разделитель
        /// </summary>
        public Delimiter()
        {
            InitializeComponent();

            // Определяем повторение фона
            ChangeStyle(); 
            ChangeOrientation();
            BackgroundImageLayout = ImageLayout.Tile;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void ChangeStyle()
        /// <summary>
        /// Меняет фоновый рисунок
        /// </summary>
        private void ChangeStyle()
        {

            // Определяем нужную картинку
            if (_style == DelimiterStyle.Dotted)
                BackgroundImage = Properties.Resources.delimiter_dotted;
            else
            {
                if (_style == DelimiterStyle.Solid)
                    if (_Orientation == DelimiterOrientation.Horizontal)
                        BackgroundImage = Properties.Resources.delimeter_solid_horizontal;
                    else
                        BackgroundImage = Properties.Resources.delimeter_solid_vertical;
            }

            // Подгоняем размер
            ChangeSize();
        }
        #endregion

        #region private void ChangeOrientation()
        /// <summary>
        /// Меняет направление разделителя
        /// </summary>
        private void ChangeOrientation()
        {
            // Направление разделителя может повлиять на изменение рисунка 
            if (_style == DelimiterStyle.Solid)
                if (_Orientation == DelimiterOrientation.Horizontal)
                    BackgroundImage = Properties.Resources.delimeter_solid_horizontal;
                else
                    BackgroundImage = Properties.Resources.delimeter_solid_vertical;

            //
            ChangeSize();
        }
        #endregion

        #region private void ChangeSize()
        /// <summary>
        /// Обновляем размер разделителя
        /// </summary>
        private void ChangeSize()
        {
            // Определяем большую состовляющую размера
            int max;
            if (Size.Width > Size.Height)
                max = Size.Width;
            else
                max = Size.Height;

            // В зависимости от выбранного рисунка разделителя меньшая длина может меняться
            int min;
            if (_style == DelimiterStyle.Dotted)
                min = 1;
            else
                min = 2;

            // Больший размер выставляем в выбраном направлении
            if (_Orientation == DelimiterOrientation.Horizontal)
                Size = new Size(max, min);
            else
                Size = new Size(min, max);
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// Размер контрола поменялся
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            ChangeSize();
        }
        #endregion

    }
}
