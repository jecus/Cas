using MetroFramework.Controls;

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
			MetroFramework.Controls.MetroLabel labelNumber;
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel label2;
			MetroFramework.Controls.MetroLabel label3;
			this.flightNumberListViewAll = new CAS.UI.UIControls.ScheduleControls.FlightNumberListView();
			this.flightNumberListView2 = new CAS.UI.UIControls.ScheduleControls.FlightNumberListView();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxDayOfWeek = new System.Windows.Forms.ComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.lookupComboboxTrip = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
			this.panel1 = new MetroFramework.Controls.MetroPanel();
			this.radioButtonSummer = new MetroFramework.Controls.MetroRadioButton();
			this.radioButtonWinter = new MetroFramework.Controls.MetroRadioButton();
			this.panel2 = new MetroFramework.Controls.MetroPanel();
			this.radioButtonUnSchedule = new MetroFramework.Controls.MetroRadioButton();
			this.radioButtonSchedule = new MetroFramework.Controls.MetroRadioButton();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.ButtonFilter = new AvControls.AvButtonT.AvButtonT();
			labelNumber = new MetroFramework.Controls.MetroLabel();
			label1 = new MetroFramework.Controls.MetroLabel();
			label2 = new MetroFramework.Controls.MetroLabel();
			label3 = new MetroFramework.Controls.MetroLabel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(11, 63);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(81, 19);
			labelNumber.TabIndex = 28;
			labelNumber.Text = "Track Name:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(11, 93);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(86, 19);
			label1.TabIndex = 30;
			label1.Text = "Day of Week:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(446, 93);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 19);
			label2.TabIndex = 210;
			label2.Text = "Remarks:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(446, 63);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(70, 19);
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
			this.flightNumberListViewAll.Location = new System.Drawing.Point(11, 119);
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
			this.flightNumberListView2.Location = new System.Drawing.Point(11, 393);
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
			this.buttonDelete.Location = new System.Drawing.Point(1068, 680);
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
			this.buttonAdd.Location = new System.Drawing.Point(1159, 680);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(96, 33);
			this.buttonAdd.TabIndex = 40;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(302, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(525, 93);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(320, 20);
			this.textBoxRemarks.TabIndex = 211;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxDayOfWeek
			// 
			this.comboBoxDayOfWeek.FormattingEnabled = true;
			this.comboBoxDayOfWeek.Location = new System.Drawing.Point(105, 93);
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
			this.buttonOk.Location = new System.Drawing.Point(987, 680);
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
			this.lookupComboboxTrip.Location = new System.Drawing.Point(105, 63);
			this.lookupComboboxTrip.Name = "lookupComboboxTrip";
			this.lookupComboboxTrip.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxTrip.Size = new System.Drawing.Size(320, 21);
			this.lookupComboboxTrip.TabIndex = 244;
			this.lookupComboboxTrip.Type = null;
			// 
			// comboBoxCustomer
			// 
			this.comboBoxCustomer.FormattingEnabled = true;
			this.comboBoxCustomer.Location = new System.Drawing.Point(525, 63);
			this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxCustomer.Name = "comboBoxCustomer";
			this.comboBoxCustomer.Size = new System.Drawing.Size(320, 21);
			this.comboBoxCustomer.TabIndex = 246;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButtonSummer);
			this.panel1.Controls.Add(this.radioButtonWinter);
			this.panel1.HorizontalScrollbarBarColor = true;
			this.panel1.HorizontalScrollbarHighlightOnWheel = false;
			this.panel1.HorizontalScrollbarSize = 10;
			this.panel1.Location = new System.Drawing.Point(851, 63);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(187, 21);
			this.panel1.TabIndex = 247;
			this.panel1.VerticalScrollbarBarColor = true;
			this.panel1.VerticalScrollbarHighlightOnWheel = false;
			this.panel1.VerticalScrollbarSize = 10;
			// 
			// radioButtonSummer
			// 
			this.radioButtonSummer.AutoSize = true;
			this.radioButtonSummer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonSummer.Location = new System.Drawing.Point(88, 3);
			this.radioButtonSummer.Name = "radioButtonSummer";
			this.radioButtonSummer.Size = new System.Drawing.Size(68, 15);
			this.radioButtonSummer.TabIndex = 1;
			this.radioButtonSummer.TabStop = true;
			this.radioButtonSummer.Text = "Summer";
			this.radioButtonSummer.UseSelectable = true;
			this.radioButtonSummer.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// radioButtonWinter
			// 
			this.radioButtonWinter.AutoSize = true;
			this.radioButtonWinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonWinter.Location = new System.Drawing.Point(3, 3);
			this.radioButtonWinter.Name = "radioButtonWinter";
			this.radioButtonWinter.Size = new System.Drawing.Size(58, 15);
			this.radioButtonWinter.TabIndex = 0;
			this.radioButtonWinter.TabStop = true;
			this.radioButtonWinter.Text = "Winter";
			this.radioButtonWinter.UseSelectable = true;
			this.radioButtonWinter.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.radioButtonUnSchedule);
			this.panel2.Controls.Add(this.radioButtonSchedule);
			this.panel2.HorizontalScrollbarBarColor = true;
			this.panel2.HorizontalScrollbarHighlightOnWheel = false;
			this.panel2.HorizontalScrollbarSize = 10;
			this.panel2.Location = new System.Drawing.Point(851, 93);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(187, 21);
			this.panel2.TabIndex = 248;
			this.panel2.VerticalScrollbarBarColor = true;
			this.panel2.VerticalScrollbarHighlightOnWheel = false;
			this.panel2.VerticalScrollbarSize = 10;
			// 
			// radioButtonUnSchedule
			// 
			this.radioButtonUnSchedule.AutoSize = true;
			this.radioButtonUnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonUnSchedule.Location = new System.Drawing.Point(88, 3);
			this.radioButtonUnSchedule.Name = "radioButtonUnSchedule";
			this.radioButtonUnSchedule.Size = new System.Drawing.Size(86, 15);
			this.radioButtonUnSchedule.TabIndex = 1;
			this.radioButtonUnSchedule.TabStop = true;
			this.radioButtonUnSchedule.Text = "UnSchedule";
			this.radioButtonUnSchedule.UseSelectable = true;
			this.radioButtonUnSchedule.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// radioButtonSchedule
			// 
			this.radioButtonSchedule.AutoSize = true;
			this.radioButtonSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonSchedule.Location = new System.Drawing.Point(3, 3);
			this.radioButtonSchedule.Name = "radioButtonSchedule";
			this.radioButtonSchedule.Size = new System.Drawing.Size(71, 15);
			this.radioButtonSchedule.TabIndex = 0;
			this.radioButtonSchedule.TabStop = true;
			this.radioButtonSchedule.Text = "Schedule";
			this.radioButtonSchedule.UseSelectable = true;
			this.radioButtonSchedule.CheckedChanged += new System.EventHandler(this.RadioButtonOnClick);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(1249, 60);
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
			this.ButtonFilter.Location = new System.Drawing.Point(1204, 64);
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
			this.ClientSize = new System.Drawing.Size(1262, 725);
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
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackForm";
			this.Resizable = false;
			this.ShowIcon = false;
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
		private MetroTextBox textBoxRemarks;
		private System.Windows.Forms.ComboBox comboBoxDayOfWeek;
		private System.Windows.Forms.Button buttonOk;
		private Auxiliary.LookupCombobox lookupComboboxTrip;
		private System.Windows.Forms.ComboBox comboBoxCustomer;
		private MetroPanel panel1;
		private MetroRadioButton radioButtonSummer;
		private MetroRadioButton radioButtonWinter;
		private MetroPanel panel2;
		private MetroRadioButton radioButtonUnSchedule;
		private MetroRadioButton radioButtonSchedule;
		private System.Windows.Forms.PictureBox pictureBox2;
		private AvControls.AvButtonT.AvButtonT ButtonFilter;
	}
}