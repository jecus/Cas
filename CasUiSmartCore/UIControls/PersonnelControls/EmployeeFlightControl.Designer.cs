namespace CAS.UI.UIControls.PersonnelControls
{
	partial class EmployeeFlightControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeFlightControl));
			this.employeeFlightListView = new CAS.UI.UIControls.PersonnelControls.EmployeeFlightListView();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.ButtonFilter = new AvControls.AvButtonT.AvButtonT();
			this.labelDateFrom = new System.Windows.Forms.Label();
			this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
			this.labelDateTo = new System.Windows.Forms.Label();
			this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
			this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// employeeFlightListView
			// 
			this.employeeFlightListView.Displayer = null;
			this.employeeFlightListView.DisplayerText = null;
			this.employeeFlightListView.Entity = null;
			this.employeeFlightListView.Flights = ((SmartCore.Entities.Collections.CommonCollection<SmartCore.Entities.General.Atlbs.AircraftFlight>)(resources.GetObject("employeeFlightListView.Flights")));
			this.employeeFlightListView.IgnoreAutoResize = false;
			this.employeeFlightListView.Location = new System.Drawing.Point(0, 51);
			this.employeeFlightListView.Name = "employeeFlightListView";
			this.employeeFlightListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.employeeFlightListView.ShowGroups = true;
			this.employeeFlightListView.Size = new System.Drawing.Size(1231, 490);
			this.employeeFlightListView.TabIndex = 0;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(1222, 1);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 38;
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
			this.ButtonFilter.Location = new System.Drawing.Point(1177, 5);
			this.ButtonFilter.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonFilter.Name = "ButtonFilter";
			this.ButtonFilter.NormalBackgroundImage = null;
			this.ButtonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.ShowToolTip = true;
			this.ButtonFilter.Size = new System.Drawing.Size(42, 38);
			this.ButtonFilter.TabIndex = 37;
			this.ButtonFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextMain = "";
			this.ButtonFilter.TextSecondary = "";
			this.ButtonFilter.ToolTipText = "Add Item";
			this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
			// 
			// labelDateFrom
			// 
			this.labelDateFrom.AutoSize = true;
			this.labelDateFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateFrom.Location = new System.Drawing.Point(-1, 26);
			this.labelDateFrom.Name = "labelDateFrom";
			this.labelDateFrom.Size = new System.Drawing.Size(38, 14);
			this.labelDateFrom.TabIndex = 39;
			this.labelDateFrom.Text = "From";
			// 
			// dateTimePickerDateFrom
			// 
			this.dateTimePickerDateFrom.BackColor = System.Drawing.Color.White;
			this.dateTimePickerDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDateFrom.ForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDateFrom.Location = new System.Drawing.Point(47, 23);
			this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
			this.dateTimePickerDateFrom.Size = new System.Drawing.Size(100, 20);
			this.dateTimePickerDateFrom.TabIndex = 40;
			// 
			// labelDateTo
			// 
			this.labelDateTo.AutoSize = true;
			this.labelDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateTo.Location = new System.Drawing.Point(157, 26);
			this.labelDateTo.Name = "labelDateTo";
			this.labelDateTo.Size = new System.Drawing.Size(20, 13);
			this.labelDateTo.TabIndex = 41;
			this.labelDateTo.Text = "To";
			// 
			// dateTimePickerDateTo
			// 
			this.dateTimePickerDateTo.BackColor = System.Drawing.Color.White;
			this.dateTimePickerDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDateTo.ForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDateTo.Location = new System.Drawing.Point(187, 23);
			this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
			this.dateTimePickerDateTo.Size = new System.Drawing.Size(100, 20);
			this.dateTimePickerDateTo.TabIndex = 42;
			// 
			// buttonOK
			// 
			this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonOK.ForeColor = System.Drawing.Color.DimGray;
			this.buttonOK.Location = new System.Drawing.Point(307, 21);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(70, 23);
			this.buttonOK.TabIndex = 43;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// EmployeeFlightControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelDateFrom);
			this.Controls.Add(this.dateTimePickerDateFrom);
			this.Controls.Add(this.labelDateTo);
			this.Controls.Add(this.dateTimePickerDateTo);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.ButtonFilter);
			this.Controls.Add(this.employeeFlightListView);
			this.Name = "EmployeeFlightControl";
			this.Size = new System.Drawing.Size(1237, 553);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private EmployeeFlightListView employeeFlightListView;
		private System.Windows.Forms.PictureBox pictureBox2;
		private AvControls.AvButtonT.AvButtonT ButtonFilter;
		private System.Windows.Forms.Label labelDateFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
		private System.Windows.Forms.Label labelDateTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
		private System.Windows.Forms.Button buttonOK;
	}
}
