using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс для отображения меню помощи и закрытия вкладки в заголовке 
    /// </summary>
    public partial class ContextActionControl : UserControl
    {

        #region Fields

        private bool showPrintButton = false;
        private readonly Icons icons = new Icons();

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает новый объект для отображения меню помощи и закрытия вкладки в заголовке
        /// </summary>
        public ContextActionControl()
        {
            InitializeComponent();
            splitViewer1.SplitterImage = icons.SeparatorLine;
            splitViewer1[0] = buttonHelp;
            splitViewer1[1] = buttonCloseTab;
            CloseReflectionType = ReflectionTypes.CloseSelected;
            buttonCloseTab.DisplayerRequested += referenceButtonClosetab_DisplayerRequested;
        }

        #endregion

        #region Properties

        #region public ReflectionTypes CloseReflectionType

        ///<summary>
        /// Тип отображения окна
        ///</summary>
        public ReflectionTypes CloseReflectionType
        {
            get
            {
                return buttonCloseTab.ReflectionType;
            }
            set
            {
                buttonCloseTab.ReflectionType = value;
            }
        }
        #endregion

        #region public IDisplayer CloseDisplayer

        ///<summary>
        /// Окно назначения
        ///</summary>
        public IDisplayer CloseDisplayer
        {
            get
            {
                return buttonCloseTab.Displayer;
            }
            set
            {
                buttonCloseTab.Displayer = value;
            }
        }
        #endregion

        #region public string CloseDisplayerText

        ///<summary>
        /// Заголовок открытого окна
        ///</summary>
        public string CloseDisplayerText
        {
            get
            {
                return buttonCloseTab.DisplayerText;
            }
            set
            {
                buttonCloseTab.DisplayerText = value;
            }
        }
        #endregion

        #region public IDisplayingEntity CloseEntity

        ///<summary>
        /// Отображаемая сущность
        ///</summary>
        public IDisplayingEntity CloseEntity
        {
            get
            {
                return buttonCloseTab.Entity;
            }
            set
            {
                buttonCloseTab.Entity = value;
            }
        }
        #endregion

        #region public bool ShowPrintButton

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Print
        /// </summary>
        [Description("Нужно ли показывать кнопку Print")]
        public bool ShowPrintButton
        {
            get
            {
                return showPrintButton;
            }
            set
            {
                showPrintButton = value;
                UpdateControl();
            }
        }

        #endregion

        #region public RichReferenceButton ButtonPrint

        /// <summary>
        /// Возвращает кнопку Print
        /// </summary>
        public RichReferenceButton ButtonPrint
        {
            get
            {
                return buttonPrint;
            }
        }

        #endregion

        #region public RichReferenceButton ButtonClose

        /// <summary>
        /// Возвращает кнопку Close
        /// </summary>
        public RichReferenceButton ButtonClose
        {
            get
            {
                return buttonCloseTab;
            }
        }

        #endregion

        #region public HelpRequestingButtonT ButtonHelp

        /// <summary>
        /// Возвращает кнопку Help
        /// </summary>
        public HelpRequestingButtonT ButtonHelp
        {
            get
            {
                return buttonHelp;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void referenceButtonClosetab_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void referenceButtonClosetab_DisplayerRequested(object sender, ReferenceEventArgs e)
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

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет элемент управления
        /// </summary>
        private void UpdateControl()
        {
            if (showPrintButton)
            {
                splitViewer1.ControlsAmount = 3;
                splitViewer1[0] = buttonPrint;
                splitViewer1[1] = buttonHelp;
                splitViewer1[2] = buttonCloseTab;
            }
            else
            {
                splitViewer1.ControlsAmount = 2;
                splitViewer1[0] = buttonHelp;
                splitViewer1[1] = buttonCloseTab;
            }
        }

        #endregion
        
        #endregion
        
        #region Events

        /// <summary>
        /// Событие запроса редактирования
        /// </summary>
        public event EventHandler<ReferenceEventArgs> EditDisplayerRequested;

        #endregion
        
    }
}
