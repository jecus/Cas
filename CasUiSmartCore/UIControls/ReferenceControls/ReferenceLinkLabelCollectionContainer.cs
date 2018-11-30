using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Auxiliary;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Описывается контрол 
    ///</summary>
    //[Designer(typeof(ParentControlDesigner), typeof(IDesigner))]
    public partial class ReferenceLinkLabelCollectionContainer : UserControl
    {
        #region Fields

        private ReferenceStatusImageLinkLabel[] _referenceStatusImageLinkLabels = new ReferenceStatusImageLinkLabel[16];

        #endregion

        #region Constructor
        ///<summary>
        /// Создается новый объект данного класса
        ///</summary>
        public ReferenceLinkLabelCollectionContainer()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region public Image UpperLeftIcon
        ///<summary>
        /// Иконка левого верхнего угла
        ///</summary>
        public Image UpperLeftIcon
        {
            get { return extendableRichContainer.UpperLeftIcon; }
            set { extendableRichContainer.UpperLeftIcon = value; }
        }
        #endregion

        #region public Color DescriptionTextColor
        ///<summary>
        /// Цвет текста описания
        ///</summary>
        public Color DescriptionTextColor
        {
            get
            {
                return extendableRichContainer.DescriptionTextColor;
            }
            set
            {
                extendableRichContainer.DescriptionTextColor = value;
            }
        }
        #endregion

        #region public string Caption
        ///<summary>
        /// Заголовок объекта
        ///</summary>
        public string Caption
        {
            get
            {
                return extendableRichContainer.Caption;
            }
            set
            {
                extendableRichContainer.Caption = value;
            }
        }
        #endregion

        #region public bool Extended
        /// <summary>
        /// Развернут ли элемент
        /// </summary>
        public bool Extended
        {
            get
            {
                return extendableRichContainer.Extended;
            }
            set
            {
                extendableRichContainer.Extended = value;
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink
        ///<summary>
        /// Возвращает или задает ссылку 1
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink
        {
            get { return _referenceStatusImageLinkLabels[0]; }
            set
            {
                _referenceStatusImageLinkLabels[0] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink02
        ///<summary>
        /// Возвращает или задает ссылку 2
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink02
        {
            get { return _referenceStatusImageLinkLabels[1]; }
            set
            {
                _referenceStatusImageLinkLabels[1] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink03
        ///<summary>
        /// Возвращает или задает ссылку 3
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink03
        {
            get { return _referenceStatusImageLinkLabels[2]; }
            set
            {
                _referenceStatusImageLinkLabels[2] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink04
        ///<summary>
        /// Возвращает или задает ссылку 4
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink04
        {
            get { return _referenceStatusImageLinkLabels[3]; }
            set
            {
                _referenceStatusImageLinkLabels[3] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink05
        ///<summary>
        /// Возвращает или задает ссылку 5
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink05
        {
            get { return _referenceStatusImageLinkLabels[4]; }
            set
            {
                _referenceStatusImageLinkLabels[4] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink06
        ///<summary>
        /// Возвращает или задает ссылку 6
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink06
        {
            get { return _referenceStatusImageLinkLabels[5]; }
            set
            {
                _referenceStatusImageLinkLabels[5] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink07
        ///<summary>
        /// Возвращает или задает ссылку 7
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink07
        {
            get { return _referenceStatusImageLinkLabels[6]; }
            set
            {
                _referenceStatusImageLinkLabels[6] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink08
        ///<summary>
        /// Возвращает или задает ссылку 8
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink08
        {
            get { return _referenceStatusImageLinkLabels[7]; }
            set
            {
                _referenceStatusImageLinkLabels[7] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink09
        ///<summary>
        /// Возвращает или задает ссылку 9
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink09
        {
            get { return _referenceStatusImageLinkLabels[8]; }
            set
            {
                _referenceStatusImageLinkLabels[8] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink10
        ///<summary>
        /// Возвращает или задает ссылку 10
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink10
        {
            get { return _referenceStatusImageLinkLabels[9]; }
            set
            {
                _referenceStatusImageLinkLabels[9] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink11
        ///<summary>
        /// Возвращает или задает ссылку 11
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink11
        {
            get { return _referenceStatusImageLinkLabels[10]; }
            set
            {
                _referenceStatusImageLinkLabels[10] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink12
        ///<summary>
        /// Возвращает или задает ссылку 12
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink12
        {
            get { return _referenceStatusImageLinkLabels[11]; }
            set
            {
                _referenceStatusImageLinkLabels[11] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink13
        ///<summary>
        /// Возвращает или задает ссылку 13
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink13
        {
            get { return _referenceStatusImageLinkLabels[12]; }
            set
            {
                _referenceStatusImageLinkLabels[12] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink14
        ///<summary>
        /// Возвращает или задает ссылку 14
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink14
        {
            get { return _referenceStatusImageLinkLabels[13]; }
            set
            {
                _referenceStatusImageLinkLabels[13] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink15
        ///<summary>
        /// Возвращает или задает ссылку 15
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink15
        {
            get { return _referenceStatusImageLinkLabels[14]; }
            set
            {
                _referenceStatusImageLinkLabels[14] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #region public ReferenceStatusImageLinkLabel ReferenceLink16
        ///<summary>
        /// Возвращает или задает ссылку 16
        ///</summary>
        public ReferenceStatusImageLinkLabel ReferenceLink16
        {
            get { return _referenceStatusImageLinkLabels[15]; }
            set
            {
                _referenceStatusImageLinkLabels[15] = value;
                if (!flowLayoutPanelContainer.Controls.Contains(value))
                    flowLayoutPanelContainer.Controls.Add(value);
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public void Reset()
        ///<summary>
        /// Очищает главную панель от контролов
        ///</summary>
        public void Reset()
        {
            flowLayoutPanelContainer.Controls.Clear();  
        }
        #endregion

        #region public void AddLink(ReferenceStatusImageLinkLabel linkLabel)
        ///<summary>
        ///</summary>
        ///<param name="linkLabel"></param>
        public void AddLink(ReferenceStatusImageLinkLabel linkLabel)
        {
            Css.ImageLink.Adjust(linkLabel);

            flowLayoutPanelContainer.Controls.Add(linkLabel);
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, System.EventArgs e)
        private void ExtendableRichContainerExtending(object sender, System.EventArgs e)
        {
            flowLayoutPanelContainer.Visible = extendableRichContainer.Extended;
        }
        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)

        protected override void OnControlAdded(ControlEventArgs e)
        {
            Control c = e.Control;
            if (c != flowLayoutPanelContainer
               && c != flowLayoutPanelMain
               && c != extendableRichContainer)
            {
                //if (Controls.Contains(c))
                //    Controls.Remove(c);
                //if (!flowLayoutPanelContainer.Controls.Contains(c))
                //    flowLayoutPanelContainer.Controls.Add(c);
            }

            base.OnControlAdded(e);
        }
        #endregion

        #endregion
    }
}