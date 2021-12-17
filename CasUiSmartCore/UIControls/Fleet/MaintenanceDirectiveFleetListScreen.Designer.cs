using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.Fleet
{
	partial class MaintenanceDirectiveFleetListScreen
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
			this.pictureBoxSeparatorBD = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorEx = new System.Windows.Forms.PictureBox();
			this.buttonExport = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.pictureBoxSeperatorBAN = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperato = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperator = new System.Windows.Forms.PictureBox();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.TextBoxFilter = new System.Windows.Forms.TextBox();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorBAN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperato)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperator)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.headerControl.ShowForecastButton = false;
			this.headerControl.ShowPrintButton = false;
			this.headerControl.Size = new System.Drawing.Size(735, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Size = new System.Drawing.Size(739, 205);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			this.panelTopContainer.Controls.Add(this.TextBoxFilter);
			this.panelTopContainer.Controls.Add(this.buttonFilter);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorBD);
			this.flowLayoutPanel1.Controls.Add(this.buttonExport);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperatorBAN);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(552, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(181, 62);
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
			this.buttonDeleteSelected.MinimumSize = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(55, 63);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// pictureBoxSeparatorBD
			// 
			this.pictureBoxSeparatorBD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorBD.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorBD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorBD.Name = "pictureBoxSeparatorBD";
			this.pictureBoxSeparatorBD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorBD.TabIndex = 24;
			this.pictureBoxSeparatorBD.TabStop = false;
			// 
			// pictureBoxSeparatorEx
			// 
			this.pictureBoxSeparatorEx.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorEx.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorEx.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorEx.Name = "pictureBoxSeparatorEx";
			this.pictureBoxSeparatorEx.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorEx.TabIndex = 24;
			this.pictureBoxSeparatorEx.TabStop = false;
			// 
			// buttonExport
			// 
			this.buttonExport.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonExport.ActiveBackgroundImage = null;
			this.buttonExport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExport.Displayer = null;
			this.buttonExport.DisplayerText = "";
			this.buttonExport.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonExport.Entity = null;
			this.buttonExport.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExport.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExport.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonExport.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonExport.Icon = global::CAS.UI.Properties.Resources.ExcelImport;
			this.buttonExport.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonExport.Location = new System.Drawing.Point(63, 0);
			this.buttonExport.Margin = new System.Windows.Forms.Padding(0);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.NormalBackgroundImage = null;
			this.buttonExport.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonExport.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonExport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.buttonExport.ShowToolTip = true;
			this.buttonExport.Size = new System.Drawing.Size(55, 63);
			this.buttonExport.TabIndex = 25;
			this.buttonExport.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonExport.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonExport.TextMain = "";
			this.buttonExport.TextSecondary = "";
			this.buttonExport.ToolTipText = "Export";
			this.buttonExport.Click += ExportMpd_Click;
			// 
			// pictureBoxSeperatorBAN
			// 
			this.pictureBoxSeperatorBAN.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperatorBAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperatorBAN.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperatorBAN.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperatorBAN.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperatorBAN.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperatorBAN.TabIndex = 25;
			this.pictureBoxSeperatorBAN.TabStop = false;
			// 
			// pictureBoxSeperato
			// 
			this.pictureBoxSeperato.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperato.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperato.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperato.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperato.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperato.TabIndex = 25;
			this.pictureBoxSeperato.TabStop = false;
			// 
			// pictureBoxSeperator
			// 
			this.pictureBoxSeperator.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperator.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperator.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperator.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperator.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperator.TabIndex = 25;
			this.pictureBoxSeperator.TabStop = false;
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.Dock = System.Windows.Forms.DockStyle.Right;
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
			this.buttonApplyFilter.Size = new System.Drawing.Size(55, 63);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// TextBoxFilter
			// 
			this.TextBoxFilter.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.TextBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.TextBoxFilter.Location = new System.Drawing.Point(37, 29);
			this.TextBoxFilter.Name = "TextBoxFilter";
			this.TextBoxFilter.Size = new System.Drawing.Size(528, 25);
			this.TextBoxFilter.TabIndex = 73;
			// 
			// buttonFilter
			// 
			this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonFilter.ForeColor = System.Drawing.Color.DimGray;
			this.buttonFilter.Location = new System.Drawing.Point(570, 30);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(70, 23);
			this.buttonFilter.TabIndex = 43;
			this.buttonFilter.Text = "Find";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new System.EventHandler(this.ButtonFilterClick);
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
			this.labelTitle.Location = new System.Drawing.Point(28, 3);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(600, 27);
			this.labelTitle.Status = AvControls.Statuses.NotActive;
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// MaintenanceDirectiveFleetListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "MaintenanceDirectiveFleetListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(739, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorBAN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperato)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperator)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonExport;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorBD;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorEx;
		private System.Windows.Forms.PictureBox pictureBoxSeperatorBAN;
		private System.Windows.Forms.PictureBox pictureBoxSeperato;
		private System.Windows.Forms.PictureBox pictureBoxSeperator;
		private System.Windows.Forms.TextBox TextBoxFilter;
		private System.Windows.Forms.Button buttonFilter;
	}
}
