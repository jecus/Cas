using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class CheckListForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label17;
            this.metroTextSource = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxEditionNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxRevision = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSectionNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSectionName = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPartName = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSubPartName = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSubPartNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxItemName = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxItemNumber = new MetroFramework.Controls.MetroTextBox();
            this.dateTimePickerEditionDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEditionEff = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRevisionDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRevisionEff = new System.Windows.Forms.DateTimePicker();
            this.metroTextBoxRequirement = new MetroFramework.Controls.MetroTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.numericUpNotify = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickeValidTo = new System.Windows.Forms.DateTimePicker();
            this.checkBoxRevisionValidTo = new System.Windows.Forms.CheckBox();
            this.metroTextBoxReference = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxDescribed = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxInstructions = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            metroLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpNotify)).BeginInit();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(5, 288);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 14);
            label1.TabIndex = 18;
            label1.Text = "Edition:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(5, 520);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(58, 14);
            label3.TabIndex = 22;
            label3.Text = "Section:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(5, 473);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 14);
            label4.TabIndex = 25;
            label4.Text = "Part:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Verdana", 9F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label5.Location = new System.Drawing.Point(5, 607);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 14);
            label5.TabIndex = 28;
            label5.Text = "Subpart:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 9F);
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label6.Location = new System.Drawing.Point(5, 567);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 14);
            label6.TabIndex = 31;
            label6.Text = "Item:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Verdana", 9F);
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label7.Location = new System.Drawing.Point(291, 449);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(43, 14);
            label7.TabIndex = 34;
            label7.Text = "Name";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Verdana", 9F);
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label8.Location = new System.Drawing.Point(129, 278);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(21, 14);
            label8.TabIndex = 35;
            label8.Text = "№";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Verdana", 9F);
            label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label9.Location = new System.Drawing.Point(235, 277);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(37, 14);
            label9.TabIndex = 40;
            label9.Text = "Date";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Verdana", 9F);
            label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label10.Location = new System.Drawing.Point(367, 278);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(60, 14);
            label10.TabIndex = 41;
            label10.Text = "Eff. Date";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Verdana", 9F);
            label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label11.Location = new System.Drawing.Point(456, 65);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(84, 14);
            label11.TabIndex = 42;
            label11.Text = "Requriment:";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Verdana", 9F);
            label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label12.Location = new System.Drawing.Point(456, 400);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(106, 14);
            label12.TabIndex = 300;
            label12.Text = "Auditor Actions:";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Verdana", 9F);
            label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label13.Location = new System.Drawing.Point(81, 353);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(102, 14);
            label13.TabIndex = 307;
            label13.Text = "Check/Valid To:";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Verdana", 9F);
            label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label14.Location = new System.Drawing.Point(81, 378);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(92, 14);
            label14.TabIndex = 308;
            label14.Text = "Notify (days):";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.metroTextSource.Location = new System.Drawing.Point(108, 63);
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
            // metroTextBoxEditionNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxEditionNumber.CustomButton.Image = null;
            this.metroTextBoxEditionNumber.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxEditionNumber.CustomButton.Name = "";
            this.metroTextBoxEditionNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxEditionNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxEditionNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxEditionNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxEditionNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxEditionNumber.CustomButton.Visible = false;
            this.metroTextBoxEditionNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxEditionNumber.Lines = new string[0];
            this.metroTextBoxEditionNumber.Location = new System.Drawing.Point(108, 294);
            this.metroTextBoxEditionNumber.MaxLength = 32767;
            this.metroTextBoxEditionNumber.Multiline = true;
            this.metroTextBoxEditionNumber.Name = "metroTextBoxEditionNumber";
            this.metroTextBoxEditionNumber.PasswordChar = '\0';
            this.metroTextBoxEditionNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxEditionNumber.SelectedText = "";
            this.metroTextBoxEditionNumber.SelectionLength = 0;
            this.metroTextBoxEditionNumber.SelectionStart = 0;
            this.metroTextBoxEditionNumber.ShortcutsEnabled = true;
            this.metroTextBoxEditionNumber.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxEditionNumber.TabIndex = 19;
            this.metroTextBoxEditionNumber.UseSelectable = true;
            this.metroTextBoxEditionNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxEditionNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxRevision
            // 
            // 
            // 
            // 
            this.metroTextBoxRevision.CustomButton.Image = null;
            this.metroTextBoxRevision.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxRevision.CustomButton.Name = "";
            this.metroTextBoxRevision.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxRevision.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRevision.CustomButton.TabIndex = 1;
            this.metroTextBoxRevision.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRevision.CustomButton.UseSelectable = true;
            this.metroTextBoxRevision.CustomButton.Visible = false;
            this.metroTextBoxRevision.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRevision.Lines = new string[0];
            this.metroTextBoxRevision.Location = new System.Drawing.Point(108, 321);
            this.metroTextBoxRevision.MaxLength = 32767;
            this.metroTextBoxRevision.Multiline = true;
            this.metroTextBoxRevision.Name = "metroTextBoxRevision";
            this.metroTextBoxRevision.PasswordChar = '\0';
            this.metroTextBoxRevision.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRevision.SelectedText = "";
            this.metroTextBoxRevision.SelectionLength = 0;
            this.metroTextBoxRevision.SelectionStart = 0;
            this.metroTextBoxRevision.ShortcutsEnabled = true;
            this.metroTextBoxRevision.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxRevision.TabIndex = 21;
            this.metroTextBoxRevision.UseSelectable = true;
            this.metroTextBoxRevision.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRevision.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSectionNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxSectionNumber.CustomButton.Image = null;
            this.metroTextBoxSectionNumber.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxSectionNumber.CustomButton.Name = "";
            this.metroTextBoxSectionNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxSectionNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSectionNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxSectionNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSectionNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxSectionNumber.CustomButton.Visible = false;
            this.metroTextBoxSectionNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSectionNumber.Lines = new string[0];
            this.metroTextBoxSectionNumber.Location = new System.Drawing.Point(108, 466);
            this.metroTextBoxSectionNumber.MaxLength = 32767;
            this.metroTextBoxSectionNumber.Multiline = true;
            this.metroTextBoxSectionNumber.Name = "metroTextBoxSectionNumber";
            this.metroTextBoxSectionNumber.PasswordChar = '\0';
            this.metroTextBoxSectionNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSectionNumber.SelectedText = "";
            this.metroTextBoxSectionNumber.SelectionLength = 0;
            this.metroTextBoxSectionNumber.SelectionStart = 0;
            this.metroTextBoxSectionNumber.ShortcutsEnabled = true;
            this.metroTextBoxSectionNumber.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxSectionNumber.TabIndex = 23;
            this.metroTextBoxSectionNumber.UseSelectable = true;
            this.metroTextBoxSectionNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSectionNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSectionName
            // 
            // 
            // 
            // 
            this.metroTextBoxSectionName.CustomButton.Image = null;
            this.metroTextBoxSectionName.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.metroTextBoxSectionName.CustomButton.Name = "";
            this.metroTextBoxSectionName.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.metroTextBoxSectionName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSectionName.CustomButton.TabIndex = 1;
            this.metroTextBoxSectionName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSectionName.CustomButton.UseSelectable = true;
            this.metroTextBoxSectionName.CustomButton.Visible = false;
            this.metroTextBoxSectionName.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSectionName.Lines = new string[0];
            this.metroTextBoxSectionName.Location = new System.Drawing.Point(181, 466);
            this.metroTextBoxSectionName.MaxLength = 32767;
            this.metroTextBoxSectionName.Multiline = true;
            this.metroTextBoxSectionName.Name = "metroTextBoxSectionName";
            this.metroTextBoxSectionName.PasswordChar = '\0';
            this.metroTextBoxSectionName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSectionName.SelectedText = "";
            this.metroTextBoxSectionName.SelectionLength = 0;
            this.metroTextBoxSectionName.SelectionStart = 0;
            this.metroTextBoxSectionName.ShortcutsEnabled = true;
            this.metroTextBoxSectionName.Size = new System.Drawing.Size(274, 41);
            this.metroTextBoxSectionName.TabIndex = 24;
            this.metroTextBoxSectionName.UseSelectable = true;
            this.metroTextBoxSectionName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSectionName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxPartName
            // 
            // 
            // 
            // 
            this.metroTextBoxPartName.CustomButton.Image = null;
            this.metroTextBoxPartName.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.metroTextBoxPartName.CustomButton.Name = "";
            this.metroTextBoxPartName.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.metroTextBoxPartName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPartName.CustomButton.TabIndex = 1;
            this.metroTextBoxPartName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPartName.CustomButton.UseSelectable = true;
            this.metroTextBoxPartName.CustomButton.Visible = false;
            this.metroTextBoxPartName.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxPartName.Lines = new string[0];
            this.metroTextBoxPartName.Location = new System.Drawing.Point(181, 513);
            this.metroTextBoxPartName.MaxLength = 32767;
            this.metroTextBoxPartName.Multiline = true;
            this.metroTextBoxPartName.Name = "metroTextBoxPartName";
            this.metroTextBoxPartName.PasswordChar = '\0';
            this.metroTextBoxPartName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPartName.SelectedText = "";
            this.metroTextBoxPartName.SelectionLength = 0;
            this.metroTextBoxPartName.SelectionStart = 0;
            this.metroTextBoxPartName.ShortcutsEnabled = true;
            this.metroTextBoxPartName.Size = new System.Drawing.Size(274, 41);
            this.metroTextBoxPartName.TabIndex = 27;
            this.metroTextBoxPartName.UseSelectable = true;
            this.metroTextBoxPartName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPartName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxPartNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxPartNumber.CustomButton.Image = null;
            this.metroTextBoxPartNumber.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxPartNumber.CustomButton.Name = "";
            this.metroTextBoxPartNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPartNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPartNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxPartNumber.CustomButton.Visible = false;
            this.metroTextBoxPartNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxPartNumber.Lines = new string[0];
            this.metroTextBoxPartNumber.Location = new System.Drawing.Point(108, 513);
            this.metroTextBoxPartNumber.MaxLength = 32767;
            this.metroTextBoxPartNumber.Multiline = true;
            this.metroTextBoxPartNumber.Name = "metroTextBoxPartNumber";
            this.metroTextBoxPartNumber.PasswordChar = '\0';
            this.metroTextBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPartNumber.SelectedText = "";
            this.metroTextBoxPartNumber.SelectionLength = 0;
            this.metroTextBoxPartNumber.SelectionStart = 0;
            this.metroTextBoxPartNumber.ShortcutsEnabled = true;
            this.metroTextBoxPartNumber.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxPartNumber.TabIndex = 26;
            this.metroTextBoxPartNumber.UseSelectable = true;
            this.metroTextBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSubPartName
            // 
            // 
            // 
            // 
            this.metroTextBoxSubPartName.CustomButton.Image = null;
            this.metroTextBoxSubPartName.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.metroTextBoxSubPartName.CustomButton.Name = "";
            this.metroTextBoxSubPartName.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.metroTextBoxSubPartName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSubPartName.CustomButton.TabIndex = 1;
            this.metroTextBoxSubPartName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSubPartName.CustomButton.UseSelectable = true;
            this.metroTextBoxSubPartName.CustomButton.Visible = false;
            this.metroTextBoxSubPartName.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSubPartName.Lines = new string[0];
            this.metroTextBoxSubPartName.Location = new System.Drawing.Point(181, 560);
            this.metroTextBoxSubPartName.MaxLength = 32767;
            this.metroTextBoxSubPartName.Multiline = true;
            this.metroTextBoxSubPartName.Name = "metroTextBoxSubPartName";
            this.metroTextBoxSubPartName.PasswordChar = '\0';
            this.metroTextBoxSubPartName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSubPartName.SelectedText = "";
            this.metroTextBoxSubPartName.SelectionLength = 0;
            this.metroTextBoxSubPartName.SelectionStart = 0;
            this.metroTextBoxSubPartName.ShortcutsEnabled = true;
            this.metroTextBoxSubPartName.Size = new System.Drawing.Size(274, 41);
            this.metroTextBoxSubPartName.TabIndex = 30;
            this.metroTextBoxSubPartName.UseSelectable = true;
            this.metroTextBoxSubPartName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSubPartName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSubPartNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxSubPartNumber.CustomButton.Image = null;
            this.metroTextBoxSubPartNumber.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxSubPartNumber.CustomButton.Name = "";
            this.metroTextBoxSubPartNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxSubPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSubPartNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxSubPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSubPartNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxSubPartNumber.CustomButton.Visible = false;
            this.metroTextBoxSubPartNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSubPartNumber.Lines = new string[0];
            this.metroTextBoxSubPartNumber.Location = new System.Drawing.Point(108, 560);
            this.metroTextBoxSubPartNumber.MaxLength = 32767;
            this.metroTextBoxSubPartNumber.Multiline = true;
            this.metroTextBoxSubPartNumber.Name = "metroTextBoxSubPartNumber";
            this.metroTextBoxSubPartNumber.PasswordChar = '\0';
            this.metroTextBoxSubPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSubPartNumber.SelectedText = "";
            this.metroTextBoxSubPartNumber.SelectionLength = 0;
            this.metroTextBoxSubPartNumber.SelectionStart = 0;
            this.metroTextBoxSubPartNumber.ShortcutsEnabled = true;
            this.metroTextBoxSubPartNumber.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxSubPartNumber.TabIndex = 29;
            this.metroTextBoxSubPartNumber.UseSelectable = true;
            this.metroTextBoxSubPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSubPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxItemName
            // 
            // 
            // 
            // 
            this.metroTextBoxItemName.CustomButton.Image = null;
            this.metroTextBoxItemName.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.metroTextBoxItemName.CustomButton.Name = "";
            this.metroTextBoxItemName.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.metroTextBoxItemName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxItemName.CustomButton.TabIndex = 1;
            this.metroTextBoxItemName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxItemName.CustomButton.UseSelectable = true;
            this.metroTextBoxItemName.CustomButton.Visible = false;
            this.metroTextBoxItemName.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxItemName.Lines = new string[0];
            this.metroTextBoxItemName.Location = new System.Drawing.Point(181, 607);
            this.metroTextBoxItemName.MaxLength = 32767;
            this.metroTextBoxItemName.Multiline = true;
            this.metroTextBoxItemName.Name = "metroTextBoxItemName";
            this.metroTextBoxItemName.PasswordChar = '\0';
            this.metroTextBoxItemName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxItemName.SelectedText = "";
            this.metroTextBoxItemName.SelectionLength = 0;
            this.metroTextBoxItemName.SelectionStart = 0;
            this.metroTextBoxItemName.ShortcutsEnabled = true;
            this.metroTextBoxItemName.Size = new System.Drawing.Size(274, 41);
            this.metroTextBoxItemName.TabIndex = 33;
            this.metroTextBoxItemName.UseSelectable = true;
            this.metroTextBoxItemName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxItemName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxItemNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxItemNumber.CustomButton.Image = null;
            this.metroTextBoxItemNumber.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.metroTextBoxItemNumber.CustomButton.Name = "";
            this.metroTextBoxItemNumber.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxItemNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxItemNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxItemNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxItemNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxItemNumber.CustomButton.Visible = false;
            this.metroTextBoxItemNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxItemNumber.Lines = new string[0];
            this.metroTextBoxItemNumber.Location = new System.Drawing.Point(108, 607);
            this.metroTextBoxItemNumber.MaxLength = 32767;
            this.metroTextBoxItemNumber.Multiline = true;
            this.metroTextBoxItemNumber.Name = "metroTextBoxItemNumber";
            this.metroTextBoxItemNumber.PasswordChar = '\0';
            this.metroTextBoxItemNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxItemNumber.SelectedText = "";
            this.metroTextBoxItemNumber.SelectionLength = 0;
            this.metroTextBoxItemNumber.SelectionStart = 0;
            this.metroTextBoxItemNumber.ShortcutsEnabled = true;
            this.metroTextBoxItemNumber.Size = new System.Drawing.Size(67, 21);
            this.metroTextBoxItemNumber.TabIndex = 32;
            this.metroTextBoxItemNumber.UseSelectable = true;
            this.metroTextBoxItemNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxItemNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateTimePickerEditionDate
            // 
            this.dateTimePickerEditionDate.Location = new System.Drawing.Point(190, 294);
            this.dateTimePickerEditionDate.Name = "dateTimePickerEditionDate";
            this.dateTimePickerEditionDate.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickerEditionDate.TabIndex = 36;
            // 
            // dateTimePickerEditionEff
            // 
            this.dateTimePickerEditionEff.Location = new System.Drawing.Point(336, 294);
            this.dateTimePickerEditionEff.Name = "dateTimePickerEditionEff";
            this.dateTimePickerEditionEff.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickerEditionEff.TabIndex = 37;
            // 
            // dateTimePickerRevisionDate
            // 
            this.dateTimePickerRevisionDate.Location = new System.Drawing.Point(190, 321);
            this.dateTimePickerRevisionDate.Name = "dateTimePickerRevisionDate";
            this.dateTimePickerRevisionDate.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickerRevisionDate.TabIndex = 38;
            // 
            // dateTimePickerRevisionEff
            // 
            this.dateTimePickerRevisionEff.Location = new System.Drawing.Point(336, 321);
            this.dateTimePickerRevisionEff.Name = "dateTimePickerRevisionEff";
            this.dateTimePickerRevisionEff.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickerRevisionEff.TabIndex = 39;
            // 
            // metroTextBoxRequirement
            // 
            // 
            // 
            // 
            this.metroTextBoxRequirement.CustomButton.Image = null;
            this.metroTextBoxRequirement.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.metroTextBoxRequirement.CustomButton.Name = "";
            this.metroTextBoxRequirement.CustomButton.Size = new System.Drawing.Size(329, 329);
            this.metroTextBoxRequirement.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRequirement.CustomButton.TabIndex = 1;
            this.metroTextBoxRequirement.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRequirement.CustomButton.UseSelectable = true;
            this.metroTextBoxRequirement.CustomButton.Visible = false;
            this.metroTextBoxRequirement.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRequirement.Lines = new string[0];
            this.metroTextBoxRequirement.Location = new System.Drawing.Point(560, 63);
            this.metroTextBoxRequirement.MaxLength = 32767;
            this.metroTextBoxRequirement.Multiline = true;
            this.metroTextBoxRequirement.Name = "metroTextBoxRequirement";
            this.metroTextBoxRequirement.PasswordChar = '\0';
            this.metroTextBoxRequirement.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRequirement.SelectedText = "";
            this.metroTextBoxRequirement.SelectionLength = 0;
            this.metroTextBoxRequirement.SelectionStart = 0;
            this.metroTextBoxRequirement.ShortcutsEnabled = true;
            this.metroTextBoxRequirement.Size = new System.Drawing.Size(518, 331);
            this.metroTextBoxRequirement.TabIndex = 43;
            this.metroTextBoxRequirement.UseSelectable = true;
            this.metroTextBoxRequirement.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRequirement.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(922, 728);
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
            this.buttonCancel.Location = new System.Drawing.Point(1003, 728);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 298;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(560, 400);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(518, 322);
            this.flowLayoutPanel1.TabIndex = 301;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabel1.Size = new System.Drawing.Size(36, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // numericUpNotify
            // 
            this.numericUpNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numericUpNotify.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpNotify.Location = new System.Drawing.Point(190, 376);
            this.numericUpNotify.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpNotify.Name = "numericUpNotify";
            this.numericUpNotify.Size = new System.Drawing.Size(119, 20);
            this.numericUpNotify.TabIndex = 306;
            this.numericUpNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePickeValidTo
            // 
            this.dateTimePickeValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickeValidTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickeValidTo.Location = new System.Drawing.Point(190, 347);
            this.dateTimePickeValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickeValidTo.Name = "dateTimePickeValidTo";
            this.dateTimePickeValidTo.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickeValidTo.TabIndex = 303;
            // 
            // checkBoxRevisionValidTo
            // 
            this.checkBoxRevisionValidTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRevisionValidTo.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxRevisionValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxRevisionValidTo.Location = new System.Drawing.Point(8, 317);
            this.checkBoxRevisionValidTo.Name = "checkBoxRevisionValidTo";
            this.checkBoxRevisionValidTo.Size = new System.Drawing.Size(88, 16);
            this.checkBoxRevisionValidTo.TabIndex = 309;
            this.checkBoxRevisionValidTo.Text = "Revision:";
            // 
            // metroTextBoxReference
            // 
            // 
            // 
            // 
            this.metroTextBoxReference.CustomButton.Image = null;
            this.metroTextBoxReference.CustomButton.Location = new System.Drawing.Point(325, 1);
            this.metroTextBoxReference.CustomButton.Name = "";
            this.metroTextBoxReference.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxReference.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxReference.CustomButton.TabIndex = 1;
            this.metroTextBoxReference.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxReference.CustomButton.UseSelectable = true;
            this.metroTextBoxReference.CustomButton.Visible = false;
            this.metroTextBoxReference.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxReference.Lines = new string[0];
            this.metroTextBoxReference.Location = new System.Drawing.Point(108, 108);
            this.metroTextBoxReference.MaxLength = 32767;
            this.metroTextBoxReference.Multiline = true;
            this.metroTextBoxReference.Name = "metroTextBoxReference";
            this.metroTextBoxReference.PasswordChar = '\0';
            this.metroTextBoxReference.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxReference.SelectedText = "";
            this.metroTextBoxReference.SelectionLength = 0;
            this.metroTextBoxReference.SelectionStart = 0;
            this.metroTextBoxReference.ShortcutsEnabled = true;
            this.metroTextBoxReference.Size = new System.Drawing.Size(347, 23);
            this.metroTextBoxReference.TabIndex = 311;
            this.metroTextBoxReference.UseSelectable = true;
            this.metroTextBoxReference.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxReference.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(5, 110);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 14);
            label2.TabIndex = 310;
            label2.Text = "Reference:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBoxDescribed
            // 
            // 
            // 
            // 
            this.metroTextBoxDescribed.CustomButton.Image = null;
            this.metroTextBoxDescribed.CustomButton.Location = new System.Drawing.Point(285, 2);
            this.metroTextBoxDescribed.CustomButton.Name = "";
            this.metroTextBoxDescribed.CustomButton.Size = new System.Drawing.Size(59, 59);
            this.metroTextBoxDescribed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxDescribed.CustomButton.TabIndex = 1;
            this.metroTextBoxDescribed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxDescribed.CustomButton.UseSelectable = true;
            this.metroTextBoxDescribed.CustomButton.Visible = false;
            this.metroTextBoxDescribed.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxDescribed.Lines = new string[0];
            this.metroTextBoxDescribed.Location = new System.Drawing.Point(108, 137);
            this.metroTextBoxDescribed.MaxLength = 32767;
            this.metroTextBoxDescribed.Multiline = true;
            this.metroTextBoxDescribed.Name = "metroTextBoxDescribed";
            this.metroTextBoxDescribed.PasswordChar = '\0';
            this.metroTextBoxDescribed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxDescribed.SelectedText = "";
            this.metroTextBoxDescribed.SelectionLength = 0;
            this.metroTextBoxDescribed.SelectionStart = 0;
            this.metroTextBoxDescribed.ShortcutsEnabled = true;
            this.metroTextBoxDescribed.Size = new System.Drawing.Size(347, 64);
            this.metroTextBoxDescribed.TabIndex = 313;
            this.metroTextBoxDescribed.UseSelectable = true;
            this.metroTextBoxDescribed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxDescribed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Verdana", 9F);
            label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label15.Location = new System.Drawing.Point(5, 139);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(94, 28);
            label15.TabIndex = 312;
            label15.Text = "Pre-described\r\nFinding:";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBoxInstructions
            // 
            // 
            // 
            // 
            this.metroTextBoxInstructions.CustomButton.Image = null;
            this.metroTextBoxInstructions.CustomButton.Location = new System.Drawing.Point(285, 2);
            this.metroTextBoxInstructions.CustomButton.Name = "";
            this.metroTextBoxInstructions.CustomButton.Size = new System.Drawing.Size(59, 59);
            this.metroTextBoxInstructions.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxInstructions.CustomButton.TabIndex = 1;
            this.metroTextBoxInstructions.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxInstructions.CustomButton.UseSelectable = true;
            this.metroTextBoxInstructions.CustomButton.Visible = false;
            this.metroTextBoxInstructions.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxInstructions.Lines = new string[0];
            this.metroTextBoxInstructions.Location = new System.Drawing.Point(108, 207);
            this.metroTextBoxInstructions.MaxLength = 32767;
            this.metroTextBoxInstructions.Multiline = true;
            this.metroTextBoxInstructions.Name = "metroTextBoxInstructions";
            this.metroTextBoxInstructions.PasswordChar = '\0';
            this.metroTextBoxInstructions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxInstructions.SelectedText = "";
            this.metroTextBoxInstructions.SelectionLength = 0;
            this.metroTextBoxInstructions.SelectionStart = 0;
            this.metroTextBoxInstructions.ShortcutsEnabled = true;
            this.metroTextBoxInstructions.Size = new System.Drawing.Size(347, 64);
            this.metroTextBoxInstructions.TabIndex = 315;
            this.metroTextBoxInstructions.UseSelectable = true;
            this.metroTextBoxInstructions.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxInstructions.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Verdana", 9F);
            label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label16.Location = new System.Drawing.Point(5, 209);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(87, 14);
            label16.TabIndex = 314;
            label16.Text = "Instructions:";
            label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Verdana", 9F);
            label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label17.Location = new System.Drawing.Point(81, 403);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(45, 14);
            label17.TabIndex = 316;
            label17.Text = "Level:";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxLevel.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(188, 401);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(121, 22);
            this.comboBoxLevel.TabIndex = 317;
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
            this.fileControl.Location = new System.Drawing.Point(16, 654);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "fileControl";
            this.fileControl.ShowLinkLabelBrowse = true;
            this.fileControl.ShowLinkLabelRemove = false;
            this.fileControl.Size = new System.Drawing.Size(350, 100);
            this.fileControl.TabIndex = 302;
            // 
            // CheckListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 766);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(label17);
            this.Controls.Add(this.metroTextBoxInstructions);
            this.Controls.Add(label16);
            this.Controls.Add(this.metroTextBoxDescribed);
            this.Controls.Add(label15);
            this.Controls.Add(this.metroTextBoxReference);
            this.Controls.Add(label2);
            this.Controls.Add(this.checkBoxRevisionValidTo);
            this.Controls.Add(label14);
            this.Controls.Add(label13);
            this.Controls.Add(this.numericUpNotify);
            this.Controls.Add(this.dateTimePickeValidTo);
            this.Controls.Add(this.fileControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(label12);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.metroTextBoxRequirement);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(this.dateTimePickerRevisionEff);
            this.Controls.Add(this.dateTimePickerRevisionDate);
            this.Controls.Add(this.dateTimePickerEditionEff);
            this.Controls.Add(this.dateTimePickerEditionDate);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(this.metroTextBoxItemName);
            this.Controls.Add(this.metroTextBoxItemNumber);
            this.Controls.Add(label6);
            this.Controls.Add(this.metroTextBoxSubPartName);
            this.Controls.Add(this.metroTextBoxSubPartNumber);
            this.Controls.Add(label5);
            this.Controls.Add(this.metroTextBoxPartName);
            this.Controls.Add(this.metroTextBoxPartNumber);
            this.Controls.Add(label4);
            this.Controls.Add(this.metroTextBoxSectionName);
            this.Controls.Add(this.metroTextBoxSectionNumber);
            this.Controls.Add(label3);
            this.Controls.Add(this.metroTextBoxRevision);
            this.Controls.Add(this.metroTextBoxEditionNumber);
            this.Controls.Add(label1);
            this.Controls.Add(this.metroTextSource);
            this.Controls.Add(metroLabel1);
            this.Name = "CheckListForm";
            this.Resizable = false;
            this.Text = "Add Check List";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpNotify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextSource;
        private MetroFramework.Controls.MetroTextBox metroTextBoxEditionNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRevision;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSectionNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSectionName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPartName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPartNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSubPartName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSubPartNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItemName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItemNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditionDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditionEff;
        private System.Windows.Forms.DateTimePicker dateTimePickerRevisionDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerRevisionEff;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRequirement;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public UIControls.Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.NumericUpDown numericUpNotify;
        private System.Windows.Forms.DateTimePicker dateTimePickeValidTo;
        private CheckBox checkBoxRevisionValidTo;
        private MetroFramework.Controls.MetroTextBox metroTextBoxReference;
        private MetroFramework.Controls.MetroTextBox metroTextBoxDescribed;
        private MetroFramework.Controls.MetroTextBox metroTextBoxInstructions;
        private ComboBox comboBoxLevel;
    }
}