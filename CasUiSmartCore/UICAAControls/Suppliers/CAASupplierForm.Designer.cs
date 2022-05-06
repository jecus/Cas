using CAS.UI.UICAAControls.Suppliers;
using MetroFramework.Controls;
using CASTerms;
using Entity.Abstractions;


namespace CAS.UI.UIControls.SupplierControls
{
    partial class CAASupplierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxEmail = new MetroFramework.Controls.MetroTextBox();
			this.textBoxAccount = new MetroFramework.Controls.MetroTextBox();
			this.textBoxAddress = new MetroFramework.Controls.MetroTextBox();
			this.textBoxPhone = new MetroFramework.Controls.MetroTextBox();
			this.textBoxShortName = new MetroFramework.Controls.MetroTextBox();
			this.textBoxName = new MetroFramework.Controls.MetroTextBox();
			this.labelEmail = new MetroFramework.Controls.MetroLabel();
			this.labelContactPerson = new MetroFramework.Controls.MetroLabel();
			this.labelAddress = new MetroFramework.Controls.MetroLabel();
			this.labelPhone = new MetroFramework.Controls.MetroLabel();
			this.labelShortName = new MetroFramework.Controls.MetroLabel();
			this.labelName = new MetroFramework.Controls.MetroLabel();
			this.textBoxVendorCode = new MetroFramework.Controls.MetroTextBox();
			this.labelVendorCode = new MetroFramework.Controls.MetroLabel();
			this.textBoxFax = new MetroFramework.Controls.MetroTextBox();
			this.labelFax = new MetroFramework.Controls.MetroLabel();
			this.textBoxWebSite = new MetroFramework.Controls.MetroTextBox();
			this.labelWebSite = new MetroFramework.Controls.MetroLabel();
			this.checkBoxApproved = new MetroFramework.Controls.MetroCheckBox();
			this.panelLabelImages = new System.Windows.Forms.Panel();
			this.ButtonAddDoc = new AvControls.AvButtonT.AvButtonT();
			this.buttonDeleteDoc = new AvControls.AvButtonT.AvButtonT();
			this.labelImageCaption = new MetroFramework.Controls.MetroLabel();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.buttonFormCertificate = new System.Windows.Forms.Button();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxSupplierClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.documentationListView = new CAS.UI.UIControls.DocumentationControls.DocumentationListView();
			this.dataGridViewControlSuppliers = new CAASupplierCourseListView();
			this.labelSupplier = new MetroFramework.Controls.MetroLabel();
			this.textBoxSubject = new MetroFramework.Controls.MetroTextBox();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBoxAirCode = new MetroFramework.Controls.MetroTextBox();
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.panelLabelImages.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(912, 700);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 18;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSave.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonSave.Location = new System.Drawing.Point(810, 700);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(96, 33);
			this.buttonSave.TabIndex = 17;
			this.buttonSave.Text = "Save";
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			this.buttonSave.Enabled = !(userType == UserType.ReadOnly);
			// 
			// textBoxEmail
			// 
			// 
			// 
			// 
			this.textBoxEmail.CustomButton.Image = null;
			this.textBoxEmail.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxEmail.CustomButton.Name = "";
			this.textBoxEmail.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxEmail.CustomButton.TabIndex = 1;
			this.textBoxEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxEmail.CustomButton.UseSelectable = true;
			this.textBoxEmail.CustomButton.Visible = false;
			this.textBoxEmail.Lines = new string[0];
			this.textBoxEmail.Location = new System.Drawing.Point(634, 159);
			this.textBoxEmail.MaxLength = 32767;
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.PasswordChar = '\0';
			this.textBoxEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxEmail.SelectedText = "";
			this.textBoxEmail.SelectionLength = 0;
			this.textBoxEmail.SelectionStart = 0;
			this.textBoxEmail.ShortcutsEnabled = true;
			this.textBoxEmail.Size = new System.Drawing.Size(360, 22);
			this.textBoxEmail.TabIndex = 11;
			this.textBoxEmail.UseSelectable = true;
			this.textBoxEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxAccount
			// 
			// 
			// 
			// 
			this.textBoxAccount.CustomButton.Image = null;
			this.textBoxAccount.CustomButton.Location = new System.Drawing.Point(306, 1);
			this.textBoxAccount.CustomButton.Name = "";
			this.textBoxAccount.CustomButton.Size = new System.Drawing.Size(53, 53);
			this.textBoxAccount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAccount.CustomButton.TabIndex = 1;
			this.textBoxAccount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAccount.CustomButton.UseSelectable = true;
			this.textBoxAccount.CustomButton.Visible = false;
			this.textBoxAccount.Lines = new string[0];
			this.textBoxAccount.Location = new System.Drawing.Point(152, 159);
			this.textBoxAccount.MaxLength = 32767;
			this.textBoxAccount.Multiline = true;
			this.textBoxAccount.Name = "textBoxAccount";
			this.textBoxAccount.PasswordChar = '\0';
			this.textBoxAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAccount.SelectedText = "";
			this.textBoxAccount.SelectionLength = 0;
			this.textBoxAccount.SelectionStart = 0;
			this.textBoxAccount.ShortcutsEnabled = true;
			this.textBoxAccount.Size = new System.Drawing.Size(360, 55);
			this.textBoxAccount.TabIndex = 3;
			this.textBoxAccount.UseSelectable = true;
			this.textBoxAccount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAccount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxAddress
			// 
			// 
			// 
			// 
			this.textBoxAddress.CustomButton.Image = null;
			this.textBoxAddress.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxAddress.CustomButton.Name = "";
			this.textBoxAddress.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAddress.CustomButton.TabIndex = 1;
			this.textBoxAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAddress.CustomButton.UseSelectable = true;
			this.textBoxAddress.CustomButton.Visible = false;
			this.textBoxAddress.Lines = new string[0];
			this.textBoxAddress.Location = new System.Drawing.Point(634, 95);
			this.textBoxAddress.MaxLength = 32767;
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.PasswordChar = '\0';
			this.textBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAddress.SelectedText = "";
			this.textBoxAddress.SelectionLength = 0;
			this.textBoxAddress.SelectionStart = 0;
			this.textBoxAddress.ShortcutsEnabled = true;
			this.textBoxAddress.Size = new System.Drawing.Size(360, 22);
			this.textBoxAddress.TabIndex = 9;
			this.textBoxAddress.UseSelectable = true;
			this.textBoxAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxPhone
			// 
			// 
			// 
			// 
			this.textBoxPhone.CustomButton.Image = null;
			this.textBoxPhone.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxPhone.CustomButton.Name = "";
			this.textBoxPhone.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPhone.CustomButton.TabIndex = 1;
			this.textBoxPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPhone.CustomButton.UseSelectable = true;
			this.textBoxPhone.CustomButton.Visible = false;
			this.textBoxPhone.Lines = new string[0];
			this.textBoxPhone.Location = new System.Drawing.Point(634, 63);
			this.textBoxPhone.MaxLength = 32767;
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.PasswordChar = '\0';
			this.textBoxPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPhone.SelectedText = "";
			this.textBoxPhone.SelectionLength = 0;
			this.textBoxPhone.SelectionStart = 0;
			this.textBoxPhone.ShortcutsEnabled = true;
			this.textBoxPhone.Size = new System.Drawing.Size(360, 22);
			this.textBoxPhone.TabIndex = 8;
			this.textBoxPhone.UseSelectable = true;
			this.textBoxPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxShortName
			// 
			// 
			// 
			// 
			this.textBoxShortName.CustomButton.Image = null;
			this.textBoxShortName.CustomButton.Location = new System.Drawing.Point(175, 2);
			this.textBoxShortName.CustomButton.Name = "";
			this.textBoxShortName.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxShortName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxShortName.CustomButton.TabIndex = 1;
			this.textBoxShortName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxShortName.CustomButton.UseSelectable = true;
			this.textBoxShortName.CustomButton.Visible = false;
			this.textBoxShortName.Lines = new string[0];
			this.textBoxShortName.Location = new System.Drawing.Point(152, 95);
			this.textBoxShortName.MaxLength = 32767;
			this.textBoxShortName.Name = "textBoxShortName";
			this.textBoxShortName.PasswordChar = '\0';
			this.textBoxShortName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxShortName.SelectedText = "";
			this.textBoxShortName.SelectionLength = 0;
			this.textBoxShortName.SelectionStart = 0;
			this.textBoxShortName.ShortcutsEnabled = true;
			this.textBoxShortName.Size = new System.Drawing.Size(195, 22);
			this.textBoxShortName.TabIndex = 1;
			this.textBoxShortName.UseSelectable = true;
			this.textBoxShortName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxShortName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxName
			// 
			// 
			// 
			// 
			this.textBoxName.CustomButton.Image = null;
			this.textBoxName.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxName.CustomButton.Name = "";
			this.textBoxName.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxName.CustomButton.TabIndex = 1;
			this.textBoxName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxName.CustomButton.UseSelectable = true;
			this.textBoxName.CustomButton.Visible = false;
			this.textBoxName.Lines = new string[0];
			this.textBoxName.Location = new System.Drawing.Point(152, 63);
			this.textBoxName.MaxLength = 32767;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.PasswordChar = '\0';
			this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxName.SelectedText = "";
			this.textBoxName.SelectionLength = 0;
			this.textBoxName.SelectionStart = 0;
			this.textBoxName.ShortcutsEnabled = true;
			this.textBoxName.Size = new System.Drawing.Size(360, 22);
			this.textBoxName.TabIndex = 0;
			this.textBoxName.UseSelectable = true;
			this.textBoxName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEmail.Location = new System.Drawing.Point(536, 159);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(44, 19);
			this.labelEmail.TabIndex = 6;
			this.labelEmail.Text = "Email:";
			// 
			// labelContactPerson
			// 
			this.labelContactPerson.AutoSize = true;
			this.labelContactPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelContactPerson.Location = new System.Drawing.Point(11, 162);
			this.labelContactPerson.Name = "labelContactPerson";
			this.labelContactPerson.Size = new System.Drawing.Size(92, 19);
			this.labelContactPerson.TabIndex = 5;
			this.labelContactPerson.Text = "Contc. Person:";
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddress.Location = new System.Drawing.Point(536, 95);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(59, 19);
			this.labelAddress.TabIndex = 4;
			this.labelAddress.Text = "Address:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhone.Location = new System.Drawing.Point(536, 63);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(49, 19);
			this.labelPhone.TabIndex = 7;
			this.labelPhone.Text = "Phone:";
			// 
			// labelShortName
			// 
			this.labelShortName.AutoSize = true;
			this.labelShortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelShortName.Location = new System.Drawing.Point(11, 95);
			this.labelShortName.Name = "labelShortName";
			this.labelShortName.Size = new System.Drawing.Size(84, 19);
			this.labelShortName.TabIndex = 9;
			this.labelShortName.Text = "Short Name:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelName.Location = new System.Drawing.Point(11, 63);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(48, 19);
			this.labelName.TabIndex = 8;
			this.labelName.Text = "Name:";
			// 
			// textBoxVendorCode
			// 
			// 
			// 
			// 
			this.textBoxVendorCode.CustomButton.Image = null;
			this.textBoxVendorCode.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxVendorCode.CustomButton.Name = "";
			this.textBoxVendorCode.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxVendorCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxVendorCode.CustomButton.TabIndex = 1;
			this.textBoxVendorCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxVendorCode.CustomButton.UseSelectable = true;
			this.textBoxVendorCode.CustomButton.Visible = false;
			this.textBoxVendorCode.Lines = new string[0];
			this.textBoxVendorCode.Location = new System.Drawing.Point(152, 127);
			this.textBoxVendorCode.MaxLength = 32767;
			this.textBoxVendorCode.Name = "textBoxVendorCode";
			this.textBoxVendorCode.PasswordChar = '\0';
			this.textBoxVendorCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxVendorCode.SelectedText = "";
			this.textBoxVendorCode.SelectionLength = 0;
			this.textBoxVendorCode.SelectionStart = 0;
			this.textBoxVendorCode.ShortcutsEnabled = true;
			this.textBoxVendorCode.Size = new System.Drawing.Size(360, 22);
			this.textBoxVendorCode.TabIndex = 2;
			this.textBoxVendorCode.UseSelectable = true;
			this.textBoxVendorCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxVendorCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelVendorCode
			// 
			this.labelVendorCode.AutoSize = true;
			this.labelVendorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelVendorCode.Location = new System.Drawing.Point(11, 127);
			this.labelVendorCode.Name = "labelVendorCode";
			this.labelVendorCode.Size = new System.Drawing.Size(87, 19);
			this.labelVendorCode.TabIndex = 16;
			this.labelVendorCode.Text = "Vendor code:";
			// 
			// textBoxFax
			// 
			// 
			// 
			// 
			this.textBoxFax.CustomButton.Image = null;
			this.textBoxFax.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxFax.CustomButton.Name = "";
			this.textBoxFax.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxFax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxFax.CustomButton.TabIndex = 1;
			this.textBoxFax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxFax.CustomButton.UseSelectable = true;
			this.textBoxFax.CustomButton.Visible = false;
			this.textBoxFax.Lines = new string[0];
			this.textBoxFax.Location = new System.Drawing.Point(634, 191);
			this.textBoxFax.MaxLength = 32767;
			this.textBoxFax.Name = "textBoxFax";
			this.textBoxFax.PasswordChar = '\0';
			this.textBoxFax.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxFax.SelectedText = "";
			this.textBoxFax.SelectionLength = 0;
			this.textBoxFax.SelectionStart = 0;
			this.textBoxFax.ShortcutsEnabled = true;
			this.textBoxFax.Size = new System.Drawing.Size(360, 22);
			this.textBoxFax.TabIndex = 12;
			this.textBoxFax.UseSelectable = true;
			this.textBoxFax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxFax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelFax
			// 
			this.labelFax.AutoSize = true;
			this.labelFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFax.Location = new System.Drawing.Point(536, 191);
			this.labelFax.Name = "labelFax";
			this.labelFax.Size = new System.Drawing.Size(31, 19);
			this.labelFax.TabIndex = 18;
			this.labelFax.Text = "Fax:";
			// 
			// textBoxWebSite
			// 
			// 
			// 
			// 
			this.textBoxWebSite.CustomButton.Image = null;
			this.textBoxWebSite.CustomButton.Location = new System.Drawing.Point(340, 2);
			this.textBoxWebSite.CustomButton.Name = "";
			this.textBoxWebSite.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxWebSite.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxWebSite.CustomButton.TabIndex = 1;
			this.textBoxWebSite.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxWebSite.CustomButton.UseSelectable = true;
			this.textBoxWebSite.CustomButton.Visible = false;
			this.textBoxWebSite.Lines = new string[0];
			this.textBoxWebSite.Location = new System.Drawing.Point(634, 127);
			this.textBoxWebSite.MaxLength = 32767;
			this.textBoxWebSite.Name = "textBoxWebSite";
			this.textBoxWebSite.PasswordChar = '\0';
			this.textBoxWebSite.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxWebSite.SelectedText = "";
			this.textBoxWebSite.SelectionLength = 0;
			this.textBoxWebSite.SelectionStart = 0;
			this.textBoxWebSite.ShortcutsEnabled = true;
			this.textBoxWebSite.Size = new System.Drawing.Size(360, 22);
			this.textBoxWebSite.TabIndex = 10;
			this.textBoxWebSite.UseSelectable = true;
			this.textBoxWebSite.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxWebSite.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelWebSite
			// 
			this.labelWebSite.AutoSize = true;
			this.labelWebSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWebSite.Location = new System.Drawing.Point(536, 127);
			this.labelWebSite.Name = "labelWebSite";
			this.labelWebSite.Size = new System.Drawing.Size(62, 19);
			this.labelWebSite.TabIndex = 20;
			this.labelWebSite.Text = "Web site:";
			// 
			// checkBoxApproved
			// 
			this.checkBoxApproved.AutoSize = true;
			this.checkBoxApproved.Location = new System.Drawing.Point(634, 222);
			this.checkBoxApproved.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxApproved.Name = "checkBoxApproved";
			this.checkBoxApproved.Size = new System.Drawing.Size(75, 15);
			this.checkBoxApproved.TabIndex = 13;
			this.checkBoxApproved.Text = "Approved";
			this.checkBoxApproved.UseSelectable = true;
			// 
			// panelLabelImages
			// 
			this.panelLabelImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelLabelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLabelImages.Controls.Add(this.ButtonAddDoc);
			this.panelLabelImages.Controls.Add(this.buttonDeleteDoc);
			this.panelLabelImages.Controls.Add(this.labelImageCaption);
			this.panelLabelImages.Location = new System.Drawing.Point(5, 340);
			this.panelLabelImages.Margin = new System.Windows.Forms.Padding(2);
			this.panelLabelImages.Name = "panelLabelImages";
			this.panelLabelImages.Size = new System.Drawing.Size(989, 30);
			this.panelLabelImages.TabIndex = 4;
			// 
			// ButtonAddDoc
			// 
			this.ButtonAddDoc.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAddDoc.ActiveBackgroundImage = null;
			this.ButtonAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonAddDoc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAddDoc.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonAddDoc.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonAddDoc.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAddDoc.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAddDoc.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
			this.ButtonAddDoc.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAddDoc.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.ButtonAddDoc.Location = new System.Drawing.Point(910, -4);
			this.ButtonAddDoc.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonAddDoc.Name = "ButtonAddDoc";
			this.ButtonAddDoc.NormalBackgroundImage = null;
			this.ButtonAddDoc.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAddDoc.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAddDoc.ShowToolTip = true;
			this.ButtonAddDoc.Size = new System.Drawing.Size(35, 35);
			this.ButtonAddDoc.TabIndex = 0;
			this.ButtonAddDoc.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAddDoc.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAddDoc.TextMain = "";
			this.ButtonAddDoc.TextSecondary = "";
			this.ButtonAddDoc.ToolTipText = "Add Item";
			this.ButtonAddDoc.Click += new System.EventHandler(this.ButtonAddFileClick);
			this.ButtonAddDoc.Enabled = !(userType == UserType.ReadOnly);
			// 
			// buttonDeleteDoc
			// 
			this.buttonDeleteDoc.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonDeleteDoc.ActiveBackgroundImage = null;
			this.buttonDeleteDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeleteDoc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDeleteDoc.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.buttonDeleteDoc.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonDeleteDoc.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.buttonDeleteDoc.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonDeleteDoc.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.buttonDeleteDoc.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDeleteDoc.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIconGraySmall;
			this.buttonDeleteDoc.Location = new System.Drawing.Point(953, -3);
			this.buttonDeleteDoc.Margin = new System.Windows.Forms.Padding(5);
			this.buttonDeleteDoc.Name = "buttonDeleteDoc";
			this.buttonDeleteDoc.NormalBackgroundImage = null;
			this.buttonDeleteDoc.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteDoc.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDeleteDoc.ShowToolTip = true;
			this.buttonDeleteDoc.Size = new System.Drawing.Size(35, 35);
			this.buttonDeleteDoc.TabIndex = 1;
			this.buttonDeleteDoc.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteDoc.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteDoc.TextMain = "";
			this.buttonDeleteDoc.TextSecondary = "";
			this.buttonDeleteDoc.ToolTipText = "Delete";
			this.buttonDeleteDoc.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteDoc.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// labelImageCaption
			// 
			this.labelImageCaption.AutoSize = true;
			this.labelImageCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelImageCaption.Location = new System.Drawing.Point(436, 1);
			this.labelImageCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelImageCaption.Name = "labelImageCaption";
			this.labelImageCaption.Size = new System.Drawing.Size(34, 19);
			this.labelImageCaption.TabIndex = 3;
			this.labelImageCaption.Text = "Files";
			this.labelImageCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(802, 1);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(39, 39);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(152, 288);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(842, 41);
			this.textBoxRemarks.TabIndex = 14;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(11, 288);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(62, 19);
			this.labelRemarks.TabIndex = 29;
			this.labelRemarks.Text = "Remarks:";
			// 
			// buttonFormCertificate
			// 
			this.buttonFormCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFormCertificate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFormCertificate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonFormCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonFormCertificate.Location = new System.Drawing.Point(4, 700);
			this.buttonFormCertificate.Name = "buttonFormCertificate";
			this.buttonFormCertificate.Size = new System.Drawing.Size(141, 33);
			this.buttonFormCertificate.TabIndex = 16;
			this.buttonFormCertificate.Text = "Form Certificate";
			this.buttonFormCertificate.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(11, 218);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 19);
			this.label1.TabIndex = 42;
			this.label1.Text = "Supplier Type:";
			// 
			// comboBoxSupplierClass
			// 
			this.comboBoxSupplierClass.Displayer = null;
			this.comboBoxSupplierClass.DisplayerText = null;
			this.comboBoxSupplierClass.DropDownHeight = 256;
			this.comboBoxSupplierClass.Entity = null;
			this.comboBoxSupplierClass.Location = new System.Drawing.Point(152, 219);
			this.comboBoxSupplierClass.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxSupplierClass.Name = "comboBoxSupplierClass";
			this.comboBoxSupplierClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxSupplierClass.RootNodesNames = null;
			this.comboBoxSupplierClass.Size = new System.Drawing.Size(360, 21);
			this.comboBoxSupplierClass.TabIndex = 41;
			// 
			// documentationListView
			// 
			this.documentationListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.documentationListView.Displayer = null;
			this.documentationListView.DisplayerText = null;
			this.documentationListView.Entity = null;
			this.documentationListView.Location = new System.Drawing.Point(5, 373);
			this.documentationListView.Margin = new System.Windows.Forms.Padding(4);
			this.documentationListView.Name = "documentationListView";
			this.documentationListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.documentationListView.Size = new System.Drawing.Size(989, 142);
			this.documentationListView.TabIndex = 15;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(4, 544);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(990, 152);
			this.dataGridViewControlSuppliers.TabIndex = 126;
			// 
			// labelSupplier
			// 
			this.labelSupplier.AutoSize = true;
			this.labelSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplier.Location = new System.Drawing.Point(427, 513);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(77, 19);
			this.labelSupplier.TabIndex = 125;
			this.labelSupplier.Text = "PRODUCTS";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSubject
			// 
			// 
			// 
			// 
			this.textBoxSubject.CustomButton.Image = null;
			this.textBoxSubject.CustomButton.Location = new System.Drawing.Point(802, 1);
			this.textBoxSubject.CustomButton.Name = "";
			this.textBoxSubject.CustomButton.Size = new System.Drawing.Size(39, 39);
			this.textBoxSubject.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSubject.CustomButton.TabIndex = 1;
			this.textBoxSubject.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSubject.CustomButton.UseSelectable = true;
			this.textBoxSubject.CustomButton.Visible = false;
			this.textBoxSubject.Lines = new string[0];
			this.textBoxSubject.Location = new System.Drawing.Point(152, 244);
			this.textBoxSubject.MaxLength = 32767;
			this.textBoxSubject.Multiline = true;
			this.textBoxSubject.Name = "textBoxSubject";
			this.textBoxSubject.PasswordChar = '\0';
			this.textBoxSubject.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSubject.SelectedText = "";
			this.textBoxSubject.SelectionLength = 0;
			this.textBoxSubject.SelectionStart = 0;
			this.textBoxSubject.ShortcutsEnabled = true;
			this.textBoxSubject.Size = new System.Drawing.Size(842, 41);
			this.textBoxSubject.TabIndex = 127;
			this.textBoxSubject.UseSelectable = true;
			this.textBoxSubject.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSubject.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(11, 244);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 19);
			this.label2.TabIndex = 128;
			this.label2.Text = "Subject:";
			// 
			// textBoxAirCode
			// 
			// 
			// 
			// 
			this.textBoxAirCode.CustomButton.Image = null;
			this.textBoxAirCode.CustomButton.Location = new System.Drawing.Point(64, 2);
			this.textBoxAirCode.CustomButton.Name = "";
			this.textBoxAirCode.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxAirCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAirCode.CustomButton.TabIndex = 1;
			this.textBoxAirCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAirCode.CustomButton.UseSelectable = true;
			this.textBoxAirCode.CustomButton.Visible = false;
			this.textBoxAirCode.Lines = new string[0];
			this.textBoxAirCode.Location = new System.Drawing.Point(428, 95);
			this.textBoxAirCode.MaxLength = 32767;
			this.textBoxAirCode.Name = "textBoxAirCode";
			this.textBoxAirCode.PasswordChar = '\0';
			this.textBoxAirCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAirCode.SelectedText = "";
			this.textBoxAirCode.SelectionLength = 0;
			this.textBoxAirCode.SelectionStart = 0;
			this.textBoxAirCode.ShortcutsEnabled = true;
			this.textBoxAirCode.Size = new System.Drawing.Size(84, 22);
			this.textBoxAirCode.TabIndex = 129;
			this.textBoxAirCode.UseSelectable = true;
			this.textBoxAirCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAirCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(357, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 19);
			this.label3.TabIndex = 130;
			this.label3.Text = "Air Code:";
			// 
			// SupplierForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(1003, 744);
			this.Controls.Add(this.textBoxAirCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxSubject);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridViewControlSuppliers);
			this.Controls.Add(this.labelSupplier);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSupplierClass);
			this.Controls.Add(this.buttonFormCertificate);
			this.Controls.Add(this.documentationListView);
			this.Controls.Add(this.panelLabelImages);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.checkBoxApproved);
			this.Controls.Add(this.textBoxWebSite);
			this.Controls.Add(this.labelWebSite);
			this.Controls.Add(this.textBoxFax);
			this.Controls.Add(this.labelFax);
			this.Controls.Add(this.textBoxVendorCode);
			this.Controls.Add(this.labelVendorCode);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.textBoxAccount);
			this.Controls.Add(this.textBoxAddress);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxShortName);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelContactPerson);
			this.Controls.Add(this.labelAddress);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelShortName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SupplierForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Supplier/Provider Form";
			this.panelLabelImages.ResumeLayout(false);
			this.panelLabelImages.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private MetroTextBox textBoxEmail;
        private MetroTextBox textBoxAccount;
        private MetroTextBox textBoxAddress;
        private MetroTextBox textBoxPhone;
        private MetroTextBox textBoxShortName;
        private MetroTextBox textBoxName;
        private MetroLabel labelEmail;
        private MetroLabel labelContactPerson;
        private MetroLabel labelAddress;
        private MetroLabel labelPhone;
        private MetroLabel labelShortName;
        private MetroLabel labelName;
        private MetroTextBox textBoxVendorCode;
        private MetroLabel labelVendorCode;
        private MetroTextBox textBoxFax;
        private MetroLabel labelFax;
        private MetroTextBox textBoxWebSite;
        private MetroLabel labelWebSite;
        private MetroCheckBox checkBoxApproved;
        private System.Windows.Forms.Panel panelLabelImages;
        private MetroLabel labelImageCaption;
        private MetroTextBox textBoxRemarks;
        private MetroLabel labelRemarks;
        private AvControls.AvButtonT.AvButtonT ButtonAddDoc;
        private AvControls.AvButtonT.AvButtonT buttonDeleteDoc;
        private DocumentationControls.DocumentationListView documentationListView;
        private System.Windows.Forms.Button buttonFormCertificate;
		private Auxiliary.TreeDictionaryComboBox comboBoxSupplierClass;
		private MetroLabel label1;
		private CAASupplierCourseListView dataGridViewControlSuppliers;
		private MetroLabel labelSupplier;
		private MetroTextBox textBoxSubject;
		private MetroLabel label2;
		private MetroTextBox textBoxAirCode;
		private MetroLabel label3;
	}
}