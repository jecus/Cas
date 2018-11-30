using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls.AvMultitabControl.Design;

namespace AvControls.AvMultitabControl
{
    /// <summary>
    /// Описывает страницу мультивкладочного контрола
    /// </summary>
    [Designer(typeof(MultitabPageDesigner)), ToolboxItem(false)]
    public partial class MultitabPage : Panel
    {
        #region Fields
        /// <summary>
        /// Владелец данной вкладки (Мульти-вкладочный контрол)
        /// </summary>
        private AvMultitabControl _owner;
        /// <summary>
        /// Текст данной вкладки
        /// </summary>
        private string _text;
        /// <summary>
        /// Текст всплывающей подсказки
        /// </summary>
        private string _toolTipText;

        #endregion

        #region Properties

        #region public AvMultitabControl Owner
        /// <summary>
        /// Возвращает или задает владельца данной страницы
        /// </summary>
        public AvMultitabControl Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                InvokeOwnerChanget();
            }
        }
        #endregion

        public Image Icon { get; set; }

        #region public override string Text
        /// <summary>
        /// Возвращает или задает текст данной вкладки
        /// </summary>
        [Browsable(true)]
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (_owner != null)
                {
                    _owner.Invalidate();
                }
            }
        }
        #endregion

        #region public string ToolTipText
        /// <summary>
        /// Возвращает или задает текст всплывающей подсказки
        /// </summary>
        [DefaultValue("")]
        public string ToolTipText
        {
            get { return !string.IsNullOrEmpty(_toolTipText) ? _toolTipText : _text; }
            set { _toolTipText = !string.IsNullOrEmpty(value) ? value : ""; }
        }
        #endregion

        #endregion

        #region Constructors

        public MultitabPage()
        {
            InitializeComponent();
        }

        public MultitabPage(string text) : this()
        {
            _text = text;
        }

        #endregion

        #region Events

        #region public event EventHandler OwnerChanget
        /// <summary>
        /// Событие оповещающее о смене владельца вкладки
        /// </summary>
        public event EventHandler OwnerChanget;
        /// <summary>
        /// Возбуждает событие о смене владельца вкладки
        /// </summary>
        private void InvokeOwnerChanget()
        {
            EventHandler handler = OwnerChanget;
            if (handler != null) handler(this, new EventArgs());
        }
        #endregion

        #endregion
    }
}
