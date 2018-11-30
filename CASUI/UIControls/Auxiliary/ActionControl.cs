using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using Controls.AvButtonT;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий кнопки в заголовке для выполнения каких-то действий
    ///</summary>
    public partial class ActionControl : UserControl
    {

        #region Constructor

        ///<summary>
        /// Создается новый объект отображения действия
        ///</summary>
        public ActionControl()
        {
            InitializeComponent();
            splitViewer1.SplitterImage = icons.SeparatorLine;
            avButtonReload = new AvButtonT();
            richReferenceButtonEdit = new RichReferenceButton();
            //
            // avButtonReload
            //
            avButtonReload.ActiveBackgroundImage = icons.HeaderBarClicked;
            avButtonReload.Dock = DockStyle.Left;
            avButtonReload.Icon = icons.Reload;
            avButtonReload.IconNotEnabled = icons.ReloadGray;
            avButtonReload.IconLayout = ImageLayout.Center;
            avButtonReload.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            avButtonReload.FontSecondary = Css.HeaderControl.Fonts.SecondaryFont;
            avButtonReload.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            avButtonReload.ForeColorSecondary = Css.HeaderControl.Colors.SecondaryColor;
            avButtonReload.Margin = new Padding(0);
            avButtonReload.TextMain = "Reload";
            avButtonReload.TextSecondary = "data";
            avButtonReload.TextAlignMain = ContentAlignment.BottomCenter;
            avButtonReload.TextAlignSecondary = ContentAlignment.TopCenter;
            avButtonReload.Width = STANDART_BUTTONS_WIDTH;
            avButtonReload.Height = 58;
            //
            // richReferenceButtonEdit
            //
            richReferenceButtonEdit.ActiveBackgroundImage = icons.HeaderBarClicked;
            richReferenceButtonEdit.Dock = DockStyle.Left;
            richReferenceButtonEdit.Icon = icons.Edit;
            richReferenceButtonEdit.IconNotEnabled = icons.EditGray;
            richReferenceButtonEdit.IconLayout = ImageLayout.Center;
            richReferenceButtonEdit.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            richReferenceButtonEdit.FontSecondary = Css.HeaderControl.Fonts.SecondaryFont;
            richReferenceButtonEdit.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            richReferenceButtonEdit.ForeColorSecondary = Css.HeaderControl.Colors.SecondaryColor;
            richReferenceButtonEdit.Margin = new Padding(0);
            richReferenceButtonEdit.TextMain = "Edit";
            richReferenceButtonEdit.TextSecondary = "data";
            richReferenceButtonEdit.TextAlignMain = ContentAlignment.BottomCenter;
            richReferenceButtonEdit.TextAlignSecondary = ContentAlignment.TopCenter;
            richReferenceButtonEdit.Width = STANDART_BUTTONS_WIDTH;
            richReferenceButtonEdit.Height = 58;

            splitViewer1[0] = avButtonReload;
            splitViewer1[1] = richReferenceButtonEdit;

            avButtonReload.Click += avButtonReload_Click;
            richReferenceButtonEdit.DisplayerRequested += avButtonEdit_DisplayerRequested;
        }

        #endregion

        #region Fields

        private const int STANDART_BUTTONS_WIDTH = 150;
        private readonly AvButtonT avButtonReload;
        private readonly RichReferenceButton richReferenceButtonEdit;
        private readonly Icons icons = new Icons();
        private bool showEditButton = true;

        #endregion

        #region Properties

        #region public ReflectionTypes CloseReflectionType

        ///<summary>
        /// Тип отображения окна
        ///</summary>
        public ReflectionTypes EditReflectionType
        {
            get
            {
                return richReferenceButtonEdit.ReflectionType;
            }
            set
            {
                richReferenceButtonEdit.ReflectionType = value;
            }
        }
        #endregion


        #region public IDisplayer EditDisplayer

        ///<summary>
        /// Окно назначения
        ///</summary>
        public IDisplayer EditDisplayer
        {
            get
            {
                return richReferenceButtonEdit.Displayer;
            }
            set
            {
                richReferenceButtonEdit.Displayer = value;
            }
        }
        #endregion

        #region public string CloseDisplayerText

        ///<summary>
        /// Заголовок открытого окна
        ///</summary>
        public string EditDisplayerText
        {
            get
            {
                return richReferenceButtonEdit.DisplayerText;
            }
            set
            {
                richReferenceButtonEdit.DisplayerText = value;
            }
        }
        #endregion

        #region public IDisplayingEntity EditEntity

        ///<summary>
        /// Отображаемая сущность
        ///</summary>
        public IDisplayingEntity EditEntity
        {
            get
            {
                return richReferenceButtonEdit.Entity;
            }
            set
            {
                richReferenceButtonEdit.Entity = value;
            }
        }
        #endregion

        #region public RichReferenceButton ButtonEdit

        /// <summary>
        /// Возвращает кнопку Edit/Save
        /// </summary>
        public RichReferenceButton ButtonEdit
        {
            get
            {
                return richReferenceButtonEdit;
            }
        }

        #endregion

       

        #region public AvButtonT ButtonReload

        /// <summary>
        /// Кнопка перезагрузки
        /// </summary>
        public AvButtonT ButtonReload
        {
            get
            {
                return avButtonReload;
            }
        }

        #endregion

        #region public bool ShowEditButton

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Edit
        /// </summary>
        public bool ShowEditButton
        {
            get
            {
                return showEditButton;
            }
            set
            {
                showEditButton = value;
                UpdateControl();
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void avButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void avButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnEditDisplayerRequested(e);
        }

        #endregion

        #region private void OnEditDisplayerRequested(ReferenceEventArgs e)

        private void OnEditDisplayerRequested(ReferenceEventArgs e)
        {
            if (EditDisplayerRequested != null)
                EditDisplayerRequested(this, e);
        }

        #endregion

        #region private void avButtonReload_Click(object sender, EventArgs e)

        private void avButtonReload_Click(object sender, EventArgs e)
        {
            OnReloadRised(e);
        }

        #endregion

        #region private void OnReloadRised(EventArgs e)

        private void OnReloadRised(EventArgs e)
        {
            if (ReloadRised != null)
                ReloadRised(this, e);
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет элемент управления
        /// </summary>
        private void UpdateControl()
        {
            if (showEditButton)
            {
                splitViewer1.ControlsAmount = 2;
                splitViewer1[0] = avButtonReload;
                splitViewer1[1] = richReferenceButtonEdit;
            }
            else
            {
                splitViewer1.ControlsAmount = 1;
                //ButtonReload.Dock = DockStyle.Left;
                splitViewer1[0] = avButtonReload;
            }
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие запроса обновления
        /// </summary>
        public event EventHandler ReloadRised;

        /// <summary>
        /// Событие запроса редактирования
        /// </summary>
        public event EventHandler<ReferenceEventArgs> EditDisplayerRequested;

        #endregion
    }
}
