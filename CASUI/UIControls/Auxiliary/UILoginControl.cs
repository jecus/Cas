using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LTR.Core.Core.Settings;
using LTR.Core.Management;
using LTR.Core.Settings;
using LTR.Events;
using HelpEventHandler=LTR.Events.HelpEventHandler;

namespace LTR.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления, предназначенный для подключения к SQL серверу
    /// </summary>
    internal partial class UILoginControl : UserControl
    {

        #region Fields
        protected Label labelTitle;
        protected Panel panelLoginPasswordContainer;
        protected Panel panelConnectionSettingsContainer;
        protected LinkLabel linkLabelShowConnectionSettings;
        private PictureBox pictureBoxPasswordBorder;
        private PictureBox pictureBoxLoginBorder;
        private PictureBox pictureBoxServerNameBorder;
        private PictureBox pictureBoxAuthenticationBorder;

        private Label labelServerName;
        private TextBox textBoxLogin;
        private Label labelAuthentication;
        private Label labelLogin;
        private Label labelPassword;
        private ComboBox comboBoxServerName;
        private ComboBox comboBoxAuthentication;
        private Button buttonConnect;
        private Button buttonExit;
        private LinkLabel buttonHelp;
        private TextBox textBoxPassword;
        private CheckBox checkBoxRememberLogin;

        private readonly Font labelFont = new Font("Verdana", 12F, FontStyle.Regular);
        private readonly Font textBoxFont = new Font("Verdana", 22F, FontStyle.Regular);
        private readonly Font buttonFont = new Font("Verdana", 12F);

        private const int PADDING = 20;
        private readonly Size labelSize = new Size(150, 20);
        private readonly Size textBoxSize = new Size(270, 20);
        private readonly Size comboBoxSize = new Size(214, 20);
        private readonly Size buttonSize = new Size(103, 33);

        private ConnectionState connectionStatus = ConnectionState.Closed;
        private Thread connectionThread;
        private bool isSimple = true;
        #endregion

        #region Constructor
        public UILoginControl()
        {
            InitializeComponent();

            Initialize();
            connectionThread = new Thread(Connect);
            LoadSettings();
        }

        #endregion

        #region Delegates
        private delegate void eventInvoker();

        private delegate void failureEventInvoker(string reason);
        #endregion

        #region Events

        #region public event EventHandler Connected
        /// <summary>
        /// Событие, возникающее когда подключение прошло успешно
        /// </summary>
        public event EventHandler Connected;
        #endregion

        #region private void OnConnected()
        private void OnConnected()
        {
            connectionStatus = ConnectionState.Open;
            buttonExit.Text = "Exit";
            ConnectingFinished();
            if (Connected != null)
                Connected(this, new EventArgs());
            SaveSettings();
        }
        #endregion

        #region public event EventHandler Connecting
        /// <summary>
        /// Событие, возникающее при начале подключения
        /// </summary>
        public event EventHandler Connecting;
        #endregion

        #region private void OnConnecting()
        private void OnConnecting()
        {
            SetEnabled(false, isSimple);
            buttonExit.Text = "Cancel";
            connectionStatus = ConnectionState.Connecting;
            if (Connecting != null)
                Connecting(this, new EventArgs());
        }
        #endregion

        #region public event EventHandler Disconnected
        /// <summary>
        /// Событие, возникающее при отключении
        /// </summary>
        public event EventHandler Disconnected;
        #endregion

        #region private void OnDisconnected()
        private void OnDisconnected()
        {
            connectionStatus = ConnectionState.Closed;
            if (Disconnected != null)
                Disconnected(this, new EventArgs());
        }
        #endregion

        #region public event HelpEventHandler HelpClicked
        /// <summary>
        /// Событие, возникающее при вызове справки
        /// </summary>
        public event HelpEventHandler HelpClicked;
        #endregion

        #region private void OnHelpClicked()
        private void OnHelpClicked()
        {
            if (HelpClicked != null)
                HelpClicked(this, new HelpEventHandlerArgs("Help not specified"));
        }
        #endregion

        #region public event EventHandler ExitClicked
        /// <summary>
        /// Событие, возникающее при выходе
        /// </summary>
        public event EventHandler ExitClicked;
        #endregion

        #region private void OnExitClicked()
        private void OnExitClicked()
        {
            Disconnect();
            if (ExitClicked != null)
                ExitClicked(this, new EventArgs());
        }
        #endregion

        #region public event EventHandler ConnectionFailed
        /// <summary>
        /// Событие, возникающее при потере соединения с сервером
        /// </summary>
        public event EventHandler ConnectionFailed;
        #endregion

        #region private void OnFailed(string reason)
        private void OnFailed(string reason)
        {
            connectionStatus = ConnectionState.Closed;
            buttonExit.Text = "Exit";
            MessageBox.Show("Failed to connect:\r\n" + reason);
            ConnectingFinished();
            if (ConnectionFailed != null)
                ConnectionFailed(this, new EventArgs());
        }
        #endregion

        #endregion

        #region Properties

        #region public bool IsConnecting
        /// <summary>
        /// Идет ли попытка подключения
        /// </summary>
        public bool IsConnecting
        {
            get { return connectionStatus == ConnectionState.Connecting; }
        }
        #endregion

        #region public Button ButtonConnect
        /// <summary>
        /// Возвращает кнопку подключения к серверу
        /// </summary>
        public Button ButtonConnect
        {
            get { return buttonConnect; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void Initialize()
        private void Initialize()
        {
            Width = 3 * PADDING + labelSize.Width + textBoxSize.Width;
            Height = 6 * PADDING + 4 * labelSize.Height + buttonSize.Height;


            labelServerName = new Label();
            labelAuthentication = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            comboBoxServerName = new ComboBox();
            comboBoxAuthentication = new ComboBox();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonConnect = new Button();
            buttonExit = new Button();
            buttonHelp = new LinkLabel();
            checkBoxRememberLogin = new CheckBox();
            panelLoginPasswordContainer = new Panel();
            panelConnectionSettingsContainer = new Panel();
            labelTitle = new Label();
            pictureBoxLoginBorder = new PictureBox();
            pictureBoxPasswordBorder = new PictureBox();
            pictureBoxServerNameBorder = new PictureBox();
            pictureBoxAuthenticationBorder = new PictureBox();
            linkLabelShowConnectionSettings = new LinkLabel();
            //
            // labelTitle
            //
            labelTitle.Location = new Point(PADDING, PADDING - 10);
            labelTitle.AutoSize = true;
            labelTitle.Text = "Login form";
            labelTitle.Font = new Font("Verdana", 18F, FontStyle.Bold);
            labelTitle.BackColor = Color.Transparent;
            labelTitle.ForeColor = Color.White;
            //
            // panelLoginPasswordContainer
            //
            panelLoginPasswordContainer.Location = new Point(PADDING, PADDING + labelTitle.Height + PADDING);
            panelLoginPasswordContainer.Size = new Size(Width - 2 * PADDING, 150);
            panelLoginPasswordContainer.BackColor = Color.Transparent;
            //
            // panelConnectionSettingsContainer
            //
            panelConnectionSettingsContainer.Location =
                new Point(PADDING, panelLoginPasswordContainer.Top + panelLoginPasswordContainer.Height + 10);
            panelConnectionSettingsContainer.Size = new Size(Width - 2 * PADDING, 200);
            panelConnectionSettingsContainer.BackColor = Color.Transparent;
            panelConnectionSettingsContainer.Visible = false;
            //
            // labelLogin 
            //
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(0, 20);
            labelLogin.Font = labelFont;
            labelLogin.ForeColor = Color.White;
            labelLogin.TextAlign = ContentAlignment.MiddleLeft;
            labelLogin.Text = "User name:";
            //
            // labelPassword
            //
            labelPassword.Size = labelSize;
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(0, 70);
            labelPassword.Font = labelFont;
            labelPassword.ForeColor = Color.White;
            labelPassword.TextAlign = ContentAlignment.MiddleLeft;
            labelPassword.Text = "Password:";
            //
            // comboBoxServerName
            //
            comboBoxServerName.Size = comboBoxSize;
            comboBoxServerName.Location = new Point(186, 10);
            comboBoxServerName.Font = labelFont;
            comboBoxServerName.ForeColor = Color.White;
            comboBoxServerName.TabIndex = 5;
            comboBoxServerName.FlatStyle = FlatStyle.Flat;
            comboBoxServerName.BackColor = Color.FromArgb(52, 121, 191);
            //
            // comboBoxAuthentication
            //
            comboBoxAuthentication.Size = comboBoxSize;
            comboBoxAuthentication.Location = new Point(186, 50);
            comboBoxAuthentication.Font = labelFont;
            comboBoxAuthentication.ForeColor = Color.White;
            comboBoxAuthentication.TabIndex = 6;
            comboBoxAuthentication.DropDownStyle =ComboBoxStyle.DropDownList;
            comboBoxAuthentication.Items.Add("Simple");
            comboBoxAuthentication.Items.Add("Windows");
            comboBoxAuthentication.FlatStyle = FlatStyle.Flat;
            comboBoxAuthentication.BackColor = Color.FromArgb(52, 121, 191);
            comboBoxAuthentication.SelectedIndexChanged += comboBoxAuthentication_SelectedIndexChanged;
            //
            // labelServerName 
            //
            labelServerName.AutoSize = true;
            labelServerName.Location = new Point(0, 10);
            labelServerName.Font = labelFont;
            labelServerName.ForeColor = Color.White;
            labelServerName.TextAlign = ContentAlignment.MiddleLeft;
            labelServerName.Text = "Server name:";
            //
            // labelAuthentication
            //
            labelAuthentication.AutoSize = true;
            labelAuthentication.Location = new Point(0, 55);
            labelAuthentication.Font = labelFont;
            labelAuthentication.ForeColor = Color.White;
            labelAuthentication.TextAlign = ContentAlignment.MiddleLeft;
            labelAuthentication.Text = "Authentication:";
            //
            // textBoxLogin
            //
            textBoxLogin.Size = textBoxSize;
            textBoxLogin.Location = new Point(130, 12);
            textBoxLogin.Font = textBoxFont;
            textBoxLogin.ForeColor = Color.White;
            textBoxLogin.TabIndex = 0;
            textBoxLogin.BackColor = Color.FromArgb(52, 121, 191);
            textBoxLogin.BorderStyle = BorderStyle.None;
            textBoxLogin.Text = "username";
            //
            // textBoxPassword
            //
            textBoxPassword.Size = textBoxSize;
            textBoxPassword.Location = new Point(130, 62);
            textBoxPassword.Font = textBoxFont;
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.TabIndex = 1;
            textBoxPassword.BackColor = Color.FromArgb(52, 121, 191);
            ;
            textBoxPassword.PasswordChar = '•';
            textBoxPassword.BorderStyle = BorderStyle.None;
            //
            // pictureBoxPasswordBorder
            //
            pictureBoxPasswordBorder.Location = new Point(textBoxPassword.Left - 2, textBoxPassword.Top - 2);
            pictureBoxPasswordBorder.Size = new Size(textBoxPassword.Width + 4, textBoxPassword.Height - 3);
            pictureBoxPasswordBorder.BackColor = Color.White;
            //
            // pictureBoxLoginBorder
            //
            pictureBoxLoginBorder.Location = new Point(textBoxLogin.Left - 2, textBoxLogin.Top - 2);
            pictureBoxLoginBorder.Size = new Size(textBoxLogin.Width + 4, textBoxLogin.Height - 3);
            pictureBoxLoginBorder.BackColor = Color.White;
            //
            // pictureBoxAuthenticationBorder
            //
            pictureBoxAuthenticationBorder.Location = new Point(185, 49);
            pictureBoxAuthenticationBorder.Size = new Size(comboBoxAuthentication.Width + 2, 28);
            pictureBoxAuthenticationBorder.BackColor = Color.White;
            //
            // pictureBoxServerNameBorder
            //
            pictureBoxServerNameBorder.Location = new Point(185, 9);
            pictureBoxServerNameBorder.Size = new Size(comboBoxServerName.Width + 2, 28);
            pictureBoxServerNameBorder.BackColor = Color.White;
            //
            // buttonConnect
            //
            buttonConnect.Size = buttonSize;
            //buttonConnect.Location = new Point(Width - 3*PADDING - 3*buttonSize.Width,5*PADDING + 4*textBoxSize.Height);
            buttonConnect.FlatStyle = FlatStyle.Flat;
            buttonConnect.FlatAppearance.BorderSize = 0;
            buttonConnect.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 186, 0);
            buttonConnect.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 180, 0);
            buttonConnect.BackColor = Color.FromArgb(255, 138, 0);
            buttonConnect.Location = new Point(186, 110);
            buttonConnect.Font = buttonFont;
            buttonConnect.ForeColor = Color.White;
            buttonConnect.TabIndex = 2;
            buttonConnect.Text = "Connect";
            buttonConnect.Click += buttonConnect_Click;
            //
            // buttonExit
            //
            buttonExit.Size = buttonSize;
            //buttonExit.Location = new Point(Width - 2*PADDING - 2*buttonSize.Width,5*PADDING + 4*textBoxSize.Height);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 186, 0);
            buttonExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 180, 0);
            buttonExit.BackColor = Color.FromArgb(255, 138, 0);
            buttonExit.Location = new Point(186 + PADDING / 2 + buttonConnect.Width, 110);
            buttonExit.Font = buttonFont;
            buttonExit.ForeColor = Color.White;
            buttonExit.TabIndex = 3;
            buttonExit.Text = "Exit";
            buttonExit.Click += buttonExit_Click;
            //
            // buttonHelp
            //
            buttonHelp.Size = buttonSize;
            buttonHelp.Location = new Point(376, 17);
            buttonHelp.Font = labelFont;
            buttonHelp.ActiveLinkColor = Color.White;
            buttonHelp.VisitedLinkColor = Color.White;
            buttonHelp.LinkColor = Color.White;
            buttonHelp.ForeColor = Color.Transparent;
            buttonHelp.TabIndex = 4;
            buttonHelp.Text = "Help";
            buttonHelp.Click += buttonHelp_Click;
            //buttonHelp.Visible = false;
            //
            // linkLabelShowConnectionSettings
            //
            linkLabelShowConnectionSettings.Text = "Connection settings";
            linkLabelShowConnectionSettings.ActiveLinkColor = Color.White;
            linkLabelShowConnectionSettings.VisitedLinkColor = Color.White;
            linkLabelShowConnectionSettings.LinkColor = Color.White;
            linkLabelShowConnectionSettings.ForeColor = Color.Transparent;
            linkLabelShowConnectionSettings.Location = new Point(0, 115);
            linkLabelShowConnectionSettings.Font = new Font(labelFont.FontFamily, labelFont.Size - 1);
            linkLabelShowConnectionSettings.AutoSize = true;
            linkLabelShowConnectionSettings.Click += linkLabelShowConnectionSettings_Click;


            panelLoginPasswordContainer.Controls.Add(labelLogin);
            panelLoginPasswordContainer.Controls.Add(labelPassword);
            panelLoginPasswordContainer.Controls.Add(textBoxLogin);
            panelLoginPasswordContainer.Controls.Add(textBoxPassword);
            panelLoginPasswordContainer.Controls.Add(pictureBoxPasswordBorder);
            panelLoginPasswordContainer.Controls.Add(pictureBoxLoginBorder);
            panelLoginPasswordContainer.Controls.Add(buttonConnect);
            panelLoginPasswordContainer.Controls.Add(buttonExit);
            panelLoginPasswordContainer.Controls.Add(linkLabelShowConnectionSettings);

            panelConnectionSettingsContainer.Controls.Add(labelServerName);
            panelConnectionSettingsContainer.Controls.Add(labelAuthentication);
            panelConnectionSettingsContainer.Controls.Add(comboBoxServerName);
            panelConnectionSettingsContainer.Controls.Add(comboBoxAuthentication);
            panelConnectionSettingsContainer.Controls.Add(pictureBoxAuthenticationBorder);
            panelConnectionSettingsContainer.Controls.Add(pictureBoxServerNameBorder);

            Controls.Add(panelLoginPasswordContainer);
            Controls.Add(panelConnectionSettingsContainer);
            Controls.Add(labelTitle);


            Controls.Add(buttonHelp);
        }
        #endregion

        #region private void linkLabelShowConnectionSettings_Click(object sender, EventArgs e)

        private void linkLabelShowConnectionSettings_Click(object sender, EventArgs e)
        {
            panelConnectionSettingsContainer.Visible = !panelConnectionSettingsContainer.Visible;
        }

        #endregion

        #region private void LoadSettings()
        /// <summary>
        /// Создает новый элемент управления для подключения к базе данных
        /// </summary>
        private void LoadSettings()
        {
            LoginSettingsContainer settings = LoginSettingsProvider.ReadSettings();
            string[] servers = settings.Servers;
            if (servers != null)
                comboBoxServerName.Items.AddRange(servers);
            comboBoxServerName.Text = settings.LastConnectedServer;
            isSimple = settings.IsSimpleAuthentication;
            if (isSimple)
            {
                comboBoxAuthentication.SelectedIndex = 0;
                checkBoxRememberLogin.Checked = settings.SaveUsernamePassword;
                textBoxLogin.Text = settings.Username;
            }
            else
            {
                comboBoxAuthentication.SelectedIndex = 1;
            }
            SetEnabled(true, isSimple);
        }
        #endregion

        #region private void SaveSettings()
        private void SaveSettings()
        {
            string[] servers = new string[comboBoxServerName.Items.Count];
            for (int i = 0; i < comboBoxServerName.Items.Count; i++)
                servers[i] = (string) comboBoxServerName.Items[i];
            LoginSettingsContainer settings =
                new LoginSettingsContainer(servers, comboBoxServerName.Text, isSimple, checkBoxRememberLogin.Checked,
                                           textBoxLogin.Text, "");
            LoginSettingsProvider.SaveSettings(settings);
        }
        #endregion

        #region private void SetEnabled(bool value, bool authentication)
        /// <summary>
        /// Устанавливает свойство Enabled всем полям по заданному значению
        /// </summary>
        /// <param name="value">Новое значение свойства Enabled</param>
        /// <param name="authentication">true - если Authentication="Simple", false - если Authentication="Windows"</param>
        /// <remarks>Используется, когда необходимо произвести подключение</remarks>
        private void SetEnabled(bool value, bool authentication)
        {
            //labelServerName.Enabled = value;
            //labelAuthentication.Enabled = value;
            //labelLogin.Enabled = value;
            //labelPassword.Enabled = value;
            comboBoxServerName.Enabled = value;
            comboBoxAuthentication.Enabled = value;
            buttonConnect.Enabled = value;
            //buttonHelp.Enabled = value;
            checkBoxRememberLogin.Enabled = value && authentication;
            textBoxLogin.Enabled = value && authentication;
            textBoxPassword.Enabled = value && authentication;
        }
        #endregion

        #region private void buttonConnect_Click(object sender, EventArgs e)
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectionSettingsContainer settings =
                new ConnectionSettingsContainer(comboBoxServerName.Text, textBoxLogin.Text, textBoxPassword.Text,
                                                isSimple);
            connectionThread = new Thread(Connect);
            connectionThread.Start(settings);
        }
        #endregion

        #region private void comboBoxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        private void comboBoxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool value = (comboBoxAuthentication.SelectedIndex == 0);
            isSimple = value;
            SetEnabled(true, isSimple);
        }
        #endregion

        #region private void buttonExit_Click(object sender, EventArgs e)
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (connectionStatus == ConnectionState.Connecting)
            {
                CancelConnection();
            }
            else
            {
                OnExitClicked();
            }
        }
        #endregion

        #region private void Connect(object obj)
        private void Connect(object obj)
        {
            ConnectionSettingsContainer settings = obj as ConnectionSettingsContainer;
            if (settings != null)
            {
                AuthenticationType authentication = AuthenticationType.Windows;
                if (settings.IsSimple)
                    authentication = AuthenticationType.SQLServer;
                Invoke(new eventInvoker(OnConnecting));
                string message;
                if (ConnectionManager.Connect(settings.ServerName, settings.Username,
                                              settings.Password, authentication, out message))
                {
                    Invoke(new eventInvoker(OnConnected));
                }
                else
                {
                    Invoke(new failureEventInvoker(OnFailed), new object[1] {message});
                }
            }
            else
            {
                Invoke(new failureEventInvoker(OnFailed), new object[1] {"Wrong connection parameters"});
            }
        }
        #endregion

        #region private void Disconnect()
        private void Disconnect()
        {
            if (connectionThread.IsAlive) 
            {
                connectionThread.Abort();
                ConnectionManager.Disconnect();
                OnDisconnected();
            }
        }
        #endregion

        #region private void CancelConnection()
        private void CancelConnection()
        {
            connectionThread.Abort();
            ConnectingFinished();
            ConnectionManager.Disconnect();
            OnDisconnected();
        }
        #endregion

        #region private void ConnectingFinished()
        private void ConnectingFinished()
        {
            SetEnabled(true, isSimple);
            buttonExit.Text = "Exit";
        }
        #endregion

        #region private void buttonHelp_Click(object sender, EventArgs e)
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            OnHelpClicked();
        }
        #endregion

        #endregion
    }
}