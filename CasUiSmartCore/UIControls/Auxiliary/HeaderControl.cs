using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// �����, ����������� ������� ���������
    ///</summary>
    public partial class HeaderControl : UserControl
    {

        #region Fields
        //private int _oldWidth;
        #endregion

        #region Constructor
        ///<summary>
        /// ��������� ����� ������
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
        /// ������� ����������
        ///</summary>
        [Category("Appearance"), Description("������� ���������� ������ Close")]
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
        /// ��������� ��������� ����
        ///</summary>
        [Category("Appearance"), Description("��������� ������� ����������� ������� Close")]
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
        /// ���������� ��� ������������� ��������, �������� �� ������ Close
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ Close")]
        [DefaultValue(true)]
        public bool CloseButtonEnabled
        {
            get { return buttonCloseTab.Enabled; }
            set { buttonCloseTab.Enabled = value; }
        }

        #endregion

        #region public IDisplayingEntity CloseButtonEntity

        ///<summary>
        /// ������������ ��������
        ///</summary>
        [Category("Appearance"), Description("���������� ������� ���������� ������ Close")]
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
        /// ��� ����������� ����
        ///</summary>
        [Category("Appearance"), Description("��� ����������� ���� ������� Close")]
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
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ CloseTab
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ CloseTab")]
        [DefaultValue(true)]
        public bool CloseButtonShowToolTip
        {
            get { return buttonCloseTab.ShowToolTip; }
            set { buttonCloseTab.ShowToolTip = value; }
        }
        #endregion

        #region public bool CloseButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ CloseTab
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ CloseTab")]
        [DefaultValue("Close Tab")]
        public string CloseButtonToolTipText
        {
            get { return buttonCloseTab.ToolTipText; }
            set { buttonCloseTab.ToolTipText = value; }
        }
        #endregion

        #region public string EditButtonDisplayerText
        /// <summary>
        /// ��������� ��������� ���� ��������������
        /// </summary>
        [Category("Appearance"), Description("��������� ������� ����������� ������� Edit")]
        [DefaultValue("")]
        public string EditButtonDisplayerText
        {
            get { return richReferenceButtonEdit.DisplayerText; }
            set { richReferenceButtonEdit.DisplayerText = value; }
        }

        #endregion

        #region public bool EditButtonEnabled
        /// <summary>
        /// ���������� ��� ������������� ��������, �������� �� ������ Edit
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ Edit")]
        [DefaultValue(true)]
        public bool EditButtonEnabled
        {
            get { return richReferenceButtonEdit.Enabled; }
            set { richReferenceButtonEdit.Enabled = value; }
        }

        #endregion

        #region public ReflectionTypes EditReflectionType
        /// <summary>
        /// ��� ����������� ���� ��������������
        /// </summary>
        [Category("Appearance"), Description("��� ����������� ���� �������������� Edit")]
        [DefaultValue(null)]
        public ReflectionTypes EditReflectionType
        {
            get { return richReferenceButtonEdit.ReflectionType;}
            set { richReferenceButtonEdit.ReflectionType = value; }
        }

        #endregion

        #region public bool EditButtonShowToolTip
        /// <summary>
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ Edit
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ Edit")]
        [DefaultValue(false)]
        public bool EditButtonShowToolTip
        {
            get { return richReferenceButtonEdit.ShowToolTip; }
            set { richReferenceButtonEdit.ShowToolTip = value; }
        }
        #endregion

        #region public bool EditButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ Edit
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ Edit")]
        [DefaultValue("")]
        public string EditButtonToolTipText
        {
            get { return richReferenceButtonEdit.ToolTipText; }
            set { richReferenceButtonEdit.ToolTipText = value; }
        }
        #endregion

        #region public bool HelpButtonTopicId
        /// <summary>
        /// ���������� ��� ������������� �������� �������������� ����������� ���������
        /// </summary>
        [Category("Appearance"), Description("������������� ����������� ��������� ��� ������ Help")]
        [DefaultValue("")]
        public string HelpButtonTopicId
        {
            get { return buttonHelp.TopicId; }
            set { buttonHelp.TopicId = value; }
        }
        #endregion

        #region public bool PrintButtonContextMenuStrip
        /// <summary>
        /// ���������� ��� ������������� ����������� ���� ��� ������ Print
        /// </summary>
        public ContextMenuStrip PrintButtonContextMenuStrip
        {
            get { return buttonPrint.ContextMenuStrip; }
            set { buttonPrint.ContextMenuStrip = value; }
        }

        #endregion

        #region public bool PrintButtonEnabled
        /// <summary>
        /// ���������� ��� ������������� ��������, �������� �� ������ Print
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ Print")]
        [DefaultValue(true)]
        public bool PrintButtonEnabled
        {
            get { return buttonPrint.Enabled; }
            set { buttonPrint.Enabled = value; }
        }

        #endregion

        #region public bool PrintButtonShowToolTip
        /// <summary>
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ Print
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ Print")]
        [DefaultValue(true)]
        public bool PrintButtonShowToolTip
        {
            get { return buttonPrint.ShowToolTip; }
            set { buttonPrint.ShowToolTip = value; }
        }
        #endregion

        #region public bool PrintButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ Print
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ Print")]
        [DefaultValue("Print Preview")]
        public string PrintButtonToolTipText
        {
            get { return buttonPrint.ToolTipText; }
            set { buttonPrint.ToolTipText = value; }
        }
        #endregion

        #region public bool ReloadButtonEnabled
        /// <summary>
        /// ���������� ��� ������������� ��������, �������� �� ������ Reload
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ Reload")]
        [DefaultValue(true)]
        public bool ReloadButtonEnabled
        {
            get { return avButtonReload.Enabled; }
            set { avButtonReload.Enabled = value; }
        }

        #endregion

        #region public bool ReloadButtonShowToolTip
        /// <summary>
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ Reload
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ Reload")]
        [DefaultValue(true)]
        public bool ReloadButtonShowToolTip
        {
            get { return avButtonReload.ShowToolTip; }
            set { avButtonReload.ShowToolTip = value; }
        }
        #endregion

        #region public bool ReloadButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ Reload
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ Reload")]
        [DefaultValue("Reload")]
        public string ReloadButtonToolTipText
        {
            get { return avButtonReload.ToolTipText; }
            set { avButtonReload.ToolTipText = value; }
        }
        #endregion

        #region public ReflectionTypes SaveReflectionType
        /// <summary>
        /// ��� ����������� ���� ����������
        /// </summary>
        [Category("Appearance"), Description("��� ����������� ���� ������� Save")]
        [DefaultValue(ReflectionTypes.DisplayInNew)]
        public ReflectionTypes SaveReflectionType
        {
            get { return richReferenceButtonSave.ReflectionType; }
            set { richReferenceButtonSave.ReflectionType = value; }
        }

        #endregion

        #region public bool SaveButtonEnabled
        /// <summary>
        /// ���������� ��� ������������� ��������, �������� �� ������ SaveAndEdit
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ SaveAndEdit")]
        [DefaultValue(true)]
        public bool SaveButtonEnabled
        {
            get { return richReferenceButtonSave.Enabled; }
            set { richReferenceButtonSave.Enabled = value; }
        }

        #endregion

        #region public bool SaveButtonShowToolTip
        /// <summary>
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ Save
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ Save")]
        [DefaultValue(false)]
        public bool SaveButtonShowToolTip
        {
            get { return richReferenceButtonSave.ShowToolTip; }
            set { richReferenceButtonSave.ShowToolTip = value; }
        }
        #endregion

        #region public bool SaveButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ Save
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ Save")]
        [DefaultValue("")]
        public string SaveButtonToolTipText
        {
            get { return richReferenceButtonSave.ToolTipText; }
            set { richReferenceButtonSave.ToolTipText = value; }
        }
        #endregion

        #region public ReflectionTypes Save2ReflectionType
        /// <summary>
        /// ��� ����������� ���� ����������2
        /// </summary>
        [Category("Appearance"), Description("��� ����������� ���� ������� Save2")]
        [DefaultValue(ReflectionTypes.DisplayInNew)]
        public ReflectionTypes Save2ReflectionType
        {
            get { return richReferenceButtonSave2.ReflectionType; }
            set { richReferenceButtonSave2.ReflectionType = value; }
        }

        #endregion

        #region public bool SaveAndAddButtonEnabled
        /// <summary>
        /// ���������� ��� ������������� ��������, �������� �� ������ SaveAndAdd
        /// </summary>
        [Category("Layout"), Description("�������� �� ������ SaveAndAdd")]
        [DefaultValue(true)]
        public bool SaveAndAddButtonEnabled
        {
            get { return richReferenceButtonSave2.Enabled; }
            set { richReferenceButtonSave2.Enabled = value; }
        }

        #endregion

        #region public bool Save2ButtonShowToolTip
        /// <summary>
        /// ���������� ��� ������������� ��������, ���������� ��������� ��� ������ Save2
        /// </summary>
        [Category("Appearance"), Description("���������� ����� ����������� ��������� ��� ������ Save2")]
        [DefaultValue(false)]
        public bool Save2ButtonShowToolTip
        {
            get { return richReferenceButtonSave2.ShowToolTip; }
            set { richReferenceButtonSave2.ShowToolTip = value; }
        }
        #endregion

        #region public bool Save2ButtonToolTipText
        /// <summary>
        /// ���������� ��� ������������� �������� ������ ��������� ��� ������ Save2
        /// </summary>
        [Category("Appearance"), Description("����� ����������� ��������� ��� ������ Save2")]
        [DefaultValue("")]
        public string Save2ButtonToolTipText
        {
            get { return richReferenceButtonSave2.ToolTipText; }
            set { richReferenceButtonSave2.ToolTipText = value; }
        }
        #endregion

        #region public bool ShowCloseButton
        /// <summary>
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Close
        /// </summary>
        [Description("����� �� ���������� ������ Close"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Edit
        /// </summary>
        [Description("����� �� ���������� ������ Edit"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Forecast
        /// </summary>
        [Description("����� �� ���������� ������ Forecast"), Category("Layout")]
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
        /// ��������/������ ����� ���� "��� ��������"
        ///</summary>
        [Description("��������/������ ����� ���� ��� ��������"), Category("Layout")]
        [DefaultValue(false)]
        public bool ShowNoForecastMenuItem
        {
            get { return forecastControl.ShowNoForecastMenuItem; }
            set { forecastControl.ShowNoForecastMenuItem = value; }
        }
        #endregion

        #region public bool ShowHelpButton
        /// <summary>
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Help
        /// </summary>
        [Description("����� �� ���������� ������ Help"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Print
        /// </summary>
        [Description("����� �� ���������� ������ Print"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Reload
        ///</summary>
        [Description("����� �� ���������� ������ Reload"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Save
        /// </summary>
        [Description("����� �� ���������� ������ Save"), Category("Layout")]
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
        /// ���������� ��� ������������� ��������, ������������ ����� �� ���������� ������ Save2
        /// </summary>
        [Description("����� �� ���������� ������ Save2"), Category("Layout")]
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
        /// ��������� �� ������� ������������ (�������)
        /// </summary>
        private IDisplayer _currentDisplayer;
        ///<summary>
        /// ��������� �� ������� ������������ (�������)
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
        /// ��������� �� ��������� ���-�� ������� � �������� ������� � ������ ���������� ������� (����������������� ��������)
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
        ///// �����, ����������� ��� ����������� ����������� ������� �������� ����������
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
        /// �����, �������������� ������� ���������� ������ �������� ����������
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
        /// ������� ������ ��������������
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
        /// ������� ������ ������������ ���� � ��������
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
        /// ������� ������ ����������
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
        /// ������� ������ ����������
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
        /// ������� ������ ���������� � �������� �� ����� �������
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
        /// ������� ������ ���������� 2
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
        /// ������� ������ ����������� ������
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
