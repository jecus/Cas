using CAS.UI.Helpers;

namespace CAS.UI.UIControls.ComponentControls
{
	partial class ComponentChangeLLPCategoryRecordForm
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
			this.labelLLPCategory = new System.Windows.Forms.Label();
			this.comboBoxCategories = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lifelengthViewer_LastCompliance
			// 
			this.lifelengthViewer_LastCompliance.EnabledCalendar = false;
			this.lifelengthViewer_LastCompliance.Location = new System.Drawing.Point(1, 45);
			this.lifelengthViewer_LastCompliance.ShowCalendar = true;
			this.lifelengthViewer_LastCompliance.ShowLeftHeader = true;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(126, 119);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
			// 
			// textBox_Remarks
			// 
			// 
			// 
			// 
			this.textBox_Remarks.CustomButton.Image = null;
			this.textBox_Remarks.CustomButton.Location = new System.Drawing.Point(250, 2);
			this.textBox_Remarks.CustomButton.Name = "";
			this.textBox_Remarks.CustomButton.Size = new System.Drawing.Size(99, 99);
			this.textBox_Remarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBox_Remarks.CustomButton.TabIndex = 1;
			this.textBox_Remarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBox_Remarks.CustomButton.UseSelectable = true;
			this.textBox_Remarks.CustomButton.Visible = false;
			this.textBox_Remarks.Lines = new string[0];
			this.textBox_Remarks.Location = new System.Drawing.Point(126, 151);
			// 
			// fileControl
			// 
			this.fileControl.Location = new System.Drawing.Point(126, 270);
			this.fileControl.ShowLinkLabelBrowse = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(258, 417);
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(339, 417);
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(420, 417);
			this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
			// 
			// delimiter1
			// 
			this.delimiter1.Location = new System.Drawing.Point(8, 146);
			// 
			// delimiter2
			// 
			this.delimiter2.Location = new System.Drawing.Point(6, 262);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBoxCategories);
			this.groupBox1.Controls.Add(this.labelLLPCategory);
			this.groupBox1.Size = new System.Drawing.Size(484, 348);
			this.groupBox1.Controls.SetChildIndex(this.delimiter2, 0);
			this.groupBox1.Controls.SetChildIndex(this.label1, 0);
			this.groupBox1.Controls.SetChildIndex(this.delimiter1, 0);
			this.groupBox1.Controls.SetChildIndex(this.dateTimePicker1, 0);
			this.groupBox1.Controls.SetChildIndex(this.label2, 0);
			this.groupBox1.Controls.SetChildIndex(this.textBox_Remarks, 0);
			this.groupBox1.Controls.SetChildIndex(this.fileControl, 0);
			this.groupBox1.Controls.SetChildIndex(this.labelLLPCategory, 0);
			this.groupBox1.Controls.SetChildIndex(this.lifelengthViewer_LastCompliance, 0);
			this.groupBox1.Controls.SetChildIndex(this.comboBoxCategories, 0);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(70, 121);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(39, 151);
			// 
			// labelLLPCategory
			// 
			this.labelLLPCategory.AutoSize = true;
			this.labelLLPCategory.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.labelLLPCategory.ForeColor = System.Drawing.Color.DimGray;
			this.labelLLPCategory.Location = new System.Drawing.Point(10, 18);
			this.labelLLPCategory.Name = "labelLLPCategory";
			this.labelLLPCategory.Size = new System.Drawing.Size(110, 18);
			this.labelLLPCategory.TabIndex = 11;
			this.labelLLPCategory.Text = "On Category:";
			// 
			// comboBoxCategories
			// 
			this.comboBoxCategories.FormattingEnabled = true;
			this.comboBoxCategories.Location = new System.Drawing.Point(126, 19);
			this.comboBoxCategories.Name = "comboBoxCategories";
			this.comboBoxCategories.Size = new System.Drawing.Size(352, 21);
			this.comboBoxCategories.TabIndex = 12;
			this.comboBoxCategories.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// ComponentChangeLLPCategoryRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 460);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "ComponentChangeLLPCategoryRecordForm";
			this.Text = "DetailChangeLLPCategoryRecordForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxCategories;
		private System.Windows.Forms.Label labelLLPCategory;
	}
}