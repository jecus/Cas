using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controls.ExtendableList;
using LTR.Core.Types.Dictionaries;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения ATAChapter
    /// </summary>
    [ToolboxItem(false)]
    public partial class DetailATAChapterItem : UserControl ,IExtendableItem
    {
        #region Fields

        private Label labelATAChapter;

        private readonly double percentLocation = 0.04;
        private readonly ATAChapter ATAChapter;
        private const int SHORT_HEIGHT = 40;

        #endregion

        #region Constructors
         /// <summary>
        /// Констурктор для создания ATAChapter
        /// </summary>
        public DetailATAChapterItem(ATAChapter ATAChapter)
        {
            this.ATAChapter = ATAChapter;    
            InitializeATAChapter();
        }

        #endregion

        #region Methods

        #region private void InitializeElements()

    
        #endregion

        #region private void InitializeSizes()

        private void InitializeSizes()
        {
            if (labelATAChapter == null) return;
            labelATAChapter.Location = new Point((int)(Width * percentLocation), 0);
            labelATAChapter.Size = new Size((int)(Width - Width * percentLocation), SHORT_HEIGHT);
        }

        #endregion

        #region private void InitializeATAChapter()

        private void InitializeATAChapter()
        {
            Height = SHORT_HEIGHT;
            Margin = new Padding(0);
            BackColor = Color.Transparent;
            labelATAChapter = new Label();
            labelATAChapter.Font = new Font("Verdana", 17, FontStyle.Bold, GraphicsUnit.Pixel);
            //
            // labelATAChapter
            //
            labelATAChapter.TextAlign = ContentAlignment.MiddleLeft;
            if (ATAChapter != null) labelATAChapter.Text = ATAChapter.FullName; else labelATAChapter.Text = "NULL";
            InitializeSizes();
            Controls.Add(labelATAChapter);
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InitializeSizes();
        }

        #endregion

        #region public void SetShortView()

        ///<summary>
        /// Задает упрощенное состояние отображения
        ///</summary>
        public void SetShortView()
        {
        }

        #endregion

        #region public void SetExtendedView()

        ///<summary>
        /// Задает расширенное состояние отображения
        ///</summary>
        public void SetExtendedView()
        {
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Контрол был переведен в расширенное состояние
        /// </summary>
        public event EventHandler Extended;

        #endregion

    
    }
}
