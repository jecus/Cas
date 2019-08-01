using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.Users
{
	partial class ActivityListScreen
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
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.buttonExport = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelDateFrom = new System.Windows.Forms.Label();
			this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
			this.labelDateTo = new System.Windows.Forms.Label();
			this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
			this.buttonOK = new System.Windows.Forms.Button();
			this.headerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(1483, 58);
			this.headerControl.ShowPrintButton = false;
			this.headerControl.ShowSaveButton = false;
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Size = new System.Drawing.Size(1487, 456);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
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
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// labelDateFrom
			// 
			this.labelDateFrom.AutoSize = true;
			this.labelDateFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateFrom.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
			this.labelDateFrom.Location = new System.Drawing.Point(32, 35);
			this.labelDateFrom.Text = "From";
			// 
			// dateTimePickerDateFrom
			// 
			this.dateTimePickerDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			this.dateTimePickerDateFrom.ForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerDateFrom.BackColor = System.Drawing.Color.White;
			this.dateTimePickerDateFrom.Location = new System.Drawing.Point(80, 32);
			this.dateTimePickerDateFrom.Width = 100;
			this.dateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			// 
			// labelDateTo
			// 
			this.labelDateTo.AutoSize = true;
			this.labelDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			this.labelDateTo.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
			this.labelDateTo.Location = new System.Drawing.Point(190, 35);
			this.labelDateTo.Text = "To";
			// 
			// dateTimePickerDateTo
			// 
			this.dateTimePickerDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			this.dateTimePickerDateTo.ForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerDateTo.BackColor = System.Drawing.Color.White;
			this.dateTimePickerDateTo.Location = new System.Drawing.Point(220, 32);
			this.dateTimePickerDateTo.Width = 100;
			this.dateTimePickerDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			//
			// buttonOK
			//
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			this.buttonOK.ForeColor = System.Drawing.Color.DimGray;
			this.buttonOK.Location = new System.Drawing.Point(340, 30);
			this.buttonOK.Width = 70;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += ButtonOkClick;
			this.buttonOK.Enabled = !(userType == UsetType.ReadOnly);
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
			this.buttonExport.Click += ExportActivity_Click;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(124, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
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
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel1.Controls.Add(this.buttonExport);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this.labelDateFrom);
			this.panelTopContainer.Controls.Add(this.dateTimePickerDateFrom);
			this.panelTopContainer.Controls.Add(this.labelDateTo);
			this.panelTopContainer.Controls.Add(this.dateTimePickerDateTo);
			this.panelTopContainer.Controls.Add(this.buttonOK);
			// 
			// DocumentationListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Name = "DocumentationListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(1487, 634);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelDateFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
		private System.Windows.Forms.Label labelDateTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
		private System.Windows.Forms.Button buttonOK;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonExport;
		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
