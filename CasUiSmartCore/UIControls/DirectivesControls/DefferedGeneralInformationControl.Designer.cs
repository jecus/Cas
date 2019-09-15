using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.DirectivesControls
{
	partial class DefferedGeneralInformationControl
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
			this.labelDefferedCategory = new System.Windows.Forms.Label();
			this.comboBoxDefferedCategory = new System.Windows.Forms.ComboBox();
			this.textBoxLogBookRef = new System.Windows.Forms.TextBox();
			this.labelLogBookRef = new System.Windows.Forms.Label();
			this.labelMelCdlItem = new System.Windows.Forms.Label();
			this.textBoxMelCdlItem = new System.Windows.Forms.TextBox();
			this.textBoxExtention = new System.Windows.Forms.TextBox();
			this.labelExtention = new System.Windows.Forms.Label();
			this.lookupComboboxFlight = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
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
			this.labelApplicability.Location = new System.Drawing.Point(929, 215);
			this.labelApplicability.Name = "labelApplicability";
			this.labelApplicability.Size = new System.Drawing.Size(90, 25);
			this.labelApplicability.TabIndex = 0;
			this.labelApplicability.Text = "Applicability";
			this.labelApplicability.Visible = false;
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
			this.labelSubject.Location = new System.Drawing.Point(10, 339);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(150, 25);
			this.labelSubject.TabIndex = 0;
			this.labelSubject.Text = "Subject:";
			// 
			// textboxSubject
			// 
			this.textboxSubject.BackColor = System.Drawing.Color.White;
			this.textboxSubject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textboxSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxSubject.Location = new System.Drawing.Point(160, 339);
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
			this.textboxApplicability.Location = new System.Drawing.Point(1025, 212);
			this.textboxApplicability.MaxLength = 1000;
			this.textboxApplicability.Multiline = true;
			this.textboxApplicability.Name = "textboxApplicability";
			this.textboxApplicability.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxApplicability.Size = new System.Drawing.Size(47, 25);
			this.textboxApplicability.TabIndex = 9;
			this.textboxApplicability.Visible = false;
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
			this.labelRemarks.Location = new System.Drawing.Point(600, 339);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(100, 23);
			this.labelRemarks.TabIndex = 0;
			this.labelRemarks.Text = "Remarks:";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(600, 464);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(150, 25);
			this.labelHiddenRemarks.TabIndex = 0;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
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
			this.textboxRemarks.Location = new System.Drawing.Point(750, 339);
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
			this.textboxHiddenRemarks.Location = new System.Drawing.Point(750, 464);
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
			this.ataChapterComboBox.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			// labelDefferedCategory
			// 
			this.labelDefferedCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDefferedCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDefferedCategory.Location = new System.Drawing.Point(600, 164);
			this.labelDefferedCategory.Name = "labelDefferedCategory";
			this.labelDefferedCategory.Size = new System.Drawing.Size(150, 25);
			this.labelDefferedCategory.TabIndex = 17;
			this.labelDefferedCategory.Text = "Category";
			// 
			// comboBoxDefferedCategory
			// 
			this.comboBoxDefferedCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDefferedCategory.FormattingEnabled = true;
			this.comboBoxDefferedCategory.Location = new System.Drawing.Point(750, 160);
			this.comboBoxDefferedCategory.Name = "comboBoxDefferedCategory";
			this.comboBoxDefferedCategory.Size = new System.Drawing.Size(350, 25);
			this.comboBoxDefferedCategory.TabIndex = 18;
			this.comboBoxDefferedCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxLogBookRef
			// 
			this.textBoxLogBookRef.BackColor = System.Drawing.Color.White;
			this.textBoxLogBookRef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLogBookRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxLogBookRef.Location = new System.Drawing.Point(160, 266);
			this.textBoxLogBookRef.MaxLength = 200;
			this.textBoxLogBookRef.Name = "textBoxLogBookRef";
			this.textBoxLogBookRef.Size = new System.Drawing.Size(350, 22);
			this.textBoxLogBookRef.TabIndex = 19;
			// 
			// labelLogBookRef
			// 
			this.labelLogBookRef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLogBookRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLogBookRef.Location = new System.Drawing.Point(10, 269);
			this.labelLogBookRef.Name = "labelLogBookRef";
			this.labelLogBookRef.Size = new System.Drawing.Size(150, 25);
			this.labelLogBookRef.TabIndex = 20;
			this.labelLogBookRef.Text = "Log. Book Ref.:";
			// 
			// labelMelCdlItem
			// 
			this.labelMelCdlItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMelCdlItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMelCdlItem.Location = new System.Drawing.Point(600, 269);
			this.labelMelCdlItem.Name = "labelMelCdlItem";
			this.labelMelCdlItem.Size = new System.Drawing.Size(150, 25);
			this.labelMelCdlItem.TabIndex = 22;
			this.labelMelCdlItem.Text = "MEL/CDL Item:";
			// 
			// textBoxMelCdlItem
			// 
			this.textBoxMelCdlItem.BackColor = System.Drawing.Color.White;
			this.textBoxMelCdlItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMelCdlItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMelCdlItem.Location = new System.Drawing.Point(750, 266);
			this.textBoxMelCdlItem.MaxLength = 200;
			this.textBoxMelCdlItem.Name = "textBoxMelCdlItem";
			this.textBoxMelCdlItem.Size = new System.Drawing.Size(350, 22);
			this.textBoxMelCdlItem.TabIndex = 21;
			// 
			// textBoxExtention
			// 
			this.textBoxExtention.BackColor = System.Drawing.Color.White;
			this.textBoxExtention.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxExtention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxExtention.Location = new System.Drawing.Point(160, 464);
			this.textBoxExtention.MaxLength = 1000;
			this.textBoxExtention.Multiline = true;
			this.textBoxExtention.Name = "textBoxExtention";
			this.textBoxExtention.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxExtention.Size = new System.Drawing.Size(350, 105);
			this.textBoxExtention.TabIndex = 24;
			// 
			// labelExtention
			// 
			this.labelExtention.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelExtention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelExtention.Location = new System.Drawing.Point(10, 464);
			this.labelExtention.Name = "labelExtention";
			this.labelExtention.Size = new System.Drawing.Size(150, 25);
			this.labelExtention.TabIndex = 23;
			this.labelExtention.Text = "Extention:";
			// 
			// lookupComboboxFlight
			// 
			this.lookupComboboxFlight.ComboboxEnabled = false;
			this.lookupComboboxFlight.Displayer = null;
			this.lookupComboboxFlight.DisplayerText = null;
			this.lookupComboboxFlight.Entity = null;
			this.lookupComboboxFlight.Location = new System.Drawing.Point(160, 294);
			this.lookupComboboxFlight.Name = "lookupComboboxFlight";
			this.lookupComboboxFlight.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFlight.Size = new System.Drawing.Size(350, 21);
			this.lookupComboboxFlight.TabIndex = 187;
			this.lookupComboboxFlight.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// DefferedGeneralInformationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.lookupComboboxFlight);
			this.Controls.Add(this.textBoxExtention);
			this.Controls.Add(this.labelExtention);
			this.Controls.Add(this.labelMelCdlItem);
			this.Controls.Add(this.textBoxMelCdlItem);
			this.Controls.Add(this.labelLogBookRef);
			this.Controls.Add(this.textBoxLogBookRef);
			this.Controls.Add(this.comboBoxDefferedCategory);
			this.Controls.Add(this.labelDefferedCategory);
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
			this.Name = "DefferedGeneralInformationControl";
			this.Size = new System.Drawing.Size(1103, 572);
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
		private Label labelDefferedCategory;
		public ComboBox comboBoxDefferedCategory;
		private TextBox textBoxLogBookRef;
		private Label labelLogBookRef;
		private Label labelMelCdlItem;
		private TextBox textBoxMelCdlItem;
		private TextBox textBoxExtention;
		private Label labelExtention;
		private LookupCombobox lookupComboboxFlight;
	}
}
