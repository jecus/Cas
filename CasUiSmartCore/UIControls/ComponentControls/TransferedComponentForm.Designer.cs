using AvControls.AvButtonT;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.ComponentControls
{
	partial class TransferedComponentForm
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
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Removed", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Installed", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Wait remove confirm", System.Windows.Forms.HorizontalAlignment.Left);
			this.listViewTransferedDetails = new System.Windows.Forms.ListView();
			this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnTransferTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnTransferDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonCancel = new AvControls.AvButtonT.AvButtonT();
			this.SuspendLayout();
			// 
			// listViewTransferedDetails
			// 
			this.listViewTransferedDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewTransferedDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnDescription,
			this.columnTransferTo,
			this.columnTransferDate});
			this.listViewTransferedDetails.FullRowSelect = true;
			listViewGroup4.Header = "Removed";
			listViewGroup4.Name = "listViewGroupRemoved";
			listViewGroup5.Header = "Installed";
			listViewGroup5.Name = "listViewGroupInstalled";
			listViewGroup6.Header = "Wait remove confirm";
			listViewGroup6.Name = "listViewGroupWaitRemove";
			this.listViewTransferedDetails.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
			listViewGroup4,
			listViewGroup5,
			listViewGroup6});
			this.listViewTransferedDetails.Location = new System.Drawing.Point(13, 63);
			this.listViewTransferedDetails.Name = "listViewTransferedDetails";
			this.listViewTransferedDetails.Size = new System.Drawing.Size(1269, 341);
			this.listViewTransferedDetails.TabIndex = 0;
			this.listViewTransferedDetails.UseCompatibleStateImageBehavior = false;
			this.listViewTransferedDetails.View = System.Windows.Forms.View.Details;
			this.listViewTransferedDetails.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewTransferedDetailsMouseClick);
			// 
			// columnDescription
			// 
			this.columnDescription.Text = "Description";
			this.columnDescription.Width = 626;
			// 
			// columnTransferTo
			// 
			this.columnTransferTo.Text = "Transfered To";
			this.columnTransferTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnTransferTo.Width = 444;
			// 
			// columnTransferDate
			// 
			this.columnTransferDate.Text = "Transfer Date";
			this.columnTransferDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnTransferDate.Width = 180;
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.Enabled = false;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.ButtonDelete.Location = new System.Drawing.Point(239, 410);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(258, 54);
			this.ButtonDelete.TabIndex = 10;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete from aircraft ";
			this.ButtonDelete.TextSecondary = "components";
			this.ButtonDelete.ToolTipText = null;
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			this.ButtonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAdd.ActiveBackgroundImage = null;
			this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.ButtonAdd.Location = new System.Drawing.Point(12, 410);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(221, 54);
			this.ButtonAdd.TabIndex = 9;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add to aircraft ";
			this.ButtonAdd.TextSecondary = "components";
			this.ButtonAdd.ToolTipText = null;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonCancel.ActiveBackgroundImage = null;
			this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonCancel.Enabled = false;
			this.ButtonCancel.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonCancel.FontSecondary = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonCancel.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonCancel.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonCancel.Icon = global::CAS.UI.Properties.Resources.CancelEdit;
			this.ButtonCancel.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonCancel.IconNotEnabled = global::CAS.UI.Properties.Resources.CancelEdit_gray;
			this.ButtonCancel.Location = new System.Drawing.Point(503, 410);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.NormalBackgroundImage = null;
			this.ButtonCancel.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonCancel.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonCancel.ShowToolTip = false;
			this.ButtonCancel.Size = new System.Drawing.Size(143, 54);
			this.ButtonCancel.TabIndex = 11;
			this.ButtonCancel.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonCancel.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonCancel.TextMain = "Cancel";
			this.ButtonCancel.TextSecondary = "remove";
			this.ButtonCancel.ToolTipText = null;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// TransferedComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1284, 480);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.listViewTransferedDetails);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1300, 570);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1300, 390);
			this.Name = "TransferedComponentForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Transfered Detail Form";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewTransferedDetails;
		private System.Windows.Forms.ColumnHeader columnDescription;
		private System.Windows.Forms.ColumnHeader columnTransferDate;
		private System.Windows.Forms.ColumnHeader columnTransferTo;
		public AvButtonT ButtonDelete;
		public AvButtonT ButtonAdd;
		public AvButtonT ButtonCancel;
	}
}