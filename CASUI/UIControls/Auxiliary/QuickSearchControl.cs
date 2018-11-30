using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для быстрого поиска в списке директив и агрегатов
    /// </summary>
    public class QuickSearchControl : Control
    {

        #region Fields

        private readonly Color searchSuccessColor = Color.FromArgb(56, 136, 233);
        private readonly Color searchFailedColor = Color.FromArgb(233, 56, 56);
        private readonly Icons icons = new Icons();
        private readonly Label labelQuickSearch;
        private readonly PictureBox pictureBoxQuickSearch;
        private bool successBackgroundColor = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает новый элемент управления для быстрого поиска в списке директив и агрегатов
        /// </summary>
        public QuickSearchControl()
        {
            labelQuickSearch = new Label();
            pictureBoxQuickSearch = new PictureBox();
            //
            // labelQuickSearch
            //
            labelQuickSearch.BorderStyle = BorderStyle.None;
            labelQuickSearch.BackColor = searchSuccessColor;
            labelQuickSearch.Font = Css.ListView.Fonts.BoldFont;
            labelQuickSearch.ForeColor = Color.White;
            labelQuickSearch.Size = new Size(150, 25);
            labelQuickSearch.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pictureBoxQuickSearch
            //
            pictureBoxQuickSearch.BackColor = searchSuccessColor;
            pictureBoxQuickSearch.BackgroundImage = icons.Search;
            pictureBoxQuickSearch.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxQuickSearch.Location = new Point(labelQuickSearch.Right, 0);
            pictureBoxQuickSearch.Size = new Size(30, 25);

            Size = new Size(180, 25);
            Controls.Add(labelQuickSearch);
            Controls.Add(pictureBoxQuickSearch);
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
                return successBackgroundColor;
            }
            set
            {
                successBackgroundColor = value;
                if (successBackgroundColor)
                {
                    labelQuickSearch.BackColor = searchSuccessColor;
                    pictureBoxQuickSearch.BackColor = searchSuccessColor;
                }
                else
                {
                    labelQuickSearch.BackColor = searchFailedColor;
                    pictureBoxQuickSearch.BackColor = searchFailedColor;
                }
            }
        }

        #endregion

        #endregion

    }
}
