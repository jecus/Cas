using MetroFramework.Controls;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceCheckEdit
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
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.Label labelKitRequired;
			System.Windows.Forms.Label labelMainSource;
			this._lifelengthViewerInterval = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this._lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.numericUpDownManHours = new System.Windows.Forms.NumericUpDown();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
			this._textBoxName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._comboBoxCheckType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.checkBoxGrouping = new System.Windows.Forms.CheckBox();
			this.comboBoxMainSource = new System.Windows.Forms.ComboBox();
			this.checkBoxSchedule = new System.Windows.Forms.CheckBox();
			this._buttonCancel = new System.Windows.Forms.Button();
			this._buttonOk = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			labelKitRequired = new System.Windows.Forms.Label();
			labelMainSource = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label4.Location = new System.Drawing.Point(6, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(59, 18);
			label4.TabIndex = 11;
			label4.Text = "Name:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(6, 44);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(101, 18);
			label1.TabIndex = 12;
			label1.Text = "Check Type:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(15, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 18);
			label2.TabIndex = 13;
			label2.Text = "Cost:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(263, 23);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(39, 18);
			label3.TabIndex = 15;
			label3.Text = "MH:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this._lifelengthViewerInterval);
			groupBox2.Controls.Add(this._lifelengthViewerNotify);
			groupBox2.Location = new System.Drawing.Point(2, 171);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(474, 116);
			groupBox2.TabIndex = 5;
			groupBox2.TabStop = false;
			// 
			// _lifelengthViewerInterval
			// 
			this._lifelengthViewerInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lifelengthViewerInterval.AutoSize = true;
			this._lifelengthViewerInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._lifelengthViewerInterval.CalendarApplicable = false;
			this._lifelengthViewerInterval.CyclesApplicable = false;
			this._lifelengthViewerInterval.EnabledCalendar = true;
			this._lifelengthViewerInterval.EnabledCycle = true;
			this._lifelengthViewerInterval.EnabledHours = true;
			this._lifelengthViewerInterval.FieldsBackColor = System.Drawing.SystemColors.Window;
			this._lifelengthViewerInterval.ForeColor = System.Drawing.Color.DimGray;
			this._lifelengthViewerInterval.HeaderCalendar = "Calendar";
			this._lifelengthViewerInterval.HeaderCycles = "Cycles";
			this._lifelengthViewerInterval.HeaderFormattedCalendar = "Calendar";
			this._lifelengthViewerInterval.HeaderHours = "Hours";
			this._lifelengthViewerInterval.HoursApplicable = false;
			this._lifelengthViewerInterval.LeftHeader = "Interval";
			this._lifelengthViewerInterval.Location = new System.Drawing.Point(13, 9);
			this._lifelengthViewerInterval.Margin = new System.Windows.Forms.Padding(2);
			this._lifelengthViewerInterval.Modified = false;
			this._lifelengthViewerInterval.Name = "_lifelengthViewerInterval";
			this._lifelengthViewerInterval.ReadOnly = false;
			this._lifelengthViewerInterval.ShowCalendar = true;
			this._lifelengthViewerInterval.ShowFormattedCalendar = false;
			this._lifelengthViewerInterval.ShowMinutes = true;
			this._lifelengthViewerInterval.Size = new System.Drawing.Size(419, 52);
			this._lifelengthViewerInterval.SystemCalculated = true;
			this._lifelengthViewerInterval.TabIndex = 5;
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
			this._lifelengthViewerNotify.Location = new System.Drawing.Point(26, 60);
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
			this._lifelengthViewerNotify.TabIndex = 6;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(this.linkLabelEditKit);
			groupBox3.Controls.Add(labelKitRequired);
			groupBox3.Controls.Add(this.numericUpDownManHours);
			groupBox3.Controls.Add(this.textBoxKitRequired);
			groupBox3.Controls.Add(this.numericUpDownCost);
			groupBox3.Controls.Add(label3);
			groupBox3.Controls.Add(label2);
			groupBox3.Location = new System.Drawing.Point(2, 289);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(474, 93);
			groupBox3.TabIndex = 9;
			groupBox3.TabStop = false;
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(206, 62);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 35;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// labelKitRequired
			// 
			labelKitRequired.AutoSize = true;
			labelKitRequired.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelKitRequired.Location = new System.Drawing.Point(23, 65);
			labelKitRequired.Name = "labelKitRequired";
			labelKitRequired.Size = new System.Drawing.Size(42, 18);
			labelKitRequired.TabIndex = 15;
			labelKitRequired.Text = "Kits:";
			// 
			// numericUpDownManHours
			// 
			this.numericUpDownManHours.DecimalPlaces = 2;
			this.numericUpDownManHours.Location = new System.Drawing.Point(308, 20);
			this.numericUpDownManHours.Maximum = new decimal(new int[] {
			100000000,
			0,
			0,
			0});
			this.numericUpDownManHours.Name = "numericUpDownManHours";
			this.numericUpDownManHours.Size = new System.Drawing.Size(121, 20);
			this.numericUpDownManHours.TabIndex = 18;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Location = new System.Drawing.Point(65, 63);
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(132, 20);
			this.textBoxKitRequired.TabIndex = 14;
			// 
			// numericUpDownCost
			// 
			this.numericUpDownCost.DecimalPlaces = 2;
			this.numericUpDownCost.Location = new System.Drawing.Point(65, 21);
			this.numericUpDownCost.Maximum = new decimal(new int[] {
			1410065408,
			2,
			0,
			0});
			this.numericUpDownCost.Name = "numericUpDownCost";
			this.numericUpDownCost.Size = new System.Drawing.Size(132, 20);
			this.numericUpDownCost.TabIndex = 17;
			// 
			// labelMainSource
			// 
			labelMainSource.AutoSize = true;
			labelMainSource.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			labelMainSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelMainSource.Location = new System.Drawing.Point(6, 71);
			labelMainSource.Name = "labelMainSource";
			labelMainSource.Size = new System.Drawing.Size(119, 18);
			labelMainSource.TabIndex = 15;
			labelMainSource.Text = "Main resource:";
			// 
			// _textBoxName
			// 
			this._textBoxName.Location = new System.Drawing.Point(142, 15);
			this._textBoxName.Name = "_textBoxName";
			this._textBoxName.Size = new System.Drawing.Size(187, 20);
			this._textBoxName.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._comboBoxCheckType);
			this.groupBox1.Controls.Add(this.checkBoxGrouping);
			this.groupBox1.Controls.Add(labelMainSource);
			this.groupBox1.Controls.Add(this.comboBoxMainSource);
			this.groupBox1.Controls.Add(this.checkBoxSchedule);
			this.groupBox1.Controls.Add(label1);
			this.groupBox1.Controls.Add(label4);
			this.groupBox1.Controls.Add(this._textBoxName);
			this.groupBox1.Location = new System.Drawing.Point(2, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(474, 107);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// _comboBoxCheckType
			// 
			this._comboBoxCheckType.Displayer = null;
			this._comboBoxCheckType.DisplayerText = null;
			this._comboBoxCheckType.Entity = null;
			this._comboBoxCheckType.Location = new System.Drawing.Point(142, 41);
			this._comboBoxCheckType.Name = "_comboBoxCheckType";
			this._comboBoxCheckType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this._comboBoxCheckType.Size = new System.Drawing.Size(188, 21);
			this._comboBoxCheckType.TabIndex = 11;
			// 
			// checkBoxGrouping
			// 
			this.checkBoxGrouping.AutoSize = true;
			this.checkBoxGrouping.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxGrouping.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxGrouping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxGrouping.Location = new System.Drawing.Point(335, 69);
			this.checkBoxGrouping.Name = "checkBoxGrouping";
			this.checkBoxGrouping.Size = new System.Drawing.Size(94, 22);
			this.checkBoxGrouping.TabIndex = 16;
			this.checkBoxGrouping.Text = "Grouping";
			this.checkBoxGrouping.UseVisualStyleBackColor = true;
			// 
			// comboBoxMainSource
			// 
			this.comboBoxMainSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMainSource.FormattingEnabled = true;
			this.comboBoxMainSource.Items.AddRange(new object[] {
			"A",
			"B",
			"C"});
			this.comboBoxMainSource.Location = new System.Drawing.Point(142, 70);
			this.comboBoxMainSource.Name = "comboBoxMainSource";
			this.comboBoxMainSource.Size = new System.Drawing.Size(187, 21);
			this.comboBoxMainSource.TabIndex = 14;
			// 
			// checkBoxSchedule
			// 
			this.checkBoxSchedule.AutoSize = true;
			this.checkBoxSchedule.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxSchedule.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxSchedule.Location = new System.Drawing.Point(335, 42);
			this.checkBoxSchedule.Name = "checkBoxSchedule";
			this.checkBoxSchedule.Size = new System.Drawing.Size(93, 22);
			this.checkBoxSchedule.TabIndex = 13;
			this.checkBoxSchedule.Text = "Schedule";
			this.checkBoxSchedule.UseVisualStyleBackColor = true;
			this.checkBoxSchedule.CheckedChanged += new System.EventHandler(this.CheckBoxScheduleCheckedChanged);
			// 
			// _buttonCancel
			// 
			this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this._buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._buttonCancel.Location = new System.Drawing.Point(395, 385);
			this._buttonCancel.Name = "_buttonCancel";
			this._buttonCancel.Size = new System.Drawing.Size(75, 33);
			this._buttonCancel.TabIndex = 8;
			this._buttonCancel.Text = "Cancel";
			this._buttonCancel.UseVisualStyleBackColor = true;
			this._buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// _buttonOk
			// 
			this._buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this._buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._buttonOk.Location = new System.Drawing.Point(314, 385);
			this._buttonOk.Name = "_buttonOk";
			this._buttonOk.Size = new System.Drawing.Size(75, 33);
			this._buttonOk.TabIndex = 7;
			this._buttonOk.Text = "Ok";
			this._buttonOk.UseVisualStyleBackColor = true;
			this._buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// MaintenanceCheckEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 420);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._buttonOk);
			this.Controls.Add(this._buttonCancel);
			this.Name = "MaintenanceCheckEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "MaintenanceCheckEdit";
			this.Load += new System.EventHandler(this.MaintenanceLimitationEditLoad);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox _textBoxName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button _buttonCancel;
		private System.Windows.Forms.Button _buttonOk;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer _lifelengthViewerInterval;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer _lifelengthViewerNotify;
		private System.Windows.Forms.NumericUpDown numericUpDownCost;
		private System.Windows.Forms.NumericUpDown numericUpDownManHours;
		private System.Windows.Forms.CheckBox checkBoxSchedule;
		private System.Windows.Forms.TextBox textBoxKitRequired;
		public System.Windows.Forms.LinkLabel linkLabelEditKit;
		private System.Windows.Forms.CheckBox checkBoxGrouping;
		private System.Windows.Forms.ComboBox comboBoxMainSource;
		private Auxiliary.DictionaryComboBox _comboBoxCheckType;
	}
}