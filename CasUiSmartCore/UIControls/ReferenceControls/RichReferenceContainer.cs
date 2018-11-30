using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Описывается контрол 
    ///</summary>
    public partial class RichReferenceContainer : UserControl
    {

        #region Constructor

        ///<summary>
        /// Создается новый объект данного класса
        ///</summary>
        public RichReferenceContainer()
        {
            InitializeComponent();
        }

        #endregion

        #region Fields

        private Color _descriptionTextColor = Color.DimGray;

        private ConditionState _condition;

        #endregion

        #region Properties

        #region public Control AfterCaptionControl
        /// <summary>
        /// Элемент управления, отображаемый после заголовка
        /// </summary>
        public Control AfterCaptionControl
        {
            get
            {
                return tableLayoutPanel.GetControlFromPosition(2, 0);
            }
            set
            {
                if (AfterCaptionControl != null)
                    tableLayoutPanel.Controls.Remove(AfterCaptionControl);
                if (value == null) return;
                tableLayoutPanel.Controls.Add(value, 2, 0);
            }
        }
        #endregion

        #region public Control AfterCaptionControl2
        /// <summary>
        /// Элемент управления, отображаемый 2 после заголовка
        /// </summary>
        public Control AfterCaptionControl2
        {
            get
            {
                return tableLayoutPanel.GetControlFromPosition(3, 0);
            }
            set
            {
                if (AfterCaptionControl2 != null)
                    tableLayoutPanel.Controls.Remove(AfterCaptionControl2);
                if (value == null) return;
                tableLayoutPanel.Controls.Add(value, 3, 0);
            }
        }
        #endregion

        #region public Control AfterCaptionControl3
        /// <summary>
        /// Элемент управления, отображаемый 3 после заголовка
        /// </summary>
        public Control AfterCaptionControl3
        {
            get
            {
                return tableLayoutPanel.GetControlFromPosition(4, 0);
            }
            set
            {
                if (AfterCaptionControl3 != null)
                    tableLayoutPanel.Controls.Remove(AfterCaptionControl3);
                if (value == null) return;
                tableLayoutPanel.Controls.Add(value, 4, 0);
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
                return labelCaption.Text;
            }
            set
            {
                labelCaption.Text = value;
            }
        }
        #endregion

        #region public Font CaptionFon
        ///<summary>
        /// Шрифт заголовка
        ///</summary>
        public Font CaptionFont
        {
            get
            {
                return labelCaption.Font;
            }
            set
            {
                labelCaption.Font = value;
            } 
        }
        #endregion

        #region public PictureBox PictureBoxIcon

        /// <summary>
        /// Возвращает PictureBox иконки
        /// </summary>
        public PictureBox PictureBoxIcon
        {
            get
            {
                return pictureBoxIcon;
            }
        }

        #endregion

        #region public Label LabelCaption
        ///<summary>
        /// Label заголовка
        ///</summary>
        public Label LabelCaption
        {
            get { return labelCaption; }
        }
        #endregion

        #region public Image UpperLeftIcon
        ///<summary>
        /// Иконка левого верхнего угла
        ///</summary>
        public Image UpperLeftIcon
        {
            get
            {
                return pictureBoxIcon.Image;
            }
            set
            {
                pictureBoxIcon.Image = value;
                pictureBoxIcon.Size = value != null ? value.Size : new Size(30,30);
            }
        }
        #endregion

        #region public Control MainControl
        ///<summary>
        /// Объект, отображаемый как основной
        ///</summary>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual Control MainControl
        {
            get
            {
                return tableLayoutPanel.GetControlFromPosition(1, 1);
            }
            set
            {
                if (value == null)return;
                tableLayoutPanel.Controls.Add(value, 1, 1);
                tableLayoutPanel.SetColumnSpan(value, 5);
            }
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
                return _descriptionTextColor;
            }
            set
            {
                _descriptionTextColor = value;
            }
        }
        #endregion

        #region  public ConditionState Condition
        ///<summary>
        /// Делает верхнюю иконку стрелкой определенного цвета, в зависимости от переданного состояния
        ///</summary>
        public ConditionState Condition
        {
            get { return _condition; }
            set {SetCondition(value);}
        }
        #endregion

        #endregion

        #region private void SetCondition(ConditionState conditionState)
        private void SetCondition(ConditionState conditionState)
        {
            _condition = conditionState;

            Icons icons = new Icons();

            if (conditionState == null)
                UpperLeftIcon = icons.BlueArrow;
            if (conditionState == ConditionState.NotEstimated)
                UpperLeftIcon = icons.BlueArrow;
            if (conditionState == ConditionState.Satisfactory)
                UpperLeftIcon = icons.GreenArrow;
            if (conditionState == ConditionState.Notify)
                UpperLeftIcon = icons.OrangeArrow;
            if (conditionState == ConditionState.Overdue)
                UpperLeftIcon = icons.RedArrow;   
        }
        #endregion

        #region protected override void OnDockChanged(EventArgs e)
        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.DockChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnDockChanged(EventArgs e)
        {
            tableLayoutPanel.Dock = Dock;
            base.OnDockChanged(e);
        }
        #endregion

    }
}