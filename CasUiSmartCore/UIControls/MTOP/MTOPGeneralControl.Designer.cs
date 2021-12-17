using CAS.UI.UIControls.NewGrid;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.MTOP
{
	partial class MTOPGeneralControl
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
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.avButtonAddCheck = new AvControls.AvButtonT.AvButtonT();
			this.avButtonEditCheck = new AvControls.AvButtonT.AvButtonT();
			this.avButtonDeleteCheck = new AvControls.AvButtonT.AvButtonT();
			this.mtopCheckListView1 = new CAS.UI.UIControls.MTOP.MTOPCheckListView();
			this.averageUtilizationItemControl1 = new CAS.UI.UIControls.MonthlyUtilizationsControls.AverageUtilizationItemControl();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// avButtonAddCheck
			// 
			this.avButtonAddCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonAddCheck.ActiveBackgroundImage = null;
			this.avButtonAddCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonAddCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonAddCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonAddCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonAddCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonAddCheck.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.avButtonAddCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonAddCheck.IconNotEnabled = null;
			this.avButtonAddCheck.Location = new System.Drawing.Point(3, 3);
			this.avButtonAddCheck.Name = "avButtonAddCheck";
			this.avButtonAddCheck.NormalBackgroundImage = null;
			this.avButtonAddCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonAddCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonAddCheck.ShowToolTip = true;
			this.avButtonAddCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonAddCheck.TabIndex = 6;
			this.avButtonAddCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddCheck.TextMain = "";
			this.avButtonAddCheck.TextSecondary = "";
			this.avButtonAddCheck.ToolTipText = "Add";
			this.avButtonAddCheck.Click += new System.EventHandler(this.avButtonAddCheck_Click);
			this.avButtonAddCheck.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// avButtonEditCheck
			// 
			this.avButtonEditCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonEditCheck.ActiveBackgroundImage = null;
			this.avButtonEditCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonEditCheck.Enabled = false;
			this.avButtonEditCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonEditCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonEditCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonEditCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonEditCheck.Icon = global::CAS.UI.Properties.Resources.EditIcon;
			this.avButtonEditCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonEditCheck.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
			this.avButtonEditCheck.Location = new System.Drawing.Point(63, 3);
			this.avButtonEditCheck.Name = "avButtonEditCheck";
			this.avButtonEditCheck.NormalBackgroundImage = null;
			this.avButtonEditCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonEditCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonEditCheck.ShowToolTip = true;
			this.avButtonEditCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonEditCheck.TabIndex = 7;
			this.avButtonEditCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditCheck.TextMain = "";
			this.avButtonEditCheck.TextSecondary = "";
			this.avButtonEditCheck.ToolTipText = "Edit";
			this.avButtonEditCheck.Click += new System.EventHandler(this.avButtonEditCheck_Click);
			this.avButtonEditCheck.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// avButtonDeleteCheck
			// 
			this.avButtonDeleteCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonDeleteCheck.ActiveBackgroundImage = null;
			this.avButtonDeleteCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonDeleteCheck.Enabled = false;
			this.avButtonDeleteCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonDeleteCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonDeleteCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonDeleteCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonDeleteCheck.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.avButtonDeleteCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonDeleteCheck.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.avButtonDeleteCheck.Location = new System.Drawing.Point(123, 3);
			this.avButtonDeleteCheck.Name = "avButtonDeleteCheck";
			this.avButtonDeleteCheck.NormalBackgroundImage = null;
			this.avButtonDeleteCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonDeleteCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonDeleteCheck.ShowToolTip = true;
			this.avButtonDeleteCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonDeleteCheck.TabIndex = 8;
			this.avButtonDeleteCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonDeleteCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonDeleteCheck.TextMain = "";
			this.avButtonDeleteCheck.TextSecondary = "";
			this.avButtonDeleteCheck.ToolTipText = "Delete";
			this.avButtonDeleteCheck.Click += new System.EventHandler(this.avButtonDeleteCheck_Click);
			this.avButtonDeleteCheck.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// mtopCheckListView1
			// 
			this.mtopCheckListView1.ConfigurePaste = null;
			this.mtopCheckListView1.Displayer = null;
			this.mtopCheckListView1.DisplayerText = null;
			this.mtopCheckListView1.EnableCustomSorting = true;
			this.mtopCheckListView1.Entity = null;
			this.mtopCheckListView1.IgnoreEnterPress = false;
			this.mtopCheckListView1.Location = new System.Drawing.Point(3, 53);
			this.mtopCheckListView1.MenuOpeningAction = null;
			this.mtopCheckListView1.Name = "mtopCheckListView1";
			this.mtopCheckListView1.OldColumnIndex = 0;
			this.mtopCheckListView1.PasteComplete = null;
			this.mtopCheckListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.mtopCheckListView1.Size = new System.Drawing.Size(1101, 303);
			this.mtopCheckListView1.SortDirection = SortDirection.Asc;
			this.mtopCheckListView1.TabIndex = 9;
			this.mtopCheckListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.mtopCheckListView1_SelectedItemsChanged_1);
			// 
			// averageUtilizationItemControl1
			// 
			this.averageUtilizationItemControl1.Location = new System.Drawing.Point(6, 19);
			this.averageUtilizationItemControl1.Name = "averageUtilizationItemControl1";
			this.averageUtilizationItemControl1.Size = new System.Drawing.Size(164, 128);
			this.averageUtilizationItemControl1.TabIndex = 10;
			this.averageUtilizationItemControl1.ShowRadioButtons = false;
			this.averageUtilizationItemControl1.ShowCycDay = true;
			this.averageUtilizationItemControl1.LabelHoursText = "HRS/DAY";
			this.averageUtilizationItemControl1.LabelCyclesText = "HRS/CYC";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.averageUtilizationItemControl1);
			this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F);
			this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox1.Location = new System.Drawing.Point(1110, 53);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 156);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "AverageUtilization";
			// 
			// MTOPGeneralControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.mtopCheckListView1);
			this.Controls.Add(this.avButtonAddCheck);
			this.Controls.Add(this.avButtonEditCheck);
			this.Controls.Add(this.avButtonDeleteCheck);
			this.Name = "MTOPGeneralControl";
			this.Size = new System.Drawing.Size(1399, 359);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private AvControls.AvButtonT.AvButtonT avButtonAddCheck;
		private AvControls.AvButtonT.AvButtonT avButtonEditCheck;
		private AvControls.AvButtonT.AvButtonT avButtonDeleteCheck;
		private MTOPCheckListView mtopCheckListView1;
		public MonthlyUtilizationsControls.AverageUtilizationItemControl averageUtilizationItemControl1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
