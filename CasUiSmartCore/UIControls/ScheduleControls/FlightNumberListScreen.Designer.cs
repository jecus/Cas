
using System;
using System.Web.UI.WebControls;

namespace CAS.UI.UIControls.ScheduleControls
{
    partial class FlightNumberListScreen
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
			this.labelDateAsOf = new System.Windows.Forms.Label();
	        this.isSummerRadioButton = new System.Windows.Forms.RadioButton();
	        this.isWinterRadioButton = new System.Windows.Forms.RadioButton();
	        this.isAllRadioButton = new System.Windows.Forms.RadioButton();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
	        this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
	        this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
	        this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
	        this.pictureBox1 = new System.Windows.Forms.PictureBox();
	        this.pictureBox2 = new System.Windows.Forms.PictureBox();
	        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
	        this.labelDateFrom = new System.Windows.Forms.Label();
	        this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
	        this.labelDateTo = new System.Windows.Forms.Label();
	        this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
	        this._statusImageLinkLabel1 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
	        this.flowLayoutPanel1.SuspendLayout();
	        this.SuspendLayout();

	        // 
	        // panel1
	        // 
	        this.panel1.Location = new System.Drawing.Point(0, 129);
	        this.panel1.Size = new System.Drawing.Size(917, 413);
	        // 
	        // aircraftHeaderControl1
	        //
	        this.aircraftHeaderControl1.ChildClickable = true;
	        this.aircraftHeaderControl1.OperatorClickable = true;
	        this.aircraftHeaderControl1.NextClickable = true;
	        this.aircraftHeaderControl1.PrevClickable = true;
	        // 
	        // headerControl
	        // 
	        this.headerControl.Size = new System.Drawing.Size(985, 58);
	        this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
	        this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
	        this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
	        this.panelTopContainer.Controls.Add(this._statusImageLinkLabel1);
	        this.panelTopContainer.Controls.Add(this.isAllRadioButton);
	        this.panelTopContainer.Controls.Add(this.isSummerRadioButton);
	        this.panelTopContainer.Controls.Add(this.isWinterRadioButton);
			this.panelTopContainer.Controls.Add(this.labelDateFrom);
	        this.panelTopContainer.Controls.Add(this.dateTimePickerDateFrom);
	        this.panelTopContainer.Controls.Add(this.labelDateTo);
	        this.panelTopContainer.Controls.Add(this.dateTimePickerDateTo);
	        this.panelTopContainer.Controls.Add(this.buttonOK);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
	        // 
	        // _statusImageLinkLabel1
	        // 
	        this._statusImageLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
	        this._statusImageLinkLabel1.Displayer = null;
	        this._statusImageLinkLabel1.DisplayerText = null;
	        this._statusImageLinkLabel1.Entity = null;
	        this._statusImageLinkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
	        this._statusImageLinkLabel1.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
	        this._statusImageLinkLabel1.ImageBackColor = System.Drawing.Color.Transparent;
	        this._statusImageLinkLabel1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
	        this._statusImageLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
	        this._statusImageLinkLabel1.LinkMouseCapturedColor = System.Drawing.Color.Empty;
	        this._statusImageLinkLabel1.Location = new System.Drawing.Point(28, 3);
	        this._statusImageLinkLabel1.Margin = new System.Windows.Forms.Padding(0);
	        this._statusImageLinkLabel1.Name = "_statusImageLinkLabel1";
	        this._statusImageLinkLabel1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
	        this._statusImageLinkLabel1.Size = new System.Drawing.Size(100, 27);
	        this._statusImageLinkLabel1.Status = AvControls.Statuses.Pending;
	        this._statusImageLinkLabel1.TabIndex = 16;
	        this._statusImageLinkLabel1.Text = "Track";
	        this._statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	        this._statusImageLinkLabel1.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
	        this._statusImageLinkLabel1.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkTripDisplayerRequested);
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
			// isSummerRadioButton
			// 
			this.isSummerRadioButton.AutoSize = true;
	        this.isSummerRadioButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.isSummerRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.isSummerRadioButton.Location = new System.Drawing.Point(190, 3);
	        this.isSummerRadioButton.Name = "radioButton1";
	        this.isSummerRadioButton.TabIndex = 25;
	        this.isSummerRadioButton.Text = "Summer";
	        this.isSummerRadioButton.UseVisualStyleBackColor = true;
			this.isSummerRadioButton.Click += RadioButtonOnClick;
			// 
			// isWinterRadioButton
			// 
			this.isWinterRadioButton.AutoSize = true;
	        this.isWinterRadioButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.isWinterRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.isWinterRadioButton.Location = new System.Drawing.Point(270, 3);
	        this.isWinterRadioButton.Name = "radioButton1";
	        this.isWinterRadioButton.TabIndex = 25;
	        this.isWinterRadioButton.Text = "Winter";
	        this.isWinterRadioButton.UseVisualStyleBackColor = true;
	        this.isWinterRadioButton.Click += RadioButtonOnClick;
			// 
			// isAllRadioButton
			// 
			this.isAllRadioButton.AutoSize = true;
	        this.isAllRadioButton.Checked = true;
			this.isAllRadioButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.isAllRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.isAllRadioButton.Location = new System.Drawing.Point(145, 3);
	        this.isAllRadioButton.Name = "radioButton1";
	        this.isAllRadioButton.TabIndex = 25;
	        this.isAllRadioButton.Text = "All";
	        this.isAllRadioButton.UseVisualStyleBackColor = true;
	        this.isAllRadioButton.Click += RadioButtonOnClick;
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
	        this.buttonApplyFilter.Click += ButtonApplyFilterClick;
	        // 
	        // buttonAddNew
	        // 
	        this.buttonAddNew.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
	        this.buttonAddNew.ActiveBackgroundImage = null;
	        this.buttonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
	        this.buttonAddNew.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
	        this.buttonAddNew.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
	        this.buttonAddNew.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
	        this.buttonAddNew.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
	        this.buttonAddNew.Icon = global::CAS.UI.Properties.Resources.AddIcon;
	        this.buttonAddNew.IconLayout = System.Windows.Forms.ImageLayout.Center;
	        this.buttonAddNew.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
	        this.buttonAddNew.Location = new System.Drawing.Point(66, 0);
	        this.buttonAddNew.Name = "buttonAddDocument";
	        this.buttonAddNew.NormalBackgroundImage = null;
	        this.buttonAddNew.ShowToolTip = true;
	        this.buttonAddNew.Size = new System.Drawing.Size(52, 57);
	        this.buttonAddNew.TabIndex = 0;
	        this.buttonAddNew.TextMain = "";
	        this.buttonAddNew.TextSecondary = "";
	        this.buttonAddNew.ToolTipText = "Add new";
	        this.buttonAddNew.DisplayerRequested += ButtonAddDisplayerRequested;
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
	        this.buttonDeleteSelected.Location = new System.Drawing.Point(135, 0);
	        this.buttonDeleteSelected.Name = "buttonDeleteSelected";
	        this.buttonDeleteSelected.NormalBackgroundImage = null;
	        this.buttonDeleteSelected.ShowToolTip = true;
	        this.buttonDeleteSelected.Size = new System.Drawing.Size(52, 57);
	        this.buttonDeleteSelected.TabIndex = 20;
	        this.buttonDeleteSelected.TextMain = "";
	        this.buttonDeleteSelected.TextSecondary = "";
	        this.buttonDeleteSelected.ToolTipText = "Delete selected";
	        this.buttonDeleteSelected.Click += ButtonDeleteClick;
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
	        // flowLayoutPanel1
	        // 
	        this.flowLayoutPanel1.AutoSize = true;
	        this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
	        this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
	        this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
	        this.flowLayoutPanel1.Controls.Add(this.buttonAddNew);
	        this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
	        this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
	        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
	        this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
	        this.flowLayoutPanel1.Location = new System.Drawing.Point(1291, 0);
	        this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
	        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
	        this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
	        this.flowLayoutPanel1.TabIndex = 3;
	        this.flowLayoutPanel1.WrapContents = false;
			// 
			// FlightNumberListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.Name = "FlightNumberListScreen";
	        this.ShowAircraftStatusPanel = false;
	        this.Size = new System.Drawing.Size(917, 590);
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
	        this.flowLayoutPanel1.ResumeLayout(false);
	        this.ResumeLayout(false);
	        this.PerformLayout();

		}


	    private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
	    private System.Windows.Forms.RadioButton isSummerRadioButton;
	    private System.Windows.Forms.RadioButton isWinterRadioButton;
	    private System.Windows.Forms.RadioButton isAllRadioButton;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNew;
	    private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
	    private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
	    private System.Windows.Forms.Label labelDateAsOf;
	    private System.Windows.Forms.PictureBox pictureBox1;
	    private System.Windows.Forms.PictureBox pictureBox2;
	    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

	    private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel1;

		private System.Windows.Forms.Label labelDateFrom;
	    private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
	    private System.Windows.Forms.Label labelDateTo;
	    private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
	    private System.Windows.Forms.Button buttonOK;

		#endregion
	}
}
