using System.ComponentModel;

namespace CAS.UI.UICAAControls.CAAEducation
{
    partial class EducationComplianceForm
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label13;
            MetroFramework.Controls.MetroLabel labelNomenclature;
            MetroFramework.Controls.MetroLabel metroLabel1;
            MetroFramework.Controls.MetroLabel metroLabel2;
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.dateTimePickeValidTo = new System.Windows.Forms.DateTimePicker();
            this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
            this.comboAircraft = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.checkBoxAircraft = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxLevel = new MetroFramework.Controls.MetroCheckBox();
            this.lifelengthViewer = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.checkBoxRepeat = new MetroFramework.Controls.MetroCheckBox();
            label3 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            labelNomenclature = new MetroFramework.Controls.MetroLabel();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(3, 91);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 14);
            label3.TabIndex = 333;
            label3.Text = "Remark:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Verdana", 9F);
            label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label13.Location = new System.Drawing.Point(3, 66);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(115, 14);
            label13.TabIndex = 337;
            label13.Text = "Last Compliance:";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNomenclature
            // 
            labelNomenclature.AutoSize = true;
            labelNomenclature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            labelNomenclature.Location = new System.Drawing.Point(3, 252);
            labelNomenclature.Name = "labelNomenclature";
            labelNomenclature.Size = new System.Drawing.Size(55, 19);
            labelNomenclature.TabIndex = 339;
            labelNomenclature.Text = "Aircraft:";
            labelNomenclature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(3, 279);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(85, 19);
            metroLabel1.TabIndex = 341;
            metroLabel1.Text = "English Level:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel2.Location = new System.Drawing.Point(3, 226);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new System.Drawing.Size(53, 19);
            metroLabel2.TabIndex = 347;
            metroLabel2.Text = "Repeat:";
            metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(249, 357);
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
            this.buttonCancel.Location = new System.Drawing.Point(330, 357);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 329;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(188, 2);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(91, 91);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(124, 92);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(282, 96);
            this.metroTextBoxRemark.TabIndex = 334;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateTimePickeValidTo
            // 
            this.dateTimePickeValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickeValidTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickeValidTo.Location = new System.Drawing.Point(124, 66);
            this.dateTimePickeValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickeValidTo.Name = "dateTimePickeValidTo";
            this.dateTimePickeValidTo.Size = new System.Drawing.Size(282, 20);
            this.dateTimePickeValidTo.TabIndex = 335;
            // 
            // documentControl1
            // 
            this.documentControl1.CurrentDocument = null;
            this.documentControl1.Location = new System.Drawing.Point(3, 304);
            this.documentControl1.Name = "documentControl1";
            this.documentControl1.Size = new System.Drawing.Size(402, 41);
            this.documentControl1.TabIndex = 338;
            // 
            // comboAircraft
            // 
            this.comboAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboAircraft.ForeColor = System.Drawing.Color.DimGray;
            this.comboAircraft.FormattingEnabled = true;
            this.comboAircraft.Location = new System.Drawing.Point(123, 250);
            this.comboAircraft.Name = "comboAircraft";
            this.comboAircraft.Size = new System.Drawing.Size(250, 21);
            this.comboAircraft.TabIndex = 340;
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxLevel.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(123, 277);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(250, 21);
            this.comboBoxLevel.TabIndex = 342;
            // 
            // checkBoxAircraft
            // 
            this.checkBoxAircraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxAircraft.Location = new System.Drawing.Point(98, 250);
            this.checkBoxAircraft.Name = "checkBoxAircraft";
            this.checkBoxAircraft.Size = new System.Drawing.Size(19, 25);
            this.checkBoxAircraft.TabIndex = 343;
            this.checkBoxAircraft.CheckedChanged += new System.EventHandler(this.checkBoxAircraft_CheckedChanged);
            // 
            // checkBoxLevel
            // 
            this.checkBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxLevel.Location = new System.Drawing.Point(98, 273);
            this.checkBoxLevel.Name = "checkBoxLevel";
            this.checkBoxLevel.Size = new System.Drawing.Size(19, 25);
            this.checkBoxLevel.TabIndex = 344;
            this.checkBoxLevel.CheckedChanged += new System.EventHandler(this.checkBoxLevel_CheckedChanged);
            // 
            // lifelengthViewer
            // 
            this.lifelengthViewer.AutoSize = true;
            this.lifelengthViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer.CalendarApplicable = false;
            this.lifelengthViewer.CyclesApplicable = false;
            this.lifelengthViewer.EnabledCalendar = true;
            this.lifelengthViewer.EnabledCycle = false;
            this.lifelengthViewer.EnabledHours = false;
            this.lifelengthViewer.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer.HeaderCalendar = "";
            this.lifelengthViewer.HeaderCycles = "";
            this.lifelengthViewer.HeaderFormattedCalendar = "";
            this.lifelengthViewer.HeaderHours = "";
            this.lifelengthViewer.HoursApplicable = false;
            this.lifelengthViewer.LeftHeader = "";
            this.lifelengthViewer.Location = new System.Drawing.Point(123, 193);
            this.lifelengthViewer.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer.Modified = false;
            this.lifelengthViewer.Name = "lifelengthViewer";
            this.lifelengthViewer.ReadOnly = false;
            this.lifelengthViewer.ShowCalendar = true;
            this.lifelengthViewer.ShowCalendarOnly = true;
            this.lifelengthViewer.ShowFormattedCalendar = false;
            this.lifelengthViewer.ShowMinutes = false;
            this.lifelengthViewer.Size = new System.Drawing.Size(176, 52);
            this.lifelengthViewer.SystemCalculated = true;
            this.lifelengthViewer.TabIndex = 345;
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRepeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxRepeat.Location = new System.Drawing.Point(99, 220);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(19, 25);
            this.checkBoxRepeat.TabIndex = 346;
            this.checkBoxRepeat.UseSelectable = true;
            this.checkBoxRepeat.CheckedChanged += new System.EventHandler(this.checkBoxRepeat_CheckedChanged);
            // 
            // EducationComplianceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 397);
            this.Controls.Add(metroLabel2);
            this.Controls.Add(this.checkBoxRepeat);
            this.Controls.Add(this.lifelengthViewer);
            this.Controls.Add(this.checkBoxLevel);
            this.Controls.Add(this.checkBoxAircraft);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(metroLabel1);
            this.Controls.Add(this.comboAircraft);
            this.Controls.Add(labelNomenclature);
            this.Controls.Add(this.documentControl1);
            this.Controls.Add(label13);
            this.Controls.Add(this.dateTimePickeValidTo);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Controls.Add(label3);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.Name = "EducationComplianceForm";
            this.Resizable = false;
            this.Text = "Add New Compliance Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MetroFramework.Controls.MetroCheckBox checkBoxRepeat;

        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewer;

        private System.Windows.Forms.CheckBox checkBoxAircraft;
        private System.Windows.Forms.CheckBox checkBoxLevel;

        private System.Windows.Forms.ComboBox comboAircraft;
        private System.Windows.Forms.ComboBox comboBoxLevel;

        private CAS.UI.UIControls.DocumentationControls.DocumentControl documentControl1;

        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;
        private System.Windows.Forms.DateTimePicker dateTimePickeValidTo;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        #endregion
    }
}