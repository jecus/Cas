using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{
	partial class DiscrepancyControlLight
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscrepancyControlLight));
			this.labelDiscrepancy = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textSNOn = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textSNOff = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textPNOff = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textPNOn = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textStation = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.labelAuthB1 = new System.Windows.Forms.Label();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioMaintenanceStaff = new System.Windows.Forms.RadioButton();
			this.radioCrew = new System.Windows.Forms.RadioButton();
			this.label12 = new System.Windows.Forms.Label();
			this.textCorrectiveAction = new System.Windows.Forms.TextBox();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.label10 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.textDescription = new System.Windows.Forms.TextBox();
			this.dateTimePickerRTSDate = new System.Windows.Forms.DateTimePicker();
			this.comboSpecialist1 = new System.Windows.Forms.ComboBox();
			this.comboSpecialist2 = new System.Windows.Forms.ComboBox();
			this.labelAuthB2 = new System.Windows.Forms.Label();
			this.panelMain = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.TemplateComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
			this.panelExtendable = new System.Windows.Forms.Panel();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelRelease = new System.Windows.Forms.Panel();
			this.checkBoxReliability = new System.Windows.Forms.CheckBox();
			this.panel2.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
			this.panelExtendable.SuspendLayout();
			this.flowLayoutPanelMain.SuspendLayout();
			this.panelRelease.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelDiscrepancy
			// 
			this.labelDiscrepancy.AutoSize = true;
			this.labelDiscrepancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDiscrepancy.Location = new System.Drawing.Point(3, 5);
			this.labelDiscrepancy.Name = "labelDiscrepancy";
			this.labelDiscrepancy.Size = new System.Drawing.Size(89, 13);
			this.labelDiscrepancy.TabIndex = 13;
			this.labelDiscrepancy.Text = "Discrepancy #";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(621, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Component Change";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(621, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "S/N on";
			// 
			// textSNOn
			// 
			this.textSNOn.Location = new System.Drawing.Point(666, 52);
			this.textSNOn.Name = "textSNOn";
			this.textSNOn.Size = new System.Drawing.Size(65, 20);
			this.textSNOn.TabIndex = 7;
			this.textSNOn.Text = " ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(735, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "S/N off";
			// 
			// textSNOff
			// 
			this.textSNOff.Location = new System.Drawing.Point(780, 52);
			this.textSNOff.Name = "textSNOff";
			this.textSNOff.Size = new System.Drawing.Size(65, 20);
			this.textSNOff.TabIndex = 9;
			this.textSNOff.Text = " ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(735, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "P/N off";
			// 
			// textPNOff
			// 
			this.textPNOff.Location = new System.Drawing.Point(780, 26);
			this.textPNOff.Name = "textPNOff";
			this.textPNOff.Size = new System.Drawing.Size(65, 20);
			this.textPNOff.TabIndex = 8;
			this.textPNOff.Text = " ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(621, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "ATA Chapter";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(880, 37);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(101, 13);
			this.label15.TabIndex = 45;
			this.label15.Text = "Release To Service";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(621, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "P/N on";
			// 
			// textPNOn
			// 
			this.textPNOn.Location = new System.Drawing.Point(666, 26);
			this.textPNOn.Name = "textPNOn";
			this.textPNOn.Size = new System.Drawing.Size(65, 20);
			this.textPNOn.TabIndex = 6;
			this.textPNOn.Text = "85796858";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(880, 5);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 13);
			this.label16.TabIndex = 49;
			this.label16.Text = "MRO";
			// 
			// textStation
			// 
			this.textStation.Location = new System.Drawing.Point(912, 2);
			this.textStation.Name = "textStation";
			this.textStation.Size = new System.Drawing.Size(38, 20);
			this.textStation.TabIndex = 10;
			this.textStation.Text = "DBX";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(956, 5);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(30, 13);
			this.label17.TabIndex = 51;
			this.label17.Text = "Date";
			// 
			// labelAuthB1
			// 
			this.labelAuthB1.AutoSize = true;
			this.labelAuthB1.Location = new System.Drawing.Point(880, 29);
			this.labelAuthB1.Name = "labelAuthB1";
			this.labelAuthB1.Size = new System.Drawing.Size(45, 13);
			this.labelAuthB1.TabIndex = 53;
			this.labelAuthB1.Text = "Auth B1";
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(863, 22);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 47);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 56;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.radioMaintenanceStaff);
			this.panel2.Controls.Add(this.radioCrew);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Location = new System.Drawing.Point(142, 3);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(224, 20);
			this.panel2.TabIndex = 0;
			// 
			// radioMaintenanceStaff
			// 
			this.radioMaintenanceStaff.AutoSize = true;
			this.radioMaintenanceStaff.Location = new System.Drawing.Point(109, 0);
			this.radioMaintenanceStaff.Name = "radioMaintenanceStaff";
			this.radioMaintenanceStaff.Size = new System.Drawing.Size(112, 17);
			this.radioMaintenanceStaff.TabIndex = 1;
			this.radioMaintenanceStaff.Text = "Maintenance Staff";
			this.radioMaintenanceStaff.UseVisualStyleBackColor = true;
			// 
			// radioCrew
			// 
			this.radioCrew.AutoSize = true;
			this.radioCrew.Checked = true;
			this.radioCrew.Location = new System.Drawing.Point(53, 0);
			this.radioCrew.Name = "radioCrew";
			this.radioCrew.Size = new System.Drawing.Size(49, 17);
			this.radioCrew.TabIndex = 0;
			this.radioCrew.TabStop = true;
			this.radioCrew.Text = "Crew";
			this.radioCrew.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(-3, 2);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Filled by:";
			// 
			// textCorrectiveAction
			// 
			this.textCorrectiveAction.Location = new System.Drawing.Point(327, 26);
			this.textCorrectiveAction.Multiline = true;
			this.textCorrectiveAction.Name = "textCorrectiveAction";
			this.textCorrectiveAction.Size = new System.Drawing.Size(273, 47);
			this.textCorrectiveAction.TabIndex = 5;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(612, 22);
			this.delimiter4.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 47);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 59;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(324, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 13);
			this.label10.TabIndex = 60;
			this.label10.Text = "Corrective Action";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 13);
			this.label13.TabIndex = 63;
			this.label13.Text = "Description";
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
			this.delimiter5.Location = new System.Drawing.Point(308, 22);
			this.delimiter5.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter5.Name = "delimiter5";
			this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter5.Size = new System.Drawing.Size(1, 47);
			this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter5.TabIndex = 62;
			// 
			// textDescription
			// 
			this.textDescription.Location = new System.Drawing.Point(6, 26);
			this.textDescription.Multiline = true;
			this.textDescription.Name = "textDescription";
			this.textDescription.Size = new System.Drawing.Size(295, 47);
			this.textDescription.TabIndex = 4;
			this.textDescription.Text = "What Where When Extent";
			// 
			// dateTimePickerRTSDate
			// 
			this.dateTimePickerRTSDate.Location = new System.Drawing.Point(992, 2);
			this.dateTimePickerRTSDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerRTSDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRTSDate.Name = "dateTimePickerRTSDate";
			this.dateTimePickerRTSDate.Size = new System.Drawing.Size(133, 20);
			this.dateTimePickerRTSDate.TabIndex = 179;
			this.dateTimePickerRTSDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// comboSpecialist1
			// 
			this.comboSpecialist1.FormattingEnabled = true;
			this.comboSpecialist1.Location = new System.Drawing.Point(931, 26);
			this.comboSpecialist1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboSpecialist1.Name = "comboSpecialist1";
			this.comboSpecialist1.Size = new System.Drawing.Size(194, 21);
			this.comboSpecialist1.TabIndex = 181;
			this.comboSpecialist1.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboSpecialist2
			// 
			this.comboSpecialist2.FormattingEnabled = true;
			this.comboSpecialist2.Location = new System.Drawing.Point(931, 52);
			this.comboSpecialist2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboSpecialist2.Name = "comboSpecialist2";
			this.comboSpecialist2.Size = new System.Drawing.Size(194, 21);
			this.comboSpecialist2.TabIndex = 183;
			this.comboSpecialist2.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelAuthB2
			// 
			this.labelAuthB2.AutoSize = true;
			this.labelAuthB2.Location = new System.Drawing.Point(880, 55);
			this.labelAuthB2.Name = "labelAuthB2";
			this.labelAuthB2.Size = new System.Drawing.Size(45, 13);
			this.labelAuthB2.TabIndex = 182;
			this.labelAuthB2.Text = "Auth B2";
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.TemplateComboBox);
			this.panelMain.Controls.Add(this.ataChapterComboBox);
			this.panelMain.Controls.Add(this.numericUpDownIndex);
			this.panelMain.Controls.Add(this.labelDiscrepancy);
			this.panelMain.Controls.Add(this.label9);
			this.panelMain.Controls.Add(this.label15);
			this.panelMain.Controls.Add(this.panel2);
			this.panelMain.Location = new System.Drawing.Point(3, 38);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(984, 57);
			this.panelMain.TabIndex = 187;
			this.panelMain.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 210;
			this.label1.Text = "Use. Templ:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TemplateComboBox
			// 
			this.TemplateComboBox.FormattingEnabled = true;
			this.TemplateComboBox.Location = new System.Drawing.Point(73, 33);
			this.TemplateComboBox.Name = "TemplateComboBox";
			this.TemplateComboBox.Size = new System.Drawing.Size(542, 21);
			this.TemplateComboBox.TabIndex = 209;
			this.TemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.TemplateComboBox_SelectedIndexChanged);
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Location = new System.Drawing.Point(689, 33);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(156, 21);
			this.ataChapterComboBox.TabIndex = 208;
			// 
			// numericUpDownIndex
			// 
			this.numericUpDownIndex.Location = new System.Drawing.Point(98, 3);
			this.numericUpDownIndex.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.numericUpDownIndex.Maximum = new decimal(new int[] {
			4,
			0,
			0,
			0});
			this.numericUpDownIndex.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDownIndex.Name = "numericUpDownIndex";
			this.numericUpDownIndex.Size = new System.Drawing.Size(38, 20);
			this.numericUpDownIndex.TabIndex = 207;
			this.numericUpDownIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownIndex.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// panelExtendable
			// 
			this.panelExtendable.AutoSize = true;
			this.panelExtendable.Controls.Add(this.extendableRichContainer);
			this.panelExtendable.Location = new System.Drawing.Point(3, 3);
			this.panelExtendable.Name = "panelExtendable";
			this.panelExtendable.Size = new System.Drawing.Size(434, 29);
			this.panelExtendable.TabIndex = 187;
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Discrepancy";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = false;
			this.extendableRichContainer.Location = new System.Drawing.Point(0, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(431, 22);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoSize = true;
			this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelMain.Controls.Add(this.panelExtendable);
			this.flowLayoutPanelMain.Controls.Add(this.panelMain);
			this.flowLayoutPanelMain.Controls.Add(this.panelRelease);
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1178, 188);
			this.flowLayoutPanelMain.TabIndex = 188;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// panelRelease
			// 
			this.panelRelease.AutoSize = true;
			this.panelRelease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelRelease.Controls.Add(this.label13);
			this.panelRelease.Controls.Add(this.label17);
			this.panelRelease.Controls.Add(this.labelAuthB1);
			this.panelRelease.Controls.Add(this.checkBoxReliability);
			this.panelRelease.Controls.Add(this.label16);
			this.panelRelease.Controls.Add(this.delimiter3);
			this.panelRelease.Controls.Add(this.textStation);
			this.panelRelease.Controls.Add(this.label5);
			this.panelRelease.Controls.Add(this.label4);
			this.panelRelease.Controls.Add(this.textCorrectiveAction);
			this.panelRelease.Controls.Add(this.textSNOn);
			this.panelRelease.Controls.Add(this.textPNOn);
			this.panelRelease.Controls.Add(this.comboSpecialist2);
			this.panelRelease.Controls.Add(this.delimiter4);
			this.panelRelease.Controls.Add(this.label6);
			this.panelRelease.Controls.Add(this.label10);
			this.panelRelease.Controls.Add(this.labelAuthB2);
			this.panelRelease.Controls.Add(this.textDescription);
			this.panelRelease.Controls.Add(this.textPNOff);
			this.panelRelease.Controls.Add(this.delimiter5);
			this.panelRelease.Controls.Add(this.comboSpecialist1);
			this.panelRelease.Controls.Add(this.label7);
			this.panelRelease.Controls.Add(this.label8);
			this.panelRelease.Controls.Add(this.dateTimePickerRTSDate);
			this.panelRelease.Controls.Add(this.textSNOff);
			this.panelRelease.Location = new System.Drawing.Point(3, 101);
			this.panelRelease.Name = "panelRelease";
			this.panelRelease.Size = new System.Drawing.Size(1172, 84);
			this.panelRelease.TabIndex = 209;
			this.panelRelease.Visible = false;
			// 
			// checkBoxReliability
			// 
			this.checkBoxReliability.AutoSize = true;
			this.checkBoxReliability.Location = new System.Drawing.Point(1135, 25);
			this.checkBoxReliability.Name = "checkBoxReliability";
			this.checkBoxReliability.Size = new System.Drawing.Size(34, 17);
			this.checkBoxReliability.TabIndex = 210;
			this.checkBoxReliability.Text = "R";
			this.checkBoxReliability.UseVisualStyleBackColor = true;
			// 
			// DiscrepancyControlLight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DiscrepancyControlLight";
			this.Size = new System.Drawing.Size(1184, 194);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).EndInit();
			this.panelExtendable.ResumeLayout(false);
			this.panelExtendable.PerformLayout();
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.panelRelease.ResumeLayout(false);
			this.panelRelease.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelDiscrepancy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textSNOn;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textSNOff;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textPNOff;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textPNOn;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textStation;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label labelAuthB1;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textCorrectiveAction;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter5;
		private System.Windows.Forms.TextBox textDescription;
		private System.Windows.Forms.DateTimePicker dateTimePickerRTSDate;
		private System.Windows.Forms.ComboBox comboSpecialist1;
		private System.Windows.Forms.ComboBox comboSpecialist2;
		private System.Windows.Forms.Label labelAuthB2;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelExtendable;
		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
		private System.Windows.Forms.NumericUpDown numericUpDownIndex;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private System.Windows.Forms.Panel panelRelease;
		private System.Windows.Forms.RadioButton radioMaintenanceStaff;
		private System.Windows.Forms.RadioButton radioCrew;
		private System.Windows.Forms.Label label12;
		private Auxiliary.ATAChapterComboBox TemplateComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxReliability;
	}
}
