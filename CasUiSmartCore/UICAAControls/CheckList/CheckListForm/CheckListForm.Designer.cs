﻿using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList.CheckListForm
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

        private void InitializeComponent()
{
    System.Windows.Forms.Label metroLabel1;
    System.Windows.Forms.Label label3;
    System.Windows.Forms.Label label4;
    System.Windows.Forms.Label label5;
    System.Windows.Forms.Label label6;
    System.Windows.Forms.Label label7;
    System.Windows.Forms.Label label11;
    System.Windows.Forms.Label label12;
    System.Windows.Forms.Label label2;
    System.Windows.Forms.Label label17;
    System.Windows.Forms.Label label18;
    System.Windows.Forms.Label label19;
    System.Windows.Forms.Label label1;
    this.metroTextSource = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxSectionNumber = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxSectionName = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxPartName = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxSubPartName = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxSubPartNumber = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxItemName = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxItemNumber = new MetroFramework.Controls.MetroTextBox();
    this.metroTextBoxRequirement = new MetroFramework.Controls.MetroTextBox();
    this.buttonOk = new System.Windows.Forms.Button();
    this.buttonCancel = new System.Windows.Forms.Button();
    this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
    this.linkLabel1 = new System.Windows.Forms.LinkLabel();
    this.metroTextBoxReference = new MetroFramework.Controls.MetroTextBox();
    this.comboBoxLevel = new System.Windows.Forms.ComboBox();
    this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
    this.comboBoxPhase = new System.Windows.Forms.ComboBox();
    this.metroTextBoxMH = new MetroFramework.Controls.MetroTextBox();
    this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
    this.metroTextBoxProgramType = new MetroFramework.Controls.MetroTextBox();
    metroLabel1 = new System.Windows.Forms.Label();
    label3 = new System.Windows.Forms.Label();
    label4 = new System.Windows.Forms.Label();
    label5 = new System.Windows.Forms.Label();
    label6 = new System.Windows.Forms.Label();
    label7 = new System.Windows.Forms.Label();
    label11 = new System.Windows.Forms.Label();
    label12 = new System.Windows.Forms.Label();
    label2 = new System.Windows.Forms.Label();
    label17 = new System.Windows.Forms.Label();
    label18 = new System.Windows.Forms.Label();
    label19 = new System.Windows.Forms.Label();
    label1 = new System.Windows.Forms.Label();
    this.flowLayoutPanel1.SuspendLayout();
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
    label3.Location = new System.Drawing.Point(6, 254);
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
    label4.Location = new System.Drawing.Point(6, 301);
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
    label5.Location = new System.Drawing.Point(6, 348);
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
    label6.Location = new System.Drawing.Point(6, 395);
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
    label7.Location = new System.Drawing.Point(292, 230);
    label7.Name = "label7";
    label7.Size = new System.Drawing.Size(43, 14);
    label7.TabIndex = 34;
    label7.Text = "Name";
    label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
    // label17
    // 
    label17.AutoSize = true;
    label17.Font = new System.Drawing.Font("Verdana", 9F);
    label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
    label17.Location = new System.Drawing.Point(8, 169);
    label17.Name = "label17";
    label17.Size = new System.Drawing.Size(45, 14);
    label17.TabIndex = 316;
    label17.Text = "Level:";
    label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
    // 
    // label18
    // 
    label18.AutoSize = true;
    label18.Font = new System.Drawing.Font("Verdana", 9F);
    label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
    label18.Location = new System.Drawing.Point(8, 197);
    label18.Name = "label18";
    label18.Size = new System.Drawing.Size(51, 14);
    label18.TabIndex = 318;
    label18.Text = "Phase:";
    label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
    // 
    // label19
    // 
    label19.AutoSize = true;
    label19.Font = new System.Drawing.Font("Verdana", 9F);
    label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
    label19.Location = new System.Drawing.Point(8, 230);
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
    label1.Location = new System.Drawing.Point(5, 140);
    label1.Name = "label1";
    label1.Size = new System.Drawing.Size(98, 14);
    label1.TabIndex = 323;
    label1.Text = "Program Type:";
    label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
    this.metroTextBoxSectionNumber.Location = new System.Drawing.Point(109, 247);
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
    this.metroTextBoxSectionName.Location = new System.Drawing.Point(182, 247);
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
    this.metroTextBoxPartName.Location = new System.Drawing.Point(182, 294);
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
    this.metroTextBoxPartNumber.Location = new System.Drawing.Point(109, 294);
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
    this.metroTextBoxSubPartName.Location = new System.Drawing.Point(182, 341);
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
    this.metroTextBoxSubPartNumber.Location = new System.Drawing.Point(109, 341);
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
    this.metroTextBoxItemName.Location = new System.Drawing.Point(182, 388);
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
    this.metroTextBoxItemNumber.Location = new System.Drawing.Point(109, 388);
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
    this.metroTextBoxRequirement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
    this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
    this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
    this.buttonOk.Location = new System.Drawing.Point(1196, 782);
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
    this.buttonCancel.Location = new System.Drawing.Point(1277, 782);
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
    this.flowLayoutPanel1.Size = new System.Drawing.Size(518, 376);
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
    // comboBoxLevel
    // 
    this.comboBoxLevel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
    this.comboBoxLevel.ForeColor = System.Drawing.Color.DimGray;
    this.comboBoxLevel.FormattingEnabled = true;
    this.comboBoxLevel.Location = new System.Drawing.Point(108, 166);
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
    this.fileControl.Location = new System.Drawing.Point(17, 435);
    this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
    this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
    this.fileControl.Name = "fileControl";
    this.fileControl.ShowLinkLabelBrowse = true;
    this.fileControl.ShowLinkLabelRemove = false;
    this.fileControl.Size = new System.Drawing.Size(350, 100);
    this.fileControl.TabIndex = 302;
    // 
    // comboBoxPhase
    // 
    this.comboBoxPhase.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
    this.comboBoxPhase.ForeColor = System.Drawing.Color.DimGray;
    this.comboBoxPhase.FormattingEnabled = true;
    this.comboBoxPhase.Location = new System.Drawing.Point(108, 194);
    this.comboBoxPhase.Name = "comboBoxPhase";
    this.comboBoxPhase.Size = new System.Drawing.Size(121, 22);
    this.comboBoxPhase.TabIndex = 319;
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
    this.metroTextBoxMH.Location = new System.Drawing.Point(108, 222);
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
    // flowLayoutPanel2
    // 
    this.flowLayoutPanel2.AutoScroll = true;
    this.flowLayoutPanel2.Location = new System.Drawing.Point(1084, 65);
    this.flowLayoutPanel2.Name = "flowLayoutPanel2";
    this.flowLayoutPanel2.Size = new System.Drawing.Size(270, 711);
    this.flowLayoutPanel2.TabIndex = 302;
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
    this.metroTextBoxProgramType.Location = new System.Drawing.Point(108, 137);
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
    // CheckListForm
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(1359, 820);
    this.Controls.Add(this.metroTextBoxProgramType);
    this.Controls.Add(label1);
    this.Controls.Add(this.metroTextBoxMH);
    this.Controls.Add(this.flowLayoutPanel2);
    this.Controls.Add(label19);
    this.Controls.Add(this.comboBoxPhase);
    this.Controls.Add(label18);
    this.Controls.Add(this.comboBoxLevel);
    this.Controls.Add(label17);
    this.Controls.Add(this.metroTextBoxReference);
    this.Controls.Add(label2);
    this.Controls.Add(this.fileControl);
    this.Controls.Add(this.flowLayoutPanel1);
    this.Controls.Add(label12);
    this.Controls.Add(this.buttonOk);
    this.Controls.Add(this.buttonCancel);
    this.Controls.Add(this.metroTextBoxRequirement);
    this.Controls.Add(label11);
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
    this.Controls.Add(this.metroTextSource);
    this.Controls.Add(metroLabel1);
    this.MaximizeBox = false;
    this.Name = "CheckListForm";
    this.Resizable = false;
    this.Text = "Check List";
    this.flowLayoutPanel1.ResumeLayout(false);
    this.flowLayoutPanel1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
}

        private MetroFramework.Controls.MetroTextBox metroTextBoxProgramType;

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextSource;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSectionNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSectionName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPartName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPartNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSubPartName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSubPartNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItemName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItemNumber;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRequirement;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private MetroFramework.Controls.MetroTextBox metroTextBoxReference;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxPhase;
        private MetroFramework.Controls.MetroTextBox metroTextBoxMH;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}