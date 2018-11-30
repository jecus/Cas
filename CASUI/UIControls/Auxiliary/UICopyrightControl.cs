using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LTR.Settings;

namespace LTR.UI.UIControls
{
    /// <summary>
    /// Элемент управления, необходимый для отображения информации о защите 
    /// авторских прав компании
    /// </summary>
    //[ToolboxItem(false)]
    internal partial class UICopyrightControl : Control
    {
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о защите 
        /// авторских прав компании
        /// </summary>
        public UICopyrightControl()
        {
            InitializeComponent();

            labelCopyright = new Label();
            //
            // Copyright
            //
            labelCopyright.Width = Width;
            labelCopyright.Height = COPYRIGHT_HEIGHT;
            labelCopyright.Location = new Point(0, Bottom - COPYRIGHT_HEIGHT);
            labelCopyright.Padding = new Padding(COPYRIGHT_PADDING, 0, 0, 0);
            labelCopyright.Font = labelsFont;
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.BackColor = Color.FromArgb(208, 223, 254); //todo
            labelCopyright.Text = ProgramSettings.Copyright;

            Controls.Add(labelCopyright);
        }

        #endregion

        #region Fields

        private const int COPYRIGHT_HEIGHT = 20;
        private const int COPYRIGHT_PADDING = 10;
        private readonly Label labelCopyright;
        private readonly Font labelsFont = new Font("Tahoma", 10.25f, FontStyle.Regular);
        
        #endregion

        #region Methods

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Height != COPYRIGHT_HEIGHT) Height = COPYRIGHT_HEIGHT;
        }

        #endregion

        #endregion
    }
}