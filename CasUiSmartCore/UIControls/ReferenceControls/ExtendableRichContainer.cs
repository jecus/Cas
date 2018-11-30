using System;
using System.Windows.Forms;

namespace CAS.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Класс, опсисывающий расширяемый <see cref="RichReferenceContainer"/>
    /// </summary>
    public partial class ExtendableRichContainer : RichReferenceContainer
    {

        #region Fields
        /// <summary>
        /// Определяется, будет ли меняться формат отображения информации
        /// </summary>
        private bool _extendable = true;
        /// <summary>
        /// Развернут ли элемент
        /// </summary>
        private bool _extended = true;

        private Control _mainControl;

        #endregion
        
        #region Constructors
        /// <summary>
        /// Создается экземпляр расширяемого <see cref="RichReferenceContainer"/>
        /// </summary>
        public ExtendableRichContainer()
        {
            InitializeComponent();

            LabelCaption.Cursor = Cursors.Hand;
            PictureBoxIcon.Cursor = Cursors.Hand;
            labelCaption.MouseClick += LabelCaptionMouseClick;
            pictureBoxIcon.MouseClick += LabelCaptionMouseClick;
        }
        #endregion

        #region Properties

        #region public bool Extended
        /// <summary>
        /// Развернут ли элемент
        /// </summary>
        public bool Extended
        {
            get { return _extended; }
            set
            {
                _extended = value;
                if (_extended)
                {
                    if (_mainControl != null)
                    {
                        tableLayoutPanel.Controls.Add(_mainControl, 1, 1);
                        tableLayoutPanel.SetColumnSpan(_mainControl, 4);
                    }
                }
                else
                {
                    tableLayoutPanel.Controls.Remove(_mainControl);
                }
                if (Extending != null)
                    Extending(this, new EventArgs());
            }
        }
        #endregion

        #region public Control MainControl
        ///<summary>
        /// Объект, отображаемый как основной
        ///</summary>
        public override Control MainControl
        {
            get
            {
                return _mainControl;
            }
            set
            {

                if (value == null)
                {
                    tableLayoutPanel.Controls.Remove(_mainControl);
                    _mainControl = value;
                }
                else
                {
                    tableLayoutPanel.Controls.Remove(_mainControl);
                    _mainControl = value;
                    _mainControl.Dock = DockStyle.Top;
                    _mainControl.AutoSize = true;
                    if (_extended)
                    {
                        tableLayoutPanel.Controls.Add(value, 1, 1);
                        tableLayoutPanel.SetColumnSpan(value, 4);
                    }
                }
            }
        }
        #endregion

        #region public bool Extendable
        /// <summary>
        /// Определяется, будет ли меняться формат отображения информации
        /// </summary>
        public bool Extendable
        {
            get { return _extendable; }
            set { _extendable = value; }
        }
        #endregion

        #endregion

        #region Methods
        
        #region void LabelCaptionMouseClick(object sender, MouseEventArgs e)
        void LabelCaptionMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button ==  MouseButtons.Left)
            {
                if (_extendable)
                {
                    Extended = !_extended;
                }
            }
        }
        #endregion

        #endregion

        #region Events

        #region public event EventHandler Extending;

        /// <summary>
        /// Событие разворачивания
        /// </summary>
        public event EventHandler Extending;

        #endregion

        #endregion
    }
}
