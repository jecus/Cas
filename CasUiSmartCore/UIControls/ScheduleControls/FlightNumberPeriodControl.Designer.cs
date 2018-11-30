namespace CAS.UI.UIControls.ScheduleControls
{
	partial class FlightNumberPeriodControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label label18;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightNumberPeriodControl));
			this.dateTimePickerTakeOff = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDG = new System.Windows.Forms.DateTimePicker();
			this.label14 = new System.Windows.Forms.Label();
			this.textFlight = new System.Windows.Forms.TextBox();
			this.dateTimePickerDep = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePickerArrival = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.checkMonday = new System.Windows.Forms.CheckBox();
			this.checkBoxTuesday = new System.Windows.Forms.CheckBox();
			this.checkBoxWednesday = new System.Windows.Forms.CheckBox();
			this.checkBoxThursday = new System.Windows.Forms.CheckBox();
			this.checkBoxFriday = new System.Windows.Forms.CheckBox();
			this.checkBoxSaturday = new System.Windows.Forms.CheckBox();
			this.checkBoxSunday = new System.Windows.Forms.CheckBox();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.radioButtonWinter = new System.Windows.Forms.RadioButton();
			this.radioButtonSummer = new System.Windows.Forms.RadioButton();
			label18 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label18.Location = new System.Drawing.Point(631, 7);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(75, 14);
			label18.TabIndex = 131;
			label18.Text = "Document:";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePickerTakeOff
			// 
			this.dateTimePickerTakeOff.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOff.Location = new System.Drawing.Point(36, 2);
			this.dateTimePickerTakeOff.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTakeOff.Name = "dateTimePickerTakeOff";
			this.dateTimePickerTakeOff.ShowUpDown = true;
			this.dateTimePickerTakeOff.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerTakeOff.TabIndex = 38;
			this.dateTimePickerTakeOff.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOff_ValueChanged);
			// 
			// dateTimePickerLDG
			// 
			this.dateTimePickerLDG.CustomFormat = "HH:mm";
			this.dateTimePickerLDG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerLDG.Location = new System.Drawing.Point(120, 2);
			this.dateTimePickerLDG.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerLDG.Name = "dateTimePickerLDG";
			this.dateTimePickerLDG.ShowUpDown = true;
			this.dateTimePickerLDG.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerLDG.TabIndex = 39;
			this.dateTimePickerLDG.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOff_ValueChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(181, 5);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 13);
			this.label14.TabIndex = 41;
			this.label14.Text = "Flight";
			// 
			// textFlight
			// 
			this.textFlight.Location = new System.Drawing.Point(219, 2);
			this.textFlight.Name = "textFlight";
			this.textFlight.ReadOnly = true;
			this.textFlight.Size = new System.Drawing.Size(45, 20);
			this.textFlight.TabIndex = 40;
			this.textFlight.TabStop = false;
			this.textFlight.Text = "03:40";
			// 
			// dateTimePickerDep
			// 
			this.dateTimePickerDep.Location = new System.Drawing.Point(305, 2);
			this.dateTimePickerDep.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerDep.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerDep.Name = "dateTimePickerDep";
			this.dateTimePickerDep.Size = new System.Drawing.Size(137, 20);
			this.dateTimePickerDep.TabIndex = 43;
			this.dateTimePickerDep.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(270, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 42;
			this.label4.Text = "From";
			// 
			// dateTimePickerArrival
			// 
			this.dateTimePickerArrival.Location = new System.Drawing.Point(472, 2);
			this.dateTimePickerArrival.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerArrival.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerArrival.Name = "dateTimePickerArrival";
			this.dateTimePickerArrival.Size = new System.Drawing.Size(137, 20);
			this.dateTimePickerArrival.TabIndex = 45;
			this.dateTimePickerArrival.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(447, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 44;
			this.label1.Text = "Till";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 13);
			this.label2.TabIndex = 46;
			this.label2.Text = "Dep";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(97, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 13);
			this.label3.TabIndex = 47;
			this.label3.Text = "Arr";
			// 
			// checkMonday
			// 
			this.checkMonday.AutoSize = true;
			this.checkMonday.Location = new System.Drawing.Point(49, 29);
			this.checkMonday.Name = "checkMonday";
			this.checkMonday.Size = new System.Drawing.Size(47, 17);
			this.checkMonday.TabIndex = 48;
			this.checkMonday.Text = "1Mo";
			this.checkMonday.UseVisualStyleBackColor = true;
			// 
			// checkBoxTuesday
			// 
			this.checkBoxTuesday.AutoSize = true;
			this.checkBoxTuesday.Location = new System.Drawing.Point(102, 29);
			this.checkBoxTuesday.Name = "checkBoxTuesday";
			this.checkBoxTuesday.Size = new System.Drawing.Size(45, 17);
			this.checkBoxTuesday.TabIndex = 49;
			this.checkBoxTuesday.Text = "2Tu";
			this.checkBoxTuesday.UseVisualStyleBackColor = true;
			// 
			// checkBoxWednesday
			// 
			this.checkBoxWednesday.AutoSize = true;
			this.checkBoxWednesday.Location = new System.Drawing.Point(153, 29);
			this.checkBoxWednesday.Name = "checkBoxWednesday";
			this.checkBoxWednesday.Size = new System.Drawing.Size(49, 17);
			this.checkBoxWednesday.TabIndex = 50;
			this.checkBoxWednesday.Text = "3We";
			this.checkBoxWednesday.UseVisualStyleBackColor = true;
			// 
			// checkBoxThursday
			// 
			this.checkBoxThursday.AutoSize = true;
			this.checkBoxThursday.Location = new System.Drawing.Point(208, 29);
			this.checkBoxThursday.Name = "checkBoxThursday";
			this.checkBoxThursday.Size = new System.Drawing.Size(45, 17);
			this.checkBoxThursday.TabIndex = 51;
			this.checkBoxThursday.Text = "4Th";
			this.checkBoxThursday.UseVisualStyleBackColor = true;
			// 
			// checkBoxFriday
			// 
			this.checkBoxFriday.AutoSize = true;
			this.checkBoxFriday.Location = new System.Drawing.Point(259, 29);
			this.checkBoxFriday.Name = "checkBoxFriday";
			this.checkBoxFriday.Size = new System.Drawing.Size(41, 17);
			this.checkBoxFriday.TabIndex = 52;
			this.checkBoxFriday.Text = "5Fr";
			this.checkBoxFriday.UseVisualStyleBackColor = true;
			// 
			// checkBoxSaturday
			// 
			this.checkBoxSaturday.AutoSize = true;
			this.checkBoxSaturday.Location = new System.Drawing.Point(306, 29);
			this.checkBoxSaturday.Name = "checkBoxSaturday";
			this.checkBoxSaturday.Size = new System.Drawing.Size(45, 17);
			this.checkBoxSaturday.TabIndex = 53;
			this.checkBoxSaturday.Text = "6Sa";
			this.checkBoxSaturday.UseVisualStyleBackColor = true;
			// 
			// checkBoxSunday
			// 
			this.checkBoxSunday.AutoSize = true;
			this.checkBoxSunday.Location = new System.Drawing.Point(357, 29);
			this.checkBoxSunday.Name = "checkBoxSunday";
			this.checkBoxSunday.Size = new System.Drawing.Size(45, 17);
			this.checkBoxSunday.TabIndex = 54;
			this.checkBoxSunday.Text = "7Su";
			this.checkBoxSunday.UseVisualStyleBackColor = true;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(0, 74);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(1040, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 127;
			// 
			// linkLabelRemove
			// 
			this.linkLabelRemove.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemove.Location = new System.Drawing.Point(274, 49);
			this.linkLabelRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelRemove.Name = "linkLabelRemove";
			this.linkLabelRemove.Size = new System.Drawing.Size(120, 24);
			this.linkLabelRemove.TabIndex = 128;
			this.linkLabelRemove.TabStop = true;
			this.linkLabelRemove.Text = "Remove";
			this.linkLabelRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked);
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(621, 0);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 75);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 129;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 29);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(37, 17);
			this.checkBox1.TabIndex = 130;
			this.checkBox1.Text = "All";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(712, 5);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(314, 41);
			this.documentControl1.TabIndex = 132;
			// 
			// radioButtonWinter
			// 
			this.radioButtonWinter.AutoSize = true;
			this.radioButtonWinter.Location = new System.Drawing.Point(472, 28);
			this.radioButtonWinter.Name = "radioButtonWinter";
			this.radioButtonWinter.Size = new System.Drawing.Size(56, 17);
			this.radioButtonWinter.TabIndex = 133;
			this.radioButtonWinter.TabStop = true;
			this.radioButtonWinter.Text = "Winter";
			this.radioButtonWinter.UseVisualStyleBackColor = true;
			this.radioButtonWinter.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButtonSummer
			// 
			this.radioButtonSummer.AutoSize = true;
			this.radioButtonSummer.Location = new System.Drawing.Point(472, 49);
			this.radioButtonSummer.Name = "radioButtonSummer";
			this.radioButtonSummer.Size = new System.Drawing.Size(63, 17);
			this.radioButtonSummer.TabIndex = 134;
			this.radioButtonSummer.TabStop = true;
			this.radioButtonSummer.Text = "Summer";
			this.radioButtonSummer.UseVisualStyleBackColor = true;
			this.radioButtonSummer.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// FlightNumberPeriodControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.radioButtonSummer);
			this.Controls.Add(this.radioButtonWinter);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(label18);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.linkLabelRemove);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.checkBoxSunday);
			this.Controls.Add(this.checkBoxSaturday);
			this.Controls.Add(this.checkBoxFriday);
			this.Controls.Add(this.checkBoxThursday);
			this.Controls.Add(this.checkBoxWednesday);
			this.Controls.Add(this.checkBoxTuesday);
			this.Controls.Add(this.checkMonday);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePickerArrival);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePickerDep);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dateTimePickerTakeOff);
			this.Controls.Add(this.dateTimePickerLDG);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textFlight);
			this.Name = "FlightNumberPeriodControl";
			this.Size = new System.Drawing.Size(1050, 79);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOff;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDG;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textFlight;
		private System.Windows.Forms.DateTimePicker dateTimePickerDep;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dateTimePickerArrival;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkMonday;
		private System.Windows.Forms.CheckBox checkBoxTuesday;
		private System.Windows.Forms.CheckBox checkBoxWednesday;
		private System.Windows.Forms.CheckBox checkBoxThursday;
		private System.Windows.Forms.CheckBox checkBoxFriday;
		private System.Windows.Forms.CheckBox checkBoxSaturday;
		private System.Windows.Forms.CheckBox checkBoxSunday;
		private Auxiliary.Delimiter delimiter1;
		private System.Windows.Forms.LinkLabel linkLabelRemove;
		private Auxiliary.Delimiter delimiter2;
		private System.Windows.Forms.CheckBox checkBox1;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.RadioButton radioButtonWinter;
		private System.Windows.Forms.RadioButton radioButtonSummer;
	}
}
