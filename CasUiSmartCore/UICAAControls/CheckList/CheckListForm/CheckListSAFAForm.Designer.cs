using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList.CheckListForm
{
    partial class CheckListSAFAForm
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
            System.Windows.Forms.Label metroLabel1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            this.metroTextSource = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxItem = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxItemNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxInspectionTitle = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxStandard = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxStandardText = new MetroFramework.Controls.MetroTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.metroTextBoxMH = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxProgramType = new MetroFramework.Controls.MetroTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.metroTextBoxFindings = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxInstruction = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxStandardRef = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPdfCode = new MetroFramework.Controls.MetroTextBox();
            metroLabel1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(5, 65);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(55, 14);
            metroLabel1.TabIndex = 16;
            metroLabel1.Text = "Source:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(6, 199);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 14);
            label3.TabIndex = 22;
            label3.Text = "Inspection Item:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(6, 226);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(108, 14);
            label4.TabIndex = 25;
            label4.Text = "Inspection Title:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Verdana", 9F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label5.Location = new System.Drawing.Point(8, 251);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 14);
            label5.TabIndex = 28;
            label5.Text = "Standard:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Verdana", 9F);
            label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label11.Location = new System.Drawing.Point(726, 46);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(103, 14);
            label11.TabIndex = 42;
            label11.Text = "StandardS Text";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Verdana", 9F);
            label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label17.Location = new System.Drawing.Point(5, 140);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(70, 14);
            label17.TabIndex = 316;
            label17.Text = "Category:";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Verdana", 9F);
            label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label19.Location = new System.Drawing.Point(8, 173);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(31, 14);
            label19.TabIndex = 321;
            label19.Text = "MH:";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(5, 111);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 14);
            label1.TabIndex = 323;
            label1.Text = "Program Type:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(726, 396);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(143, 14);
            label2.TabIndex = 325;
            label2.Text = "Pre-described Finding";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Verdana", 9F);
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label7.Location = new System.Drawing.Point(652, 501);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(321, 14);
            label7.TabIndex = 327;
            label7.Text = "Instruction for completing the detailed description";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 9F);
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label6.Location = new System.Drawing.Point(8, 278);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(94, 14);
            label6.TabIndex = 329;
            label6.Text = "Standard Ref:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Verdana", 9F);
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label8.Location = new System.Drawing.Point(8, 366);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(73, 14);
            label8.TabIndex = 331;
            label8.Text = "PDF Code:";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextSource
            // 
            // 
            // 
            // 
            this.metroTextSource.CustomButton.Image = null;
            this.metroTextSource.CustomButton.Location = new System.Drawing.Point(309, 1);
            this.metroTextSource.CustomButton.Name = "";
            this.metroTextSource.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.metroTextSource.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextSource.CustomButton.TabIndex = 1;
            this.metroTextSource.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextSource.CustomButton.UseSelectable = true;
            this.metroTextSource.CustomButton.Visible = false;
            this.metroTextSource.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextSource.Lines = new string[0];
            this.metroTextSource.Location = new System.Drawing.Point(133, 63);
            this.metroTextSource.MaxLength = 32767;
            this.metroTextSource.Multiline = true;
            this.metroTextSource.Name = "metroTextSource";
            this.metroTextSource.PasswordChar = '\0';
            this.metroTextSource.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextSource.SelectedText = "";
            this.metroTextSource.SelectionLength = 0;
            this.metroTextSource.SelectionStart = 0;
            this.metroTextSource.ShortcutsEnabled = true;
            this.metroTextSource.Size = new System.Drawing.Size(347, 39);
            this.metroTextSource.TabIndex = 17;
            this.metroTextSource.UseSelectable = true;
            this.metroTextSource.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextSource.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxItem
            // 
            // 
            // 
            // 
            this.metroTextBoxItem.CustomButton.Image = null;
            this.metroTextBoxItem.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxItem.CustomButton.Name = "";
            this.metroTextBoxItem.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxItem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxItem.CustomButton.TabIndex = 1;
            this.metroTextBoxItem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxItem.CustomButton.UseSelectable = true;
            this.metroTextBoxItem.CustomButton.Visible = false;
            this.metroTextBoxItem.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxItem.Lines = new string[0];
            this.metroTextBoxItem.Location = new System.Drawing.Point(133, 192);
            this.metroTextBoxItem.MaxLength = 32767;
            this.metroTextBoxItem.Multiline = true;
            this.metroTextBoxItem.Name = "metroTextBoxItem";
            this.metroTextBoxItem.PasswordChar = '\0';
            this.metroTextBoxItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxItem.SelectedText = "";
            this.metroTextBoxItem.SelectionLength = 0;
            this.metroTextBoxItem.SelectionStart = 0;
            this.metroTextBoxItem.ShortcutsEnabled = true;
            this.metroTextBoxItem.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxItem.TabIndex = 23;
            this.metroTextBoxItem.UseSelectable = true;
            this.metroTextBoxItem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxItem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxItemNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxItemNumber.CustomButton.Image = null;
            this.metroTextBoxItemNumber.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.metroTextBoxItemNumber.CustomButton.Name = "";
            this.metroTextBoxItemNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxItemNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxItemNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxItemNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxItemNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxItemNumber.CustomButton.Visible = false;
            this.metroTextBoxItemNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxItemNumber.Lines = new string[0];
            this.metroTextBoxItemNumber.Location = new System.Drawing.Point(206, 192);
            this.metroTextBoxItemNumber.MaxLength = 32767;
            this.metroTextBoxItemNumber.Multiline = true;
            this.metroTextBoxItemNumber.Name = "metroTextBoxItemNumber";
            this.metroTextBoxItemNumber.PasswordChar = '\0';
            this.metroTextBoxItemNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxItemNumber.SelectedText = "";
            this.metroTextBoxItemNumber.SelectionLength = 0;
            this.metroTextBoxItemNumber.SelectionStart = 0;
            this.metroTextBoxItemNumber.ShortcutsEnabled = true;
            this.metroTextBoxItemNumber.Size = new System.Drawing.Size(274, 21);
            this.metroTextBoxItemNumber.TabIndex = 24;
            this.metroTextBoxItemNumber.UseSelectable = true;
            this.metroTextBoxItemNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxItemNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxInspectionTitle
            // 
            // 
            // 
            // 
            this.metroTextBoxInspectionTitle.CustomButton.Image = null;
            this.metroTextBoxInspectionTitle.CustomButton.Location = new System.Drawing.Point(327, 1);
            this.metroTextBoxInspectionTitle.CustomButton.Name = "";
            this.metroTextBoxInspectionTitle.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxInspectionTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxInspectionTitle.CustomButton.TabIndex = 1;
            this.metroTextBoxInspectionTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxInspectionTitle.CustomButton.UseSelectable = true;
            this.metroTextBoxInspectionTitle.CustomButton.Visible = false;
            this.metroTextBoxInspectionTitle.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxInspectionTitle.Lines = new string[0];
            this.metroTextBoxInspectionTitle.Location = new System.Drawing.Point(133, 219);
            this.metroTextBoxInspectionTitle.MaxLength = 32767;
            this.metroTextBoxInspectionTitle.Multiline = true;
            this.metroTextBoxInspectionTitle.Name = "metroTextBoxInspectionTitle";
            this.metroTextBoxInspectionTitle.PasswordChar = '\0';
            this.metroTextBoxInspectionTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxInspectionTitle.SelectedText = "";
            this.metroTextBoxInspectionTitle.SelectionLength = 0;
            this.metroTextBoxInspectionTitle.SelectionStart = 0;
            this.metroTextBoxInspectionTitle.ShortcutsEnabled = true;
            this.metroTextBoxInspectionTitle.Size = new System.Drawing.Size(347, 21);
            this.metroTextBoxInspectionTitle.TabIndex = 27;
            this.metroTextBoxInspectionTitle.UseSelectable = true;
            this.metroTextBoxInspectionTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxInspectionTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxStandard
            // 
            // 
            // 
            // 
            this.metroTextBoxStandard.CustomButton.Image = null;
            this.metroTextBoxStandard.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.metroTextBoxStandard.CustomButton.Name = "";
            this.metroTextBoxStandard.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxStandard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxStandard.CustomButton.TabIndex = 1;
            this.metroTextBoxStandard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxStandard.CustomButton.UseSelectable = true;
            this.metroTextBoxStandard.CustomButton.Visible = false;
            this.metroTextBoxStandard.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxStandard.Lines = new string[0];
            this.metroTextBoxStandard.Location = new System.Drawing.Point(133, 246);
            this.metroTextBoxStandard.MaxLength = 32767;
            this.metroTextBoxStandard.Multiline = true;
            this.metroTextBoxStandard.Name = "metroTextBoxStandard";
            this.metroTextBoxStandard.PasswordChar = '\0';
            this.metroTextBoxStandard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxStandard.SelectedText = "";
            this.metroTextBoxStandard.SelectionLength = 0;
            this.metroTextBoxStandard.SelectionStart = 0;
            this.metroTextBoxStandard.ShortcutsEnabled = true;
            this.metroTextBoxStandard.Size = new System.Drawing.Size(121, 21);
            this.metroTextBoxStandard.TabIndex = 29;
            this.metroTextBoxStandard.UseSelectable = true;
            this.metroTextBoxStandard.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxStandard.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxStandardText
            // 
            // 
            // 
            // 
            this.metroTextBoxStandardText.CustomButton.Image = null;
            this.metroTextBoxStandardText.CustomButton.Location = new System.Drawing.Point(262, 1);
            this.metroTextBoxStandardText.CustomButton.Name = "";
            this.metroTextBoxStandardText.CustomButton.Size = new System.Drawing.Size(329, 329);
            this.metroTextBoxStandardText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxStandardText.CustomButton.TabIndex = 1;
            this.metroTextBoxStandardText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxStandardText.CustomButton.UseSelectable = true;
            this.metroTextBoxStandardText.CustomButton.Visible = false;
            this.metroTextBoxStandardText.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxStandardText.Lines = new string[0];
            this.metroTextBoxStandardText.Location = new System.Drawing.Point(486, 63);
            this.metroTextBoxStandardText.MaxLength = 32767;
            this.metroTextBoxStandardText.Multiline = true;
            this.metroTextBoxStandardText.Name = "metroTextBoxStandardText";
            this.metroTextBoxStandardText.PasswordChar = '\0';
            this.metroTextBoxStandardText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxStandardText.SelectedText = "";
            this.metroTextBoxStandardText.SelectionLength = 0;
            this.metroTextBoxStandardText.SelectionStart = 0;
            this.metroTextBoxStandardText.ShortcutsEnabled = true;
            this.metroTextBoxStandardText.Size = new System.Drawing.Size(592, 331);
            this.metroTextBoxStandardText.TabIndex = 43;
            this.metroTextBoxStandardText.UseSelectable = true;
            this.metroTextBoxStandardText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxStandardText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1196, 620);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 299;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1277, 620);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 298;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxCategory.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(133, 135);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 22);
            this.comboBoxCategory.TabIndex = 317;
            // 
            // fileControl
            // 
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.IconNotEnabled = null;
            this.fileControl.Location = new System.Drawing.Point(8, 388);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "fileControl";
            this.fileControl.ShowLinkLabelBrowse = true;
            this.fileControl.ShowLinkLabelRemove = false;
            this.fileControl.Size = new System.Drawing.Size(350, 100);
            this.fileControl.TabIndex = 302;
            // 
            // metroTextBoxMH
            // 
            // 
            // 
            // 
            this.metroTextBoxMH.CustomButton.Image = null;
            this.metroTextBoxMH.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.metroTextBoxMH.CustomButton.Name = "";
            this.metroTextBoxMH.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxMH.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxMH.CustomButton.TabIndex = 1;
            this.metroTextBoxMH.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxMH.CustomButton.UseSelectable = true;
            this.metroTextBoxMH.CustomButton.Visible = false;
            this.metroTextBoxMH.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxMH.Lines = new string[0];
            this.metroTextBoxMH.Location = new System.Drawing.Point(133, 165);
            this.metroTextBoxMH.MaxLength = 32767;
            this.metroTextBoxMH.Multiline = true;
            this.metroTextBoxMH.Name = "metroTextBoxMH";
            this.metroTextBoxMH.PasswordChar = '\0';
            this.metroTextBoxMH.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxMH.SelectedText = "";
            this.metroTextBoxMH.SelectionLength = 0;
            this.metroTextBoxMH.SelectionStart = 0;
            this.metroTextBoxMH.ShortcutsEnabled = true;
            this.metroTextBoxMH.Size = new System.Drawing.Size(121, 21);
            this.metroTextBoxMH.TabIndex = 322;
            this.metroTextBoxMH.UseSelectable = true;
            this.metroTextBoxMH.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxMH.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxProgramType
            // 
            // 
            // 
            // 
            this.metroTextBoxProgramType.CustomButton.Image = null;
            this.metroTextBoxProgramType.CustomButton.Location = new System.Drawing.Point(325, 1);
            this.metroTextBoxProgramType.CustomButton.Name = "";
            this.metroTextBoxProgramType.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxProgramType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxProgramType.CustomButton.TabIndex = 1;
            this.metroTextBoxProgramType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxProgramType.CustomButton.UseSelectable = true;
            this.metroTextBoxProgramType.CustomButton.Visible = false;
            this.metroTextBoxProgramType.Enabled = false;
            this.metroTextBoxProgramType.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxProgramType.Lines = new string[0];
            this.metroTextBoxProgramType.Location = new System.Drawing.Point(133, 106);
            this.metroTextBoxProgramType.MaxLength = 32767;
            this.metroTextBoxProgramType.Multiline = true;
            this.metroTextBoxProgramType.Name = "metroTextBoxProgramType";
            this.metroTextBoxProgramType.PasswordChar = '\0';
            this.metroTextBoxProgramType.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxProgramType.SelectedText = "";
            this.metroTextBoxProgramType.SelectionLength = 0;
            this.metroTextBoxProgramType.SelectionStart = 0;
            this.metroTextBoxProgramType.ShortcutsEnabled = true;
            this.metroTextBoxProgramType.Size = new System.Drawing.Size(347, 23);
            this.metroTextBoxProgramType.TabIndex = 324;
            this.metroTextBoxProgramType.UseSelectable = true;
            this.metroTextBoxProgramType.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxProgramType.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1084, 65);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(270, 537);
            this.flowLayoutPanel2.TabIndex = 302;
            // 
            // metroTextBoxFindings
            // 
            // 
            // 
            // 
            this.metroTextBoxFindings.CustomButton.Image = null;
            this.metroTextBoxFindings.CustomButton.Location = new System.Drawing.Point(510, 2);
            this.metroTextBoxFindings.CustomButton.Name = "";
            this.metroTextBoxFindings.CustomButton.Size = new System.Drawing.Size(79, 79);
            this.metroTextBoxFindings.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxFindings.CustomButton.TabIndex = 1;
            this.metroTextBoxFindings.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxFindings.CustomButton.UseSelectable = true;
            this.metroTextBoxFindings.CustomButton.Visible = false;
            this.metroTextBoxFindings.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxFindings.Lines = new string[0];
            this.metroTextBoxFindings.Location = new System.Drawing.Point(486, 413);
            this.metroTextBoxFindings.MaxLength = 32767;
            this.metroTextBoxFindings.Multiline = true;
            this.metroTextBoxFindings.Name = "metroTextBoxFindings";
            this.metroTextBoxFindings.PasswordChar = '\0';
            this.metroTextBoxFindings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxFindings.SelectedText = "";
            this.metroTextBoxFindings.SelectionLength = 0;
            this.metroTextBoxFindings.SelectionStart = 0;
            this.metroTextBoxFindings.ShortcutsEnabled = true;
            this.metroTextBoxFindings.Size = new System.Drawing.Size(592, 84);
            this.metroTextBoxFindings.TabIndex = 326;
            this.metroTextBoxFindings.UseSelectable = true;
            this.metroTextBoxFindings.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxFindings.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxInstruction
            // 
            // 
            // 
            // 
            this.metroTextBoxInstruction.CustomButton.Image = null;
            this.metroTextBoxInstruction.CustomButton.Location = new System.Drawing.Point(510, 2);
            this.metroTextBoxInstruction.CustomButton.Name = "";
            this.metroTextBoxInstruction.CustomButton.Size = new System.Drawing.Size(79, 79);
            this.metroTextBoxInstruction.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxInstruction.CustomButton.TabIndex = 1;
            this.metroTextBoxInstruction.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxInstruction.CustomButton.UseSelectable = true;
            this.metroTextBoxInstruction.CustomButton.Visible = false;
            this.metroTextBoxInstruction.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxInstruction.Lines = new string[0];
            this.metroTextBoxInstruction.Location = new System.Drawing.Point(486, 518);
            this.metroTextBoxInstruction.MaxLength = 32767;
            this.metroTextBoxInstruction.Multiline = true;
            this.metroTextBoxInstruction.Name = "metroTextBoxInstruction";
            this.metroTextBoxInstruction.PasswordChar = '\0';
            this.metroTextBoxInstruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxInstruction.SelectedText = "";
            this.metroTextBoxInstruction.SelectionLength = 0;
            this.metroTextBoxInstruction.SelectionStart = 0;
            this.metroTextBoxInstruction.ShortcutsEnabled = true;
            this.metroTextBoxInstruction.Size = new System.Drawing.Size(592, 84);
            this.metroTextBoxInstruction.TabIndex = 328;
            this.metroTextBoxInstruction.UseSelectable = true;
            this.metroTextBoxInstruction.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxInstruction.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxStandardRef
            // 
            // 
            // 
            // 
            this.metroTextBoxStandardRef.CustomButton.Image = null;
            this.metroTextBoxStandardRef.CustomButton.Location = new System.Drawing.Point(41, 2);
            this.metroTextBoxStandardRef.CustomButton.Name = "";
            this.metroTextBoxStandardRef.CustomButton.Size = new System.Drawing.Size(77, 77);
            this.metroTextBoxStandardRef.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxStandardRef.CustomButton.TabIndex = 1;
            this.metroTextBoxStandardRef.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxStandardRef.CustomButton.UseSelectable = true;
            this.metroTextBoxStandardRef.CustomButton.Visible = false;
            this.metroTextBoxStandardRef.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxStandardRef.Lines = new string[0];
            this.metroTextBoxStandardRef.Location = new System.Drawing.Point(133, 273);
            this.metroTextBoxStandardRef.MaxLength = 32767;
            this.metroTextBoxStandardRef.Multiline = true;
            this.metroTextBoxStandardRef.Name = "metroTextBoxStandardRef";
            this.metroTextBoxStandardRef.PasswordChar = '\0';
            this.metroTextBoxStandardRef.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxStandardRef.SelectedText = "";
            this.metroTextBoxStandardRef.SelectionLength = 0;
            this.metroTextBoxStandardRef.SelectionStart = 0;
            this.metroTextBoxStandardRef.ShortcutsEnabled = true;
            this.metroTextBoxStandardRef.Size = new System.Drawing.Size(121, 82);
            this.metroTextBoxStandardRef.TabIndex = 330;
            this.metroTextBoxStandardRef.UseSelectable = true;
            this.metroTextBoxStandardRef.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxStandardRef.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxPdfCode
            // 
            // 
            // 
            // 
            this.metroTextBoxPdfCode.CustomButton.Image = null;
            this.metroTextBoxPdfCode.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.metroTextBoxPdfCode.CustomButton.Name = "";
            this.metroTextBoxPdfCode.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxPdfCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPdfCode.CustomButton.TabIndex = 1;
            this.metroTextBoxPdfCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPdfCode.CustomButton.UseSelectable = true;
            this.metroTextBoxPdfCode.CustomButton.Visible = false;
            this.metroTextBoxPdfCode.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxPdfCode.Lines = new string[0];
            this.metroTextBoxPdfCode.Location = new System.Drawing.Point(133, 361);
            this.metroTextBoxPdfCode.MaxLength = 32767;
            this.metroTextBoxPdfCode.Multiline = true;
            this.metroTextBoxPdfCode.Name = "metroTextBoxPdfCode";
            this.metroTextBoxPdfCode.PasswordChar = '\0';
            this.metroTextBoxPdfCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPdfCode.SelectedText = "";
            this.metroTextBoxPdfCode.SelectionLength = 0;
            this.metroTextBoxPdfCode.SelectionStart = 0;
            this.metroTextBoxPdfCode.ShortcutsEnabled = true;
            this.metroTextBoxPdfCode.Size = new System.Drawing.Size(121, 21);
            this.metroTextBoxPdfCode.TabIndex = 332;
            this.metroTextBoxPdfCode.UseSelectable = true;
            this.metroTextBoxPdfCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPdfCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CheckListSAFAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 658);
            this.Controls.Add(this.metroTextBoxPdfCode);
            this.Controls.Add(label8);
            this.Controls.Add(this.metroTextBoxStandardRef);
            this.Controls.Add(label6);
            this.Controls.Add(this.metroTextBoxInstruction);
            this.Controls.Add(label7);
            this.Controls.Add(this.metroTextBoxFindings);
            this.Controls.Add(label2);
            this.Controls.Add(this.metroTextBoxProgramType);
            this.Controls.Add(label1);
            this.Controls.Add(this.metroTextBoxMH);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(label19);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(label17);
            this.Controls.Add(this.fileControl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.metroTextBoxStandardText);
            this.Controls.Add(label11);
            this.Controls.Add(this.metroTextBoxStandard);
            this.Controls.Add(label5);
            this.Controls.Add(this.metroTextBoxInspectionTitle);
            this.Controls.Add(label4);
            this.Controls.Add(this.metroTextBoxItemNumber);
            this.Controls.Add(this.metroTextBoxItem);
            this.Controls.Add(label3);
            this.Controls.Add(this.metroTextSource);
            this.Controls.Add(metroLabel1);
            this.MaximizeBox = false;
            this.Name = "CheckListSAFAForm";
            this.Resizable = false;
            this.Text = "Check List";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MetroFramework.Controls.MetroTextBox metroTextBoxFindings;
        private MetroFramework.Controls.MetroTextBox metroTextBoxInstruction;
        private MetroFramework.Controls.MetroTextBox metroTextBoxStandardRef;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPdfCode;

        private MetroFramework.Controls.MetroTextBox metroTextBoxProgramType;

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextSource;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItem;
        private MetroFramework.Controls.MetroTextBox metroTextBoxInspectionTitle;
        private MetroFramework.Controls.MetroTextBox metroTextBoxStandard;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItemNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxStandardText;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        public CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private MetroFramework.Controls.MetroTextBox metroTextBoxMH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}