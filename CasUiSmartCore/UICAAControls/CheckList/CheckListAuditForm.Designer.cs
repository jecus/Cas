using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class CheckListAuditForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label1;
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.metroTextBoxItem = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSubPart = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPart = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSection = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxRequirement = new MetroFramework.Controls.MetroTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonSatisfactory = new System.Windows.Forms.RadioButton();
            this.radioButtonNotSatisfactory = new System.Windows.Forms.RadioButton();
            this.metroTextBoxReference = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxComments = new MetroFramework.Controls.MetroTextBox();
            this.checkBoxNotApplicable = new System.Windows.Forms.CheckBox();
            this.comboBoxRootCategory = new System.Windows.Forms.ComboBox();
            metroLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            labelSourceText = new System.Windows.Forms.Label();
            labelEditorText = new System.Windows.Forms.Label();
            labelRevisionText = new System.Windows.Forms.Label();
            labelLevelText = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(5, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 14);
            label2.TabIndex = 324;
            label2.Text = "Editor:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(117, 90);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 14);
            label3.TabIndex = 326;
            label3.Text = "Revision:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(264, 90);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 14);
            label4.TabIndex = 331;
            label4.Text = "Level:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Verdana", 9F);
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label8.Location = new System.Drawing.Point(5, 504);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(94, 14);
            label8.TabIndex = 347;
            label8.Text = "SubReference";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Verdana", 9F);
            label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label9.Location = new System.Drawing.Point(5, 607);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(74, 14);
            label9.TabIndex = 349;
            label9.Text = "Comments";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Verdana", 9F);
            label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label10.Location = new System.Drawing.Point(5, 715);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(139, 14);
            label10.TabIndex = 351;
            label10.Text = "Root cause Category";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(834, 782);
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
            this.buttonCancel.Location = new System.Drawing.Point(915, 782);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 298;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // metroTextBoxItem
            // 
            // 
            // 
            // 
            this.metroTextBoxItem.CustomButton.Image = null;
            this.metroTextBoxItem.CustomButton.Location = new System.Drawing.Point(436, 1);
            this.metroTextBoxItem.CustomButton.Name = "";
            this.metroTextBoxItem.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxItem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxItem.CustomButton.TabIndex = 1;
            this.metroTextBoxItem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxItem.CustomButton.UseSelectable = true;
            this.metroTextBoxItem.CustomButton.Visible = false;
            this.metroTextBoxItem.Enabled = false;
            this.metroTextBoxItem.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxItem.Lines = new string[0];
            this.metroTextBoxItem.Location = new System.Drawing.Point(8, 203);
            this.metroTextBoxItem.MaxLength = 32767;
            this.metroTextBoxItem.Multiline = true;
            this.metroTextBoxItem.Name = "metroTextBoxItem";
            this.metroTextBoxItem.PasswordChar = '\0';
            this.metroTextBoxItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxItem.SelectedText = "";
            this.metroTextBoxItem.SelectionLength = 0;
            this.metroTextBoxItem.SelectionStart = 0;
            this.metroTextBoxItem.ShortcutsEnabled = true;
            this.metroTextBoxItem.Size = new System.Drawing.Size(458, 23);
            this.metroTextBoxItem.TabIndex = 340;
            this.metroTextBoxItem.UseSelectable = true;
            this.metroTextBoxItem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxItem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSubPart
            // 
            // 
            // 
            // 
            this.metroTextBoxSubPart.CustomButton.Image = null;
            this.metroTextBoxSubPart.CustomButton.Location = new System.Drawing.Point(436, 1);
            this.metroTextBoxSubPart.CustomButton.Name = "";
            this.metroTextBoxSubPart.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxSubPart.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSubPart.CustomButton.TabIndex = 1;
            this.metroTextBoxSubPart.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSubPart.CustomButton.UseSelectable = true;
            this.metroTextBoxSubPart.CustomButton.Visible = false;
            this.metroTextBoxSubPart.Enabled = false;
            this.metroTextBoxSubPart.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSubPart.Lines = new string[0];
            this.metroTextBoxSubPart.Location = new System.Drawing.Point(8, 172);
            this.metroTextBoxSubPart.MaxLength = 32767;
            this.metroTextBoxSubPart.Multiline = true;
            this.metroTextBoxSubPart.Name = "metroTextBoxSubPart";
            this.metroTextBoxSubPart.PasswordChar = '\0';
            this.metroTextBoxSubPart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSubPart.SelectedText = "";
            this.metroTextBoxSubPart.SelectionLength = 0;
            this.metroTextBoxSubPart.SelectionStart = 0;
            this.metroTextBoxSubPart.ShortcutsEnabled = true;
            this.metroTextBoxSubPart.Size = new System.Drawing.Size(458, 23);
            this.metroTextBoxSubPart.TabIndex = 338;
            this.metroTextBoxSubPart.UseSelectable = true;
            this.metroTextBoxSubPart.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSubPart.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxPart
            // 
            // 
            // 
            // 
            this.metroTextBoxPart.CustomButton.Image = null;
            this.metroTextBoxPart.CustomButton.Location = new System.Drawing.Point(436, 1);
            this.metroTextBoxPart.CustomButton.Name = "";
            this.metroTextBoxPart.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxPart.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPart.CustomButton.TabIndex = 1;
            this.metroTextBoxPart.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPart.CustomButton.UseSelectable = true;
            this.metroTextBoxPart.CustomButton.Visible = false;
            this.metroTextBoxPart.Enabled = false;
            this.metroTextBoxPart.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxPart.Lines = new string[0];
            this.metroTextBoxPart.Location = new System.Drawing.Point(8, 143);
            this.metroTextBoxPart.MaxLength = 32767;
            this.metroTextBoxPart.Multiline = true;
            this.metroTextBoxPart.Name = "metroTextBoxPart";
            this.metroTextBoxPart.PasswordChar = '\0';
            this.metroTextBoxPart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPart.SelectedText = "";
            this.metroTextBoxPart.SelectionLength = 0;
            this.metroTextBoxPart.SelectionStart = 0;
            this.metroTextBoxPart.ShortcutsEnabled = true;
            this.metroTextBoxPart.Size = new System.Drawing.Size(458, 23);
            this.metroTextBoxPart.TabIndex = 336;
            this.metroTextBoxPart.UseSelectable = true;
            this.metroTextBoxPart.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPart.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSection
            // 
            // 
            // 
            // 
            this.metroTextBoxSection.CustomButton.Image = null;
            this.metroTextBoxSection.CustomButton.Location = new System.Drawing.Point(436, 1);
            this.metroTextBoxSection.CustomButton.Name = "";
            this.metroTextBoxSection.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxSection.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSection.CustomButton.TabIndex = 1;
            this.metroTextBoxSection.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSection.CustomButton.UseSelectable = true;
            this.metroTextBoxSection.CustomButton.Visible = false;
            this.metroTextBoxSection.Enabled = false;
            this.metroTextBoxSection.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxSection.Lines = new string[0];
            this.metroTextBoxSection.Location = new System.Drawing.Point(8, 114);
            this.metroTextBoxSection.MaxLength = 32767;
            this.metroTextBoxSection.Multiline = true;
            this.metroTextBoxSection.Name = "metroTextBoxSection";
            this.metroTextBoxSection.PasswordChar = '\0';
            this.metroTextBoxSection.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSection.SelectedText = "";
            this.metroTextBoxSection.SelectionLength = 0;
            this.metroTextBoxSection.SelectionStart = 0;
            this.metroTextBoxSection.ShortcutsEnabled = true;
            this.metroTextBoxSection.Size = new System.Drawing.Size(458, 23);
            this.metroTextBoxSection.TabIndex = 334;
            this.metroTextBoxSection.UseSelectable = true;
            this.metroTextBoxSection.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSection.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxRequirement
            // 
            // 
            // 
            // 
            this.metroTextBoxRequirement.CustomButton.Image = null;
            this.metroTextBoxRequirement.CustomButton.Location = new System.Drawing.Point(258, 1);
            this.metroTextBoxRequirement.CustomButton.Name = "";
            this.metroTextBoxRequirement.CustomButton.Size = new System.Drawing.Size(199, 199);
            this.metroTextBoxRequirement.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRequirement.CustomButton.TabIndex = 1;
            this.metroTextBoxRequirement.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRequirement.CustomButton.UseSelectable = true;
            this.metroTextBoxRequirement.CustomButton.Visible = false;
            this.metroTextBoxRequirement.Enabled = false;
            this.metroTextBoxRequirement.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRequirement.Lines = new string[0];
            this.metroTextBoxRequirement.Location = new System.Drawing.Point(8, 232);
            this.metroTextBoxRequirement.MaxLength = 32767;
            this.metroTextBoxRequirement.Multiline = true;
            this.metroTextBoxRequirement.Name = "metroTextBoxRequirement";
            this.metroTextBoxRequirement.PasswordChar = '\0';
            this.metroTextBoxRequirement.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRequirement.SelectedText = "";
            this.metroTextBoxRequirement.SelectionLength = 0;
            this.metroTextBoxRequirement.SelectionStart = 0;
            this.metroTextBoxRequirement.ShortcutsEnabled = true;
            this.metroTextBoxRequirement.Size = new System.Drawing.Size(458, 201);
            this.metroTextBoxRequirement.TabIndex = 342;
            this.metroTextBoxRequirement.UseSelectable = true;
            this.metroTextBoxRequirement.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRequirement.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(472, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(518, 711);
            this.flowLayoutPanel1.TabIndex = 343;
            // 
            // radioButtonSatisfactory
            // 
            this.radioButtonSatisfactory.AutoSize = true;
            this.radioButtonSatisfactory.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioButtonSatisfactory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.radioButtonSatisfactory.Location = new System.Drawing.Point(8, 472);
            this.radioButtonSatisfactory.Name = "radioButtonSatisfactory";
            this.radioButtonSatisfactory.Size = new System.Drawing.Size(99, 18);
            this.radioButtonSatisfactory.TabIndex = 344;
            this.radioButtonSatisfactory.TabStop = true;
            this.radioButtonSatisfactory.Checked = true;
            this.radioButtonSatisfactory.Text = "Satisfactory";
            // 
            // radioButtonNotSatisfactory
            // 
            this.radioButtonNotSatisfactory.AutoSize = true;
            this.radioButtonNotSatisfactory.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioButtonNotSatisfactory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.radioButtonNotSatisfactory.Location = new System.Drawing.Point(109, 472);
            this.radioButtonNotSatisfactory.Name = "radioButtonNotSatisfactory";
            this.radioButtonNotSatisfactory.Size = new System.Drawing.Size(125, 18);
            this.radioButtonNotSatisfactory.TabIndex = 345;
            this.radioButtonNotSatisfactory.TabStop = true;
            this.radioButtonNotSatisfactory.Text = "Not Satisfactory";
            // 
            // metroTextBoxReference
            // 
            // 
            // 
            // 
            this.metroTextBoxReference.CustomButton.Image = null;
            this.metroTextBoxReference.CustomButton.Location = new System.Drawing.Point(384, 2);
            this.metroTextBoxReference.CustomButton.Name = "";
            this.metroTextBoxReference.CustomButton.Size = new System.Drawing.Size(71, 71);
            this.metroTextBoxReference.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxReference.CustomButton.TabIndex = 1;
            this.metroTextBoxReference.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxReference.CustomButton.UseSelectable = true;
            this.metroTextBoxReference.CustomButton.Visible = false;
            this.metroTextBoxReference.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxReference.Lines = new string[0];
            this.metroTextBoxReference.Location = new System.Drawing.Point(8, 523);
            this.metroTextBoxReference.MaxLength = 32767;
            this.metroTextBoxReference.Multiline = true;
            this.metroTextBoxReference.Name = "metroTextBoxReference";
            this.metroTextBoxReference.PasswordChar = '\0';
            this.metroTextBoxReference.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxReference.SelectedText = "";
            this.metroTextBoxReference.SelectionLength = 0;
            this.metroTextBoxReference.SelectionStart = 0;
            this.metroTextBoxReference.ShortcutsEnabled = true;
            this.metroTextBoxReference.Size = new System.Drawing.Size(458, 76);
            this.metroTextBoxReference.TabIndex = 346;
            this.metroTextBoxReference.UseSelectable = true;
            this.metroTextBoxReference.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxReference.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxComments
            // 
            // 
            // 
            // 
            this.metroTextBoxComments.CustomButton.Image = null;
            this.metroTextBoxComments.CustomButton.Location = new System.Drawing.Point(384, 2);
            this.metroTextBoxComments.CustomButton.Name = "";
            this.metroTextBoxComments.CustomButton.Size = new System.Drawing.Size(71, 71);
            this.metroTextBoxComments.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxComments.CustomButton.TabIndex = 1;
            this.metroTextBoxComments.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxComments.CustomButton.UseSelectable = true;
            this.metroTextBoxComments.CustomButton.Visible = false;
            this.metroTextBoxComments.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxComments.Lines = new string[0];
            this.metroTextBoxComments.Location = new System.Drawing.Point(8, 626);
            this.metroTextBoxComments.MaxLength = 32767;
            this.metroTextBoxComments.Multiline = true;
            this.metroTextBoxComments.Name = "metroTextBoxComments";
            this.metroTextBoxComments.PasswordChar = '\0';
            this.metroTextBoxComments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxComments.SelectedText = "";
            this.metroTextBoxComments.SelectionLength = 0;
            this.metroTextBoxComments.SelectionStart = 0;
            this.metroTextBoxComments.ShortcutsEnabled = true;
            this.metroTextBoxComments.Size = new System.Drawing.Size(458, 76);
            this.metroTextBoxComments.TabIndex = 348;
            this.metroTextBoxComments.UseSelectable = true;
            this.metroTextBoxComments.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxComments.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // checkBoxNotApplicable
            // 
            this.checkBoxNotApplicable.AutoSize = true;
            this.checkBoxNotApplicable.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxNotApplicable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxNotApplicable.Location = new System.Drawing.Point(8, 449);
            this.checkBoxNotApplicable.Name = "checkBoxNotApplicable";
            this.checkBoxNotApplicable.Size = new System.Drawing.Size(115, 18);
            this.checkBoxNotApplicable.TabIndex = 350;
            this.checkBoxNotApplicable.Text = "Not applicable";
            this.checkBoxNotApplicable.UseVisualStyleBackColor = true;
            this.checkBoxNotApplicable.CheckedChanged += new System.EventHandler(this.checkBoxNotApplicable_CheckedChanged);
            // 
            // comboBoxRootCategory
            // 
            this.comboBoxRootCategory.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxRootCategory.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxRootCategory.FormattingEnabled = true;
            this.comboBoxRootCategory.Location = new System.Drawing.Point(8, 732);
            this.comboBoxRootCategory.Name = "comboBoxRootCategory";
            this.comboBoxRootCategory.Size = new System.Drawing.Size(458, 22);
            this.comboBoxRootCategory.TabIndex = 352;
            // 
            // labelSourceText
            // 
            labelSourceText.AutoSize = true;
            labelSourceText.Font = new System.Drawing.Font("Verdana", 9F);
            labelSourceText.ForeColor = System.Drawing.Color.Black;
            labelSourceText.Location = new System.Drawing.Point(63, 65);
            labelSourceText.Name = "labelSourceText";
            labelSourceText.Size = new System.Drawing.Size(50, 14);
            labelSourceText.TabIndex = 323;
            labelSourceText.Text = "Source";
            labelSourceText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEditorText
            // 
            labelEditorText.AutoSize = true;
            labelEditorText.Font = new System.Drawing.Font("Verdana", 9F);
            labelEditorText.ForeColor = System.Drawing.Color.Black;
            labelEditorText.Location = new System.Drawing.Point(63, 90);
            labelEditorText.Name = "labelEditorText";
            labelEditorText.Size = new System.Drawing.Size(44, 14);
            labelEditorText.TabIndex = 325;
            labelEditorText.Text = "Editor";
            labelEditorText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRevisionText
            // 
            labelRevisionText.AutoSize = true;
            labelRevisionText.Font = new System.Drawing.Font("Verdana", 9F);
            labelRevisionText.ForeColor = System.Drawing.Color.Black;
            labelRevisionText.Location = new System.Drawing.Point(185, 90);
            labelRevisionText.Name = "labelRevisionText";
            labelRevisionText.Size = new System.Drawing.Size(59, 14);
            labelRevisionText.TabIndex = 327;
            labelRevisionText.Text = "Revision";
            labelRevisionText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLevelText
            // 
            labelLevelText.AutoSize = true;
            labelLevelText.Font = new System.Drawing.Font("Verdana", 9F);
            labelLevelText.ForeColor = System.Drawing.Color.Black;
            labelLevelText.Location = new System.Drawing.Point(315, 90);
            labelLevelText.Name = "labelLevelText";
            labelLevelText.Size = new System.Drawing.Size(40, 14);
            labelLevelText.TabIndex = 332;
            labelLevelText.Text = "Level";
            labelLevelText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(469, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 14);
            label1.TabIndex = 353;
            label1.Text = "Audit action";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckListAuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 820);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxRootCategory);
            this.Controls.Add(label10);
            this.Controls.Add(this.checkBoxNotApplicable);
            this.Controls.Add(label9);
            this.Controls.Add(this.metroTextBoxComments);
            this.Controls.Add(label8);
            this.Controls.Add(this.metroTextBoxReference);
            this.Controls.Add(this.radioButtonSatisfactory);
            this.Controls.Add(this.radioButtonNotSatisfactory);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.metroTextBoxRequirement);
            this.Controls.Add(this.metroTextBoxItem);
            this.Controls.Add(this.metroTextBoxSubPart);
            this.Controls.Add(this.metroTextBoxPart);
            this.Controls.Add(this.metroTextBoxSection);
            this.Controls.Add(labelLevelText);
            this.Controls.Add(label4);
            this.Controls.Add(labelRevisionText);
            this.Controls.Add(label3);
            this.Controls.Add(labelEditorText);
            this.Controls.Add(label2);
            this.Controls.Add(labelSourceText);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(metroLabel1);
            this.Name = "CheckListAuditForm";
            this.Resizable = false;
            this.Text = "Check List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private MetroFramework.Controls.MetroTextBox metroTextBoxItem;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSubPart;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPart;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSection;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRequirement;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButtonSatisfactory;
        private RadioButton radioButtonNotSatisfactory;
        private MetroFramework.Controls.MetroTextBox metroTextBoxReference;
        private MetroFramework.Controls.MetroTextBox metroTextBoxComments;
        private CheckBox checkBoxNotApplicable;
        private ComboBox comboBoxRootCategory;
        System.Windows.Forms.Label labelSourceText;
        System.Windows.Forms.Label labelEditorText;
        System.Windows.Forms.Label labelRevisionText;
        System.Windows.Forms.Label labelLevelText;
    }
}