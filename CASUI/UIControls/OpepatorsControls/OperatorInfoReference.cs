using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.OpepatorsControls
{
    ///<summary>
    /// Информация о операторе
    ///</summary>
    public class OperatorInfoReference : RichReferenceContainer
    {

        #region Fields

        private readonly Operator currentOperator;

        private Label labelAddress;
        private Label labelAddressValue;
        private Label labelFax;
        private Label labelFaxValue;
        private Label labelICAO;
        private Label labelICAOValue;
        private Label labelName;
        private Label labelNameValue;
        private Label labelPhone;
        private Label labelPhoneValue;
        private Label labelEmail;
        private LinkLabel labelEmailValue;
        private Panel panelMain;
        private ReferenceLinkLabel linkLabelEditOperatorInfo;

        private const int WIDTH_INTERVAL = 95;
        private const int HEIGHT_INTERVAL = 5;
        private const int MAX_LABEL_WIDTH = 250;
        private const int MAX_LABEL_HEIGHT = 20;

        #endregion

        #region Constructor

        ///<summary>
        /// Создается контрол отбражения информации об операторе
        ///</summary>
        public OperatorInfoReference(Operator currentOperator)
        {
            this.currentOperator = currentOperator;
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region public void UpdateDataForOperator()

        ///<summary>
        /// Отображает согласно переданному оператору
        ///</summary>
        public void UpdateDataForOperator()
        {
            labelNameValue.Text = currentOperator.Name;
            labelFaxValue.Text = currentOperator.Fax;
            labelICAOValue.Text = currentOperator.ICAOCode;
            labelPhoneValue.Text = currentOperator.Phone;
            labelAddressValue.Text = currentOperator.Address;
            labelEmailValue.Text = currentOperator.Email;
        }

        #endregion

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelMain = new Panel();
            labelFax = new Label();
            labelPhone = new Label();
            labelAddress = new Label();
            labelICAO = new Label();
            labelName = new Label();
            labelFaxValue = new Label();
            labelPhoneValue = new Label();
            labelAddressValue = new Label();
            labelICAOValue = new Label();
            labelNameValue = new Label();
            labelEmail = new Label();
            labelEmailValue = new LinkLabel();
            linkLabelEditOperatorInfo = new ReferenceLinkLabel();
            // 
            // panelMain
            //
            panelMain.AutoSize = true;
            panelMain.Controls.Add(labelName);
            panelMain.Controls.Add(labelNameValue);
            panelMain.Controls.Add(labelICAO);
            panelMain.Controls.Add(labelICAOValue);
            panelMain.Controls.Add(labelAddress);
            panelMain.Controls.Add(labelAddressValue);
            panelMain.Controls.Add(labelPhone);
            panelMain.Controls.Add(labelPhoneValue);
            panelMain.Controls.Add(labelFax);
            panelMain.Controls.Add(labelFaxValue);
            panelMain.Controls.Add(labelEmail);
            panelMain.Controls.Add(labelEmailValue);
            panelMain.Controls.Add(linkLabelEditOperatorInfo);
            panelMain.Dock = DockStyle.Fill;
            //panelMain.Location = new Point(10, 36);
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelName.Location = new Point(0, HEIGHT_INTERVAL);
            labelName.Text = "Name";
            // 
            // labelNameValue
            // 
            labelNameValue.AutoSize = true;
            labelNameValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNameValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNameValue.Location = new Point(WIDTH_INTERVAL, HEIGHT_INTERVAL);
            labelNameValue.MaximumSize = new Size(MAX_LABEL_WIDTH, MAX_LABEL_HEIGHT);
            labelNameValue.SizeChanged += label_SizeChanged;
            // 
            // labelICAO
            // 
            labelICAO.AutoSize = true;
            labelICAO.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelICAO.ForeColor = Css.OrdinaryText.Colors.ForeColor; 
            labelICAO.Text = "ICAO code";
            // 
            // labelICAOValue
            // 
            labelICAOValue.AutoSize = true;
            labelICAOValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelICAOValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelICAOValue.MaximumSize = new Size(MAX_LABEL_WIDTH, MAX_LABEL_HEIGHT);
            labelICAOValue.SizeChanged += label_SizeChanged;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelAddress.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAddress.Text = "Address";
            // 
            // labelAddressValue
            // 
            labelAddressValue.AutoSize = true;
            labelAddressValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAddressValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAddressValue.MaximumSize = new Size(MAX_LABEL_WIDTH, 2 * MAX_LABEL_HEIGHT);
            labelAddressValue.Text = "labelAddress";
            labelAddressValue.SizeChanged += label_SizeChanged;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelPhone.ForeColor = Css.OrdinaryText.Colors.ForeColor; 
            labelPhone.Text = "Phone";
            // 
            // labelPhoneValue
            // 
            labelPhoneValue.AutoSize = true;
            labelPhoneValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPhoneValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPhoneValue.MaximumSize = new Size(MAX_LABEL_WIDTH, MAX_LABEL_HEIGHT);
            labelPhoneValue.SizeChanged += label_SizeChanged;
            // 
            // labelFax
            // 
            labelFax.AutoSize = true;
            labelFax.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelFax.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFax.Text = "Fax";
            // 
            // labelFaxValue
            // 
            labelFaxValue.AutoSize = true;
            labelFaxValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFaxValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFaxValue.MaximumSize = new Size(MAX_LABEL_WIDTH, MAX_LABEL_HEIGHT);
            labelFaxValue.SizeChanged += label_SizeChanged;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelEmail.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEmail.Text = "Email";
            // 
            // labelEmailValue
            // 
            labelEmailValue.AutoSize = true;
            labelEmailValue.Font = Css.SimpleLink.Fonts.Font;
            labelEmailValue.LinkColor = Css.SimpleLink.Colors.LinkColor;
            labelEmailValue.MaximumSize = new Size(MAX_LABEL_WIDTH, MAX_LABEL_HEIGHT);
            labelEmailValue.SizeChanged += label_SizeChanged;
            labelEmailValue.LinkClicked += labelEmailValue_LinkClicked;
            //
            // linkLabelEditOperatorInfo
            //
            linkLabelEditOperatorInfo.AutoSize = true;
            linkLabelEditOperatorInfo.Font = Css.SimpleLink.Fonts.Font;
            linkLabelEditOperatorInfo.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelEditOperatorInfo.DisplayerRequested += linkLabelEditOperatorInfo_DisplayerRequested;
            if (currentOperator.HasPermission(Users.CurrentUser, DataEvent.Update))
                linkLabelEditOperatorInfo.Text = "Edit operator's info";
            else 
                linkLabelEditOperatorInfo.Text = "View operator's info";

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Caption = "General information";
            UpperLeftIcon = new Icons().GrayArrow;
            MainControl = panelMain;
        }

        #endregion

        #region private void labelEmailValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void labelEmailValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("Outlook.exe");
            startInfo.FileName = "mailto:" + currentOperator.Email;
            Process.Start(startInfo);
        }

        #endregion

        #region private void linkLabelEditOperatorInfo_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLabelEditOperatorInfo_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentOperator.Name + ". Summary";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredOperatorScreen(currentOperator);
        }

        #endregion

        #region private void label_SizeChanged(object sender, EventArgs e)

        private void label_SizeChanged(object sender, EventArgs e)
        {
            labelICAO.Location = new Point(0, labelNameValue.Bottom + HEIGHT_INTERVAL);
            labelICAOValue.Location = new Point(WIDTH_INTERVAL, labelNameValue.Bottom + HEIGHT_INTERVAL);
            labelAddress.Location = new Point(0, labelICAOValue.Bottom + HEIGHT_INTERVAL);
            labelAddressValue.Location = new Point(WIDTH_INTERVAL, labelICAOValue.Bottom + HEIGHT_INTERVAL);
            labelPhone.Location = new Point(0, labelAddressValue.Bottom + HEIGHT_INTERVAL);
            labelPhoneValue.Location = new Point(WIDTH_INTERVAL, labelAddressValue.Bottom + HEIGHT_INTERVAL);
            labelFax.Location = new Point(0, labelPhoneValue.Bottom + HEIGHT_INTERVAL);
            labelFaxValue.Location = new Point(WIDTH_INTERVAL, labelPhoneValue.Bottom + HEIGHT_INTERVAL);
            labelEmail.Location = new Point(0, labelFaxValue.Bottom + HEIGHT_INTERVAL);
            labelEmailValue.Location = new Point(WIDTH_INTERVAL, labelFaxValue.Bottom + HEIGHT_INTERVAL);
            linkLabelEditOperatorInfo.Location = new Point(0, labelEmailValue.Bottom + HEIGHT_INTERVAL);
        }

        #endregion

        #endregion
    }
}