using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий верхний заголовок
    ///</summary>
    public partial class HeaderControl : UserControl
    {

        #region Fields
        //private int _oldWidth;
        #endregion

        #region Constructor
        ///<summary>
        /// Создается новый объект
        ///</summary>
        public HeaderControl()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            TabIndex = 0;
        }

        

       #endregion

        #region Properties

        #region public IDisplayer CloseButtonDisplayer
        ///<summary>
        /// Вкладка назначения
        ///</summary>
        [Category("Appearance"), Description("Вкладка назначения кнопки Close")]
        [DefaultValue(null)]
        public IDisplayer CloseButtonDisplayer
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

        #region public string CloseButtonDisplayerText

        ///<summary>
        /// Заголовок открытого окна
        ///</summary>
        [Category("Appearance"), Description("Заголовок вкладки открываемой кнопкой Close")]
        [DefaultValue("")]
        public string CloseButtonDisplayerText
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

        #region public bool CloseButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка Close
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Close")]
        [DefaultValue(true)]
        public bool CloseButtonEnabled
        {
            get { return buttonCloseTab.Enabled; }
            set { buttonCloseTab.Enabled = value; }
        }

        #endregion

        #region public IDisplayingEntity CloseButtonEntity

        ///<summary>
        /// Отображаемая сущность
        ///</summary>
        [Category("Appearance"), Description("Содержимое вкладки назначения кнопки Close")]
        [DefaultValue(null)]
        public IDisplayingEntity CloseButtonEntity
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

        #region public ReflectionTypes CloseButtonReflectionType
        ///<summary>
        /// Тип отображения окна
        ///</summary>
        [Category("Appearance"), Description("Тип отображения окна кнопкой Close")]
        [DefaultValue(ReflectionTypes.CloseSelected)]
        public ReflectionTypes CloseButtonReflectionType
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

        #region public bool CloseButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки CloseTab
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки CloseTab")]
        [DefaultValue(true)]
        public bool CloseButtonShowToolTip
        {
            get { return buttonCloseTab.ShowToolTip; }
            set { buttonCloseTab.ShowToolTip = value; }
        }
        #endregion

        #region public bool CloseButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки CloseTab
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки CloseTab")]
        [DefaultValue("Close Tab")]
        public string CloseButtonToolTipText
        {
            get { return buttonCloseTab.ToolTipText; }
            set { buttonCloseTab.ToolTipText = value; }
        }
        #endregion

        #region public string EditButtonDisplayerText
        /// <summary>
        /// Заголовок открытого окна редактирования
        /// </summary>
        [Category("Appearance"), Description("Заголовок вкладки открываемой кнопкой Edit")]
        [DefaultValue("")]
        public string EditButtonDisplayerText
        {
            get { return richReferenceButtonEdit.DisplayerText; }
            set { richReferenceButtonEdit.DisplayerText = value; }
        }

        #endregion

        #region public bool EditButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка Edit
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Edit")]
        [DefaultValue(true)]
        public bool EditButtonEnabled
        {
            get { return richReferenceButtonEdit.Enabled; }
            set { richReferenceButtonEdit.Enabled = value; }
        }

        #endregion

        #region public ReflectionTypes EditReflectionType
        /// <summary>
        /// Тип отображения окна редактирования
        /// </summary>
        [Category("Appearance"), Description("Тип отображения окна редактирования Edit")]
        [DefaultValue(null)]
        public ReflectionTypes EditReflectionType
        {
            get { return richReferenceButtonEdit.ReflectionType;}
            set { richReferenceButtonEdit.ReflectionType = value; }
        }

        #endregion

        #region public bool EditButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки Edit
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки Edit")]
        [DefaultValue(false)]
        public bool EditButtonShowToolTip
        {
            get { return richReferenceButtonEdit.ShowToolTip; }
            set { richReferenceButtonEdit.ShowToolTip = value; }
        }
        #endregion

        #region public bool EditButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки Edit
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки Edit")]
        [DefaultValue("")]
        public string EditButtonToolTipText
        {
            get { return richReferenceButtonEdit.ToolTipText; }
            set { richReferenceButtonEdit.ToolTipText = value; }
        }
        #endregion

        #region public bool HelpButtonTopicId
        /// <summary>
        /// Возвращает или устанавливает значение Идентификатора справочного материала
        /// </summary>
        [Category("Appearance"), Description("Идентификатор справочного материала для кнокпи Help")]
        [DefaultValue("")]
        public string HelpButtonTopicId
        {
            get { return buttonHelp.TopicId; }
            set { buttonHelp.TopicId = value; }
        }
        #endregion

        #region public bool PrintButtonContextMenuStrip
        /// <summary>
        /// Возвращает или устанавливает контекстное меню для кнопки Print
        /// </summary>
        public ContextMenuStrip PrintButtonContextMenuStrip
        {
            get { return buttonPrint.ContextMenuStrip; }
            set { buttonPrint.ContextMenuStrip = value; }
        }

        #endregion

        #region public bool PrintButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка Print
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Print")]
        [DefaultValue(true)]
        public bool PrintButtonEnabled
        {
            get { return buttonPrint.Enabled; }
            set { buttonPrint.Enabled = value; }
        }

        #endregion

        #region public bool PrintButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки Print
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки Print")]
        [DefaultValue(true)]
        public bool PrintButtonShowToolTip
        {
            get { return buttonPrint.ShowToolTip; }
            set { buttonPrint.ShowToolTip = value; }
        }
        #endregion

        #region public bool PrintButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки Print
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки Print")]
        [DefaultValue("Print Preview")]
        public string PrintButtonToolTipText
        {
            get { return buttonPrint.ToolTipText; }
            set { buttonPrint.ToolTipText = value; }
        }
        #endregion

        #region public bool ReloadButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка Reload
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Reload")]
        [DefaultValue(true)]
        public bool ReloadButtonEnabled
        {
            get { return avButtonReload.Enabled; }
            set { avButtonReload.Enabled = value; }
        }

        #endregion

        #region public bool ReloadButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки Reload
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки Reload")]
        [DefaultValue(true)]
        public bool ReloadButtonShowToolTip
        {
            get { return avButtonReload.ShowToolTip; }
            set { avButtonReload.ShowToolTip = value; }
        }
        #endregion

        #region public bool ReloadButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки Reload
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки Reload")]
        [DefaultValue("Reload")]
        public string ReloadButtonToolTipText
        {
            get { return avButtonReload.ToolTipText; }
            set { avButtonReload.ToolTipText = value; }
        }
        #endregion

        #region public ReflectionTypes SaveReflectionType
        /// <summary>
        /// Тип отображения окна сохранения
        /// </summary>
        [Category("Appearance"), Description("Тип отображения окна кнопкой Save")]
        [DefaultValue(ReflectionTypes.DisplayInNew)]
        public ReflectionTypes SaveReflectionType
        {
            get { return richReferenceButtonSave.ReflectionType; }
            set { richReferenceButtonSave.ReflectionType = value; }
        }

        #endregion

        #region public bool SaveButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка SaveAndEdit
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка SaveAndEdit")]
        [DefaultValue(true)]
        public bool SaveButtonEnabled
        {
            get { return richReferenceButtonSave.Enabled; }
            set { richReferenceButtonSave.Enabled = value; }
        }

        #endregion

        #region public bool SaveButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки Save
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки Save")]
        [DefaultValue(false)]
        public bool SaveButtonShowToolTip
        {
            get { return richReferenceButtonSave.ShowToolTip; }
            set { richReferenceButtonSave.ShowToolTip = value; }
        }
        #endregion

        #region public bool SaveButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки Save
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки Save")]
        [DefaultValue("")]
        public string SaveButtonToolTipText
        {
            get { return richReferenceButtonSave.ToolTipText; }
            set { richReferenceButtonSave.ToolTipText = value; }
        }
        #endregion

        #region public ReflectionTypes Save2ReflectionType
        /// <summary>
        /// Тип отображения окна сохранения2
        /// </summary>
        [Category("Appearance"), Description("Тип отображения окна кнопкой Save2")]
        [DefaultValue(ReflectionTypes.DisplayInNew)]
        public ReflectionTypes Save2ReflectionType
        {
            get { return richReferenceButtonSave2.ReflectionType; }
            set { richReferenceButtonSave2.ReflectionType = value; }
        }

        #endregion

        #region public bool SaveAndAddButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка SaveAndAdd
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка SaveAndAdd")]
        [DefaultValue(true)]
        public bool SaveAndAddButtonEnabled
        {
            get { return richReferenceButtonSave2.Enabled; }
            set { richReferenceButtonSave2.Enabled = value; }
        }

        #endregion

        #region public bool Save2ButtonShowToolTip
        /// <summary>
        /// Возвращает или устанавливает значение, показывать подсказки для кнопки Save2
        /// </summary>
        [Category("Appearance"), Description("Показывать текст всплывающей подсказки для кнопки Save2")]
        [DefaultValue(false)]
        public bool Save2ButtonShowToolTip
        {
            get { return richReferenceButtonSave2.ShowToolTip; }
            set { richReferenceButtonSave2.ShowToolTip = value; }
        }
        #endregion

        #region public bool Save2ButtonToolTipText
        /// <summary>
        /// Возвращает или устанавливает значение текста подсказки для кнопки Save2
        /// </summary>
        [Category("Appearance"), Description("Текст всплывающей подсказки для кнопки Save2")]
        [DefaultValue("")]
        public string Save2ButtonToolTipText
        {
            get { return richReferenceButtonSave2.ToolTipText; }
            set { richReferenceButtonSave2.ToolTipText = value; }
        }
        #endregion

        #region public bool ShowCloseButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Close
        /// </summary>
        [Description("Нужно ли показывать кнопку Close"), Category("Layout")]
        [DefaultValue(true)]
        public bool ShowCloseButton
        {
            get
            {
                return buttonCloseTab.Visible;
            }
            set
            {
                buttonCloseTab.Visible = value;
            }
        }

        #endregion

        #region public bool ShowEditButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Edit
        /// </summary>
        [Description("Нужно ли показывать кнопку Edit"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowEditButton
        {
            get
            {
                return richReferenceButtonEdit.Visible;
            }
            set
            {
                richReferenceButtonEdit.Visible = value;
               // pictureBox2.Visible = value;
                //pictureBoxH.Visible = true;
            }
        }

        #endregion

        #region public bool ShowForecastButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Forecast
        /// </summary>
        [Description("Нужно ли показывать кнопку Forecast"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowForecastButton
        {
            get
            {
                return forecastControl.Visible;
            }
            set
            {
                forecastControl.Visible = value;
                pictureBoxF.Visible = value;
            }
        }
        #endregion

        #region public bool ShowNoForecastMenuItem
        ///<summary>
        /// Показать/Скрыть пункт меню "Без прогноза"
        ///</summary>
        [Description("Показать/Скрыть пункт меню Без прогноза"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowNoForecastMenuItem
        {
            get { return forecastControl.ShowNoForecastMenuItem; }
            set { forecastControl.ShowNoForecastMenuItem = value; }
        }
        #endregion

        #region public bool ShowHelpButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Help
        /// </summary>
        [Description("Нужно ли показывать кнопку Help"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowHelpButton
        {
            get
            {
                return buttonHelp.Visible;
            }
            set
            {
                buttonHelp.Visible = value;
            }
        }

        #endregion

        #region public bool ShowPrintButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Print
        /// </summary>
        [Description("Нужно ли показывать кнопку Print"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowPrintButton
        {
            get
            {
                return buttonPrint.Visible;
            }
            set
            {
                buttonPrint.Visible = value;
                pictureBoxP.Visible = value;
            }
        }

        #endregion

        #region public bool ShowReloadButton
        ///<summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Reload
        ///</summary>
        [Description("Нужно ли показывать кнопку Reload"), Category("Layout")]
        [DefaultValue(true)]
        public bool ShowReloadButton
        {
            get
            {
                return avButtonReload.Visible;
            }
            set
            {
                avButtonReload.Visible = value;
                pictureBox2.Visible = value;
            }
        }
        #endregion

        #region public bool ShowSaveButton
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Save
        /// </summary>
        [Description("Нужно ли показывать кнопку Save"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowSaveButton
        {
            get
            {
                return richReferenceButtonSave.Visible;
            }
            set
            {
                pictureBoxS.Visible = value;
                richReferenceButtonSave.Visible = value;
            }
        }

        #endregion

        #region public bool ShowSaveButton2
        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать кнопку Save2
        /// </summary>
        [Description("Нужно ли показывать кнопку Save2"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowSaveButton2
        {
            get
            {
                return richReferenceButtonSave2.Visible;
            }
            set
            {
                pictureBoxS2.Visible = value;
                richReferenceButtonSave2.Visible = value;
            }
        }

        #endregion

        #region IDisplayer currentDisplayer;
        /// <summary>
        /// Указывает на текущий отображатель (вкладку)
        /// </summary>
        private IDisplayer _currentDisplayer;
        ///<summary>
        /// Указывает на текущий отображатель (вкладку)
        ///</summary>
        public IDisplayer CurrentDisplayer
        {
            get { return _currentDisplayer; }
            set
            {
                if (_currentDisplayer != null)
                    _currentDisplayer.CountScreenChanget -= CurrentDisplayerScreenChanget;

                _currentDisplayer = value;

                if (_currentDisplayer != null)
                {
                    _currentDisplayer.CountScreenChanget += CurrentDisplayerScreenChanget;
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        #region private void CurrentDisplayerScreenChanget(object sender, EventArgs e)
        /// <summary>
        /// Реагирует на изменение кол-ва вкладок у родителя связной с данным заголовком вкладки (мультивкладочного контрола)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDisplayerScreenChanget(object sender, EventArgs e)
        {
            buttonCloseTab.Enabled = _currentDisplayer.CanEnableCloseTab();
        }
        #endregion
       
        #region protected override void OnSizeChanged(EventArgs e)

        ///// <summary>
        ///// Метод, необходимый для корректного отображения данного элемента управления
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnSizeChanged(EventArgs e)
        //{     
        //    base.OnSizeChanged(e);
        //    if (Width != _oldWidth)
        //    {
        //        _oldWidth = Width;
        //        contextActionControl.Left = Width - contextActionControl.Width;
        //    }
        //}

        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий события добавления нового элемента управления
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.Top = 0;
            e.Control.Height = Height;
            if (e.Control is AbstractOperatorHeaderControl)
                e.Control.TabIndex = 0;
            base.OnControlAdded(e);
        }

        #endregion

        #endregion

        #region Events

        #region ButtonEditClick
        ///<summary>
        /// Нажатие кнопки редактирования
        ///</summary>
        [Category("Buttons")]
        public event EventHandler EditButtonClick;

        void ButtonEditClick(object sender, EventArgs e)
        {
            EventHandler handler = EditButtonClick;
            if (handler != null) handler(this, new EventArgs());
        }
        #endregion

        #region ForecastContextMenuClick
        ///<summary>
        /// Нажатие пункта контекстного меню в прогнозе
        ///</summary>
        [Category("Buttons")]
        public event EventHandler ForecastContextMenuClick;
        void ButtonForecatMenuClick(object sender, EventArgs e)
        {
            EventHandler handler = ForecastContextMenuClick;
            if (handler != null) handler(sender, new EventArgs());
        }

        #endregion

        #region ButtonReloadClick
        ///<summary>
        /// Нажатие кнопки обновления
        ///</summary>
        [Category("Buttons")]
        public event EventHandler ReloadButtonClick;
        void ButtonReloadClick(object sender, EventArgs e)
        {
            EventHandler handler = ReloadButtonClick;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #region ButtonSaveClick
        ///<summary>
        /// Нажатие кнопки сохранения
        ///</summary>
        [Category("Buttons")]
        public event EventHandler SaveButtonClick;
        void ButtonSaveClick(object sender, EventArgs e)
        {
            EventHandler handler = SaveButtonClick;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #region SaveButtonDisplayerRequested
        ///<summary>
        /// Нажатие кнопки сохранения с запросом на новую вкладку
        ///</summary>
        [Category("Buttons")]
        public event EventHandler<ReferenceEventArgs> SaveButtonDisplayerRequested;

        void ButtonSaveDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (SaveButtonDisplayerRequested != null)
            {
                SaveButtonDisplayerRequested(sender, e);
            }
        }
        #endregion

        #region ButtonSaveClick2
        ///<summary>
        /// Нажатие кнопки сохранения 2
        ///</summary>
        [Category("Buttons")]
        public event EventHandler SaveButton2Click;
        void ButtonSave2Click(object sender, EventArgs e)
        {
            EventHandler handler = SaveButton2Click;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #region ButtonPrintDisplayerRequested
        ///<summary>
        /// Нажатие кнопки отображения отчета
        ///</summary>
        [Category("Buttons")]
        public event EventHandler<ReferenceEventArgs> PrintButtonDisplayerRequested;

        void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (PrintButtonDisplayerRequested != null)
            {
                PrintButtonDisplayerRequested(sender, e);
            }
        }
        #endregion

        #endregion
    }
}
