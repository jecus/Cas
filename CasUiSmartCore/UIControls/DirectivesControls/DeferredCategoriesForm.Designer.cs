using AvControls.AvButtonT;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.DirectivesControls
{
	partial class DeferredCategoriesForm
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
			this.listViewDefferedCategories = new System.Windows.Forms.ListView();
			this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAircraftModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnCategoryThreshold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.SuspendLayout();
			// 
			// listViewDefferedCategories
			// 
			this.listViewDefferedCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnCategory,
			this.columnAircraftModel,
			this.columnCategoryThreshold});
			this.listViewDefferedCategories.FullRowSelect = true;
			this.listViewDefferedCategories.HideSelection = false;
			this.listViewDefferedCategories.Location = new System.Drawing.Point(12, 63);
			this.listViewDefferedCategories.Name = "listViewDefferedCategories";
			this.listViewDefferedCategories.Size = new System.Drawing.Size(579, 181);
			this.listViewDefferedCategories.TabIndex = 0;
			this.listViewDefferedCategories.UseCompatibleStateImageBehavior = false;
			this.listViewDefferedCategories.View = System.Windows.Forms.View.Details;
			this.listViewDefferedCategories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDefferedCategoriesMouseClick);
			this.listViewDefferedCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDefferedCategoriesMouseDoubleClick);
			// 
			// columnCategory
			// 
			this.columnCategory.Text = "Category";
			this.columnCategory.Width = 98;
			// 
			// columnAircraftModel
			// 
			this.columnAircraftModel.Text = "Aircraft Model";
			this.columnAircraftModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnAircraftModel.Width = 171;
			// 
			// columnCategoryThreshold
			// 
			this.columnCategoryThreshold.Text = "Category threshold";
			this.columnCategoryThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnCategoryThreshold.Width = 294;
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
			this.ButtonDelete.Location = new System.Drawing.Point(282, 250);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(267, 54);
			this.ButtonDelete.TabIndex = 10;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete deffered ";
			this.ButtonDelete.TextSecondary = "category";
			this.ButtonDelete.ToolTipText = null;
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
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
			this.ButtonAdd.Location = new System.Drawing.Point(55, 250);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(221, 54);
			this.ButtonAdd.TabIndex = 9;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add deffered";
			this.ButtonAdd.TextSecondary = "category";
			this.ButtonAdd.ToolTipText = null;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// DeferredCategoriesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 315);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.listViewDefferedCategories);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 350);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 300);
			this.Name = "DeferredCategoriesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Deffered categories";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewDefferedCategories;
		private System.Windows.Forms.ColumnHeader columnCategory;
		private System.Windows.Forms.ColumnHeader columnCategoryThreshold;
		private System.Windows.Forms.ColumnHeader columnAircraftModel;
		public AvButtonT ButtonDelete;
		public AvButtonT ButtonAdd;
	}
}