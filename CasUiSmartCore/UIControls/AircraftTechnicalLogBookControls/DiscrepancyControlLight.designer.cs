using System.Threading;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
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
			this.label4 = new System.Windows.Forms.Label();
			this.textPNOn = new System.Windows.Forms.TextBox();
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
			this.label1 = new System.Windows.Forms.Label();
			this.panelMain = new System.Windows.Forms.Panel();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
			this.panelExtendable = new System.Windows.Forms.Panel();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelRelease = new System.Windows.Forms.Panel();
			this.ataChapterComboBox1 = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
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
			this.label5.Location = new System.Drawing.Point(478, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Component Change";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(478, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "S/N on";
			// 
			// textSNOn
			// 
			this.textSNOn.Location = new System.Drawing.Point(523, 52);
			this.textSNOn.Name = "textSNOn";
			this.textSNOn.Size = new System.Drawing.Size(65, 20);
			this.textSNOn.TabIndex = 7;
			this.textSNOn.Text = " ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(592, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "S/N off";
			// 
			// textSNOff
			// 
			this.textSNOff.Location = new System.Drawing.Point(637, 52);
			this.textSNOff.Name = "textSNOff";
			this.textSNOff.Size = new System.Drawing.Size(65, 20);
			this.textSNOff.TabIndex = 9;
			this.textSNOff.Text = " ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(592, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "P/N off";
			// 
			// textPNOff
			// 
			this.textPNOff.Location = new System.Drawing.Point(637, 26);
			this.textPNOff.Name = "textPNOff";
			this.textPNOff.Size = new System.Drawing.Size(65, 20);
			this.textPNOff.TabIndex = 8;
			this.textPNOff.Text = " ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(478, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "ATA Chapter";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(478, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "P/N on";
			// 
			// textPNOn
			// 
			this.textPNOn.Location = new System.Drawing.Point(523, 26);
			this.textPNOn.Name = "textPNOn";
			this.textPNOn.Size = new System.Drawing.Size(65, 20);
			this.textPNOn.TabIndex = 6;
			this.textPNOn.Text = "85796858";
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(718, 22);
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
			this.panel2.Location = new System.Drawing.Point(243, 3);
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
			this.textCorrectiveAction.Location = new System.Drawing.Point(243, 26);
			this.textCorrectiveAction.Multiline = true;
			this.textCorrectiveAction.Name = "textCorrectiveAction";
			this.textCorrectiveAction.Size = new System.Drawing.Size(200, 47);
			this.textCorrectiveAction.TabIndex = 5;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(460, 22);
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
			this.label10.Location = new System.Drawing.Point(240, 0);
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
			this.delimiter5.Location = new System.Drawing.Point(224, 22);
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
			this.textDescription.Size = new System.Drawing.Size(200, 47);
			this.textDescription.TabIndex = 4;
			this.textDescription.Text = "What Where When Extent";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 184;
			this.label1.Text = "Use. Templ";
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.Controls.Add(this.ataChapterComboBox1);
			this.panelMain.Controls.Add(this.ataChapterComboBox);
			this.panelMain.Controls.Add(this.numericUpDownIndex);
			this.panelMain.Controls.Add(this.labelDiscrepancy);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.label9);
			this.panelMain.Controls.Add(this.panel2);
			this.panelMain.Location = new System.Drawing.Point(3, 38);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(705, 57);
			this.panelMain.TabIndex = 187;
			this.panelMain.Visible = false;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Location = new System.Drawing.Point(546, 33);
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
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(740, 188);
			this.flowLayoutPanelMain.TabIndex = 188;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// panelRelease
			// 
			this.panelRelease.AutoSize = true;
			this.panelRelease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelRelease.Controls.Add(this.label13);
			this.panelRelease.Controls.Add(this.delimiter3);
			this.panelRelease.Controls.Add(this.label5);
			this.panelRelease.Controls.Add(this.label4);
			this.panelRelease.Controls.Add(this.textCorrectiveAction);
			this.panelRelease.Controls.Add(this.textSNOn);
			this.panelRelease.Controls.Add(this.textPNOn);
			this.panelRelease.Controls.Add(this.delimiter4);
			this.panelRelease.Controls.Add(this.label6);
			this.panelRelease.Controls.Add(this.label10);
			this.panelRelease.Controls.Add(this.textDescription);
			this.panelRelease.Controls.Add(this.textPNOff);
			this.panelRelease.Controls.Add(this.delimiter5);
			this.panelRelease.Controls.Add(this.label7);
			this.panelRelease.Controls.Add(this.label8);
			this.panelRelease.Controls.Add(this.textSNOff);
			this.panelRelease.Location = new System.Drawing.Point(3, 101);
			this.panelRelease.Name = "panelRelease";
			this.panelRelease.Size = new System.Drawing.Size(734, 84);
			this.panelRelease.TabIndex = 209;
			this.panelRelease.Visible = false;
			// 
			// ataChapterComboBox1
			// 
			this.ataChapterComboBox1.FormattingEnabled = true;
			this.ataChapterComboBox1.Location = new System.Drawing.Point(70, 32);
			this.ataChapterComboBox1.Name = "ataChapterComboBox1";
			this.ataChapterComboBox1.Size = new System.Drawing.Size(397, 21);
			this.ataChapterComboBox1.TabIndex = 209;
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
			this.Size = new System.Drawing.Size(746, 194);
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textPNOn;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioMaintenanceStaff;
		private System.Windows.Forms.RadioButton radioCrew;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textCorrectiveAction;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter5;
		private System.Windows.Forms.TextBox textDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelExtendable;
		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
		private System.Windows.Forms.NumericUpDown numericUpDownIndex;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private System.Windows.Forms.Panel panelRelease;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox1;
	}
}
