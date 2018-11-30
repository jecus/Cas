namespace CAS.UI.UIControls.SupplierControls
{
    partial class SupplierForm
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxAccount = new System.Windows.Forms.TextBox();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.textBoxShortName = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelContactPerson = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelShortName = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxVendorCode = new System.Windows.Forms.TextBox();
			this.labelVendorCode = new System.Windows.Forms.Label();
			this.textBoxFax = new System.Windows.Forms.TextBox();
			this.labelFax = new System.Windows.Forms.Label();
			this.textBoxWebSite = new System.Windows.Forms.TextBox();
			this.labelWebSite = new System.Windows.Forms.Label();
			this.checkBoxApproved = new System.Windows.Forms.CheckBox();
			this.panelLabelImages = new System.Windows.Forms.Panel();
			this.ButtonAddDoc = new AvControls.AvButtonT.AvButtonT();
			this.buttonDeleteDoc = new AvControls.AvButtonT.AvButtonT();
			this.labelImageCaption = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.buttonFormCertificate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxSupplierClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.documentationListView = new CAS.UI.UIControls.DocumentationControls.DocumentationListView();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.labelSupplier = new System.Windows.Forms.Label();
			this.textBoxSubject = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxAirCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panelLabelImages.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.buttonCancel.Location = new System.Drawing.Point(912, 624);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(78, 23);
			this.buttonCancel.TabIndex = 18;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.buttonSave.Location = new System.Drawing.Point(851, 624);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(55, 23);
			this.buttonSave.TabIndex = 17;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxEmail.Location = new System.Drawing.Point(633, 105);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(360, 22);
			this.textBoxEmail.TabIndex = 11;
			// 
			// textBoxAccount
			// 
			this.textBoxAccount.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxAccount.Location = new System.Drawing.Point(151, 105);
			this.textBoxAccount.Multiline = true;
			this.textBoxAccount.Name = "textBoxAccount";
			this.textBoxAccount.Size = new System.Drawing.Size(360, 55);
			this.textBoxAccount.TabIndex = 3;
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxAddress.Location = new System.Drawing.Point(633, 41);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(360, 22);
			this.textBoxAddress.TabIndex = 9;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxPhone.Location = new System.Drawing.Point(633, 9);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(360, 22);
			this.textBoxPhone.TabIndex = 8;
			// 
			// textBoxShortName
			// 
			this.textBoxShortName.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxShortName.Location = new System.Drawing.Point(151, 41);
			this.textBoxShortName.Name = "textBoxShortName";
			this.textBoxShortName.Size = new System.Drawing.Size(195, 22);
			this.textBoxShortName.TabIndex = 1;
			// 
			// textBoxName
			// 
			this.textBoxName.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxName.Location = new System.Drawing.Point(151, 9);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(360, 22);
			this.textBoxName.TabIndex = 0;
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEmail.Location = new System.Drawing.Point(535, 108);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(47, 16);
			this.labelEmail.TabIndex = 6;
			this.labelEmail.Text = "Email:";
			// 
			// labelContactPerson
			// 
			this.labelContactPerson.AutoSize = true;
			this.labelContactPerson.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelContactPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelContactPerson.Location = new System.Drawing.Point(10, 111);
			this.labelContactPerson.Name = "labelContactPerson";
			this.labelContactPerson.Size = new System.Drawing.Size(107, 16);
			this.labelContactPerson.TabIndex = 5;
			this.labelContactPerson.Text = "Contc. Person:";
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddress.Location = new System.Drawing.Point(535, 44);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(66, 16);
			this.labelAddress.TabIndex = 4;
			this.labelAddress.Text = "Address:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhone.Location = new System.Drawing.Point(535, 12);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(54, 16);
			this.labelPhone.TabIndex = 7;
			this.labelPhone.Text = "Phone:";
			// 
			// labelShortName
			// 
			this.labelShortName.AutoSize = true;
			this.labelShortName.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelShortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelShortName.Location = new System.Drawing.Point(10, 44);
			this.labelShortName.Name = "labelShortName";
			this.labelShortName.Size = new System.Drawing.Size(91, 16);
			this.labelShortName.TabIndex = 9;
			this.labelShortName.Text = "Short Name:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelName.Location = new System.Drawing.Point(10, 14);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(50, 16);
			this.labelName.TabIndex = 8;
			this.labelName.Text = "Name:";
			// 
			// textBoxVendorCode
			// 
			this.textBoxVendorCode.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxVendorCode.Location = new System.Drawing.Point(151, 73);
			this.textBoxVendorCode.Name = "textBoxVendorCode";
			this.textBoxVendorCode.Size = new System.Drawing.Size(360, 22);
			this.textBoxVendorCode.TabIndex = 2;
			// 
			// labelVendorCode
			// 
			this.labelVendorCode.AutoSize = true;
			this.labelVendorCode.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelVendorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelVendorCode.Location = new System.Drawing.Point(10, 76);
			this.labelVendorCode.Name = "labelVendorCode";
			this.labelVendorCode.Size = new System.Drawing.Size(96, 16);
			this.labelVendorCode.TabIndex = 16;
			this.labelVendorCode.Text = "Vendor code:";
			// 
			// textBoxFax
			// 
			this.textBoxFax.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxFax.Location = new System.Drawing.Point(633, 137);
			this.textBoxFax.Name = "textBoxFax";
			this.textBoxFax.Size = new System.Drawing.Size(360, 22);
			this.textBoxFax.TabIndex = 12;
			// 
			// labelFax
			// 
			this.labelFax.AutoSize = true;
			this.labelFax.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFax.Location = new System.Drawing.Point(535, 140);
			this.labelFax.Name = "labelFax";
			this.labelFax.Size = new System.Drawing.Size(36, 16);
			this.labelFax.TabIndex = 18;
			this.labelFax.Text = "Fax:";
			// 
			// textBoxWebSite
			// 
			this.textBoxWebSite.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxWebSite.Location = new System.Drawing.Point(633, 73);
			this.textBoxWebSite.Name = "textBoxWebSite";
			this.textBoxWebSite.Size = new System.Drawing.Size(360, 22);
			this.textBoxWebSite.TabIndex = 10;
			// 
			// labelWebSite
			// 
			this.labelWebSite.AutoSize = true;
			this.labelWebSite.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelWebSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWebSite.Location = new System.Drawing.Point(535, 76);
			this.labelWebSite.Name = "labelWebSite";
			this.labelWebSite.Size = new System.Drawing.Size(71, 16);
			this.labelWebSite.TabIndex = 20;
			this.labelWebSite.Text = "Web site:";
			// 
			// checkBoxApproved
			// 
			this.checkBoxApproved.AutoSize = true;
			this.checkBoxApproved.Location = new System.Drawing.Point(633, 168);
			this.checkBoxApproved.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxApproved.Name = "checkBoxApproved";
			this.checkBoxApproved.Size = new System.Drawing.Size(72, 17);
			this.checkBoxApproved.TabIndex = 13;
			this.checkBoxApproved.Text = "Approved";
			this.checkBoxApproved.UseVisualStyleBackColor = true;
			// 
			// panelLabelImages
			// 
			this.panelLabelImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelLabelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLabelImages.Controls.Add(this.ButtonAddDoc);
			this.panelLabelImages.Controls.Add(this.buttonDeleteDoc);
			this.panelLabelImages.Controls.Add(this.labelImageCaption);
			this.panelLabelImages.Location = new System.Drawing.Point(4, 286);
			this.panelLabelImages.Margin = new System.Windows.Forms.Padding(2);
			this.panelLabelImages.Name = "panelLabelImages";
			this.panelLabelImages.Size = new System.Drawing.Size(991, 30);
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
			this.ButtonAddDoc.Location = new System.Drawing.Point(912, -4);
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
			this.buttonDeleteDoc.Location = new System.Drawing.Point(955, -3);
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
			// 
			// labelImageCaption
			// 
			this.labelImageCaption.AutoSize = true;
			this.labelImageCaption.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelImageCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelImageCaption.Location = new System.Drawing.Point(436, 1);
			this.labelImageCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelImageCaption.Name = "labelImageCaption";
			this.labelImageCaption.Size = new System.Drawing.Size(46, 18);
			this.labelImageCaption.TabIndex = 3;
			this.labelImageCaption.Text = "Files";
			this.labelImageCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxRemarks.Location = new System.Drawing.Point(151, 234);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(842, 41);
			this.textBoxRemarks.TabIndex = 14;
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(12, 234);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(68, 16);
			this.labelRemarks.TabIndex = 29;
			this.labelRemarks.Text = "Remarks:";
			// 
			// buttonFormCertificate
			// 
			this.buttonFormCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonFormCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.buttonFormCertificate.Location = new System.Drawing.Point(4, 624);
			this.buttonFormCertificate.Name = "buttonFormCertificate";
			this.buttonFormCertificate.Size = new System.Drawing.Size(141, 23);
			this.buttonFormCertificate.TabIndex = 16;
			this.buttonFormCertificate.Text = "Form Certificate";
			this.buttonFormCertificate.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(10, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 16);
			this.label1.TabIndex = 42;
			this.label1.Text = "Supplier Type:";
			// 
			// comboBoxSupplierClass
			// 
			this.comboBoxSupplierClass.Displayer = null;
			this.comboBoxSupplierClass.DisplayerText = null;
			this.comboBoxSupplierClass.DropDownHeight = 256;
			this.comboBoxSupplierClass.Entity = null;
			this.comboBoxSupplierClass.Location = new System.Drawing.Point(151, 165);
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
			this.documentationListView.IgnoreAutoResize = false;
			this.documentationListView.Location = new System.Drawing.Point(4, 319);
			this.documentationListView.Margin = new System.Windows.Forms.Padding(4);
			this.documentationListView.Name = "documentationListView";
			this.documentationListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.documentationListView.ShowGroups = true;
			this.documentationListView.Size = new System.Drawing.Size(989, 142);
			this.documentationListView.TabIndex = 15;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(3, 470);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowAddNew = false;
			this.dataGridViewControlSuppliers.ShowDelete = false;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(990, 152);
			this.dataGridViewControlSuppliers.TabIndex = 126;
			// 
			// labelSupplier
			// 
			this.labelSupplier.AutoSize = true;
			this.labelSupplier.Font = new System.Drawing.Font("Verdana", 12F);
			this.labelSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplier.Location = new System.Drawing.Point(426, 449);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(97, 18);
			this.labelSupplier.TabIndex = 125;
			this.labelSupplier.Text = "PRODUCTS";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSubject
			// 
			this.textBoxSubject.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxSubject.Location = new System.Drawing.Point(151, 190);
			this.textBoxSubject.Multiline = true;
			this.textBoxSubject.Name = "textBoxSubject";
			this.textBoxSubject.Size = new System.Drawing.Size(842, 41);
			this.textBoxSubject.TabIndex = 127;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(12, 190);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 128;
			this.label2.Text = "Subject:";
			// 
			// textBoxAirCode
			// 
			this.textBoxAirCode.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxAirCode.Location = new System.Drawing.Point(427, 41);
			this.textBoxAirCode.Name = "textBoxAirCode";
			this.textBoxAirCode.Size = new System.Drawing.Size(84, 22);
			this.textBoxAirCode.TabIndex = 129;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(352, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 16);
			this.label3.TabIndex = 130;
			this.label3.Text = "Air Code:";
			// 
			// SupplierForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(1003, 659);
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
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Supplier Form";
			this.panelLabelImages.ResumeLayout(false);
			this.panelLabelImages.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxShortName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelContactPerson;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelShortName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxVendorCode;
        private System.Windows.Forms.Label labelVendorCode;
        private System.Windows.Forms.TextBox textBoxFax;
        private System.Windows.Forms.Label labelFax;
        private System.Windows.Forms.TextBox textBoxWebSite;
        private System.Windows.Forms.Label labelWebSite;
        private System.Windows.Forms.CheckBox checkBoxApproved;
        private System.Windows.Forms.Panel panelLabelImages;
        private System.Windows.Forms.Label labelImageCaption;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelRemarks;
        private AvControls.AvButtonT.AvButtonT ButtonAddDoc;
        private AvControls.AvButtonT.AvButtonT buttonDeleteDoc;
        private DocumentationControls.DocumentationListView documentationListView;
        private System.Windows.Forms.Button buttonFormCertificate;
		private Auxiliary.TreeDictionaryComboBox comboBoxSupplierClass;
		private System.Windows.Forms.Label label1;
		private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
		private System.Windows.Forms.Label labelSupplier;
		private System.Windows.Forms.TextBox textBoxSubject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxAirCode;
		private System.Windows.Forms.Label label3;
	}
}