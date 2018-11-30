using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение информации об операторе или коллекции шаблонных ВС
    ///</summary>
    public abstract partial class AbstractOperatorHeaderControl : UserControl
    {

        #region Fields

        private readonly RichReferenceButton logotypeButton = new RichReferenceButton();
        private readonly RichReferenceButton titleButton = new RichReferenceButton();
        private readonly RichReferenceButton previousButton = new RichReferenceButton();
        private readonly RichReferenceButton nextButton = new RichReferenceButton();
        private bool operatorClickable = false;
        private readonly Font font = new Font("Verdana", 17F, FontStyle.Regular, GraphicsUnit.Point);
        private readonly Color normalColor = Color.FromArgb(122, 122, 122);
        private readonly Color selectColor = Color.FromArgb(150, 150, 150);
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructor

        #region public AbstractOperatorHeaderControl()

        ///<summary>
        /// Создается новый объект отображения оператора
        ///</summary>
        public AbstractOperatorHeaderControl()
        {
            InitializeComponent();
            splitViewer1.SplitterImage = icons.SeparatorLine;
            //
            // logotypeButton
            //
            logotypeButton.Width = logotypeButton.Height;
            logotypeButton.Dock = DockStyle.Fill;
            logotypeButton.TextMain = "";
            logotypeButton.IconLayout = ImageLayout.Zoom;
            logotypeButton.MouseMove += logotypeButton_MouseMove;
            logotypeButton.MouseLeave += logotypeButton_MouseLeave;
            logotypeButton.ReflectionType = ReflectionTypes.DisplayInNew;
            logotypeButton.DisplayerRequested += logotypeButton_DisplayerRequested;
            //
            // titleButton
            //
            titleButton.ReflectionType = ReflectionTypes.DisplayInNew;
            titleButton.Dock = DockStyle.Left;
            titleButton.FontMain = font;
            titleButton.ForeColorMain = normalColor;
            titleButton.TextAlignMain = ContentAlignment.MiddleCenter;
            titleButton.MouseMove += logotypeButton_MouseMove;
            titleButton.MouseLeave += logotypeButton_MouseLeave;
            titleButton.DisplayerRequested += logotypeButton_DisplayerRequested;
            //
            // previousButton
            //
            previousButton.ReflectionType = ReflectionTypes.DisplayInNew;
            previousButton.Dock = DockStyle.Left;
            previousButton.FontMain = font;
            previousButton.ForeColorMain = normalColor;
            previousButton.TextAlignMain = ContentAlignment.MiddleCenter;
            previousButton.Icon = icons.BlueArrowBack;
            previousButton.IconNotEnabled = icons.BlueArrowBackGrey;
            previousButton.Width = 50;
            previousButton.TextMain = "";
            //previousButton.MouseMove += logotypeButton_MouseMove;
            //previousButton.MouseLeave += logotypeButton_MouseLeave;
            previousButton.DisplayerRequested += previousButton_DisplayerRequested;
            //
            // nextButton
            //
            nextButton.ReflectionType = ReflectionTypes.DisplayInNew;
            nextButton.Dock = DockStyle.Left;
            nextButton.FontMain = font;
            nextButton.ForeColorMain = normalColor;
            nextButton.TextAlignMain = ContentAlignment.MiddleCenter;
            nextButton.Icon = icons.BlueArrow;
            nextButton.IconNotEnabled = icons.GrayArrow;
            nextButton.Width = 50;
            nextButton.TextMain = "";
            //nextButton.MouseMove += logotypeButton_MouseMove;
            //nextButton.MouseLeave += logotypeButton_MouseLeave;
            nextButton.DisplayerRequested += nextButton_DisplayerRequested;
            

            splitViewer1[0] = logotypeButton;
            splitViewer1[1] = titleButton;
            splitViewer1[2] = previousButton;
            splitViewer1[3] = nextButton;
        }

        #endregion
       
        #endregion

        #region Properties

        #region protected RichReferenceButton LogotypeButton

        /// <summary>
        /// Возвращает кнопку, которая отображает иконку оператора
        /// </summary>
        protected RichReferenceButton LogotypeButton
        {
            get
            {
                return logotypeButton;
            }
        }

        #endregion

        #region protected RichReferenceButton TitleButton

        /// <summary>
        /// Возвращает кнопку, которая отображает название оператора
        /// </summary>
        protected RichReferenceButton TitleButton
        {
            get
            {
                return titleButton;
            }
        }

        #endregion

        #region public RichReferenceButton PreviousButton

        /// <summary>
        /// Возвращает кнопку "Назад"
        /// </summary>
        public RichReferenceButton PreviousButton
        {
            get { return previousButton; }
        }

        #endregion

        #region public RichReferenceButton NextButton

        /// <summary>
        /// Возвращает кнопку "Вперед"
        /// </summary>
        public RichReferenceButton NextButton
        {
            get { return nextButton; }
        }

        #endregion

        #region public bool OperatorClickable

        /// <summary>
        /// Возвращет или устанавливает значение, показывающее нужно ли переходить на какую-либо страницу, 
        /// при клике на иконку или текст
        /// </summary>
        public bool OperatorClickable
        {
            get
            {
                return operatorClickable;
            }
            set
            {
                operatorClickable = value;
                UpdateOperatorHeaderControl();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void UpdateOperatorInfo(string operatorName, Image operatorIcon)

        /// <summary>
        /// Обновить информацию по оператору
        /// </summary>
        protected void UpdateOperatorInfo(string operatorName, Image operatorIcon)
        {
            TitleButton.TextMain = operatorName;
            TitleButton.ChangeWidth();
            TitleButton.DisplayerText = operatorName;
            TitleButton.ReflectionType = ReflectionTypes.DisplayInNew;
            LogotypeButton.Icon = operatorIcon;
            LogotypeButton.DisplayerText = operatorName;
            LogotypeButton.ReflectionType = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void UpdateOperatorHeaderControl()

        /// <summary>
        /// Обновляется отображение элментов управления
        /// </summary>
        private void UpdateOperatorHeaderControl()
        {
            if (operatorClickable)
            {
                logotypeButton.Cursor = Cursors.Hand;
                titleButton.Cursor = Cursors.Hand;
                
            }
            else
            {
                logotypeButton.Cursor = Cursors.Default;
                titleButton.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region private void logotypeButton_MouseMove(object sender, MouseEventArgs e)

        private void logotypeButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (operatorClickable)
                titleButton.ForeColor = selectColor;
        }

        #endregion

        #region private void logotypeButton_MouseLeave(object sender, EventArgs e)

        private void logotypeButton_MouseLeave(object sender, EventArgs e)
        {
            if (operatorClickable)
                titleButton.ForeColor = normalColor;
        }

        #endregion

        #region protected abstract void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e);

        protected abstract void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e);

        #endregion

        #region private void previousButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void previousButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayPreviousPage;
        }

        #endregion

        #region private void nextButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void nextButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayNextPage;
        }

        #endregion

        #endregion

    }
}