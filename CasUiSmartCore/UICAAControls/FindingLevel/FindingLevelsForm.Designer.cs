using System.ComponentModel;

namespace CAS.UI.UICAAControls.FindingLevel
{
    partial class FindingLevelsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label metroLabel1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.metroTextLevel = new MetroFramework.Controls.MetroTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.comboBoxProgramType = new System.Windows.Forms.ComboBox();
            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.lifelengthCorrective = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewerFinal = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            label1 = new System.Windows.Forms.Label();
            metroLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(11, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 14);
            label1.TabIndex = 327;
            label1.Text = "Class:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(11, 65);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(108, 14);
            metroLabel1.TabIndex = 325;
            metroLabel1.Text = "Lavel/Category:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(11, 125);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 14);
            label2.TabIndex = 331;
            label2.Text = "Color:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(11, 153);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(50, 14);
            label3.TabIndex = 333;
            label3.Text = "Action:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(11, 290);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 14);
            label4.TabIndex = 335;
            label4.Text = "Program Type:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Verdana", 9F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label5.Location = new System.Drawing.Point(11, 317);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 14);
            label5.TabIndex = 337;
            label5.Text = "Remark:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 9F);
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label6.Location = new System.Drawing.Point(11, 201);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(118, 14);
            label6.TabIndex = 339;
            label6.Text = "Corrective Action:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Verdana", 9F);
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label7.Location = new System.Drawing.Point(11, 254);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 14);
            label7.TabIndex = 340;
            label7.Text = "Final Action:";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxClass.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(140, 94);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(252, 22);
            this.comboBoxClass.TabIndex = 328;
            // 
            // metroTextLevel
            // 
            // 
            // 
            // 
            this.metroTextLevel.CustomButton.Image = null;
            this.metroTextLevel.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.metroTextLevel.CustomButton.Name = "";
            this.metroTextLevel.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.metroTextLevel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextLevel.CustomButton.TabIndex = 1;
            this.metroTextLevel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextLevel.CustomButton.UseSelectable = true;
            this.metroTextLevel.CustomButton.Visible = false;
            this.metroTextLevel.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextLevel.Lines = new string[0];
            this.metroTextLevel.Location = new System.Drawing.Point(140, 63);
            this.metroTextLevel.MaxLength = 32767;
            this.metroTextLevel.Multiline = true;
            this.metroTextLevel.Name = "metroTextLevel";
            this.metroTextLevel.PasswordChar = '\0';
            this.metroTextLevel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextLevel.SelectedText = "";
            this.metroTextLevel.SelectionLength = 0;
            this.metroTextLevel.SelectionStart = 0;
            this.metroTextLevel.ShortcutsEnabled = true;
            this.metroTextLevel.Size = new System.Drawing.Size(252, 25);
            this.metroTextLevel.TabIndex = 326;
            this.metroTextLevel.UseSelectable = true;
            this.metroTextLevel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextLevel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(236, 365);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 330;
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
            this.buttonCancel.Location = new System.Drawing.Point(317, 365);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 329;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxColor.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(140, 122);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(252, 22);
            this.comboBoxColor.TabIndex = 332;
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxAction.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Location = new System.Drawing.Point(140, 150);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(252, 22);
            this.comboBoxAction.TabIndex = 334;
            // 
            // comboBoxProgramType
            // 
            this.comboBoxProgramType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxProgramType.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxProgramType.FormattingEnabled = true;
            this.comboBoxProgramType.Location = new System.Drawing.Point(140, 287);
            this.comboBoxProgramType.Name = "comboBoxProgramType";
            this.comboBoxProgramType.Size = new System.Drawing.Size(252, 22);
            this.comboBoxProgramType.TabIndex = 336;
            this.comboBoxProgramType.SelectedIndexChanged += new System.EventHandler(this.comboBoxProgramType_SelectedIndexChanged);
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(140, 315);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(252, 25);
            this.metroTextBoxRemark.TabIndex = 338;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lifelengthCorrective
            // 
            this.lifelengthCorrective.AutoSize = true;
            this.lifelengthCorrective.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthCorrective.CalendarApplicable = false;
            this.lifelengthCorrective.CyclesApplicable = false;
            this.lifelengthCorrective.Enabled = true;
            this.lifelengthCorrective.EnabledCalendar = true;
            this.lifelengthCorrective.EnabledCycle = false;
            this.lifelengthCorrective.EnabledHours = false;
            this.lifelengthCorrective.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthCorrective.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthCorrective.HeaderCalendar = "Calendar";
            this.lifelengthCorrective.HeaderCycles = "Cycles";
            this.lifelengthCorrective.HeaderFormattedCalendar = "Calendar";
            this.lifelengthCorrective.HeaderHours = "Hours";
            this.lifelengthCorrective.HoursApplicable = false;
            this.lifelengthCorrective.LeftHeader = "";
            this.lifelengthCorrective.Location = new System.Drawing.Point(140, 174);
            this.lifelengthCorrective.Margin = new System.Windows.Forms.Padding(4);
            this.lifelengthCorrective.Modified = false;
            this.lifelengthCorrective.Name = "lifelengthCorrective";
            this.lifelengthCorrective.ReadOnly = false;
            this.lifelengthCorrective.ShowCalendar = true;
            this.lifelengthCorrective.ShowCalendarOnly = true;
            this.lifelengthCorrective.ShowFormattedCalendar = false;
            this.lifelengthCorrective.ShowLeftHeader = false;
            this.lifelengthCorrective.ShowMinutes = true;
            this.lifelengthCorrective.Size = new System.Drawing.Size(172, 52);
            this.lifelengthCorrective.SystemCalculated = true;
            this.lifelengthCorrective.TabIndex = 341;
            // 
            // lifelengthViewerFinal
            // 
            this.lifelengthViewerFinal.AutoSize = true;
            this.lifelengthViewerFinal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerFinal.CalendarApplicable = false;
            this.lifelengthViewerFinal.CyclesApplicable = false;
            this.lifelengthViewerFinal.Enabled = true;
            this.lifelengthViewerFinal.ShowHeaders = false;
            this.lifelengthViewerFinal.EnabledCalendar = true;
            this.lifelengthViewerFinal.EnabledCycle = false;
            this.lifelengthViewerFinal.EnabledHours = false;
            this.lifelengthViewerFinal.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerFinal.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerFinal.HeaderCalendar = "Calendar";
            this.lifelengthViewerFinal.HeaderCycles = "Cycles";
            this.lifelengthViewerFinal.HeaderFormattedCalendar = "Calendar";
            this.lifelengthViewerFinal.HeaderHours = "Hours";
            this.lifelengthViewerFinal.HoursApplicable = false;
            this.lifelengthViewerFinal.LeftHeader = "";
            this.lifelengthViewerFinal.Location = new System.Drawing.Point(139, 228);
            this.lifelengthViewerFinal.Margin = new System.Windows.Forms.Padding(4);
            this.lifelengthViewerFinal.Modified = false;
            this.lifelengthViewerFinal.Name = "lifelengthViewerFinal";
            this.lifelengthViewerFinal.ReadOnly = false;
            this.lifelengthViewerFinal.ShowCalendar = true;
            this.lifelengthViewerFinal.ShowCalendarOnly = true;
            this.lifelengthViewerFinal.ShowFormattedCalendar = false;
            this.lifelengthViewerFinal.ShowLeftHeader = false;
            this.lifelengthViewerFinal.ShowMinutes = true;
            this.lifelengthViewerFinal.Size = new System.Drawing.Size(172, 52);
            this.lifelengthViewerFinal.SystemCalculated = true;
            this.lifelengthViewerFinal.TabIndex = 342;
            // 
            // FindingLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 405);
            this.Controls.Add(this.lifelengthViewerFinal);
            this.Controls.Add(this.lifelengthCorrective);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Controls.Add(label5);
            this.Controls.Add(this.comboBoxProgramType);
            this.Controls.Add(label4);
            this.Controls.Add(this.comboBoxAction);
            this.Controls.Add(label3);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(label2);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(label1);
            this.Controls.Add(this.metroTextLevel);
            this.Controls.Add(metroLabel1);
            this.MaximizeBox = false;
            this.Name = "FindingLevelsForm";
            this.Resizable = false;
            this.Text = "Finding Level Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxClass;

        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerFinal;

        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthCorrective;

        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.ComboBox comboBox3;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        private System.Windows.Forms.ComboBox comboBoxProgramType;
        private MetroFramework.Controls.MetroTextBox metroTextLevel;

        #endregion
    }
}