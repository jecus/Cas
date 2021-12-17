using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.DirectivesControls
{
	partial class DefferedListScreen
	{
		/// <summary> 
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS2 = new System.Windows.Forms.PictureBox();
			this.buttonImportExcel = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS3 = new System.Windows.Forms.PictureBox();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5);
			this.headerControl.Size = new System.Drawing.Size(1450, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(1454, 406);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS2);
			this.flowLayoutPanel1.Controls.Add(this.buttonImportExcel);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS3);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1270, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// buttonDeleteSelected
			// 
			this.buttonDeleteSelected.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonDeleteSelected.ActiveBackgroundImage = null;
			this.buttonDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDeleteSelected.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDeleteSelected.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDeleteSelected.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.buttonDeleteSelected.Location = new System.Drawing.Point(126, 0);
			this.buttonDeleteSelected.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// pictureBoxS2
			// 
			this.pictureBoxS2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS2.Location = new System.Drawing.Point(118, 3);
			this.pictureBoxS2.Name = "pictureBoxS2";
			this.pictureBoxS2.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS2.TabIndex = 20;
			this.pictureBoxS2.TabStop = false;
			// 
			// buttonImportExcel
			// 
			this.buttonImportExcel.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonImportExcel.ActiveBackgroundImage = null;
			this.buttonImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonImportExcel.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonImportExcel.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonImportExcel.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonImportExcel.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonImportExcel.Icon = global::CAS.UI.Properties.Resources.ExcelImport;
			this.buttonImportExcel.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonImportExcel.IconNotEnabled = global::CAS.UI.Properties.Resources.ExcelImport;
			this.buttonImportExcel.Location = new System.Drawing.Point(63, 0);
			this.buttonImportExcel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonImportExcel.Name = "buttonImportExcel";
			this.buttonImportExcel.NormalBackgroundImage = null;
			this.buttonImportExcel.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonImportExcel.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonImportExcel.ShowToolTip = true;
			this.buttonImportExcel.Size = new System.Drawing.Size(52, 57);
			this.buttonImportExcel.TabIndex = 19;
			this.buttonImportExcel.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonImportExcel.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonImportExcel.TextMain = "";
			this.buttonImportExcel.TextSecondary = "";
			this.buttonImportExcel.ToolTipText = "Import From Excel";
			this.buttonImportExcel.Click += new System.EventHandler(this.ButtonImportFromExcelClick);
			// 
			// pictureBoxS3
			// 
			this.pictureBoxS3.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS3.Location = new System.Drawing.Point(55, 3);
			this.pictureBoxS3.Name = "pictureBoxS3";
			this.pictureBoxS3.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS3.TabIndex = 20;
			this.pictureBoxS3.TabStop = false;
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonApplyFilter.IconNotEnabled = null;
			this.buttonApplyFilter.Location = new System.Drawing.Point(0, 0);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(55, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			// 
			// labelDateAsOf
			// 
			this.labelDateAsOf.AutoSize = true;
			this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateAsOf.Location = new System.Drawing.Point(57, 30);
			this.labelDateAsOf.Name = "labelDateAsOf";
			this.labelDateAsOf.Size = new System.Drawing.Size(0, 17);
			this.labelDateAsOf.TabIndex = 21;
			// 
			// labelTitle
			// 
			this.labelTitle.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
			this.labelTitle.Enabled = false;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
			this.labelTitle.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.labelTitle.ImageBackColor = System.Drawing.Color.Transparent;
			this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.labelTitle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelTitle.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.labelTitle.Location = new System.Drawing.Point(37, 4);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(600, 22);
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// DefferedListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DefferedListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(1454, 584);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private AvControls.AvButtonT.AvButtonT buttonImportExcel;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBoxS3;
		private System.Windows.Forms.PictureBox pictureBoxS2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
