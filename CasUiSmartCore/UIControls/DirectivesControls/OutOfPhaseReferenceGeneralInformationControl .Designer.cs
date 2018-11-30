using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
namespace CAS.UI.UIControls.DirectivesControls
{
    partial class OutOfPhaseReferenceGeneralInformationControl
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
            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelATAChapter = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelEffectivityDate = new System.Windows.Forms.Label();
            this.labelApplicability = new System.Windows.Forms.Label();
            this.labelBiWeeklyReport = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.textboxSubject = new System.Windows.Forms.TextBox();
            this.textboxApplicability = new System.Windows.Forms.TextBox();
            this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.labelHiddenRemarks = new System.Windows.Forms.Label();
            this.textboxTitle = new System.Windows.Forms.TextBox();
            this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
            this.textboxRemarks = new System.Windows.Forms.TextBox();
            this.textboxHiddenRemarks = new System.Windows.Forms.TextBox();
            this.labelSB = new System.Windows.Forms.Label();
            this.textBoxServiceBulletin = new System.Windows.Forms.TextBox();
            this.fileControlSB = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.fileControlADNo = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
            this.labelEngOrderNo = new System.Windows.Forms.Label();
            this.textBoxEngOrderNo = new System.Windows.Forms.TextBox();
            this.radioButtonAppliance = new System.Windows.Forms.RadioButton();
            this.radioButtonAirFrame = new System.Windows.Forms.RadioButton();
            this.labelADType = new System.Windows.Forms.Label();
            this.fileControlEO = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.SuspendLayout();
            // 
            // labelATAChapter
            // 
            this.labelATAChapter.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelATAChapter.Location = new System.Drawing.Point(10, 10);
            this.labelATAChapter.Name = "labelATAChapter";
            this.labelATAChapter.Size = new System.Drawing.Size(150, 25);
            this.labelATAChapter.TabIndex = 0;
            this.labelATAChapter.Text = "ATA Chapter";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTitle.Location = new System.Drawing.Point(10, 55);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(100, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // labelEffectivityDate
            // 
            this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectivityDate.Location = new System.Drawing.Point(600, 10);
            this.labelEffectivityDate.Name = "labelEffectivityDate";
            this.labelEffectivityDate.Size = new System.Drawing.Size(150, 25);
            this.labelEffectivityDate.TabIndex = 0;
            this.labelEffectivityDate.Text = "Discovery Date";
            // 
            // labelApplicability
            // 
            this.labelApplicability.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApplicability.Location = new System.Drawing.Point(10, 392);
            this.labelApplicability.Name = "labelApplicability";
            this.labelApplicability.Size = new System.Drawing.Size(150, 25);
            this.labelApplicability.TabIndex = 0;
            this.labelApplicability.Text = "Applicability";
            // 
            // labelBiWeeklyReport
            // 
            this.labelBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.labelBiWeeklyReport.Name = "labelBiWeeklyReport";
            this.labelBiWeeklyReport.Size = new System.Drawing.Size(150, 25);
            this.labelBiWeeklyReport.TabIndex = 0;
            this.labelBiWeeklyReport.Text = "BiWeekly Report";
            // 
            // labelSubject
            // 
            this.labelSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSubject.Location = new System.Drawing.Point(10, 267);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(150, 25);
            this.labelSubject.TabIndex = 0;
            this.labelSubject.Text = "Subject";
            // 
            // textboxSubject
            // 
            this.textboxSubject.BackColor = System.Drawing.Color.White;
            this.textboxSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxSubject.Location = new System.Drawing.Point(160, 267);
            this.textboxSubject.MaxLength = 1000;
            this.textboxSubject.Multiline = true;
            this.textboxSubject.Name = "textboxSubject";
            this.textboxSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxSubject.Size = new System.Drawing.Size(350, 105);
            this.textboxSubject.TabIndex = 7;
            // 
            // textboxApplicability
            // 
            this.textboxApplicability.BackColor = System.Drawing.Color.White;
            this.textboxApplicability.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxApplicability.Location = new System.Drawing.Point(160, 392);
            this.textboxApplicability.MaxLength = 1000;
            this.textboxApplicability.Multiline = true;
            this.textboxApplicability.Name = "textboxApplicability";
            this.textboxApplicability.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxApplicability.Size = new System.Drawing.Size(350, 105);
            this.textboxApplicability.TabIndex = 9;
            // 
            // dateTimePickerEffDate
            // 
            this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerEffDate.Location = new System.Drawing.Point(750, 10);
            this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
            this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 25);
            this.dateTimePickerEffDate.TabIndex = 2;
            this.dateTimePickerEffDate.ValueChanged += new System.EventHandler(this.DateTimePickerEffDateValueChanged);
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(600, 267);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(100, 23);
            this.labelRemarks.TabIndex = 0;
            this.labelRemarks.Text = "Remarks";
            // 
            // labelHiddenRemarks
            // 
            this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelHiddenRemarks.Location = new System.Drawing.Point(600, 392);
            this.labelHiddenRemarks.Name = "labelHiddenRemarks";
            this.labelHiddenRemarks.Size = new System.Drawing.Size(150, 25);
            this.labelHiddenRemarks.TabIndex = 0;
            this.labelHiddenRemarks.Text = "Hidden Remarks";
            // 
            // textboxTitle
            // 
            this.textboxTitle.BackColor = System.Drawing.Color.White;
            this.textboxTitle.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxTitle.Location = new System.Drawing.Point(160, 55);
            this.textboxTitle.MaxLength = 50;
            this.textboxTitle.Name = "textboxTitle";
            this.textboxTitle.Size = new System.Drawing.Size(350, 25);
            this.textboxTitle.TabIndex = 3;
            // 
            // textboxBiWeeklyReport
            // 
            this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
            this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.textboxBiWeeklyReport.MaxLength = 1000;
            this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
            this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 25);
            this.textboxBiWeeklyReport.TabIndex = 9;
            // 
            // textboxRemarks
            // 
            this.textboxRemarks.BackColor = System.Drawing.Color.White;
            this.textboxRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxRemarks.Location = new System.Drawing.Point(750, 267);
            this.textboxRemarks.MaxLength = 34000;
            this.textboxRemarks.Multiline = true;
            this.textboxRemarks.Name = "textboxRemarks";
            this.textboxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxRemarks.Size = new System.Drawing.Size(350, 105);
            this.textboxRemarks.TabIndex = 8;
            // 
            // textboxHiddenRemarks
            // 
            this.textboxHiddenRemarks.BackColor = System.Drawing.Color.White;
            this.textboxHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textboxHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxHiddenRemarks.Location = new System.Drawing.Point(750, 392);
            this.textboxHiddenRemarks.MaxLength = 34000;
            this.textboxHiddenRemarks.Multiline = true;
            this.textboxHiddenRemarks.Name = "textboxHiddenRemarks";
            this.textboxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxHiddenRemarks.Size = new System.Drawing.Size(350, 105);
            this.textboxHiddenRemarks.TabIndex = 10;
            // 
            // labelSB
            // 
            this.labelSB.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSB.Location = new System.Drawing.Point(600, 55);
            this.labelSB.Name = "labelSB";
            this.labelSB.Size = new System.Drawing.Size(150, 25);
            this.labelSB.TabIndex = 0;
            this.labelSB.Text = "Service Bulletin";
            // 
            // textBoxServiceBulletin
            // 
            this.textBoxServiceBulletin.BackColor = System.Drawing.Color.White;
            this.textBoxServiceBulletin.Enabled = false;
            this.textBoxServiceBulletin.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxServiceBulletin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxServiceBulletin.Location = new System.Drawing.Point(750, 55);
            this.textBoxServiceBulletin.MaxLength = 1000;
            this.textBoxServiceBulletin.Name = "textBoxServiceBulletin";
            this.textBoxServiceBulletin.Size = new System.Drawing.Size(350, 25);
            this.textBoxServiceBulletin.TabIndex = 5;
            // 
            // fileControlSB
            // 
            this.fileControlSB.AutoSize = true;
            this.fileControlSB.BackColor = System.Drawing.Color.Transparent;
            this.fileControlSB.Description1 = null;
            this.fileControlSB.Description2 = null;
            this.fileControlSB.Enabled = false;
            this.fileControlSB.Filter = null;
            this.fileControlSB.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControlSB.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
            this.fileControlSB.Location = new System.Drawing.Point(750, 86);
            this.fileControlSB.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControlSB.Name = "fileControlSB";
            this.fileControlSB.Size = new System.Drawing.Size(350, 37);
            this.fileControlSB.TabIndex = 6;
            // 
            // fileControlADNo
            // 
            this.fileControlADNo.AutoSize = true;
            this.fileControlADNo.BackColor = System.Drawing.Color.Transparent;
            this.fileControlADNo.Description1 = null;
            this.fileControlADNo.Description2 = null;
            this.fileControlADNo.Filter = null;
            this.fileControlADNo.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControlADNo.IconNotEnabled = null;
            this.fileControlADNo.Location = new System.Drawing.Point(160, 87);
            this.fileControlADNo.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControlADNo.Name = "fileControlADNo";
            this.fileControlADNo.Size = new System.Drawing.Size(350, 37);
            this.fileControlADNo.TabIndex = 4;
            // 
            // ataChapterComboBox
            // 
            this.ataChapterComboBox.BackColor = System.Drawing.Color.White;
            this.ataChapterComboBox.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ataChapterComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ataChapterComboBox.FormattingEnabled = true;
            this.ataChapterComboBox.Location = new System.Drawing.Point(160, 10);
            this.ataChapterComboBox.Name = "ataChapterComboBox";
            this.ataChapterComboBox.Size = new System.Drawing.Size(350, 25);
            this.ataChapterComboBox.TabIndex = 1;
            // 
            // labelEngOrderNo
            // 
            this.labelEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEngOrderNo.Location = new System.Drawing.Point(10, 166);
            this.labelEngOrderNo.Name = "labelEngOrderNo";
            this.labelEngOrderNo.Size = new System.Drawing.Size(150, 25);
            this.labelEngOrderNo.TabIndex = 11;
            this.labelEngOrderNo.Text = "Eng. Order No:";
            // 
            // textBoxEngOrderNo
            // 
            this.textBoxEngOrderNo.BackColor = System.Drawing.Color.White;
            this.textBoxEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxEngOrderNo.Location = new System.Drawing.Point(160, 163);
            this.textBoxEngOrderNo.MaxLength = 200;
            this.textBoxEngOrderNo.Name = "textBoxEngOrderNo";
            this.textBoxEngOrderNo.Size = new System.Drawing.Size(350, 22);
            this.textBoxEngOrderNo.TabIndex = 12;
            // 
            // radioButtonAppliance
            // 
            this.radioButtonAppliance.AutoSize = true;
            this.radioButtonAppliance.Location = new System.Drawing.Point(825, 220);
            this.radioButtonAppliance.Name = "radioButtonAppliance";
            this.radioButtonAppliance.Size = new System.Drawing.Size(72, 17);
            this.radioButtonAppliance.TabIndex = 16;
            this.radioButtonAppliance.TabStop = true;
            this.radioButtonAppliance.Text = "Appliance";
            this.radioButtonAppliance.UseVisualStyleBackColor = true;
            this.radioButtonAppliance.Visible = false;
            // 
            // radioButtonAirFrame
            // 
            this.radioButtonAirFrame.AutoSize = true;
            this.radioButtonAirFrame.Location = new System.Drawing.Point(756, 220);
            this.radioButtonAirFrame.Name = "radioButtonAirFrame";
            this.radioButtonAirFrame.Size = new System.Drawing.Size(63, 17);
            this.radioButtonAirFrame.TabIndex = 15;
            this.radioButtonAirFrame.TabStop = true;
            this.radioButtonAirFrame.Text = "Airframe";
            this.radioButtonAirFrame.UseVisualStyleBackColor = true;
            this.radioButtonAirFrame.Visible = false;
            // 
            // labelADType
            // 
            this.labelADType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelADType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelADType.Location = new System.Drawing.Point(600, 221);
            this.labelADType.Name = "labelADType";
            this.labelADType.Size = new System.Drawing.Size(150, 25);
            this.labelADType.TabIndex = 14;
            this.labelADType.Text = "AD Type";
            this.labelADType.Visible = false;
            // 
            // fileControlEO
            // 
            this.fileControlEO.AutoSize = true;
            this.fileControlEO.BackColor = System.Drawing.Color.Transparent;
            this.fileControlEO.Description1 = null;
            this.fileControlEO.Description2 = null;
            this.fileControlEO.Filter = null;
            this.fileControlEO.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControlEO.IconNotEnabled = null;
            this.fileControlEO.Location = new System.Drawing.Point(160, 191);
            this.fileControlEO.MaximumSize = new System.Drawing.Size(350, 70);
            this.fileControlEO.Name = "fileControlEO";
            this.fileControlEO.Size = new System.Drawing.Size(350, 37);
            this.fileControlEO.TabIndex = 13;
            // 
            // OutOfPhaseReferenceGeneralInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.radioButtonAppliance);
            this.Controls.Add(this.radioButtonAirFrame);
            this.Controls.Add(this.labelADType);
            this.Controls.Add(this.labelEngOrderNo);
            this.Controls.Add(this.textBoxEngOrderNo);
            this.Controls.Add(this.fileControlSB);
            this.Controls.Add(this.fileControlADNo);
            this.Controls.Add(this.textBoxServiceBulletin);
            this.Controls.Add(this.labelSB);
            this.Controls.Add(this.ataChapterComboBox);
            this.Controls.Add(this.textboxSubject);
            this.Controls.Add(this.labelATAChapter);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textboxTitle);
            this.Controls.Add(this.labelEffectivityDate);
            this.Controls.Add(this.dateTimePickerEffDate);
            this.Controls.Add(this.labelApplicability);
            this.Controls.Add(this.textboxApplicability);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.textboxRemarks);
            this.Controls.Add(this.labelHiddenRemarks);
            this.Controls.Add(this.textboxHiddenRemarks);
            this.Controls.Add(this.fileControlEO);
            this.Name = "OutOfPhaseReferenceGeneralInformationControl";
            this.Size = new System.Drawing.Size(1103, 514);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelATAChapter;
        private Label labelTitle;
        private Label labelEffectivityDate;
        private Label labelApplicability;
        private Label labelBiWeeklyReport;
        private Label labelSubject;
        private Label labelRemarks;
        private Label labelHiddenRemarks;
        private TextBox textboxTitle;
        private DateTimePicker dateTimePickerEffDate;
        private TextBox textboxApplicability;
        private TextBox textboxBiWeeklyReport;
        private TextBox textboxSubject;
        private TextBox textboxRemarks;
        private TextBox textboxHiddenRemarks;
        private Label labelSB;
        private TextBox textBoxServiceBulletin;
        private AttachedFileControl fileControlADNo;
        private AttachedFileControl fileControlSB;
        private Label labelEngOrderNo;
        private TextBox textBoxEngOrderNo;
        private RadioButton radioButtonAppliance;
        private RadioButton radioButtonAirFrame;
        private Label labelADType;
        private AttachedFileControl fileControlEO;
        private ATAChapterComboBox ataChapterComboBox;
    }
}
