namespace CAS.UI.UIControls.StoresControls
{
	partial class WorkPackageStoreScreen
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
			this.comboBoxWorkPackage = new System.Windows.Forms.ComboBox();
			this.labelWorkPackage = new System.Windows.Forms.Label();
			this.buttonCalculate = new System.Windows.Forms.Button();
			this.headerControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(1423, 54);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 126);
			this.panel1.Size = new System.Drawing.Size(1427, 487);
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.comboBoxWorkPackage);
			this.panelTopContainer.Controls.Add(this.labelWorkPackage);
			this.panelTopContainer.Controls.Add(this.buttonCalculate);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// comboBoxWorkPackage
			// 
			this.comboBoxWorkPackage.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkPackage.FormattingEnabled = true;
			this.comboBoxWorkPackage.Location = new System.Drawing.Point(130, 26);
			this.comboBoxWorkPackage.Name = "comboBoxWorkPackage";
			this.comboBoxWorkPackage.Size = new System.Drawing.Size(350, 25);
			this.comboBoxWorkPackage.TabIndex = 73;
			// 
			// labelWorkPackage
			// 
			this.labelWorkPackage.AutoSize = true;
			this.labelWorkPackage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWorkPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWorkPackage.Location = new System.Drawing.Point(20, 30);
			this.labelWorkPackage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelWorkPackage.Name = "labelWorkPackage";
			this.labelWorkPackage.Size = new System.Drawing.Size(62, 14);
			this.labelWorkPackage.TabIndex = 72;
			this.labelWorkPackage.Text = "Work packages:";
			// 
			// buttonOK
			// 
			this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCalculate.ForeColor = System.Drawing.Color.DimGray;
			this.buttonCalculate.Location = new System.Drawing.Point(485, 25);
			this.buttonCalculate.Name = "buttonOK";
			this.buttonCalculate.Size = new System.Drawing.Size(70, 23);
			this.buttonCalculate.TabIndex = 43;
			this.buttonCalculate.Text = "OK";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculateClick);

			// 
			// WorkPackageStoreScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Name = "WorkPackageStoreScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(1427, 661);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxWorkPackage;
		private System.Windows.Forms.Label labelWorkPackage;
		private System.Windows.Forms.Button buttonCalculate;
	}
}
