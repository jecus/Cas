using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.DirectivesControls
{
	partial class DamageGeneralInformationControl
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
			lookupComboboxJobCard.SelectedIndexChanged -= LookupComboboxJobCardSelectedIndexChanged;

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
			this.labelEngOrderNo = new System.Windows.Forms.Label();
			this.textBoxEngOrderNo = new System.Windows.Forms.TextBox();
			this.radioButtonAppliance = new System.Windows.Forms.RadioButton();
			this.radioButtonAirFrame = new System.Windows.Forms.RadioButton();
			this.labelADType = new System.Windows.Forms.Label();
			this.textBoxInspectionDocs = new System.Windows.Forms.TextBox();
			this.labelInspectionDocs = new System.Windows.Forms.Label();
			this.labelNumber = new System.Windows.Forms.Label();
			this.textBoxDamageNumber = new System.Windows.Forms.TextBox();
			this.labelLocation = new System.Windows.Forms.Label();
			this.textBoxLocation = new System.Windows.Forms.TextBox();
			this.comboBoxDamageType = new System.Windows.Forms.ComboBox();
			this.labelDamageType = new System.Windows.Forms.Label();
			this.numericUpDownLenght = new System.Windows.Forms.NumericUpDown();
			this.labelDamageLenght = new System.Windows.Forms.Label();
			this.numericUpDownDepth = new System.Windows.Forms.NumericUpDown();
			this.labelDepth = new System.Windows.Forms.Label();
			this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
			this.labelWidth = new System.Windows.Forms.Label();
			this.numericUpDownLenghtLimit = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownDepthLimit = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownWidthLimit = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.numericUpDownAY = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.labelJobCard = new System.Windows.Forms.Label();
			this.comboBoxClass = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lookupComboboxJobCard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.fileControlInspectionDocs = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlSB = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlADNo = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.fileControlEO = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxCorrective = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenghtLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepthLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidthLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAY)).BeginInit();
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
			this.labelTitle.Location = new System.Drawing.Point(10, 58);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(100, 23);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Damage:";
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
			this.labelApplicability.Location = new System.Drawing.Point(9, 522);
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
			this.labelSubject.Location = new System.Drawing.Point(10, 411);
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
			this.textboxSubject.Location = new System.Drawing.Point(160, 411);
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
			this.textboxApplicability.Location = new System.Drawing.Point(159, 522);
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
			this.labelRemarks.Location = new System.Drawing.Point(600, 411);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(100, 23);
			this.labelRemarks.TabIndex = 0;
			this.labelRemarks.Text = "Remarks";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(599, 525);
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
			this.textboxRemarks.Location = new System.Drawing.Point(750, 411);
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
			this.textboxHiddenRemarks.Location = new System.Drawing.Point(749, 522);
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
			// labelEngOrderNo
			// 
			this.labelEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEngOrderNo.Location = new System.Drawing.Point(10, 274);
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
			this.textBoxEngOrderNo.Location = new System.Drawing.Point(160, 271);
			this.textBoxEngOrderNo.MaxLength = 200;
			this.textBoxEngOrderNo.Name = "textBoxEngOrderNo";
			this.textBoxEngOrderNo.Size = new System.Drawing.Size(350, 22);
			this.textBoxEngOrderNo.TabIndex = 12;
			// 
			// radioButtonAppliance
			// 
			this.radioButtonAppliance.AutoSize = true;
			this.radioButtonAppliance.Location = new System.Drawing.Point(825, 328);
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
			this.radioButtonAirFrame.Location = new System.Drawing.Point(756, 328);
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
			this.labelADType.Location = new System.Drawing.Point(600, 329);
			this.labelADType.Name = "labelADType";
			this.labelADType.Size = new System.Drawing.Size(150, 25);
			this.labelADType.TabIndex = 14;
			this.labelADType.Text = "AD Type";
			this.labelADType.Visible = false;
			// 
			// textBoxInspectionDocs
			// 
			this.textBoxInspectionDocs.BackColor = System.Drawing.Color.White;
			this.textBoxInspectionDocs.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxInspectionDocs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxInspectionDocs.Location = new System.Drawing.Point(750, 268);
			this.textBoxInspectionDocs.MaxLength = 1000;
			this.textBoxInspectionDocs.Name = "textBoxInspectionDocs";
			this.textBoxInspectionDocs.Size = new System.Drawing.Size(350, 25);
			this.textBoxInspectionDocs.TabIndex = 18;
			// 
			// labelInspectionDocs
			// 
			this.labelInspectionDocs.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelInspectionDocs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInspectionDocs.Location = new System.Drawing.Point(600, 268);
			this.labelInspectionDocs.Name = "labelInspectionDocs";
			this.labelInspectionDocs.Size = new System.Drawing.Size(150, 25);
			this.labelInspectionDocs.TabIndex = 17;
			this.labelInspectionDocs.Text = "Inspec. Documents";
			// 
			// labelNumber
			// 
			this.labelNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Location = new System.Drawing.Point(10, 165);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(150, 25);
			this.labelNumber.TabIndex = 20;
			this.labelNumber.Text = "Damage Number:";
			// 
			// textBoxDamageNumber
			// 
			this.textBoxDamageNumber.BackColor = System.Drawing.Color.White;
			this.textBoxDamageNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDamageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDamageNumber.Location = new System.Drawing.Point(160, 162);
			this.textBoxDamageNumber.MaxLength = 200;
			this.textBoxDamageNumber.Name = "textBoxDamageNumber";
			this.textBoxDamageNumber.Size = new System.Drawing.Size(350, 22);
			this.textBoxDamageNumber.TabIndex = 21;
			// 
			// labelLocation
			// 
			this.labelLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLocation.Location = new System.Drawing.Point(10, 241);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.Size = new System.Drawing.Size(150, 25);
			this.labelLocation.TabIndex = 22;
			this.labelLocation.Text = "Location:";
			// 
			// textBoxLocation
			// 
			this.textBoxLocation.BackColor = System.Drawing.Color.White;
			this.textBoxLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxLocation.Location = new System.Drawing.Point(160, 238);
			this.textBoxLocation.MaxLength = 200;
			this.textBoxLocation.Name = "textBoxLocation";
			this.textBoxLocation.Size = new System.Drawing.Size(350, 22);
			this.textBoxLocation.TabIndex = 23;
			// 
			// comboBoxDamageType
			// 
			this.comboBoxDamageType.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxDamageType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxDamageType.FormattingEnabled = true;
			this.comboBoxDamageType.Location = new System.Drawing.Point(160, 211);
			this.comboBoxDamageType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboBoxDamageType.Name = "comboBoxDamageType";
			this.comboBoxDamageType.Size = new System.Drawing.Size(350, 22);
			this.comboBoxDamageType.TabIndex = 36;
			this.comboBoxDamageType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDamageTypeSelectedIndexChanged);
			this.comboBoxDamageType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelDamageType
			// 
			this.labelDamageType.AutoSize = true;
			this.labelDamageType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDamageType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDamageType.Location = new System.Drawing.Point(10, 214);
			this.labelDamageType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDamageType.Name = "labelDamageType";
			this.labelDamageType.Size = new System.Drawing.Size(97, 14);
			this.labelDamageType.TabIndex = 37;
			this.labelDamageType.Text = "Damage Type:";
			// 
			// numericUpDownLenght
			// 
			this.numericUpDownLenght.DecimalPlaces = 2;
			this.numericUpDownLenght.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownLenght.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownLenght.Location = new System.Drawing.Point(750, 162);
			this.numericUpDownLenght.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownLenght.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownLenght.Name = "numericUpDownLenght";
			this.numericUpDownLenght.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownLenght.TabIndex = 39;
			// 
			// labelDamageLenght
			// 
			this.labelDamageLenght.AutoSize = true;
			this.labelDamageLenght.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDamageLenght.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDamageLenght.Location = new System.Drawing.Point(600, 164);
			this.labelDamageLenght.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDamageLenght.Name = "labelDamageLenght";
			this.labelDamageLenght.Size = new System.Drawing.Size(56, 14);
			this.labelDamageLenght.TabIndex = 38;
			this.labelDamageLenght.Text = "Lenght:";
			// 
			// numericUpDownDepth
			// 
			this.numericUpDownDepth.DecimalPlaces = 2;
			this.numericUpDownDepth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownDepth.Location = new System.Drawing.Point(750, 214);
			this.numericUpDownDepth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownDepth.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownDepth.Name = "numericUpDownDepth";
			this.numericUpDownDepth.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownDepth.TabIndex = 41;
			this.numericUpDownDepth.ValueChanged += new System.EventHandler(this.NumericUpDownDepthValueChanged);
			// 
			// labelDepth
			// 
			this.labelDepth.AutoSize = true;
			this.labelDepth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDepth.Location = new System.Drawing.Point(600, 216);
			this.labelDepth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDepth.Name = "labelDepth";
			this.labelDepth.Size = new System.Drawing.Size(50, 14);
			this.labelDepth.TabIndex = 40;
			this.labelDepth.Text = "Depth:";
			// 
			// numericUpDownWidth
			// 
			this.numericUpDownWidth.DecimalPlaces = 2;
			this.numericUpDownWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownWidth.Location = new System.Drawing.Point(750, 188);
			this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownWidth.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownWidth.Name = "numericUpDownWidth";
			this.numericUpDownWidth.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownWidth.TabIndex = 43;
			this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.NumericUpDownWidthValueChanged);
			// 
			// labelWidth
			// 
			this.labelWidth.AutoSize = true;
			this.labelWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWidth.Location = new System.Drawing.Point(600, 190);
			this.labelWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(49, 14);
			this.labelWidth.TabIndex = 42;
			this.labelWidth.Text = "Width:";
			// 
			// numericUpDownLenghtLimit
			// 
			this.numericUpDownLenghtLimit.DecimalPlaces = 2;
			this.numericUpDownLenghtLimit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownLenghtLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownLenghtLimit.Location = new System.Drawing.Point(964, 162);
			this.numericUpDownLenghtLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownLenghtLimit.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownLenghtLimit.Name = "numericUpDownLenghtLimit";
			this.numericUpDownLenghtLimit.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownLenghtLimit.TabIndex = 45;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(900, 164);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 14);
			this.label1.TabIndex = 44;
			this.label1.Text = "Limit:";
			// 
			// numericUpDownDepthLimit
			// 
			this.numericUpDownDepthLimit.DecimalPlaces = 2;
			this.numericUpDownDepthLimit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownDepthLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownDepthLimit.Location = new System.Drawing.Point(964, 214);
			this.numericUpDownDepthLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownDepthLimit.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownDepthLimit.Name = "numericUpDownDepthLimit";
			this.numericUpDownDepthLimit.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownDepthLimit.TabIndex = 47;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(900, 216);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 14);
			this.label2.TabIndex = 46;
			this.label2.Text = "Limit:";
			// 
			// numericUpDownWidthLimit
			// 
			this.numericUpDownWidthLimit.DecimalPlaces = 2;
			this.numericUpDownWidthLimit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownWidthLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownWidthLimit.Location = new System.Drawing.Point(964, 188);
			this.numericUpDownWidthLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownWidthLimit.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownWidthLimit.Name = "numericUpDownWidthLimit";
			this.numericUpDownWidthLimit.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownWidthLimit.TabIndex = 49;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(900, 190);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 14);
			this.label3.TabIndex = 48;
			this.label3.Text = "Limit:";
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(964, 240);
			this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(136, 22);
			this.comboBoxMeasure.TabIndex = 50;
			this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(900, 243);
			this.labelMeasure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(66, 14);
			this.labelMeasure.TabIndex = 51;
			this.labelMeasure.Text = "Measure:";
			// 
			// numericUpDownAY
			// 
			this.numericUpDownAY.DecimalPlaces = 2;
			this.numericUpDownAY.Enabled = false;
			this.numericUpDownAY.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownAY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownAY.Location = new System.Drawing.Point(750, 241);
			this.numericUpDownAY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownAY.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownAY.Name = "numericUpDownAY";
			this.numericUpDownAY.Size = new System.Drawing.Size(135, 22);
			this.numericUpDownAY.TabIndex = 53;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(600, 243);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 14);
			this.label4.TabIndex = 52;
			this.label4.Text = "A/Y:";
			// 
			// labelJobCard
			// 
			this.labelJobCard.AutoSize = true;
			this.labelJobCard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelJobCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelJobCard.Location = new System.Drawing.Point(10, 390);
			this.labelJobCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelJobCard.Name = "labelJobCard";
			this.labelJobCard.Size = new System.Drawing.Size(62, 14);
			this.labelJobCard.TabIndex = 55;
			this.labelJobCard.Text = "Job Card";
			// 
			// comboBoxClass
			// 
			this.comboBoxClass.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxClass.FormattingEnabled = true;
			this.comboBoxClass.Location = new System.Drawing.Point(160, 187);
			this.comboBoxClass.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxClass.Name = "comboBoxClass";
			this.comboBoxClass.Size = new System.Drawing.Size(350, 22);
			this.comboBoxClass.TabIndex = 57;
			this.comboBoxClass.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(10, 190);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 14);
			this.label5.TabIndex = 58;
			this.label5.Text = "Damage Class:";
			// 
			// lookupComboboxJobCard
			// 
			this.lookupComboboxJobCard.Displayer = null;
			this.lookupComboboxJobCard.DisplayerText = null;
			this.lookupComboboxJobCard.Entity = null;
			this.lookupComboboxJobCard.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxJobCard.Location = new System.Drawing.Point(160, 384);
			this.lookupComboboxJobCard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lookupComboboxJobCard.Name = "lookupComboboxJobCard";
			this.lookupComboboxJobCard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxJobCard.Size = new System.Drawing.Size(349, 22);
			this.lookupComboboxJobCard.TabIndex = 56;
			this.lookupComboboxJobCard.Type = null;
			this.lookupComboboxJobCard.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxJobCardSelectedIndexChanged);
			this.lookupComboboxJobCard.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// fileControlInspectionDocs
			// 
			this.fileControlInspectionDocs.AutoSize = true;
			this.fileControlInspectionDocs.BackColor = System.Drawing.Color.Transparent;
			this.fileControlInspectionDocs.Description1 = null;
			this.fileControlInspectionDocs.Description2 = null;
			this.fileControlInspectionDocs.Filter = null;
			this.fileControlInspectionDocs.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlInspectionDocs.IconNotEnabled = null;
			this.fileControlInspectionDocs.Location = new System.Drawing.Point(750, 299);
			this.fileControlInspectionDocs.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlInspectionDocs.MaximumSize = new System.Drawing.Size(350, 75);
			this.fileControlInspectionDocs.Name = "fileControlInspectionDocs";
			this.fileControlInspectionDocs.ShowLinkLabelBrowse = true;
			this.fileControlInspectionDocs.ShowLinkLabelRemove = false;
			this.fileControlInspectionDocs.Size = new System.Drawing.Size(350, 37);
			this.fileControlInspectionDocs.TabIndex = 19;
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
			this.fileControlSB.Margin = new System.Windows.Forms.Padding(4);
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
			this.fileControlADNo.Margin = new System.Windows.Forms.Padding(4);
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
			this.ataChapterComboBox.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			this.fileControlEO.Location = new System.Drawing.Point(160, 299);
			this.fileControlEO.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlEO.MaximumSize = new System.Drawing.Size(350, 70);
			this.fileControlEO.Name = "fileControlEO";
			this.fileControlEO.ShowLinkLabelBrowse = true;
			this.fileControlEO.ShowLinkLabelRemove = false;
			this.fileControlEO.Size = new System.Drawing.Size(350, 37);
			this.fileControlEO.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(9, 633);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(150, 25);
			this.label6.TabIndex = 59;
			this.label6.Text = "Corrective Action";
			// 
			// textBoxCorrective
			// 
			this.textBoxCorrective.BackColor = System.Drawing.Color.White;
			this.textBoxCorrective.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCorrective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCorrective.Location = new System.Drawing.Point(159, 633);
			this.textBoxCorrective.MaxLength = 1000;
			this.textBoxCorrective.Multiline = true;
			this.textBoxCorrective.Name = "textBoxCorrective";
			this.textBoxCorrective.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxCorrective.Size = new System.Drawing.Size(350, 105);
			this.textBoxCorrective.TabIndex = 60;
			// 
			// DamageGeneralInformationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxCorrective);
			this.Controls.Add(this.comboBoxClass);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lookupComboboxJobCard);
			this.Controls.Add(this.labelJobCard);
			this.Controls.Add(this.numericUpDownAY);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxMeasure);
			this.Controls.Add(this.labelMeasure);
			this.Controls.Add(this.numericUpDownWidthLimit);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDownDepthLimit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownLenghtLimit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownWidth);
			this.Controls.Add(this.labelWidth);
			this.Controls.Add(this.numericUpDownDepth);
			this.Controls.Add(this.labelDepth);
			this.Controls.Add(this.numericUpDownLenght);
			this.Controls.Add(this.labelDamageLenght);
			this.Controls.Add(this.comboBoxDamageType);
			this.Controls.Add(this.labelDamageType);
			this.Controls.Add(this.labelLocation);
			this.Controls.Add(this.textBoxLocation);
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.textBoxDamageNumber);
			this.Controls.Add(this.fileControlInspectionDocs);
			this.Controls.Add(this.textBoxInspectionDocs);
			this.Controls.Add(this.labelInspectionDocs);
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
			this.Name = "DamageGeneralInformationControl";
			this.Size = new System.Drawing.Size(1104, 761);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenghtLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepthLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidthLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAY)).EndInit();
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
		private AttachedFileControl fileControlInspectionDocs;
		private TextBox textBoxInspectionDocs;
		private Label labelInspectionDocs;
		private Label labelNumber;
		private TextBox textBoxDamageNumber;
		private Label labelLocation;
		private TextBox textBoxLocation;
		private ComboBox comboBoxDamageType;
		private Label labelDamageType;
		private NumericUpDown numericUpDownLenght;
		private Label labelDamageLenght;
		private NumericUpDown numericUpDownDepth;
		private Label labelDepth;
		private NumericUpDown numericUpDownWidth;
		private Label labelWidth;
		private NumericUpDown numericUpDownLenghtLimit;
		private Label label1;
		private NumericUpDown numericUpDownDepthLimit;
		private Label label2;
		private NumericUpDown numericUpDownWidthLimit;
		private Label label3;
		private ComboBox comboBoxMeasure;
		private Label labelMeasure;
		private NumericUpDown numericUpDownAY;
		private Label label4;
		private LookupCombobox lookupComboboxJobCard;
		private Label labelJobCard;
		private ComboBox comboBoxClass;
		private Label label5;
		private Label label6;
		private TextBox textBoxCorrective;
	}
}
