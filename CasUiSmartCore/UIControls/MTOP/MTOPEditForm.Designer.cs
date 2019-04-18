using MetroFramework.Controls;

namespace CAS.UI.UIControls.MTOP
{
	partial class MTOPEditForm
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
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel label4;
			System.Windows.Forms.GroupBox groupBox2;
			this._lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this._lifelengthViewerTresh = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this._lifelengthViewerRepeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			this._comboBoxCheckType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this._textBoxName = new MetroFramework.Controls.MetroTextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			label1 = new MetroFramework.Controls.MetroLabel();
			label4 = new MetroFramework.Controls.MetroLabel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(6, 41);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(78, 19);
			label1.TabIndex = 12;
			label1.Text = "Check Type:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label4.Location = new System.Drawing.Point(6, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(48, 19);
			label4.TabIndex = 11;
			label4.Text = "Name:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this._lifelengthViewerNotify);
			groupBox2.Controls.Add(this._lifelengthViewerTresh);
			groupBox2.Controls.Add(this._lifelengthViewerRepeat);
			groupBox2.Location = new System.Drawing.Point(12, 169);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(474, 143);
			groupBox2.TabIndex = 6;
			groupBox2.TabStop = false;
			// 
			// _lifelengthViewerNotify
			// 
			this._lifelengthViewerNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lifelengthViewerNotify.AutoSize = true;
			this._lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._lifelengthViewerNotify.CalendarApplicable = false;
			this._lifelengthViewerNotify.CyclesApplicable = false;
			this._lifelengthViewerNotify.EnabledCalendar = true;
			this._lifelengthViewerNotify.EnabledCycle = true;
			this._lifelengthViewerNotify.EnabledHours = true;
			this._lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this._lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
			this._lifelengthViewerNotify.HeaderCalendar = "Calendar";
			this._lifelengthViewerNotify.HeaderCycles = "Cycles";
			this._lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
			this._lifelengthViewerNotify.HeaderHours = "Hours";
			this._lifelengthViewerNotify.HoursApplicable = false;
			this._lifelengthViewerNotify.LeftHeader = "Notify";
			this._lifelengthViewerNotify.Location = new System.Drawing.Point(26, 99);
			this._lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(2);
			this._lifelengthViewerNotify.Modified = false;
			this._lifelengthViewerNotify.Name = "_lifelengthViewerNotify";
			this._lifelengthViewerNotify.ReadOnly = false;
			this._lifelengthViewerNotify.ShowCalendar = true;
			this._lifelengthViewerNotify.ShowFormattedCalendar = false;
			this._lifelengthViewerNotify.ShowHeaders = false;
			this._lifelengthViewerNotify.ShowMinutes = true;
			this._lifelengthViewerNotify.Size = new System.Drawing.Size(407, 35);
			this._lifelengthViewerNotify.SystemCalculated = true;
			this._lifelengthViewerNotify.TabIndex = 7;
			// 
			// _lifelengthViewerTresh
			// 
			this._lifelengthViewerTresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lifelengthViewerTresh.AutoSize = true;
			this._lifelengthViewerTresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._lifelengthViewerTresh.CalendarApplicable = false;
			this._lifelengthViewerTresh.CyclesApplicable = false;
			this._lifelengthViewerTresh.EnabledCalendar = true;
			this._lifelengthViewerTresh.EnabledCycle = true;
			this._lifelengthViewerTresh.EnabledHours = true;
			this._lifelengthViewerTresh.FieldsBackColor = System.Drawing.SystemColors.Window;
			this._lifelengthViewerTresh.ForeColor = System.Drawing.Color.DimGray;
			this._lifelengthViewerTresh.HeaderCalendar = "Calendar";
			this._lifelengthViewerTresh.HeaderCycles = "Cycles";
			this._lifelengthViewerTresh.HeaderFormattedCalendar = "Calendar";
			this._lifelengthViewerTresh.HeaderHours = "Hours";
			this._lifelengthViewerTresh.HoursApplicable = false;
			this._lifelengthViewerTresh.LeftHeader = "Thresh";
			this._lifelengthViewerTresh.Location = new System.Drawing.Point(17, 9);
			this._lifelengthViewerTresh.Margin = new System.Windows.Forms.Padding(2);
			this._lifelengthViewerTresh.Modified = false;
			this._lifelengthViewerTresh.Name = "_lifelengthViewerTresh";
			this._lifelengthViewerTresh.ReadOnly = false;
			this._lifelengthViewerTresh.ShowCalendar = true;
			this._lifelengthViewerTresh.ShowFormattedCalendar = false;
			this._lifelengthViewerTresh.ShowMinutes = true;
			this._lifelengthViewerTresh.Size = new System.Drawing.Size(415, 52);
			this._lifelengthViewerTresh.SystemCalculated = true;
			this._lifelengthViewerTresh.TabIndex = 5;
			// 
			// _lifelengthViewerRepeat
			// 
			this._lifelengthViewerRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lifelengthViewerRepeat.AutoSize = true;
			this._lifelengthViewerRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._lifelengthViewerRepeat.CalendarApplicable = false;
			this._lifelengthViewerRepeat.CyclesApplicable = false;
			this._lifelengthViewerRepeat.EnabledCalendar = true;
			this._lifelengthViewerRepeat.EnabledCycle = true;
			this._lifelengthViewerRepeat.EnabledHours = true;
			this._lifelengthViewerRepeat.FieldsBackColor = System.Drawing.SystemColors.Window;
			this._lifelengthViewerRepeat.ForeColor = System.Drawing.Color.DimGray;
			this._lifelengthViewerRepeat.HeaderCalendar = "Calendar";
			this._lifelengthViewerRepeat.HeaderCycles = "Cycles";
			this._lifelengthViewerRepeat.HeaderFormattedCalendar = "Calendar";
			this._lifelengthViewerRepeat.HeaderHours = "Hours";
			this._lifelengthViewerRepeat.HoursApplicable = false;
			this._lifelengthViewerRepeat.LeftHeader = "Repeat";
			this._lifelengthViewerRepeat.Location = new System.Drawing.Point(18, 60);
			this._lifelengthViewerRepeat.Margin = new System.Windows.Forms.Padding(2);
			this._lifelengthViewerRepeat.Modified = false;
			this._lifelengthViewerRepeat.Name = "_lifelengthViewerRepeat";
			this._lifelengthViewerRepeat.ReadOnly = false;
			this._lifelengthViewerRepeat.ShowCalendar = true;
			this._lifelengthViewerRepeat.ShowFormattedCalendar = false;
			this._lifelengthViewerRepeat.ShowHeaders = false;
			this._lifelengthViewerRepeat.ShowMinutes = true;
			this._lifelengthViewerRepeat.Size = new System.Drawing.Size(415, 35);
			this._lifelengthViewerRepeat.SystemCalculated = true;
			this._lifelengthViewerRepeat.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this._comboBoxCheckType);
			this.groupBox1.Controls.Add(label1);
			this.groupBox1.Controls.Add(label4);
			this.groupBox1.Controls.Add(this._textBoxName);
			this.groupBox1.Location = new System.Drawing.Point(12, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(474, 100);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBox1.Location = new System.Drawing.Point(339, 68);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(92, 15);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Text = "Is Zero Phase";
			this.checkBox1.UseSelectable = true;
			// 
			// _comboBoxCheckType
			// 
			this._comboBoxCheckType.Displayer = null;
			this._comboBoxCheckType.DisplayerText = null;
			this._comboBoxCheckType.Entity = null;
			this._comboBoxCheckType.Location = new System.Drawing.Point(142, 41);
			this._comboBoxCheckType.Name = "_comboBoxCheckType";
			this._comboBoxCheckType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this._comboBoxCheckType.Size = new System.Drawing.Size(326, 21);
			this._comboBoxCheckType.TabIndex = 11;
			// 
			// _textBoxName
			// 
			// 
			// 
			// 
			this._textBoxName.CustomButton.Image = null;
			this._textBoxName.CustomButton.Location = new System.Drawing.Point(308, 2);
			this._textBoxName.CustomButton.Name = "";
			this._textBoxName.CustomButton.Size = new System.Drawing.Size(15, 15);
			this._textBoxName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this._textBoxName.CustomButton.TabIndex = 1;
			this._textBoxName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this._textBoxName.CustomButton.UseSelectable = true;
			this._textBoxName.CustomButton.Visible = false;
			this._textBoxName.Lines = new string[0];
			this._textBoxName.Location = new System.Drawing.Point(142, 15);
			this._textBoxName.MaxLength = 32767;
			this._textBoxName.Name = "_textBoxName";
			this._textBoxName.PasswordChar = '\0';
			this._textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._textBoxName.SelectedText = "";
			this._textBoxName.SelectionLength = 0;
			this._textBoxName.SelectionStart = 0;
			this._textBoxName.ShortcutsEnabled = true;
			this._textBoxName.Size = new System.Drawing.Size(326, 20);
			this._textBoxName.TabIndex = 0;
			this._textBoxName.UseSelectable = true;
			this._textBoxName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this._textBoxName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(411, 319);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 280;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(320, 319);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(85, 33);
			this.buttonOk.TabIndex = 279;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// MTOPEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(495, 358);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MTOPEditForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "MTOP Edit Form";
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private Auxiliary.DictionaryComboBox _comboBoxCheckType;
		private MetroTextBox _textBoxName;
		private Auxiliary.LifelengthViewer _lifelengthViewerTresh;
		private Auxiliary.LifelengthViewer _lifelengthViewerRepeat;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private Auxiliary.LifelengthViewer _lifelengthViewerNotify;
		private MetroCheckBox checkBox1;
	}
}