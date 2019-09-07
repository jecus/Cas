using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.ComponentControls
{
	partial class ComponentsFleetListScreen
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
			var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorEx = new System.Windows.Forms.PictureBox();
			this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonExport = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.buttonPreTransferFilter = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.buttonTransferDetails = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.TextBoxFilter = new System.Windows.Forms.TextBox();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.headerControl.ShowForecastButton = true;
			this.headerControl.ShowPrintButton = true;
			this.headerControl.Size = new System.Drawing.Size(773, 58);
			this.headerControl.ForecastContextMenuClick += new System.EventHandler(this.ForecastMenuClick);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			this.headerControl.SaveButtonClick += new System.EventHandler(HeaderControlSaveButtonClick);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel1.Controls.Add(this.buttonExport);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorEx);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddNew);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox3);
			this.flowLayoutPanel1.Controls.Add(this.buttonTransferDetails);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox4);
			this.flowLayoutPanel1.Controls.Add(this.buttonPreTransferFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(530, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this.TextBoxFilter);
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
			this.buttonDeleteSelected.Location = new System.Drawing.Point(189, 0);
			this.buttonDeleteSelected.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.BottomLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(181, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
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
			this.buttonExport.TabIndex = 19;
			this.buttonExport.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonExport.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonExport.TextMain = "";
			this.buttonExport.TextSecondary = "";
			this.buttonExport.ToolTipText = "Export";
			this.buttonExport.Click += new System.EventHandler(this.ButtonExportComponent_Click);
			// 
			// buttonAddNew
			// 
			this.buttonAddNew.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddNew.ActiveBackgroundImage = null;
			this.buttonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddNew.Displayer = null;
			this.buttonAddNew.DisplayerText = "";
			this.buttonAddNew.Entity = null;
			this.buttonAddNew.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.buttonAddNew.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddNew.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.buttonAddNew.Location = new System.Drawing.Point(126, 0);
			this.buttonAddNew.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.Name = "buttonAddNew";
			this.buttonAddNew.NormalBackgroundImage = null;
			this.buttonAddNew.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.buttonAddNew.ShowToolTip = true;
			this.buttonAddNew.Size = new System.Drawing.Size(52, 57);
			this.buttonAddNew.TabIndex = 19;
			this.buttonAddNew.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonAddNew.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonAddNew.TextMain = "";
			this.buttonAddNew.TextSecondary = "";
			this.buttonAddNew.ToolTipText = "Add New";
			this.buttonAddNew.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonAddDisplayerRequested);
			this.buttonAddNew.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(118, 3);
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
			this.buttonApplyFilter.Location = new System.Drawing.Point(63, 0);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// buttonPreTransferFilter
			// 
			this.buttonPreTransferFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonPreTransferFilter.ActiveBackgroundImage = null;
			this.buttonPreTransferFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPreTransferFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonPreTransferFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonPreTransferFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonPreTransferFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonPreTransferFilter.Icon = global::CAS.UI.Properties.Resources.PreTransfer;
			this.buttonPreTransferFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonPreTransferFilter.IconNotEnabled = null;
			this.buttonPreTransferFilter.Location = new System.Drawing.Point(63, 0);
			this.buttonPreTransferFilter.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPreTransferFilter.Name = "buttonApplyFilter";
			this.buttonPreTransferFilter.NormalBackgroundImage = null;
			this.buttonPreTransferFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonPreTransferFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonPreTransferFilter.ShowToolTip = true;
			this.buttonPreTransferFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonPreTransferFilter.TabIndex = 18;
			this.buttonPreTransferFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPreTransferFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPreTransferFilter.TextMain = "";
			this.buttonPreTransferFilter.TextSecondary = "";
			this.buttonPreTransferFilter.ToolTipText = "Apply filter";
			this.buttonPreTransferFilter.Click += ButtonPreTransferFilter_Click;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox3.Location = new System.Drawing.Point(55, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(5, 50);
			this.pictureBox3.TabIndex = 22;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox4.Location = new System.Drawing.Point(55, 3);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(5, 50);
			this.pictureBox4.TabIndex = 22;
			this.pictureBox4.TabStop = false;
			// 
			// buttonTransferDetails
			// 
			this.buttonTransferDetails.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonTransferDetails.ActiveBackgroundImage = null;
			this.buttonTransferDetails.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonTransferDetails.Enabled = false;
			this.buttonTransferDetails.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonTransferDetails.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonTransferDetails.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonTransferDetails.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonTransferDetails.Icon = global::CAS.UI.Properties.Resources.TransferComponentRed;
			this.buttonTransferDetails.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonTransferDetails.IconNotEnabled = global::CAS.UI.Properties.Resources.TransferComponentGray;
			this.buttonTransferDetails.Location = new System.Drawing.Point(0, 0);
			this.buttonTransferDetails.Margin = new System.Windows.Forms.Padding(0);
			this.buttonTransferDetails.Name = "buttonTransferDetails";
			this.buttonTransferDetails.NormalBackgroundImage = null;
			this.buttonTransferDetails.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonTransferDetails.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonTransferDetails.ShowToolTip = true;
			this.buttonTransferDetails.Size = new System.Drawing.Size(52, 57);
			this.buttonTransferDetails.TabIndex = 18;
			this.buttonTransferDetails.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTransferDetails.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTransferDetails.TextMain = "";
			this.buttonTransferDetails.TextSecondary = "";
			this.buttonTransferDetails.ToolTipText = "Transfered Components";
			this.buttonTransferDetails.Click += new System.EventHandler(this.ButtonTransferedDetailsClick);
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
			this.labelDateAsOf.Location = new System.Drawing.Point(43, 24);
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
			// DetailsListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "ComponentsFleetListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(777, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonExport;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNew;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private AvControls.AvButtonT.AvButtonT buttonPreTransferFilter;
		private AvControls.AvButtonT.AvButtonT buttonTransferDetails;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorEx;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.TextBox TextBoxFilter;
		private System.Windows.Forms.Button buttonFilter;
	}
}
