namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	partial class TrackForm
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
			System.Windows.Forms.Label labelNumber;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			this.flightNumberListViewAll = new CAS.UI.UIControls.ScheduleControls.FlightNumberListView();
			this.flightNumberListView2 = new CAS.UI.UIControls.ScheduleControls.FlightNumberListView();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.comboBoxDayOfWeek = new System.Windows.Forms.ComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.lookupComboboxTrip = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButtonSummer = new System.Windows.Forms.RadioButton();
			this.radioButtonWinter = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioButtonUnSchedule = new System.Windows.Forms.RadioButton();
			this.radioButtonSchedule = new System.Windows.Forms.RadioButton();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.ButtonFilter = new AvControls.AvButtonT.AvButtonT();
			labelNumber = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(12, 9);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(84, 14);
			labelNumber.TabIndex = 28;
			labelNumber.Text = "Track Name:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(12, 39);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(91, 14);
			label1.TabIndex = 30;
			label1.Text = "Day of Week:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(450, 39);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 14);
			label2.TabIndex = 210;
			label2.Text = "Remarks:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(450, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(73, 14);
			label3.TabIndex = 245;
			label3.Text = "Customer:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// flightNumberListViewAll
			// 
			this.flightNumberListViewAll.Displayer = null;
			this.flightNumberListViewAll.DisplayerText = null;
			this.flightNumberListViewAll.Entity = null;
			this.flightNumberListViewAll.IgnoreAutoResize = false;
			this.flightNumberListViewAll.Location = new System.Drawing.Point(15, 61);
			this.flightNumberListViewAll.Name = "flightNumberListViewAll";
			this.flightNumberListViewAll.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.flightNumberListViewAll.ShowGroups = true;
			this.flightNumberListViewAll.Size = new System.Drawing.Size(1244, 268);
			this.flightNumberListViewAll.TabIndex = 38;
			// 
			// flightNumberListView2
			// 
			this.flightNumberListView2.Displayer = null;
			this.flightNumberListView2.DisplayerText = null;
			this.flightNumberListView2.Entity = null;
			this.flightNumberListView2.IgnoreAutoResize = false;
			this.flightNumberListView2.Location = new System.Drawing.Point(15, 335);
			this.flightNumberListView2.Name = "flightNumberListView2";
			this.flightNumberListView2.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.flightNumberListView2.ShowGroups = true;
			this.flightNumberListView2.Size = new System.Drawing.Size(1244, 272);
			this.flightNumberListView2.TabIndex = 39;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(1063, 625);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 42;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAdd.Location = new System.Drawing.Point(1154, 625);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(96, 33);
			this.buttonAdd.TabIndex = 40;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Location = new System.Drawing.Point(529, 35);
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(320, 20);
			this.textBoxRemarks.TabIndex = 211;
			// 
			// comboBoxDayOfWeek
			// 
			this.comboBoxDayOfWeek.FormattingEnabled = true;
			this.comboBoxDayOfWeek.Location = new System.Drawing.Point(109, 37);
			this.comboBoxDayOfWeek.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxDayOfWeek.Name = "comboBoxDayOfWeek";
			this.comboBoxDayOfWeek.Size = new System.Drawing.Size(320, 21);
			this.comboBoxDayOfWeek.TabIndex = 212;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(982, 625);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 243;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// lookupComboboxTrip
			// 
			this.lookupComboboxTrip.Displayer = null;
			this.lookupComboboxTrip.DisplayerText = null;
			this.lookupComboboxTrip.Entity = null;
			this.lookupComboboxTrip.Location = new System.Drawing.Point(109, 5);
			this.lookupComboboxTrip.Name = "lookupComboboxTrip";
			this.lookupComboboxTrip.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxTrip.Size = new System.Drawing.Size(320, 21);
			this.lookupComboboxTrip.TabIndex = 244;
			this.lookupComboboxTrip.Type = null;
			// 
			// comboBoxCustomer
			// 
			this.comboBoxCustomer.FormattingEnabled = true;
			this.comboBoxCustomer.Location = new System.Drawing.Point(529, 5);
			this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxCustomer.Name = "comboBoxCustomer";
			this.comboBoxCustomer.Size = new System.Drawing.Size(320, 21);
			this.comboBoxCustomer.TabIndex = 246;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButtonSummer);
			this.panel1.Controls.Add(this.radioButtonWinter);
			this.panel1.Location = new System.Drawing.Point(855, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(187, 21);
			this.panel1.TabIndex = 247;
			// 
			// radioButtonSummer
			// 
			this.radioButtonSummer.AutoSize = true;
			this.radioButtonSummer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButtonSummer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonSummer.Location = new System.Drawing.Point(88, 1);
			this.radioButtonSummer.Name = "radioButtonSummer";
			this.radioButtonSummer.Size = new System.Drawing.Size(76, 18);
			this.radioButtonSummer.TabIndex = 1;
			this.radioButtonSummer.TabStop = true;
			this.radioButtonSummer.Text = "Summer";
			this.radioButtonSummer.UseVisualStyleBackColor = true;
			this.radioButtonSummer.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// radioButtonWinter
			// 
			this.radioButtonWinter.AutoSize = true;
			this.radioButtonWinter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButtonWinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonWinter.Location = new System.Drawing.Point(3, 1);
			this.radioButtonWinter.Name = "radioButtonWinter";
			this.radioButtonWinter.Size = new System.Drawing.Size(67, 18);
			this.radioButtonWinter.TabIndex = 0;
			this.radioButtonWinter.TabStop = true;
			this.radioButtonWinter.Text = "Winter";
			this.radioButtonWinter.UseVisualStyleBackColor = true;
			this.radioButtonWinter.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.radioButtonUnSchedule);
			this.panel2.Controls.Add(this.radioButtonSchedule);
			this.panel2.Location = new System.Drawing.Point(855, 35);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(187, 21);
			this.panel2.TabIndex = 248;
			// 
			// radioButtonUnSchedule
			// 
			this.radioButtonUnSchedule.AutoSize = true;
			this.radioButtonUnSchedule.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButtonUnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonUnSchedule.Location = new System.Drawing.Point(88, 0);
			this.radioButtonUnSchedule.Name = "radioButtonUnSchedule";
			this.radioButtonUnSchedule.Size = new System.Drawing.Size(99, 18);
			this.radioButtonUnSchedule.TabIndex = 1;
			this.radioButtonUnSchedule.TabStop = true;
			this.radioButtonUnSchedule.Text = "UnSchedule";
			this.radioButtonUnSchedule.UseVisualStyleBackColor = true;
			this.radioButtonUnSchedule.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// radioButtonSchedule
			// 
			this.radioButtonSchedule.AutoSize = true;
			this.radioButtonSchedule.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButtonSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonSchedule.Location = new System.Drawing.Point(3, 1);
			this.radioButtonSchedule.Name = "radioButtonSchedule";
			this.radioButtonSchedule.Size = new System.Drawing.Size(82, 18);
			this.radioButtonSchedule.TabIndex = 0;
			this.radioButtonSchedule.TabStop = true;
			this.radioButtonSchedule.Text = "Schedule";
			this.radioButtonSchedule.UseVisualStyleBackColor = true;
			this.radioButtonSchedule.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(1253, 2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 250;
			this.pictureBox2.TabStop = false;
			// 
			// ButtonFilter
			// 
			this.ButtonFilter.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonFilter.ActiveBackgroundImage = null;
			this.ButtonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonFilter.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonFilter.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.ButtonFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonFilter.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.ButtonFilter.Location = new System.Drawing.Point(1208, 6);
			this.ButtonFilter.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonFilter.Name = "ButtonFilter";
			this.ButtonFilter.NormalBackgroundImage = null;
			this.ButtonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.ShowToolTip = true;
			this.ButtonFilter.Size = new System.Drawing.Size(42, 38);
			this.ButtonFilter.TabIndex = 249;
			this.ButtonFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextMain = "";
			this.ButtonFilter.TextSecondary = "";
			this.ButtonFilter.ToolTipText = "Add Item";
			this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
			// 
			// TrackForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 670);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.ButtonFilter);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.comboBoxCustomer);
			this.Controls.Add(label3);
			this.Controls.Add(this.lookupComboboxTrip);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.comboBoxDayOfWeek);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(label2);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.flightNumberListView2);
			this.Controls.Add(this.flightNumberListViewAll);
			this.Controls.Add(label1);
			this.Controls.Add(labelNumber);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TrackForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TripForm_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private FlightNumberListView flightNumberListViewAll;
		private FlightNumberListView flightNumberListView2;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.ComboBox comboBoxDayOfWeek;
		private System.Windows.Forms.Button buttonOk;
		private Auxiliary.LookupCombobox lookupComboboxTrip;
		private System.Windows.Forms.ComboBox comboBoxCustomer;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButtonSummer;
		private System.Windows.Forms.RadioButton radioButtonWinter;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioButtonUnSchedule;
		private System.Windows.Forms.RadioButton radioButtonSchedule;
		private System.Windows.Forms.PictureBox pictureBox2;
		private AvControls.AvButtonT.AvButtonT ButtonFilter;
	}
}