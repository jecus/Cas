namespace CAS.UI.UIControls.WorkPakage
{
	partial class EmployeeWorkPackageForm
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
			this.employeeWorkPackageListView = new EmployeeWorkPackageListView();
			this.SuspendLayout();
			// 
			// employeeCategoriesControl1
			// 
			this.employeeWorkPackageListView.AutoSize = true;
			this.employeeWorkPackageListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.employeeWorkPackageListView.Displayer = null;
			this.employeeWorkPackageListView.DisplayerText = null;
			this.employeeWorkPackageListView.Entity = null;
			this.employeeWorkPackageListView.Location = new System.Drawing.Point(460, 68);
			this.employeeWorkPackageListView.Name = "employeeCategoriesControl1";
			this.employeeWorkPackageListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.employeeWorkPackageListView.Size = new System.Drawing.Size(562, 293);
			this.employeeWorkPackageListView.TabIndex = 0;
			// 
			// EmployeeWorkPackageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(810, 680);
this.Controls.Add(this.employeeWorkPackageListView);
			this.Name = "EmployeeWorkPackageForm";
			this.Text = "EmployeeWorkPackageForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private EmployeeWorkPackageListView employeeWorkPackageListView;
	}
}