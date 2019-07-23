using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DirectiveInformationControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
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
			this.labelADType = new System.Windows.Forms.Label();
			this.fileControlEO = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.adTypeComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.attachedFileControlSTC = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.textBoxStc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxIsApplicability = new System.Windows.Forms.CheckBox();
			this.labelSBSubject = new System.Windows.Forms.Label();
			this.textBoxSBSubject = new System.Windows.Forms.TextBox();
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
			this.labelTitle.Text = "AD No";
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(600, 10);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(150, 25);
			this.labelEffectivityDate.TabIndex = 0;
			this.labelEffectivityDate.Text = "Effective Date";
			// 
			// labelApplicability
			// 
			this.labelApplicability.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelApplicability.Location = new System.Drawing.Point(10, 442);
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
			this.labelSubject.Location = new System.Drawing.Point(10, 331);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(150, 25);
			this.labelSubject.TabIndex = 0;
			this.labelSubject.Text = "Description";
			// 
			// textboxSubject
			// 
			this.textboxSubject.BackColor = System.Drawing.Color.White;
			this.textboxSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textboxSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxSubject.Location = new System.Drawing.Point(160, 331);
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
			this.textboxApplicability.Location = new System.Drawing.Point(160, 442);
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
			this.labelRemarks.Location = new System.Drawing.Point(600, 331);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(100, 23);
			this.labelRemarks.TabIndex = 0;
			this.labelRemarks.Text = "Remarks";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(600, 442);
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
			this.textboxRemarks.Location = new System.Drawing.Point(750, 331);
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
			this.textboxHiddenRemarks.Location = new System.Drawing.Point(750, 442);
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
			this.fileControlSB.Filter = null;
			this.fileControlSB.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlSB.IconNotEnabled = null;
			this.fileControlSB.Location = new System.Drawing.Point(750, 86);
			this.fileControlSB.MaximumSize = new System.Drawing.Size(350, 75);
			this.fileControlSB.Name = "fileControlSB";
			this.fileControlSB.ShowLinkLabelBrowse = true;
			this.fileControlSB.ShowLinkLabelRemove = false;
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
			this.fileControlADNo.ShowLinkLabelBrowse = true;
			this.fileControlADNo.ShowLinkLabelRemove = false;
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
			// labelADType
			// 
			this.labelADType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelADType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelADType.Location = new System.Drawing.Point(10, 277);
			this.labelADType.Name = "labelADType";
			this.labelADType.Size = new System.Drawing.Size(150, 25);
			this.labelADType.TabIndex = 14;
			this.labelADType.Text = "AD Type";
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
			this.fileControlEO.ShowLinkLabelBrowse = true;
			this.fileControlEO.ShowLinkLabelRemove = false;
			this.fileControlEO.Size = new System.Drawing.Size(350, 37);
			this.fileControlEO.TabIndex = 13;
			// 
			// adTypeComboBox
			// 
			this.adTypeComboBox.BackColor = System.Drawing.Color.White;
			this.adTypeComboBox.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.adTypeComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.adTypeComboBox.FormattingEnabled = true;
			this.adTypeComboBox.Location = new System.Drawing.Point(160, 274);
			this.adTypeComboBox.Name = "adTypeComboBox";
			this.adTypeComboBox.Size = new System.Drawing.Size(350, 25);
			this.adTypeComboBox.TabIndex = 15;
			// 
			// attachedFileControlSTC
			// 
			this.attachedFileControlSTC.AutoSize = true;
			this.attachedFileControlSTC.BackColor = System.Drawing.Color.Transparent;
			this.attachedFileControlSTC.Description1 = null;
			this.attachedFileControlSTC.Description2 = null;
			this.attachedFileControlSTC.Filter = null;
			this.attachedFileControlSTC.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.attachedFileControlSTC.IconNotEnabled = null;
			this.attachedFileControlSTC.Location = new System.Drawing.Point(750, 195);
			this.attachedFileControlSTC.MaximumSize = new System.Drawing.Size(350, 75);
			this.attachedFileControlSTC.Name = "attachedFileControlSTC";
			this.attachedFileControlSTC.ShowLinkLabelBrowse = true;
			this.attachedFileControlSTC.ShowLinkLabelRemove = false;
			this.attachedFileControlSTC.Size = new System.Drawing.Size(350, 37);
			this.attachedFileControlSTC.TabIndex = 18;
			// 
			// textBoxStc
			// 
			this.textBoxStc.BackColor = System.Drawing.Color.White;
			this.textBoxStc.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxStc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxStc.Location = new System.Drawing.Point(750, 164);
			this.textBoxStc.MaxLength = 1000;
			this.textBoxStc.Name = "textBoxStc";
			this.textBoxStc.Size = new System.Drawing.Size(350, 25);
			this.textBoxStc.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(600, 164);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 25);
			this.label1.TabIndex = 16;
			this.label1.Text = "STC ";
			// 
			// checkBoxIsApplicability
			// 
			this.checkBoxIsApplicability.AutoSize = true;
			this.checkBoxIsApplicability.Location = new System.Drawing.Point(80, 465);
			this.checkBoxIsApplicability.Name = "checkBoxIsApplicability";
			this.checkBoxIsApplicability.Size = new System.Drawing.Size(15, 14);
			this.checkBoxIsApplicability.TabIndex = 60;
			this.checkBoxIsApplicability.UseVisualStyleBackColor = true;
			this.checkBoxIsApplicability.CheckedChanged += new System.EventHandler(this.checkBoxIsApplicability_CheckedChanged);
			// 
			// labelSBSubject
			// 
			this.labelSBSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSBSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSBSubject.Location = new System.Drawing.Point(600, 274);
			this.labelSBSubject.Name = "labelSBSubject";
			this.labelSBSubject.Size = new System.Drawing.Size(100, 23);
			this.labelSBSubject.TabIndex = 61;
			this.labelSBSubject.Text = "SB Subject";
			// 
			// textBoxSBSubject
			// 
			this.textBoxSBSubject.BackColor = System.Drawing.Color.White;
			this.textBoxSBSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSBSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSBSubject.Location = new System.Drawing.Point(750, 274);
			this.textBoxSBSubject.MaxLength = 34000;
			this.textBoxSBSubject.Multiline = true;
			this.textBoxSBSubject.Name = "textBoxSBSubject";
			this.textBoxSBSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxSBSubject.Size = new System.Drawing.Size(350, 51);
			this.textBoxSBSubject.TabIndex = 62;
			// 
			// DirectiveInformationControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.labelSBSubject);
			this.Controls.Add(this.textBoxSBSubject);
			this.Controls.Add(this.checkBoxIsApplicability);
			this.Controls.Add(this.attachedFileControlSTC);
			this.Controls.Add(this.textBoxStc);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.adTypeComboBox);
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
			this.Name = "DirectiveInformationControl";
			this.Size = new System.Drawing.Size(1103, 571);
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
        private Label labelADType;
        private AttachedFileControl fileControlEO;
        private ATAChapterComboBox ataChapterComboBox;
		private ATAChapterComboBox adTypeComboBox;
		private AttachedFileControl attachedFileControlSTC;
		private TextBox textBoxStc;
		private Label label1;
		private CheckBox checkBoxIsApplicability;
		private Label labelSBSubject;
		private TextBox textBoxSBSubject;
	}
}
