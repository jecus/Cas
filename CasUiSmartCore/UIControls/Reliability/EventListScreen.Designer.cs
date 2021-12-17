using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.Discrepancies
{
    partial class EventListScreen
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
            this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.pictureBoxSeparatorBD = new System.Windows.Forms.PictureBox();
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
            this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
	        this.labelDateFrom = new System.Windows.Forms.Label();
	        this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
	        this.labelDateTo = new System.Windows.Forms.Label();
	        this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
	        this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Size = new System.Drawing.Size(917, 413);
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(950, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowForecastButton = false;
            this.headerControl.ShowNoForecastMenuItem = true;
            this.headerControl.ForecastContextMenuClick += ForecastMenuClick;
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
            this.panelTopContainer.Controls.Add(this.labelDateAsOf);
	        this.panelTopContainer.Controls.Add(this.labelDateFrom);
	        this.panelTopContainer.Controls.Add(this.dateTimePickerDateFrom);
	        this.panelTopContainer.Controls.Add(this.labelDateTo);
	        this.panelTopContainer.Controls.Add(this.dateTimePickerDateTo);
	        this.panelTopContainer.Controls.Add(this.buttonOK);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorBD);
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


			// 
			// labelTitle
			// 
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.Enabled = false;
            this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelTitle.Location = new System.Drawing.Point(28, 3);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Size = new System.Drawing.Size(600, 27);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // labelDateAsOf
            // 
            this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
            this.labelDateAsOf.Location = new System.Drawing.Point(57, 30);
            this.labelDateAsOf.Size = new System.Drawing.Size(47, 19);
            this.labelDateAsOf.TabIndex = 21;
            this.labelDateAsOf.Name = "_labelDateAsOf";
            // 
            // RequestForQuotationListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RequestForQuotationListScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
        private System.Windows.Forms.PictureBox pictureBoxSeparatorBD;
        private System.Windows.Forms.Label labelDateAsOf;
	    private System.Windows.Forms.Label labelDateFrom;
	    private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
	    private System.Windows.Forms.Label labelDateTo;
	    private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
	    private System.Windows.Forms.Button buttonOK;
	}
}
