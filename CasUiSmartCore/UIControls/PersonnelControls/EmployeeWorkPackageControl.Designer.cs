namespace CAS.UI.UIControls.PersonnelControls
{
	partial class EmployeeWorkPackageControl
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
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.ButtonFilter = new AvControls.AvButtonT.AvButtonT();
			this.employeeWorkPackageListView = new CAS.UI.UIControls.PersonnelControls.EmployeeWorkPackageListView();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(1226, -4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 40;
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
			this.ButtonFilter.Location = new System.Drawing.Point(1181, 0);
			this.ButtonFilter.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonFilter.Name = "ButtonFilter";
			this.ButtonFilter.NormalBackgroundImage = null;
			this.ButtonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.ShowToolTip = true;
			this.ButtonFilter.Size = new System.Drawing.Size(42, 38);
			this.ButtonFilter.TabIndex = 39;
			this.ButtonFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextMain = "";
			this.ButtonFilter.TextSecondary = "";
			this.ButtonFilter.ToolTipText = "Add Item";
			this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
			// 
			// employeeWorkPackageListView
			// 
			this.employeeWorkPackageListView.CurrentSpecialist = null;
			this.employeeWorkPackageListView.Displayer = null;
			this.employeeWorkPackageListView.DisplayerText = null;
			this.employeeWorkPackageListView.Entity = null;
			this.employeeWorkPackageListView.IgnoreAutoResize = false;
			this.employeeWorkPackageListView.Location = new System.Drawing.Point(3, 47);
			this.employeeWorkPackageListView.Name = "employeeWorkPackageListView";
			this.employeeWorkPackageListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.employeeWorkPackageListView.ShowGroups = true;
			this.employeeWorkPackageListView.Size = new System.Drawing.Size(1231, 503);
			this.employeeWorkPackageListView.TabIndex = 0;
			// 
			// EmployeeWorkPackageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.ButtonFilter);
			this.Controls.Add(this.employeeWorkPackageListView);
			this.Name = "EmployeeWorkPackageControl";
			this.Size = new System.Drawing.Size(1237, 553);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private EmployeeWorkPackageListView employeeWorkPackageListView;
		private System.Windows.Forms.PictureBox pictureBox2;
		private AvControls.AvButtonT.AvButtonT ButtonFilter;
	}
}
