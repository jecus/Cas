using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.Fleet
{
	partial class DirectiveFleetListScreen
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
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.buttonImportExcel = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS3 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorAD = new System.Windows.Forms.PictureBox();
			this.labelFilter = new System.Windows.Forms.Label();
			this.labelFilterParagraph = new System.Windows.Forms.Label();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.TextBoxFilter = new System.Windows.Forms.TextBox();
			this.TextBoxFilterParagraph = new System.Windows.Forms.TextBox();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.buttonAddAD = new AvControls.AvButtonT.AvButtonT();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorAD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5);
			this.headerControl.ShowForecastButton = false;
			this.headerControl.ShowPrintButton = false;
			this.headerControl.Size = new System.Drawing.Size(773, 58);
			this.headerControl.SaveButtonClick += new System.EventHandler(HeaderControlSaveButtonClick);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(777, 205);
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
			this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddAD);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorAD);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(593, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this.labelFilter);
			this.panelTopContainer.Controls.Add(this.labelFilterParagraph);
			this.panelTopContainer.Controls.Add(this.TextBoxFilter);
			this.panelTopContainer.Controls.Add(this.TextBoxFilterParagraph);
			this.panelTopContainer.Controls.Add(this.buttonFilter);
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
			// pictureBoxSeparatorAD
			// 
			this.pictureBoxSeparatorAD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorAD.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorAD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorAD.Name = "pictureBoxSeparatorAD";
			this.pictureBoxSeparatorAD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorAD.TabIndex = 24;
			this.pictureBoxSeparatorAD.TabStop = false;
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
			// buttonAddAD
			// 
			this.buttonAddAD.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddAD.ActiveBackgroundImage = null;
			this.buttonAddAD.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddAD.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddAD.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddAD.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddAD.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddAD.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.buttonAddAD.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddAD.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.buttonAddAD.Location = new System.Drawing.Point(66, 0);
			this.buttonAddAD.Name = "buttonAddDocument";
			this.buttonAddAD.NormalBackgroundImage = null;
			this.buttonAddAD.ShowToolTip = true;
			this.buttonAddAD.Size = new System.Drawing.Size(52, 57);
			this.buttonAddAD.TabIndex = 0;
			this.buttonAddAD.TextMain = "";
			this.buttonAddAD.TextSecondary = "";
			this.buttonAddAD.ToolTipText = "Add new";
			this.buttonAddAD.Click += new System.EventHandler(this.ButtonAddADClick);
			this.buttonAddAD.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// pictureBoxS3
			// 
			this.pictureBoxS3.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS3.Location = new System.Drawing.Point(118, 3);
			this.pictureBoxS3.Name = "pictureBoxS2";
			this.pictureBoxS3.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS3.TabIndex = 20;
			this.pictureBoxS3.TabStop = false;
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
			this.labelTitle.Size = new System.Drawing.Size(800, 22);
			this.labelTitle.Status = AvControls.Statuses.NotActive;
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// TextBoxFilter
			// 
			this.TextBoxFilter.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.TextBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.TextBoxFilter.Location = new System.Drawing.Point(90, 2);
			this.TextBoxFilter.Name = "TextBoxFilter";
			this.TextBoxFilter.Size = new System.Drawing.Size(110, 25);
			this.TextBoxFilter.TabIndex = 73;
			// 
			// TextBoxFilterParagraph
			// 
			this.TextBoxFilterParagraph.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.TextBoxFilterParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.TextBoxFilterParagraph.Location = new System.Drawing.Point(90, 29);
			this.TextBoxFilterParagraph.Name = "TextBoxFilterParagraph";
			this.TextBoxFilterParagraph.Size = new System.Drawing.Size(110, 25);
			this.TextBoxFilterParagraph.TabIndex = 73;
			// 
			// labelFilter
			// 
			this.labelFilter.AutoSize = true;
			this.labelFilter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFilter.Location = new System.Drawing.Point(10, 6);
			this.labelFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelFilter.Name = "labelFilter";
			this.labelFilter.Size = new System.Drawing.Size(33, 14);
			this.labelFilter.TabIndex = 72;
			this.labelFilter.Text = "Title:";
			// 
			// labelFilterParagraph
			// 
			this.labelFilterParagraph.AutoSize = true;
			this.labelFilterParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFilterParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFilterParagraph.Location = new System.Drawing.Point(10, 33);
			this.labelFilterParagraph.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelFilterParagraph.Name = "labelFilterParagraph";
			this.labelFilterParagraph.Size = new System.Drawing.Size(33, 14);
			this.labelFilterParagraph.TabIndex = 72;
			this.labelFilterParagraph.Text = "Paragraph:";
			// 
			// buttonFilter
			// 
			this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonFilter.ForeColor = System.Drawing.Color.DimGray;
			this.buttonFilter.Location = new System.Drawing.Point(210, 30);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(70, 23);
			this.buttonFilter.TabIndex = 43;
			this.buttonFilter.Text = "Find";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new System.EventHandler(this.ButtonFilterClick);
			// 
			// DirectiveFleetListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DirectiveFleetListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(777, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorAD)).EndInit();
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
		private System.Windows.Forms.TextBox TextBoxFilter;
		private System.Windows.Forms.TextBox TextBoxFilterParagraph;
		private System.Windows.Forms.Button buttonFilter;
		private System.Windows.Forms.Label labelFilter;
		private System.Windows.Forms.Label labelFilterParagraph;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorAD;
		private AvControls.AvButtonT.AvButtonT buttonAddAD;
	}
}
