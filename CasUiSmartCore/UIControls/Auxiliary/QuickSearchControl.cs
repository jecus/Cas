using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// ЭУ для быстрого поиска в списках
    ///</summary>
    public partial class QuickSearchControl : UserControl
    {
        #region Fields

        private readonly Color _searchSuccessColor = Color.FromArgb(56, 136, 233);
        private readonly Color _searchFailedColor = Color.FromArgb(233, 56, 56);
        private bool _successBackgroundColor;

        #endregion

        #region Constructors
        ///<summary>
        /// Конструктор по умолчанию без параметров
        ///</summary>
        public QuickSearchControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region public override string Text
        ///<summary>
        ///Gets or sets the text associated with this control.
        ///</summary>
        ///
        ///<returns>
        ///The text associated with this control.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public override string Text
        {
            get
            {
                return labelQuickSearch.Text;
            }
            set
            {
                labelQuickSearch.Text = value;
            }
        }

        #endregion

        #region public bool SuccessBackgroundColor
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее был ли поиск удачен или нет
        /// </summary>
        public bool SuccessBackgroundColor
        {
            get
            {
                return _successBackgroundColor;
            }
            set
            {
                _successBackgroundColor = value;
                if (_successBackgroundColor)
                {
                    labelQuickSearch.BackColor = _searchSuccessColor;
                    pictureBoxQuickSearch.BackColor = _searchSuccessColor;
                }
                else
                {
                    labelQuickSearch.BackColor = _searchFailedColor;
                    pictureBoxQuickSearch.BackColor = _searchFailedColor;
                }
            }
        }

        #endregion

        #endregion
    }
}
