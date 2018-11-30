using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;

namespace CAS.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Элемент управления для отображения информации о заданном эксплуатанте
    /// </summary>
    public class OperatorControl : UserControl, IReference
    {

        #region Fields

        private readonly Operator currentOperator;

        private Label labelName;
        private Label labelICAO;
        private Label labelAddress;
        private Label labelPhone;
        private Label labelFax;
        private Label labelEmail;
        private Label labelTransparentLogotype;
        private Label labelWhiteBackgroundLogotype;
        private TextBox textBoxName;
        private TextBox textBoxICAO;
        private TextBox textBoxAddress;
        private TextBox textBoxPhone;
        private TextBox textBoxFax;
        private TextBox textBoxEmail;
        private PictureBox pictureBoxTransparentLogotype;
        private PictureBox pictureBoxWhiteBackgroundLogotype;
        private LinkLabel linkChangeTransparentLogotype;
        private LinkLabel linkChangeWhiteBackgroundLogotype;
        private ReferenceLinkLabel linkLabelViewAircrafts;
        private const int LEFT_MARGIN = 20;
        private const int TOP_MARGIN = 20;
        private const int HEIGHT_INTERVAL = 10;
        private const int WIDTH_INTERVAL = 25;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 210;
        private const int TEXTBOX_WIDTH = 200;
        private readonly Size pictureBoxSize = new Size(48, 48);
        private readonly Icons icons = new Icons();
        private bool logotypeChanged = false;
        private bool logotypeWhiteChanged = false;
        private const string transparentFilter = "PNG (*.png)|*.png";
        private const string whiteBackgroundFilter = "GIF (*.gif)|*.gif";

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о заданном эксплуатанте
        /// </summary>
        /// <param name="currentOperator">Заданный эксплуатант</param>
        /// <param name="view">Тип отображения (добавление или редактирование)</param>
        public OperatorControl(Operator currentOperator, OperatorScreenView view)
        {
            this.currentOperator = currentOperator;
            InitializeComponent();
            UpdateInformation();
            if (view == OperatorScreenView.Add)
            {
                linkLabelViewAircrafts.Visible = false;
                pictureBoxTransparentLogotype.BackgroundImage = icons.EmptyLogotype;
                pictureBoxWhiteBackgroundLogotype.BackgroundImage = icons.EmptyLogotype;
            }
        }

        #endregion

        #region Properties

        #region public string OperatorName

        /// <summary>
        /// Возвращает название эксплуатанта
        /// </summary>
        public string OperatorName
        {
            get
            {
                return textBoxName.Text;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelName = new Label();
            labelICAO = new Label();
            labelAddress = new Label();
            labelPhone = new Label();
            labelFax = new Label();
            labelEmail = new Label();
            labelTransparentLogotype = new Label();
            labelWhiteBackgroundLogotype = new Label();
            textBoxName = new TextBox();
            textBoxICAO = new TextBox();
            textBoxAddress = new TextBox();
            textBoxPhone = new TextBox();
            textBoxFax = new TextBox();
            textBoxEmail = new TextBox();
            pictureBoxTransparentLogotype = new PictureBox();
            pictureBoxWhiteBackgroundLogotype = new PictureBox();
            linkChangeTransparentLogotype = new LinkLabel();
            linkChangeWhiteBackgroundLogotype = new LinkLabel();
            linkLabelViewAircrafts = new ReferenceLinkLabel();
            // 
            // labelName
            // 
            labelName.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelName.Location = new Point(LEFT_MARGIN, TOP_MARGIN);
            labelName.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelName.Text = "Name";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelICAO
            // 
            labelICAO.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelICAO.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelICAO.Location = new Point(LEFT_MARGIN, labelName.Bottom + HEIGHT_INTERVAL);
            labelICAO.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelICAO.Text = "ICAO code";
            labelICAO.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelAddress
            // 
            labelAddress.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAddress.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAddress.Location = new Point(LEFT_MARGIN, labelICAO.Bottom + HEIGHT_INTERVAL);
            labelAddress.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAddress.Text = "Address";
            labelAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPhone
            // 
            labelPhone.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPhone.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPhone.Location = new Point(LEFT_MARGIN, labelAddress.Bottom + HEIGHT_INTERVAL);
            labelPhone.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPhone.Text = "Phone";
            labelPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelFax
            // 
            labelFax.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFax.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFax.Location = new Point(LEFT_MARGIN, labelPhone.Bottom + HEIGHT_INTERVAL);
            labelFax.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelFax.Text = "Fax";
            labelFax.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelEmail
            // 
            labelEmail.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEmail.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEmail.Location = new Point(LEFT_MARGIN, labelFax.Bottom + HEIGHT_INTERVAL);
            labelEmail.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEmail.Text = "Email";
            labelEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTransparentLogotype
            //
            labelTransparentLogotype.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTransparentLogotype.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTransparentLogotype.Location = new Point(LEFT_MARGIN, labelEmail.Bottom + HEIGHT_INTERVAL);
            labelTransparentLogotype.Size = new Size(LABEL_WIDTH, pictureBoxSize.Height);
            labelTransparentLogotype.Text = "Transparent logotype\r\n(48x48px, *.png)";
            labelTransparentLogotype.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pictureBoxTransparentLogotype
            //
            pictureBoxTransparentLogotype.BackColor = Color.White;
            pictureBoxTransparentLogotype.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxTransparentLogotype.BackgroundImage = icons.EmptyLogotype;
            pictureBoxTransparentLogotype.Cursor = Cursors.Hand;
            pictureBoxTransparentLogotype.Location = new Point(labelTransparentLogotype.Right, labelTransparentLogotype.Top);
            pictureBoxTransparentLogotype.Size = pictureBoxSize;
            pictureBoxTransparentLogotype.TabIndex = 6;
            pictureBoxTransparentLogotype.Click += pictureBoxLogotype_Click;
            //
            // linkChangeTransparentLogotype
            //
            linkChangeTransparentLogotype.Font = Css.SimpleLink.Fonts.Font;
            linkChangeTransparentLogotype.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkChangeTransparentLogotype.Location = new Point(pictureBoxTransparentLogotype.Right + WIDTH_INTERVAL, labelTransparentLogotype.Top);
            linkChangeTransparentLogotype.Size = new Size(LABEL_WIDTH, pictureBoxSize.Height);
            linkChangeTransparentLogotype.TextAlign = ContentAlignment.MiddleLeft;
            linkChangeTransparentLogotype.LinkClicked += linkLogotype_LinkClicked;
            linkChangeTransparentLogotype.Text = "Change";
            // 
            // labelWhiteBackgroundLogotype
            //
            labelWhiteBackgroundLogotype.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelWhiteBackgroundLogotype.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWhiteBackgroundLogotype.Location = new Point(LEFT_MARGIN, labelTransparentLogotype.Bottom + HEIGHT_INTERVAL);
            labelWhiteBackgroundLogotype.Size = new Size(LABEL_WIDTH, pictureBoxSize.Height + 5);
            labelWhiteBackgroundLogotype.Text = "Report logotype:\r\nWhite background\r\n200 dpi,*.gif";
            labelWhiteBackgroundLogotype.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pictureBoxWhiteBackgroundLogotype
            //
            pictureBoxWhiteBackgroundLogotype.BackColor = Color.White;
            pictureBoxWhiteBackgroundLogotype.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxWhiteBackgroundLogotype.BackgroundImage = icons.EmptyLogotype;
            pictureBoxWhiteBackgroundLogotype.Cursor = Cursors.Hand;
            pictureBoxWhiteBackgroundLogotype.Location = new Point(labelWhiteBackgroundLogotype.Right, labelWhiteBackgroundLogotype.Top);
            pictureBoxWhiteBackgroundLogotype.Size = pictureBoxSize;
            pictureBoxWhiteBackgroundLogotype.TabIndex = 6;
            pictureBoxWhiteBackgroundLogotype.Click += pictureBoxLogotype_Click;
            //
            // linkChangeWhiteBackgroundLogotype
            //
            linkChangeWhiteBackgroundLogotype.Font = Css.SimpleLink.Fonts.Font;
            linkChangeWhiteBackgroundLogotype.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkChangeWhiteBackgroundLogotype.Location = new Point(pictureBoxWhiteBackgroundLogotype.Right + WIDTH_INTERVAL, labelWhiteBackgroundLogotype.Top);
            linkChangeWhiteBackgroundLogotype.Size = new Size(LABEL_WIDTH, pictureBoxSize.Height);
            linkChangeWhiteBackgroundLogotype.TextAlign = ContentAlignment.MiddleLeft;
            linkChangeWhiteBackgroundLogotype.LinkClicked += linkLogotype_LinkClicked;
            linkChangeWhiteBackgroundLogotype.Text = "Change";
            // 
            // textBoxName
            // 
            textBoxName.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxName.Location = new Point(labelName.Right, TOP_MARGIN);
            textBoxName.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxName.TabIndex = 0;
            // 
            // textBoxICAO
            // 
            textBoxICAO.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxICAO.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxICAO.Location = new Point(labelICAO.Right, textBoxName.Bottom + HEIGHT_INTERVAL);
            textBoxICAO.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxICAO.TabIndex = 1;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAddress.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAddress.Location = new Point(labelAddress.Right, textBoxICAO.Bottom + HEIGHT_INTERVAL);
            textBoxAddress.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxAddress.TabIndex = 2;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPhone.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPhone.Location = new Point(labelPhone.Right, textBoxAddress.Bottom + HEIGHT_INTERVAL);
            textBoxPhone.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxPhone.TabIndex = 3;
            // 
            // textBoxFax
            // 
            textBoxFax.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxFax.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxFax.Location = new Point(labelFax.Right, textBoxPhone.Bottom + HEIGHT_INTERVAL);
            textBoxFax.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxFax.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = Css.SimpleLink.Fonts.Font;
            textBoxEmail.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEmail.Location = new Point(labelEmail.Right, textBoxFax.Bottom + HEIGHT_INTERVAL);
            textBoxEmail.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxEmail.TabIndex = 5;
            //
            // linkLabelViewAircrafts
            //
            linkLabelViewAircrafts.Font = Css.SimpleLink.Fonts.Font;
            linkLabelViewAircrafts.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelViewAircrafts.Location = new Point(LEFT_MARGIN, pictureBoxWhiteBackgroundLogotype.Bottom + HEIGHT_INTERVAL);
            linkLabelViewAircrafts.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            linkLabelViewAircrafts.DisplayerRequested += linkLabelViewAircrafts_DisplayerRequested;
            linkLabelViewAircrafts.Text = "View aircrafts";
            // 
            // OperatorControl
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(labelName);
            Controls.Add(labelICAO);
            Controls.Add(labelAddress);
            Controls.Add(labelPhone);
            Controls.Add(labelFax);
            Controls.Add(labelEmail);
            Controls.Add(labelTransparentLogotype);
            Controls.Add(labelWhiteBackgroundLogotype);
            Controls.Add(textBoxName);
            Controls.Add(textBoxICAO);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxFax);
            Controls.Add(textBoxEmail);
            Controls.Add(pictureBoxTransparentLogotype);
            Controls.Add(pictureBoxWhiteBackgroundLogotype);
            Controls.Add(linkChangeTransparentLogotype);
            Controls.Add(linkChangeWhiteBackgroundLogotype);
            Controls.Add(linkLabelViewAircrafts);
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Проверяет, вносились ли изменения в данные эксплуатанта
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (textBoxName.Text != currentOperator.Name ||
                    textBoxICAO.Text != currentOperator.ICAOCode ||
                    textBoxAddress.Text != currentOperator.Address ||
                    textBoxPhone.Text != currentOperator.Phone ||
                    textBoxFax.Text != currentOperator.Fax ||
                    textBoxEmail.Text != currentOperator.Email ||
                    logotypeChanged || logotypeWhiteChanged);
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные эксплуатанта
        /// </summary>
        public void UpdateInformation()
        {
            textBoxName.Text = currentOperator.Name;
            textBoxICAO.Text = currentOperator.ICAOCode;
            textBoxAddress.Text = currentOperator.Address;
            textBoxPhone.Text = currentOperator.Phone;
            textBoxFax.Text = currentOperator.Fax;
            textBoxEmail.Text = currentOperator.Email;
            pictureBoxTransparentLogotype.BackgroundImage = currentOperator.LogoType;
            pictureBoxWhiteBackgroundLogotype.BackgroundImage = currentOperator.LogoTypeWhite;
            logotypeChanged = false;
            logotypeWhiteChanged = false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохраняет измененные данные эксплуатанта
        /// </summary>
        public void SaveData()
        {
            if (textBoxName.Text != currentOperator.Name)
            {
                currentOperator.Name = textBoxName.Text;
                string caption = currentOperator.Name + ". Summary";
                if (DisplayerRequested != null)
                    DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
            }
            if (textBoxICAO.Text != currentOperator.ICAOCode)
                currentOperator.ICAOCode = textBoxICAO.Text;
            if (textBoxAddress.Text != currentOperator.Address)
                currentOperator.Address = textBoxAddress.Text;
            if (textBoxPhone.Text != currentOperator.Phone)
                currentOperator.Phone = textBoxPhone.Text;
            if (textBoxFax.Text != currentOperator.Fax)
                currentOperator.Fax = textBoxFax.Text;
            if (textBoxEmail.Text != currentOperator.Email)
                currentOperator.Email = textBoxEmail.Text;
            if (logotypeChanged)
                currentOperator.LogoType = pictureBoxTransparentLogotype.BackgroundImage;
            if (logotypeWhiteChanged)
                currentOperator.LogoTypeWhite = pictureBoxWhiteBackgroundLogotype.BackgroundImage;
            logotypeChanged = false;
            logotypeWhiteChanged = false;
        }

        #endregion

        #region public void CheckPermission()

        /// <summary>
        /// Проверят права доступа и блокирует при необходимости некоторые элементы управления
        /// </summary>
        public void CheckPermission()
        {
            bool permission = currentOperator.HasPermission(Users.CurrentUser, DataEvent.Update);
            textBoxName.ReadOnly = !permission;
            textBoxICAO.ReadOnly = !permission;
            textBoxAddress.ReadOnly = !permission;
            textBoxPhone.ReadOnly = !permission;
            textBoxFax.ReadOnly = !permission;
            textBoxEmail.ReadOnly = !permission;
            pictureBoxTransparentLogotype.Enabled = permission;
            pictureBoxWhiteBackgroundLogotype.Enabled = permission;
            linkChangeTransparentLogotype.Visible = permission;
            linkChangeWhiteBackgroundLogotype.Visible = permission;
        }

        #endregion

        #region private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)

        private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image logotype = Image.FromFile(dialog.FileName);
                Stream stream = dialog.OpenFile();
                long size = stream.Length;
                stream.Close();
                if (size > 200000 || logotype.Width > 500 || logotype.Height > 500)
                {
                    MessageBox.Show("Logotype shouldn't exceed 500x500 px and 200 Kb", (string) new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pictureBox.BackgroundImage = logotype;
                changed = true;
            }
        }

        #endregion

        #region private void pictureBoxLogotype_Click(object sender, EventArgs e)

        private void pictureBoxLogotype_Click(object sender, EventArgs e)
        {
            if ((PictureBox)sender == pictureBoxTransparentLogotype)
                OpenFile(pictureBoxTransparentLogotype, ref logotypeChanged, transparentFilter);
            else
                OpenFile(pictureBoxWhiteBackgroundLogotype, ref logotypeWhiteChanged, whiteBackgroundFilter);
        }

        #endregion

        #region private void linkLogotype_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLogotype_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((LinkLabel)sender == linkChangeTransparentLogotype)
                OpenFile(pictureBoxTransparentLogotype, ref logotypeChanged, transparentFilter);
            else
                OpenFile(pictureBoxWhiteBackgroundLogotype, ref logotypeWhiteChanged, whiteBackgroundFilter);
        }

        #endregion

        #region private void linkLabelViewAircrafts_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLabelViewAircrafts_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = currentOperator.Name;
            e.RequestedEntity = new DispatcheredAircraftCollectionScreen(currentOperator);
        }

        #endregion

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

    }
}
