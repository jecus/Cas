using MetroFramework.Controls;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.WorkPakage
{
	partial class WorkPackageEmployeeForm
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
			var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelCAA = new MetroFramework.Controls.MetroLabel();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.labelWpNumber = new MetroFramework.Controls.MetroLabel();
			this.labelWpTitle = new MetroFramework.Controls.MetroLabel();
			this.workPackageEmployeeListView2 = new CAS.UI.UIControls.WorkPakage.WorkPackageEmployeeListView();
			this.workPackageEmployeeListViewAll = new CAS.UI.UIControls.WorkPakage.WorkPackageEmployeeListView();
			this.textboxRemark = new MetroFramework.Controls.MetroTextBox();
			this.labelAddress = new MetroFramework.Controls.MetroLabel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(647, 677);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 18;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			//this.buttonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAdd.Location = new System.Drawing.Point(738, 677);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(96, 33);
			this.buttonAdd.TabIndex = 16;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			//this.buttonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(840, 677);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 17;
			this.buttonClose.Text = "OK";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// labelCAA
			// 
			this.labelCAA.AutoSize = true;
			this.labelCAA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCAA.Location = new System.Drawing.Point(12, 63);
			this.labelCAA.Name = "labelCAA";
			this.labelCAA.Size = new System.Drawing.Size(116, 19);
			this.labelCAA.TabIndex = 38;
			this.labelCAA.Text = "Work package №:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(12, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 19);
			this.label1.TabIndex = 39;
			this.label1.Text = "Work package title:";
			// 
			// labelWpNumber
			// 
			this.labelWpNumber.AutoSize = true;
			this.labelWpNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWpNumber.Location = new System.Drawing.Point(137, 63);
			this.labelWpNumber.Name = "labelWpNumber";
			this.labelWpNumber.Size = new System.Drawing.Size(25, 19);
			this.labelWpNumber.TabIndex = 40;
			this.labelWpNumber.Text = "№";
			// 
			// labelWpTitle
			// 
			this.labelWpTitle.AutoSize = true;
			this.labelWpTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWpTitle.Location = new System.Drawing.Point(137, 87);
			this.labelWpTitle.Name = "labelWpTitle";
			this.labelWpTitle.Size = new System.Drawing.Size(33, 19);
			this.labelWpTitle.TabIndex = 41;
			this.labelWpTitle.Text = "Title";
			// 
			// workPackageEmployeeListView2
			// 
			this.workPackageEmployeeListView2.Displayer = null;
			this.workPackageEmployeeListView2.DisplayerText = null;
			this.workPackageEmployeeListView2.Entity = null;
			this.workPackageEmployeeListView2.Location = new System.Drawing.Point(12, 380);
			this.workPackageEmployeeListView2.Name = "workPackageEmployeeListView2";
			this.workPackageEmployeeListView2.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.workPackageEmployeeListView2.Size = new System.Drawing.Size(897, 259);
			this.workPackageEmployeeListView2.TabIndex = 1;
			// 
			// workPackageEmployeeListViewAll
			// 
			this.workPackageEmployeeListViewAll.Displayer = null;
			this.workPackageEmployeeListViewAll.DisplayerText = null;
			this.workPackageEmployeeListViewAll.Entity = null;
			this.workPackageEmployeeListViewAll.Location = new System.Drawing.Point(12, 115);
			this.workPackageEmployeeListViewAll.Name = "workPackageEmployeeListViewAll";
			this.workPackageEmployeeListViewAll.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.workPackageEmployeeListViewAll.Size = new System.Drawing.Size(897, 259);
			this.workPackageEmployeeListViewAll.TabIndex = 0;
			// 
			// textboxRemark
			// 
			this.textboxRemark.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textboxRemark.CustomButton.Image = null;
			this.textboxRemark.CustomButton.Location = new System.Drawing.Point(457, 1);
			this.textboxRemark.CustomButton.Name = "";
			this.textboxRemark.CustomButton.Size = new System.Drawing.Size(65, 65);
			this.textboxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textboxRemark.CustomButton.TabIndex = 1;
			this.textboxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textboxRemark.CustomButton.UseSelectable = true;
			this.textboxRemark.CustomButton.Visible = false;
			this.textboxRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxRemark.Lines = new string[0];
			this.textboxRemark.Location = new System.Drawing.Point(83, 645);
			this.textboxRemark.MaxLength = 3000;
			this.textboxRemark.Multiline = true;
			this.textboxRemark.Name = "textboxRemark";
			this.textboxRemark.PasswordChar = '\0';
			this.textboxRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxRemark.SelectedText = "";
			this.textboxRemark.SelectionLength = 0;
			this.textboxRemark.SelectionStart = 0;
			this.textboxRemark.ShortcutsEnabled = true;
			this.textboxRemark.Size = new System.Drawing.Size(523, 67);
			this.textboxRemark.TabIndex = 43;
			this.textboxRemark.UseSelectable = true;
			this.textboxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textboxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddress.Location = new System.Drawing.Point(14, 648);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(57, 19);
			this.labelAddress.TabIndex = 42;
			this.labelAddress.Text = "Remark:";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(910, 65);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 45;
			this.pictureBox2.TabStop = false;
			// 
			// WorkPackageEmployeeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 722);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.textboxRemark);
			this.Controls.Add(this.labelAddress);
			this.Controls.Add(this.labelWpTitle);
			this.Controls.Add(this.labelWpNumber);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelCAA);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.workPackageEmployeeListView2);
			this.Controls.Add(this.workPackageEmployeeListViewAll);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorkPackageEmployeeForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Work Package Employee Form";
			this.Load += new System.EventHandler(this.WorkPackageEmployeeForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WorkPackageEmployeeListView workPackageEmployeeListViewAll;
		private WorkPackageEmployeeListView workPackageEmployeeListView2;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonClose;
		private MetroLabel labelCAA;
		private MetroLabel label1;
		private MetroLabel labelWpNumber;
		private MetroLabel labelWpTitle;
		private MetroTextBox textboxRemark;
		private MetroLabel labelAddress;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}