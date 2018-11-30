using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LTR.Settings;
using LTR.UI.Properties;

namespace LTR.UI.UIControls
{
    /// <summary>
    /// Элемент управления, необходимый для отображения информации о данной программе
    /// в других элементах управления
    /// </summary>
    //[ToolboxItem(false)]
    internal partial class UITitleControl : Control
    {

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о данной программе
        /// </summary>
        public UITitleControl(string pageTitle)
        {
            InitializeComponent();
            BackColor = Color.FromArgb(208, 223, 254); //todo
            Height = TITLE_HEIGHT;
            pictureBoxLogotype = new PictureBox();
            labelProgramName = new Label();
            labelPageTitle = new Label();
            //
            // pictureBoxLogotype
            //
            pictureBoxLogotype.Size = new Size(TITLE_HEIGHT, TITLE_HEIGHT);
            pictureBoxLogotype.Location = Location;
            pictureBoxLogotype.BackColor = Color.Transparent;
            pictureBoxLogotype.BackgroundImage = Resources.AvalonIcon; //todo размеры ??
            pictureBoxLogotype.BackgroundImageLayout = ImageLayout.Zoom;
            //
            // labelProgramName
            //
            labelProgramName.Width = Width - TITLE_HEIGHT;
            labelProgramName.Height = TITLE_HEIGHT / 2;
            labelProgramName.Left = Left + TITLE_HEIGHT;
            labelProgramName.Top = Top;
            labelProgramName.TextAlign = ContentAlignment.MiddleLeft;
            labelProgramName.Padding = new Padding(LOGOTYPE_PADDING, 0, 0, 0);
            labelProgramName.Font = labelsFont;
            labelProgramName.BackColor = Color.Transparent;
            labelProgramName.Text = ProgramSettings.ProgramName;
            //
            // labelPageTitle
            //
            labelPageTitle.Width = labelProgramName.Width;
            labelPageTitle.Height = TITLE_HEIGHT - labelProgramName.Height;
            labelPageTitle.Left = labelProgramName.Left;
            labelPageTitle.Top = Top + labelProgramName.Height;
            labelPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelPageTitle.Padding = new Padding(LOGOTYPE_PADDING, 0, 0, 0);
            labelPageTitle.Font = labelsFont;
            labelPageTitle.BackColor = Color.Transparent;
            labelPageTitle.Text = pageTitle;
            
            Controls.Add(pictureBoxLogotype);
            Controls.Add(labelProgramName);
            Controls.Add(labelPageTitle);

        }


        #endregion

        #region Fields

        private const int TITLE_HEIGHT = 100; 
        private const int LOGOTYPE_PADDING = 20;
        private readonly Label labelProgramName;
        private readonly Label labelPageTitle;
        private readonly Font labelsFont = new Font("Tahoma", 14.25f, FontStyle.Regular);
        private int oldWidth = 0;

        #endregion

        #region Properties

        #region public string TitleText

        /// <summary>
        /// Возвращает текст заголока данного элемента управления
        /// </summary>
        public string TitleText
        {
            get { return labelPageTitle.Text; }
            set { labelPageTitle.Text = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, необходимый для корректного отображения данного элемента управления, при изменении его размеров
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((labelProgramName == null) || (labelPageTitle == null))
                return;

            if (Height != TITLE_HEIGHT)
            {
                Height = TITLE_HEIGHT;
            }

            if (Width < TITLE_HEIGHT)
            {
                Width = TITLE_HEIGHT;
            }

            if (Width != oldWidth)
            {
                labelProgramName.Width = Width - TITLE_HEIGHT;
                labelPageTitle.Width = labelProgramName.Width;
            }

            oldWidth = Width;
        }

        #endregion

        #endregion

    }
}