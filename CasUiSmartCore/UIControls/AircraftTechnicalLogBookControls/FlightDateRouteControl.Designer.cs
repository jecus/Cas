using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
	partial class FlightDateRouteControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelPageNum = new System.Windows.Forms.Label();
			this.textBoxPageNum = new System.Windows.Forms.TextBox();
			this.dateTimePickerFlightDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxFlightType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.labelFlightCategory = new System.Windows.Forms.Label();
			this.comboBoxFlightCategory = new System.Windows.Forms.ComboBox();
			this.labelRecordType = new System.Windows.Forms.Label();
			this.comboBoxRecordType = new System.Windows.Forms.ComboBox();
			this.labelAircraftCode = new System.Windows.Forms.Label();
			this.comboBoxAircraftCode = new System.Windows.Forms.ComboBox();
			this.lookupComboboxFrom = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lookupComboboxTo = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.label6 = new System.Windows.Forms.Label();
			this.lookupComboboxFlightNum = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Flight General Information";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Flight No";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 186);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Date";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "From";
			// 
			// labelPageNum
			// 
			this.labelPageNum.AutoSize = true;
			this.labelPageNum.Location = new System.Drawing.Point(3, 82);
			this.labelPageNum.Name = "labelPageNum";
			this.labelPageNum.Size = new System.Drawing.Size(49, 13);
			this.labelPageNum.TabIndex = 14;
			this.labelPageNum.Text = "Page No";
			// 
			// textBoxPageNum
			// 
			this.textBoxPageNum.Location = new System.Drawing.Point(70, 79);
			this.textBoxPageNum.Name = "textBoxPageNum";
			this.textBoxPageNum.Size = new System.Drawing.Size(178, 20);
			this.textBoxPageNum.TabIndex = 13;
			this.textBoxPageNum.Text = "1258";
			// 
			// dateTimePickerFlightDate
			// 
			this.dateTimePickerFlightDate.Location = new System.Drawing.Point(70, 181);
			this.dateTimePickerFlightDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerFlightDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerFlightDate.Name = "dateTimePickerFlightDate";
			this.dateTimePickerFlightDate.Size = new System.Drawing.Size(178, 20);
			this.dateTimePickerFlightDate.TabIndex = 15;
			this.dateTimePickerFlightDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			this.dateTimePickerFlightDate.ValueChanged += new System.EventHandler(this.DateTimePickerFlightDateValueChanged);
			// 
			// comboBoxFlightType
			// 
			this.comboBoxFlightType.FormattingEnabled = true;
			this.comboBoxFlightType.Location = new System.Drawing.Point(70, 105);
			this.comboBoxFlightType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxFlightType.Name = "comboBoxFlightType";
			this.comboBoxFlightType.Size = new System.Drawing.Size(178, 21);
			this.comboBoxFlightType.TabIndex = 16;
			this.comboBoxFlightType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Flight Type";
			// 
			// labelFlightCategory
			// 
			this.labelFlightCategory.AutoSize = true;
			this.labelFlightCategory.Location = new System.Drawing.Point(3, 134);
			this.labelFlightCategory.Name = "labelFlightCategory";
			this.labelFlightCategory.Size = new System.Drawing.Size(54, 13);
			this.labelFlightCategory.TabIndex = 19;
			this.labelFlightCategory.Text = "Flight Cat.";
			// 
			// comboBoxFlightCategory
			// 
			this.comboBoxFlightCategory.FormattingEnabled = true;
			this.comboBoxFlightCategory.Location = new System.Drawing.Point(70, 131);
			this.comboBoxFlightCategory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxFlightCategory.Name = "comboBoxFlightCategory";
			this.comboBoxFlightCategory.Size = new System.Drawing.Size(178, 21);
			this.comboBoxFlightCategory.TabIndex = 18;
			this.comboBoxFlightCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelRecordType
			// 
			this.labelRecordType.AutoSize = true;
			this.labelRecordType.Location = new System.Drawing.Point(3, 30);
			this.labelRecordType.Name = "labelRecordType";
			this.labelRecordType.Size = new System.Drawing.Size(56, 13);
			this.labelRecordType.TabIndex = 21;
			this.labelRecordType.Text = "FL./Maint.";
			// 
			// comboBoxRecordType
			// 
			this.comboBoxRecordType.FormattingEnabled = true;
			this.comboBoxRecordType.Location = new System.Drawing.Point(70, 27);
			this.comboBoxRecordType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxRecordType.Name = "comboBoxRecordType";
			this.comboBoxRecordType.Size = new System.Drawing.Size(178, 21);
			this.comboBoxRecordType.TabIndex = 20;
			this.comboBoxRecordType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecordType_SelectedIndexChanged);
			this.comboBoxRecordType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelAircraftCode
			// 
			this.labelAircraftCode.AutoSize = true;
			this.labelAircraftCode.Location = new System.Drawing.Point(3, 56);
			this.labelAircraftCode.Name = "labelAircraftCode";
			this.labelAircraftCode.Size = new System.Drawing.Size(59, 13);
			this.labelAircraftCode.TabIndex = 23;
			this.labelAircraftCode.Text = "Aircr. Code";
			// 
			// comboBoxAircraftCode
			// 
			this.comboBoxAircraftCode.FormattingEnabled = true;
			this.comboBoxAircraftCode.Location = new System.Drawing.Point(70, 53);
			this.comboBoxAircraftCode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxAircraftCode.Name = "comboBoxAircraftCode";
			this.comboBoxAircraftCode.Size = new System.Drawing.Size(178, 21);
			this.comboBoxAircraftCode.TabIndex = 22;
			this.comboBoxAircraftCode.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// lookupComboboxFrom
			// 
			this.lookupComboboxFrom.Displayer = null;
			this.lookupComboboxFrom.DisplayerText = null;
			this.lookupComboboxFrom.Entity = null;
			this.lookupComboboxFrom.Location = new System.Drawing.Point(70, 206);
			this.lookupComboboxFrom.Name = "lookupComboboxFrom";
			this.lookupComboboxFrom.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFrom.Size = new System.Drawing.Size(178, 21);
			this.lookupComboboxFrom.TabIndex = 24;
			this.lookupComboboxFrom.Type = null;
			this.lookupComboboxFrom.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// lookupComboboxTo
			// 
			this.lookupComboboxTo.Displayer = null;
			this.lookupComboboxTo.DisplayerText = null;
			this.lookupComboboxTo.Entity = null;
			this.lookupComboboxTo.Location = new System.Drawing.Point(70, 233);
			this.lookupComboboxTo.Name = "lookupComboboxTo";
			this.lookupComboboxTo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxTo.Size = new System.Drawing.Size(178, 21);
			this.lookupComboboxTo.TabIndex = 26;
			this.lookupComboboxTo.Type = null;
			this.lookupComboboxTo.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 235);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "To";
			// 
			// lookupComboboxFlightNum
			// 
			this.lookupComboboxFlightNum.Displayer = null;
			this.lookupComboboxFlightNum.DisplayerText = null;
			this.lookupComboboxFlightNum.Entity = null;
			this.lookupComboboxFlightNum.Location = new System.Drawing.Point(70, 155);
			this.lookupComboboxFlightNum.Name = "lookupComboboxFlightNum";
			this.lookupComboboxFlightNum.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFlightNum.Size = new System.Drawing.Size(178, 21);
			this.lookupComboboxFlightNum.TabIndex = 27;
			this.lookupComboboxFlightNum.Type = null;
			this.lookupComboboxFlightNum.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// FlightDateRouteControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lookupComboboxFlightNum);
			this.Controls.Add(this.lookupComboboxTo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lookupComboboxFrom);
			this.Controls.Add(this.labelAircraftCode);
			this.Controls.Add(this.comboBoxAircraftCode);
			this.Controls.Add(this.labelRecordType);
			this.Controls.Add(this.comboBoxRecordType);
			this.Controls.Add(this.labelFlightCategory);
			this.Controls.Add(this.comboBoxFlightCategory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBoxFlightType);
			this.Controls.Add(this.dateTimePickerFlightDate);
			this.Controls.Add(this.labelPageNum);
			this.Controls.Add(this.textBoxPageNum);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightDateRouteControl";
			this.Size = new System.Drawing.Size(251, 265);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelPageNum;
		private System.Windows.Forms.TextBox textBoxPageNum;
		private System.Windows.Forms.DateTimePicker dateTimePickerFlightDate;
		private System.Windows.Forms.ComboBox comboBoxFlightType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelFlightCategory;
		private System.Windows.Forms.ComboBox comboBoxFlightCategory;
		private System.Windows.Forms.Label labelRecordType;
		private System.Windows.Forms.ComboBox comboBoxRecordType;
		private System.Windows.Forms.Label labelAircraftCode;
		private System.Windows.Forms.ComboBox comboBoxAircraftCode;
		private Auxiliary.LookupCombobox lookupComboboxFrom;
		private Auxiliary.LookupCombobox lookupComboboxTo;
		private System.Windows.Forms.Label label6;
		private Auxiliary.LookupCombobox lookupComboboxFlightNum;
	}
}
